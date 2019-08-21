using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestPage_ShareFilesWithOtherUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {}
    protected void Button1_Click(object sender, EventArgs e)
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = from v in DB.GetTable<FileSharingRequest>() select v.ID;
        int nextID = 0;
        foreach (var r in res) if ((int)r > nextID) nextID = (int)r;
        nextID++;
        TextBox1.Text = "nextID = " + nextID;
    }
}