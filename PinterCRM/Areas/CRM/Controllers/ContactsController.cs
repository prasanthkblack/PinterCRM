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
    public class ContactsController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/Contacts
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.Account);
            return View(contacts.ToList());
        }

        // GET: CRM/Contacts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: CRM/Contacts/Create
        public ActionResult Create()
        {
            ViewBag.Contact_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name");
            return View();
        }

        // POST: CRM/Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contact_ID,Last_Name,First_Name,Contact_Owner_ID,Email,Company,Lead_Source,Industry,Phone,Mobile,Skype_ID,Title,Mailing_Street,Mailing_City,Mailing_State,Date_of_Birth,Mailing_Zip,Twitter,Description")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Contact_ID = Guid.NewGuid();
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Contact_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", contact.Contact_ID);
            return View(contact);
        }

        // GET: CRM/Contacts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.Contact_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", contact.Contact_ID);
            return View(contact);
        }

        // POST: CRM/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contact_ID,Last_Name,First_Name,Contact_Owner_ID,Email,Company,Lead_Source,Industry,Phone,Mobile,Skype_ID,Title,Mailing_Street,Mailing_City,Mailing_State,Date_of_Birth,Mailing_Zip,Twitter,Description")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Contact_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", contact.Contact_ID);
            return View(contact);
        }

        // GET: CRM/Contacts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: CRM/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
