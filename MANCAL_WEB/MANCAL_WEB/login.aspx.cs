﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;

namespace MANCAL_WEB
{
    public partial class login : System.Web.UI.Page
    {
        bl_login objLogin;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //txtUser.Text = System.Environment.UserName;  
                String txtUsr = "$('#inputEmail').val('" + System.Environment.UserName + "');";
                ClientScript.RegisterStartupScript(typeof(string), "ServerControlScript", txtUsr, true);
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            String u = String.Format("{0}", Request.Form["username"]);// txtUser.Text;
            String p = String.Format("{0}", Request.Form["password"]);// txtPwd.Text;
            objLogin = new bl_login();

            if (objLogin.validaEstadoUsr(u))
            {
                if (!objLogin.validaUsuario(u, p))
                {
                    String notificacionUno = "alert(\"Usuario o Contraseña ingresada no coincide.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                    Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
                }
                else
                {
                    String v_pr = objLogin.getPerfilUsr(u);
                    String pcusr = System.Environment.UserName;

                    Session["usr_pc"] = System.Environment.UserName;
                    Session["COT_VAL_SHW"] = "2";

                    HttpCookie cookie_perfil = new HttpCookie("v_pr");
                    HttpCookie cookie_pcusr = new HttpCookie("pcusr");
                    HttpCookie cookie_acredi = new HttpCookie("acredi");

                    cookie_perfil.Value = v_pr;
                    cookie_pcusr.Value = pcusr;

                    cookie_perfil.Expires = DateTime.Now.AddMinutes(60);
                    cookie_pcusr.Expires = DateTime.Now.AddMinutes(60);

                    Response.Cookies.Add(cookie_perfil);
                    Response.Cookies.Add(cookie_pcusr);
                    Response.Cookies.Add(cookie_acredi);

                    Response.Redirect("~/index.aspx");
                }
            }
            else
            {
                String notificacionUno = "alert(\"Usuario ingresado no esta habilitado.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", notificacionUno, true);
                Response.AddHeader("REFRESH", "0.5;URL=login.aspx");
            }
        }
    }
}