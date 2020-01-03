<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rpt_incidencias_resumen_general.aspx.cs" Inherits="S7MVC.Reports_Pages.rpt_incidencias_resumen_general" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        });

        $(document).ready(function () {
            $("#txt_fecha_termino").datepicker();
        });


    </script> 


</head>
<body style="height: 1208px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        Fecha Inicio:<asp:TextBox ID="txt_fecha_inicio" runat="server"></asp:TextBox>
        Fecha Termino<asp:TextBox ID="txt_fecha_termino" runat="server"></asp:TextBox>
        <asp:Button ID="btn_ver" runat="server" OnClick="btn_ver_Click" Text="Ver Informe" />
        <rsweb:ReportViewer ID="rw_generico" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1006px">
            <LocalReport ReportPath="Reports\rpt_incidencias_resumen_general.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
