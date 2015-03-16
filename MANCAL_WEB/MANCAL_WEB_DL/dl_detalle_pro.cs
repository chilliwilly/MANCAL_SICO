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

        public void updateDetalleProy(String idusr_, int nitem_, String nparte_, String descrip_, String nserie_, int qty_, String crep_, String prep_, String cmo_, String pmo_, String monto_)
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.SP_UPDATE_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idusr_;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nitem", OracleDbType.Int32)).Value = nitem_;
                    cmd.Parameters["nitem"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nparte", OracleDbType.Varchar2)).Value = nparte_;
                    cmd.Parameters["nparte"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("descrip", OracleDbType.Varchar2)).Value = descrip_;
                    cmd.Parameters["descrip"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nserie", OracleDbType.Varchar2)).Value = nserie_;
                    cmd.Parameters["nserie"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("qty", OracleDbType.Int32)).Value = qty_;
                    cmd.Parameters["qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("crep", OracleDbType.Varchar2)).Value = crep_;
                    cmd.Parameters["crep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("prep", OracleDbType.Varchar2)).Value = prep_;
                    cmd.Parameters["prep"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("cmo", OracleDbType.Varchar2)).Value = cmo_;
                    cmd.Parameters["cmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("pmo", OracleDbType.Varchar2)).Value = pmo_;
                    cmd.Parameters["pmo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("monto", OracleDbType.Varchar2)).Value = monto_;
                    cmd.Parameters["monto"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public void deleteDetalleProy(String idusr_, int nitem_) 
        {
            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "PKG_MANCAL_DET_PROY.SP_DELETE_EQUIPO_DET";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idusr_;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("nitem", OracleDbType.Int32)).Value = nitem_;
                    cmd.Parameters["nitem"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public DataTable selectEquipoBuscar(String nom, String mod, String nparte, String nserie, int idcli)
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                con.BeginTransaction();
                String qry_proc = "SP_SPAC_SEARCH_EQUIPO";
                using (OracleCommand cmd_proc = new OracleCommand(qry_proc, con))
                {
                    cmd_proc.CommandType = CommandType.StoredProcedure;

                    cmd_proc.Parameters.Add(new OracleParameter("P_NOMBRE", OracleDbType.Varchar2)).Value = nom;
                    cmd_proc.Parameters["P_NOMBRE"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_MODELO", OracleDbType.Varchar2)).Value = mod;
                    cmd_proc.Parameters["P_MODELO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_PARTE", OracleDbType.Varchar2)).Value = nparte;
                    cmd_proc.Parameters["P_PARTE"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_SERIE", OracleDbType.Varchar2)).Value = nserie;
                    cmd_proc.Parameters["P_SERIE"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_TIPO", OracleDbType.Varchar2)).Value = null;
                    cmd_proc.Parameters["P_TIPO"].Direction = ParameterDirection.Input;

                    cmd_proc.Parameters.Add(new OracleParameter("P_ID_CLIENTE", OracleDbType.Int32)).Value = idcli;
                    cmd_proc.Parameters["P_ID_CLIENTE"].Direction = ParameterDirection.Input;
                }

                String qry = "SELECT * FROM TBL_SPAC_SEARCH_EQUIPO_TMP";
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
    }
}
