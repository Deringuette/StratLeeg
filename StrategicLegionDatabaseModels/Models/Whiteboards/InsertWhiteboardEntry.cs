using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Whiteboards
{
    public class InsertWhiteboardEntry : IDatabaseModel
    {
        public string WhiteboardName { get; set; }
    }
}
