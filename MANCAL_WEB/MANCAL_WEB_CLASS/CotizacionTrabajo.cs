using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTrabajo
    {
        public String idn_ttrabajo { get; set; }
        public String nom_ttrabajo { get; set; }

        public CotizacionTrabajo() { }

        public CotizacionTrabajo(String idn_ttrabajo, String nom_ttrabajo) 
        {
            this.idn_ttrabajo = idn_ttrabajo;
            this.nom_ttrabajo = nom_ttrabajo;
        }
    }
}
