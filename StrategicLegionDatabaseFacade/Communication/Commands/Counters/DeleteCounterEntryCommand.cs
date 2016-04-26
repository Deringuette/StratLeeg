using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Counters
{
    public class DeleteCounterEntryCommand : Command
    {
        public DeleteCounterEntryCommand() : base(DatabaseConstants.Counters.DeleteCounterEntry)
        {

        }
    }
}
