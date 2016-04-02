using System;
using System.Data;
using System.Data.SqlClient;

namespace StrategicLegionDatabaseFacade.Communication
{
    public interface ICommandResult
    {
        SqlParameterCollection Parameters { get; set; }
        string ErrorMessage { get; }
        Exception Exception { get; set; }
        bool Success { get; }
        DataTable Data { get; set; }
    }
}
