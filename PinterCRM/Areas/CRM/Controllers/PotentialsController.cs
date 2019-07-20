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
    public class PotentialsController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/Potentials
        public ActionResult Index()
        {
            var potentials = db.Potentials.Include(p => p.Account);
            return View(potentials.ToList());
        }

        // GET: CRM/Potentials/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potential potential = db.Potentials.Find(id);
            if (potential == null)
            {
                return HttpNotFound();
            }
            return View(potential);
        }

        // GET: CRM/Potentials/Create
        public ActionResult Create()
        {
            ViewBag.Account_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name");
            return View();
        }

        // POST: CRM/Potentials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Deal_ID,Deal_Name,Deal_Owner_ID,Created_by_ID,Modified_by_ID,Created_Time,Modified_Time,Amount,Closing_Date,Account_ID,Type,Stage,Probability____,Sales_Cycle_Duration,Overall_Sales_Duration,Expected_Revenue,Contact_ID")] Potential potential)
        {
            if (ModelState.IsValid)
            {
                potential.Deal_ID = Guid.NewGuid();
                db.Potentials.Add(potential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Account_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", potential.Account_ID);
            return View(potential);
        }

        // GET: CRM/Potentials/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potential potential = db.Potentials.Find(id);
            if (potential == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", potential.Account_ID);
            return View(potential);
        }

        // POST: CRM/Potentials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Deal_ID,Deal_Name,Deal_Owner_ID,Created_by_ID,Modified_by_ID,Created_Time,Modified_Time,Amount,Closing_Date,Account_ID,Type,Stage,Probability____,Sales_Cycle_Duration,Overall_Sales_Duration,Expected_Revenue,Contact_ID")] Potential potential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", potential.Account_ID);
            return View(potential);
        }

        // GET: CRM/Potentials/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potential potential = db.Potentials.Find(id);
            if (potential == null)
            {
                return HttpNotFound();
            }
            return View(potential);
        }

        // POST: CRM/Potentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Potential potential = db.Potentials.Find(id);
            db.Potentials.Remove(potential);
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
