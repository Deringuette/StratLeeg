﻿using StrategicLegionDatabaseModels.Models.Checklists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists
{
    public class GetMultipleChecklistItemsResponseModel
    {
        public IList<GetChecklistItemEntry> ChecklistItemEntries;
    }
}
