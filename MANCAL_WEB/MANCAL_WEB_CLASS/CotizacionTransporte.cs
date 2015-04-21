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

        //PARA INSERTAR
        public static CotizacionTransporte objCotiTrans(Object obj)
        {
            CotizacionTransporte ct = new CotizacionTransporte();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object ctrans_total = null;
            Object reg_id = null;
            Object ten_id = null;
            Object ctrans_direccion = null;

            d.TryGetValue("ctrans_total", out ctrans_total);
            d.TryGetValue("reg_id", out reg_id);
            d.TryGetValue("ten_id", out ten_id);
            d.TryGetValue("ctrans_direccion", out ctrans_direccion);

            ct.ctrans_total = ctrans_total.ToString();
            ct.reg_id = reg_id.ToString();
            ct.ten_id = ten_id.ToString();
            ct.ctrans_direccion = ctrans_direccion.ToString();

            return ct;
        }
    }
}
