using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DataSet_Previews.StudentPreviewClearingCardTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class StudentClearanceSourceTableAdapter : Component
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
	public StudentClearanceSourceTableAdapter()
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
		dataTableMapping.DataSetTable = "StudentClearanceSource";
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("StudentID", "StudentID");
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("StudyStatus", "StudyStatus");
		dataTableMapping.ColumnMappings.Add("BursaryStatus", "BursaryStatus");
		dataTableMapping.ColumnMappings.Add("BursaryProvider", "BursaryProvider");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("RequiredFees", "RequiredFees");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		dataTableMapping.ColumnMappings.Add("FeesDiscount", "FeesDiscount");
		dataTableMapping.ColumnMappings.Add("Status", "Status");
		dataTableMapping.ColumnMappings.Add("Oid", "Oid");
		dataTableMapping.ColumnMappings.Add("auto", "auto");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_Stud] WHERE (([StudentNumber] = @Original_StudentNumber) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_BursaryStatus = 1 AND [BursaryStatus] IS NULL) OR ([BursaryStatus] = @Original_BursaryStatus)) AND ((@IsNull_BursaryProvider = 1 AND [BursaryProvider] IS NULL) OR ([BursaryProvider] = @Original_BursaryProvider)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)) AND ((@IsNull_Status = 1 AND [Status] IS NULL) OR ([Status] = @Original_Status)) AND ([Oid] = @Original_Oid) AND ([auto] = @Original_auto))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudyStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryProvider", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_Stud] ([StudentNumber], [StudentID], [fullName], [ClassId], [StreamId], [Sex], [StudyStatus], [BursaryStatus], [BursaryProvider], [Picture], [RequiredFees], [cashOnAccount], [FeesDiscount], [Status], [Oid]) VALUES (@StudentNumber, @StudentID, @fullName, @ClassId, @StreamId, @Sex, @StudyStatus, @BursaryStatus, @BursaryProvider, @Picture, @RequiredFees, @cashOnAccount, @FeesDiscount, @Status, @Oid);\r\nSELECT StudentNumber, StudentID, fullName, ClassId, StreamId, Sex, StudyStatus, BursaryStatus, BursaryProvider, Picture, RequiredFees, cashOnAccount, FeesDiscount, Status, Oid, auto FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_Stud] SET [StudentNumber] = @StudentNumber, [StudentID] = @StudentID, [fullName] = @fullName, [ClassId] = @ClassId, [StreamId] = @StreamId, [Sex] = @Sex, [StudyStatus] = @StudyStatus, [BursaryStatus] = @BursaryStatus, [BursaryProvider] = @BursaryProvider, [Picture] = @Picture, [RequiredFees] = @RequiredFees, [cashOnAccount] = @cashOnAccount, [FeesDiscount] = @FeesDiscount, [Status] = @Status, [Oid] = @Oid WHERE (([StudentNumber] = @Original_StudentNumber) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_BursaryStatus = 1 AND [BursaryStatus] IS NULL) OR ([BursaryStatus] = @Original_BursaryStatus)) AND ((@IsNull_BursaryProvider = 1 AND [BursaryProvider] IS NULL) OR ([BursaryProvider] = @Original_BursaryProvider)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)) AND ((@IsNull_Status = 1 AND [Status] IS NULL) OR ([Status] = @Original_Status)) AND ([Oid] = @Original_Oid) AND ([auto] = @Original_auto));\r\nSELECT StudentNumber, StudentID, fullName, ClassId, StreamId, Sex, StudyStatus, BursaryStatus, BursaryProvider, Picture, RequiredFees, cashOnAccount, FeesDiscount, Status, Oid, auto FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = @auto)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudyStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BursaryStatus", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "BursaryStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_BursaryProvider", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BursaryProvider", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BursaryProvider", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT StudentNumber, StudentID, fullName, ClassId, StreamId, Sex, StudyStatus, BursaryStatus, BursaryProvider, Picture, RequiredFees, cashOnAccount, FeesDiscount, Status, Oid, auto FROM tbl_Stud WHERE cashOnAccount >= {StudentFeesCard.FeesBalance} AND ClassId = '{StudentFeesCard.ClassId}' AND StreamId = '{StudentFeesCard.StreamId}'";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(StudentPreviewClearingCard.StudentClearanceSourceDataTable dataTable)
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
	public virtual StudentPreviewClearingCard.StudentClearanceSourceDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		StudentPreviewClearingCard.StudentClearanceSourceDataTable studentClearanceSourceDataTable = new StudentPreviewClearingCard.StudentClearanceSourceDataTable();
		Adapter.Fill(studentClearanceSourceDataTable);
		return studentClearanceSourceDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(StudentPreviewClearingCard.StudentClearanceSourceDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(StudentPreviewClearingCard dataSet)
	{
		return Adapter.Update(dataSet, "StudentClearanceSource");
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
	public virtual int Delete(string Original_StudentNumber, string Original_StudentID, string Original_fullName, string Original_ClassId, string Original_StreamId, string Original_Sex, string Original_StudyStatus, bool? Original_BursaryStatus, string Original_BursaryProvider, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, string Original_Status, Guid Original_Oid, long Original_auto)
	{
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.DeleteCommand.Parameters[0].Value = Original_StudentNumber;
		if (Original_StudentID == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_StudentID;
		}
		if (Original_fullName == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_fullName;
		}
		if (Original_ClassId == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_StreamId;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_Sex;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_StudyStatus;
		}
		if (Original_BursaryStatus.HasValue)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_BursaryStatus.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		if (Original_BursaryProvider == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_BursaryProvider;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		if (Original_Status == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_Status;
		}
		Adapter.DeleteCommand.Parameters[25].Value = Original_Oid;
		Adapter.DeleteCommand.Parameters[26].Value = Original_auto;
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
	public virtual int Insert(string StudentNumber, string StudentID, string fullName, string ClassId, string StreamId, string Sex, string StudyStatus, bool? BursaryStatus, string BursaryProvider, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, string Status, Guid Oid)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		if (StudentID == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = StudentID;
		}
		if (fullName == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = fullName;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = ClassId;
		}
		if (StreamId == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = StreamId;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = Sex;
		}
		if (StudyStatus == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = StudyStatus;
		}
		if (BursaryStatus.HasValue)
		{
			Adapter.InsertCommand.Parameters[7].Value = BursaryStatus.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		if (BursaryProvider == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = BursaryProvider;
		}
		if (Picture == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = Picture;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.InsertCommand.Parameters[10].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.InsertCommand.Parameters[11].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.InsertCommand.Parameters[12].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		if (Status == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = Status;
		}
		Adapter.InsertCommand.Parameters[14].Value = Oid;
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
	public virtual int Update(string StudentNumber, string StudentID, string fullName, string ClassId, string StreamId, string Sex, string StudyStatus, bool? BursaryStatus, string BursaryProvider, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, string Status, Guid Oid, string Original_StudentNumber, string Original_StudentID, string Original_fullName, string Original_ClassId, string Original_StreamId, string Original_Sex, string Original_StudyStatus, bool? Original_BursaryStatus, string Original_BursaryProvider, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, string Original_Status, Guid Original_Oid, long Original_auto, long auto)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		if (StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = StudentID;
		}
		if (fullName == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = fullName;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = ClassId;
		}
		if (StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = StreamId;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = Sex;
		}
		if (StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = StudyStatus;
		}
		if (BursaryStatus.HasValue)
		{
			Adapter.UpdateCommand.Parameters[7].Value = BursaryStatus.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		if (BursaryProvider == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = BursaryProvider;
		}
		if (Picture == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = Picture;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[10].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[11].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[12].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		if (Status == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = Status;
		}
		Adapter.UpdateCommand.Parameters[14].Value = Oid;
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[15].Value = Original_StudentNumber;
		if (Original_StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = 1;
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = 0;
			Adapter.UpdateCommand.Parameters[17].Value = Original_StudentID;
		}
		if (Original_fullName == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = 1;
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = 0;
			Adapter.UpdateCommand.Parameters[19].Value = Original_fullName;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = 1;
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = 0;
			Adapter.UpdateCommand.Parameters[21].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = 1;
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = 0;
			Adapter.UpdateCommand.Parameters[23].Value = Original_StreamId;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_Sex;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_StudyStatus;
		}
		if (Original_BursaryStatus.HasValue)
		{
			Adapter.UpdateCommand.Parameters[28].Value = 0;
			Adapter.UpdateCommand.Parameters[29].Value = Original_BursaryStatus.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = 1;
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		if (Original_BursaryProvider == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = 1;
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = 0;
			Adapter.UpdateCommand.Parameters[31].Value = Original_BursaryProvider;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[32].Value = 0;
			Adapter.UpdateCommand.Parameters[33].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = 1;
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[34].Value = 0;
			Adapter.UpdateCommand.Parameters[35].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = 1;
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[36].Value = 0;
			Adapter.UpdateCommand.Parameters[37].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = 1;
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		if (Original_Status == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = 1;
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = 0;
			Adapter.UpdateCommand.Parameters[39].Value = Original_Status;
		}
		Adapter.UpdateCommand.Parameters[40].Value = Original_Oid;
		Adapter.UpdateCommand.Parameters[41].Value = Original_auto;
		Adapter.UpdateCommand.Parameters[42].Value = auto;
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
	public virtual int Update(string StudentID, string fullName, string ClassId, string StreamId, string Sex, string StudyStatus, bool? BursaryStatus, string BursaryProvider, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, string Status, string Original_StudentNumber, string Original_StudentID, string Original_fullName, string Original_ClassId, string Original_StreamId, string Original_Sex, string Original_StudyStatus, bool? Original_BursaryStatus, string Original_BursaryProvider, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, string Original_Status, Guid Original_Oid, long Original_auto)
	{
		return Update(Original_StudentNumber, StudentID, fullName, ClassId, StreamId, Sex, StudyStatus, BursaryStatus, BursaryProvider, Picture, RequiredFees, cashOnAccount, FeesDiscount, Status, Original_Oid, Original_StudentNumber, Original_StudentID, Original_fullName, Original_ClassId, Original_StreamId, Original_Sex, Original_StudyStatus, Original_BursaryStatus, Original_BursaryProvider, Original_RequiredFees, Original_cashOnAccount, Original_FeesDiscount, Original_Status, Original_Oid, Original_auto, Original_auto);
	}
}
