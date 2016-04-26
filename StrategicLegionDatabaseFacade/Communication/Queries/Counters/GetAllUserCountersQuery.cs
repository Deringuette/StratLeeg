using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Counters
{
    public class GetAllUserCountersQuery : Query
    {
        public GetAllUserCountersQuery() : base(DatabaseConstants.Counters.GetAllUserCounterEntries)
        {

        }
    }
}
