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
    
    public partial class ct_bai_lam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ct_bai_lam()
        {
            this.ket_qua = new HashSet<ket_qua>();
        }
    
        public int id_bai_lam { get; set; }
        public int id_lua_chon { get; set; }
    
        public virtual bai_lam bai_lam { get; set; }
        public virtual lua_chon lua_chon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ket_qua> ket_qua { get; set; }
    }
}
