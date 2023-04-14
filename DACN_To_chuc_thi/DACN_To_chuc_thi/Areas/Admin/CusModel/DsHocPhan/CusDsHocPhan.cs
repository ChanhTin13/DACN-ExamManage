using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.DsHocPhan
{
    public class CusDsHocPhan:sinh_vien
    {
        public int nhom_hoc_phan { get; set; }
        public bool co_phieu_du_thi { get; set; }
        public bool da_thi { get; set; }
    }
}