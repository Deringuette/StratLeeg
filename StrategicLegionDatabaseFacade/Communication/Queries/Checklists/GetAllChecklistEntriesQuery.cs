using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Checklists
{
    public class GetAllChecklistEntriesQuery : Query
    {
        public GetAllChecklistEntriesQuery() : base(DatabaseConstants.Checklists.GetAllChecklistEntries)
        {

        }
    }
}
