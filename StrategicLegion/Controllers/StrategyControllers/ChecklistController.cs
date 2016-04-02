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
using System.Web.Routing;
using StrategicLegionDatabaseFacade.Presentation;
using StrategicLegionDatabaseModels.Models.Checklists;
using StrategicLegionDatabaseFacade.Communication;

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class ChecklistController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checklist
        public ActionResult Index()
        {
            return View(db.Checklists.ToList());
        }

        // GET: Checklist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = db.Checklists.Find(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // GET: Checklist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Checklist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChecklistName, GroupCount")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                IDatabaseRequestsFacade database = new DatabaseRequestsFacade();

                InsertChecklistEntry newChecklistModel = new InsertChecklistEntry();
                newChecklistModel.ChecklistName = checklist.ChecklistName;
            
                ICommandResult result = database.Commands.InsertChecklistEntry(newChecklistModel);
                int newId = (int)result.Parameters["@ChecklistId"].Value;
                for (int currentGroup = 0; currentGroup < checklist.GroupCount; currentGroup++)
                {
                    InsertChecklistGroupEntry newChecklistGroupModel = new InsertChecklistGroupEntry();
                    newChecklistGroupModel.ParentChecklistId = newId;
                    database.Commands.InsertChecklistGroupEntry(newChecklistGroupModel);
                }

                return RedirectToAction("Create", "ChecklistGroup", new RouteValueDictionary(new { checklistId = newId }));
            }

            return View(checklist);
        }

        // GET: Checklist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = db.Checklists.Find(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // POST: Checklist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChecklistName")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checklist);
        }

        // GET: Checklist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Checklist checklist = db.Checklists.Find(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        // POST: Checklist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Checklist checklist = db.Checklists.Find(id);
            db.Checklists.Remove(checklist);
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
