using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_DL;
using MANCAL_WEB_CLASS;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_login
    {
        bl_codificar_pwd objCodificar = new bl_codificar_pwd();
        dl_login objLogin;

        public bool validaUsuario(String usr_nick, String usr_pwd) 
        {
            bool valida = false;
            objLogin = new dl_login();

            DataTable dt = objLogin.selectUsuario();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["USR_USRPC"].ToString().Equals(usr_nick))
                {
                    if (dr["USR_PWD"].ToString().Equals(objCodificar.cryptoPwd(usr_pwd))) 
                    {
                        valida = true;
                        break;
                    }
                }
            }
            return valida;
        }

        public bool validaEstadoUsr(String usr_nick) 
        {
            bool valida = false;
            objLogin = new dl_login();

            DataTable dt = objLogin.selectUsuario();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["USR_USRPC"].ToString().Equals(usr_nick))
                {
                    if (dr["USR_ESTADO"].ToString().Equals("1"))
                    {
                        valida = true;
                        break;
                    }
                }
            }
            return valida;
        }

        public String getPerfilUsr(String usr_nick) 
        {
            String perfil = "";
            objLogin = new dl_login();

            DataTable dt = objLogin.selectUsuario();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["USR_USRPC"].ToString().Equals(usr_nick))
                {
                    perfil = dr["USR_PERFIL"].ToString();
                    break;
                }
            }
            return perfil;
        }

        public void actualizaPwdUsuario(String usr, String pwd) 
        {
            objLogin = new dl_login();
            objLogin.updatePassword(usr, pwd);
        }

        public void actualizaEstadoUsr(String usrid) 
        {
            int idusr = Convert.ToInt32(usrid);
            objLogin = new dl_login();
            objLogin.updateEstadoUsuario(idusr);
        }
    }
}
