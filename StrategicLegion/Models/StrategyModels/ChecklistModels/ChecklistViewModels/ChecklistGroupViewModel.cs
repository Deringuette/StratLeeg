using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels.ChecklistModels.ChecklistViewModels
{
    public class ChecklistGroupViewModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [Display(Name = "Group Name")]
        public String GroupName { get; set; }

        [Required]
        [Display(Name = "Number of Items in Group")]
        public int ItemCount { get; set; }
    }
}