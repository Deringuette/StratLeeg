using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Whiteboards
{
    public class DeleteWhiteboardEntryCommand : Command
    {
        public DeleteWhiteboardEntryCommand() : base(DatabaseConstants.Whiteboards.DeleteWhiteboardEntry)
        {

        }
    }
}
