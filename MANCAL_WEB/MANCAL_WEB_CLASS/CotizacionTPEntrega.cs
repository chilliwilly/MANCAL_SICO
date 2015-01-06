using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTPEntrega
    {
        public String idn_plazoentrega { get; set; }
        public String nom_plazoentrega { get; set; }

        public CotizacionTPEntrega() { }

        public CotizacionTPEntrega(String idn_plazoentrega, String nom_plazoentrega) 
        {
            this.idn_plazoentrega = idn_plazoentrega;
            this.nom_plazoentrega = nom_plazoentrega;
        }
    }
}
