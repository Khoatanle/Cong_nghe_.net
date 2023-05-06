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
    public class footerController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/footer
        public ActionResult Index()
        {
            return View(db.table_footer.ToList());
        }

        // GET: admin/footer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_footer table_footer = db.table_footer.Find(id);
            if (table_footer == null)
            {
                return HttpNotFound();
            }
            return View(table_footer);
        }

        // GET: admin/footer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/footer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,compname,description,address,phone,email,hide,dateupdate")] table_footer table_footer)
        {
            if (ModelState.IsValid)
            {
                db.table_footer.Add(table_footer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_footer);
        }

        // GET: admin/footer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_footer table_footer = db.table_footer.Find(id);
            if (table_footer == null)
            {
                return HttpNotFound();
            }
            return View(table_footer);
        }

        // POST: admin/footer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,compname,description,address,phone,email,hide,dateupdate")] table_footer table_footer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_footer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_footer);
        }

        // GET: admin/footer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_footer table_footer = db.table_footer.Find(id);
            if (table_footer == null)
            {
                return HttpNotFound();
            }
            return View(table_footer);
        }

        // POST: admin/footer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_footer table_footer = db.table_footer.Find(id);
            db.table_footer.Remove(table_footer);
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
