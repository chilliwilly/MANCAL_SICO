using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_detalle_pro
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public String selectTotalEquipoIn(int tcoti, int tmoneda, String crep, String prep, String cmo, String pmo, int qty) 
        {
            String total = "";

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.FN_CALCULA_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("vtotal", OracleDbType.Varchar2, 20)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("tcoti", OracleDbType.Int32)).Value = tcoti;
                    cmd.Parameters["tcoti"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tmoneda", OracleDbType.Int32)).Value = tmoneda;
                    cmd.Parameters["tmoneda"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("crep", OracleDbType.Varchar2)).Value = crep;
                    cmd.Parameters["crep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prep", OracleDbType.Varchar2)).Value = prep;
                    cmd.Parameters["prep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("cmo", OracleDbType.Varchar2)).Value = cmo;
                    cmd.Parameters["cmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pmo", OracleDbType.Varchar2)).Value = pmo;
                    cmd.Parameters["pmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("qty", OracleDbType.Int32)).Value = qty;
                    cmd.Parameters["qty"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    total = cmd.Parameters["vtotal"].Value.ToString().Trim();
                }
                con.Close();
            }
            return total;
        }

        public void insertEquipoIn(String idusr, String nparte, String descrip, String nserie, int qty, String crep, String prep, String cmo, String pmo, String monto) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.SP_INSERT_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idusr;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nparte", OracleDbType.Varchar2)).Value = nparte;
                    cmd.Parameters["nparte"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("descrip", OracleDbType.Varchar2)).Value = descrip;
                    cmd.Parameters["descrip"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nserie", OracleDbType.Varchar2)).Value = nserie;
                    cmd.Parameters["nserie"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("qty", OracleDbType.Int32)).Value = qty;
                    cmd.Parameters["qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("crep", OracleDbType.Varchar2)).Value = crep;
                    cmd.Parameters["crep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prep", OracleDbType.Varchar2)).Value = prep;
                    cmd.Parameters["prep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("cmo", OracleDbType.Varchar2)).Value = cmo;
                    cmd.Parameters["cmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pmo", OracleDbType.Varchar2)).Value = pmo;
                    cmd.Parameters["pmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("monto", OracleDbType.Varchar2)).Value = monto;
                    cmd.Parameters["monto"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet selectDetalleProy(String usr, int moneda) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.FN_SELECT_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_det_prov", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = usr;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tmoneda", OracleDbType.Int32)).Value = moneda;
                    cmd.Parameters["tmoneda"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_det_prov");
                    }
                }
                con.Close();
            }
            return ds;
        }
    }
}
