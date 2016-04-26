using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels
{
    public class ImageStrategyModel
    {
        [Key]
        public int ImageId { get; set; }

        [DisplayName("Image Name")]
        public int ImageName { get; set; }

        [DisplayName("Date Submitted")]
        public DateTime DateSubmitted { get; set; }

        [DisplayName("Submitter")]
        public String Submitter { get; set; }

        public ImageStrategyModel()
        {

        }
    }
}