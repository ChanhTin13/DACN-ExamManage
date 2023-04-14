using DACN_To_chuc_thi.Areas.Admin.CusModel.Test;
using DACN_To_chuc_thi.Models;
using DACN_To_chuc_thi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DACN_To_chuc_thi.Controllers
{
    public class ThiController : Controller
    {
        // GET: Thi
        public ActionResult Index(string mssv, int id_mon)
        {
            //string mssv = "19111", int id_mon = 1
            int _id = (int)DataProvider.Thuc_Thi.ExcuteScalar("layMaDeBangMssv @mssv , @id_m", new object[] { mssv, id_mon });
            //dung de luu kq
            OneTest content = new OneTest();
            List<MotBoCauHoi> lst = new List<MotBoCauHoi>();
            DataTable bch = DataProvider.Thuc_Thi.GetData("getTestInfoById @id ", new object[] { _id });
            foreach (DataRow r in bch.Rows)
            {
                content.id_de = _id;
                content.ten_ma_de = r["ma_de_thi"].ToString();
                content.ten_mon_hoc = r["ten_mon"].ToString();
                content.noi_dung_de_thi = getListGroupTestByIdTest(_id);
                lst = content.noi_dung_de_thi;
            }
            ViewBag.x = lst;
            return View(content);
        }
        private List<MotBoCauHoi> getListGroupTestByIdTest(int id_de)// lấy ds các bộ câu hỏi và nội dung theo đề
        {
            List<MotBoCauHoi> lst = new List<MotBoCauHoi>();
            DataTable bch = DataProvider.Thuc_Thi.GetData("getTestGroupContentByIdTest @id ", new object[] { id_de });
            foreach (DataRow r in bch.Rows)
            {
                MotBoCauHoi x = new MotBoCauHoi();
                int id_bo_cau_hoi = (int)r["id_bo_cau_hoi"]; // id bộ câu hỏi

                x.id_bo_cau_hoi = id_bo_cau_hoi;
                x.ten_bo_cau_hoi = r["ten_bo_cau_hoi"].ToString();
                x.CauHoi_LuaChon = getListCauHoi_LuaChon_ByIdGroup(id_bo_cau_hoi);
                lst.Add(x);
            }
            return lst;
        }

        private List<CauHoi_LuaChon> getListCauHoi_LuaChon_ByIdGroup(int id_bo_cau_hoi) // lấy ds câu hỏi và lựa chọn theo bộ
        {
            List<CauHoi_LuaChon> lst = new List<CauHoi_LuaChon>();
            DataTable ch = DataProvider.Thuc_Thi.GetData("getListQuestionByIdGroupTest @id ", new object[] { id_bo_cau_hoi });
            foreach (DataRow r in ch.Rows)
            {
                CauHoi_LuaChon cauHoi_LuaChon = new CauHoi_LuaChon();
                // lay in4 cau hoi
                int id_cau_hoi = (int)r["id_cau_hoi"];

                cauHoi_LuaChon.id_cau_hoi = id_cau_hoi;
                cauHoi_LuaChon.noi_dung = r["noi_dung"].ToString();
                cauHoi_LuaChon.DsLuaChon = getListOptionByIdQuestion(id_cau_hoi);
                //lay ds lua chon 
                lst.Add(cauHoi_LuaChon);
            }
            return lst;
        }
        private List<lua_chon> getListOptionByIdQuestion(int id_cau_hoi) // lấy ds lựa chọn theo câu hỏi
        {
            List<lua_chon> lst = new List<lua_chon>();
            DataTable data_lc = DataProvider.Thuc_Thi.GetData("getListOptionByIdQuestion @id ", new object[] { id_cau_hoi });
            foreach (DataRow rlc in data_lc.Rows)
            {
                lua_chon lc = new lua_chon();
                lc.id_lua_chon = (int)rlc["id_lua_chon"];
                lc.noi_dung = rlc["noi_dung"].ToString();
                lc.dung_hay_sai = (bool)rlc["dung_hay_sai"];
                lst.Add(lc);
            }
            return lst;
        }

        public JsonResult ThongTinThi()
        {
            thong_tin_khi_thi x = new thong_tin_khi_thi();
            DataTable data = DataProvider.Thuc_Thi.GetData("layThongTinThiBangMssv @id ", new object[] { "19111" });
            foreach (DataRow r in data.Rows)
            {
                x.id_phieu_du_thi = (int)r["id_phieu_du_thi"];
                x.ten_mon = r["ten_mon"].ToString();
                x.ho_ten = r["ho_ten"].ToString();
                x.mssv = r["mssv"].ToString();
                x.thoi_luong_thi = (int)r["thoi_luong_thi"];
                x.ngay_thi = (DateTime)r["ngay_thi"];
                x.ngay_thi_str = x.ngay_thi.ToString("dd/MM/yyyy");
                x.id_de_thi = (int)r["id_de_thi"];
                x.gio_bd = x.ngay_thi.ToString("HH:mm");
                x.gio_kt = x.ngay_thi.AddMinutes(x.thoi_luong_thi).ToString("HH:mm");
                x.ma_de_thi = r["ma_de_thi"].ToString();
                int so_cau = (int)DataProvider.Thuc_Thi.ExcuteScalar("getAmountQuestion @id_de", new object[] { x.id_de_thi });
                x.so_cau = so_cau;
                break;
            }
            return Json(x, JsonRequestBehavior.AllowGet);
        }



        public JsonResult layListIdCauHoi()
        {
            List<int> lst_int = new List<int>();
            int _id = (int)DataProvider.Thuc_Thi.ExcuteScalar("layMaDeBangMssv @mssv , @id_m", new object[] { Session["sv_mssv"].ToString(), Convert.ToInt32(Session["id_mon"]) });
            List<MotBoCauHoi> lst = getListGroupTestByIdTest(_id);
            foreach (var item in lst)
            {
                foreach (var ch in item.CauHoi_LuaChon)
                {
                    lst_int.Add(ch.id_cau_hoi);
                }
            }
            return Json(lst_int, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChamThi(cjd x)
        {
            if (x.nd != null)
            {
                string[] list = x.nd.Split('_');
                int id_bai_lam = Convert.ToInt32(Session["id_bai_lam"]);
                foreach (string item in list)
                {
                    if (item != "")
                    {
                        DataProvider.Thuc_Thi.ExecuteNonQuery("insert into ct_bai_lam values( @id_bl , @id_lc )", new object[] { id_bai_lam, Int32.Parse(item) });
                        DataProvider.Thuc_Thi.ExecuteNonQuery("them_kq @id_bl , @id_lc ", new object[] { id_bai_lam, Int32.Parse(item) });
                    }
                }
            } 
            return Json(new { code = 1 });
        }
        public ActionResult KetQuaThi( )
        {
            int _id = (int)DataProvider.Thuc_Thi.ExcuteScalar("layMaDeBangMssv @mssv , @id_m", new object[] { Session["sv_mssv"].ToString(), Convert.ToInt32(Session["id_mon"]) });
            //dung de luu kq
            OneTest content = new OneTest();
            List<MotBoCauHoi> lst = new List<MotBoCauHoi>();
            DataTable bch = DataProvider.Thuc_Thi.GetData("getTestInfoById @id ", new object[] { _id });
            foreach (DataRow r in bch.Rows)
            {
                content.id_de = _id;
                content.ten_ma_de = r["ma_de_thi"].ToString();
                content.ten_mon_hoc = r["ten_mon"].ToString();
                content.noi_dung_de_thi = getListGroupTestByIdTest(_id);
                lst = content.noi_dung_de_thi;
            }
            tt_kq_thi ttkq = new tt_kq_thi();
            int id_bai_lam = Convert.ToInt32(Session["id_bai_lam"]);
            List<int> lst_int = new List<int>();
            foreach(var item in content.noi_dung_de_thi)
            {
                foreach(var cc in item.CauHoi_LuaChon)
                {
                    var lcd = (cc.DsLuaChon.FirstOrDefault(m => m.dung_hay_sai == true).id_lua_chon);
                    int x = (int)DataProvider.Thuc_Thi.ExcuteScalar("checkcjd @idbl , @idlc",new object[] { id_bai_lam, lcd });
                    if (x> 0) {
                        lst_int.Add(1);
                    }
                    else
                    {
                        lst_int.Add(0);
                    }
                }
            }
            ttkq.lst_bch = content.noi_dung_de_thi;
            ttkq.lst_int=lst_int;
            ttkq.diem= (int)DataProvider.Thuc_Thi.ExcuteScalar("layDiem @idbl ", new object[] { id_bai_lam  });
            Session.Clear();
            return View(ttkq); 
        }

    }
}