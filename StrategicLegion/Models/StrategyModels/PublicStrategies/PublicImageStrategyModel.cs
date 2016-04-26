using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels.PublicStrategies
{
    public class PublicImageStrategyModel
    {
        public int ImageId { get; set; }

        public int ImageName { get; set; }

        public DateTime DateSubmitted { get; set; }

        public String Submitter { get; set; }

        public PublicImageStrategyModel()
        {

        }
    }
}