using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Images
{
    public class InsertImageEntryCommand : Command
    {
        public InsertImageEntryCommand() : base(DatabaseConstants.Images.InsertImageEntry)
        {

        }
    }
}
