using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.AdvancedReports.StorageSub.PrimaryASubDSTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class adapterPrimaryASubDS : Component
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
	public adapterPrimaryASubDS()
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
		dataTableMapping.DataSetTable = "PrimaryASubDS";
		dataTableMapping.ColumnMappings.Add("id", "id");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("SubjectId", "SubjectId");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("HoP", "HoP");
		dataTableMapping.ColumnMappings.Add("BOT", "BOT");
		dataTableMapping.ColumnMappings.Add("MOT", "MOT");
		dataTableMapping.ColumnMappings.Add("EOT", "EOT");
		dataTableMapping.ColumnMappings.Add("AvMark", "AvMark");
		dataTableMapping.ColumnMappings.Add("Grade", "Grade");
		dataTableMapping.ColumnMappings.Add("Category", "Category");
		dataTableMapping.ColumnMappings.Add("Initial", "Initial");
		dataTableMapping.ColumnMappings.Add("SemesterId", "SemesterId");
		dataTableMapping.ColumnMappings.Add("Comment", "Comment");
		dataTableMapping.ColumnMappings.Add("IsAssessed", "IsAssessed");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_GeneralReportCards_Primary] WHERE (([id] = @Original_id) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_SubjectId = 1 AND [SubjectId] IS NULL) OR ([SubjectId] = @Original_SubjectId)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_HoP = 1 AND [HoP] IS NULL) OR ([HoP] = @Original_HoP)) AND ((@IsNull_BOT = 1 AND [BOT] IS NULL) OR ([BOT] = @Original_BOT)) AND ((@IsNull_MOT = 1 AND [MOT] IS NULL) OR ([MOT] = @Original_MOT)) AND ((@IsNull_EOT = 1 AND [EOT] IS NULL) OR ([EOT] = @Original_EOT)) AND ((@IsNull_AvMark = 1 AND [AvMark] IS NULL) OR ([AvMark] = @Original_AvMark)) AND ((@IsNull_Grade = 1 AND [Grade] IS NULL) OR ([Grade] = @Original_Grade)) AND ((@IsNull_Category = 1 AND [Category] IS NULL) OR ([Category] = @Original_Category)) AND ((@IsNull_Initial = 1 AND [Initial] IS NULL) OR ([Initial] = @Original_Initial)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_Comment = 1 AND [Comment] IS NULL) OR ([Comment] = @Original_Comment)) AND ((@IsNull_IsAssessed = 1 AND [IsAssessed] IS NULL) OR ([IsAssessed] = @Original_IsAssessed)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HoP", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HoP", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_BOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_MOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_MOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_EOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_EOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_AvMark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Initial", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_IsAssessed", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsAssessed", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IsAssessed", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsAssessed", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_GeneralReportCards_Primary] ([StudentNumber], [SubjectId], [ClassId], [HoP], [BOT], [MOT], [EOT], [AvMark], [Grade], [Category], [Initial], [SemesterId], [Comment], [IsAssessed]) VALUES (@StudentNumber, @SubjectId, @ClassId, @HoP, @BOT, @MOT, @EOT, @AvMark, @Grade, @Category, @Initial, @SemesterId, @Comment, @IsAssessed);\r\nSELECT id, StudentNumber, SubjectId, ClassId, HoP, BOT, MOT, EOT, AvMark, Grade, Category, Initial, SemesterId, Comment, IsAssessed FROM tbl_GeneralReportCards_Primary WHERE (id = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HoP", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@MOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@EOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@IsAssessed", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsAssessed", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_GeneralReportCards_Primary] SET [StudentNumber] = @StudentNumber, [SubjectId] = @SubjectId, [ClassId] = @ClassId, [HoP] = @HoP, [BOT] = @BOT, [MOT] = @MOT, [EOT] = @EOT, [AvMark] = @AvMark, [Grade] = @Grade, [Category] = @Category, [Initial] = @Initial, [SemesterId] = @SemesterId, [Comment] = @Comment, [IsAssessed] = @IsAssessed WHERE (([id] = @Original_id) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_SubjectId = 1 AND [SubjectId] IS NULL) OR ([SubjectId] = @Original_SubjectId)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_HoP = 1 AND [HoP] IS NULL) OR ([HoP] = @Original_HoP)) AND ((@IsNull_BOT = 1 AND [BOT] IS NULL) OR ([BOT] = @Original_BOT)) AND ((@IsNull_MOT = 1 AND [MOT] IS NULL) OR ([MOT] = @Original_MOT)) AND ((@IsNull_EOT = 1 AND [EOT] IS NULL) OR ([EOT] = @Original_EOT)) AND ((@IsNull_AvMark = 1 AND [AvMark] IS NULL) OR ([AvMark] = @Original_AvMark)) AND ((@IsNull_Grade = 1 AND [Grade] IS NULL) OR ([Grade] = @Original_Grade)) AND ((@IsNull_Category = 1 AND [Category] IS NULL) OR ([Category] = @Original_Category)) AND ((@IsNull_Initial = 1 AND [Initial] IS NULL) OR ([Initial] = @Original_Initial)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_Comment = 1 AND [Comment] IS NULL) OR ([Comment] = @Original_Comment)) AND ((@IsNull_IsAssessed = 1 AND [IsAssessed] IS NULL) OR ([IsAssessed] = @Original_IsAssessed)));\r\nSELECT id, StudentNumber, SubjectId, ClassId, HoP, BOT, MOT, EOT, AvMark, Grade, Category, Initial, SemesterId, Comment, IsAssessed FROM tbl_GeneralReportCards_Primary WHERE (id = @id)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HoP", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsAssessed", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsAssessed", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HoP", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HoP", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_BOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_MOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_MOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_EOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_EOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_AvMark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Initial", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_IsAssessed", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IsAssessed", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IsAssessed", SqlDbType.Bit, 0, ParameterDirection.Input, 0, 0, "IsAssessed", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT id, StudentNumber, SubjectId, ClassId, HoP, BOT, MOT, EOT, AvMark, Grade, Category, Initial, SemesterId, Comment, IsAssessed\r\nFROM   tbl_GeneralReportCards_Primary\r\nWHERE (IsAssessed = 1) AND (SemesterId = '{ReportParameters.Semester}') AND (ClassId = '{ReportParameters.Class}')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(PrimaryASubDS.PrimaryASubDSDataTable dataTable)
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
	public virtual PrimaryASubDS.PrimaryASubDSDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		PrimaryASubDS.PrimaryASubDSDataTable primaryASubDSDataTable = new PrimaryASubDS.PrimaryASubDSDataTable();
		Adapter.Fill(primaryASubDSDataTable);
		return primaryASubDSDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(PrimaryASubDS.PrimaryASubDSDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(PrimaryASubDS dataSet)
	{
		return Adapter.Update(dataSet, "PrimaryASubDS");
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
	public virtual int Delete(long Original_id, string Original_StudentNumber, string Original_SubjectId, string Original_ClassId, string Original_HoP, string Original_BOT, string Original_MOT, string Original_EOT, double? Original_AvMark, int? Original_Grade, string Original_Category, string Original_Initial, string Original_SemesterId, string Original_Comment, bool? Original_IsAssessed)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_id;
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
		if (Original_SubjectId == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_SubjectId;
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
		if (Original_HoP == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_HoP;
		}
		if (Original_BOT == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_BOT;
		}
		if (Original_MOT == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_MOT;
		}
		if (Original_EOT == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_EOT;
		}
		if (Original_AvMark.HasValue)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_AvMark.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		if (Original_Grade.HasValue)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_Grade.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		if (Original_Category == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_Category;
		}
		if (Original_Initial == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_Initial;
		}
		if (Original_SemesterId == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_SemesterId;
		}
		if (Original_Comment == null)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_Comment;
		}
		if (Original_IsAssessed.HasValue)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_IsAssessed.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
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
	public virtual int Insert(string StudentNumber, string SubjectId, string ClassId, string HoP, string BOT, string MOT, string EOT, double? AvMark, int? Grade, string Category, string Initial, string SemesterId, string Comment, bool? IsAssessed)
	{
		if (StudentNumber == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		}
		if (SubjectId == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = SubjectId;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = ClassId;
		}
		if (HoP == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = HoP;
		}
		if (BOT == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = BOT;
		}
		if (MOT == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = MOT;
		}
		if (EOT == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = EOT;
		}
		if (AvMark.HasValue)
		{
			Adapter.InsertCommand.Parameters[7].Value = AvMark.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		if (Grade.HasValue)
		{
			Adapter.InsertCommand.Parameters[8].Value = Grade.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		if (Category == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = Category;
		}
		if (Initial == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = Initial;
		}
		if (SemesterId == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = SemesterId;
		}
		if (Comment == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = Comment;
		}
		if (IsAssessed.HasValue)
		{
			Adapter.InsertCommand.Parameters[13].Value = IsAssessed.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
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
	public virtual int Update(string StudentNumber, string SubjectId, string ClassId, string HoP, string BOT, string MOT, string EOT, double? AvMark, int? Grade, string Category, string Initial, string SemesterId, string Comment, bool? IsAssessed, long Original_id, string Original_StudentNumber, string Original_SubjectId, string Original_ClassId, string Original_HoP, string Original_BOT, string Original_MOT, string Original_EOT, double? Original_AvMark, int? Original_Grade, string Original_Category, string Original_Initial, string Original_SemesterId, string Original_Comment, bool? Original_IsAssessed, long id)
	{
		if (StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		}
		if (SubjectId == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = SubjectId;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = ClassId;
		}
		if (HoP == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = HoP;
		}
		if (BOT == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = BOT;
		}
		if (MOT == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = MOT;
		}
		if (EOT == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = EOT;
		}
		if (AvMark.HasValue)
		{
			Adapter.UpdateCommand.Parameters[7].Value = AvMark.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		if (Grade.HasValue)
		{
			Adapter.UpdateCommand.Parameters[8].Value = Grade.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		if (Category == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = Category;
		}
		if (Initial == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = Initial;
		}
		if (SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = SemesterId;
		}
		if (Comment == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = Comment;
		}
		if (IsAssessed.HasValue)
		{
			Adapter.UpdateCommand.Parameters[13].Value = IsAssessed.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		Adapter.UpdateCommand.Parameters[14].Value = Original_id;
		if (Original_StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = 1;
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = 0;
			Adapter.UpdateCommand.Parameters[16].Value = Original_StudentNumber;
		}
		if (Original_SubjectId == null)
		{
			Adapter.UpdateCommand.Parameters[17].Value = 1;
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = 0;
			Adapter.UpdateCommand.Parameters[18].Value = Original_SubjectId;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[19].Value = 1;
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = 0;
			Adapter.UpdateCommand.Parameters[20].Value = Original_ClassId;
		}
		if (Original_HoP == null)
		{
			Adapter.UpdateCommand.Parameters[21].Value = 1;
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = 0;
			Adapter.UpdateCommand.Parameters[22].Value = Original_HoP;
		}
		if (Original_BOT == null)
		{
			Adapter.UpdateCommand.Parameters[23].Value = 1;
			Adapter.UpdateCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[23].Value = 0;
			Adapter.UpdateCommand.Parameters[24].Value = Original_BOT;
		}
		if (Original_MOT == null)
		{
			Adapter.UpdateCommand.Parameters[25].Value = 1;
			Adapter.UpdateCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[25].Value = 0;
			Adapter.UpdateCommand.Parameters[26].Value = Original_MOT;
		}
		if (Original_EOT == null)
		{
			Adapter.UpdateCommand.Parameters[27].Value = 1;
			Adapter.UpdateCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[27].Value = 0;
			Adapter.UpdateCommand.Parameters[28].Value = Original_EOT;
		}
		if (Original_AvMark.HasValue)
		{
			Adapter.UpdateCommand.Parameters[29].Value = 0;
			Adapter.UpdateCommand.Parameters[30].Value = Original_AvMark.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[29].Value = 1;
			Adapter.UpdateCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Original_Grade.HasValue)
		{
			Adapter.UpdateCommand.Parameters[31].Value = 0;
			Adapter.UpdateCommand.Parameters[32].Value = Original_Grade.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[31].Value = 1;
			Adapter.UpdateCommand.Parameters[32].Value = DBNull.Value;
		}
		if (Original_Category == null)
		{
			Adapter.UpdateCommand.Parameters[33].Value = 1;
			Adapter.UpdateCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[33].Value = 0;
			Adapter.UpdateCommand.Parameters[34].Value = Original_Category;
		}
		if (Original_Initial == null)
		{
			Adapter.UpdateCommand.Parameters[35].Value = 1;
			Adapter.UpdateCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[35].Value = 0;
			Adapter.UpdateCommand.Parameters[36].Value = Original_Initial;
		}
		if (Original_SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[37].Value = 1;
			Adapter.UpdateCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[37].Value = 0;
			Adapter.UpdateCommand.Parameters[38].Value = Original_SemesterId;
		}
		if (Original_Comment == null)
		{
			Adapter.UpdateCommand.Parameters[39].Value = 1;
			Adapter.UpdateCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[39].Value = 0;
			Adapter.UpdateCommand.Parameters[40].Value = Original_Comment;
		}
		if (Original_IsAssessed.HasValue)
		{
			Adapter.UpdateCommand.Parameters[41].Value = 0;
			Adapter.UpdateCommand.Parameters[42].Value = Original_IsAssessed.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[41].Value = 1;
			Adapter.UpdateCommand.Parameters[42].Value = DBNull.Value;
		}
		Adapter.UpdateCommand.Parameters[43].Value = id;
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
	public virtual int Update(string StudentNumber, string SubjectId, string ClassId, string HoP, string BOT, string MOT, string EOT, double? AvMark, int? Grade, string Category, string Initial, string SemesterId, string Comment, bool? IsAssessed, long Original_id, string Original_StudentNumber, string Original_SubjectId, string Original_ClassId, string Original_HoP, string Original_BOT, string Original_MOT, string Original_EOT, double? Original_AvMark, int? Original_Grade, string Original_Category, string Original_Initial, string Original_SemesterId, string Original_Comment, bool? Original_IsAssessed)
	{
		return Update(StudentNumber, SubjectId, ClassId, HoP, BOT, MOT, EOT, AvMark, Grade, Category, Initial, SemesterId, Comment, IsAssessed, Original_id, Original_StudentNumber, Original_SubjectId, Original_ClassId, Original_HoP, Original_BOT, Original_MOT, Original_EOT, Original_AvMark, Original_Grade, Original_Category, Original_Initial, Original_SemesterId, Original_Comment, Original_IsAssessed, Original_id);
	}
}
