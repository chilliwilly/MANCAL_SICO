using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_DL;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_equipo
    {
        public String listaEquipo() 
        {
            dl_equipo objEqDL = new dl_equipo();
            DataTable dt = new DataTable();
            dt.Dispose();
            dt = objEqDL.selectEquipoTodo();

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append(dr["EQ_NROPARTE"].ToString() + ":");
            }

            return sb.ToString().Substring(0);
        }
    }
}
