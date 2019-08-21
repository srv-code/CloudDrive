using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// IonicZip Namespace
using Ionic.Zip;
using System.IO;
using System.Collections;
// SQL Namespaces
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class Homepage : System.Web.UI.Page
{
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    /* void Wait()
    {
        System.Threading.Thread.Sleep(500);
    }*/
    void Show_LoginLogoutOption()
    {
        try
        {
            if (Session["user"] != null)
            {
                btnLogout.Visible = true; btnLogin.Visible = false;
                btnLogout.Text = "Welcome " + Session["user"].ToString() + "!";
                ImageProPic.Visible = true;
                if (Session["user"].ToString() == "Admin")
                {
                    imgPopupUserPic.ImageUrl = "~/Images/NotificationImages/AdminPic.png"; return;
                }
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"].ToString() select v;
                var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
                foreach (var r in res)
                {
                    ImageProPic.ImageUrl = r.UserProfilePicFile;
                    if (ImageProPic.ImageUrl == "")
                    {
                        if (r.UserGender == "Male")
                            ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                        else
                            ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                    }
                }
                btnPopupVisitUserAcc.PostBackUrl = "CustomerPage.aspx";
            }
            else
            {
                btnLogout.Visible = false;
                btnLogout.Text = "";
                btnLogin.Visible = true;
                ImageProPic.Visible = false;
                ImageProPic.ImageUrl = "";
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void Login()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            bool UserLogin = DB.UserInfos.Where(x => x.Username == txtLoginUsername.Text && x.UserPwd == txtLoginPassword.Text).Count() == 1 ? true : false;
            bool AdminLogin = DB.AdminInfos.Where(y => y.AdminName == txtLoginUsername.Text && y.AdminPwd == txtLoginPassword.Text).Count() == 1 ? true : false;

            if (UserLogin == true)
            {
                lblSessionExpiredMessage.Visible = false;
                //string wnote="Login Successful: Welcome " + txtLoginUsername.Text;
                //ScriptManager.RegisterStartupScript(this, GetType(), "Login Successful!", "alert('Login Successful: Welcome User!')", true);
                // var Username = from v in DB.GetTable<UserInfo>() where v.Username == txtLoginUsername.Text select v;
                var Username = DB.UserInfos.Where(x => x.Username == txtLoginUsername.Text);
                foreach (var r in Username)
                {
                    Session["user"] = r.Username;
                    Session["showPanelUploadedFiles"] = "0";
                    Session["showPanelDeleteAccountPopup"] = "0";
                    ImageProPic.ImageUrl = r.UserProfilePicFile;
                    if (ImageProPic.ImageUrl == "")
                    {
                        if (r.UserGender == "Male")
                            ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                        else
                            ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                    }
                }
                btnLogout.Visible = true;
                btnLogout.Text = "Welcome " + Session["user"].ToString() + "!";
                btnLogin.Visible = false;
                ImageProPic.Visible = true;
                lblLoginErrorMessage.Visible = false;
            }
            else if (AdminLogin == true)
            {
                lblSessionExpiredMessage.Visible = false;

                Session["user"] = txtLoginUsername.Text.Trim();
                Session["showPanelUploadedFiles"] = "0";
                Session["showPanelDeleteAccountPopup"] = "0";
                btnLogout.Visible = true;
                btnLogout.Text = "Welcome " + Session["user"].ToString() + "!";
                btnLogin.Visible = false;
                ImageProPic.Visible = true;
                ImageProPic.ImageUrl = "~/Images/NotificationImages/AdminPic.png";
                lblLoginErrorMessage.Visible = false;
                Response.Redirect("AdminPage.aspx");
            }
            else
            {
                lblSessionExpiredMessage.Visible = false;
                //ScriptManager.RegisterStartupScript(this, GetType(), "Login Failed!", "alert('Login Failed: Wrong username and password combination. Please try again!')", true);
                lblLoginErrorMessage.Visible = true;
            }
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
    void Logout()
    {
        try
        {
            if (Session["user"].ToString() == "Admin")
                RecordLastAdminLogoutDateTime();
            Session.Abandon();
            btnLogout.Visible = false;
            btnLogout.Text = "";
            btnLogin.Visible = true;
            ImageProPic.Visible = false;
            ImageProPic.ImageUrl = "";
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void Search()
    {
        if (txtSearch.Text.Trim() == "")
        {
            PanelSearch.Visible = false;
            PanelAdrotator.Visible = true;
            //txtSearch.Text = "No term entered!";
            return;
        }
        else
        {
            PanelSearch.Visible = true;
            PanelAdrotator.Visible = false;

            //try
            {
                /* 
                 * Facilities added:
                 * Searching is not case sensitive
                 * Seaching is not leading or trailing white spaces sensitive
                */

                if (DropDownListSearchCategory.SelectedItem.Text == "Choose a category")
                {
                    lblSearchResultNo.Text = "Warning: Choose a file category first!";
                }
                else
                {
                    int SearchResNo = 0;
                    if (txtSearch.Text.Trim() != "")
                    {
                        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

                        var SearchedFiles = DB.DBFiles.Where(x => x.UploadedFileName.Contains(txtSearch.Text.Trim()) && x.Category == DropDownListSearchCategory.SelectedItem.Text && x.Mode == "General").Select(x => new { x.UploadedFileName, x.UploadedFileName_WithExt, x.Category, x.UploadedFileSize, x.UploadDateTime }).Distinct();

                        // DirectoryInfo mydir = new DirectoryInfo(@Server.MapPath("~/UploadedFiles/ServerDatabase/" + (DropDownListSearchCategory.SelectedItem.Text).Trim() + "s/"));

                        foreach (var r in SearchedFiles)
                        {
                            SearchResNo++;

                            // --- Creating label to show the searched file's info 
                            Label lbl = new Label();
                            lbl.Text = "[ Size: " + r.UploadedFileSize + " |  Upload Date and Time: " + r.UploadDateTime + " ]";
                            lbl.CssClass = "SearchlblStyle"; lbl.BorderWidth = 0;
                            // *** Creating label to show the searched file's info

                            // --- Creating hyperlink to link the file to the database address
                            LinkButton FileLink = new LinkButton();
                            FileLink.OnClientClick = "window.document.forms[0].target='_blank'";
                            FileLink.CssClass = "SearchResultsStyle"; FileLink.BorderWidth = 0;
                            FileLink.Text = Convert.ToString(r.UploadedFileName);
                            FileLink.CommandName = "ViewContent";
                            FileLink.CommandArgument = "~/UploadedFiles/ServerDatabase/" + r.Category.ToString() + "s/" + r.UploadedFileName_WithExt.ToString() + ".zip";
                            FileLink.Command += new CommandEventHandler(ViewContent);
                            // *** Creating hyperlink to link the file to the database address

                            // *** Creating download ImageButton to download the content to the clent's system
                            ImageButton imgbtnDownload = new ImageButton();
                            imgbtnDownload.ImageUrl = "~/Images/NotificationImages/download_icon_small.png";
                            //imgbtnDownload.Height = 35; imgbtnDownload.Width = 35;
                            imgbtnDownload.CommandName = "DownloadContent";
                            imgbtnDownload.CommandArgument = "~/UploadedFiles/ServerDatabase/" + r.Category.ToString() + "s/" + r.UploadedFileName_WithExt.ToString() + ".zip";
                            imgbtnDownload.Command += DownloadContent;
                            // *** Creating download ImageButton to download the content to the clent's system

                            // --- Creating Image to display the correct icon with respect to the category of the file
                            Image ImgIcon = new Image();
                            switch (DropDownListSearchCategory.SelectedItem.Text)
                            {
                                case "Image": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Image.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                                case "Video": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Video.ico"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                                case "Music": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/itunes-icon.png.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                                case "Document": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Document.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                                case "Executable": ImgIcon.ImageUrl = "~/Images/SearchResultsIcon/Executable.png"; ImgIcon.Height = 20; ImgIcon.Width = 20; break;
                            }
                            // *** Creating Image to display the correct icon with respect to the category of the file

                            // --- Attatching all Controls (Image, HyperLink, Label) to the Placeholder Control 
                            PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                            PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;"));
                            PlaceHolder1.Controls.Add(ImgIcon); PlaceHolder1.Controls.Add(new LiteralControl("&nbsp; "));
                            PlaceHolder1.Controls.Add(FileLink); PlaceHolder1.Controls.Add(new LiteralControl("&nbsp; "));
                            PlaceHolder1.Controls.Add(lbl); PlaceHolder1.Controls.Add(new LiteralControl("&nbsp; &nbsp;"));
                            PlaceHolder1.Controls.Add(imgbtnDownload);
                            // --- Attatching all Controls (Image, HyperLink, Label) to the Placeholder Control 
                        }
                    }
                    lblSearchResultNo.Text = SearchResNo.ToString() + " result(s) returned!";
                }
            }
            /* catch (Exception exc)
            {
                Response.Write("Exception inside Search(): " + exc.Message);
            } */

        }
    }
    protected void ViewContent(Object sender, CommandEventArgs e)
    {
        LinkButton lnk = sender as LinkButton;
        //Response.Redirect("SignupPage.aspx");
        string filename = UnzipFile(Server.MapPath(e.CommandArgument.ToString()));
        Response.Redirect("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/" + filename);
    }
    protected void DownloadContent(Object sender, CommandEventArgs e)
    {
        ImageButton imgbtn = sender as ImageButton;
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        string filename = UnzipFile(Server.MapPath(e.CommandArgument.ToString()));
        Response.AppendHeader("content-disposition", "attachment; filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/" + filename));
        Response.End();
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
    void LoadPanelControls()
    {
        try
        {
            lblLoggedInUsername.Text = Session["user"].ToString();
            if (Session["user"].ToString() == "Admin")
            {
                ImageProPic.ImageUrl = "~/Images/NotificationImages/AdminPic.png";
                btnPopupVisitUserAcc.PostBackUrl = "~/AdminPage.aspx";
            }
            else
            {
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"].ToString() select v;
                var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
                foreach (var r in res)
                {
                    imgPopupUserPic.ImageUrl = r.UserProfilePicFile;
                    if (ImageProPic.ImageUrl == "")
                    {
                        if (r.UserGender == "Male")
                            ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                        else
                            ImageProPic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                    }
                }
                btnPopupVisitUserAcc.PostBackUrl = "CustomerPage.aspx";
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            if (Request.QueryString["s"].ToString() == "0")
                //Response.Write("<center><h3><font face=\"Century Gothic\" color=\"red\">Your session expired! Please login again to continue.</font></h3><center>");
                lblSessionExpiredMessage.Visible = true;
            else lblSessionExpiredMessage.Visible = false;

        Show_LoginLogoutOption();
        PopupPanelUserLogin.Visible = false;
        PopupPanelUserLogout.Visible = false;
        //PanelSearch.Visible = false;
        //PanelAdrotator.Visible = true;
        DeleteFilesFrom_TempDownloads_Directory();
        Search();
    }

    protected void btnPopupLogin_Click(object sender, EventArgs e)
    {
        Login();
    }
    protected void btnPopupLogout_Click(object sender, EventArgs e)
    {
        Logout();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        PopupPanelUserLogin.Visible = true;
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        PopupPanelUserLogout.Visible = true;
        LoadPanelControls();
    }
    protected void btnSearch_Click1(object sender, ImageClickEventArgs e)
    {
        //Search();
        //PanelAdrotator.Visible = false;
        //PanelSearch.Visible = true;
    }
    protected void btnT_P_Click(object sender, EventArgs e)
    {
        Response.Redirect("Terms_and_PoliciesPage.aspx");
    }
    protected void btnContactUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("ContactUsPage.aspx");
    }
    protected void btnAboutUs_Click(object sender, EventArgs e)
    {
        Response.Redirect("AboutUsPage.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["user"] = "SouravDey";
        Session["showPanelUploadedFiles"] = "0";
        Session["showPanelDeleteAccountPopup"] = "0";
        Response.Redirect("CustomerPage.aspx");
    }
}
