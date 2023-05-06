using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Controllers
{
    public class DiscountController : Controller
    {
        CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: Discount
        public ActionResult getDiscount()
        {
            ViewBag.meta = "khuyen-mai";
            var v = from t in db.table_discount
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return View(v.ToList());
        }

        public ActionResult getDetailDiscount(long id)
        {
            var v = from t in db.table_discount
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}