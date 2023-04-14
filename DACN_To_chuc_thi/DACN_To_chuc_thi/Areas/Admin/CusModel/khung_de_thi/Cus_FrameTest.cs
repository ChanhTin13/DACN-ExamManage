using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.khung_de_thi
{
    public class Cus_FrameTest: DACN_To_chuc_thi.Models.khung_de_thi
    {
        //DACN_Model
        public string ngay_tao_str { get; set; }
        public string ten_mon { get; set; }
        public int so_de { get; set; }
    }
}