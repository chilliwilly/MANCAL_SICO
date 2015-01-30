using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace MANCAL_WEB_DL
{
    public class dl_menu
    {
        private static String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ora_sico_mancal"].ConnectionString;

        public DataTable selectMenu()
        {
            DataTable dt = new DataTable();

            using (OracleConnection con = new OracleConnection(conStr))
            {
                con.Open();
                String qry = "SELECT * FROM TBL_MENU";
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
