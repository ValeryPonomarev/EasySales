using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasySales.Infrastructure.Repositories.Customers;
using EasySales.Model;
using EasySales.Model.EntityServices;
using EasySales.Model.Entities;

namespace EasySales.WEB.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View(StudentService.GetAll());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = StudentService.Get(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.StudentGroupID = new SelectList(Enumerable.Empty<StudentGroup>(), "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentGroupID,Name,SurName,LastName,DateBirth,Name2,SurName2,LastName2,Key,DateEdit,DateCreate")] Student student)
        {
            if (ModelState.IsValid)
            {
                StudentService.Save(student);
                return RedirectToAction("Index");
            }

            ViewBag.StudentGroupID = new SelectList(Enumerable.Empty<StudentGroup>(), "Id", "Name", student.StudentGroupID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = StudentService.Get(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentGroupID = new SelectList(Enumerable.Empty<StudentGroup>(), "Id", "Name", student.StudentGroupID);
            return View(student);
        }

        // POST: Students/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentGroupID,Name,SurName,LastName,DateBirth,Name2,SurName2,LastName2,Key,DateEdit,DateCreate")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentGroupID = new SelectList(Enumerable.Empty<StudentGroup>(), "Id", "Name", student.StudentGroupID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = StudentService.Get(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = StudentService.Get(id);
            StudentService.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
