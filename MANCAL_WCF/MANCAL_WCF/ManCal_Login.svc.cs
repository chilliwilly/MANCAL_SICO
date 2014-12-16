using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MANCAL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class ManCal_Login : IService
    {
        public List<Usuario> listaUsuario()
        {
            List<Usuario> ls = new List<Usuario>();

            using (var db = new ModelManCal.EntitiesManCal()) 
            {
                foreach (var usr in db.TBL_USUARIO) 
                {
                    Usuario u = new Usuario();
                    u.UsrNom = usr.USR_USRPC;
                    u.UsrPwd = usr.USR_PWD;
                    u.UsrSta = Convert.ToInt32(usr.USR_ESTADO);
                    u.UsrPerfil = Convert.ToInt32(usr.USR_PERFIL);
                    ls.Add(u);
                }
            }
            return ls;
        }


        public List<Menu> listaMenu(int nro_perfil)
        {
            List<Menu> ls = new List<Menu>();
            
            ModelManCal.EntitiesManCal db = new ModelManCal.EntitiesManCal();
            IEnumerable<ModelManCal.TBL_MENU> menu = null;

            if (nro_perfil == 1) 
            {
                menu = db.TBL_MENU.Where(it => it.MENU_FUNCU == nro_perfil).OrderBy(it=>it.MENU_ID);
            } 

            if (nro_perfil == 2) 
            {
                menu = db.TBL_MENU.Where(it => it.MENU_FUNCD == nro_perfil).OrderBy(it => it.MENU_ID);
            } 

            if (nro_perfil == 3) 
            {
                menu = db.TBL_MENU.Where(it => it.MENU_FUNCT == nro_perfil).OrderBy(it => it.MENU_ID);
            } 

            if (nro_perfil == 4) 
            {
                menu = db.TBL_MENU.Where(it => it.MENU_FUNCC == nro_perfil).OrderBy(it => it.MENU_ID);
            }

            foreach (ModelManCal.TBL_MENU m in menu)
            {
                Menu menu_usr = new Menu();
                menu_usr.MenuId = Convert.ToInt32(m.MENU_ID);
                menu_usr.MenuNom = m.MENU_NOMBRE;
                menu_usr.MenuGrp = Convert.ToInt32(m.MENU_GRUPO);
                menu_usr.MenuUrl = m.MENU_URL;
                ls.Add(menu_usr);
            }
            return ls;
        }
    }
}
