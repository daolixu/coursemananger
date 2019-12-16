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
    public class ActionlinkController : Controller
    {
        private CoursemanagerEntities db = new CoursemanagerEntities();

        // GET: Actionlink
        public ActionResult Index()
        {
            return View(db.Actionlink.ToList());
        }

        // GET: Actionlink/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actionlink actionlink = db.Actionlink.Find(id);
            if (actionlink == null)
            {
                return HttpNotFound();
            }
            return View(actionlink);
        }

        // GET: Actionlink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actionlink/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Controller,Action")] Actionlink actionlink)
        {
            if (ModelState.IsValid)
            {
                db.Actionlink.Add(actionlink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionlink);
        }

        // GET: Actionlink/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actionlink actionlink = db.Actionlink.Find(id);
            if (actionlink == null)
            {
                return HttpNotFound();
            }
            return View(actionlink);
        }

        // POST: Actionlink/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Controller,Action")] Actionlink actionlink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionlink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionlink);
        }

        // GET: Actionlink/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actionlink actionlink = db.Actionlink.Find(id);
            if (actionlink == null)
            {
                return HttpNotFound();
            }
            return View(actionlink);
        }

        // POST: Actionlink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actionlink actionlink = db.Actionlink.Find(id);
            db.Actionlink.Remove(actionlink);
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
