using StrategicLegion.Models.StrategyModels.ChecklistModels.ChecklistViewModels;
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

        public int ParentChecklistId { get; set; }

        [DisplayName("Group Name")]
        public String GroupName { get; set; }

        [DisplayName("Number of Items")]
        public int ItemCount { get; set; }

        public List<ChecklistItem> ItemsInGroup { get; set; }

        public ChecklistGroup()
        {
            ItemsInGroup = new List<ChecklistItem>();
        }
    }
}