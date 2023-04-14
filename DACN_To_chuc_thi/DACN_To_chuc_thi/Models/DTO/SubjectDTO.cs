using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DACN_To_chuc_thi.Models.DTO
{
    public class SubjectDTO
    {
        private int id_mon;
        private string ten_mon;
        private int stc;

        public SubjectDTO(int id_mon, string ten_mon, int stc)
        {
            this.Id_mon = id_mon;
            this.Ten_mon = ten_mon;
            this.Stc = stc;
        }
        public SubjectDTO(DataRow r)
        {
            this.Id_mon = (int)r["id_mon"]; ;
            this.Ten_mon = r["ten_mon"].ToString();
            this.Stc = (int)r["sct"];
        }

        public int Id_mon { get => id_mon; set => id_mon = value; }
        public string Ten_mon { get => ten_mon; set => ten_mon = value; }
        public int Stc { get => stc; set => stc = value; }
    }
}