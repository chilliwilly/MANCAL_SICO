<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pwd_smaster_res.aspx.cs" Inherits="MANCAL_WEB.frm_pwd.pwd_smaster_res" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table align="center">
            <tr>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img_files/LOGO DTS UN Man Cal.bmp"/>
                </td>
            </tr>
            <tr>
                <td>
                    <h2 style="font-family:Arial; text-align:center;">Sistema Cotizacion</h2>
                </td>
            </tr>
            <tr>
                <td style="font-family:Arial; text-align:center;">
                    Ingrese datos para resetear contraseña
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
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
                <td style="text-align:center;">
                    <asp:Button ID="btnResetear" runat="server" Text="Enviar" 
                        onclick="btnResetear_Click" />
                </td>                
            </tr>            
        </table>
    </form>
</body>
</html>
