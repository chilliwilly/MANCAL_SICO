<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rpt_cotizacion_cal.aspx.cs" Inherits="MANCAL_WEB.frm_reporte.rpt_cotizacion_cal" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=9.0.15.225, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <telerik:ReportViewer ID="rptViewer" runat="server" height="630px" width="100%"></telerik:ReportViewer>
    </div>
    </form>
</body>
</html>
