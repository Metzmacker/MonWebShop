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
    
    public partial class DetailCommande
    {
        public int DCOM_Id { get; set; }
        public int DCOM_COM_Id { get; set; }
        public int DCOM_ART_Id { get; set; }
        public int DCOM_Quantite { get; set; }
        public decimal DCOM_PrixUnitaire { get; set; }
    
        public virtual Article Article { get; set; }
        public virtual Commande Commande { get; set; }
    }
}
