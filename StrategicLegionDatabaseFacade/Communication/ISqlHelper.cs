using System.Configuration;

namespace StrategicLegionDatabaseFacade.Communication
{
    public interface ISqlHelper
    {
        void EnsureConnectionOpened();

        CommandResult SendCommand(Command command);

        QueryResult SendQuery(Query query);

        string Greeting { get; }
    }
}
