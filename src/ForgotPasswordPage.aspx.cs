using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPasswordPage : System.Web.UI.Page
{
    void Wait()
    {
        System.Threading.Thread.Sleep(1000);
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        bool test=DB.UserInfos.Where(x => x.Username==txtUsername.Text).Count()==1?true:false;
        if (test == true)
        {
            txtUsername.Enabled = false;
            lblWarning.Text = "";
            var qn = from v in DB.GetTable<UserInfo>() where v.Username == txtUsername.Text select v.UserSecurityQuestion;
            foreach (var r in qn)
                txtSecurityQuestion.Text = r;
            txtSecurityQuestion.Enabled = false;
        }
        else
        {
            lblWarning.Text = "No such username was found! Please check the username first!";
        }
    }
    protected void btnGetPwd_Click(object sender, EventArgs e)
    {
        Wait();
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        bool test = DB.UserInfos.Where(x => x.Username==txtUsername.Text && x.UserSecurityQuestion==txtSecurityQuestion.Text && x.UserSecurityAnswer==txtSecurityAnswer.Text).Count()==1?true:false;
        if (test == true)
        {
            PanelShowUserPwd.Visible = true;
            PanelGetUserInputs.Visible = false;
            var pwd = from v in DB.GetTable<UserInfo>() where v.Username == txtUsername.Text select v.UserPwd;
            foreach(var r in pwd)
                lblShowUserPwd.Text="Your account password was: '" + r + "'";
        }
        else
        {
            if(txtUsername.Text != "" && txtSecurityQuestion.Text != "" && txtSecurityAnswer.Text != "")
                lblWarning.Text = "Your security answer did not matched with the security answer you provided! Please try again!";
        }
    }
}