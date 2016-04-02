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

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class ChecklistItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChecklistItems
        public ActionResult Index()
        {
            return View(db.ChecklistItems.ToList());
        }

        // GET: ChecklistItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistItem checklistItem = db.ChecklistItems.Find(id);
            if (checklistItem == null)
            {
                return HttpNotFound();
            }
            return View(checklistItem);
        }


        

       // GET: ChecklistItems/Create
       public ActionResult Create(int? checklistId)
       {
            if (checklistId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IDatabaseRequestsFacade database = new DatabaseRequestsFacade();

            GetChecklistEntry checklistEntry = database.Queries.GetChecklistEntry((int)checklistId);
            GetMultipleChecklistGroupsResponseModel checklistGroupEntries = database.Queries.GetChecklistChildrenQuery((int)checklistId);

            Checklist checklist = new Checklist();
            checklist.ChecklistName = checklistEntry.ChecklistName;
            checklist.ChecklistId = checklistEntry.ChecklistId;

            foreach (GetChecklistGroupEntry currentGroup in checklistGroupEntries.ChecklistGroupEntries)
            {
                ChecklistGroup newChecklistGroup = new ChecklistGroup();
                newChecklistGroup.ChecklistGroupId = currentGroup.ChecklistGroupId;
                newChecklistGroup.ParentChecklistId = currentGroup.ParentChecklistId;
                newChecklistGroup.GroupName = currentGroup.GroupName;
                GetMultipleChecklistItemsResponseModel checklistItemEntries = database.Queries.GetChecklistGroupChildrenQuery(newChecklistGroup.ChecklistGroupId);
                foreach (GetChecklistItemEntry currentItem in checklistItemEntries.ChecklistItemEntries)
                {
                    ChecklistItem newChecklistItem = new ChecklistItem();
                    newChecklistItem.ChecklistItemId = currentItem.ChecklistItemId;
                    newChecklistItem.ParentChecklistGroupId = currentItem.ParentChecklistGroupId;
                    newChecklistItem.ChecklistItemName = currentItem.ChecklistItemName;
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
       


        // GET: ChecklistItems/Edit/5
        public ActionResult Edit(int id)
        {
            IDatabaseRequestsFacade database = new DatabaseRequestsFacade();

            GetChecklistEntry checklistEntry = database.Queries.GetChecklistEntry(id);
            GetMultipleChecklistGroupsResponseModel checklistGroupEntries = database.Queries.GetChecklistChildrenQuery(id);

            Checklist checklist = new Checklist();
            checklist.ChecklistGroups = AutoMapper.Mapper.Map<IList<GetChecklistGroupEntry>, IList<ChecklistGroup>>(checklistGroupEntries.ChecklistGroupEntries);
            ChecklistItem checklistItem = db.ChecklistItems.Find(id);

            if (checklistItem == null)
            {
                return HttpNotFound();
            }
            return View(checklistItem);
        }

        // POST: ChecklistItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChecklistItemName")] ChecklistItem checklistItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklistItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checklistItem);
        }

        // GET: ChecklistItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChecklistItem checklistItem = db.ChecklistItems.Find(id);
            if (checklistItem == null)
            {
                return HttpNotFound();
            }
            return View(checklistItem);
        }

        // POST: ChecklistItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChecklistItem checklistItem = db.ChecklistItems.Find(id);
            db.ChecklistItems.Remove(checklistItem);
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
