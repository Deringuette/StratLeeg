using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Counters
{
    public class DeleteCounterEntry : IDatabaseModel
    {
        public int CounterId { get; set; }
    }
}
