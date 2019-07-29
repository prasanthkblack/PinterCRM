using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PinterCRM.Areas.CRM.Models;

namespace PinterCRM.Areas.CRM.Controllers
{
    public class machinedetailsController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/machinedetails
        public ActionResult Index()
        {
            var machinedetails = db.machinedetails.Include(m => m.Account).Include(m => m.Machine);
            return View(machinedetails.ToList());
        }

        // GET: CRM/machinedetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            machinedetail machinedetail = db.machinedetails.Find(id);
            if (machinedetail == null)
            {
                return HttpNotFound();
            }
            return View(machinedetail);
        }

        // GET: CRM/machinedetails/Create
        public ActionResult Create()
        {
            ViewBag.fk_Company = new SelectList(db.Accounts, "Account_ID", "Account_Name");
            ViewBag.Fk_Machine = new SelectList(db.Machines, "Type_id", "Model");
            return View();
        }

        // POST: CRM/machinedetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fk_Company,Fk_Machine,Spindles,Description")] machinedetail machinedetail)
        {
            if (ModelState.IsValid)
            {
                db.machinedetails.Add(machinedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Company = new SelectList(db.Accounts, "Account_ID", "Account_Name", machinedetail.fk_Company);
            ViewBag.Fk_Machine = new SelectList(db.Machines, "Type_id", "Model", machinedetail.Fk_Machine);
            return View(machinedetail);
        }

        // GET: CRM/machinedetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            machinedetail machinedetail = db.machinedetails.Find(id);
            if (machinedetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Company = new SelectList(db.Accounts, "Account_ID", "Account_Name", machinedetail.fk_Company);
            ViewBag.Fk_Machine = new SelectList(db.Machines, "Type_id", "Model", machinedetail.Fk_Machine);
            return View(machinedetail);
        }

        // POST: CRM/machinedetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fk_Company,Fk_Machine,Spindles,Description")] machinedetail machinedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machinedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Company = new SelectList(db.Accounts, "Account_ID", "Account_Name", machinedetail.fk_Company);
            ViewBag.Fk_Machine = new SelectList(db.Machines, "Type_id", "Model", machinedetail.Fk_Machine);
            return View(machinedetail);
        }

        // GET: CRM/machinedetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            machinedetail machinedetail = db.machinedetails.Find(id);
            if (machinedetail == null)
            {
                return HttpNotFound();
            }
            return View(machinedetail);
        }

        // POST: CRM/machinedetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            machinedetail machinedetail = db.machinedetails.Find(id);
            db.machinedetails.Remove(machinedetail);
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
