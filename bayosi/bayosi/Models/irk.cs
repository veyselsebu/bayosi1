//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bayosi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class irk
    {
        public irk()
        {
            this.hayvan = new HashSet<hayvan>();
        }
    
        public int irk_id { get; set; }
        public string irk_adi { get; set; }
        public int tur_id { get; set; }
        public string irk_aciklama { get; set; }
    
        public virtual ICollection<hayvan> hayvan { get; set; }
        public virtual tur tur { get; set; }
    }
}