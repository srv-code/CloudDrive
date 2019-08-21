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
using System.Collections;


public partial class FileSharingRequestDetailsPage : System.Web.UI.Page
{
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    int[] GetNoOfFilesSelected()
    {
        int TotalRows = GridViewSharedFilesDetails.Rows.Count;
        int SelecteddRows = 0;
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewSharedFilesDetails.Rows[i].FindControl("chkRow");
            if (chk.Checked) SelecteddRows++;
        }
        //Response.Write("SelectedRows = " + SelecteddRows + ", TotalRows = " + TotalRows);
        return (new int[] { SelecteddRows, TotalRows });
    }
    void ShowFilesSharingMessage()
    {
        int selectedFiles = GetNoOfFilesSelected()[0];
        if (selectedFiles == 0) 
        {
            lblShareFilesConfirmation.Text = "Please select atleast one file or press 'Reject File(s)' Button!";
            PanelShareFilesConfirmation.Visible = true;
            ModalPopupExtenderShareFilesConfirmation.Show();            
        }
        else
        {
            lblShareFilesConfirmation.Text = "Are you sure to add these " + selectedFiles.ToString() + " file(s) to your database?";
            PanelShareFilesConfirmation.Visible = true;
            ModalPopupExtenderShareFilesConfirmation.Show();            
        }
    }
    bool AcceptSelectedFilesForSharing()
    {
        if (GetNoOfFilesSelected()[0] == 0) return false;
        else
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            var res = DB.FileSharingRequests.Where(x => x.ID == int.Parse(Request.QueryString["FSR_ID"]));
            string RequestedUser = null, RequestingUser = null;
            foreach (var r in res)
            {
                RequestedUser = r.RequestedUser.ToString();
                RequestingUser = r.RequestingUser.ToString();
                // --- Changing Confirmed field of FileSharingRequests to "Y"
                r.Confirmed = 'Y';
                // *** Changing Confirmed field of FileSharingRequests to "Y"
            }

            //Response.Write("RequestedUser = " + RequestedUser + ", RequestingUser = " + RequestingUser);
            string[] acceptedSharedFiles = new string[100];
            int indexAcceptedSharedFiles = 0;

            int TotalRows = GridViewSharedFilesDetails.Rows.Count;
            for (int i = 0; i < TotalRows; i++)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)GridViewSharedFilesDetails.Rows[i].FindControl("chkRow");

                if ((chk.Checked) && ((DB.DBFiles.Where(x => (x.UploadedFileName_WithExt.ToString().Trim() == GridViewSharedFilesDetails.Rows[i].Cells[1].Text.Trim()) && (x.UploaderUserName.ToString().Trim() == RequestedUser.Trim()) && (x.SharedWith.ToString().Contains(RequestingUser.Trim()))).Count() > 0 ? true : false) == false))
                {
                    acceptedSharedFiles[indexAcceptedSharedFiles++] = GridViewSharedFilesDetails.Rows[i].Cells[1].Text;

                    // --- Adding selected files to the requested user's DBFiles from requesting user's DBFiles 
                    DBFile DBFileNewRecord = new DBFile();
                    var res1 = DB.DBFiles.Where(x => x.UploadedFileName_WithExt == GridViewSharedFilesDetails.Rows[i].Cells[1].Text && x.UploaderUserName == RequestingUser);
                    int NewFileNo = 0;
                    if (DB.DBFiles.Count() == 0) NewFileNo = 0;
                    else
                    {
                        var res2 = from v in DB.GetTable<DBFile>() select v.FileNo;
                        foreach (var r in res2) NewFileNo = r;
                    }
                    DBFileNewRecord.FileNo = ++NewFileNo;
                    DBFileNewRecord.UploaderUserName = RequestedUser;
                    foreach (var r in res1)
                    {
                        DBFileNewRecord.Category = r.Category;
                        DBFileNewRecord.Mode = r.Mode;
                        DBFileNewRecord.UploadedFileName = r.UploadedFileName;
                        DBFileNewRecord.UploadedFileSize = r.UploadedFileSize;
                        DBFileNewRecord.UploadDateTime = r.UploadDateTime;
                        DBFileNewRecord.UploadedFileName_WithExt = r.UploadedFileName_WithExt;

                        // --- Adding the SharedWith field to the requested user's DBFiles
                        DBFileNewRecord.SharedWith = RequestingUser + " ";
                        // *** Adding the SharedWith field to the requested user's DBFiles

                        // --- Modifying the SharedWith field of the requesting user's DBFiles
                        string sharedWithUsers_String = r.SharedWith.ToString();
                        if (sharedWithUsers_String.Trim() == "Nobody") r.SharedWith = RequestedUser + " ";
                        else
                        {
                            char[] sharedWithUsers_chars = sharedWithUsers_String.ToCharArray();
                            int usersSharedWith_index = 0; string[] usersSharedWith = new string[25];
                            foreach (char c in sharedWithUsers_chars)
                                if (c == ' ') usersSharedWith_index++;
                                else usersSharedWith[usersSharedWith_index] += c.ToString();

                            if (!usersSharedWith.Contains(RequestedUser)) r.SharedWith += RequestedUser + " ";
                        }
                        // *** Modifying the SharedWith field of the requesting user's DBFiles
                    }

                    DB.DBFiles.InsertOnSubmit(DBFileNewRecord);
                    DB.SubmitChanges();
                }
            }

            // --- Sending notification to the Requesting user

            string notification = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  " + RequestedUser + " accepted your file sharing request(s) and added " + indexAcceptedSharedFiles.ToString() + " file(s) namely";

            for (int i = 0; i < indexAcceptedSharedFiles; i++)
                if (i == (indexAcceptedSharedFiles - 1) && (indexAcceptedSharedFiles > 1))
                    notification += " and '" + acceptedSharedFiles[i] + "' ";
                else if (indexAcceptedSharedFiles == 1) notification += " '" + acceptedSharedFiles[i] + "' ";
                else notification += " '" + acceptedSharedFiles[i] + "', ";

            notification += "to his/her Database.|";

            var resAddNtf = DB.UserInfos.Where(x => x.Username == RequestingUser);
            foreach (var r in resAddNtf) r.Notifications = notification + r.Notifications.ToString();
            DB.SubmitChanges();

            // --- Sending notification to the Requesting user

            return true;
        }            
    }
    void SelectUnselectAll()
    {
        if (CheckBoxSelectAll.Checked == true)
        {
            for (int i = 0; i < GridViewSharedFilesDetails.Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)GridViewSharedFilesDetails.Rows[i].FindControl("chkRow");
                chk.Checked = true;
            }

        }
        else
        {
            for (int i = 0; i < GridViewSharedFilesDetails.Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)GridViewSharedFilesDetails.Rows[i].FindControl("chkRow");
                chk.Checked = false;
            }

        }
    }
    void ShowPageHeading()
    {
        try
        {
            if (!Page.IsPostBack)
            {
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
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
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void populateGridView()
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = DB.FileSharingRequests.Where(x => x.ID == int.Parse(Request.QueryString["FSR_ID"]));
        string RequestedUser = "", RequestingUser = "", FileNames_WithExt_Fetched = "";
        foreach (var r in res)
        {
            FileNames_WithExt_Fetched = r.FileNames_WithExt.ToString();
            RequestedUser = r.RequestedUser.ToString();
            RequestingUser = r.RequestingUser.ToString();
        }

        int indexFileNames_WithExt = 0;
        char[] charFileNames_WithExt = FileNames_WithExt_Fetched.ToCharArray();
        foreach (char ch in charFileNames_WithExt) if (ch == '|') indexFileNames_WithExt++;
        string[] FileNames_WithExt_Filtered = new string[indexFileNames_WithExt];
        indexFileNames_WithExt = 0;
        foreach (char ch in charFileNames_WithExt)
            if (ch == '|') indexFileNames_WithExt++;
            else FileNames_WithExt_Filtered[indexFileNames_WithExt] += ch.ToString();

        string sqlQuery = "select UploadedFileName_WithExt \" Original Filename \", UploadedFileSize \" Size \", Category \" Category \", Mode \" Upload Mode \", UploadDateTime \" Upload Date\\Time \" from DBFiles where UploaderUserName='" + RequestingUser + "' and (UploadedFileName_WithExt=";
        for (int i = 0; i < indexFileNames_WithExt; i++)
            if (i == 0) sqlQuery += "'" + FileNames_WithExt_Filtered[i] + "'";
            else sqlQuery += " or UploadedFileName_WithExt='" + FileNames_WithExt_Filtered[i] + "'";
        sqlQuery += ")";

        //Response.Write("sqlQuery = " + sqlQuery);
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand(sqlQuery, con);
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewSharedFilesDetails.DataSource = reader;
        GridViewSharedFilesDetails.DataBind();
        con.Close();
        int totalFilesNo;
        for (totalFilesNo = 0; totalFilesNo < GridViewSharedFilesDetails.Rows.Count; totalFilesNo++)
        {
            LinkButton linkDownload = new LinkButton();
            LinkButton linkView = new LinkButton();

            string fullFileAddressInServerDB = "~/UploadedFiles/ServerDatabase/" + GridViewSharedFilesDetails.Rows[totalFilesNo].Cells[3].Text + "s/" + GridViewSharedFilesDetails.Rows[totalFilesNo].Cells[1].Text + ".zip";

            linkDownload = (LinkButton)GridViewSharedFilesDetails.Rows[totalFilesNo].FindControl("lnkbtnDownloadContent");
            linkView = (LinkButton)GridViewSharedFilesDetails.Rows[totalFilesNo].FindControl("lnkbtnViewContent");

            linkDownload.CommandArgument = fullFileAddressInServerDB;
            linkView.CommandArgument = fullFileAddressInServerDB;
        }
        lblFileSharedMessage.Text = "You have received " + totalFilesNo.ToString() + " file sharing request(s) from " + RequestingUser; 
    }
    void CheckForRequestConfirmaion()
    {
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = DB.FileSharingRequests.Where(x => x.ID == int.Parse(Request.QueryString["FSR_ID"]));
        foreach(var r in res)
            if (r.Confirmed == 'N')
            {
                GridViewSharedFilesDetails.Enabled = true;
                CheckBoxSelectAll.Enabled = true;
                btnAddFiles.Enabled = true;
                btnRejectFiles.Enabled = true;
            }
            else
            {
                //lblFileSharedMessage.ForeColor = System.Drawing.Color.Red;
                lblFileSharedMessage.Text += " (Already Confirmed)";
                GridViewSharedFilesDetails.Enabled = false;
                CheckBoxSelectAll.Enabled = false;
                btnAddFiles.Enabled = false;
                btnRejectFiles.Enabled = false;
            }
    }
    void checkForValidFSR_ID()
    {
        try
        {
            // Checking if the FSR_ID is having the Session["user"] value equal to the RequestedUser value in the  FileSharingRequests table
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            if (!(DB.FileSharingRequests.Where(x => (x.ID.ToString() == Request.QueryString["FSR_ID"]) && (x.RequestedUser == Session["user"].ToString())).Count() > 0 ? true : false)) Response.Redirect("NotificationsPage.aspx");
        }
        catch (Exception exc) { Response.Redirect("NotificationsPage.aspx"); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        checkForValidFSR_ID();
        ShowPageHeading();
        if(!Page.IsPostBack) populateGridView();
        CheckForRequestConfirmaion();
    }
    protected void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        SelectUnselectAll();
    }
    protected void btnAddFiles_Click(object sender, EventArgs e)
    {
        ShowFilesSharingMessage();
    }
    protected void btnShareYes_Click(object sender, EventArgs e)
    {
        try
        {
            if (AcceptSelectedFilesForSharing())
                Response.Redirect("NotificationsPage.aspx");
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void btnShareNo_Click(object sender, EventArgs e)
    {
        PanelShareFilesConfirmation.Visible = false;
        ModalPopupExtenderShareFilesConfirmation.Hide();
    }
    protected void btnRejectFiles_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerPage.aspx");
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {
        Response.Write("GetNoOfFilesSelected()[0] = " + GetNoOfFilesSelected()[0].ToString());
    }
    protected void linkGoBackToCustomerPage_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerPage.aspx");
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void GridViewSharedFilesDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            string filename = UnzipFile(Server.MapPath(e.CommandArgument.ToString()));
            Response.AppendHeader("content-disposition", "attachment; filename=" + filename);
            Response.TransmitFile(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/" + filename));
            Response.End();
        }
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