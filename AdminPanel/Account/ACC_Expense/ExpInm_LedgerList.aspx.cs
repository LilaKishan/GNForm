using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AdminPanel_Account_ACC_Expense_ExpInm_LedgerList : System.Web.UI.Page
{
    #region 11.0 Variables

    String FormName = "ExpInm_LedgerList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #endregion 11.0 Variables
   
    #region 12.0 Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {

            #region 12.1 Set Default Value

            lblSearchHeader.Text = CV.SearchHeaderText;
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 12.2 Set Default Value
            SetDefaultDateTime();
            Search(1);

            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }
    #endregion

    #region 13.0 Fillable
    private void FillLabels(String FormName)
    {
    }
    #endregion

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

        SqlString LedgerType = SqlString.Null;
        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        decimal TotalBalance = 0;
        Int32 Offset = (PageNo - 1) * PageRecordSize;
        Int32 TotalRecords = 0;
        Int32 TotalPages = 1;

        #endregion Parameters

        #region Gather Data

        if (txtLedgerType.Text.Trim() != String.Empty)
        {
            LedgerType = txtLedgerType.Text.Trim();
            }
            if (dtpLedgerFromDate.Text.Trim() != String.Empty)
        {
            FromDate = Convert.ToDateTime(dtpLedgerFromDate.Text.Trim());
        }
        if (dtpLedgerToDate.Text.Trim() != String.Empty)
        {
            ToDate = Convert.ToDateTime(dtpLedgerToDate.Text.Trim());
        }

        #endregion Gather Data

        ACC_ExpInm_LedgerBAL balACC_ExpInm_LedgerBAL = new ACC_ExpInm_LedgerBAL();


        DataTable dt = balACC_ExpInm_LedgerBAL.SelectPage(Offset, PageRecordSize, out TotalRecords, FromDate, ToDate,LedgerType);
        foreach (DataRow row in dt.Rows)
        {
            if (row.Field<String>("LedgerType") == "Income")
                TotalBalance += row.Field<decimal>("LedgerAmount");
            else
                TotalBalance -= row.Field<decimal>("LedgerAmount");
        }
        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)((decimal)TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            Div_ExportOption.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();
            lblTotalAmount.Text = TotalBalance.ToString();

            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);

            lbtnExportExcel.Visible = true;
            if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
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

            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName == "DeleteRecord")
        //{
        //    try
        //    {
        //        ACC_ExpInm_LedgerBAL balMST_ExpenseType = new ACC_ExpInm_LedgerBAL();
        //        if (e.CommandArgument.ToString().Trim() != "")
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ucMessage.ShowError(ex.Message.ToString());
        //    }
        //}
    }
    protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Find the data item
            var ledgerType = DataBinder.Eval(e.Item.DataItem, "LedgerType").ToString();

            // Find the row
            var row = e.Item.FindControl("tr") as HtmlTableRow;
            if (row != null)
            {
                // Apply the style based on the LedgerType
                if (ledgerType.Equals("Income", StringComparison.OrdinalIgnoreCase))
                {
                    row.Attributes.Add("style", "background-color: green;");
                }
                else if (ledgerType.Equals("Expense", StringComparison.OrdinalIgnoreCase))
                {
                    row.Attributes.Add("style", "background-color: red;");
                }
            }
        }
    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 17.0 Pagination   

    #region 17.1 Pagination Events

    #region ItemDataBound Event

    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    LinkButton lb = (LinkButton)e.Item.FindControl("lbtnPageNo");
        //    HtmlGenericControl hgc = (HtmlGenericControl)e.Item.FindControl("liPageNo");
        //    if (Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(lb.CommandArgument))
        //    {
        //        hgc.Attributes["class"] = CSSClass.PaginationButtonActive;
        //        lb.Enabled = false;
        //    }
        //    else
        //        hgc.Attributes["class"] = CSSClass.PaginationButton;
        //}
    }

    #endregion ItemDataBound Event

    #region PageChange Event

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);

        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);

        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);

        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));

        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }

    #endregion PageChange Event

    #endregion 17.1 Pagination Events

    #endregion 17.0 Pagination

    #region 19.0 Export Data 

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();
        int TotalReceivedRecord = 0;
        SqlString LedgerType = SqlString.Null;
        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;

        if (txtLedgerType.Text.Trim() != String.Empty)
        {
            LedgerType = txtLedgerType.Text.Trim();
        }
        if (dtpLedgerFromDate.Text.Trim() != String.Empty)
        {
            FromDate = Convert.ToDateTime(dtpLedgerFromDate.Text.Trim());
        }
        if (dtpLedgerToDate.Text.Trim() != String.Empty)
        {
            ToDate = Convert.ToDateTime(dtpLedgerToDate.Text.Trim());
        }




        Int32 Offset = 0;

        if (ViewState["CurrentPage"] != null)
            Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        ACC_ExpInm_LedgerBAL balACC_ExpInm_LedgerBAL = new ACC_ExpInm_LedgerBAL();
        DataTable dtACC_ExpInm_LedgerBAL = balACC_ExpInm_LedgerBAL.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, FromDate, ToDate,LedgerType);
        if (dtACC_ExpInm_LedgerBAL != null && dtACC_ExpInm_LedgerBAL.Rows.Count > 0)
        {
            Session["ExportTable"] = dtACC_ExpInm_LedgerBAL;
            Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType);
        }
    }

    #endregion 19.1 Excel Export Button Click Event

    #endregion 19.0 Export Data x`

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 20.0 Cancel Button Event

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    protected void ddlPageSizeTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #endregion 21.0 ddlPageSize Selected Index Changed Event

    #region 22.0 ClearControls 

    private void ClearControls()
    {
        txtLedgerType.Text = String.Empty;
        dtpLedgerFromDate.Text = String.Empty;
        dtpLedgerToDate.Text = String.Empty;
        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls

    #region 23.0 SetDefaultDateTime
    private void SetDefaultDateTime()
    {
        DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        dtpLedgerFromDate.Text = dateTime.Date.ToString("dd-MM-yyyy");
        dtpLedgerToDate.Text = Convert.ToDateTime(dateTime).AddMonths(1).AddDays(-1).Date.ToString("dd-MM-yyyy");
    }
    #endregion SetDefaultDateTime


}