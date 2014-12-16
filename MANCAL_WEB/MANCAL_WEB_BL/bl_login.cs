using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_BL.ManCal_Login;

namespace MANCAL_WEB_BL
{
    public class bl_login
    {
        ServiceClient login = new ServiceClient();
        bl_codificar_pwd objCodificar = new bl_codificar_pwd();

        public bool validaUsuario(String usr_nick, String usr_pwd) 
        {
            bool valida = false;
            var lsUsr = login.listaUsuario();

            foreach (Usuario usr in lsUsr) 
            {
                if (usr.UsrNom.Equals(usr_nick)) 
                {
                    if (usr.UsrPwd.Equals(objCodificar.cryptoPwd(usr_pwd))) 
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

            var lsUsr = login.listaUsuario();

            foreach (Usuario usr in lsUsr)
            {
                if (usr.UsrNom.Equals(usr_nick))
                {
                    if (usr.UsrSta == 1)
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

            var lsUsr = login.listaUsuario();

            foreach (Usuario usr in lsUsr)
            {
                if (usr.UsrNom.Equals(usr_nick))
                {
                    perfil = usr.UsrPerfil.ToString();
                }
            }
            return perfil;
        }
    }
}
