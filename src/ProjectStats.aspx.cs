using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.countMe();        
    }
    protected void fetchAllData()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/Tracker.xml"));

        txtAllDataFetched.Text = "Number of page hits: " + tmpDs.Tables[0].Rows[0]["hits"].ToString();
        //txtAllDataFetched.Text += "Current Password: " + tmpDs.Tables[0].Rows[0]["password"].ToString();
    }
    private void countMe()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/Tracker.xml"));

        int hits = Int32.Parse(tmpDs.Tables[0].Rows[0]["hits"].ToString());

        hits++;

        tmpDs.Tables[0].Rows[0]["hits"] = hits.ToString();

        tmpDs.WriteXml(Server.MapPath("~/Tracker.xml"));
    } 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        checkPassword();
    }
    protected void checkPassword()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/Tracker.xml"));        
        
        if (txtPassword.Text == tmpDs.Tables[0].Rows[0]["password"].ToString()) // "sybase55500_03412529069")
        {
            lblPasswordErrorMessage.Text = "Password accepted!";
            PanelStatistics.Visible = true;
        }
        else
        {
            PanelStatistics.Visible = false;
            lblPasswordErrorMessage.Text = "Wrong password!";
        }
    }
    protected void btnFetchAllData_Click(object sender, EventArgs e)
    {
        fetchAllData();
    }
    protected void changePassword()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/Tracker.xml"));

        if (txtOldPassword.Text != tmpDs.Tables[0].Rows[0]["password"].ToString())
        {
            lblPasswordChangeErrorMessage.Text = "Wrong old password!"; return;
        }
        if (txtNewPassword1.Text != txtNewPassword2.Text)
        {
            lblPasswordChangeErrorMessage.Text = "New passwords didn't matched!"; return;
        }
        if (txtNewPassword1.Text.Trim() == "")
        {
            lblPasswordChangeErrorMessage.Text = "Cannot assign a null password!"; return;
        }
        lblPasswordChangeErrorMessage.Text = "Password changed successfully!";
        tmpDs.Tables[0].Rows[0]["password"] = txtNewPassword2.Text;
        tmpDs.WriteXml(Server.MapPath("~/Tracker.xml"));
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        changePassword();
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {
        // Getting ip of visitor
        string ip = Request.ServerVariables["REMOTE_ADDR"];
        // Getting the page which called the script
        string page = Request.ServerVariables["HTTP_REFERER"];
        // Getting Browser Name of Visitor
        string browser = "Not available";
        txtAllDataFetched.Text = " ip = " + ip + "\n page = " + page + "\n browser = " + Request.ServerVariables["HTTP_USER_AGENT"].ToString() + "\n REMOTE_HOST = " + Request.ServerVariables["REMOTE_HOST"].ToString() + "\n SERVER_NAME = " + Request.ServerVariables["SERVER_NAME"].ToString() + "\n SERVER_PORT	= " + Request.ServerVariables["SERVER_PORT"].ToString() + "\n SERVER_SOFTWARE = " + Request.ServerVariables["SERVER_SOFTWARE"].ToString() + "\n URL = " + Request.ServerVariables["URL"].ToString();
        txtAllDataFetched.Text += "\n\n\nAll Request.ServerVariables:\n"; 
        foreach (string x in Request.ServerVariables)
        {
            txtAllDataFetched.Text += "\n\t Request.ServerVariables[" + x + "] = " + Request.ServerVariables[x] ;
        }
    }
    protected void resetPageHitCounter()
    {
        DataSet tmpDs = new DataSet();
        tmpDs.ReadXml(Server.MapPath("~/Tracker.xml"));
        tmpDs.Tables[0].Rows[0]["hits"] = "0".ToString();
        tmpDs.WriteXml(Server.MapPath("~/Tracker.xml"));

        tmpDs.ReadXml(Server.MapPath("~/Tracker.xml"));
        if(tmpDs.Tables[0].Rows[0]["hits"].ToString() == "0") lblResetPageHitCounterMessage.Text = "Counter resetting done!";
    }
    protected void btnResetPageHitCounter_Click(object sender, EventArgs e)
    {
        resetPageHitCounter();
    }
}