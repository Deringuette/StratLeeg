using System.Diagnostics.CodeAnalysis;

namespace StrategicLegionDatabaseFacade.Communication
{
    [ExcludeFromCodeCoverage]
    public class Command : DatabaseRequest
    {        
     
        public Command(string name) : base(name)
        {
            
        }
    }
}
