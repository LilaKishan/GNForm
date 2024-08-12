using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_StudentAddEditPopup : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "MST_StudentAddEdit";

    #endregion 10.0 Variables 

    #region 11.0 Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 DropDown List Fill Section 

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section 

            #region 11.4 Set Control Default Value 

            lblFormHeader.Text = CV.PageHeaderAdd + " Student";
            txtModalStudentName.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 



        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels 

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 

    #region 13.0 Fill DropDownList 

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCurrentSem(ddlModalCurrentSem);
        CommonFillMethods.FillDropDownListGender(ddlModalGender);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK  

    private void FillControls()
    {
        if (Request.QueryString["StudentID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Student";
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            MST_StudentENT entMST_Student = new MST_StudentENT();
            entMST_Student = balMST_Student.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]));

            if (!entMST_Student.StudentName.IsNull)
                txtModalStudentName.Text = entMST_Student.StudentName.Value.ToString();

            if (!entMST_Student.EnrollmentNo.IsNull)
                txtModalEnrollmentNo.Text = entMST_Student.EnrollmentNo.Value.ToString();

            if (!entMST_Student.CurrentSem.IsNull)
                ddlModalCurrentSem.SelectedValue = entMST_Student.CurrentSem.Value.ToString();

            if (!entMST_Student.EmailInstitute.IsNull)
                txtModalEmailInstitute.Text = entMST_Student.EmailInstitute.Value.ToString();

            if (!entMST_Student.EmailPersonal.IsNull)
                txtModalEmailPersonal.Text = entMST_Student.EmailPersonal.Value.ToString();

            if (!entMST_Student.Gender.IsNull)
                ddlModalGender.SelectedValue = entMST_Student.Gender.Value.ToString();

            if (!entMST_Student.RollNo.IsNull)
                txtModalRollNo.Text = entMST_Student.RollNo.Value.ToString();

            if (!entMST_Student.BirthDate.IsNull)
                dtpModalBirthDate.Text = entMST_Student.BirthDate.Value.ToString(CV.DefaultDateFormat);

            if (!entMST_Student.ContactNo.IsNull)
                txtModalContactNo.Text = entMST_Student.ContactNo.Value.ToString();
        }
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate("vdStudent");
        if (Page.IsValid)
        {
            try
            {
                MST_StudentBAL balMST_Student = new MST_StudentBAL();
                MST_StudentENT entMST_Student = new MST_StudentENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtModalStudentName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Student Name");
                if (txtModalEnrollmentNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Enrollment No");
                if (ddlModalCurrentSem.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Current Sem");
                if (txtModalEmailPersonal.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Email Personal");
                if (ddlModalGender.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Gender");
                if (txtModalContactNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Contact No");
                if (dtpModalBirthDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birth Date");


                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);

                    // Set the data-target attribute dynamically
                    btnSave.Attributes["data-target"] = "#view";
                    btnSave.Attributes["data-toggle"] = "modal";

                    // Use JavaScript to show the modal again
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MasterPageView", "$('#view').modal('show');", true);

                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 


                if (txtModalStudentName.Text.Trim() != String.Empty)
                    entMST_Student.StudentName = txtModalStudentName.Text.Trim();

                if (txtModalEnrollmentNo.Text.Trim() != String.Empty)
                    entMST_Student.EnrollmentNo = txtModalEnrollmentNo.Text.Trim();

                if (ddlModalCurrentSem.SelectedIndex > 0)
                    entMST_Student.CurrentSem = Convert.ToInt32(ddlModalCurrentSem.SelectedValue);

                if (txtModalEmailInstitute.Text.Trim() != String.Empty)
                    entMST_Student.EmailInstitute = txtModalEmailInstitute.Text.Trim();

                if (txtModalEmailPersonal.Text.Trim() != String.Empty)
                    entMST_Student.EmailPersonal = txtModalEmailPersonal.Text.Trim();

                if (ddlModalGender.SelectedIndex > 0)
                    entMST_Student.Gender = ddlModalGender.SelectedValue.Trim();

                if (dtpModalBirthDate.Text.Trim() != String.Empty)
                    entMST_Student.BirthDate = Convert.ToDateTime(dtpModalBirthDate.Text.Trim());
                if (txtModalRollNo.Text.Trim() != String.Empty)
                    entMST_Student.RollNo = Convert.ToInt32(txtModalRollNo.Text.Trim());
                if (txtModalContactNo.Text.Trim() != String.Empty)
                    entMST_Student.ContactNo = txtModalContactNo.Text.Trim();



                entMST_Student.UserID = Convert.ToInt32(Session["UserID"]);

                entMST_Student.Created = DateTime.Now;

                entMST_Student.Modified = DateTime.Now;


                #endregion 15.2 Gather Data 


                #region 15.3 Insert,Update,Copy 

                if (Request.QueryString["StudentID"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Student.StudentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]);
                    if (balMST_Student.Update(entMST_Student))
                    {
                        // Use Response.Redirect with endResponse set to false
                        Response.Redirect("MST_StudentList.aspx", false);

                        // Complete the request
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        ucMessage.ShowError(balMST_Student.Message);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);
                    }
                }

                else
                {
                    if (Request.QueryString["StudentID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Student.Insert(entMST_Student))
                        {
                            ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                            ClearControls();
                            Response.Redirect("MST_StudentList.aspx");
                            Context.ApplicationInstance.CompleteRequest();

                        }
                        else
                        {
                            ucMessage.ShowError(balMST_Student.Message);

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);
                        }
                    }
                }

                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#view').modal('show');", true);

            }
        }

    }


    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 

    private void ClearControls()
    {
        txtModalStudentName.Text = String.Empty;
        txtModalEnrollmentNo.Text = String.Empty;
        ddlModalCurrentSem.SelectedIndex = 0;
        txtModalEmailInstitute.Text = String.Empty;
        txtModalEmailPersonal.Text = String.Empty;
        ddlModalGender.SelectedIndex = 0;
        txtModalRollNo.Text = String.Empty;
        txtModalContactNo.Text = String.Empty;
        dtpModalBirthDate.Text = String.Empty;
        txtModalStudentName.Focus();
    }

    #endregion 16.0 Clear Controls 


}