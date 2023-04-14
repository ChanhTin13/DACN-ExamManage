using DACN_To_chuc_thi.Areas.Admin.CusModel.Student;
using DACN_To_chuc_thi.Areas.Admin.CusModel.ToChucThi;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class ToChucThiController : Controller
    {
        // GET: Admin/ToChucThi
        public ActionResult Index()
        {
            //Chia_de();
            string x = MonChuaCoDeThi();
            int so_mon = (int)DataProvider.Thuc_Thi.ExcuteScalar("select count(*) from mon");
            ViewBag.so_mon = so_mon.ToString();
            ViewBag.x = x;
            return View();
        }
        private string MonChuaCoDeThi()
        {
            string mon_thi_chua_co_de = "";
            List<string> lst = new List<string>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layDsMonKhongCoDeThi");
            foreach (DataRow r in data.Rows)
            {
                mon_thi_chua_co_de += r["ten_mon"].ToString() + ", ";
            }
            return mon_thi_chua_co_de;
        }
        private List<CusMon_Sodethi> LayDsMonCoDe()
        {
            List<CusMon_Sodethi> lst_mon = new List<CusMon_Sodethi>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layDsMonCoDeThi");
            foreach (DataRow r in data.Rows)
            {
                CusMon_Sodethi m = new CusMon_Sodethi();
                m.id_mon = (int)r["id_mon"];
                m.ten_mon = r["ten_mon"].ToString();
                m.sodethi = (int)r["Số đề thi"];
                lst_mon.Add(m);
            }
            return lst_mon;
        }
        private List<layDsDeThiTheoIdMon> LayDsDeThiTheoIdMon(int id_mon)
        {
            List<layDsDeThiTheoIdMon> lst_mon = new List<layDsDeThiTheoIdMon>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layDsDeThiTheoIdMon @id", new object[] { id_mon });
            foreach (DataRow r in data.Rows)
            {
                layDsDeThiTheoIdMon m = new layDsDeThiTheoIdMon();
                m.id_mon = (int)r["id_mon"];
                m.id_de_thi = (int)r["id_de_thi"];
                lst_mon.Add(m);
            }
            return lst_mon;
        }
        private List<Thong_tin_hoc_phan> LayDsHocPhanTheoIdMon(int id_mon)
        {
            List<Thong_tin_hoc_phan> lst_mon = new List<Thong_tin_hoc_phan>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layDsHocPhanTheoIdMon @id", new object[] { id_mon });
            foreach (DataRow r in data.Rows)
            {
                Thong_tin_hoc_phan m = new Thong_tin_hoc_phan();
                m.id_mon = (int)r["id_mon"];
                m.mssv = r["mssv"].ToString();
                m.nhom_hoc_phan = (int)r["nhom_hoc_phan"];
                lst_mon.Add(m);
            }
            return lst_mon;
        }

        private void Chia_de()
        {
            List<CusMonThi_NhomHp> lst = new List<CusMonThi_NhomHp>();

            //Ds môn 
            List<CusMon_Sodethi> lst_mon = LayDsMonCoDe();
            foreach (var item in lst_mon)
            {
                CusMonThi_NhomHp to_chuc_thi_mot_mon = new CusMonThi_NhomHp();


                // lấy ds đề
                List<layDsDeThiTheoIdMon> lst_de_thi = LayDsDeThiTheoIdMon(item.id_mon);
                //đánh số để chia đề
                int index = 0;
                //lấy ds hp
                List<Thong_tin_hoc_phan> lst_dshp = LayDsHocPhanTheoIdMon(item.id_mon);
                // danh sách mssv đã chia đề theo môn
                List<chiaDe> lst_chiaDe = new List<chiaDe>();
                foreach (var hp in lst_dshp) // vòng lặp dshp --> chia đề
                {
                    if (index == lst_de_thi.Count())
                    {
                        index = 0;
                    }

                    // Chia đề thi
                    chiaDe chiaDe = new chiaDe();
                    chiaDe.mssv = hp.mssv;
                    chiaDe.id_de_thi = lst_de_thi[index].id_de_thi;
                    chiaDe.id_nhom_hoc_pham = hp.nhom_hoc_phan;
                    //lưu vào ds
                    lst_chiaDe.Add(chiaDe);
                    ////////////////////////////////////////////////////
                    index++;

                }

                to_chuc_thi_mot_mon.id_mon = item.id_mon;
                to_chuc_thi_mot_mon.lst_chiaDe = lst_chiaDe;
                //lưu
                lst.Add(to_chuc_thi_mot_mon);
            }//kết thúc vòng lặp môn
            var xx = lst;

        }
        public ActionResult tao()
        {
             
        }
    }
}