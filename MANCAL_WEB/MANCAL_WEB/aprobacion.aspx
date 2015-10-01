<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="aprobacion.aspx.cs" Inherits="MANCAL_WEB.aprobacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <div>
        <input type="text" id="CI" />
        <input type="text" id="keyPwd" />
        <input type="button" value="Jquery" onclick="CallService(); return false;" />
        <input type="button" value="WSDL" onclick="soap();" />
    </div>
</asp:Content>
