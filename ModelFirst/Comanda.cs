//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comanda()
        {
            this.ComandaDetalles = new HashSet<ComandaDetalle>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Mesa { get; set; }
        public string Comentario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComandaDetalle> ComandaDetalles { get; set; }
    }
}