using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.HelperDSTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class ALevelGradingScaleTableAdapter : Component
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
	public ALevelGradingScaleTableAdapter()
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
		dataTableMapping.DataSetTable = "ALevelGradingScale";
		dataTableMapping.ColumnMappings.Add("GradeId", "GradeId");
		dataTableMapping.ColumnMappings.Add("Category", "Category");
		dataTableMapping.ColumnMappings.Add("Debut", "Debut");
		dataTableMapping.ColumnMappings.Add("End", "End");
		dataTableMapping.ColumnMappings.Add("Points", "Points");
		dataTableMapping.ColumnMappings.Add("Comment", "Comment");
		dataTableMapping.ColumnMappings.Add("Comment2", "Comment2");
		dataTableMapping.ColumnMappings.Add("Comment3", "Comment3");
		dataTableMapping.ColumnMappings.Add("Comment4", "Comment4");
		dataTableMapping.ColumnMappings.Add("Comment5", "Comment5");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [ALevelGradingScale] WHERE (([GradeId] = @Original_GradeId) AND ((@IsNull_Category = 1 AND [Category] IS NULL) OR ([Category] = @Original_Category)) AND ((@IsNull_Debut = 1 AND [Debut] IS NULL) OR ([Debut] = @Original_Debut)) AND ((@IsNull_End = 1 AND [End] IS NULL) OR ([End] = @Original_End)) AND ((@IsNull_Points = 1 AND [Points] IS NULL) OR ([Points] = @Original_Points)) AND ((@IsNull_Comment = 1 AND [Comment] IS NULL) OR ([Comment] = @Original_Comment)) AND ((@IsNull_Comment2 = 1 AND [Comment2] IS NULL) OR ([Comment2] = @Original_Comment2)) AND ((@IsNull_Comment3 = 1 AND [Comment3] IS NULL) OR ([Comment3] = @Original_Comment3)) AND ((@IsNull_Comment4 = 1 AND [Comment4] IS NULL) OR ([Comment4] = @Original_Comment4)) AND ((@IsNull_Comment5 = 1 AND [Comment5] IS NULL) OR ([Comment5] = @Original_Comment5)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GradeId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GradeId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Debut", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Debut", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Debut", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Debut", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_End", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "End", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_End", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "End", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Points", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Points", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [ALevelGradingScale] ([Category], [Debut], [End], [Points], [Comment], [Comment2], [Comment3], [Comment4], [Comment5]) VALUES (@Category, @Debut, @End, @Points, @Comment, @Comment2, @Comment3, @Comment4, @Comment5);\r\nSELECT GradeId, Category, Debut, [End], Points, Comment, Comment2, Comment3, Comment4, Comment5 FROM ALevelGradingScale WHERE (GradeId = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Debut", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Debut", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@End", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "End", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Points", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [ALevelGradingScale] SET [Category] = @Category, [Debut] = @Debut, [End] = @End, [Points] = @Points, [Comment] = @Comment, [Comment2] = @Comment2, [Comment3] = @Comment3, [Comment4] = @Comment4, [Comment5] = @Comment5 WHERE (([GradeId] = @Original_GradeId) AND ((@IsNull_Category = 1 AND [Category] IS NULL) OR ([Category] = @Original_Category)) AND ((@IsNull_Debut = 1 AND [Debut] IS NULL) OR ([Debut] = @Original_Debut)) AND ((@IsNull_End = 1 AND [End] IS NULL) OR ([End] = @Original_End)) AND ((@IsNull_Points = 1 AND [Points] IS NULL) OR ([Points] = @Original_Points)) AND ((@IsNull_Comment = 1 AND [Comment] IS NULL) OR ([Comment] = @Original_Comment)) AND ((@IsNull_Comment2 = 1 AND [Comment2] IS NULL) OR ([Comment2] = @Original_Comment2)) AND ((@IsNull_Comment3 = 1 AND [Comment3] IS NULL) OR ([Comment3] = @Original_Comment3)) AND ((@IsNull_Comment4 = 1 AND [Comment4] IS NULL) OR ([Comment4] = @Original_Comment4)) AND ((@IsNull_Comment5 = 1 AND [Comment5] IS NULL) OR ([Comment5] = @Original_Comment5)));\r\nSELECT GradeId, Category, Debut, [End], Points, Comment, Comment2, Comment3, Comment4, Comment5 FROM ALevelGradingScale WHERE (GradeId = @GradeId)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Debut", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Debut", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@End", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "End", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Points", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GradeId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GradeId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Debut", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Debut", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Debut", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Debut", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_End", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "End", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_End", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "End", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Points", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Points", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GradeId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "GradeId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = "SELECT        ALevelGradingScale.*\r\nFROM            ALevelGradingScale";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(HelperDS.ALevelGradingScaleDataTable dataTable)
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
	public virtual HelperDS.ALevelGradingScaleDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		HelperDS.ALevelGradingScaleDataTable aLevelGradingScaleDataTable = new HelperDS.ALevelGradingScaleDataTable();
		Adapter.Fill(aLevelGradingScaleDataTable);
		return aLevelGradingScaleDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(HelperDS.ALevelGradingScaleDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(HelperDS dataSet)
	{
		return Adapter.Update(dataSet, "ALevelGradingScale");
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
	public virtual int Delete(int Original_GradeId, string Original_Category, double? Original_Debut, double? Original_End, int? Original_Points, string Original_Comment, string Original_Comment2, string Original_Comment3, string Original_Comment4, string Original_Comment5)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_GradeId;
		if (Original_Category == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_Category;
		}
		if (Original_Debut.HasValue)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_Debut.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		if (Original_End.HasValue)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_End.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		if (Original_Points.HasValue)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_Points.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		if (Original_Comment == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_Comment;
		}
		if (Original_Comment2 == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_Comment2;
		}
		if (Original_Comment3 == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_Comment3;
		}
		if (Original_Comment4 == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_Comment4;
		}
		if (Original_Comment5 == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_Comment5;
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
	public virtual int Insert(string Category, double? Debut, double? End, int? Points, string Comment, string Comment2, string Comment3, string Comment4, string Comment5)
	{
		if (Category == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = Category;
		}
		if (Debut.HasValue)
		{
			Adapter.InsertCommand.Parameters[1].Value = Debut.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		if (End.HasValue)
		{
			Adapter.InsertCommand.Parameters[2].Value = End.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		if (Points.HasValue)
		{
			Adapter.InsertCommand.Parameters[3].Value = Points.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		if (Comment == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = Comment;
		}
		if (Comment2 == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = Comment2;
		}
		if (Comment3 == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = Comment3;
		}
		if (Comment4 == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = Comment4;
		}
		if (Comment5 == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = Comment5;
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
	public virtual int Update(string Category, double? Debut, double? End, int? Points, string Comment, string Comment2, string Comment3, string Comment4, string Comment5, int Original_GradeId, string Original_Category, double? Original_Debut, double? Original_End, int? Original_Points, string Original_Comment, string Original_Comment2, string Original_Comment3, string Original_Comment4, string Original_Comment5, int GradeId)
	{
		if (Category == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = Category;
		}
		if (Debut.HasValue)
		{
			Adapter.UpdateCommand.Parameters[1].Value = Debut.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		if (End.HasValue)
		{
			Adapter.UpdateCommand.Parameters[2].Value = End.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		if (Points.HasValue)
		{
			Adapter.UpdateCommand.Parameters[3].Value = Points.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		if (Comment == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = Comment;
		}
		if (Comment2 == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = Comment2;
		}
		if (Comment3 == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = Comment3;
		}
		if (Comment4 == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = Comment4;
		}
		if (Comment5 == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = Comment5;
		}
		Adapter.UpdateCommand.Parameters[9].Value = Original_GradeId;
		if (Original_Category == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = 1;
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = 0;
			Adapter.UpdateCommand.Parameters[11].Value = Original_Category;
		}
		if (Original_Debut.HasValue)
		{
			Adapter.UpdateCommand.Parameters[12].Value = 0;
			Adapter.UpdateCommand.Parameters[13].Value = Original_Debut.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = 1;
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		if (Original_End.HasValue)
		{
			Adapter.UpdateCommand.Parameters[14].Value = 0;
			Adapter.UpdateCommand.Parameters[15].Value = Original_End.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = 1;
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		if (Original_Points.HasValue)
		{
			Adapter.UpdateCommand.Parameters[16].Value = 0;
			Adapter.UpdateCommand.Parameters[17].Value = Original_Points.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = 1;
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		if (Original_Comment == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = 1;
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = 0;
			Adapter.UpdateCommand.Parameters[19].Value = Original_Comment;
		}
		if (Original_Comment2 == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = 1;
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = 0;
			Adapter.UpdateCommand.Parameters[21].Value = Original_Comment2;
		}
		if (Original_Comment3 == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = 1;
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = 0;
			Adapter.UpdateCommand.Parameters[23].Value = Original_Comment3;
		}
		if (Original_Comment4 == null)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_Comment4;
		}
		if (Original_Comment5 == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_Comment5;
		}
		Adapter.UpdateCommand.Parameters[28].Value = GradeId;
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
	public virtual int Update(string Category, double? Debut, double? End, int? Points, string Comment, string Comment2, string Comment3, string Comment4, string Comment5, int Original_GradeId, string Original_Category, double? Original_Debut, double? Original_End, int? Original_Points, string Original_Comment, string Original_Comment2, string Original_Comment3, string Original_Comment4, string Original_Comment5)
	{
		return Update(Category, Debut, End, Points, Comment, Comment2, Comment3, Comment4, Comment5, Original_GradeId, Original_Category, Original_Debut, Original_End, Original_Points, Original_Comment, Original_Comment2, Original_Comment3, Original_Comment4, Original_Comment5, Original_GradeId);
	}
}
