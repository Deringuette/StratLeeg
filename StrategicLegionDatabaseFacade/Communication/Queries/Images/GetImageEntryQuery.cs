using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.Queries.Images
{
    public class GetImageEntryQuery : Query
    {
        public GetImageEntryQuery() : base(DatabaseConstants.Images.GetImageEntry)
        {

        }
    }
}
