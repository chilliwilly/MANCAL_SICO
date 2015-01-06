using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTPFactura
    {
        public String idn_pagofactura { get; set; }
        public String nom_pagofactura { get; set; }

        public CotizacionTPFactura() { }

        public CotizacionTPFactura(String idn_pagofactura, String nom_pagofactura) 
        {
            this.idn_pagofactura = idn_pagofactura;
            this.nom_pagofactura = nom_pagofactura;
        }
    }
}
