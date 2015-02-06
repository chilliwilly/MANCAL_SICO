﻿<%@ Page Title="Mantenimiento - Sistema Cotizacion" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="proy_new.aspx.cs" Inherits="MANCAL_WEB.frm_proy.proy_new"
    EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        function agregarEquipo() {
            $("#btnAddEquipo").on('click', function () {
                chgTipoCoti();
                $("#dialog-equipo-add").dialog({
                    modal: true,
                    width: "350px",
                    title: "Agregar Equipo",
                    buttons: {
                        "Calcular": sumDetEquipo,
                        "Agregar": setDetEquipo,
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            });
        }
    </script>

    <style type="text/css">
        .style1
        {
            width: 120px;
        }
        .style2
        {
            width: 266px;
        }
        .style4
        {
            width: 102px;
        }
        .style5
        {
            width: 120px;
            height: 28px;
        }
        .style6
        {
            width: 266px;
            height: 28px;
        }
        .style8
        {
            width: 102px;
            height: 28px;
        }
        .style9
        {
            height: 28px;
        }
        .style12
        {
            width: 428px;
        }      
        .style13
        {
            width: 77px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Ingreso Proyecto Mantenimiento</h1>

<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" ScriptMode="Release" EnablePartialRendering="true" LoadScriptsBeforeUI="false">
</asp:ToolkitScriptManager>        

    <asp:UpdatePanel ID="panelCli" runat="server" UpdateMode="Conditional"><ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td class="style5">
                    Tipo Cotización
                </td>
                <td class="style6">
                    <asp:DropDownList ID="cboTipoCotizacion" runat="server" Width="263px" 
                        oninit="cboTipoCotizacion_Init" onchange="chgTipoCoti();"> 
                    </asp:DropDownList>
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtCorrelativo" runat="server" Width="30px" Visible="false"></asp:TextBox>
                </td>
                <td class="style8">
                    Nro Cotización
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtIdCotizacion" runat="server" Width="130px" ReadOnly="True"></asp:TextBox>
                </td>                
            </tr>
            <tr>
                <td class="style5">
                    Fecha Cotizacion
                </td>
                <td class="style6">
                                    <%-- ACA VA EL CONTROLTOOLKIT --%>                      
                    <asp:TextBox ID="txtFecha" runat="server" AutoPostBack="True" style="text-align:center;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFecha" runat="server"
                        FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td class="style9">
                </td>
                <td class="style8">
                    Cliente
                </td>                
                <td class="style9"><%--CBO CLIENTE --%>
                    <asp:TextBox ID="txtCliente" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td class="style5">
                    Vendedor
                </td>
                <td class="style6">
                    <asp:DropDownList ID="cboVendedor" runat="server" Height="22px" Width="263px" 
                        AutoPostBack="True" oninit="cboVendedor_Init">
                    </asp:DropDownList>
                </td>
                <td class="style9">
                    <%--<asp:TextBox ID="txtCodEmpresa" runat="server" Width="30px"></asp:TextBox>--%>
                </td>
                <td class="style8">
                    Cliente Informe
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtClienteInforme" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <%-- VENDEDOR--%>
                <td class="style5">
                    Correo Vendedor</td>
                    <td class="style6">
                        <asp:TextBox ID="txtMailVendedor" runat="server" Width="260px" ReadOnly="True"></asp:TextBox>
                    </td>
                <td class="style9">
                    <%--<asp:TextBox ID="txtInicialVendedor" runat="server" Width="30px" Height="22px"></asp:TextBox>--%>
                </td>
                <td class="style4">
                    Cliente Contacto
                </td>
                <td>
                    <asp:TextBox ID="txtContactoCliente" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" rowspan="3">
                    Referencias
                </td>
                <td class="style2" rowspan="3">
                    <asp:TextBox ID="txtReferencia" runat="server" Height="68px" Width="260px" 
                        TextMode="MultiLine">Sin Referencia.</asp:TextBox>
                </td>
                    <td class="style9">
                    </td>
                <td class="style4">
                    Cliente Dirección
                </td>
                <td>
                    <asp:TextBox ID="txtDireccionCliente" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td>
                    &nbsp;
                </td>
                <td class="style4">
                    Cliente Mail
                </td>
                <td>
                    <asp:TextBox ID="txtMailCliente" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="style4">
                    Cliente Fono
                </td>
                <td>
                    <asp:TextBox ID="txtFonoCliente" runat="server" Width="263px"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td></td>
                <td>
                    <asp:TextBox ID="txtIdContactoCli" runat="server" Width="20px" Visible="false"></asp:TextBox>
                    <asp:HiddenField ID="txtHiddenTipoTarifa" runat="server" />
                </td>
                <td></td> 
                <td class="style8">
                    Tipo Tarifa
                </td>
                <td class="style9">
                    <asp:DropDownList ID="cboTipoTarifa" runat="server" Width="263px" 
                        AutoPostBack="true" oninit="cboTipoTarifa_Init">
                    </asp:DropDownList>
                </td>               
            </tr>
            <tr>
                <td>
                    Anexo
                </td>
                <td colspan="4">
                    <asp:DropDownList ID="cboAnexo" runat="server" oninit="cboAnexo_Init">
                    </asp:DropDownList>
                </td>
            </tr>
        </table><br /></ContentTemplate></asp:UpdatePanel>

    <%--SELECCION DE EQUIPO A COTIZAR --%>      

    <%--DETALLE DEL EQUIPO BUSCADO--%>
    <br /> 
    Datos Equipo
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional"><ContentTemplate>
        <script type="text/javascript">
            Sys.Application.add_load(agregarEquipo);
     	</script>       

        <table cellpadding="5px"><%--BOTON  QUE CALCULA EN CASO DE MODIFICAR LA CANTIDAD U OTROS VALORES QUE AFECTEN EL MONTO --%>
            <tr>
                <td><input type="button" name="btnAddEquipo" id="btnAddEquipo" value="Agregar Equipo" /></td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="bold">
                    SIGNIFICADO LETRAS DETALLE COTIZACIÓN: E; Editar / B; Borrar
                </td>
            </tr>
        </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <%--DIV PARA AGREGAR EQUIPO CON JQUERY Y AJAX --%>
    <div id="dialog-equipo-add" style="display:none;">
        <form action="" id="frm-equipo-add">
            <table>
                <tr>
                    <td>
                        Nro Parte
                    </td>
                    <td>
                        <input type="text" id="txt_nroparte" name="txt_nroparte" value="" class="text ui-widget-content ui-corner-all" placeholder="Ingrese Nro Parte"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Descripcion
                    </td>
                    <td>
                        <input type="text" id="txt_descrip" name="txt_descrip" value="" class="text ui-widget-content ui-corner-all" placeholder="Ingrese Descripcion"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nro Serie
                    </td>
                    <td>
                        <input type="text" id="txt_serie" name="txt_serie" value="" class="text ui-widget-content ui-corner-all"  placeholder="Ingrese Nro Serie"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cantidad
                    </td>
                    <td>
                        <input type="number" id="txt_cantidad" name="txt_cantidad" value="1" class="text ui-widget-content ui-corner-all" style="width:100px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Costo Repuesto
                    </td>
                    <td>
                        <input type="number" id="txt_crep" name="txt_crep" value="0" class="text ui-widget-content ui-corner-all" style="width:100px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Precio Repuesto
                    </td>
                    <td>
                        <input type="number" id="txt_prep" name="txt_prep" value="0" class="text ui-widget-content ui-corner-all" style="width:100px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Costo MO
                    </td>
                    <td>
                        <input type="number" id="txt_cmo" name="txt_cmo" value="0" class="text ui-widget-content ui-corner-all" style="width:100px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Precio MO
                    </td>
                    <td>
                        <input type="number" id="txt_pmo" name="txt_pmo" value="0" class="text ui-widget-content ui-corner-all" style="width:100px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Monto
                    </td>
                    <td>
                        <input type="text" id="txt_monto" name="txt_monto" value="0" class="text ui-widget-content ui-corner-all" style="width:100px;" disabled="disabled"/>
                    </td>
                </tr>
            </table>            
        </form>
    </div>

    <%--DIV PARA MODIFICAR EQUIPO CON JQUERY Y AJAX --%>

    <%--DETALLE DE EQUIPOS AGREGADOS--%>
    <br />
    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="165px"><%-- ACA VA EL GRIDVIEW ScrollBars="Vertical" --%>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional"><ContentTemplate>
        <asp:GridView ID="GV1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="Item,IdVenta" PageSize="5" 
        PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" 
        PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                AllowPaging="true" onpageindexchanging="GV1_PageIndexChanging" 
                onrowcommand="GV1_RowCommand" >
            <RowStyle CssClass="gvDetalleProy" />
            <Columns>
            
                <asp:TemplateField HeaderText="Id Cotizacion" ShowHeader="false" Visible="false">
                    <EditItemTemplate>
                        <asp:Label ID="IdVenta" runat="server" Text='<%# Bind("IdVenta") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="IdVenta" CssClass="id_venta" runat="server" Text='<%# Bind("IdVenta") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                            
                <asp:TemplateField HeaderText="Item" ItemStyle-Width="40px">
                    <EditItemTemplate>
                        <asp:Label ID="Item" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Item" runat="server" CssClass="item_" Text='<%# Bind("Item") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nro Parte" ItemStyle-Width="160px">
                    <EditItemTemplate>
                        <asp:Label ID="NroParte" runat="server" Text='<%# Bind("NroParte") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="NroParte" runat="server" CssClass="nro_parte" Text='<%# Bind("NroParte") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descripcion" ItemStyle-Width="260px">
                    <EditItemTemplate>
                        <asp:TextBox ID="Descripcion" runat="server" Width="260px" Text='<%# Bind("Descripcion") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Descripcion" runat="server" CssClass="descrip_" Text='<%# Bind("Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                          

                <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="50px">
                    <EditItemTemplate>
                        <asp:TextBox ID="Cantidad" runat="server" Width="50px" Text='<%# Bind("Cantidad") %>'/>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Cantidad" runat="server" CssClass="cantidad_" Text='<%# Bind("Cantidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nro Serie" ItemStyle-Width="100px">
                    <EditItemTemplate>
                        <asp:TextBox ID="NroSerie" runat="server" Width="100px" Text='<%# Bind("NroSerie") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="NroSerie" runat="server" CssClass="nro_serie" Text='<%# Bind("NroSerie") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Costo Repuesto" ItemStyle-Width="100px">
                    <EditItemTemplate>
                        <asp:TextBox ID="CostoRepuesto" runat="server" Width="100px" Text='<%# Bind("CostoRepuesto") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="CostoRepuesto" runat="server" CssClass="costo_rep" Text='<%# Bind("CostoRepuesto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Precio Repuesto" ItemStyle-Width="100px">
                    <EditItemTemplate>
                        <asp:TextBox ID="PrecioRepuesto" runat="server" Width="100px" Text='<%# Bind("PrecioRepuesto") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="PrecioRepuesto" runat="server" CssClass="precio_rep" Text='<%# Bind("PrecioRepuesto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Costo MO" ItemStyle-Width="100px">
                    <EditItemTemplate>
                        <asp:TextBox ID="CostoMO" runat="server" ReadOnly="true" Width="100px" Text='<%# Bind("CostoMO") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="CostoMO" runat="server" CssClass="costo_mo" Text='<%# Bind("CostoMO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Precio MO" ItemStyle-Width="100px">
                    <EditItemTemplate>
                        <asp:TextBox ID="PrecioMO" runat="server" Width="100px" Text='<%# Bind("PrecioMO") %>'/>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="PrecioMO" runat="server" CssClass="precio_mo" Text='<%# Bind("PrecioMO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Total" ItemStyle-Width="100px">
                    <EditItemTemplate>
                        <asp:TextBox ID="PrecioTotal" runat="server" ReadOnly="true" Width="100px" Text='<%# Bind("PrecioTotal") %>'/>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="PrecioTotal" runat="server" CssClass="precio_t" Text='<%# Bind("PrecioTotal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Editar" ItemStyle-Width="50px" ShowHeader="false">
                    <ItemTemplate>
                        <%--<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="bEditar" Text="E"></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="bBorrar" Text="B"></asp:LinkButton>--%>
                        <a href="javascript:void(null);" id="btn-upd" onclick="editaNroParte();" style="display:inline-block;" class="ui-icon ui-icon-transferthick-e-w"></a>
                        <a href="javascript:void(null);" id="btn-del" onclick="borraNroParte();" style="display:inline-block;" class="ui-icon ui-icon-trash"></a>                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

            <asp:Button runat="server" ID="btnUpdate" style="display:none;" 
                onclick="btnUpdate_Click" />

        </ContentTemplate>        
        </asp:UpdatePanel>
    </asp:Panel>
    <br />
    <%--CALCULO DE VALORES--%>
    <asp:UpdatePanel ID="panelCalculo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="contenedor">
                <div id="margenes">
                    <div class="tabla">
                        <div class="fila">
                            <div class="columna">Total Costo MO</div>
                            <div class="columna"><asp:TextBox ID="txtTotalCostoMo" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Total Costo Rpto</div>
                            <div class="columna"><asp:TextBox ID="txtTotalCostoRpto" runat="server" 
                                    Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Mg Operacional %</div>
                            <div class="columna"><asp:TextBox ID="txtMgOpPorc" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna"><asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="true">Mg Bruto %</asp:Label></div>
                            <div class="columna"><asp:TextBox ID="txtMgBrutoPorc" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Mg Contribucion</div>
                            <div class="columna"><asp:TextBox ID="txtMgContribucion" runat="server" 
                                    Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Mg Contribucion %</div>
                            <div class="columna"><asp:TextBox ID="txtMgContribucionPorc" runat="server" 
                                    Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Utilidad Eseperada %</div>
                            <div class="columna"><asp:TextBox ID="txtUtilidadEspPorc" runat="server" 
                                    Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                    </div>
                </div>
                <div id="ivaotros">
                    <div class="tabla">
                        <div class="fila">
                            <div class="columna">Pago Impuesto</div>
                            <div class="columna">
                                <asp:DropDownList ID="cboTipoImpuesto" runat="server">
                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                    <asp:ListItem Value="1">c/ IVA</asp:ListItem>
                                    <asp:ListItem Value="2">s/ IVA</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="fila">
                            <div class="columna">Con Descuento</div>
                            <div class="columna"><asp:CheckBox ID="chkDcto" runat="server" AutoPostBack="true"/></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Tipo Moneda</div>
                            <div class="columna"><asp:TextBox ID="txtTipoMoneda" runat="server" ReadOnly="True"></asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna"></div>
                            <div class="columna"></div>
                        </div>
                        <div class="fila">
                            <div class="columna"></div>
                            <div class="columna">
                                <asp:Button ID="btnCalcular" runat="server" Text="Calcular" Width="90px" />
                            </div>
                        </div>
                    </div>
                </div>
                <div id="precionormal">        
                    <div class="tabla">
                        <div class="fila">
                            <div class="columna"><asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true">Precio Total Normal</asp:Label></div>
                            <div class="columna"></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Neto</div>
                            <div class="columna"><asp:TextBox ID="txtNeto" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Descuento</div>
                            <div class="columna"><asp:TextBox ID="txtDcto" runat="server" Width="100px" 
                                    Enabled="False" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Neto Dcto</div>
                            <div class="columna"><asp:TextBox ID="txtNetoDcto" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">IVA</div>
                            <div class="columna"><asp:TextBox ID="txtIva" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                        <div class="fila">
                            <div class="columna">Total</div>
                            <div class="columna"><asp:TextBox ID="txtTotal" runat="server" Width="100px" 
                                    ReadOnly="True" style="text-align: right;">0</asp:TextBox></div>
                        </div>
                    </div>
                </div>        
                <div id="precioexcede">
                    
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--NOTAS DE LA COTIZACION--%>
    <br />
    <asp:UpdatePanel runat="server" ID="panelNota" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="5px">
                <tr>
                    <td>Nota 1:</td>
                    <td>
                        <asp:TextBox ID="txtNotaUno" runat="server" TextMode="MultiLine" Width="625px" Height="50px" onKeyPress="return taLimit(this)" onKeyUp="return taCount(this,'myCounter')">Sin Nota</asp:TextBox>                
                    </td>
                    <td>
                        Caracteres restantes: <span id="myCounter">400</span>
                    </td>
                </tr>
                <tr>
                    <td>Nota 2:</td>
                    <td>
                        <asp:TextBox ID="txtNotaDos" runat="server" TextMode="MultiLine" Width="625px" Height="50px" onKeyPress="return taLimit(this)" onKeyUp="return taCount(this,'myCounterDos')">Sin Nota</asp:TextBox>
                    </td>
                    <td>
                        Caracteres restantes: <span id="myCounterDos">400</span>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--PANEL COMENTARIOS FACTURACION --%>
    <br />
    <asp:UpdatePanel runat="server" ID="panelComentarirFac" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="5px">
                <tr>
                    <td style="width:90px;">
                        Facturación
                          <br />
                        <asp:DropDownList ID="cboFacturacion" runat="server" 
                            Width="140px" oninit="cboFacturacion_Init"> 
                        </asp:DropDownList>
                    </td>
                    <td><asp:Panel ID="panelFac" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="fac" runat="server" AutoPostBack="True" BackColor="White" BorderColor="Black" BorderWidth="2px">                           
                                </asp:RadioButtonList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                    <td class="style12">Comentario Facturacion<br />
                        <asp:TextBox ID="txtFacturacion" runat="server" Height="50px" 
                            TextMode="MultiLine" Width="421px"></asp:TextBox>
                        <asp:PopupControlExtender ID="PopFac" PopupControlID="panelFac" TargetControlID="txtFacturacion" Position="Bottom" runat="server" CommitProperty="value">
                        </asp:PopupControlExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width:90px;">
                        Forma Pago Facturación
                        <br />
                        <asp:DropDownList ID="cboFormaPago" runat="server" Width="140px" 
                            oninit="cboFormaPago_Init">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td class="style12">Comentario Forma Pago Facturacion<br />
                        <asp:TextBox ID="txtFormaPago" runat="server" Height="50px" 
                            TextMode="MultiLine" Width="422px">a contar de la fecha de facturación</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:90px;">
                        Plazo Entrega<br />
                        <asp:DropDownList ID="cboPlazoEntrega" runat="server" Width="140px" 
                            oninit="cboPlazoEntrega_Init">
                        </asp:DropDownList>                
                    </td>
                    <td><asp:Panel ID="panelPEn" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="pEn" runat="server" AutoPostBack="True" 
                                    BackColor="White" BorderColor="Black" BorderWidth="2px">
                                </asp:RadioButtonList>
                            </ContentTemplate>                    
                        </asp:UpdatePanel>                
                        </asp:Panel>
                    </td>
                    <td class="style12">Comentario Plazo Entrega<br />
                        <asp:TextBox ID="txtPlazoEntrega" runat="server" Height="50px" 
                            TextMode="MultiLine" Width="422px"></asp:TextBox>
                            <asp:PopupControlExtender ID="PopPEn" PopupControlID="panelPEn" TargetControlID="txtPlazoEntrega" Position="Bottom" runat="server" CommitProperty="value">
                            </asp:PopupControlExtender>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--PANEL GARANTIA Y LUGAR DE EJECUCION --%>
    <br />
    <asp:UpdatePanel ID="panelJefe" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="5px">
            <tr>
                <td>Texto solo cotizaciones<br /> clientes extranjeros</td>
                <td>
                    <asp:DropDownList ID="cboTextCotEx" runat="server">
                        <asp:ListItem>Seleccione...</asp:ListItem>
                        <asp:ListItem>Todos los costos de traslado e impuestos serán de cargo del cliente.</asp:ListItem>
                        <asp:ListItem>Los costos de traslado e impuestos en origen serán de cargo del cliente.</asp:ListItem>
                        <asp:ListItem>Los costos e impuestos de exportación serán de cargo de DTS Ltda.</asp:ListItem>
                        <asp:ListItem>Todos los costos de traslado e impuestos aduaneros serán de cargo de DTS Ltda.</asp:ListItem>
                        <asp:ListItem>Otro</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Lugar Ejecucion Trabajos</td>
                <td>
                    <asp:DropDownList ID="cboEjecTrab" runat="server" oninit="cboEjecTrab_Init">
                    </asp:DropDownList>                                           
                </td>
            </tr>
            <tr>
                <td>Lugar de Entrega</td>
                <td>
                    <asp:DropDownList ID="cboLugarEntrega" runat="server" AutoPostBack="true" 
                        oninit="cboLugarEntrega_Init">
                    </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp; Sector Entrega
                    <asp:TextBox ID="txtSectorEntrega" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Validez Oferta</td>
                <td>
                    <asp:TextBox ID="txtValidezOferta" runat="server" style="text-align:center;"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtValidezOferta" FirstDayOfWeek="Monday" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>Garantia</td>
                <td>
                    <asp:DropDownList ID="cboGarantia" runat="server" oninit="cboGarantia_Init">
                    </asp:DropDownList>

                &nbsp;&nbsp;&nbsp;&nbsp; Validez Garantia

                    <asp:DropDownList ID="cboValidezGar" runat="server" oninit="cboValidezGar_Init">
                    </asp:DropDownList>            
                </td>
            </tr>
            <tr>
                <td>Aceptador por</td>
                <td>
                    <asp:DropDownList ID="cboJefe" runat="server" AutoPostBack="True" 
                        oninit="cboJefe_Init" 
                        onselectedindexchanged="cboJefe_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                    Mail&nbsp;<asp:TextBox ID="txtMailJefe" runat="server" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                    Cargo&nbsp;<asp:TextBox ID="txtCargoJefe" runat="server" Width="180px" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            </table>                    
        </ContentTemplate>
    </asp:UpdatePanel>

<%--PEGAR LO CORTADO--%>    
<br /><br /><br />
    <table cellpadding="5px">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" 
                Text="Guardar Cotizacion" Width="130px"/>
            </td>

            <td>
                <asp:Button ID="btnSavePrint" runat="server" Text="Guardar e Imprimir"/>
            </td>
        </tr>
      </table>

      <%--SECTOR DE JAVASCRIPT--%>
        <script type="text/javascript">            
            maxL = 400;
            var bName = navigator.appName;
            function taLimit(taObj) {
                if (taObj.value.length == maxL) return false;
                return true;
            }

            function taCount(taObj, Cnt) {
                objCnt = createObject(Cnt);
                objVal = taObj.value;
                if (objVal.length > maxL) objVal = objVal.substring(0, maxL);
                if (objCnt) {
                    if (bName == "Netscape") {
                        objCnt.textContent = maxL - objVal.length;
                    }
                    else { objCnt.innerText = maxL - objVal.length; }
                }
                return true;
            }
            function createObject(objId) {
                if (document.getElementById) return document.getElementById(objId);
                else if (document.layers) return eval("document." + objId);
                else if (document.all) return eval("document.all." + objId);
                else return eval("document." + objId);
            }

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                if (args.get_error() == undefined) {
//                    reloadAutocomplete();
                }
            }

            $(document).ready(function () {
                $(".td").css("text-align", "left");
                $(".td").css("font-weight", "bold");
            });

            var itemnro;
            function dataEquipo() {
                var objEquipo = new Object();
                var pccookie = $.cookie("pcusr");

                objEquipo.idventa = pccookie;
                objEquipo.item = itemnro;
                objEquipo.nroparte = $("#txt_nroparte").val();
                objEquipo.descripcion = $("#txt_descrip").val();
                objEquipo.nroserie = $("#txt_serie").val();
                objEquipo.cantidad = $("#txt_cantidad").val();
                objEquipo.costorepuesto = $("#txt_crep").val();
                objEquipo.preciorepuesto = $("#txt_prep").val();
                objEquipo.costomo = $("#txt_cmo").val();
                objEquipo.preciomo = $("#txt_pmo").val();
                objEquipo.preciototal = $("#txt_monto").val();

                return objEquipo;
            }

            function sumDetEquipo() {
                var coti = $('#<%=cboTipoCotizacion.ClientID %>').val();
                var mone = $('#<%=cboTipoTarifa.ClientID %>').val();

                itemnro = itemnro ? itemnro : "1";
                
                var tot = sumEquipo(dataEquipo(), coti, mone);
                $("#txt_monto").val(tot);
            }

            function setDetEquipo() {
                //itemnro = "1";
                setEquipo(dataEquipo());
                $("#<%=btnUpdate.ClientID %>").click();
                limpiaIngreso();
                //btnUpdate - UpdatePanel5 - hfUpdate
            }

            function chgTipoCoti() {
                var tc = $('#<%=cboTipoCotizacion.ClientID %>').val();

                if (tc == 5) {
                    $("#txt_cmo").attr("disabled", "disabled");
                    $("#txt_pmo").attr("disabled", "disabled");
                }
                else if (tc == 6) {
                    $("#txt_cmo").removeAttr("disabled");
                    $("#txt_pmo").removeAttr("disabled");
                    $("#txt_crep").attr("disabled", "disabled");
                }
                else if (tc == 7) {
                    $("#txt_cmo").removeAttr("disabled");
                    $("#txt_pmo").removeAttr("disabled");
                    $("#txt_crep").removeAttr("disabled");
                }
            }

            function limpiaIngreso() {
                $("#txt_nroparte").val("");
                $("#txt_descrip").val("");
                $("#txt_serie").val("");
                $("#txt_cantidad").val("1");
                $("#txt_crep").val("0");
                $("#txt_prep").val("0");
                $("#txt_cmo").val("0");
                $("#txt_pmo").val("0");
                $("#txt_monto").val("0");
            }

            function updDetalle() {
//                $('.gvDetalleProy').on('click', function () {
//                    itemnro = $('.item_', $(this).closest("tr")).html();
//                    $("#txt_nroparte").val($('.nro_parte', $(this).closest("tr")).html()); //txt_nro_parte_m
//                    $("#txt_descrip").val($('.descrip_', $(this).closest("tr")).html()); //txt_descrip_m
//                    $("#txt_cantidad").val($('.cantidad_', $(this).closest("tr")).html()); //txt_cantidad_m
//                    $("#txt_serie").val($('.nro_serie', $(this).closest("tr")).html()); //txt_serie_m
//                    $("#txt_crep").val($('.costo_rep', $(this).closest("tr")).html()); //txt_crep_m
//                    $("#txt_prep").val($('.precio_rep', $(this).closest("tr")).html()); //txt_prep_m
//                    $("#txt_cmo").val($('.costo_mo', $(this).closest("tr")).html()); //txt_cmo_m
//                    $("#txt_pmo").val($('.precio_mo', $(this).closest("tr")).html()); //txt_pmo_m
//                    $("#txt_monto").val($('.precio_t', $(this).closest("tr")).html()); //txt_monto_m
//                });
            }

            function editaNroParte() {
                $('.gvDetalleProy').on('click', function () {
                    itemnro = $('.item_', $(this).closest("tr")).html();
                    $("#txt_nroparte").val($('.nro_parte', $(this).closest("tr")).html()); //txt_nro_parte_m
                    $("#txt_descrip").val($('.descrip_', $(this).closest("tr")).html()); //txt_descrip_m
                    $("#txt_cantidad").val($('.cantidad_', $(this).closest("tr")).html()); //txt_cantidad_m
                    $("#txt_serie").val($('.nro_serie', $(this).closest("tr")).html()); //txt_serie_m
                    $("#txt_crep").val($('.costo_rep', $(this).closest("tr")).html()); //txt_crep_m
                    $("#txt_prep").val($('.precio_rep', $(this).closest("tr")).html()); //txt_prep_m
                    $("#txt_cmo").val($('.costo_mo', $(this).closest("tr")).html()); //txt_cmo_m
                    $("#txt_pmo").val($('.precio_mo', $(this).closest("tr")).html()); //txt_pmo_m
                    $("#txt_monto").val($('.precio_t', $(this).closest("tr")).html()); //txt_monto_m
                });

                $("#dialog-equipo-add").dialog({
                    modal: true,
                    width: "350px",
                    title: "Modificar Equipo",
                    buttons: {
                        "Calcular": sumDetEquipo,
                        "Actualizar": function () {
                            updEquipo(dataEquipo());
                            $("#<%=btnUpdate.ClientID %>").click();
                            $(this).dialog('close');
                            limpiaIngreso();
                        },
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            }

            function borraNroParte() {
                var nroitem_;
                $('.gvDetalleProy').on('click', function () {
                    nroitem_ = $('.item_', $(this).closest("tr")).html();

                    alert(nroitem_);
                });

                

                $("<div id='dialog-del'><p>Esta seguro que desea borrar el item Nro " + nroitem + " del detalle?</p></div>").dialog({
                    modal: true,
                    title: "Borrar Equipo",
                    buttons: {
                        "Si": function () {
                            $(this).dialog('close');
                        },
                        "No": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            }
        </script>

</asp:Content>