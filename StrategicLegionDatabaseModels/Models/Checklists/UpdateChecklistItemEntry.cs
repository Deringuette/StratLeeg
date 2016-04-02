using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Checklists
{
    public class UpdateChecklistItemEntry : IDatabaseModel
    {
        public int ChecklistItemId { get; set; }

        public string ChecklistItemName { get; set; }
    }
}
