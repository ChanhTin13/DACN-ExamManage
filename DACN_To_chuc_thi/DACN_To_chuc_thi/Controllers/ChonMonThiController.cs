using DACN_To_chuc_thi.Areas.Admin.CusModel.GetSet;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Controllers
{
    public class ChonMonThiController : Controller
    {
        // GET: ChonMonThi
        public ActionResult Index()
        {
            int kt = (int)DataProvider.Thuc_Thi.ExcuteScalar("demThongTinTrcKhiThiBangMssv @m", new object[] { Session["sv_mssv"] });
            if (kt > 0)
            {
                layThongTinTrcKhiThiBangMssv_Result y = new layThongTinTrcKhiThiBangMssv_Result();
                DataTable data = DataProvider.Thuc_Thi.GetData("layThongTinTrcKhiThiBangMssv @mssv", new object[] { Session["sv_mssv"] });
                foreach (DataRow r in data.Rows)
                {
                    y.id_phieu_du_thi = (int)r["id_phieu_du_thi"];
                    get_set_int.Instance.setInt(y.id_phieu_du_thi);
                    y.mssv = r["mssv"].ToString();
                    y.ho_ten = r["ho_ten"].ToString();
                    y.ten_mon = r["ten_mon"].ToString(); 
                    Session["id_mon"] = (int)r["id_mon"];
                    y.ngay_thi = (DateTime)r["ngay_thi"];
                    break;
                }
                return View(y);
            }
            return View();
        }
        public ActionResult Thi()
        {
            int id_phieu_du_thi = get_set_int.Instance.getInt();
            int id_bl = (int)(decimal)DataProvider.Thuc_Thi.ExcuteScalar("themBaiLam @m ", new object[] { id_phieu_du_thi }  );
            Session["id_bai_lam"] = id_bl;
            return RedirectToAction("Index", "Thi", new { mssv= Session["sv_mssv"].ToString() , id_mon= Convert.ToInt32(Session["id_mon"] )   });
        }
    }
}