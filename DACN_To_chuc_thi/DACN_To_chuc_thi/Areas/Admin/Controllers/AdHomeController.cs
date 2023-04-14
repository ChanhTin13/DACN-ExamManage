using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class AdHomeController : Controller
    {
        // GET: Admin/AdHome
        
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}