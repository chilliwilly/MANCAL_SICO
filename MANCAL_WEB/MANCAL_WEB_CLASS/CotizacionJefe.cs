using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionJefe
    {
        public String jef_idn { get; set; }
        public String jef_nom { get; set; }
        public String jef_car { get; set; }
        public String jef_mai { get; set; }

        public CotizacionJefe() { }

        public CotizacionJefe(String jef_idn, String jef_nom) 
        {
            this.jef_idn = jef_idn;
            this.jef_nom = jef_nom;
        }
    }
}
