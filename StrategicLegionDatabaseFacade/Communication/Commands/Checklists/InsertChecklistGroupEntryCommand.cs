using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Checklists
{
    public class InsertChecklistGroupEntryCommand : Command
    {
        public InsertChecklistGroupEntryCommand()
            : base(DatabaseConstants.ChecklistGroups.InsertChecklistGroupEntry)
        {

        }
    }
}
