using System;

namespace StrategicLegionDatabaseFacade.Communication
{
    public interface IQueryResultParser
    {
        object ParseMultipleRecords(System.Data.DataTable data, Type modelType);
        object ParseSingleRecord(System.Data.DataTable data, Type modelType);
    }
}
