using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Counters
{
    public class GetCounterEntryQuery : Query
    {
        public GetCounterEntryQuery() : base(DatabaseConstants.Counters.GetCounterEntry)
        {

        }
    }
}
