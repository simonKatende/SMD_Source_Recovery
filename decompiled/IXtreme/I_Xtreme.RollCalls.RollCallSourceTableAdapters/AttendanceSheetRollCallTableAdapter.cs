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

namespace I_Xtreme.RollCalls.RollCallSourceTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class AttendanceSheetRollCallTableAdapter : Component
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
	public AttendanceSheetRollCallTableAdapter()
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
		dataTableMapping.DataSetTable = "AttendanceSheetRollCall";
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("Name", "Name");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("StudentId", "StudentId");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("Date1", "Date1");
		dataTableMapping.ColumnMappings.Add("Date2", "Date2");
		dataTableMapping.ColumnMappings.Add("Date3", "Date3");
		dataTableMapping.ColumnMappings.Add("Date4", "Date4");
		dataTableMapping.ColumnMappings.Add("Date5", "Date5");
		dataTableMapping.ColumnMappings.Add("Date6", "Date6");
		dataTableMapping.ColumnMappings.Add("Date7", "Date7");
		dataTableMapping.ColumnMappings.Add("Flag", "Flag");
		dataTableMapping.ColumnMappings.Add("Date8", "Date8");
		dataTableMapping.ColumnMappings.Add("Date9", "Date9");
		dataTableMapping.ColumnMappings.Add("Date10", "Date10");
		dataTableMapping.ColumnMappings.Add("Date11", "Date11");
		dataTableMapping.ColumnMappings.Add("Date12", "Date12");
		dataTableMapping.ColumnMappings.Add("Date13", "Date13");
		dataTableMapping.ColumnMappings.Add("Date14", "Date14");
		dataTableMapping.ColumnMappings.Add("Date15", "Date15");
		dataTableMapping.ColumnMappings.Add("Date16", "Date16");
		dataTableMapping.ColumnMappings.Add("Date17", "Date17");
		dataTableMapping.ColumnMappings.Add("Date18", "Date18");
		dataTableMapping.ColumnMappings.Add("Date19", "Date19");
		dataTableMapping.ColumnMappings.Add("Date20", "Date20");
		dataTableMapping.ColumnMappings.Add("Date21", "Date21");
		dataTableMapping.ColumnMappings.Add("Date22", "Date22");
		dataTableMapping.ColumnMappings.Add("Date23", "Date23");
		dataTableMapping.ColumnMappings.Add("Date24", "Date24");
		dataTableMapping.ColumnMappings.Add("Date25", "Date25");
		dataTableMapping.ColumnMappings.Add("Date26", "Date26");
		dataTableMapping.ColumnMappings.Add("Date27", "Date27");
		dataTableMapping.ColumnMappings.Add("Date28", "Date28");
		dataTableMapping.ColumnMappings.Add("Date29", "Date29");
		dataTableMapping.ColumnMappings.Add("Date30", "Date30");
		dataTableMapping.ColumnMappings.Add("Date31", "Date31");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("UserId", "UserId");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [AttendanceSheetRollCall] WHERE (([Id] = @Original_Id) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_StudentId = 1 AND [StudentId] IS NULL) OR ([StudentId] = @Original_StudentId)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_Date1 = 1 AND [Date1] IS NULL) OR ([Date1] = @Original_Date1)) AND ((@IsNull_Date2 = 1 AND [Date2] IS NULL) OR ([Date2] = @Original_Date2)) AND ((@IsNull_Date3 = 1 AND [Date3] IS NULL) OR ([Date3] = @Original_Date3)) AND ((@IsNull_Date4 = 1 AND [Date4] IS NULL) OR ([Date4] = @Original_Date4)) AND ((@IsNull_Date5 = 1 AND [Date5] IS NULL) OR ([Date5] = @Original_Date5)) AND ((@IsNull_Date6 = 1 AND [Date6] IS NULL) OR ([Date6] = @Original_Date6)) AND ((@IsNull_Date7 = 1 AND [Date7] IS NULL) OR ([Date7] = @Original_Date7)) AND ((@IsNull_Flag = 1 AND [Flag] IS NULL) OR ([Flag] = @Original_Flag)) AND ((@IsNull_Date8 = 1 AND [Date8] IS NULL) OR ([Date8] = @Original_Date8)) AND ((@IsNull_Date9 = 1 AND [Date9] IS NULL) OR ([Date9] = @Original_Date9)) AND ((@IsNull_Date10 = 1 AND [Date10] IS NULL) OR ([Date10] = @Original_Date10)) AND ((@IsNull_Date11 = 1 AND [Date11] IS NULL) OR ([Date11] = @Original_Date11)) AND ((@IsNull_Date12 = 1 AND [Date12] IS NULL) OR ([Date12] = @Original_Date12)) AND ((@IsNull_Date13 = 1 AND [Date13] IS NULL) OR ([Date13] = @Original_Date13)) AND ((@IsNull_Date14 = 1 AND [Date14] IS NULL) OR ([Date14] = @Original_Date14)) AND ((@IsNull_Date15 = 1 AND [Date15] IS NULL) OR ([Date15] = @Original_Date15)) AND ((@IsNull_Date16 = 1 AND [Date16] IS NULL) OR ([Date16] = @Original_Date16)) AND ((@IsNull_Date17 = 1 AND [Date17] IS NULL) OR ([Date17] = @Original_Date17)) AND ((@IsNull_Date18 = 1 AND [Date18] IS NULL) OR ([Date18] = @Original_Date18)) AND ((@IsNull_Date19 = 1 AND [Date19] IS NULL) OR ([Date19] = @Original_Date19)) AND ((@IsNull_Date20 = 1 AND [Date20] IS NULL) OR ([Date20] = @Original_Date20)) AND ((@IsNull_Date21 = 1 AND [Date21] IS NULL) OR ([Date21] = @Original_Date21)) AND ((@IsNull_Date22 = 1 AND [Date22] IS NULL) OR ([Date22] = @Original_Date22)) AND ((@IsNull_Date23 = 1 AND [Date23] IS NULL) OR ([Date23] = @Original_Date23)) AND ((@IsNull_Date24 = 1 AND [Date24] IS NULL) OR ([Date24] = @Original_Date24)) AND ((@IsNull_Date25 = 1 AND [Date25] IS NULL) OR ([Date25] = @Original_Date25)) AND ((@IsNull_Date26 = 1 AND [Date26] IS NULL) OR ([Date26] = @Original_Date26)) AND ((@IsNull_Date27 = 1 AND [Date27] IS NULL) OR ([Date27] = @Original_Date27)) AND ((@IsNull_Date28 = 1 AND [Date28] IS NULL) OR ([Date28] = @Original_Date28)) AND ((@IsNull_Date29 = 1 AND [Date29] IS NULL) OR ([Date29] = @Original_Date29)) AND ((@IsNull_Date30 = 1 AND [Date30] IS NULL) OR ([Date30] = @Original_Date30)) AND ((@IsNull_Date31 = 1 AND [Date31] IS NULL) OR ([Date31] = @Original_Date31)) AND ((@IsNull_UserId = 1 AND [UserId] IS NULL) OR ([UserId] = @Original_UserId)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date1", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date2", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date3", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date4", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date5", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date6", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date6", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date6", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date6", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date7", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date7", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date7", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date7", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Flag", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Flag", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Flag", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Flag", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date8", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date8", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date8", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date8", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date9", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date9", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date9", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date9", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date10", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date10", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date10", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date10", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date11", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date11", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date11", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date11", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date12", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date12", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date12", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date12", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date13", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date13", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date13", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date13", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date14", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date14", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date14", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date14", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date15", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date15", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date15", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date15", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date16", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date16", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date16", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date16", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date17", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date17", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date17", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date17", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date18", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date18", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date18", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date18", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date19", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date19", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date19", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date19", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date20", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date20", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date20", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date20", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date21", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date21", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date21", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date21", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date22", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date22", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date22", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date22", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date23", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date23", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date23", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date23", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date24", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date24", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date24", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date24", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date25", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date25", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date25", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date25", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date26", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date26", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date26", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date26", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date27", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date27", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date27", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date27", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date28", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date28", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date28", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date28", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date29", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date29", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date29", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date29", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date30", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date30", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date30", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date30", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Date31", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date31", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Date31", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date31", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_UserId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "UserId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_UserId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UserId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [AttendanceSheetRollCall] ([Name], [Sex], [StudentNumber], [StudentId], [ClassId], [StreamId], [Date1], [Date2], [Date3], [Date4], [Date5], [Date6], [Date7], [Flag], [Date8], [Date9], [Date10], [Date11], [Date12], [Date13], [Date14], [Date15], [Date16], [Date17], [Date18], [Date19], [Date20], [Date21], [Date22], [Date23], [Date24], [Date25], [Date26], [Date27], [Date28], [Date29], [Date30], [Date31], [UserId]) VALUES (@Name, @Sex, @StudentNumber, @StudentId, @ClassId, @StreamId, @Date1, @Date2, @Date3, @Date4, @Date5, @Date6, @Date7, @Flag, @Date8, @Date9, @Date10, @Date11, @Date12, @Date13, @Date14, @Date15, @Date16, @Date17, @Date18, @Date19, @Date20, @Date21, @Date22, @Date23, @Date24, @Date25, @Date26, @Date27, @Date28, @Date29, @Date30, @Date31, @UserId);\r\nSELECT Id, Name, Sex, StudentNumber, StudentId, ClassId, StreamId, Date1, Date2, Date3, Date4, Date5, Date6, Date7, Flag, Date8, Date9, Date10, Date11, Date12, Date13, Date14, Date15, Date16, Date17, Date18, Date19, Date20, Date21, Date22, Date23, Date24, Date25, Date26, Date27, Date28, Date29, Date30, Date31, UserId FROM AttendanceSheetRollCall WHERE (Id = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date1", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date2", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date3", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date4", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date5", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date6", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date6", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date7", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date7", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Flag", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Flag", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date8", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date8", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date9", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date9", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date10", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date10", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date11", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date11", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date12", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date12", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date13", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date13", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date14", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date14", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date15", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date15", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date16", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date16", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date17", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date17", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date18", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date18", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date19", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date19", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date20", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date20", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date21", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date21", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date22", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date22", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date23", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date23", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date24", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date24", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date25", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date25", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date26", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date26", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date27", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date27", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date28", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date28", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date29", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date29", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date30", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date30", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date31", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date31", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UserId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [AttendanceSheetRollCall] SET [Name] = @Name, [Sex] = @Sex, [StudentNumber] = @StudentNumber, [StudentId] = @StudentId, [ClassId] = @ClassId, [StreamId] = @StreamId, [Date1] = @Date1, [Date2] = @Date2, [Date3] = @Date3, [Date4] = @Date4, [Date5] = @Date5, [Date6] = @Date6, [Date7] = @Date7, [Flag] = @Flag, [Date8] = @Date8, [Date9] = @Date9, [Date10] = @Date10, [Date11] = @Date11, [Date12] = @Date12, [Date13] = @Date13, [Date14] = @Date14, [Date15] = @Date15, [Date16] = @Date16, [Date17] = @Date17, [Date18] = @Date18, [Date19] = @Date19, [Date20] = @Date20, [Date21] = @Date21, [Date22] = @Date22, [Date23] = @Date23, [Date24] = @Date24, [Date25] = @Date25, [Date26] = @Date26, [Date27] = @Date27, [Date28] = @Date28, [Date29] = @Date29, [Date30] = @Date30, [Date31] = @Date31, [UserId] = @UserId WHERE (([Id] = @Original_Id) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_StudentId = 1 AND [StudentId] IS NULL) OR ([StudentId] = @Original_StudentId)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_Date1 = 1 AND [Date1] IS NULL) OR ([Date1] = @Original_Date1)) AND ((@IsNull_Date2 = 1 AND [Date2] IS NULL) OR ([Date2] = @Original_Date2)) AND ((@IsNull_Date3 = 1 AND [Date3] IS NULL) OR ([Date3] = @Original_Date3)) AND ((@IsNull_Date4 = 1 AND [Date4] IS NULL) OR ([Date4] = @Original_Date4)) AND ((@IsNull_Date5 = 1 AND [Date5] IS NULL) OR ([Date5] = @Original_Date5)) AND ((@IsNull_Date6 = 1 AND [Date6] IS NULL) OR ([Date6] = @Original_Date6)) AND ((@IsNull_Date7 = 1 AND [Date7] IS NULL) OR ([Date7] = @Original_Date7)) AND ((@IsNull_Flag = 1 AND [Flag] IS NULL) OR ([Flag] = @Original_Flag)) AND ((@IsNull_Date8 = 1 AND [Date8] IS NULL) OR ([Date8] = @Original_Date8)) AND ((@IsNull_Date9 = 1 AND [Date9] IS NULL) OR ([Date9] = @Original_Date9)) AND ((@IsNull_Date10 = 1 AND [Date10] IS NULL) OR ([Date10] = @Original_Date10)) AND ((@IsNull_Date11 = 1 AND [Date11] IS NULL) OR ([Date11] = @Original_Date11)) AND ((@IsNull_Date12 = 1 AND [Date12] IS NULL) OR ([Date12] = @Original_Date12)) AND ((@IsNull_Date13 = 1 AND [Date13] IS NULL) OR ([Date13] = @Original_Date13)) AND ((@IsNull_Date14 = 1 AND [Date14] IS NULL) OR ([Date14] = @Original_Date14)) AND ((@IsNull_Date15 = 1 AND [Date15] IS NULL) OR ([Date15] = @Original_Date15)) AND ((@IsNull_Date16 = 1 AND [Date16] IS NULL) OR ([Date16] = @Original_Date16)) AND ((@IsNull_Date17 = 1 AND [Date17] IS NULL) OR ([Date17] = @Original_Date17)) AND ((@IsNull_Date18 = 1 AND [Date18] IS NULL) OR ([Date18] = @Original_Date18)) AND ((@IsNull_Date19 = 1 AND [Date19] IS NULL) OR ([Date19] = @Original_Date19)) AND ((@IsNull_Date20 = 1 AND [Date20] IS NULL) OR ([Date20] = @Original_Date20)) AND ((@IsNull_Date21 = 1 AND [Date21] IS NULL) OR ([Date21] = @Original_Date21)) AND ((@IsNull_Date22 = 1 AND [Date22] IS NULL) OR ([Date22] = @Original_Date22)) AND ((@IsNull_Date23 = 1 AND [Date23] IS NULL) OR ([Date23] = @Original_Date23)) AND ((@IsNull_Date24 = 1 AND [Date24] IS NULL) OR ([Date24] = @Original_Date24)) AND ((@IsNull_Date25 = 1 AND [Date25] IS NULL) OR ([Date25] = @Original_Date25)) AND ((@IsNull_Date26 = 1 AND [Date26] IS NULL) OR ([Date26] = @Original_Date26)) AND ((@IsNull_Date27 = 1 AND [Date27] IS NULL) OR ([Date27] = @Original_Date27)) AND ((@IsNull_Date28 = 1 AND [Date28] IS NULL) OR ([Date28] = @Original_Date28)) AND ((@IsNull_Date29 = 1 AND [Date29] IS NULL) OR ([Date29] = @Original_Date29)) AND ((@IsNull_Date30 = 1 AND [Date30] IS NULL) OR ([Date30] = @Original_Date30)) AND ((@IsNull_Date31 = 1 AND [Date31] IS NULL) OR ([Date31] = @Original_Date31)) AND ((@IsNull_UserId = 1 AND [UserId] IS NULL) OR ([UserId] = @Original_UserId)));\r\nSELECT Id, Name, Sex, StudentNumber, StudentId, ClassId, StreamId, Date1, Date2, Date3, Date4, Date5, Date6, Date7, Flag, Date8, Date9, Date10, Date11, Date12, Date13, Date14, Date15, Date16, Date17, Date18, Date19, Date20, Date21, Date22, Date23, Date24, Date25, Date26, Date27, Date28, Date29, Date30, Date31, UserId FROM AttendanceSheetRollCall WHERE (Id = @Id)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date1", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date2", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date3", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date4", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date5", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date6", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date6", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date7", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date7", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Flag", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Flag", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date8", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date8", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date9", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date9", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date10", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date10", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date11", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date11", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date12", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date12", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date13", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date13", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date14", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date14", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date15", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date15", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date16", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date16", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date17", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date17", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date18", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date18", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date19", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date19", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date20", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date20", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date21", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date21", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date22", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date22", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date23", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date23", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date24", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date24", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date25", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date25", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date26", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date26", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date27", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date27", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date28", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date28", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date29", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date29", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date30", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date30", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Date31", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date31", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UserId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StudentId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date1", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date2", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date3", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date4", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date5", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date6", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date6", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date6", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date6", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date7", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date7", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date7", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date7", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Flag", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Flag", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Flag", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Flag", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date8", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date8", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date8", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date8", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date9", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date9", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date9", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date9", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date10", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date10", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date10", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date10", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date11", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date11", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date11", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date11", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date12", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date12", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date12", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date12", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date13", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date13", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date13", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date13", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date14", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date14", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date14", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date14", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date15", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date15", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date15", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date15", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date16", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date16", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date16", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date16", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date17", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date17", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date17", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date17", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date18", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date18", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date18", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date18", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date19", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date19", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date19", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date19", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date20", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date20", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date20", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date20", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date21", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date21", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date21", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date21", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date22", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date22", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date22", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date22", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date23", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date23", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date23", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date23", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date24", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date24", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date24", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date24", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date25", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date25", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date25", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date25", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date26", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date26", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date26", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date26", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date27", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date27", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date27", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date27", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date28", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date28", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date28", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date28", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date29", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date29", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date29", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date29", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date30", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date30", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date30", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date30", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Date31", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date31", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Date31", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date31", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_UserId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "UserId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_UserId", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "UserId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT        Id, Name, Sex, StudentNumber, StudentId, ClassId, StreamId, Date1, Date2, Date3, Date4, Date5, Date6, Date7, Flag, Date8, Date9, Date10, Date11, Date12, Date13, Date14, Date15, Date16, Date17, Date18, Date19, Date20, \r\n                         Date21, Date22, Date23, Date24, Date25, Date26, Date27, Date28, Date29, Date30, Date31, UserId\r\nFROM            AttendanceSheetRollCall\r\nWHERE        (ClassId = '{RollCallHelper.ClassId}') AND (StreamId = '{RollCallHelper.StreamId}') AND (UserId = '{CurrentUser.UserID}')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(RollCallSource.AttendanceSheetRollCallDataTable dataTable)
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
	public virtual RollCallSource.AttendanceSheetRollCallDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		RollCallSource.AttendanceSheetRollCallDataTable attendanceSheetRollCallDataTable = new RollCallSource.AttendanceSheetRollCallDataTable();
		Adapter.Fill(attendanceSheetRollCallDataTable);
		return attendanceSheetRollCallDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(RollCallSource.AttendanceSheetRollCallDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(RollCallSource dataSet)
	{
		return Adapter.Update(dataSet, "AttendanceSheetRollCall");
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
	public virtual int Delete(long Original_Id, string Original_Name, string Original_Sex, string Original_StudentNumber, string Original_StudentId, string Original_ClassId, string Original_StreamId, DateTime? Original_Date1, DateTime? Original_Date2, DateTime? Original_Date3, DateTime? Original_Date4, DateTime? Original_Date5, DateTime? Original_Date6, DateTime? Original_Date7, string Original_Flag, DateTime? Original_Date8, DateTime? Original_Date9, DateTime? Original_Date10, DateTime? Original_Date11, DateTime? Original_Date12, DateTime? Original_Date13, DateTime? Original_Date14, DateTime? Original_Date15, DateTime? Original_Date16, DateTime? Original_Date17, DateTime? Original_Date18, DateTime? Original_Date19, DateTime? Original_Date20, DateTime? Original_Date21, DateTime? Original_Date22, DateTime? Original_Date23, DateTime? Original_Date24, DateTime? Original_Date25, DateTime? Original_Date26, DateTime? Original_Date27, DateTime? Original_Date28, DateTime? Original_Date29, DateTime? Original_Date30, DateTime? Original_Date31, string Original_UserId)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_Id;
		if (Original_Name == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_Name;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_Sex;
		}
		if (Original_StudentNumber == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_StudentNumber;
		}
		if (Original_StudentId == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_StudentId;
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
		if (Original_StreamId == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_StreamId;
		}
		if (Original_Date1.HasValue)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_Date1.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		if (Original_Date2.HasValue)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_Date2.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		if (Original_Date3.HasValue)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_Date3.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		if (Original_Date4.HasValue)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_Date4.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Original_Date5.HasValue)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_Date5.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		if (Original_Date6.HasValue)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_Date6.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		if (Original_Date7.HasValue)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_Date7.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		if (Original_Flag == null)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_Flag;
		}
		if (Original_Date8.HasValue)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_Date8.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Original_Date9.HasValue)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_Date9.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		if (Original_Date10.HasValue)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_Date10.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		if (Original_Date11.HasValue)
		{
			Adapter.DeleteCommand.Parameters[35].Value = 0;
			Adapter.DeleteCommand.Parameters[36].Value = Original_Date11.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[35].Value = 1;
			Adapter.DeleteCommand.Parameters[36].Value = DBNull.Value;
		}
		if (Original_Date12.HasValue)
		{
			Adapter.DeleteCommand.Parameters[37].Value = 0;
			Adapter.DeleteCommand.Parameters[38].Value = Original_Date12.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[37].Value = 1;
			Adapter.DeleteCommand.Parameters[38].Value = DBNull.Value;
		}
		if (Original_Date13.HasValue)
		{
			Adapter.DeleteCommand.Parameters[39].Value = 0;
			Adapter.DeleteCommand.Parameters[40].Value = Original_Date13.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[39].Value = 1;
			Adapter.DeleteCommand.Parameters[40].Value = DBNull.Value;
		}
		if (Original_Date14.HasValue)
		{
			Adapter.DeleteCommand.Parameters[41].Value = 0;
			Adapter.DeleteCommand.Parameters[42].Value = Original_Date14.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[41].Value = 1;
			Adapter.DeleteCommand.Parameters[42].Value = DBNull.Value;
		}
		if (Original_Date15.HasValue)
		{
			Adapter.DeleteCommand.Parameters[43].Value = 0;
			Adapter.DeleteCommand.Parameters[44].Value = Original_Date15.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[43].Value = 1;
			Adapter.DeleteCommand.Parameters[44].Value = DBNull.Value;
		}
		if (Original_Date16.HasValue)
		{
			Adapter.DeleteCommand.Parameters[45].Value = 0;
			Adapter.DeleteCommand.Parameters[46].Value = Original_Date16.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[45].Value = 1;
			Adapter.DeleteCommand.Parameters[46].Value = DBNull.Value;
		}
		if (Original_Date17.HasValue)
		{
			Adapter.DeleteCommand.Parameters[47].Value = 0;
			Adapter.DeleteCommand.Parameters[48].Value = Original_Date17.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[47].Value = 1;
			Adapter.DeleteCommand.Parameters[48].Value = DBNull.Value;
		}
		if (Original_Date18.HasValue)
		{
			Adapter.DeleteCommand.Parameters[49].Value = 0;
			Adapter.DeleteCommand.Parameters[50].Value = Original_Date18.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[49].Value = 1;
			Adapter.DeleteCommand.Parameters[50].Value = DBNull.Value;
		}
		if (Original_Date19.HasValue)
		{
			Adapter.DeleteCommand.Parameters[51].Value = 0;
			Adapter.DeleteCommand.Parameters[52].Value = Original_Date19.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[51].Value = 1;
			Adapter.DeleteCommand.Parameters[52].Value = DBNull.Value;
		}
		if (Original_Date20.HasValue)
		{
			Adapter.DeleteCommand.Parameters[53].Value = 0;
			Adapter.DeleteCommand.Parameters[54].Value = Original_Date20.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[53].Value = 1;
			Adapter.DeleteCommand.Parameters[54].Value = DBNull.Value;
		}
		if (Original_Date21.HasValue)
		{
			Adapter.DeleteCommand.Parameters[55].Value = 0;
			Adapter.DeleteCommand.Parameters[56].Value = Original_Date21.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[55].Value = 1;
			Adapter.DeleteCommand.Parameters[56].Value = DBNull.Value;
		}
		if (Original_Date22.HasValue)
		{
			Adapter.DeleteCommand.Parameters[57].Value = 0;
			Adapter.DeleteCommand.Parameters[58].Value = Original_Date22.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[57].Value = 1;
			Adapter.DeleteCommand.Parameters[58].Value = DBNull.Value;
		}
		if (Original_Date23.HasValue)
		{
			Adapter.DeleteCommand.Parameters[59].Value = 0;
			Adapter.DeleteCommand.Parameters[60].Value = Original_Date23.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[59].Value = 1;
			Adapter.DeleteCommand.Parameters[60].Value = DBNull.Value;
		}
		if (Original_Date24.HasValue)
		{
			Adapter.DeleteCommand.Parameters[61].Value = 0;
			Adapter.DeleteCommand.Parameters[62].Value = Original_Date24.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[61].Value = 1;
			Adapter.DeleteCommand.Parameters[62].Value = DBNull.Value;
		}
		if (Original_Date25.HasValue)
		{
			Adapter.DeleteCommand.Parameters[63].Value = 0;
			Adapter.DeleteCommand.Parameters[64].Value = Original_Date25.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[63].Value = 1;
			Adapter.DeleteCommand.Parameters[64].Value = DBNull.Value;
		}
		if (Original_Date26.HasValue)
		{
			Adapter.DeleteCommand.Parameters[65].Value = 0;
			Adapter.DeleteCommand.Parameters[66].Value = Original_Date26.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[65].Value = 1;
			Adapter.DeleteCommand.Parameters[66].Value = DBNull.Value;
		}
		if (Original_Date27.HasValue)
		{
			Adapter.DeleteCommand.Parameters[67].Value = 0;
			Adapter.DeleteCommand.Parameters[68].Value = Original_Date27.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[67].Value = 1;
			Adapter.DeleteCommand.Parameters[68].Value = DBNull.Value;
		}
		if (Original_Date28.HasValue)
		{
			Adapter.DeleteCommand.Parameters[69].Value = 0;
			Adapter.DeleteCommand.Parameters[70].Value = Original_Date28.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[69].Value = 1;
			Adapter.DeleteCommand.Parameters[70].Value = DBNull.Value;
		}
		if (Original_Date29.HasValue)
		{
			Adapter.DeleteCommand.Parameters[71].Value = 0;
			Adapter.DeleteCommand.Parameters[72].Value = Original_Date29.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[71].Value = 1;
			Adapter.DeleteCommand.Parameters[72].Value = DBNull.Value;
		}
		if (Original_Date30.HasValue)
		{
			Adapter.DeleteCommand.Parameters[73].Value = 0;
			Adapter.DeleteCommand.Parameters[74].Value = Original_Date30.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[73].Value = 1;
			Adapter.DeleteCommand.Parameters[74].Value = DBNull.Value;
		}
		if (Original_Date31.HasValue)
		{
			Adapter.DeleteCommand.Parameters[75].Value = 0;
			Adapter.DeleteCommand.Parameters[76].Value = Original_Date31.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[75].Value = 1;
			Adapter.DeleteCommand.Parameters[76].Value = DBNull.Value;
		}
		if (Original_UserId == null)
		{
			Adapter.DeleteCommand.Parameters[77].Value = 1;
			Adapter.DeleteCommand.Parameters[78].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[77].Value = 0;
			Adapter.DeleteCommand.Parameters[78].Value = Original_UserId;
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
	public virtual int Insert(string Name, string Sex, string StudentNumber, string StudentId, string ClassId, string StreamId, DateTime? Date1, DateTime? Date2, DateTime? Date3, DateTime? Date4, DateTime? Date5, DateTime? Date6, DateTime? Date7, string Flag, DateTime? Date8, DateTime? Date9, DateTime? Date10, DateTime? Date11, DateTime? Date12, DateTime? Date13, DateTime? Date14, DateTime? Date15, DateTime? Date16, DateTime? Date17, DateTime? Date18, DateTime? Date19, DateTime? Date20, DateTime? Date21, DateTime? Date22, DateTime? Date23, DateTime? Date24, DateTime? Date25, DateTime? Date26, DateTime? Date27, DateTime? Date28, DateTime? Date29, DateTime? Date30, DateTime? Date31, string UserId)
	{
		if (Name == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = Name;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = Sex;
		}
		if (StudentNumber == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = StudentNumber;
		}
		if (StudentId == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = StudentId;
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
		if (Date1.HasValue)
		{
			Adapter.InsertCommand.Parameters[6].Value = Date1.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		if (Date2.HasValue)
		{
			Adapter.InsertCommand.Parameters[7].Value = Date2.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		if (Date3.HasValue)
		{
			Adapter.InsertCommand.Parameters[8].Value = Date3.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		if (Date4.HasValue)
		{
			Adapter.InsertCommand.Parameters[9].Value = Date4.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		if (Date5.HasValue)
		{
			Adapter.InsertCommand.Parameters[10].Value = Date5.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		if (Date6.HasValue)
		{
			Adapter.InsertCommand.Parameters[11].Value = Date6.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		if (Date7.HasValue)
		{
			Adapter.InsertCommand.Parameters[12].Value = Date7.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		if (Flag == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = Flag;
		}
		if (Date8.HasValue)
		{
			Adapter.InsertCommand.Parameters[14].Value = Date8.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		if (Date9.HasValue)
		{
			Adapter.InsertCommand.Parameters[15].Value = Date9.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		if (Date10.HasValue)
		{
			Adapter.InsertCommand.Parameters[16].Value = Date10.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		if (Date11.HasValue)
		{
			Adapter.InsertCommand.Parameters[17].Value = Date11.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		if (Date12.HasValue)
		{
			Adapter.InsertCommand.Parameters[18].Value = Date12.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		if (Date13.HasValue)
		{
			Adapter.InsertCommand.Parameters[19].Value = Date13.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		if (Date14.HasValue)
		{
			Adapter.InsertCommand.Parameters[20].Value = Date14.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Date15.HasValue)
		{
			Adapter.InsertCommand.Parameters[21].Value = Date15.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[21].Value = DBNull.Value;
		}
		if (Date16.HasValue)
		{
			Adapter.InsertCommand.Parameters[22].Value = Date16.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[22].Value = DBNull.Value;
		}
		if (Date17.HasValue)
		{
			Adapter.InsertCommand.Parameters[23].Value = Date17.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[23].Value = DBNull.Value;
		}
		if (Date18.HasValue)
		{
			Adapter.InsertCommand.Parameters[24].Value = Date18.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[24].Value = DBNull.Value;
		}
		if (Date19.HasValue)
		{
			Adapter.InsertCommand.Parameters[25].Value = Date19.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[25].Value = DBNull.Value;
		}
		if (Date20.HasValue)
		{
			Adapter.InsertCommand.Parameters[26].Value = Date20.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[26].Value = DBNull.Value;
		}
		if (Date21.HasValue)
		{
			Adapter.InsertCommand.Parameters[27].Value = Date21.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[27].Value = DBNull.Value;
		}
		if (Date22.HasValue)
		{
			Adapter.InsertCommand.Parameters[28].Value = Date22.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[28].Value = DBNull.Value;
		}
		if (Date23.HasValue)
		{
			Adapter.InsertCommand.Parameters[29].Value = Date23.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[29].Value = DBNull.Value;
		}
		if (Date24.HasValue)
		{
			Adapter.InsertCommand.Parameters[30].Value = Date24.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Date25.HasValue)
		{
			Adapter.InsertCommand.Parameters[31].Value = Date25.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[31].Value = DBNull.Value;
		}
		if (Date26.HasValue)
		{
			Adapter.InsertCommand.Parameters[32].Value = Date26.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[32].Value = DBNull.Value;
		}
		if (Date27.HasValue)
		{
			Adapter.InsertCommand.Parameters[33].Value = Date27.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[33].Value = DBNull.Value;
		}
		if (Date28.HasValue)
		{
			Adapter.InsertCommand.Parameters[34].Value = Date28.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[34].Value = DBNull.Value;
		}
		if (Date29.HasValue)
		{
			Adapter.InsertCommand.Parameters[35].Value = Date29.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[35].Value = DBNull.Value;
		}
		if (Date30.HasValue)
		{
			Adapter.InsertCommand.Parameters[36].Value = Date30.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[36].Value = DBNull.Value;
		}
		if (Date31.HasValue)
		{
			Adapter.InsertCommand.Parameters[37].Value = Date31.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[37].Value = DBNull.Value;
		}
		if (UserId == null)
		{
			Adapter.InsertCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[38].Value = UserId;
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
	public virtual int Update(string Name, string Sex, string StudentNumber, string StudentId, string ClassId, string StreamId, DateTime? Date1, DateTime? Date2, DateTime? Date3, DateTime? Date4, DateTime? Date5, DateTime? Date6, DateTime? Date7, string Flag, DateTime? Date8, DateTime? Date9, DateTime? Date10, DateTime? Date11, DateTime? Date12, DateTime? Date13, DateTime? Date14, DateTime? Date15, DateTime? Date16, DateTime? Date17, DateTime? Date18, DateTime? Date19, DateTime? Date20, DateTime? Date21, DateTime? Date22, DateTime? Date23, DateTime? Date24, DateTime? Date25, DateTime? Date26, DateTime? Date27, DateTime? Date28, DateTime? Date29, DateTime? Date30, DateTime? Date31, string UserId, long Original_Id, string Original_Name, string Original_Sex, string Original_StudentNumber, string Original_StudentId, string Original_ClassId, string Original_StreamId, DateTime? Original_Date1, DateTime? Original_Date2, DateTime? Original_Date3, DateTime? Original_Date4, DateTime? Original_Date5, DateTime? Original_Date6, DateTime? Original_Date7, string Original_Flag, DateTime? Original_Date8, DateTime? Original_Date9, DateTime? Original_Date10, DateTime? Original_Date11, DateTime? Original_Date12, DateTime? Original_Date13, DateTime? Original_Date14, DateTime? Original_Date15, DateTime? Original_Date16, DateTime? Original_Date17, DateTime? Original_Date18, DateTime? Original_Date19, DateTime? Original_Date20, DateTime? Original_Date21, DateTime? Original_Date22, DateTime? Original_Date23, DateTime? Original_Date24, DateTime? Original_Date25, DateTime? Original_Date26, DateTime? Original_Date27, DateTime? Original_Date28, DateTime? Original_Date29, DateTime? Original_Date30, DateTime? Original_Date31, string Original_UserId, long Id)
	{
		if (Name == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = Name;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = Sex;
		}
		if (StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = StudentNumber;
		}
		if (StudentId == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = StudentId;
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
		if (Date1.HasValue)
		{
			Adapter.UpdateCommand.Parameters[6].Value = Date1.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		if (Date2.HasValue)
		{
			Adapter.UpdateCommand.Parameters[7].Value = Date2.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		if (Date3.HasValue)
		{
			Adapter.UpdateCommand.Parameters[8].Value = Date3.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		if (Date4.HasValue)
		{
			Adapter.UpdateCommand.Parameters[9].Value = Date4.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		if (Date5.HasValue)
		{
			Adapter.UpdateCommand.Parameters[10].Value = Date5.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		if (Date6.HasValue)
		{
			Adapter.UpdateCommand.Parameters[11].Value = Date6.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		if (Date7.HasValue)
		{
			Adapter.UpdateCommand.Parameters[12].Value = Date7.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		if (Flag == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = Flag;
		}
		if (Date8.HasValue)
		{
			Adapter.UpdateCommand.Parameters[14].Value = Date8.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		if (Date9.HasValue)
		{
			Adapter.UpdateCommand.Parameters[15].Value = Date9.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		if (Date10.HasValue)
		{
			Adapter.UpdateCommand.Parameters[16].Value = Date10.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		if (Date11.HasValue)
		{
			Adapter.UpdateCommand.Parameters[17].Value = Date11.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		if (Date12.HasValue)
		{
			Adapter.UpdateCommand.Parameters[18].Value = Date12.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		if (Date13.HasValue)
		{
			Adapter.UpdateCommand.Parameters[19].Value = Date13.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		if (Date14.HasValue)
		{
			Adapter.UpdateCommand.Parameters[20].Value = Date14.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Date15.HasValue)
		{
			Adapter.UpdateCommand.Parameters[21].Value = Date15.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		if (Date16.HasValue)
		{
			Adapter.UpdateCommand.Parameters[22].Value = Date16.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		if (Date17.HasValue)
		{
			Adapter.UpdateCommand.Parameters[23].Value = Date17.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		if (Date18.HasValue)
		{
			Adapter.UpdateCommand.Parameters[24].Value = Date18.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = DBNull.Value;
		}
		if (Date19.HasValue)
		{
			Adapter.UpdateCommand.Parameters[25].Value = Date19.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		if (Date20.HasValue)
		{
			Adapter.UpdateCommand.Parameters[26].Value = Date20.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = DBNull.Value;
		}
		if (Date21.HasValue)
		{
			Adapter.UpdateCommand.Parameters[27].Value = Date21.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		if (Date22.HasValue)
		{
			Adapter.UpdateCommand.Parameters[28].Value = Date22.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = DBNull.Value;
		}
		if (Date23.HasValue)
		{
			Adapter.UpdateCommand.Parameters[29].Value = Date23.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		if (Date24.HasValue)
		{
			Adapter.UpdateCommand.Parameters[30].Value = Date24.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Date25.HasValue)
		{
			Adapter.UpdateCommand.Parameters[31].Value = Date25.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		if (Date26.HasValue)
		{
			Adapter.UpdateCommand.Parameters[32].Value = Date26.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = DBNull.Value;
		}
		if (Date27.HasValue)
		{
			Adapter.UpdateCommand.Parameters[33].Value = Date27.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		if (Date28.HasValue)
		{
			Adapter.UpdateCommand.Parameters[34].Value = Date28.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = DBNull.Value;
		}
		if (Date29.HasValue)
		{
			Adapter.UpdateCommand.Parameters[35].Value = Date29.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		if (Date30.HasValue)
		{
			Adapter.UpdateCommand.Parameters[36].Value = Date30.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = DBNull.Value;
		}
		if (Date31.HasValue)
		{
			Adapter.UpdateCommand.Parameters[37].Value = Date31.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		if (UserId == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = UserId;
		}
		Adapter.UpdateCommand.Parameters[39].Value = Original_Id;
		if (Original_Name == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = 1;
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = 0;
			Adapter.UpdateCommand.Parameters[41].Value = Original_Name;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[42].Value = 1;
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = 0;
			Adapter.UpdateCommand.Parameters[43].Value = Original_Sex;
		}
		if (Original_StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[44].Value = 1;
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = 0;
			Adapter.UpdateCommand.Parameters[45].Value = Original_StudentNumber;
		}
		if (Original_StudentId == null)
		{
			Adapter.UpdateCommand.Parameters[46].Value = 1;
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = 0;
			Adapter.UpdateCommand.Parameters[47].Value = Original_StudentId;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[48].Value = 1;
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = 0;
			Adapter.UpdateCommand.Parameters[49].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[50].Value = 1;
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = 0;
			Adapter.UpdateCommand.Parameters[51].Value = Original_StreamId;
		}
		if (Original_Date1.HasValue)
		{
			Adapter.UpdateCommand.Parameters[52].Value = 0;
			Adapter.UpdateCommand.Parameters[53].Value = Original_Date1.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[52].Value = 1;
			Adapter.UpdateCommand.Parameters[53].Value = DBNull.Value;
		}
		if (Original_Date2.HasValue)
		{
			Adapter.UpdateCommand.Parameters[54].Value = 0;
			Adapter.UpdateCommand.Parameters[55].Value = Original_Date2.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[54].Value = 1;
			Adapter.UpdateCommand.Parameters[55].Value = DBNull.Value;
		}
		if (Original_Date3.HasValue)
		{
			Adapter.UpdateCommand.Parameters[56].Value = 0;
			Adapter.UpdateCommand.Parameters[57].Value = Original_Date3.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[56].Value = 1;
			Adapter.UpdateCommand.Parameters[57].Value = DBNull.Value;
		}
		if (Original_Date4.HasValue)
		{
			Adapter.UpdateCommand.Parameters[58].Value = 0;
			Adapter.UpdateCommand.Parameters[59].Value = Original_Date4.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[58].Value = 1;
			Adapter.UpdateCommand.Parameters[59].Value = DBNull.Value;
		}
		if (Original_Date5.HasValue)
		{
			Adapter.UpdateCommand.Parameters[60].Value = 0;
			Adapter.UpdateCommand.Parameters[61].Value = Original_Date5.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[60].Value = 1;
			Adapter.UpdateCommand.Parameters[61].Value = DBNull.Value;
		}
		if (Original_Date6.HasValue)
		{
			Adapter.UpdateCommand.Parameters[62].Value = 0;
			Adapter.UpdateCommand.Parameters[63].Value = Original_Date6.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[62].Value = 1;
			Adapter.UpdateCommand.Parameters[63].Value = DBNull.Value;
		}
		if (Original_Date7.HasValue)
		{
			Adapter.UpdateCommand.Parameters[64].Value = 0;
			Adapter.UpdateCommand.Parameters[65].Value = Original_Date7.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[64].Value = 1;
			Adapter.UpdateCommand.Parameters[65].Value = DBNull.Value;
		}
		if (Original_Flag == null)
		{
			Adapter.UpdateCommand.Parameters[66].Value = 1;
			Adapter.UpdateCommand.Parameters[67].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[66].Value = 0;
			Adapter.UpdateCommand.Parameters[67].Value = Original_Flag;
		}
		if (Original_Date8.HasValue)
		{
			Adapter.UpdateCommand.Parameters[68].Value = 0;
			Adapter.UpdateCommand.Parameters[69].Value = Original_Date8.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[68].Value = 1;
			Adapter.UpdateCommand.Parameters[69].Value = DBNull.Value;
		}
		if (Original_Date9.HasValue)
		{
			Adapter.UpdateCommand.Parameters[70].Value = 0;
			Adapter.UpdateCommand.Parameters[71].Value = Original_Date9.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[70].Value = 1;
			Adapter.UpdateCommand.Parameters[71].Value = DBNull.Value;
		}
		if (Original_Date10.HasValue)
		{
			Adapter.UpdateCommand.Parameters[72].Value = 0;
			Adapter.UpdateCommand.Parameters[73].Value = Original_Date10.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[72].Value = 1;
			Adapter.UpdateCommand.Parameters[73].Value = DBNull.Value;
		}
		if (Original_Date11.HasValue)
		{
			Adapter.UpdateCommand.Parameters[74].Value = 0;
			Adapter.UpdateCommand.Parameters[75].Value = Original_Date11.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[74].Value = 1;
			Adapter.UpdateCommand.Parameters[75].Value = DBNull.Value;
		}
		if (Original_Date12.HasValue)
		{
			Adapter.UpdateCommand.Parameters[76].Value = 0;
			Adapter.UpdateCommand.Parameters[77].Value = Original_Date12.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[76].Value = 1;
			Adapter.UpdateCommand.Parameters[77].Value = DBNull.Value;
		}
		if (Original_Date13.HasValue)
		{
			Adapter.UpdateCommand.Parameters[78].Value = 0;
			Adapter.UpdateCommand.Parameters[79].Value = Original_Date13.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[78].Value = 1;
			Adapter.UpdateCommand.Parameters[79].Value = DBNull.Value;
		}
		if (Original_Date14.HasValue)
		{
			Adapter.UpdateCommand.Parameters[80].Value = 0;
			Adapter.UpdateCommand.Parameters[81].Value = Original_Date14.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[80].Value = 1;
			Adapter.UpdateCommand.Parameters[81].Value = DBNull.Value;
		}
		if (Original_Date15.HasValue)
		{
			Adapter.UpdateCommand.Parameters[82].Value = 0;
			Adapter.UpdateCommand.Parameters[83].Value = Original_Date15.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[82].Value = 1;
			Adapter.UpdateCommand.Parameters[83].Value = DBNull.Value;
		}
		if (Original_Date16.HasValue)
		{
			Adapter.UpdateCommand.Parameters[84].Value = 0;
			Adapter.UpdateCommand.Parameters[85].Value = Original_Date16.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[84].Value = 1;
			Adapter.UpdateCommand.Parameters[85].Value = DBNull.Value;
		}
		if (Original_Date17.HasValue)
		{
			Adapter.UpdateCommand.Parameters[86].Value = 0;
			Adapter.UpdateCommand.Parameters[87].Value = Original_Date17.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[86].Value = 1;
			Adapter.UpdateCommand.Parameters[87].Value = DBNull.Value;
		}
		if (Original_Date18.HasValue)
		{
			Adapter.UpdateCommand.Parameters[88].Value = 0;
			Adapter.UpdateCommand.Parameters[89].Value = Original_Date18.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[88].Value = 1;
			Adapter.UpdateCommand.Parameters[89].Value = DBNull.Value;
		}
		if (Original_Date19.HasValue)
		{
			Adapter.UpdateCommand.Parameters[90].Value = 0;
			Adapter.UpdateCommand.Parameters[91].Value = Original_Date19.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[90].Value = 1;
			Adapter.UpdateCommand.Parameters[91].Value = DBNull.Value;
		}
		if (Original_Date20.HasValue)
		{
			Adapter.UpdateCommand.Parameters[92].Value = 0;
			Adapter.UpdateCommand.Parameters[93].Value = Original_Date20.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[92].Value = 1;
			Adapter.UpdateCommand.Parameters[93].Value = DBNull.Value;
		}
		if (Original_Date21.HasValue)
		{
			Adapter.UpdateCommand.Parameters[94].Value = 0;
			Adapter.UpdateCommand.Parameters[95].Value = Original_Date21.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[94].Value = 1;
			Adapter.UpdateCommand.Parameters[95].Value = DBNull.Value;
		}
		if (Original_Date22.HasValue)
		{
			Adapter.UpdateCommand.Parameters[96].Value = 0;
			Adapter.UpdateCommand.Parameters[97].Value = Original_Date22.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[96].Value = 1;
			Adapter.UpdateCommand.Parameters[97].Value = DBNull.Value;
		}
		if (Original_Date23.HasValue)
		{
			Adapter.UpdateCommand.Parameters[98].Value = 0;
			Adapter.UpdateCommand.Parameters[99].Value = Original_Date23.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[98].Value = 1;
			Adapter.UpdateCommand.Parameters[99].Value = DBNull.Value;
		}
		if (Original_Date24.HasValue)
		{
			Adapter.UpdateCommand.Parameters[100].Value = 0;
			Adapter.UpdateCommand.Parameters[101].Value = Original_Date24.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[100].Value = 1;
			Adapter.UpdateCommand.Parameters[101].Value = DBNull.Value;
		}
		if (Original_Date25.HasValue)
		{
			Adapter.UpdateCommand.Parameters[102].Value = 0;
			Adapter.UpdateCommand.Parameters[103].Value = Original_Date25.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[102].Value = 1;
			Adapter.UpdateCommand.Parameters[103].Value = DBNull.Value;
		}
		if (Original_Date26.HasValue)
		{
			Adapter.UpdateCommand.Parameters[104].Value = 0;
			Adapter.UpdateCommand.Parameters[105].Value = Original_Date26.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[104].Value = 1;
			Adapter.UpdateCommand.Parameters[105].Value = DBNull.Value;
		}
		if (Original_Date27.HasValue)
		{
			Adapter.UpdateCommand.Parameters[106].Value = 0;
			Adapter.UpdateCommand.Parameters[107].Value = Original_Date27.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[106].Value = 1;
			Adapter.UpdateCommand.Parameters[107].Value = DBNull.Value;
		}
		if (Original_Date28.HasValue)
		{
			Adapter.UpdateCommand.Parameters[108].Value = 0;
			Adapter.UpdateCommand.Parameters[109].Value = Original_Date28.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[108].Value = 1;
			Adapter.UpdateCommand.Parameters[109].Value = DBNull.Value;
		}
		if (Original_Date29.HasValue)
		{
			Adapter.UpdateCommand.Parameters[110].Value = 0;
			Adapter.UpdateCommand.Parameters[111].Value = Original_Date29.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[110].Value = 1;
			Adapter.UpdateCommand.Parameters[111].Value = DBNull.Value;
		}
		if (Original_Date30.HasValue)
		{
			Adapter.UpdateCommand.Parameters[112].Value = 0;
			Adapter.UpdateCommand.Parameters[113].Value = Original_Date30.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[112].Value = 1;
			Adapter.UpdateCommand.Parameters[113].Value = DBNull.Value;
		}
		if (Original_Date31.HasValue)
		{
			Adapter.UpdateCommand.Parameters[114].Value = 0;
			Adapter.UpdateCommand.Parameters[115].Value = Original_Date31.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[114].Value = 1;
			Adapter.UpdateCommand.Parameters[115].Value = DBNull.Value;
		}
		if (Original_UserId == null)
		{
			Adapter.UpdateCommand.Parameters[116].Value = 1;
			Adapter.UpdateCommand.Parameters[117].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[116].Value = 0;
			Adapter.UpdateCommand.Parameters[117].Value = Original_UserId;
		}
		Adapter.UpdateCommand.Parameters[118].Value = Id;
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
	public virtual int Update(string Name, string Sex, string StudentNumber, string StudentId, string ClassId, string StreamId, DateTime? Date1, DateTime? Date2, DateTime? Date3, DateTime? Date4, DateTime? Date5, DateTime? Date6, DateTime? Date7, string Flag, DateTime? Date8, DateTime? Date9, DateTime? Date10, DateTime? Date11, DateTime? Date12, DateTime? Date13, DateTime? Date14, DateTime? Date15, DateTime? Date16, DateTime? Date17, DateTime? Date18, DateTime? Date19, DateTime? Date20, DateTime? Date21, DateTime? Date22, DateTime? Date23, DateTime? Date24, DateTime? Date25, DateTime? Date26, DateTime? Date27, DateTime? Date28, DateTime? Date29, DateTime? Date30, DateTime? Date31, string UserId, long Original_Id, string Original_Name, string Original_Sex, string Original_StudentNumber, string Original_StudentId, string Original_ClassId, string Original_StreamId, DateTime? Original_Date1, DateTime? Original_Date2, DateTime? Original_Date3, DateTime? Original_Date4, DateTime? Original_Date5, DateTime? Original_Date6, DateTime? Original_Date7, string Original_Flag, DateTime? Original_Date8, DateTime? Original_Date9, DateTime? Original_Date10, DateTime? Original_Date11, DateTime? Original_Date12, DateTime? Original_Date13, DateTime? Original_Date14, DateTime? Original_Date15, DateTime? Original_Date16, DateTime? Original_Date17, DateTime? Original_Date18, DateTime? Original_Date19, DateTime? Original_Date20, DateTime? Original_Date21, DateTime? Original_Date22, DateTime? Original_Date23, DateTime? Original_Date24, DateTime? Original_Date25, DateTime? Original_Date26, DateTime? Original_Date27, DateTime? Original_Date28, DateTime? Original_Date29, DateTime? Original_Date30, DateTime? Original_Date31, string Original_UserId)
	{
		return Update(Name, Sex, StudentNumber, StudentId, ClassId, StreamId, Date1, Date2, Date3, Date4, Date5, Date6, Date7, Flag, Date8, Date9, Date10, Date11, Date12, Date13, Date14, Date15, Date16, Date17, Date18, Date19, Date20, Date21, Date22, Date23, Date24, Date25, Date26, Date27, Date28, Date29, Date30, Date31, UserId, Original_Id, Original_Name, Original_Sex, Original_StudentNumber, Original_StudentId, Original_ClassId, Original_StreamId, Original_Date1, Original_Date2, Original_Date3, Original_Date4, Original_Date5, Original_Date6, Original_Date7, Original_Flag, Original_Date8, Original_Date9, Original_Date10, Original_Date11, Original_Date12, Original_Date13, Original_Date14, Original_Date15, Original_Date16, Original_Date17, Original_Date18, Original_Date19, Original_Date20, Original_Date21, Original_Date22, Original_Date23, Original_Date24, Original_Date25, Original_Date26, Original_Date27, Original_Date28, Original_Date29, Original_Date30, Original_Date31, Original_UserId, Original_Id);
	}
}
