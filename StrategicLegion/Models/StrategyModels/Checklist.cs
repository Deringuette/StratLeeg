using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StrategicLegion.Models.StrategyModels.ChecklistModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StrategicLegion.Models
{
    public class Checklist
    {
        [Key]
        public int ChecklistId { get; set; }

        [DisplayName("Checklist Name")]
        public String ChecklistName { get; set; }

        public List<ChecklistGroup> ChecklistGroups;
    }
}