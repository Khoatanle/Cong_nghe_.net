using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopCongNghe.Models;

namespace WebShopCongNghe.Areas.admin.Controllers
{
    public class loginController : Controller
    {
        private CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: admin/login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Vui long nhap ten dang nhap";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Vui long nhap mat khau";
            }
            else
            {
                table_login tblogin = db.table_login.SingleOrDefault(n => n.userAdmin == tendn && n.passAdmin == matkhau);
                if (tblogin != null)
                {
                    Session["TaikhoanAdmins"] = tendn;
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    ViewBag.Thongbao = "Sai dang nhap";
                }
            }
            return View();
        }
    }
}