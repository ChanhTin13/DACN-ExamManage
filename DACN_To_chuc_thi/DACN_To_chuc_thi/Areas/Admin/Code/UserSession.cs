using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.Code
{
    [Serializable]
    public class UserSession
    {
        public int id { get; set; } 
        public string Email { get; set; }
    }
}