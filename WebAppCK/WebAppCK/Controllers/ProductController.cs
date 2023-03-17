using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCK.Models;

namespace WebAppCK.Controllers
{
    public class ProductController : Controller
    {
        CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: Product
        public ActionResult toProduct(String meta)
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
    }
}