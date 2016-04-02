using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Checklists
{
    public class InsertChecklistGroupEntry : IDatabaseModel
    {
        public int ParentChecklistId { get; set; }
    }
}