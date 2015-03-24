using System;
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

        #region Metodos Para Proyecto

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
                dcp.nroserie = dr["dp_nserie"].ToString();
                dcp.cantidad = dr["dp_cantidad"].ToString();
                dcp.descripcion = dr["dp_descrip"].ToString();
                dcp.costorepuesto = dr["costorep"].ToString();
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

        public void modEquipo(DetalleCotizacionPro det) 
        {
            objProDet = new dl_detalle_pro();
            int cant = Convert.ToInt32(det.cantidad);
            int item = Convert.ToInt32(det.item);

            objProDet.updateDetalleProy(det.idventa, item, det.nroparte, det.descripcion, det.nroserie, cant, det.costorepuesto, det.preciorepuesto, det.costomo, det.preciomo, det.preciototal);
        }

        public void delEquipo(String[] det) 
        {
            objProDet = new dl_detalle_pro();
            int item = Convert.ToInt32(det[0]);

            objProDet.deleteDetalleProy(det[1], item);
        }

        #endregion

        #region Metodos Cotizacion

        //METODO PARA OBTENER LISTA DE EQUIPO PARA SER SELECCIONADOS
        public List<CotizacionEquipo> getEquipo(String nombre, String nroparte, String modelo, String sysid, String idtarifa, String fcoti) 
        {   
            objProDet=new dl_detalle_pro();
            List<CotizacionEquipo> ls = new List<CotizacionEquipo>();
            int id_sys = Convert.ToInt32(sysid);
            int id_ta = Convert.ToInt32(idtarifa);
            DateTime fechcot = Convert.ToDateTime(fcoti);

            DataTable dt = objProDet.selectEquipoBuscar(nombre.ToUpper(), nroparte.ToUpper(), modelo.ToUpper(), id_sys);
            DataTable dt_eq = new DataTable();

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionEquipo cot = new CotizacionEquipo();
                cot.equiponombre = dr["NOMBRE"].ToString();
                cot.equipomodelo = dr["MODELO"].ToString();
                cot.equiponparte = dr["N_PARTE"].ToString();
                cot.equipoid = dr["ID_PP_PLANTILLA"].ToString();

                int id_eq = Convert.ToInt32(dr["ID_PP_PLANTILLA"].ToString());
                dt_eq = objProDet.selectDatoEquipo(id_sys, id_eq, id_ta, fechcot).Tables["CUR_PRECIO_EQ"];

                foreach (DataRow dr_eq in dt_eq.Rows) 
                {
                    cot.equipotarifaorig = dr_eq["TARIFA_ORIG"].ToString();
                    cot.equipopmo = dr_eq["PRECIO_MO"].ToString();
                    cot.equipocostorep = dr_eq["VAL_RPTO"].ToString();
                    cot.equipocmo = dr_eq["VAL_MO"].ToString();
                    cot.equipototal = dr_eq["PRECIO_VENTA"].ToString();
                }

                ls.Add(cot);
            }

            return ls;
        }

        //CALIBRACIONES METODO PARA OBTENER PRECIO DEL EQUIPO AL SELECCIONARLO
        public DetalleCotizacionPro getDatoEquipo(String ideq, String idtarifa, String fcoti) 
        {
            DetalleCotizacionPro cot = new DetalleCotizacionPro();
            objProDet = new dl_detalle_pro();

            int id_sys = 2;
            int id_eq = Convert.ToInt32(ideq);
            int id_ta = Convert.ToInt32(idtarifa);
            DateTime fechcot = Convert.ToDateTime(fcoti);

            DataTable dt = objProDet.selectDatoEquipo(id_sys, id_eq, id_ta, fechcot).Tables["CUR_PRECIO_EQ"];

            foreach (DataRow dr in dt.Rows) 
            {
                cot.tarifaoriginal = dr["TARIFA_ORIG"].ToString();
                cot.preciomo = dr["PRECIO_MO"].ToString();
                cot.costorepuesto = dr["VAL_RPTO"].ToString();
                cot.costomo = dr["VAL_MO"].ToString();
                cot.preciototal = dr["PRECIO_VENTA"].ToString();
            }

            return cot;
        } 

        #endregion
    }
}
