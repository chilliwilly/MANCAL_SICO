using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MANCAL_WEB_BL;

namespace MANCAL_WEB.frm_manto
{
    public partial class manto_cot_new : System.Web.UI.Page
    {
        bl_carga_cbo objCbo;
        String un = "MAN";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Pre Carga de Combos

        protected void cboTipoCotizacion_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();
            

            foreach (var ct in objCbo.lsTipoCotizacion(un)) 
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

        protected void cboTipoTrabajo_Init(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();
            String forma = "COT";

            foreach (var ctr in objCbo.lsTrabajoTipo(un, forma)) 
            {
                cboTipoTrabajo.Items.Add(new ListItem(ctr.nom_ttrabajo, ctr.idn_ttrabajo));   
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

        #endregion

        protected void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            Boolean eValida = false;            

            if (cboTipoTrabajo.SelectedValue.Equals("0")) 
            {
                String nd = "alert(\"Debe seleccionar tipo de trabajo.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "Tipo Trabajo", nd, true);
            }
        }

        protected void cboJefe_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCbo = new bl_carga_cbo();
            var cj = objCbo.datoJefe(cboJefe.SelectedValue);

            txtCargoJefe.Text = cj.jef_car;
            txtMailJefe.Text = cj.jef_mai;
        }
    }
}