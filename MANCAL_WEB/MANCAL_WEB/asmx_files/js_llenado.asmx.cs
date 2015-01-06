﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MANCAL_WEB_BL;

namespace MANCAL_WEB.asmx_files
{
    /// <summary>
    /// Descripción breve de js_llenado
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class js_llenado : System.Web.Services.WebService
    {

        [WebMethod]
        public String lsNroParte()
        {
            bl_equipo objEquipo = new bl_equipo();

            return objEquipo.listaEquipo();
        }
    }
}
