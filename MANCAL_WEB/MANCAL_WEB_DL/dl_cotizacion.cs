﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_cotizacion
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public String insertCotizacion(String dataCot, String dataTrans, String dataComi) 
        {
            String varOut = "";

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT.SP_MANCAL_INSERT_COT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_COT", OracleDbType.Clob)).Value = dataCot;
                    cmd.Parameters["P_DATO_COT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_COT_TRANS", OracleDbType.Clob)).Value = dataTrans;
                    cmd.Parameters["P_DATO_COT_TRANS"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_COT_COMI", OracleDbType.Clob)).Value = dataComi;
                    cmd.Parameters["P_DATO_COT_COMI"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_VAR_PRINT", OracleDbType.Varchar2, 100)).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    varOut = cmd.Parameters["P_VAR_PRINT"].Value.ToString();
                }
                con.Close();
            }
            return varOut;
        }

        public void updateCotizacion(String dataCot, String dataTrans, String dataComi) 
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_MANCAL_DMLCOT.SP_MANCAL_UPDATE_COT";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_COT", OracleDbType.Clob)).Value = dataCot;
                    cmd.Parameters["P_DATO_COT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_COT_TRANS", OracleDbType.Clob)).Value = dataTrans;
                    cmd.Parameters["P_DATO_COT_TRANS"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DATO_COT_COMI", OracleDbType.Clob)).Value = dataComi;
                    cmd.Parameters["P_DATO_COT_COMI"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataSet selectCotizacion(int? dataVendedor, int? dataEstadoCot, int? dataCliente, int? dataCotiNum, String dataCotiText) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                con.BeginTransaction();
                String qry = "PKG_MANCAL_DMLCOT.FN_MANCAL_SELECT_COT";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_COTIZACION", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_NRO_VENDEDOR", OracleDbType.Int32)).Value = dataVendedor;
                    cmd.Parameters["P_NRO_VENDEDOR"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NRO_ESTADOCOT", OracleDbType.Int32)).Value = dataEstadoCot;
                    cmd.Parameters["P_NRO_ESTADOCOT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NRO_CLIENTE", OracleDbType.Int32)).Value = dataCliente;
                    cmd.Parameters["P_NRO_CLIENTE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NRO_COTINUM", OracleDbType.Int32)).Value = dataCotiNum;
                    cmd.Parameters["P_NRO_COTINUM"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TXT_COTINUM", OracleDbType.Varchar2)).Value = dataCotiText;
                    cmd.Parameters["P_TXT_COTINUM"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_COTIZACION");
                    }
                }
                con.Close();
            }

            return ds;
        }

        
    }
}
