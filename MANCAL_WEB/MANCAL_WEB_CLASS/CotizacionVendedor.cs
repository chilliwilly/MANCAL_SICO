using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionVendedor
    {
        public String id_ven { get; set; }
        public String id_nom { get; set; }

        public CotizacionVendedor() { }

        public CotizacionVendedor(String id_ven, String id_nom) 
        {
            this.id_ven = id_ven;
            this.id_nom = id_nom;
        }
    }
}
