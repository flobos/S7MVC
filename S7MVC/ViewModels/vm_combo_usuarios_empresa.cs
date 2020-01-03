using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S7MVC.ViewModels
{
    public class vm_combo_usuarios_empresa
    {


        [DisplayName("Id")]
        public int emp_usu_sed_idn { get; set; }
        [DisplayName("Usuario")]
        public string usu_nombres { get; set; }

    }
}