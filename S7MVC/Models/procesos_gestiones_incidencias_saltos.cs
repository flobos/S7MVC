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
    
    public partial class procesos_gestiones_incidencias_saltos
    {
        public int pro_ges_inc_sal { get; set; }
        public int pro_ges_inc_idn { get; set; }
        public int pro_ges_inc_idn_salta { get; set; }
    
        public virtual procesos_gestiones_incidencias procesos_gestiones_incidencias { get; set; }
        public virtual procesos_gestiones_incidencias procesos_gestiones_incidencias1 { get; set; }
    }
}
