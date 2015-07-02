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

        function agregarArchivo() {
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
                        <asp:DropDownList ID="cboTipoCotizacion" runat="server" Width="263px" CssClass="_cboTipoCotizacion_"
                            oninit="cboTipoCotizacion_Init"> 
                        </asp:DropDownList>
                    </td>
                    <td class="style9">
                        <asp:TextBox ID="txtCorrelativo" runat="server" Width="30px" Visible="false"></asp:TextBox>
                    </td>
                    <td class="style8">
                        Cliente
                    </td>
                    <td class="style9">
                        <asp:TextBox ID="txtIdCotizacion" runat="server" Width="130px" ReadOnly="True" style="display:none;"></asp:TextBox>
                        <asp:TextBox ID="txtCliente" runat="server" Width="350px" ReadOnly="true" CssClass="_txtCliente_"></asp:TextBox><!--263px-->
                        &nbsp;&nbsp;&nbsp;
                        <a href="javascript:void(null);" id="btn-busca-cli" style="display:inline-block;" class="ui-icon ui-icon-search"></a>
                    </td>                
                </tr>
                <tr>
                    <td class="style5">
                        Fecha Cotizacion
                    </td>
                    <td class="style6">
                                        <%-- ACA VA EL CONTROLTOOLKIT AutoPostBack="True" --%>                      
                        <asp:TextBox ID="txtFecha" runat="server" style="text-align:center;" ReadOnly="true" CssClass="_txtFecha_"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFecha" runat="server" OnClientDateSelectionChanged="cambioFechaCotizacion"
                            FirstDayOfWeek="Monday" Format="dd/MM/yyyy" BehaviorID="nuevaFechaCotiza" OnClientShown="deshabilitaFinDeSemana" OnPreRender="CalendarExtender1_PreRender">
                        </asp:CalendarExtender>                        
                    </td>
                    <td class="style9">
                    </td>
                    <td class="style8">
                        Cuenta
                    </td>                
                    <td class="style9"><%--CBO CLIENTE --%>
                        <asp:TextBox ID="txtCuenta" runat="server" Width="350px" ReadOnly="true" CssClass="_txtCuenta_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td class="style5">
                        Vendedor
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="cboVendedor" runat="server" Height="22px" Width="263px" oninit="cboVendedor_Init" CssClass="_cboVendedor_">
                        </asp:DropDownList>
                    </td>
                    <td class="style9">
                        <%--<asp:TextBox ID="txtCodEmpresa" runat="server" Width="30px"></asp:TextBox>--%>
                    </td>
                    <td class="style8">
                        Cliente Informe
                    </td>
                    <td class="style9">
                        <asp:TextBox ID="txtClienteInforme" runat="server" Width="350px" CssClass="_txtClienteInforme_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <%-- VENDEDOR--%>
                    <td class="style5">
                        Correo Vendedor</td>
                        <td class="style6">
                            <%--<asp:TextBox ID="txtMailVendedor" runat="server" Width="260px" ReadOnly="True"></asp:TextBox>--%>
                            <input type="text" id="txtMailVendedor" name="txtMailVendedor" readonly="readonly" style="width:260px;" />
                        </td>
                    <td class="style9">
                        <%--<asp:TextBox ID="txtInicialVendedor" runat="server" Width="30px" Height="22px"></asp:TextBox>--%>
                    </td>
                    <td class="style4">
                        Cliente Cert.
                    </td>
                    <td>
                        <asp:TextBox ID="txtClienteCertificado" runat="server" Width="350px" CssClass="_txtClienteCertificado_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1" rowspan="3">
                        Referencias
                    </td>
                    <td class="style2" rowspan="3">
                        <asp:TextBox ID="txtReferencia" runat="server" Height="68px" Width="260px" CssClass="_txtReferencia_"
                            TextMode="MultiLine">Sin Referencia.</asp:TextBox>
                    </td>
                        <td class="style9">
                        </td>
                    <td class="style4">
                        Cliente Contacto
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactoCliente" runat="server" Width="350px" CssClass="_txtContactoCliente_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                
                    <td>
                        &nbsp;
                    </td>
                    <td class="style4">
                        Cliente Dirección
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionCliente" runat="server" Width="350px" CssClass="_txtDireccionCliente_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td class="style4">
                        Cliente Mail
                    </td>
                    <td>
                        <asp:TextBox ID="txtMailCliente" runat="server" Width="350px" CssClass="_txtMailCliente_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td class="style8">Cliente Fono</td>
                    <td class="style9">
                        <asp:TextBox ID="txtFonoCliente" runat="server" Width="350px" CssClass="_txtFonoCliente_"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td></td>
                    <td>
                        <asp:TextBox ID="txtIdContactoCli" runat="server" Width="20px" Visible="false" CssClass="_txtIdContactoCli_"></asp:TextBox>
                        <asp:TextBox ID="txtIdCliente" runat="server" style="display:none;" CssClass="_txtIdCliente_"></asp:TextBox>
                        <asp:TextBox ID="txtIdUniNeg" runat="server" style="display:none;" CssClass="_txtIdUniNeg_" Text="CAL"></asp:TextBox>
                        <asp:TextBox ID="txtEstadoCot" runat="server" style="display:none;" CssClass="_txtEstadoCot_" Text="2"></asp:TextBox>
                        <asp:HiddenField ID="txtHiddenTipoTarifa" runat="server" />
                        <asp:HiddenField ID="txtHiddIdCliente" runat="server" />
                    </td>
                    <td></td> 
                    <td class="style8">
                        Tipo Tarifa
                    </td>
                    <td class="style9">
                        <asp:DropDownList ID="cboTipoTarifa" runat="server" Width="263px" oninit="cboTipoTarifa_Init" CssClass="_cboTipoTarifa_">
                        </asp:DropDownList>
                    </td>               
                </tr>
            </table>
            <br />            
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="upBtnLsCliente" runat="server" UpdateMode="Conditional" style="display:none;">
        <ContentTemplate>
            <asp:Button ID="btnUpdLsCliente" runat="server" style="display:none;" 
                    onclick="btnUpdLsCliente_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--CUADRO QUE SE UTILIZARA PARA BUSCAR CLIENTE --%>
    <asp:UpdatePanel ID="upUpdDatoEquipo" runat="server" UpdateMode="Conditional" style="display:none;">
        <ContentTemplate>
            <asp:Button ID="btnUpdDatoEquipo" runat="server" 
                onclick="btnUpdDatoEquipo_Click"/><!-- onclick="btnUpdDatoEquipo_Click"-->
        </ContentTemplate>
    </asp:UpdatePanel>
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
                                <asp:Label ID="lblFonoContacto" CssClass="fonocontacto_" runat="server" Text='<%# Bind("FONOCONTACTO") %>'></asp:Label>
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
        <div id="tab" style="height:380px;"> 
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
                
                <%-- ACA VA EL GRIDVIEW ScrollBars="Vertical" --%>
                <%--<asp:Panel ID="Panel1" runat="server" Width="100%" Height="165px">--%>
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GV1" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="equipocotid,equipoitem,equipoid" PageSize="5" 
                                PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" 
                                PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                                        AllowPaging="true" OnPageIndexChanging="GV1_PageIndexChanging" Font-Size="Small">
                                    <RowStyle CssClass="cssDetEq" />
                                <Columns>

                                    <asp:TemplateField HeaderText="Id Cotizacion" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocotid" CssClass="equipocotid_" runat="server" Text='<%# Bind("EQUIPOCOTID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            
                                    <asp:TemplateField HeaderText="Item" ItemStyle-Width="40px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipoid" CssClass="equipoid_" runat="server" Text='<%# Bind("EQUIPOID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item" ItemStyle-Width="40px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipoitem" CssClass="equipoitem_" runat="server" Text='<%# Bind("EQUIPOITEM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nombre" ItemStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="equiponombre" CssClass="equiponombre_" runat="server" Text='<%# Bind("EQUIPONOMBRE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            
                                    <asp:TemplateField HeaderText="Modelo" ItemStyle-Width="110px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipomodelo" CssClass="equipomodelo_" runat="server" Text='<%# Eval("EQUIPOMODELO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nro Parte" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="equiponparte" CssClass="equiponparte_" runat="server" Text='<%# Bind("EQUIPONPARTE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Nro Serie" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="equiponserie" CssClass="equiponserie_" runat="server" Text='<%# Bind("EQUIPONSERIE") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qty" ItemStyle-Width="40px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocantidad" CssClass="equipocantidad_" runat="server" Text='<%# Bind("EQUIPOCANTIDAD") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Precio MO" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipopmo" CssClass="equipopmo_" runat="server" Text='<%# Bind("EQUIPOPMO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Gastos" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocalgasto" CssClass="equipocalgasto_" runat="server" Text='<%# Bind("EQUIPOCALGASTO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Precio Carga" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocalpcarga" CssClass="equipocalpcarga_" runat="server" Text='<%# Bind("EQUIPOCALPCARGA") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="equipototal" CssClass="equipototal_" runat="server" Text='<%# Bind("EQUIPOTOTAL") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocalid" CssClass="equipocalid_" runat="server" Text='<%# Bind("EQUIPOCALID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipotrabajoid" CssClass="equipotrabajoid_" runat="server" Text='<%# Bind("EQUIPOTRABAJOID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipotrabajo" CssClass="equipotrabajo_" runat="server" Text='<%# Bind("EQUIPOTRABAJO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocalnp" CssClass="equipocalnp_" runat="server" Text='<%# Bind("EQUIPOCALNP") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocaloc" CssClass="equipocaloc_" runat="server" Text='<%# Bind("EQUIPOCALOC") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipocalsaot" CssClass="equipocalsaot_" runat="server" Text='<%# Bind("EQUIPOCALSAOT") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipolp_idn" CssClass="equipolp_idn_" runat="server" Text='<%# Bind("EQUIPOLP_IDN") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipolp_nom" CssClass="equipolp_nom_" runat="server" Text='<%# Bind("EQUIPOLP_NOM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipodet_idn" CssClass="equipodet_idn_" runat="server" Text='<%# Bind("EQUIPODET_IDN") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total No Exceder" ItemStyle-Width="100px" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                                        <ItemTemplate>
                                            <asp:Label ID="equipodet_nom" CssClass="equipodet_nom_" runat="server" Text='<%# Bind("EQUIPODET_NOM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Otros / Puntos">
                                        <ItemTemplate>
                                            <a href="javascript:void(null);" id="btn-det-cal-det" onclick="seleccionDetalleCal();" style="display:inline-block;" class="ui-icon ui-icon-circle-plus"></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <a href="javascript:void(null);" id="btn-det-cal-edita" onclick="seleccionDetalleCalPrecio();" style="display:inline-block;" class="ui-icon ui-icon-transferthick-e-w"></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                <%--</asp:Panel>--%>
            </div>

            <div id="tab-costo">
                <asp:UpdatePanel ID="panelTransCom" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>        
        
                        <%--TRANSPORTE --%>
                        <fieldset style="width: 20%; padding-left:13px; padding-right:13px;">
                            <legend>Transporte</legend>
                            <table align="center" style="font-size:small;">
                                <tr>
                                    <td>Transporte</td>
                                    <td></td>
                                    <td>
                                        <input type="checkbox" id="chkTransporte" />                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>Region</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="cboRegion" runat="server" Width="200px" CssClass="_cboRegion_"
                                            oninit="cboRegion_Init">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>Dirección</td>
                                    <td></td>
                                    <td>
                                        <input type="text" id="txtDirTransporte" name="txtDirTransporte" style="width:200px;" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>Traslado</td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="cboTraslado" runat="server" Width="150px" CssClass="_cboTraslado_"
                                            oninit="cboTraslado_Init">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Total</td>
                                    <td></td>
                                    <td>
                                        <input type="text" id="txtTotalTransporte" name="txtTotalTransporte" readonly="readonly" style="width:100px; text-align:right;" value="0" />
                                        <%--<asp:TextBox ID="TextBox21" runat="server" style="text-align: right;" ReadOnly="true" Width="100px">0</asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>                
                                    <td colspan="3" style="text-align:center;">
                                        <%--<asp:Button ID="Button2" runat="server" Text="Distribuir Precio" />--%>
                                        <input type="button" id="btnAddTransporte" value="Distribuir Precio" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                        <%--COMISION --%>
                        <fieldset style="width: 60%;">
                            <legend>Costo Comision</legend>
                            <table align="center" style="font-size:small;">
                                <tr>
                                    <td>Cantidad Personas</td>
                                    <td>                                        
                                        <input type="number" id="txt-com-qty-persona" name="txt-com-qty-persona" style="text-align:right; width:40px;" value="0" />
                                    </td>
                                    <td>Lugar</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="cboLugarComision" runat="server" Width="200px" CssClass="_cboLugarComision_"
                                            oninit="cboLugarComision_Init">
                                        </asp:DropDownList>
                                    </td>                
                                </tr>
                                <tr>
                                    <td>Cantidad Dias</td>
                                    <td>                                        
                                        <input type="number" id="txt-com-qty-dia" name="txt-com-qty-dia" style="text-align:right; width:40px;" value="0" />
                                    </td>
                                    <td>Transporte DTS</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-trans-dts" name="txt-com-trans-dts" readonly="readonly"/>
                                    </td>
                                    <td>Hotel</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-hotel" name="txt-com-hotel" readonly="readonly"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cantidad Vehiculo</td>
                                    <td>
                                        <input type="number" style="text-align:right; width:40px;" value="0" id="txt-com-qty-veh" name="txt-com-qty-veh" />
                                    </td>
                                    <td>Transporte Hotel</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-trans-hotel" name="txt-com-trans-hotel" readonly="readonly"/>
                                    </td>
                                    <td>Fondo a Rendir</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-fondo-rend" name="txt-com-fondo-rend" readonly="readonly"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Traslado Eq/Doc Ciudad</td>
                                    <td>
                                        <input type="number" style="text-align:right; width:40px;" value="0" id="txt-com-eq-c" name="txt-com-eq-c" />
                                    </td>
                                    <td>Transporte Avion Persona</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-trans-av-per" name="txt-com-trans-av-per" readonly="readonly"/>
                                    </td>
                                    <td>Gasto Repr.</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-gasto-rep" name="txt-com-gasto-rep" readonly="readonly"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Traslado Eq/Doc Avion</td>
                                    <td>
                                        <input type="number" style="text-align:right; width:40px;" value="0" id="txt-com-eq-a" name="txt-com-eq-a" />
                                    </td>
                                    <td>Arriendo Vehiculo</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-arr-veh" name="txt-com-arr-veh" readonly="readonly"/>
                                    </td>
                                    <td>Total Costo Com.</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-tot-cos-com" name="txt-com-tot-cos-com" readonly="readonly"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Fondo a Rendir</td>
                                    <td>
                                        <input type="number" style="text-align:right; width:40px;" value="0" id="txt-com-fondo-rendir" name="txt-com-fondo-rendir" />
                                    </td>
                                    <td>Traslado Eq/Doc Ciudad</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-tras-eq-c" name="txt-com-tras-eq-c" readonly="readonly"/>
                                    </td>
                                    <td>Total Precio Com.</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-tot-p-com" name="txt-com-tot-p-com" readonly="readonly"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Gastos Representacion</td>
                                    <td>
                                        <input type="number" style="text-align:right; width:40px;" value="0" id="txt-com-rep-gasto" name="txt-com-rep-gasto" />
                                    </td>
                                    <td>Traslado Eq/Doc Avion</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-tras-eq-a" name="txt-com-tras-eq-a" readonly="readonly"/>
                                    </td>
                                    <td colspan="2" rowspan="2" style="text-align:center;">                                        
                                        <input type="button" id="btnAddComision" value="Cargar Comision" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Cantidad Com 1 Mes</td>                
                                    <td>
                                        <input type="number" style="text-align:right; width:40px;" value="0" id="txt-com-qty-com-mes" name="txt-com-qty-com-mes" />
                                    </td>
                                    <td>Viatico</td>
                                    <td>
                                        <input type="text" style="text-align:right; width:90px;" value="0" id="txt-com-viatico" name="txt-com-viatico" readonly="readonly"/>
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
                        <fieldset style="width:25%;" class="inline">
                            <legend>Margenes Comerciales</legend>
                            <table align="center" style="font-size:small;">
                                <tr>
                                    <td>
                                        Total Costo MO
                                    </td>
                                    <td>
                                        <input type="text" id="txtTotalCostoMo" name="txtTotalCostoMo" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Total Costo Rpto
                                    </td>
                                    <td>
                                        <input type="text" id="txtTotalCostoRpto" name="txtTotalCostoRpto" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mg Operacional %
                                    </td>
                                    <td>
                                        <input type="text" id="txtMgOpPorc" name="txtMgOpPorc" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight:bold;">
                                        Mg Bruto %
                                    </td>
                                    <td>
                                        <input type="text" id="txtMgBrutoPorc" name="txtMgBrutoPorc" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mg Contribucion
                                    </td>
                                    <td>
                                        <input type="text" id="txtMgContribucion" name="txtMgContribucion" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mg Contribucion %
                                    </td>
                                    <td>
                                        <input type="text" id="txtMgContribucionPorc" name="txtMgContribucionPorc" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Utilidad Esperada %
                                    </td>
                                    <td>
                                        <input type="text" id="txtUtilidadEspPorc" name="txtUtilidadEspPorc" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                        <fieldset style="width:25%;" class="inline">
                            <legend>Impuesto</legend>
                            <table align="center" style="font-size:small;">
                                <tr>
                                    <td>
                                        Impuesto
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboTipoImpuesto" runat="server" CssClass="_cboTipoImpuesto_">
                                            <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                            <asp:ListItem Value="1">c/ IVA</asp:ListItem>
                                            <asp:ListItem Value="2">s/ IVA</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descuento
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkDcto" CssClass="_chkDcto_" runat="server"/>
                                        <asp:CheckBox ID="chkExcede" CssClass="_chkExcede_" style="display:none;" runat="server"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Moneda
                                    </td>
                                    <td>
                                        <input type="text" id="txtTipoMoneda" name="txtTipoMoneda" readonly="readonly"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:center;">
                                        <input type="button" id="btnCalcularTotal" value="Calcular" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>

                        <fieldset style="width:15%;" class="inline">
                            <legend>Precio Total</legend>
                            <table align="center" style="font-size:small;">
                                <tr>
                                    <td>
                                        Neto
                                    </td>
                                    <td>
                                        <input type="text" id="txtNeto" name="txtNeto" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Dcto %
                                    </td>
                                    <td>
                                        <input type="text" id="txtDctoPorc" name="txtDctoPorc" value="0" style="text-align:right; width:100px;" disabled="disabled"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Descuento
                                    </td>
                                    <td>
                                        <input type="text" id="txtDcto" name="txtDcto" value="0" style="text-align:right; width:100px;" disabled="disabled"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Neto Dcto
                                    </td>
                                    <td>
                                        <input type="text" id="txtNetoDcto" name="txtNetoDcto" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        IVA
                                    </td>
                                    <td>
                                        <input type="text" id="txtIva" name="txtIva" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Total
                                    </td>
                                    <td>
                                        <input type="text" id="txtTotal" name="txtTotal" value="0" readonly="readonly" style="text-align:right; width:100px;"/>
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
                                    <asp:TextBox ID="txtNotaUno" CssClass="_txtNotaUno_" runat="server" TextMode="MultiLine" Width="625px" Height="50px" onKeyPress="return taLimit(this)" onKeyUp="return taCount(this,'myCounter')">Sin Nota</asp:TextBox>                
                                </td>
                                <td>
                                    Caracteres restantes: <span id="myCounter">400</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Nota 2:</td>
                                <td>
                                    <asp:TextBox ID="txtNotaDos" CssClass="_txtNotaDos_" runat="server" TextMode="MultiLine" Width="625px" Height="50px" onKeyPress="return taLimit(this)" onKeyUp="return taCount(this,'myCounterDos')">Sin Nota</asp:TextBox>
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
                                    <asp:DropDownList ID="cboFacturacion" runat="server" CssClass="_cboFacturacion_"
                                        Width="140px" oninit="cboFacturacion_Init"> 
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td class="style12">Comentario Facturacion<br />
                                    <asp:TextBox ID="txtFacturacion" runat="server" Height="50px" CssClass="_txtFacturacion_"
                                        TextMode="MultiLine" Width="421px" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:90px;">
                                    Forma Pago Facturación
                                    <br />
                                    <asp:DropDownList ID="cboFormaPago" runat="server" Width="140px" CssClass="_cboFormaPago_"
                                        oninit="cboFormaPago_Init">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td class="style12">Comentario Forma Pago Facturacion<br />
                                    <asp:TextBox ID="txtFormaPago" runat="server" Height="50px" CssClass="_txtFormaPago_"
                                        TextMode="MultiLine" Width="422px">a contar de la fecha de facturación</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:90px;">
                                    Plazo Entrega<br />
                                    <%--<asp:DropDownList ID="cboPlazoEntrega" runat="server" Width="140px" 
                                        oninit="cboPlazoEntrega_Init">
                                    </asp:DropDownList>--%>
                                    <input type="text" id="txtPlazoEntregaD" name="txtPlazoEntregaD" placeholder="Plazo entrega dias" pattern="^\d+$" style="width:140px;"/>
                                </td>
                                <td>
                                </td>
                                <td class="style12">Comentario Plazo Entrega<br />
                                    <asp:TextBox ID="txtPlazoEntrega" runat="server" Height="50px" CssClass="_txtPlazoEntrega_"
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
                                <asp:DropDownList ID="cboTextCotEx" runat="server" CssClass="_cboTextCotEx_">
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
                                <asp:DropDownList ID="cboEjecTrab" runat="server" oninit="cboEjecTrab_Init" CssClass="_cboEjecTrab_">
                                </asp:DropDownList>                                           
                            </td>
                        </tr>
                        <tr>
                            <td>Lugar de Retiro</td>
                            <td>
                                <asp:DropDownList ID="cboLugarRetiro" runat="server" OnInit="cboLugarRetiro_Init" CssClass="_cboLugarRetiro_">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                Sector Retiro
                                <asp:TextBox ID="txtSectorRetiro" runat="server" Width="200px" CssClass="_txtSectorRetiro_"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                Nombre Responsable
                                <asp:TextBox ID="txtSectorRetiroNom" runat="server" Width="200px" CssClass="_txtSectorRetiroNom_"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Lugar de Entrega</td>
                            <td>
                                <asp:DropDownList ID="cboLugarEntrega" runat="server" CssClass="_cboLugarEntrega_"
                                    oninit="cboLugarEntrega_Init">
                                </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp; Sector Entrega
                                <asp:TextBox ID="txtSectorEntrega" runat="server" Width="400px" CssClass="_txtSectorEntrega_"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Validez Oferta</td>
                            <td>
                                <asp:TextBox ID="txtValidezOferta" runat="server" style="text-align:center;" ReadOnly="true" CssClass="_txtValidezOferta_"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtValidezOferta" FirstDayOfWeek="Monday" Format="dd/MM/yyyy" BehaviorID="nuevaFechaVence">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>Garantia</td>
                            <td>
                                <asp:DropDownList ID="cboGarantia" runat="server" oninit="cboGarantia_Init" CssClass="_cboGarantia_">
                                </asp:DropDownList>

                            &nbsp;&nbsp;&nbsp;&nbsp; Validez Garantia

                                <asp:DropDownList ID="cboValidezGar" runat="server" oninit="cboValidezGar_Init" CssClass="_cboValidezGar_">
                                </asp:DropDownList>            
                            </td>
                        </tr>
                        <tr>
                            <td>Aceptador por</td>
                            <td>
                                <asp:DropDownList ID="cboJefe" runat="server" CssClass="_cboJefe_"
                                    oninit="cboJefe_Init"> <%--onselectedindexchanged="cboJefe_SelectedIndexChanged"--%>
                                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                                Mail&nbsp;<asp:TextBox ID="txtMailJefe" runat="server" ReadOnly="True" CssClass="_txtMailJefe_"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                Cargo&nbsp;<asp:TextBox ID="txtCargoJefe" runat="server" Width="250px" CssClass="_txtCargoJefe_"
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        </table>                    
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="tab-adjunto">
                <asp:UpdatePanel ID="upBtnAdjDoc" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <script type="text/javascript">
                            Sys.Application.add_load(agregarArchivo);
                        </script>

                        <input type="button" id="btn-doc" name="btn-doc" value="Adjuntar Documento" />
                    </ContentTemplate>
                </asp:UpdatePanel>                
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

    <%--DIV PARA ELIMINAR EL ARCHIVO SELECCIONADO --%>
    <div id="dialog-archivo" title="Quitar Archivo" style="display:none;">
        Esta seguro que desea quitar el archivo?
        <br /><br />
        <input type="button" id="btn-del-archivo" name="btn-del-archivo" value="Eliminar" />
    </div>
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
    <br /><br />
    <table cellpadding="5px">
        <tr>
            <td>
                <%--<asp:Button ID="btnSave" runat="server" 
                Text="Guardar" Width="130px"/>--%>                
                <input type="button" id="btnGuardaCoti" value="Guardar Cotizacion" onclick="insCotizacion();" />
                <%--<input type="button" id="btnTestPrint" value="Imprimir" onclick="imprimeCotizacion();"/>--%>
            </td>
            <%--<td>
                <asp:Button ID="btnSaveDraft" runat="server" Text="Guardar Borrador" style="display:none;"/>
            </td>
            <td>
                <asp:Button ID="btnSavePrint" runat="server" Text="Guardar e Imprimir"/>
            </td>    --%>        
            <td>
                
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
                <tr style="display:none;">
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

                        <asp:TemplateField HeaderText="Peso" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblequipopeso" CssClass="eqpeso_" runat="server" Text='<%# Bind("EQUIPOCALPESO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PMO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblequipopmo" CssClass="eqpmo_" runat="server" Text='<%# Bind("EQUIPOPMO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CREP" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblcostorep" CssClass="eqcrep_" runat="server" Text='<%# Bind("EQUIPOCOSTOREP") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CMO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lblcostomo" CssClass="eqcmo_" runat="server" Text='<%# Bind("EQUIPOCMO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TTO" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="lbltarifaorig" CssClass="eqtto_" runat="server" Text='<%# Bind("EQUIPOTARIFAORIG") %>'></asp:Label>
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
    <asp:UpdatePanel ID="upActualizaGVPunto" runat="server" UpdateMode="Conditional" style="display:none;">
        <ContentTemplate>
            <asp:Button ID="btnActualizaGVPunto" runat="server" OnClick="btnActualizaGVPunto_Click" />
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
            <tr style="display:none;">
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
            <tr style="display:none;"><!--OCULTAR-->
                <td>Costo Rpto</td>
                <td><input type="text" id="txt-eq-read-crpto" name="txt-eq-read-crpto" class="text ui-widget-content ui-corner-all" value="0" /></td>
            </tr>
            <tr style="display:none;"><!--OCULTAR-->
                <td>Costo MO</td>
                <td><input type="text" id="txt-eq-read-cmo" name="txt-eq-read-cmo" class="text ui-widget-content ui-corner-all" value="0" /></td>
            </tr>
            <tr style="display:none;"><!--OCULTAR-->
                <td>Tarifa Original</td>
                <td><input type="text" id="txt-eq-read-tto" name="txt-eq-read-tto" class="text ui-widget-content ui-corner-all" value="0" /></td>
            </tr>
            <tr>
                <td>Gastos</td>
                <td><input type="number" id="txt-eq-read-gasto" name="txt-eq-read-gasto" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr>
                <td>Precio Carga</td>
                <td><input type="number" id="txt-eq-read-pcarga" name="txt-eq-read-pcarga" readonly="readonly" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr>
                <td>Precio Venta</td>
                <td><input type="text" id="txt-eq-read-pventa" name="txt-eq-read-pventa" readonly="readonly" class="text ui-widget-content ui-corner-all" value="0"/></td>
            </tr>
            <tr style="display:none;">
                <td>Peso</td>
                <td><input type="text" id="txt-eq-read-peso" name="txt-eq-read-peso" readonly="readonly" class="text ui-widget-content ui-corner-all" value="0" /></td>
            </tr>
            <tr>
                <td>Estado</td>
                <td>
                    <asp:DropDownList ID="cbo_eq_read_estado" runat="server" OnInit="cbo_eq_read_estado_Init">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Nota de Pedido</td>
                <td><input type="text" id="txt-eq-read-notap" name="txt-eq-read-notap" class="text ui-widget-content ui-corner-all" placeholder="Solo si posee NP"/></td>
            </tr>
            <tr>
                <td>Linea Prod</td>
                <td>
                    <asp:DropDownList ID="cbo_eq_read_lprod" runat="server" OnInit="cbo_eq_read_lprod_Init" CssClass="_cboeqreadlprod_">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>O Compra</td>
                <td><input type="text" id="txt-eq-read-oc" name="txt-eq-read-oc" class="text ui-widget-content ui-corner-all"  placeholder="Solo si posee OC"/></td>
            </tr>
            <tr>
                <td>SAOT</td>
                <td><input type="text" id="txt-eq-read-saot" name="txt-eq-read-saot" class="text ui-widget-content ui-corner-all"  placeholder="Solo si posee SAOT"/></td>
            </tr>
            <tr>
                <td>Puntos Calibracion</td>
                <td>
                    <%--<input type="text" id="txt-eq-read-puntos" name="txt-eq-read-puntos" class="text ui-widget-content ui-corner-all"  placeholder="Solo si posee"/>--%>
                    <a href="javascript:void(null);" id="btn-select-equ" onclick="dialogPunto();" style="display:inline-block;" class="ui-icon 	ui-icon-circle-plus"></a>
                </td>
            </tr>
        </table>
    </div>
    <%-- DIV PARA AGREGAR PUNTOS AL EQUIPO SELECCIONADO --%>
    <div id="dialog-equipo-punto" title="Puntos a Cotizar" style="display:none;">
        Puntos del equipo a cotizar
        <br /><br />
        <input type="text" id="txt_in_punto_eq_id" name="txt_in_punto_eq_id" style="display:none;"/>
        <input type="text" id="txt_in_punto_eq_cot" name="txt_in_punto_eq_cot" style="display:none;"/>
        <input type="text" id="txt_in_punto_eq_item" name="txt_in_punto_eq_item" style="display:none;"/>
        Magnitud:<br />
        <asp:DropDownList ID="cbo_magnitud" runat="server" OnInit="cbo_punto_magnitud_Init">
        </asp:DropDownList>
        <br /><br />
        Funcion:<br />
        <select id="cbo_funcion" name="cbo_funcion"></select>
        <br /><br />
        Puntos:<br />
        <input type="text" id="txt-in-punto-cal" name="txt-in-punto-cal" placeholder="Ingrese puntos" />
        <br /><br />
        Comentario:<br />
        <asp:TextBox ID="txt_in_punto_coment" CssClass="_txt_in_punto_coment_" TextMode="MultiLine" Height="68px" Width="260px" runat="server">Ingrese algun comentario</asp:TextBox>        
        <br /><br />
        <input type="button" id="btn-in-punto-cal" name="btn-in-punto-cal" value="Ingresar" />
        <input type="button" id="btn-ed-punto-cal" name="btn-ed-punto-cal" value="Agregar" />
        <br /><br />
        <asp:UpdatePanel ID="upListaPunto" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvListaPunto" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="cp_id,cp_numero,cp_item,cp_id_equipo" PageSize="5" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="Primera" PagerSettings-LastPageText="Ultima" 
                    AllowPaging="true" Font-Size="Small" OnPageIndexChanging="gvListaPunto_PageIndexChanging">
                    <RowStyle CssClass="gvListaPuntocss" />
                    <Columns>
                
                        <asp:TemplateField HeaderText="Item">
                            <ItemTemplate>
                                <asp:Label ID="cp_id" CssClass="cp_id_" runat="server" Text='<%# Bind("CP_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <asp:Label ID="cp_no_esp" CssClass="cp_no_esp_" runat="server" Text='<%# Bind("CP_NO_ESP") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Especialidad" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_id_esp" CssClass="cp_id_esp_" runat="server" Text='<%# Bind("CP_ID_ESP") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Magnitud">
                            <ItemTemplate>
                                <asp:Label ID="cp_no_mag" CssClass="cp_no_mag_" runat="server" Text='<%# Bind("CP_NO_MAG") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Magnitud" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_id_mag" CssClass="cp_id_mag_" runat="server" Text='<%# Bind("CP_ID_MAG") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Puntos">
                            <ItemTemplate>
                                <asp:Label ID="cp_punto" CssClass="cp_punto_" runat="server" Text='<%# Bind("CP_PUNTO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Id Cotizacion" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_cot_id" CssClass="cp_cot_id_" runat="server" Text='<%# Bind("CP_DCOT_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Id Cotizacion" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_numero" CssClass="cp_numero_" runat="server" Text='<%# Bind("CP_NUMERO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Id Cotizacion" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_item" CssClass="cp_item_" runat="server" Text='<%# Bind("CP_ITEM") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comentario" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_comentario" CssClass="cp_comentario_" runat="server" Text='<%# Bind("CP_COMENTARIO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Id Cotizacion" HeaderStyle-CssClass="ocultaCol" ItemStyle-CssClass="ocultaCol">
                            <ItemTemplate>
                                <asp:Label ID="cp_id_equipo" CssClass="cp_id_equipo_" runat="server" Text='<%# Bind("CP_ID_EQUIPO") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <a href="javascript:void(null);" id="btn-det-cal-edita-punto" onclick="editaPuntoDet();" class="ui-icon ui-icon-transferthick-e-w"></a>                                
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <a href="javascript:void(null);" id="btn-det-cal-edita-punto-gv" onclick="editaPuntoDetGv();" class="ui-icon ui-icon-transferthick-e-w"></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>    
            </ContentTemplate>
        </asp:UpdatePanel>       
        
    </div>
    <div id="dialog-equipo-dato-cal"  title="Otros Datos Equipo" style="display:none;">
        <div id="tab-equipo-dato-cal">
            <ul>
                <li><a href="#tab-equipo-dato-cal-otro">Editar Otros</a></li>
                <li><a href="#tab-equipo-dato-cal-ptos">Editar Puntos</a></li>
            </ul>

            <div id="tab-equipo-dato-cal-otro">
                <table>
                    <tr>
                        <td>
                            Tipo Trabajo
                        </td>
                        <td>
                            <asp:DropDownList ID="cbo_eq_dato_cal_tt" runat="server" oninit="cbo_eq_dato_cal_tt_Init">
                            </asp:DropDownList>                    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Estado
                        </td>
                        <td>
                            <asp:DropDownList ID="cbo_eq_dato_cal_est" runat="server" OnInit="cbo_eq_dato_cal_est_Init">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nota Pedido
                        </td>
                        <td>
                            <input type="text" id="txt-eq-dato-cal-np" name="txt-eq-dato-cal-np" class="text ui-widget-content ui-corner-all" placeholder="Solo si posee NP"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Line Producto
                        </td>
                        <td>
                            <asp:DropDownList ID="cbo_eq_dato_cal_lp" runat="server" OnInit="cbo_eq_dato_cal_lp_Init">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Orden Compra
                        </td>
                        <td>
                            <input type="text" id="txt-eq-dato-cal-oc" name="txt-eq-dato-cal-oc" class="text ui-widget-content ui-corner-all" placeholder="Solo si posee OC"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            SAOT
                        </td>
                        <td>
                            <input type="text" id="txt-eq-dato-cal-saot" name="txt-eq-dato-cal-saot" class="text ui-widget-content ui-corner-all" placeholder="Solo si posee SAOT"/>
                        </td>
                    </tr>
                </table>
            </div>

            <div id="tab-equipo-dato-cal-ptos">
                <a href="javascript:void(null);" id="btn-muestra-edit-ptos" onclick="muestraEditPuntos();">Editar Puntos</a>
            </div>
        </div>        
    </div>

    <%--DIALOG PARA EDITAR PRECIOS O ELIMINAR EQUIPO SELECCIONADO DEL GRIDVIEW --%>
    <div id="dialog-tab-edit-eq" title="Edicion Equipo" style="display:none;">
        <div id="tab-edit-eq">
            <ul>
                <li><a href="#tab-edit-eq-valor">Editar Precios</a></li>
                <li><a href="#tab-edit-eq-delete">Eliminar Equipo</a></li>
            </ul>

            <div id="tab-edit-eq-valor">
                <form action="" id="frm-edit-eq-valor">
                    <table>
                        <tr>
                            <td>Item</td>
                            <td><input type="text" id="edit_eq_item" name="edit-eq-item" class="text ui-widget-content ui-corner-all" readonly="readonly"/></td>
                        </tr>
                        <tr style="display:none;">
                            <td>Id Equipo</td>
                            <td><input type="text" id="edit_eq_id_eq" name="edit-eq-id-eq" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr style="display:none;">
                            <td>Id Coti</td>
                            <td><input type="text" id="edit_eq_id_cot" name="edit-eq-id-cot" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr>
                            <td>Nro Parte</td>
                            <td><input type="text" id="edit_eq_nparte" name="edit-eq-nparte" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr>
                            <td>Nro Serie</td>
                            <td><input type="text" id="edit_eq_nserie" name="edit-eq-nserie" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr>
                            <td>Cantidad</td>
                            <td><input type="number" id="edit_eq_qty" name="edit-eq-qty" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr style="display:none;">
                            <td>Costo MO</td>
                            <td><input type="text" id="edit_eq_cmo" name="edit-eq-cmo" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr>
                            <td>Precio MO</td>
                            <td><input type="number" id="edit_eq_pmo" name="edit-eq-pmo" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr style="display:none;">
                            <td>Costo Rpto</td>
                            <td><input type="text" id="edit_eq_crep" name="edit-eq-crep" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr style="display:none;">
                            <td>T Original</td>
                            <td><input type="text" id="edit_eq_torig" name="edit-eq-torig" class="text ui-widget-content ui-corner-all"/></td>
                        </tr>
                        <tr>
                            <td>Gastos</td>
                            <td>
                                <input type="number" id="edit_eq_gasto" name="edit-eq-gasto" class="text ui-widget-content ui-corner-all"/>
                                <input type="number" id="edit_eq_gasto_h" name="edit-eq-gasto-h" class="text ui-widget-content ui-corner-all" style="display:none;"/>
                            </td>
                        </tr>
                        <tr>
                            <td>Precio Carga</td>
                            <td><input type="text" id="edit_eq_pcarga" name="edit-eq-pcarga" class="text ui-widget-content ui-corner-all" readonly="readonly"/></td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td><input type="text" id="edit_eq_total" name="edit-eq-total" class="text ui-widget-content ui-corner-all" readonly="readonly"/></td>
                        </tr>
                    </table>
                </form>                
            </div>

            <div id="tab-edit-eq-delete">
                Esta seguro que desea borrar el equipo seleccionado?
                <br /><br />
                <input type="button" id="btn_edit_eq_del" value="Eliminar Equipo" />
            </div>

        </div>
    </div>

    <%--DIALOG QUE EDITA LOS PUNTOS DEL GRID YA INGRESADOS --%>
    <div id="dialog-edit-punto-grid" title="Editar Puntos Ingresados" style="display:none;">
        <div id="tab-edit-punto">
            <ul>
                <li><a href="#tab-editar-punto">Editar Punto</a></li>
                <li><a href="#tab-delete-punto">Borrar Punto</a></li>
            </ul>

            <div id="tab-editar-punto">
                <table>
                    <tr>
                        <td>Item</td>
                        <td>
                            <input type="text" id="txt-edit-punto-item-gv" value="" class="text ui-widget-content ui-corner-all" readonly="readonly"/>
                            <input type="text" id="txt-edit-punto-dccid-gv" value="" style="display:none;" />
                        </td>
                    </tr>
                    <tr>
                        <td>Magnitud</td>
                        <td>
                            <input type="text" id="txt-edit-punto-esp-gv" value="" class="text ui-widget-content ui-corner-all" readonly="readonly"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Funcion</td>
                        <td>
                            <input type="text" id="txt-edit-punto-mag-gv" value="" class="text ui-widget-content ui-corner-all" readonly="readonly"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Puntos</td>
                        <td>
                            <input type="text" id="txt-edit-punto-lista-gv" value="" class="text ui-widget-content ui-corner-all"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Comentario</td>
                        <td>
                            <asp:TextBox ID="txt_edit_punto_coment" CssClass="_txt_edit_punto_coment_" TextMode="MultiLine" Height="68px" Width="260px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br /><br />
                <input type="button" id="btn-edit-punto-upd-gv" value="Actualizar" />
            </div>
            
            <div id="tab-delete-punto">
                Esta seguro que desea borrar estos puntos?
                <br /><br />
                <input type="button" id="btn-edit-punto-del-gv" value="Eliminar Punto" />

            </div>
        </div>
    </div>
    
      <%--SECTOR DE JAVASCRIPT--%>
        <script type="text/javascript">
            $.cookie('nomclient', '');
            $.cookie('nomcuenta', '');
            $.cookie('nomcontact', '');
            $.cookie('nomtipo', '');
            $.cookie('nomestado', '');            
            var objEqJs = new EquipoCotizacion();
            var objComCot = new ComisionCotizacion();
            var objInfoCot = new InfoCotizacion();

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

            /*DOCUMENT READY*/
            $(document).ready(function () {
                $(".td").css("text-align", "left");
                $(".td").css("font-weight", "bold");
                cambiaAjaxUploader();
                $("#<%=cbo_eq_dato_cal_tt.ClientID %>").prop("disabled", true);
                $("#btnAddComision").attr('disabled', 'disabled');
                transporteVal();
                bloqueaCampoComision();
                $("#btn-ed-punto-cal").toggle(false);
                //$("#btn-det-cal-edita-punto-gv").toggle(false);
                $('._cboJefe_').val("2");
                getDatoAceptadoPor("2");
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
                    $("#<%=txtIdCliente.ClientID %>").val($('.idcliente_', $(this).closest('tr')).html()); //$('.idcliente_', find('td:first').text()                   
                    $("#<%=txtCliente.ClientID %>").val($('.nomcliente_', $(this).closest('tr')).html());
                    $("#<%=txtCuenta.ClientID %>").val($('.nomcuenta_', $(this).closest('tr')).html());
                    $("#<%=txtClienteInforme.ClientID %>").val($('.nomcuenta_', $(this).closest('tr')).html());
                    $("#<%=txtContactoCliente.ClientID %>").val($('.nomcontacto_', $(this).closest('tr')).html());
                    $("#<%=txtDireccionCliente.ClientID %>").val($('.direccioncli_', $(this).closest('tr')).html());
                    $("#<%=txtClienteCertificado.ClientID %>").val($('.direccioncli_', $(this).closest('tr')).html());
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
                    $.cookie('idequipocot', $('.eqid_', $(this).closest('tr')).html());
                    getValorEquipo_Cal($('.eqid_', $(this).closest('tr')).html(), $("#<%=cboTipoTarifa.ClientID %>").val(), $("#<%=txtFecha.ClientID %>").val());
                });
            }

            var dgcItem = "";
            var dgcEquId = "";
            var dgcItemCal = "";
            function dataGridCal() {
                $('.cssDetEq').on('click', function () {
                    dgcEquId = $('.equipoid_', $(this).closest('tr')).html();
                    dgcItem = $('.equipoitem_', $(this).closest('tr')).html();
                    dgcItemCal = $('.equipocalid_', $(this).closest('tr')).html();
                    $("#<%=cbo_eq_dato_cal_tt.ClientID %>").val($('.equipotrabajoid_', $(this).closest('tr')).html());
                    $("#<%=cbo_eq_dato_cal_est.ClientID %>").val($('.equipodet_idn_', $(this).closest('tr')).html());
                    $("#<%=cbo_eq_dato_cal_lp.ClientID %>").val($('.equipolp_idn_', $(this).closest('tr')).html());
                    $("#txt-eq-dato-cal-np").val($('.equipocalnp_', $(this).closest('tr')).html());
                    $("#txt-eq-dato-cal-oc").val($('.equipocaloc_', $(this).closest('tr')).html());
                    $("#txt-eq-dato-cal-saot").val($('.equipocalsaot_', $(this).closest('tr')).html());
                });
            }

            function dataGridCalPrecio() {
                $('.cssDetEq').on('click', function () {
                    $("#edit_eq_item").val($('.equipoitem_', $(this).closest('tr')).html());
                    $("#edit_eq_id_eq").val($('.equipoid_', $(this).closest('tr')).html());
                    $("#edit_eq_id_cot").val($('.equipocotid_', $(this).closest('tr')).html());
                    $("#edit_eq_nparte").val($('.equiponparte_', $(this).closest('tr')).html());
                    $("#edit_eq_nserie").val($('.equiponserie_', $(this).closest('tr')).html());
                    $("#edit_eq_qty").val($('.equipocantidad_', $(this).closest('tr')).html());                    
                    $("#edit_eq_pmo").val($('.equipopmo_', $(this).closest('tr')).html());
                    $("#edit_eq_gasto").val($('.equipocalgasto_', $(this).closest('tr')).html());
                    $("#edit_eq_gasto_h").val($('.equipocalgasto_', $(this).closest('tr')).html());
                    $("#edit_eq_pcarga").val($('.equipocalpcarga_', $(this).closest('tr')).html());
                    $("#edit_eq_total").val($('.equipototal_', $(this).closest('tr')).html());

                    getValoresEquipoEdit($('.equipoid_', $(this).closest('tr')).html(),
                                         $("#<%=cboTipoTarifa.ClientID %>").val(),
                                         $("#<%=txtFecha.ClientID %>").val());
                });
            }

            var dgpEditIdEq = "";
            function dataGridPunto() {
                $('.gvListaPuntocss').on('click', function () {
                    $("#txt-edit-punto-item-gv").val($('.cp_id_', $(this).closest('tr')).html());
                    $("#txt-edit-punto-dccid-gv").val($('.cp_cot_id_', $(this).closest('tr')).html());
                    $("#txt-edit-punto-esp-gv").val($('.cp_no_esp_', $(this).closest('tr')).html());
                    $("#txt-edit-punto-mag-gv").val($('.cp_no_mag_', $(this).closest('tr')).html());
                    $("#txt-edit-punto-lista-gv").val($('.cp_punto_', $(this).closest('tr')).html());
                    $('._txt_edit_punto_coment_').val($('.cp_comentario_', $(this).closest('tr')).html());
                    dgpEditIdEq = $('.cp_id_equipo_', $(this).closest('tr')).html();
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

            //FUNCION QUE MUESTRA EL CUADRO DONDE SE INGRESAN LOS DATOS DEL EQUIPO FE: PRECIO PUNTOS NP OC ETC
            function seleccionEquipo() {
                dataEquipo();
                $("#dialog-equipo-busca").dialog('close');
                $("#<%=cbo_eq_read_trabajo.ClientID %>").val("8");
                $("#<%=cbo_eq_read_estado.ClientID %>").val("1");
                $("#dialog-equipo-precio").dialog({
                    modal: true,
                    width: "500px",
                    buttons: {
                        "Calcular": function () {
                            objEqJs.equipoid = $("#txt-eq-read-id").val();
                            objEqJs.equipocantidad = $("#txt-eq-read-qty").val();
                            objEqJs.equipopmo = $("#txt-eq-read-pmo").val();
                            objEqJs.equipocalgasto = $("#txt-eq-read-gasto").val();
                            objEqJs.equipocalpcarga = $("#txt-eq-read-pcarga").val();
                            equipoCal_Total(objEqJs, "2", $("#<%=cboTipoTarifa.ClientID %>").val(), $("#<%=txtFecha.ClientID %>").val());
                        },
                        "Agregar": function () {
                            //$(this).dialog('close');
                            if (!validaNparteNserie()) {
                                if (!validaIngresoDetEquipo()) {
                                    setEquipoCal();
                                    equipoCal_Guarda(objEqJs);
                                    limpiaEquipoDialog();
                                    $("#<%=cbo_eq_read_lprod.ClientID %>").val("N");
                                    $("#<%= cbo_eq_read_estado.ClientID %>").val("1");
                                    $("#<%=cbo_eq_read_trabajo.ClientID %>").val("8");
                                    $("#<%=btnUpdDatoEquipo.ClientID %>").click();
                                    $(this).dialog('close');
                                } else {
                                    alert("El equipo que esta ingresando ya existe en el detalle verifique el Nro de Parte que esta tratando de ingresar");
                                }
                            } else {
                                alert("El numero de parte, numero de serie o linea de producto no puede quedar en blanco");
                            }
                        },
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            }

            /*****************/
            /*****************/
            function seleccionDetalleCal() {
                dataGridCal();
                dataGridPunto();
                $("#dialog-equipo-dato-cal").dialog({
                    modal: true,
                    width: "500px",
                    buttons: {
                        "Actualizar": function () {
                            modValoresDetCalProd(dgcItem,
                                                 $.cookie('pcusr'),
                                                 $("#txt-eq-dato-cal-np").val(),
                                                 $("#txt-eq-dato-cal-oc").val(),
                                                 $("#txt-eq-dato-cal-saot").val(),
                                                 $("#<%=cbo_eq_dato_cal_lp.ClientID %>").val(),
                                                 $("#<%=cbo_eq_dato_cal_est.ClientID %>").val());
                            $("#<%=btnUpdDatoEquipo.ClientID %>").click();
                        },
                        "Cerrar": function () {
                            $(this).dialog('close');
                        }
                    }
                });
            }

            function muestraEditPuntos() {
                $.cookie('flag_inpunto', '2');
                $("#btn-in-punto-cal").toggle(false);                
                $("#btn-ed-punto-cal").toggle(true);                
                $.cookie('idequipocot', dgcEquId);
                $.cookie('iditemeq', dgcItem);
                $("#<%=btnActualizaGVPunto.ClientID %>").click();
                dialogPuntoEdit();
            }
            /*****************/
            /*****************/

            var oldGasto = "";
            function seleccionDetalleCalPrecio() {
                dataGridCalPrecio();

                $("#dialog-tab-edit-eq").dialog({
                    modal: true,
                    width: "500px",
                    buttons: {
                        "Calcular": function () {
                            validaPrecioGastoChange($("#edit_eq_gasto_h").val(), $("#edit_eq_gasto").val());
                            validaPrecioMOChange();
                            objEqJs.equipoid = $("#edit_eq_id_eq").val();
                            objEqJs.equipocantidad = $("#edit_eq_qty").val();
                            objEqJs.equipopmo = $("#edit_eq_pmo").val();
                            objEqJs.equipocalgasto = $("#edit_eq_gasto").val();
                            objEqJs.equipocalpcarga = $("#edit_eq_pcarga").val();
                            getTotalEquipoEdit(objEqJs, "2", $("#<%=cboTipoTarifa.ClientID %>").val(), $("#<%=txtFecha.ClientID %>").val());
                        },
                        "Actualizar": function () {
                            setEquipoCalEdit();
                            setValoresEquipoEdit(objEqJs, $("#<%=cboTipoTarifa.ClientID %>").val());
                            $("#<%=btnUpdDatoEquipo.ClientID %>").click();                            
                        },
                        "Cerrar": function () {                            
                            $(this).dialog('close');
                        }
                    }
                });
            }

            $("#btn_edit_eq_del").on('click', function () {
                delValoresEquiposEdit($.cookie('pcusr'), 
                                      $("#edit_eq_item").val(),
                                      $("#edit_eq_id_eq").val());
                $("#<%=btnUpdDatoEquipo.ClientID %>").click();
            });

            function mostrarid() {
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

            //EDITA PUNTOS CUANDO SE ESTAN INGRESANDO
            function editaPuntoDet() {
                dataGridPunto();//SET DE DATOS PARA MOSTRAR EN EL EDITOR DE PUNTOS
                editPuntoGV();//FUNCION QUE LLAMA AL DIALOG PARA EDITAR O ELIMINAR PUNTOS
            }

            function editaPuntoDetGv() {
                //FUNCION PARA EDITAR UN PUNTO EN ESPECIFICO DESDE EL GRID EQUIPOS
                dataGridPunto(); //SET DE DATOS PARA MOSTRAR EN EL EDITOR DE PUNTOS
                editPuntoGV(); //FUNCION QUE LLAMA AL DIALOG PARA EDITAR O ELIMINAR PUNTOS
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
                $("#tab-edit-eq").tabs();
                $("#tab-edit-punto").tabs();
                $("#tab-equipo-dato-cal").tabs();
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
                    $('#txtDcto').removeAttr("disabled"); //txtDctoPorc                 
                } else {
                    $('#txtDcto').attr("disabled", "disabled"); //txtDcto
                    $('#txtDcto').val("0");
                    $('#txtDctoPorc').val("0"); //no estaba
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

            function setEquipoCal() {
                objEqJs.equipotarifaorig = $("#txt-eq-read-tto").val();
                objEqJs.equipopmo = $("#txt-eq-read-pmo").val();
                objEqJs.equipocostorep = $("#txt-eq-read-crpto").val();
                objEqJs.equipocmo = $("#txt-eq-read-cmo").val();
                objEqJs.equipototal = $("#txt-eq-read-pventa").val();
                objEqJs.equiponparte = $("#txt-eq-read-np").val();
                objEqJs.equiponserie = $("#txt-eq-read-ns").val();
                objEqJs.equipomodelo = $("#txt-eq-read-mod").val();
                objEqJs.equiponombre = $("#txt-eq-read-nom").val();
                objEqJs.equipocalpeso = $("#txt-eq-read-peso").val();
                objEqJs.equipocantidad = $("#txt-eq-read-qty").val();
                objEqJs.equipocalgasto = $("#txt-eq-read-gasto").val();
                objEqJs.equipocalpcarga = $("#txt-eq-read-pcarga").val();
                objEqJs.equipoid = $("#txt-eq-read-id").val();
                objEqJs.equipocotid = $.cookie('pcusr');
                objEqJs.equipocalnp = $("#txt-eq-read-notap").val();
                objEqJs.equipocaloc = $("#txt-eq-read-oc").val();
                objEqJs.equipocalsaot = $("#txt-eq-read-saot").val();
                objEqJs.equipolp_idn = $("#<%=cbo_eq_read_lprod.ClientID %>").val();
                objEqJs.equipodet_idn = $("#<%= cbo_eq_read_estado.ClientID %>").val();
                objEqJs.equipotrabajo = $("#<%=cbo_eq_read_trabajo.ClientID %>").val();
            }

            function setEquipoCalEdit() {
                objEqJs.equipopmo = $("#edit_eq_pmo").val();
                objEqJs.equipototal = $("#edit_eq_total").val();
                objEqJs.equiponparte = $("#edit_eq_nparte").val();
                objEqJs.equiponserie = $("#edit_eq_nserie").val();
                objEqJs.equipocantidad = $("#edit_eq_qty").val();
                objEqJs.equipocalgasto = $("#edit_eq_gasto").val();
                objEqJs.equipocalpcarga = $("#edit_eq_pcarga").val();
                objEqJs.equipoitem = $("#edit_eq_item").val();
                objEqJs.equipocotid = $.cookie('pcusr');
            }

            function setInfoMgTotCot() {
                objInfoCot.cot_tipomoneda = $("#<%=cboTipoTarifa.ClientID %>").val();
                objInfoCot.cot_afecto = $("#<%=cboTipoImpuesto.ClientID %>").val();
                objInfoCot.tc_id = $("#<%=cboTipoCotizacion.ClientID %>").val();
                objInfoCot.cot_descuento = $("#txtDcto").val(); //txtDctoPorc
                objInfoCot.cot_id = $.cookie('pcusr');
                objInfoCot.cot_fecha = $("#<%=txtFecha.ClientID %>").val();
            }

            function setDatoComision() {
                if ($("#<%=cboLugarComision.ClientID %>").val() == 0) {
                    objComCot.lug_id = prevLCom;
                } else {
                    objComCot.lug_id = $("#<%=cboLugarComision.ClientID %>").val();
                }
                objComCot.ccom_qtypersona = $("#txt-com-qty-persona").val();
                objComCot.ccom_qtydia = $("#txt-com-qty-dia").val();
                objComCot.ccom_qtyveh = $("#txt-com-qty-veh").val();
                objComCot.ccom_qtranseqt = $("#txt-com-eq-c").val();
                objComCot.ccom_qtranseqa = $("#txt-com-eq-a").val();
                objComCot.ccom_fondor = $("#txt-com-fondo-rendir").val();
                objComCot.ccom_qgasrepr = $("#txt-com-rep-gasto").val();
                objComCot.ccom_qtycommes = $("#txt-com-qty-com-mes").val();
            }

            function transporteVal() {
                if ($("#chkTransporte").is(":not(:checked)")) {
                    $("#txtdirtransporte").prop("disabled", true);
                    $("#<%=cboRegion.ClientID %>").prop("disabled", true);
                    $("#<%=cboTraslado.ClientID %>").prop("disabled", true);
                    $("#btnaddtransporte").attr('disabled', 'disabled');
                }
            }

            $("#chkTransporte").on('click', function () {
                if ($(this).is(":checked")) {
                    //$("#txtDirTransporte").prop("disabled", false);
                    $("#<%=cboRegion.ClientID %>").prop("disabled", false);
                    $("#<%=cboTraslado.ClientID %>").prop("disabled", false);
                    $("#btnAddTransporte").removeAttr('disabled');
                } else {
                    //$("#txtDirTransporte").prop("disabled", true);
                    $("#<%=cboRegion.ClientID %>").prop("disabled", true);
                    $("#<%=cboTraslado.ClientID %>").prop("disabled", true);
                    $("#btnAddTransporte").attr('disabled', 'disabled');
                    //$("#txtDirTransporte").val("");
                    $("#txtTotalTransporte").val("0");
                    $("#<%=cboRegion.ClientID %>").val("0");
                    $("#<%=cboTraslado.ClientID %>").val("0");
                    getTotalSinTransCot($.cookie('pcusr'));
                    $("#<%=btnUpdDatoEquipo.ClientID %>").click();
                }
            });

            $("#btnAddTransporte").on('click', function () {
                getTotalTransCot($.cookie('pcusr'),
                                $("#<%=cboTraslado.ClientID %>").val(),
                                $("#<%=cboRegion.ClientID %>").val(),
                                $("#<%=cboTipoTarifa.ClientID %>").val(),
                                $("#<%=txtFecha.ClientID %>").val());
                $("#<%=btnUpdDatoEquipo.ClientID %>").click();
            });

            var prevLCom = "";
            $("#<%=cboLugarComision.ClientID %>").on('focus', function () {
                prevLCom = $("#<%=cboLugarComision.ClientID %>").val();
            });

            $("#<%=cboLugarComision.ClientID %>").change(function () {
                if ($("#<%=cboLugarComision.ClientID %>").val() == 0) {
                    $("#btnAddComision").attr('disabled', 'disabled');
                    setDatoComision();
                    bloqueaCampoComision();                    
                    setTotalCostoComision(objComCot,
                                          $.cookie('pcusr'),
                                          $("#<%=cboTipoTarifa.ClientID %>").val(),
                                          $("#<%=txtFecha.ClientID %>").val());
                    $("#<%=btnUpdDatoEquipo.ClientID %>").click();
                } else {
                    $("#btnAddComision").removeAttr('disabled');
                    desbloqueaCampoComision();
                }
                $("#chkTransporte").focus();
            });

            $("#<%=cboVendedor.ClientID %>").change(function () {
                getEmailVendedor($("#<%=cboVendedor.ClientID %>").val());
            });

            $("#<%=cbo_magnitud.ClientID %>").change(function () {
                getListaMagniFunct($(this).val());
            });

            $('._cboJefe_').change(function () {
                getDatoAceptadoPor($(this).val());
            });

            $('._cboLugarRetiro_').change(function () {
                if ($('._cboLugarRetiro_').val() == 3) {
                    $('._txtSectorRetiro_').val("N/A");
                    $('._txtSectorRetiroNom_').val("N/A");
                }
            });

            $('._cboGarantia_').change(function () {
                if ($('._cboGarantia_').val() == 13) {
                    $('._cboValidezGar_').val("4");
                }
            });

            $("#btnAddComision").on('click', function () {
                setDatoComision();
                getTotalCostoComision(objComCot,
                                      $.cookie('pcusr'),
                                      $("#<%=cboTipoTarifa.ClientID %>").val(),
                                      $("#<%=txtFecha.ClientID %>").val());
                $("#<%=btnUpdDatoEquipo.ClientID %>").click();
                //alert("boton ejecutado");
            });

            $("#btnCalcularTotal").on('click', function () {
                setInfoMgTotCot();
                getMargenTotalCot(objInfoCot, "CAL");
            });

            //FUNCION DE AGREGAR PUNTOS CUANDO SE INGRESA EQUIPO AL DETALLE COTIZACION
            $("#btn-in-punto-cal").on('click', function () {
                $.cookie('iditemeq', getNumeroFilaGVDetCot());
                $.cookie('flag_inpunto', '1');
                setListaPuntoEquipo($.cookie('pcusr'),
                                    $("#<%=cbo_magnitud.ClientID %>").val(),
                                    $("#cbo_funcion").val(),
                                    $("#txt-in-punto-cal").val(),
                                    $("#txt-eq-read-id").val(),
                                    $("#txt_in_punto_eq_item").val(),
                                    $('._txt_in_punto_coment_').val());
                $("#<%=btnActualizaGVPunto.ClientID %>").click();
                $("#<%=cbo_magnitud.ClientID %>").val("0");
                $("#cbo_funcion").val("0");
                $("#txt-in-punto-cal").val("");
                $('._txt_in_punto_coment_').val("Ingrese algun comentario");
                //$.removeCookie('iditemeq');
            });

            //BOTON QUE ESTABA OCULTO QUE SOLO SE MUESTRA CUANDO SE EDITA PUNTOS DESDE EL DETALLE COTIZACION
            $("#btn-ed-punto-cal").on('click', function () {
                $.cookie('iditemeq', dgcItemCal); //txt-edit-punto-item-gv $("#txt-edit-punto-dccid-gv").val() dgcItemCal
                $.cookie('flag_inpunto', '2');
                modInsDatoPuntoCot($.cookie('pcusr'),
                                   $("#<%=cbo_magnitud.ClientID %>").val(),
                                   $("#cbo_funcion").val(),
                                   $("#txt-in-punto-cal").val(),
                                   dgcItemCal,
                                   dgcItem,
                                   dgcEquId,
                                   $('._txt_in_punto_coment_').val());
                $("#<%=btnActualizaGVPunto.ClientID %>").click();
                $("#<%=cbo_magnitud.ClientID %>").val("0");
                $("#cbo_funcion").val("0");
                $("#txt-in-punto-cal").val("");
                $('._txt_in_punto_coment_').val("Ingrese algun comentario");
                //$.removeCookie('iditemeq');
            });

            $("#btn-edit-punto-upd-gv").on('click', function () {
                $.cookie('iditemeq', $("#txt-edit-punto-dccid-gv").val());
                modPuntoDetFila($("#txt-edit-punto-item-gv").val(),
                                $.cookie('pcusr'),
                                $("#txt-edit-punto-lista-gv").val(),
                                $("#txt-edit-punto-dccid-gv").val(),
                                $('._txt_edit_punto_coment_').val());
                $("#<%=btnActualizaGVPunto.ClientID %>").click();
                limpiaPuntoDetFila();
                $("#dialog-edit-punto-grid").dialog('close');
                //$.removeCookie('iditemeq');
            });

            $("#btn-edit-punto-del-gv").on('click', function () {
                $.cookie('iditemeq', $("#txt-edit-punto-dccid-gv").val());

                var eq_id = (($("#txt-eq-read-id").val() == "" || $("#txt-eq-read-id").val() == null) ? dgpEditIdEq : $("#txt-eq-read-id").val());

                delPuntoDetFila($("#txt-edit-punto-item-gv").val(),
                                $.cookie('pcusr'),
                                eq_id,
                                $("#txt-edit-punto-dccid-gv").val());
                $("#<%=btnActualizaGVPunto.ClientID %>").click();
                limpiaPuntoDetFila();
                $("#dialog-edit-punto-grid").dialog('close');
                //$.removeCookie('iditemeq');
            });

            $('#frm-edit-eq-valor').validate({
                rules: {
                    edit_eq_qty: {
                        required: true,
                        number: true
                    },
                    edit_eq_pmo: {
                        required: true,
                        number: true
                    },
                    edit_eq_gasto: {
                        required: true,
                        number: true
                    }
                }
            });            
        </script>

</asp:Content>
