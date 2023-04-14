using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.ToChucThi
{
    public class CusMonThi_NhomHp
    {
        public int id_mon { get; set; }
        public List<chiaDe> lst_chiaDe { get; set; }
    }
}