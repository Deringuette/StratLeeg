using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategicLegion.Models
{
    public class StrategyModel
    {
        public int StrategyId { get; set; }
        public int SubmitterId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public StrategyTypes StrategyType { get; set; }
        public int ReferenceId { get; set; }
        public bool IsPublic { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public enum StrategyTypes { Checklist=1, Image=2, Notepad=3, Whiteboard=4, Counter=5}

        public StrategyModel()
        {

        }
    }
}