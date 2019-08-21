using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class terms_and_policy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null) linkGoBackToCustomerPage.Visible = false;
        else linkGoBackToCustomerPage.Visible = true;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerPage.aspx");
    }
    protected void linkGoBackToCustomerPage_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerPage.aspx");
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
}