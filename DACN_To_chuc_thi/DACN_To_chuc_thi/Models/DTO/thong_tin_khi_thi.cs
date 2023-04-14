using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Models.DTO
{
    public class thong_tin_khi_thi
    {
        public int id_phieu_du_thi { get; set; }
        public string ten_mon { get; set; }
        public string ho_ten { get; set; }
        public string mssv { get; set; }
        public int thoi_luong_thi { get; set; }
        public DateTime ngay_thi { get; set; }
        public string ngay_thi_str { get; set; }
        public int id_de_thi { get; set; }
        public string gio_bd { get; set; }
        public string gio_kt { get; set; }
        public string ma_de_thi { get; set; }
        public int so_cau { get; set; }
    }
}