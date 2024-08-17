using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_RPT_RPT_HospitalWise_IncomeTypeWiseList : System.Web.UI.Page
{
    #region private variable

    DataTable dtACC_Income = new DataTable();
    private DS_ACC_Income objAcc_Income = new DS_ACC_Income();
    #endregion private variable 

    #region  Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowReport();
        }
    }

    #endregion  Page Load Event

    #region ShowReport
    protected void ShowReport()
    {
        ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
        DataTable dt = balACC_Income.Report_ACC_Income_List();
        //dt.Merge(balACC_Income.Report_ACC_Income_List());
        //dt.Merge(balACC_Income.Report_ACC_Income_List());
        //dt.Merge(balACC_Income.Report_ACC_Income_List());
        dtACC_Income = dt.Copy();
        FillDataSet();

    }
    #endregion ShowReport

    #region FillDataSet
    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Income.Rows)
        {
            DS_ACC_Income.dtACC_IncomeRow drACC_Income = objAcc_Income.dtACC_Income.NewdtACC_IncomeRow();
            if (!dr["IncomeID"].Equals(System.DBNull.Value))
            {
                drACC_Income.IncomeID = Convert.ToInt32(dr["IncomeID"]);
            }
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
            {
                drACC_Income.FinYearName = Convert.ToString(dr["FinYearName"]);
            }
            if (!dr["Hospital"].Equals(System.DBNull.Value))
            {
                drACC_Income.Hospital = Convert.ToString(dr["Hospital"]);
            }
            if (!dr["IncomeType"].Equals(System.DBNull.Value))
            {
                drACC_Income.IncomeType = Convert.ToString(dr["IncomeType"]);
            }
            if (!dr["Amount"].Equals(System.DBNull.Value))
            {
                drACC_Income.Amount = Convert.ToDecimal(dr["Amount"]);
            }
            if (!dr["IncomeDate"].Equals(System.DBNull.Value))
            {
                drACC_Income.IncomeDate = Convert.ToDateTime(dr["IncomeDate"]).ToString(CV.DefaultDateFormat);

            }
            objAcc_Income.dtACC_Income.Rows.Add(drACC_Income);

        }
        SetReportParameters();
        this.rvHospitalReport.LocalReport.DataSources.Clear();
        this.rvHospitalReport.LocalReport.DataSources.Add(new ReportDataSource("dtACC_Income", (DataTable)objAcc_Income.dtACC_Income));
        this.rvHospitalReport.LocalReport.Refresh();
    }
    #endregion FillDataSet

    #region SetReportParameters
    private void SetReportParameters()
    {
        String RptTitle = "Income Report";
        DateTime PrintDate = DateTime.Now;
        ReportParameter rptTitle = new ReportParameter("ReportTitle", RptTitle);
       ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());
        this.rvHospitalReport.LocalReport.SetParameters(new ReportParameter[] { rptTitle,rptPrintDate });
    }
    #endregion SetReportParameters
}