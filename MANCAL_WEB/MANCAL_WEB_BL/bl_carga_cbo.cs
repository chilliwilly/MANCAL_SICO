using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_BL.ManCal_Cbo;
using MANCAL_WEB_CLASS;

namespace MANCAL_WEB_BL
{
    public class bl_carga_cbo
    {
        ServiceClient combo = new ServiceClient();

        public List<CotizacionTipo> lsTipoCotizacion(String un_id) 
        {
            var ls = combo.lsTipoCotizacionMan(un_id);
            List<CotizacionTipo> lstc = new List<CotizacionTipo>();

            lstc.Add(new CotizacionTipo("0", "Seleccione"));

            foreach (TipoCotizacion tc in ls) 
            {
                CotizacionTipo ct = new CotizacionTipo();
                if (un_id.Equals("PRO"))
                {       
                    if (tc.id_tipocot >= 3)
                    {
                        ct.idtipocot = tc.id_tipocot.ToString();
                        ct.nomtipocot = tc.nom_tipocot;
                        lstc.Add(ct);
                    }
                }
                else 
                {
                    ct.idtipocot = tc.id_tipocot.ToString();
                    ct.nomtipocot = tc.nom_tipocot;
                    lstc.Add(ct);
                }
            }
            return lstc;
        }

        public List<CotizacionVendedor> lsVendedorCot(String un_id) 
        {
            List<CotizacionVendedor> lscv = new List<CotizacionVendedor>();
            var ls = combo.lsVendedor(un_id);

            lscv.Add(new CotizacionVendedor("0", "Seleccione"));

            foreach (Vendedor v in ls) 
            {
                CotizacionVendedor cv = new CotizacionVendedor();
                cv.id_ven = v.id_venta.ToString();
                cv.id_nom = v.nom_venta;
                lscv.Add(cv);
            }

            return lscv;
        }

        public List<CotizacionTarifa> lsTarifaTipo() 
        {
            List<CotizacionTarifa> lstt = new List<CotizacionTarifa>();
            var ls = combo.lsTarifa();

            lstt.Add(new CotizacionTarifa("0", "Seleccione"));

            foreach (TipoTarifa tt in ls) 
            {
                CotizacionTarifa ct = new CotizacionTarifa();
                ct.tt_idn = tt.id_tarifa.ToString();
                ct.tt_nom = tt.nom_tarifa;
                lstt.Add(ct);
            }
            return lstt;            
        }

        public List<CotizacionTrabajo> lsTrabajoTipo(String un, String fr) 
        {
            List<CotizacionTrabajo> lsttr = new List<CotizacionTrabajo>();
            var ls = combo.lsTrabajo(un, fr);

            lsttr.Add(new CotizacionTrabajo("0", "Seleccione"));

            foreach (TipoTrabajo ttr in ls) 
            {
                CotizacionTrabajo ct = new CotizacionTrabajo();
                ct.idn_ttrabajo = ttr.idn_trabajo.ToString();
                ct.nom_ttrabajo = ttr.nom_trabajo;
                lsttr.Add(ct);
            }
            return lsttr;
        }

        public List<CotizacionTFactura> lsTipoFactura() 
        {
            List<CotizacionTFactura> lstf = new List<CotizacionTFactura>();
            var ls = combo.lsFactura();

            lstf.Add(new CotizacionTFactura("0", "Seleccione"));

            foreach (TipoFactura tf in ls) 
            {
                CotizacionTFactura ctf = new CotizacionTFactura();
                ctf.idn_factura = tf.idn_factura.ToString();
                ctf.nom_factura = tf.nom_factura;
                lstf.Add(ctf);
            }
            return lstf;
        }

        public List<CotizacionTPFactura> lsTipoPagoFactura()
        {
            List<CotizacionTPFactura> lstpf = new List<CotizacionTPFactura>();
            var ls = combo.lsPagoFactura();

            lstpf.Add(new CotizacionTPFactura("0", "Seleccione"));

            foreach (TipoPagoFactura tf in ls)
            {
                CotizacionTPFactura ctpf = new CotizacionTPFactura();
                ctpf.idn_pagofactura = tf.idn_pagofactura.ToString();
                ctpf.nom_pagofactura = tf.nom_pagofactura;
                lstpf.Add(ctpf);
            }
            return lstpf;
        }

        public List<CotizacionTPEntrega> lsTipoPlazoEn()
        {
            List<CotizacionTPEntrega> lstpe = new List<CotizacionTPEntrega>();
            var ls = combo.lsPlazoEntregaFac();

            lstpe.Add(new CotizacionTPEntrega("0", "Seleccione"));

            foreach (TipoPlazoEntregaFac tf in ls)
            {
                CotizacionTPEntrega ctpe = new CotizacionTPEntrega();
                ctpe.idn_plazoentrega = tf.idn_plazoentregafac.ToString();
                ctpe.nom_plazoentrega = tf.nom_plazoentregafac;
                lstpe.Add(ctpe);
            }
            return lstpe;
        }

        public List<CotizacionLugarEjec> lsLugarEjec() 
        {
            List<CotizacionLugarEjec> ls = new List<CotizacionLugarEjec>();
            var serls = combo.lsLugarEjec();

            ls.Add(new CotizacionLugarEjec("0", "Seleccione"));

            foreach (TipoLugarEjec obj in serls) 
            {
                CotizacionLugarEjec cle = new CotizacionLugarEjec();
                cle.le_idn = obj.idn_lugarejec.ToString();
                cle.le_nom = obj.nom_lugarejec;
                ls.Add(cle);
            }
            return ls;
        }

        public List<CotizacionLugarEntr> lsLugarEntr() 
        {
            List<CotizacionLugarEntr> ls = new List<CotizacionLugarEntr>();
            var serls = combo.lsLugarEntr();

            ls.Add(new CotizacionLugarEntr("0", "Seleccione"));

            foreach (TipoLugarEntr obj in serls) 
            {
                CotizacionLugarEntr clen = new CotizacionLugarEntr();
                clen.len_idn = obj.idn_lugarentr.ToString();
                clen.len_nom = obj.nom_lugarentr;
                ls.Add(clen);
            }
            return ls;
        }

        public List<CotizacionGarantia> lsGarantia() 
        {
            List<CotizacionGarantia> lsg = new List<CotizacionGarantia>();
            var serls = combo.lsGarantia();

            lsg.Add(new CotizacionGarantia("0", "Seleccione"));

            foreach (TipoGarantia obj in serls) 
            {
                CotizacionGarantia cg = new CotizacionGarantia();
                cg.g_idn = obj.idn_garantia.ToString();
                cg.g_nom = obj.nom_garantia;
                lsg.Add(cg);
            }
            return lsg;
        }

        public List<CotizacionGarantiaVal> lsGarantiaVal() 
        {
            List<CotizacionGarantiaVal> lsgv = new List<CotizacionGarantiaVal>();
            var serls = combo.lsGarantiaVal();

            lsgv.Add(new CotizacionGarantiaVal("0", "Seleccione"));

            foreach (TipoGarantiaVal obj in serls) 
            {
                CotizacionGarantiaVal cgv = new CotizacionGarantiaVal();
                cgv.gv_idn = obj.idn_garantiaval.ToString();
                cgv.gv_nom = obj.nom_garantiaval;
                lsgv.Add(cgv);
            }

            return lsgv;
        }

        public List<CotizacionJefe> lsJefe() 
        {
            List<CotizacionJefe> lsj = new List<CotizacionJefe>();
            var serls = combo.lsJefe();

            lsj.Add(new CotizacionJefe("0", "Seleccione"));

            foreach (Jefe obj in serls) 
            {
                CotizacionJefe cj = new CotizacionJefe();
                cj.jef_idn = obj.idn_jefe.ToString();
                cj.jef_nom = obj.nom_jefe;
                lsj.Add(cj);
            }
            return lsj;
        }

        public List<CotizacionLugarCom> lsLugarCom() 
        {
            List<CotizacionLugarCom> lslc = new List<CotizacionLugarCom>();
            var serls = combo.lsLugar();

            lslc.Add(new CotizacionLugarCom("0", "Seleccione"));

            foreach (Lugar l in serls) 
            {
                CotizacionLugarCom clc = new CotizacionLugarCom();
                clc.lugar_idn = l.idn_lugar.ToString();
                clc.lugar_nom = l.nom_lugar;
                lslc.Add(clc);
            }
            return lslc;
        }

        public List<CotizacionRegion> lsRegion() 
        {
            List<CotizacionRegion> lsr = new List<CotizacionRegion>();
            var serls = combo.lsRegion();

            lsr.Add(new CotizacionRegion("0", "Seleccione"));

            foreach (Region r in serls) 
            {
                CotizacionRegion cr = new CotizacionRegion();
                cr.region_idn = r.idn_region.ToString();
                cr.region_nom = r.nom_region;
                lsr.Add(cr);
            }
            return lsr;
        }

        public List<CotizacionEnvio> lsEnvio() 
        {
            List<CotizacionEnvio> lse = new List<CotizacionEnvio>();
            var serls = combo.lsEnvio();

            lse.Add(new CotizacionEnvio("0", "Seleccione"));

            foreach (TipoEnvio te in serls) 
            {
                CotizacionEnvio ce = new CotizacionEnvio();
                ce.envio_idn = te.idn_tipoenvio.ToString();
                ce.envio_nom = te.nom_tipoenvio;
                lse.Add(ce);
            }
            return lse;
        }

        public CotizacionJefe datoJefe(String id_jef) 
        {
            CotizacionJefe cj = new CotizacionJefe();
            var serls = combo.datosJefe(Convert.ToDecimal(id_jef));

            cj.jef_car = serls.car_jefe;
            cj.jef_mai = serls.mai_jefe;

            return cj;
        }
    }
}
