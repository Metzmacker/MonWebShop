//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonWebShop.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SousCategorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SousCategorie()
        {
            this.Articles = new HashSet<Article>();
        }
    
        public int SCAT_Id { get; set; }
        public int SCAT_CAT_Id { get; set; }
        public string SCAT_Libelle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
