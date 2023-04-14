using DACN_To_chuc_thi.Areas.Admin.Code;
using DACN_To_chuc_thi.Areas.Admin.CusModel.GetSet;
using DACN_To_chuc_thi.Areas.Admin.CusModel.Test;
using DACN_To_chuc_thi.Models;
using Microsoft.Ajax.Utilities;
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
    public class ListTestController : Controller
    {
        // GET: Admin/BankTest
        //private List<string> list_add_failed = new List<string>();
        //private int numberAddFailed = 0;
        //int id_khung_local=0 ; 
        //string asdd = "";
        public ActionResult Index(int id_khung)
        {
            get_set_ListTest.Instance.setInt(id_khung);
            //id_khung_local =(int)id_khung; 
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] files)
        {
            //save file then read 
            try
            {
                List<string> str = new List<string>();     // Dùng để lưu đường dẫn file rồi đọc
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
                                var ServerSavePath = Path.Combine(Server.MapPath("~/App_Data/TestHistory"), InputFileName);
                                //Save file to server folder  
                                file.SaveAs(ServerSavePath);
                                str.Add(ServerSavePath);
                            }
                        }
                    }
                    if (str.Count != 0) // de phong truong hop k co file nao thoa man
                    {
                        Add_Test_by_Excel(str);
                        //ViewBag.Message = "Tải " + count.ToString() + " File lên Thành Công "; 
                    }
                }
                int x = get_set_ListTest.Instance.getInt();
                return this.Index(x);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
                return View();
            }
        }

        private int getValues(int x)
        {
            return x;
        }
        private List<CusTest> getList( )
        {
            int x = get_set_ListTest.Instance.getInt();
            DateTime dateTime = DateTime.Now;
            List<CusTest> lst = new List<CusTest>();

            object[] dethi = new object[] { x };
            DataTable data = DataProvider.Thuc_Thi.GetData("getAllTestByIdFrame @id ", dethi);

            foreach (DataRow r in data.Rows)
            {
                CusTest y = new CusTest();
                dateTime = (DateTime)r["ngay_tao"];
                int id_de = (int)r["id_de_thi"];
                int so_cau = (int)DataProvider.Thuc_Thi.ExcuteScalar("getAmountQuestion @id_de", new object[] { id_de });

                y.id_de_thi = id_de;
                y.so_cau = so_cau;
                y.ma_de_thi = r["ma_de_thi"].ToString();
                y.ngay_tao_str = dateTime.ToString("dd/MM/yyyy HH:mm");
                lst.Add(y);
            }
            return lst;
        }
        public JsonResult List()
        {
            List<CusTest> lst = getList();
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        private void Add_Test_by_Excel(List<string> file_paths)
        {
            try
            {
                int ma_de_local = 0;
                int ma_bo_cau_hoi_local = 0;
                int ma_cau_hoi_local = 0;
                foreach (var path in file_paths)
                {
                    FileInfo f = getDataFromExcelToList.Thuc_Thi.getExcelFile(path);
                    if (f.colCount == 3) //check file thoa yeu cau chua ?
                    {
                        List<string> list = f.data;

                        foreach (var item in list)
                        {
                            // lay ma de

                            if (item.Split('_')[0].Equals("op"))//lua chon bth
                            {
                                object[] para = new object[] { item.Split('_')[1], 0, ma_cau_hoi_local };
                                DataProvider.Thuc_Thi.ExecuteNonQuery("themLuaChon @noi_dung , @dung_hay_sai , @id_cau_hoi ", para);
                            }
                            else if (item.Split('_')[0].Equals("ans"))//dap an dung
                            {
                                object[] para = new object[] { item.Split('_')[1], 1, ma_cau_hoi_local };
                                DataProvider.Thuc_Thi.ExecuteNonQuery("themLuaChon @noi_dung , @dung_hay_sai , @id_cau_hoi ", para);
                            }
                            else if (item.Split('_')[0].Equals("qe"))//cau hoi
                            {
                                object[] para = new object[] { item.Split('_')[1], item.Split('_')[2], ma_bo_cau_hoi_local };
                                int x = (int)(decimal)DataProvider.Thuc_Thi.ExcuteScalar("themCauHoi @noi_dung , @diem , @id_bo_cau_hoi ", para);// tra ve ma_cau_hoi vừa thêm
                                ma_cau_hoi_local = x;// luu lại
                            }
                            else if (item.Split('_')[0].Equals("#"))//bo cau hoi
                            {
                                object[] para = new object[] { item.Split('_')[1], ma_de_local };
                                int x = (int)(decimal)DataProvider.Thuc_Thi.ExcuteScalar("themBoCauHoi @ten_bo_cau_hoi , @id_de_thi ", para);// tra ve ma_bo_cau_hoi vừa thêm
                                ma_bo_cau_hoi_local = x;// luu lại
                            }
                            else if (item.Split('_')[0].Equals("ma-de"))//ma de thi
                            {
                                int id_khung = get_set_ListTest.Instance.getInt();
                                object[] para = new object[] { item.Split('_')[1], id_khung };
                                int x = (int)(decimal)DataProvider.Thuc_Thi.ExcuteScalar("themDeThi @ma_de_thi , @id_khung_de", para);// tra ve ma de moi them
                                ma_de_local = x;// luu lại
                            }
                        }
                        //asdd = ma_de_local.ToString() + ma_bo_cau_hoi_local.ToString() + ma_cau_hoi_local.ToString();
                    }
                }
            }
            catch (Exception) { }
        }


        public JsonResult Delete(int ID)
        {

            object[] parameter = new object[] { ID };
            bool check = (bool)DataProvider.Thuc_Thi.ExcuteScalar("isTestDeletable @id  ", parameter);
            if (check == true)
            {
                int res = DataProvider.Thuc_Thi.ExecuteNonQuery("deleteTestById @id  ", parameter);
                return Json(res, JsonRequestBehavior.AllowGet); 
            }
            else
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}