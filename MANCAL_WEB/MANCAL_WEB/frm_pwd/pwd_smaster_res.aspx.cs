using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            pwd_bal objPwd = new pwd_bal();

            if (!objPwd.setPasswordReset(txtUser.Text))
            {
                String notificacionUno = "alert(\"Usuario ingresado no coincide o no existe.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
            }
            else
            {
                Response.AddHeader("REFRESH", "0.5;URL=/forms_load/load_pwd_recordar.aspx");
            }
        }
    }
}