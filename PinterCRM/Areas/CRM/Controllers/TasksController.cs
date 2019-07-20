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
    public class TasksController : Controller
    {
        private crmEntities db = new crmEntities();

        // GET: CRM/Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.Account);
            return View(tasks.ToList());
        }

        // GET: CRM/Tasks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: CRM/Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Task_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name");
            return View();
        }

        // POST: CRM/Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_ID,Task_Owner_ID,Subject,Due_Date,Contact_Name,Related_To,Status,Priority,Send_Notification_Email,Description")] Task task)
        {
            if (ModelState.IsValid)
            {
                task.Task_ID = Guid.NewGuid();
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Task_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", task.Task_Owner_ID);
            return View(task);
        }

        // GET: CRM/Tasks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Task_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", task.Task_Owner_ID);
            return View(task);
        }

        // POST: CRM/Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_ID,Task_Owner_ID,Subject,Due_Date,Contact_Name,Related_To,Status,Priority,Send_Notification_Email,Description")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Task_Owner_ID = new SelectList(db.Accounts, "Account_ID", "Account_Name", task.Task_Owner_ID);
            return View(task);
        }

        // GET: CRM/Tasks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: CRM/Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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
