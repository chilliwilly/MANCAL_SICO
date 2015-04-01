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

//FUNCION LLAMADA AL MOMENTO DE QUEERER AGREGAR PUNTOS AL EQUIPO
function dialogPunto() {
    $("#dialog-equipo-punto").dialog({
        modal: true,
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
            //$.each(arr, function (index, a) {
            //    alert(a);
            //});
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