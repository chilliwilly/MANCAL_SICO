using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionGarantiaVal
    {
        public String gv_idn { get; set; }
        public String gv_nom { get; set; }

        public CotizacionGarantiaVal() { }

        public CotizacionGarantiaVal(String gv_idn, String gv_nom) 
        {
            this.gv_idn = gv_idn;
            this.gv_nom = gv_nom;
        }
    }
}
