using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Checklists
{
    public class InsertChecklistEntryCommand : Command
    {
        public InsertChecklistEntryCommand()
            : base(DatabaseConstants.Checklists.InsertChecklistEntry)
        {

        }
    }
}
