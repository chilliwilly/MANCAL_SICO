using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_menu
    {
        dl_menu objMenu;

        public List<MenuUsuario> getMenuUser(String idFunc)
        {
            int id_Func = Convert.ToInt32(idFunc);
            objMenu = new dl_menu();

            DataTable dt = objMenu.selectMenu();

            List<MenuUsuario> lsMenu = new List<MenuUsuario>();

            //var qry = (from t in dt.AsEnumerable()
            //           where t.Field<Double>("MENU_FUNCU") == id_Func || t.Field<Double>("MENU_FUNCD") == id_Func || t.Field<Double>("MENU_FUNCT") == id_Func || t.Field<Double>("MENU_FUNCC") == id_Func
            //           select t);

            //DataView dv = qry.AsDataView();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["MENU_FUNCU"].ToString().Equals(idFunc) || dr["MENU_FUNCD"].ToString().Equals(idFunc) || dr["MENU_FUNCT"].ToString().Equals(idFunc) || dr["MENU_FUNCC"].ToString().Equals(idFunc))
                    {
                        if (Convert.ToInt32(dr["MENU_ID"]) == Convert.ToInt32(dr["MENU_GRUPO"]))
                        {
                            MenuUsuario menu = new MenuUsuario();
                            menu.menu_nom = dr["MENU_NOMBRE"].ToString();
                            menu.menu_id = dr["MENU_ID"].ToString();
                            menu.menu_grupo = String.Empty;
                            menu.menu_link = dr["MENU_URL"].ToString();

                            lsMenu.Add(menu);
                        }
                    }
                }
            }
            return lsMenu;
        }

        public List<MenuUsuario> getSubMenuUser(String idFunc)
        {
            int id_Func = Convert.ToInt32(idFunc);
            objMenu = new dl_menu();

            DataTable dt = objMenu.selectMenu();

            List<MenuUsuario> lsSubMenu = new List<MenuUsuario>();

            //var qry = (from t in dt.AsEnumerable()
            //           where t.Field<Int32>("MENU_FUNCU") == id_Func || t.Field<Int32>("MENU_FUNCD") == id_Func || t.Field<Int32>("MENU_FUNCT") == id_Func || t.Field<Int32>("MENU_FUNCC") == id_Func
            //           select t);

            //DataView dv = qry.AsDataView();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["MENU_FUNCU"].ToString().Equals(idFunc) || dr["MENU_FUNCD"].ToString().Equals(idFunc) || dr["MENU_FUNCT"].ToString().Equals(idFunc) || dr["MENU_FUNCC"].ToString().Equals(idFunc))
                    {
                        MenuUsuario menu = new MenuUsuario();
                        menu.menu_nom = dr["MENU_NOMBRE"].ToString();
                        menu.menu_id = dr["MENU_ID"].ToString();
                        menu.menu_grupo = dr["MENU_GRUPO"].ToString();
                        menu.menu_link = dr["MENU_URL"].ToString();

                        lsSubMenu.Add(menu);
                    }
                }
            }
            return lsSubMenu;
        }
    }
}
