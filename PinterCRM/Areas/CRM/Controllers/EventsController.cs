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
    public class EventsController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/Events
        public ActionResult Index()
        {
            //var events = db.Events.Include(@ => @.Account);
            ///return View(events.ToList());
            //return View();
            var events = db.Events.Include(t => t.Account);
            return View(events.ToList());
        }

        // GET: CRM/Events/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: CRM/Events/Create
        public ActionResult Create()
        {
            ViewBag.Event_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name");
            return View();
        }

        // POST: CRM/Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_ID,Event_Owner_ID,Title,From,To,Location,Who_Id,Contact_Name,What_Name,Related_To,Send_Notification_Email,Description,All_day")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.Event_ID = Guid.NewGuid();
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Event_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", @event.Event_Owner_ID);
            return View(@event);
        }

        // GET: CRM/Events/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.Event_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", @event.Event_Owner_ID);
            return View(@event);
        }

        // POST: CRM/Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_ID,Event_Owner_ID,Title,From,To,Location,Who_Id,Contact_Name,What_Name,Related_To,Send_Notification_Email,Description,All_day")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Event_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", @event.Event_Owner_ID);
            return View(@event);
        }

        // GET: CRM/Events/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: CRM/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
