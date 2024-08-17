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
using Org.BouncyCastle.Asn1.Ocsp;

public partial class AdminPanel_RPT_RPT_ACC_GNTransaction : System.Web.UI.Page
{
    #region 11.0 Local Variable 
    private dsACC_GNTransaction objdsACC_GNTransaction = new dsACC_GNTransaction();
    #endregion 11.0 Local Variable

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["TransactionID"] != null && Request.QueryString["ReportType"] != null)
            {
                ShowReport();
            }
        }
    }

    #endregion 12.0 Page Load Event

    #region 18.0 Export Data

    #region 18.1 Excel Export Button Click Event

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvPatientReceipt.LocalReport.Render(format,
                                                        null,
                                                        out mimeType,
                                                        out encoding,
                                                        out extension,
                                                        out streamIds,
                                                        out warnings);

            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("Content-Disposition", "attachment; filename=report." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
        }

    }

    #endregion 18.1 Excel Export Button Click Event

    #endregion 18.0 Export Data

    #region 22.0 REPORT

    #region  22.1  ShowReport

    protected void ShowReport()
    {
        if (Request.QueryString["TransactionID"] != null && Request.QueryString["ReportType"] != null)
        {
            SqlInt32 TransactionID = CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionID"]);
            SqlString ReportType = CommonFunctions.DecryptBase64(Request.QueryString["ReportType"]);

            ACC_GNTransactionBAL balACC_GNTransaction = new ACC_GNTransactionBAL();

            DataTable dtPatientReport = balACC_GNTransaction.SelectReportPage(TransactionID);

            if (dtPatientReport != null)
            {
                FillDataSet(dtPatientReport);
            }

            ExportReport(ReportType.ToString());

        }
    }

    #endregion 22.1 ShowReport 

    #region 22.2 FillDataSet

    protected void FillDataSet(DataTable dtPatientReport)
    {
        foreach (DataRow dr in dtPatientReport.Rows)
        {
            dsACC_GNTransaction.dtPatientReportRow drPatientReport = objdsACC_GNTransaction.dtPatientReport.NewdtPatientReportRow();

            if (!dr["PatientName"].Equals(System.DBNull.Value))
                drPatientReport.PatientName = Convert.ToString(dr["PatientName"]);

            if (!dr["Age"].Equals(System.DBNull.Value))
                drPatientReport.Age = Convert.ToInt32(dr["Age"]);

            if (!dr["MobileNo"].Equals(System.DBNull.Value))
                drPatientReport.MobileNo = Convert.ToString(dr["MobileNo"]);

            if (!dr["DateOfAdmission"].Equals(System.DBNull.Value))
                drPatientReport.DateOfAdmission = Convert.ToDateTime(dr["DateOfAdmission"]);

            if (!dr["DateOfDischarge"].Equals(System.DBNull.Value))
                drPatientReport.DateOfDischarge = Convert.ToDateTime(dr["DateOfDischarge"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drPatientReport.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["ReferenceDoctor"].Equals(System.DBNull.Value))
                drPatientReport.ReferenceDoctor = Convert.ToString(dr["ReferenceDoctor"]);

            if (!dr["ReceiptNo"].Equals(System.DBNull.Value))
                drPatientReport.ReceiptNo = Convert.ToInt32(dr["ReceiptNo"]);

            if (!dr["ReceiptTypeName"].Equals(System.DBNull.Value))
                drPatientReport.ReceiptTypeName = Convert.ToString(dr["ReceiptTypeName"]);

            if (!dr["Treatment"].Equals(System.DBNull.Value))
                drPatientReport.Treatment = Convert.ToString(dr["Treatment"]);

            if (!dr["Rate"].Equals(System.DBNull.Value))
                drPatientReport.Rate = Convert.ToDecimal(dr["Rate"]);

            if (!dr["Quantity"].Equals(System.DBNull.Value))
                drPatientReport.Quantity = Convert.ToInt32(dr["Quantity"]);

            if (!dr["Amount"].Equals(System.DBNull.Value))
                drPatientReport.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drPatientReport.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["TreatmentDate"].Equals(System.DBNull.Value))
                drPatientReport.TreatmentDate = Convert.ToDateTime(dr["TreatmentDate"]);


            objdsACC_GNTransaction.dtPatientReport.Rows.Add(drPatientReport);

        }

        SetReportParamater();
        this.rvPatientReceipt.LocalReport.DataSources.Clear();
        this.rvPatientReceipt.LocalReport.DataSources.Add(new ReportDataSource("dtPatientReport", (DataTable)objdsACC_GNTransaction.dtPatientReport));
        this.rvPatientReceipt.LocalReport.Refresh();
    }
    #endregion 22.2 FillDataSet

    #region 22.3 SetReportParamater
    protected void SetReportParamater()
    {
        String ReportTitle = "Patient Report";
        String ReportSubTitle = "";
        DateTime PrintDate = DateTime.Now;
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvPatientReceipt.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, rptPrintDate });

    }
    #endregion 22.3 SetReportParamater 

    #endregion 22.0 REPORT
}