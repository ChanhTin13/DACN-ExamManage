using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.AdminModels
{
    public class SubjectPageModel : mon
    {
        public int amount_Subject_Satisfied { get; set; }
        public int total_pages { get; set; }

    }
}