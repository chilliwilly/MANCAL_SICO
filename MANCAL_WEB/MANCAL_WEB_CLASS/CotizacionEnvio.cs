using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionEnvio
    {
        public String envio_idn { get; set; }
        public String envio_nom { get; set; }

        public CotizacionEnvio() { }

        public CotizacionEnvio(String envio_idn, String envio_nom)
        {
            this.envio_idn = envio_idn;
            this.envio_nom = envio_nom;
        }
    }
}
