using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.To_thi
{
    public class ThongTinToThi:sinh_vien
    {
        public string ten_mon { get; set; }
        public string ma_de { get; set; }
        public int thoi_luong_thi { get; set; } 
    }
}