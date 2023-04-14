using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.To_thi
{
    public class CusToThi:to_thi
    {
        public int so_thi_sinh { get; set; }
        public int id_phong { get; set; }
        public string ten_phong { get; set; }
        public int so_ghe { get; set; }
        public string ngay_thi_str { get; set; }
    }
}