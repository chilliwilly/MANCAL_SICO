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
        public String id_mail { get; set; }
        public String id_fono { get; set; }

        public CotizacionVendedor() { }

        public CotizacionVendedor(String id_ven, String id_nom) 
        {
            this.id_ven = id_ven;
            this.id_nom = id_nom;
        }

        public CotizacionVendedor(String nom, String mail, String fono) 
        {
            this.id_nom = nom;
            this.id_mail = mail;
            this.id_fono = fono;
        }
    }
}
