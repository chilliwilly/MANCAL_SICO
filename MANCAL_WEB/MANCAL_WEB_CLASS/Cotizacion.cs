using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class Cotizacion
    {
        public String cot_numero { get; set; }
        public String cot_id { get; set; }
        public String cot_un_id { get; set; }
        public String cot_fecha { get; set; }
        public String cot_referencia { get; set; }
        public String cot_id_cliente { get; set; }
        public String cot_cuentacli { get; set; }
        public String cot_informecli { get; set; }
        public String cot_contacto_nom { get; set; }
        public String cot_contacto_dir { get; set; }
        public String cot_contacto_cargo { get; set; }
        public String cot_contacto_ff { get; set; }
        public String cot_contacto_fc { get; set; }
        public String cot_contacto_mail { get; set; }
        public String cot_notauno { get; set; }
        public String cot_notados { get; set; }
        public String cot_txtfacturacion { get; set; }
        public String cot_txtformapago { get; set; }
        public String cot_txttpe { get; set; }
        public String cot_plazo_entrega { get; set; }
        public String cot_secentrega { get; set; }
        public String cot_tipo_retiro { get; set; }
        public String cot_secretiro_dir { get; set; }
        public String cot_secretiro_nom { get; set; }
        public String cot_certificado_dir { get; set; }
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
        public String tpe_id { get; set; }//descomentado
        public String tt_id { get; set; }
        public String ec_id { get; set; }
        public String tc_id { get; set; }
        public String jef_id { get; set; }
        public String ven_id { get; set; }
        public String tle_id { get; set; }//fin int 
        public String cot_cantidad { get; set; }
        public String cot_moneda_texto { get; set; }
        public String cot_dcto_porc { get; set; }
        public DetalleCotizacionPro DetalleCotizacionPro { get; set; }
        public CotizacionTransporte CotizacionTransporte { get; set; }
        public CotizacionComision CotizacionComision { get; set; }
        public CotizacionEjecutivo CotizacionEjecutivo { get; set; }
        public CotizacionVendedor CotizacionVendedor { get; set; }
        public CotizacionPunto CotizacionPunto { get; set; }

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

        //FULL COTIZACION UPDATE
        public static Cotizacion objCotizacion(Object obj) 
        {
            Cotizacion cot = new Cotizacion();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object cot_numero = null;
            Object cot_id = null;
            Object cot_un_id = null;
            Object cot_fecha = null;
            Object cot_referencia = null;
            Object cot_id_cliente = null;
            Object cot_cuentacli = null;
            Object cot_informecli = null;
            Object cot_contacto_nom = null;
            Object cot_contacto_dir = null;
            Object cot_contacto_cargo = null;
            Object cot_contacto_ff = null;
            Object cot_contacto_fc = null;
            Object cot_contacto_mail = null;
            Object cot_notauno = null;
            Object cot_notados = null;
            Object cot_txtfacturacion = null;
            Object cot_txtformapago = null;
            Object cot_txttpe = null;
            Object cot_plazo_entrega = null;
            Object cot_secentrega = null;
            Object cot_tipo_retiro = null;
            Object cot_secretiro_dir = null;
            Object cot_secretiro_nom = null;
            Object cot_certificado_dir = null;
            Object cot_valioferta = null;
            Object cot_totcostmo = null;
            Object cot_totvalrpto = null;
            Object cot_mgopporc = null;
            Object cot_mgbrutoporc = null;
            Object cot_mgcontrib = null;
            Object cot_mgcontribporc = null;
            Object cot_utilesperaporc = null;
            Object cot_afecto = null;
            Object cot_tipomoneda = null;
            Object cot_neto = null;
            Object cot_descuento = null;
            Object cot_netodcto = null;
            Object cot_iva = null;
            Object cot_total = null;
            Object cot_chkdcto = null;
            Object cot_chkex = null;
            Object cot_usrpc = null;
            Object tf_id = null;//int
            Object tvg_id = null;
            Object tg_id = null;
            Object tfpf_id = null;
            Object tlej_id = null;            
            Object tt_id = null;
            Object ec_id = null;
            Object tc_id = null;
            Object jef_id = null;
            Object ven_id = null;
            Object tle_id = null;//fin int

            d.TryGetValue("cot_numero", out cot_numero);
            d.TryGetValue("cot_id", out cot_id);
            d.TryGetValue("cot_un_id", out cot_un_id);
            d.TryGetValue("cot_fecha", out cot_fecha);
            d.TryGetValue("cot_referencia", out cot_referencia);
            d.TryGetValue("cot_id_cliente", out cot_id_cliente);
            d.TryGetValue("cot_cuentacli", out cot_cuentacli);
            d.TryGetValue("cot_informecli", out cot_informecli);
            d.TryGetValue("cot_contacto_nom", out cot_contacto_nom);
            d.TryGetValue("cot_contacto_dir", out cot_contacto_dir);
            d.TryGetValue("cot_contacto_cargo", out cot_contacto_cargo);
            d.TryGetValue("cot_contacto_ff", out cot_contacto_ff);
            d.TryGetValue("cot_contacto_fc", out cot_contacto_fc);
            d.TryGetValue("cot_contacto_mail", out cot_contacto_mail);
            d.TryGetValue("cot_notauno", out cot_notauno);
            d.TryGetValue("cot_notados", out cot_notados);
            d.TryGetValue("cot_txtfacturacion", out cot_txtfacturacion);
            d.TryGetValue("cot_txtformapago", out cot_txtformapago);
            d.TryGetValue("cot_txttpe", out cot_txttpe);
            d.TryGetValue("cot_plazo_entrega", out cot_plazo_entrega);
            d.TryGetValue("cot_secentrega", out cot_secentrega);
            d.TryGetValue("cot_tipo_retiro", out cot_tipo_retiro);
            d.TryGetValue("cot_secretiro_dir", out cot_secretiro_dir);
            d.TryGetValue("cot_secretiro_nom", out cot_secretiro_nom);
            d.TryGetValue("cot_certificado_dir", out cot_certificado_dir);
            d.TryGetValue("cot_valioferta", out cot_valioferta);
            d.TryGetValue("cot_totcostmo", out cot_totcostmo);
            d.TryGetValue("cot_totvalrpto", out cot_totvalrpto);
            d.TryGetValue("cot_mgopporc", out cot_mgopporc);
            d.TryGetValue("cot_mgbrutoporc", out cot_mgbrutoporc);
            d.TryGetValue("cot_mgcontrib", out cot_mgcontrib);
            d.TryGetValue("cot_mgcontribporc", out cot_mgcontribporc);
            d.TryGetValue("cot_utilesperaporc", out cot_utilesperaporc);
            d.TryGetValue("cot_afecto", out cot_afecto);
            d.TryGetValue("cot_tipomoneda", out cot_tipomoneda);
            d.TryGetValue("cot_neto", out cot_neto);
            d.TryGetValue("cot_descuento", out cot_descuento);
            d.TryGetValue("cot_netodcto", out cot_netodcto);
            d.TryGetValue("cot_iva", out cot_iva);
            d.TryGetValue("cot_total", out cot_total);
            d.TryGetValue("cot_chkdcto", out cot_chkdcto);
            d.TryGetValue("cot_chkex", out cot_chkex);
            d.TryGetValue("cot_usrpc", out cot_usrpc);
            d.TryGetValue("tf_id", out tf_id);//int
            d.TryGetValue("tvg_id", out tvg_id);
            d.TryGetValue("tg_id", out tg_id);
            d.TryGetValue("tfpf_id", out tfpf_id);
            d.TryGetValue("tlej_id", out tlej_id);
            d.TryGetValue("tt_id", out tt_id);
            d.TryGetValue("ec_id", out ec_id);
            d.TryGetValue("tc_id", out tc_id);
            d.TryGetValue("jef_id", out jef_id);
            d.TryGetValue("ven_id", out ven_id);
            d.TryGetValue("tle_id", out tle_id);//fin int

            cot.cot_numero = cot_numero.ToString();
            cot.cot_id = cot_id.ToString();
            cot.cot_un_id = cot_un_id.ToString();
            cot.cot_fecha = cot_fecha.ToString();
            cot.cot_referencia = cot_referencia.ToString();
            cot.cot_id_cliente = cot_id_cliente.ToString();
            cot.cot_cuentacli = cot_cuentacli.ToString();
            cot.cot_informecli = cot_informecli.ToString();
            cot.cot_contacto_nom = cot_contacto_nom.ToString();
            cot.cot_contacto_dir = cot_contacto_dir.ToString();
            cot.cot_contacto_cargo = cot_contacto_cargo.ToString();
            cot.cot_contacto_ff = cot_contacto_ff.ToString();
            cot.cot_contacto_fc = cot_contacto_fc.ToString();
            cot.cot_contacto_mail = cot_contacto_mail.ToString();
            cot.cot_notauno = cot_notauno.ToString();
            cot.cot_notados = cot_notados.ToString();
            cot.cot_txtfacturacion = cot_txtfacturacion.ToString();
            cot.cot_txtformapago = cot_txtformapago.ToString();
            cot.cot_txttpe = cot_txttpe.ToString();
            cot.cot_plazo_entrega = cot_plazo_entrega.ToString();
            cot.cot_secentrega = cot_secentrega.ToString();
            cot.cot_tipo_retiro = cot_tipo_retiro.ToString();
            cot.cot_secretiro_dir = cot_secretiro_dir.ToString();
            cot.cot_secretiro_nom = cot_secretiro_nom.ToString();
            cot.cot_certificado_dir = cot_certificado_dir.ToString();
            cot.cot_valioferta = cot_valioferta.ToString();
            cot.cot_totcostmo = cot_totcostmo.ToString();
            cot.cot_totvalrpto = cot_totvalrpto.ToString();
            cot.cot_mgopporc = cot_mgopporc.ToString();
            cot.cot_mgbrutoporc = cot_mgbrutoporc.ToString();
            cot.cot_mgcontrib = cot_mgcontrib.ToString();
            cot.cot_mgcontribporc = cot_mgcontribporc.ToString();
            cot.cot_utilesperaporc = cot_utilesperaporc.ToString();
            cot.cot_afecto = cot_afecto.ToString();
            cot.cot_tipomoneda = cot_tipomoneda.ToString();
            cot.cot_neto = cot_neto.ToString();
            cot.cot_descuento = cot_descuento.ToString();
            cot.cot_netodcto = cot_netodcto.ToString();
            cot.cot_iva = cot_iva.ToString();
            cot.cot_total = cot_total.ToString();
            cot.cot_chkdcto = cot_chkdcto.ToString();
            cot.cot_chkex = cot_chkex.ToString();
            cot.cot_usrpc = cot_usrpc.ToString();
            cot.tf_id = tf_id.ToString();//int
            cot.tvg_id = tvg_id.ToString();
            cot.tg_id = tg_id.ToString();
            cot.tfpf_id = tfpf_id.ToString();
            cot.tlej_id = tlej_id.ToString();
            cot.tt_id = tt_id.ToString();
            cot.ec_id = ec_id.ToString();
            cot.tc_id = tc_id.ToString();
            cot.jef_id = jef_id.ToString();
            cot.ven_id = ven_id.ToString();
            cot.tle_id = tle_id.ToString();//fin int

            return cot;
        }

        //FULL COTIZACION INSERT
        public static Cotizacion objCotizacionIns(Object obj) 
        {
            Cotizacion cot = new Cotizacion();
            return cot;
        }
    }
}