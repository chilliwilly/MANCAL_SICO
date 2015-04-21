using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;
using System.IO;

namespace MANCAL_WEB_BL
{
    public class bl_cotizacion
    {
        dl_cotizacion objCotizacion;

        public void insDatoCotizacion(Cotizacion objCot) 
        {
            objCotizacion = new dl_cotizacion();

            #region Datos Cotizacion

            String dataXmlc;
            DataTable dtXmlc = new DataTable("DatoCotizacion");

            dtXmlc.Columns.Add("cot_un_id", typeof(string));
            dtXmlc.Columns.Add("cot_fecha", typeof(string));
            dtXmlc.Columns.Add("cot_referencia", typeof(string));
            dtXmlc.Columns.Add("cot_id_cliente", typeof(string));
            dtXmlc.Columns.Add("cot_cuentacli", typeof(string));
            dtXmlc.Columns.Add("cot_informecli", typeof(string));
            dtXmlc.Columns.Add("cot_contacto_nom", typeof(string));
            dtXmlc.Columns.Add("cot_contacto_dir", typeof(string));
            dtXmlc.Columns.Add("cot_contacto_ff", typeof(string));
            dtXmlc.Columns.Add("cot_contacto_mail", typeof(string));
            dtXmlc.Columns.Add("cot_notauno", typeof(string));
            dtXmlc.Columns.Add("cot_notados", typeof(string));
            dtXmlc.Columns.Add("cot_txtfacturacion", typeof(string));
            dtXmlc.Columns.Add("cot_txtformapago", typeof(string));
            dtXmlc.Columns.Add("cot_txttpe", typeof(string));
            dtXmlc.Columns.Add("cot_plazo_entrega", typeof(string));
            dtXmlc.Columns.Add("cot_secentrega", typeof(string));
            dtXmlc.Columns.Add("cot_tipo_retiro", typeof(string));
            dtXmlc.Columns.Add("cot_secretiro_dir", typeof(string));
            dtXmlc.Columns.Add("cot_secretiro_nom", typeof(string));
            dtXmlc.Columns.Add("cot_certificado_dir", typeof(string));
            dtXmlc.Columns.Add("cot_valioferta", typeof(string));
            dtXmlc.Columns.Add("cot_totcostmo", typeof(string));
            dtXmlc.Columns.Add("cot_totvalrpto", typeof(string));
            dtXmlc.Columns.Add("cot_mgopporc", typeof(string));
            dtXmlc.Columns.Add("cot_mgbrutoporc", typeof(string));
            dtXmlc.Columns.Add("cot_mgcontrib", typeof(string));
            dtXmlc.Columns.Add("cot_mgcontribporc", typeof(string));
            dtXmlc.Columns.Add("cot_utilesperaporc", typeof(string));
            dtXmlc.Columns.Add("cot_afecto", typeof(string));
            dtXmlc.Columns.Add("cot_tipomoneda", typeof(string));
            dtXmlc.Columns.Add("cot_neto", typeof(string));
            dtXmlc.Columns.Add("cot_descuento", typeof(string));
            dtXmlc.Columns.Add("cot_netodcto", typeof(string));
            dtXmlc.Columns.Add("cot_iva", typeof(string));
            dtXmlc.Columns.Add("cot_total", typeof(string));
            dtXmlc.Columns.Add("cot_chkdcto", typeof(string));
            dtXmlc.Columns.Add("cot_usrpc", typeof(string));
            dtXmlc.Columns.Add("tf_id", typeof(string));
            dtXmlc.Columns.Add("tvg_id", typeof(string));
            dtXmlc.Columns.Add("tg_id", typeof(string));
            dtXmlc.Columns.Add("tfpf_id", typeof(string));
            dtXmlc.Columns.Add("tlej_id", typeof(string));
            dtXmlc.Columns.Add("tt_id", typeof(string));
            dtXmlc.Columns.Add("tc_id", typeof(string));
            dtXmlc.Columns.Add("jef_id", typeof(string));
            dtXmlc.Columns.Add("ven_id", typeof(string));
            dtXmlc.Columns.Add("tle_id", typeof(string));

            DataRow drXmlc = dtXmlc.NewRow();
            drXmlc["cot_un_id"] = objCot.cot_un_id;
            drXmlc["cot_fecha"] = objCot.cot_fecha;
            drXmlc["cot_referencia"] = objCot.cot_referencia;
            drXmlc["cot_id_cliente"] = objCot.cot_id_cliente;
            drXmlc["cot_cuentacli"] = objCot.cot_cuentacli;
            drXmlc["cot_informecli"] = objCot.cot_informecli;
            drXmlc["cot_contacto_nom"] = objCot.cot_contacto_nom;
            drXmlc["cot_contacto_dir"] = objCot.cot_contacto_dir;
            drXmlc["cot_contacto_ff"] = objCot.cot_contacto_ff;
            drXmlc["cot_contacto_mail"] = objCot.cot_contacto_mail;
            drXmlc["cot_notauno"] = objCot.cot_notauno;
            drXmlc["cot_notados"] = objCot.cot_notados;
            drXmlc["cot_txtfacturacion"] = objCot.cot_txtfacturacion;
            drXmlc["cot_txtformapago"] = objCot.cot_txtformapago;
            drXmlc["cot_txttpe"] = objCot.cot_txttpe;
            drXmlc["cot_plazo_entrega"] = objCot.cot_plazo_entrega;
            drXmlc["cot_secentrega"] = objCot.cot_secentrega;
            drXmlc["cot_tipo_retiro"] = objCot.cot_tipo_retiro;
            drXmlc["cot_secretiro_dir"] = objCot.cot_secretiro_dir;
            drXmlc["cot_secretiro_nom"] = objCot.cot_secretiro_nom;
            drXmlc["cot_certificado_dir"] = objCot.cot_certificado_dir;
            drXmlc["cot_valioferta"] = objCot.cot_valioferta;
            drXmlc["cot_totcostmo"] = objCot.cot_totcostmo;
            drXmlc["cot_totvalrpto"] = objCot.cot_totvalrpto;
            drXmlc["cot_mgopporc"] = objCot.cot_mgopporc;
            drXmlc["cot_mgbrutoporc"] = objCot.cot_mgbrutoporc;
            drXmlc["cot_mgcontrib"] = objCot.cot_mgcontrib;
            drXmlc["cot_mgcontribporc"] = objCot.cot_mgcontribporc;
            drXmlc["cot_utilesperaporc"] = objCot.cot_utilesperaporc;
            drXmlc["cot_afecto"] = objCot.cot_afecto;
            drXmlc["cot_tipomoneda"] = objCot.cot_tipomoneda;
            drXmlc["cot_neto"] = objCot.cot_neto;
            drXmlc["cot_descuento"] = objCot.cot_descuento;
            drXmlc["cot_netodcto"] = objCot.cot_netodcto;
            drXmlc["cot_iva"] = objCot.cot_iva;
            drXmlc["cot_total"] = objCot.cot_total;
            drXmlc["cot_chkdcto"] = objCot.cot_chkdcto;
            drXmlc["cot_usrpc"] = objCot.cot_usrpc;
            drXmlc["tf_id"] = objCot.tf_id;
            drXmlc["tvg_id"] = objCot.tvg_id;
            drXmlc["tg_id"] = objCot.tg_id;
            drXmlc["tfpf_id"] = objCot.tfpf_id;
            drXmlc["tlej_id"] = objCot.tlej_id;
            drXmlc["tt_id"] = objCot.tt_id;
            drXmlc["tc_id"] = objCot.tc_id;
            drXmlc["jef_id"] = objCot.jef_id;
            drXmlc["ven_id"] = objCot.ven_id;
            drXmlc["tle_id"] = objCot.tle_id;

            dtXmlc.Rows.Add(drXmlc);

            using (StringWriter swrc = new StringWriter())
            {
                dtXmlc.WriteXml(swrc);
                dataXmlc = swrc.ToString();
            }

            #endregion

            #region Datos Transporte

            String dataXmlt;
            DataTable dtXmlt = new DataTable("DatoTransporte");

            dtXmlt.Columns.Add("ctrans_total", typeof(string));
            dtXmlt.Columns.Add("reg_id", typeof(string));
            dtXmlt.Columns.Add("ten_id", typeof(string));
            dtXmlt.Columns.Add("ctrans_direccion", typeof(string));

            DataRow drXmlt = dtXmlt.NewRow();
            drXmlt["ctrans_total"] = objCot.CotizacionTransporte.ctrans_total;
            drXmlt["reg_id"] = objCot.CotizacionTransporte.reg_id;
            drXmlt["ten_id"] = objCot.CotizacionTransporte.ten_id;
            drXmlt["ctrans_direccion"] = objCot.CotizacionTransporte.ctrans_direccion;

            dtXmlt.Rows.Add(drXmlt);

            using (StringWriter swrt = new StringWriter()) 
            {
                dtXmlt.WriteXml(swrt);
                dataXmlt = swrt.ToString();
            }

            #endregion

            #region Datos Comision

            String dataXmlco;
            DataTable dtXmlco = new DataTable("DatoComision");

            dtXmlco.Columns.Add("ccom_qtypersona", typeof(string));
            dtXmlco.Columns.Add("ccom_qtydia", typeof(string));
            dtXmlco.Columns.Add("ccom_qtyveh", typeof(string));
            dtXmlco.Columns.Add("ccom_qtranseqt", typeof(string));
            dtXmlco.Columns.Add("ccom_qtranseqa", typeof(string));
            dtXmlco.Columns.Add("ccom_fondor", typeof(string));
            dtXmlco.Columns.Add("ccom_qgasrepr", typeof(string));
            dtXmlco.Columns.Add("ccom_qtycommes", typeof(string));
            dtXmlco.Columns.Add("ccom_transdts", typeof(string));
            dtXmlco.Columns.Add("ccom_transhotel", typeof(string));
            dtXmlco.Columns.Add("ccom_psjavionper", typeof(string));
            dtXmlco.Columns.Add("ccom_alqveh", typeof(string));
            dtXmlco.Columns.Add("ccom_transeqt", typeof(string));
            dtXmlco.Columns.Add("ccom_transeqa", typeof(string));
            dtXmlco.Columns.Add("ccom_viatico", typeof(string));
            dtXmlco.Columns.Add("ccom_hotel", typeof(string));
            dtXmlco.Columns.Add("ccom_frendir", typeof(string));
            dtXmlco.Columns.Add("ccom_gasrepr", typeof(string));
            dtXmlco.Columns.Add("ccom_totalcom", typeof(string));
            dtXmlco.Columns.Add("ccom_totalcommg", typeof(string));
            dtXmlco.Columns.Add("lug_id", typeof(string));

            DataRow drXmlco = dtXmlco.NewRow();
            drXmlco["ccom_qtypersona"] = objCot.CotizacionComision.ccom_qtypersona;
            drXmlco["ccom_qtydia"] = objCot.CotizacionComision.ccom_qtydia;
            drXmlco["ccom_qtyveh"] = objCot.CotizacionComision.ccom_qtyveh;
            drXmlco["ccom_qtranseqt"] = objCot.CotizacionComision.ccom_qtranseqt;
            drXmlco["ccom_qtranseqa"] = objCot.CotizacionComision.ccom_qtranseqa;
            drXmlco["ccom_fondor"] = objCot.CotizacionComision.ccom_fondor;
            drXmlco["ccom_qgasrepr"] = objCot.CotizacionComision.ccom_qgasrepr;
            drXmlco["ccom_qtycommes"] = objCot.CotizacionComision.ccom_qtycommes;
            drXmlco["ccom_transdts"] = objCot.CotizacionComision.ccom_transdts;
            drXmlco["ccom_transhotel"] = objCot.CotizacionComision.ccom_transhotel;
            drXmlco["ccom_psjavionper"] = objCot.CotizacionComision.ccom_psjavionper;
            drXmlco["ccom_alqveh"] = objCot.CotizacionComision.ccom_alqveh;
            drXmlco["ccom_transeqt"] = objCot.CotizacionComision.ccom_transeqt;
            drXmlco["ccom_transeqa"] = objCot.CotizacionComision.ccom_transeqa;
            drXmlco["ccom_viatico"] = objCot.CotizacionComision.ccom_viatico;
            drXmlco["ccom_hotel"] = objCot.CotizacionComision.ccom_hotel;
            drXmlco["ccom_frendir"] = objCot.CotizacionComision.ccom_frendir;
            drXmlco["ccom_gasrepr"] = objCot.CotizacionComision.ccom_gasrepr;
            drXmlco["ccom_totalcom"] = objCot.CotizacionComision.ccom_totalcom;
            drXmlco["ccom_totalcommg"] = objCot.CotizacionComision.ccom_totalcommg;
            drXmlco["lug_id"] = objCot.CotizacionComision.lug_id;

            dtXmlco.Rows.Add(drXmlco);

            using (StringWriter swrco = new StringWriter()) 
            {
                dtXmlco.WriteXml(swrco);
                dataXmlco = swrco.ToString();
            }

            #endregion
        }
    }
}
