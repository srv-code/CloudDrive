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

public partial class CustomerPage : System.Web.UI.Page
{
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    int[] GetNoOfFilesSelected()
    {
        int TotalRows = GridViewUploadedFiles.Rows.Count;
        int SelectedRows = 0;
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
            if (chk.Checked) SelectedRows++;
        }
        return (new int[] { SelectedRows, TotalRows });
    }
    void ShowDeleteFilesMessage()
    {
        int[] resultReturned = GetNoOfFilesSelected();
        int rowsSelected = resultReturned[0], totalRows = resultReturned[1];
        //Test
        //Response.Write("rowsSelected = " + rowsSelected);
        //Test

        if (rowsSelected > 0) lblDeleteFilesConfirmation.Text = "Sure to delete " + rowsSelected.ToString() + " file(s) out of " + totalRows.ToString() + " file(s) permanently?";
        else
        {
            //lblSharingFilesConfirmationMessage.ForeColor = System.Drawing.Color.Red;
            //imgSharingFilesConfirmationIcon.ImageUrl = "~/Images/NotificationImages/cross.png";
            lblDeleteFilesConfirmation.Text = "Please select atleast any one of your uploaded file!";
        }
    }
    void MakeOtherControlsInvisible()
    {
        PanelUploadFile.Visible = false;
        PanelUploadedFiles.Visible = false;
        PanelChangePassword.Visible = false;
        PanelChangeProfilePicture.Visible = false;
    }
    void RefreshUserUploadedFilesList()
    {
        MakeOtherControlsInvisible();
        PanelUploadedFiles.Visible = true;

        GetUserUploadedFilesList();
    }
    void GetUserUploadedFilesList()
    {
        try
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select  UploadedFileName_WithExt \"Original filename\", UploadedFileSize \" Size \", Category \" Category \", Mode \" Upload Mode \", UploadDateTime \" Upload Date\\Time \",SharedWith \"Shared With\" from DBFiles where UploaderUserName=@UserName", con);
            cmd.Parameters.AddWithValue("@UserName", Session["user"]);
            SqlDataReader reader = cmd.ExecuteReader();
            GridViewUploadedFiles.DataSource = reader;
            GridViewUploadedFiles.DataBind();
            con.Close();
            int totalFilesNo;
            for (totalFilesNo = 0; totalFilesNo < GridViewUploadedFiles.Rows.Count; totalFilesNo++)
            {
                LinkButton linkDownload = new LinkButton();
                LinkButton linkView = new LinkButton();

                string fullFileAddressInServerDB = "";
                if (GridViewUploadedFiles.Rows[totalFilesNo].Cells[3].Text == "N/A")
                    fullFileAddressInServerDB = "~/UploadedFiles/ServerDatabase/SecureUploads/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[1].Text + ".zip";
                else
                    fullFileAddressInServerDB = "~/UploadedFiles/ServerDatabase/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[3].Text + "s/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[1].Text + ".zip";

                linkDownload = (LinkButton)GridViewUploadedFiles.Rows[totalFilesNo].FindControl("lnkbtnDownloadContent");
                linkView = (LinkButton)GridViewUploadedFiles.Rows[totalFilesNo].FindControl("lnkbtnViewContent");

                linkDownload.CommandArgument = fullFileAddressInServerDB;
                linkView.CommandArgument = fullFileAddressInServerDB;
            }
            lblFileDeletion.Text = "You have uploded " + totalFilesNo.ToString() + " file(s) currently in the Database";

            // Check for GridView rows number
            if (GridViewUploadedFiles.Rows.Count == 0)
            {
                CheckBoxSelectAll.Visible = false;
                ButtonDeleteFile.Enabled = false;
                ButtonShareWith.Enabled = false;
            }
            else
            {
                CheckBoxSelectAll.Visible = true;
                ButtonDeleteFile.Enabled = true;
                ButtonShareWith.Enabled = true;
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void DeleteSelectedRows()
    {
        string fullFileAddressInServer = null;
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        
        int TotalRows = GridViewUploadedFiles.Rows.Count;
        int DeletedRows = 0;
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
            if (chk.Checked)
            {
                if (GridViewUploadedFiles.Rows[i].Cells[4].Text == "Secure")
                    fullFileAddressInServer = Server.MapPath("~/UploadedFiles/ServerDatabase/SecureUploads/") + GridViewUploadedFiles.Rows[i].Cells[1].Text + ".zip";
                else fullFileAddressInServer = Server.MapPath("~/UploadedFiles/ServerDatabase/" + GridViewUploadedFiles.Rows[i].Cells[3].Text + "s/") + GridViewUploadedFiles.Rows[i].Cells[1].Text + ".zip";
                
                // --- Deleting File physically from the Server Directory
                File.Delete(fullFileAddressInServer);
                /* if (File.Exists(fullFileAddressInServer)) Response.Write("Error deleting file phsically from Server! fullFileAddressInServer = " + fullFileAddressInServer);
                else Response.Write("File phsically deleted from Server. fullFileAddressInServer = " + fullFileAddressInServer);
                 * */
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
            lblFileDeletion.Text = "All your uploded file(s) are deleted from Database!";
            CheckBoxSelectAll.Visible = false;
            ButtonDeleteFile.Enabled = false;
        }
        RefreshUserUploadedFilesList();
    }
    void DeleteUserAccount()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

            // Deleting user profile picture from ServerDatabase (~/UploadedFiles/UserProfilePictures/) physically
            var resProPic = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"].ToString() select v.UserProfilePicFile;
            string profilePicAddressInServer = "";
            foreach (var r in resProPic) profilePicAddressInServer = Server.MapPath(r.ToString());

            if (!File.Exists(profilePicAddressInServer))
            {
                Response.Write("Profile Picture not found in Server! Picture address = " + profilePicAddressInServer);
                ModalPopupExtenderDeleteAccount.Hide();
                return;
            }
            else File.Delete(profilePicAddressInServer);

            var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
            foreach (var r in res)
            {
                DB.UserInfos.DeleteOnSubmit(r);
            }
            DB.SubmitChanges();

            Session.Abandon();
            Response.Redirect("Homepage.aspx?s=1");
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
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
    void UploadFile()
    {
        try
        {
            DropDownListSearchCategory.Enabled = true;
            if (FileUpload1.HasFile)
            {
               FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                
               // Checking for requested file to be uploaded is already present in the user's upload list
               if ((DropDownListSearchCategory.SelectedItem.Text != "Choose a category") && (DropDownListUploadMode.SelectedItem.Text != "Choose an upload mode") && (DB.DBFiles.Where(x => x.UploaderUserName.ToString().Trim() == Session["user"].ToString().Trim() && x.Category.ToString().Trim() == DropDownListSearchCategory.SelectedItem.Text.Trim() && x.UploadedFileName_WithExt.ToString().Trim() == Path.GetFileName(FileUpload1.FileName).ToString().Trim() && x.UploadedFileSize.ToString().Trim() == convertToProperFormat(Convert.ToDouble(FileUpload1.PostedFile.ContentLength)).ToString().Trim()).Count() > 0 ? true : false))
               {
			       lblUploadStatus.Text = "Upload Status: Error: Requested file already exists in your upload list! Cannot upload duplicate file!";
                   return;
               }
               
                // Checking if uploading file do not cross maximum single file upload size limit ie 10MB
                if (FileUpload1.PostedFile.ContentLength > (10 * 1024 * 1024)) // Max 10MB for single file upload
                {
                    //Response.Write("File size > 10MB!");
                    lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                    return;
                }

                // Checking if uploading file do not cross maximum permitted upload space ie 10MB
                var resSize = from v in DB.GetTable<DBFile>() where v.UploaderUserName == Session["user"].ToString() select v.UploadedFileSize;
                double totalUploadedSize = 0;
                string fileSizeInString;
                foreach (var r in resSize)
                {
                    fileSizeInString = r.ToString();
                    string pt1 = fileSizeInString.Substring(0, (fileSizeInString.Length - 2));
                    string pt2 = fileSizeInString.Substring((fileSizeInString.Length - 2), 2);
                    if (pt2 == "KB") totalUploadedSize += (1024 * Convert.ToDouble(pt1));
                    else if (pt2 == "MB") totalUploadedSize += (1024 * 1024 * Convert.ToDouble(pt1));
                    else totalUploadedSize += Convert.ToDouble(pt1);
                }

                //Response.Write("You have consumed " + convertToProperFormat(totalUploadedSize) + " space in DB");


                double combinedUploadSize = (totalUploadedSize + Convert.ToDouble(FileUpload1.PostedFile.ContentLength));
                if (combinedUploadSize > (double)(10.0 * 1024.0 * 1024.0)) // Max 10 MB upload space provided
                {
                    double freeExtraSpace = (combinedUploadSize - (10.0 * 1024.0 * 1024.0));

                    lblUploadStatus.Text = "This upload will exceed the maximum space provided to you for upload. You need to free  " + convertToProperFormat(freeExtraSpace) + " of space to make this upload possible!";
                    return;
                }
            }
            if (DropDownListUploadMode.SelectedItem.Text == "General Mode")
            {
                if (FileUpload1.HasFile)
                {
                   // Creating new record in DBFiles table for the uploading file
                    FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                    int NewFileNo = 0;
                    if (DB.DBFiles.Count() == 0) NewFileNo = 0;
                    else
                    {
                        var res = from v in DB.GetTable<DBFile>() select v.FileNo;
                        foreach (var r in res) NewFileNo = r;
                    }
                    DBFile record = new DBFile();
                    record.FileNo = NewFileNo + 1;
                    record.UploaderUserName = Session["user"].ToString();
                    record.Mode = "General";
                    record.SharedWith = "Nobody";
                    DateTime now = DateTime.Now;
                    record.UploadDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // 'YYYY-MM-DD HH:MM:SS'
                    record.Category = DropDownListSearchCategory.SelectedItem.Text;
                    record.UploadedFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);

                    string filenameWithExt = Path.GetFileName(FileUpload1.FileName);
                    record.UploadedFileName_WithExt = filenameWithExt;
                    record.UploadedFileSize = convertToProperFormat(Convert.ToDouble(FileUpload1.PostedFile.ContentLength));

                    switch (DropDownListSearchCategory.SelectedItem.Text)
                    {
                        case "Choose a category":
                            {
                                lblUploadStatus.Text = ("Upload Status: Error: Choose a category first!"); break;
                            }
                        case "Image":
                            {
                                //Response.Write("Image"); 
                                if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/png" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/gif" || FileUpload1.PostedFile.ContentType == "image/x-icon")
                                {
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // Adding new notification to the user uploading file
                                        FunZoneDatabaseDataContext DB2 = new FunZoneDatabaseDataContext();
                                        var res2 = DB.UserInfos.Where(x => x.Username == Session["user"]);
                                        foreach (var r in res2) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You uploaded a file named '" + Path.GetFileName(FileUpload1.FileName) + "' of " + DropDownListSearchCategory.SelectedItem.Text + " category in GeneralMode.|" + r.Notifications.ToString();
                                        DB2.SubmitChanges();

                                        FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/" + filenameWithExt));

                                        // zipping the file and saving it to the appropriate directory of the ServerDatabase
                                        using (var zip = new ZipFile())
                                        {
                                            string fullFileAddress = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/Images/" + filenameWithExt + ".zip";
                                            zip.AddDirectory(Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempUploads/");
                                            zip.Save(fullFileAddress);
                                            string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/"));
                                            foreach (string f in files) System.IO.File.Delete(f);
                                        }
                                        
                                        lblUploadStatus.Text = "Upload Status: File '" + filenameWithExt + "' uploaded successfully!";
                                        DB.DBFiles.InsertOnSubmit(record);
                                        DB.SubmitChanges();
                                        DropDownListSearchCategory.ClearSelection();
                                        DropDownListUploadMode.ClearSelection();
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";                                        
                                    }
                                    else
                                    {
                                        lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                                    }
                                }
                                else
                                {
                                    lblUploadStatus.Text = "Upload Status: Error: Only " + DropDownListSearchCategory.SelectedItem.Text + " file(*.jpg, *.jpeg, *.png, *.gif, *.ico) can be uploaded!";
                                }
                                break;
                            }
                        case "Video":
                            {
                                //Response.Write("Video"); 
                                if (FileUpload1.PostedFile.ContentType == "video/mp4" || FileUpload1.PostedFile.ContentType == "video/3gpp")
                                {
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // Adding new notification to the user uploading file
                                        FunZoneDatabaseDataContext DB2 = new FunZoneDatabaseDataContext();
                                        var res2 = DB.UserInfos.Where(x => x.Username == Session["user"]);
                                        foreach (var r in res2) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You uploaded a file named '" + Path.GetFileName(FileUpload1.FileName) + "' of " + DropDownListSearchCategory.SelectedItem.Text + " category in GeneralMode.|" + r.Notifications.ToString();
                                        DB2.SubmitChanges();

                                        FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/" + filenameWithExt));


                                        // zipping the file and saving it to the appropriate directory of the ServerDatabase
                                        using (var zip = new ZipFile())
                                        {
                                            string fullFileAddress = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/Videos/" + filenameWithExt + ".zip";
                                            zip.AddDirectory(Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempUploads/");
                                            zip.Save(fullFileAddress);
                                            string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/"));
                                            foreach (string f in files) System.IO.File.Delete(f);
                                        }

                                        lblUploadStatus.Text = "Upload Status: File '" + filenameWithExt + "' uploaded successfully!";
                                        DB.DBFiles.InsertOnSubmit(record);
                                        DB.SubmitChanges();
                                        DropDownListSearchCategory.ClearSelection();
                                        DropDownListUploadMode.ClearSelection();
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";
                                    }
                                    else
                                    {
                                        lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                                    }
                                }
                                else
                                {
                                    lblUploadStatus.Text = "Upload Status: Error: Only " + DropDownListSearchCategory.SelectedItem.Text + " file(*.mp4, *.3gp) can be uploaded!";
                                }
                                break;
                            }
                        case "Music":
                            {
                                //Response.Write("Music"); 
                                if (FileUpload1.PostedFile.ContentType == "audio/mpeg" || FileUpload1.PostedFile.ContentType == "audio/wav" || FileUpload1.PostedFile.ContentType == "audio/wave" || FileUpload1.PostedFile.ContentType == "audio/x-wav" || FileUpload1.PostedFile.ContentType == "audio/vnd.wave" || FileUpload1.PostedFile.ContentType == "audio/mpeg3" || FileUpload1.PostedFile.ContentType == "audio/x-mpeg3" || FileUpload1.PostedFile.ContentType == "audio/mp3" || FileUpload1.PostedFile.ContentType == "audio/mpg" || FileUpload1.PostedFile.ContentType == "audio/x-mpegaudio")
                                {
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // Adding new notification to the user uploading file
                                        FunZoneDatabaseDataContext DB2 = new FunZoneDatabaseDataContext();
                                        var res2 = DB.UserInfos.Where(x => x.Username == Session["user"]);
                                        foreach (var r in res2) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You uploaded a file named '" + Path.GetFileName(FileUpload1.FileName) + "' of " + DropDownListSearchCategory.SelectedItem.Text + " category in GeneralMode.|" + r.Notifications.ToString();
                                        DB2.SubmitChanges();

                                        FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/" + filenameWithExt));

                                        // zipping the file and saving it to the appropriate directory of the ServerDatabase
                                        using (var zip = new ZipFile())
                                        {
                                            string fullFileAddress = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/Musics/" + filenameWithExt + ".zip";
                                            zip.AddDirectory(Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempUploads/");
                                            zip.Save(fullFileAddress);
                                            string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/"));
                                            foreach (string f in files) System.IO.File.Delete(f);
                                        }

                                        lblUploadStatus.Text = "Upload Status: File '" + filenameWithExt + "' uploaded successfully!";
                                        DB.DBFiles.InsertOnSubmit(record);
                                        DB.SubmitChanges();
                                        DropDownListSearchCategory.ClearSelection();
                                        DropDownListUploadMode.ClearSelection();
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";
                                    }
                                    else
                                    {
                                        lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                                    }
                                }
                                else
                                {
                                    lblUploadStatus.Text = "Upload Status: Error: Only " + DropDownListSearchCategory.SelectedItem.Text + " file(*.mp3, *.wav) can be uploaded!";
                                }
                                break;
                            }
                        case "Document":
                            {
                                //Response.Write("Document"); 
                                if (FileUpload1.PostedFile.ContentType == "application/pdf" || FileUpload1.PostedFile.ContentType == "text/plain" || FileUpload1.PostedFile.ContentType == "application/msword" || FileUpload1.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                                {
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // Adding new notification to the user uploading file
                                        FunZoneDatabaseDataContext DB2 = new FunZoneDatabaseDataContext();
                                        var res2 = DB.UserInfos.Where(x => x.Username == Session["user"]);
                                        foreach (var r in res2) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You uploaded a file named '" + Path.GetFileName(FileUpload1.FileName) + "' of " + DropDownListSearchCategory.SelectedItem.Text + " category in GeneralMode.|" + r.Notifications.ToString();
                                        DB2.SubmitChanges();

                                        FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/" + filenameWithExt));

                                        // zipping the file and saving it to the appropriate directory of the ServerDatabase
                                        using (var zip = new ZipFile())
                                        {
                                            string fullFileAddress = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/Documents/" + filenameWithExt + ".zip";
                                            zip.AddDirectory(Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempUploads/");
                                            zip.Save(fullFileAddress);
                                            string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/"));
                                            foreach (string f in files) System.IO.File.Delete(f);
                                        }

                                        lblUploadStatus.Text = "Upload Status: File '" + filenameWithExt + "' uploaded successfully!";
                                        DB.DBFiles.InsertOnSubmit(record);
                                        DB.SubmitChanges();
                                        DropDownListSearchCategory.ClearSelection();
                                        DropDownListUploadMode.ClearSelection();
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";
                                    }
                                    else
                                    {
                                        lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                                    }
                                }
                                else
                                {
                                    lblUploadStatus.Text = "Upload Status: Error: Only " + DropDownListSearchCategory.SelectedItem.Text + " file(*.pdf, *.txt, *.doc, *.docx) can be uploaded!";
                                }
                                break;
                            }
                        case "Executable":
                            {
                                //Response.Write("Executable"); 
                                if (FileUpload1.PostedFile.ContentType == "application/exe" || FileUpload1.PostedFile.ContentType == "application/x-msdownload" || FileUpload1.PostedFile.ContentType == "application/dos-exe" || FileUpload1.PostedFile.ContentType == "application/x-exe" || FileUpload1.PostedFile.ContentType == "application/x-winexe" || FileUpload1.PostedFile.ContentType == "application/msdos-windows")
                                {
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // Adding new notification to the user uploading file
                                        FunZoneDatabaseDataContext DB2 = new FunZoneDatabaseDataContext();
                                        var res2 = DB.UserInfos.Where(x => x.Username == Session["user"]);
                                        foreach (var r in res2) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You uploaded a file named '" + Path.GetFileName(FileUpload1.FileName) + "' of " + DropDownListSearchCategory.SelectedItem.Text + " category in GeneralMode.|" + r.Notifications.ToString();
                                        DB2.SubmitChanges();

                                        FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/" + filenameWithExt));

                                        // zipping the file and saving it to the appropriate directory of the ServerDatabase
                                        using (var zip = new ZipFile())
                                        {
                                            string fullFileAddress = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/Executables/" + filenameWithExt + ".zip";
                                            zip.AddDirectory(Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempUploads/");
                                            zip.Save(fullFileAddress);
                                            string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/"));
                                            foreach (string f in files) System.IO.File.Delete(f);
                                        }

                                        lblUploadStatus.Text = "Upload Status: File '" + filenameWithExt + "' uploaded successfully!";
                                        DB.DBFiles.InsertOnSubmit(record);
                                        DB.SubmitChanges();
                                        DropDownListSearchCategory.ClearSelection();
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";
                                    }
                                    else
                                    {
                                        lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                                    }
                                }
                                else
                                {
                                    lblUploadStatus.Text = "Upload Status: Error: Only " + DropDownListSearchCategory.SelectedItem.Text + " file(*.exe) can be uploaded!";
                                }
                                break;
                            }
                        default:
                            {
                                Response.Write("Error: Category not recognised!"); break;
                            }
                    }
                    
                    /*if (FileUpload1.PostedFile.ContentType == "image/jpeg")
                    {*/

                    /*}
                    else
                    {
                        lblUploadStatus.Text = "Upload Status: Error: Only picture file (*.jpg, *.jpeg) can be uploaded!";
                        //Image1.ImageUrl = "~\\ImageControl Icons\\Error.ico";
                    }*/
                }
                else
                {
                    lblUploadStatus.Text = "Upload Status: Error: Please choose a file to upload!";
                    //Image1.ImageUrl = "~\\ImageControl Icons\\Error.ico";
                }
            }
            else 
            if (DropDownListUploadMode.SelectedItem.Text == "Secure Archive Mode")
            {
                /*
                record.Mode = "Secure";
                 */
                DropDownListSearchCategory.Enabled = true;
                if (FileUpload1.HasFile)
                {
                    FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                    int NewFileNo = 0;
                    if (DB.DBFiles.Count() == 0)
                    {
                        NewFileNo = 0;
                    }
                    else
                    {
                        var res = from v in DB.GetTable<DBFile>() select v.FileNo;
                        foreach (var r in res)
                            NewFileNo = r;
                    }
                    DBFile record1 = new DBFile();
                    record1.FileNo = NewFileNo+1;

                    string filenameWithExt = Path.GetFileName(FileUpload1.FileName);
                    record1.UploadedFileName_WithExt = filenameWithExt;

                    record1.UploaderUserName = Session["user"].ToString();
                    record1.Mode = "Secure";
                    record1.Category = "N/A";
                    DateTime now = DateTime.Now;
                    record1.SharedWith = "Nobody";
                    record1.UploadDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // 'YYYY-MM-DD HH:MM:SS'
                    record1.UploadedFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);

                    if (Convert.ToInt32(FileUpload1.PostedFile.ContentLength) < 1024)
                        record1.UploadedFileSize = Convert.ToString(FileUpload1.PostedFile.ContentLength) + "B";
                    else if (Convert.ToInt32(FileUpload1.PostedFile.ContentLength) >= 1024 && Convert.ToInt32(FileUpload1.PostedFile.ContentLength) <= (1024 * 1024))
                        record1.UploadedFileSize = Convert.ToString(((double)FileUpload1.PostedFile.ContentLength / (double)(1024)).ToString("0.00")) + "KB";
                    else
                        record1.UploadedFileSize = Convert.ToString(((double)FileUpload1.PostedFile.ContentLength / (double)(1024 * 1024)).ToString("0.00")) + "MB";

                                record1.UploadDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // 'YYYY-MM-DD HH:MM:SS'
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // Adding new notification to the user uploading file
                                        FunZoneDatabaseDataContext DB2 = new FunZoneDatabaseDataContext();
                                        var res2 = DB.UserInfos.Where(x => x.Username == Session["user"]);
                                        foreach (var r in res2) r.Notifications = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You uploaded a file named '" + Path.GetFileName(FileUpload1.FileName) + "' in Secure Archive Mode.|" + r.Notifications.ToString();
                                        DB2.SubmitChanges();

                                        FileUpload1.SaveAs(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/" + filenameWithExt));

                                        // zipping the file and saving it to the appropriate directory of the ServerDatabase
                                        using (var zip = new ZipFile())
                                        {
                                            string fullFileAddress = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/SecureUploads/" + filenameWithExt + ".zip";
                                            zip.AddDirectory(Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempUploads/");
                                            zip.Save(fullFileAddress);
                                            string[] files = System.IO.Directory.GetFiles(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempUploads/"));
                                            foreach (string f in files) System.IO.File.Delete(f);
                                        }

                                        lblUploadStatus.Text = "Upload Status: File '" + filenameWithExt + "' uploaded successfully!";
                                        DB.DBFiles.InsertOnSubmit(record1);
                                        DB.SubmitChanges();
                                        DropDownListSearchCategory.ClearSelection();
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";
                                    }
                                    else
                                    {
                                        lblUploadStatus.Text = "Upload Status: Error: File size should be less than 10MB!";
                                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                                    }
                                
                }
                DropDownListSearchCategory.Enabled = true;                
            }
            else if (DropDownListUploadMode.SelectedItem.Text == "Choose an upload mode")
            {
                lblUploadStatus.Text = "Upload Status: Error: Please choose an upload mode first!";
            }

        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
        catch (Exception exc)
        {
            Response.Write("Exc inside UploadFile(): " + exc.Message);
        }

    }
    void WelcomeMsg()
    {
        try
        {
            string CustUsername = Session["user"].ToString();
            Label1.Text = "CloudDrive: Welcome ";
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            // var res = from v in DB.GetTable<UserInfo>() where v.Username == CustUsername select v;
            var res = DB.UserInfos.Where(x => x.Username == CustUsername);
            foreach (var r in res)
            {
                if (r.UserGender == "Male")
                {
                    Label1.Text = Label1.Text + "Mr. ";
                }
                else
                {
                    if (r.UserMartialStatus == "n")
                    {
                        Label1.Text = Label1.Text + "Miss ";
                    }
                    else
                    {
                        Label1.Text = Label1.Text + "Mrs. ";
                    }
                }
                Label1.Text = Label1.Text + r.UserFirstName + " " + r.UserLastName + " to your account";
            }
        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void SetProfilePic()
    {
        try
        {
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"].ToString() select v;
            var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
            foreach (var r in res)
            {
                ImageProfilePic.ImageUrl = r.UserProfilePicFile;
                if (ImageProfilePic.ImageUrl == "")
                {
                    if (r.UserGender == "Male")
                        ImageProfilePic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                    else
                        ImageProfilePic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                }
                else
                    ImageProfilePic.ImageUrl = r.UserProfilePicFile;
            }

            if (ImageProfilePic.ImageUrl == "")
                ImageProfilePic.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePic.png";
        }
        catch (Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
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
    void UpdatePanelUsageInfo()
    {
        try
        {
            //*****************************************************************
            lblUsed.Text = ""; lblUnused.Text = "";

            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            var res = from v in DB.GetTable<DBFile>() where v.UploaderUserName == Session["user"].ToString() select v.UploadedFileSize;
            double totalUploadSize = 0;
            string fileSizeInString;
            foreach (var r in res)
            {
                fileSizeInString = r.ToString();
                string pt1 = fileSizeInString.Substring(0, (fileSizeInString.Length - 2));
                string pt2 = fileSizeInString.Substring((fileSizeInString.Length - 2), 2);
                if (pt2 == "KB") totalUploadSize += (1024 * Convert.ToDouble(pt1));
                else if (pt2 == "MB") totalUploadSize += (1024 * 1024 * Convert.ToDouble(pt1));
                else totalUploadSize += Convert.ToDouble(pt1);
            }

            // Total File Upload Limit Set : 10 MB
            float uploadPercentage = ((float)totalUploadSize / (float)(10 * 1024 * 1024)) * 100;

            lblUsed.Width = (int)uploadPercentage * 10;
            if (uploadPercentage >= 20.00) lblUsed.Text = uploadPercentage.ToString("0.00") + "% (" + convertToProperFormat(totalUploadSize) + "/10MB)";
            else
            {
                lblUnused.Width = 500;
                lblUnused.Text = uploadPercentage.ToString("0.00") + "% (" + convertToProperFormat(totalUploadSize) + "/10MB)";
                lblUsed.Text = " ";
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void ChangePassword()
    {
        try
        {
            if (txtNewPassword2.Text.Trim() == "" || txtNewPassword1.Text.Trim() == "")
                lblChangePasswordWarning.Text = "You cannot leave the new password field blank!";
            else if ((txtNewPassword2.Text.Trim()).Length < 5)
                lblChangePasswordWarning.Text = "Password should be atleast 5 characters wide!";
            else if (txtNewPassword1.Text.Trim() != txtNewPassword2.Text.Trim())
                lblChangePasswordWarning.Text = "New passwords do not matched try again!";
            else
            {
                FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"] select v;
                var res = DB.UserInfos.Where(x => x.Username == Session["user"]);
                string CurrentPwd = null;
                foreach (var r in res)
                {
                    CurrentPwd = r.UserPwd;
                }
                if (txtCurrentPassword.Text == CurrentPwd)
                {
                    foreach (var r in res)
                        r.UserPwd = txtNewPassword2.Text;
                    DB.SubmitChanges();
                    lblChangePasswordWarning.Text = "Password Changed successfully!";
                }
                else
                {
                    lblChangePasswordWarning.Text = "Your entered current password did not matched with the actual one! Please try again!";
                }
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void RemoveProfilePicture()
    {
        try
        {
            string OldProfilePic = null;
            string NewProfilePic = null;
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"] select v;
            var res = DB.UserInfos.Where(x => x.Username == Session["user"]);
            foreach (var r in res)
            {
                OldProfilePic = r.UserProfilePicFile;
                if (r.UserGender == "Male")
                {
                    NewProfilePic = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                    r.UserProfilePicFile = NewProfilePic;
                }
                else
                {
                    NewProfilePic = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                    r.UserProfilePicFile = NewProfilePic;
                }
            }
            DB.SubmitChanges();
            ImageProfilePic.ImageUrl = NewProfilePic;
            if (OldProfilePic != "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png" && OldProfilePic != "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png")
            {
                string filepath = "~/UploadedFiles/UserProfilePictures/";
                //Response.Write("OldProfilePic: " + OldProfilePic + "   && filepath: " + filepath + "   &&  filepath.Length:" + filepath.Length + "   &&   OldProfilePic.Length:" + OldProfilePic.Length);
                string filename = OldProfilePic.Remove(0, filepath.Length);
                //Response.Write("filename: " + filename + "   &   filepath: " + filepath + "    &     OldProfilePic: " + OldProfilePic);

                DirectoryInfo mydir = new DirectoryInfo(@Server.MapPath(filepath));
                FileInfo[] f = mydir.GetFiles();
                foreach (FileInfo file in f)
                {
                    if (file.Name == filename)
                    {
                        //Response.Write("File '" + file.Name + "' deleted successfully!");
                        file.Delete();
                    }
                }
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void ChangeProfilePicture()
    {
        try
        {
            if (FileUploadChangeProfilePicture.HasFile)
            {
                if (FileUploadChangeProfilePicture.PostedFile.ContentType == "image/jpeg" || FileUploadChangeProfilePicture.PostedFile.ContentType == "image/png" || FileUploadChangeProfilePicture.PostedFile.ContentType == "image/jpg" || FileUploadChangeProfilePicture.PostedFile.ContentType == "image/gif" || FileUploadChangeProfilePicture.PostedFile.ContentType == "image/x-icon")
                {
                    if (FileUploadChangeProfilePicture.PostedFile.ContentLength < 10485760)
                    {
                        string OldProfilePic = null;
                        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
                        // var res = from v in DB.GetTable<UserInfo>() where v.Username == Session["user"] select v;
                        var res = DB.UserInfos.Where(x => x.Username == Session["user"]);
                        foreach (var r in res)
                        {
                            OldProfilePic = r.UserProfilePicFile;
                            r.UserProfilePicFile = "~/UploadedFiles/UserProfilePictures/" + FileUploadChangeProfilePicture.PostedFile.FileName;
                        }
                        DB.SubmitChanges();
                        if (OldProfilePic != "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png" && OldProfilePic != "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png")
                        {
                            string filepath = "~/UploadedFiles/UserProfilePictures/";
                            //Response.Write("OldProfilePic: " + OldProfilePic + "   && filepath: " + filepath + "   &&  filepath.Length:" + filepath.Length + "   &&   OldProfilePic.Length:" + OldProfilePic.Length);
                            string filename = OldProfilePic.Remove(0, filepath.Length);
                            //Response.Write("filename: " + filename + "   &   filepath: " + filepath + "    &     OldProfilePic: " + OldProfilePic);

                            DirectoryInfo mydir = new DirectoryInfo(@Server.MapPath(filepath));
                            FileInfo[] f = mydir.GetFiles();
                            foreach (FileInfo file in f)
                            {
                                if (file.Name == filename)
                                {
                                    //Response.Write("File '" + file.Name + "' deleted successfully!");
                                    file.Delete();
                                }
                            }
                        }
                        FileUploadChangeProfilePicture.SaveAs(Server.MapPath("~/UploadedFiles/UserProfilePictures/" + FileUploadChangeProfilePicture.PostedFile.FileName));
                        ImageProfilePic.ImageUrl = "~/UploadedFiles/UserProfilePictures/" + FileUploadChangeProfilePicture.PostedFile.FileName;
                        lblWarningUploadingProPic.Text = "Your profile picture changed successfully!";
                        //Image1.ImageUrl = "~\\ImageControl Icons\\Tick.ico";
                    }
                    else
                    {
                        lblWarningUploadingProPic.Text = "Upload Status: Error: File size should be less than 10MB!";
                        //Image1.ImageUrl = "~\\ImageControl Icons\\Warning.ico";
                    }
                }
                else
                {
                    lblWarningUploadingProPic.Text = "Upload Status: Error: Only image file(*.jpg, *.jpeg, *.png, *.gif, *.ico) can be uploaded!";
                }

            }
            else
            {
                lblWarningUploadingProPic.Text = "Upload Status: Error: Please choose a file to upload!";
                //Image1.ImageUrl = "~\\ImageControl Icons\\Error.ico";
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    void ShowPanelDeleteAccount()
    {
        try
        {
            ModalPopupExtenderDeleteAccount.Show();
            PanelDeleteAccountPopup.Visible = true;
            FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
            var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
            foreach (var r in res)
            {
                ImageProfilePictureDeleteAccount.ImageUrl = r.UserProfilePicFile;
                if (ImageProfilePictureDeleteAccount.ImageUrl == "")
                {
                    if (r.UserGender == "Male")
                        ImageProfilePictureDeleteAccount.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicMale.png";
                    else
                        ImageProfilePictureDeleteAccount.ImageUrl = "~/UploadedFiles/UserProfilePictures/NoProfilePicFemale.png";
                }
                lblUsernameDeleteAccount.Text = "Sure to delete your account permanently " + r.UserFirstName.ToString() + "?";
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //PanelDeleteAccountPopup.Visible = false; PanelDeleteFiles.Visible = false; PanelShareWith.Visible = false;
            WelcomeMsg();
            SetProfilePic();
            int notificationNo = 1000;
            try
            { notificationNo = CheckForNotifications(); }
            catch (System.Exception exc) { Response.Redirect("Homepage.aspx?s=0"); }
            if (notificationNo > 0)
            {
                Menu1.Items.RemoveAt(1);
                MenuItem notificationsMenuItem = new MenuItem("Notifications (" + notificationNo + ")");
                Menu1.Items.AddAt(1, notificationsMenuItem);
            }

            if (Session["showPanelUploadedFiles"].ToString() == "0") { }
            else if (Session["showPanelUploadedFiles"].ToString() == "1") showPanelUploadFile_Info();
            if (Session["showPanelDeleteAccountPopup"].ToString() == "1") PanelDeleteAccountPopup.Visible = true;
            else if (Session["showPanelDeleteAccountPopup"].ToString() == "0") PanelDeleteAccountPopup.Visible = false;
            DeleteFilesFrom_TempDownloads_Directory();
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    int CheckForNotifications()
    {
        int newNoficationNo = 0;
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        var res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
        string notifications = "";
        foreach (var r in res) notifications = r.Notifications.ToString();
        char[] ntfFetched = notifications.ToCharArray();
        foreach (char ch in ntfFetched) if (ch == '*') newNoficationNo++;
        return newNoficationNo;
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        try
        {
            if (Menu1.SelectedItem.Text == "Contact Us")
            {
                Session["showPanelUploadedFiles"] = "0";
                Response.Redirect("ContactUsPage.aspx");
                return;
            }

            if (Menu1.SelectedItem.Text == "About Us")
            {
                Session["showPanelUploadedFiles"] = "0";
                Response.Redirect("AboutUsPage.aspx");
                return;
            }

            if (Menu1.SelectedItem.Text == "Our Terms & Policies")
            {
                Session["showPanelUploadedFiles"] = "0";
                Response.Redirect("Terms_and_PoliciesPage.aspx");
                return;
            }

            if (Menu1.SelectedItem.Text == "Change password")
            {
                Session["showPanelUploadedFiles"] = "0";
                MakeOtherControlsInvisible();
                PanelChangePassword.Visible = true;
                return;
            }

            if (Menu1.SelectedItem.Text == "Delete account")
            {
                Session["showPanelUploadedFiles"] = "0";
                Session["showPanelDeleteAccountPopup"] = "1";
                MakeOtherControlsInvisible();
                ShowPanelDeleteAccount();
                return;
            }

            if (Menu1.SelectedItem.Text == "Sign Out")
            {
                DeleteFilesFrom_TempDownloads_Directory();
                Session["showPanelUploadedFiles"] = "0";
                Session.Abandon();
                Response.Redirect("Homepage.aspx?s=1");
                return;
            }

            if (Menu1.SelectedItem.Text == "Upload File")
            {
                Session["showPanelUploadedFiles"] = "0";
                MakeOtherControlsInvisible();
                PanelUploadFile.Visible = true;

                return;
            }

            if (Menu1.SelectedItem.Text.Contains("Notifications"))
            {
                Session["showPanelUploadedFiles"] = "0";
                Response.Redirect("NotificationsPage.aspx");
                return;
            }

            if (Menu1.SelectedItem.Text == "My Uploads")
            {
                //Session["showPanelUploadedFiles"] = "1";
                showPanelUploadFile_Info();
                return;
            }

            if (Menu1.SelectedItem.Text == "Change Profile Picture")
            {
                Session["showPanelUploadedFiles"] = "0";
                MakeOtherControlsInvisible();
                PanelChangeProfilePicture.Visible = true;
                return;
            }
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
    protected void showPanelUploadFile_Info()
    {
        UpdatePanelUsageInfo();
        RefreshUserUploadedFilesList();
    }
protected void DropDownListUploadMode_SelectedIndexChanged(object sender, EventArgs e)
{
    if (DropDownListUploadMode.SelectedItem.Text == "Secure Archive Mode")
    {
        DropDownListSearchCategory.ClearSelection();
        DropDownListSearchCategory.Enabled = false;
    }
    else
    {
        DropDownListSearchCategory.Enabled = true;
    }
}
protected void btnUploadFile_Click(object sender, EventArgs e)
{
    UploadFile();
}
protected void CheckBoxSelectAll_CheckedChanged(object sender, EventArgs e)
{
    SelectUnselectAll();
}
protected void ButtonDeleteFile_Click(object sender, EventArgs e)
{
    //Response.Write("  ButtonDeleteFile_Click() Entered!  ");
    ShowDeleteFilesMessage();        
    PanelShareWith.Visible = false;
    ModalPopupExtenderDeleteFiles.Show();
    PanelDeleteFiles.Visible = true;
    //Response.Write("   ButtonDeleteFile_Click() Exiting!  ");
}
protected void btnChangePassword_Click(object sender, EventArgs e)
{
    ChangePassword();    
}
protected void btnChangeProfilePicture_Click(object sender, EventArgs e)
{
    ChangeProfilePicture();
}
protected void ButtonChangeProfilePicture_Click(object sender, EventArgs e)
{
    MakeOtherControlsInvisible();
    PanelChangeProfilePicture.Visible = true;
}
protected void btnRemoveProfilePicture_Click(object sender, EventArgs e)
{
    RemoveProfilePicture();
}
protected void Button1_Click(object sender, EventArgs e)
{
    //PanelDeleteFiles.Visible = true; PanelShareWith.Visible = false; 
    ModalPopupExtenderDeleteFiles.Show();
}
protected void btnDeleteAccConfirmNo_Click(object sender, EventArgs e)
{
    try
    {
        Session["showPanelDeleteAccountPopup"] = "0";
        PanelDeleteAccountPopup.Visible = false;
        ModalPopupExtenderDeleteAccount.Hide();
    }
    catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
}
protected void btnDeleteAccConfirmYes_Click(object sender, EventArgs e)
{
    DeleteUserAccount();
}
protected void ButtonAccountDeletePanelPopup_Click(object sender, EventArgs e)
{
    // MakeOtherControlsInvisible();
    // ShowPanelDeleteAccount();
}
protected void btnDeleteNo_Click(object sender, EventArgs e)
{}
protected void btnDeleteYes_Click(object sender, EventArgs e)
{
    try
    {
        DeleteSelectedRows();
        Session["showPanelUploadedFiles"] = "1";
        Response.Redirect("CustomerPage.aspx");
    }
    catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
}

protected void ButtonSendRequestsToUsers_Click(object sender, EventArgs e)
{

}

protected void ButtonShareWith_Click(object sender, EventArgs e)
{
    if (GetNoOfFilesSelected()[0] == 0) 
    {
        lblFileSharingErrorMessage.Text = "Please select atleast one file to share!";
        return; 
    }
    lblFileSharingErrorMessage.Text = "";
    GridViewUploadedFiles.Enabled = false;
    ButtonDeleteFile.Enabled = false; ButtonShareWith.Enabled = false; CheckBoxSelectAll.Enabled = false;
    PanelShareWith.Visible = true; 
    txtSearchUser.Text = "";
    GridViewSearchedUsers.DataSource = null; GridViewSearchedUsers.DataBind(); lblSearchUserErrorMessage.Text = "";
    Session["usersAddedInNewGroup"] = Session["user"] + "|";
    populateGridViewAddedUsers();
    btnSendRequestsToUsers.Enabled = false;
}
    /*

    // ******** Sharing files codes
bool CheckForRequestedUsernamesForFilesSharing()
{
        if (txtUsernamesForSharingFiles.Text.Trim() == "")
        {
            lblSharingFilesConfirmationMessage.ForeColor = System.Drawing.Color.Red;
            lblSharingFilesConfirmationMessage.Text = "Please enter atleast one username!";
            return false;
        }

        string providedUsernames_Raw = txtUsernamesForSharingFiles.Text.Trim().ToUpper();
        string[] usernamesFound = new string[25];

        // ****** Checking for and Removing extra spaces and replacing LF and CR with a single space 
        char[] chars = providedUsernames_Raw.ToCharArray();

        int spaceFlag = 0, indexUsernames = 0;

        string providedUsernames_Filtered = "";
        foreach (char ch in chars)
        {
            if ((int)ch == 32 || (int)ch == 13 || (int)ch == 10) // Irrelevant character found: space, LF, CR
                spaceFlag++;
            else
                spaceFlag = 0;
            if (spaceFlag > 1) continue;
            else
            {
                if ((int)ch == 13 || (int)ch == 10) { providedUsernames_Filtered += " "; spaceFlag++; }
                else providedUsernames_Filtered += ch.ToString();
            }
        }

        // ******* Storing usernames to string array
        char[] chars2 = providedUsernames_Filtered.ToCharArray();
        string[] duplicateUsernamesProvided = new string[25];
        foreach (char c in chars2)
            if ((int)c == 32) indexUsernames++;
            else usernamesFound[indexUsernames] += c.ToString();

        // ******** Removing duplicate username entries
        string[] Usernames_Filtered = new string[25]; int indexUsernames_Filtered = 0;
        for (int i = 0; i <= indexUsernames; i++)
            if (!Usernames_Filtered.Contains(usernamesFound[i]))
                Usernames_Filtered[indexUsernames_Filtered++] = usernamesFound[i];

        // ********* Checking each entered string for a valid username
        string[] WrongUsernames = new string[25]; int indexWrongUsernames = 0;
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

        for (int i = 0; i < indexUsernames_Filtered; i++)
        {
            if (Usernames_Filtered[i] == Session["user"].ToString().ToUpper())
            {
                // ********** Prohibiting user from sharing file(s) with themselves
                lblSharingFilesConfirmationMessage.ForeColor = System.Drawing.Color.Red;
                lblSharingFilesConfirmationMessage.Text = "You cannot share any of your own file(s) with yourself!";
                return false;
            }
            if (!(DB.UserInfos.Where(x => x.Username == Usernames_Filtered[i]).Count() == 1 ? true : false))
                WrongUsernames[indexWrongUsernames++] = Usernames_Filtered[i];
        }

        //Response.Write("indexUsernames_Filtered = " + indexUsernames_Filtered + ", Usernames_Filtered[0] = " + Usernames_Filtered[0]);
        if (indexWrongUsernames > 0)
        {
            // ******** Showing wrong usernames provided message to the user
            lblSharingFilesConfirmationMessage.ForeColor = System.Drawing.Color.Red;
            lblSharingFilesConfirmationMessage.Text = "Following are found to be either invalid strings or non-existing usernames:  ";
            for (int i = 0; i < indexWrongUsernames; i++)
                if (i == (indexWrongUsernames - 1)) lblSharingFilesConfirmationMessage.Text += WrongUsernames[i] + "!";
                else lblSharingFilesConfirmationMessage.Text += WrongUsernames[i] + ", ";
            return false;
        }
        else
        {
            // ********* Showing send file(s) sharing request message to the user
            lblSharingFilesConfirmationMessage.ForeColor = System.Drawing.Color.Blue;
            lblSharingFilesConfirmationMessage.Text = "Sure to send file(s) sharing requests to ";


            string passUsernamesToAnotherPage = "";
            for (int i = 0; i < indexUsernames_Filtered; i++)
            {
                passUsernamesToAnotherPage += Usernames_Filtered[i] + " ";
                if (i == (indexUsernames_Filtered - 1))
                    lblSharingFilesConfirmationMessage.Text += Usernames_Filtered[i] + "?";
                else
                    lblSharingFilesConfirmationMessage.Text += Usernames_Filtered[i] + ", ";
            }
            Session["UsernamesToShareWith"] = passUsernamesToAnotherPage;
            return true;
        }
}
     */ 
int getNextFileSharingRequestsID()
{
    FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
    var res = from v in DB.GetTable<FileSharingRequest>() select v.ID;
    int nextID = 0;
    foreach (var r in res) nextID = (int)r;
    return ++nextID;
}
void SendRequestsToUsersForFileSharing()
{
    try
    {
        // ********** Gathering all the user names from GridViewAddedUsers
        Session["usersAddedInNewGroup"] = "";
        string[] usernamesFound = new string[25];
        int indexUsernames = GridViewAddedUsers.Rows.Count;
        int insertIndex = 0;
        for (int i = 0; i < indexUsernames; i++)
            if (!(GridViewAddedUsers.Rows[i].Cells[3].Text.Trim() == Session["user"].ToString()))
            { usernamesFound[insertIndex++] = GridViewAddedUsers.Rows[i].Cells[3].Text.Trim(); }

        indexUsernames--;
        
        // ************ Send notifications to each users
        // Write to DB Table FileSharingRequests    
        FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();
        string filesShared_FileNames_WithExt = "";
        int TotalRows = GridViewUploadedFiles.Rows.Count;
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
            if (chk.Checked) filesShared_FileNames_WithExt += GridViewUploadedFiles.Rows[i].Cells[1].Text + "|";
        }

        int[] FSR_IDs = new int[indexUsernames];
        for (int i = 0; i < indexUsernames; i++)
        {
            FileSharingRequest recordFSR = new FileSharingRequest();
            FSR_IDs[i] = getNextFileSharingRequestsID();
            recordFSR.ID = FSR_IDs[i];
            recordFSR.RequestingUser = Session["user"].ToString();
            recordFSR.RequestedUser = usernamesFound[i];
            recordFSR.FileNames_WithExt = filesShared_FileNames_WithExt;
            recordFSR.Confirmed = 'N';
            DB.FileSharingRequests.InsertOnSubmit(recordFSR);
            DB.SubmitChanges();
        }

        // Send notification to the user sending file sharing request
        int noOfFilesSelected = GetNoOfFilesSelected()[0], j = 0;
        string notification = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  You sent request(s) to " + indexUsernames.ToString() + " user(s) ( ";
        for (int i = 0; i < indexUsernames; i++)
            if (i == (indexUsernames - 1)) notification += usernamesFound[i] + " ";
            else notification += usernamesFound[i] + ", ";
        notification += ") for sharing " + noOfFilesSelected.ToString() + " file(s) ( ";
        for (int i = 0; i < TotalRows; i++)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)GridViewUploadedFiles.Rows[i].FindControl("chkRow");
            if (chk.Checked)
            {
                if (++j == noOfFilesSelected) notification += GridViewUploadedFiles.Rows[i].Cells[1].Text + " ";
                else notification += GridViewUploadedFiles.Rows[i].Cells[1].Text + ", ";
            }
        }
        notification += " ) |";
        var res = DB.UserInfos.Where(x => x.Username == Session["user"]);
        foreach (var r in res) r.Notifications = notification + r.Notifications.ToString();
        DB.SubmitChanges();

        // Send notifications to each user requested for file sharing
        string ntf_pt1 = "* [" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) + "]  ";
        res = DB.UserInfos.Where(x => x.Username == Session["user"].ToString());
        foreach (var r in res) ntf_pt1 += "<a href=AdminUserAccountControl.aspx?User=" + r.Username + ">" + r.UserFirstName + " " + r.UserLastName + "</a> ";

        for (int i = 0; i < indexUsernames; i++)
        {
            res = DB.UserInfos.Where(x => x.Username == usernamesFound[i]);
            notification = ntf_pt1 + "sent you a file sharing request. &nbsp;&nbsp;&nbsp; <a href=FileSharingRequestDetailsPage.aspx?FSR_ID=" + FSR_IDs[i] + ">View Details</a>|";
            foreach (var r in res)
                r.Notifications = notification + r.Notifications.ToString();
        }
        DB.SubmitChanges();
        lblFileDeletion.Text = noOfFilesSelected.ToString() + " file(s) shared successfully to " + (indexUsernames).ToString() + " requested user(s)!";
        PanelShareWith.Visible = false;
    }
    catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
}
    /*
protected void btnCheckForRequestedUsernamesForFilesSharing_Click(object sender, EventArgs e)
{
    bool res = false;
    try
    {
        res = CheckForRequestedUsernamesForFilesSharing();
    }
    catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    if (res)
    {
        imgSharingFilesConfirmationIcon.ImageUrl = "~/Images/NotificationImages/tick.png";
        btnCheckForRequestedUsernamesForFilesSharing.Enabled = false;
        btnReenterUsernames.Enabled = true;
        btnSendRequestsToUsers.Enabled = true;
    }
    else
    {
        imgSharingFilesConfirmationIcon.ImageUrl = "~/Images/NotificationImages/unchecked.png";
        btnReenterUsernames.Enabled = false;
    }
}
     * */
protected void btnSendRequestsToUsers_Click(object sender, EventArgs e)
{
    SendRequestsToUsersForFileSharing();
    GridViewUploadedFiles.Enabled = true;
    ButtonDeleteFile.Enabled = true; ButtonShareWith.Enabled = true; CheckBoxSelectAll.Enabled = true;
}
    /*
protected void btnReenterUsernames_Click(object sender, EventArgs e)
{
    btnReenterUsernames.Enabled = false;
    btnSendRequestsToUsers.Enabled = false;
    lblSharingFilesConfirmationMessage.Text = "";
    txtUsernamesForSharingFiles.Text = "";
    imgSharingFilesConfirmationIcon.ImageUrl = "";
    btnCheckForRequestedUsernamesForFilesSharing.Enabled = true;
    txtUsernamesForSharingFiles.Text = "";
    lblSharingFilesConfirmationMessage.Text = "";
}
     */ 
protected void btnCancelFileSharing_Click(object sender, EventArgs e)
{
    PanelShareWith.Visible = false; 
    GridViewUploadedFiles.Enabled = true; 
    CheckBoxSelectAll.Enabled = true;
    ButtonShareWith.Enabled = true;
    ButtonDeleteFile.Enabled = true;
}
protected void GridViewUploadedFiles_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName == "Download")
    {
        //Response.Write("Download button clicked! | fullFileAddressInServerDB (e.CommandArgument) = '" + e.CommandArgument.ToString() + "'");

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        string filename = UnzipFile(Server.MapPath(e.CommandArgument.ToString()));
        Response.AppendHeader("content-disposition", "attachment; filename=" + filename);
        Response.TransmitFile(Server.MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/" + filename));
        Response.End();
    }
    if (e.CommandName == "View")
    {
        //Response.Write("View button clicked! | fullFileAddressInServerDB (e.CommandArgument) = '" + e.CommandArgument.ToString() + "'");

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
protected void btnSearchUser_Click(object sender, EventArgs e)
{
    //Session["usersAddedInNewGroup"] = Session["user"].ToString() + "|";
    populateGridViewSearchedUsers();
    populateGridViewAddedUsers();
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

    sqlQuery = "select UserFirstName \"First Name\", UserLastName \"Last Name\", Username \"Username\" from UserInfos where ";
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
        imgbtnProPic.PostBackUrl = "AdminUserAccountControl.aspx?User=" + GridViewAddedUsers.Rows[i].Cells[3].Text;
        imgbtnProPic.ImageAlign = System.Web.UI.WebControls.ImageAlign.AbsBottom;
        var res = from v in DB.GetTable<UserInfo>() where v.Username == GridViewAddedUsers.Rows[i].Cells[3].Text select v.UserProfilePicFile;
        foreach (var r in res) imgbtnProPic.ImageUrl = r.ToString();
        Button btnRemove = new Button();
        btnRemove = (Button)GridViewAddedUsers.Rows[i].FindControl("btnRemoveUser");
        if (GridViewAddedUsers.Rows[i].Cells[3].Text == Session["user"].ToString())
            btnRemove.Enabled = false;
        else
            btnRemove.CommandArgument = GridViewAddedUsers.Rows[i].Cells[3].Text;

    }
    if (GridViewAddedUsers.Rows.Count > 1) btnSendRequestsToUsers.Enabled = true;
    else { lblUsersAddedCounter.Text = "No users selected for file sharing!"; btnSendRequestsToUsers.Enabled = false; }

    //}
    //catch (Exception exc) { Response.Write(" | <b>Exc caught</b> inside populateGridViewAddedUsers()! Exc Details: " + exc.Message + " sqlQuery=" + sqlQuery + " | "); }
}
string fetchUsernameFrom_txtSearchUser()
{
    if (txtSearchUser.Text.Trim() == "") return ""; 
    else
    {
        if (!(txtSearchUser.Text.Contains("[") &&  txtSearchUser.Text.Contains("]"))) return "";
        else
        {
            string usernameFetched = "";
            int i = 0; bool startRecording = false;
            char[] textEntered_chars = txtSearchUser.Text.Trim().ToCharArray();
            foreach (char c in textEntered_chars)
            {
                if (c == '[') { startRecording = true; continue; }
                if (c == ']') break;
                if (startRecording) usernameFetched += c.ToString();
            }
            return usernameFetched;
        }
    }
}
void populateGridViewSearchedUsers()
{
    string fetchedUsername = fetchUsernameFrom_txtSearchUser();

    if (fetchedUsername == "")
    {
        GridViewSearchedUsers.DataSource = null; GridViewSearchedUsers.DataBind(); lblSearchUserErrorMessage.Text = "";
        lblSearchUserErrorMessage.Text = "Please enter a non-null search term!"; return;
    }

    SqlConnection con = new SqlConnection(constr);
    con.Open();
    string sqlQuery = "select UserFirstName \"First Name\", UserLastName \"Last Name\", Username \"Username\" from UserInfos where Username='" + fetchedUsername + "'";
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
        imgbtnProPic.PostBackUrl = "AdminUserAccountControl.aspx?User=" + GridViewSearchedUsers.Rows[i].Cells[3].Text;
        imgbtnProPic.ImageAlign = System.Web.UI.WebControls.ImageAlign.AbsBottom;
        var res = from v in DB.GetTable<UserInfo>() where v.Username == GridViewSearchedUsers.Rows[i].Cells[3].Text select v.UserProfilePicFile;
        foreach (var r in res) imgbtnProPic.ImageUrl = r.ToString();
        Button btnAdd = new Button();
        btnAdd = (Button)GridViewSearchedUsers.Rows[i].FindControl("btnAddUser");
        btnAdd.CommandArgument = GridViewSearchedUsers.Rows[i].Cells[3].Text;
    }
}
protected void GridViewSearchedUsers_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName.ToString() == "AddUserInNewGroup")
    {
        //Response.Write(" AddUserInNewGroup() working! " + DateTime.Now.ToString("HH:mm:ss") + " | ");
        Button btn = sender as Button;
        if (!((getUsersAddedInNewGroup()).Contains(e.CommandArgument.ToString()))) Session["usersAddedInNewGroup"] += e.CommandArgument.ToString() + "|";
        populateGridViewAddedUsers();
    }
}
protected void GridViewAddedUsers_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName.ToString() == "RemoveUserFromNewGroup")
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
protected void Button1_Click1(object sender, EventArgs e)
{
    try { Response.Write("Session[usersAddedInNewGroup]=" + Session["usersAddedInNewGroup"]); }
    catch (System.NullReferenceException exc) { Response.Write(" | <b>Exc occured</b> in Session[usersAddedInNewGroup]: " + exc.Message + " |"); }
}
}