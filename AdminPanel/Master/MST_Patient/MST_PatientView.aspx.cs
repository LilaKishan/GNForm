using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using GNForm3C.DAL;
public partial class AdminPanel_Master_MST_Patient_MST_PatientView : System.Web.UI.Page
{
    #region Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 10.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 10.1 Check User Login 

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PatientID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["PatientID"] != null)
        {
            MST_PatientBAL balMST_Patient = new MST_PatientBAL();
            DataTable dtMST_Patient = balMST_Patient.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["PatientID"]));
            if (dtMST_Patient != null)
            {
                foreach (DataRow dr in dtMST_Patient.Rows)
                {

                    if (!dr["PatientName"].Equals(DBNull.Value))
                        lblPatientName.Text = Convert.ToString(dr["PatientName"]);

                    if (!dr["Age"].Equals(DBNull.Value))
                        lblAge.Text = Convert.ToInt32(dr["Age"]).ToString();

                    if (!dr["DOB"].Equals(DBNull.Value))
                        lblDOB.Text = Convert.ToDateTime(dr["DOB"]).ToString();

                    if (!dr["MobileNo"].Equals(DBNull.Value))
                        lblMobileNo.Text = Convert.ToString(dr["MobileNo"]);

                    if (!dr["PrimaryDesc"].Equals(DBNull.Value))
                        lblPrimaryDesc.Text = Convert.ToString(dr["PrimaryDesc"]).ToString();

                    

                    if (!dr["UserName"].Equals(DBNull.Value))
                        lblUserID.Text = Convert.ToString(dr["UserName"]);

                    if (!dr["Created"].Equals(DBNull.Value))
                        lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

                    if (!dr["Modified"].Equals(DBNull.Value))
                        lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

                }
            }
        }
    }
    #endregion FillControls
}
