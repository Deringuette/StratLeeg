using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategicLegionDatabaseModels.Models.Checklists;

namespace StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists
{
    public class GetMultipleChecklistsResponseModel
    {
        public IList<GetChecklistEntry> ChecklistEntries;
    }
}
