using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Areas.admin.Controllers
{
    public class menusController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/menus
        public ActionResult Index()
        {
            return View(db.table_menu.ToList());
        }

        // GET: admin/menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_menu table_menu = db.table_menu.Find(id);
            if (table_menu == null)
            {
                return HttpNotFound();
            }
            return View(table_menu);
        }

        // GET: admin/menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,link,meta,hide,order,dateupdate")] table_menu table_menu)
        {
            if (ModelState.IsValid)
            {
                db.table_menu.Add(table_menu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_menu);
        }

        // GET: admin/menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_menu table_menu = db.table_menu.Find(id);
            if (table_menu == null)
            {
                return HttpNotFound();
            }
            return View(table_menu);
        }

        // POST: admin/menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,link,meta,hide,order,dateupdate")] table_menu table_menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_menu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_menu);
        }

        // GET: admin/menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_menu table_menu = db.table_menu.Find(id);
            if (table_menu == null)
            {
                return HttpNotFound();
            }
            return View(table_menu);
        }

        // POST: admin/menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_menu table_menu = db.table_menu.Find(id);
            db.table_menu.Remove(table_menu);
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
