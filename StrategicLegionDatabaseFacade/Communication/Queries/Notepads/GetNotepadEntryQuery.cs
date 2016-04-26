using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Notepads
{
    public class GetNotepadEntryQuery : Query
    {
        public GetNotepadEntryQuery() : base(DatabaseConstants.Notepads.GetNotepadEntry)
        {

        }
    }
}
