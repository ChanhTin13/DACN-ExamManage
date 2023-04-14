using DACN_To_chuc_thi.Areas.Admin.Code;
using DACN_To_chuc_thi.Areas.Admin.CusModel.DsHocPhan;
using DACN_To_chuc_thi.Areas.Admin.CusModel.khung_de_thi;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileInfo = DACN_To_chuc_thi.Areas.Admin.CusModel.File.FileInfo;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class DsHocPhanController : Controller
    {
        // GET: Admin/DsHocPhan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] files)
        {
            //save file then read 
            try
            {
                //Ensure model state is valid  
                if (ModelState.IsValid)
                {   //iterating through multiple file collection   
                    int count = 0;
                    List<string> str = new List<string>();

                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            if ((file.ContentType.Split('/')[0] == "application") && (file.ContentType.Contains("sheet")))
                            {
                                count++;
                                var InputFileName = Path.GetFileName(file.FileName);
                                var ServerSavePath = Path.Combine(Server.MapPath("~/App_Data/StudentHistory"), InputFileName);
                                //Save file to server folder  
                                file.SaveAs(ServerSavePath);
                                str.Add(ServerSavePath);
                            }
                        }
                    }
                    if (str.Count != 0) // de phong truong hop k co file nao thoa man
                    {
                        ThemDsHocPhanBangFileExcel(str);
                        //ViewBag.Message = "Tải " + count.ToString() + " File lên Thành Công ";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View();
            }

        }

        private List<CusDsHocPhan> getList(int id )
        {
            int id_mon;
            if (id==-1)
            {
                id_mon = (int)DataProvider.Thuc_Thi.ExcuteScalar("select *  from mon");
            }
            else
            { 
                id_mon = id; 
            }

            List<CusDsHocPhan> lst = new List<CusDsHocPhan>();
            DataTable data = DataProvider.Thuc_Thi.GetData("layDsHocPhanBangIdMon @id_mon", new object[] { id_mon });
            foreach (DataRow r in data.Rows)
            {
                CusDsHocPhan y = new CusDsHocPhan();
                y.mssv = r["mssv"].ToString();
                y.ho_ten = r["ho_ten"].ToString();
                y.gioi_tinh = (bool)r["gioi_tinh"];
                y.lop = r["lop"].ToString();
                y.nhom_hoc_phan = (int)r["nhom_hoc_phan"];
                y.da_thi = (bool)r["da_thi"];
                y.co_phieu_du_thi = (bool)r["co_phieu_du_thi"];
                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List(int id)
        {
            List<CusDsHocPhan> lst = getList(id);
            return Json(lst, JsonRequestBehavior.AllowGet);

        } 
        private void ThemDsHocPhanBangFileExcel(List<string> file_paths)
        {
            //try {
            foreach (var path in file_paths)
            {
                FileInfo f = getDataFromExcelToList.Thuc_Thi.getExcelFile(path);
                if (f.colCount == 3) //check file thoa yeu cau chua ?
                {
                    List<string> list = f.data;

                    foreach (var item in list)
                    {
                        var _id_mon = item.Split('_')[0];
                        var _mssv = item.Split('_')[1];
                        var _nhom_hp = item.Split('_')[2];
                        //kiểm tra môn
                        bool coMon = (bool)DataProvider.Thuc_Thi.ExcuteScalar("kiemTraMonHocKhiNhapDsHp @id_mon", new object[] { _id_mon });//1 la ton tai,0 la deo
                        //kiểm tra sinh viên
                        bool svHopLe = (bool)DataProvider.Thuc_Thi.ExcuteScalar("kiemTraSvKhiNhapDsHp @mssv , @id_mon", new object[] { _mssv , _id_mon });//1 la thỏa mãn,0 la deo
                        if (coMon == true && svHopLe == true)//them sinh vien  
                        {
                            DataProvider.Thuc_Thi.ExecuteNonQuery("themDsHp @id_mon , @mssv , @nhomhp", new object[] { _id_mon, _mssv, _nhom_hp });
                        }
                    }
                }
            }
            //} catch(Exception ex) { }
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