using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Checklists
{
    public class GetChecklistGroupChildrenQuery : Query
    {
        public GetChecklistGroupChildrenQuery() : base(DatabaseConstants.ChecklistGroups.GetChecklistGroupChildren)
        {

        }
    }
}
