using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace MANCAL_WEB.frm_equipo
{
    public partial class equipo_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //String cod = TextBox1.Text;

            String valor, password;
            valor = "12345";
            password = "DTSSIGEBASE";

            String codif = "";// Global_Procedures_of_netdll.Encripta(valor, password);
            
            ////Blowfish crypt=new Blowfish(cod);
            ////String cryptCod=crypt.encryptString(cod);              
            //SR_EncriptaPasswd.Encripta_wsSOAPPortTypeClient a = new SR_EncriptaPasswd.Encripta_wsSOAPPortTypeClient();
            //String s = a.Encripta(valor, password);//a.Encripta(valor, password);            
            //TextBox1.Text = codif;
            //DateTime.Now.ToShortDateString();
            //Label1.Text = codif;
            //MANCAL_WEB_BL.bl_detalle_pro obj = new MANCAL_WEB_BL.bl_detalle_pro();
            //MANCAL_WEB_CLASS.CotizacionEquipo c = new MANCAL_WEB_CLASS.CotizacionEquipo();
            //obj.setDetCotCal(c);
        }
    }
}