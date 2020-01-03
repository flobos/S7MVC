using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace S7MVC.Models
{
    [MetadataType(typeof(usuarios.Metadata))]
    public partial class usuarios
    {

        sealed class Metadata {
            [Display(Name = "Id Usuarios")]
            [Required]
            public int usu_idn { get; set; }
            [Display(Name = "Nombre")]
            [Required]
            public string usu_nombres { get; set; }
            [Display(Name = "Apellidos")]
            [Required]
            public string usu_apellidos { get; set; }
            [Display(Name = "Rut")]
            [Required]
            public string usu_id_nacional { get; set; }
            [Display(Name = "Email")]
            [Required]
            public string usu_email { get; set; }
            [Display(Name = "Clave")]
            [Required]
            public string usu_clave { get; set; }

        }
    }
}