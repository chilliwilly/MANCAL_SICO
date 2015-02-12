using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_adjunto
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public void insertArchivo(String nomarch, String dirarch, String idinput) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_ARCHIVO.SP_INSERT_ARCHIVO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("nomarch", OracleDbType.Varchar2)).Value = nomarch;
                    cmd.Parameters["nomarch"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("dirarch", OracleDbType.Varchar2)).Value = dirarch;
                    cmd.Parameters["dirarch"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("idnarch", OracleDbType.Varchar2)).Value = idinput;
                    cmd.Parameters["idnarch"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void deleteArchivo(int numarch, String idncotiz) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_ARCHIVO.SP_DELETE_ARCHIVO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("itnarch", OracleDbType.Int32)).Value = numarch;
                    cmd.Parameters["itnarch"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("idnarch", OracleDbType.Varchar2)).Value = idncotiz;
                    cmd.Parameters["idnarch"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataSet selectArchivo(String idncotiz) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_ARCHIVO.FN_SELECT_ARCHIVO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_select", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("idnarch", OracleDbType.Varchar2)).Value = idncotiz;
                    cmd.Parameters["idnarch"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_select");
                    }
                }
                con.Close();
            }
            return ds;
        }
    }
}
