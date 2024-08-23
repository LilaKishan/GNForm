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

public partial class AdminPanel_RPT_RPT_ACC_Ledger : System.Web.UI.Page
{
    #region 11.0 Variables

    String FormName = "RPT_ACC_Ledger_ByFinYearHospital_IncomeExpense_Balance";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;


    #region Report Variables

    private DataTable dtACC_Ledger = new DataTable();
    private dsACC_Ledger obj_dsACC_Ledger = new dsACC_Ledger();

    #endregion

    #endregion 11.0 Variables

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            FillDropDownList();

            #endregion 12.1 DropDown List Fill Section

            Search(1);

            #region 12.2 Set Default Value

            ddlFinYearID.SelectedIndex = 0;
            ddlHospitalID.SelectedIndex = 0;
            lblSearchHeader.Text = CV.SearchHeaderText;
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 12.2 Set Default Value

            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
        //ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        //ddlExpenseTypeID.Items.Insert(0, new ListItem("Select Expense Type", "-99"));

        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
        CommonFillMethods.FillDropDownListFinYearID(ddlFinYearID);

    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters

        //SqlInt32 ExpenseTypeID = SqlInt32.Null;
        //SqlDecimal Amount = SqlDecimal.Null;
        //SqlDateTime ExpenseDate = SqlDateTime.Null;

        SqlInt32 FinYearID = SqlInt32.Null;
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data

        //if (ddlExpenseTypeID.SelectedIndex > 0)
        //    ExpenseTypeID = Convert.ToInt32(ddlExpenseTypeID.SelectedValue);

        //if (txtAmount.Text.Trim() != String.Empty)
        //    Amount = Convert.ToDecimal(txtAmount.Text.Trim());

        //if (dtpExpenseDate.Text.Trim() != String.Empty)
        //    ExpenseDate = Convert.ToDateTime(dtpExpenseDate.Text.Trim());      

        if (ddlFinYearID.SelectedIndex > 0)
            FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

        if (ddlHospitalID.SelectedIndex > 0)
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);


        #endregion Gather Data

        ACC_LedgerBAL balACC_Ledger = new ACC_LedgerBAL();

        DataTable dt = balACC_Ledger.Report_ACC_Ledger(FinYearID, HospitalID);

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            Div_ExportOption.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();

            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;



            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);

            lbtnExportExcel.Visible = true;

        }

        else if (TotalPages < PageNo && TotalPages > 0)
            Search(TotalPages);

        else
        {
            Div_SearchResult.Visible = false;
            lbtnExportExcel.Visible = false;

            ViewState["TotalPages"] = 0;
            ViewState["CurrentPage"] = 1;

            rpData.DataSource = null;
            rpData.DataBind();


            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();


            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }

        ShowReport(FinYearID, HospitalID);
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                ACC_LedgerBAL balACC_Ledger = new ACC_LedgerBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    //if (balACC_Ledger.Delete(Convert.ToInt32(e.CommandArgument)))
                    //{
                    //    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                    //    if (ViewState["CurrentPage"] != null)
                    //    {
                    //        int Count = rpData.Items.Count;

                    //        if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                    //            ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                    //        Search(Convert.ToInt32(ViewState["CurrentPage"]));
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 18.0 Button Delete Click Event


    #endregion 18.0 Button Delete Click Event

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 20.0 Cancel Button Event

    #region 22.0 ClearControls

    private void ClearControls()
    {
        //ddlFinYearID.Items.Clear();
        //ddlFinYearID.Items.Insert(0, new ListItem("Select Fin Year", "-99"));
        //ddlExpenseTypeID.Items.Clear();
        //ddlExpenseTypeID.Items.Insert(0, new ListItem("Select Expense Type", "-99"));
        //txtAmount.Text = String.Empty;
        //dtpExpenseDate.Text = String.Empty;


        ddlFinYearID.SelectedIndex = 0;
        ddlHospitalID.SelectedIndex = 0;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls



    #region ShowReport
    protected void ShowReport(SqlInt32 FinYearID, SqlInt32 HospitalID)
    {
        ACC_LedgerBAL balACC_Ledger = new ACC_LedgerBAL();
        dtACC_Ledger = balACC_Ledger.Report_ACC_Ledger(FinYearID, HospitalID);

        FillDataSet();
    }

    #endregion ShowReport

    #region FillDataSet
    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Ledger.Rows)
        {
            dsACC_Ledger.dtACC_LedgerRow drACC_Ledger = obj_dsACC_Ledger.dtACC_Ledger.NewdtACC_LedgerRow();

            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drACC_Ledger.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drACC_Ledger.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["TransactionDate"].Equals(System.DBNull.Value))
                drACC_Ledger.TransactionDate = Convert.ToDateTime(dr["TransactionDate"]);

            if (!dr["TransactionType"].Equals(System.DBNull.Value))
                drACC_Ledger.TransactionType = Convert.ToString(dr["TransactionType"]);

            if (!dr["IncomeAmount"].Equals(System.DBNull.Value))
                drACC_Ledger.IncomeAmount = Convert.ToDecimal(dr["IncomeAmount"]);

            if (!dr["ExpenseAmount"].Equals(System.DBNull.Value))
                drACC_Ledger.ExpenseAmount = Convert.ToDecimal(dr["ExpenseAmount"]);

            if (!dr["Balance"].Equals(System.DBNull.Value))
                drACC_Ledger.Balance = Convert.ToDecimal(dr["Balance"]);

            if (!dr["IncomeType"].Equals(System.DBNull.Value))
                drACC_Ledger.IncomeType = Convert.ToString(dr["IncomeType"]);

            if (!dr["ExpenseType"].Equals(System.DBNull.Value))
                drACC_Ledger.ExpenseType = Convert.ToString(dr["ExpenseType"]);

            obj_dsACC_Ledger.dtACC_Ledger.Rows.Add(drACC_Ledger);
        }

        SetReportParameters();
        this.rvLedger.LocalReport.DataSources.Clear();
        this.rvLedger.LocalReport.DataSources.Add(new ReportDataSource("dtACC_Ledger", (DataTable)obj_dsACC_Ledger.dtACC_Ledger));
    }

    #endregion FillDataSet

    #region SetReportParameters

    private void SetReportParameters()
    {
        string ReportTitle = "Ledger";
        string ReportFinYear = "";
        string ReportHospital = "";

        if (ddlFinYearID.SelectedIndex > 0)
            ReportFinYear = ddlFinYearID.SelectedItem.Text.ToString();
        else
            ReportFinYear = " ";

        if (ddlHospitalID.SelectedIndex > 0)
            ReportHospital = ddlHospitalID.SelectedItem.Text.ToString();
        else
            ReportHospital = " ";



        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportFinYear = new ReportParameter("ReportFinYear", ReportFinYear);
        ReportParameter rptReportHospital = new ReportParameter("ReportHospital", ReportHospital);

        this.rvLedger.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportFinYear, rptReportHospital });
    }

    #endregion SetReportParameters

    #region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();
        #region Parameters

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;

        #endregion Parameters

        #region Gather Data


        SqlInt32 FinYearID = SqlInt32.Null;
        SqlInt32 HospitalID = SqlInt32.Null;


        if (ddlFinYearID.SelectedIndex > 0)
            FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

        if (ddlHospitalID.SelectedIndex > 0)
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);


        #endregion Gather Data

        ACC_LedgerBAL balACC_Ledger = new ACC_LedgerBAL();

        dtACC_Ledger = balACC_Ledger.Report_ACC_Ledger(FinYearID, HospitalID);
        if (dtACC_Ledger != null && dtACC_Ledger.Rows.Count > 0)
        {
            ExportReport(ExportType);
        }
    }

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvLedger.LocalReport.Render(format,
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
            Response.End();

        }
        catch (Exception ex)
        {
            ucMessage.ShowError(format + " is Not Correct Format");
        }

    }

    #endregion 19.1 Excel Export Button Click Event

    #endregion 19.0 Export Data






}
