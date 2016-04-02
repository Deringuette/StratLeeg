using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Checklists
{
    public class GetChecklistGroupEntryQuery : Query
    {
        public GetChecklistGroupEntryQuery() : base(DatabaseConstants.ChecklistGroups.GetChecklistGroupEntry)
        {

        }
    }
}
