using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Security_Demo_DemoView : System.Web.UI.Page
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
            if (Request.QueryString["DemoID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["DemoID"] != null)
        {
            DemoBAL balDemo = new DemoBAL();
            DataTable dtMST_Hospital = balDemo.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["DemoID"]));
            if (dtMST_Hospital != null)
            {
                foreach (DataRow dr in dtMST_Hospital.Rows)
                {

                    if (!dr["DemoName"].Equals(DBNull.Value))
                        lblDemoName.Text = Convert.ToString(dr["DemoName"]);

                    if (!dr["UserName"].Equals(DBNull.Value))
                        lblUserName.Text = Convert.ToString(dr["UserName"]);

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