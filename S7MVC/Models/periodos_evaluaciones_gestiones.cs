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
    
    public partial class periodos_evaluaciones_gestiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public periodos_evaluaciones_gestiones()
        {
            this.semaforo_periodos_evaluaciones = new HashSet<semaforo_periodos_evaluaciones>();
        }
    
        public int per_eva_ges_idn { get; set; }
        public System.DateTime per_eva_ges_fecha_inicio { get; set; }
        public bool per_eva_ges_activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<semaforo_periodos_evaluaciones> semaforo_periodos_evaluaciones { get; set; }
    }
}
