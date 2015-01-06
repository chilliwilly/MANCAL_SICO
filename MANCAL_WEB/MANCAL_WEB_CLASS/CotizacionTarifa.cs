using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTarifa
    {
        public String tt_idn { get; set; }
        public String tt_nom { get; set; }

        public CotizacionTarifa() { }

        public CotizacionTarifa(String tt_idn, String tt_nom) 
        {
            this.tt_idn = tt_idn;
            this.tt_nom = tt_nom;
        }
    }
}
