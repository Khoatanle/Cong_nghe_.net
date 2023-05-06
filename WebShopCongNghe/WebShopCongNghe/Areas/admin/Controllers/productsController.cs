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
    public class productsController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();

        // GET: admin/products
        public ActionResult Index(long? id = null)
        {
            getCategory(id);
            //return View(db.products.ToList());
            return View();
        }
        public void getCategory(long? selectedId = null)
        {
            ViewBag.Category = new SelectList(db.table_catagory.Where(x => x.hide == true)
                .OrderBy(x => x.order), "id", "name", selectedId);
        }
        public ActionResult getProduct(long? id)
        {
            if (id == null)
            {
                var v = db.table_products.OrderBy(x => x.order).ToList();
                return PartialView(v);
            }
            var m = db.table_products.Where(x => x.categoryid == id).OrderBy(x => x.order).ToList();
            return PartialView(m);
        }

        // GET: admin/products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_products table_products = db.table_products.Find(id);
            if (table_products == null)
            {
                return HttpNotFound();
            }
            return View(table_products);
        }

        // GET: admin/products/Create
        public ActionResult Create()
        {
            getCategory();
            return View();
        }

        // POST: admin/products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,price,img,description,meta,color,hide,order,dateupdate,categoryid")] table_products table_products, HttpPostedFileBase img)
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
                        table_products.img = filename; //Lưu ý
                    }
                    else
                    {
                        table_products.img = "logo.png";
                    }
                    table_products.dateupdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    table_products.meta = Functions.ConvertToUnSign(table_products.meta); //convert Tiếng Việt không dấu
                    table_products.order = getMaxOrder(table_products.categoryid);
                    db.table_products.Add(table_products);
                    db.SaveChanges();
                    return RedirectToAction("Index", "products", new { id = table_products.categoryid });
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
            return View(table_products);
        }

        // GET: admin/products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            table_products table_products = db.table_products.Find(id);
            if (table_products == null)
            {
                return HttpNotFound();
            }
            getCategory(table_products.categoryid);
            return View(table_products);
        }

        // POST: admin/products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,price,img,description,meta,color,hide,order,dateupdate,categoryid")] table_products table_products, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                table_products temp = db.table_products.Find(table_products.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Uploads/img"), filename);
                        img.SaveAs(path);
                        temp.img = filename; //Lưu ý
                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.name = table_products.name;
                    temp.price = table_products.price;
                    temp.description = table_products.description;
                    temp.meta = Functions.ConvertToUnSign(table_products.meta); //convert Tiếng Việt không dấu
                    temp.color = table_products.color;
                    temp.hide = table_products.hide;
                    temp.order = table_products.order;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "products", new { id = table_products.categoryid });
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

            return View(table_products);
        }

        // GET: admin/products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            table_products table_products = db.table_products.Find(id);
            if (table_products == null)
            {
                return HttpNotFound();
            }
            return View(table_products);
        }

        // POST: admin/products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            table_products table_products = db.table_products.Find(id);
            db.table_products.Remove(table_products);
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

        public int getMaxOrder(long? CategoryId)
        {
            if (CategoryId == null)
                return 1;
            return db.table_products.Where(x => x.categoryid == CategoryId).Count();
        }
    }
}
