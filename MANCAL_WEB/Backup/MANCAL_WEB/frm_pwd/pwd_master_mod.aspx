<%@ Page Title="Cambio Contraseña - Sistema Cotizacion" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="pwd_master_mod.aspx.cs" Inherits="MANCAL_WEB.frm_pwd.pwd_master_mod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Modificar Contraseña</h1>
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
        <tr>
            <td style="text-align:center; font-family:Arial;">
                Contraseña Antigua
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:center; font-family:Arial;">
                Contraseña Nueva
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtPwdNew" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:center; font-family:Arial;">
                Repita Contraseña Nueva
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:TextBox ID="txtPwdNewR" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr><td></td></tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" 
                    onclick="btnCambiar_Click" />
            </td>                
        </tr>            
    </table>        
</asp:Content>
