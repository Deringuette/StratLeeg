using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Checklists
{
    public class InsertCounterEntryCommand : Command
    {
        public InsertCounterEntryCommand()
            : base(DatabaseConstants.Counters.InsertCounterEntry)
        {

        }
    }
}
