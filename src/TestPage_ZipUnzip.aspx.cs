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


public partial class TestPage_ZipUnzip : System.Web.UI.Page
{
    /*
     Symbols:
        // $$$$$$$$$$$$$$$$$$ - This line is to be modified at the time of deploymnet
        // ++++++++++++++++++ - Add this line to the code
     */
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    { }

    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        UploadFile();
    }

    void UploadFile()
    {
        try
        {
            DropDownListSearchCategory.Enabled = true;
            if (DropDownListUploadMode.SelectedItem.Text == "General Mode")
            {
                if (FileUpload1.HasFile)
                {
                    FunZoneDatabaseDataContext DB = new FunZoneDatabaseDataContext();

                    // Inserting values to each column of the uploaded file's record


                    int NewFileNo = 0;
                    if (DB.DBFiles.Count() == 0) NewFileNo = 0;
                    else
                    {
                        var res = from v in DB.GetTable<DBFile>() select v.FileNo;
                        foreach (var r in res) NewFileNo = r;
                    }
                    DBFile record = new DBFile();
                    record.FileNo = NewFileNo + 1;
                    // $$$$$$$$$$$$$$$$$$$$$$$$$ record.UploaderUserName = Request.QueryString[""].ToString();
                    record.UploaderUserName = "Sourav";
                    record.Mode = "General";
                    record.SharedWith = "Nobody";
                    DateTime now = DateTime.Now;
                    record.UploadDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // 'YYYY-MM-DD HH:MM:SS'
                    switch (DropDownListSearchCategory.SelectedItem.Text)
                    {
                        case "Image":
                            {
                                //Response.Write("Image"); 
                                record.Category = DropDownListSearchCategory.SelectedItem.Text;
                                record.UploadedFileName = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                                // ++++++++++++++++++++++++++++++
                                string filenameWithExt = Path.GetFileName(FileUpload1.FileName);
                                record.UploadedFileName_WithExt = filenameWithExt;

                                if (Convert.ToInt32(FileUpload1.PostedFile.ContentLength) < 1024)
                                    record.UploadedFileSize = Convert.ToString(FileUpload1.PostedFile.ContentLength) + "B";
                                else if (Convert.ToInt32(FileUpload1.PostedFile.ContentLength) >= 1024 && Convert.ToInt32(FileUpload1.PostedFile.ContentLength) <= (1024 * 1024))
                                    record.UploadedFileSize = Convert.ToString(FileUpload1.PostedFile.ContentLength / 1024) + "KB";
                                else
                                    record.UploadedFileSize = Convert.ToString(FileUpload1.PostedFile.ContentLength / (1024 * 1024)) + "MB";

                                if (FileUpload1.PostedFile.ContentType == "image/jpeg" || FileUpload1.PostedFile.ContentType == "image/png" || FileUpload1.PostedFile.ContentType == "image/jpg" || FileUpload1.PostedFile.ContentType == "image/gif" || FileUpload1.PostedFile.ContentType == "image/x-icon")
                                {
                                    if (FileUpload1.PostedFile.ContentLength < 10485760)
                                    {
                                        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                                        //record.FileAddressInServerDB = "~/UploadedFiles/ServerDatabase/Images/" + filenameWithExt;
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
                    }
                }
                else
                {
                    lblUploadStatus.Text = "FileUpload1 does not have a file!";
                }
            }
            else
            {
                lblUploadStatus.Text = "Please choose an upload category!";
            }
        }
        catch (Exception exc)
        {
            Response.Write("Exc inside UploadFile(): " + exc.Message);
        }
    }

    void GetUserUploadedFilesList()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("select  UploadFileName_WithExt \"Original filename\", UploadedFileSize \" Size \", Category \" Category \", Mode \" Upload Mode \", UploadDateTime \" Upload Date\\Time \",SharedWith \"Shared With\" from DBFiles where UploaderUserName=@UserName", con);
        cmd.Parameters.AddWithValue("@UserName", "Sourav");
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewUploadedFiles.DataSource = reader;
        GridViewUploadedFiles.DataBind();
        con.Close();
        int totalFilesNo;
        for (totalFilesNo = 0; totalFilesNo < GridViewUploadedFiles.Rows.Count; totalFilesNo++)
        {
            LinkButton linkDownload = new LinkButton();
            LinkButton linkView = new LinkButton();

            string fullFileAddressInServerDB = "~/UploadedFiles/ServerDatabase/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[3].Text + "s/" + GridViewUploadedFiles.Rows[totalFilesNo].Cells[1].Text + ".zip";

            linkDownload = (LinkButton)GridViewUploadedFiles.Rows[totalFilesNo].FindControl("lnkbtnDownloadContent");
            linkView = (LinkButton)GridViewUploadedFiles.Rows[totalFilesNo].FindControl("lnkbtnViewContent");

            linkDownload.CommandArgument = fullFileAddressInServerDB;
            linkView.CommandArgument = fullFileAddressInServerDB;
        }
        lblFileDeletion.Text = "You have uploded " + totalFilesNo.ToString() + " file(s) currently in the Database";
    }

    protected void DropDownListUploadMode_SelectedIndexChanged(object sender, EventArgs e)
    {}
    protected void btnGridViewUploadedFiles_Click(object sender, EventArgs e)
    {
        GetUserUploadedFilesList();    
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
    protected String UnzipFile(String FullFilename)
    {
        //string zipToUnpack = Server.MapPath(".") + @"\Zip\" + filename;
        string zipToUnpack = FullFilename;
        string unpackDirectory = Server.MapPath(".") + @"/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/";
        using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
        {
            foreach (ZipEntry e in zip1)
            {
                e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
            }
        }
        DirectoryInfo dir = new DirectoryInfo(MapPath("/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/"));
        FileInfo[] files = dir.GetFiles();
        return files[0].Name;
    }
    string checkIfFileExistsIn_TempDownloads_Directory(string fullFileAddressInServerDB)
    {
        if (File.Exists(fullFileAddressInServerDB))
        {
            DirectoryInfo dir = new DirectoryInfo(MapPath("/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/"));
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo f in files)
                if (f.FullName.ToString() == fullFileAddressInServerDB) return f.Name.ToString();
            return "Arrived at Unpredictable CP!";
        }
        else return "File does not exist!";
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {
        try
        {
            /* string fullFileAdd = MapPath("~/UploadedFiles/ServerDatabase/TempFiles/TempDownloads/burger.jpg");
            Response.Write("checkIfFileExistsIn_TempDownloads_Directory(" + fullFileAdd + ") = " + checkIfFileExistsIn_TempDownloads_Directory(fullFileAdd)); */
            if (Session["user"] == null)
                Response.Write("Null string");
            else
                Response.Write("Session[\"user\"] = " + Session["user"]);
        }
        catch (System.NullReferenceException exc) { Response.Redirect("Homepage.aspx?s=0"); }
    }
}