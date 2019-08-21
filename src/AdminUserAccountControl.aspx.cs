using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class AdminUserAccountControl : System.Web.UI.Page
{
    void SendMessageToUser()
    {
        if (txtMessageToUser.Text.Trim() == "")
        {
            //lblUserMessageSendingErrorMessage.Visible = true;
            lblUserMessageSendingErrorMessage.ForeColor = System.Drawing.Color.Red;
            lblUserMessageSendingErrorMessage.Text = "Please enter a message first to send to the user!";
            return;
        }
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = DB.UserInfos.Where(x => x.Username == Request.QueryString["User"].ToString());
        foreach (var r in res) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).ToString() + "] A message from Site's Administrator: " + txtMessageToUser.Text + "|" + r.Notifications.ToString();
        DB.SubmitChanges();
        lblUserMessageSendingErrorMessage.ForeColor = System.Drawing.Color.DarkBlue;
        lblUserMessageSendingErrorMessage.Text = "Message sent to the user successfully!";
        txtMessageToUser.Text = "";
    }
    void DisplayUserInfo()
    {
        //lblUserMessageSendingErrorMessage.Visible = false;
        //lblUserMessageSendingErrorMessage.Text = "";
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        // var res = from v in DB.GetTable<UserInfo>() where v.Username == Request.QueryString["User"].ToString() select v;
        var res = DB.UserInfos.Where(x => x.Username == Request.QueryString["User"].ToString());
        foreach (var r in res)
        {
            lblUsername.Text = r.Username;
            lblFirstName.Text = r.UserFirstName;
            if (r.UserMiddleName == "")
            {
                Label3.Visible = false; lblMiddleName.Visible = false;
            }
            else
            {
                Label3.Visible = true; lblMiddleName.Text = r.UserMiddleName;
            }
            lblLastName.Text = r.UserLastName;
            lblGender.Text = r.UserGender;
            lblDOB.Text = r.UserDOB;
            lblCountry.Text = r.UserCountry;
            lblCity.Text = r.UserCity;
            if (r.UserMartialStatus == "y")
                lblMartialStatus.Text = "Married";
            else
                lblMartialStatus.Text = "Unmarried";
            lblEMail.Text = r.UserEMail;
            lblSendUserMessage.Text = "Send a message to " + r.UserFirstName + " " + r.UserLastName + ":";
            ImageUserProfilePicture.ImageUrl = r.UserProfilePicFile;
        }
    }
    void DeleteUserAccount()
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = DB.UserInfos.Where(x => x.Username == lblUsername.Text);
        foreach (var r in res)
            DB.UserInfos.DeleteOnSubmit(r);
        DB.SubmitChanges();
        Response.Redirect("AdminPage.aspx");
    }
    void checkForValidSession()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            if ((DB.AdminInfos.Where(x => x.AdminName == Session["user"].ToString()).Count() == 1 ? true : false))
            { PanelAdminControlTools.Visible = true; PanelUserTools.Visible = false; ImageAdminPic.Visible = true; return; }
            if ((DB.UserInfos.Where(y => y.Username == Session["user"].ToString()).Count() == 1 ? true : false))
            { PanelAdminControlTools.Visible = false; PanelUserTools.Visible = true; ImageAdminPic.Visible = false; return; }
            throw new Exception();
        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkForValidSession();
        DisplayUserInfo();
    }
    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {
        DeleteUserAccount();
    }
    protected void btnSendUserMessage_Click(object sender, EventArgs e)
    {
        SendMessageToUser();
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