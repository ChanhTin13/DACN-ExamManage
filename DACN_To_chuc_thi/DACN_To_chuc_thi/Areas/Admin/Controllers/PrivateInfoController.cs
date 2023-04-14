using DACN_To_chuc_thi.Areas.Admin.Code;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class PrivateInfoController : Controller
    {
        // GET: Admin/PrivateInfo
        public ActionResult Index()
        {
            //int id = SessionHelper.GetSession().id;
            int id = 1;
            if (id != 0)
            {
                object[] parameter =
                {
                new SqlParameter("@id_nguoi_dung",id)
                };
                using (DACN_To_Chuc_ThiEntities context = new DACN_To_Chuc_ThiEntities())
                {

                    var info = context.Nguoi_dung.First(m => m.id_nguoi_dung == id);
                    return View(info);
                }
            }
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}