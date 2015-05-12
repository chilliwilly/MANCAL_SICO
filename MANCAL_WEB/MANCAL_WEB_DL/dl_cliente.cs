using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace MANCAL_WEB_DL
{
    public class dl_cliente
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public void selectCliente() 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SP_SPAC_SEARCH_CLIENTE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("P_NOMCLI", OracleDbType.Varchar2)).Value = null;
                    cmd.Parameters["P_NOMCLI"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_DIRECCION", OracleDbType.Varchar2)).Value = null;
                    cmd.Parameters["P_DIRECCION"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPO_CLIENTE", OracleDbType.Int32)).Value = null;
                    cmd.Parameters["P_TIPO_CLIENTE"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Int32)).Value = null;
                    cmd.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }                
                con.Close();
            }
        }

        public DataSet selectDTCliente(String cli, String cta, String cont, int tipo, int estado) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                //String qryproc = "SP_SPAC_SEARCH_CLIENTE";
                //using (OracleCommand cmdproc = new OracleCommand(qryproc, con))
                //{
                //    cmdproc.CommandType = CommandType.StoredProcedure;

                //    cmdproc.Parameters.Add(new OracleParameter("P_NOMCLI", OracleDbType.Varchar2)).Value = null;
                //    cmdproc.Parameters["P_NOMCLI"].Direction = ParameterDirection.Input;

                //    cmdproc.Parameters.Add(new OracleParameter("P_DIRECCION", OracleDbType.Varchar2)).Value = null;
                //    cmdproc.Parameters["P_DIRECCION"].Direction = ParameterDirection.Input;

                //    cmdproc.Parameters.Add(new OracleParameter("P_TIPO_CLIENTE", OracleDbType.Int32)).Value = null;
                //    cmdproc.Parameters["P_TIPO_CLIENTE"].Direction = ParameterDirection.Input;

                //    cmdproc.Parameters.Add(new OracleParameter("P_ESTADO", OracleDbType.Int32)).Value = null;
                //    cmdproc.Parameters["P_ESTADO"].Direction = ParameterDirection.Input;

                //    cmdproc.ExecuteNonQuery();
                //}
                
                String qry = "FN_MANCAL_BUSCAR_CLIENTE";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_SELECT_CLI", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_NOMCLI", OracleDbType.Varchar2)).Value = cli;
                    cmd.Parameters["P_NOMCLI"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NOMCTA", OracleDbType.Varchar2)).Value = cta;
                    cmd.Parameters["P_NOMCTA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_NOMCONT", OracleDbType.Varchar2)).Value = cont;
                    cmd.Parameters["P_NOMCONT"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_TIPOCLI", OracleDbType.Int32)).Value = tipo;
                    cmd.Parameters["P_TIPOCLI"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("P_ESTADOCLI", OracleDbType.Int32)).Value = estado;
                    cmd.Parameters["P_ESTADOCLI"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_SELECT_CLI");
                    }
                }
                con.Close();
            }

            return ds;
        }

        public String selectNombreCli(int id_cliente)
        {
            String nom_cli = "";

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry = "FN_MANCAL_GET_NOM_CLI";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("NOM_CLI", OracleDbType.Varchar2, 200)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_ID_CLIENTE", OracleDbType.Int32)).Value = id_cliente;
                    cmd.Parameters["P_ID_CLIENTE"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    nom_cli = cmd.Parameters["NOM_CLI"].Value.ToString();
                }
            }


            return nom_cli;
        }
    }
}