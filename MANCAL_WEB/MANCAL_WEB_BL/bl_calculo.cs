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
            int idntipocot = cotin.tc_id;

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
            }

            return cot;
        }
    }
}
