using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Notepads
{
    public class UpdateNotepadEntry : IDatabaseModel
    {
        public string NotepadId { get; set; }

        public string NotepadName { get; set; }

        public string NotepadContent { get; set; }
    }
}
