using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Controllers
{

    public class ProductController : Controller
    {
        CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: Product
        public ActionResult getProductDetail(String meta)
        {
            var v = from t in db.table_catagory
                    where t.meta == meta
                    select t;

            return View(v.FirstOrDefault());
        }

        public ActionResult Detail(long id)
        {
            var v = from t in db.table_products
                    where t.id == id
                    select t;

            return View(v.FirstOrDefault());
        }

        public ActionResult ShoppingCart()
        {
            ViewBag.meta = "gio-hang";
           var v = from t in db.table_products
                    select t;

            return View(v.FirstOrDefault());
        }
    }
}