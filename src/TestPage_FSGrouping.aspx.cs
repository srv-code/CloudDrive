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

public partial class TestPage_FSGrouping : System.Web.UI.Page
{
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
    } 
    protected void btnCreateNewGroup_Click(object sender, EventArgs e)
    {
        Session["user"] = "SouravDey";
        Session["usersAddedInNewGroup"] = Session["user"] + "|";
        PanelCreateNewGroup.Visible = true;
    }
    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        populateGridViewSearchedUsers();
    }
    string[] getUsersAddedInNewGroup()
    {
        // ******* Storing usernames to string array
        char[] users_chars = Session["usersAddedInNewGroup"].ToString().ToCharArray();
        string[] usernamesFound = new string[25];
        int indexUsernames = 0;
        foreach (char c in users_chars)
            if (c == '|') indexUsernames++;
            else usernamesFound[indexUsernames] += c.ToString();

        return usernamesFound;
    }
    int getArrayFilledUpSize(string[] array)
    {
        int i;
        for (i = 0; i < array.Length; i++)
            if (array[i] == null) break;
        return i;
    }
    void populateGridViewAddedUsers()
    {
        //try
        //{
            string[] usersAddedInNewGroup = getUsersAddedInNewGroup();

            string sqlQuery = "";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
        
            sqlQuery = "select UserFirstName \"First Name\", UserMiddleName \"Middle Name\", UserLastName \"Last Name\", Username \"Username\" from UserInfos where ";
            int noOfUsers = getArrayFilledUpSize(usersAddedInNewGroup);

            for (int i = 0; i < noOfUsers; i++)
                if (i == (noOfUsers - 1)) sqlQuery += " Username='" + usersAddedInNewGroup[i] + "' ";
                else sqlQuery += " Username='" + usersAddedInNewGroup[i] + "' or ";

            //Response.Write("GridViewAddedUsers sqlQuery = " + sqlQuery);

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader reader = cmd.ExecuteReader();
            GridViewAddedUsers.DataSource = reader;
            GridViewAddedUsers.DataBind();
            con.Close();

            lblUsersAddedCounter.Text = GridViewAddedUsers.Rows.Count + " user(s) selected for adding!";
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            for (int i = 0; i < GridViewAddedUsers.Rows.Count; i++)
            {
                ImageButton imgbtnProPic = new ImageButton();
                imgbtnProPic = (ImageButton)GridViewAddedUsers.Rows[i].FindControl("imgbtnUserProPic0");
                imgbtnProPic.PostBackUrl = "AdminUserAccountControl.aspx?User=" + GridViewAddedUsers.Rows[i].Cells[4].Text;
                imgbtnProPic.ImageAlign = System.Web.UI.WebControls.ImageAlign.AbsBottom;
                var res = from v in DB.GetTable<UserInfo>() where v.Username == GridViewAddedUsers.Rows[i].Cells[4].Text select v.UserProfilePicFile;
                foreach (var r in res) imgbtnProPic.ImageUrl = r.ToString();
                Button btnRemove = new Button();
                btnRemove = (Button)GridViewAddedUsers.Rows[i].FindControl("btnRemoveUser");
                if (GridViewAddedUsers.Rows[i].Cells[4].Text == Session["user"].ToString())
                    btnRemove.Enabled = false;
                else
                    btnRemove.CommandArgument = GridViewAddedUsers.Rows[i].Cells[4].Text;
                
            }
            if (GridViewAddedUsers.Rows.Count > 1) { }
            else { }
                
        //}
        //catch (Exception exc) { Response.Write(" | <b>Exc caught</b> inside populateGridViewAddedUsers()! Exc Details: " + exc.Message + " sqlQuery=" + sqlQuery + " | "); }
    }
    void populateGridViewSearchedUsers()
    {
        if (txtSearchUser.Text.Trim() == "")
        {
            lblSearchUserErrorMessage.Text = "Please enter a non-null search term!"; return;
        }

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string sqlQuery = "select UserFirstName \"First Name\", UserMiddleName \"Middle Name\", UserLastName \"Last Name\", Username \"Username\" from UserInfos where UserFirstName like '%" + txtSearchUser.Text.Trim() + "%' or UserMiddleName  like '%" + txtSearchUser.Text.Trim() + "%' or UserLastName like '%" + txtSearchUser.Text.Trim() + "%' ";
        SqlCommand cmd = new SqlCommand(sqlQuery, con);
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewSearchedUsers.DataSource = reader;
        GridViewSearchedUsers.DataBind();
        con.Close();

        lblSearchUserErrorMessage.Text = GridViewSearchedUsers.Rows.Count + " result(s) returned!";
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        for (int i = 0; i < GridViewSearchedUsers.Rows.Count; i++)
        {
            ImageButton imgbtnProPic = new ImageButton();
            imgbtnProPic = (ImageButton)GridViewSearchedUsers.Rows[i].FindControl("imgbtnUserProPic");
            imgbtnProPic.PostBackUrl = "AdminUserAccountControl.aspx?User=" + GridViewSearchedUsers.Rows[i].Cells[4].Text;
            imgbtnProPic.ImageAlign = System.Web.UI.WebControls.ImageAlign.AbsBottom;
            var res = from v in DB.GetTable<UserInfo>() where v.Username == GridViewSearchedUsers.Rows[i].Cells[4].Text select v.UserProfilePicFile;
            foreach (var r in res) imgbtnProPic.ImageUrl = r.ToString();
            Button btnAdd = new Button();
            btnAdd = (Button)GridViewSearchedUsers.Rows[i].FindControl("btnAddUser");
            btnAdd.CommandArgument = GridViewSearchedUsers.Rows[i].Cells[4].Text;
        }
    }
    protected void btnUserSignOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        populateGridViewAddedUsers();
    }
    protected void GridViewSearchedUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName.ToString() == "AddUserInNewGroup")
        {
            //Response.Write(" AddUserInNewGroup() working! " + DateTime.Now.ToString("HH:mm:ss") + " | ");
            Button btn = sender as Button;
            if (!((getUsersAddedInNewGroup()).Contains(e.CommandArgument.ToString()))) Session["usersAddedInNewGroup"] += e.CommandArgument.ToString() + "|";
            populateGridViewAddedUsers();
        }
    }
protected void GridViewAddedUsers_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if(e.CommandName.ToString() == "RemoveUserFromNewGroup")
    {
        //Response.Write(" RemoveUserFromNewGroup() working! " + DateTime.Now.ToString("HH:mm:ss") + " | ");
        Button btn = sender as Button;
        string[] usersList = getUsersAddedInNewGroup();
        Session["usersAddedInNewGroup"] = "";

        foreach (string user in usersList)
        {
            if (user == null) break;
            if (!(user == e.CommandArgument.ToString())) Session["usersAddedInNewGroup"] += user + "|";
        }
        populateGridViewAddedUsers();
    }
}
protected void btnCreateNewGroup_Click1(object sender, EventArgs e)
{
    PanelCreateNewGroup.Visible = true;
    Session["user"] = "SouravDey";
    Session["usersAddedInNewGroup"] = Session["user"].ToString() + "|";
    populateGridViewAddedUsers();
}
protected void Button2_Click(object sender, EventArgs e)
{
    try { Response.Write("Session[usersAddedInNewGroup]=" + Session["usersAddedInNewGroup"]); }
    catch (System.NullReferenceException exc) { Response.Write(" | <b>Exc occured</b> in Session[usersAddedInNewGroup]: " + exc.Message + " |"); }

    try { Response.Write("  Session[user]=" + Session["user"]); }
    catch (System.NullReferenceException exc) { Response.Write(" | <b>Exc occured</b> in Session[user]: " + exc.Message + " |"); }

}
protected void btnCreateGroup_Click(object sender, EventArgs e)
{
}
}
