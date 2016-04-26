using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Whiteboards
{
    public class UpdateWhiteboardEntryCommand : Command
    {
        public UpdateWhiteboardEntryCommand() : base(DatabaseConstants.Whiteboards.UpdateWhiteboardEntry)
        {

        }
    }
}
