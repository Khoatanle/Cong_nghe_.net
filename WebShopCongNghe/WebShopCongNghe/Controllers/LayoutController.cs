using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Controllers
{
    public class LayoutController : Controller
    {
        CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getMenu()
        {
            var v = from t in db.table_menu
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }

        public ActionResult getFooter()
        {
            var v = from t in db.table_footer
                    select t;
            return PartialView(v.FirstOrDefault());
        }
    }
}