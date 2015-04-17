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

        //CALIBRACION METODO PARA OBTENER LISTA DE EQUIPO PARA SER SELECCIONADOS
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

                //int id_eq = Convert.ToInt32(dr["ID_PP_PLANTILLA"].ToString());
                //dt_eq = objProDet.selectValorEquipo(id_sys, id_eq, id_ta, fechcot).Tables["CUR_PRECIO_EQ"];

                //foreach (DataRow dr_eq in dt_eq.Rows) 
                //{
                //    cot.equipotarifaorig = dr_eq["TARIFA_ORIG"].ToString();
                //    cot.equipopmo = dr_eq["PRECIO_MO"].ToString();
                //    cot.equipocostorep = dr_eq["VAL_RPTO"].ToString();
                //    cot.equipocmo = dr_eq["VAL_MO"].ToString();
                //    cot.equipocalpeso = dr_eq["PESO_EQ"].ToString();
                //    cot.equipototal = dr_eq["PRECIO_VENTA"].ToString();
                //}

                ls.Add(cot);
            }

            return ls;
        }

        public CotizacionEquipo getEquipoValCom(String sys_id, String eq_id, String eq_tar, String eq_fec) 
        {
            CotizacionEquipo ce = new CotizacionEquipo();
            objProDet = new dl_detalle_pro();

            int id_sys = Convert.ToInt32(sys_id);
            int id_eq = Convert.ToInt32(eq_id);
            int tar_eq = Convert.ToInt32(eq_tar);
            DateTime dtCot = Convert.ToDateTime(eq_fec);

            DataTable dt = objProDet.selectValorEquipo(id_sys, id_eq, tar_eq, dtCot).Tables["CUR_PRECIO_EQ"];

            foreach (DataRow dr in dt.Rows) 
            {
                ce.equipotarifaorig = dr["TARIFA_ORIG"].ToString();
                ce.equipopmo = dr["PRECIO_MO"].ToString();
                ce.equipocostorep = dr["VAL_RPTO"].ToString();
                ce.equipocmo = dr["VAL_MO"].ToString();
                ce.equipocalpeso = dr["PESO_EQ"].ToString();
                ce.equipototal = dr["PRECIO_VENTA"].ToString();
            }            

            return ce;
        }

        #endregion

        //CALIBRACION METODO PARA CALCULAR EQUIPOS MODIFICADOS
        public String[] calculaEquipo(String eq_id, String sys_id, String qty, String pmo, String gasto, String pcarga, String tarifa_id, String fecha_cot) 
        {
            objProDet = new dl_detalle_pro();
            int id_eq = Convert.ToInt32(eq_id);
            int id_sys = Convert.ToInt32(sys_id);
            int eq_qty = Convert.ToInt32(qty);
            int tarifa = Convert.ToInt32(tarifa_id);
            DateTime fcot = Convert.ToDateTime(fecha_cot);
            String[] cal_calculo = new String[2];

            DataTable dt = objProDet.selectCalculoEquipo(id_eq, id_sys, eq_qty, pmo, gasto, pcarga, tarifa, fcot).Tables["RET_PRECIO_VENTA"];

            foreach (DataRow dr in dt.Rows) 
            {
                if (dr["RES_VALIDA"].ToString().Equals("Y"))
                {
                    cal_calculo[0] = dr["RES_TOTAL"].ToString();
                    cal_calculo[1] = "";
                }
                else 
                {
                    cal_calculo[0] = dr["RES_PRECIOMO"].ToString();
                    cal_calculo[1] = "El Precio MO no puede ser menor al ya estipulado (Precio MO Ref: " + dr["RES_REALPMO"].ToString() + ")";
                }
            }

            return cal_calculo;
        }

        public void setDetCotCal(CotizacionEquipo coteq) 
        {
            objProDet = new dl_detalle_pro();
            String tblxml;
            DataTable dt = new DataTable("EqCotizado");

            dt.Columns.Add("equipocotid", typeof(string));
            dt.Columns.Add("equipoid", typeof(string));
            dt.Columns.Add("equiponparte", typeof(string));
            dt.Columns.Add("equiponserie", typeof(string));
            dt.Columns.Add("equipocantidad", typeof(string));
            dt.Columns.Add("equipotrabajo", typeof(string));
            dt.Columns.Add("equipocostorep", typeof(string));
            dt.Columns.Add("equipocmo", typeof(string));
            dt.Columns.Add("equipopmo", typeof(string));
            dt.Columns.Add("equipototal", typeof(string));
            dt.Columns.Add("equipotarifaorig", typeof(string));
            dt.Columns.Add("equipocalgasto", typeof(string));
            dt.Columns.Add("equipocalpeso", typeof(string));
            dt.Columns.Add("equipocalpcarga", typeof(string));
            dt.Columns.Add("equipocalnp", typeof(string));
            dt.Columns.Add("equipocaloc", typeof(string));
            dt.Columns.Add("equipocalsaot", typeof(string));
            dt.Columns.Add("equipolp_idn", typeof(string));
            dt.Columns.Add("equipodet_idn", typeof(string));
            dt.Columns.Add("equipomodelo", typeof(string));
            dt.Columns.Add("equiponombre", typeof(string));

            DataRow dr = dt.NewRow();
            dr["equipotarifaorig"] = coteq.equipotarifaorig;
            dr["equipopmo"] = coteq.equipopmo;
            dr["equipocostorep"] = coteq.equipocostorep;
            dr["equipocmo"] = coteq.equipocmo;
            dr["equipototal"] = coteq.equipototal;
            dr["equiponparte"] = coteq.equiponparte;
            dr["equiponserie"] = coteq.equiponserie;
            dr["equipomodelo"] = coteq.equipomodelo;
            dr["equiponombre"] = coteq.equiponombre;
            dr["equipocalpeso"] = coteq.equipocalpeso;
            dr["equipocantidad"] = coteq.equipocantidad;
            dr["equipocalgasto"] = coteq.equipocalgasto;
            dr["equipocalpcarga"] = coteq.equipocalpcarga;
            dr["equipoid"] = coteq.equipoid;
            dr["equipocotid"] = coteq.equipocotid;
            dr["equipocalnp"] = coteq.equipocalnp;
            dr["equipocaloc"] = coteq.equipocaloc;
            dr["equipocalsaot"] = coteq.equipocalsaot;
            dr["equipolp_idn"] = coteq.equipolp_idn;
            dr["equipodet_idn"] = coteq.equipodet_idn;
            dr["equipotrabajo"] = coteq.equipotrabajo;

            dt.Rows.Add(dr);

            using (StringWriter swr = new StringWriter()) 
            {
                dt.WriteXml(swr);
                tblxml = swr.ToString();
            }

            objProDet.insertDetCotCal(tblxml);
        }

        public List<CotizacionEquipo> getDetalleCot(String cot_id, String tarifa_id) 
        {
            List<CotizacionEquipo> ls = new List<CotizacionEquipo>();
            objProDet = new dl_detalle_pro();
            int idtarifa = Convert.ToInt32(tarifa_id);

            DataTable dt = objProDet.selectEquipoCot(cot_id, idtarifa).Tables["CUR_DET"];

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionEquipo ce = new CotizacionEquipo();
                ce.equipocotid = dr["COT_NUMERO"].ToString();
                ce.equipoid = dr["DC_ID_EQUIPO"].ToString();
                ce.equipoitem = dr["DC_ITEM"].ToString();
                ce.equiponombre = dr["NOMBRE_EQ"].ToString();
                ce.equipomodelo = dr["MODELO_EQ"].ToString();
                ce.equiponparte = dr["DC_NPARTE"].ToString();
                ce.equiponserie = dr["DC_NSERIE"].ToString();
                ce.equipocantidad = dr["DC_CANTIDAD"].ToString();
                ce.equipopmo = dr["PRECIOMO"].ToString();
                ce.equipocalgasto = dr["GASTO"].ToString();
                ce.equipocalpcarga = dr["PRECIOCARGA"].ToString();
                ce.equipototal = dr["TOTAL"].ToString();
                ce.equipocalid = dr["DCC_ID"].ToString();
                ce.equipocalnp = dr["DCC_NP"].ToString();
                ce.equipocaloc = dr["DCC_OC"].ToString();
                ce.equipocalsaot = dr["DCC_SAOT"].ToString();
                ce.equipolp_idn = dr["LP_ID"].ToString();
                ce.equipolp_nom = dr["LP_NOMBRE"].ToString();
                ce.equipodet_idn = dr["DCE_ID"].ToString();
                ce.equipodet_nom = dr["DCE_NOMBRE"].ToString();
                ce.equipotrabajo = dr["TTR_NOMBRE"].ToString();
                ce.equipotrabajoid = dr["TTR_ID"].ToString();

                ls.Add(ce);
            }            

            return ls;
        }

        //UTILIZADO POR WEBMETHOD setDatoPuntoCot
        public void setDatoPuntoEquipo(String cot_id, String esp_id, String fun_id, String punto_in, String id_detcot, String id_item, String equ_id) 
        {
            objProDet = new dl_detalle_pro();
            
            int idesp = Convert.ToInt32(esp_id);
            int idfun = Convert.ToInt32(fun_id);
            int iddc = Convert.ToInt32(id_detcot);
            int iditm = Convert.ToInt32(id_item);
            int idequ = Convert.ToInt32(equ_id);

            objProDet.insertDatoPuntoEquipo(cot_id, idesp, idfun, punto_in, iddc, iditm, idequ);
        }

        public List<CotizacionPunto> getListaPuntoEquipo(String idcot, String idequ, String iddcc) 
        {
            objProDet = new dl_detalle_pro();
            List<CotizacionPunto> ls = new List<CotizacionPunto>();
            int equid = Convert.ToInt32(idequ);
            int? dccid = 0;

            if (String.IsNullOrEmpty(iddcc))
            {
                dccid = null;
            }
            else 
            {
                dccid = Convert.ToInt32(iddcc);
            }

            DataTable dt = objProDet.selectDatoPuntoEquipo(idcot, equid, dccid).Tables["CUR_DETPUNTO"];

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionPunto cp = new CotizacionPunto();
                cp.cp_id = dr["PDCC_ID"].ToString();
                cp.cp_id_esp = dr["PDCC_ID_ESP"].ToString();
                cp.cp_no_esp = dr["NOM_ESP"].ToString();
                cp.cp_id_mag = dr["PDCC_ID_MAG"].ToString();
                cp.cp_no_mag = dr["NOM_MAG"].ToString();
                cp.cp_punto = dr["PDCC_PUNTO"].ToString();
                cp.cp_dcot_id = dr["DCC_ID"].ToString();
                cp.cp_numero = dr["COT_NUMERO"].ToString();
                cp.cp_item = dr["DC_ITEM"].ToString();
                cp.cp_id_equipo = dr["DC_ID_EQUIPO"].ToString();

                ls.Add(cp);
            }

            return ls;
        }

        public void setValorEquipoDetEdit(CotizacionEquipo ceq, String idtarifa) 
        {
            objProDet = new dl_detalle_pro();
            int tarifaid = Convert.ToInt32(idtarifa);
            int cantidad = Convert.ToInt32(ceq.equipocantidad);
            int nitem = Convert.ToInt32(ceq.equipoitem);
            
            objProDet.updateValorEquipoDet(ceq.equipocotid, nitem, ceq.equiponparte, ceq.equiponserie, cantidad, ceq.equipopmo, ceq.equipocalgasto, ceq.equipocalpcarga, ceq.equipototal, tarifaid);
        }

        public void delEquipoCot(String idcot, String nitem, String equid) 
        {
            objProDet = new dl_detalle_pro();
            int itemn = Convert.ToInt32(nitem);
            int ideq = Convert.ToInt32(equid);

            objProDet.deleteEquipoCot(idcot, itemn, ideq);
        }

        public void modEquipoDetCalProd(String item_, String cotiid_, String np_, String oc_, String saot_, String lp_, String estado_) 
        {
            objProDet = new dl_detalle_pro();
            int nitem = Convert.ToInt32(item_);
            int nlp = Convert.ToInt32(lp_);
            int nestado = Convert.ToInt32(estado_);

            objProDet.updateEquipoDetCalProd(nitem, cotiid_, np_, oc_, saot_, nlp, nestado);
        }

        public void setPuntoDetFila(String itemnro, String cotiid, String detpunto, String indcc) //ACTUALIZA UN ITEM DE LA LISTA DE PUNTOS DEL EQUIPO
        {
            objProDet = new dl_detalle_pro();
            int nroitem = Convert.ToInt32(itemnro);
            int dccin = Convert.ToInt32(indcc);
            objProDet.updatePuntoDetFila(nroitem, cotiid, detpunto, dccin);
        }

        public void delPuntoDetFila(String item, String coti, String equipo, String dccin) 
        {
            objProDet = new dl_detalle_pro();
            int nroitem = Convert.ToInt32(item);
            int nroequipo = Convert.ToInt32(equipo);
            int in_dcc = Convert.ToInt32(dccin);
            objProDet.deletePuntoDetFila(nroitem, coti, nroequipo, in_dcc);
        }
    }
}