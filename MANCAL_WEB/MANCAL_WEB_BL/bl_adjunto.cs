using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;

namespace MANCAL_WEB_BL
{
    public class bl_adjunto
    {
        dl_adjunto objAdjunto;

        public void addAdjunto(String usr_pc, String nomdoc, String dirdoc)
        {
            objAdjunto = new dl_adjunto();
            objAdjunto.insertArchivo(nomdoc, dirdoc, usr_pc);
        }

        public void delAdjunto(String iddoc, String cotizdoc)
        {
            objAdjunto = new dl_adjunto();
            int id_adj = int.Parse(iddoc);
            objAdjunto.deleteArchivo(id_adj, cotizdoc);
        }

        public List<CotizacionAdjunto> getAdjunto(String idncotiz)
        {
            objAdjunto = new dl_adjunto();
            List<CotizacionAdjunto> lsAdj = new List<CotizacionAdjunto>();

            DataTable dt = objAdjunto.selectArchivo(idncotiz).Tables["cur_select"];

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionAdjunto objAdju = new CotizacionAdjunto();
                objAdju.adjunto_id = dr["ARCHP_ITEM"].ToString();
                objAdju.cotiz_id = dr["PROY_NUMERO"].ToString();
                objAdju.adjunto_nombre = dr["ARCHP_NOMBRE"].ToString();
                objAdju.adjunto_dir = dr["ARCHP_DIRECCION"].ToString();
                lsAdj.Add(objAdju);
            }

            return lsAdj;
        }

        public String adjuntarDocumento(String file_name, String pc_usr)
        {
            String arch = System.IO.Path.GetFileName(file_name);
            String[] nomArch = arch.Split('.');
            String dirArch = arch;

            addAdjunto(pc_usr, nomArch[0], dirArch);

            return dirArch;
        }
    }
}
