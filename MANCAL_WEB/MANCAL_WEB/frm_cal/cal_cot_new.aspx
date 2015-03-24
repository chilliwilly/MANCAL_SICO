<%@ Page Title="Calibraciones - Sistema Cotizacion" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cal_cot_new.aspx.cs" Inherits="MANCAL_WEB.frm_cal.cal_cot_new" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript">
        function chgSectorEntrega() {
            $("#<%=cboLugarEntrega.ClientID %>").on('change', function () {
                var idLE = $("#<%=cboLugarEntrega.ClientID %>").val();

                if (idLE == 2) {
                    llenaSectorEntrega();
                } else {
                    $("#<%=txtSectorEntrega.ClientID %>").val("");
                }
            });
        }

        function btnBuscarCliente() {
            $("#btn-busca-cli").on('click', function () {
                $("#dialog-busca-cli").dialog({
                    modal: true,
                    width: "1000px",
                    buttons: {
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            });
        }

        function agregarEquipo() {
            $("#btnAddEquipo").on('click', function () {                
                $("#dialog-equipo-busca").dialog({
                    modal: true,
                    width: "1000px",
                    buttons: {
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
        fieldset {
            display:inline;
            /*border:none;*/
            vertical-align:top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ingreso Cotización Calibraciones</h1>

<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True" ScriptMode="Release" EnablePartialRendering="true" LoadScriptsBeforeUI="false">
</asp:ToolkitScriptManager>

    <%-- PANEL DE ENCABEZADO DE LA COTIZACION--%>
    <asp:UpdatePanel ID="panelCli" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <script type="text/javascript">
                Sys.Application.add_load(btnBuscarCliente);
     	    </script>

            <table style="width: 100%;">
                <tr>
                    <td class="style5">
                        Tipo Cotización
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="cboTipoCotizacion" runat="server" Width="263px" 
                            oninit="cboTipoCotizacion_Init"> 
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
                        &nbsp;&nbsp;&nbsp;
                        <a href="javascript:void(null);" id="btn-busca-cli" style="display:inline-block;" class="ui-icon ui-icon-search"></a>
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
                        <asp:HiddenField ID="txtHiddIdCliente" runat="server" />
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
            </table>
            <br />
            <asp:Button ID="btnUpdLsCliente" runat="server" style="display:none;" 
                    onclick="btnUpdLsCliente_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--CUADRO QUE SE UTILIZARA PARA BUSCAR CLIENTE --%> 
    <div id="dialog-busca-cli" style="display:none;" title="Buscar Cliente">
        <fieldset>
            <legend>
                Criterios de Busqueda
            </legend>
            <table>
                <tr>
                    <td>
                        <label id="lbl-busca-nom-cli">Nombre Cliente:</label> 
                    </td>
                    <td>
                        <input type="text" id="txt-busca-nom-cli" name="txt-busca-nom-cli" value="" />
                    </td>
                    <td>                        
                        <label id="lbl-busca-nom-cta">Nombre Cuenta:</label> 
                    </td>
                    <td>
                        <input type="text" id="txt-busca-nom-cta" name="txt-busca-nom-cta" value="" />
                    </td>                   
                </tr>   
                <tr>
                    <td>
                        <label id="lbl-busca-nom-cont">Nombre Contacto:</label>
                    </td>
                    <td>
                        <input type="text" id="txt-busca-nom-cont" name="txt-busca-nom-cont" value="" />
                    </td>
                </tr>                             
                <tr>
                    <td colspan="2">
                        <label style="font-weight:bold;">Tipo Cliente</label><br />
                        <asp:RadioButtonList ID="rblTipoCliente" RepeatDirection="Horizontal" runat="server" 
                            oninit="rblTipoCliente_Init"></asp:RadioButtonList>
                    </td>                    
                </tr>
                <tr>
                    <td colspan="2">
                        <label style="font-weight:bold;">Estado Cliente</label><br />
                        <asp:RadioButtonList ID="rblEstadoCliente" RepeatDirection="Horizontal" runat="server" 
                            oninit="rblEstadoCliente_Init"></asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" id="btn-busca-cliente" value="Buscar Cliente"/>
                    </td>
                </tr>
            </table>
        </fieldset>
        <asp:UpdatePanel ID="upListaCliente" runat="server" UpdateMode="Conditional" 
            onload="upListaCliente_Load"><%--onload="upListaCliente_Load"--%>
            <ContentTemplate>                    

                <asp:GridView ID="gvListaCliente" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="5" PagerSettings-PageButtonCount="5" DataKeyNames="IdCliente"
                    PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="Primera" 
                    PagerSettings-LastPageText="Ultima" Width="950px" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Left" Font-Size="Small"
                    onpageindexchanging="gvListaCliente_PageIndexChanging" 
                    oninit="gvListaCliente_Init"><%--oninit="gvListaCliente_Init"--%>
                    <RowStyle CssClass="gridListaCliente" />
                    <Columns>

                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblidcliente" CssClass="idcliente_" runat="server" Text='<%# Bind("IDCLIENTE") %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NOMBRE CLIENTE">
                            <ItemTemplate>
                                <asp:Label ID="lblnomcliente" CssClass="nomcliente_" runat="server" Text='<%# Bind("NOMCLIENTE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NOMBRE CUENTA">
                            <ItemTemplate>
                                <asp:Label ID="lblnomcuenta" CssClass="nomcuenta_" runat="server" Text='<%# Bind("NOMCUENTA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NOMBRE CONTACTO">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreContacto" CssClass="nomcontacto_" runat="server" Text='<%# Bind("NOMCONTACTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CARGO CONTACTO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblCargoContacto" CssClass="carcontacto_" runat="server" Text='<%# Bind("CARGOCONTACTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="FONO CONTACTO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblFonoContacto" CssClass="fonocontacto_" runat="server" Text='<%# Bind("FONOCONTACTO")&"-"&Bind("CELCONTACTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="EMAIL CONTACTO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblMailContacto" CssClass="mailcontacto_" runat="server" Text='<%# Bind("MAILCONTACTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DIRECCION" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lbldireccion" CssClass="direccioncli_" runat="server" Text='<%# Bind("DIRCLIENTE") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href="javascript:void(null);" id="btn-select-cli" onclick="seleccionaCliente();" style="display:inline-block;" class="ui-icon ui-icon-check"></a>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="dialog-tab">
        <div id="tab"> 
            <ul>
                <li><a href="#tab-det-cot">Detalle Cotizacion</a></li>
                <li><a href="#tab-costo">Otros Costos</a></li>
                <li><a href="#tab-total">Total/Margenes</a></li>
                <li><a href="#tab-total-ex">Total Exceder</a></li>
                <li><a href="#tab-notas">Notas</a></li>
                <li><a href="#tab-factura">Facturacion</a></li>
                <li><a href="#tab-garantia">Garantia/Otros</a></li>
                <li><a href="#tab-adjunto">Adjuntos</a></li>
            </ul>

            <div id="tab-det-cot">
                Datos Equipo
                <asp:UpdatePanel ID="upBtnBuscarEquipo" runat="server" UpdateMode="Conditional" style="display:none;">
                    <ContentTemplate>
                        <asp:Button ID="btnBuscarListaEquipo" runat="server" 
                            onclick="btnBuscarListaEquipo_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upSelectEqCotiza" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <script type="text/javascript">
                            Sys.Application.add_load(agregarEquipo);
     	                </script>       

                        <table cellpadding="5px"><%--BOTON  QUE CALCULA EN CASO DE MODIFICAR LA CANTIDAD U OTROS VALORES QUE AFECTEN EL MONTO --%>
                            <tr>
                                <td><input type="button" name="btnAddEquipo" id="btnAddEquipo" value="Agregar Equipo" /></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <br />

                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="165px"><%-- ACA VA EL GRIDVIEW ScrollBars="Vertical" --%>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional"><ContentTemplate>
                    <asp:GridView ID="GV1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Item,IdCotizacion" PageSize="5" 
                    PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" 
                    PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                            AllowPaging="true" >
                        <Columns>

                            <asp:TemplateField HeaderText="Id Cotizacion" ShowHeader="false" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="IdCotizacion" runat="server" Text='<%# Bind("IdCotizacion") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="IdCotizacion" runat="server" Text='<%# Bind("IdCotizacion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="40px">
                                <EditItemTemplate>
                                    <asp:Label ID="Item" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Item" runat="server" Text='<%# Bind("Item") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nro Parte" ItemStyle-Width="160px">
                                <EditItemTemplate>
                                    <asp:Label ID="NroParte" runat="server" Text='<%# Bind("NroParte") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="NroParte" runat="server" Text='<%# Bind("NroParte") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Descripcion" ItemStyle-Width="260px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Descripcion" runat="server" Width="260px" Text='<%# Bind("Descripcion") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Descripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Tipo Trabajo" ItemStyle-Width="130px">
                                <EditItemTemplate>
                                    <asp:Label ID="TipoTrabajo" runat="server" Text='<%# Eval("NOMTIPOTRABAJO") %>'></asp:Label>                                                                                                         
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="TipoTrabajo" runat="server" Text='<%# Eval("NOMTIPOTRABAJO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="50px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Cantidad" runat="server" Width="50px" Text='<%# Bind("Cantidad") %>'/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Nro Serie" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="NroSerie" runat="server" Width="100px" Text='<%# Bind("NroSerie") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="NroSerie" runat="server" Text='<%# Bind("NroSerie") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Precio Repuesto" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="PrecioRep" runat="server" Width="100px" Text='<%# Bind("PrecioRep") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="PrecioRep" runat="server" Text='<%# Bind("PrecioRep") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Costo MO" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="CostoMO" runat="server" ReadOnly="true" Width="100px" Text='<%# Bind("CostoMO") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="CostoMO" runat="server" Text='<%# Bind("CostoMO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Precio MO" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="PrecioMO" runat="server" Width="100px" Text='<%# Bind("PrecioMO") %>'/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="PrecioMO" runat="server" Text='<%# Bind("PrecioMO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tipo Tarifa Original" ItemStyle-Width="100px" Visible="false">
                                <EditItemTemplate>
                                    <asp:Label ID="TipoTarifaOriginal" runat="server" Text='<%# Bind("TipoTarifaOriginal") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="TipoTarifaOriginal" runat="server" Text='<%# Bind("TipoTarifaOriginal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="Total" runat="server" ReadOnly="true" Width="100px" Text='<%# Bind("Total") %>'/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Total" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TotalExceder" runat="server" Width="100px" Text='<%# Bind("TotalExceder") %>'/>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="TotalExceder" runat="server" Text='<%# Bind("TotalExceder") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Editar" ShowHeader="false">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="bActualizar" Text="A"></asp:LinkButton>
                                    <asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="bCancelar" Text="C"></asp:LinkButton>
                                    <asp:LinkButton ID="btnCalcula" runat="server" CausesValidation="false" CommandName="bCalcula" Text="S"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="bEditar" Text="E" Enabled="false"></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="bBorrar" Text="B"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView></ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </div>

            <div id="tab-costo">
                <asp:UpdatePanel ID="panelTransCom" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>        
        
                        <%--TRANSPORTE --%>
                        <fieldset style="width: 30%; padding-left:13px; padding-right:13px;">
                            <legend>Transporte</legend>
                            <table align="center">
                                <tr>
                                    <td>Incluye Transporte</td>
                                    <td></td>
                                    <td>
                                        <asp:CheckBox ID="chkTransporte" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Region Cotizacion</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="cboRegion" runat="server" Width="200px" 
                                            oninit="cboRegion_Init">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Tipo Traslado</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="cboTraslado" runat="server" Width="150px" 
                                            oninit="cboTraslado_Init">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Total Traslado</td>
                                    <td></td>
                                    <td>
                                        <asp:TextBox ID="txtTotalTransporte" runat="server" style="text-align: right;" ReadOnly="true" Width="100px">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>                
                                    <td colspan="3" style="text-align:center;">
                                        <asp:Button ID="Button2" runat="server" Text="Distribuir Precio" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                        <%--COMISION --%>
                        <fieldset style="width: 55%;">
                            <legend>Costo Comision</legend>
                            <table align="center">
                                <tr>
                                    <td>Cantidad Personas</td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Lugar</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="cboLugarComision" runat="server" Width="200px" 
                                            oninit="cboLugarComision_Init">
                                        </asp:DropDownList>
                                    </td>                
                                </tr>
                                <tr>
                                    <td>Cantidad Dias</td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Transporte DTS</td>
                                    <td>
                                        <asp:TextBox ID="TextBox9" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Hotel</td>
                                    <td>
                                        <asp:TextBox ID="TextBox10" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cantidad Vehiculo</td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Transporte Hotel</td>
                                    <td>
                                        <asp:TextBox ID="TextBox11" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Fondo a Rendir</td>
                                    <td>
                                        <asp:TextBox ID="TextBox12" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Traslado Eq/Doc Ciudad</td>
                                    <td>
                                        <asp:TextBox ID="TextBox4" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Transporte Avion Persona</td>
                                    <td>
                                        <asp:TextBox ID="TextBox13" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Gasto Representacion</td>
                                    <td>
                                        <asp:TextBox ID="TextBox14" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Traslado Eq/Doc Avion</td>
                                    <td>
                                        <asp:TextBox ID="TextBox5" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Arriendo Vehiculo</td>
                                    <td>
                                        <asp:TextBox ID="TextBox15" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Total Costo Comision</td>
                                    <td>
                                        <asp:TextBox ID="TextBox16" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Fondo a Rendir</td>
                                    <td>
                                        <asp:TextBox ID="TextBox6" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Traslado Eq/Doc Ciudad</td>
                                    <td>
                                        <asp:TextBox ID="TextBox17" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Total Precio Comision</td>
                                    <td>
                                        <asp:TextBox ID="TextBox18" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Gastos Representacion</td>
                                    <td>
                                        <asp:TextBox ID="TextBox7" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Traslado Eq/Doc Avion</td>
                                    <td>
                                        <asp:TextBox ID="TextBox19" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td colspan="2" rowspan="2" style="text-align:center;">
                                        <asp:Button ID="Button1" runat="server" Text="Cargar Precio" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cantidad Com 1 Mes</td>                
                                    <td>
                                        <asp:TextBox ID="TextBox8" runat="server" Width="40px" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                    <td>Viatico</td>
                                    <td>
                                        <asp:TextBox ID="TextBox20" runat="server" Width="90px" ReadOnly="true" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="tab-total">
                <asp:UpdatePanel ID="panelCalculo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset style="width:20%;" class="inline">
                            <legend>Margenes Comerciales</legend>
                            <table align="center">
                                <tr>
                                    <td>
                                        Total Costo MO
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotalCostoMo" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Total Costo Rpto
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotalCostoRpto" runat="server" 
                                                Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mg Operacional %
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMgOpPorc" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight:bold;">
                                        Mg Bruto %
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMgBrutoPorc" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mg Contribucion
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMgContribucion" runat="server" 
                                                Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mg Contribucion %
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMgContribucionPorc" runat="server" 
                                                Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Utilidad Esperada %
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUtilidadEspPorc" runat="server" 
                                                Width="100px" ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                        <fieldset style="width:25%;" class="inline">
                            <legend>Impuesto</legend>
                            <table align="center">
                                <tr>
                                    <td>
                                        Pago Impuesto
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboTipoImpuesto" runat="server">
                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            <asp:ListItem Value="1">c/ IVA</asp:ListItem>
                                            <asp:ListItem Value="2">s/ IVA</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Con Descuento
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkDcto" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Moneda
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTipoMoneda" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:center;">
                                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" Width="90px" 
                                            onclick="btnCalcular_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                        <fieldset style="width:15%;" class="inline">
                            <legend>Precio Total</legend>
                            <table align="center">
                                <tr>
                                    <td>
                                        Neto
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNeto" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descuento
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDcto" runat="server" Width="100px" 
                                                Enabled="False" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Neto Dcto
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNetoDcto" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        IVA
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIva" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Total
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotal" runat="server" Width="100px" 
                                                ReadOnly="True" style="text-align: right;">0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="tab-total-ex">
                Solo para cotizaciones de mantenimiento
            </div>

            <div id="tab-notas">
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
            </div>

            <div id="tab-factura">
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
                                <td>
                                </td>
                                <td class="style12">Comentario Facturacion<br />
                                    <asp:TextBox ID="txtFacturacion" runat="server" Height="50px" 
                                        TextMode="MultiLine" Width="421px" ReadOnly="true"></asp:TextBox>
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
                                <td>
                                </td>
                                <td class="style12">Comentario Plazo Entrega<br />
                                    <asp:TextBox ID="txtPlazoEntrega" runat="server" Height="50px" 
                                        TextMode="MultiLine" Width="422px" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <div id="dialog-comentario-fac" style="display:none;">
                            Seleccione una opcion la cual puede modificar, o bien escriba una nueva.
                            <br /><br />
                            <asp:RadioButtonList ID="rblComentarioFac" runat="server" 
                                oninit="rblComentarioFac_Init">
                            </asp:RadioButtonList>
                            <br /> 
                            <textarea name="txta-fac" id="txta-fac" rows="6" cols="60" maxlength="200"></textarea>
                        </div>

                        <div id="dialog-comentario-pen" style="display:none;">
                            Seleccione una opcion la cual puede modificar, o bien escriba una nueva.
                            <br /><br />
                            <asp:RadioButtonList ID="rblComentarioPen" runat="server" 
                                oninit="rblComentarioPen_Init">
                            </asp:RadioButtonList>
                            <br />
                            <textarea name="txta-pen" id="txta-pen" rows="6" cols="60" maxlength="200"></textarea>                  
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="tab-garantia">
                <asp:UpdatePanel ID="panelJefe" runat="server" UpdateMode="Conditional">    
                    <ContentTemplate>
                    <script type="text/javascript">
                        Sys.Application.add_load(chgSectorEntrega);
                    </script>
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
                                <asp:DropDownList ID="cboLugarEntrega" runat="server" 
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
            </div>

            <div id="tab-adjunto">
                Archivos Adjuntos
                <asp:UpdatePanel ID="udpArchivo" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvArchivo" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="ADJUNTO_ID,COTIZ_ID" PageSize="5" 
                    PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" 
                    PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                            AllowPaging="true" onpageindexchanging="gvArchivo_PageIndexChanging" 
                            onrowcommand="gvArchivo_RowCommand">
                            <RowStyle CssClass="gvArchivoDet" />
                            <Columns>

                                <asp:TemplateField HeaderText="Item" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:Label ID="ADJUNTO_ID" runat="server" CssClass="adj_nroitem" Text='<%# Bind("ADJUNTO_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID Cotiz" ItemStyle-Width="100px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="COTIZ_ID" runat="server" CssClass="adj_cotid" Text='<%# Bind("COTIZ_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Nombre Adjunto" ItemStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="ADJUNTO_NOMBRE" CssClass="adj_direccion" runat="server" Text='<%# Eval("ADJUNTO_NOMBRE") %>' NavigateUrl='<%# Eval("ADJUNTO_DIR") %>' Target="_blank"></asp:HyperLink>                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Link Doc" ItemStyle-Width="100px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="ADJUNTO_DIR" runat="server" Text='<%# Bind("ADJUNTO_DIR") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                      
                                <asp:TemplateField HeaderText="Borrar" ItemStyle-Width="60px">
                                    <ItemTemplate>
                                        <a href="javascript:void(null);" id="btn-del-file" onclick="borraArchivo();" style="display:inline-block;" class="ui-icon ui-icon-close"></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>            
                        </asp:GridView>

                        <asp:Button ID="btnUpdateDoc" runat="server" style="display:none;" OnClick="btnUpdateDoc_Click"/>

                    </ContentTemplate>        
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <%--SELECCION DE EQUIPO A COTIZAR --%>  
    
    
    <%--DETALLE DE EQUIPOS AGREGADOS--%>
    <br />
    
    <br />
    
    <%-- CUADROS DE DIALOGO PARA TRANSPORTE Y COMISION --%>
    

    <br />
    <br />

    <%--CALCULO DE VALORES--%>
    

    <%--NOTAS DE LA COTIZACION--%>
    <br />
    

    <%--PANEL COMENTARIOS FACTURACION --%>
    <br />
    

    <%--PANEL GARANTIA Y LUGAR DE EJECUCION --%>
    <br />
    

    <%--DIV PARA ELIMINAR EL ARCHIVO SELECCIONADO --%>
    <div id="dialog-archivo" title="Quitar Archivo" style="display:none;">
        Esta seguro que desea quitar el archivo?
        <br /><br />
        <input type="button" id="btn-del-archivo" name="btn-del-archivo" value="Eliminar" />
    </div>
    
    <br /><br />
    <%--PANEL DE DATOS ADJUNTOS --%>
    
    <%--DIALGO PARA MOSTRAR INGRESO SECTOR EN LUGAR DE ENTREGA Y DIALOG PARA MOSTRAR EL CUADRO DONDE SE SELECCIONAN LOS ARCHIVOS A ADJUNTAR --%>
    <div id="dialog-sector" style="display:none;">
        Ingrese sector de entrega
        <br /><br />
        <input type="text" id="txt-sector" name="txt-sector" value="" placeholder="Ingrese sector de entrega" size="40"/>
    </div>    

    <div id="dialog-doc" style="display:none;">
        <asp:AjaxFileUpload ID="fuCalibracion" runat="server" OnUploadComplete="fuCalibracion_UploadComplete" />
    </div>

    <%--BOTONES DE GUARDAR/IMPRIMIR/ADJUNTAR--%>    
    <br /><br /><br />
    <table cellpadding="5px">
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" 
                Text="Guardar" Width="130px"/>
            </td>
            <td>
                <asp:Button ID="btnSaveDraft" runat="server" Text="Guardar Borrador" />
            </td>
            <td>
                <asp:Button ID="btnSavePrint" runat="server" Text="Guardar e Imprimir"/>
            </td>            
            <td>
                <input type="button" id="btn-doc" name="btn-doc" value="Adjuntar Documento" />
            </td>
        </tr>
      </table>

    <%--DIALOG PARA BUSCAR Y AGREGAR EQUIPO --%>
    <div id="dialog-equipo-busca" title="Buscar Equipo" style="display:none;">
        <fieldset>
            <legend>
                Criterios de Busqueda
            </legend>
            <table>
                <tr>
                    <td>
                        Nombre Cliente
                    </td>
                    <td colspan="3">
                        <input type="text" id="txt-cliente-bloq" name="txt-cliente-bloq" readonly="readonly" disabled="disabled" style="width:400px;"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lbl-eq-nombre">Nombre</label>
                    </td>
                    <td>
                        <input id="txt-eq-nombre" name="txt-eq-nombre" type="text" />
                    </td>
                    <td>
                        <label id="lbl-eq-modelo">Modelo</label>
                    </td>
                    <td>
                        <input id="txt-eq-modelo" name="txt-eq-modelo" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lbl-eq-nparte">Nro Parte</label>
                    </td>
                    <td>
                        <input id="txt-eq-nparte" name="txt-eq-nparte" type="text" />
                    </td>
                    <td>
                        <label id="lbl-eq-nserie">Nro Serie</label>
                    </td>
                    <td>
                        <input id="txt-eq-nserie" name="txt-eq-nserie" type="text" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input id="btn-eq-busca" type="button" value="Buscar" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <asp:UpdatePanel ID="upEquipoBusca" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvEquipoBusca" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="5" PagerSettings-PageButtonCount="5" DataKeyNames="EquipoId"
                    PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="Primera" 
                    PagerSettings-LastPageText="Ultima" Width="950px" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Left" Font-Size="Small"
                    OnPageIndexChanging="gvEquipoBusca_PageIndexChanging">
                    <RowStyle CssClass="gvEquipoBuscaCss" />
                    <EmptyDataTemplate>
                        <h1>NO SE HAN ENCONTRADO ELEMENTOS PARA EL CRITERIO DE BUSQUEDA INGRESADO</h1>
                    </EmptyDataTemplate>
                    <Columns>
                    
                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblequipoid" CssClass="eqid_" runat="server" Text='<%# Bind("EQUIPOID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblequiponombre" CssClass="eqnombre_" runat="server" Text='<%# Bind("EQUIPONOMBRE") %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Modelo">
                            <ItemTemplate>
                                <asp:Label ID="lblequipomodelo" CssClass="eqmodelo_" runat="server" Text='<%# Bind("EQUIPOMODELO") %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nro Parte">
                            <ItemTemplate>
                                <asp:Label ID="lblequiponparte" CssClass="eqnparte_" runat="server" Text='<%# Bind("EQUIPONPARTE") %>'></asp:Label>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PMO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblequipopmo" CssClass="eqpmo_" runat="server" Text='<%# Bind("EQUIPOPMO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblequipototal" CssClass="eqtotal_" runat="server" Text='<%# Bind("EQUIPOTOTAL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href="javascript:void(null);" id="btn-select-equ" onclick="seleccionEquipo();" style="display:inline-block;" class="ui-icon ui-icon-check"></a>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>                
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%--DIALOG DONDE SE MODIFICAN PRECIOS/OTROS DEL EQUIPO SELECCIONADO --%>
    <asp:UpdatePanel ID="upUpdDatoEquipo" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Button ID="btnUpdDatoEquipo" runat="server" Text="Button" onclick="btnUpdDatoEquipo_Click"/><!-- onclick="btnUpdDatoEquipo_Click"-->
        </ContentTemplate>
    </asp:UpdatePanel>    
    <div id="dialog-equipo-precio" title="Datos Equipo" style="display:none;">
        Modificacion de los datos del equipo a cotizar
        <br /><br />
        <table>
            <tr>
                <td>
                    ID
                </td>
                <td>
                    <input type="text" id="txt-eq-read-id" name="txt-eq-read-id" readonly="readonly" class="text ui-widget-content ui-corner-all" />
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td><input type="text" id="txt-eq-read-nom" name="txt-eq-read-nom" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>Modelo</td>
                <td><input type="text" id="txt-eq-read-mod" name="txt-eq-read-mod" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>Nro Parte</td>
                <td><input type="text" id="txt-eq-read-np" name="txt-eq-read-np" class="text ui-widget-content ui-corner-all" placeholder="Ingrese Nro Parte"/></td>
            </tr>
            <tr>
                <td>Nro Serie</td>
                <td><input type="text" id="txt-eq-read-ns" name="txt-eq-read-ns" class="text ui-widget-content ui-corner-all" placeholder="Ingrese Nro Serie"/></td>
            </tr>
            <tr>
                <td>Cantidad</td>
                <td><input type="number" id="txt-eq-read-qty" name="txt-eq-read-qty" class="text ui-widget-content ui-corner-all" value="1"/></td>
            </tr>
            <tr>
                <td>
                    Tipo Trabajo
                </td>
                <td>
                    <%--<input type="text" id="txt-eq-read-trabajo" name="txt-eq-read-trabajo" />--%>
                    <asp:DropDownList ID="cbo_eq_read_trabajo" runat="server" oninit="cbo_eq_read_trabajo_Init">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Precio MO</td>
                <td><input type="text" id="txt-eq-read-pmo" name="txt-eq-read-pmo" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr>
                <td>Gastos</td>
                <td><input type="text" id="txt-eq-read-gasto" name="txt-eq-read-gasto" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr>
                <td>Precio Carga</td>
                <td><input type="text" id="txt-eq-read-pcarga" name="txt-eq-read-pcarga" readonly="readonly" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr>
                <td>Precio Venta</td>
                <td><input type="text" id="txt-eq-read-pventa" name="txt-eq-read-pventa" readonly="readonly" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr>
                <td>Estado</td>
                <td><input type="text" id="txt-eq-read-estado" name="txt-eq-read-estado" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>Nota de Pedido</td>
                <td><input type="text" id="txt-eq-read-notap" name="txt-eq-read-notap" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>Linea Prod</td>
                <td><input type="text" id="txt-eq-read-lprod" name="txt-eq-read-lprod" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>O Compra</td>
                <td><input type="text" id="txt-eq-read-oc" name="txt-eq-read-oc" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>SAOT</td>
                <td><input type="text" id="txt-eq-read-saot" name="txt-eq-read-saot" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
            <tr>
                <td>Puntos Calibracion</td>
                <td><input type="text" id="txt-eq-read-puntos" name="txt-eq-read-puntos" readonly="readonly" class="text ui-widget-content ui-corner-all"/></td>
            </tr>
        </table>
    </div>

      <%--SECTOR DE JAVASCRIPT--%>
        <script type="text/javascript">
            $.cookie('nomclient', '');
            $.cookie('nomcuenta', '');
            $.cookie('nomcontact', '');
            $.cookie('nomtipo', '');
            $.cookie('nomestado', '');

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

            $(document).ready(function () {
                $(".td").css("text-align", "left");
                $(".td").css("font-weight", "bold");
                cambiaAjaxUploader();
            });

            var itemnro;
            var clinom, clicta, cliid, clidir;
            var pccookie = $.cookie("pcusr");

            var arch_idcoti;
            var arch_nroitem;
            function delDetalleArch() {
                $('.gvArchivoDet').on('click', function () {
                    arch_nroitem = $('.adj_nroitem', $(this).closest('tr')).html();
                    arch_idcoti = pccookie; // $('.adj_cotid', $(this).closest('tr')).html();
                });
            }

            function dataCliente() {
                $('.gridListaCliente').on('click', function () {
                    $("#<%=txtHiddIdCliente.ClientID %>").val($('.idcliente_', $(this).closest('tr')).html()); //$('.idcliente_', find('td:first').text()                   
                    $("#<%=txtCliente.ClientID %>").val($('.nomcliente_', $(this).closest('tr')).html());
                    $("#<%=txtClienteInforme.ClientID %>").val($('.nomcuenta_', $(this).closest('tr')).html());
                    $("#<%=txtContactoCliente.ClientID %>").val($('.nomcontacto_', $(this).closest('tr')).html());
                    $("#<%=txtDireccionCliente.ClientID %>").val($('.direccioncli_', $(this).closest('tr')).html());
                    $("#<%=txtMailCliente.ClientID %>").val($('.mailcontacto_', $(this).closest('tr')).html());
                    $("#<%=txtFonoCliente.ClientID %>").val($('.fonocontacto_', $(this).closest('tr')).html());
                    $("#txt-cliente-bloq").val($("#<%=txtCliente.ClientID %>").val());
                });
            }
            
            function dataEquipo() {
                $('.gvEquipoBuscaCss').on('click', function () {
                    $("#txt-eq-read-id").val($('.eqid_', $(this).closest('tr')).html());
                    $("#txt-eq-read-nom").val($('.eqnombre_', $(this).closest('tr')).html());
                    $("#txt-eq-read-mod").val($('.eqmodelo_', $(this).closest('tr')).html());
                    $("#txt-eq-read-np").val($('.eqnparte_', $(this).closest('tr')).html());
                    $("#txt-eq-read-pmo").val($('.eqpmo_', $(this).closest('tr')).html());
                    $("#txt-eq-read-pventa").val($('.eqtotal_', $(this).closest('tr')).html());
                    //$("#txt-eq-read-ns").val($('.eqnserie_', $(this).closest('tr')).html());
                });
            }

            function borraArchivo() {
                delDetalleArch();

                $("#dialog-archivo").dialog({
                    modal: true,
                    width: "400px",
                    buttons: {
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            }

            function seleccionaCliente() {
                dataCliente();

                $("#dialog-busca-cli").dialog('close');
            }

            function seleccionEquipo() {
                dataEquipo();                
                $("#dialog-equipo-busca").dialog('close');
                $("#dialog-equipo-precio").dialog({
                    modal: true,
                    width: "500px",
                    buttons: {
                        "Calcular": function () {
                            $(this).dialog('close');
                        },
                        "Agregar": function () {
                            $(this).dialog('close');
                        },
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });                
            }

            function mostrarID() {
                var idequipobusca = $("#txt-eq-read-id").val();
                alert(idequipobusca);
            }

            function llenaSectorEntrega() {
                $("#dialog-sector").dialog({
                    modal: true,
                    title: "Sector Entrega",
                    width: "350px",
                    buttons: {
                        "Aceptar": function () {
                            var intxt = $("#txt-sector").val();
                            $("#<%=txtSectorEntrega.ClientID %>").val(intxt);
                            $("#txt-sector").val("");
                            $(this).dialog('close');
                        },
                        "Cancelar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            }

            $("#<%=txtFacturacion.ClientID %>").on('click', function () {
                $("#txta-fac").val($("#<%=txtFacturacion.ClientID %>").val());
                $("#dialog-comentario-fac").dialog({
                    modal: true,
                    title: "Comentario Facturacion",
                    width: "550px",
                    buttons: {
                        "Agregar": function () {
                            $("#<%=txtFacturacion.ClientID %>").val($("#txta-fac").val());
                            $(this).dialog('close');
                            $("#txta-fac").val("");
                        },
                        "Cerrar": function () {
                            $(this).dialog('close');
                            $("#txta-fac").val("");
                        }
                    }
                });
            });

            $(function () {
                $("#tab").tabs();
            });

            $("#<%=txtPlazoEntrega.ClientID %>").on('click', function () {
                $("#txta-pen").val($("#<%=txtPlazoEntrega.ClientID %>").val());
                $("#dialog-comentario-pen").dialog({
                    modal: true,
                    title: "Comentario Plazo Entrega",
                    width: "550px",
                    buttons: {
                        "Agregar": function () {
                            $("#<%=txtPlazoEntrega.ClientID %>").val($("#txta-pen").val());
                            $(this).dialog('close');
                            $("#txta-pen").val("");
                        },
                        "Cerrar": function () {
                            $(this).dialog('close');
                            $("#txta-pen").val("");
                        }
                    }
                });
            });

            $("#<%=rblComentarioFac.ClientID %>").on('click', function () {
                var txtf = $("#<%=rblComentarioFac.ClientID %>").find(":checked").val();
                $("#txta-fac").val("");
                $("#txta-fac").val(txtf);
            });

            $("#<%=rblComentarioPen.ClientID %>").on('click', function () {
                var txtp = $("#<%=rblComentarioPen.ClientID %>").find(":checked").val();
                $("#txta-pen").val("");
                $("#txta-pen").val(txtp);
            });

            $("#<%=chkDcto.ClientID %>").on('click', function () {
                if ($("#<%=chkDcto.ClientID %>").is(':checked')) {
                    $('#<%=txtDcto.ClientID %>').removeAttr("disabled");
                } else {
                    $('#<%=txtDcto.ClientID %>').attr("disabled", "disabled");
                    $('#<%=txtDcto.ClientID %>').val("0");
                }
            });

            $("#btn-del-archivo").on('click', function () {
                var nitem = arch_nroitem;
                var ncoti = arch_idcoti;

                delArchivo(nitem, ncoti);
                arch_nroitem = "";
                arch_idcoti = "";
                $("#<%=btnUpdateDoc.ClientID %>").click();
            });

            $("#btn-doc").on('click', function () {
                $("#dialog-doc").dialog({
                    modal: true,
                    width: "600px",
                    title: "Adjuntar Documento",
                    buttons: {
                        "Cerrar": function () {
                            $("#<%=btnUpdateDoc.ClientID %>").click();
                            $(this).dialog('close');
                        }
                    }
                });
            });

            $("#btn-busca-cliente").on('click', function () {
                $.cookie('nomclient', $("#txt-busca-nom-cli").val());
                $.cookie('nomcuenta', $("#txt-busca-nom-cta").val());
                $.cookie('nomcontact', $("#txt-busca-nom-cont").val());
                $.cookie('nomtipo', $("#<%=rblTipoCliente.ClientID%>").find(":checked").val());
                $.cookie('nomestado', $("#<%=rblEstadoCliente.ClientID%>").find(":checked").val());
                $("#<%=btnUpdLsCliente.ClientID %>").click();
            });

            $("#btn-eq-busca").on('click', function () {
                var tarifa_id = $("#<%=cboTipoTarifa.ClientID %>").val(); //txtHiddIdCliente
                if (tarifa_id == 0) {//(tarifa_id == "" || tarifa_id == null) {
                    $("<div id='dialog-aux-eq' title='Error Tarifa'>Debe seleccionar un tipo tarifa para proceder a buscar un equipo.</div>").dialog({
                        modal: true,
                        buttons: {
                            "Cerrar": function () {
                                $(this).dialog('close');
                                $("#dialog-equipo-busca").dialog('close');
                            }
                        }
                    });
                } else {
                    $.cookie('eqnombre', $("#txt-eq-nombre").val());
                    $.cookie('eqmodelo', $("#txt-eq-modelo").val());
                    $.cookie('eqnparte', $("#txt-eq-nparte").val());
                    //$.cookie('eqnserie', $("#txt-eq-nserie").val());
                    //$.cookie('eqcodcli', $("#<%=txtHiddIdCliente.ClientID %>").val());
                    $("#<%=btnBuscarListaEquipo.ClientID %>").click();
                }
            });
        </script>

</asp:Content>
