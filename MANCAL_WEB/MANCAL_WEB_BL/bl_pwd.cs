using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_BL.ManCal_Login;

namespace MANCAL_WEB_BL
{
    public class bl_pwd
    {
        bl_mail objMail;
        bl_codificar_pwd objCodPwd;
        ServiceClient usrPassword = new ServiceClient();
        String resetPwd = "5f4dcc3b5aa765d61d8327deb882cf99";// password

        public Boolean setPasswordReset(String usr_name)
        {
            objMail = new bl_mail();
            var lsUsr = usrPassword.listaUsuario();
            Boolean flag = false;

            foreach (Usuario u in lsUsr)
            {
                if (u.UsrNom.Equals(usr_name)) 
                {
                    usrPassword.updateUsrPassword(usr_name, resetPwd);
                    objMail.envioMailRenueva(usr_name);
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public Boolean setPasswordChange(String usr_name, String usr_old_pwd, String usr_new_pwd)
        {
            Boolean flag = false;
            objCodPwd = new bl_codificar_pwd();
            objMail = new bl_mail();                        
            String new_pwd = objCodPwd.cryptoPwd(usr_new_pwd);
            String old_pwd = objCodPwd.cryptoPwd(usr_old_pwd);
            var lsUsr = usrPassword.listaUsuario();

            foreach (Usuario u in lsUsr)
            {
                if (u.UsrNom.Equals(usr_name)) 
                {
                    if (u.UsrPwd.Equals(old_pwd)) 
                    {
                        usrPassword.updateUsrPassword(usr_name, new_pwd);
                        objMail.envioMailCambia(usr_name);
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
    }
}
