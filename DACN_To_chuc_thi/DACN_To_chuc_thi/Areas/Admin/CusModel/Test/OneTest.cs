using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.Test
{ 
    public class OneTest
    {
        public int id_de { get; set; }
        public string ten_ma_de { get; set; }
        public string ten_mon_hoc { get; set; }
        public List<MotBoCauHoi> noi_dung_de_thi { get; set; }
    }
}