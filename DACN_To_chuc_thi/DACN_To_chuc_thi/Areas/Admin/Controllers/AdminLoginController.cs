using DACN_To_chuc_thi.Areas.Admin.Code;
using DACN_To_chuc_thi.Areas.AdminModel;
using DACN_To_chuc_thi.Areas.AdminModels;
using DACN_To_chuc_thi.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACN_To_chuc_thi.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            //var result = new AccountModel().Login(model.Email, model.Password);
            object[] parameter = new object[] 
            { 
                model.Email, 
                model.Password 
            };
            var result = (bool)DataProvider.Thuc_Thi.ExcuteScalar("Account_Login @email , @mat_khau ",parameter );
            if (result && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession()
                //{
                //    id=model.id,
                //    Email= model.Email
                //});
                Session["ad_id"] = model.id;
                return RedirectToAction("Index", "AdHome");
            }
            else
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu không khớp");
            }
            return View(model);
        }
    }
}