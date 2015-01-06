﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_detalle_pro
    {
        dl_detalle_pro objProDet;

        public List<DetalleCotizacionPro> getDetalleCotizacion(String idu, String tmo) 
        {
            objProDet = new dl_detalle_pro();
            int moneda=Convert.ToInt32(tmo);
            List<DetalleCotizacionPro> ls = new List<DetalleCotizacionPro>();
            DataTable dt = objProDet.selectDetalleProy(idu, moneda).Tables["cur_det_prov"];

            foreach (DataRow dr in dt.Rows) 
            {
                DetalleCotizacionPro dcp = new DetalleCotizacionPro();
                dcp.idventa = dr["proy_numero"].ToString();
                dcp.item = dr["dp_item"].ToString();
                dcp.nroparte = dr["dp_nroparte"].ToString();
                dcp.cantidad = dr["dp_cantidad"].ToString();
                dcp.nroserie = dr["dp_nserie"].ToString();
                dcp.preciorepuesto = dr["preciorep"].ToString();
                dcp.costomo = dr["costomo"].ToString();
                dcp.preciomo = dr["preciomo"].ToString();
                dcp.preciototal = dr["total"].ToString();
                ls.Add(dcp);
            }
            return ls;
        }

        public String getTotalEquipo(DetalleCotizacionPro det, String coti, String moneda)
        {
            objProDet = new dl_detalle_pro();
            int tcoti = Convert.ToInt32(coti);
            int tmoneda = Convert.ToInt32(moneda);
            int cant = Convert.ToInt32(det.cantidad);

            String totalEq = objProDet.selectTotalEquipoIn(tcoti, tmoneda, det.costorepuesto, det.preciorepuesto, det.costomo, det.preciomo, cant);

            return totalEq;
        }

        public void setEquipo(DetalleCotizacionPro det) 
        {
            objProDet = new dl_detalle_pro();
            int cant = Convert.ToInt32(det.cantidad);

            objProDet.insertEquipoIn(det.idventa, det.nroparte, det.descripcion, det.nroserie, cant, det.costorepuesto, det.preciorepuesto, det.costomo, det.preciomo, det.preciototal);
        }
    }
}