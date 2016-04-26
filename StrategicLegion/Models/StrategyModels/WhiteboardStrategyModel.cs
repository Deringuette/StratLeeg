using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models
{
    public class WhiteboardModel
    {
        [Key]
        public int WhiteboardId { get; set; }

        [DisplayName("Whiteboard Name")]
        public string WhiteboardName { get; set; }

        public WhiteboardModel()
        {

        }
    }
}