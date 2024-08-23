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

public partial class AdminPanel_RPT_RPT_PatientIDCard : System.Web.UI.Page
{
    #region private variable

    DataTable dtMST_Patient = new DataTable();
    private dsMST_Patient objMST_Patient = new dsMST_Patient();
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
        MST_PatientBAL balMST_Patient = new MST_PatientBAL();
        DataTable dt = balMST_Patient.RPT_PatientIDCard();
        //dt.Merge(balMST_Patient.Report_ACC_Income_List());
        //dt.Merge(balMST_Patient.Report_ACC_Income_List());
        //dt.Merge(balMST_Patient.Report_ACC_Income_List());
        dtMST_Patient = dt.Copy();
        FillDataSet();

    }
    #endregion ShowReport

    #region FillDataSet
    protected void FillDataSet()
    {
        foreach (DataRow dr in dtMST_Patient.Rows)
        {
            dsMST_Patient.dtMST_PatientRow drMST_Patient = objMST_Patient.dtMST_Patient.NewdtMST_PatientRow();
            if (!dr["PatientID"].Equals(System.DBNull.Value))
            {
                drMST_Patient.PatientID = Convert.ToInt32(dr["PatientID"]);
            }
            if (!dr["PatientName"].Equals(System.DBNull.Value))
            {
                drMST_Patient.PatientName = Convert.ToString(dr["PatientName"]);
            }
            if (!dr["DOB"].Equals(System.DBNull.Value))
            {
                drMST_Patient.DOB = Convert.ToDateTime(dr["DOB"]);

            }
            if (!dr["Age"].Equals(System.DBNull.Value))
            {
                drMST_Patient.Age = Convert.ToInt32(dr["Age"]);
            }
            if (!dr["MobileNo"].Equals(System.DBNull.Value))
            {
                drMST_Patient.MobileNo = Convert.ToString(dr["MobileNo"]);
            }
            if (!dr["PrimaryDesc"].Equals(System.DBNull.Value))
            {
                drMST_Patient.PrimaryDesc = Convert.ToString(dr["PrimaryDesc"]);
            }
            //if (!dr["PatientPhotoPath"].Equals(System.DBNull.Value))
            //{
            //    drMST_Patient.PatientPhotoPath = Convert.ToString(dr["PatientPhotoPath"]);
            //}
            
            if (!dr["PatientPhotoPath"].Equals(System.DBNull.Value))
                drMST_Patient.PatientPhotoPath = CommonFunctions.ConvertImagePathToPngBytes(Convert.ToString(dr["PatientPhotoPath"]));
            else
                drMST_Patient.PatientPhotoPath = CommonFunctions.ConvertImagePathToPngBytes(CV.DefaultNoImagePath);
            if (!dr["Hospital"].Equals(System.DBNull.Value))
            {
                drMST_Patient.Hospital = Convert.ToString(dr["Hospital"]);
            }
            if (!dr["FinYearName"].Equals(System.DBNull.Value))
            {
                drMST_Patient.FinYearName = Convert.ToString(dr["FinYearName"]);
            }

            if (!dr["HospitalID"].Equals(System.DBNull.Value))
            {
                drMST_Patient.HospitalID = Convert.ToInt32(dr["HospitalID"]);
            }

            if (!dr["FinYearID"].Equals(System.DBNull.Value))
            {
                drMST_Patient.FinYearID = Convert.ToInt32(dr["FinYearID"]);
            }
            if (!dr["PatientID"].Equals(System.DBNull.Value))
            {
                drMST_Patient.BarCode = CommonFunctions.GenerateBarcode(drMST_Patient.PatientID.ToString());
            }
            objMST_Patient.dtMST_Patient.Rows.Add(drMST_Patient);

        }
        SetReportParameters();
        this.rvPatientID.LocalReport.DataSources.Clear();
        this.rvPatientID.LocalReport.DataSources.Add(new ReportDataSource("dtMST_Patient", (DataTable)objMST_Patient.dtMST_Patient));
        this.rvPatientID.LocalReport.Refresh();
    }
    #endregion FillDataSet

    #region SetReportParameters
    private void SetReportParameters()
    {
        String ReportTitle = "Patient ID";
        String SubTitle = "";
        DateTime PrintDate = DateTime.Now;
        ReportParameter rptTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptSubTitle = new ReportParameter("SubTitle", SubTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());
        this.rvPatientID.LocalReport.SetParameters(new ReportParameter[] { rptTitle, rptSubTitle, rptPrintDate });
    }
    #endregion SetReportParameters
}