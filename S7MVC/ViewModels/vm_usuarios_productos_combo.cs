using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S7MVC.ViewModels
{
    public class vm_usuarios_productos_combo
    {

       
        [DisplayName("Id")]
        public int usu_pro_idn { get; set; }
        [DisplayName("Producto(s)")]
        public string pro_nombre { get; set; }
        
    }
}