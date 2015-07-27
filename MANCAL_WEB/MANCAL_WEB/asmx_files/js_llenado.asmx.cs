using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MANCAL_WEB_BL;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

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
            //System.IO.File.Delete(Server.MapPath("~/adjunto_doc/") + nomArchivo);
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

        [WebMethod]//REVISAR EL TEMA DESCUENTO
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
            MANCAL_WEB_CLASS.CotizacionComision cc = MANCAL_WEB_CLASS.CotizacionComision.objCotCom(obj);
            bl_calculo cal = new bl_calculo();

            cal.setSinCostoComision(cc.lug_id, cc.ccom_qtypersona, cc.ccom_qtycommes, cc.ccom_qtyveh, cc.ccom_qtydia, cc.ccom_qtranseqt, cc.ccom_qtranseqa, cc.ccom_fondor, cc.ccom_qgasrepr, idc, ttar, fcot);
        }

        [WebMethod]
        public ArrayList getListaMagFun(String id_mag, String id_sys) 
        {
            List<MANCAL_WEB_CLASS.CotizacionMagnitudFuncion> lsc = new List<MANCAL_WEB_CLASS.CotizacionMagnitudFuncion>();
            ArrayList ls = new ArrayList();
            bl_carga_cbo cc = new bl_carga_cbo();

            lsc = cc.getMagFunc(id_mag, id_sys);

            foreach (var item in lsc) 
            {
                ls.Add(new ListItem(item.nommagfunc, item.idnmagfunc));
            }

            return ls;
        }

        [WebMethod]//UTILIZADO POR bl_detalle_pro.setDatoPuntoEquipo
        public void setDatoPuntoCot(String idcot, String idesp, String idfun, String txtpunto, String iddetcot, String iditem, String idequ, String pcoment) 
        {
            bl_detalle_pro objDetPro = new bl_detalle_pro();
            objDetPro.setDatoPuntoEquipo(idcot, idesp, idfun, txtpunto, iddetcot, iditem, idequ, pcoment);
        }

        [WebMethod]
        public void setValorEquEdit(Object obj, String tarifa) 
        {
            MANCAL_WEB_CLASS.CotizacionEquipo det = MANCAL_WEB_CLASS.CotizacionEquipo.objCalEqEd(obj);
            bl_detalle_pro o_det = new bl_detalle_pro();

            o_det.setValorEquipoDetEdit(det, tarifa);
        }

        [WebMethod]
        public void delValorEquEdit(String cotid, String cotitem, String coteq) 
        {
            bl_detalle_pro objDet = new bl_detalle_pro();
            objDet.delEquipoCot(cotid, cotitem, coteq);
        }

        [WebMethod]
        public void modEquDetCalProd(String item, String cotiid, String np, String oc, String saot, String lp, String estado) 
        {
            bl_detalle_pro objDet = new bl_detalle_pro();
            objDet.modEquipoDetCalProd(item, cotiid, np, oc, saot, lp, estado);
        }

        [WebMethod]
        public String getVendedorMail(String venid) 
        {
            bl_carga_cbo mail = new bl_carga_cbo();            
            return mail.getMailVendedor(venid);
        }

        [WebMethod]
        public void updPuntoDetFila(String item, String coti, String punto, String indcc, String pcoment) 
        {
            bl_detalle_pro det = new bl_detalle_pro();
            det.setPuntoDetFila(item, coti, punto, indcc, pcoment);
        }

        [WebMethod]//UTILIZADO POR AJAX delPuntoDetFila 
        public void delePuntoDetFila(String item, String coti, String equi, String dccid)         
        {
            bl_detalle_pro det = new bl_detalle_pro();
            det.delPuntoDetFila(item, coti, equi, dccid);
        }

        [WebMethod]
        public void insModDatoPuntoCot(String idcot, String idesp, String idfun, String txtpunto, String iddcc, String iddcitem, String idequ, String pcoment)
        {
            bl_detalle_pro objDetPro = new bl_detalle_pro();
            objDetPro.setDatoPuntoEquipo(idcot, idesp, idfun, txtpunto, iddcc, iddcitem, idequ, pcoment);            
        }

        [WebMethod(EnableSession = true)]//INSERTAR COTIZACION
        public void insObjCotizacion(Object cot, Object trans, Object comi) 
        {
            MANCAL_WEB_CLASS.Cotizacion objCot = MANCAL_WEB_CLASS.Cotizacion.objCotizacion(cot);
            MANCAL_WEB_CLASS.CotizacionTransporte objCotTrans = MANCAL_WEB_CLASS.CotizacionTransporte.objCotiTrans(trans);
            MANCAL_WEB_CLASS.CotizacionComision objCotComis = MANCAL_WEB_CLASS.CotizacionComision.objCotiCom(comi);
            MANCAL_WEB_BL.bl_reporte rpt = new MANCAL_WEB_BL.bl_reporte();
            String validaPto = "";
            int mostrar = 1;

            objCot.CotizacionComision = objCotComis;
            objCot.CotizacionTransporte = objCotTrans;
            
            bl_cotizacion blCot = new bl_cotizacion();
            String[] dataInforme = blCot.insDatoCotizacion(objCot).Split(',');

            if (rpt.getPuntoCotCal(dataInforme[0]).Count < 1)
            {
                validaPto = "N";
            }
            else
            {
                validaPto = "Y";
            }

            Session.Add("RPT_NUM_PTO", validaPto);
            Session.Add("RPT_NUM_COT", dataInforme[0]);
            Session.Add("RPT_NUM_TXT", dataInforme[1]);
            Session.Add("RPT_VAL_ACR", dataInforme[2]);
            Session.Add("COT_VAL_SHW", mostrar);
            Session.Add("COT_VAL_TAR", objCot.tt_id);
            HttpContext.Current.Response.Cookies["COTVALSHW"].Value = mostrar.ToString();
            //return dataInforme;
        }

        [WebMethod(EnableSession = true)]//ACTUALIZAR COTIZACION
        public void updObjCotizacion(Object cot, Object trans, Object comi)
        {
            MANCAL_WEB_CLASS.Cotizacion objCot = MANCAL_WEB_CLASS.Cotizacion.objCotizacion(cot);
            MANCAL_WEB_CLASS.CotizacionTransporte objCotTrans = MANCAL_WEB_CLASS.CotizacionTransporte.objCotiTrans(trans);
            MANCAL_WEB_CLASS.CotizacionComision objCotComis = MANCAL_WEB_CLASS.CotizacionComision.objCotiCom(comi);            
            String validaPto = "";

            objCot.CotizacionComision = objCotComis;
            objCot.CotizacionTransporte = objCotTrans;

            bl_cotizacion blCot = new bl_cotizacion();
            String[] dataInforme = blCot.updDatoCotizacion(objCot).Split(',');

            MANCAL_WEB_BL.bl_reporte rpt = new MANCAL_WEB_BL.bl_reporte();

            if (rpt.getPuntoCotCal(dataInforme[0]).Count < 1)
            {
                validaPto = "N";
            }
            else
            {
                validaPto = "Y";
            }

            Session.Add("RPT_NUM_PTO", validaPto);
            Session.Add("RPT_NUM_COT", dataInforme[0]);
            Session.Add("RPT_NUM_TXT", dataInforme[1]);
            Session.Add("RPT_VAL_ACR", dataInforme[2]);
        }

        [WebMethod]//MOSTRAR COTIZACION EN PAGINA
        public MANCAL_WEB_CLASS.Cotizacion selObjCotizacion(String numcot) 
        {            
            bl_cotizacion blcot = new bl_cotizacion();

            MANCAL_WEB_CLASS.Cotizacion cot = blcot.selDatoCotizacion(numcot);
            
            HttpContext.Current.Response.Cookies["pcusr"].Value = cot.cot_numero;
            HttpContext.Current.Response.Cookies["pcusr"].Expires = DateTime.Now.AddMinutes(60);

            HttpContext.Current.Response.Cookies["txtcot"].Value = cot.cot_id;
            HttpContext.Current.Response.Cookies["txtcot"].Expires = DateTime.Now.AddMinutes(60);

            HttpContext.Current.Response.Cookies["acredi"].Value = cot.tpe_id;
            //JavaScriptSerializer jsrlz = new JavaScriptSerializer();
            //var obj = blcot.selDatoCotizacion(numcot).ToString().ToList();
            //var objJson = jsrlz.Serialize(obj);
            return cot;
        }

        [WebMethod]
        public String[] getDatoAceptadoPor(String idjefe)
        {
            bl_carga_cbo objCbo = new bl_carga_cbo();
            String[] objDAP = new String[2];
            objDAP = objCbo.getDatoAceptadoPor(idjefe);

            return objDAP;
        }

        [WebMethod(EnableSession = true)]
        public void selDocuCotizacion(String numcot, String txtcot)//, String acredito) 
        {
            MANCAL_WEB_BL.bl_reporte rpt = new MANCAL_WEB_BL.bl_reporte();
            String validaPto = "";            

            if (rpt.getPuntoCotCal(numcot).Count < 1)
            {
                validaPto = "N";
            }
            else 
            {
                validaPto = "Y";
            }

            Session.Add("RPT_NUM_PTO", validaPto);
            Session.Add("RPT_NUM_COT", numcot);
            Session.Add("RPT_NUM_TXT", txtcot);
            Session.Add("RPT_VAL_ACR", HttpContext.Current.Request.Cookies["acredi"].Value);
        }

        [WebMethod]//OBTIENE SOLO NOMBRE CLIENTE
        public String getNombreCliente(String cliid) 
        {
            MANCAL_WEB_BL.bl_cliente objCli = new MANCAL_WEB_BL.bl_cliente();
            return objCli.getNombreCli(cliid);
        }

        [WebMethod]
        public void extendCookie(String vcookie) 
        {
            HttpContext.Current.Response.Cookies["v_pr"].Value = vcookie;
            HttpContext.Current.Response.Cookies["v_pr"].Expires = DateTime.Now.AddMinutes(60);
        }

        [WebMethod]
        public String getCotId()
        {
            List<MANCAL_WEB_CLASS.CotizacionEstado> lsc = new List<MANCAL_WEB_CLASS.CotizacionEstado>();
            
            bl_carga_cbo cc = new bl_carga_cbo();
            //String jsonList = "";

            /*foreach (var item in cc.getIdCotizacion())
            {
                MANCAL_WEB_CLASS.CotizacionEstado idcot = new MANCAL_WEB_CLASS.CotizacionEstado();
                idcot.noestado = item;
                lsc.Add(idcot);
            }*/

            JavaScriptSerializer jscr = new JavaScriptSerializer();
            var objser = cc.getIdCotizacion().ToList();
            var jsonList = jscr.Serialize(objser);

            return jsonList;
        }

        //Metodo que realiza el cambio de divisa segun lo seleccionado por el usuario
        [WebMethod]
        public void calCambioDivisa(String curTarifa, String prevTarifa, String fechaCot, String numCoti) 
        {
        
        }

        [WebMethod]
        public String getPwdSigepac(String pwd, String pwdkey) 
        {
            String pwdencripta = "";
            //EncriptaRequest datocrypt = new EncriptaRequest();
            //EncriptaResponse respcrypt = new EncriptaResponse();
            
            //datocrypt.valor = pwd;
            //datocrypt.password = pwdkey;

            //Encripta_wsSOAPPortTypeClient a = new Encripta_wsSOAPPortTypeClient();
            //a.Open();
            //pwdencripta = a.Encripta(datocrypt.valor, datocrypt.password);

            //using (var sr = new SR_EncriptaPasswd.Encripta_wsSOAPPortTypeClient("Encripta_wsSOAPPort"))
            //{
            //    pwdencripta = sr.Encripta(pwd, pwdkey).ToString();
            //}            
            
            //EncriptaRequest req = new EncriptaRequest();
            //req.valor = pwd;
            //req.password = pwdkey;            
            //EncriptaResponse res = new EncriptaResponse();
            

            /*using (var ws = new SR_EncriptaPasswd.Encripta_wsSOAPPortTypeClient("Encripta_wsSOAPPort")) 
            {
                pwdencripta = ws.Encripta(pwd, pwdkey);
            }*/

            Encripta enc = new Encripta();
            pwdencripta = enc.EncryptRijndael("12345", "");
            

            return pwdencripta;
        }
    }
}
