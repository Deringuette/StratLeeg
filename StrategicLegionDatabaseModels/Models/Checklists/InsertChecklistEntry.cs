using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Checklists
{
    public class InsertChecklistEntry : IDatabaseModel
    {
        public String ChecklistName { get; set; }

        public String Submitter { get; set; }
    }
}
