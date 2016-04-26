using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using StrategicLegion.Models;
using StrategicLegion.Models.StrategyModels.ChecklistModels;
using System.Web.Routing;
using StrategicLegionDatabaseModels.Models.Checklists;
using StrategicLegionDatabaseFacade.Communication;
using StrategicLegionDatabaseFacade.Communication.ResponseModels.Checklists;
using AutoMapper;

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class ChecklistController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checklist
        public ActionResult Index()
        {
            IList<GetChecklistEntry> checklistEntries = DatabaseRequestsFacade.Queries.GetChecklistEntries().ChecklistEntries;
            List <Checklist> checklistList = new List<Checklist>();
            foreach(GetChecklistEntry currentChecklistEntry in checklistEntries)
            {
                Mapper.CreateMap<GetChecklistEntry, Checklist>();
                Checklist newChecklist = Mapper.Map<Checklist>(currentChecklistEntry);
                checklistList.Add(newChecklist);
            }
            return View(checklistList);
        }

        // GET: Checklist/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GetChecklistEntry checklistEntry = DatabaseRequestsFacade.Queries.GetChecklistEntry((int)id);
            GetMultipleChecklistGroupsResponseModel checklistGroupEntries = DatabaseRequestsFacade.Queries.GetChecklistChildrenQuery((int)id);

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
                InsertChecklistEntry newChecklistModel = new InsertChecklistEntry();
                newChecklistModel.ChecklistName = checklist.ChecklistName;

                newChecklistModel.Submitter = "SubmitterName";

                ICommandResult result = DatabaseRequestsFacade.Commands.InsertChecklistEntry(newChecklistModel);
                int newId = (int)result.Parameters["@ChecklistId"].Value;
                for (int currentGroup = 0; currentGroup < checklist.GroupCount; currentGroup++)
                {
                    InsertChecklistGroupEntry newChecklistGroupModel = new InsertChecklistGroupEntry();
                    newChecklistGroupModel.ParentChecklistId = newId;
                    DatabaseRequestsFacade.Commands.InsertChecklistGroupEntry(newChecklistGroupModel);
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
