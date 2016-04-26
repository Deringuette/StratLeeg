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

        public class Counters
        {
            public static string GetCounterEntry = "CounterSchema.GetCounterEntry";

            public static string GetAllUserCounterEntries = "CounterSchema.GetAllUserCounterEntries";

            public static string UpdateCounterEntry = "CounterSchema.UpdateCounterEntry";

            public static string DeleteCounterEntry = "CounterSchema.DeleteCounterEntry";

            public static string InsertCounterEntry = "CounterSchema.InsertCounterEntry";
        }

        public class Images
        {
            public static string GetImageEntry = "ImageSchema.GetImageEntry";

            public static string UpdateImageEntry = "ImageSchema.UpdateImageEntry";

            public static string DeleteImageEntry = "ImageSchema.DeleteImageEntry";

            public static string InsertImageEntry = "ImageSchema.InsertImageEntry";
        }

        public class Notepads
        {
            public static string GetNotepadEntry = "NotepadSchema.GetNotepadEntry";

            public static string GetAllUserNotepadEntries = "NotepadSchema.GetAllUserNotepadEntries";

            public static string UpdateNotepadEntry = "NotepadSchema.UpdateNotepadEntry";

            public static string DeleteNotepadEntry = "NotepadSchema.DeleteNotepadEntry";

            public static string InsertNotepadEntry = "NotepadSchema.InsertNotepadEntry";
        }

        public class Whiteboards
        {
            public static string GetWhiteboardEntry = "WhiteboardSchema.GetWhiteboardEntry";

            public static string GetAllUserWhiteboardEntries = "WhiteboardSchema.GetAllUserWhiteboardEntries";

            public static string UpdateWhiteboardEntry = "WhiteboardSchema.UpdateWhiteboardEntry";

            public static string DeleteWhiteboardEntry = "WhiteboardSchema.DeleteWhiteboardEntry";

            public static string InsertWhiteboardEntry = "WhiteboardSchema.InsertWhiteboardEntry";
        }
    }
}
