using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionLugarCom
    {
        public String lugar_idn { get; set; }
        public String lugar_nom { get; set; }

        public CotizacionLugarCom() { }

        public CotizacionLugarCom(String lugar_idn, String lugar_nom)
        {
            this.lugar_idn = lugar_idn;
            this.lugar_nom = lugar_nom;
        }
    }
}
