using GNForm3C;
using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_BranchIntake : System.Web.UI.Page
{
    #region Variables

    String FormName = "Branch Intake";
    static Int32 PageRecordSize = CV.PageRecordSize; // Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #endregion Variables

    #region Page Load event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion Check User Login

        if (!Page.IsPostBack)
        {
            Search(1);

            #region Set Help Text
            //ucHelp.ShowHelp("Help Text will be shown here");
            #endregion Set Help Text
        }
    }

    #endregion Page Load event

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

        MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
        DataTable dt = balMST_BranchIntake.GetBranchIntakeData();


        if (dt != null && dt.Rows.Count > 0)
        {

            rpAddmissionYearHead.DataSource = CommonFunctions.ColumnOfDataTable(dt);
            rpAddmissionYearHead.DataBind();
            rpIntakeData.DataSource = dt;
            rpIntakeData.DataBind();

        }
        else
        {

            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }

    #endregion 15.2 Search Function

    #region 15.3 rpIntake_ItemDataBound
    protected void rpIntake_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rpAddmissionYearBody = (Repeater)e.Item.FindControl("rpAddmissionYearBody");
            DataRowView drv = (DataRowView)e.Item.DataItem;

            if (rpAddmissionYearBody != null && drv != null)
            {
                // Retrieve column names excluding the "Branch" column
                DataTable dt = drv.DataView.Table;
                List<string> yearColumns = CommonFunctions.ColumnOfDataTable(dt).GetRange(1, dt.Columns.Count - 1);

                // Create a data source with year and intake pairs for binding
                List<YearIntakePair> yearIntakePairs = new List<YearIntakePair>();
                foreach (string year in yearColumns)
                {
                    yearIntakePairs.Add(new YearIntakePair
                    {
                        Year = year,
                        Intake = drv[year].ToString()
                    });
                }

                rpAddmissionYearBody.DataSource = yearIntakePairs;
                rpAddmissionYearBody.DataBind();
            }
        }
    }

    // Helper class to store year and intake pairs
    public class YearIntakePair
    {
        public string Year { get; set; }
        public string Intake { get; set; }
    }
    protected string BindIntakeData(string year, object dataItem)
    {
        DataRowView rowView = dataItem as DataRowView;
        if (rowView != null && rowView.Row.Table.Columns.Contains(year))
        {
            return rowView[year].ToString();
        }
        return string.Empty;
    }

    #endregion 15.3 rpIntake_ItemDataBound

    #endregion 15.0 Search

    #region 16.0 MST_BranchIntake Add/Edit
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
                //MST_StudentBranchIntakeMatrixENT entSTU_StudentBranchIntakeMatrix = new MST_StudentBranchIntakeMatrixENT();
                DataTable branchIntakeTable = new DataTable();
                branchIntakeTable.Columns.Add("Branch", typeof(string));
                branchIntakeTable.Columns.Add("AdmissionYear", typeof(string));
                branchIntakeTable.Columns.Add("Intake", typeof(int));



                foreach (RepeaterItem item in rpIntakeData.Items)
                {
                    Label lblBranch = (Label)item.FindControl("lblBranch");

                    if (lblBranch != null)
                    {
                        Repeater rpAddmissionYearBody = (Repeater)item.FindControl("rpAddmissionYearBody");

                        if (rpAddmissionYearBody != null)
                        {
                            foreach (RepeaterItem yearItem in rpAddmissionYearBody.Items)
                            {
                                TextBox txtIntake = (TextBox)yearItem.FindControl("txtIntake");
                                Label lblYear = (Label)yearItem.FindControl("lblYear");

                                if (txtIntake != null && lblYear != null)
                                {
                                    int intake;
                                    int year;

                                    if (int.TryParse(txtIntake.Text, out intake) && int.TryParse(lblYear.Text, out year))
                                    {
                                        branchIntakeTable.Rows.Add(lblBranch.Text, year, intake);
                                    }
                                }
                            }


                        }
                    }
                }
                if (balMST_BranchIntake.SaveBranchIntakeData(branchIntakeTable))
                {
                    ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                }
                else
                {
                    ucMessage.ShowError(balMST_BranchIntake.Message);
                }
                

                // Refresh the data
                Search(1);
               
               

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
            
        }
    }

    #endregion 16.0 MST_BranchIntake Add/Edit

    #region 17.0 Clear Button
    protected void btnClear_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in rpIntakeData.Items)
        {
            Repeater rpAddmissionYearBody = (Repeater)item.FindControl("rpAddmissionYearBody");

            if (rpAddmissionYearBody != null)
            {
                foreach (RepeaterItem yearItem in rpAddmissionYearBody.Items)
                {
                    TextBox txtIntake = (TextBox)yearItem.FindControl("txtIntake");

                    if (txtIntake != null)
                    {
                        txtIntake.Text = string.Empty;
                    }
                }
            }
        }
    }
    #endregion  17.0 Clear Button

}