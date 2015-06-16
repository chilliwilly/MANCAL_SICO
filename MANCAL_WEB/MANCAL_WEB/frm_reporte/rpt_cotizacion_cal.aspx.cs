using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;
using Telerik.Reporting.Processing;
using System.IO;

namespace MANCAL_WEB.frm_reporte
{
    public partial class rpt_cotizacion_cal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportBook rptBook = new ReportBook();
            rptBook.Reports.Add(new rpt_cal.rptCotizacionCal());
            rptBook.Reports.Add(new rpt_cal.rptCotizacionCal_Det());
            rptBook.Reports.Add(new rpt_cal.rptCotizacion_Resp());
            
            rptBook.Reports[0].ReportParameters[0].Value = Session["RPT_NUM_COT"].ToString();// "18";
            rptBook.Reports[1].ReportParameters[0].Value = Session["RPT_NUM_COT"].ToString();// "18";
            rptBook.Reports[0].ReportParameters[1].Value = Session["RPT_VAL_ACR"].ToString();// "18";
            rptBook.Reports[1].ReportParameters[1].Value = Session["RPT_VAL_ACR"].ToString();// "18";
            rptBook.Reports[2].ReportParameters[0].Value = Session["RPT_VAL_ACR"].ToString();// "18";
            
            String num_pto = Session["RPT_NUM_PTO"].ToString();

            if (num_pto.Equals("Y")) 
            {
                rptBook.Reports.Add(new rpt_cal.rptCotizacionCal_DetPunto());
                rptBook.Reports[3].ReportParameters[0].Value = Session["RPT_NUM_COT"].ToString();// "18";
                rptBook.Reports[3].ReportParameters[1].Value = Session["RPT_VAL_ACR"].ToString();// "18";
            }

            rptBook.DocumentName = Session["RPT_NUM_TXT"].ToString();
            rptViewer.ReportSource = rptBook;
        }
    }
}