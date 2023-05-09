using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Controllers
{
    public class DefaultController : Controller
    {
        CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getBanners()
        {
            var v = from t in db.table_banners
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getCategory()
        {
            ViewBag.meta = "san-pham";
            var v = from t in db.table_catagory
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getProduct(long id, string metatitle)
        {
            //new
            ViewBag.meta = "san-pham";

            var v = from t in db.table_products
                    where t.categoryid == id && t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}