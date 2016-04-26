using StrategicLegionDatabaseFacade.Communication;
using StrategicLegionDatabaseModels.Models.Checklists;
using StrategicLegionDatabaseModels.Models.Counters;
using StrategicLegionDatabaseModels.Models.Images;
using StrategicLegionDatabaseModels.Models.Notepads;
using StrategicLegionDatabaseModels.Models.Whiteboards;

namespace StrategicLegionDatabaseFacade.Presentation
{
    public interface IDbCommands
    {
        ICommandResult InsertChecklistEntry(InsertChecklistEntry insertChecklistEntry);

        ICommandResult InsertChecklistGroupEntry(InsertChecklistGroupEntry insertChecklistGroupEntry);

        ICommandResult InsertChecklistItemEntry(InsertChecklistItemEntry insertChecklistItemEntry);

        ICommandResult UpdateChecklistGroupEntry(UpdateChecklistGroupEntry updateChecklistGroupEntry);

        ICommandResult UpdateChecklistItemEntry(UpdateChecklistItemEntry updateChecklistItemEntry);

        ICommandResult InsertCounterEntry(InsertCounterEntry insertCounterEntry);

        ICommandResult UpdateCounterEntry(UpdateCounterEntry updateCounterEntry);

        ICommandResult DeleteCounterEntry(DeleteCounterEntry deleteCounterEntry);

        ICommandResult InsertWhiteboardEntry(InsertWhiteboardEntry insertWhiteboardEntry);

        ICommandResult UpdateWhiteboardEntry(UpdateWhiteboardEntry updateWhiteboardEntry);

        ICommandResult DeleteWhiteboardEntry(DeleteWhiteboardEntry deleteWhiteboardEntry);

        ICommandResult InsertNotepadEntry(InsertNotepadEntry insertEntry);

        ICommandResult UpdateNotepadEntry(UpdateNotepadEntry updateEntry);

        ICommandResult DeleteNotepadEntry(DeleteNotepadEntry deleteEntry);

        ICommandResult InsertImageEntry(InsertImageEntry insertImageEntry);

        ICommandResult UpdateImageEntry(UpdateImageEntry updateImageEntry);
    }
}
