using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace MANCAL_WEB_DL
{
    public class dl_login
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public DataTable selectUsuario() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "SELECT USR_USRPC, USR_PWD, USR_ESTADO, USR_PERFIL FROM TBL_USUARIO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(dt);
                    }
                }
                con.Close();
            }
            return dt;
        }

        public void updatePassword(String usr, String pwd)
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "UPDATE TBL_USUARIO SET USR_PWD = :INPWD WHERE USR_USRPC = :INUSR";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("INPWD", OracleDbType.Varchar2)).Value = pwd;
                    cmd.Parameters["INPWD"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("INUSR", OracleDbType.Varchar2)).Value = usr;
                    cmd.Parameters["INUSR"].Direction = ParameterDirection.Input;                    

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void updateEstadoUsuario(int usr) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "UPDATE TBL_USUARIO SET USR_ESTADO = 0 WHERE USR_ID = :INID";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new OracleParameter("INID", OracleDbType.Int32)).Value = usr;
                    cmd.Parameters["INID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
