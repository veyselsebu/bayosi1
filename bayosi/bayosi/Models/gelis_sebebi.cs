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
    
    public partial class gelis_sebebi
    {
        public gelis_sebebi()
        {
            this.hayvan = new HashSet<hayvan>();
        }
    
        public int gelis_sebebi_id { get; set; }
        public string gelis_sebebi1 { get; set; }
        public string aciklama { get; set; }
    
        public virtual ICollection<hayvan> hayvan { get; set; }
    }
}
