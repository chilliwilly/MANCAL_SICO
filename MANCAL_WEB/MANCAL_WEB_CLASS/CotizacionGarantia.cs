using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionGarantia
    {
        public String g_idn { get; set; }
        public String g_nom { get; set; }

        public CotizacionGarantia() { }

        public CotizacionGarantia(String g_idn, String g_nom) 
        {
            this.g_idn = g_idn;
            this.g_nom = g_nom;
        }
    }
}
