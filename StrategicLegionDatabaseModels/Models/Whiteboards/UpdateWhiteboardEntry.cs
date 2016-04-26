using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Whiteboards
{
    public class UpdateWhiteboardEntry : IDatabaseModel
    {
        public int WhiteboardId { get; set; }

        public string WhiteboardName { get; set; }
    }
}
