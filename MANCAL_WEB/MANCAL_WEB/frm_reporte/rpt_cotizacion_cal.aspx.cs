using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;

namespace MANCAL_WEB.frm_reporte
{
    public partial class rpt_cotizacion_cal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             Report1 rpt = new Report1();
                int idusr = Convert.ToInt32(TextBox1.Text);
                rpt.ReportParameters[0].Value = TextBox1.Text;
                rptView.ReportSource = rpt;

             */
            ReportBook rptBook = new ReportBook();
            rptBook.Reports.Add(new rpt_cal.rptCotizacionCal());
            rptBook.Reports.Add(new rpt_cal.rptCotizacionCal_Det());
            rptBook.Reports.Add(new rpt_cal.rptCotizacion_Resp());
            //rptBook.Reports.Add(new rpt_cal.rptCotizacionCal_DetPunto());            
            rptBook.Reports[0].ReportParameters[0].Value = Session["RPT_NUM_COT"].ToString();// "18";
            rptBook.Reports[1].ReportParameters[0].Value = Session["RPT_NUM_COT"].ToString();// "18";
            //rptBook.Reports[3].ReportParameters[0].Value = Session["RPT_NUM_COT"].ToString();// "18";
            rptBook.DocumentName = Session["RPT_NUM_TXT"].ToString();
            rptViewer.ReportSource = rptBook;

            //rpt_cal.rptCotizacionCal rpt = new rpt_cal.rptCotizacionCal();
            //rpt.ReportParameters[0].Value = "18";
            //rptViewer.ReportSource = rpt;
        }
    }
}