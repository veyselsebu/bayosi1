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
    
    public partial class personel
    {
        public personel()
        {
            this.besleme = new HashSet<besleme>();
            this.kullanici = new HashSet<kullanici>();
            this.tedavi = new HashSet<tedavi>();
        }
    
        public int tc_no { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public int tel_no { get; set; }
        public string adres { get; set; }
        public int meslek_id { get; set; }
        public byte[] resim { get; set; }
    
        public virtual ICollection<besleme> besleme { get; set; }
        public virtual ICollection<kullanici> kullanici { get; set; }
        public virtual meslek meslek { get; set; }
        public virtual ICollection<tedavi> tedavi { get; set; }
    }
}
