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
    public class LeadsController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/Leads
        public ActionResult Index()
        {
            var leads = db.Leads.Include(l => l.User);
            return View(leads.ToList());
        }

        // GET: CRM/Leads/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // GET: CRM/Leads/Create
        public ActionResult Create()
        {
            ViewBag.Lead_Owner_ID = new SelectList(db.Users, "User_id", "Role");
            return View();
        }

        // POST: CRM/Leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Lead_ID,Title,Last_Name,First_Name,Lead_Owner_ID,Email,Company,Lead_Source,Industry,Lead_Status,Phone,Mobile,Website,No__of_Employees,Annual_Revenue,Skype_ID,Salutation,Street,City,Country,State,Zip_Code,Twitter,Description")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                lead.Lead_ID = Guid.NewGuid();
                db.Leads.Add(lead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lead_Owner_ID = new SelectList(db.Users, "User_id", "Role", lead.Lead_Owner_ID);
            return View(lead);
        }

        // GET: CRM/Leads/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lead_Owner_ID = new SelectList(db.Users, "User_id", "Role", lead.Lead_Owner_ID);
            return View(lead);
        }

        // POST: CRM/Leads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Lead_ID,Title,Last_Name,First_Name,Lead_Owner_ID,Email,Company,Lead_Source,Industry,Lead_Status,Phone,Mobile,Website,No__of_Employees,Annual_Revenue,Skype_ID,Salutation,Street,City,Country,State,Zip_Code,Twitter,Description")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lead_Owner_ID = new SelectList(db.Users, "User_id", "Role", lead.Lead_Owner_ID);
            return View(lead);
        }

        // GET: CRM/Leads/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        // POST: CRM/Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Lead lead = db.Leads.Find(id);
            db.Leads.Remove(lead);
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
