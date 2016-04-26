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
using System.Web.Routing;
using StrategicLegionDatabaseFacade.Communication;
using AutoMapper;

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class ChecklistGroupController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: ChecklistGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistGroup checklistGroup = db.ChecklistGroups.Find(id);
            if (checklistGroup == null)
            {
                return HttpNotFound();
            }
            return View(checklistGroup);
        }
        
        // GET: ChecklistGroups/Create
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

            foreach (GetChecklistGroupEntry currentGroup in checklistGroupEntries.ChecklistGroupEntries) {

                Mapper.CreateMap<GetChecklistGroupEntry, ChecklistGroup>();
                ChecklistGroup newChecklistGroup = Mapper.Map<ChecklistGroup>(currentGroup);
                checklist.ChecklistGroups.Add(newChecklistGroup);
            }

            if (checklist == null)
            {
                return HttpNotFound();
            }

            return View(checklist);
        }

        // POST: ChecklistGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                foreach (ChecklistGroup currentGroup in checklist.ChecklistGroups)
                {
                    UpdateChecklistGroupEntry updateChecklistGroup = new UpdateChecklistGroupEntry();
                    updateChecklistGroup.ChecklistGroupId = currentGroup.ChecklistGroupId;
                    updateChecklistGroup.GroupName = currentGroup.GroupName;

                    ICommandResult result = DatabaseRequestsFacade.Commands.UpdateChecklistGroupEntry(updateChecklistGroup);
                    int newGroupId = (int)result.Parameters["@ChecklistGroupId"].Value;
                    for (int currentItem = 0; currentItem < currentGroup.ItemCount; currentItem++)
                    {
                        InsertChecklistItemEntry newChecklistItemModel = new InsertChecklistItemEntry();
                        newChecklistItemModel.ParentChecklistGroupId = newGroupId;
                        DatabaseRequestsFacade.Commands.InsertChecklistItemEntry(newChecklistItemModel);
                    }
                }
                return RedirectToAction("Create", "ChecklistItem", new RouteValueDictionary(new { checklistId = checklist.ChecklistId }));
            }

            return View(checklist);
        }
        


        // GET: ChecklistGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistGroup checklistGroup = db.ChecklistGroups.Find(id);
            if (checklistGroup == null)
            {
                return HttpNotFound();
            }
            return View(checklistGroup);
        }

        // POST: ChecklistGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChecklistGroupName,ItemCount")] ChecklistGroup checklistGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklistGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checklistGroup);
        }

        // GET: ChecklistGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistGroup checklistGroup = db.ChecklistGroups.Find(id);
            if (checklistGroup == null)
            {
                return HttpNotFound();
            }
            return View(checklistGroup);
        }

        // POST: ChecklistGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChecklistGroup checklistGroup = db.ChecklistGroups.Find(id);
            db.ChecklistGroups.Remove(checklistGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
