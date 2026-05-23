using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace I_Xtreme.dSetStudentIdsTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class studentsTableAdapter : Component
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
	public studentsTableAdapter()
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
		dataTableMapping.DataSetTable = "students";
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("FirstName", "FirstName");
		dataTableMapping.ColumnMappings.Add("LastName", "LastName");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("StudyStatus", "StudyStatus");
		dataTableMapping.ColumnMappings.Add("HouseId", "HouseId");
		dataTableMapping.ColumnMappings.Add("Religion", "Religion");
		dataTableMapping.ColumnMappings.Add("Guardian", "Guardian");
		dataTableMapping.ColumnMappings.Add("FormerSchool", "FormerSchool");
		dataTableMapping.ColumnMappings.Add("BursaryStatus", "BursaryStatus");
		dataTableMapping.ColumnMappings.Add("RequiredFees", "RequiredFees");
		dataTableMapping.ColumnMappings.Add("BursaryProvider", "BursaryProvider");
		dataTableMapping.ColumnMappings.Add("AdmissionDate", "AdmissionDate");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("HomeCountry", "HomeCountry");
		dataTableMapping.ColumnMappings.Add("Status", "Status");
		dataTableMapping.ColumnMappings.Add("Notes", "Notes");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[students] WHERE (((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ([StudentNumber] = @Original_StudentNumber) AND ((@IsNull_FirstName = 1 AND [FirstName] IS NULL) OR ([FirstName] = @Original_FirstName)) AND ((@IsNull_LastName = 1 AND [LastName] IS NULL) OR ([LastName] = @Original_LastName)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_Religion = 1 AND [Religion] IS NULL) OR ([Religion] = @Original_Religion)) AND ((@IsNull_Guardian = 1 AND [Guardian] IS NULL) OR ([Guardian] = @Original_Guardian)) AND ((@IsNull_FormerSchool = 1 AND [FormerSchool] IS NULL) OR ([FormerSchool] = @Original_FormerSchool)) AND ((@IsNull_BursaryStatus = 1 AND [BursaryStatus] IS NULL) OR ([BursaryStatus] = @Original_BursaryStatus)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_BursaryProvider = 1 AND [BursaryProvider] IS NULL) OR ([BursaryProvider] = @Original_BursaryProvider)) AND ((@IsNull_AdmissionDate = 1 AND [AdmissionDate] IS NULL) OR ([AdmissionDate] = @Original_AdmissionDate)) AND ((@IsNull_HomeCountry = 1 AND [HomeCountry] IS NULL) OR ([HomeCountry] = @Original_HomeCountry)) AND ((@IsNull_Status = 1 AND [Status] IS NULL) OR ([Status] = @Original_Status)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FirstName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_LastName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BursaryStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryProvider", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_AdmissionDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HomeCountry", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[students] ([fullName], [StudentNumber], [FirstName], [LastName], [ClassId], [StreamId], [Sex], [StudyStatus], [HouseId], [Religion], [Guardian], [FormerSchool], [BursaryStatus], [RequiredFees], [BursaryProvider], [AdmissionDate], [Picture], [HomeCountry], [Status], [Notes], [cashOnAccount]) VALUES (@fullName, @StudentNumber, @FirstName, @LastName, @ClassId, @StreamId, @Sex, @StudyStatus, @HouseId, @Religion, @Guardian, @FormerSchool, @BursaryStatus, @RequiredFees, @BursaryProvider, @AdmissionDate, @Picture, @HomeCountry, @Status, @Notes, @cashOnAccount);\r\nSELECT fullName, StudentNumber, FirstName, LastName, ClassId, StreamId, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, RequiredFees, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, cashOnAccount FROM tbl_Stud WHERE (StudentNumber = @StudentNumber)";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FormerSchool", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BursaryStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [dbo].[students] SET [fullName] = @fullName, [StudentNumber] = @StudentNumber, [FirstName] = @FirstName, [LastName] = @LastName, [ClassId] = @ClassId, [StreamId] = @StreamId, [Sex] = @Sex, [StudyStatus] = @StudyStatus, [HouseId] = @HouseId, [Religion] = @Religion, [Guardian] = @Guardian, [FormerSchool] = @FormerSchool, [BursaryStatus] = @BursaryStatus, [RequiredFees] = @RequiredFees, [BursaryProvider] = @BursaryProvider, [AdmissionDate] = @AdmissionDate, [Picture] = @Picture, [HomeCountry] = @HomeCountry, [Status] = @Status, [Notes] = @Notes, [cashOnAccount] = @cashOnAccount WHERE (((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ([StudentNumber] = @Original_StudentNumber) AND ((@IsNull_FirstName = 1 AND [FirstName] IS NULL) OR ([FirstName] = @Original_FirstName)) AND ((@IsNull_LastName = 1 AND [LastName] IS NULL) OR ([LastName] = @Original_LastName)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_Religion = 1 AND [Religion] IS NULL) OR ([Religion] = @Original_Religion)) AND ((@IsNull_Guardian = 1 AND [Guardian] IS NULL) OR ([Guardian] = @Original_Guardian)) AND ((@IsNull_FormerSchool = 1 AND [FormerSchool] IS NULL) OR ([FormerSchool] = @Original_FormerSchool)) AND ((@IsNull_BursaryStatus = 1 AND [BursaryStatus] IS NULL) OR ([BursaryStatus] = @Original_BursaryStatus)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_BursaryProvider = 1 AND [BursaryProvider] IS NULL) OR ([BursaryProvider] = @Original_BursaryProvider)) AND ((@IsNull_AdmissionDate = 1 AND [AdmissionDate] IS NULL) OR ([AdmissionDate] = @Original_AdmissionDate)) AND ((@IsNull_HomeCountry = 1 AND [HomeCountry] IS NULL) OR ([HomeCountry] = @Original_HomeCountry)) AND ((@IsNull_Status = 1 AND [Status] IS NULL) OR ([Status] = @Original_Status)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)));\r\nSELECT fullName, StudentNumber, FirstName, LastName, ClassId, StreamId, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, RequiredFees, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, cashOnAccount FROM tbl_Stud WHERE (StudentNumber = @StudentNumber)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Religion", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FormerSchool", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerSchool", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BursaryStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FirstName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_LastName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BursaryStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryProvider", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_AdmissionDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_AdmissionDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "AdmissionDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HomeCountry", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HomeCountry", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HomeCountry", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitConnection()
	{
		_connection = new SqlConnection();
		_connection.ConnectionString = "Data Source=INTELLIGENT\\SQLEXPRESS;Initial Catalog=IntelligentSRMS;User ID=sa";
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitCommandCollection()
	{
		_commandCollection = new SqlCommand[1];
		_commandCollection[0] = new SqlCommand();
		_commandCollection[0].Connection = Connection;
		_commandCollection[0].CommandText = "SELECT fullName, StudentNumber, FirstName, LastName, ClassId, StreamId, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, RequiredFees, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, cashOnAccount FROM dbo.tbl_Stud";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(dSetStudentIds.studentsDataTable dataTable)
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
	public virtual dSetStudentIds.studentsDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		dSetStudentIds.studentsDataTable studentsDataTable = new dSetStudentIds.studentsDataTable();
		Adapter.Fill(studentsDataTable);
		return studentsDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dSetStudentIds.studentsDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dSetStudentIds dataSet)
	{
		return Adapter.Update(dataSet, "students");
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
	public virtual int Delete(string Original_fullName, string Original_StudentNumber, string Original_FirstName, string Original_LastName, string Original_ClassId, string Original_StreamId, string Original_Sex, string Original_StudyStatus, string Original_HouseId, string Original_Religion, string Original_Guardian, string Original_FormerSchool, string Original_BursaryStatus, decimal? Original_RequiredFees, string Original_BursaryProvider, string Original_AdmissionDate, string Original_HomeCountry, string Original_Status, decimal? Original_cashOnAccount)
	{
		if (Original_fullName == null)
		{
			Adapter.DeleteCommand.Parameters[0].Value = 1;
			Adapter.DeleteCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[0].Value = 0;
			Adapter.DeleteCommand.Parameters[1].Value = Original_fullName;
		}
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.DeleteCommand.Parameters[2].Value = Original_StudentNumber;
		if (Original_FirstName == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_FirstName;
		}
		if (Original_LastName == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_LastName;
		}
		if (Original_ClassId == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_StreamId;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_Sex;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_StudyStatus;
		}
		if (Original_HouseId == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_HouseId;
		}
		if (Original_Religion == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_Religion;
		}
		if (Original_Guardian == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_Guardian;
		}
		if (Original_FormerSchool == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_FormerSchool;
		}
		if (Original_BursaryStatus == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_BursaryStatus;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		if (Original_BursaryProvider == null)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_BursaryProvider;
		}
		if (Original_AdmissionDate == null)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_AdmissionDate;
		}
		if (Original_HomeCountry == null)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_HomeCountry;
		}
		if (Original_Status == null)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_Status;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[35].Value = 0;
			Adapter.DeleteCommand.Parameters[36].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[35].Value = 1;
			Adapter.DeleteCommand.Parameters[36].Value = DBNull.Value;
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
	public virtual int Insert(string fullName, string StudentNumber, string FirstName, string LastName, string ClassId, string StreamId, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, string BursaryStatus, decimal? RequiredFees, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal? cashOnAccount)
	{
		if (fullName == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = fullName;
		}
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.InsertCommand.Parameters[1].Value = StudentNumber;
		if (FirstName == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = FirstName;
		}
		if (LastName == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = LastName;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = ClassId;
		}
		if (StreamId == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = StreamId;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = Sex;
		}
		if (StudyStatus == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = StudyStatus;
		}
		if (HouseId == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = HouseId;
		}
		if (Religion == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = Religion;
		}
		if (Guardian == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = Guardian;
		}
		if (FormerSchool == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = FormerSchool;
		}
		if (BursaryStatus == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = BursaryStatus;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.InsertCommand.Parameters[13].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		if (BursaryProvider == null)
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = BursaryProvider;
		}
		if (AdmissionDate == null)
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = AdmissionDate;
		}
		if (Picture == null)
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = Picture;
		}
		if (HomeCountry == null)
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = HomeCountry;
		}
		if (Status == null)
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = Status;
		}
		if (Notes == null)
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = Notes;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.InsertCommand.Parameters[20].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
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
	public virtual int Update(string fullName, string StudentNumber, string FirstName, string LastName, string ClassId, string StreamId, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, string BursaryStatus, decimal? RequiredFees, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal? cashOnAccount, string Original_fullName, string Original_StudentNumber, string Original_FirstName, string Original_LastName, string Original_ClassId, string Original_StreamId, string Original_Sex, string Original_StudyStatus, string Original_HouseId, string Original_Religion, string Original_Guardian, string Original_FormerSchool, string Original_BursaryStatus, decimal? Original_RequiredFees, string Original_BursaryProvider, string Original_AdmissionDate, string Original_HomeCountry, string Original_Status, decimal? Original_cashOnAccount)
	{
		if (fullName == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = fullName;
		}
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[1].Value = StudentNumber;
		if (FirstName == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = FirstName;
		}
		if (LastName == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = LastName;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = ClassId;
		}
		if (StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = StreamId;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = Sex;
		}
		if (StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = StudyStatus;
		}
		if (HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = HouseId;
		}
		if (Religion == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = Religion;
		}
		if (Guardian == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = Guardian;
		}
		if (FormerSchool == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = FormerSchool;
		}
		if (BursaryStatus == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = BursaryStatus;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[13].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		if (BursaryProvider == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = BursaryProvider;
		}
		if (AdmissionDate == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = AdmissionDate;
		}
		if (Picture == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = Picture;
		}
		if (HomeCountry == null)
		{
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = HomeCountry;
		}
		if (Status == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = Status;
		}
		if (Notes == null)
		{
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = Notes;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[20].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Original_fullName == null)
		{
			Adapter.UpdateCommand.Parameters[21].Value = 1;
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = 0;
			Adapter.UpdateCommand.Parameters[22].Value = Original_fullName;
		}
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[23].Value = Original_StudentNumber;
		if (Original_FirstName == null)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_FirstName;
		}
		if (Original_LastName == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_LastName;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[28].Value = 1;
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = 0;
			Adapter.UpdateCommand.Parameters[29].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = 1;
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = 0;
			Adapter.UpdateCommand.Parameters[31].Value = Original_StreamId;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[32].Value = 1;
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = 0;
			Adapter.UpdateCommand.Parameters[33].Value = Original_Sex;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[34].Value = 1;
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = 0;
			Adapter.UpdateCommand.Parameters[35].Value = Original_StudyStatus;
		}
		if (Original_HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = 1;
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = 0;
			Adapter.UpdateCommand.Parameters[37].Value = Original_HouseId;
		}
		if (Original_Religion == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = 1;
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = 0;
			Adapter.UpdateCommand.Parameters[39].Value = Original_Religion;
		}
		if (Original_Guardian == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = 1;
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = 0;
			Adapter.UpdateCommand.Parameters[41].Value = Original_Guardian;
		}
		if (Original_FormerSchool == null)
		{
			Adapter.UpdateCommand.Parameters[42].Value = 1;
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = 0;
			Adapter.UpdateCommand.Parameters[43].Value = Original_FormerSchool;
		}
		if (Original_BursaryStatus == null)
		{
			Adapter.UpdateCommand.Parameters[44].Value = 1;
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = 0;
			Adapter.UpdateCommand.Parameters[45].Value = Original_BursaryStatus;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[46].Value = 0;
			Adapter.UpdateCommand.Parameters[47].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = 1;
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		if (Original_BursaryProvider == null)
		{
			Adapter.UpdateCommand.Parameters[48].Value = 1;
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = 0;
			Adapter.UpdateCommand.Parameters[49].Value = Original_BursaryProvider;
		}
		if (Original_AdmissionDate == null)
		{
			Adapter.UpdateCommand.Parameters[50].Value = 1;
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = 0;
			Adapter.UpdateCommand.Parameters[51].Value = Original_AdmissionDate;
		}
		if (Original_HomeCountry == null)
		{
			Adapter.UpdateCommand.Parameters[52].Value = 1;
			Adapter.UpdateCommand.Parameters[53].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[52].Value = 0;
			Adapter.UpdateCommand.Parameters[53].Value = Original_HomeCountry;
		}
		if (Original_Status == null)
		{
			Adapter.UpdateCommand.Parameters[54].Value = 1;
			Adapter.UpdateCommand.Parameters[55].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[54].Value = 0;
			Adapter.UpdateCommand.Parameters[55].Value = Original_Status;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[56].Value = 0;
			Adapter.UpdateCommand.Parameters[57].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[56].Value = 1;
			Adapter.UpdateCommand.Parameters[57].Value = DBNull.Value;
		}
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
	public virtual int Update(string fullName, string FirstName, string LastName, string ClassId, string StreamId, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, string BursaryStatus, decimal? RequiredFees, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal? cashOnAccount, string Original_fullName, string Original_StudentNumber, string Original_FirstName, string Original_LastName, string Original_ClassId, string Original_StreamId, string Original_Sex, string Original_StudyStatus, string Original_HouseId, string Original_Religion, string Original_Guardian, string Original_FormerSchool, string Original_BursaryStatus, decimal? Original_RequiredFees, string Original_BursaryProvider, string Original_AdmissionDate, string Original_HomeCountry, string Original_Status, decimal? Original_cashOnAccount)
	{
		return Update(fullName, Original_StudentNumber, FirstName, LastName, ClassId, StreamId, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, RequiredFees, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, cashOnAccount, Original_fullName, Original_StudentNumber, Original_FirstName, Original_LastName, Original_ClassId, Original_StreamId, Original_Sex, Original_StudyStatus, Original_HouseId, Original_Religion, Original_Guardian, Original_FormerSchool, Original_BursaryStatus, Original_RequiredFees, Original_BursaryProvider, Original_AdmissionDate, Original_HomeCountry, Original_Status, Original_cashOnAccount);
	}
}
