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

namespace MANCAL_WEB.frm_proy
{
    public partial class proy_new : System.Web.UI.Page
    {
        bl_carga_cbo objCbo;
        bl_adjunto objAdj;
        bl_detalle_pro objDet = new bl_detalle_pro();
        String un = "MAN";

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
            String forma = "PRO";

            foreach (var ct in objCbo.lsTrabajoTipo(un, forma))
            {
                cboTipoCotizacion.Items.Add(new ListItem(ct.nom_ttrabajo, ct.idn_ttrabajo));
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

        protected void cboAnexo_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var f in objCbo.lsTipoCotizacion("PRO")) 
            {
                cboAnexo.Items.Add(new ListItem(f.nomtipocot, f.idtipocot));
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

        #endregion

        protected void cboJefe_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();
            CotizacionJefe cj = objCbo.datoJefe(cboJefe.SelectedValue);

            txtCargoJefe.Text = cj.jef_car;
            txtMailJefe.Text = cj.jef_mai;
        }

        //protected void btnCalcula_Click(object sender, EventArgs e)
        //{
        //    this.txtCantidad_TextChanged(sender, e);
        //    this.txtCostoRepuesto_TextChanged(sender, e);
        //    this.txtPrecioTipoTarifa_TextChanged(sender, e);
        //    this.txtValorMO_TextChanged(sender, e);
        //    this.txtValorRepuesto_TextChanged(sender, e);
        //}

        protected void btnAgrega_Click(object sender, EventArgs e)
        {
            String usr = System.Environment.UserName;
            String moneda = cboTipoTarifa.SelectedValue;

            //ingresarEquipo();
            mostrarDetalle(usr, moneda);
            //limpiaCamposEquipo();

            UpdatePanel5.Update();
            UpdatePanel4.Update();
        }

        protected void fuProyecto_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            objAdj = new bl_adjunto();
            String adjunto = "";
            String usr = System.Environment.UserName;

            adjunto = objAdj.adjuntarDocumento(e.FileName, usr);
            fuProyecto.SaveAs(Server.MapPath("~/adjunto_doc/") + adjunto);
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

        #region Metodos Privados

        //private void calculaTotalEquipo() 
        //{
        //    String qty = this.txtCantidad.Text;
        //    String crpto = this.txtCostoRepuesto.Text;
        //    String prpto = this.txtValorRepuesto.Text;
        //    String cmo = this.txtValorMO.Text;
        //    String pmo = this.txtPrecioTipoTarifa.Text;
        //    String tmoneda = this.cboTipoTarifa.SelectedValue;
        //    String tcoti = this.cboTipoCotizacion.SelectedValue;            

        //    if (String.IsNullOrEmpty(tmoneda))
        //    {
        //        String ndmo = "alert(\"Debe seleccionar un tipo tarifa.\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", ndmo, true);
        //    }
        //    else
        //    {
        //        DetalleCotizacionPro objDC = new DetalleCotizacionPro();
        //        objDC.cantidad = qty;
        //        objDC.costorepuesto = crpto;
        //        objDC.preciorepuesto = prpto;
        //        objDC.costomo = cmo;
        //        objDC.preciomo = pmo;

        //        if (int.Parse(qty) <= 0)
        //        {
        //            String ndmo = "alert(\"Cantidad no puede ser menor o igual a 0. Favor revisar.\");";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", ndmo, true);
        //        }
        //        else
        //        {
        //            this.txtMonto.Text = objDet.getTotalEquipo(objDC, tcoti, tmoneda);
        //        }
        //    }
        //}

        //private void ingresarEquipo() 
        //{
        //    DetalleCotizacionPro dcp = new DetalleCotizacionPro();
        //    objDet = new bl_detalle_pro();

        //    dcp.idventa = System.Environment.UserName;
        //    dcp.nroparte = txtNroParte.Text;
        //    dcp.descripcion = txtDescripcion.Text;
        //    dcp.nroserie = txtNroSerie.Text;
        //    dcp.cantidad = txtCantidad.Text;
        //    dcp.costorepuesto = txtCostoRepuesto.Text;
        //    dcp.preciorepuesto = txtValorRepuesto.Text;
        //    dcp.costomo = txtValorMO.Text;
        //    dcp.preciomo = txtPrecioTipoTarifa.Text;
        //    dcp.preciototal = txtMonto.Text;

        //    objDet.setEquipo(dcp);
        //}

        private void getListArchivo(String idu)
        {
            objAdj = new bl_adjunto();
            gvArchivo.DataSource = objAdj.getAdjunto(idu);
            gvArchivo.DataBind();
        }

        private void mostrarDetalle(String idusr, String tmoneda) 
        {
            objDet = new bl_detalle_pro();
            GV1.DataSource = objDet.getDetalleCotizacion(idusr, tmoneda);
            GV1.DataBind();
        }

        //public void limpiaCamposEquipo()
        //{
        //    txtNroParte.Text = "";
        //    txtDescripcion.Text = "";
        //    txtNroSerie.Text = "";
        //    txtCantidad.Text = "1";
        //    txtCostoRepuesto.Text = "0";
        //    txtValorRepuesto.Text = "0";
        //    txtValorMO.Text = "0";
        //    txtPrecioTipoTarifa.Text = "0";
        //    txtMonto.Text = "0";
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String ttarifa = cboTipoTarifa.SelectedValue;
            String copcusr = Request.Cookies["pcusr"].Value;
            mostrarDetalle(copcusr, ttarifa);
            UpdatePanel5.Update();
        }

        protected void GV1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String ttarifa = cboTipoTarifa.SelectedValue;
            String copcusr = Request.Cookies["pcusr"].Value;
            GV1.PageIndex = e.NewPageIndex;
            mostrarDetalle(copcusr, ttarifa);
        }

        protected void GV1_RowCommand(object sender, GridViewCommandEventArgs e)
        {            

        }

        #endregion

        #region Cambio_Valores_Ingreso_Equipo

        //protected void txtCantidad_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox revtxt = sender as TextBox;

        //    if (revtxt != null)
        //    {
        //        this.calculaTotalEquipo();
        //    }
        //}

        //protected void txtCostoRepuesto_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox revtxt = sender as TextBox;

        //    if (revtxt != null)
        //    {
        //        this.calculaTotalEquipo();
        //    }
        //}

        //protected void txtValorRepuesto_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox revtxt = sender as TextBox;

        //    if (revtxt != null)
        //    {
        //        this.calculaTotalEquipo();
        //    }
        //}

        //protected void txtValorMO_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox revtxt = sender as TextBox;

        //    if (revtxt != null)
        //    {
        //        this.calculaTotalEquipo();
        //    }
        //}

        //protected void txtPrecioTipoTarifa_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox revtxt = sender as TextBox;

        //    if (revtxt != null)
        //    {
        //        this.calculaTotalEquipo();
        //    }
        //}

        #endregion
    }
}