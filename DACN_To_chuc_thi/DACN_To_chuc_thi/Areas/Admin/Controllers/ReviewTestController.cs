using DACN_To_chuc_thi.Areas.Admin.CusModel.Test;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class ReviewTestController : Controller
    {
        // GET: Admin/ReviewTest  
        public ActionResult Index(int id_de)
        {
            int _id = id_de;
              //dung de luu kq
            OneTest content = new OneTest();
            List<MotBoCauHoi> lst = new List<MotBoCauHoi>();
            DataTable bch = DataProvider.Thuc_Thi.GetData("getTestInfoById @id ", new object[] { _id });
            foreach (DataRow r in bch.Rows)
            {
                content.id_de = _id;
                content.ten_ma_de= r["ma_de_thi"].ToString();
                content.ten_mon_hoc= r["ten_mon"].ToString();
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
                int id_cau_hoi= (int)r["id_cau_hoi"];

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




    }
}