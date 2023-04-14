using DACN_To_chuc_thi.Areas.Admin.CusModel.khung_de_thi;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class FrameTestController : Controller
    {
        // GET: Admin/FrameTest
        public ActionResult Index()
        {
            return View();
        }
        private List<Cus_FrameTest> getList()
        {
            DateTime dateTime= DateTime.Now;
            List<Cus_FrameTest> lst = new List<Cus_FrameTest>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from khung_de_thi");
            foreach(DataRow r in data.Rows)
            {

                Cus_FrameTest y = new Cus_FrameTest();
                dateTime = (DateTime)r["ngay_tao"];
                y.id_khung_de = (int)r["id_khung_de"];
                y.ten_khung_de = r["ten_khung_de"].ToString();
                y.thoi_luong_thi = (int)r["thoi_luong_thi"];
                y.ngay_tao_str = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                y.ten_mon = DataProvider.Thuc_Thi.ExcuteScalar("getSubjectName @x", new object[] { (int)r["id_mon"] }).ToString();
                y.so_de = (int) DataProvider.Thuc_Thi.ExcuteScalar("getAmountTestById @x", new object[] { (int)r["id_khung_de"] });
                 
                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List()
        {
            List<Cus_FrameTest> lst = getList();
            return Json(lst, JsonRequestBehavior.AllowGet); 
        }
        public JsonResult getbyID(int ID)
        {
            List<Cus_FrameTest> lst = getList();
            var m = lst.Find(x => x.id_khung_de.Equals(ID));
            return Json(m, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(khung_de_thi x)
        { 
            object[] parameter = new object[] {x.ten_khung_de,x.thoi_luong_thi,x.id_mon };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("AddFrameTest @ten_khung , @thoi_gian , @id_mon ", parameter), JsonRequestBehavior.AllowGet); 
        }
        public JsonResult Update(khung_de_thi x)
        {
            object[] parameter = new object[] {x.id_khung_de, x.ten_khung_de, x.thoi_luong_thi, x.id_mon };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("UpdateFrameTest @id , @ten_khung , @thoi_gian , @id_mon ", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            object[] parameter = new object[] { ID };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("Delete khung_de_thi where id_khung_de = @id ", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadSelectSubject()
        {
            List<mon> lst = new List<mon>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from mon");
            foreach (DataRow r in data.Rows)
            {
                mon y = new mon();
                y.id_mon= (int)r["id_mon"];
                y.ten_mon= r["ten_mon"].ToString();
                lst.Add(y);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}