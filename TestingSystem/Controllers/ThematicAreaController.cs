using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Models;
using TestingSystem.DAL;
using System.Diagnostics;
using System.Data.SqlClient;

namespace TestingSystem.Controllers
{
    public class ThematicAreaController : Controller
    {
        private TestingSystemContext db = new TestingSystemContext();

        // GET: /ThematicArea/
        public ActionResult Index()
        {
            var thematicAreas = db.ThematicAreas.Where(ta => ta.ThematicAreaID == null).Include(t => t.SubThematicAreas);
            return View(thematicAreas.ToList());
        }

        // GET: /ThematicArea/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicArea thematicarea = db.ThematicAreas.Find(id);
            if (thematicarea == null)
            {
                return HttpNotFound();
            }
            return View(thematicarea);
        }

        // GET: /ThematicArea/Create
        public ActionResult Create()
        {
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name");
            return View();
        }

        // POST: /ThematicArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,ThematicAreaID")] ThematicArea thematicarea)
        {
            if (ModelState.IsValid)
            {
                db.ThematicAreas.Add(thematicarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name", thematicarea.ThematicAreaID);
            return View(thematicarea);
        }

        // GET: /ThematicArea/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicArea thematicarea = db.ThematicAreas.Find(id);
            if (thematicarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name", thematicarea.ThematicAreaID);
            return View(thematicarea);
        }

        // POST: /ThematicArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,ThematicAreaID")] ThematicArea thematicarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thematicarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name", thematicarea.ThematicAreaID);
            return View(thematicarea);
        }

        // GET: /ThematicArea/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicArea thematicarea = db.ThematicAreas.Find(id);
            if (thematicarea == null)
            {
                return HttpNotFound();
            }
            return View(thematicarea);
        }

        // POST: /ThematicArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ThematicArea thematicarea = db.ThematicAreas.Find(id);
            db.ThematicAreas.Remove(thematicarea);
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
