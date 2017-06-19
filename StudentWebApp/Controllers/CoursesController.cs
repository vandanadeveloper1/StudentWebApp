using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentWebApp.Models.Database;

namespace StudentWebApp.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private StudentModelContainer db = new StudentModelContainer();

        // GET: Courses
        public ActionResult Index([Bind(Prefix = "id")]int studentID)
        {
            //var courses = db.Courses.Include(c => c.Student).Include(c => c.Teacher);
            var courses = db.Courses.Where(t => t.StudentID == studentID).ToList();
            var student = db.Students.Find(studentID);
            ViewBag.FirstName = student.FirstName;
            ViewBag.LastName = student.LastName;
            ViewBag.StudentID = student.StudentID;
            return View(courses.ToList());
          
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.StudentList = new SelectList(db.Students, "StudentID", "LastName");
            ViewBag.TeacherList = new SelectList(db.Teachers, "TeacherID", "LastName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        //public ActionResult Create([Bind(Include = "CourseID,CourseName,StudentID,Fee,StartDate,EndDate,TeacherID")] Course course)
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = course.StudentID });
            }

            ViewBag.StudentList = new SelectList(db.Students, "StudentID", "LastName", course.StudentID);
            ViewBag.TeacherList = new SelectList(db.Teachers, "TeacherID", "LastName", course.TeacherID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentList = new SelectList(db.Students, "StudentID", "LastName", course.StudentID);
            ViewBag.TeacherList = new SelectList(db.Teachers, "TeacherID", "LastName", course.TeacherID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,CourseName,StudentID,Fee,StartDate,EndDate,TeacherID")] Course course)
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = course.StudentID });
            }
            ViewBag.StudentList = new SelectList(db.Students, "StudentID", "LastName", course.StudentID);
            ViewBag.TeacherList = new SelectList(db.Teachers, "TeacherID", "LastName", course.TeacherID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            if (course.Student.Courses.Count > 0)
            {

            }
            else if (course.Student.Courses.Count > 0)
            {
                db.Courses.Remove(course);
                db.SaveChanges();

            }
     
            return RedirectToAction("Index", new { id = course.StudentID });
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
