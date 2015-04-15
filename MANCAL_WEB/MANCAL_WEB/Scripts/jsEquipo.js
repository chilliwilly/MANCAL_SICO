function setEquipo(obj) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setDatoEquipo",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "eq": obj }),
        success: function (data, status) {
            alert("Equipo Guardado");
        },
        error: function (data) {
            alert("Error al ingresar equipo");
        }
    });
}

function sumEquipo(obj, cot, mon) {
    var total;
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getSumEquipo",
        dataType: "json",
        async: false,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "eq": obj, "tcot": cot, "tmon": mon }),
        success: function (data, status) {
            total = data.d;
        },
        error: function (data) {
            alert("Error al calcular equipo");
        }
    });
    return total;
}

function updEquipo(obj) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/modDatoEquipo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "eq": obj }),
        success: function (data, status) {
            alert("Equipo actualizado");
        },
        error: function (data) {
            alert("Error al actualizar equipo");
        }
    });
}

function delEquipo(obj) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/delDatoEquipo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "eq": obj }),
        success: function (data, status) {
            alert("Equipo Borrado");
        },
        error: function (data) {
            alert("Error al borrar equipo");
        }
    });
}

function getCommFac() { //OBTIENE COMENTARIO FATURACION
    $.ajax({
        type: "GET",
        url: "/asmx_files/js_llenado.asmx/delDatoEquipo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: "",
        success: function (data, sstatus) {
        },
        error: function (data) {
        }
    });
}

function delArchivo(item, coti) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/delDatoArchivo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "item_": item, "coti_": coti }),
        success: function (data, status) {
            alert("Archivo Eliminado");
        },
        error: function (data) {
            alert("Error al eliminar archivo");
        }
    });
}

function getFiltroCliente(nom, cta, tip, est) {
    $.ajax({
        type: "POST",
        url: "proy_new.aspx/setFiltroCliente",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "clinom": nom, "clicta": cta, "clitipo": tip, "cliestado": est}),
        success: function (data, status) {
            
        },
        error: function (data) {
            alert("Error al buscar cliente");
        }
    });
}

//FUNCION LLAMADA AL MOMENTO DE QUEERER AGREGAR PUNTOS AL EQUIPO NUEVO
function dialogPunto() {
    $("#btn-in-punto-cal").toggle(true);
    //$("#btn-det-cal-edita-punto").toggle(true);
    $("#btn-ed-punto-cal").toggle(false);
    //$("#btn-det-cal-edita-punto-gv").toggle(false);
    $("#dialog-equipo-punto").dialog({
        modal: true,
        width: "565",
        height: "522",
        buttons: {
            "Cerrar": function () {
                $(this).dialog('close');                
            }
        }
    });
}

//FUNCION LLAMADA SOLO PARA DIALOG PUNTO LIMPIO LLAMADO DESDE GRID EQUIPOS
function dialogPuntoEdit() {
    $("#dialog-equipo-punto").dialog({
        modal: true,
        width: "565",
        height: "522",
        buttons: {
            "Cerrar": function () {
                $(this).dialog('close');
            }
        }
    });
}

//FUNCION QUE LLAMA DIALOG PARA EDITAR UN PUNTO DE LA LISTA
function editPuntoGV() {    
    $("#dialog-edit-punto-grid").dialog({
        modal: true,
        width: "565",
        buttons: {
            "Cerrar": function () {
                $(this).dialog('close');
            }
        }
    });
}

/************************************************************/
/************************************************************/
function getEquipoDato(id_eq, id_ta, fe_co) {
    var EqCot = new EquipoCotizacion();
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getDatoEq",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "ideq": id_eq, "idtarifa": id_ta, "fcoti": fe_co }),
        succes: function (data, status) {
            alert(data.d);
        },
        error: function (data) {
            alert("Error al recuperar datos del equipo");
        }
    });
}

//FUNCION QUE ES LLAMADA AL PRESIONAR CALCULAR PARA UN UNICO EQUIPO - WEBSERVICE getCalculaEquipo
function equipoCal_Total(obj, id_sys, id_tarifa, f_cot) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getCalculaEquipo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj, "id_sys": id_sys, "id_tarifa": id_tarifa, "f_cot": f_cot }),
        success: function (data, status) {
            var arr = data.d;
            if (arr[1] == null || arr[1] == "") {
                $("#txt-eq-read-pventa").val(arr[0]);
            } else {
                alert(arr[1]);
                $("#txt-eq-read-pmo").val(arr[0]);
            }
        },
        error: function (data) {
            alert("Error al calcular equipo");
        }
    });
}

//FUNCION QUE ES LLAMADA AL MOMENTO DE PRESIONAR GUARDAR EQUIPO - WEBSERVICE setEquipoSeleccion
function equipoCal_Guarda(obj) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setEquipoSeleccion",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj }),
        success: function (data, status) {
            alert("Equipo Guardado");
        },
        error: function (data) {
            alert("Error al guardar equipo");
        }
    });
}

//FUNCION QUE TRAE VALORES COMERCIALES DEL EQUIPO A PARTIR DEL EQUIPO SELECCIONADO EN LA BUSQUEDA
function getValorEquipo_Cal(eq_id, eq_tarifa, eq_fech) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getEqComercial",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "e_id": eq_id, "e_tarifa": eq_tarifa, "e_fecha": eq_fech }),
        success: function (data, status) {
            var objData = data.d;
            $("#txt-eq-read-pmo").val(objData.equipopmo);
            $("#txt-eq-read-crpto").val(objData.equipocostorep);
            $("#txt-eq-read-cmo").val(objData.equipocmo);
            $("#txt-eq-read-tto").val(objData.equipotarifaorig);
            $("#txt-eq-read-peso").val(objData.equipocalpeso);
            $("#txt-eq-read-pventa").val(objData.equipototal);
        },
        error: function (data) {
            alert("Error al buscar datos comerciales del equipo");
        }
    });
}

//FUNCION UTILIZADA PARA SETEAR LOS VALORES PARA TRANSPORTE POR EQUIPO EN EL DETALLE - WEBMETHOD getCotTotalTrans
function getTotalTransCot(cotid, trasid, regiid, tariid, cotfec) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getCotTotalTrans",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "cotid": cotid, "trasid": trasid, "regiid": regiid, "tariid": tariid, "cotfec": cotfec }),
        success: function (data, status) {
            $("#txtTotalTransporte").val(data.d);
        },
        error: function (data) {
            alert("Error al distribuir costos transporte");
        }
    });
}

//FUNCION UTILIZADA CUANDO QUITO EL TRANSPORTE - WEBMETHOD setCotTotalSinTrans
function getTotalSinTransCot(idcot) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setCotTotalSinTrans",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "idcot": idcot }),
        success: function (data, status) {
        },
        error: function (data) {
            alert("Error al restaurar costo transporte");
        }
    });
}

function getTotalCostoComision(obj, idcot, ttarifa, fcot) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getCotComision",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj, "idc": idcot, "ttar": ttarifa, "fcot": fcot }),
        success: function (data, status) {
            var retObj = data.d;
            $("#txt-com-trans-dts").val(retObj.ccom_transdts);
            $("#txt-com-trans-hotel").val(retObj.ccom_transhotel);
            $("#txt-com-trans-av-per").val(retObj.ccom_psjavionper);
            $("#txt-com-arr-veh").val(retObj.ccom_alqveh);
            $("#txt-com-tras-eq-c").val(retObj.ccom_transeqt);
            $("#txt-com-tras-eq-a").val(retObj.ccom_transeqa);
            $("#txt-com-viatico").val(retObj.ccom_viatico);
            $("#txt-com-hotel").val(retObj.ccom_hotel);
            $("#txt-com-fondo-rend").val(retObj.ccom_frendir);
            $("#txt-com-gasto-rep").val(retObj.ccom_gasrepr);
            $("#txt-com-tot-cos-com").val(retObj.ccom_totalcom);
            $("#txt-com-tot-p-com").val(retObj.ccom_totalcommg);
        },
        error: function (data) {
            alert("Error al cargar datos de comision");
        }
    });
}

//FUNCION QUE AL DEJAR EN SELECCIONAR EL CBO DE COMISION ESTE ACTUALIZARA A 0 LOS VALORES CORRESPONDIENTES
function setTotalCostoComision(obj, idcot, ttarifa, fcot) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setTotalCostoCom",
        datatype: "ajax",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj, "idc": idcot, "ttar": ttarifa, "fcot": fcot }),
        success: function (data, status) {
            alert("Costo de comision actualizados");
        },
        error: function (data) {
            alert("Error al invalidar costo de comision");
        }
    });
}

function getMargenTotalCot(obj, un_nom) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getCotTotalMargen",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj, "idun": un_nom }),
        success: function (data, status) {
            var cotObj = data.d;
            $("#txtTotalCostoMo").val(cotObj.cot_totcostmo);
            $("#txtTotalCostoRpto").val(cotObj.cot_totvalrpto);
            $("#txtMgOpPorc").val(cotObj.cot_mgopporc);
            $("#txtMgBrutoPorc").val(cotObj.cot_mgbrutoporc);
            $("#txtMgContribucion").val(cotObj.cot_mgcontrib);
            $("#txtMgContribucionPorc").val(cotObj.cot_mgcontribporc);
            $("#txtUtilidadEspPorc").val(cotObj.cot_utilesperaporc);
            $("#txtTipoMoneda").val(cotObj.cot_tipomoneda);
            $("#txtNeto").val(cotObj.cot_neto);
            $("#txtNetoDcto").val(cotObj.cot_netodcto);
            $("#txtIva").val(cotObj.cot_iva);
            $("#txtTotal").val(cotObj.cot_total);

            if (cotObj.cot_msgautoriza != "Y") {
                alert(cotObj.cot_msgautoriza);
            }
        },
        error: function (data) {
            alert("Error al calcular margenes y/o total");
        }
    });
}

function getListaMagniFunct(idmag) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getListaMagFun",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "id_mag": idmag, "id_sys": "2" }),
        success: function (data, status) {
            var lsFun = data.d;
            //alert(lsFun);
            $("#cbo_funcion").empty().append($("<option></option>").val("0").html("Seleccione"));
            $.each(lsFun, function () {
                $("#cbo_funcion").append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        },
        error: function (data) {
            alert("Error al cargar funciones de la magnitud");
        }
    });
}

//FUNCION UTILIZADA CUANDO SE INSERTAN PUNTOS PRO PRIMERA VEZ
function setListaPuntoEquipo(cotid, espid, funid, punto, equid, eqdccid) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setDatoPuntoCot",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "idcot": cotid, "idesp": espid, "idfun": funid, "txtpunto": punto, "idequ": equid }),
        success: function (data, status) {
            alert("Puntos agregados");
            limpiaEditaGridDetPunto();
        },
        error: function (data) {
            alert("Error al agregar dato de puntos");
        }
    });
}

//FUNCION QUE SE UTILIZA PARA AGREGAR PUNTOS LUEGO DE EDITAR EL DETALLE COTIZACION
function modInsDatoPuntoCot(idcot, idesp, idfun, txtpunto, iddcc, iddcitem, idequ) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/insModDatoPuntoCot",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "idcot": idcot, "idesp": idesp, "idfun": idfun, "txtpunto": txtpunto, "iddcc": iddcc, "iddcitem": iddcitem, "idequ": idequ }),
        success: function (data, status) {
            alert("Puntos agregados");
            limpiaEditaGridDetPunto();
        },
        error: function (data) {
            alert("Error al agregar dato de puntos");
        }
    });
}

//---------------------------------------------------//
//---------------------------------------------------//

//INICIO FUNCIONES DE EDICION DE EQUIPO EN EL DETALLE

//---------------------------------------------------//
//---------------------------------------------------//
function getValoresEquipoEdit(e_id, e_tarifa, e_fecha) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getEqComercial",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "e_id": e_id, "e_tarifa": e_tarifa, "e_fecha": e_fecha }),
        success: function (data, status) {
            var lsDato = data.d;
            $("#edit_eq_cmo").val(lsDato.equipocmo);
            $("#edit_eq_crep").val(lsDato.equipocostorep);
            $("#edit_eq_torig").val(lsDato.equipotarifaorig);
        },
        error: function (data) {
            alert("Error al buscar datos del item");
        }
    });
}

function getTotalEquipoEdit(obj, id_sys, id_tarifa, f_cot) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getCalculaEquipo",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj, "id_sys": id_sys, "id_tarifa": id_tarifa, "f_cot": f_cot }),
        success: function (data, status) {
            var arr = data.d;
            if (arr[1] == null || arr[1] == "") {
                $("#edit_eq_total").val(arr[0]);
            } else {
                alert(arr[1]);
                $("#edit_eq_pmo").val(arr[0]);
            }
        },
        error: function (data) {
            alert("Error al calcular equipo");
        }
    });
}

function setValoresEquipoEdit(objEqEdit, intarifa) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setValorEquEdit",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": objEqEdit, "tarifa": intarifa }),
        success: function (data, status) {
            alert("Equipo actualizado correctamente");
        },
        error: function (data) {
            alert("Error al actualizar datos del equipo");
        }
    });
}

function delValoresEquiposEdit(cot_id, cot_item, cot_eq) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/delValorEquEdit",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "cotid": cot_id, "cotitem": cot_item, "coteq": cot_eq }),
        success: function (data, status) {
            alert("Equipo borrado correctamente");
        },
        error: function (data) {
            alert("Error al borrar datos del equipo");
        }
    });
}

function modValoresDetCalProd(item, cotiid, np, oc, saot, lp, estado) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/modEquDetCalProd",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "item": item, "cotiid": cotiid, "np": np, "oc": oc, "saot": saot, "lp": lp, "estado": estado }),
        success: function (data, status) {
            alert("Datos actualizados correctamente");
        },
        error: function (data) {
            alert("Error al actualizar datos");
        }
    });
}
//---------------------------------------------------//
//---------------------------------------------------//

//FIN FUNCIONES DE EDICION DE EQUIPO EN EL DETALLE

//---------------------------------------------------//
//---------------------------------------------------//


//---------------------------------------------------//
//---------------------------------------------------//

//FUNCIONES DE EDICION DEL PUNTO DEL EQUIPO

//---------------------------------------------------//
//---------------------------------------------------//
function modPuntoDetFila(item, coti, punto) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/updPuntoDetFila",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "item": item, "coti": coti, "punto": punto }),
        success: function (data, status) {
            alert("Puntos actualizados correctamente");
        },
        error: function (data) {
            alert("Error al actualizar puntos");
        }
    });
}

//FUNCION QUE ELIMINA EQUIPO PUNTO DEL DETALLE
function delPuntoDetFila(item, coti, equi) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/delePuntoDetFila",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "item": item, "coti": coti, "equi": equi }),
        success: function (data, status) {
            alert("Puntos borrados correctamente");
        },
        error: function (data) {
            alert("Error al borrar puntos");
        }
    });
} 

function limpiaPuntoDetFila() {
    $("#txt-edit-punto-item-gv").val("");
    $("#txt-edit-punto-esp-gv").val("");
    $("#txt-edit-punto-mag-gv").val("");
    $("#txt-edit-punto-lista-gv").val("");
}
//---------------------------------------------------//
//---------------------------------------------------//

//FIN FUNCIONES DE EDICION DEL PUNTO DEL EQUIPO

//---------------------------------------------------//
//---------------------------------------------------//

//FUNCION PARA OBTENER EL MAIL DEL VENDEDOR
function getEmailVendedor(idven) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getVendedorMail",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "venid": idven }),
        success: function (data, status) {
            $("#txtMailVendedor").val(data.d);
        },
        error: function (data) {
            alert("Error al buscar mail del vendedor");
        }
    });
}

function validaPrecioGastoChange(oldPGasto, newPGasto) {
    if (newPGasto < oldPGasto) {
        alert("El nuevo precio de gasto no puede ser menor al actual");
        $("#edit_eq_gasto").val(oldPGasto);
    }
}

function validaPrecioMOChange() {
    if ($("#edit_eq_pmo").val() < $("#edit_eq_torig").val()) {
        alert("El Precio MO no puede ser menor al precio base (" + $("#edit_eq_torig").val() + ")");
        $("#edit_eq_pmo").val($("#edit_eq_torig").val());
    }
}

function bloqueaCampoComision() {
    $("#txt-com-qty-persona").prop("disabled", true);
    $("#txt-com-qty-dia").prop("disabled", true);
    $("#txt-com-qty-veh").prop("disabled", true);
    $("#txt-com-eq-c").prop("disabled", true);
    $("#txt-com-eq-a").prop("disabled", true);
    $("#txt-com-fondo-rendir").prop("disabled", true);
    $("#txt-com-rep-gasto").prop("disabled", true);
    $("#txt-com-qty-com-mes").prop("disabled", true);

    $("#txt-com-qty-persona").val("0");
    $("#txt-com-qty-dia").val("0");
    $("#txt-com-qty-veh").val("0");
    $("#txt-com-eq-c").val("0");
    $("#txt-com-eq-a").val("0");
    $("#txt-com-fondo-rendir").val("0");
    $("#txt-com-rep-gasto").val("0");
    $("#txt-com-qty-com-mes").val("0");

    $("#txt-com-trans-dts").val("0");
    $("#txt-com-trans-hotel").val("0");
    $("#txt-com-trans-av-per").val("0");
    $("#txt-com-arr-veh").val("0");
    $("#txt-com-tras-eq-c").val("0");
    $("#txt-com-tras-eq-a").val("0");
    $("#txt-com-viatico").val("0");
    $("#txt-com-hotel").val("0");
    $("#txt-com-fondo-rend").val("0");
    $("#txt-com-gasto-rep").val("0");
    $("#txt-com-tot-cos-com").val("0");
    $("#txt-com-tot-p-com").val("0");
}

function limpiaEditaGridDetPunto() {
    $("#txt_in_punto_eq_item").val("");
    $("#txt_in_punto_eq_id").val("");
    $("#txt_in_punto_eq_cot").val("");
}

function desbloqueaCampoComision() {
    $("#txt-com-qty-persona").prop("disabled", false);
    $("#txt-com-qty-dia").prop("disabled", false);
    $("#txt-com-qty-veh").prop("disabled", false);
    $("#txt-com-eq-c").prop("disabled", false);
    $("#txt-com-eq-a").prop("disabled", false);
    $("#txt-com-fondo-rendir").prop("disabled", false);
    $("#txt-com-rep-gasto").prop("disabled", false);
    $("#txt-com-qty-com-mes").prop("disabled", false);
}

function EquipoCotizacion() {
    this.equipoid = "";
    this.equiponombre = "";
    this.equipomodelo = "";
    this.equiponparte = "";
    this.equiponserie = "";
    this.equipocantidad = "";
    this.equipotrabajo = "";
    this.equipopmo = "";
    this.equipocostorep = "";
    this.equipocmo = "";
    this.equipotarifaorig = "";
    this.equipocalgasto = "";
    this.equipocalpcarga = "";
    this.equipototal = "";
    this.equipocalpeso = "";
    this.equipodet_idn = "";
    this.equipocalnp = "";
    this.equipolp_idn = "";
    this.equipocaloc = "";
    this.equipocalsaot = "";
    this.setValueEqCot = function (obj) {
        this.equipoid = obj.equipoid;
        this.equiponombre = obj.equiponombre;
        this.equipomodelo = obj.equipomodelo;
        this.equiponparte = obj.equiponparte;
        this.equiponserie = obj.equiponserie;
        this.equipocantidad = obj.equipocantidad;
        this.equipotrabajo = obj.equipotrabajo;
        this.equipopmo = obj.equipopmo;
        this.equipocostorep = obj.equipocostorep;
        this.equipocmo = obj.equipocmo;
        this.equipotarifaorig = obj.equipotarifaorig;
        this.equipocalgasto = obj.equipocalgasto;
        this.equipocalpcarga = obj.equipocalpcarga;
        this.equipototal = obj.equipototal;
        this.equipocalpeso = obj.equipocalpeso;
        this.equipodet_idn = obj.equipodet_idn;
        this.equipocalnp = obj.equipocalnp;
        this.equipolp_idn = obj.equipolp_idn;
        this.equipocaloc = obj.equipocaloc;
        this.equipocalsaot = obj.equipocalsaot;
    };
}

function ComisionCotizacion() {
    this.ccom_qtypersona = "";
    this.ccom_qtydia = "";
    this.ccom_qtyveh = "";
    this.ccom_qtranseqt = "";
    this.ccom_qtranseqa = "";
    this.ccom_fondor = "";
    this.ccom_qgasrepr = "";
    this.ccom_qtycommes = "";
    this.ccom_transdts = "";
    this.ccom_transhotel = "";
    this.ccom_psjavionper = "";
    this.ccom_alqveh = "";
    this.ccom_transeqt = "";
    this.ccom_transeqa = "";
    this.ccom_viatico = "";
    this.ccom_hotel = "";
    this.ccom_frendir = "";
    this.ccom_gasrepr = "";
    this.ccom_totalcom = "";
    this.ccom_totalcommg = "";
    this.lug_id = "";
    this.cot_numero = "";
}

function InfoCotizacion() {
    this.cot_tipomoneda = "";
    this.cot_afecto = "";
    this.tc_id = "";
    this.cot_descuento = "";
    this.cot_id = "";
    this.cot_fecha = "";
}
/************************************************************/
/************************************************************/

function limpiaEquipoDialog() {
    $("#txt-eq-read-tto").val("0");
    $("#txt-eq-read-pmo").val("0");
    $("#txt-eq-read-crpto").val("0");
    $("#txt-eq-read-cmo").val("0");
    $("#txt-eq-read-pventa").val("0");
    $("#txt-eq-read-np").val("");
    $("#txt-eq-read-ns").val("");
    $("#txt-eq-read-mod").val("");
    $("#txt-eq-read-nom").val("");
    $("#txt-eq-read-peso").val("0");
    $("#txt-eq-read-qty").val("1");
    $("#txt-eq-read-gasto").val("0");
    $("#txt-eq-read-pcarga").val("0");
    $("#txt-eq-read-id").val("");
    $("#txt-eq-read-notap").val("");
    $("#txt-eq-read-oc").val("");
    $("#txt-eq-read-saot").val("");
}

function cambiaAjaxUploader() {
    Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile = "Seleccione";
    Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles = "Seleccione Archivos";
    Sys.Extended.UI.Resources.AjaxFileUpload_Pending = "Pendiente";
    Sys.Extended.UI.Resources.AjaxFileUpload_Remove = "Quitar";
    Sys.Extended.UI.Resources.AjaxFileUpload_Upload = "Subir";
    Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue = "{0} archivo(s) en cola.";
    Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage = "Completado {0} %";
    Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload = "Seleccione archivo(s) para subir.";
    Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded = "Se han subido los archivos.";
    Sys.Extended.UI.Resources.AjaxFileUpload_Cancel = "Cancelar";
    Sys.Extended.UI.Resources.AjaxFileUpload_Canceled = "Cancelado";
    Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled = "Archivo Cancelado";
    Sys.Extended.UI.Resources.AjaxFileUpload_UploadingInputFile = "Subiendo Archivo: {0}.";
    Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded = "Subido";
}