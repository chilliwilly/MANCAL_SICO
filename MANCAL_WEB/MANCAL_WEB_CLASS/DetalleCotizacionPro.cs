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

        public static DetalleCotizacionPro getObjDet(Object obj)
        {
            DetalleCotizacionPro det = new DetalleCotizacionPro();
            Dictionary<String, Object> dObj = (Dictionary<string, object>)obj;
            
            Object idventa = null;
            Object item = null;
            Object nroparte = null;
            Object descripcion = null;
            Object nroserie = null;
            Object cantidad = null;
            Object costorepuesto = null;
            Object preciorepuesto = null;
            Object costomo = null;
            Object preciomo = null;
            Object preciototal = null;

            dObj.TryGetValue("idventa", out idventa);
            dObj.TryGetValue("item", out item);
            dObj.TryGetValue("nroparte", out nroparte);
            dObj.TryGetValue("descripcion", out descripcion);
            dObj.TryGetValue("nroserie", out nroserie);
            dObj.TryGetValue("cantidad", out cantidad);
            dObj.TryGetValue("costorepuesto", out costorepuesto);
            dObj.TryGetValue("preciorepuesto", out preciorepuesto);
            dObj.TryGetValue("costomo", out costomo);
            dObj.TryGetValue("preciomo", out preciomo);
            dObj.TryGetValue("preciototal", out preciototal);

            det.idventa = idventa.ToString();
            det.item = item.ToString();
            det.nroparte = nroparte.ToString();
            det.descripcion = descripcion.ToString();
            det.nroserie = nroserie.ToString();
            det.cantidad = cantidad.ToString();
            det.costorepuesto = costorepuesto.ToString();
            det.preciorepuesto = preciorepuesto.ToString();
            det.costomo = costomo.ToString();
            det.preciomo = preciomo.ToString();
            det.preciototal = preciototal.ToString();

            return det;
        }
    }
}
