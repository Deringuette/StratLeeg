using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Whiteboards
{
    public class InsertWhiteboardEntryCommand : Command
    {
        public InsertWhiteboardEntryCommand() : base(DatabaseConstants.Whiteboards.InsertWhiteboardEntry)
        {

        }
    }
}
