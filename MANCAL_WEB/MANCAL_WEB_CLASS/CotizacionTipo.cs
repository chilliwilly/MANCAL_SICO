using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTipo
    {
        public String idtipocot { get; set; }
        public String nomtipocot { get; set; }

        public CotizacionTipo() { }

        public CotizacionTipo(String idtipocot, String nomtipocot) 
        {
            this.idtipocot = idtipocot;
            this.nomtipocot = nomtipocot;
        }
    }
}
