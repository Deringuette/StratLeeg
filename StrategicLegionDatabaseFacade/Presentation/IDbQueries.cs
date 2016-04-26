using StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists;
using StrategicLegionDatabaseModels.Models.Checklists;
using StrategicLegionDatabaseModels.Models.Counters;
using StrategicLegionDatabaseModels.Models.Images;
using StrategicLegionDatabaseModels.Models.Notepads;
using StrategicLegionDatabaseModels.Models.Whiteboards;

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

        GetCounterEntry GetCounterEntry(int counterId);

        GetImageEntry GetImageEntry(int imageId);

        GetWhiteboardEntry GetWhiteboardEntry(int whiteboardId);

        GetNotepadEntry GetNotepadEntry(int notepadId);
    }
}
