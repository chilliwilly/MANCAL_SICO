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
        String un = "CAL";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtFecha.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                this.txtValidezOferta.Text = DateTime.Now.Date.AddDays(30).ToString("dd/MM/yyyy");
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

        protected void cboPlazoEntrega_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsTipoPlazoEn())
            {
                cboPlazoEntrega.Items.Add(new ListItem(f.nom_plazoentrega, f.idn_plazoentrega));
            }
        }

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

        #endregion

        protected void gvListaCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String cli_nom = Request.Cookies["nomclient"].Value ?? null;
            String cli_cta = Request.Cookies["nomcuenta"].Value ?? null;
            String cli_cont = Request.Cookies["nomcontact"].Value ?? null;
            String cli_tipo = Request.Cookies["nomtipo"].Value ?? null;
            String cli_estado = Request.Cookies["nomestado"].Value ?? null;

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

        public void mostrarCliente(String clinom, String clicta, String nomcont, String clitipo, String cliestado)
        {
            objCliente = new bl_cliente();
            gvListaCliente.DataSource = objCliente.getListaCliente(clinom, clicta, nomcont, clitipo, cliestado);
            gvListaCliente.DataBind();
        }

        protected void btnUpdLsCliente_Click(object sender, EventArgs e)
        {
            String cli_nom = Request.Cookies["nomclient"].Value ?? null;
            String cli_cta = Request.Cookies["nomcuenta"].Value ?? null;
            String cli_cont = Request.Cookies["nomcontact"].Value ?? null;
            String cli_tipo = Request.Cookies["nomtipo"].Value ?? null;
            String cli_estado = Request.Cookies["nomestado"].Value ?? null;

            mostrarCliente(cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado);
            upListaCliente.Update();
        }

        private void getListArchivo(String idu)
        {
            objAdj = new bl_adjunto();
            gvArchivo.DataSource = objAdj.getAdjunto(idu);
            gvArchivo.DataBind();
        }
    }
}