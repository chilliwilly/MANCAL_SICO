using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class Cotizacion
    {
        public int cot_numero { get; set; }
        public String cot_id { get; set; }
        public String cot_un_id { get; set; }
        public String cot_fecha { get; set; }
        public String cot_referencia { get; set; }
        public String cot_informecli { get; set; }
        public String cot_notauno { get; set; }
        public String cot_notados { get; set; }
        public String cot_txtfacturacion { get; set; }
        public String cot_txtformapago { get; set; }
        public String cot_txttpe { get; set; }
        public String cot_secentrega { get; set; }
        public String cot_valioferta { get; set; }
        public String cot_totcostmo { get; set; }
        public String cot_totvalrpto { get; set; }
        public String cot_mgopporc { get; set; }
        public String cot_mgbrutoporc { get; set; }
        public String cot_mgcontrib { get; set; }
        public String cot_mgcontribporc { get; set; }
        public String cot_utilesperaporc { get; set; }
        public String cot_afecto { get; set; }
        public String cot_tipomoneda { get; set; }
        public String cot_neto { get; set; }
        public String cot_descuento { get; set; }
        public String cot_netodcto { get; set; }
        public String cot_iva { get; set; }
        public String cot_total { get; set; }
        public String cot_chkdcto { get; set; }
        public String cot_chkex { get; set; }
        public String cot_usrpc { get; set; }
        public String tf_id { get; set; }//int
        public String tvg_id { get; set; }
        public String tg_id { get; set; }
        public String tfpf_id { get; set; }
        public String tlej_id { get; set; }
        public String tpe_id { get; set; }
        public String tt_id { get; set; }
        public String ec_id { get; set; }
        public String tc_id { get; set; }
        public String jef_id { get; set; }
        public String ven_id { get; set; }
        public String tle_id { get; set; }//fin int
        public DetalleCotizacionPro DetalleCotizacionPro { get; set; }

        public String cot_msgautoriza { get; set; }

        public Cotizacion() { }

        public static Cotizacion objCotiTotal(Object obj) 
        {
            Cotizacion cot = new Cotizacion();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object cot_tipomoneda = null;
            Object cot_afecto = null;
            Object tc_id = null;
            Object cot_descuento = null;
            Object cot_id = null;
            Object cot_fecha = null;

            d.TryGetValue("cot_tipomoneda", out cot_tipomoneda);
            d.TryGetValue("cot_afecto", out cot_afecto);
            d.TryGetValue("tc_id", out tc_id);
            d.TryGetValue("cot_descuento", out cot_descuento);
            d.TryGetValue("cot_id", out cot_id);
            d.TryGetValue("cot_fecha", out cot_fecha);

            cot.cot_tipomoneda = cot_tipomoneda.ToString();
            cot.cot_afecto = cot_afecto.ToString();
            cot.tc_id = tc_id.ToString();
            cot.cot_descuento = cot_descuento.ToString();
            cot.cot_id = cot_id.ToString();
            cot.cot_fecha = cot_fecha.ToString();

            return cot;
        }
    }
}