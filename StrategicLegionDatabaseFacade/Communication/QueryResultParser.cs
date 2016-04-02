using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;

namespace StrategicLegionDatabaseFacade.Communication
{
    public class QueryResultParser : IQueryResultParser
    {
        public object ParseMultipleRecords(DataTable data, Type modelType)
        {

            if (data == null)
            {
                return null;
            } 
            
            IList records = (IList) Activator.CreateInstance(
            typeof(List<>).MakeGenericType(modelType));

            foreach (DataRow row in data.Rows)
            {
                object record = Activator.CreateInstance(modelType);
                
                foreach (DataColumn column in data.Columns)
                {
                    PropertyInfo propertyInfo = modelType.GetProperty(column.ColumnName);
                    
                    // If the property exists in the model
                    if (propertyInfo == null || propertyInfo.GetSetMethod() == null)
                    {
                        continue;
                    }

                    object value = row[column];
                    Type propertyType = propertyInfo.PropertyType;
                    
                    if (propertyType.IsEnum)
                    {
                        object eValue = Enum.Parse(propertyType, value.ToString().Split('.').Last());
                        {
                            propertyInfo.SetValue(record, eValue, null);
                        }
                    }
                    else
                    {

                        if (value == DBNull.Value && IsNullable(propertyType))
                        {
                            propertyInfo.SetValue(record, null, null);

                        }
                        else if (value == DBNull.Value)
                        {
                            propertyInfo.SetValue(record, Activator.CreateInstance(propertyType), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(record, row[column], null);
                        }
                    }
                }

                records.Add(record);
            }
            return records;
        }

        public object ParseSingleRecord(DataTable data, Type modelType)
        {
            if (data == null)
            {
                return null;
            }
             
            object record = Activator.CreateInstance(modelType);

            foreach (DataColumn column in data.Columns)
            {
                PropertyInfo propertyInfo = modelType.GetProperty(column.ColumnName);

                // If the property exists in the model
                if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                {

                    Type propertyType = propertyInfo.PropertyType;
                    if (propertyType.IsEnum)
                    {
                        object eValue = Enum.Parse(propertyType, data.Rows[0][column].ToString().Split('.').Last());
                        {
                            propertyInfo.SetValue(record, eValue, null);
                        }
                    }
                    else
                    {
                        if (data.Rows[0][column] == DBNull.Value && propertyInfo.PropertyType == typeof(int?))
                        {
                            propertyInfo.SetValue(record, null, null);
                        }
                        else
                        {
                            propertyInfo.SetValue(record, data.Rows[0][column], null);
                        }
                    }
                }
            }

            return record;
        }

        private bool IsNullable(Type type)
        {

            return (type == typeof(String) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }
    }
}
