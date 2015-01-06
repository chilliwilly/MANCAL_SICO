using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionLugarEntr
    {
        public String len_idn { get; set; }
        public String len_nom { get; set; }

        public CotizacionLugarEntr() { }

        public CotizacionLugarEntr(String len_idn, String len_nom) 
        {
            this.len_idn = len_idn;
            this.len_nom = len_nom;
        }
    }
}
