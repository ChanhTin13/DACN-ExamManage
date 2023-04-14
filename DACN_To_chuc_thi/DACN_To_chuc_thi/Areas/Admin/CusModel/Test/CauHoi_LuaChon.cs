using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.Test
{
    public class CauHoi_LuaChon
    {
        public int id_cau_hoi { get; set; }
        public string noi_dung { get; set; } 
        public List<lua_chon> DsLuaChon { get; set; }
    }
}