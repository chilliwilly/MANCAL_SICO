using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTFactura
    {
        public String idn_factura { get; set; }
        public String nom_factura { get; set; }

        public CotizacionTFactura() { }

        public CotizacionTFactura(String idn_factura, String nom_factura) 
        {
            this.idn_factura = idn_factura;
            this.nom_factura = nom_factura;
        }
    }
}
