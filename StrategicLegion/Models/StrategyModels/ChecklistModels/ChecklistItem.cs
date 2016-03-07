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

        [DisplayName("Item Name")]
        public String ChecklistItemName { get; set; }

        public bool IsChecked { get; set; }
    }
}