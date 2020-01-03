using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace S7MVC.Reports_Pages
{
    public partial class rpt_incidencias_resumen_general : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ver_Click(object sender, EventArgs e)
        {

            DataTable _dt = obtiene_datos();

            rw_generico.LocalReport.DataSources.Clear();
            rw_generico.LocalReport.DataSources.Add(new ReportDataSource("ds", _dt));
            rw_generico.LocalReport.Refresh();
        }

        private DataTable obtiene_datos()
        {

            DataTable _dt_resultado = new DataTable();

            SqlConnection _conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sieteConnectionString"].ConnectionString);
            SqlCommand _comando = new SqlCommand("rpt_usaurios_incidencias", _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Add("@fecha_inicio", SqlDbType.DateTime).Value = DateTime.Parse("2014-01-01 00:00:00");
            _comando.Parameters.Add("@fecha_termino", SqlDbType.DateTime).Value = DateTime.Parse("2017-01-01 00:00:00");

            SqlDataAdapter _adaptador = new SqlDataAdapter(_comando);
            _adaptador.Fill(_dt_resultado);


            return _dt_resultado;
        }
    }
}