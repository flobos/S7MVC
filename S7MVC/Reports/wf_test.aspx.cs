using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S7MVC.Models;
using Microsoft.Reporting.WebForms;

namespace S7MVC.Reports
{
    public partial class wf_test : System.Web.UI.Page
    {
        private sieteEntidades db = new sieteEntidades();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack) {

                List<usuarios> allusuarios = new List<usuarios>();

                allusuarios = db.usuarios.ToList();

                this.rw_test.LocalReport.DataSources.Clear();

                ReportDataSource rds_test = new ReportDataSource("ds", allusuarios);

                this.rw_test.LocalReport.DataSources.Add(rds_test);
            
                this.rw_test.LocalReport.Refresh();
            }



        }
    }
}