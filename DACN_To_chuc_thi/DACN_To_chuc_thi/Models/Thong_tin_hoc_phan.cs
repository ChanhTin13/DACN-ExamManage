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
    
    public partial class Thong_tin_hoc_phan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thong_tin_hoc_phan()
        {
            this.phieu_du_thi = new HashSet<phieu_du_thi>();
        }
    
        public int id_mon { get; set; }
        public string mssv { get; set; }
        public int nhom_hoc_phan { get; set; }
        public bool co_phieu_du_thi { get; set; }
        public bool da_thi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieu_du_thi> phieu_du_thi { get; set; }
        public virtual sinh_vien sinh_vien { get; set; }
        public virtual mon mon { get; set; }
    }
}