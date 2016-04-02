using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Checklists
{
    public class GetChecklistEntry : IDatabaseModel
    {
        public int ChecklistId { get; set; }

        public string ChecklistName { get; set; }
    }
}
