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

        public DataSet selectTotalDetalle(int tmoneda, String descto, int idiva, String idcotiz, String idun) 
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

                    cmd.Parameters.Add(new OracleParameter("tipoun", OracleDbType.Varchar2)).Value = idun;
                    cmd.Parameters["tipoun"].Direction = ParameterDirection.Input;

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

        public DataSet selectTotalMargenes(String idcotiz, int idmoneda, int idtcoti, String fechcot, String idun) 
        {
            DataSet ds = new DataSet();

            using (OracleConnection con = new OracleConnection(conStr)) 
            {
                con.Open();
                String qry = "FN_MANCAL_MARGENES_REPMO";
                using (OracleCommand cmd = new OracleCommand(qry, con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new OracleParameter("cur_total_margen", OracleDbType.RefCursor)).Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(new OracleParameter("IDCOTIZ", OracleDbType.Varchar2)).Value = idcotiz;
                    cmd.Parameters["IDCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("IDMONEDA", OracleDbType.Int32)).Value = idmoneda;
                    cmd.Parameters["IDMONEDA"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("IDTCOTIZ", OracleDbType.Int32)).Value = idtcoti;
                    cmd.Parameters["IDTCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("FECCOTIZ", OracleDbType.Varchar2)).Value = fechcot;
                    cmd.Parameters["FECCOTIZ"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add(new OracleParameter("IDUNNEG", OracleDbType.Varchar2)).Value = idun;
                    cmd.Parameters["IDUNNEG"].Direction = ParameterDirection.Input;

                    using (OracleDataAdapter oda = new OracleDataAdapter(cmd)) 
                    {
                        oda.Fill(ds, "cur_total_margen");
                    }
                }
                con.Close();
            }

            return ds;
        }
    }
}
