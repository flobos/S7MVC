<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_usuarios_incidencias.aspx.cs" Inherits="S7MVC.Reports_Pages.frm_usuarios_incidencias" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 1056px;
        }
    </style>
    
    <script src="Scripts/jquery-3.1.0.js"></script>
    <script src="Scripts/jquery-ui.js"></script>
    <link href="Scripts/jquery-ui.css" rel="stylesheet" />
    
    <script>

        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'yy/mm/dd',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);

        $(document).ready(function () {
            $("#txt_fecha_inicio").datepicker();
            $("#txt_fecha_termino").datepicker();
        });

      


    </script> 

</head>



<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        Fecha Inicio:<asp:TextBox ID="txt_fecha_inicio" runat="server"></asp:TextBox>
        Fecha Termino:<asp:TextBox ID="txt_fecha_termino" runat="server"></asp:TextBox>
        <asp:Button ID="btn_ver" runat="server" OnClick="btn_ver_Click" Text="Ver Informe" />
        <rsweb:ReportViewer ID="rw_generico" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="988px" Height="693px">
            <LocalReport ReportPath="Reports\rpt_usuarios_incidencias.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    
    </form>
</body>
</html>
