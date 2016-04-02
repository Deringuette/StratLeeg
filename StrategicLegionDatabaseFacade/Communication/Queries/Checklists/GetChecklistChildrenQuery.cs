using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Checklists
{
    public class GetChecklistChildrenQuery : Query
    {
        public GetChecklistChildrenQuery() : base(DatabaseConstants.Checklists.GetChecklistChildren)
        {

        }
    }
}
