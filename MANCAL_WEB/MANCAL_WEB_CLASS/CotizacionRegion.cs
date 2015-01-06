using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionRegion
    {
        public String region_idn { get; set; }
        public String region_nom { get; set; }

        public CotizacionRegion() { }

        public CotizacionRegion(String region_idn, String region_nom)
        {
            this.region_idn = region_idn;
            this.region_nom = region_nom;
        }
    }
}
