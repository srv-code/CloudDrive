using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// SQL Namespaces
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /*
    [WebMethod]
    public string[] getDBFilesSuggestionList(string prefixText, int count)
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

        string[] names = new string[DB.DBFiles.Count()];
        List<string> MatchList = new List<string>();

        var res = from v in DB.GetTable<DBFile>() where v.Mode.ToString() == "General" select v;
        int i = 0;
        foreach (var r in res)
            names[i++] = r.UploadedFileName;

        foreach (string element in names)
            if (element.ToLower().Contains(prefixText.ToLower())) MatchList.Add(element);
        return MatchList.ToArray();
    }
    */

    [WebMethod]
    public string[] getUserInfosSuggestionList(string prefixText, int count)
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

        string[] names = new string[DB.UserInfos.Count()];
        List<string> MatchList=new List<string>();

        var res = from v in DB.GetTable<UserInfo>() select v;
        int i = 0;
        foreach (var r in res)
            names[i++] = r.UserFirstName + " " + r.UserLastName + " [" + r.Username + "]";
        
        foreach (string element in names)
            if (element.ToLower().Contains(prefixText.ToLower())) MatchList.Add(element);
        return MatchList.ToArray();
    }
    
}
