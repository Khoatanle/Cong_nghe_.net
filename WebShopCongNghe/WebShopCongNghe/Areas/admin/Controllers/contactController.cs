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
    public class contactController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/contact
        public ActionResult Index()
        {
            return View(db.table_contact.ToList());
        }

        // GET: admin/contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_contact table_contact = db.table_contact.Find(id);
            if (table_contact == null)
            {
                return HttpNotFound();
            }
            return View(table_contact);
        }

        // GET: admin/contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,info,address,mail,phonenum")] table_contact table_contact)
        {
            if (ModelState.IsValid)
            {
                db.table_contact.Add(table_contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_contact);
        }

        // GET: admin/contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_contact table_contact = db.table_contact.Find(id);
            if (table_contact == null)
            {
                return HttpNotFound();
            }
            return View(table_contact);
        }

        // POST: admin/contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,info,address,mail,phonenum")] table_contact table_contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_contact);
        }

        // GET: admin/contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_contact table_contact = db.table_contact.Find(id);
            if (table_contact == null)
            {
                return HttpNotFound();
            }
            return View(table_contact);
        }

        // POST: admin/contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_contact table_contact = db.table_contact.Find(id);
            db.table_contact.Remove(table_contact);
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
