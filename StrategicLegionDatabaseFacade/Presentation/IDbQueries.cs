using StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists;
using StrategicLegionDatabaseModels.Models.Checklists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Presentation
{
    public interface IDbQueries
    {
        GetMultipleChecklistsResponseModel GetChecklistEntries();

        GetChecklistEntry GetChecklistEntry(int checklistEntryId);

        GetMultipleChecklistGroupsResponseModel GetChecklistChildrenQuery(int checklistId);

        GetChecklistGroupEntry GetChecklistGroupEntry(int checklistGroupEntryId);

        GetMultipleChecklistItemsResponseModel GetChecklistGroupChildrenQuery(int checklistGroupId);

        GetChecklistItemEntry GetChecklistItemEntry(int checklistItemEntryId);
    }
}
