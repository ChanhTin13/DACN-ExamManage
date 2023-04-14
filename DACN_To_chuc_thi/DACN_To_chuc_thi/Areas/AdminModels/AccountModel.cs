using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.AdminModel
{
    public class AccountModel
    {
        private DACN_To_Chuc_ThiEntities context;
        public AccountModel()
        {
            context=new DACN_To_Chuc_ThiEntities();
        }
        public bool Login(string email,string mk)
        {
            object[] xxx= {
                new SqlParameter("@email", email),
                new SqlParameter("@mat_khau", mk),
            };
            var result = context.Database.SqlQuery<bool>("Account_Login @email,@mat_khau", xxx).SingleOrDefault(); 
            return result;
        }
    }
}