using GNForm3C.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Web.Script.Services;
using System.Web.Services;


[WebService(Namespace = "~/WebService/WebService_MST_Patient")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WebService_MST_Patient : System.Web.Services.WebService
{

    public WebService_MST_Patient()
    {

    }

    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public List<string> GetPatientList(string prefixText, string count)
    {
        SqlString TxtSearch = SqlString.Null;
        SqlString TxtContext = SqlString.Null;

        if (prefixText != "")
            TxtSearch = Convert.ToString(prefixText);

        Console.WriteLine(TxtSearch);

        List<string> list = new List<string>();
        MST_PatientBAL balMST_Patient = new MST_PatientBAL();
        DataTable dt = balMST_Patient.AutoComplete(TxtSearch, TxtContext);

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string detail = string.Format("{0} - {1} - {2}",
                        row["PatientID"].ToString(),
                        row["PatientName"].ToString(),
                        row["MobileNo"].ToString()
                    );
                list.Add(detail);
            }

        }

        return list;
    }
}