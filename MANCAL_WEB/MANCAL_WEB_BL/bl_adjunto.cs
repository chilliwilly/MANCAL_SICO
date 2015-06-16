using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MANCAL_WEB_CLASS;
using MANCAL_WEB_DL;
using System.Data;
using System.IO;

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

        public String delAdjunto(String iddoc, String cotizdoc)
        {
            objAdjunto = new dl_adjunto();
            int id_adj = int.Parse(iddoc);

            List<CotizacionAdjunto> cotAdj = getAdjunto(cotizdoc);

            objAdjunto.deleteArchivo(id_adj, cotizdoc);
                        
            String nomArch = "";

            foreach (CotizacionAdjunto ca in cotAdj)
            {
                if (ca.adjunto_id.Equals(iddoc))
                {                  
                    String[] dirArch = ca.adjunto_dir.Split('/');                    
                    nomArch = dirArch[2];
                    String direArch = @"C:\Users\wcontreras\Documents\GitHub\MANCAL_SICO\MANCAL_WEB\MANCAL_WEB\adjunto_doc\" + nomArch + "";
                    //String direArch = @"C:\WebManCal_Cot\adjunto_doc\" + nomArch + "";
                    File.Delete(direArch);
                    break;
                }
            }

            return nomArch;
        }

        public List<CotizacionAdjunto> getAdjunto(String idncotiz)
        {
            objAdjunto = new dl_adjunto();
            List<CotizacionAdjunto> lsAdj = new List<CotizacionAdjunto>();

            DataTable dt = objAdjunto.selectArchivo(idncotiz).Tables["cur_select"];

            foreach (DataRow dr in dt.Rows)
            {
                CotizacionAdjunto objAdju = new CotizacionAdjunto();
                objAdju.adjunto_id = dr["ARCH_ITEM"].ToString();
                objAdju.cotiz_id = dr["ARCH_ID_CP"].ToString();
                objAdju.adjunto_nombre = dr["ARCH_NOMBRE"].ToString();
                objAdju.adjunto_dir = dr["ARCH_DIRECCION"].ToString();
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
