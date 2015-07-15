using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;

namespace MANCAL_WEB.frm_pwd
{
    public partial class pwd_smaster_res : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                txtUser.Text = System.Environment.UserName;
            }
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
            bl_pwd objPwd = new bl_pwd();            

            if (!objPwd.setPasswordReset(txtUser.Text))
            {
                String notificacionUno = "alert(\"Usuario ingresado no coincide o no existe.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
            }
            else
            {
                String notificacionUno = "alert(\"Contraseña se ha reseteado. Se le ha enviado un email con la nueva contraseña.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                Response.AddHeader("REFRESH", "0.5;URL=/login.aspx");
            }
        }
    }
}