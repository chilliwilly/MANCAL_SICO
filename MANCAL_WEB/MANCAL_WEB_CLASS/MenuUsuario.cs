using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class MenuUsuario
    {
        public String menu_id { get; set; }
        public String menu_nom { get; set; }
        public String menu_grupo { get; set; }
        public String menu_link { get; set; }
        public String menu_sub { get; set; }

        public MenuUsuario() { }

        public MenuUsuario(String menu_id, String menu_nom, String menu_grupo, String menu_link)
        {
            this.menu_id = menu_id;
            this.menu_nom = menu_nom;
            this.menu_grupo = menu_grupo;
            this.menu_link = menu_link;
        }
    }
}
