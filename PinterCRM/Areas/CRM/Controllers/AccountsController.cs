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
    public class AccountsController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Contact);
            return View(accounts.ToList());
        }

        // GET: CRM/Accounts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: CRM/Accounts/Create
        public ActionResult Create()
        {
            ViewBag.Account_ID = new SelectList(db.Contacts, "Contact_ID", "Last_Name");
            return View();
        }

        // POST: CRM/Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Account_ID,Account_Name,Phone,Account_Type,Ownership,Industry,Employees,Annual_Revenue,Billing_Street,Billing_City,Billing_Country,Billing_State,Machines_Model,Total_Spindles,Total_machine,Description")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.Account_ID = Guid.NewGuid();
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Account_ID = new SelectList(db.Contacts, "Contact_ID", "Last_Name", account.Account_ID);
            return View(account);
        }

        // GET: CRM/Accounts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.Account_ID = new SelectList(db.Contacts, "Contact_ID", "Last_Name", account.Account_ID);
            return View(account);
        }

        // POST: CRM/Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Account_ID,Account_Name,Phone,Account_Type,Ownership,Industry,Employees,Annual_Revenue,Billing_Street,Billing_City,Billing_Country,Billing_State,Machines_Model,Total_Spindles,Total_machine,Description")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account_ID = new SelectList(db.Contacts, "Contact_ID", "Last_Name", account.Account_ID);
            return View(account);
        }

        // GET: CRM/Accounts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: CRM/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
