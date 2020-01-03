<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wf_test.aspx.cs" Inherits="S7MVC.Reports.wf_test" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:scriptmanager runat="server"></asp:scriptmanager>
        <rsweb:ReportViewer ID="rw_test" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="840px">
            <LocalReport ReportPath="Reports\rpt_test.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    
    </form>
</body>
</html>
