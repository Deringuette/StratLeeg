using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Notepads
{
    public class UpdateNotepadEntryCommand : Command
    {
        public UpdateNotepadEntryCommand() : base(DatabaseConstants.Notepads.UpdateNotepadEntry)
        {

        }
    }
}
