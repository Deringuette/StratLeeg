using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Checklists
{
    public class InsertChecklistItemEntry : IDatabaseModel
    {
        public int ParentChecklistGroupId { get; set; }
    }
}