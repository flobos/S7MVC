//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S7MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class empresas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empresas()
        {
            this.empresas_usuarios_sedes = new HashSet<empresas_usuarios_sedes>();
        }
    
        public int emp_idn { get; set; }
        public string emp_id_nacional { get; set; }
        public string emp_nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresas_usuarios_sedes> empresas_usuarios_sedes { get; set; }
    }
}