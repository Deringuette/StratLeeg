using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels.ChecklistModels
{
    public class ChecklistGroup
    {
        [Key]
        public int ChecklistGroupId { get; set; }

        [DisplayName("Group Name")]
        public String ChecklistGroupName { get; set; }

        public List<ChecklistItem> ItemsInGroup;
    }
}