using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_RPT_RPT_FinYearWiseHospitalWiseIncomeExpenseList : System.Web.UI.Page
{
    #region private variable

    DataTable dtACC_Ledger = new DataTable();
    private dsACC_IncomeExpense objACC_IncomeExpense = new dsACC_IncomeExpense();
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
        ACC_LedgerBAL balACC_Ledger = new ACC_LedgerBAL();
        DataTable dt = balACC_Ledger.Report_FinYearWiseHospitalWiseIncomeExpenseList();
 
        dtACC_Ledger = dt.Copy();
        FillDataSet();

    }
    #endregion ShowReport

    #region FillDataSet
    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Ledger.Rows)
        {
            dsACC_IncomeExpense.dtACC_LedgerRow drACC_Ledger = objACC_IncomeExpense.dtACC_Ledger.NewdtACC_LedgerRow();
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
            {
                drACC_Ledger.FinYearName = Convert.ToString(dr["FinYearName"]);
            }
          
            if (!dr["Hospital"].Equals(System.DBNull.Value))
            {
                drACC_Ledger.Hospital = Convert.ToString(dr["Hospital"]);
            }
            
            if (!dr["TotalIncome"].Equals(System.DBNull.Value))
            {
                drACC_Ledger.TotalIncome = Convert.ToDecimal(dr["TotalIncome"]);
            }
            if (!dr["TotalExpense"].Equals(System.DBNull.Value))
            {
                drACC_Ledger.TotalExpense = Convert.ToDecimal(dr["TotalExpense"]);
            }
            if (!dr["TotalPatient"].Equals(System.DBNull.Value))
            {
                drACC_Ledger.TotalPatient = Convert.ToInt32(dr["TotalPatient"]);
            }
           
            objACC_IncomeExpense.dtACC_Ledger.Rows.Add(drACC_Ledger);

        }
        SetReportParameters();
        this.rvIncomeExpense.LocalReport.DataSources.Clear();
        this.rvIncomeExpense.LocalReport.DataSources.Add(new ReportDataSource("dtACC_Ledger", (DataTable)objACC_IncomeExpense.dtACC_Ledger));
        this.rvIncomeExpense.LocalReport.Refresh();
    }
    #endregion FillDataSet

    #region SetReportParameters
    private void SetReportParameters()
    {
        String ReportTitle = "IncomeExpense Report";
        String SubTitle = "FinYearWise | HospitalWise";
        DateTime PrintDate = DateTime.Now;
        ReportParameter rptTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptSubTitle = new ReportParameter("SubTitle", SubTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());
        this.rvIncomeExpense.LocalReport.SetParameters(new ReportParameter[] { rptTitle,rptSubTitle,rptPrintDate });
    }
    #endregion SetReportParameters
}