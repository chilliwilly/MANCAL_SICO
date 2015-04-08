using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_DL;
using MANCAL_WEB_CLASS;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_calculo
    {
        dl_calculo objCalculo;

        public Cotizacion getMargenTotal(Cotizacion cotin, String iduneg)
        {
            objCalculo = new dl_calculo();
            Cotizacion cot = new Cotizacion();

            int tipomoneda = Convert.ToInt32(cotin.cot_tipomoneda);
            int idniva = Convert.ToInt32(cotin.cot_afecto);
            int idntipocot = Convert.ToInt32(cotin.tc_id);

            DataTable dt = objCalculo.selectTotalDetalle(tipomoneda, cotin.cot_descuento, idniva, cotin.cot_id, iduneg).Tables["cur_ret_total"];
            DataTable dtm = objCalculo.selectTotalMargenes(cotin.cot_id, tipomoneda, idntipocot, cotin.cot_fecha, iduneg).Tables["cur_total_margen"];

            foreach (DataRow dr in dt.Rows) 
            {
                cot.cot_neto = dr["NETO"].ToString();
                cot.cot_netodcto = dr["NETODESC"].ToString();
                cot.cot_iva = dr["IVA"].ToString();
                cot.cot_total = dr["TOTAL"].ToString();
            }

            foreach (DataRow dr in dtm.Rows) 
            {
                cot.cot_totcostmo = dr["TOTALMO"].ToString();
                cot.cot_totvalrpto = dr["TOTALRPTO"].ToString();
                cot.cot_mgopporc = dr["PORCMGOPERACIONAL"].ToString();
                cot.cot_mgbrutoporc = dr["PORCMGBRUTO"].ToString();
                cot.cot_mgcontrib = dr["MGCONTRIBUCION"].ToString();
                cot.cot_mgcontribporc = dr["PORCMGCONTRIBUCION"].ToString();
                cot.cot_utilesperaporc = dr["PORCUTILIDADESPERA"].ToString();
                cot.cot_tipomoneda = dr["TXTTIPOMONEDA"].ToString();

                //utilizado solo para devolver el mensaje del margen
                if (dr["TXTMGAUTORIZA"].ToString().Equals("N"))
                {
                    cot.cot_msgautoriza = "El margen bruto porcentual no puede ser menor al margen autorizado (" + dr["PORCMGAUTORIZA"].ToString() + ")";
                }
                else 
                {
                    cot.cot_msgautoriza = "Y";
                }
            }

            return cot;
        }

        public String getTotalTransporte(String cotid, String trasid, String regiid, String tariid, String cotfec) 
        {
            objCalculo = new dl_calculo();
            int idtras = Convert.ToInt32(trasid);
            int idregi = Convert.ToInt32(regiid);
            int idtari = Convert.ToInt32(tariid);
            DateTime fechco = Convert.ToDateTime(cotfec);
            String total = objCalculo.selectTotalTransporte(cotid, idtras, idregi, idtari, fechco);            

            return total;
        }

        public void setTotalSinTransporte(String cotid) 
        {
            objCalculo = new dl_calculo();
            objCalculo.selectTotalSinTransporte(cotid);
        }

        public void setSinCostoComision(String idlugar, String qtypersona, String qtycommes, String qtyveh, String qtydia, String eqdoct, String eqdoca, String fondoren, String gastorep, String idcoti, String ttarifa, String fcoti)
        {
            CotizacionComision cc = new CotizacionComision();
            objCalculo = new dl_calculo();

            int lugarid = Convert.ToInt32(idlugar);
            int personaqty = Convert.ToInt32(qtypersona);
            int commesqty = Convert.ToInt32(qtycommes);
            int vehqty = Convert.ToInt32(qtyveh);
            int diaqty = Convert.ToInt32(qtydia);
            int tdoceq = Convert.ToInt32(eqdoct);
            int adoceq = Convert.ToInt32(eqdoca);
            int renfondo = Convert.ToInt32(fondoren);
            int repgasto = Convert.ToInt32(gastorep);
            int tarifat = Convert.ToInt32(ttarifa);
            DateTime cotif = Convert.ToDateTime(fcoti);

            objCalculo.selectSinCostoComision(lugarid, personaqty, commesqty, vehqty, diaqty, tdoceq, adoceq, renfondo, repgasto, idcoti, tarifat, cotif);
        }

        public CotizacionComision getTotalComision(String idlugar, String qtypersona, String qtycommes, String qtyveh, String qtydia, String eqdoct, String eqdoca, String fondoren, String gastorep, String idcoti, String ttarifa, String fcoti) 
        {
            CotizacionComision cc = new CotizacionComision();
            objCalculo = new dl_calculo();

            int lugarid = Convert.ToInt32(idlugar);
            int personaqty = Convert.ToInt32(qtypersona);
            int commesqty = Convert.ToInt32(qtycommes);
            int vehqty = Convert.ToInt32(qtyveh);
            int diaqty = Convert.ToInt32(qtydia);
            int tdoceq = Convert.ToInt32(eqdoct);
            int adoceq = Convert.ToInt32(eqdoca);
            int renfondo = Convert.ToInt32(fondoren);
            int repgasto = Convert.ToInt32(gastorep);
            int tarifat = Convert.ToInt32(ttarifa);
            DateTime cotif = Convert.ToDateTime(fcoti);

            DataTable dt = objCalculo.selectCostoComision(lugarid, personaqty, commesqty, vehqty, diaqty, tdoceq, adoceq, renfondo, repgasto, idcoti, tarifat, cotif).Tables["CUR_COMISION"];

            foreach (DataRow dr in dt.Rows) 
            {
                cc.ccom_transdts = dr["TRANSDTS"].ToString();
                cc.ccom_transhotel = dr["TRANSHOTEL"].ToString();
                cc.ccom_psjavionper = dr["PSJEAVION"].ToString();
                cc.ccom_alqveh = dr["RENTVEH"].ToString();
                cc.ccom_transeqt = dr["EQDOCC"].ToString();
                cc.ccom_transeqa = dr["EQDOCA"].ToString();
                cc.ccom_viatico = dr["VIATICO"].ToString();
                cc.ccom_hotel = dr["HOTEL"].ToString();
                cc.ccom_frendir = dr["FONDORENDIR"].ToString();
                cc.ccom_gasrepr = dr["GASTOREP"].ToString();
                cc.ccom_totalcom = dr["COMISION"].ToString();
                cc.ccom_totalcommg = dr["COMISIONMG"].ToString();
            }

            return cc;
        }
    }
}
