using System.Diagnostics.CodeAnalysis;

namespace StrategicLegionDatabaseFacade.Communication
{
    [ExcludeFromCodeCoverage]
    public class Query : DatabaseRequest
    {
        public Query(string name) : base(name)
        {
        }
    }
}
