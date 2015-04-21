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

        //PARA INSERTAR
        public static CotizacionComision objCotiCom(Object obj) 
        {
            CotizacionComision cc = new CotizacionComision();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object ccom_qtypersona = null;
            Object ccom_qtydia = null;
            Object ccom_qtyveh = null;
            Object ccom_qtranseqt = null;
            Object ccom_qtranseqa = null;
            Object ccom_fondor = null;
            Object ccom_qgasrepr = null;
            Object ccom_qtycommes = null;
            Object ccom_transdts = null;
            Object ccom_transhotel = null;
            Object ccom_psjavionper = null;
            Object ccom_alqveh = null;
            Object ccom_transeqt = null;
            Object ccom_transeqa = null;
            Object ccom_viatico = null;
            Object ccom_hotel = null;
            Object ccom_frendir = null;
            Object ccom_gasrepr = null;
            Object ccom_totalcom = null;
            Object ccom_totalcommg = null;
            Object lug_id = null;

            d.TryGetValue("ccom_qtypersona", out ccom_qtypersona);
            d.TryGetValue("ccom_qtydia", out ccom_qtydia);
            d.TryGetValue("ccom_qtyveh", out ccom_qtyveh);
            d.TryGetValue("ccom_qtranseqt", out ccom_qtranseqt);
            d.TryGetValue("ccom_qtranseqa", out ccom_qtranseqa);
            d.TryGetValue("ccom_fondor", out ccom_fondor);
            d.TryGetValue("ccom_qgasrepr", out ccom_qgasrepr);
            d.TryGetValue("ccom_qtycommes", out ccom_qtycommes);
            d.TryGetValue("ccom_transdts", out ccom_transdts);
            d.TryGetValue("ccom_transhotel", out ccom_transhotel);
            d.TryGetValue("ccom_psjavionper", out ccom_psjavionper);
            d.TryGetValue("ccom_alqveh", out ccom_alqveh);
            d.TryGetValue("ccom_transeqt", out ccom_transeqt);
            d.TryGetValue("ccom_transeqa", out ccom_transeqa);
            d.TryGetValue("ccom_viatico", out ccom_viatico);
            d.TryGetValue("ccom_hotel", out ccom_hotel);
            d.TryGetValue("ccom_frendir", out ccom_frendir);
            d.TryGetValue("ccom_gasrepr", out ccom_gasrepr);
            d.TryGetValue("ccom_totalcom", out ccom_totalcom);
            d.TryGetValue("ccom_totalcommg", out ccom_totalcommg);
            d.TryGetValue("lug_id", out lug_id);

            cc.ccom_qtypersona = ccom_qtypersona.ToString();
            cc.ccom_qtydia = ccom_qtydia.ToString();
            cc.ccom_qtyveh = ccom_qtyveh.ToString();
            cc.ccom_qtranseqt = ccom_qtranseqt.ToString();
            cc.ccom_qtranseqa = ccom_qtranseqa.ToString();
            cc.ccom_fondor = ccom_fondor.ToString();
            cc.ccom_qgasrepr = ccom_qgasrepr.ToString();
            cc.ccom_qtycommes = ccom_qtycommes.ToString();
            cc.ccom_transdts = ccom_transdts.ToString();
            cc.ccom_transhotel = ccom_transhotel.ToString();
            cc.ccom_psjavionper = ccom_psjavionper.ToString();
            cc.ccom_alqveh = ccom_alqveh.ToString();
            cc.ccom_transeqt = ccom_transeqt.ToString();
            cc.ccom_transeqa = ccom_transeqa.ToString();
            cc.ccom_viatico = ccom_viatico.ToString();
            cc.ccom_hotel = ccom_hotel.ToString();
            cc.ccom_frendir = ccom_frendir.ToString();
            cc.ccom_gasrepr = ccom_gasrepr.ToString();
            cc.ccom_totalcom = ccom_totalcom.ToString();
            cc.ccom_totalcommg = ccom_totalcommg.ToString();
            cc.lug_id = lug_id.ToString();

            return cc;
        }
    }
}
