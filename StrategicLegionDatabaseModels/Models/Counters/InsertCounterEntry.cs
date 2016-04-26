﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Counters
{
    public class InsertCounterEntry : IDatabaseModel
    {
        public string CounterName { get; set; }

        public int CounterValue { get; set; }

        public string SubmitterName { get; set; }
    }
}
