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
        public int tf_id { get; set; }
        public int tvg_id { get; set; }
        public int tg_id { get; set; }
        public int tfpf_id { get; set; }
        public int tlej_id { get; set; }
        public int tpe_id { get; set; }
        public int tt_id { get; set; }
        public int ec_id { get; set; }
        public int tc_id { get; set; }
        public int jef_id { get; set; }
        public int ven_id { get; set; }
        public int tle_id { get; set; }
        public DetalleCotizacionPro DetalleCotizacionPro { get; set; }

        public String cot_msgautoriza { get; set; }

        public Cotizacion() { }
    }
}