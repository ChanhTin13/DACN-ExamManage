using DACN_To_chuc_thi.Areas.Admin.Code;
using DACN_To_chuc_thi.Areas.Admin.CusModel.Student;
using DACN_To_chuc_thi.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using FileInfo = DACN_To_chuc_thi.Areas.Admin.CusModel.File.FileInfo;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        // GET: Admin/Student
        private List<string> str = new List<string>();
        private List<string> list_add_failed = new List<string>();
        private int numberAddFailed = 0;
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
                    str.Clear();
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
                        Add_Students_by_Excels(str);
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

        private List<CusStudent> getList()
        {
            DateTime dateTime = new DateTime();
            List<CusStudent> lst = new List<CusStudent>();
            DataTable data = DataProvider.Thuc_Thi.GetData("select * from sinh_vien");
            foreach (DataRow r in data.Rows)
            {
                CusStudent y = new CusStudent();
                y.mssv = r["mssv"].ToString();
                y.ho_ten = r["ho_ten"].ToString();
                dateTime = (DateTime)r["ngay_sinh"];
                y.ns = dateTime.ToString("dd/MM/yyyy");
                y.gioi_tinh = (bool)r["gioi_tinh"];
                y.lop = r["lop"].ToString();

                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List()
        {
            List<CusStudent> lst = getList();
            return Json(lst, JsonRequestBehavior.AllowGet);

        }
        private void Add_Students_by_Excels(List<string> file_paths)
        {
            //try {
            foreach (var path in file_paths)
            {
                FileInfo f = getDataFromExcelToList.Thuc_Thi.getExcelFile(path);
                if (f.colCount == 5) //check file thoa yeu cau chua ?
                {
                    List<string> list = f.data;

                    foreach (var item in list)
                    {
                        var xx = item.Split('_')[0];
                        object[] para_check = new object[]  {
                                xx
                            };

                        //check
                        bool isExist = (bool)DataProvider.Thuc_Thi.ExcuteScalar("isExistedStudent @mssv", para_check);//1 la ton tai,0 deo
                        if (isExist)// da ton tai--> them vao ds failed
                        {
                            list_add_failed.Add(item.Split('_')[1]);
                            numberAddFailed++;
                        }
                        else //them sinh vien
                        {
                            double date = double.Parse(item.Split('_')[2]);
                            var dateTime = DateTime.FromOADate(date).ToString("dd/MM/yyyy");
                            object[] para = new object[]  {
                            item.Split('_')[0],
                            item.Split('_')[1],
                            dateTime,
                            item.Split('_')[3],
                            item.Split('_')[4]
                            };
                            DataProvider.Thuc_Thi.ExecuteNonQuery("themSV @mssv , @hoten , @ns , @gt , @lop", para);
                        }
                    }
                }
            }
            //} catch(Exception ex) { }
        }
       
        
        public JsonResult getbyID(string id)
        {
            List<CusStudent> lst = new List<CusStudent>();
            CusStudent y = new CusStudent();
            
            DateTime dateTime = new DateTime();
            DataTable data = DataProvider.Thuc_Thi.GetData("stuGetById N'"+id+"'");
            foreach (DataRow r in data.Rows)
            {
                y.mssv = r["mssv"].ToString();
                y.ho_ten = r["ho_ten"].ToString();
                dateTime = (DateTime)r["ngay_sinh"];
                y.ns = dateTime.ToString("DD/MM/YYYY");
                y.gioi_tinh = (bool)r["gioi_tinh"];
                y.lop = r["lop"].ToString();
                lst.Add(y);
            }
            //var m = lst.Find(x => x.mssv.Equals(canTim));
            return Json(y, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult Update(sinh_vien x)
        {
            object[] parameter = new object[] { x.mssv, x.ho_ten, x.ngay_sinh, x.gioi_tinh, x.lop };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery(" UpdateStudent @mssv , @ten , @ns , @gt  , @lop ", parameter), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            object[] parameter = new object[] { id };
            return Json(DataProvider.Thuc_Thi.ExecuteNonQuery(" deleteStuById @i ", parameter), JsonRequestBehavior.AllowGet);
        }


    }
}