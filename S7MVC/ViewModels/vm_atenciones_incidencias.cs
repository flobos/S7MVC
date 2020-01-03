using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S7MVC.ViewModels
{
    public class vm_atenciones_incidencias
    {

        [DisplayName("Genre")]
        public int usu_idn { get; set; }
        [DisplayName("Productos")]
        [Required]
        public int usu_pro_idn { get; set; }

        [DisplayName("Tipo incidencia")]
        [Required]
        public int tip_inc_idn { get; set; }

        [DisplayName("Incidencia")]
        [Required]
        public int inc_idn { get; set; }
        [DisplayName("Descripcion")]
        [Required]
        public string ate_inc_observacion { get; set; }





    }
}