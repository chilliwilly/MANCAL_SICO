using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_carga_cbo
    {
        dl_carga_cbo objCbo;

        public List<CotizacionTipo> lsTipoCotizacion(String un_id) 
        {
            List<CotizacionTipo> lstc = new List<CotizacionTipo>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTipoCotizacion();

            lstc.Add(new CotizacionTipo("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionTipo ct = new CotizacionTipo();
                if (dr["TC_UN_ID"].ToString().Equals(un_id) || dr["TC_UN_ID"].ToString().Equals("DUO")) 
                {
                    if (un_id.Equals("PRO"))
                    {
                        if (Convert.ToInt32(dr["TC_ID"]) >= 3)
                        {
                            ct.idtipocot = dr["TC_ID"].ToString();
                            ct.nomtipocot = dr["TC_NOMBRE"].ToString();
                            lstc.Add(ct);
                        }
                    }
                    else
                    {
                        ct.idtipocot = dr["TC_ID"].ToString();
                        ct.nomtipocot = dr["TC_NOMBRE"].ToString();
                        lstc.Add(ct);
                    }
                }
            }
            return lstc;
        }

        public List<CotizacionVendedor> lsVendedorCot(String un_id) 
        {
            List<CotizacionVendedor> lscv = new List<CotizacionVendedor>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectVendedor();

            lscv.Add(new CotizacionVendedor("0", "Seleccione"));
            
            foreach (DataRow dr in dt.Rows) 
            {
                if (dr["VEN_UN_ID"].ToString().Equals(un_id) || dr["VEN_UN_ID"].ToString().Equals("DUO")) 
                {
                    CotizacionVendedor cv = new CotizacionVendedor();
                    cv.id_ven = dr["VEN_ID"].ToString();
                    cv.id_nom = dr["USR_NOMBRE"].ToString() + " " + dr["USR_APPAT"].ToString();
                    lscv.Add(cv);
                }
            }

            return lscv;
        }

        public List<CotizacionTarifa> lsTarifaTipo() 
        {
            List<CotizacionTarifa> lstt = new List<CotizacionTarifa>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTarifa();

            lstt.Add(new CotizacionTarifa("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionTarifa ct = new CotizacionTarifa();
                ct.tt_idn = dr["TT_ID"].ToString();
                ct.tt_nom = dr["TT_NOMBRE"].ToString();
                lstt.Add(ct);
            }
            return lstt;            
        }

        public List<CotizacionTrabajo> lsTrabajoTipo(String un, String fr) 
        {
            List<CotizacionTrabajo> lsttr = new List<CotizacionTrabajo>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTrabajo();

            lsttr.Add(new CotizacionTrabajo("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TTR_UN_ID"].ToString().Equals(un) && dr["TTR_FORMATO"].ToString().Equals(fr)) 
                {
                    CotizacionTrabajo ct = new CotizacionTrabajo();
                    ct.idn_ttrabajo = dr["TTR_ID"].ToString();
                    ct.nom_ttrabajo = dr["TTR_NOMBRE"].ToString();
                    lsttr.Add(ct);
                }
            }
            return lsttr;
        }

        public List<CotizacionTFactura> lsTipoFactura() 
        {
            List<CotizacionTFactura> lstf = new List<CotizacionTFactura>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectFactura();

            lstf.Add(new CotizacionTFactura("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionTFactura ctf = new CotizacionTFactura();
                ctf.idn_factura = dr["TF_ID"].ToString();
                ctf.nom_factura = dr["TF_NOMBRE"].ToString();
                lstf.Add(ctf);
            }
            return lstf;
        }

        public List<CotizacionTPFactura> lsTipoPagoFactura()
        {
            List<CotizacionTPFactura> lstpf = new List<CotizacionTPFactura>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectPagoFactura();

            lstpf.Add(new CotizacionTPFactura("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionTPFactura ctpf = new CotizacionTPFactura();
                ctpf.idn_pagofactura = dr["TFPF_ID"].ToString();
                ctpf.nom_pagofactura = dr["TFPF_NOMBRE"].ToString();
                lstpf.Add(ctpf);
            }
            return lstpf;
        }

        public List<CotizacionTPEntrega> lsTipoPlazoEn()
        {
            List<CotizacionTPEntrega> lstpe = new List<CotizacionTPEntrega>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectPlazoEntrega();

            lstpe.Add(new CotizacionTPEntrega("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionTPEntrega ctpe = new CotizacionTPEntrega();
                ctpe.idn_plazoentrega = dr["TPE_ID"].ToString();
                ctpe.nom_plazoentrega = dr["TPE_NOMBRE"].ToString();
                lstpe.Add(ctpe);
            }
            return lstpe;
        }

        public List<CotizacionLugarEjec> lsLugarEjec() 
        {
            List<CotizacionLugarEjec> ls = new List<CotizacionLugarEjec>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectLugarEjec();

            ls.Add(new CotizacionLugarEjec("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionLugarEjec cle = new CotizacionLugarEjec();
                cle.le_idn = dr["TLEJ_ID"].ToString();
                cle.le_nom = dr["TLEJ_NOMBRE"].ToString();
                ls.Add(cle);
            }
            return ls;
        }

        public List<CotizacionLugarEntr> lsLugarEntr() 
        {
            List<CotizacionLugarEntr> ls = new List<CotizacionLugarEntr>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectLugarEntr();

            ls.Add(new CotizacionLugarEntr("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionLugarEntr clen = new CotizacionLugarEntr();
                clen.len_idn = dr["TLE_ID"].ToString();
                clen.len_nom = dr["TLE_NOMBRE"].ToString();
                ls.Add(clen);
            }
            return ls;
        }

        public List<CotizacionGarantia> lsGarantia() 
        {
            List<CotizacionGarantia> lsg = new List<CotizacionGarantia>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectGarantia();

            lsg.Add(new CotizacionGarantia("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionGarantia cg = new CotizacionGarantia();
                cg.g_idn = dr["TG_ID"].ToString();
                cg.g_nom = dr["TG_NOMBRE"].ToString();
                lsg.Add(cg);
            }
            return lsg;
        }

        public List<CotizacionGarantiaVal> lsGarantiaVal() 
        {
            List<CotizacionGarantiaVal> lsgv = new List<CotizacionGarantiaVal>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectGarantiaVal();

            lsgv.Add(new CotizacionGarantiaVal("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionGarantiaVal cgv = new CotizacionGarantiaVal();
                cgv.gv_idn = dr["TVG_ID"].ToString();
                cgv.gv_nom = dr["TVG_NOMBRE"].ToString();
                lsgv.Add(cgv);
            }

            return lsgv;
        }

        public List<CotizacionJefe> lsJefe() 
        {
            List<CotizacionJefe> lsj = new List<CotizacionJefe>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectJefe();

            lsj.Add(new CotizacionJefe("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionJefe cj = new CotizacionJefe();
                cj.jef_idn = dr["JEF_ID"].ToString();
                cj.jef_nom = dr["USR_NOMBRE"].ToString() + " " + dr["USR_APPAT"].ToString();
                lsj.Add(cj);
            }
            return lsj;
        }

        public List<CotizacionLugarCom> lsLugarCom() 
        {
            List<CotizacionLugarCom> lslc = new List<CotizacionLugarCom>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectLugar();

            lslc.Add(new CotizacionLugarCom("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionLugarCom clc = new CotizacionLugarCom();
                clc.lugar_idn = dr["LUG_ID"].ToString();
                clc.lugar_nom = dr["LUG_NOMBRE"].ToString();
                lslc.Add(clc);
            }
            return lslc;
        }

        public List<CotizacionRegion> lsRegion() 
        {
            List<CotizacionRegion> lsr = new List<CotizacionRegion>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectRegion();

            lsr.Add(new CotizacionRegion("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionRegion cr = new CotizacionRegion();
                cr.region_idn = dr["REG_ID"].ToString();
                cr.region_nom = dr["REG_NOMBRE"].ToString();
                lsr.Add(cr);
            }
            return lsr;
        }

        public List<CotizacionEnvio> lsEnvio() 
        {
            List<CotizacionEnvio> lse = new List<CotizacionEnvio>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectEnvio();

            lse.Add(new CotizacionEnvio("0", "Seleccione"));

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionEnvio ce = new CotizacionEnvio();
                ce.envio_idn = dr["TEN_ID"].ToString();
                ce.envio_nom = dr["TEN_NOMBRE"].ToString();
                lse.Add(ce);
            }
            return lse;
        }

        public CotizacionJefe datoJefe(String id_jef) 
        {
            CotizacionJefe cj = new CotizacionJefe();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectDatoJefe();

            foreach (DataRow dr in dt.Rows) 
            {
                if (dr["JEF_ID"].ToString().Equals(id_jef)) 
                {
                    cj.jef_car = dr["JEF_AREA"].ToString();
                    cj.jef_mai = dr["USR_USRPC"].ToString() + "@dts.cl";
                    break;
                }
            }
            return cj;
        }

        public List<CotizacionTextoFactura> getTextFac() 
        {
            List<CotizacionTextoFactura> cot = new List<CotizacionTextoFactura>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTextFactura();

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionTextoFactura c = new CotizacionTextoFactura();
                c.idntxtfac = dr["TXTF_ID"].ToString();
                c.nomtxtfac = dr["TXTF_DESCRIP"].ToString();

                cot.Add(c);
            }
            return cot;
        }

        public List<CotizacionTextoFactura> getTextPen() 
        {
            List<CotizacionTextoFactura> cot = new List<CotizacionTextoFactura>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTextPentrega();

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionTextoFactura c = new CotizacionTextoFactura();
                c.idntxtfac = dr["TXTPE_ID"].ToString();
                c.nomtxtfac = dr["TXTPE_DESCRIP"].ToString();

                cot.Add(c);
            }
            return cot;
        }

        public List<CotizacionEstadoCliente> getEstadoCliente() 
        {
            List<CotizacionEstadoCliente> ls = new List<CotizacionEstadoCliente>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTextEstadoCliente();

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionEstadoCliente cli = new CotizacionEstadoCliente();
                cli.idestadocli = dr["ESTCLI_ID"].ToString();
                cli.nomestadocli = dr["ESTCLI_NOMBRE"].ToString();

                ls.Add(cli);
            }
            return ls;
        }

        public List<CotizacionTipoCliente> getTipoCliente() 
        {
            List<CotizacionTipoCliente> ls = new List<CotizacionTipoCliente>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectTextTipoCliente();

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionTipoCliente cot = new CotizacionTipoCliente();
                cot.idtipocli = dr["TIPOCLI_ID"].ToString();
                cot.nomtipocli = dr["TIPOCLI_NOMBRE"].ToString();

                ls.Add(cot);
            }
            return ls;
        }

        public List<CotizacionEstadoDet> getEstadoDet() 
        {
            List<CotizacionEstadoDet> ls = new List<CotizacionEstadoDet>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectEstadoDetCot();            

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionEstadoDet cot = new CotizacionEstadoDet();
                cot.idestadodet = dr["DCE_ID"].ToString();
                cot.nomestadodet = dr["DCE_NOMBRE"].ToString();
                
                ls.Add(cot);
            }
            return ls;
        }

        public List<CotizacionLineaProd> getLineaProd() 
        {
            List<CotizacionLineaProd> ls = new List<CotizacionLineaProd>();
            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectLineaProd();

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionLineaProd clp = new CotizacionLineaProd();
                clp.idnlineaprod = dr["LP_ID"].ToString();
                clp.nomlineaprod = dr["LP_NOMBRE"].ToString();

                ls.Add(clp);
            }
            return ls;
        }

        public List<CotizacionMagnitud> getMagnitud(String codsys) 
        {
            List<CotizacionMagnitud> ls = new List<CotizacionMagnitud>();
            objCbo = new dl_carga_cbo();

            int cod = Convert.ToInt32(codsys);
            DataTable dt = objCbo.selectMagnitud(cod);

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionMagnitud cm = new CotizacionMagnitud();
                cm.idnmagnitud = dr["ID_ESPECIALIDAD"].ToString();
                cm.nommagnitud = dr["NOMBRE"].ToString();

                ls.Add(cm);
            }

            return ls;
        }

        public List<CotizacionMagnitudFuncion> getMagFunc(String magid, String sysid) 
        {
            List<CotizacionMagnitudFuncion> ls = new List<CotizacionMagnitudFuncion>();
            int mag_id = Convert.ToInt32(magid);
            int sys_id = Convert.ToInt32(sysid);

            objCbo = new dl_carga_cbo();

            DataTable dt = objCbo.selectFuncionMagnitud(mag_id, sys_id);            

            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionMagnitudFuncion cmf = new CotizacionMagnitudFuncion();
                cmf.idnmagfunc = dr["ID_FUNCION"].ToString();
                cmf.nommagfunc = dr["NOMBRE_FUNCION"].ToString();

                ls.Add(cmf);
            }

            return ls;
        }

        public String getMailVendedor(String idvendedor) 
        {
            objCbo = new dl_carga_cbo();
            int idv = Convert.ToInt32(idvendedor);
            return objCbo.selectMailVendedor(idv);
        }
    }
}
