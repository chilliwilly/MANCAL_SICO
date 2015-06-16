using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;
using MANCAL_WEB_CLASS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace MANCAL_WEB.frm_cal
{
    public partial class cal_cot_new : System.Web.UI.Page
    {
        bl_carga_cbo objCbo;
        bl_adjunto objAdj;
        bl_cliente objCliente;
        bl_detalle_pro objDet;
        String un = "CAL";
        String cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado;
        String eq_nombre, eq_modelo, eq_nparte;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtFecha.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                this.txtValidezOferta.Text = DateTime.Now.Date.AddDays(30).ToString("dd/MM/yyyy");
                Response.Cookies["pcusr"].Value = System.Environment.UserName;
                Response.Cookies["pcusr"].Expires = DateTime.Now.AddMinutes(60);
                Session["pag_num"] = "1";
            }
        }

        #region Pre Carga de Combos

        protected void cboTipoCotizacion_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();
            String forma = "DUO";

            foreach (var ct in objCbo.lsTipoCotizacion(forma))
            {
                cboTipoCotizacion.Items.Add(new ListItem(ct.nomtipocot, ct.idtipocot));
            }
        }

        protected void cboVendedor_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var cv in objCbo.lsVendedorCot(un))
            {
                cboVendedor.Items.Add(new ListItem(cv.id_nom, cv.id_ven));
            }
        }

        protected void cboTipoTarifa_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var ct in objCbo.lsTarifaTipo())
            {
                cboTipoTarifa.Items.Add(new ListItem(ct.tt_nom, ct.tt_idn));
            }
        }

        protected void cbo_eq_read_trabajo_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            foreach (var cj in objCbo.lsTrabajoTipo(un, "COT")) 
            {
                cbo_eq_read_trabajo.Items.Add(new ListItem(cj.nom_ttrabajo, cj.idn_ttrabajo));                
            }
        }

        protected void cbo_eq_dato_cal_tt_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var cj in objCbo.lsTrabajoTipo(un, "COT"))
            {
                cbo_eq_dato_cal_tt.Items.Add(new ListItem(cj.nom_ttrabajo, cj.idn_ttrabajo));
            }
        }

        protected void cbo_eq_read_lprod_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            cbo_eq_read_lprod.Items.Add(new ListItem("Seleccione", "N"));

            foreach (var clp in objCbo.getLineaProd()) 
            {
                cbo_eq_read_lprod.Items.Add(new ListItem(clp.nomlineaprod, clp.idnlineaprod));                
            }
        }

        protected void cbo_eq_dato_cal_lp_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            cbo_eq_dato_cal_lp.Items.Add(new ListItem("Seleccione", "N"));

            foreach (var clp in objCbo.getLineaProd()) 
            {
                cbo_eq_dato_cal_lp.Items.Add(new ListItem(clp.nomlineaprod, clp.idnlineaprod));
            }
        }

        protected void cbo_eq_read_estado_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            cbo_eq_read_estado.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var ce in objCbo.getEstadoDet()) 
            {
                cbo_eq_read_estado.Items.Add(new ListItem(ce.nomestadodet, ce.idestadodet));                
            }
        }

        protected void cbo_eq_dato_cal_est_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            cbo_eq_dato_cal_est.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var ce in objCbo.getEstadoDet())
            {
                cbo_eq_dato_cal_est.Items.Add(new ListItem(ce.nomestadodet, ce.idestadodet));
            }
        }

        protected void cboFacturacion_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsTipoFactura())
            {
                cboFacturacion.Items.Add(new ListItem(f.nom_factura, f.idn_factura));
            }
        }

        protected void cboFormaPago_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsTipoPagoFactura())
            {
                cboFormaPago.Items.Add(new ListItem(f.nom_pagofactura, f.idn_pagofactura));
            }
        }

        //protected void cboPlazoEntrega_Init(object sender, EventArgs e)
        //{
        //    objCbo = new bl_carga_cbo();

        //    foreach (var f in objCbo.lsTipoPlazoEn())
        //    {
        //        cboPlazoEntrega.Items.Add(new ListItem(f.nom_plazoentrega, f.idn_plazoentrega));
        //    }
        //}

        protected void cboEjecTrab_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsLugarEjec())
            {
                cboEjecTrab.Items.Add(new ListItem(f.le_nom, f.le_idn));
            }
        }

        protected void cboLugarEntrega_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsLugarEntr())
            {
                cboLugarEntrega.Items.Add(new ListItem(f.len_nom, f.len_idn));
            }
        }

        protected void cboGarantia_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsGarantia())
            {
                cboGarantia.Items.Add(new ListItem(f.g_nom, f.g_idn));
            }
        }

        protected void cboValidezGar_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsGarantiaVal())
            {
                cboValidezGar.Items.Add(new ListItem(f.gv_nom, f.gv_idn));
            }
        }

        protected void cboJefe_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsJefe())
            {
                cboJefe.Items.Add(new ListItem(f.jef_nom, f.jef_idn));
            }
        }

        protected void rblComentarioFac_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var rad in objCbo.getTextFac())
            {
                rblComentarioFac.Items.Add(new ListItem(rad.nomtxtfac, rad.nomtxtfac));
            }
        }

        protected void rblComentarioPen_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var rad in objCbo.getTextPen())
            {
                rblComentarioPen.Items.Add(new ListItem(rad.nomtxtfac, rad.nomtxtfac));
            }
        }

        protected void rblTipoCliente_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var rad in objCbo.getTipoCliente())
            {
                rblTipoCliente.Items.Add(new ListItem(rad.nomtipocli, rad.idtipocli));
            }
        }

        protected void rblEstadoCliente_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var rad in objCbo.getEstadoCliente())
            {
                rblEstadoCliente.Items.Add(new ListItem(rad.nomestadocli, rad.idestadocli));
            }
        }

        protected void cboRegion_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            foreach (var cbo in objCbo.lsRegion()) 
            {
                cboRegion.Items.Add(new ListItem(cbo.region_nom, cbo.region_idn));
            }
        }

        protected void cboTraslado_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            foreach (var cbo in objCbo.lsEnvio()) 
            {
                cboTraslado.Items.Add(new ListItem(cbo.envio_nom, cbo.envio_idn));
            }
        }

        protected void cboLugarComision_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            foreach (var cbo in objCbo.lsLugarCom()) 
            {
                cboLugarComision.Items.Add(new ListItem(cbo.lugar_nom, cbo.lugar_idn));
            }
        }

        protected void cbo_punto_magnitud_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();
            String cod = "2";

            cbo_magnitud.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var cbo in objCbo.getMagnitud(cod)) 
            {
                cbo_magnitud.Items.Add(new ListItem(cbo.nommagnitud, cbo.idnmagnitud));
            }
        }

        protected void cboLugarRetiro_Init(object sender, EventArgs e) 
        {
            cboLugarRetiro.Items.Add(new ListItem("Seleccione", "0"));
            cboLugarRetiro.Items.Add(new ListItem("Retira DTS", "1"));
            cboLugarRetiro.Items.Add(new ListItem("Envia Cliente", "2"));
            cboLugarRetiro.Items.Add(new ListItem("No Aplica", "3"));
        }

        #endregion

        #region Metodos Protected        

        protected void gvListaCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            setValueCliente();

            gvListaCliente.PageIndex = e.NewPageIndex;

            mostrarCliente(cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado);
        }

        protected void gvListaCliente_Init(object sender, EventArgs e)
        {
            mostrarCliente("", "", "", "", "");
        }

        protected void upListaCliente_Load(object sender, EventArgs e)
        {
            mostrarCliente("", "", "", "", "");
            upListaCliente.Update();
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            //objCalculo = new bl_calculo();
            //Cotizacion c = new Cotizacion();

            //c.cot_tipomoneda = cboTipoTarifa.SelectedValue;
            //c.cot_afecto = cboTipoImpuesto.SelectedValue;
            //c.tc_id = Convert.ToInt32(cboTipoCotizacion.SelectedValue);
            //c.cot_descuento = txtDcto.Text;
            //c.cot_id = System.Environment.UserName;
            //c.cot_fecha = txtFecha.Text;

            //c = objCalculo.getMargenTotal(c, "PRO");

            //txtTotalCostoMo.Text = c.cot_totcostmo;
            //txtTotalCostoRpto.Text = c.cot_totvalrpto;
            //txtMgOpPorc.Text = c.cot_mgopporc;
            //txtMgBrutoPorc.Text = c.cot_mgbrutoporc;
            //txtMgContribucion.Text = c.cot_mgcontrib;
            //txtMgContribucionPorc.Text = c.cot_mgcontribporc;
            //txtUtilidadEspPorc.Text = c.cot_utilesperaporc;
            //txtTipoMoneda.Text = c.cot_tipomoneda;

            //txtNeto.Text = c.cot_neto;
            //txtNetoDcto.Text = c.cot_netodcto;
            //txtIva.Text = c.cot_iva;
            //txtTotal.Text = c.cot_total;

            //panelCalculo.Update();

            //if (!String.IsNullOrEmpty(c.cot_msgautoriza))
            //{
            //    String msgautoriza = "alert(\"" + c.cot_msgautoriza + ".\");";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", msgautoriza, true);
            //}
        }

        protected void cboJefe_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();
            CotizacionJefe cj = objCbo.datoJefe(cboJefe.SelectedValue);

            txtCargoJefe.Text = cj.jef_car;
            txtMailJefe.Text = cj.jef_mai;
        }

        protected void GV1_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            String usr = System.Environment.UserName;

            GV1.PageIndex = e.NewPageIndex;
            getListaDetalle(usr, cboTipoTarifa.SelectedValue);
        }

        protected void gvArchivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String usr = System.Environment.UserName;

            gvArchivo.PageIndex = e.NewPageIndex;
            getListArchivo(usr);
        }

        protected void gvArchivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String usr = System.Environment.UserName;
            getListArchivo(usr);
        }

        protected void btnUpdateDoc_Click(object sender, EventArgs e)
        {
            getListArchivo(System.Environment.UserName);
            udpArchivo.Update();
        }

        protected void fuCalibracion_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            objAdj = new bl_adjunto();
            String adjunto = "";
            String usr = System.Environment.UserName;

            adjunto = objAdj.adjuntarDocumento(e.FileName, usr);
            fuCalibracion.SaveAs(Server.MapPath("~/adjunto_doc/") + adjunto);
        }

        #endregion
        
        public void mostrarCliente(String clinom, String clicta, String nomcont, String clitipo, String cliestado)
        {
            objCliente = new bl_cliente();
            gvListaCliente.DataSource = objCliente.getListaCliente(clinom, clicta, nomcont, clitipo, cliestado);
            gvListaCliente.DataBind();
        }

        protected void btnUpdLsCliente_Click(object sender, EventArgs e)
        {
            setValueCliente();
            mostrarCliente(cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado);
            upListaCliente.Update();
        }

        private void getListArchivo(String idu)
        {
            objAdj = new bl_adjunto();
            gvArchivo.DataSource = objAdj.getAdjunto(idu);
            gvArchivo.DataBind();
        }

        private void getListaEquipo(String nom, String np, String modelo) 
        {
            objDet = new bl_detalle_pro();
            String systemid = "2";
            gvEquipoBusca.DataSource = objDet.getEquipo(nom, np, modelo, systemid, cboTipoTarifa.SelectedValue, txtFecha.Text);
            gvEquipoBusca.DataBind();
        }

        protected void btnBuscarListaEquipo_Click(object sender, EventArgs e)
        {
            setValueEquipo();
            getListaEquipo(eq_nombre, eq_nparte, eq_modelo);
            upEquipoBusca.Update();
        }

        protected void btnUpdDatoEquipo_Click(object sender, EventArgs e) //
        {
            String usr = System.Environment.UserName;
            getListaDetalle(usr, cboTipoTarifa.SelectedValue);
            gvListaPunto.DataSource = null;
            gvListaPunto.DataBind();
            upListaPunto.Update();
            UpdatePanel5.Update();
        }

        public void setValueCliente() 
        {
            cli_nom = Request.Cookies["nomclient"].Value ?? null;
            cli_cta = Request.Cookies["nomcuenta"].Value ?? null;
            cli_cont = Request.Cookies["nomcontact"].Value ?? null;
            cli_tipo = Request.Cookies["nomtipo"].Value ?? null;
            cli_estado = Request.Cookies["nomestado"].Value ?? null;
        }

        public void setValueEquipo() 
        {
            eq_nombre = Request.Cookies["eqnombre"].Value ?? null;
            eq_modelo = Request.Cookies["eqmodelo"].Value ?? null;
            eq_nparte = Request.Cookies["eqnparte"].Value ?? null;
            //eq_nserie = Request.Cookies["eqnserie"].Value ?? null;
            //eq_codcli = Request.Cookies["eqcodcli"].Value ?? null;
        }

        protected void gvEquipoBusca_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            setValueEquipo();
            gvEquipoBusca.PageIndex = e.NewPageIndex;
            getListaEquipo(eq_nombre, eq_nparte, eq_modelo);
        }

        protected void gvListaPunto_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            gvListaPunto.PageIndex = e.NewPageIndex;
            getListaPunto();
        }

        public void getListaDetalle(String idcot, String idtarifa) 
        {
            objDet = new bl_detalle_pro();
            GV1.DataSource = objDet.getDetalleCot(idcot, idtarifa);
            GV1.DataBind();
        }

        public void getListaPunto() 
        {
            objDet = new bl_detalle_pro();
            String usr = System.Environment.UserName;
            String eqid = Request.Cookies["idequipocot"].Value ?? null;
            String dcc = Request.Cookies["iditemeq"].Value ?? null;
            String fl_inpunto = Request.Cookies["flag_inpunto"].Value;
            
            gvListaPunto.DataSource = objDet.getListaPuntoEquipo(usr, eqid, dcc);
            gvListaPunto.DataBind();

            if (fl_inpunto.Equals("1")) 
            {
                gvListaPunto.Columns[11].Visible = true;
                gvListaPunto.Columns[12].Visible = false;
            }
            else if (fl_inpunto.Equals("2")) 
            {
                gvListaPunto.Columns[11].Visible = false;
                gvListaPunto.Columns[12].Visible = true;
            }
        }

        protected void btnActualizaGVPunto_Click(object sender, EventArgs e) 
        {
            getListaPunto();
            upListaPunto.Update();
        }

        protected void CalendarExtender1_PreRender(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            DateTime sd = objCbo.getFechaDivisa().Min();
            DateTime ed = objCbo.getFechaDivisa().Max();

            CalendarExtender1.StartDate = sd;            
            CalendarExtender1.EndDate = ed;//.AddDays(1);
        }
    }
}