using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MANCAL_WEB_CLASS
{
    public class CotizacionEquipo : CotizacionEquipoCal
    {
        public String equipotarifaorig { get; set; }
        public String equipopmo { get; set; }
        public String equipocostorep { get; set; }
        public String equipocmo { get; set; }
        public String equipototal { get; set; }
        public String equiponparte { get; set; }
        public String equiponserie { get; set; }
        public String equipomodelo { get; set; }
        public String equipocondicion { get; set; }
        public String equiponombre { get; set; }
        public String equipocatfach { get; set; }
        public String equipocatotro { get; set; }
        public String equipopreciousd { get; set; }
        public String equipocostoclp { get; set; }
        public String equipocantidad { get; set; }      
        public String equipoid { get; set; }
        public String equipocotid { get; set; }
        public String equipoitem { get; set; }
        public String equipotrabajo { get; set; }
        public String equipotrabajoid { get; set; }
        public String equipofactordcto { get; set; }
        public String equipofactordctototal { get; set; }
        public String equipocargope { get; set; }
        public String equipototalcargope { get; set; }
        public String equipofabricante { get; set; }
        public String equipofamilia { get; set; }
        public String equipomagnitud { get; set; }

        public CotizacionEquipo() { }
        
        public static CotizacionEquipo objCotEq(Object eq)
        {
            CotizacionEquipo ce = new CotizacionEquipo();
            Dictionary<String, Object> d = (Dictionary<String, Object>)eq;

            Object equipotarifaorig = null;
            Object equipopmo = null;
            Object equipocostorep = null;
            Object equipocmo = null;
            Object equipototal = null;
            Object equiponparte = null;
            Object equiponserie = null;
            Object equipomodelo = null;
            Object equipocondicion = null;
            Object equiponombre = null;
            Object equipocatfach = null;
            Object equipocatotro = null;
            Object equipopreciousd = null;
            Object equipocostoclp = null;
            Object equipocalpeso = null;
            Object equipocantidad = null;
            Object equipocalgasto = null;
            Object equipocalpcarga = null;
            Object equipoid = null;
            Object equipocotid = null;
            Object equipoitem = null;

            d.TryGetValue("equipotarifaorig", out equipotarifaorig);
            d.TryGetValue("equipopmo", out equipopmo);
            d.TryGetValue("equipocostorep", out equipocostorep);
            d.TryGetValue("equipocmo", out equipocmo);
            d.TryGetValue("equipototal", out equipototal);
            d.TryGetValue("equiponparte", out equiponparte);
            d.TryGetValue("equiponserie", out equiponserie);
            d.TryGetValue("equipomodelo", out equipomodelo);
            d.TryGetValue("equipocondicion", out equipocondicion);
            d.TryGetValue("equiponombre", out equiponombre);
            d.TryGetValue("equipocatfach", out equipocatfach);
            d.TryGetValue("equipocatotro", out equipocatotro);
            d.TryGetValue("equipopreciousd", out equipopreciousd);
            d.TryGetValue("equipocostoclp", out equipocostoclp);
            d.TryGetValue("equipocalpeso", out equipocalpeso);
            d.TryGetValue("equipocantidad", out equipocantidad);
            d.TryGetValue("equipocalgasto", out equipocalgasto);
            d.TryGetValue("equipocalpcarga", out equipocalpcarga);
            d.TryGetValue("equipoid", out equipoid);
            d.TryGetValue("equipocotid", out equipocotid);
            d.TryGetValue("equipoitem", out equipoitem);

            ce.equipotarifaorig = equipotarifaorig.ToString();
            ce.equipopmo = equipopmo.ToString();
            ce.equipocostorep = equipocostorep.ToString();
            ce.equipocmo = equipocmo.ToString();
            ce.equipototal = equipototal.ToString();
            ce.equiponparte = equiponparte.ToString();
            ce.equiponserie = equiponserie.ToString();
            ce.equipomodelo = equipomodelo.ToString();
            ce.equipocondicion = equipocondicion.ToString();
            ce.equiponombre = equiponombre.ToString();
            ce.equipocatfach = equipocatfach.ToString();
            ce.equipocatotro = equipocatotro.ToString();
            ce.equipopreciousd = equipopreciousd.ToString();
            ce.equipocostoclp = equipocostoclp.ToString();
            ce.equipocalpeso = equipocalpeso.ToString();
            ce.equipocantidad = equipocantidad.ToString();
            ce.equipocalgasto = equipocalgasto.ToString();
            ce.equipocalpcarga = equipocalpcarga.ToString();
            ce.equipoid = equipoid.ToString();
            ce.equipocotid = equipocotid.ToString();
            ce.equipoitem = equipoitem.ToString();

            return ce;
        }

        //OBTENER OBJETO SOLO PARA ACTUALIZAR
        public static CotizacionEquipo objCalEqEd(Object obj) 
        {
            CotizacionEquipo ce = new CotizacionEquipo();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object equipopmo = null;
            Object equipototal = null;
            Object equiponparte = null;
            Object equiponserie = null;
            Object equipocantidad = null;
            Object equipocalgasto = null;
            Object equipocalpcarga = null;
            Object equipoitem = null;
            Object equipocotid = null;

            d.TryGetValue("equipopmo", out equipopmo);
            d.TryGetValue("equipototal", out equipototal);
            d.TryGetValue("equiponparte", out equiponparte);
            d.TryGetValue("equiponserie", out equiponserie);
            d.TryGetValue("equipocantidad", out equipocantidad);
            d.TryGetValue("equipocalgasto", out equipocalgasto);
            d.TryGetValue("equipocalpcarga", out equipocalpcarga);
            d.TryGetValue("equipoitem", out equipoitem);
            d.TryGetValue("equipocotid", out equipocotid);

            ce.equipopmo = equipopmo.ToString();
            ce.equipototal = equipototal.ToString();
            ce.equiponparte = equiponparte.ToString();
            ce.equiponserie = equiponserie.ToString();
            ce.equipocantidad = equipocantidad.ToString();
            ce.equipocalgasto = equipocalgasto.ToString();
            ce.equipocalpcarga = equipocalpcarga.ToString();
            ce.equipoitem = equipoitem.ToString();
            ce.equipocotid = equipocotid.ToString();

            return ce;
        }

        //OBTENER OBJETO EQUIPO SOLO PARA CALCULAR
        public static CotizacionEquipo objCalEq(Object obj)
        {
            CotizacionEquipo ce = new CotizacionEquipo();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object equipopmo = null;
            Object equipocantidad = null;
            Object equipocalgasto = null;
            Object equipocalpcarga = null;
            Object equipoid = null;

            d.TryGetValue("equipopmo", out equipopmo);
            d.TryGetValue("equipocantidad", out equipocantidad);
            d.TryGetValue("equipocalgasto", out equipocalgasto);
            d.TryGetValue("equipocalpcarga", out equipocalpcarga);
            d.TryGetValue("equipoid", out equipoid);

            ce.equipopmo = equipopmo.ToString();
            ce.equipocantidad = equipocantidad.ToString();
            ce.equipocalgasto = equipocalgasto.ToString();
            ce.equipocalpcarga = equipocalpcarga.ToString();
            ce.equipoid = equipoid.ToString();

            return ce;
        }

        //METODO OBJETO PARA GUARDAR EQUIPO SELECCIONADO
        public static CotizacionEquipo objCalEqGuarda(Object obj)
        {
            CotizacionEquipo ce = new CotizacionEquipo();
            Dictionary<String, Object> d = (Dictionary<String, Object>)obj;

            Object equipotarifaorig = null;
            Object equipopmo = null;
            Object equipocostorep = null;
            Object equipocmo = null;
            Object equipototal = null;
            Object equiponparte = null;
            Object equiponserie = null;
            Object equipomodelo = null;
            Object equiponombre = null;
            Object equipocalpeso = null;
            Object equipocantidad = null;
            Object equipocalgasto = null;
            Object equipocalpcarga = null;
            Object equipoid = null;
            Object equipocotid = null;
            Object equipocalnp = null;
            Object equipocaloc = null;
            Object equipocalsaot = null;
            Object equipolp_idn = null;
            Object equipodet_idn = null;
            Object equipotrabajo = null;

            d.TryGetValue("equipotarifaorig", out equipotarifaorig);
            d.TryGetValue("equipopmo", out equipopmo);
            d.TryGetValue("equipocostorep", out equipocostorep);
            d.TryGetValue("equipocmo", out equipocmo);
            d.TryGetValue("equipototal", out equipototal);
            d.TryGetValue("equiponparte", out equiponparte);
            d.TryGetValue("equiponserie", out equiponserie);
            d.TryGetValue("equipomodelo", out equipomodelo);
            d.TryGetValue("equiponombre", out equiponombre);
            d.TryGetValue("equipocalpeso", out equipocalpeso);
            d.TryGetValue("equipocantidad", out equipocantidad);
            d.TryGetValue("equipocalgasto", out equipocalgasto);
            d.TryGetValue("equipocalpcarga", out equipocalpcarga);
            d.TryGetValue("equipoid", out equipoid);
            d.TryGetValue("equipocotid", out equipocotid);
            d.TryGetValue("equipocalnp", out equipocalnp);
            d.TryGetValue("equipocaloc", out equipocaloc);
            d.TryGetValue("equipocalsaot", out equipocalsaot);
            d.TryGetValue("equipolp_idn", out equipolp_idn);
            d.TryGetValue("equipodet_idn", out equipodet_idn);
            d.TryGetValue("equipotrabajo", out equipotrabajo);

            ce.equipotarifaorig = equipotarifaorig.ToString();
            ce.equipopmo = equipopmo.ToString();
            ce.equipocostorep = equipocostorep.ToString();
            ce.equipocmo = equipocmo.ToString();
            ce.equipototal = equipototal.ToString();
            ce.equiponparte = equiponparte.ToString();
            ce.equiponserie = equiponserie.ToString();
            ce.equipomodelo = equipomodelo.ToString();
            ce.equiponombre = equiponombre.ToString();
            ce.equipocalpeso = equipocalpeso.ToString();
            ce.equipocantidad = equipocantidad.ToString();
            ce.equipocalgasto = equipocalgasto.ToString();
            ce.equipocalpcarga = equipocalpcarga.ToString();
            ce.equipoid = equipoid.ToString();
            ce.equipocotid = equipocotid.ToString();
            ce.equipocalnp = equipocalnp.ToString();
            ce.equipocaloc = equipocaloc.ToString();
            ce.equipocalsaot = equipocalsaot.ToString();
            ce.equipolp_idn = equipolp_idn.ToString();
            ce.equipodet_idn = equipodet_idn.ToString();
            ce.equipotrabajo = equipotrabajo.ToString();

            return ce;
        }
    }
}
