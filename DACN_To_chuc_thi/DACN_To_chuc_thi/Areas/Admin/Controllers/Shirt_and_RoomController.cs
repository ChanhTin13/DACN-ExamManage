using DACN_To_chuc_thi.Areas.Admin.CusModel.Student;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class Shirt_and_RoomController : Controller
    {
        // GET: Admin/Shirt_and_Room
        public ActionResult Index()
        {
            return View();
        }
        private List<phong_thi> getList()
        { 
            List<phong_thi> lst = new List<phong_thi>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from phong_thi");
            foreach (DataRow r in data.Rows)
            {
                phong_thi y = new phong_thi();
                y.id_phong_thi = (int)r["id_phong_thi"] ;
                y.ten_phong_thi = r["ten_phong_thi"].ToString();  
                y.so_luong_may = (int)r["so_luong_may"] ;

                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List()
        {
            List<phong_thi> lst = getList();
            return Json(lst, JsonRequestBehavior.AllowGet);

        }
        public JsonResult getbyID(int ID)
        {
            List<phong_thi> lst = getList();
            var m = lst.Find(x => x.id_phong_thi.Equals(ID));
            return Json(m, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(phong_thi x)
        {
            object[] parameter = new object[] { x.ten_phong_thi, x.so_luong_may };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("insert into phong_thi values( @ten_phong_thi , @so_luong_may )", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(phong_thi x)
        {
            object[] parameter = new object[] { x.id_phong_thi, x.ten_phong_thi, x.so_luong_may };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("UpdatePhongThi @id , @ten_phong_thi , @so_luong_may ", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            object[] parameter = new object[] { ID };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("Delete phong_thi where id_phong_thi = @id ", parameter), JsonRequestBehavior.AllowGet);
        }
    }
}