using StrategicLegionDatabaseFacade.Communication;
using StrategicLegionDatabaseModels.Models.Checklists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Presentation
{
    public interface IDbCommands
    {
        ICommandResult InsertChecklistEntry(InsertChecklistEntry insertChecklistEntry);

        ICommandResult InsertChecklistGroupEntry(InsertChecklistGroupEntry insertChecklistGroupEntry);

        ICommandResult InsertChecklistItemEntry(InsertChecklistItemEntry insertChecklistItemEntry);

        ICommandResult UpdateChecklistGroupEntry(UpdateChecklistGroupEntry updateChecklistGroupEntry);

        ICommandResult UpdateChecklistItemEntry(UpdateChecklistItemEntry updateChecklistItemEntry);
    }
}
