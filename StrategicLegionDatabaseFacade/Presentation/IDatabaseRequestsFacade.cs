using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Presentation
{
    public interface IDatabaseRequestsFacade
    {
        IDbCommands Commands { get; }
        IDbQueries Queries { get; }

        string Connection { get; }
    }
}
