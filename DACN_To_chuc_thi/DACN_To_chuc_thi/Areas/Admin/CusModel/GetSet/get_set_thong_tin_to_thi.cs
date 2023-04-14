using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.GetSet
{
    public class get_set_thong_tin_to_thi
    {
        private static get_set_thong_tin_to_thi instance;
        public static get_set_thong_tin_to_thi Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new get_set_thong_tin_to_thi();
                }
                return instance;
            }
        }
        private int int_val;
        public void setInt(int x)
        {
            int_val = x;
        }
        public int getInt()
        {
            return int_val;
        }
    }
}