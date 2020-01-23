using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationEmployeeManagement.DAL;
using WebApplicationEmployeeManagement.Models;
using WebApplicationEmployeeManagement.ViewModel;

namespace WebApplicationEmployeeManagement.Controllers
{
    [Authorize(Users = "admin@idb.com")]
    public class DesignationsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Designations
        public async Task<ActionResult> Index()
        {
            return View(await db.Designations.ToListAsync());
        }

        public async Task<PartialViewResult> GetEmployeeList(int? id)
        {
            Designation designation = await db.Designations.FindAsync(id);


            var EmployeeList = await db.Employees.Where(e => e.DesignationID == id).ToListAsync();

            var model = new List<EmployeeInfo>();
            foreach (var emp in EmployeeList)
            {
                EmployeeInfo empInfo = new EmployeeInfo();
                empInfo.ID = emp.Id;
                empInfo.Name = emp.FullName();
                empInfo.Gender = emp.Gender.ToString();
                empInfo.Designation = emp.Designation.Name;
                empInfo.Salary = emp.Salary;
                model.Add(empInfo);
            }


            return PartialView("pv_EmployeeList",model);
        }

        // GET: Designations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DesignationID,Name")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Designations.Add(designation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        // GET: Designations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DesignationID,Name")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(designation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(designation);
        }

        // GET: Designations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = await db.Designations.FindAsync(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Designation designation = await db.Designations.FindAsync(id);
            db.Designations.Remove(designation);
            await db.SaveChangesAsync();
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
