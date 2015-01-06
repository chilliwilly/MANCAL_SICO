using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class DetalleCotizacionPro
    {
        public String idventa { get; set; }
        public String item { get; set; }
        public String nroparte { get; set; }
        public String descripcion { get; set; }
        public String nroserie { get; set; }
        public String cantidad { get; set; }
        public String costorepuesto { get; set; }
        public String preciorepuesto { get; set; }
        public String costomo { get; set; }
        public String preciomo { get; set; }
        public String preciototal { get; set; }

        public DetalleCotizacionPro() { }

        public DetalleCotizacionPro(String item, String nroparte, String descripcion, String nroserie, String cantidad, String costorepuesto, String preciorepuesto, String costomo, String preciomo, String preciototal)
        {
            this.item = item;
            this.nroparte = nroparte;
            this.descripcion = descripcion;
            this.nroserie = nroserie;
            this.cantidad = cantidad;
            this.costorepuesto = costorepuesto;
            this.preciorepuesto = preciorepuesto;
            this.costomo = costomo;
            this.preciomo = preciomo;
            this.preciototal = preciototal;
        }
    }
}
