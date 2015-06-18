using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MANCAL_WEB
{
    public partial class load : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int cookie_page_id = Convert.ToInt32(Session["page_id"]);
            //Request.Cookies["page_id"]);

            if (Session["pag_num"].ToString().Equals("1"))//redirect nueva cot caal Session["page_id"].ToString().Equals("1")
            {
                Response.AddHeader("REFRESH", "3;URL=/frm_cal/cal_cot_mod.aspx");
            }
            if (Session["pag_num"].ToString().Equals("2"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("3"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("4"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("5"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("6"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("7"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("8"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("9"))
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
            if (Session["pag_num"].ToString().Equals("10")) //cambio y reset de pwd
            {
                Response.AddHeader("REFRESH", "3;URL=/index.aspx");
            }
        }
    }
}