using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade
{
    [ExcludeFromCodeCoverage]
    public class DatabaseConstants
    {
        public class Checklists
        {
            public static string GetAllChecklistEntries = "ChecklistSchema.GetAllChecklistEntries";

            public static string GetChecklistEntry = "ChecklistSchema.GetChecklistEntry";

            public static string InsertChecklistEntry = "ChecklistSchema.InsertChecklistEntry";

            public static string GetChecklistChildren = "ChecklistSchema.GetChecklistChildren";
        }

        public class ChecklistGroups
        {
            public static string GetAllChecklistGroupEntries = "ChecklistSchema.GetAllChecklistGroupEntries";

            public static string GetChecklistGroupEntry = "ChecklistSchema.GetChecklistGroupEntry";

            public static string InsertChecklistGroupEntry = "ChecklistSchema.InsertChecklistGroupEntry";

            public static string GetChecklistGroupChildren = "ChecklistSchema.GetChecklistGroupChildren";

            public static string UpdateChecklistGroupEntry = "ChecklistSchema.UpdateChecklistGroup";
        }

        public class ChecklistItems
        {
            public static string GetAllChecklistItemEntries = "ChecklistSchema.GetAllChecklistItemEntries";

            public static string GetChecklistItemEntry = "ChecklistSchema.GetChecklistItemEntry";

            public static string InsertChecklistItemEntry = "ChecklistSchema.InsertChecklistItemEntry";

            public static string UpdateChecklistItemEntry = "ChecklistSchema.UpdateChecklistItem";
        }
    }
}
