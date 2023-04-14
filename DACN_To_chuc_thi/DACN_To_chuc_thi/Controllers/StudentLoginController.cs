using DACN_To_chuc_thi.Areas.Admin.Code;
using DACN_To_chuc_thi.Areas.AdminModels;
using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Controllers
{
    public class StudentLoginController : Controller
    {
        // GET: StudentLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(sinh_vien model)
        {
            //var result = new AccountModel().Login(model.Email, model.Password);
            object[] parameter = new object[]
            {
                model.mssv,
                model.mat_khau
            };
            var result = (bool)DataProvider.Thuc_Thi.ExcuteScalar("StudentLogin @mssv , @mat_khau ", parameter);
            if (result && ModelState.IsValid)
            {
                Session["sv_mssv"] = model.mssv;
                return RedirectToAction("Index", "ChonMonThi");
            }
            else
            {
                ModelState.AddModelError("", "Mssv hoặc mật khẩu không khớp");
            }
            return View(model);
        }
    }

}