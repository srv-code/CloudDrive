using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StartPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("https:localhost:44302//Homepage.aspx?s=1");
        //Response.Redirect("Homepage.aspx?s=1");
    }
}