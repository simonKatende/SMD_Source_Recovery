using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.DataSet_Previews.StudentPreviewSourceTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class StudentPreviewSourceTableAdapter : Component
{
	private SqlDataAdapter _adapter;

	private SqlConnection _connection;

	private SqlTransaction _transaction;

	private SqlCommand[] _commandCollection;

	private bool _clearBeforeFill;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected internal SqlDataAdapter Adapter
	{
		get
		{
			if (_adapter == null)
			{
				InitAdapter();
			}
			return _adapter;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	internal SqlConnection Connection
	{
		get
		{
			if (_connection == null)
			{
				InitConnection();
			}
			return _connection;
		}
		set
		{
			_connection = value;
			if (Adapter.InsertCommand != null)
			{
				Adapter.InsertCommand.Connection = value;
			}
			if (Adapter.DeleteCommand != null)
			{
				Adapter.DeleteCommand.Connection = value;
			}
			if (Adapter.UpdateCommand != null)
			{
				Adapter.UpdateCommand.Connection = value;
			}
			for (int i = 0; i < CommandCollection.Length; i++)
			{
				if (CommandCollection[i] != null)
				{
					CommandCollection[i].Connection = value;
				}
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	internal SqlTransaction Transaction
	{
		get
		{
			return _transaction;
		}
		set
		{
			_transaction = value;
			for (int i = 0; i < CommandCollection.Length; i++)
			{
				CommandCollection[i].Transaction = _transaction;
			}
			if (Adapter != null && Adapter.DeleteCommand != null)
			{
				Adapter.DeleteCommand.Transaction = _transaction;
			}
			if (Adapter != null && Adapter.InsertCommand != null)
			{
				Adapter.InsertCommand.Transaction = _transaction;
			}
			if (Adapter != null && Adapter.UpdateCommand != null)
			{
				Adapter.UpdateCommand.Transaction = _transaction;
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected SqlCommand[] CommandCollection
	{
		get
		{
			if (_commandCollection == null)
			{
				InitCommandCollection();
			}
			return _commandCollection;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public bool ClearBeforeFill
	{
		get
		{
			return _clearBeforeFill;
		}
		set
		{
			_clearBeforeFill = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public StudentPreviewSourceTableAdapter()
	{
		ClearBeforeFill = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitAdapter()
	{
		_adapter = new SqlDataAdapter();
		DataTableMapping dataTableMapping = new DataTableMapping();
		dataTableMapping.SourceTable = "Table";
		dataTableMapping.DataSetTable = "StudentPreviewSource";
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("auto", "auto");
		dataTableMapping.ColumnMappings.Add("Oid", "Oid");
		dataTableMapping.ColumnMappings.Add("StudentID", "StudentID");
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("fullNameAr", "fullNameAr");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("ClassIdEn", "ClassIdEn");
		dataTableMapping.ColumnMappings.Add("ClassIdAr", "ClassIdAr");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("StreamAr", "StreamAr");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("StudyStatus", "StudyStatus");
		dataTableMapping.ColumnMappings.Add("HouseId", "HouseId");
		dataTableMapping.ColumnMappings.Add("Religion", "Religion");
		dataTableMapping.ColumnMappings.Add("Guardian", "Guardian");
		dataTableMapping.ColumnMappings.Add("FormerSchool", "FormerSchool");
		dataTableMapping.ColumnMappings.Add("BursaryStatus", "BursaryStatus");
		dataTableMapping.ColumnMappings.Add("BursaryProvider", "BursaryProvider");
		dataTableMapping.ColumnMappings.Add("AdmissionDate", "AdmissionDate");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("HomeCountry", "HomeCountry");
		dataTableMapping.ColumnMappings.Add("Status", "Status");
		dataTableMapping.ColumnMappings.Add("Notes", "Notes");
		dataTableMapping.ColumnMappings.Add("RequiredFees", "RequiredFees");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		dataTableMapping.ColumnMappings.Add("FeesDiscount", "FeesDiscount");
		dataTableMapping.ColumnMappings.Add("vID", "vID");
		dataTableMapping.ColumnMappings.Add("tagged", "tagged");
		dataTableMapping.ColumnMappings.Add("Comb", "Comb");
		dataTableMapping.ColumnMappings.Add("SubjectString", "SubjectString");
		dataTableMapping.ColumnMappings.Add("fName", "fName");
		dataTableMapping.ColumnMappings.Add("fAddress", "fAddress");
		dataTableMapping.ColumnMappings.Add("fContact", "fContact");
		dataTableMapping.ColumnMappings.Add("fEmail", "fEmail");
		dataTableMapping.ColumnMappings.Add("mName", "mName");
		dataTableMapping.ColumnMappings.Add("mAddress", "mAddress");
		dataTableMapping.ColumnMappings.Add("mContact", "mContact");
		dataTableMapping.ColumnMappings.Add("mEmail", "mEmail");
		dataTableMapping.ColumnMappings.Add("DOB", "DOB");
		dataTableMapping.ColumnMappings.Add("IsTheologyStud", "IsTheologyStud");
		dataTableMapping.ColumnMappings.Add("PrimaryScores1", "PrimaryScores1");
		dataTableMapping.ColumnMappings.Add("PrimaryScores2", "PrimaryScores2");
		dataTableMapping.ColumnMappings.Add("PrimaryScores3", "PrimaryScores3");
		dataTableMapping.ColumnMappings.Add("IsSynched", "IsSynched");
		dataTableMapping.ColumnMappings.Add("Sponsor", "Sponsor");
		dataTableMapping.ColumnMappings.Add("SponsorContact", "SponsorContact");
		dataTableMapping.ColumnMappings.Add("mNIN", "mNIN");
		dataTableMapping.ColumnMappings.Add("fNIN", "fNIN");
		dataTableMapping.ColumnMappings.Add("sNIN", "sNIN");
		dataTableMapping.ColumnMappings.Add("PriorityContact", "PriorityContact");
		dataTableMapping.ColumnMappings.Add("OtherContact", "OtherContact");
		dataTableMapping.ColumnMappings.Add("GuardianAddress", "GuardianAddress");
		dataTableMapping.ColumnMappings.Add("Email", "Email");
		dataTableMapping.ColumnMappings.Add("GamesAndSports", "GamesAndSports");
		dataTableMapping.ColumnMappings.Add("Clubs", "Clubs");
		dataTableMapping.ColumnMappings.Add("StreamEn", "StreamEn");
		dataTableMapping.ColumnMappings.Add("SexAr", "SexAr");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_Stud] WHERE (([StudentNumber] = @Original_StudentNumber) AND ([auto] = @Original_auto) AND ([Oid] = @Original_Oid) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_fullNameAr = 1 AND [fullNameAr] IS NULL) OR ([fullNameAr] = @Original_fullNameAr)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_ClassIdEn = 1 AND [ClassIdEn] IS NULL) OR ([ClassIdEn] = @Original_ClassIdEn)) AND ((@IsNull_ClassIdAr = 1 AND [ClassIdAr] IS NULL) OR ([ClassIdAr] = @Original_ClassIdAr)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_StreamAr = 1 AND [StreamAr] IS NULL) OR ([StreamAr] = @Original_StreamAr)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_Religion = 1 AND [Religion] IS NULL) OR ([Religion] = @Original_Religion)) AND ((@IsNull_Guardian = 1 AND [Guardian] IS NULL) OR ([Guardian] = @Original_Guardian)) AND ((@IsNull_FormerSchool = 1 AND [FormerSchool] IS NULL) OR ([FormerSchool] = @Original_FormerSchool)) AND ((@IsNull_BursaryStatus = 1 AND [BursaryStatus] IS NULL) OR ([BursaryStatus] = @Original_BursaryStatus)) AND ((@IsNull_BursaryProvider = 1 AND [BursaryProvider] IS NULL) OR ([BursaryProvider] = @Original_BursaryProvider)) AND ((@IsNull_AdmissionDate = 1 AND [AdmissionDate] IS NULL) OR ([AdmissionDate] = @Original_AdmissionDate)) AND ((@IsNull_HomeCountry = 1 AND [HomeCountry] IS NULL) OR ([HomeCountry] = @Original_HomeCountry)) AND ((@IsNull_Status = 1 AND [Status] IS NULL) OR ([Status] = @Original_Status)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)) AND ((@IsNull_vID = 1 AND [vID] IS NULL) OR ([vID] = @Original_vID)) AND ((@IsNull_tagged = 1 AND [tagged] IS NULL) OR ([tagged] = @Original_tagged)) AND ((@IsNull_Comb = 1 AND [Comb] IS NULL) OR ([Comb] = @Original_Comb)) AND ((@IsNull_SubjectString = 1 AND [SubjectString] IS NULL) OR ([SubjectString] = @Original_SubjectString)) AND ((@IsNull_fName = 1 AND [fName] IS NULL) OR ([fName] = @Original_fName)) AND ((@IsNull_fAddress = 1 AND [fAddress] IS NULL) OR ([fAddress] = @Original_fAddress)) AND ((@IsNull_fContact = 1 AND [fContact] IS NULL) OR ([fContact] = @Original_fContact)) AND ((@IsNull_fEmail = 1 AND [fEmail] IS NULL) OR ([fEmail] = @Original_fEmail)) AND ((@IsNull_mName = 1 AND [mName] IS NULL) OR ([mName] = @Original_mName)) AND ((@IsNull_mAddress = 1 AND [mAddress] IS NULL) OR ([mAddress] = @Original_mAddress)) AND ((@IsNull_mContact = 1 AND [mContact] IS NULL) OR ([mContact] = @Original_mContact)) AND ((@IsNull_mEmail = 1 AND [mEmail] IS NULL) OR ([mEmail] = @Original_mEmail)) AND ((@IsNull_DOB = 1 AND [DOB] IS NULL) OR ([DOB] = @Original_DOB)) AND ((@IsNull_IsTheologyStud = 1 AND [IsTheologyStud] IS NULL) OR ([IsTheologyStud] = @Original_IsTheologyStud)) AND ((@IsNull_PrimaryScores1 = 1 AND [PrimaryScores1] IS NULL) OR ([PrimaryScores1] = @Original_PrimaryScores1)) AND ((@IsNull_PrimaryScores2 = 1 AND [PrimaryScores2] IS NULL) OR ([PrimaryScores2] = @Original_PrimaryScores2)) AND ((@IsNull_PrimaryScores3 = 1 AND [PrimaryScores3] IS NULL) OR ([PrimaryScores3] = @Original_PrimaryScores3)) AND ((@IsNull_IsSynched = 1 AND [IsSynched] IS NULL) OR ([IsSynched] = @Original_IsSynched)) AND ((@IsNull_Sponsor = 1 AND [Sponsor] IS NULL) OR ([Sponsor] = @Original_Sponsor)) AND ((@IsNull_SponsorContact = 1 AND [SponsorContact] IS NULL) OR ([SponsorContact] = @Original_SponsorContact)) AND ((@IsNull_mNIN = 1 AND [mNIN] IS NULL) OR ([mNIN] = @Original_mNIN)) AND ((@IsNull_fNIN = 1 AND [fNIN] IS NULL) OR ([fNIN] = @Original_fNIN)) AND ((@IsNull_sNIN = 1 AND [sNIN] IS NULL) OR ([sNIN] = @Original_sNIN)) AND ((@IsNull_PriorityContact = 1 AND [PriorityContact] IS NULL) OR ([PriorityContact] = @Original_PriorityContact)) AND ((@IsNull_OtherContact = 1 AND [OtherContact] IS NULL) OR ([OtherContact] = @Original_OtherContact)) AND ((@IsNull_GuardianAddress = 1 AND [GuardianAddress] IS NULL) OR ([GuardianAddress] = @Original_GuardianAddress)) AND ((@IsNull_Email = 1 AND [Email] IS NULL) OR ([Email] = @Original_Email)) AND ((@IsNull_GamesAndSports = 1 AND [GamesAndSports] IS NULL) OR ([GamesAndSports] = @Original_GamesAndSports)) AND ((@IsNull_Clubs = 1 AND [Clubs] IS NULL) OR ([Clubs] = @Original_Clubs)) AND ((@IsNull_StreamEn = 1 AND [StreamEn] IS NULL) OR ([StreamEn] = @Original_StreamEn)) AND ((@IsNull_SexAr = 1 AND [SexAr] IS NULL) OR ([SexAr] = @Original_SexAr)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fullNameAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fullNameAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassIdEn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassIdEn", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassIdAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassIdAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudyStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HouseId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Religion", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Religion", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Guardian", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FormerSchool", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FormerSchool", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryProvider", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_AdmissionDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HomeCountry", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_vID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "vID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_vID", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "vID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_tagged", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "tagged", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_tagged", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "tagged", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comb", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comb", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comb", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comb", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectString", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectString", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubjectString", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectString", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "fContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fEmail", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fEmail", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fEmail", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_mName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_mName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_mAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_mAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_mContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_mContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "mContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_mEmail", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mEmail", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_mEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mEmail", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_DOB", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DOB", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DOB", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DOB", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_IsTheologyStud", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PrimaryScores1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PrimaryScores1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PrimaryScores1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PrimaryScores2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PrimaryScores2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PrimaryScores2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PrimaryScores3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PrimaryScores3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PrimaryScores3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_IsSynched", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsSynched", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsSynched", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsSynched", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sponsor", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sponsor", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sponsor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sponsor", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SponsorContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SponsorContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SponsorContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SponsorContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_mNIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mNIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_mNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "mNIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fNIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fNIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fNIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_sNIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "sNIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_sNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "sNIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PriorityContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PriorityContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PriorityContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PriorityContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OtherContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OtherContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_GuardianAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GuardianAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GuardianAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GuardianAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Email", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Email", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Email", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Email", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_GamesAndSports", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GamesAndSports", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GamesAndSports", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GamesAndSports", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Clubs", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Clubs", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Clubs", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Clubs", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamEn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SexAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_Stud] ([StudentNumber], [Oid], [StudentID], [fullName], [fullNameAr], [ClassId], [ClassIdEn], [ClassIdAr], [StreamId], [StreamAr], [Sex], [StudyStatus], [HouseId], [Religion], [Guardian], [FormerSchool], [BursaryStatus], [BursaryProvider], [AdmissionDate], [Picture], [HomeCountry], [Status], [Notes], [RequiredFees], [cashOnAccount], [FeesDiscount], [vID], [tagged], [Comb], [SubjectString], [fName], [fAddress], [fContact], [fEmail], [mName], [mAddress], [mContact], [mEmail], [DOB], [IsTheologyStud], [PrimaryScores1], [PrimaryScores2], [PrimaryScores3], [IsSynched], [Sponsor], [SponsorContact], [mNIN], [fNIN], [sNIN], [PriorityContact], [OtherContact], [GuardianAddress], [Email], [GamesAndSports], [Clubs], [StreamEn], [SexAr]) VALUES (@StudentNumber, @Oid, @StudentID, @fullName, @fullNameAr, @ClassId, @ClassIdEn, @ClassIdAr, @StreamId, @StreamAr, @Sex, @StudyStatus, @HouseId, @Religion, @Guardian, @FormerSchool, @BursaryStatus, @BursaryProvider, @AdmissionDate, @Picture, @HomeCountry, @Status, @Notes, @RequiredFees, @cashOnAccount, @FeesDiscount, @vID, @tagged, @Comb, @SubjectString, @fName, @fAddress, @fContact, @fEmail, @mName, @mAddress, @mContact, @mEmail, @DOB, @IsTheologyStud, @PrimaryScores1, @PrimaryScores2, @PrimaryScores3, @IsSynched, @Sponsor, @SponsorContact, @mNIN, @fNIN, @sNIN, @PriorityContact, @OtherContact, @GuardianAddress, @Email, @GamesAndSports, @Clubs, @StreamEn, @SexAr);\r\nSELECT StudentNumber, auto, Oid, StudentID, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, RequiredFees, cashOnAccount, FeesDiscount, vID, tagged, Comb, SubjectString, fName, fAddress, fContact, fEmail, mName, mAddress, mContact, mEmail, DOB, IsTheologyStud, PrimaryScores1, PrimaryScores2, PrimaryScores3, IsSynched, Sponsor, SponsorContact, mNIN, fNIN, sNIN, PriorityContact, OtherContact, GuardianAddress, Email, GamesAndSports, Clubs, StreamEn, SexAr FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullNameAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassIdEn", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassIdAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FormerSchool", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@vID", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "vID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@tagged", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "tagged", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comb", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comb", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubjectString", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectString", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "fContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fEmail", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@mName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@mAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@mContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "mContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@mEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mEmail", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@DOB", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DOB", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PrimaryScores1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PrimaryScores2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PrimaryScores3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsSynched", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsSynched", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sponsor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sponsor", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SponsorContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SponsorContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@mNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "mNIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fNIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@sNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "sNIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PriorityContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PriorityContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OtherContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@GuardianAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GuardianAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Email", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@GamesAndSports", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GamesAndSports", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Clubs", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Clubs", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_Stud] SET [StudentNumber] = @StudentNumber, [Oid] = @Oid, [StudentID] = @StudentID, [fullName] = @fullName, [fullNameAr] = @fullNameAr, [ClassId] = @ClassId, [ClassIdEn] = @ClassIdEn, [ClassIdAr] = @ClassIdAr, [StreamId] = @StreamId, [StreamAr] = @StreamAr, [Sex] = @Sex, [StudyStatus] = @StudyStatus, [HouseId] = @HouseId, [Religion] = @Religion, [Guardian] = @Guardian, [FormerSchool] = @FormerSchool, [BursaryStatus] = @BursaryStatus, [BursaryProvider] = @BursaryProvider, [AdmissionDate] = @AdmissionDate, [Picture] = @Picture, [HomeCountry] = @HomeCountry, [Status] = @Status, [Notes] = @Notes, [RequiredFees] = @RequiredFees, [cashOnAccount] = @cashOnAccount, [FeesDiscount] = @FeesDiscount, [vID] = @vID, [tagged] = @tagged, [Comb] = @Comb, [SubjectString] = @SubjectString, [fName] = @fName, [fAddress] = @fAddress, [fContact] = @fContact, [fEmail] = @fEmail, [mName] = @mName, [mAddress] = @mAddress, [mContact] = @mContact, [mEmail] = @mEmail, [DOB] = @DOB, [IsTheologyStud] = @IsTheologyStud, [PrimaryScores1] = @PrimaryScores1, [PrimaryScores2] = @PrimaryScores2, [PrimaryScores3] = @PrimaryScores3, [IsSynched] = @IsSynched, [Sponsor] = @Sponsor, [SponsorContact] = @SponsorContact, [mNIN] = @mNIN, [fNIN] = @fNIN, [sNIN] = @sNIN, [PriorityContact] = @PriorityContact, [OtherContact] = @OtherContact, [GuardianAddress] = @GuardianAddress, [Email] = @Email, [GamesAndSports] = @GamesAndSports, [Clubs] = @Clubs, [StreamEn] = @StreamEn, [SexAr] = @SexAr WHERE (([StudentNumber] = @Original_StudentNumber) AND ([auto] = @Original_auto) AND ([Oid] = @Original_Oid) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_fullNameAr = 1 AND [fullNameAr] IS NULL) OR ([fullNameAr] = @Original_fullNameAr)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_ClassIdEn = 1 AND [ClassIdEn] IS NULL) OR ([ClassIdEn] = @Original_ClassIdEn)) AND ((@IsNull_ClassIdAr = 1 AND [ClassIdAr] IS NULL) OR ([ClassIdAr] = @Original_ClassIdAr)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_StreamAr = 1 AND [StreamAr] IS NULL) OR ([StreamAr] = @Original_StreamAr)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_Religion = 1 AND [Religion] IS NULL) OR ([Religion] = @Original_Religion)) AND ((@IsNull_Guardian = 1 AND [Guardian] IS NULL) OR ([Guardian] = @Original_Guardian)) AND ((@IsNull_FormerSchool = 1 AND [FormerSchool] IS NULL) OR ([FormerSchool] = @Original_FormerSchool)) AND ((@IsNull_BursaryStatus = 1 AND [BursaryStatus] IS NULL) OR ([BursaryStatus] = @Original_BursaryStatus)) AND ((@IsNull_BursaryProvider = 1 AND [BursaryProvider] IS NULL) OR ([BursaryProvider] = @Original_BursaryProvider)) AND ((@IsNull_AdmissionDate = 1 AND [AdmissionDate] IS NULL) OR ([AdmissionDate] = @Original_AdmissionDate)) AND ((@IsNull_HomeCountry = 1 AND [HomeCountry] IS NULL) OR ([HomeCountry] = @Original_HomeCountry)) AND ((@IsNull_Status = 1 AND [Status] IS NULL) OR ([Status] = @Original_Status)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)) AND ((@IsNull_vID = 1 AND [vID] IS NULL) OR ([vID] = @Original_vID)) AND ((@IsNull_tagged = 1 AND [tagged] IS NULL) OR ([tagged] = @Original_tagged)) AND ((@IsNull_Comb = 1 AND [Comb] IS NULL) OR ([Comb] = @Original_Comb)) AND ((@IsNull_SubjectString = 1 AND [SubjectString] IS NULL) OR ([SubjectString] = @Original_SubjectString)) AND ((@IsNull_fName = 1 AND [fName] IS NULL) OR ([fName] = @Original_fName)) AND ((@IsNull_fAddress = 1 AND [fAddress] IS NULL) OR ([fAddress] = @Original_fAddress)) AND ((@IsNull_fContact = 1 AND [fContact] IS NULL) OR ([fContact] = @Original_fContact)) AND ((@IsNull_fEmail = 1 AND [fEmail] IS NULL) OR ([fEmail] = @Original_fEmail)) AND ((@IsNull_mName = 1 AND [mName] IS NULL) OR ([mName] = @Original_mName)) AND ((@IsNull_mAddress = 1 AND [mAddress] IS NULL) OR ([mAddress] = @Original_mAddress)) AND ((@IsNull_mContact = 1 AND [mContact] IS NULL) OR ([mContact] = @Original_mContact)) AND ((@IsNull_mEmail = 1 AND [mEmail] IS NULL) OR ([mEmail] = @Original_mEmail)) AND ((@IsNull_DOB = 1 AND [DOB] IS NULL) OR ([DOB] = @Original_DOB)) AND ((@IsNull_IsTheologyStud = 1 AND [IsTheologyStud] IS NULL) OR ([IsTheologyStud] = @Original_IsTheologyStud)) AND ((@IsNull_PrimaryScores1 = 1 AND [PrimaryScores1] IS NULL) OR ([PrimaryScores1] = @Original_PrimaryScores1)) AND ((@IsNull_PrimaryScores2 = 1 AND [PrimaryScores2] IS NULL) OR ([PrimaryScores2] = @Original_PrimaryScores2)) AND ((@IsNull_PrimaryScores3 = 1 AND [PrimaryScores3] IS NULL) OR ([PrimaryScores3] = @Original_PrimaryScores3)) AND ((@IsNull_IsSynched = 1 AND [IsSynched] IS NULL) OR ([IsSynched] = @Original_IsSynched)) AND ((@IsNull_Sponsor = 1 AND [Sponsor] IS NULL) OR ([Sponsor] = @Original_Sponsor)) AND ((@IsNull_SponsorContact = 1 AND [SponsorContact] IS NULL) OR ([SponsorContact] = @Original_SponsorContact)) AND ((@IsNull_mNIN = 1 AND [mNIN] IS NULL) OR ([mNIN] = @Original_mNIN)) AND ((@IsNull_fNIN = 1 AND [fNIN] IS NULL) OR ([fNIN] = @Original_fNIN)) AND ((@IsNull_sNIN = 1 AND [sNIN] IS NULL) OR ([sNIN] = @Original_sNIN)) AND ((@IsNull_PriorityContact = 1 AND [PriorityContact] IS NULL) OR ([PriorityContact] = @Original_PriorityContact)) AND ((@IsNull_OtherContact = 1 AND [OtherContact] IS NULL) OR ([OtherContact] = @Original_OtherContact)) AND ((@IsNull_GuardianAddress = 1 AND [GuardianAddress] IS NULL) OR ([GuardianAddress] = @Original_GuardianAddress)) AND ((@IsNull_Email = 1 AND [Email] IS NULL) OR ([Email] = @Original_Email)) AND ((@IsNull_GamesAndSports = 1 AND [GamesAndSports] IS NULL) OR ([GamesAndSports] = @Original_GamesAndSports)) AND ((@IsNull_Clubs = 1 AND [Clubs] IS NULL) OR ([Clubs] = @Original_Clubs)) AND ((@IsNull_StreamEn = 1 AND [StreamEn] IS NULL) OR ([StreamEn] = @Original_StreamEn)) AND ((@IsNull_SexAr = 1 AND [SexAr] IS NULL) OR ([SexAr] = @Original_SexAr)));\r\nSELECT StudentNumber, auto, Oid, StudentID, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, RequiredFees, cashOnAccount, FeesDiscount, vID, tagged, Comb, SubjectString, fName, fAddress, fContact, fEmail, mName, mAddress, mContact, mEmail, DOB, IsTheologyStud, PrimaryScores1, PrimaryScores2, PrimaryScores3, IsSynched, Sponsor, SponsorContact, mNIN, fNIN, sNIN, PriorityContact, OtherContact, GuardianAddress, Email, GamesAndSports, Clubs, StreamEn, SexAr FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = @auto)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullNameAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassIdEn", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassIdAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FormerSchool", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@vID", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "vID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@tagged", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "tagged", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comb", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comb", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubjectString", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectString", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "fContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fEmail", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "mContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mEmail", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DOB", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DOB", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PrimaryScores1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PrimaryScores2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PrimaryScores3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsSynched", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsSynched", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sponsor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sponsor", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SponsorContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SponsorContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "mNIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fNIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@sNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "sNIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PriorityContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PriorityContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OtherContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GuardianAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GuardianAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Email", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GamesAndSports", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GamesAndSports", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Clubs", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Clubs", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fullNameAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fullNameAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassIdEn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassIdEn", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassIdAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassIdAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudyStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HouseId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Religion", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Religion", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Guardian", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FormerSchool", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FormerSchool", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryProvider", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_AdmissionDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HomeCountry", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_vID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "vID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_vID", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "vID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_tagged", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "tagged", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_tagged", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "tagged", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comb", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comb", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comb", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comb", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectString", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectString", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubjectString", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectString", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "fContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fEmail", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fEmail", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fEmail", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_mName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_mName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_mAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_mAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_mContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_mContact", SqlDbType.Char, 0, ParameterDirection.Input, 0, 0, "mContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_mEmail", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mEmail", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_mEmail", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mEmail", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_DOB", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DOB", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DOB", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DOB", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_IsTheologyStud", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PrimaryScores1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PrimaryScores1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PrimaryScores1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PrimaryScores2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PrimaryScores2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PrimaryScores2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PrimaryScores3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PrimaryScores3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PrimaryScores3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PrimaryScores3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_IsSynched", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsSynched", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsSynched", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsSynched", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sponsor", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sponsor", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sponsor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sponsor", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SponsorContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SponsorContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SponsorContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SponsorContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_mNIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mNIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_mNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "mNIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fNIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fNIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fNIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_sNIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "sNIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_sNIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "sNIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PriorityContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PriorityContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PriorityContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PriorityContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OtherContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OtherContact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_GuardianAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GuardianAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GuardianAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GuardianAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Email", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Email", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Email", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Email", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_GamesAndSports", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GamesAndSports", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GamesAndSports", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "GamesAndSports", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Clubs", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Clubs", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Clubs", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Clubs", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamEn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SexAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@auto", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitConnection()
	{
		_connection = new SqlConnection();
		_connection.ConnectionString = DataConnection.ConnectToDatabase();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitCommandCollection()
	{
		_commandCollection = new SqlCommand[1];
		_commandCollection[0] = new SqlCommand();
		_commandCollection[0].Connection = Connection;
		_commandCollection[0].CommandText = $"SELECT  StudentNumber, auto, Oid, StudentID, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, BursaryProvider, AdmissionDate, \r\n                         Picture, HomeCountry, Status, Notes, RequiredFees, cashOnAccount, FeesDiscount, vID, tagged, Comb, SubjectString, fName, fAddress, fContact, fEmail, mName, mAddress, mContact, mEmail, DOB, IsTheologyStud, \r\n                         PrimaryScores1, PrimaryScores2, PrimaryScores3, IsSynched, Sponsor, SponsorContact, mNIN, fNIN, sNIN, PriorityContact, OtherContact, GuardianAddress, Email, GamesAndSports, Clubs, StreamEn, SexAr\r\nFROM            tbl_Stud\r\nWHERE        (StudentNumber = '{StudentOptions.ActiveStudent()}')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(StudentPreviewSource.StudentPreviewSourceDataTable dataTable)
	{
		Adapter.SelectCommand = CommandCollection[0];
		if (ClearBeforeFill)
		{
			dataTable.Clear();
		}
		return Adapter.Fill(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	public virtual StudentPreviewSource.StudentPreviewSourceDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		StudentPreviewSource.StudentPreviewSourceDataTable studentPreviewSourceDataTable = new StudentPreviewSource.StudentPreviewSourceDataTable();
		Adapter.Fill(studentPreviewSourceDataTable);
		return studentPreviewSourceDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(StudentPreviewSource.StudentPreviewSourceDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(StudentPreviewSource dataSet)
	{
		return Adapter.Update(dataSet, "StudentPreviewSource");
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(DataRow dataRow)
	{
		return Adapter.Update(new DataRow[1] { dataRow });
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(DataRow[] dataRows)
	{
		return Adapter.Update(dataRows);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	public virtual int Delete(string Original_StudentNumber, long Original_auto, Guid Original_Oid, string Original_StudentID, string Original_fullName, string Original_fullNameAr, string Original_ClassId, string Original_ClassIdEn, string Original_ClassIdAr, string Original_StreamId, string Original_StreamAr, string Original_Sex, string Original_StudyStatus, string Original_HouseId, string Original_Religion, string Original_Guardian, string Original_FormerSchool, bool? Original_BursaryStatus, string Original_BursaryProvider, string Original_AdmissionDate, string Original_HomeCountry, string Original_Status, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, bool? Original_vID, bool? Original_tagged, string Original_Comb, string Original_SubjectString, string Original_fName, string Original_fAddress, string Original_fContact, string Original_fEmail, string Original_mName, string Original_mAddress, string Original_mContact, string Original_mEmail, DateTime? Original_DOB, bool? Original_IsTheologyStud, string Original_PrimaryScores1, string Original_PrimaryScores2, string Original_PrimaryScores3, bool? Original_IsSynched, string Original_Sponsor, string Original_SponsorContact, string Original_mNIN, string Original_fNIN, string Original_sNIN, string Original_PriorityContact, string Original_OtherContact, string Original_GuardianAddress, string Original_Email, string Original_GamesAndSports, string Original_Clubs, string Original_StreamEn, string Original_SexAr)
	{
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.DeleteCommand.Parameters[0].Value = Original_StudentNumber;
		Adapter.DeleteCommand.Parameters[1].Value = Original_auto;
		Adapter.DeleteCommand.Parameters[2].Value = Original_Oid;
		if (Original_StudentID == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_StudentID;
		}
		if (Original_fullName == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_fullName;
		}
		if (Original_fullNameAr == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_fullNameAr;
		}
		if (Original_ClassId == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_ClassId;
		}
		if (Original_ClassIdEn == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_ClassIdEn;
		}
		if (Original_ClassIdAr == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_ClassIdAr;
		}
		if (Original_StreamId == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_StreamId;
		}
		if (Original_StreamAr == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_StreamAr;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_Sex;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_StudyStatus;
		}
		if (Original_HouseId == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_HouseId;
		}
		if (Original_Religion == null)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_Religion;
		}
		if (Original_Guardian == null)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_Guardian;
		}
		if (Original_FormerSchool == null)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_FormerSchool;
		}
		if (Original_BursaryStatus.HasValue)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_BursaryStatus.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		if (Original_BursaryProvider == null)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_BursaryProvider;
		}
		if (Original_AdmissionDate == null)
		{
			Adapter.DeleteCommand.Parameters[35].Value = 1;
			Adapter.DeleteCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[35].Value = 0;
			Adapter.DeleteCommand.Parameters[36].Value = Original_AdmissionDate;
		}
		if (Original_HomeCountry == null)
		{
			Adapter.DeleteCommand.Parameters[37].Value = 1;
			Adapter.DeleteCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[37].Value = 0;
			Adapter.DeleteCommand.Parameters[38].Value = Original_HomeCountry;
		}
		if (Original_Status == null)
		{
			Adapter.DeleteCommand.Parameters[39].Value = 1;
			Adapter.DeleteCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[39].Value = 0;
			Adapter.DeleteCommand.Parameters[40].Value = Original_Status;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.DeleteCommand.Parameters[41].Value = 0;
			Adapter.DeleteCommand.Parameters[42].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[41].Value = 1;
			Adapter.DeleteCommand.Parameters[42].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[43].Value = 0;
			Adapter.DeleteCommand.Parameters[44].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[43].Value = 1;
			Adapter.DeleteCommand.Parameters[44].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[45].Value = 0;
			Adapter.DeleteCommand.Parameters[46].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[45].Value = 1;
			Adapter.DeleteCommand.Parameters[46].Value = DBNull.Value;
		}
		if (Original_vID.HasValue)
		{
			Adapter.DeleteCommand.Parameters[47].Value = 0;
			Adapter.DeleteCommand.Parameters[48].Value = Original_vID.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[47].Value = 1;
			Adapter.DeleteCommand.Parameters[48].Value = DBNull.Value;
		}
		if (Original_tagged.HasValue)
		{
			Adapter.DeleteCommand.Parameters[49].Value = 0;
			Adapter.DeleteCommand.Parameters[50].Value = Original_tagged.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[49].Value = 1;
			Adapter.DeleteCommand.Parameters[50].Value = DBNull.Value;
		}
		if (Original_Comb == null)
		{
			Adapter.DeleteCommand.Parameters[51].Value = 1;
			Adapter.DeleteCommand.Parameters[52].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[51].Value = 0;
			Adapter.DeleteCommand.Parameters[52].Value = Original_Comb;
		}
		if (Original_SubjectString == null)
		{
			Adapter.DeleteCommand.Parameters[53].Value = 1;
			Adapter.DeleteCommand.Parameters[54].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[53].Value = 0;
			Adapter.DeleteCommand.Parameters[54].Value = Original_SubjectString;
		}
		if (Original_fName == null)
		{
			Adapter.DeleteCommand.Parameters[55].Value = 1;
			Adapter.DeleteCommand.Parameters[56].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[55].Value = 0;
			Adapter.DeleteCommand.Parameters[56].Value = Original_fName;
		}
		if (Original_fAddress == null)
		{
			Adapter.DeleteCommand.Parameters[57].Value = 1;
			Adapter.DeleteCommand.Parameters[58].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[57].Value = 0;
			Adapter.DeleteCommand.Parameters[58].Value = Original_fAddress;
		}
		if (Original_fContact == null)
		{
			Adapter.DeleteCommand.Parameters[59].Value = 1;
			Adapter.DeleteCommand.Parameters[60].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[59].Value = 0;
			Adapter.DeleteCommand.Parameters[60].Value = Original_fContact;
		}
		if (Original_fEmail == null)
		{
			Adapter.DeleteCommand.Parameters[61].Value = 1;
			Adapter.DeleteCommand.Parameters[62].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[61].Value = 0;
			Adapter.DeleteCommand.Parameters[62].Value = Original_fEmail;
		}
		if (Original_mName == null)
		{
			Adapter.DeleteCommand.Parameters[63].Value = 1;
			Adapter.DeleteCommand.Parameters[64].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[63].Value = 0;
			Adapter.DeleteCommand.Parameters[64].Value = Original_mName;
		}
		if (Original_mAddress == null)
		{
			Adapter.DeleteCommand.Parameters[65].Value = 1;
			Adapter.DeleteCommand.Parameters[66].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[65].Value = 0;
			Adapter.DeleteCommand.Parameters[66].Value = Original_mAddress;
		}
		if (Original_mContact == null)
		{
			Adapter.DeleteCommand.Parameters[67].Value = 1;
			Adapter.DeleteCommand.Parameters[68].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[67].Value = 0;
			Adapter.DeleteCommand.Parameters[68].Value = Original_mContact;
		}
		if (Original_mEmail == null)
		{
			Adapter.DeleteCommand.Parameters[69].Value = 1;
			Adapter.DeleteCommand.Parameters[70].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[69].Value = 0;
			Adapter.DeleteCommand.Parameters[70].Value = Original_mEmail;
		}
		if (Original_DOB.HasValue)
		{
			Adapter.DeleteCommand.Parameters[71].Value = 0;
			Adapter.DeleteCommand.Parameters[72].Value = Original_DOB.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[71].Value = 1;
			Adapter.DeleteCommand.Parameters[72].Value = DBNull.Value;
		}
		if (Original_IsTheologyStud.HasValue)
		{
			Adapter.DeleteCommand.Parameters[73].Value = 0;
			Adapter.DeleteCommand.Parameters[74].Value = Original_IsTheologyStud.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[73].Value = 1;
			Adapter.DeleteCommand.Parameters[74].Value = DBNull.Value;
		}
		if (Original_PrimaryScores1 == null)
		{
			Adapter.DeleteCommand.Parameters[75].Value = 1;
			Adapter.DeleteCommand.Parameters[76].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[75].Value = 0;
			Adapter.DeleteCommand.Parameters[76].Value = Original_PrimaryScores1;
		}
		if (Original_PrimaryScores2 == null)
		{
			Adapter.DeleteCommand.Parameters[77].Value = 1;
			Adapter.DeleteCommand.Parameters[78].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[77].Value = 0;
			Adapter.DeleteCommand.Parameters[78].Value = Original_PrimaryScores2;
		}
		if (Original_PrimaryScores3 == null)
		{
			Adapter.DeleteCommand.Parameters[79].Value = 1;
			Adapter.DeleteCommand.Parameters[80].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[79].Value = 0;
			Adapter.DeleteCommand.Parameters[80].Value = Original_PrimaryScores3;
		}
		if (Original_IsSynched.HasValue)
		{
			Adapter.DeleteCommand.Parameters[81].Value = 0;
			Adapter.DeleteCommand.Parameters[82].Value = Original_IsSynched.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[81].Value = 1;
			Adapter.DeleteCommand.Parameters[82].Value = DBNull.Value;
		}
		if (Original_Sponsor == null)
		{
			Adapter.DeleteCommand.Parameters[83].Value = 1;
			Adapter.DeleteCommand.Parameters[84].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[83].Value = 0;
			Adapter.DeleteCommand.Parameters[84].Value = Original_Sponsor;
		}
		if (Original_SponsorContact == null)
		{
			Adapter.DeleteCommand.Parameters[85].Value = 1;
			Adapter.DeleteCommand.Parameters[86].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[85].Value = 0;
			Adapter.DeleteCommand.Parameters[86].Value = Original_SponsorContact;
		}
		if (Original_mNIN == null)
		{
			Adapter.DeleteCommand.Parameters[87].Value = 1;
			Adapter.DeleteCommand.Parameters[88].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[87].Value = 0;
			Adapter.DeleteCommand.Parameters[88].Value = Original_mNIN;
		}
		if (Original_fNIN == null)
		{
			Adapter.DeleteCommand.Parameters[89].Value = 1;
			Adapter.DeleteCommand.Parameters[90].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[89].Value = 0;
			Adapter.DeleteCommand.Parameters[90].Value = Original_fNIN;
		}
		if (Original_sNIN == null)
		{
			Adapter.DeleteCommand.Parameters[91].Value = 1;
			Adapter.DeleteCommand.Parameters[92].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[91].Value = 0;
			Adapter.DeleteCommand.Parameters[92].Value = Original_sNIN;
		}
		if (Original_PriorityContact == null)
		{
			Adapter.DeleteCommand.Parameters[93].Value = 1;
			Adapter.DeleteCommand.Parameters[94].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[93].Value = 0;
			Adapter.DeleteCommand.Parameters[94].Value = Original_PriorityContact;
		}
		if (Original_OtherContact == null)
		{
			Adapter.DeleteCommand.Parameters[95].Value = 1;
			Adapter.DeleteCommand.Parameters[96].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[95].Value = 0;
			Adapter.DeleteCommand.Parameters[96].Value = Original_OtherContact;
		}
		if (Original_GuardianAddress == null)
		{
			Adapter.DeleteCommand.Parameters[97].Value = 1;
			Adapter.DeleteCommand.Parameters[98].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[97].Value = 0;
			Adapter.DeleteCommand.Parameters[98].Value = Original_GuardianAddress;
		}
		if (Original_Email == null)
		{
			Adapter.DeleteCommand.Parameters[99].Value = 1;
			Adapter.DeleteCommand.Parameters[100].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[99].Value = 0;
			Adapter.DeleteCommand.Parameters[100].Value = Original_Email;
		}
		if (Original_GamesAndSports == null)
		{
			Adapter.DeleteCommand.Parameters[101].Value = 1;
			Adapter.DeleteCommand.Parameters[102].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[101].Value = 0;
			Adapter.DeleteCommand.Parameters[102].Value = Original_GamesAndSports;
		}
		if (Original_Clubs == null)
		{
			Adapter.DeleteCommand.Parameters[103].Value = 1;
			Adapter.DeleteCommand.Parameters[104].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[103].Value = 0;
			Adapter.DeleteCommand.Parameters[104].Value = Original_Clubs;
		}
		if (Original_StreamEn == null)
		{
			Adapter.DeleteCommand.Parameters[105].Value = 1;
			Adapter.DeleteCommand.Parameters[106].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[105].Value = 0;
			Adapter.DeleteCommand.Parameters[106].Value = Original_StreamEn;
		}
		if (Original_SexAr == null)
		{
			Adapter.DeleteCommand.Parameters[107].Value = 1;
			Adapter.DeleteCommand.Parameters[108].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[107].Value = 0;
			Adapter.DeleteCommand.Parameters[108].Value = Original_SexAr;
		}
		ConnectionState state = Adapter.DeleteCommand.Connection.State;
		if ((Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			Adapter.DeleteCommand.Connection.Open();
		}
		try
		{
			return Adapter.DeleteCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				Adapter.DeleteCommand.Connection.Close();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	public virtual int Insert(string StudentNumber, Guid Oid, string StudentID, string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, bool? BursaryStatus, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, bool? vID, bool? tagged, string Comb, string SubjectString, string fName, string fAddress, string fContact, string fEmail, string mName, string mAddress, string mContact, string mEmail, DateTime? DOB, bool? IsTheologyStud, string PrimaryScores1, string PrimaryScores2, string PrimaryScores3, bool? IsSynched, string Sponsor, string SponsorContact, string mNIN, string fNIN, string sNIN, string PriorityContact, string OtherContact, string GuardianAddress, string Email, string GamesAndSports, string Clubs, string StreamEn, string SexAr)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		Adapter.InsertCommand.Parameters[1].Value = Oid;
		if (StudentID == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = StudentID;
		}
		if (fullName == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = fullName;
		}
		if (fullNameAr == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = fullNameAr;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = ClassId;
		}
		if (ClassIdEn == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = ClassIdEn;
		}
		if (ClassIdAr == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = ClassIdAr;
		}
		if (StreamId == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = StreamId;
		}
		if (StreamAr == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = StreamAr;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = Sex;
		}
		if (StudyStatus == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = StudyStatus;
		}
		if (HouseId == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = HouseId;
		}
		if (Religion == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = Religion;
		}
		if (Guardian == null)
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = Guardian;
		}
		if (FormerSchool == null)
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = FormerSchool;
		}
		if (BursaryStatus.HasValue)
		{
			Adapter.InsertCommand.Parameters[16].Value = BursaryStatus.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		if (BursaryProvider == null)
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = BursaryProvider;
		}
		if (AdmissionDate == null)
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = AdmissionDate;
		}
		if (Picture == null)
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = Picture;
		}
		if (HomeCountry == null)
		{
			Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[20].Value = HomeCountry;
		}
		if (Status == null)
		{
			Adapter.InsertCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[21].Value = Status;
		}
		if (Notes == null)
		{
			Adapter.InsertCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[22].Value = Notes;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.InsertCommand.Parameters[23].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[23].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.InsertCommand.Parameters[24].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[24].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.InsertCommand.Parameters[25].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[25].Value = DBNull.Value;
		}
		if (vID.HasValue)
		{
			Adapter.InsertCommand.Parameters[26].Value = vID.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[26].Value = DBNull.Value;
		}
		if (tagged.HasValue)
		{
			Adapter.InsertCommand.Parameters[27].Value = tagged.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[27].Value = DBNull.Value;
		}
		if (Comb == null)
		{
			Adapter.InsertCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[28].Value = Comb;
		}
		if (SubjectString == null)
		{
			Adapter.InsertCommand.Parameters[29].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[29].Value = SubjectString;
		}
		if (fName == null)
		{
			Adapter.InsertCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[30].Value = fName;
		}
		if (fAddress == null)
		{
			Adapter.InsertCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[31].Value = fAddress;
		}
		if (fContact == null)
		{
			Adapter.InsertCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[32].Value = fContact;
		}
		if (fEmail == null)
		{
			Adapter.InsertCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[33].Value = fEmail;
		}
		if (mName == null)
		{
			Adapter.InsertCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[34].Value = mName;
		}
		if (mAddress == null)
		{
			Adapter.InsertCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[35].Value = mAddress;
		}
		if (mContact == null)
		{
			Adapter.InsertCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[36].Value = mContact;
		}
		if (mEmail == null)
		{
			Adapter.InsertCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[37].Value = mEmail;
		}
		if (DOB.HasValue)
		{
			Adapter.InsertCommand.Parameters[38].Value = DOB.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[38].Value = DBNull.Value;
		}
		if (IsTheologyStud.HasValue)
		{
			Adapter.InsertCommand.Parameters[39].Value = IsTheologyStud.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[39].Value = DBNull.Value;
		}
		if (PrimaryScores1 == null)
		{
			Adapter.InsertCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[40].Value = PrimaryScores1;
		}
		if (PrimaryScores2 == null)
		{
			Adapter.InsertCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[41].Value = PrimaryScores2;
		}
		if (PrimaryScores3 == null)
		{
			Adapter.InsertCommand.Parameters[42].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[42].Value = PrimaryScores3;
		}
		if (IsSynched.HasValue)
		{
			Adapter.InsertCommand.Parameters[43].Value = IsSynched.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[43].Value = DBNull.Value;
		}
		if (Sponsor == null)
		{
			Adapter.InsertCommand.Parameters[44].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[44].Value = Sponsor;
		}
		if (SponsorContact == null)
		{
			Adapter.InsertCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[45].Value = SponsorContact;
		}
		if (mNIN == null)
		{
			Adapter.InsertCommand.Parameters[46].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[46].Value = mNIN;
		}
		if (fNIN == null)
		{
			Adapter.InsertCommand.Parameters[47].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[47].Value = fNIN;
		}
		if (sNIN == null)
		{
			Adapter.InsertCommand.Parameters[48].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[48].Value = sNIN;
		}
		if (PriorityContact == null)
		{
			Adapter.InsertCommand.Parameters[49].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[49].Value = PriorityContact;
		}
		if (OtherContact == null)
		{
			Adapter.InsertCommand.Parameters[50].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[50].Value = OtherContact;
		}
		if (GuardianAddress == null)
		{
			Adapter.InsertCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[51].Value = GuardianAddress;
		}
		if (Email == null)
		{
			Adapter.InsertCommand.Parameters[52].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[52].Value = Email;
		}
		if (GamesAndSports == null)
		{
			Adapter.InsertCommand.Parameters[53].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[53].Value = GamesAndSports;
		}
		if (Clubs == null)
		{
			Adapter.InsertCommand.Parameters[54].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[54].Value = Clubs;
		}
		if (StreamEn == null)
		{
			Adapter.InsertCommand.Parameters[55].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[55].Value = StreamEn;
		}
		if (SexAr == null)
		{
			Adapter.InsertCommand.Parameters[56].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[56].Value = SexAr;
		}
		ConnectionState state = Adapter.InsertCommand.Connection.State;
		if ((Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			Adapter.InsertCommand.Connection.Open();
		}
		try
		{
			return Adapter.InsertCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				Adapter.InsertCommand.Connection.Close();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	public virtual int Update(string StudentNumber, Guid Oid, string StudentID, string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, bool? BursaryStatus, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, bool? vID, bool? tagged, string Comb, string SubjectString, string fName, string fAddress, string fContact, string fEmail, string mName, string mAddress, string mContact, string mEmail, DateTime? DOB, bool? IsTheologyStud, string PrimaryScores1, string PrimaryScores2, string PrimaryScores3, bool? IsSynched, string Sponsor, string SponsorContact, string mNIN, string fNIN, string sNIN, string PriorityContact, string OtherContact, string GuardianAddress, string Email, string GamesAndSports, string Clubs, string StreamEn, string SexAr, string Original_StudentNumber, long Original_auto, Guid Original_Oid, string Original_StudentID, string Original_fullName, string Original_fullNameAr, string Original_ClassId, string Original_ClassIdEn, string Original_ClassIdAr, string Original_StreamId, string Original_StreamAr, string Original_Sex, string Original_StudyStatus, string Original_HouseId, string Original_Religion, string Original_Guardian, string Original_FormerSchool, bool? Original_BursaryStatus, string Original_BursaryProvider, string Original_AdmissionDate, string Original_HomeCountry, string Original_Status, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, bool? Original_vID, bool? Original_tagged, string Original_Comb, string Original_SubjectString, string Original_fName, string Original_fAddress, string Original_fContact, string Original_fEmail, string Original_mName, string Original_mAddress, string Original_mContact, string Original_mEmail, DateTime? Original_DOB, bool? Original_IsTheologyStud, string Original_PrimaryScores1, string Original_PrimaryScores2, string Original_PrimaryScores3, bool? Original_IsSynched, string Original_Sponsor, string Original_SponsorContact, string Original_mNIN, string Original_fNIN, string Original_sNIN, string Original_PriorityContact, string Original_OtherContact, string Original_GuardianAddress, string Original_Email, string Original_GamesAndSports, string Original_Clubs, string Original_StreamEn, string Original_SexAr, long auto)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		Adapter.UpdateCommand.Parameters[1].Value = Oid;
		if (StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = StudentID;
		}
		if (fullName == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = fullName;
		}
		if (fullNameAr == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = fullNameAr;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = ClassId;
		}
		if (ClassIdEn == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = ClassIdEn;
		}
		if (ClassIdAr == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = ClassIdAr;
		}
		if (StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = StreamId;
		}
		if (StreamAr == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = StreamAr;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = Sex;
		}
		if (StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = StudyStatus;
		}
		if (HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = HouseId;
		}
		if (Religion == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = Religion;
		}
		if (Guardian == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = Guardian;
		}
		if (FormerSchool == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = FormerSchool;
		}
		if (BursaryStatus.HasValue)
		{
			Adapter.UpdateCommand.Parameters[16].Value = BursaryStatus.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		if (BursaryProvider == null)
		{
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = BursaryProvider;
		}
		if (AdmissionDate == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = AdmissionDate;
		}
		if (Picture == null)
		{
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = Picture;
		}
		if (HomeCountry == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = HomeCountry;
		}
		if (Status == null)
		{
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = Status;
		}
		if (Notes == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = Notes;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[23].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[24].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[25].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		if (vID.HasValue)
		{
			Adapter.UpdateCommand.Parameters[26].Value = vID.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = DBNull.Value;
		}
		if (tagged.HasValue)
		{
			Adapter.UpdateCommand.Parameters[27].Value = tagged.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		if (Comb == null)
		{
			Adapter.UpdateCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = Comb;
		}
		if (SubjectString == null)
		{
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[29].Value = SubjectString;
		}
		if (fName == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = fName;
		}
		if (fAddress == null)
		{
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[31].Value = fAddress;
		}
		if (fContact == null)
		{
			Adapter.UpdateCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = fContact;
		}
		if (fEmail == null)
		{
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[33].Value = fEmail;
		}
		if (mName == null)
		{
			Adapter.UpdateCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = mName;
		}
		if (mAddress == null)
		{
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[35].Value = mAddress;
		}
		if (mContact == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = mContact;
		}
		if (mEmail == null)
		{
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[37].Value = mEmail;
		}
		if (DOB.HasValue)
		{
			Adapter.UpdateCommand.Parameters[38].Value = DOB.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = DBNull.Value;
		}
		if (IsTheologyStud.HasValue)
		{
			Adapter.UpdateCommand.Parameters[39].Value = IsTheologyStud.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		if (PrimaryScores1 == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = PrimaryScores1;
		}
		if (PrimaryScores2 == null)
		{
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[41].Value = PrimaryScores2;
		}
		if (PrimaryScores3 == null)
		{
			Adapter.UpdateCommand.Parameters[42].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = PrimaryScores3;
		}
		if (IsSynched.HasValue)
		{
			Adapter.UpdateCommand.Parameters[43].Value = IsSynched.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		if (Sponsor == null)
		{
			Adapter.UpdateCommand.Parameters[44].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = Sponsor;
		}
		if (SponsorContact == null)
		{
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[45].Value = SponsorContact;
		}
		if (mNIN == null)
		{
			Adapter.UpdateCommand.Parameters[46].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = mNIN;
		}
		if (fNIN == null)
		{
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[47].Value = fNIN;
		}
		if (sNIN == null)
		{
			Adapter.UpdateCommand.Parameters[48].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = sNIN;
		}
		if (PriorityContact == null)
		{
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[49].Value = PriorityContact;
		}
		if (OtherContact == null)
		{
			Adapter.UpdateCommand.Parameters[50].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = OtherContact;
		}
		if (GuardianAddress == null)
		{
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[51].Value = GuardianAddress;
		}
		if (Email == null)
		{
			Adapter.UpdateCommand.Parameters[52].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[52].Value = Email;
		}
		if (GamesAndSports == null)
		{
			Adapter.UpdateCommand.Parameters[53].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[53].Value = GamesAndSports;
		}
		if (Clubs == null)
		{
			Adapter.UpdateCommand.Parameters[54].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[54].Value = Clubs;
		}
		if (StreamEn == null)
		{
			Adapter.UpdateCommand.Parameters[55].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[55].Value = StreamEn;
		}
		if (SexAr == null)
		{
			Adapter.UpdateCommand.Parameters[56].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[56].Value = SexAr;
		}
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[57].Value = Original_StudentNumber;
		Adapter.UpdateCommand.Parameters[58].Value = Original_auto;
		Adapter.UpdateCommand.Parameters[59].Value = Original_Oid;
		if (Original_StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[60].Value = 1;
			Adapter.UpdateCommand.Parameters[61].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[60].Value = 0;
			Adapter.UpdateCommand.Parameters[61].Value = Original_StudentID;
		}
		if (Original_fullName == null)
		{
			Adapter.UpdateCommand.Parameters[62].Value = 1;
			Adapter.UpdateCommand.Parameters[63].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[62].Value = 0;
			Adapter.UpdateCommand.Parameters[63].Value = Original_fullName;
		}
		if (Original_fullNameAr == null)
		{
			Adapter.UpdateCommand.Parameters[64].Value = 1;
			Adapter.UpdateCommand.Parameters[65].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[64].Value = 0;
			Adapter.UpdateCommand.Parameters[65].Value = Original_fullNameAr;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[66].Value = 1;
			Adapter.UpdateCommand.Parameters[67].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[66].Value = 0;
			Adapter.UpdateCommand.Parameters[67].Value = Original_ClassId;
		}
		if (Original_ClassIdEn == null)
		{
			Adapter.UpdateCommand.Parameters[68].Value = 1;
			Adapter.UpdateCommand.Parameters[69].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[68].Value = 0;
			Adapter.UpdateCommand.Parameters[69].Value = Original_ClassIdEn;
		}
		if (Original_ClassIdAr == null)
		{
			Adapter.UpdateCommand.Parameters[70].Value = 1;
			Adapter.UpdateCommand.Parameters[71].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[70].Value = 0;
			Adapter.UpdateCommand.Parameters[71].Value = Original_ClassIdAr;
		}
		if (Original_StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[72].Value = 1;
			Adapter.UpdateCommand.Parameters[73].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[72].Value = 0;
			Adapter.UpdateCommand.Parameters[73].Value = Original_StreamId;
		}
		if (Original_StreamAr == null)
		{
			Adapter.UpdateCommand.Parameters[74].Value = 1;
			Adapter.UpdateCommand.Parameters[75].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[74].Value = 0;
			Adapter.UpdateCommand.Parameters[75].Value = Original_StreamAr;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[76].Value = 1;
			Adapter.UpdateCommand.Parameters[77].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[76].Value = 0;
			Adapter.UpdateCommand.Parameters[77].Value = Original_Sex;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[78].Value = 1;
			Adapter.UpdateCommand.Parameters[79].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[78].Value = 0;
			Adapter.UpdateCommand.Parameters[79].Value = Original_StudyStatus;
		}
		if (Original_HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[80].Value = 1;
			Adapter.UpdateCommand.Parameters[81].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[80].Value = 0;
			Adapter.UpdateCommand.Parameters[81].Value = Original_HouseId;
		}
		if (Original_Religion == null)
		{
			Adapter.UpdateCommand.Parameters[82].Value = 1;
			Adapter.UpdateCommand.Parameters[83].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[82].Value = 0;
			Adapter.UpdateCommand.Parameters[83].Value = Original_Religion;
		}
		if (Original_Guardian == null)
		{
			Adapter.UpdateCommand.Parameters[84].Value = 1;
			Adapter.UpdateCommand.Parameters[85].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[84].Value = 0;
			Adapter.UpdateCommand.Parameters[85].Value = Original_Guardian;
		}
		if (Original_FormerSchool == null)
		{
			Adapter.UpdateCommand.Parameters[86].Value = 1;
			Adapter.UpdateCommand.Parameters[87].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[86].Value = 0;
			Adapter.UpdateCommand.Parameters[87].Value = Original_FormerSchool;
		}
		if (Original_BursaryStatus.HasValue)
		{
			Adapter.UpdateCommand.Parameters[88].Value = 0;
			Adapter.UpdateCommand.Parameters[89].Value = Original_BursaryStatus.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[88].Value = 1;
			Adapter.UpdateCommand.Parameters[89].Value = DBNull.Value;
		}
		if (Original_BursaryProvider == null)
		{
			Adapter.UpdateCommand.Parameters[90].Value = 1;
			Adapter.UpdateCommand.Parameters[91].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[90].Value = 0;
			Adapter.UpdateCommand.Parameters[91].Value = Original_BursaryProvider;
		}
		if (Original_AdmissionDate == null)
		{
			Adapter.UpdateCommand.Parameters[92].Value = 1;
			Adapter.UpdateCommand.Parameters[93].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[92].Value = 0;
			Adapter.UpdateCommand.Parameters[93].Value = Original_AdmissionDate;
		}
		if (Original_HomeCountry == null)
		{
			Adapter.UpdateCommand.Parameters[94].Value = 1;
			Adapter.UpdateCommand.Parameters[95].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[94].Value = 0;
			Adapter.UpdateCommand.Parameters[95].Value = Original_HomeCountry;
		}
		if (Original_Status == null)
		{
			Adapter.UpdateCommand.Parameters[96].Value = 1;
			Adapter.UpdateCommand.Parameters[97].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[96].Value = 0;
			Adapter.UpdateCommand.Parameters[97].Value = Original_Status;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[98].Value = 0;
			Adapter.UpdateCommand.Parameters[99].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[98].Value = 1;
			Adapter.UpdateCommand.Parameters[99].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[100].Value = 0;
			Adapter.UpdateCommand.Parameters[101].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[100].Value = 1;
			Adapter.UpdateCommand.Parameters[101].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[102].Value = 0;
			Adapter.UpdateCommand.Parameters[103].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[102].Value = 1;
			Adapter.UpdateCommand.Parameters[103].Value = DBNull.Value;
		}
		if (Original_vID.HasValue)
		{
			Adapter.UpdateCommand.Parameters[104].Value = 0;
			Adapter.UpdateCommand.Parameters[105].Value = Original_vID.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[104].Value = 1;
			Adapter.UpdateCommand.Parameters[105].Value = DBNull.Value;
		}
		if (Original_tagged.HasValue)
		{
			Adapter.UpdateCommand.Parameters[106].Value = 0;
			Adapter.UpdateCommand.Parameters[107].Value = Original_tagged.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[106].Value = 1;
			Adapter.UpdateCommand.Parameters[107].Value = DBNull.Value;
		}
		if (Original_Comb == null)
		{
			Adapter.UpdateCommand.Parameters[108].Value = 1;
			Adapter.UpdateCommand.Parameters[109].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[108].Value = 0;
			Adapter.UpdateCommand.Parameters[109].Value = Original_Comb;
		}
		if (Original_SubjectString == null)
		{
			Adapter.UpdateCommand.Parameters[110].Value = 1;
			Adapter.UpdateCommand.Parameters[111].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[110].Value = 0;
			Adapter.UpdateCommand.Parameters[111].Value = Original_SubjectString;
		}
		if (Original_fName == null)
		{
			Adapter.UpdateCommand.Parameters[112].Value = 1;
			Adapter.UpdateCommand.Parameters[113].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[112].Value = 0;
			Adapter.UpdateCommand.Parameters[113].Value = Original_fName;
		}
		if (Original_fAddress == null)
		{
			Adapter.UpdateCommand.Parameters[114].Value = 1;
			Adapter.UpdateCommand.Parameters[115].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[114].Value = 0;
			Adapter.UpdateCommand.Parameters[115].Value = Original_fAddress;
		}
		if (Original_fContact == null)
		{
			Adapter.UpdateCommand.Parameters[116].Value = 1;
			Adapter.UpdateCommand.Parameters[117].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[116].Value = 0;
			Adapter.UpdateCommand.Parameters[117].Value = Original_fContact;
		}
		if (Original_fEmail == null)
		{
			Adapter.UpdateCommand.Parameters[118].Value = 1;
			Adapter.UpdateCommand.Parameters[119].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[118].Value = 0;
			Adapter.UpdateCommand.Parameters[119].Value = Original_fEmail;
		}
		if (Original_mName == null)
		{
			Adapter.UpdateCommand.Parameters[120].Value = 1;
			Adapter.UpdateCommand.Parameters[121].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[120].Value = 0;
			Adapter.UpdateCommand.Parameters[121].Value = Original_mName;
		}
		if (Original_mAddress == null)
		{
			Adapter.UpdateCommand.Parameters[122].Value = 1;
			Adapter.UpdateCommand.Parameters[123].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[122].Value = 0;
			Adapter.UpdateCommand.Parameters[123].Value = Original_mAddress;
		}
		if (Original_mContact == null)
		{
			Adapter.UpdateCommand.Parameters[124].Value = 1;
			Adapter.UpdateCommand.Parameters[125].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[124].Value = 0;
			Adapter.UpdateCommand.Parameters[125].Value = Original_mContact;
		}
		if (Original_mEmail == null)
		{
			Adapter.UpdateCommand.Parameters[126].Value = 1;
			Adapter.UpdateCommand.Parameters[127].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[126].Value = 0;
			Adapter.UpdateCommand.Parameters[127].Value = Original_mEmail;
		}
		if (Original_DOB.HasValue)
		{
			Adapter.UpdateCommand.Parameters[128].Value = 0;
			Adapter.UpdateCommand.Parameters[129].Value = Original_DOB.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[128].Value = 1;
			Adapter.UpdateCommand.Parameters[129].Value = DBNull.Value;
		}
		if (Original_IsTheologyStud.HasValue)
		{
			Adapter.UpdateCommand.Parameters[130].Value = 0;
			Adapter.UpdateCommand.Parameters[131].Value = Original_IsTheologyStud.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[130].Value = 1;
			Adapter.UpdateCommand.Parameters[131].Value = DBNull.Value;
		}
		if (Original_PrimaryScores1 == null)
		{
			Adapter.UpdateCommand.Parameters[132].Value = 1;
			Adapter.UpdateCommand.Parameters[133].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[132].Value = 0;
			Adapter.UpdateCommand.Parameters[133].Value = Original_PrimaryScores1;
		}
		if (Original_PrimaryScores2 == null)
		{
			Adapter.UpdateCommand.Parameters[134].Value = 1;
			Adapter.UpdateCommand.Parameters[135].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[134].Value = 0;
			Adapter.UpdateCommand.Parameters[135].Value = Original_PrimaryScores2;
		}
		if (Original_PrimaryScores3 == null)
		{
			Adapter.UpdateCommand.Parameters[136].Value = 1;
			Adapter.UpdateCommand.Parameters[137].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[136].Value = 0;
			Adapter.UpdateCommand.Parameters[137].Value = Original_PrimaryScores3;
		}
		if (Original_IsSynched.HasValue)
		{
			Adapter.UpdateCommand.Parameters[138].Value = 0;
			Adapter.UpdateCommand.Parameters[139].Value = Original_IsSynched.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[138].Value = 1;
			Adapter.UpdateCommand.Parameters[139].Value = DBNull.Value;
		}
		if (Original_Sponsor == null)
		{
			Adapter.UpdateCommand.Parameters[140].Value = 1;
			Adapter.UpdateCommand.Parameters[141].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[140].Value = 0;
			Adapter.UpdateCommand.Parameters[141].Value = Original_Sponsor;
		}
		if (Original_SponsorContact == null)
		{
			Adapter.UpdateCommand.Parameters[142].Value = 1;
			Adapter.UpdateCommand.Parameters[143].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[142].Value = 0;
			Adapter.UpdateCommand.Parameters[143].Value = Original_SponsorContact;
		}
		if (Original_mNIN == null)
		{
			Adapter.UpdateCommand.Parameters[144].Value = 1;
			Adapter.UpdateCommand.Parameters[145].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[144].Value = 0;
			Adapter.UpdateCommand.Parameters[145].Value = Original_mNIN;
		}
		if (Original_fNIN == null)
		{
			Adapter.UpdateCommand.Parameters[146].Value = 1;
			Adapter.UpdateCommand.Parameters[147].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[146].Value = 0;
			Adapter.UpdateCommand.Parameters[147].Value = Original_fNIN;
		}
		if (Original_sNIN == null)
		{
			Adapter.UpdateCommand.Parameters[148].Value = 1;
			Adapter.UpdateCommand.Parameters[149].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[148].Value = 0;
			Adapter.UpdateCommand.Parameters[149].Value = Original_sNIN;
		}
		if (Original_PriorityContact == null)
		{
			Adapter.UpdateCommand.Parameters[150].Value = 1;
			Adapter.UpdateCommand.Parameters[151].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[150].Value = 0;
			Adapter.UpdateCommand.Parameters[151].Value = Original_PriorityContact;
		}
		if (Original_OtherContact == null)
		{
			Adapter.UpdateCommand.Parameters[152].Value = 1;
			Adapter.UpdateCommand.Parameters[153].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[152].Value = 0;
			Adapter.UpdateCommand.Parameters[153].Value = Original_OtherContact;
		}
		if (Original_GuardianAddress == null)
		{
			Adapter.UpdateCommand.Parameters[154].Value = 1;
			Adapter.UpdateCommand.Parameters[155].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[154].Value = 0;
			Adapter.UpdateCommand.Parameters[155].Value = Original_GuardianAddress;
		}
		if (Original_Email == null)
		{
			Adapter.UpdateCommand.Parameters[156].Value = 1;
			Adapter.UpdateCommand.Parameters[157].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[156].Value = 0;
			Adapter.UpdateCommand.Parameters[157].Value = Original_Email;
		}
		if (Original_GamesAndSports == null)
		{
			Adapter.UpdateCommand.Parameters[158].Value = 1;
			Adapter.UpdateCommand.Parameters[159].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[158].Value = 0;
			Adapter.UpdateCommand.Parameters[159].Value = Original_GamesAndSports;
		}
		if (Original_Clubs == null)
		{
			Adapter.UpdateCommand.Parameters[160].Value = 1;
			Adapter.UpdateCommand.Parameters[161].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[160].Value = 0;
			Adapter.UpdateCommand.Parameters[161].Value = Original_Clubs;
		}
		if (Original_StreamEn == null)
		{
			Adapter.UpdateCommand.Parameters[162].Value = 1;
			Adapter.UpdateCommand.Parameters[163].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[162].Value = 0;
			Adapter.UpdateCommand.Parameters[163].Value = Original_StreamEn;
		}
		if (Original_SexAr == null)
		{
			Adapter.UpdateCommand.Parameters[164].Value = 1;
			Adapter.UpdateCommand.Parameters[165].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[164].Value = 0;
			Adapter.UpdateCommand.Parameters[165].Value = Original_SexAr;
		}
		Adapter.UpdateCommand.Parameters[166].Value = auto;
		ConnectionState state = Adapter.UpdateCommand.Connection.State;
		if ((Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			Adapter.UpdateCommand.Connection.Open();
		}
		try
		{
			return Adapter.UpdateCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				Adapter.UpdateCommand.Connection.Close();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	public virtual int Update(string StudentID, string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, bool? BursaryStatus, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, bool? vID, bool? tagged, string Comb, string SubjectString, string fName, string fAddress, string fContact, string fEmail, string mName, string mAddress, string mContact, string mEmail, DateTime? DOB, bool? IsTheologyStud, string PrimaryScores1, string PrimaryScores2, string PrimaryScores3, bool? IsSynched, string Sponsor, string SponsorContact, string mNIN, string fNIN, string sNIN, string PriorityContact, string OtherContact, string GuardianAddress, string Email, string GamesAndSports, string Clubs, string StreamEn, string SexAr, string Original_StudentNumber, long Original_auto, Guid Original_Oid, string Original_StudentID, string Original_fullName, string Original_fullNameAr, string Original_ClassId, string Original_ClassIdEn, string Original_ClassIdAr, string Original_StreamId, string Original_StreamAr, string Original_Sex, string Original_StudyStatus, string Original_HouseId, string Original_Religion, string Original_Guardian, string Original_FormerSchool, bool? Original_BursaryStatus, string Original_BursaryProvider, string Original_AdmissionDate, string Original_HomeCountry, string Original_Status, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, bool? Original_vID, bool? Original_tagged, string Original_Comb, string Original_SubjectString, string Original_fName, string Original_fAddress, string Original_fContact, string Original_fEmail, string Original_mName, string Original_mAddress, string Original_mContact, string Original_mEmail, DateTime? Original_DOB, bool? Original_IsTheologyStud, string Original_PrimaryScores1, string Original_PrimaryScores2, string Original_PrimaryScores3, bool? Original_IsSynched, string Original_Sponsor, string Original_SponsorContact, string Original_mNIN, string Original_fNIN, string Original_sNIN, string Original_PriorityContact, string Original_OtherContact, string Original_GuardianAddress, string Original_Email, string Original_GamesAndSports, string Original_Clubs, string Original_StreamEn, string Original_SexAr)
	{
		return Update(Original_StudentNumber, Original_Oid, StudentID, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, RequiredFees, cashOnAccount, FeesDiscount, vID, tagged, Comb, SubjectString, fName, fAddress, fContact, fEmail, mName, mAddress, mContact, mEmail, DOB, IsTheologyStud, PrimaryScores1, PrimaryScores2, PrimaryScores3, IsSynched, Sponsor, SponsorContact, mNIN, fNIN, sNIN, PriorityContact, OtherContact, GuardianAddress, Email, GamesAndSports, Clubs, StreamEn, SexAr, Original_StudentNumber, Original_auto, Original_Oid, Original_StudentID, Original_fullName, Original_fullNameAr, Original_ClassId, Original_ClassIdEn, Original_ClassIdAr, Original_StreamId, Original_StreamAr, Original_Sex, Original_StudyStatus, Original_HouseId, Original_Religion, Original_Guardian, Original_FormerSchool, Original_BursaryStatus, Original_BursaryProvider, Original_AdmissionDate, Original_HomeCountry, Original_Status, Original_RequiredFees, Original_cashOnAccount, Original_FeesDiscount, Original_vID, Original_tagged, Original_Comb, Original_SubjectString, Original_fName, Original_fAddress, Original_fContact, Original_fEmail, Original_mName, Original_mAddress, Original_mContact, Original_mEmail, Original_DOB, Original_IsTheologyStud, Original_PrimaryScores1, Original_PrimaryScores2, Original_PrimaryScores3, Original_IsSynched, Original_Sponsor, Original_SponsorContact, Original_mNIN, Original_fNIN, Original_sNIN, Original_PriorityContact, Original_OtherContact, Original_GuardianAddress, Original_Email, Original_GamesAndSports, Original_Clubs, Original_StreamEn, Original_SexAr, Original_auto);
	}
}
