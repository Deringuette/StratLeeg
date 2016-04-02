using System;
using System.Data;
using System.Data.SqlClient;

namespace StrategicLegionDatabaseFacade.Communication
{
    public class CommandResult : ICommandResult
    {
        public string ErrorMessage {
            get
            {
                if (Exception != null)
                {
                    return Exception.Message;
                }

                return "";
            }
        }

        public int RowsAffected { get; set; }
        public bool Success { get ; private set; }

        public Exception Exception
        {
            get { return m_exception; }
            set
            {
                Success = false;
                m_exception = value;
            }
        }

        public SqlParameterCollection Parameters { get; set; }

        private Exception m_exception;

        public CommandResult()
        {
            Success = true;
        }

        public CommandResult(int rowsAffected) :this()
        {
            RowsAffected = rowsAffected;
        }

        public DataTable Data { get; set; }
    }
}
