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