using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Admin/Subject 
        public ActionResult Index()
        {

            return View();

        }
        public JsonResult List()
        {
            List<mon> lst = new List<mon>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from mon");
            foreach (DataRow r in data.Rows)
            {
                mon y = new mon();
                y.id_mon = (int)r["id_mon"];
                y.ten_mon = r["ten_mon"].ToString();
                y.stc = (int)r["stc"];
                lst.Add(y);
            }
            return Json(lst, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetbyID(int ID)
        {
            List<mon> lst = new List<mon>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from mon");
            foreach (DataRow r in data.Rows)
            {
                mon y = new mon();
                y.id_mon = (int)r["id_mon"];
                y.ten_mon = r["ten_mon"].ToString();
                y.stc = (int)r["stc"];
                lst.Add(y);
            }
            var m = lst.Find(x=>x.id_mon.Equals(ID));
            return Json(m, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult Add(mon x)
        { 
            object[] parameter = new object[] { x.ten_mon, x.stc };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("insert into mon values( @ten_mon , @stc )", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(mon x)
        {
            object[] parameter = new object[] {x.id_mon, x.ten_mon, x.stc };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("UpdateSubject @id , @ten , @stc ", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            object[] parameter = new object[] { ID };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery("Delete mon where id_mon = @id ", parameter), JsonRequestBehavior.AllowGet);
        }
    }
}