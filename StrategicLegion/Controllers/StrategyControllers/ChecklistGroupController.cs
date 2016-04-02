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

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class ChecklistGroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChecklistGroups
        public ActionResult Index()
        {
            return View(db.ChecklistGroups.ToList());
        }

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

            IDatabaseRequestsFacade database = new DatabaseRequestsFacade();

            GetChecklistEntry checklistEntry = database.Queries.GetChecklistEntry((int)checklistId);
            GetMultipleChecklistGroupsResponseModel checklistGroupEntries = database.Queries.GetChecklistChildrenQuery((int)checklistId);

            Checklist checklist = new Checklist();
            checklist.ChecklistName = checklistEntry.ChecklistName;
            checklist.ChecklistId = checklistEntry.ChecklistId;

            foreach (GetChecklistGroupEntry currentGroup in checklistGroupEntries.ChecklistGroupEntries) {
                ChecklistGroup newChecklistGroup = new ChecklistGroup();
                newChecklistGroup.ChecklistGroupId = currentGroup.ChecklistGroupId;
                newChecklistGroup.ParentChecklistId = currentGroup.ParentChecklistId;
                newChecklistGroup.GroupName = currentGroup.GroupName;
                checklist.ChecklistGroups.Add(newChecklistGroup);
            }

            //checklist.ChecklistGroups = AutoMapper.Mapper.Map<IList<GetChecklistGroupEntry>, IList<ChecklistGroup>>(checklistGroupEntries.ChecklistGroupEntries);

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
                IDatabaseRequestsFacade database = new DatabaseRequestsFacade();

                foreach (ChecklistGroup currentGroup in checklist.ChecklistGroups)
                {
                    UpdateChecklistGroupEntry updateChecklistGroup = new UpdateChecklistGroupEntry();
                    updateChecklistGroup.ChecklistGroupId = currentGroup.ChecklistGroupId;
                    updateChecklistGroup.GroupName = currentGroup.GroupName;

                    ICommandResult result = database.Commands.UpdateChecklistGroupEntry(updateChecklistGroup);
                    int newGroupId = (int)result.Parameters["@ChecklistGroupId"].Value;
                    for (int currentItem = 0; currentItem < currentGroup.ItemCount; currentItem++)
                    {
                        InsertChecklistItemEntry newChecklistItemModel = new InsertChecklistItemEntry();
                        newChecklistItemModel.ParentChecklistGroupId = newGroupId;
                        database.Commands.InsertChecklistItemEntry(newChecklistItemModel);
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
