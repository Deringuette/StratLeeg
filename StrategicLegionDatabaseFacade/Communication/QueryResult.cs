using System;
using System.Data;

namespace StrategicLegionDatabaseFacade.Communication
{
    public class QueryResult : IQueryResult
    {
        private Exception m_exception;

        public QueryResult()
        {
            Success = true;
        }

        public QueryResult(int rowsAffected) : this()
        {
            Success = true;
            RowsAffected = rowsAffected;
        }

        public int RowsAffected { get; set; }

        public DataTable Data { get; set; }

        public string ErrorMessage
        {
            get { return Exception.Message; }
        }

        public bool Success { get; private set; }

        public Exception Exception
        {
            get { return m_exception; }
            set
            {
                Success = false;
                m_exception = value;
            }
        }
    }
}