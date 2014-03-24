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
using TestingSystem.ViewModels;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Text;

namespace TestingSystem.Controllers
{
    public class QuestionController : Controller
    {
        private TestingSystemContext db = new TestingSystemContext();

        // GET: /Question/
        public ActionResult Index(string ThematicAreaID)
        {
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name");
            ViewBag.CurrentFilter = ThematicAreaID;

            if (!String.IsNullOrEmpty(ThematicAreaID))
            {
                long id = long.Parse(ThematicAreaID);
                var area = db.ThematicAreas.Where(ta => ta.ID == id).Single();
                var ParentThematicAreas = db.ThematicAreas.Where(ta => ta.ThematicAreaID == null);

                var query = db.Database.SqlQuery<ThematicArea>
                        ("[dbo].[GetThematicAreasTree] @RootName",
                        new SqlParameter("@RootName", area.Name));

                List<long> ids = new List<long>();
                foreach(var q in query) ids.Add(q.ID);
                var filteredQuestions = GetQuestionsByAreaId(ids);

                return View(filteredQuestions);
            }
            var questions = db.Questions.Include(q => q.ThematicArea);
            return View(questions.ToList());
        }

        public IEnumerable<Question> GetQuestionsByAreaId(List<long> ids)
        {
            string values = string.Join(", ", ids);

            var sql = string.Format(
                "SELECT * FROM [dbo].[Question] WHERE [ThematicAreaID] IN ({0})",
                values);

            return db.Database.SqlQuery<Question>(sql);
        }

        // GET: /Question/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: /Question/Create
        public ActionResult Create()
        {
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name");
            return View();
        }

        // POST: /Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text,Points,Explanation,ThematicAreaID, Answers")] Question question)
        {
            if (ModelState.IsValid)
            {
                foreach (Answer a in question.Answers.ToList())
                {
                    if (a.deleteThis)
                    {
                        question.Answers.Remove(a);
                    }
                }
                question.QuestionType = 
                    question.Answers.Where(q => q.IsCorrect).ToList().Count > 1 ? QuestionType.multiple : QuestionType.one;
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name", question.ThematicAreaID);
            return View(question);
        }

        // GET: /Question/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name", question.ThematicAreaID);
            return View(question);
        }

        // POST: /Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Text,Points,Explanation,ThematicAreaID, Answers")] Question question)
        {
            if (ModelState.IsValid)
            {
                foreach (Answer a in question.Answers.ToList())
                {
                    if (a.ID == 0)
                    {
                        a.QuestionID = question.ID;
                        db.Answers.Add(a);
                        question.Answers.Add(a);
                    }
                    else
                    {
                        if (a.deleteThis)
                        {
                            question.Answers.Remove(a);
                            db.Entry(a).State = EntityState.Deleted;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.Entry(a).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                question.QuestionType =
                    question.Answers.Where(q => q.IsCorrect).ToList().Count > 1 ? QuestionType.multiple : QuestionType.one;
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.ThematicAreaID = new SelectList(db.ThematicAreas, "ID", "Name", question.ThematicAreaID);
            return View(question);
        }

        public ViewResult BlankEditorRow()
        {
            return View("AnswerEditorRow", new Answer());
        }

        // GET: /Question/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
