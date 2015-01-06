using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionLugarEjec
    {
        public String le_idn { get; set; }
        public String le_nom { get; set; }

        public CotizacionLugarEjec() { }

        public CotizacionLugarEjec(String le_idn, String le_nom) 
        {
            this.le_idn = le_idn;
            this.le_nom = le_nom;
        }
    }
}
