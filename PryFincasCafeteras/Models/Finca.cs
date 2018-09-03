//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PryFincasCafeteras.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Finca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Finca()
        {
            this.FincaAsociado = new HashSet<FincaAsociado>();
            this.Trabajador = new HashSet<Trabajador>();
        }
    
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdVereda { get; set; }
    
        public virtual Vereda Vereda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FincaAsociado> FincaAsociado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trabajador> Trabajador { get; set; }
    }
}
