//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DACN_To_chuc_thi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class phieu_du_thi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieu_du_thi()
        {
            this.bai_lam = new HashSet<bai_lam>();
        }
    
        public int id_phieu_du_thi { get; set; }
        public bool het_gio { get; set; }
        public bool da_thi { get; set; }
        public int id_phong_thi { get; set; }
        public int id_de_thi { get; set; }
        public int id_mon { get; set; }
        public string mssv { get; set; }
        public int id_to_thi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bai_lam> bai_lam { get; set; }
        public virtual de_thi de_thi { get; set; }
        public virtual phong_thi phong_thi { get; set; }
        public virtual Thong_tin_hoc_phan Thong_tin_hoc_phan { get; set; }
        public virtual to_thi to_thi { get; set; }
    }
}