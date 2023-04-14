using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.Test
{
    public class MotBoCauHoi
    {
        public int id_bo_cau_hoi { get; set; }
        public string ten_bo_cau_hoi { get; set; }
        public List<CauHoi_LuaChon> CauHoi_LuaChon { get; set; } 
    }
}