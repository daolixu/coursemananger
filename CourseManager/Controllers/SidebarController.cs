using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class SidebarController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        // GET: Sidebar
        public ActionResult Index()
        {
            return View(db.Sidebar.ToList());
        }

        // GET: Sidebar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sidebar sidebar = db.Sidebar.Find(id);
            if (sidebar == null)
            {
                return HttpNotFound();
            }
            return View(sidebar);
        }

        // GET: Sidebar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sidebar/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Controller,Action")] Sidebar sidebar)
        {
            if (ModelState.IsValid)
            {
                db.Sidebar.Add(sidebar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sidebar);
        }

        // GET: Sidebar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sidebar sidebar = db.Sidebar.Find(id);
            if (sidebar == null)
            {
                return HttpNotFound();
            }
            return View(sidebar);
        }

        // POST: Sidebar/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Controller,Action")] Sidebar sidebar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sidebar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sidebar);
        }

        // GET: Sidebar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sidebar sidebar = db.Sidebar.Find(id);
            if (sidebar == null)
            {
                return HttpNotFound();
            }
            return View(sidebar);
        }

        // POST: Sidebar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sidebar sidebar = db.Sidebar.Find(id);
            db.Sidebar.Remove(sidebar);
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
