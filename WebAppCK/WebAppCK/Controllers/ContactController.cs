using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCK.Models;

namespace WebAppCK.Controllers
{

    public class ContactController : Controller
    {
        CuaHangTestEntities db = new CuaHangTestEntities();
        // GET: Contact
        public ActionResult getContact()
        {
            ViewBag.meta = "lien-he";
            var v = from t in db.table_contact
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}