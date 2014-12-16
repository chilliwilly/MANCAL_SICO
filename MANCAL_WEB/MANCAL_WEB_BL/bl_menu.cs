using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_BL.ManCal_Login;
using MANCAL_WEB_CLASS;

namespace MANCAL_WEB_BL
{
    public class bl_menu
    {
        ServiceClient svMenu = new ServiceClient();

        public List<MenuUsuario> getMenuUser(String idFunc)
        {
            int id_Func = Convert.ToInt32(idFunc);
            var m = svMenu.listaMenu(id_Func);
            List<MenuUsuario> lsMenu = new List<MenuUsuario>();

            if (m != null && m.Length > 0)
            {
                foreach (Menu mUsr in m)
                {
                    if (Convert.ToInt32(mUsr.MenuId) == Convert.ToInt32(mUsr.MenuGrp))
                    {
                        MenuUsuario menu = new MenuUsuario();
                        menu.menu_nom = mUsr.MenuNom;
                        menu.menu_id = mUsr.MenuId.ToString();
                        menu.menu_grupo = String.Empty;
                        menu.menu_link = mUsr.MenuUrl;

                        lsMenu.Add(menu);
                    }
                }
            }
            return lsMenu;
        }

        public List<MenuUsuario> getSubMenuUser(String idFunc)
        {
            int id_Func = Convert.ToInt32(idFunc);
            var m = svMenu.listaMenu(id_Func);
            List<MenuUsuario> lsSubMenu = new List<MenuUsuario>();

            if (m != null && m.Length > 0)
            {
                foreach (Menu mUsr in m)
                {
                    MenuUsuario menu = new MenuUsuario();
                    menu.menu_nom = mUsr.MenuNom;
                    menu.menu_id = mUsr.MenuId.ToString();
                    menu.menu_grupo = mUsr.MenuGrp.ToString();
                    menu.menu_link = mUsr.MenuUrl;

                    lsSubMenu.Add(menu);
                }
            }
            return lsSubMenu;
        }
    }
}
