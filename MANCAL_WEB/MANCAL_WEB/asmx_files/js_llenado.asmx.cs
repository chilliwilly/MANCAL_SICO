﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MANCAL_WEB_BL;

namespace MANCAL_WEB.asmx_files
{
    /// <summary>
    /// Descripción breve de js_llenado
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class js_llenado : System.Web.Services.WebService
    {

        [WebMethod]
        public String lsNroParte()
        {
            bl_equipo objEquipo = new bl_equipo();

            return objEquipo.listaEquipo();
        }

        [WebMethod]
        public void setDatoEquipo(Object eq)
        {
            MANCAL_WEB_CLASS.DetalleCotizacionPro det = MANCAL_WEB_CLASS.DetalleCotizacionPro.getObjDet(eq);

            bl_detalle_pro objBL = new bl_detalle_pro();
            objBL.setEquipo(det);
        }

        [WebMethod]
        public String getSumEquipo(Object eq, String tcot, String tmon)
        {
            MANCAL_WEB_CLASS.DetalleCotizacionPro det = MANCAL_WEB_CLASS.DetalleCotizacionPro.getObjDet(eq);

            bl_detalle_pro objBL = new bl_detalle_pro();
            String totEq = objBL.getTotalEquipo(det, tcot, tmon);

            return totEq;
        }

        [WebMethod]
        public void modDatoEquipo(Object eq) 
        {
            MANCAL_WEB_CLASS.DetalleCotizacionPro det = MANCAL_WEB_CLASS.DetalleCotizacionPro.getObjDet(eq);

            bl_detalle_pro objBL = new bl_detalle_pro();
            objBL.modEquipo(det);
        }

        [WebMethod]
        public void delDatoEquipo(Object eq) 
        {
            MANCAL_WEB_CLASS.DetalleCotizacionPro det = MANCAL_WEB_CLASS.DetalleCotizacionPro.getObjDet(eq);

            bl_detalle_pro objBL = new bl_detalle_pro();
            String[] objDet = { det.item, det.idventa };

            objBL.delEquipo(objDet);
        }

        [WebMethod]
        public void delDatoArchivo(String item_, String coti_)
        {
            MANCAL_WEB_BL.bl_adjunto objAdjunto = new MANCAL_WEB_BL.bl_adjunto();
            String nomArchivo = objAdjunto.delAdjunto(item_, coti_);
            System.IO.File.Delete(Server.MapPath("~/adjunto_doc/") + nomArchivo);
        }

        [WebMethod]
        public static MANCAL_WEB_CLASS.DetalleCotizacionPro getDatoEq(String ideq, String idtarifa, String fcoti) 
        {            
            MANCAL_WEB_CLASS.DetalleCotizacionPro det = new MANCAL_WEB_CLASS.DetalleCotizacionPro();

            //bl_detalle_pro objdp = new bl_detalle_pro();

            //det = objdp.getDatoEquipo(ideq, idtarifa, fcoti);            

            return det;
        }

        [WebMethod]
        public MANCAL_WEB_CLASS.CotizacionEquipo getCotEquipo(Object obj) 
        {
            MANCAL_WEB_CLASS.CotizacionEquipo eq = MANCAL_WEB_CLASS.CotizacionEquipo.objCotEq(obj);

            return null;
        }

        [WebMethod]
        public String[] getCalculaEquipo(Object obj, String id_sys, String id_tarifa, String f_cot) 
        {
            String[] a_calculo = new String[2];

            MANCAL_WEB_CLASS.CotizacionEquipo det = MANCAL_WEB_CLASS.CotizacionEquipo.objCalEq(obj);
            bl_detalle_pro m_det = new bl_detalle_pro();

            a_calculo = m_det.calculaEquipo(det.equipoid, id_sys, det.equipocantidad, det.equipopmo, det.equipocalgasto, det.equipocalpcarga, id_tarifa, f_cot);

            return a_calculo;
        }

        [WebMethod]
        public void setEquipoSeleccion(Object obj) 
        {
            MANCAL_WEB_CLASS.CotizacionEquipo det = MANCAL_WEB_CLASS.CotizacionEquipo.objCalEqGuarda(obj);
            bl_detalle_pro o_det = new bl_detalle_pro();

            o_det.setDetCotCal(det);
        }

        [WebMethod]
        public MANCAL_WEB_CLASS.CotizacionEquipo getEqComercial(String e_id, String e_tarifa, String e_fecha)
        {
            MANCAL_WEB_CLASS.CotizacionEquipo c = new MANCAL_WEB_CLASS.CotizacionEquipo();
            bl_detalle_pro o_det = new bl_detalle_pro();
            String idsys = "2";
            c = o_det.getEquipoValCom(idsys, e_id, e_tarifa, e_fecha);

            return c;
        }

        [WebMethod]
        public String getCotTotalTrans(String cotid, String trasid, String regiid, String tariid, String cotfec) 
        {
            MANCAL_WEB_BL.bl_calculo obj = new MANCAL_WEB_BL.bl_calculo();
            String total = obj.getTotalTransporte(cotid, trasid, regiid, tariid, cotfec);

            return total;
        }

        [WebMethod]
        public void setCotTotalSinTrans(String idcot) 
        {
            MANCAL_WEB_BL.bl_calculo obj = new MANCAL_WEB_BL.bl_calculo();
            obj.setTotalSinTransporte(idcot);
        }

        [WebMethod]
        public MANCAL_WEB_CLASS.CotizacionComision getCotComision(Object obj, String idc, String ttar, String fcot) 
        {            
            MANCAL_WEB_CLASS.CotizacionComision cc = MANCAL_WEB_CLASS.CotizacionComision.objCotCom(obj);
            bl_calculo cal = new bl_calculo();

            MANCAL_WEB_CLASS.CotizacionComision retCom = cal.getTotalComision(cc.lug_id, cc.ccom_qtypersona, cc.ccom_qtycommes, cc.ccom_qtyveh, cc.ccom_qtydia, cc.ccom_qtranseqt, cc.ccom_qtranseqa, cc.ccom_fondor, cc.ccom_qgasrepr, idc, ttar, fcot);

            return retCom;
        }

        [WebMethod]
        public MANCAL_WEB_CLASS.Cotizacion getCotTotalMargen(Object obj, String idun) 
        {
            MANCAL_WEB_CLASS.Cotizacion coti = MANCAL_WEB_CLASS.Cotizacion.objCotiTotal(obj);
            bl_calculo cal = new bl_calculo();

            MANCAL_WEB_CLASS.Cotizacion infoCot = cal.getMargenTotal(coti, idun);

            return infoCot;
        }

        [WebMethod]//costo comision
        public void setTotalCostoCom(Object obj, String idc, String ttar, String fcot) //sec_prev = sector previo
        { 
        //devolver a 0 costo comision recalcular dcc_gasto y restarlo del actual y dejar en 0 factor comision.
            MANCAL_WEB_CLASS.CotizacionComision cc = MANCAL_WEB_CLASS.CotizacionComision.objCotCom(obj);
            bl_calculo cal = new bl_calculo();

            cal.setSinCostoComision(cc.lug_id, cc.ccom_qtypersona, cc.ccom_qtycommes, cc.ccom_qtyveh, cc.ccom_qtydia, cc.ccom_qtranseqt, cc.ccom_qtranseqa, cc.ccom_fondor, cc.ccom_qgasrepr, idc, ttar, fcot);
        }
    }
}
