using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.IslamicTheology.TheologyStudSourceTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class tbl_StudTableAdapter : Component
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
	public tbl_StudTableAdapter()
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
		dataTableMapping.DataSetTable = "tbl_Stud";
		dataTableMapping.ColumnMappings.Add("auto", "auto");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("Oid", "Oid");
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("fullNameAr", "fullNameAr");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("ClassIdEn", "ClassIdEn");
		dataTableMapping.ColumnMappings.Add("ClassIdAr", "ClassIdAr");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("StreamAr", "StreamAr");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("SexAr", "SexAr");
		dataTableMapping.ColumnMappings.Add("LIN", "LIN");
		dataTableMapping.ColumnMappings.Add("StreamEn", "StreamEn");
		dataTableMapping.ColumnMappings.Add("StudyStatus", "StudyStatus");
		dataTableMapping.ColumnMappings.Add("HouseId", "HouseId");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("RequiredFees", "RequiredFees");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		dataTableMapping.ColumnMappings.Add("FeesDiscount", "FeesDiscount");
		dataTableMapping.ColumnMappings.Add("StudentID", "StudentID");
		dataTableMapping.ColumnMappings.Add("IsTheologyStud", "IsTheologyStud");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_Stud] WHERE (([auto] = @Original_auto) AND ([StudentNumber] = @Original_StudentNumber) AND ([Oid] = @Original_Oid) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_fullNameAr = 1 AND [fullNameAr] IS NULL) OR ([fullNameAr] = @Original_fullNameAr)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_ClassIdEn = 1 AND [ClassIdEn] IS NULL) OR ([ClassIdEn] = @Original_ClassIdEn)) AND ((@IsNull_ClassIdAr = 1 AND [ClassIdAr] IS NULL) OR ([ClassIdAr] = @Original_ClassIdAr)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_StreamAr = 1 AND [StreamAr] IS NULL) OR ([StreamAr] = @Original_StreamAr)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_SexAr = 1 AND [SexAr] IS NULL) OR ([SexAr] = @Original_SexAr)) AND ((@IsNull_LIN = 1 AND [LIN] IS NULL) OR ([LIN] = @Original_LIN)) AND ((@IsNull_StreamEn = 1 AND [StreamEn] IS NULL) OR ([StreamEn] = @Original_StreamEn)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_IsTheologyStud = 1 AND [IsTheologyStud] IS NULL) OR ([IsTheologyStud] = @Original_IsTheologyStud)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SexAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_LIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamEn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudyStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HouseId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_IsTheologyStud", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_Stud] ([StudentNumber], [Oid], [fullName], [fullNameAr], [ClassId], [ClassIdEn], [ClassIdAr], [StreamId], [StreamAr], [Sex], [SexAr], [LIN], [StreamEn], [StudyStatus], [HouseId], [Picture], [RequiredFees], [cashOnAccount], [FeesDiscount], [StudentID], [IsTheologyStud]) VALUES (@StudentNumber, @Oid, @fullName, @fullNameAr, @ClassId, @ClassIdEn, @ClassIdAr, @StreamId, @StreamAr, @Sex, @SexAr, @LIN, @StreamEn, @StudyStatus, @HouseId, @Picture, @RequiredFees, @cashOnAccount, @FeesDiscount, @StudentID, @IsTheologyStud);\r\nSELECT auto, StudentNumber, Oid, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, SexAr, LIN, StreamEn, StudyStatus, HouseId, Picture, RequiredFees, cashOnAccount, FeesDiscount, StudentID, IsTheologyStud FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullNameAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassIdEn", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassIdAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_Stud] SET [StudentNumber] = @StudentNumber, [Oid] = @Oid, [fullName] = @fullName, [fullNameAr] = @fullNameAr, [ClassId] = @ClassId, [ClassIdEn] = @ClassIdEn, [ClassIdAr] = @ClassIdAr, [StreamId] = @StreamId, [StreamAr] = @StreamAr, [Sex] = @Sex, [SexAr] = @SexAr, [LIN] = @LIN, [StreamEn] = @StreamEn, [StudyStatus] = @StudyStatus, [HouseId] = @HouseId, [Picture] = @Picture, [RequiredFees] = @RequiredFees, [cashOnAccount] = @cashOnAccount, [FeesDiscount] = @FeesDiscount, [StudentID] = @StudentID, [IsTheologyStud] = @IsTheologyStud WHERE (([auto] = @Original_auto) AND ([StudentNumber] = @Original_StudentNumber) AND ([Oid] = @Original_Oid) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_fullNameAr = 1 AND [fullNameAr] IS NULL) OR ([fullNameAr] = @Original_fullNameAr)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_ClassIdEn = 1 AND [ClassIdEn] IS NULL) OR ([ClassIdEn] = @Original_ClassIdEn)) AND ((@IsNull_ClassIdAr = 1 AND [ClassIdAr] IS NULL) OR ([ClassIdAr] = @Original_ClassIdAr)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_StreamAr = 1 AND [StreamAr] IS NULL) OR ([StreamAr] = @Original_StreamAr)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_SexAr = 1 AND [SexAr] IS NULL) OR ([SexAr] = @Original_SexAr)) AND ((@IsNull_LIN = 1 AND [LIN] IS NULL) OR ([LIN] = @Original_LIN)) AND ((@IsNull_StreamEn = 1 AND [StreamEn] IS NULL) OR ([StreamEn] = @Original_StreamEn)) AND ((@IsNull_StudyStatus = 1 AND [StudyStatus] IS NULL) OR ([StudyStatus] = @Original_StudyStatus)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_IsTheologyStud = 1 AND [IsTheologyStud] IS NULL) OR ([IsTheologyStud] = @Original_IsTheologyStud)));\r\nSELECT auto, StudentNumber, Oid, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, SexAr, LIN, StreamEn, StudyStatus, HouseId, Picture, RequiredFees, cashOnAccount, FeesDiscount, StudentID, IsTheologyStud FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = @auto)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullNameAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "fullNameAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassIdEn", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassIdAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassIdAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SexAr", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SexAr", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SexAr", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_LIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamEn", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamEn", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamEn", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudyStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudyStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudyStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HouseId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_IsTheologyStud", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsTheologyStud", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsTheologyStud", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT        auto, StudentNumber, Oid, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, SexAr, LIN, StreamEn, StudyStatus, HouseId, Picture, RequiredFees, cashOnAccount, FeesDiscount, StudentID, \r\n                         IsTheologyStud\r\nFROM            tbl_Stud\r\nWHERE        (IsTheologyStud = 1) AND (ClassIdEn = '{ReportParameters.Class}')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(TheologyStudSource.tbl_StudDataTable dataTable)
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
	public virtual TheologyStudSource.tbl_StudDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		TheologyStudSource.tbl_StudDataTable tbl_StudDataTable = new TheologyStudSource.tbl_StudDataTable();
		Adapter.Fill(tbl_StudDataTable);
		return tbl_StudDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(TheologyStudSource.tbl_StudDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(TheologyStudSource dataSet)
	{
		return Adapter.Update(dataSet, "tbl_Stud");
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
	public virtual int Delete(long Original_auto, string Original_StudentNumber, Guid Original_Oid, string Original_fullName, string Original_fullNameAr, string Original_ClassId, string Original_ClassIdEn, string Original_ClassIdAr, string Original_StreamId, string Original_StreamAr, string Original_Sex, string Original_SexAr, string Original_LIN, string Original_StreamEn, string Original_StudyStatus, string Original_HouseId, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, string Original_StudentID, bool? Original_IsTheologyStud)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_auto;
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.DeleteCommand.Parameters[1].Value = Original_StudentNumber;
		Adapter.DeleteCommand.Parameters[2].Value = Original_Oid;
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
		if (Original_fullNameAr == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_fullNameAr;
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
		if (Original_ClassIdEn == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_ClassIdEn;
		}
		if (Original_ClassIdAr == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_ClassIdAr;
		}
		if (Original_StreamId == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_StreamId;
		}
		if (Original_StreamAr == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_StreamAr;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_Sex;
		}
		if (Original_SexAr == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_SexAr;
		}
		if (Original_LIN == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_LIN;
		}
		if (Original_StreamEn == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_StreamEn;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_StudyStatus;
		}
		if (Original_HouseId == null)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_HouseId;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		if (Original_StudentID == null)
		{
			Adapter.DeleteCommand.Parameters[35].Value = 1;
			Adapter.DeleteCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[35].Value = 0;
			Adapter.DeleteCommand.Parameters[36].Value = Original_StudentID;
		}
		if (Original_IsTheologyStud.HasValue)
		{
			Adapter.DeleteCommand.Parameters[37].Value = 0;
			Adapter.DeleteCommand.Parameters[38].Value = Original_IsTheologyStud.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[37].Value = 1;
			Adapter.DeleteCommand.Parameters[38].Value = DBNull.Value;
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
	public virtual int Insert(string StudentNumber, Guid Oid, string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string SexAr, string LIN, string StreamEn, string StudyStatus, string HouseId, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, string StudentID, bool? IsTheologyStud)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		Adapter.InsertCommand.Parameters[1].Value = Oid;
		if (fullName == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = fullName;
		}
		if (fullNameAr == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = fullNameAr;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = ClassId;
		}
		if (ClassIdEn == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = ClassIdEn;
		}
		if (ClassIdAr == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = ClassIdAr;
		}
		if (StreamId == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = StreamId;
		}
		if (StreamAr == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = StreamAr;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = Sex;
		}
		if (SexAr == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = SexAr;
		}
		if (LIN == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = LIN;
		}
		if (StreamEn == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = StreamEn;
		}
		if (StudyStatus == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = StudyStatus;
		}
		if (HouseId == null)
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = HouseId;
		}
		if (Picture == null)
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = Picture;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.InsertCommand.Parameters[16].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.InsertCommand.Parameters[17].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.InsertCommand.Parameters[18].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		if (StudentID == null)
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = StudentID;
		}
		if (IsTheologyStud.HasValue)
		{
			Adapter.InsertCommand.Parameters[20].Value = IsTheologyStud.Value;
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
	public virtual int Update(string StudentNumber, Guid Oid, string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string SexAr, string LIN, string StreamEn, string StudyStatus, string HouseId, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, string StudentID, bool? IsTheologyStud, long Original_auto, string Original_StudentNumber, Guid Original_Oid, string Original_fullName, string Original_fullNameAr, string Original_ClassId, string Original_ClassIdEn, string Original_ClassIdAr, string Original_StreamId, string Original_StreamAr, string Original_Sex, string Original_SexAr, string Original_LIN, string Original_StreamEn, string Original_StudyStatus, string Original_HouseId, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, string Original_StudentID, bool? Original_IsTheologyStud, long auto)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		Adapter.UpdateCommand.Parameters[1].Value = Oid;
		if (fullName == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = fullName;
		}
		if (fullNameAr == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = fullNameAr;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = ClassId;
		}
		if (ClassIdEn == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = ClassIdEn;
		}
		if (ClassIdAr == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = ClassIdAr;
		}
		if (StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = StreamId;
		}
		if (StreamAr == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = StreamAr;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = Sex;
		}
		if (SexAr == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = SexAr;
		}
		if (LIN == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = LIN;
		}
		if (StreamEn == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = StreamEn;
		}
		if (StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = StudyStatus;
		}
		if (HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = HouseId;
		}
		if (Picture == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = Picture;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[16].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[17].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[18].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		if (StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = StudentID;
		}
		if (IsTheologyStud.HasValue)
		{
			Adapter.UpdateCommand.Parameters[20].Value = IsTheologyStud.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		Adapter.UpdateCommand.Parameters[21].Value = Original_auto;
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[22].Value = Original_StudentNumber;
		Adapter.UpdateCommand.Parameters[23].Value = Original_Oid;
		if (Original_fullName == null)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_fullName;
		}
		if (Original_fullNameAr == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_fullNameAr;
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
		if (Original_ClassIdEn == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = 1;
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = 0;
			Adapter.UpdateCommand.Parameters[31].Value = Original_ClassIdEn;
		}
		if (Original_ClassIdAr == null)
		{
			Adapter.UpdateCommand.Parameters[32].Value = 1;
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = 0;
			Adapter.UpdateCommand.Parameters[33].Value = Original_ClassIdAr;
		}
		if (Original_StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[34].Value = 1;
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = 0;
			Adapter.UpdateCommand.Parameters[35].Value = Original_StreamId;
		}
		if (Original_StreamAr == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = 1;
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = 0;
			Adapter.UpdateCommand.Parameters[37].Value = Original_StreamAr;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = 1;
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = 0;
			Adapter.UpdateCommand.Parameters[39].Value = Original_Sex;
		}
		if (Original_SexAr == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = 1;
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = 0;
			Adapter.UpdateCommand.Parameters[41].Value = Original_SexAr;
		}
		if (Original_LIN == null)
		{
			Adapter.UpdateCommand.Parameters[42].Value = 1;
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = 0;
			Adapter.UpdateCommand.Parameters[43].Value = Original_LIN;
		}
		if (Original_StreamEn == null)
		{
			Adapter.UpdateCommand.Parameters[44].Value = 1;
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = 0;
			Adapter.UpdateCommand.Parameters[45].Value = Original_StreamEn;
		}
		if (Original_StudyStatus == null)
		{
			Adapter.UpdateCommand.Parameters[46].Value = 1;
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = 0;
			Adapter.UpdateCommand.Parameters[47].Value = Original_StudyStatus;
		}
		if (Original_HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[48].Value = 1;
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = 0;
			Adapter.UpdateCommand.Parameters[49].Value = Original_HouseId;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[50].Value = 0;
			Adapter.UpdateCommand.Parameters[51].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = 1;
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[52].Value = 0;
			Adapter.UpdateCommand.Parameters[53].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[52].Value = 1;
			Adapter.UpdateCommand.Parameters[53].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[54].Value = 0;
			Adapter.UpdateCommand.Parameters[55].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[54].Value = 1;
			Adapter.UpdateCommand.Parameters[55].Value = DBNull.Value;
		}
		if (Original_StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[56].Value = 1;
			Adapter.UpdateCommand.Parameters[57].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[56].Value = 0;
			Adapter.UpdateCommand.Parameters[57].Value = Original_StudentID;
		}
		if (Original_IsTheologyStud.HasValue)
		{
			Adapter.UpdateCommand.Parameters[58].Value = 0;
			Adapter.UpdateCommand.Parameters[59].Value = Original_IsTheologyStud.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[58].Value = 1;
			Adapter.UpdateCommand.Parameters[59].Value = DBNull.Value;
		}
		Adapter.UpdateCommand.Parameters[60].Value = auto;
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
	public virtual int Update(string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string SexAr, string LIN, string StreamEn, string StudyStatus, string HouseId, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, string StudentID, bool? IsTheologyStud, long Original_auto, string Original_StudentNumber, Guid Original_Oid, string Original_fullName, string Original_fullNameAr, string Original_ClassId, string Original_ClassIdEn, string Original_ClassIdAr, string Original_StreamId, string Original_StreamAr, string Original_Sex, string Original_SexAr, string Original_LIN, string Original_StreamEn, string Original_StudyStatus, string Original_HouseId, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, string Original_StudentID, bool? Original_IsTheologyStud)
	{
		return Update(Original_StudentNumber, Original_Oid, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId, StreamAr, Sex, SexAr, LIN, StreamEn, StudyStatus, HouseId, Picture, RequiredFees, cashOnAccount, FeesDiscount, StudentID, IsTheologyStud, Original_auto, Original_StudentNumber, Original_Oid, Original_fullName, Original_fullNameAr, Original_ClassId, Original_ClassIdEn, Original_ClassIdAr, Original_StreamId, Original_StreamAr, Original_Sex, Original_SexAr, Original_LIN, Original_StreamEn, Original_StudyStatus, Original_HouseId, Original_RequiredFees, Original_cashOnAccount, Original_FeesDiscount, Original_StudentID, Original_IsTheologyStud, Original_auto);
	}
}
