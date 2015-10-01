function CallService() {
    //Creamos la variable que contiene la url del webservice
    var webServiceURL = 'http://172.29.0.150:8090/ENCRIPTA_USR_WS_WEB/awws/Encripta_ws.awws?wsdl';
    //Este es el mensaje SOAP, dentro de las etiquetas <CI>'+ $('#ci').val() +'</CI> hacemos uso de una función JQuery para obtener valor que está en el campo de texto
    var soapMessage = '<?xml version="1.0" encoding="utf-8"?><s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Header><Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">urn:Encripta_ws/Encripta</Action></s:Header><s:Body><valor>' + $('#CI').val() + '</valor><password>' + $('#keyPwd').val() + '</password></s:Body></s:Envelope>';
    //'<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><ObtenerEstudianteDadoCI xmlns="urn:akademos"><CI>' + $('#ci').val() + '</CI></ObtenerEstudianteDadoCI></soap:Body></soap:Envelope>';

    //Llamamos a la función AJAX de JQuery
    $.ajax({
        url: webServiceURL,
        type: "POST",
        cache: false,
        data: soapMessage,
        contentType: "text/xml",
        success: OnSuccess,
        error: OnError
    });
    return false;
}
//Función que se ejecuta si realizó completa la petición
function OnSuccess(data, status) {
    //Aquí mostramos el valor que aparece en la etiqueta "PrimerNombre" del cuerpo de respuesta
    alert($(data).find("EncriptaResult").text());
}
function OnError(request, status, error)  //Función que se ejecuta si ocurre algún error
{
    alert(status);
}
$(function () {
    //Evita problemas de cross-domain con JQuery
    jQuery.support.cors = true;
});

var requete;
function construitxml() {
    requete = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/1999/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/1999/XMLSchema\"><soap:Body>";


    requete = requete + "<valor xsd:type=\"xsd:string\" xmlns=\"urn:Encripta_ws\">";
    requete = requete + $('#CI').val();//document.getElementById("valor").value;
    requete = requete + "</valor>";

    requete = requete + "<password xsd:type=\"xsd:string\" xmlns=\"urn:Encripta_ws\">";
    requete = requete + $('#keyPwd').val();//document.getElementById("password").value;
    requete = requete + "</password>";


    requete = requete + "</soap:Body></soap:Envelope>";
    //document.xmlform.xml.value = requete;
    //document.xmlform.action.value = "urn:Encripta_ws/Encripta";
    //document.xmlform.submit();            
}

function soap() {
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open('POST', 'http://172.29.0.150:8090/ENCRIPTA_USR_WS_WEB/awws/Encripta_ws.awws?wsdl', true);

    // build SOAP request
    var sr = '<?xml version="1.0" encoding="utf-8"?><s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Header><Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">urn:Encripta_ws/Encripta</Action></s:Header><s:Body><valor>' + $('#CI').val() + '</valor><password>' + $('#keyPwd').val() + '</password></s:Body></s:Envelope>';
    construitxml();
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {

                alert('done use firebug to see response');
            }
        }
    }
    // Send the POST request
    xmlhttp.setRequestHeader('Content-Type', 'text/xml');
    xmlhttp.send(requete);
    // send request
    // ...
}

function soapjquery() {
    $.soap({
        url: 'http://172.29.0.150:8090/ENCRIPTA_USR_WS_WEB/awws/Encripta_ws.awws?wsdl',
        method: 'Encripta',
        data: {
            valor: '12345',
            password: 'DTSSIGEBASE'
        },

        success: function (soapResponse) {
            // do stuff with soapResponse
            // if you want to have the response as JSON use soapResponse.toJSON();
            // or soapResponse.toString() to get XML string
            // or soapResponse.toXML() to get XML DOM
            alert(soapResponse.toString());
        },
        error: function (SOAPResponse) {
            // show error
        }
    });
}

function soapajax() {
    var wsUrl = "http://172.29.0.150:8090/ENCRIPTA_USR_WS_WEB/awws/Encripta_ws.awws?wsdl";
    var soapRequest = '<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/"><s:Header><Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">urn:Encripta_ws/Encripta</Action></s:Header><s:Body><valor>' + $('#CI').val() + '</valor><password>' + $('#keyPwd').val() + '</password></s:Body></s:Envelope>';
    alert(soapRequest)
    $.ajax({
        type: "POST",
        url: wsUrl,
        contentType: "text/xml",
        dataType: "xml",
        data: soapRequest,
        success: processSuccess,
        error: processError
    });
}

function processSuccess(data, status, req) { alert('success');
    if (status == "success")
        $(req.responseXML).find("EncriptaResult").text();
        //$("#response").text($(req.responseXML).find("Result").text());

    alert($(req.responseXML).find("EncriptaResult").text());
}

function processError(data, status, req) {
    alert('err'+data.state);
    //alert(req.responseText + " " + status);
} 