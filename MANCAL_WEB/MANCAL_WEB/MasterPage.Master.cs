﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;
using MANCAL_WEB_CLASS;

namespace MANCAL_WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        String columna = "";
        bl_menu objMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["v_pr"] != null)
            {
                if (Request.Cookies["v_pr"].Value.Equals("1"))
                {
                    columna = "MENU_FUNCU";
                }

                if (Request.Cookies["v_pr"].Value.Equals("2"))
                {
                    columna = "MENU_FUNCD";
                }

                if (Request.Cookies["v_pr"].Value.Equals("3"))
                {
                    columna = "MENU_FUNCT";
                }

                if (Request.Cookies["v_pr"].Value.Equals("4"))
                {
                    columna = "MENU_FUNCC";
                }

                if (!String.IsNullOrEmpty(columna))
                {
                    //ejecutar llenado menu
                    BindMenuControl(columna);
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        protected void BindMenuControl(String colPrivilegio)
        {
            objMenu = new bl_menu();
            String reqCookie = Request.Cookies["v_pr"].Value.ToString();

            foreach (MenuUsuario m in objMenu.getMenuUser(reqCookie))
            {
                MenuItem mItem = new MenuItem(m.menu_nom, m.menu_id, m.menu_grupo, m.menu_link);
                NavigationMenu.Items.Add(mItem);
                AddChildItem(ref mItem, reqCookie);
            }
        }

        protected void AddChildItem(ref MenuItem mItem, String idFuncion)
        {
            objMenu = new bl_menu();
            foreach (MenuUsuario m in objMenu.getSubMenuUser(idFuncion))
            {
                if (Convert.ToInt32(m.menu_grupo) == Convert.ToInt32(mItem.Value) && Convert.ToInt32(m.menu_id) != Convert.ToInt32(m.menu_grupo))
                {
                    MenuItem miSubItem = new MenuItem(m.menu_nom, m.menu_id, String.Empty, m.menu_link);
                    mItem.ChildItems.Add(miSubItem);
                    AddChildItem(ref miSubItem, idFuncion);
                }
            }
        }
    }
}