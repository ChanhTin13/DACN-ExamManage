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
    
    public partial class lua_chon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lua_chon()
        {
            this.ct_bai_lam = new HashSet<ct_bai_lam>();
        }
    
        public int id_lua_chon { get; set; }
        public string noi_dung { get; set; }
        public bool dung_hay_sai { get; set; }
        public int id_cau_hoi { get; set; }
    
        public virtual Cau_hoi Cau_hoi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ct_bai_lam> ct_bai_lam { get; set; }
    }
}
