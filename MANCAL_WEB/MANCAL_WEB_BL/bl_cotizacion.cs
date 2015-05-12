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

        public String insDatoCotizacion(Cotizacion objCot) 
        {
            objCotizacion = new dl_cotizacion();
            String datoInforme = "";

            #region Datos Cotizacion

            String dataXmlc;
            DataTable dtXmlc = new DataTable("DatoCotizacion");

            dtXmlc.Columns.Add("cot_un_id", typeof(string));
            dtXmlc.Columns.Add("cot_fecha", typeof(string));
            dtXmlc.Columns.Add("cot_referencia", typeof(string));
            dtXmlc.Columns.Add("cot_id_cliente", typeof(Int32));
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
            dtXmlc.Columns.Add("cot_plazo_entrega", typeof(Int32));
            dtXmlc.Columns.Add("cot_secentrega", typeof(string));
            dtXmlc.Columns.Add("cot_tipo_retiro", typeof(Int32));
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
            dtXmlc.Columns.Add("cot_afecto", typeof(Int32));
            dtXmlc.Columns.Add("cot_tipomoneda", typeof(string));
            dtXmlc.Columns.Add("cot_neto", typeof(string));
            dtXmlc.Columns.Add("cot_descuento", typeof(string));
            dtXmlc.Columns.Add("cot_netodcto", typeof(string));
            dtXmlc.Columns.Add("cot_iva", typeof(string));
            dtXmlc.Columns.Add("cot_total", typeof(string));
            dtXmlc.Columns.Add("cot_chkdcto", typeof(string));
            dtXmlc.Columns.Add("cot_chkex", typeof(string));
            dtXmlc.Columns.Add("cot_usrpc", typeof(string));
            dtXmlc.Columns.Add("tf_id", typeof(Int32));
            dtXmlc.Columns.Add("tvg_id", typeof(Int32));
            dtXmlc.Columns.Add("tg_id", typeof(Int32));
            dtXmlc.Columns.Add("tfpf_id", typeof(Int32));
            dtXmlc.Columns.Add("tlej_id", typeof(Int32));
            dtXmlc.Columns.Add("tt_id", typeof(Int32));
            dtXmlc.Columns.Add("tc_id", typeof(Int32));
            dtXmlc.Columns.Add("jef_id", typeof(Int32));
            dtXmlc.Columns.Add("ven_id", typeof(Int32));
            dtXmlc.Columns.Add("tle_id", typeof(Int32));

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
            drXmlc["cot_chkex"] = objCot.cot_chkex;
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
            dtXmlt.Columns.Add("reg_id", typeof(Int32));
            dtXmlt.Columns.Add("ten_id", typeof(Int32));
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

            dtXmlco.Columns.Add("ccom_qtypersona", typeof(Int32));
            dtXmlco.Columns.Add("ccom_qtydia", typeof(Int32));
            dtXmlco.Columns.Add("ccom_qtyveh", typeof(Int32));
            dtXmlco.Columns.Add("ccom_qtranseqt", typeof(Int32));
            dtXmlco.Columns.Add("ccom_qtranseqa", typeof(Int32));
            dtXmlco.Columns.Add("ccom_fondor", typeof(Int32));
            dtXmlco.Columns.Add("ccom_qgasrepr", typeof(Int32));
            dtXmlco.Columns.Add("ccom_qtycommes", typeof(Int32));
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
            dtXmlco.Columns.Add("lug_id", typeof(Int32));

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

            datoInforme = objCotizacion.insertCotizacion(dataXmlc, dataXmlt, dataXmlco);

            return datoInforme;
        }

        public Cotizacion selDatoCotizacion(String cotnum) 
        {
            Cotizacion cot = new Cotizacion();
            objCotizacion = new dl_cotizacion();
            int num = Convert.ToInt32(cotnum);

            DataTable dt = objCotizacion.selectCotizacion(null, null, null, num, "").Tables["CUR_COTIZACION"];

            foreach (DataRow dr in dt.Rows) 
            {
                cot.cot_numero = dr["COT_NUMERO"].ToString();
                cot.cot_id = dr["COT_ID"].ToString();
                cot.cot_un_id = dr["COT_UN_ID"].ToString();
                //cot.CotizacionVendedor = new CotizacionVendedor("", dr["COT_NOMBRE_VEN"].ToString()); 
                cot.cot_fecha = dr["COT_FECHA"].ToString();
                cot.cot_referencia = dr["COT_REFERENCIA"].ToString();
                cot.cot_id_cliente = dr["COT_ID_CLIENTE"].ToString();
                cot.ec_id = dr["EC_ID"].ToString();
                cot.cot_cuentacli = dr["COT_CUENTACLI"].ToString();
                cot.cot_informecli = dr["COT_INFORMECLI"].ToString();
                cot.cot_contacto_nom = dr["COT_CONTACTO_NOM"].ToString();
                cot.cot_contacto_dir = dr["COT_CONTACTO_DIR"].ToString();
                cot.cot_contacto_cargo = dr["COT_CONTACTO_CARGO"].ToString();
                cot.cot_contacto_ff = dr["COT_CONTACTO_FF"].ToString();
                cot.cot_contacto_fc = dr["COT_CONTACTO_FC"].ToString();
                cot.cot_contacto_mail = dr["COT_CONTACTO_MAIL"].ToString();
                cot.cot_notauno = dr["COT_NOTAUNO"].ToString();
                cot.cot_notados = dr["COT_NOTADOS"].ToString();
                cot.cot_txtfacturacion = dr["COT_TXTFACTURACION"].ToString();
                cot.cot_txtformapago = dr["COT_TXTFORMAPAGO"].ToString();
                cot.cot_txttpe = dr["COT_TXTTPE"].ToString();
                cot.cot_plazo_entrega = dr["COT_PLAZO_ENTREGA"].ToString();
                cot.cot_secentrega = dr["COT_SECENTREGA"].ToString();
                cot.cot_tipo_retiro = dr["COT_TIPO_RETIRO"].ToString();
                cot.cot_secretiro_dir = dr["COT_SECRETIRO_DIR"].ToString();
                cot.cot_secretiro_nom = dr["COT_SECRETIRO_NOM"].ToString();
                cot.cot_certificado_dir = dr["COT_CERTIFICADO_DIR"].ToString();
                cot.cot_valioferta = dr["COT_VALIOFERTA"].ToString();
                cot.cot_totcostmo = dr["COT_TOTCOSTMO"].ToString();
                cot.cot_totvalrpto = dr["COT_TOTVALRPTO"].ToString();
                cot.cot_mgopporc = dr["COT_MGOPPORC"].ToString();
                cot.cot_mgbrutoporc = dr["COT_MGBRUTOPORC"].ToString();
                cot.cot_mgcontrib = dr["COT_MGCONTRIB"].ToString();
                cot.cot_mgcontribporc = dr["COT_MGCONTRIBPORC"].ToString();
                cot.cot_utilesperaporc = dr["COT_UTILESPERAPORC"].ToString();
                cot.cot_afecto = dr["COT_AFECTO"].ToString();
                cot.cot_tipomoneda = dr["COT_TIPOMONEDA"].ToString();
                cot.cot_neto = dr["COT_NETO"].ToString();
                cot.cot_descuento = dr["COT_DESCUENTO"].ToString();
                cot.cot_netodcto = dr["COT_NETODCTO"].ToString();
                cot.cot_iva = dr["COT_IVA"].ToString();
                cot.cot_total = dr["COT_TOTAL"].ToString();
                cot.cot_chkdcto = dr["COT_CHKDCTO"].ToString();
                cot.cot_chkex = dr["COT_CHKEX"].ToString();
                cot.cot_usrpc = dr["COT_USRPC"].ToString();
                cot.tf_id = dr["TF_ID"].ToString();//int
                cot.tvg_id = dr["TVG_ID"].ToString();
                cot.tg_id = dr["TG_ID"].ToString();
                cot.tfpf_id = dr["TFPF_ID"].ToString();
                cot.tlej_id = dr["TLEJ_ID"].ToString();
                //public String tpe_id = dr[""].ToString();
                cot.tt_id = dr["TT_ID"].ToString();
                cot.tc_id = dr["TC_ID"].ToString();
                cot.jef_id = dr["JEF_ID"].ToString();
                cot.ven_id = dr["VEN_ID"].ToString();
                cot.tle_id = dr["TLE_ID"].ToString();//fin int

                if (String.IsNullOrEmpty(dr["CTRANS_ID"].ToString()))
                {
                    cot.CotizacionTransporte = null;
                }
                else
                {
                    cot.CotizacionTransporte = new CotizacionTransporte(dr["CTRANS_ID"].ToString(), "", dr["CTRANS_TOTAL"].ToString(), dr["REG_ID"].ToString(), dr["TEN_ID"].ToString(), dr["CTRANS_DIRECCION"].ToString());
                }
                /*cot.CotizacionTransporte.ctrans_id = dr["CTRANS_ID"].ToString();
                cot.CotizacionTransporte.ten_id = dr["TEN_ID"].ToString();
                cot.CotizacionTransporte.reg_id = dr["REG_ID"].ToString();
                cot.CotizacionTransporte.ctrans_direccion = dr["CTRANS_DIRECCION"].ToString();
                cot.CotizacionTransporte.ctrans_total = dr["CTRANS_TOTAL"].ToString();*/

                if (String.IsNullOrEmpty(dr["LUG_ID"].ToString()))
                {
                    cot.CotizacionComision = null;
                }
                else
                {
                    cot.CotizacionComision = new CotizacionComision(dr["CCOM_ID"].ToString(), dr["CCOM_QTYPERSONA"].ToString(), dr["CCOM_QTYDIA"].ToString(), dr["CCOM_QTYVEH"].ToString(), dr["CCOM_QTRANSEQT"].ToString(), dr["CCOM_QTRANSEQA"].ToString(), dr["CCOM_FONDOR"].ToString(), dr["CCOM_QGASREPR"].ToString(), dr["CCOM_QTYCOMMES"].ToString(), dr["CCOM_TRANSDTS"].ToString(), dr["CCOM_TRANSHOTEL"].ToString(), dr["CCOM_PSJAVIONPER"].ToString(), dr["CCOM_ALQVEH"].ToString(), dr["CCOM_TRANSEQT"].ToString(), dr["CCOM_TRANSEQA"].ToString(), dr["CCOM_VIATICO"].ToString(), dr["CCOM_HOTEL"].ToString(), dr["CCOM_FRENDIR"].ToString(), dr["CCOM_GASREPR"].ToString(), dr["CCOM_TOTALCOM"].ToString(), dr["CCOM_TOTALCOMMG"].ToString(), dr["LUG_ID"].ToString());
                }
                /*cot.CotizacionComision.ccom_id = dr["CCOM_ID"].ToString();
                cot.CotizacionComision.ccom_qtypersona = dr["CCOM_QTYPERSONA"].ToString();
                cot.CotizacionComision.ccom_qtydia = dr["CCOM_QTYDIA"].ToString();
                cot.CotizacionComision.ccom_qtyveh = dr["CCOM_QTYVEH"].ToString();
                cot.CotizacionComision.ccom_qtranseqt = dr["CCOM_QTRANSEQT"].ToString();
                cot.CotizacionComision.ccom_qtranseqa = dr["CCOM_QTRANSEQA"].ToString();
                cot.CotizacionComision.ccom_fondor = dr["CCOM_FONDOR"].ToString();
                cot.CotizacionComision.ccom_qgasrepr = dr["CCOM_QGASREPR"].ToString();
                cot.CotizacionComision.ccom_qtycommes = dr["CCOM_QTYCOMMES"].ToString();
                cot.CotizacionComision.ccom_transdts = dr["CCOM_TRANSDTS"].ToString();
                cot.CotizacionComision.ccom_transhotel = dr["CCOM_TRANSHOTEL"].ToString();
                cot.CotizacionComision.ccom_psjavionper = dr["CCOM_PSJAVIONPER"].ToString();
                cot.CotizacionComision.ccom_alqveh = dr["CCOM_ALQVEH"].ToString();
                cot.CotizacionComision.ccom_transeqt = dr["CCOM_TRANSEQT"].ToString();
                cot.CotizacionComision.ccom_transeqa = dr["CCOM_TRANSEQA"].ToString();
                cot.CotizacionComision.ccom_viatico = dr["CCOM_VIATICO"].ToString();
                cot.CotizacionComision.ccom_hotel = dr["CCOM_HOTEL"].ToString();
                cot.CotizacionComision.ccom_frendir = dr["CCOM_FRENDIR"].ToString();
                cot.CotizacionComision.ccom_gasrepr = dr["CCOM_GASREPR"].ToString();
                cot.CotizacionComision.ccom_totalcom = dr["CCOM_TOTALCOM"].ToString();
                cot.CotizacionComision.ccom_totalcommg = dr["CCOM_TOTALCOMMG"].ToString();
                cot.CotizacionComision.lug_id = dr["LUG_ID"].ToString();*/

            }

            return cot;
        }

        public List<Cotizacion> selMuestraCotizacion(String dataVendedor_, String dataEstadoCot_, String dataCliente_, String dataCotiNum_, String dataCotiText_) 
        {
            List<Cotizacion> ls = new List<Cotizacion>();
            objCotizacion = new dl_cotizacion();

            int? dVendedor = 0;// Convert.ToInt32(dataVendedor_);
            int? dEstadoCot = 0;// Convert.ToInt32(dataEstadoCot_);
            int? dCliente = 0;// Convert.ToInt32(dataCliente_);
            int? dCotiNum = 0;// Convert.ToInt32(dataCotiNum_);

            if (String.IsNullOrEmpty(dataVendedor_) || Convert.ToInt32(dataVendedor_) == 0)
            {
                dVendedor = null;
            }
            else 
            {
                dVendedor = Convert.ToInt32(dataVendedor_);
            }

            if (String.IsNullOrEmpty(dataEstadoCot_) || Convert.ToInt32(dataEstadoCot_) == 0)
            {
                dEstadoCot = null;
            }

            if (String.IsNullOrEmpty(dataCliente_) || Convert.ToInt32(dataCliente_) == 0)
            {
                dCliente = null;
            }

            if (String.IsNullOrEmpty(dataCotiNum_) || Convert.ToInt32(dataCotiNum_) == 0)
            {
                dCotiNum = null;
            }

            DataTable dt = objCotizacion.selectCotizacion(dVendedor, dEstadoCot, dCliente, dCotiNum, dataCotiText_).Tables["CUR_COTIZACION"];

            foreach (DataRow dr in dt.Rows) 
            {
                Cotizacion cot = new Cotizacion();
                cot.cot_numero = dr["COT_NUMERO"].ToString();
                cot.cot_id = dr["COT_ID"].ToString();
                cot.cot_fecha = dr["COT_FECHA"].ToString();
                cot.ec_id = dr["EC_NOMBRE"].ToString();
                cot.ven_id = dr["COT_NOMBRE_VEN"].ToString();
                cot.cot_cuentacli = dr["COT_CUENTACLI"].ToString();
                cot.cot_contacto_nom = dr["COT_CONTACTO_NOM"].ToString();
                cot.cot_contacto_ff = dr["COT_CONTACTO_FF"].ToString();
                cot.cot_contacto_mail = dr["COT_CONTACTO_FF"].ToString();
                cot.cot_total = dr["COT_TOTAL"].ToString();

                ls.Add(cot);
            }

            return ls;
        }
    }
}
