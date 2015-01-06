using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MANCAL_WCF_CBO
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                 ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ManCal_Cbo : IService
    {
        public List<TipoCotizacion> lsTipoCotizacionMan(String id_un)
        {
            List<TipoCotizacion> ls = new List<TipoCotizacion>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tc in db.TBL_TIPO_COTIZACION) 
                {
                    if (tc.TC_UN_ID.Equals(id_un) || tc.TC_UN_ID.Equals("DUO")) 
                    {
                        TipoCotizacion t_c = new TipoCotizacion();
                        t_c.id_tipocot = Convert.ToInt32(tc.TC_ID);
                        t_c.nom_tipocot = tc.TC_NOMBRE;
                        ls.Add(t_c);
                    }
                }
            }
            return ls;
        }


        public List<Vendedor> lsVendedor(String id_un)
        {
            List<Vendedor> ls = new List<Vendedor>();

            ModelManCalCbo.EntitiesManCalCbo db = new ModelManCalCbo.EntitiesManCalCbo();

            var infoVendedor = (from usr in db.TBL_USUARIO join ven in db.TBL_VENDEDOR on usr.USR_ID equals ven.USR_ID where ven.VEN_UN_ID == id_un || ven.VEN_UN_ID == "DUO" select new {
                ven.VEN_ID,
                usr.USR_NOMBRE,
                usr.USR_APPAT
            }).ToList();            

            foreach (var usrV in infoVendedor) 
            {
                Vendedor v = new Vendedor();
                v.id_venta = Convert.ToInt32(usrV.VEN_ID);
                v.nom_venta = usrV.USR_NOMBRE + " " + usrV.USR_APPAT;
                ls.Add(v);
            }
            return ls;
        }


        public List<TipoTarifa> lsTarifa()
        {
            List<TipoTarifa> lst = new List<TipoTarifa>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tt in db.TBL_TIPO_TARIFA.OrderBy(it => it.TT_ID)) 
                {
                    TipoTarifa ltt = new TipoTarifa();
                    ltt.id_tarifa = Convert.ToInt32(tt.TT_ID);
                    ltt.nom_tarifa = tt.TT_NOMBRE;
                    lst.Add(ltt);
                }
            }
            return lst;
        }

        public List<TipoTrabajo> lsTrabajo(string un, string forma)
        {
            List<TipoTrabajo> ls = new List<TipoTrabajo>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var t in db.TBL_TIPO_TRABAJO) 
                {
                    if (t.TTR_UN_ID.Equals(un) && t.TTR_FORMATO.Equals(forma)) 
                    {
                        TipoTrabajo ttr = new TipoTrabajo();
                        ttr.idn_trabajo = Convert.ToInt32(t.TTR_ID);
                        ttr.nom_trabajo = t.TTR_NOMBRE;
                        ls.Add(ttr);
                    }
                }
            }
            return ls;
        }


        public List<TipoFactura> lsFactura()
        {
            List<TipoFactura> ls = new List<TipoFactura>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tf in db.TBL_TIPO_FACTURACION) 
                {
                    TipoFactura ft = new TipoFactura();
                    ft.idn_factura = Convert.ToInt32(tf.TF_ID);
                    ft.nom_factura = tf.TF_NOMBRE;
                    ls.Add(ft);
                }
            }
            return ls;
        }

        public List<TipoPagoFactura> lsPagoFactura()
        {
            List<TipoPagoFactura> ls = new List<TipoPagoFactura>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo())
            {
                foreach (var tpf in db.TBL_TIPO_FPAGO_FACTURA)
                {
                    TipoPagoFactura fpt = new TipoPagoFactura();
                    fpt.idn_pagofactura = Convert.ToInt32(tpf.TFPF_ID);
                    fpt.nom_pagofactura = tpf.TFPF_NOMBRE;
                    ls.Add(fpt);
                }
            }
            return ls;
        }

        public List<TipoPlazoEntregaFac> lsPlazoEntregaFac()
        {
            List<TipoPlazoEntregaFac> ls = new List<TipoPlazoEntregaFac>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo())
            {
                foreach (var pe in db.TBL_TIPO_PLAZO_ENTREGA)
                {
                    TipoPlazoEntregaFac pet = new TipoPlazoEntregaFac();
                    pet.idn_plazoentregafac = Convert.ToInt32(pe.TPE_ID);
                    pet.nom_plazoentregafac = pe.TPE_NOMBRE;
                    ls.Add(pet);
                }
            }
            return ls;
        }


        public List<TipoLugarEjec> lsLugarEjec()
        {
            List<TipoLugarEjec> lsle = new List<TipoLugarEjec>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tle in db.TBL_TIPO_LUGAR_EJEC) 
                {
                    TipoLugarEjec obj = new TipoLugarEjec();
                    obj.idn_lugarejec = Convert.ToInt32(tle.TLEJ_ID);
                    obj.nom_lugarejec = tle.TLEJ_NOMBRE;
                    lsle.Add(obj);
                }
            }
            return lsle;
        }

        public List<TipoLugarEntr> lsLugarEntr()
        {
            List<TipoLugarEntr> lslen = new List<TipoLugarEntr>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tlen in db.TBL_TIPO_LUGAR_ENTREGA) 
                {
                    TipoLugarEntr obj = new TipoLugarEntr();
                    obj.idn_lugarentr = Convert.ToInt32(tlen.TLE_ID);
                    obj.nom_lugarentr = tlen.TLE_NOMBRE;
                    lslen.Add(obj);
                }
            }
            return lslen;
        }

        public List<TipoGarantia> lsGarantia()
        {
            List<TipoGarantia> lsg = new List<TipoGarantia>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tg in db.TBL_TIPO_GARANTIA) 
                {
                    TipoGarantia obj = new TipoGarantia();
                    obj.idn_garantia = Convert.ToInt32(tg.TG_ID);
                    obj.nom_garantia = tg.TG_NOMBRE;
                    lsg.Add(obj);
                }
            }
            return lsg;
        }

        public List<TipoGarantiaVal> lsGarantiaVal()
        {
            List<TipoGarantiaVal> lstvg = new List<TipoGarantiaVal>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tvg in db.TBL_TIPO_VALI_GARANTIA) 
                {
                    TipoGarantiaVal obj = new TipoGarantiaVal();
                    obj.idn_garantiaval = Convert.ToInt32(tvg.TVG_ID);
                    obj.nom_garantiaval = tvg.TVG_NOMBRE;
                    lstvg.Add(obj);
                }
            }
            return lstvg;
        }

        public List<Jefe> lsJefe()
        {
            List<Jefe> jefe = new List<Jefe>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo())
            {
                var infoJefe = (from usr in db.TBL_USUARIO
                                join jef in db.TBL_JEFE on usr.USR_ID equals jef.USR_ID
                                select new
                                {
                                    jef.JEF_ID,
                                    usr.USR_NOMBRE,
                                    usr.USR_APPAT,
                                    jef.JEF_AREA,
                                    usr.USR_USRPC
                                }).ToList();

                foreach (var j in infoJefe)
                {
                    Jefe obj = new Jefe();
                    obj.idn_jefe = Convert.ToInt32(j.JEF_ID);
                    obj.nom_jefe = j.USR_NOMBRE + " " + j.USR_APPAT;
                    obj.car_jefe = j.JEF_AREA;
                    obj.mai_jefe = j.USR_USRPC + "@dts.cl";
                    jefe.Add(obj);
                }
            }
            return jefe;
        }

        public Jefe datosJefe(Decimal id_jefe)
        {
            Jefe j = new Jefe();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                var jefeDato = (from usr in db.TBL_USUARIO
                               join jef in db.TBL_JEFE
                               on usr.USR_ID equals jef.USR_ID
                               where jef.JEF_ID == id_jefe
                               select new
                               {
                                   jef.JEF_AREA,
                                   usr.USR_USRPC
                               }).ToList();

                foreach (var jef in jefeDato) 
                {
                    j.car_jefe = jef.JEF_AREA;
                    j.mai_jefe = jef.USR_USRPC + "@dts.cl";
                }
            }
            return j;
        }

        public List<Region> lsRegion()
        {
            List<Region> lsr = new List<Region>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var tr in db.TBL_REGION) 
                {
                    Region r = new Region();
                    r.idn_region = Convert.ToInt32(tr.REG_ID);
                    r.nom_region = tr.REG_NOMBRE;
                    lsr.Add(r);
                }
            }
            return lsr;
        }

        public List<TipoEnvio> lsEnvio()
        {
            List<TipoEnvio> lste = new List<TipoEnvio>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var te in db.TBL_TIPO_ENVIO) 
                {
                    TipoEnvio ten = new TipoEnvio();
                    ten.idn_tipoenvio = Convert.ToInt32(te.TEN_ID);
                    ten.nom_tipoenvio = te.TEN_NOMBRE;
                    lste.Add(ten);
                }
            }
            return lste;
        }


        public List<Lugar> lsLugar()
        {
            List<Lugar> lsl = new List<Lugar>();

            using (var db = new ModelManCalCbo.EntitiesManCalCbo()) 
            {
                foreach (var l in db.TBL_LUGAR) 
                {
                    Lugar lu = new Lugar();
                    lu.idn_lugar = Convert.ToInt32(l.LUG_ID);
                    lu.nom_lugar = l.LUG_NOMBRE;
                    lsl.Add(lu);
                }
            }
            return lsl;
        }
    }
}