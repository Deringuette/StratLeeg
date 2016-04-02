using StrategicLegion.Models.StrategyModels.ChecklistModels.ChecklistViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels.ChecklistModels
{
    public class ChecklistItem
    {
        [Key]
        public int ChecklistItemId { get; set; }

        public int ParentChecklistGroupId { get; set; }

        [DisplayName("Item Name")]
        public String ChecklistItemName { get; set; }

        public ChecklistItem()
        {
            this.ChecklistItemName = "";
        }

        public void UpdateChecklistGroup(ChecklistItemViewModel checklistItemViewModel)
        {
            this.ChecklistItemName = checklistItemViewModel.ItemName;
        }
    }
}