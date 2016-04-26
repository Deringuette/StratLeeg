using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Commands.Images
{
    public class UpdateImageEntryCommand : Command
    {
        public UpdateImageEntryCommand() : base(DatabaseConstants.Images.UpdateImageEntry)
        {

        }
    }
}
