using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.DataSet_Previews.GatePassTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class tbl_GatePassTableAdapter : Component
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
	public tbl_GatePassTableAdapter()
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
		dataTableMapping.DataSetTable = "tbl_GatePass";
		dataTableMapping.ColumnMappings.Add("passNo", "passNo");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("Name", "Name");
		dataTableMapping.ColumnMappings.Add("Class", "Class");
		dataTableMapping.ColumnMappings.Add("Stream", "Stream");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("DB", "DB");
		dataTableMapping.ColumnMappings.Add("Guardian", "Guardian");
		dataTableMapping.ColumnMappings.Add("CreatedBy", "CreatedBy");
		dataTableMapping.ColumnMappings.Add("SemesterId", "SemesterId");
		dataTableMapping.ColumnMappings.Add("CreateDate", "CreateDate");
		dataTableMapping.ColumnMappings.Add("PassType", "PassType");
		dataTableMapping.ColumnMappings.Add("Destination", "Destination");
		dataTableMapping.ColumnMappings.Add("ReturnDate", "ReturnDate");
		dataTableMapping.ColumnMappings.Add("ReturnTime", "ReturnTime");
		dataTableMapping.ColumnMappings.Add("amount", "amount");
		dataTableMapping.ColumnMappings.Add("amountInWords", "amountInWords");
		dataTableMapping.ColumnMappings.Add("pic", "pic");
		dataTableMapping.ColumnMappings.Add("CaptureDate", "CaptureDate");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_GatePass] WHERE (([passNo] = @Original_passNo) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Class = 1 AND [Class] IS NULL) OR ([Class] = @Original_Class)) AND ((@IsNull_Stream = 1 AND [Stream] IS NULL) OR ([Stream] = @Original_Stream)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_DB = 1 AND [DB] IS NULL) OR ([DB] = @Original_DB)) AND ((@IsNull_Guardian = 1 AND [Guardian] IS NULL) OR ([Guardian] = @Original_Guardian)) AND ((@IsNull_CreatedBy = 1 AND [CreatedBy] IS NULL) OR ([CreatedBy] = @Original_CreatedBy)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_CreateDate = 1 AND [CreateDate] IS NULL) OR ([CreateDate] = @Original_CreateDate)) AND ((@IsNull_PassType = 1 AND [PassType] IS NULL) OR ([PassType] = @Original_PassType)) AND ((@IsNull_Destination = 1 AND [Destination] IS NULL) OR ([Destination] = @Original_Destination)) AND ((@IsNull_ReturnDate = 1 AND [ReturnDate] IS NULL) OR ([ReturnDate] = @Original_ReturnDate)) AND ((@IsNull_ReturnTime = 1 AND [ReturnTime] IS NULL) OR ([ReturnTime] = @Original_ReturnTime)) AND ((@IsNull_amount = 1 AND [amount] IS NULL) OR ([amount] = @Original_amount)) AND ((@IsNull_CaptureDate = 1 AND [CaptureDate] IS NULL) OR ([CaptureDate] = @Original_CaptureDate)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_passNo", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "passNo", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Class", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Class", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Class", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Class", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Stream", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Stream", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Stream", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Stream", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_DB", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DB", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DB", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DB", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Guardian", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_CreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_CreatedBy", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_CreateDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CreateDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_CreateDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PassType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PassType", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PassType", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PassType", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Destination", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Destination", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Destination", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Destination", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ReturnDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ReturnDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ReturnTime", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnTime", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ReturnTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnTime", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_amount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "amount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_amount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "amount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_CaptureDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_GatePass] ([StudentNumber], [Name], [Class], [Stream], [Sex], [DB], [Guardian], [CreatedBy], [SemesterId], [CreateDate], [PassType], [Destination], [ReturnDate], [ReturnTime], [amount], [amountInWords], [pic], [CaptureDate]) VALUES (@StudentNumber, @Name, @Class, @Stream, @Sex, @DB, @Guardian, @CreatedBy, @SemesterId, @CreateDate, @PassType, @Destination, @ReturnDate, @ReturnTime, @amount, @amountInWords, @pic, @CaptureDate);\r\nSELECT passNo, StudentNumber, Name, Class, Stream, Sex, DB, Guardian, CreatedBy, SemesterId, CreateDate, PassType, Destination, ReturnDate, ReturnTime, amount, amountInWords, pic, CaptureDate FROM tbl_GatePass WHERE (passNo = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Class", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Stream", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Stream", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@DB", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DB", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PassType", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PassType", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Destination", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Destination", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ReturnTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnTime", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@amount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "amount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@amountInWords", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "amountInWords", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "pic", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_GatePass] SET [StudentNumber] = @StudentNumber, [Name] = @Name, [Class] = @Class, [Stream] = @Stream, [Sex] = @Sex, [DB] = @DB, [Guardian] = @Guardian, [CreatedBy] = @CreatedBy, [SemesterId] = @SemesterId, [CreateDate] = @CreateDate, [PassType] = @PassType, [Destination] = @Destination, [ReturnDate] = @ReturnDate, [ReturnTime] = @ReturnTime, [amount] = @amount, [amountInWords] = @amountInWords, [pic] = @pic, [CaptureDate] = @CaptureDate WHERE (([passNo] = @Original_passNo) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Class = 1 AND [Class] IS NULL) OR ([Class] = @Original_Class)) AND ((@IsNull_Stream = 1 AND [Stream] IS NULL) OR ([Stream] = @Original_Stream)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_DB = 1 AND [DB] IS NULL) OR ([DB] = @Original_DB)) AND ((@IsNull_Guardian = 1 AND [Guardian] IS NULL) OR ([Guardian] = @Original_Guardian)) AND ((@IsNull_CreatedBy = 1 AND [CreatedBy] IS NULL) OR ([CreatedBy] = @Original_CreatedBy)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_CreateDate = 1 AND [CreateDate] IS NULL) OR ([CreateDate] = @Original_CreateDate)) AND ((@IsNull_PassType = 1 AND [PassType] IS NULL) OR ([PassType] = @Original_PassType)) AND ((@IsNull_Destination = 1 AND [Destination] IS NULL) OR ([Destination] = @Original_Destination)) AND ((@IsNull_ReturnDate = 1 AND [ReturnDate] IS NULL) OR ([ReturnDate] = @Original_ReturnDate)) AND ((@IsNull_ReturnTime = 1 AND [ReturnTime] IS NULL) OR ([ReturnTime] = @Original_ReturnTime)) AND ((@IsNull_amount = 1 AND [amount] IS NULL) OR ([amount] = @Original_amount)) AND ((@IsNull_CaptureDate = 1 AND [CaptureDate] IS NULL) OR ([CaptureDate] = @Original_CaptureDate)));\r\nSELECT passNo, StudentNumber, Name, Class, Stream, Sex, DB, Guardian, CreatedBy, SemesterId, CreateDate, PassType, Destination, ReturnDate, ReturnTime, amount, amountInWords, pic, CaptureDate FROM tbl_GatePass WHERE (passNo = @passNo)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Class", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Class", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Stream", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Stream", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DB", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DB", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PassType", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PassType", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Destination", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Destination", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ReturnDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ReturnTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnTime", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@amount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "amount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@amountInWords", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "amountInWords", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "pic", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_passNo", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "passNo", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Name", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Class", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Class", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Class", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Class", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Stream", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Stream", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Stream", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Stream", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_DB", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DB", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DB", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DB", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Guardian", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Guardian", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Guardian", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_CreatedBy", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_CreatedBy", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CreatedBy", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_CreateDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CreateDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_CreateDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "CreateDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PassType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PassType", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PassType", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PassType", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Destination", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Destination", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Destination", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Destination", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ReturnDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ReturnDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ReturnTime", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnTime", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ReturnTime", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ReturnTime", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_amount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "amount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_amount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "amount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_CaptureDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@passNo", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "passNo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = "SELECT        passNo, StudentNumber, Name, Class, Stream, Sex, DB, Guardian, CreatedBy, SemesterId, CreateDate, PassType, Destination, ReturnDate, ReturnTime, amount, amountInWords, pic, CaptureDate\r\nFROM            tbl_GatePass";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(GatePass.tbl_GatePassDataTable dataTable)
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
	public virtual GatePass.tbl_GatePassDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		GatePass.tbl_GatePassDataTable tbl_GatePassDataTable = new GatePass.tbl_GatePassDataTable();
		Adapter.Fill(tbl_GatePassDataTable);
		return tbl_GatePassDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(GatePass.tbl_GatePassDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(GatePass dataSet)
	{
		return Adapter.Update(dataSet, "tbl_GatePass");
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
	public virtual int Delete(long Original_passNo, string Original_StudentNumber, string Original_Name, string Original_Class, string Original_Stream, string Original_Sex, string Original_DB, string Original_Guardian, string Original_CreatedBy, string Original_SemesterId, DateTime? Original_CreateDate, string Original_PassType, string Original_Destination, DateTime? Original_ReturnDate, DateTime? Original_ReturnTime, decimal? Original_amount, string Original_CaptureDate)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_passNo;
		if (Original_StudentNumber == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_StudentNumber;
		}
		if (Original_Name == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_Name;
		}
		if (Original_Class == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_Class;
		}
		if (Original_Stream == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_Stream;
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
		if (Original_DB == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_DB;
		}
		if (Original_Guardian == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_Guardian;
		}
		if (Original_CreatedBy == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_CreatedBy;
		}
		if (Original_SemesterId == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_SemesterId;
		}
		if (Original_CreateDate.HasValue)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_CreateDate.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Original_PassType == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_PassType;
		}
		if (Original_Destination == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_Destination;
		}
		if (Original_ReturnDate.HasValue)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_ReturnDate.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		if (Original_ReturnTime.HasValue)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_ReturnTime.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		if (Original_amount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_amount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Original_CaptureDate == null)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_CaptureDate;
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
	public virtual int Insert(string StudentNumber, string Name, string Class, string Stream, string Sex, string DB, string Guardian, string CreatedBy, string SemesterId, DateTime? CreateDate, string PassType, string Destination, DateTime? ReturnDate, DateTime? ReturnTime, decimal? amount, string amountInWords, byte[] pic, string CaptureDate)
	{
		if (StudentNumber == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		}
		if (Name == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = Name;
		}
		if (Class == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = Class;
		}
		if (Stream == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = Stream;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = Sex;
		}
		if (DB == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = DB;
		}
		if (Guardian == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = Guardian;
		}
		if (CreatedBy == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = CreatedBy;
		}
		if (SemesterId == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = SemesterId;
		}
		if (CreateDate.HasValue)
		{
			Adapter.InsertCommand.Parameters[9].Value = CreateDate.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		if (PassType == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = PassType;
		}
		if (Destination == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = Destination;
		}
		if (ReturnDate.HasValue)
		{
			Adapter.InsertCommand.Parameters[12].Value = ReturnDate.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		if (ReturnTime.HasValue)
		{
			Adapter.InsertCommand.Parameters[13].Value = ReturnTime.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		if (amount.HasValue)
		{
			Adapter.InsertCommand.Parameters[14].Value = amount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		if (amountInWords == null)
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = amountInWords;
		}
		if (pic == null)
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = pic;
		}
		if (CaptureDate == null)
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = CaptureDate;
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
	public virtual int Update(string StudentNumber, string Name, string Class, string Stream, string Sex, string DB, string Guardian, string CreatedBy, string SemesterId, DateTime? CreateDate, string PassType, string Destination, DateTime? ReturnDate, DateTime? ReturnTime, decimal? amount, string amountInWords, byte[] pic, string CaptureDate, long Original_passNo, string Original_StudentNumber, string Original_Name, string Original_Class, string Original_Stream, string Original_Sex, string Original_DB, string Original_Guardian, string Original_CreatedBy, string Original_SemesterId, DateTime? Original_CreateDate, string Original_PassType, string Original_Destination, DateTime? Original_ReturnDate, DateTime? Original_ReturnTime, decimal? Original_amount, string Original_CaptureDate, long passNo)
	{
		if (StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		}
		if (Name == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = Name;
		}
		if (Class == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = Class;
		}
		if (Stream == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = Stream;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = Sex;
		}
		if (DB == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = DB;
		}
		if (Guardian == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = Guardian;
		}
		if (CreatedBy == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = CreatedBy;
		}
		if (SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = SemesterId;
		}
		if (CreateDate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[9].Value = CreateDate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		if (PassType == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = PassType;
		}
		if (Destination == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = Destination;
		}
		if (ReturnDate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[12].Value = ReturnDate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		if (ReturnTime.HasValue)
		{
			Adapter.UpdateCommand.Parameters[13].Value = ReturnTime.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		if (amount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[14].Value = amount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		if (amountInWords == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = amountInWords;
		}
		if (pic == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = pic;
		}
		if (CaptureDate == null)
		{
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = CaptureDate;
		}
		Adapter.UpdateCommand.Parameters[18].Value = Original_passNo;
		if (Original_StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[19].Value = 1;
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = 0;
			Adapter.UpdateCommand.Parameters[20].Value = Original_StudentNumber;
		}
		if (Original_Name == null)
		{
			Adapter.UpdateCommand.Parameters[21].Value = 1;
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = 0;
			Adapter.UpdateCommand.Parameters[22].Value = Original_Name;
		}
		if (Original_Class == null)
		{
			Adapter.UpdateCommand.Parameters[23].Value = 1;
			Adapter.UpdateCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[23].Value = 0;
			Adapter.UpdateCommand.Parameters[24].Value = Original_Class;
		}
		if (Original_Stream == null)
		{
			Adapter.UpdateCommand.Parameters[25].Value = 1;
			Adapter.UpdateCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[25].Value = 0;
			Adapter.UpdateCommand.Parameters[26].Value = Original_Stream;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[27].Value = 1;
			Adapter.UpdateCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[27].Value = 0;
			Adapter.UpdateCommand.Parameters[28].Value = Original_Sex;
		}
		if (Original_DB == null)
		{
			Adapter.UpdateCommand.Parameters[29].Value = 1;
			Adapter.UpdateCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[29].Value = 0;
			Adapter.UpdateCommand.Parameters[30].Value = Original_DB;
		}
		if (Original_Guardian == null)
		{
			Adapter.UpdateCommand.Parameters[31].Value = 1;
			Adapter.UpdateCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[31].Value = 0;
			Adapter.UpdateCommand.Parameters[32].Value = Original_Guardian;
		}
		if (Original_CreatedBy == null)
		{
			Adapter.UpdateCommand.Parameters[33].Value = 1;
			Adapter.UpdateCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[33].Value = 0;
			Adapter.UpdateCommand.Parameters[34].Value = Original_CreatedBy;
		}
		if (Original_SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[35].Value = 1;
			Adapter.UpdateCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[35].Value = 0;
			Adapter.UpdateCommand.Parameters[36].Value = Original_SemesterId;
		}
		if (Original_CreateDate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[37].Value = 0;
			Adapter.UpdateCommand.Parameters[38].Value = Original_CreateDate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[37].Value = 1;
			Adapter.UpdateCommand.Parameters[38].Value = DBNull.Value;
		}
		if (Original_PassType == null)
		{
			Adapter.UpdateCommand.Parameters[39].Value = 1;
			Adapter.UpdateCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[39].Value = 0;
			Adapter.UpdateCommand.Parameters[40].Value = Original_PassType;
		}
		if (Original_Destination == null)
		{
			Adapter.UpdateCommand.Parameters[41].Value = 1;
			Adapter.UpdateCommand.Parameters[42].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[41].Value = 0;
			Adapter.UpdateCommand.Parameters[42].Value = Original_Destination;
		}
		if (Original_ReturnDate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[43].Value = 0;
			Adapter.UpdateCommand.Parameters[44].Value = Original_ReturnDate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[43].Value = 1;
			Adapter.UpdateCommand.Parameters[44].Value = DBNull.Value;
		}
		if (Original_ReturnTime.HasValue)
		{
			Adapter.UpdateCommand.Parameters[45].Value = 0;
			Adapter.UpdateCommand.Parameters[46].Value = Original_ReturnTime.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[45].Value = 1;
			Adapter.UpdateCommand.Parameters[46].Value = DBNull.Value;
		}
		if (Original_amount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[47].Value = 0;
			Adapter.UpdateCommand.Parameters[48].Value = Original_amount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[47].Value = 1;
			Adapter.UpdateCommand.Parameters[48].Value = DBNull.Value;
		}
		if (Original_CaptureDate == null)
		{
			Adapter.UpdateCommand.Parameters[49].Value = 1;
			Adapter.UpdateCommand.Parameters[50].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[49].Value = 0;
			Adapter.UpdateCommand.Parameters[50].Value = Original_CaptureDate;
		}
		Adapter.UpdateCommand.Parameters[51].Value = passNo;
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
	public virtual int Update(string StudentNumber, string Name, string Class, string Stream, string Sex, string DB, string Guardian, string CreatedBy, string SemesterId, DateTime? CreateDate, string PassType, string Destination, DateTime? ReturnDate, DateTime? ReturnTime, decimal? amount, string amountInWords, byte[] pic, string CaptureDate, long Original_passNo, string Original_StudentNumber, string Original_Name, string Original_Class, string Original_Stream, string Original_Sex, string Original_DB, string Original_Guardian, string Original_CreatedBy, string Original_SemesterId, DateTime? Original_CreateDate, string Original_PassType, string Original_Destination, DateTime? Original_ReturnDate, DateTime? Original_ReturnTime, decimal? Original_amount, string Original_CaptureDate)
	{
		return Update(StudentNumber, Name, Class, Stream, Sex, DB, Guardian, CreatedBy, SemesterId, CreateDate, PassType, Destination, ReturnDate, ReturnTime, amount, amountInWords, pic, CaptureDate, Original_passNo, Original_StudentNumber, Original_Name, Original_Class, Original_Stream, Original_Sex, Original_DB, Original_Guardian, Original_CreatedBy, Original_SemesterId, Original_CreateDate, Original_PassType, Original_Destination, Original_ReturnDate, Original_ReturnTime, Original_amount, Original_CaptureDate, Original_passNo);
	}
}
