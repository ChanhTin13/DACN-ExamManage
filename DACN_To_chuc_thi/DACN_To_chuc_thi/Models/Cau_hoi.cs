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
    
    public partial class Cau_hoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cau_hoi()
        {
            this.lua_chon = new HashSet<lua_chon>();
        }
    
        public int id_cau_hoi { get; set; }
        public string noi_dung { get; set; }
        public double diem { get; set; }
        public int id_bo_cau_hoi { get; set; }
    
        public virtual bo_cau_hoi bo_cau_hoi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lua_chon> lua_chon { get; set; }
    }
}