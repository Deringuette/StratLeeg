using StrategicLegionDatabaseModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace StrategicLegionDatabaseFacade.Communication
{
    public class DatabaseRequest
    {
        private readonly Dictionary<string, object> m_parameters;
        private readonly Dictionary<string, SqlDbType> m_outputParameters;

       
        public string Name { get; set; }

        public DatabaseRequest(string name)
        {
            Name = name;
            m_parameters = new Dictionary<string, object>();
            m_outputParameters = new Dictionary<string, SqlDbType>();
        }

        public void BuildParamsRequest(IDatabaseModel model)
        {
            Type objType = model.GetType();
            foreach (PropertyInfo propInfo in objType.GetProperties())
            {
                AddParameter(propInfo.Name,propInfo.GetValue(model));
            }
        }


        public void AddOutputParameter(string paramName, SqlDbType type)
        {
            m_outputParameters.Add(paramName, type);
        }
        public void AddParameter(string paramName, object value)
        {
            if (value == null)
            {
                m_parameters.Add("@" + paramName, null);
            }
            else if (value.GetType().IsEnum)
            {
                m_parameters.Add("@" + paramName, value.GetType().FullName + "." + value);
            }
            else
            {
                m_parameters.Add("@" + paramName, value);
            }
        }

         public IEnumerable<KeyValuePair<string,object>> Parameters
        {
            get
            {
                return m_parameters.Keys.Select(key => new KeyValuePair<string, object>(key, m_parameters[key]));
            }
        }

         public IEnumerable<KeyValuePair<string, SqlDbType>> OutputParameters
         {
             get
             {
                 return m_outputParameters.Keys.Select(key => new KeyValuePair<string, SqlDbType>(key, m_outputParameters[key]));
             }
         }


    }
}
