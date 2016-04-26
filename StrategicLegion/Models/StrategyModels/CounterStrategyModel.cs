using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels
{
    public class CounterStrategyModel
    {
        [Key]
        public int CounterId { get; set; }

        [DisplayName("Counter Name")]
        public string CounterName { get; set; }

        [DisplayName("Counter Value")]
        public int CounterValue { get; set; }

        [DisplayName("Submitter")]
        public string SubmitterName { get; set; }

        public CounterStrategyModel()
        {

        }
    }
}