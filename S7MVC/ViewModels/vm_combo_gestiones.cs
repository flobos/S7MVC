using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace S7MVC.ViewModels
{
    public class vm_combo_gestiones
    {


        [DisplayName("Id")]
        public int pro_ges_inc_idn { get; set; }
        [DisplayName("Gestiones")]
        public string ges_inc_nombre { get; set; }

    }
}