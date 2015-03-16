using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using org.jivesoftware.util;
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
            String cod = TextBox1.Text;

            Blowfish crypt=new Blowfish(cod);
            String cryptCod=crypt.encryptString(cod);

            Label1.Text = cryptCod.ToUpper();
        }
    }
}