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
    public class catagoryController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/catagory
        public ActionResult Index()
        {
            return View(db.table_catagory.ToList());
        }

        // GET: admin/catagory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_catagory table_catagory = db.table_catagory.Find(id);
            if (table_catagory == null)
            {
                return HttpNotFound();
            }
            return View(table_catagory);
        }

        // GET: admin/catagory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/catagory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,link,meta,hide,order,dateupdate")] table_catagory table_catagory)
        {
            if (ModelState.IsValid)
            {
                db.table_catagory.Add(table_catagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_catagory);
        }

        // GET: admin/catagory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_catagory table_catagory = db.table_catagory.Find(id);
            if (table_catagory == null)
            {
                return HttpNotFound();
            }
            return View(table_catagory);
        }

        // POST: admin/catagory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,link,meta,hide,order,dateupdate")] table_catagory table_catagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_catagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_catagory);
        }

        // GET: admin/catagory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_catagory table_catagory = db.table_catagory.Find(id);
            if (table_catagory == null)
            {
                return HttpNotFound();
            }
            return View(table_catagory);
        }

        // POST: admin/catagory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_catagory table_catagory = db.table_catagory.Find(id);
            db.table_catagory.Remove(table_catagory);
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
