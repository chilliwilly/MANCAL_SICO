﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_cliente
    {
        dl_cliente objCliente;

        public List<CotizacionCliente> getListaCliente(String cli, String cta, String cont, String tipo, String estado, String rut, String aliascli) 
        {
            objCliente=new dl_cliente();

            List<CotizacionCliente> ls = new List<CotizacionCliente>();

            String nomcliente = "";
            String ctacliente = "";
            String contcliente = "";
            String rutcliente = "";
            String aliascliente = "";
            int v_tipo;
            int v_estado;

            if (String.IsNullOrEmpty(cli))
            {
                nomcliente = null;
            }
            else
            {
                nomcliente = cli;
            }

            if (String.IsNullOrEmpty(cta))
            {
                ctacliente = null;
            }
            else
            {
                ctacliente = cta;
            }

            if (String.IsNullOrEmpty(cont))
            {
                contcliente = null;
            }
            else 
            {
                contcliente = cont;
            }

            if (String.IsNullOrEmpty(tipo) || tipo.Equals("undefined"))
            {
                v_tipo = 0;
            }
            else 
            {
                v_tipo = Convert.ToInt32(tipo);
            }

            if (String.IsNullOrEmpty(estado) || tipo.Equals("undefined"))
            {
                v_estado = 0;
            }
            else
            {
                v_estado = Convert.ToInt32(estado);
            }

            if (String.IsNullOrEmpty(rut))
            {
                rutcliente = null;
            }
            else
            {
                rutcliente = rut;
            }

            if (String.IsNullOrEmpty(aliascli))
            {
                aliascliente = null;
            }
            else
            {
                aliascliente = aliascli;
            }
            //objCliente.selectCliente();//.Tables["cur_select_cli"];
            DataTable dt = objCliente.selectDTCliente(nomcliente, ctacliente, contcliente, v_tipo, v_estado, rutcliente, aliascliente).Tables["CUR_SELECT_CLI"];


            foreach (DataRow dr in dt.Rows) 
            {
                CotizacionCliente ccli = new CotizacionCliente();
                ccli.idcliente = dr["ID_CLIENTE"].ToString();
                ccli.nomcliente = dr["NOMBRE"].ToString();
                ccli.aliascliente = dr["ALIASCLI"].ToString();
                ccli.nomcuenta = dr["NOMBRE_CTA"].ToString();
                ccli.dircliente = dr["DIRECCION"].ToString();
                ccli.nomcontacto = dr["NOMBRE_CONTACTO"].ToString();
                ccli.cargocontacto = dr["CARGO"].ToString();
                ccli.fonocontacto = dr["TELEFONO"].ToString() + " " + dr["CELULAR"].ToString();
                ccli.mailcontacto = dr["EMAIL"].ToString();

                ls.Add(ccli);
            }

            return ls;
        }

        public String getNombreCli(String cli_id) 
        {
            objCliente = new dl_cliente();
            int idcli = Convert.ToInt32(cli_id);

            return objCliente.selectNombreCli(idcli);
        }
    }
}
