using System;
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

            bl_detalle_pro objdp = new bl_detalle_pro();

            det = objdp.getDatoEquipo(ideq, idtarifa, fcoti);            

            return det;
        }
    }
}
