using DACN_To_chuc_thi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Areas.Admin.CusModel.GetSet
{
    public class get_set_ListTest
    {
        private static get_set_ListTest instance;
        public static get_set_ListTest Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new get_set_ListTest();
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