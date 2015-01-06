using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace MANCAL_WEB_DL
{
    public class dl_equipo
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public DataTable selectEquipoTodo() 
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT EQ_NROPARTE FROM TBL_EQUIPO WHERE EQ_UN_ID = 'MAN' OR EQ_UN_ID = 'DUO'";
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
