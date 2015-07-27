var tipoOperacion;

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

function getNomCliente(idcli) {//OBTENER SOLO NOMBRE CLIENTE    
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getNombreCliente",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "cliid": idcli }),
        success: function (data, status) {
            $('._txtCliente_').val(data.d);
        },
        error: function (data) {
            alert("Error al buscar nombre del cliente");
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
    tipoOperacion = "DET";
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setEquipoSeleccion",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "obj": obj }),
        success: function (data, status) {
            alert("Equipo Guardado");
        },
        error: errorOperacionCotizacion //function (data) {
            //alert("Error al guardar equipo");
        //}
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
            alert("Error al buscar datos comerciales del equipo, favor verifique que el equipo tenga los datos minimos para cotizar.");
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
            $("#txtDctoPorc").val(cotObj.cot_dcto_porc);
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

//FUNCION UTILIZADA CUANDO SE INSERTAN PUNTOS PRO PRIMERA VEZ WEBMETHOD setDatoPuntoCot getNumeroFilaGVDetCot
function setListaPuntoEquipo(cotid, espid, funid, punto, equid, eqdccid, coment) {
    var nroFila = getNumeroFilaGVDetCot();
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/setDatoPuntoCot",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "idcot": cotid, "idesp": espid, "idfun": funid, "txtpunto": punto, "iddetcot": nroFila, "iditem": nroFila, "idequ": equid, "pcoment": coment }),
        success: function (data, status) {
            alert("Puntos agregados");
            limpiaEditaGridDetPunto();
        },
        error: function (data) {
            alert("Error al agregar dato de puntos");
        }
    });
}

//FUNCION QUE SE UTILIZA PARA AGREGAR PUNTOS LUEGO DE EDITAR EL DETALLE COTIZACION WEBMETHOD insModDatoPuntoCot
function modInsDatoPuntoCot(idcot, idesp, idfun, txtpunto, iddcc, iddcitem, idequ, coment) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/insModDatoPuntoCot",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "idcot": idcot, "idesp": idesp, "idfun": idfun, "txtpunto": txtpunto, "iddcc": iddcc, "iddcitem": iddcitem, "idequ": idequ, "pcoment": coment }),
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
//    FUNCIONES DE EDICION DEL PUNTO DEL EQUIPO      //
//---------------------------------------------------//
//---------------------------------------------------//
function modPuntoDetFila(item, coti, punto, dcc, coment) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/updPuntoDetFila",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "item": item, "coti": coti, "punto": punto, "indcc": dcc, "pcoment": coment }),
        success: function (data, status) {
            alert("Puntos actualizados correctamente");
        },
        error: function (data) {
            alert("Error al actualizar puntos");
        }
    });
}

//FUNCION QUE ELIMINA EQUIPO PUNTO DEL DETALLE
function delPuntoDetFila(item, coti, equi, dcc) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/delePuntoDetFila",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "item": item, "coti": coti, "equi": equi, "dccid": dcc }),
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
    $('.txt_edit_punto_coment').val("");
}
//---------------------------------------------------//
//---------------------------------------------------//
//FIN FUNCIONES DE EDICION DEL PUNTO DEL EQUIPO      //
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

//FUNCION OBTENER DATOS ACPETADO POR
function getDatoAceptadoPor(jefe_id) {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getDatoAceptadoPor",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "idjefe": jefe_id }),
        success: function (data, status) {
            var arrAcepta = data.d;
            $('._txtMailJefe_').val(arrAcepta[0]);
            $('._txtCargoJefe_').val(arrAcepta[1]);            
        },
        error: function (data) {
            alert("Error al buscar datos del jefe");
        }
    });
}

//---------------------------------------------------//
//---------------------------------------------------//
//  FUNCIONES DE SELECT, UPDATE, INSERT COTIZACION   //
//---------------------------------------------------//
//---------------------------------------------------//
function insCotizacion() {//INSERT COTIZACION
    tipoOperacion = "INS";
    if (validaIngresoCotizacion()) {
        alert(msgValCot);
    } else {
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/insObjCotizacion",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "cot": CotizacionObject(), "trans": CotizacionTransObject(), "comi": CotizacionComisObject() }),
        success: function (data, status) {
            window.location = "../load.aspx";
            imprimeCotizacion();
        },
        error: errorOperacionCotizacion //function (result, status, err) {
            //alert("Error al guardar/imprimir cotizacion");
            //var err_txt = $.parseJSON(result.responseText);
            //alert(err_txt.Message);
        //}
    });
    }
}

function updCotizacion() { //UPDATE COTIZACION
    tipoOperacion = "UPD";
    if (validaIngresoCotizacion()) {
        alert(msgValCot);
    } else {
        $.ajax({
            type: "POST",
            url: "/asmx_files/js_llenado.asmx/updObjCotizacion",
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ "cot": CotizacionObject(), "trans": CotizacionTransObject(), "comi": CotizacionComisObject() }),
            success: function (data, status) {
                //window.location = "../load.aspx";
                //window.setTimeout(imprimeCotizacion(), 2000);
                alert("Actualizado");
                verDocCotizacion(CotizacionObject().cot_numero, CotizacionObject().cot_id);
            },
            error: errorOperacionCotizacion //function (data) {
                //alert("Error al actualizar/imprimir cotizacion");
            //}
        });
    }
}

function seleccionaCotizacion(num) {//SELECT COTIZACION
    tipoOperacion = "SEL";
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/selObjCotizacion",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "numcot": num }),
        success: function (data, status) {
            var cotData = data.d;

            /*LIMPIA SECTOR OTROS COSTOS*/
            limpiaCostosBusqueda();
            bloqueaCampoComision();
            $("#btnAddComision").attr('disabled', 'disabled');
            $('._cboLugarComision_').val("0");
            
            /*ENCABEZADO COTIZACION*/
            $('._txtIdCotNum_').val(cotData.cot_numero);
            $('._txtIdCotTxt_').val(cotData.cot_id);
            $('._cboTipoCotizacion_').val(cotData.tc_id);
            $('._txtFecha_').val(cotData.cot_fecha);
            $("#txt_Fecha").val(cotData.cot_fecha);
            $('._txtCuenta_').val(cotData.cot_cuentacli);
            $('._cboVendedor_').val(cotData.ven_id);
            getEmailVendedor(cotData.ven_id);
            $('._txtReferencia_').val(cotData.cot_referencia);
            $('._txtClienteInforme_').val(cotData.cot_informecli);
            $('._txtClienteCertificado_').val(cotData.cot_certificado_dir);
            $('._txtContactoCliente_').val(cotData.cot_contacto_nom);
            $('._txtDireccionCliente_').val(cotData.cot_contacto_dir);
            $('._txtMailCliente_').val(cotData.cot_contacto_mail);
            $('._txtFonoCliente_').val(cotData.cot_contacto_ff);
            $('._txtIdCliente_').val(cotData.cot_id_cliente)
            getNomCliente(cotData.cot_id_cliente);
            $('._cboTipoTarifa_').val(cotData.tt_id);
            $('._cboEstadoCotizacion_').val(cotData.ec_id);
            $('._txtEstadoCot_').val(cotData.ec_id);
            $("#txtId_Cotizacion").val(cotData.cot_id);
            $('._txtIdCotizacion_').val(cotData.cot_id);

            /*ENCABEZADO COMISION*/
            if (cotData.CotizacionComision != null) {
                $('._txtIdComis_').val(cotData.CotizacionComision.ccom_id);
                $("#txt-com-qty-persona").val(cotData.CotizacionComision.ccom_qtypersona);
                $("#txt-com-qty-dia").val(cotData.CotizacionComision.ccom_qtydia);
                $("#txt-com-qty-veh").val(cotData.CotizacionComision.ccom_qtyveh);
                $("#txt-com-eq-c").val(cotData.CotizacionComision.ccom_qtranseqt);
                $("#txt-com-eq-a").val(cotData.CotizacionComision.ccom_qtranseqa);
                $("#txt-com-fondo-rendir").val(cotData.CotizacionComision.ccom_fondor);
                $("#txt-com-rep-gasto").val(cotData.CotizacionComision.ccom_qgasrepr);
                $("#txt-com-qty-com-mes").val(cotData.CotizacionComision.ccom_qtycommes);

                $('._cboLugarComision_').val(cotData.CotizacionComision.lug_id);
                $("#txt-com-trans-dts").val(cotData.CotizacionComision.ccom_transdts);
                $("#txt-com-trans-hotel").val(cotData.CotizacionComision.ccom_transhotel);
                $("#txt-com-trans-av-per").val(cotData.CotizacionComision.ccom_psjavionper);
                $("#txt-com-arr-veh").val(cotData.CotizacionComision.ccom_alqveh);
                $("#txt-com-tras-eq-c").val(cotData.CotizacionComision.ccom_transeqt);
                $("#txt-com-tras-eq-a").val(cotData.CotizacionComision.ccom_transeqa);
                $("#txt-com-viatico").val(cotData.CotizacionComision.ccom_viatico);
                $("#txt-com-hotel").val(cotData.CotizacionComision.ccom_hotel);
                $("#txt-com-fondo-rend").val(cotData.CotizacionComision.ccom_frendir);
                $("#txt-com-gasto-rep").val(cotData.CotizacionComision.ccom_gasrepr);
                $("#txt-com-tot-cos-com").val(cotData.CotizacionComision.ccom_totalcom);
                $("#txt-com-tot-p-com").val(cotData.CotizacionComision.ccom_totalcommg);

                desbloqueaCampoComision();
                $("#btnAddComision").removeAttr('disabled');
            }

            /*ENCABEZADO TRANSPORTE*/
            if (cotData.CotizacionTransporte != null) {
                $("#chkTransporte").prop('checked', true);
                $('._cboRegion_').val(cotData.CotizacionTransporte.reg_id);
                //$("#txtDirTransporte").val(cotData.CotizacionTransporte.ctrans_direccion);
                $('._cboTraslado_').val(cotData.CotizacionTransporte.ten_id);
                $("#txtTotalTransporte").val(cotData.CotizacionTransporte.ctrans_total);
                $('._txtIdTrans_').val(cotData.CotizacionTransporte.ctrans_id);

                //$("#txtDirTransporte").prop("disabled", false);
                $('._cboRegion_').prop("disabled", false);
                $('._cboTraslado_').prop("disabled", false);
                $("#btnAddTransporte").removeAttr('disabled');
            }

            /*ENCABEZADO NOTAS*/
            $('._txtNotaUno_').val(cotData.cot_notauno);
            $('._txtNotaDos_').val(cotData.cot_notados);

            /*ENCABEZADO TOTALES*/
            $('._cboTipoImpuesto_').val(cotData.cot_afecto);
            $("#txtTipoMoneda").val(cotData.cot_tipomoneda);
            $("#txtTotalCostoMo").val(cotData.cot_totcostmo);
            $("#txtTotalCostoRpto").val(cotData.cot_totvalrpto);
            $("#txtMgOpPorc").val(cotData.cot_mgopporc);
            $("#txtMgBrutoPorc").val(cotData.cot_mgbrutoporc);
            $("#txtMgContribucion").val(cotData.cot_mgcontrib);
            $("#txtMgContribucionPorc").val(cotData.cot_mgcontribporc);
            $("#txtUtilidadEspPorc").val(cotData.cot_utilesperaporc);
            $("#txtNeto").val(cotData.cot_neto);
            $("#txtDctoPorc").val(cotData.cot_dcto_porc);
            $("#txtDcto").val(cotData.cot_descuento);
            $("#txtNetoDcto").val(cotData.cot_netodcto);
            $("#txtIva").val(cotData.cot_iva);
            $("#txtTotal").val(cotData.cot_total);

            if (cotData.cot_chkdcto == "Y") {
                $('._chkDcto_').find('>:first-child').prop('checked', true); // find('>:first-child').is(':checked')
                $("#txtDcto").removeAttr("disabled");
            } else {
                $('._chkDcto_').find('>:first-child').prop('checked', false); // find('>:first-child').is(':checked')
                $("#txtDcto").attr("disabled", "disabled");
            }

            /*ENCABEZADO FACTURACION*/
            $('._cboFacturacion_').val(cotData.tf_id);
            $('._txtFacturacion_').val(cotData.cot_txtfacturacion);
            $('._cboFormaPago_').val(cotData.tfpf_id);
            $('._txtFormaPago_').val(cotData.cot_txtformapago);
            $("#txtPlazoEntregaD").val(cotData.cot_plazo_entrega);
            $('._txtPlazoEntrega_').val(cotData.cot_txttpe);

            /*ENCABEZADO GARANTIA*/
            $('._cboEjecTrab_').val(cotData.tlej_id);
            $('._cboLugarRetiro_').val(cotData.cot_tipo_retiro);
            $('._txtSectorRetiro_').val(cotData.cot_secretiro_dir);
            $('._txtSectorRetiroNom_').val(cotData.cot_secretiro_nom);
            $('._cboLugarEntrega_').val(cotData.tle_id);
            $('._txtSectorEntrega_').val(cotData.cot_secentrega);
            $('._txtValidezOferta_').val(cotData.cot_valioferta);
            $('._cboGarantia_').val(cotData.tg_id);
            $('._cboValidezGar_').val(cotData.tvg_id);
            $('._cboJefe_').val(cotData.jef_id);
            getDatoAceptadoPor(cotData.jef_id);

            /*ENCABEZADO NP SANP*/
            $("#txtNroCaso").val(cotData.NpSanp.sanp_nro_caso);
            $("#txtVaCaso").val(cotData.NpSanp.sanp_va_caso);
            $("#txtTotalCaso").val(cotData.NpSanp.sanp_total_caso);
            $('._txtNPCaso_').val(cotData.NpSanp.sanp_np_caso);

            if ($("#dialog-busca-cot").hasClass('ui-dialog-content')) {
                $("#dialog-busca-cot").dialog('close');
            }

            $('._btnBuscaDetalleCot_').click();

            //$.cookie('acredi', cotData.tpe_id);
            //$('._btnUpdDatoEquipo_').click();
            //$('._btnUpdateDoc_').click();
        },
        error: errorOperacionCotizacion //function (data) {
            //alert("Error al cargar cotizacion");
        //}
    });
}

function errorOperacionCotizacion(result, status, err) {
    var err_txt;
    var title_txt;

    if (tipoOperacion == "INS") {
        title_txt = "Error al Guardar/Imprimir Cotización";
    } else if (tipoOperacion == "UPD") {
        title_txt = "Error al Actualizar/Imprimir Cotización";
    } else if (tipoOperacion == "SEL") {
        title_txt = "Error al Cargar Cotización";
    } else if (tipoOperacion == "DET") {
        title_txt = "Error Al Guardar Equipo";
    } else if (tipoOperacion == "DIV") {
        title_txt = "Error Al Calcular Cambio Divisa";
    }

    $("#dialog-error").html("");
    try {
        err_txt = $.parseJSON(result.responseText);
        $("#dialog-error").append("<div><b>" + status + " " + err + "</b></div><br/>");
        $("#dialog-error").append("<div><u>Excepción</u>:<br />" + err_txt.ExceptionType + "</div><br/><br/>");
        //$("#dialog-error").append("<div><u>StackTrace</u>:<br /><br />" + err_txt.StackTrace + "</div>");
        $("#dialog-error").append("<div><u>Mensaje</u>:<br />" + err_txt.Message + "</div>");
    } catch (e) {
        err_txt = result.responseText;
        $("#dialog-error").html(err_txt);
    }
    $("#dialog-error").dialog({
        title: title_txt,
        width: 700,
        modal: true,
        buttons: {
            "Cerrar": function () {
                $(this).dialog('close');
            }
        }
    });
}

function verDocCotizacion(numc, txtc, acred) {//MOSTRAR COTIZACION DESDE BUSCADOR COTIZACION
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/selDocuCotizacion",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "numcot": numc, "txtcot": txtc }), //, "acredito": acred }),
        success: function (data, status) {
            imprimeCotizacion();
        },
        error: function (data) {
            alert("Error al mostrar documento de cotizacion");
        }
    });
}
//---------------------------------------------------//
//---------------------------------------------------//
// FIN FUNCIONES DE SELECT, UPDATE, INSERT COTI      //
//---------------------------------------------------//
//---------------------------------------------------//

function imprimeCotizacion() {//IMPRIME REPORTE DE COTIZACION
    window.open('/frm_reporte/rpt_cotizacion_cal.aspx');
}

function limpiaCostosBusqueda() {
    $("#chkTransporte").prop('checked', false);
    $("#txtDirTransporte").prop("disabled", true);
    $('._cboRegion_').prop("disabled", true);
    $('._cboTraslado_').prop("disabled", true);
    $("#btnAddTransporte").attr('disabled', 'disabled');

    $('._cboRegion_').val("0");
    $("#txtDirTransporte").val("");
    $('._cboTraslado_').val("0");
    $("#txtTotalTransporte").val("");
    /*******************************/


}
/*** INI FUNCIONES BUSQUEDA COTIZACION ***/

/*** FIN FUNCIONES BUSQUEDA COTIZACION ***/

/*** INI FUNCIONES CARGA COMBO BUSQUEDA COTIZACION ***/


/*** INI FUNCIONES CARGA COMBO BUSQUEDA COTIZACION ***/

function extenderCookie(v_cookie) {//FUNCION PARA EXTENDER LA COOKIE DE LA PAGINA
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/extendCookie",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "vcookie": v_cookie }),
        success: function (data, status) {

        },
        error: function (data) {
            alert("Error al extender sesion");
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

function validaNparteNserie() {
    var fl_valida;
    if (($("#txt-eq-read-np").val() == "" || $("#txt-eq-read-np").val() == null) || ($("#txt-eq-read-ns").val() == "" || $("#txt-eq-read-ns").val() == null) || ($('._cboeqreadlprod_').val() == "" || $('._cboeqreadlprod_').val() == "N")) {
        fl_valida = true;
    } else {
        fl_valida = false;
    }
    return fl_valida;
}

function validaIngresoDetEquipo() {
    var cotid, equid, nropa, fl_inequ;
    $('.cssDetEq').each(function () {
        cotid = $('.equipocotid_', $(this).closest('tr')).html();
        equid = $('.equipoid_', $(this).closest('tr')).html();
        nropa = $('.equiponparte_', $(this).closest('tr')).html();

        if (cotid == $.cookie('pcusr') && equid == $("#txt-eq-read-id").val() && nropa == $("#txt-eq-read-np").val()) {            
            fl_inequ = true;
        } else {
            fl_inequ = false;
        }
    });
    return fl_inequ;
}

function getNumeroFilaGVDetCot() {
    var nrofila = 1;
    if (!$('.cssDetEq').length) {
        nrofila = 1;
    } else {
        $('.cssDetEq').each(function () {
            nrofila = nrofila + 1;
        });
    }
    return nrofila;
}

function validaCantidadGVDetCot() {
    var hasRows = false;
    if ($('.cssDetEq').length) {
        hasRows = true;
    }
    return hasRows;
}

//Funcion que al cambiar divisa, cambiara valores del detalle
function calculoCambioDivisa(curTarifa, prevTarifa, fechaCot, numCoti) {
    tipoOperacion = "DIV";
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/calCambioDivisa",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "curTarifa": curTarifa, "prevTarifa": prevTarifa, "fechaCot": fechaCot, "numCoti": numCoti }),
        success: function (data, status) {
            $("#txtIdTipoTarifa").val($('._rblSelectDivisa_').find(":checked").val());
            $("#txtIdTipoTarifaPrev").val($('._rblSelectDivisa_').find(":checked").val());
            $("#txtTipoTarifa").val($('._rblSelectDivisa_').find(":checked").next().html());
            $('._rblSelectDivisa_').removeAttr('checked');
        },
        error: errorOperacionCotizacion
        //error: function (data) {
        //    alert("Error al calcular el cambio de divisa");
        //}
    });
}

function cambioFechaCotizacion(sender, args) {
    var fCot = sender.get_selectedDate();
    var fCotVence = $find("nuevaFechaVence");
    var fCotCotiz = $find("nuevaFechaCotiza");

    if (fCot > new Date()) {
        alert("La fecha no puede ser mayor a hoy");
        var fnew = new Date();
        fnew = new Date(fnew.getTime() + fnew.getTimezoneOffset() * 60000);
        var fCotCot = new Date(fnew.setDate(fnew.getDate()));
        fCotCotiz.set_selectedDate(fCotCot);
    } else {
        fCot = new Date(fCot.getTime() + fCot.getTimezoneOffset() * 60000);
        var fCotVenc = new Date(fCot.setDate(fCot.getDate() + 30));
        fCotVence.set_selectedDate(fCotVenc);
    }
}

function deshabilitaFinDeSemana(sender, args) {
    for (var i = 0; i < 6; i++) {
        var row = sender._days.children[0].childNodes[1].children[i];
        for (var j = 0; j < 7; j++) {
            var cell = row.children[j].firstChild;

            if (cell.id == sender._id + "_day_" + i + "_" + "5") {
                cell.style.display = "none";
            }
            if (cell.id == sender._id + "_day_" + i + "_" + "6") {
                cell.style.display = "none";
            }
        }
    }
}

function verificaChkDcto() {
    var txtChkDcto = "";
    if ($('._chkDcto_').find('>:first-child').is(':checked')) {
        txtChkDcto = "Y";
    } else {
        txtChkDcto = "N";
    }
    return txtChkDcto;
}

function verificaChkExc() {
    var txtChkExc = "";
    if ($('._chkExcede_').find('>:first-child').is(':checked')) {
        txtChkExc = "Y";
    } else {
        txtChkExc = "N";
    }
    return txtChkExc;
}

var msgValCot = "";
function validaIngresoCotizacion() {
    var flagValCot = false;
//    var validaNumero = new RegExp(' /^\d*$/'); //'^\d+$');
//    var plazoEntrega = $("#txtPlazoEntregaD").val();
    msgValCot = "";

    if ($('._cboTipoCotizacion_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar un tipo de cotizacion.\n";
        flagValCot = true;
    }
    if ($('._cboVendedor_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar un vendedor.\n";
        flagValCot = true;
    }
    if ($('._txtCliente_').val() == "") {
        msgValCot = msgValCot + "Debe seleccionar un cliente.\n";
        flagValCot = true;
    }
    if ($('._txtClienteInforme_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un cliente informe.\n";
        flagValCot = true;
    }
    if ($('._txtClienteCertificado_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar direccion de certificado.\n";
        flagValCot = true;
    }
    if ($('._txtContactoCliente_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un nombre de contacto.\n";
        flagValCot = true;
    }
    if ($('._txtDireccionCliente_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar una direccion de contacto.\n";
        flagValCot = true;
    }
    if ($('._txtMailCliente_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un mail de contacto.\n";
        flagValCot = true;
    }
    if ($('._txtFonoCliente_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un fono de contacto.\n";
        flagValCot = true;
    }
    if ($('._cboTipoTarifa_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar un tipo de tarifa.\n";
        flagValCot = true;
    }
    if ($('._cboTipoImpuesto_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar si es afecto.\n";
        flagValCot = true;
    }
    if ($('._cboFacturacion_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar un tipo de facturacion.\n";
        flagValCot = true;
    }
    if ($('._txtFacturacion_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un tipo de facturacion.\n";
        flagValCot = true;
    }
    if ($('._cboFormaPago_').val() == "0") {
        msgValCot = msgValCot + "Debe ingresar un tipo de forma de pago.\n";
        flagValCot = true;
    }
    if ($('._txtFormaPago_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un texto de forma de pago.\n";
        flagValCot = true;
    }
    if ($("#txtPlazoEntregaD").val() == "0" || $("#txtPlazoEntregaD").val()=="") {
        msgValCot = msgValCot + "Debe ingresar un plazo de entrega o el plazo de entrega es 0.\n";
        flagValCot = true;
    }
//    if (!validaNumero.test(plazoEntrega)) {
//        msgValCot = msgValCot + "El plazo de entrega debe ser un numero valido.\n";
//        flagValCot = true;
//    }
    if ($('._txtPlazoEntrega_').val() == "") {
        msgValCot = msgValCot + "Debe ingresar un texto de plazo de entrega.\n";
        flagValCot = true;
    }
    if ($('._cboEjecTrab_').val() == "0") {
        msgValCot = msgValCot + "Debe ingresar ejecucion de trabajos.\n";
        flagValCot = true;
    }
    if ($('._cboLugarRetiro_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar un lugar de retiro.\n";
        flagValCot = true;
    } else {
        if ($('._cboLugarRetiro_').val() == "" || $('._txtSectorRetiroNom_').val() == "") {
            msgValCot = msgValCot + "Debe ingresar lugar y nombre en sector de retiro.\n";
            flagValCot = true;
        }
    }
    if ($('._cboLugarEntrega_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar un lugar de entrega.\n";
        flagValCot = true;
    }
    if ($('._cboGarantia_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar garantia.\n";
        flagValCot = true;
    }
    if ($('._cboValidezGar_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar validez de garantia.\n";
        flagValCot = true;
    }
    if ($('._cboJefe_').val() == "0") {
        msgValCot = msgValCot + "Debe seleccionar una persona para aprobacion.\n";
        flagValCot = true;
    }

    return flagValCot;
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

function CotizacionObject() {
    var objCoti = {};
    objCoti.cot_numero = $('._txtIdCotNum_').val() || "-";
    objCoti.cot_id = $('._txtIdCotTxt_').val() || "-";
    objCoti.cot_un_id = $('._txtIdUniNeg_').val();
    objCoti.cot_fecha = $('._txtFecha_').val();
    objCoti.cot_referencia = $('._txtReferencia_').val();
    objCoti.cot_id_cliente = $('._txtIdCliente_').val();
    objCoti.cot_cuentacli = $('._txtCuenta_').val();
    objCoti.cot_informecli = $('._txtClienteInforme_').val();
    objCoti.cot_contacto_nom = $('._txtContactoCliente_').val();
    objCoti.cot_contacto_dir = $('._txtDireccionCliente_').val();
    objCoti.cot_contacto_cargo = "";
    objCoti.cot_contacto_ff = $('._txtFonoCliente_').val();
    objCoti.cot_contacto_fc = "";
    objCoti.cot_contacto_mail = $('._txtMailCliente_').val();
    objCoti.cot_notauno = $('._txtNotaUno_').val();
    objCoti.cot_notados = $('._txtNotaDos_').val();
    objCoti.cot_txtfacturacion = $('._txtFacturacion_').val();
    objCoti.cot_txtformapago = $('._txtFormaPago_').val();
    objCoti.cot_txttpe = $('._txtPlazoEntrega_').val();
    objCoti.cot_plazo_entrega = $("#txtPlazoEntregaD").val();
    objCoti.cot_secentrega = $('._txtSectorEntrega_').val();
    objCoti.cot_tipo_retiro = $('._cboLugarRetiro_').val();
    objCoti.cot_secretiro_dir = $('._txtSectorRetiro_').val();
    objCoti.cot_secretiro_nom = $('._txtSectorRetiroNom_').val();
    objCoti.cot_certificado_dir = $('._txtClienteCertificado_').val();
    objCoti.cot_valioferta = $('._txtValidezOferta_').val();
    objCoti.cot_totcostmo = $("#txtTotalCostoMo").val();
    objCoti.cot_totvalrpto = $("#txtTotalCostoRpto").val();
    objCoti.cot_mgopporc = $("#txtMgOpPorc").val();
    objCoti.cot_mgbrutoporc = $("#txtMgBrutoPorc").val();
    objCoti.cot_mgcontrib = $("#txtMgContribucion").val();
    objCoti.cot_mgcontribporc = $("#txtMgContribucionPorc").val();
    objCoti.cot_utilesperaporc = $("#txtUtilidadEspPorc").val();
    objCoti.cot_afecto = $('._cboTipoImpuesto_').val();
    objCoti.cot_tipomoneda = $("#txtTipoMoneda").val();
    objCoti.cot_neto = $("#txtNeto").val();
    objCoti.cot_descuento = $("#txtDcto").val();
    objCoti.cot_netodcto = $("#txtNetoDcto").val();
    objCoti.cot_iva = $("#txtIva").val();
    objCoti.cot_total = $("#txtTotal").val();
    objCoti.cot_chkdcto = verificaChkDcto();// $('._chkDcto_').val();
    objCoti.cot_chkex = verificaChkExc();
    objCoti.cot_usrpc = $.cookie('pcusr');
    objCoti.tf_id = $('._cboFacturacion_').val(); //int
    objCoti.tvg_id = $('._cboValidezGar_').val();
    objCoti.tg_id = $('._cboGarantia_').val();
    objCoti.tfpf_id = $('._cboFormaPago_').val();
    objCoti.tlej_id = $('._cboEjecTrab_').val();
    objCoti.tt_id = $('._cboTipoTarifa_').val();
    objCoti.ec_id = $('._txtEstadoCot_').val();
    objCoti.tc_id = $('._cboTipoCotizacion_').val();
    objCoti.jef_id = $('._cboJefe_').val();
    objCoti.ven_id = $('._cboVendedor_').val();
    objCoti.tle_id = $('._cboLugarEntrega_').val(); //fin int

    return objCoti;
}

function CotizacionTransObject() {
    var objCotiTrans = {};
    objCotiTrans.ctrans_id = $('._txtIdTrans_').val() || "-";
    objCotiTrans.cot_numero = $('._txtIdCotNum_').val() || "-";
    objCotiTrans.ctrans_total = $("#txtTotalTransporte").val();
    objCotiTrans.reg_id = $('._cboRegion_').val();
    objCotiTrans.ten_id = $('._cboTraslado_').val();
    objCotiTrans.ctrans_direccion = "N/A";// $("#txtDirTransporte").val();

    return objCotiTrans;
}

function CotizacionComisObject() {
    var objCotiComis = {};
    objCotiComis.ccom_id = $('._txtIdComis_').val() || "-";
    objCotiComis.ccom_qtypersona = $("#txt-com-qty-persona").val();
    objCotiComis.ccom_qtydia = $("#txt-com-qty-dia").val();
    objCotiComis.ccom_qtyveh = $("#txt-com-qty-veh").val();
    objCotiComis.ccom_qtranseqt = $("#txt-com-eq-c").val();
    objCotiComis.ccom_qtranseqa = $("#txt-com-eq-a").val();
    objCotiComis.ccom_fondor = $("#txt-com-fondo-rendir").val();
    objCotiComis.ccom_qgasrepr = $("#txt-com-rep-gasto").val();
    objCotiComis.ccom_qtycommes = $("#txt-com-qty-com-mes").val();
    objCotiComis.ccom_transdts = $("#txt-com-trans-dts").val();
    objCotiComis.ccom_transhotel = $("#txt-com-trans-hotel").val();
    objCotiComis.ccom_psjavionper = $("#txt-com-trans-av-per").val();
    objCotiComis.ccom_alqveh = $("#txt-com-arr-veh").val();
    objCotiComis.ccom_transeqt = $("#txt-com-tras-eq-c").val();
    objCotiComis.ccom_transeqa = $("#txt-com-tras-eq-a").val();
    objCotiComis.ccom_viatico = $("#txt-com-viatico").val();
    objCotiComis.ccom_hotel = $("#txt-com-hotel").val();
    objCotiComis.ccom_frendir = $("#txt-com-fondo-rend").val();
    objCotiComis.ccom_gasrepr = $("#txt-com-gasto-rep").val();
    objCotiComis.ccom_totalcom = $("#txt-com-tot-cos-com").val();
    objCotiComis.ccom_totalcommg = $("#txt-com-tot-p-com").val();
    objCotiComis.lug_id = $('._cboLugarComision_').val();
    objCotiComis.cot_numero = $('._txtIdCotNum_').val() || "-";

    return objCotiComis;
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

function getSigebasePwd() {//FUNCION PARA EXTENDER LA COOKIE DE LA PAGINA
    $.ajax({
        type: "POST",
        url: "/asmx_files/js_llenado.asmx/getPwdSigepac",
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ "pwd": "12345", "pwdkey": "DTSSIGEBASE" }),
        success: function (data, status) {
            alert(data.d);
        },
        error: function (data) {
            alert(data.d);
        }
    });
}