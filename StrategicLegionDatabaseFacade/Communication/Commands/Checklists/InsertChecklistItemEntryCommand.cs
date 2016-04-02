using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Checklists
{
    public class InsertChecklistItemEntryCommand : Command
    {
        public InsertChecklistItemEntryCommand()
            : base(DatabaseConstants.ChecklistItems.InsertChecklistItemEntry)
        {

        }
    }
}
