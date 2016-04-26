using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseModels.Models.Images
{
    public class UpdateImageEntry : IDatabaseModel
    {
        public int ImageId { get; set; }

        public int ImageName { get; set; }

        public DateTime DateSubmitted { get; set; }

        public String Submitter { get; set; }
    }
}
