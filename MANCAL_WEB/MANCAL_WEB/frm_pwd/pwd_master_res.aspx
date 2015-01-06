<%@ Page Title="Resetear Contraseña - Sistema Cotizacion" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="pwd_master_res.aspx.cs" Inherits="MANCAL_WEB.frm_pwd.pwd_master_res" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Resetear Contraseña</h1>
    <br />
    <table>
        <tr>
            <td style="text-align:center; font-family:Arial;">
                Usuario
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtUser" runat="server" style="text-align:center;" ReadOnly="true"></asp:TextBox>
            </td>
        </tr> 
        <tr><td></td></tr>         
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="btnResetear" runat="server" Text="Enviar" 
                    onclick="btnResetear_Click" />
            </td>                
        </tr>            
    </table>
</asp:Content>
