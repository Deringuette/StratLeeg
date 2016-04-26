using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Notepads
{
    public class DeleteNotepadEntry : IDatabaseModel
    {
        public string NotepadId { get; set; }
    }
}
