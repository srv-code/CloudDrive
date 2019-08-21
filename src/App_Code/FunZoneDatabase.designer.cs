﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CloudDriveDB")]
public partial class FunZoneDatabaseDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertAdminInfo(AdminInfo instance);
  partial void UpdateAdminInfo(AdminInfo instance);
  partial void DeleteAdminInfo(AdminInfo instance);
  partial void InsertUserInfo(UserInfo instance);
  partial void UpdateUserInfo(UserInfo instance);
  partial void DeleteUserInfo(UserInfo instance);
  partial void InsertFileSharingRequest(FileSharingRequest instance);
  partial void UpdateFileSharingRequest(FileSharingRequest instance);
  partial void DeleteFileSharingRequest(FileSharingRequest instance);
  partial void InsertDBFile(DBFile instance);
  partial void UpdateDBFile(DBFile instance);
  partial void DeleteDBFile(DBFile instance);
  partial void InsertFileSharingGroup(FileSharingGroup instance);
  partial void UpdateFileSharingGroup(FileSharingGroup instance);
  partial void DeleteFileSharingGroup(FileSharingGroup instance);
  #endregion
	
	public FunZoneDatabaseDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public FunZoneDatabaseDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public FunZoneDatabaseDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public FunZoneDatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public FunZoneDatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<AdminInfo> AdminInfos
	{
		get
		{
			return this.GetTable<AdminInfo>();
		}
	}
	
	public System.Data.Linq.Table<UserInfo> UserInfos
	{
		get
		{
			return this.GetTable<UserInfo>();
		}
	}
	
	public System.Data.Linq.Table<FileSharingRequest> FileSharingRequests
	{
		get
		{
			return this.GetTable<FileSharingRequest>();
		}
	}
	
	public System.Data.Linq.Table<DBFile> DBFiles
	{
		get
		{
			return this.GetTable<DBFile>();
		}
	}
	
	public System.Data.Linq.Table<FileSharingGroup> FileSharingGroups
	{
		get
		{
			return this.GetTable<FileSharingGroup>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AdminInfo")]
public partial class AdminInfo : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _AdminName;
	
	private string _AdminPwd;
	
	private System.Nullable<System.DateTime> _LastLogoutDateTime;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAdminNameChanging(string value);
    partial void OnAdminNameChanged();
    partial void OnAdminPwdChanging(string value);
    partial void OnAdminPwdChanged();
    partial void OnLastLogoutDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnLastLogoutDateTimeChanged();
    #endregion
	
	public AdminInfo()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdminName", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string AdminName
	{
		get
		{
			return this._AdminName;
		}
		set
		{
			if ((this._AdminName != value))
			{
				this.OnAdminNameChanging(value);
				this.SendPropertyChanging();
				this._AdminName = value;
				this.SendPropertyChanged("AdminName");
				this.OnAdminNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdminPwd", DbType="VarChar(100)")]
	public string AdminPwd
	{
		get
		{
			return this._AdminPwd;
		}
		set
		{
			if ((this._AdminPwd != value))
			{
				this.OnAdminPwdChanging(value);
				this.SendPropertyChanging();
				this._AdminPwd = value;
				this.SendPropertyChanged("AdminPwd");
				this.OnAdminPwdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastLogoutDateTime", DbType="DateTime")]
	public System.Nullable<System.DateTime> LastLogoutDateTime
	{
		get
		{
			return this._LastLogoutDateTime;
		}
		set
		{
			if ((this._LastLogoutDateTime != value))
			{
				this.OnLastLogoutDateTimeChanging(value);
				this.SendPropertyChanging();
				this._LastLogoutDateTime = value;
				this.SendPropertyChanged("LastLogoutDateTime");
				this.OnLastLogoutDateTimeChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserInfos")]
public partial class UserInfo : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _Username;
	
	private string _UserPwd;
	
	private string _UserFirstName;
	
	private string _UserMiddleName;
	
	private string _UserLastName;
	
	private string _UserGender;
	
	private string _UserDOB;
	
	private string _UserCountry;
	
	private string _UserCity;
	
	private string _UserPhoneNumber;
	
	private string _UserMartialStatus;
	
	private string _UserEMail;
	
	private string _UserSecurityQuestion;
	
	private string _UserSecurityAnswer;
	
	private string _UserProfilePicFile;
	
	private System.Nullable<System.DateTime> _JoiningDateTime;
	
	private string _Notifications;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnUserPwdChanging(string value);
    partial void OnUserPwdChanged();
    partial void OnUserFirstNameChanging(string value);
    partial void OnUserFirstNameChanged();
    partial void OnUserMiddleNameChanging(string value);
    partial void OnUserMiddleNameChanged();
    partial void OnUserLastNameChanging(string value);
    partial void OnUserLastNameChanged();
    partial void OnUserGenderChanging(string value);
    partial void OnUserGenderChanged();
    partial void OnUserDOBChanging(string value);
    partial void OnUserDOBChanged();
    partial void OnUserCountryChanging(string value);
    partial void OnUserCountryChanged();
    partial void OnUserCityChanging(string value);
    partial void OnUserCityChanged();
    partial void OnUserPhoneNumberChanging(string value);
    partial void OnUserPhoneNumberChanged();
    partial void OnUserMartialStatusChanging(string value);
    partial void OnUserMartialStatusChanged();
    partial void OnUserEMailChanging(string value);
    partial void OnUserEMailChanged();
    partial void OnUserSecurityQuestionChanging(string value);
    partial void OnUserSecurityQuestionChanged();
    partial void OnUserSecurityAnswerChanging(string value);
    partial void OnUserSecurityAnswerChanged();
    partial void OnUserProfilePicFileChanging(string value);
    partial void OnUserProfilePicFileChanged();
    partial void OnJoiningDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnJoiningDateTimeChanged();
    partial void OnNotificationsChanging(string value);
    partial void OnNotificationsChanged();
    #endregion
	
	public UserInfo()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string Username
	{
		get
		{
			return this._Username;
		}
		set
		{
			if ((this._Username != value))
			{
				this.OnUsernameChanging(value);
				this.SendPropertyChanging();
				this._Username = value;
				this.SendPropertyChanged("Username");
				this.OnUsernameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserPwd", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
	public string UserPwd
	{
		get
		{
			return this._UserPwd;
		}
		set
		{
			if ((this._UserPwd != value))
			{
				this.OnUserPwdChanging(value);
				this.SendPropertyChanging();
				this._UserPwd = value;
				this.SendPropertyChanged("UserPwd");
				this.OnUserPwdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserFirstName", DbType="VarChar(100)")]
	public string UserFirstName
	{
		get
		{
			return this._UserFirstName;
		}
		set
		{
			if ((this._UserFirstName != value))
			{
				this.OnUserFirstNameChanging(value);
				this.SendPropertyChanging();
				this._UserFirstName = value;
				this.SendPropertyChanged("UserFirstName");
				this.OnUserFirstNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserMiddleName", DbType="VarChar(100)")]
	public string UserMiddleName
	{
		get
		{
			return this._UserMiddleName;
		}
		set
		{
			if ((this._UserMiddleName != value))
			{
				this.OnUserMiddleNameChanging(value);
				this.SendPropertyChanging();
				this._UserMiddleName = value;
				this.SendPropertyChanged("UserMiddleName");
				this.OnUserMiddleNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserLastName", DbType="VarChar(100)")]
	public string UserLastName
	{
		get
		{
			return this._UserLastName;
		}
		set
		{
			if ((this._UserLastName != value))
			{
				this.OnUserLastNameChanging(value);
				this.SendPropertyChanging();
				this._UserLastName = value;
				this.SendPropertyChanged("UserLastName");
				this.OnUserLastNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserGender", DbType="VarChar(50)")]
	public string UserGender
	{
		get
		{
			return this._UserGender;
		}
		set
		{
			if ((this._UserGender != value))
			{
				this.OnUserGenderChanging(value);
				this.SendPropertyChanging();
				this._UserGender = value;
				this.SendPropertyChanged("UserGender");
				this.OnUserGenderChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserDOB", DbType="VarChar(50)")]
	public string UserDOB
	{
		get
		{
			return this._UserDOB;
		}
		set
		{
			if ((this._UserDOB != value))
			{
				this.OnUserDOBChanging(value);
				this.SendPropertyChanging();
				this._UserDOB = value;
				this.SendPropertyChanged("UserDOB");
				this.OnUserDOBChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserCountry", DbType="VarChar(100)")]
	public string UserCountry
	{
		get
		{
			return this._UserCountry;
		}
		set
		{
			if ((this._UserCountry != value))
			{
				this.OnUserCountryChanging(value);
				this.SendPropertyChanging();
				this._UserCountry = value;
				this.SendPropertyChanged("UserCountry");
				this.OnUserCountryChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserCity", DbType="VarChar(100)")]
	public string UserCity
	{
		get
		{
			return this._UserCity;
		}
		set
		{
			if ((this._UserCity != value))
			{
				this.OnUserCityChanging(value);
				this.SendPropertyChanging();
				this._UserCity = value;
				this.SendPropertyChanged("UserCity");
				this.OnUserCityChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserPhoneNumber", DbType="VarChar(50)")]
	public string UserPhoneNumber
	{
		get
		{
			return this._UserPhoneNumber;
		}
		set
		{
			if ((this._UserPhoneNumber != value))
			{
				this.OnUserPhoneNumberChanging(value);
				this.SendPropertyChanging();
				this._UserPhoneNumber = value;
				this.SendPropertyChanged("UserPhoneNumber");
				this.OnUserPhoneNumberChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserMartialStatus", DbType="VarChar(1)")]
	public string UserMartialStatus
	{
		get
		{
			return this._UserMartialStatus;
		}
		set
		{
			if ((this._UserMartialStatus != value))
			{
				this.OnUserMartialStatusChanging(value);
				this.SendPropertyChanging();
				this._UserMartialStatus = value;
				this.SendPropertyChanged("UserMartialStatus");
				this.OnUserMartialStatusChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserEMail", DbType="VarChar(100)")]
	public string UserEMail
	{
		get
		{
			return this._UserEMail;
		}
		set
		{
			if ((this._UserEMail != value))
			{
				this.OnUserEMailChanging(value);
				this.SendPropertyChanging();
				this._UserEMail = value;
				this.SendPropertyChanged("UserEMail");
				this.OnUserEMailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserSecurityQuestion", DbType="VarChar(1000)")]
	public string UserSecurityQuestion
	{
		get
		{
			return this._UserSecurityQuestion;
		}
		set
		{
			if ((this._UserSecurityQuestion != value))
			{
				this.OnUserSecurityQuestionChanging(value);
				this.SendPropertyChanging();
				this._UserSecurityQuestion = value;
				this.SendPropertyChanged("UserSecurityQuestion");
				this.OnUserSecurityQuestionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserSecurityAnswer", DbType="VarChar(1000)")]
	public string UserSecurityAnswer
	{
		get
		{
			return this._UserSecurityAnswer;
		}
		set
		{
			if ((this._UserSecurityAnswer != value))
			{
				this.OnUserSecurityAnswerChanging(value);
				this.SendPropertyChanging();
				this._UserSecurityAnswer = value;
				this.SendPropertyChanged("UserSecurityAnswer");
				this.OnUserSecurityAnswerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserProfilePicFile", DbType="VarChar(1000)")]
	public string UserProfilePicFile
	{
		get
		{
			return this._UserProfilePicFile;
		}
		set
		{
			if ((this._UserProfilePicFile != value))
			{
				this.OnUserProfilePicFileChanging(value);
				this.SendPropertyChanging();
				this._UserProfilePicFile = value;
				this.SendPropertyChanged("UserProfilePicFile");
				this.OnUserProfilePicFileChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JoiningDateTime", DbType="DateTime")]
	public System.Nullable<System.DateTime> JoiningDateTime
	{
		get
		{
			return this._JoiningDateTime;
		}
		set
		{
			if ((this._JoiningDateTime != value))
			{
				this.OnJoiningDateTimeChanging(value);
				this.SendPropertyChanging();
				this._JoiningDateTime = value;
				this.SendPropertyChanged("JoiningDateTime");
				this.OnJoiningDateTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Notifications", DbType="VarChar(MAX)")]
	public string Notifications
	{
		get
		{
			return this._Notifications;
		}
		set
		{
			if ((this._Notifications != value))
			{
				this.OnNotificationsChanging(value);
				this.SendPropertyChanging();
				this._Notifications = value;
				this.SendPropertyChanged("Notifications");
				this.OnNotificationsChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FileSharingRequests")]
public partial class FileSharingRequest : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ID;
	
	private string _RequestingUser;
	
	private string _RequestedUser;
	
	private string _FileNames_WithExt;
	
	private System.Nullable<char> _Confirmed;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnRequestingUserChanging(string value);
    partial void OnRequestingUserChanged();
    partial void OnRequestedUserChanging(string value);
    partial void OnRequestedUserChanged();
    partial void OnFileNames_WithExtChanging(string value);
    partial void OnFileNames_WithExtChanged();
    partial void OnConfirmedChanging(System.Nullable<char> value);
    partial void OnConfirmedChanged();
    #endregion
	
	public FileSharingRequest()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if ((this._ID != value))
			{
				this.OnIDChanging(value);
				this.SendPropertyChanging();
				this._ID = value;
				this.SendPropertyChanged("ID");
				this.OnIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RequestingUser", DbType="VarChar(50)")]
	public string RequestingUser
	{
		get
		{
			return this._RequestingUser;
		}
		set
		{
			if ((this._RequestingUser != value))
			{
				this.OnRequestingUserChanging(value);
				this.SendPropertyChanging();
				this._RequestingUser = value;
				this.SendPropertyChanged("RequestingUser");
				this.OnRequestingUserChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RequestedUser", DbType="VarChar(50)")]
	public string RequestedUser
	{
		get
		{
			return this._RequestedUser;
		}
		set
		{
			if ((this._RequestedUser != value))
			{
				this.OnRequestedUserChanging(value);
				this.SendPropertyChanging();
				this._RequestedUser = value;
				this.SendPropertyChanged("RequestedUser");
				this.OnRequestedUserChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileNames_WithExt", DbType="VarChar(MAX)")]
	public string FileNames_WithExt
	{
		get
		{
			return this._FileNames_WithExt;
		}
		set
		{
			if ((this._FileNames_WithExt != value))
			{
				this.OnFileNames_WithExtChanging(value);
				this.SendPropertyChanging();
				this._FileNames_WithExt = value;
				this.SendPropertyChanged("FileNames_WithExt");
				this.OnFileNames_WithExtChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Confirmed", DbType="Char(1)")]
	public System.Nullable<char> Confirmed
	{
		get
		{
			return this._Confirmed;
		}
		set
		{
			if ((this._Confirmed != value))
			{
				this.OnConfirmedChanging(value);
				this.SendPropertyChanging();
				this._Confirmed = value;
				this.SendPropertyChanged("Confirmed");
				this.OnConfirmedChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DBFiles")]
public partial class DBFile : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _FileNo;
	
	private string _UploaderUserName;
	
	private string _Category;
	
	private string _Mode;
	
	private string _UploadedFileName;
	
	private string _UploadedFileName_WithExt;
	
	private string _UploadedFileSize;
	
	private System.Nullable<System.DateTime> _UploadDateTime;
	
	private string _SharedWith;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFileNoChanging(int value);
    partial void OnFileNoChanged();
    partial void OnUploaderUserNameChanging(string value);
    partial void OnUploaderUserNameChanged();
    partial void OnCategoryChanging(string value);
    partial void OnCategoryChanged();
    partial void OnModeChanging(string value);
    partial void OnModeChanged();
    partial void OnUploadedFileNameChanging(string value);
    partial void OnUploadedFileNameChanged();
    partial void OnUploadedFileName_WithExtChanging(string value);
    partial void OnUploadedFileName_WithExtChanged();
    partial void OnUploadedFileSizeChanging(string value);
    partial void OnUploadedFileSizeChanged();
    partial void OnUploadDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnUploadDateTimeChanged();
    partial void OnSharedWithChanging(string value);
    partial void OnSharedWithChanged();
    #endregion
	
	public DBFile()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileNo", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int FileNo
	{
		get
		{
			return this._FileNo;
		}
		set
		{
			if ((this._FileNo != value))
			{
				this.OnFileNoChanging(value);
				this.SendPropertyChanging();
				this._FileNo = value;
				this.SendPropertyChanged("FileNo");
				this.OnFileNoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploaderUserName", DbType="VarChar(50)")]
	public string UploaderUserName
	{
		get
		{
			return this._UploaderUserName;
		}
		set
		{
			if ((this._UploaderUserName != value))
			{
				this.OnUploaderUserNameChanging(value);
				this.SendPropertyChanging();
				this._UploaderUserName = value;
				this.SendPropertyChanged("UploaderUserName");
				this.OnUploaderUserNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="VarChar(100)")]
	public string Category
	{
		get
		{
			return this._Category;
		}
		set
		{
			if ((this._Category != value))
			{
				this.OnCategoryChanging(value);
				this.SendPropertyChanging();
				this._Category = value;
				this.SendPropertyChanged("Category");
				this.OnCategoryChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mode", DbType="VarChar(50)")]
	public string Mode
	{
		get
		{
			return this._Mode;
		}
		set
		{
			if ((this._Mode != value))
			{
				this.OnModeChanging(value);
				this.SendPropertyChanging();
				this._Mode = value;
				this.SendPropertyChanged("Mode");
				this.OnModeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadedFileName", DbType="VarChar(2000)")]
	public string UploadedFileName
	{
		get
		{
			return this._UploadedFileName;
		}
		set
		{
			if ((this._UploadedFileName != value))
			{
				this.OnUploadedFileNameChanging(value);
				this.SendPropertyChanging();
				this._UploadedFileName = value;
				this.SendPropertyChanged("UploadedFileName");
				this.OnUploadedFileNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadedFileName_WithExt", DbType="VarChar(2000)")]
	public string UploadedFileName_WithExt
	{
		get
		{
			return this._UploadedFileName_WithExt;
		}
		set
		{
			if ((this._UploadedFileName_WithExt != value))
			{
				this.OnUploadedFileName_WithExtChanging(value);
				this.SendPropertyChanging();
				this._UploadedFileName_WithExt = value;
				this.SendPropertyChanged("UploadedFileName_WithExt");
				this.OnUploadedFileName_WithExtChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadedFileSize", DbType="VarChar(50)")]
	public string UploadedFileSize
	{
		get
		{
			return this._UploadedFileSize;
		}
		set
		{
			if ((this._UploadedFileSize != value))
			{
				this.OnUploadedFileSizeChanging(value);
				this.SendPropertyChanging();
				this._UploadedFileSize = value;
				this.SendPropertyChanged("UploadedFileSize");
				this.OnUploadedFileSizeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadDateTime", DbType="DateTime")]
	public System.Nullable<System.DateTime> UploadDateTime
	{
		get
		{
			return this._UploadDateTime;
		}
		set
		{
			if ((this._UploadDateTime != value))
			{
				this.OnUploadDateTimeChanging(value);
				this.SendPropertyChanging();
				this._UploadDateTime = value;
				this.SendPropertyChanged("UploadDateTime");
				this.OnUploadDateTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SharedWith", DbType="VarChar(800)")]
	public string SharedWith
	{
		get
		{
			return this._SharedWith;
		}
		set
		{
			if ((this._SharedWith != value))
			{
				this.OnSharedWithChanging(value);
				this.SendPropertyChanging();
				this._SharedWith = value;
				this.SendPropertyChanged("SharedWith");
				this.OnSharedWithChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FileSharingGroups")]
public partial class FileSharingGroup : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _GroupID;
	
	private string _GroupName;
	
	private System.Nullable<System.DateTime> _GroupCreationDateTime;
	
	private string _GroupCreator;
	
	private string _GroupMembers;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGroupIDChanging(int value);
    partial void OnGroupIDChanged();
    partial void OnGroupNameChanging(string value);
    partial void OnGroupNameChanged();
    partial void OnGroupCreationDateTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnGroupCreationDateTimeChanged();
    partial void OnGroupCreatorChanging(string value);
    partial void OnGroupCreatorChanged();
    partial void OnGroupMembersChanging(string value);
    partial void OnGroupMembersChanged();
    #endregion
	
	public FileSharingGroup()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupID", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int GroupID
	{
		get
		{
			return this._GroupID;
		}
		set
		{
			if ((this._GroupID != value))
			{
				this.OnGroupIDChanging(value);
				this.SendPropertyChanging();
				this._GroupID = value;
				this.SendPropertyChanged("GroupID");
				this.OnGroupIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupName", DbType="VarChar(50)")]
	public string GroupName
	{
		get
		{
			return this._GroupName;
		}
		set
		{
			if ((this._GroupName != value))
			{
				this.OnGroupNameChanging(value);
				this.SendPropertyChanging();
				this._GroupName = value;
				this.SendPropertyChanged("GroupName");
				this.OnGroupNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupCreationDateTime", DbType="DateTime")]
	public System.Nullable<System.DateTime> GroupCreationDateTime
	{
		get
		{
			return this._GroupCreationDateTime;
		}
		set
		{
			if ((this._GroupCreationDateTime != value))
			{
				this.OnGroupCreationDateTimeChanging(value);
				this.SendPropertyChanging();
				this._GroupCreationDateTime = value;
				this.SendPropertyChanged("GroupCreationDateTime");
				this.OnGroupCreationDateTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupCreator", DbType="VarChar(50)")]
	public string GroupCreator
	{
		get
		{
			return this._GroupCreator;
		}
		set
		{
			if ((this._GroupCreator != value))
			{
				this.OnGroupCreatorChanging(value);
				this.SendPropertyChanging();
				this._GroupCreator = value;
				this.SendPropertyChanged("GroupCreator");
				this.OnGroupCreatorChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GroupMembers", DbType="VarChar(MAX)")]
	public string GroupMembers
	{
		get
		{
			return this._GroupMembers;
		}
		set
		{
			if ((this._GroupMembers != value))
			{
				this.OnGroupMembersChanging(value);
				this.SendPropertyChanging();
				this._GroupMembers = value;
				this.SendPropertyChanged("GroupMembers");
				this.OnGroupMembersChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
