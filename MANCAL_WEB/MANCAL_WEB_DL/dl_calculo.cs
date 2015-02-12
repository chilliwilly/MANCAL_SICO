using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_calculo
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public DataSet selectTotalDetalle(int tmoneda, String descto, int idiva, String idcotiz) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_CALCULO_TOTAL";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_ret_total", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("tipomoneda", OracleDbType.Int32)).Value = tmoneda;
                    cmd.Parameters["tipomoneda"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("descto", OracleDbType.Varchar2)).Value = descto;
                    cmd.Parameters["descto"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("tniva", OracleDbType.Int32)).Value = idiva;
                    cmd.Parameters["tniva"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("idusr", OracleDbType.Varchar2)).Value = idcotiz;
                    cmd.Parameters["idusr"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_ret_total");
                    }
                }
                con.Close();
            }
            return ds;
        }

        public DataSet selectTotalExceder(String idcotiz) 
        {
            DataSet ds = new DataSet();

            return ds;
        }

        public DataSet selectTotalMargenes(String idcotiz) 
        {
            DataSet ds = new DataSet();

            return ds;
        }
    }
}
