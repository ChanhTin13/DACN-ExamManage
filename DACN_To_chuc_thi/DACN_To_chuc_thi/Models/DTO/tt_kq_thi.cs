using DACN_To_chuc_thi.Areas.Admin.CusModel.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Models.DTO
{
    public class tt_kq_thi
    {
        public List<int> lst_int { get; set; }
        public List<MotBoCauHoi> lst_bch { get; set; }
        public int diem { get; set; }
    }
}