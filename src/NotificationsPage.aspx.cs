using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotificationsPage : System.Web.UI.Page
{
    void ShowPageHeading()
    {
        try
        {
            if (!Page.IsPostBack)
            {
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                string CustUsername = Session["user"].ToString();
                var res = DB.UserInfos.Where(x => x.Username == CustUsername);
                foreach (var r in res)
                {
                    if (r.UserGender == "Male") lblHeading.Text += "Mr. ";
                    else
                    {
                        if (r.UserMartialStatus == "n") lblHeading.Text += "Miss ";
                        else lblHeading.Text = "Mrs. ";
                    }
                    lblHeading.Text += r.UserFirstName + " " + r.UserLastName;
                }
            }
        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void ShowAllNotifications()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            string CustUsername = Session["user"].ToString();
            var res = DB.UserInfos.Where(x => x.Username == CustUsername);
            string notifications = "";
            foreach (var r in res) notifications = r.Notifications.ToString();

            char[] ntfFetched = notifications.ToCharArray();
            int newNotifications = 0;

            for (int i = 0; i < (ntfFetched.Length - 1); i++)
            {
                Label lbl = new Label(); lbl.Text = "";
                lbl.CssClass = "Notifications";
                Image img = new Image();

                if (ntfFetched[i] == '*')
                {
                    i++; newNotifications++;
                    lbl.ForeColor = System.Drawing.Color.Red;
                    img.ImageUrl = "~/Images/NotificationImages/new_notifications.png";
                    img.Height = 30; img.Width = 30;
                }
                else
                {
                    img.ImageUrl = "~/Images/NotificationImages/tick.png";
                    img.Height = 25; img.Width = 25;
                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                }
                while (ntfFetched[i] != '|' && i < (ntfFetched.Length - 1))
                {
                    lbl.Text += ntfFetched[i].ToString(); i++;
                }
                //i++;

                // --- Attatching all Controls (Image, Label) to the Placeholder Control 
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;"));
                PlaceHolder1.Controls.Add(img); PlaceHolder1.Controls.Add(new LiteralControl("&nbsp; "));
                PlaceHolder1.Controls.Add(lbl);
                // --- Attatching all Controls (Image, Label) to the Placeholder Control 
            }

            // Show new notification message
            if (newNotifications == 0) lblNewNotificationMessage.Text = "You have no new notification!";
            else if (newNotifications == 1) lblNewNotificationMessage.Text = "You have " + newNotifications.ToString() + " new notification!";
            else lblNewNotificationMessage.Text = "You have " + newNotifications.ToString() + " new notifications!";
        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void RemoveAllNewNotifications()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            string CustUsername = Session["user"].ToString();
            var res = DB.UserInfos.Where(x => x.Username == CustUsername);
            string oldNotifications = "";
            foreach (var r in res) oldNotifications += r.Notifications.ToString();
            char[] ntfFetched = oldNotifications.ToCharArray();
            string newNotifications = "";
            foreach (char ch in ntfFetched) if (ch != '*') newNotifications += ch.ToString();
            foreach (var r in res) r.Notifications = newNotifications;
            DB.SubmitChanges();
        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowPageHeading();
        ShowAllNotifications();
        RemoveAllNewNotifications();
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