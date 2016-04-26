using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StrategicLegion.Models;
using StrategicLegion.Models.StrategyModels.ChecklistModels;
using StrategicLegionDatabaseFacade.Presentation;
using StrategicLegionDatabaseModels.Models.Checklists;
using StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists;
using StrategicLegionDatabaseFacade.Communication;
using AutoMapper;

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class ChecklistItemController : BaseController
    {

       // GET: ChecklistItems/Create
       public ActionResult Create(int? checklistId)
       {
            if (checklistId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetChecklistEntry checklistEntry = DatabaseRequestsFacade.Queries.GetChecklistEntry((int)checklistId);
            GetMultipleChecklistGroupsResponseModel checklistGroupEntries = DatabaseRequestsFacade.Queries.GetChecklistChildrenQuery((int)checklistId);

            Mapper.CreateMap<GetChecklistEntry, Checklist>();
            Checklist checklist = Mapper.Map<Checklist>(checklistEntry);

            foreach (GetChecklistGroupEntry currentGroup in checklistGroupEntries.ChecklistGroupEntries)
            {

                Mapper.CreateMap<GetChecklistGroupEntry, ChecklistGroup>();
                ChecklistGroup newChecklistGroup = Mapper.Map<ChecklistGroup>(currentGroup);

                GetMultipleChecklistItemsResponseModel checklistItemEntries = DatabaseRequestsFacade.Queries.GetChecklistGroupChildrenQuery(newChecklistGroup.ChecklistGroupId);
                foreach (GetChecklistItemEntry currentItem in checklistItemEntries.ChecklistItemEntries)
                {
                    Mapper.CreateMap<GetChecklistItemEntry, ChecklistItem>();
                    ChecklistItem newChecklistItem = Mapper.Map<ChecklistItem>(currentItem);
                    newChecklistGroup.ItemsInGroup.Add(newChecklistItem);
                }
                newChecklistGroup.ItemCount = newChecklistGroup.ItemsInGroup.Count;
                checklist.ChecklistGroups.Add(newChecklistGroup);
            }

            if (checklist == null)
            {
                return HttpNotFound();
            }

            return View(checklist);
        }

       // POST: ChecklistItems/Create
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Create(Checklist checklist)
       {
            if (ModelState.IsValid)
            {
                IDatabaseRequestsFacade database = new DatabaseRequestsFacade();

                foreach (ChecklistGroup currentGroup in checklist.ChecklistGroups)
                {
                    foreach (ChecklistItem currentItem in currentGroup.ItemsInGroup)
                    {
                        UpdateChecklistItemEntry updateChecklistItem = new UpdateChecklistItemEntry();
                        updateChecklistItem.ChecklistItemId = currentItem.ChecklistItemId;
                        updateChecklistItem.ChecklistItemName = currentItem.ChecklistItemName;

                        ICommandResult result = database.Commands.UpdateChecklistItemEntry(updateChecklistItem);
                    }
                }
                return RedirectToAction("Index", "Checklist");
            }

            return View(checklist);
        }
    }
}
