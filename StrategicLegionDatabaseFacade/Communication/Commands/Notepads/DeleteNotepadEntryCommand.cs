using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Notepads
{
    public class DeleteNotepadEntryCommand : Command
    {
        public DeleteNotepadEntryCommand() : base(DatabaseConstants.Notepads.DeleteNotepadEntry)
        {

        }
    }
}
