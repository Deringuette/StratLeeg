using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels.ChecklistModels.ChecklistViewModels
{
    public class ChecklistViewModel
    {
        [DisplayName("Checklist Name")]
        public String ChecklistName { get; set; }

        [DisplayName("Number of Groups")]
        public int GroupCount { get; set; }
    }
}