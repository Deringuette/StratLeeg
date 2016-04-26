using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StrategicLegion.Models;
using StrategicLegion.Models.StrategyModels;
using StrategicLegionDatabaseFacade.Communication;
using StrategicLegionDatabaseModels.Models.Notepads;

namespace StrategicLegion.Controllers.StrategyControllers
{
    public class NotepadController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notepad
        public ActionResult Index()
        {
            return View(db.NotepadStrategyModels.ToList());
        }

        // GET: Notepad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotepadStrategyModel notepadStrategyModel = db.NotepadStrategyModels.Find(id);
            if (notepadStrategyModel == null)
            {
                return HttpNotFound();
            }
            return View(notepadStrategyModel);
        }

        // GET: Notepad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notepad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotepadName,NotepadContent")] NotepadStrategyModel notepadStrategyModel)
        {
            if (ModelState.IsValid)
            {
                InsertNotepadEntry insertNotepadEntry = new InsertNotepadEntry();
                insertNotepadEntry.NotepadName = notepadStrategyModel.NotepadName;
                insertNotepadEntry.NotepadContent = notepadStrategyModel.NotepadContent;
                ICommandResult result = DatabaseRequestsFacade.Commands.InsertNotepadEntry(insertNotepadEntry);
                int newId = (int)result.Parameters["@NotepadId"].Value;
                return RedirectToAction("Index");
            }

            return View(notepadStrategyModel);
        }

        // GET: Notepad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotepadStrategyModel notepadStrategyModel = db.NotepadStrategyModels.Find(id);
            if (notepadStrategyModel == null)
            {
                return HttpNotFound();
            }
            return View(notepadStrategyModel);
        }

        // POST: Notepad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotepadId,NotepadName,NotepadContent")] NotepadStrategyModel notepadStrategyModel)
        {
            if (ModelState.IsValid)
            {
                UpdateNotepadEntry updateNotepadEntry = new UpdateNotepadEntry();
                updateNotepadEntry.NotepadId = notepadStrategyModel.NotepadId;
                updateNotepadEntry.NotepadName = notepadStrategyModel.NotepadName;
                updateNotepadEntry.NotepadContent = notepadStrategyModel.NotepadContent;
                ICommandResult result = DatabaseRequestsFacade.Commands.UpdateNotepadEntry(updateNotepadEntry);
                return RedirectToAction("Index");
            }
            return View(notepadStrategyModel);
        }

        // GET: Notepad/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetNotepadEntry getNotepadEntry = new GetNotepadEntry();
            getNotepadEntry = DatabaseRequestsFacade.Queries.GetNotepadEntry(id);
            NotepadStrategyModel notepadStrategyModel = new NotepadStrategyModel();
            notepadStrategyModel.NotepadId = getNotepadEntry.NotepadId;
            notepadStrategyModel.NotepadName = getNotepadEntry.NotepadName;
            notepadStrategyModel.NotepadContent = getNotepadEntry.NotepadContent;
            if (notepadStrategyModel == null)
            {
                return HttpNotFound();
            }
            return View(notepadStrategyModel);
        }

        // POST: Notepad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DeleteNotepadEntry deleteNotepadEntry = new DeleteNotepadEntry();
            deleteNotepadEntry.NotepadId = id;
            ICommandResult result = DatabaseRequestsFacade.Commands.DeleteNotepadEntry(deleteNotepadEntry);
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
