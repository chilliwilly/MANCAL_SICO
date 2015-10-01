using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;
using MANCAL_WEB_CLASS;
using System.Drawing;

namespace MANCAL_WEB.frm_cal
{
    public partial class cal_cot_mod : System.Web.UI.Page
    {
        bl_carga_cbo objCbo;
        bl_cotizacion objCot;
        bl_adjunto objAdj;
        bl_cliente objCliente;
        bl_detalle_pro objDet;
        String dataV, dataEC, dataC, dataCN, dataCT;        
        String un = "CAL";
        String cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado, cli_rut, cli_alias;
        String eq_nombre, eq_modelo, eq_nparte, eq_magnitud, eq_familia, eq_fabricante;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["COT_VAL_SHW"].ToString().Equals("1"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Cosa", "seleccionaCotizacion(" + Session["RPT_NUM_COT"].ToString() + ")", true);

                    getListaDetalle(Session["RPT_NUM_COT"].ToString(), Session["COT_VAL_TAR"].ToString());
                    UpdatePanel5.Update();

                    getListArchivo(Session["RPT_NUM_TXT"].ToString());
                    udpArchivo.Update();

                    Session["COT_VAL_SHW"] = 2;                    
                }
                HttpContext.Current.Response.Cookies["COTVALSHW"].Value = "2";
            }
        }

        #region Carga Combos de Busqueda

        protected void cboBuscaNroCot_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            cboBuscaNroCot.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var nc in objCbo.getNroCotizacion())
            {
                cboBuscaNroCot.Items.Add(new ListItem(nc, nc));
            }
        }

        protected void cboBuscaIdCot_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            cboBuscaIdCot.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var ic in objCbo.getIdCotizacion()) 
            {
                cboBuscaIdCot.Items.Add(new ListItem(ic, ic));
            }
        }

        protected void cboBuscaVendedor_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var cv in objCbo.lsVendedorCot("CAL"))
            {
                cboBuscaVendedor.Items.Add(new ListItem(cv.id_nom, cv.id_ven));
            }
        }

        protected void cboBuscaEstadoCot_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            cboBuscaEstadoCot.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var ec in objCbo.getEstadoCotizacion())
            {
                cboBuscaEstadoCot.Items.Add(new ListItem(ec.noestado, ec.idestado));
            }
        }

        protected void cboBuscaCliCot_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            cboBuscaCliCot.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var cc in objCbo.getClienteBusca())
            {
                cboBuscaCliCot.Items.Add(new ListItem(cc.nomcliente, cc.idcliente));
            }
        }

        #endregion

        #region Pre Carga de Combos

        protected void cboEstadoCotizacion_Init(object sender, EventArgs e) 
        {
            objCbo = new bl_carga_cbo();

            cboEstadoCotizacion.Items.Add(new ListItem("Seleccione", "0"));

            foreach (var ec in objCbo.getEstadoCotizacion())
            {
                cboEstadoCotizacion.Items.Add(new ListItem(ec.noestado, ec.idestado));
            }
        }

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

        //protected void cboTipoTarifa_Init(object sender, EventArgs e)
        //{
        //    objCbo = new bl_carga_cbo();

        //    foreach (var ct in objCbo.lsTarifaTipo())
        //    {
        //        cboTipoTarifa.Items.Add(new ListItem(ct.tt_nom, ct.tt_idn));
        //    }
        //}

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

        //protected void rblTipoCliente_Init(object sender, EventArgs e)
        //{
        //    objCbo = new bl_carga_cbo();

        //    foreach (var rad in objCbo.getTipoCliente())
        //    {
        //        rblTipoCliente.Items.Add(new ListItem(rad.nomtipocli, rad.idtipocli));
        //    }
        //}

        //protected void rblEstadoCliente_Init(object sender, EventArgs e)
        //{
        //    objCbo = new bl_carga_cbo();

        //    foreach (var rad in objCbo.getEstadoCliente())
        //    {
        //        rblEstadoCliente.Items.Add(new ListItem(rad.nomestadocli, rad.idestadocli));
        //    }
        //}

        //Este metodo reemplaza al que rellena el tipo de tarifa en el cbo
        protected void rblSelectDivisa_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();

            foreach (var rad in objCbo.lsTarifaTipo())
            {
                if (Convert.ToInt32(rad.tt_idn) > 0)
                {
                    rblSelectDivisa.Items.Add(new ListItem(rad.tt_nom, rad.tt_idn));
                }
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

        #region Metodos Cotizacion New
        #region Metodos Protected

        protected void gvListaCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            setValueCliente();

            gvListaCliente.PageIndex = e.NewPageIndex;

            mostrarCliente(cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado, cli_rut, cli_alias);
        }

        protected void gvListaCliente_Init(object sender, EventArgs e)
        {
            mostrarCliente("", "", "", "", "", "", "");
        }

        protected void upListaCliente_Load(object sender, EventArgs e)
        {
            mostrarCliente("", "", "", "", "", "", "");
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
            String usr = Request.Cookies["pcusr"].Value;
            String tarifa = String.Format("{0}", Request.Form["txtIdTipoTarifa"]);

            GV1.PageIndex = e.NewPageIndex;
            getListaDetalle(usr, tarifa);//cboTipoTarifa.SelectedValue
        }

        protected void gvArchivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String usr = Request.Cookies["txtcot"].Value;//String.Format("{0}", Request.Form["txtId_Cotizacion_"]);

            gvArchivo.PageIndex = e.NewPageIndex;
            getListArchivo(usr);
        }

        protected void gvArchivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String usr = Request.Cookies["txtcot"].Value;//String.Format("{0}", Request.Form["txtId_Cotizacion_"]);
            getListArchivo(usr);
        }

        protected void btnUpdateDoc_Click(object sender, EventArgs e)
        {
            String txtIdCot = Request.Cookies["txtcot"].Value;//String.Format("{0}", Request.Form["txtId_Cotizacion_"]);
            getListArchivo(txtIdCot);
            udpArchivo.Update();
        }

        protected void fuCalibracion_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            objAdj = new bl_adjunto();
            String adjunto = "";
            String usr = Request.Cookies["txtcot"].Value;//String.Format("{0}", Request.Form["_txtIdCotTxt_"]);

            adjunto = objAdj.adjuntarDocumento(e.FileName, usr);
            fuCalibracion.SaveAs(Server.MapPath("~/adjunto_doc/") + adjunto);
        }

        #endregion

        public void mostrarCliente(String clinom, String clicta, String nomcont, String clitipo, String cliestado, String clirut, String clialias)
        {
            objCliente = new bl_cliente();
            gvListaCliente.DataSource = objCliente.getListaCliente(clinom, clicta, nomcont, clitipo, cliestado, clirut, clialias);
            gvListaCliente.DataBind();
        }

        protected void btnUpdLsCliente_Click(object sender, EventArgs e)
        {
            setValueCliente();
            mostrarCliente(cli_nom, cli_cta, cli_cont, cli_tipo, cli_estado, cli_rut, cli_alias);
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
            String tarifa = String.Format("{0}", Request.Form["txtIdTipoTarifa"]);

            gvEquipoBusca.DataSource = objDet.getEquipo(nom, np, /*modelo,*/ eq_fabricante, eq_magnitud, eq_familia, systemid, tarifa/*cboTipoTarifa.SelectedValue*/, String.Format("{0}", Request.Form["txt_Fecha"]));//txtFecha.Text);
            gvEquipoBusca.DataBind();

            for (int i = 0; i < gvEquipoBusca.Rows.Count; i++)
            {
                if (((Label)gvEquipoBusca.Rows[i].FindControl("lblPoseeValor")).Text.Equals("-10"))
                {
                    gvEquipoBusca.Rows[i].BackColor = ColorTranslator.FromHtml("#FF0000");
                    gvEquipoBusca.Rows[i].Cells[11].Style.Add("pointer-events", "none");
                }
            }
        }

        protected void btnBuscarListaEquipo_Click(object sender, EventArgs e)
        {
            setValueEquipo();
            getListaEquipo(eq_nombre, eq_nparte, eq_modelo);
            upEquipoBusca.Update();
        }

        protected void btnUpdDatoEquipo_Click(object sender, EventArgs e) //
        {
            String usr = Request.Cookies["pcusr"].Value;
            String tarifa = String.Format("{0}", Request.Form["txtIdTipoTarifa"]);

            getListaDetalle(usr, tarifa);//cboTipoTarifa.SelectedValue
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
            cli_rut = Request.Cookies["rutclient"].Value ?? null;
            cli_alias = Request.Cookies["aliasclient"].Value ?? null;
        }

        public void setValueEquipo()
        {
            eq_nombre = Request.Cookies["eqnombre"].Value ?? null;
            eq_modelo = Request.Cookies["eqmodelo"].Value ?? null;
            eq_nparte = Request.Cookies["eqnparte"].Value ?? null;
            eq_magnitud = Request.Cookies["numListaMagnitudBusca"].Value ?? null;
            eq_familia = Request.Cookies["numListaFamiliaBusca"].Value ?? null;
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
            String dco_cot = String.Format("{0}", Request.Form["txtDcto"]);
            //String plazo_entrega = String.Format("{0}", Request.Form["txtPlazoEntregaD"]);

            GV1.DataSource = objDet.getDetalleCot(idcot, idtarifa, dco_cot);//, plazo_entrega
            GV1.DataBind();
        }

        public void getListaPunto()
        {
            objDet = new bl_detalle_pro();
            String usr = Request.Cookies["pcusr"].Value;
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
        #endregion

        protected void upListaCotizacion_Load(object sender, EventArgs e)
        {
            buscarCotizacionLista("0", "0", "0", "0", "0");
            udpBuscaCotizacion.Update();
        }

        protected void gvListaCotizacion_PageIndexChanging(object sender, GridViewPageEventArgs e) 
        {
            setValuesLsCot();
            gvListaCotizacion.PageIndex = e.NewPageIndex;
            buscarCotizacionLista(dataV, dataEC, dataC, dataCN, dataCT);            
        }

        protected void btnBuscaCotizacion_Click(object sender, EventArgs e)
        {
            setValuesLsCot();
            buscarCotizacionLista(dataV, dataEC, dataC, dataCN, dataCT);
            udpBuscaCotizacion.Update();
        }

        protected void btnBuscaCotizacionL_Click(object sender, EventArgs e)
        {
            gvListaCotizacion.DataSource = null;
            gvListaCotizacion.DataBind();
        }

        protected void btnBuscaDetalleCot_Click(object sender, EventArgs e) 
        {
            String txt_cot = Request.Cookies["txtcot"].Value;//String.Format("{0}", Request.Form["txtId_Cotizacion_"]);
            String num_cot = Request.Cookies["pcusr"].Value;
            String tarifa = String.Format("{0}", Request.Form["txtIdTipoTarifa"]);

            getListaDetalle(num_cot, tarifa);//cboTipoTarifa.SelectedValue
            UpdatePanel5.Update();

            getListArchivo(txt_cot);
            udpArchivo.Update();
        }

        public void buscarCotizacionLista(String dataV_, String dataEC_, String dataC_, String dataCN_, String dataCT_) 
        {
            objCot = new bl_cotizacion();
            gvListaCotizacion.DataSource = objCot.selMuestraCotizacion(dataV_, dataEC_, dataC_, dataCN_, dataCT_);
            gvListaCotizacion.DataBind();
        }

        public void setValuesLsCot()
        {
            dataV = Request.Cookies["_dataV"].Value ?? null;
            dataEC = Request.Cookies["_dataEC"].Value ?? null;
            dataC = Request.Cookies["_dataC"].Value ?? null;
            dataCN = Request.Cookies["_dataCN"].Value ?? null;
            dataCT = Request.Cookies["_dataCT"].Value ?? null;
        }
    }
}