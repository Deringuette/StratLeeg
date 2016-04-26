using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Whiteboards
{
    public class GetWhiteboardEntryQuery : Query
    {
        public GetWhiteboardEntryQuery() : base(DatabaseConstants.Whiteboards.GetWhiteboardEntry)
        {

        }
    }
}
