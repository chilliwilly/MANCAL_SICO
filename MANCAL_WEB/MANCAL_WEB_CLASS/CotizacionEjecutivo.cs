using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionEjecutivo
    {
        public String ejec_id { get; set; }
        public String ejec_nom { get; set; }
        public String ejec_fono { get; set; }
        public String ejec_mail { get; set; }

        public CotizacionEjecutivo() { }

        public CotizacionEjecutivo(String nom, String fono, String mail) 
        {
            this.ejec_nom = nom;
            this.ejec_fono = fono;
            this.ejec_mail = mail;
        }
    }
}
