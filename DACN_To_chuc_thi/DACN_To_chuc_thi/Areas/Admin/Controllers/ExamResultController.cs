using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class ExamResultController : Controller
    {
        // GET: Admin/ExamResult
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoadSelectSubject()
        {
            List<mon> lst = new List<mon>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from mon");
            foreach (DataRow r in data.Rows)
            {
                mon y = new mon();
                y.id_mon = (int)r["id_mon"];
                y.ten_mon = r["ten_mon"].ToString();
                lst.Add(y);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}