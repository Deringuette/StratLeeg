using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models.StrategyModels
{
    public class NotepadStrategyModel
    {
        [Key]
        public string NotepadId { get; set; }

        [DisplayName("Notepad Name")]
        public string NotepadName { get; set; }

        [DisplayName("Content")]
        public string NotepadContent { get; set; }

        public NotepadStrategyModel()
        {

        }
    }
}