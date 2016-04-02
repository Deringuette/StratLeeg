using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Checklists
{
    public class GetChecklistItemEntryQuery : Query
    {
        public GetChecklistItemEntryQuery() : base(DatabaseConstants.ChecklistItems.GetChecklistItemEntry)
        {

        }
    }
}
