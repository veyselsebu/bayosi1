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
    
    public partial class tur
    {
        public tur()
        {
            this.hayvan = new HashSet<hayvan>();
            this.irk = new HashSet<irk>();
            this.mama = new HashSet<mama>();
        }
    
        public int tur_id { get; set; }
        public string tur_aciklama { get; set; }
    
        public virtual ICollection<hayvan> hayvan { get; set; }
        public virtual ICollection<irk> irk { get; set; }
        public virtual ICollection<mama> mama { get; set; }
    }
}
