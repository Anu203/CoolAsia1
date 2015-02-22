using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoolAsiaApplication.Models;


namespace CoolAsiaApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyDBContext db = new CompanyDBContext();

        //
        // GET: /Employee/
       [Authorize(Roles="Employee,Manager,Admin")]
        public ActionResult Index()
        {
        
            return View(db.Employees.ToList());
        }

        //
        // GET: /Employee/Details/5
        //[Authorize(Roles = "Employee,Manager,Admin")]
        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create
       // [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create
        //[Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee,Company company)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
               
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            
           
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5
       // [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee,Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5
       // [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5
       // [Authorize(Roles = "Admin,Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       // [Authorize(Roles = "Admin,Manager")]
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}