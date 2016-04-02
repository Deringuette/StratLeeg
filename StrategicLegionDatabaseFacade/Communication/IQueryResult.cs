using System;
using System.Data;

namespace StrategicLegionDatabaseFacade.Communication
{
    public interface IQueryResult
    {
        DataTable Data { get; set; }
        string ErrorMessage { get; }
        Exception Exception { get; set; }
        bool Success { get; }
    }
}
