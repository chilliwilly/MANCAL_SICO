using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace MANCAL_WEB_DL
{
    public class dl_reporte
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public DataSet selectDetCotCal(int num_cot) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry = "PKG_MANCAL_REPORT.FN_CAL_DETCOT_REPORT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_DETALLE", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_NUM_COTIZACION", OracleDbType.Int32)).Value = num_cot;
                    cmd.Parameters["P_NUM_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "CUR_DETALLE");
                    }
                }
            }

            return ds;
        }

        public DataSet selectMainCotCal(int num_cot) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry = "PKG_MANCAL_REPORT.FN_CAL_COTINI_REPORT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_COTI", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_NUM_COTIZACION", OracleDbType.Int32)).Value = num_cot;
                    cmd.Parameters["P_NUM_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "CUR_COTI");
                    }
                }
            }

            return ds;
        }

        public DataSet selectDetPuntoCal(int num_cot) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                con.BeginTransaction();
                String qry = "PKG_MANCAL_REPORT.FN_CAL_PUNTO_REPORT";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("CUR_PUNTO", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("P_NUM_COTIZACION", OracleDbType.Int32)).Value = num_cot;
                    cmd.Parameters["P_NUM_COTIZACION"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd))
                    {
                        oda.Fill(ds, "CUR_PUNTO");
                    }                    
                }
                con.Close();                
            }

            return ds;
        }
    }
}
