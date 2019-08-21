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
// IonicZip Namespace
using Ionic.Zip;
using System.IO;
using System.Collections;

public partial class AdminPage : System.Web.UI.Page
{
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    /* void SearchAllFiles()
    {
        PanelCheckNewFiles.Visible = false;
        PanelCheckNewUsers.Visible = false;
        PanelRegisteredUser.Visible = false;
        PanelSearchAllFiles.Visible = true;
        PanelUpdateAdminInfo.Visible = false;
        
        lblSearchResultNo.Visible = true;

        //try
        {
            /* 
             * Facilities added:
             * Searching is not case sensitive
             * Seaching is not leading or trailing white spaces sensitive
            */ /*
            int SearchResNo = 0;
            if (txtSearch.Text.Trim() != "")
            {
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                // var SearchedFiles = from v in (from v0 in DB.GetTable<DBFile>() where v0.Mode == "General" select v0) where v.UploadedFileName.Contains(txtSearch.Text.Trim()) select v;
                var SearchedFiles = DB.DBFiles.Where(x => x.UploadedFileName.Contains(txtSearch.Text.Trim()) && x.Mode == "General");
                //DirectoryInfo mydir = new DirectoryInfo(@Server.MapPath("~/UploadedFiles/ServerDatabase/" + (DropDownListSearchCategory.SelectedItem.Text).Trim() + "s/"));
                foreach (var r in SearchedFiles)
                {
                    SearchResNo++;
                    string FileCategory = r.Category.ToString();

                    // --- Creating label to show the searched file's info 
                    Label lbl = new Label();
                    lbl.Text = "[ Category: " + FileCategory + " | Size: " + r.UploadedFileSize + " | Uploader's Name: " + r.UploaderUserName + " |  Upload Date: " + r.UploadDateTime + " ]";
                    lbl.CssClass = "SearchlblStyle"; lbl.BorderWidth = 0;
                    // *** Creating label to show the searched file's info

                    // --- Creating hyperlink to link the file to the database address
                    HyperLink FileLink = new HyperLink();
                    FileLink.Target = "_blank";
                    FileLink.CssClass = "SearchResultsStyle"; FileLink.BorderWidth = 0;
                    FileLink.Text = Convert.ToString(r.UploadedFileName);
                    FileLink.NavigateUrl = Convert.ToString(r.FileAddressInServerDB);
                    // *** Creating hyperlink to link the file to the database address

                    // --- Creating Image to display the correct icon with respect to the category of the file
                    Image ImgIcon = new Image();
                    switch (FileCategory)
                    {
                        case "Image": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Image.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                        case "Video": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Video.ico"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                        case "Music": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/itunes-icon.png.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                        case "Document": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Document.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                        case "Executable": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Executable.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                    }
                    // --- Attatching all Controls (Image, HyperLink, Label) to the Placeholder Control 
                    PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                    PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;"));
                    PlaceHolder1.Controls.Add(ImgIcon); PlaceHolder1.Controls.Add(new LiteralControl("&nbsp; "));
                    PlaceHolder1.Controls.Add(FileLink); PlaceHolder1.Controls.Add(new LiteralControl("&nbsp; "));
                    PlaceHolder1.Controls.Add(lbl);
                    // --- Attatching all Controls (Image, HyperLink, Label) to the Placeholder Control
                }
            }
                lblSearchResultNo.Text = SearchResNo.ToString() + " results returned!";
        }
    } */
    void LoadAdminCredentials()
    {
        PanelCheckNewFiles.Visible = false;
        PanelCheckNewUsers.Visible = false;
        PanelRegisteredUser.Visible = false;
        PanelSearchAllFiles.Visible = false;
        PanelUpdateAdminInfo.Visible = true;
        
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = from v in DB.GetTable<AdminInfo>() select v;
        foreach(var r in res)
        {
            txtAdminUsername.Text = r.AdminName;
            txtAdminPassword.Text = r.AdminPwd;
        }
    }
    void ChangeAdminCredentials()
    {
        try
        {
            PanelCheckNewFiles.Visible = false;
            PanelCheckNewUsers.Visible = false;
            PanelRegisteredUser.Visible = false;
            PanelSearchAllFiles.Visible = false;
            PanelUpdateAdminInfo.Visible = true;

            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            // var res = from v in DB.GetTable<AdminInfo>() select v;
            var res = DB.AdminInfos.Where(x => x.AdminName == Session["user"]);
            foreach (var r in res)
            {
                r.AdminName = txtAdminUsername.Text;
                r.AdminPwd = txtAdminPassword.Text;
            }
            DB.SubmitChanges();
            lblConfirmAdminCredentialsChange.Text = "Admin credentials changed successfully!";
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void GetRegisteredUsersList()
    {
        PanelCheckNewFiles.Visible = false;
        PanelCheckNewUsers.Visible = false;
        PanelRegisteredUser.Visible = true;
        PanelSearchAllFiles.Visible = false;
        PanelUpdateAdminInfo.Visible = false;
        
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = from v in DB.GetTable<UserInfo>() select v;
        int UserNo = 0;
        foreach (var r in res)
        {
            UserNo++;
            Image UserImg=new Image();
            UserImg.ImageUrl=r.UserProfilePicFile;
            UserImg.Height=50; UserImg.Width=50;
            HyperLink UserLink = new HyperLink(); UserLink.CssClass = "BodyStyle";
            UserLink.Text = r.Username + "  [" + r.UserFirstName + " " + r.UserMiddleName + " " + r.UserLastName + "]";
            UserLink.Target = "_blank";
            UserLink.NavigateUrl = "AdminUserAccountControl.aspx?User=" + r.Username;
            PlaceHolderRegisteredUsers.Controls.Add(UserImg);
            PlaceHolderRegisteredUsers.Controls.Add(new LiteralControl("&nbsp; &nbsp;"));
            PlaceHolderRegisteredUsers.Controls.Add(UserLink);
            PlaceHolderRegisteredUsers.Controls.Add(new LiteralControl("<br />"));
        }
        lblRegisteredUsersNo.Text = UserNo.ToString() + " registered user(s) found!";
    }
    void SearchNewFiles_SQL()
    {
        try
        {
            PanelCheckNewFiles.Visible = true;
            PanelCheckNewUsers.Visible = false;
            PanelRegisteredUser.Visible = false;
            PanelSearchAllFiles.Visible = false;
            PanelUpdateAdminInfo.Visible = false;

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select UploadedFileName_WithExt, Category, UploadedFileSize, UploaderUserName, UploadDateTime from DBFiles where UploadDateTime >= (select LastLogoutDateTime from AdminInfo where AdminName=@AdminName) and Mode='General'", con);
            cmd.Parameters.AddWithValue("@AdminName", Session["user"].ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            GridViewNewFiles.DataSource = reader;
            GridViewNewFiles.DataBind();
            con.Close();

            for (int i = 0; i < GridViewNewFiles.Rows.Count; i++)
            {
                LinkButton linkView = new LinkButton();

                string fullFileAddressInServerDB = "~/UploadedFiles/ServerDatabase/" + GridViewNewFiles.Rows[i].Cells[2].Text + "s/" + GridViewNewFiles.Rows[i].Cells[1].Text + ".zip";
                linkView = (LinkButton)GridViewNewFiles.Rows[i].FindControl("lnkbtnViewContentNewFiles");
                linkView.CommandArgument = fullFileAddressInServerDB;
            }
            lblUnnoticedFilesUploaded.Text = GridViewNewFiles.Rows.Count.ToString() + " new file(s) uploaded since last Admin logout!";
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void SearchNewUsers_SQL()
    {
        try
        {
            PanelCheckNewFiles.Visible = false;
            PanelCheckNewUsers.Visible = true;
            PanelRegisteredUser.Visible = false;
            PanelSearchAllFiles.Visible = false;
            PanelUpdateAdminInfo.Visible = false;

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Username, UserFirstName, UserMiddlename, UserLastName, JoiningDateTime from UserInfos where JoiningDateTime >= (select LastLogoutDateTime from AdminInfo where AdminName=@AdminName)", con);
            cmd.Parameters.AddWithValue("@AdminName", Session["user"]);
            SqlDataReader reader = cmd.ExecuteReader();
            GridViewNewUsers.DataSource = reader;
            GridViewNewUsers.DataBind();
            con.Close();
            for (int i = 0; i < GridViewNewUsers.Rows.Count; i++)
            {
                HyperLink link = new HyperLink(); // link.CssClass = "BodyStyle";
                link = (HyperLink)GridViewNewUsers.Rows[i].FindControl("HyperLinkNewUsers");
                link.NavigateUrl = "AdminUserAccountControl.aspx?User=" + GridViewNewUsers.Rows[i].Cells[1].Text;
            }
            lblUnnoticedUsers.Text = GridViewNewUsers.Rows.Count.ToString() + " new user(s) signed up since last Admin logout!";
        }
        catch (System.Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void checkForValidAdminSession()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            if (!(DB.AdminInfos.Where(y => y.AdminName == Session["user"].ToString()).Count() == 1 ? true : false)) throw new Exception();

        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkForValidAdminSession();
        DeleteFilesFrom_TempDownloads_Directory();    
    }
    protected void btnShowAdminChangeCredentialsPanel_Click(object sender, EventArgs e)
    {
        PanelRegisteredUser.Visible = false;
        PanelSearchAllFiles.Visible = false;
        
        if (PanelUpdateAdminInfo.Visible == false)
        {
            PanelUpdateAdminInfo.Visible = true;
            LoadAdminCredentials();
        }
        else
        {
            PanelUpdateAdminInfo.Visible = false;
        }
    }
    protected void btnChangeAdminCredentials_Click(object sender, EventArgs e)
    {
        ChangeAdminCredentials();
        PanelUpdateAdminInfo.Visible = false;
    }
    protected void btnViewUsers_Click(object sender, EventArgs e)
    {
        if (PanelRegisteredUser.Visible == true)
        {
            PanelRegisteredUser.Visible = false;
        }
        else
        {
            PanelCheckNewFiles.Visible = false;
            PanelCheckNewUsers.Visible = false;
            PanelRegisteredUser.Visible = false;
            PanelUpdateAdminInfo.Visible = false;
            PanelRegisteredUser.Visible = true;
            GetRegisteredUsersList();
        }

    }
    protected void btnSearchAllFiles_Click(object sender, EventArgs e)
    {
        if (PanelSearchAllFiles.Visible == true)
        {
            PanelSearchAllFiles.Visible = false;
        }
        else
        {
            CheckBoxSelectAll.Enabled = false;
            ButtonDeleteFile.Enabled = false;

            GridViewUploadedFiles.DataSource = "";
            GridViewUploadedFiles.DataBind();
            lblDeleteFilesWarning.Text = "";
            txtSearch.Text = "";
            lblSearchResultNo.Text = "";
            PanelCheckNewFiles.Visible = false;
            PanelCheckNewUsers.Visible = false;
            PanelRegisteredUser.Visible = false;
            PanelUpdateAdminInfo.Visible = false;
            PanelSearchAllFiles.Visible = true;            
        }
        UpdatePanelUsageInfo();
    }
    void UpdatePanelUsageInfo()
    {
        lblSearchResultNo.Visible = true;
        //GridViewUploadedFiles.Enabled = false;
        //CheckBoxSelectAll.Enabled = false;
        //ButtonDeleteFile.Enabled = false;

        // 90 MB = total Server DB capacity
        double totalSpaceConsumed = 0;

        lblUsed.Text = ""; lblUnused.Text = "";
        //int counter = 0;
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = DB.DBFiles.Select(x => new { x.UploadedFileName_WithExt, x.UploadedFileSize }).Distinct();
        string fileSizeInString;
        foreach (var r in res)
        {
            //counter++;
            fileSizeInString = r.UploadedFileSize;
            string pt1 = fileSizeInString.Substring(0, (fileSizeInString.Length - 2));
            string pt2 = fileSizeInString.Substring((fileSizeInString.Length - 2), 2);
            if (pt2 == "KB") totalSpaceConsumed += (1024 * Convert.ToDouble(pt1));
            else if (pt2 == "MB") totalSpaceConsumed += (1024 * 1024 * Convert.ToDouble(pt1));
            else totalSpaceConsumed += Convert.ToDouble(pt1);
        }
        //Response.Write("counter = " + counter);

        // Total File Upload Limit Set : 10 MB
        float uploadPercentage = ((float)totalSpaceConsumed / (float)(30.0 * 1024 * 1024)) * 100;

        lblUsed.Width = (int)uploadPercentage * 10;
        if (uploadPercentage >= 20.00) lblUsed.Text = uploadPercentage.ToString("0.00") + "% (" + convertToProperFormat(totalSpaceConsumed) + "/10MB)";
        else
        {
            lblUnused.Width = 500;
            lblUnused.Text = uploadPercentage.ToString("0.00") + "% (" + convertToProperFormat(totalSpaceConsumed) + "/10MB)";
            lblUsed.Text = " ";
        }
    }
    string convertToProperFormat(double uploadSizeInBytes)
    {
        if (uploadSizeInBytes < 1024.0)
            return (uploadSizeInBytes.ToString() + "B");
        else if ((uploadSizeInBytes >= 1024.0) && (uploadSizeInBytes < (1024.0 * 1024.0)))
            return ((uploadSizeInBytes / 1024.0).ToString("0.00") + "KB");
        else
            return ((uploadSizeInBytes / (1024.0 * 1024.0)).ToString("0.00") + "MB");
    }
    void GetUserUploadedFilesList()
    {
        if (txtSearch.Text.Trim() == "") { lblDeleteFilesWarning.Text = "Please enter a search query to search file(s)!"; return; }
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        string sqlQuery = "select distinct UploadedFileName_WithExt \" Original Filename \", UploadedFileSize \" Size \", Category \" Category \", UploadDateTime \" Upload Date/Time \" from DBFiles where Mode='General' and UploadedFileName like '%" + txtSearch.Text.Trim() + "%'";
        SqlCommand cmd = new SqlCommand(sqlQuery, con);

        //Response.Write(" | txtSearch.Text.Trim() = " + txtSearch.Text.Trim() + " | sqlQuery = " + sqlQuery);
        
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewUploadedFiles.DataSource = reader;
        GridViewUploadedFiles.DataBind();
        con.Close();
        int totalFilesNo;
        for (totalFilesNo = 0; totalFilesNo < GridViewUploadedFiles.Rows.Count; totalFilesNo++)
        {
            LinkButton linkView = new LinkButton();

            string fullFileAddressInServerDB = "~/UploadedFiles/ServerDatabase/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[3].Text + "s/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[1].Text + ".zip";
            linkView = (LinkButton)GridViewUploadedFiles.Rows[totalFilesNo].FindControl("lnkbtnViewContentUploadedFiles");
            linkView.CommandArgument = fullFileAddressInServerDB;
        }
        lblSearchResultNo.Text = totalFilesNo.ToString() + " file(s) matched your searched query in the Database";

        //Response.Write(" | GridViewUploadedFiles.Rows.Count = " + GridViewUploadedFiles.Rows.Count + " | totalFilesNo = " + totalFilesNo);

		// Check for GridView rows number
		if (GridViewUploadedFiles.Rows.Count == 0)
        {
            lblSearchResultNo.Text = "No results matched your search query!";
            CheckBoxSelectAll.Enabled = false;
            ButtonDeleteFile.Enabled = false;
        }
        else
        {
            CheckBoxSelectAll.Enabled = true;
            ButtonDeleteFile.Enabled = true;
        }
    }
    /*
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Homepage.aspx?s=1");
    }
    */
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        lblDeleteFilesWarning.Text = "";
        GetUserUploadedFilesList();
    }
    protected void btnCheckNewUsers_Click1(object sender, EventArgs e)
    {
        if (PanelCheckNewUsers.Visible == true)
            PanelCheckNewUsers.Visible = false;
        else
        { 
            PanelCheckNewUsers.Visible = true; 
            SearchNewUsers_SQL(); 
        }
    }
    protected void btnCheckNewFiles_Click(object sender, EventArgs e)
    {
        if (PanelCheckNewFiles.Visible == true)
            PanelCheckNewFiles.Visible = false;
        else
        {
            PanelCheckNewFiles.Visible = true;
            SearchNewFiles_SQL();
        }
    }
    protected void ButtonDeleteFile_Click(object sender, EventArgs e)
    {
        DeleteSelectedRows();
    }
    void SelectUnselectAll()
    {
        if (CheckBoxSelectAll.Checked == true)
        {
            for (int i = 0; i < GridViewUploadedFiles.Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
                chk.Checked = true;
            }
        }
        else
        {
            for (int i = 0; i < GridViewUploadedFiles.Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
                chk.Checked = false;
            }

        }
    }
    void DeleteSelectedRows()
    {
        int TotalRows = GridViewUploadedFiles.Rows.Count;
        int SelectedRows = 0;
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
            if (chk.Checked) SelectedRows++;
        }

        if(SelectedRows == 0)
        {
            lblDeleteFilesWarning.Text = "Please select atleast one of the uploaded files!";
            return;
        }

        string filepath = null;
        string filename = null;
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

        int DeletedRows = 0;
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
            if (chk.Checked)
            {
                filename = GridViewUploadedFiles.Rows[i].Cells[1].Text + ".zip";
                //Response.Write("filename: " + filename);
                filepath = "~/UploadedFiles/ServerDatabase/" + GridViewUploadedFiles.Rows[i].Cells[3].Text + "s/";
                //Response.Write("filepath: " + filepath);


                // --- Deleting File physically from the Server Directory
                DirectoryInfo mydir = new DirectoryInfo(@Server.MapPath(filepath));
                FileInfo[] files = mydir.GetFiles();
                foreach (FileInfo f in files)
                    if (f.Name == filename) f.Delete();
                // *** Deleting File physically from the Server Directory

                // --- Deleting File from the Server Database
                var res = DB.DBFiles.Where(x => x.UploadedFileName_WithExt == GridViewUploadedFiles.Rows[i].Cells[1].Text);
                // var res=from v in DB.GetTable<DBFile>() where v.FileAddressInServerDB==filepath
                foreach (var r in res) DB.DBFiles.DeleteOnSubmit(r);
                DB.SubmitChanges();
                // *** Deleting File from the Server Database
                DeletedRows++;
            }
        }
        if (TotalRows == DeletedRows)
        {
            lblDeleteFilesWarning.Text = "All your uploded file(s) are deleted from Database!";
            CheckBoxSelectAll.Visible = false;
            ButtonDeleteFile.Enabled = false;
        }
        else lblDeleteFilesWarning.Text = DeletedRows + " files(s) deleted from Server Database!";
        GetUserUploadedFilesList();
        UpdatePanelUsageInfo();
    }
    protected void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        SelectUnselectAll();
    }
    protected void btnAdminLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
    protected void Logout()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            if (DB.AdminInfos.Where(y => y.AdminName == Session["user"].ToString()).Count() == 1 ? true : false)
                RecordLastAdminLogoutDateTime();
            Session.Abandon();
            Response.Redirect("Homepage.aspx?s=1");
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void RecordLastAdminLogoutDateTime()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            var res = DB.AdminInfos.Where(x => x.AdminName == Session["user"]);
            foreach (var r in res)
            {
                r.LastLogoutDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // 'YYYY-MM-DD HH:MM:SS'            
            }
            DB.SubmitChanges();
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            string filename = UnzipFile(Server.MapPath(e.CommandArgument.ToString()));
            Response.Redirect("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/" + filename);
        }
    }
    protected void DeleteFilesFrom_TempDownloads_Directory()
    {
        string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/"));
        foreach (string f in files) System.IO.File.Delete(f);
    }
    protected String UnzipFile(String fullFileAddressInServerDB)
    {
        string zipToUnpack = fullFileAddressInServerDB;
        string unpackDirectory = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/";
        using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
            foreach (ZipEntry e in zip1)
                e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
        DirectoryInfo dir = new DirectoryInfo(MapPath("/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/"));
        FileInfo[] files = dir.GetFiles();
        return files[0].Name;
    }
}