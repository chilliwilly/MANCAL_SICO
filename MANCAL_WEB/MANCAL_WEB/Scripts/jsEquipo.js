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