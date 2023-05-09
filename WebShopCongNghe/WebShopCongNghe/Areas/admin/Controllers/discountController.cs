using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Help;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Areas.admin.Controllers
{
    public class discountController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/discount
        public ActionResult Index()
        {
            return View(db.table_discount.ToList());
        }

        // GET: admin/discount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_discount table_discount = db.table_discount.Find(id);
            if (table_discount == null)
            {
                return HttpNotFound();
            }
            return View(table_discount);
        }

        // GET: admin/discount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/discount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,description,order,img,hide,dateupdate,detail")] table_discount table_discount, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Uploads/img"), filename);
                        img.SaveAs(path);
                        table_discount.img = filename; //Lưu ý
                    }
                    else
                    {
                        table_discount.img = "logo.png";
                    }
                    table_discount.dateupdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    //table_banners.meta = Functions.ConvertToUnSign(table_banners.meta); //convert Tiếng Việt không dấu
                    db.table_discount.Add(table_discount);
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

            return View(table_discount);
        }

        // GET: admin/discount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_discount table_discount = db.table_discount.Find(id);
            if (table_discount == null)
            {
                return HttpNotFound();
            }
            return View(table_discount);
        }

        // POST: admin/discount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,description,order,img,hide,dateupdate,detail")] table_discount table_discount, HttpPostedFileBase img)
        {
           try
            {
                var path = "";
                var filename = "";
                table_discount temp = getById(table_discount.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);
                        temp.img = filename; //Lưu ý
                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.title = table_discount.title;
                    temp.description = table_discount.description;
                    temp.detail = table_discount.detail;
                    temp.hide = table_discount.hide;
                    temp.order = table_discount.order;
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

            return View(table_discount);
        }

        public table_discount getById(long id)
        {
            return db.table_discount.Where(x => x.id == id).FirstOrDefault();

        }

        // GET: admin/discount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_discount table_discount = db.table_discount.Find(id);
            if (table_discount == null)
            {
                return HttpNotFound();
            }
            return View(table_discount);
        }

        // POST: admin/discount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_discount table_discount = db.table_discount.Find(id);
            db.table_discount.Remove(table_discount);
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
