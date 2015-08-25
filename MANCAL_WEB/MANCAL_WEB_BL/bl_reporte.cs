using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_DL;
using MANCAL_WEB_CLASS;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_reporte
    {
        dl_reporte objReport;

        public List<CotizacionEquipo> getDetCotCal(String numcot) 
        {
            List<CotizacionEquipo> ls = new List<CotizacionEquipo>();
            int cot_num = Convert.ToInt32(numcot);
            objReport = new dl_reporte();

            DataTable dt = objReport.selectDetCotCal(cot_num).Tables["CUR_DETALLE"];

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionEquipo ce = new CotizacionEquipo();
                ce.equipoitem = dr["DC_ITEM"].ToString();//ESTE
                ce.equiponombre = dr["DC_NOMBRE_EQ"].ToString();//ESTE
                ce.equiponparte = dr["DC_NPARTE"].ToString();//ESTE
                //ce.equiponserie = dr["DC_NSERIE"].ToString();
                ce.equipocantidad = dr["DC_CANTIDAD"].ToString();//ESTE
                ce.equipocalsaot = dr["DC_TOTAL_UNITARIO"].ToString();//ESTE
                ce.equipototal = dr["DC_TOTAL_EQ"].ToString();//ESTE

                ls.Add(ce);
            }


            return ls;
        }

        public List<Cotizacion> getMainCotCal(String numcot) 
        {
            List<Cotizacion> ls = new List<Cotizacion>();
            int cot_num = Convert.ToInt32(numcot);
            objReport = new dl_reporte();

            DataTable dt = objReport.selectMainCotCal(cot_num).Tables["CUR_COTI"];

            foreach (DataRow dr in dt.Rows) 
            {                
                Cotizacion cot = new Cotizacion();
                cot.cot_id = dr["COT_ID"].ToString();
                cot.cot_informecli = dr["COT_INFORMECLI"].ToString();
                cot.cot_contacto_nom = dr["COT_CONTACTO_NOM"].ToString();
                //cot.cot_contacto_cargo = dr["COT_CONTACTO_CAR"].ToString();
                cot.cot_fecha = dr["FECHA_COT"].ToString();
                cot.cot_contacto_mail = dr["COT_CONTACTO_MAIL"].ToString();
                cot.cot_contacto_ff = dr["COT_CONTACTO_FONO"].ToString();
                cot.cot_contacto_dir = dr["COT_CONTACTO_DIR"].ToString();
                cot.cot_certificado_dir = dr["COT_CERTIFICADO_DIR"].ToString();
                cot.tlej_id = dr["TLEJ_NOMBRE"].ToString();
                cot.cot_cantidad = dr["COT_QTY"].ToString();//qty
                cot.cot_moneda_texto = dr["COT_TEXTO_MONEDA"].ToString();//moneda con texto
                cot.cot_tipomoneda = dr["COT_TIPOMONEDA"].ToString();
                cot.cot_txtfacturacion = dr["COT_TEXTO_FACTURA"].ToString();
                cot.cot_txtformapago = dr["COT_TEXTO_FPAGO"].ToString();
                cot.cot_txttpe = dr["COT_TEXTO_PCALIB"].ToString();
                cot.cot_valioferta = dr["VALIDEZ_COT"].ToString();
                cot.tt_id = dr["COT_NOM_TRABAJO"].ToString();//nombre trabajo
                cot.CotizacionVendedor = new CotizacionVendedor(dr["COT_VEN_NOMBRE"].ToString(), dr["COT_VEN_MAIL"].ToString(), dr["VEN_FONO"].ToString());//fono vendedor
                //cot.CotizacionVendedor.id_mail = dr["COT_VEN_MAIL"].ToString();//mail vendedor
                //cot.CotizacionVendedor.id_nom = dr["COT_VEN_NOMBRE"].ToString();//vendedor nombre
                cot.cot_descuento = dr["COT_T_DCTO"].ToString();//descuento                
                cot.cot_neto = dr["COT_T_NETO"].ToString();//neto
                cot.cot_netodcto = dr["COT_T_NETODCTO"].ToString();//netodesc
                cot.cot_iva = dr["COT_T_IVA"].ToString();//iva
                cot.cot_total = dr["COT_T_TOTAL"].ToString();//total
                cot.cot_notauno = dr["COT_NOTAUNO"].ToString();//nota 1
                cot.cot_notados = dr["COT_NOTADOS"].ToString();//nota 2
                cot.CotizacionEjecutivo = new CotizacionEjecutivo(dr["COT_NOM_EJEC"].ToString(), dr["COT_FONO_EJEC"].ToString(), dr["COT_MAIL_EJEC"].ToString());
                //cot.CotizacionEjecutivo.ejec_nom = dr["COT_NOM_EJEC"].ToString();//nom ejec
                //cot.CotizacionEjecutivo.ejec_mail = dr["COT_MAIL_EJEC"].ToString();//mail ejec
                //cot.CotizacionEjecutivo.ejec_fono = dr["COT_FONO_EJEC"].ToString();//fono ejec
                cot.cot_chkdcto = dr["COT_CHKDCTO"].ToString();//validador dcto
                //cot.cot_id = dr[""].ToString();//foto firma

                ls.Add(cot);
            }

            return ls;
        }

        public List<CotizacionPunto> getPuntoCotCal(String numcot) 
        {
            List<CotizacionPunto> ls = new List<CotizacionPunto>();
            int cot_num = Convert.ToInt32(numcot);
            objReport = new dl_reporte();

            DataTable dt = objReport.selectDetPuntoCal(cot_num).Tables["CUR_PUNTO"];

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionPunto cp = new CotizacionPunto();
                cp.cp_id = dr["PDCC_ID"].ToString();
                cp.cp_id_equipo = dr["PDCC_NOMBREEQ"].ToString();
                cp.cp_numero = dr["PDCC_NPARTE"].ToString();
                cp.cp_no_mag = dr["PDCC_FUNCION"].ToString();
                cp.cp_punto = dr["PDCC_PUNTO"].ToString();
                cp.cp_dcot_id = dr["PDCC_COTID"].ToString();

                ls.Add(cp);
            }

            return ls;
        }

        public List<CotizacionPunto> getPuntoCotCalComent(String numcot) 
        {
            List<CotizacionPunto> ls = new List<CotizacionPunto>();
            int cot_num = Convert.ToInt32(numcot);
            objReport = new dl_reporte();

            DataTable dt = objReport.selectDetPuntoCal(cot_num).Tables["CUR_PUNTO"];

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionPunto cp = new CotizacionPunto();
                cp.cp_id = dr["PDCC_ID"].ToString();
                cp.cp_numero = dr["PDCC_NPARTE"].ToString();
                cp.cp_comentario = dr["PDCC_COMENTARIO"].ToString();

                ls.Add(cp);
            }

            return ls;
        }
    }
}
