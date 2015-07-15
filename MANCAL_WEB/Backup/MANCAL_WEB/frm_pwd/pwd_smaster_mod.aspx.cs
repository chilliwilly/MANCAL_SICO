using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;

namespace MANCAL_WEB.frm_pwd
{
    public partial class pwd_smaster_mod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUser.Text = System.Environment.UserName;
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            bl_pwd objPwd = new bl_pwd();

            if (!(txtPwdNew.Text.Equals(txtPwdNewR.Text)))
            {
                String notificacionUno = "alert(\"Contraseñas nuevas no coinciden.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
            }
            else
            {
                if (!objPwd.setPasswordChange(txtUser.Text, txtPwd.Text, txtPwdNew.Text))
                {
                    String notificacionUno = "alert(\"Contraseña ingresada no coincide.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                }
                else
                {
                    String notificacionUno = "alert(\"Contraseña se ha cambiado exitosamente.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                    Response.AddHeader("REFRESH", "0.5;URL=/login.aspx");
                }
            }
        }
    }
}