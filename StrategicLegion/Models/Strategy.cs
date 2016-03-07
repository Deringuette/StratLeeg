using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models
{
    public abstract class Strategy
    {
        public int StrategyId { get; set; }
        public String StrategyName { get; set; }
        public String GameName { get; set; }
        public String Submitter { get; set; }
    }
}