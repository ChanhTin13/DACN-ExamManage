using DACN_To_chuc_thi.Areas.Admin.CusModel.GetSet;
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
    public class thong_tin_to_thiController : Controller
    { 
        // GET: Admin/thong_tin_to_thi
        public ActionResult Index(int id)
        {
            get_set_thong_tin_to_thi.Instance.setInt(id);
            return View();
        } 
        private List<ThongTinToThi> getList( )
        { 
            int id_to= get_set_thong_tin_to_thi.Instance.getInt();
            List<ThongTinToThi> lst = new List<ThongTinToThi>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layThongTinToThiBangIdToThi @id", new object[] { id_to });
            foreach (DataRow r in data.Rows)
            {
                ThongTinToThi y = new ThongTinToThi(); 
                y.mssv = r["mssv"].ToString();
                y.ho_ten = r["ho_ten"].ToString();
                y.ten_mon = r["ten_mon"].ToString();
                y.ma_de = r["ma_de_thi"].ToString();
                y.thoi_luong_thi = (int)r["thoi_luong_thi"]; 

                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List( )
        {
            List<ThongTinToThi> lst = getList( );
            return Json(lst, JsonRequestBehavior.AllowGet);

        }
    }
}