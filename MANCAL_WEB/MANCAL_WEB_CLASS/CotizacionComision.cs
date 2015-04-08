using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionComision //: Cotizacion
    {
        public String ccom_id { get; set; }
        public String ccom_qtypersona { get; set; }
        public String ccom_qtydia { get; set; }
        public String ccom_qtyveh { get; set; }
        public String ccom_qtranseqt { get; set; }
        public String ccom_qtranseqa { get; set; }
        public String ccom_fondor { get; set; }
        public String ccom_qgasrepr { get; set; }
        public String ccom_qtycommes { get; set; }
        public String ccom_transdts { get; set; }
        public String ccom_transhotel { get; set; }
        public String ccom_psjavionper { get; set; }
        public String ccom_alqveh { get; set; }
        public String ccom_transeqt { get; set; }
        public String ccom_transeqa { get; set; }
        public String ccom_viatico { get; set; }
        public String ccom_hotel { get; set; }
        public String ccom_frendir { get; set; }
        public String ccom_gasrepr { get; set; }
        public String ccom_totalcom { get; set; }
        public String ccom_totalcommg { get; set; }
        public String lug_id { get; set; }

        public CotizacionComision() { }

        public static CotizacionComision objCotCom(Object obj) 
        {
            CotizacionComision cc = new CotizacionComision();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object lug_id = null;
            Object ccom_qtypersona = null;
            Object ccom_qtydia = null;
            Object ccom_qtyveh = null;
            Object ccom_qtranseqt = null;
            Object ccom_qtranseqa = null;
            Object ccom_fondor = null;
            Object ccom_qgasrepr = null;
            Object ccom_qtycommes = null;

            d.TryGetValue("lug_id", out lug_id);
            d.TryGetValue("ccom_qtypersona", out ccom_qtypersona);
            d.TryGetValue("ccom_qtydia", out ccom_qtydia);
            d.TryGetValue("ccom_qtyveh", out ccom_qtyveh);
            d.TryGetValue("ccom_qtranseqt", out ccom_qtranseqt);
            d.TryGetValue("ccom_qtranseqa", out ccom_qtranseqa);
            d.TryGetValue("ccom_fondor", out ccom_fondor);
            d.TryGetValue("ccom_qgasrepr", out ccom_qgasrepr);
            d.TryGetValue("ccom_qtycommes", out ccom_qtycommes);

            cc.lug_id = lug_id.ToString();
            cc.ccom_qtypersona = ccom_qtypersona.ToString();
            cc.ccom_qtydia = ccom_qtydia.ToString();
            cc.ccom_qtyveh = ccom_qtyveh.ToString();
            cc.ccom_qtranseqt = ccom_qtranseqt.ToString();
            cc.ccom_qtranseqa = ccom_qtranseqa.ToString();
            cc.ccom_fondor = ccom_fondor.ToString();
            cc.ccom_qgasrepr = ccom_qgasrepr.ToString();
            cc.ccom_qtycommes = ccom_qtycommes.ToString();

            return cc;
        }
    }
}
