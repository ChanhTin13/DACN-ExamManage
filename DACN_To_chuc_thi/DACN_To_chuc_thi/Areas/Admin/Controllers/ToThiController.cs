using DACN_To_chuc_thi.Areas.Admin.CusModel.Student;
using DACN_To_chuc_thi.Areas.Admin.CusModel.To_thi;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class ToThiController : Controller
    {
        // GET: Admin/ToThi
        public ActionResult Index()
        {
            return View();
        }
        private List<CusToThi> getList(int id)
        {
            int id_mon;
            if (id == -1)
            {
                id_mon = (int)DataProvider.Thuc_Thi.ExcuteScalar("select *  from mon");
            }
            else
            {
                id_mon = id;
            }
            List<CusToThi> lst = new List<CusToThi>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layDanhSachToThiBangIdMon @id",new object[] {id_mon});
            foreach (DataRow r in data.Rows)
            {
                CusToThi y = new CusToThi();
                int id_to_thi = (int)r["id_to_thi"];
                y.id_to_thi = id_to_thi;
                y.ten_to_thi = r["ten_to_thi"].ToString();

                DateTime dateTime = new DateTime();
                dateTime = (DateTime)r["ngay_thi"];
                y.ngay_thi_str = dateTime.ToString("dd/MM/yyyy");

                y.id_phong = (int)r["id_phong_thi"];
                y.ten_phong = r["ten_phong_thi"].ToString();
                y.so_ghe = (int)r["so_luong_may"];

                y.so_thi_sinh = (int)DataProvider.Thuc_Thi.ExcuteScalar("laySoLuongThiSinhTheoTo @id_to",new object[] { id_to_thi });

                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List(int id)
        {
            List<CusToThi> lst = getList(id);
            return Json(lst, JsonRequestBehavior.AllowGet);

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