using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionTransporte
    {
        public String ctrans_id { get; set; }
        public String cot_numero { get; set; }
        public String ctrans_total { get; set; }
        public String reg_id { get; set; }
        public String ten_id { get; set; }
        public String ctrans_direccion { get; set; }

        public CotizacionTransporte() { }

        public CotizacionTransporte(String ctrans_id, String cot_numero, String ctrans_total, String reg_id, String ten_id, String ctrans_direccion)
        {
            this.ctrans_id = ctrans_id;
            this.cot_numero = cot_numero;
            this.ctrans_total = ctrans_total;
            this.reg_id = reg_id;
            this.ten_id = ten_id;
            this.ctrans_direccion = ctrans_direccion;
        }

        //PARA INSERTAR
        public static CotizacionTransporte objCotiTrans(Object obj)
        {
            CotizacionTransporte ct = new CotizacionTransporte();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object ctrans_id = null;
            Object cot_numero = null;
            Object ctrans_total = null;
            Object reg_id = null;
            Object ten_id = null;
            Object ctrans_direccion = null;

            d.TryGetValue("ctrans_id", out ctrans_id);
            d.TryGetValue("cot_numero", out cot_numero);
            d.TryGetValue("ctrans_total", out ctrans_total);
            d.TryGetValue("reg_id", out reg_id);
            d.TryGetValue("ten_id", out ten_id);
            d.TryGetValue("ctrans_direccion", out ctrans_direccion);

            ct.ctrans_id = ctrans_id.ToString();
            ct.cot_numero = cot_numero.ToString();
            ct.ctrans_total = ctrans_total.ToString();
            ct.reg_id = reg_id.ToString();
            ct.ten_id = ten_id.ToString();
            ct.ctrans_direccion = ctrans_direccion.ToString();

            return ct;
        }
    }
}
