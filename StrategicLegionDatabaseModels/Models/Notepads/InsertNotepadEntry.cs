using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Notepads
{
    public class InsertNotepadEntry : IDatabaseModel
    {
        public string NotepadName { get; set; }

        public string NotepadContent { get; set; }
    }
}
