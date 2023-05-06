using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Help;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Areas.admin.Controllers
{
    public class bannersController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/banners
        public ActionResult Index()
        {
            return View(db.table_banners.ToList());
        }

        // GET: admin/banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_banners table_banners = db.table_banners.Find(id);
            if (table_banners == null)
            {
                return HttpNotFound();
            }
            return View(table_banners);
        }

        // GET: admin/banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,description,png,order,link,hide,meta")] table_banners table_banners, HttpPostedFileBase png)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (png != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + png.FileName;
                        path = Path.Combine(Server.MapPath("~/Uploads/img"), filename);
                        png.SaveAs(path);
                        table_banners.png = filename; //Lưu ý
                    }
                    else
                    {
                        table_banners.png = "logo.png";
                    }
                    //table_banners.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    table_banners.meta = Functions.ConvertToUnSign(table_banners.meta); //convert Tiếng Việt không dấu
                    db.table_banners.Add(table_banners);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(table_banners);
        }

        // GET: admin/banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_banners table_banners = db.table_banners.Find(id);
            if (table_banners == null)
            {
                return HttpNotFound();
            }
            return View(table_banners);
        }

        // POST: admin/banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,description,png,order,link,hide,meta")] table_banners table_banners, HttpPostedFileBase png)
        {
            try
            {
                var path = "";
                var filename = "";
                table_banners temp = getById(table_banners.id);
                if (ModelState.IsValid)
                {
                    if (png != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + png.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        png.SaveAs(path);
                        temp.png = filename; //Lưu ý
                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.title = table_banners.title;
                    temp.description = table_banners.description;
                    temp.meta = Functions.ConvertToUnSign(table_banners.meta); //convert Tiếng Việt không dấu
                    temp.hide = table_banners.hide;
                    temp.order = table_banners.order;
                    temp.link = table_banners.link;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(table_banners);
        }

        public table_banners getById(long id)
        {
            return db.table_banners.Where(x => x.id == id).FirstOrDefault();

        }


    // GET: admin/banners/Delete/5
    public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_banners table_banners = db.table_banners.Find(id);
            if (table_banners == null)
            {
                return HttpNotFound();
            }
            return View(table_banners);
        }

        // POST: admin/banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_banners table_banners = db.table_banners.Find(id);
            db.table_banners.Remove(table_banners);
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
