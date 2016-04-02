using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StrategicLegionDatabaseFacade.Communication
{
    public class SqlHelper : ISqlHelper
    {
        private SqlConnection SqlConnection;

        private readonly string ConnectionString;

        public SqlHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }


        public void EnsureConnectionOpened()
        {
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
        }

        public CommandResult SendCommand(Command command)
        {
            CommandResult commandResult;

            try
            {
                using (SqlConnection = new SqlConnection(ConnectionString))
                {
                    using (var sqlCmd = new SqlCommand(command.Name, SqlConnection))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;


                        foreach (KeyValuePair<string, object> pair in command.Parameters)
                        {
                            sqlCmd.Parameters.AddWithValue(pair.Key, pair.Value);
                        }

                        foreach (KeyValuePair<string, SqlDbType> pair in command.OutputParameters)
                        {
                            sqlCmd.Parameters.Add(pair.Key, pair.Value).Direction = ParameterDirection.Output;
                        }

                        EnsureConnectionOpened();

                        return commandResult = new CommandResult(sqlCmd.ExecuteNonQuery())
                        {
                            Parameters = sqlCmd.Parameters
                        };
                    }
                }
            }
            catch (Exception e)
            {
                commandResult = new CommandResult(0)
                {
                    Exception = e
                };
            }

            return commandResult;
        }



        public QueryResult SendQuery(Query query)
        {
            QueryResult queryResult;
            DataSet dataResult = new DataSet();

            try
            {
                using (SqlConnection = new SqlConnection(ConnectionString))
                {
                    using (var sqlCmd = new SqlCommand(query.Name, SqlConnection))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;


                        foreach (KeyValuePair<string, object> pair in query.Parameters)
                        {

                            sqlCmd.Parameters.AddWithValue(pair.Key, pair.Value);
                        }



                        EnsureConnectionOpened();

                        using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
                        {

                           queryResult = new QueryResult(sda.Fill(dataResult, "Results"));
                           
                        }

                        queryResult.Data = dataResult.Tables[0];
                    }
                }
            }
            catch (Exception e)
            {
                queryResult = new QueryResult(0)
                {
                    Exception = e
                };
            }

            return queryResult;
        }

        public string Greeting { get { return this.ConnectionString; } }
    }
}