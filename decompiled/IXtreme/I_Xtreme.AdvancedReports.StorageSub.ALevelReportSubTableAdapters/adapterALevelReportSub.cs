using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.AdvancedReports.StorageSub.ALevelReportSubTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class adapterALevelReportSub : Component
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
	public adapterALevelReportSub()
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
		dataTableMapping.DataSetTable = "ALevelReportSub";
		dataTableMapping.ColumnMappings.Add("id", "id");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("SemesterId", "SemesterId");
		dataTableMapping.ColumnMappings.Add("SubjectId", "SubjectId");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("Paper", "Paper");
		dataTableMapping.ColumnMappings.Add("HoP", "HoP");
		dataTableMapping.ColumnMappings.Add("BOT", "BOT");
		dataTableMapping.ColumnMappings.Add("MOT", "MOT");
		dataTableMapping.ColumnMappings.Add("EOT", "EOT");
		dataTableMapping.ColumnMappings.Add("AvMark", "AvMark");
		dataTableMapping.ColumnMappings.Add("Category", "Category");
		dataTableMapping.ColumnMappings.Add("Grade", "Grade");
		dataTableMapping.ColumnMappings.Add("Comment", "Comment");
		dataTableMapping.ColumnMappings.Add("Initial", "Initial");
		dataTableMapping.ColumnMappings.Add("SubGroup", "SubGroup");
		dataTableMapping.ColumnMappings.Add("Points", "Points");
		dataTableMapping.ColumnMappings.Add("promoStatus", "promoStatus");
		dataTableMapping.ColumnMappings.Add("HeadTeacherComments", "HeadTeacherComments");
		dataTableMapping.ColumnMappings.Add("DOSComments", "DOSComments");
		dataTableMapping.ColumnMappings.Add("ClassTeacherComments", "ClassTeacherComments");
		dataTableMapping.ColumnMappings.Add("Comment4", "Comment4");
		dataTableMapping.ColumnMappings.Add("AverageMark", "AverageMark");
		dataTableMapping.ColumnMappings.Add("CategoryPoints", "CategoryPoints");
		dataTableMapping.ColumnMappings.Add("Totals", "Totals");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_ALevelReport] ([StudentNumber], [SemesterId], [SubjectId], [ClassId], [Paper], [HoP], [BOT], [MOT], [EOT], [AvMark], [Category], [Grade], [Comment], [Initial], [SubGroup], [Points], [TotalPoints], [promoStatus], [HeadTeacherComments], [DOSComments], [ClassTeacherComments], [Comment4], [AverageMark], [CategoryPoints]) VALUES (@StudentNumber, @SemesterId, @SubjectId, @ClassId, @Paper, @HoP, @BOT, @MOT, @EOT, @AvMark, @Category, @Grade, @Comment, @Initial, @SubGroup, @Points, @Totals, @promoStatus, @HeadTeacherComments, @DOSComments, @ClassTeacherComments, @Comment4, @AverageMark, @CategoryPoints)";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Paper", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Paper", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HoP", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HoP", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@BOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "BOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@MOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "MOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@EOT", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubGroup", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubGroup", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Points", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Points", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Totals", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Totals", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@promoStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "promoStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HeadTeacherComments", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HeadTeacherComments", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@DOSComments", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "DOSComments", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassTeacherComments", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassTeacherComments", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AverageMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AverageMark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@CategoryPoints", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CategoryPoints", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT id, StudentNumber, SemesterId, SubjectId, ClassId, Paper, HoP, BOT, MOT, EOT, AvMark, Category, Grade, Comment, Initial, SubGroup, Points, TotalPoints AS Totals, promoStatus, HeadTeacherComments, DOSComments, ClassTeacherComments, Comment4, AverageMark, \r\n             CategoryPoints\r\nFROM   tbl_ALevelReport\r\nWHERE (SemesterId = '{ReportParameters.Semester}') AND (ClassId = '{ReportParameters.Class}')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(ALevelReportSub.ALevelReportSubDataTable dataTable)
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
	public virtual ALevelReportSub.ALevelReportSubDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		ALevelReportSub.ALevelReportSubDataTable aLevelReportSubDataTable = new ALevelReportSub.ALevelReportSubDataTable();
		Adapter.Fill(aLevelReportSubDataTable);
		return aLevelReportSubDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(ALevelReportSub.ALevelReportSubDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(ALevelReportSub dataSet)
	{
		return Adapter.Update(dataSet, "ALevelReportSub");
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
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	public virtual int Insert(string StudentNumber, string SemesterId, string SubjectId, string ClassId, string Paper, string HoP, string BOT, string MOT, string EOT, double? AvMark, string Category, string Grade, string Comment, string Initial, string SubGroup, double? Points, double Totals, string promoStatus, string HeadTeacherComments, string DOSComments, string ClassTeacherComments, string Comment4, double? AverageMark, string CategoryPoints)
	{
		if (StudentNumber == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		}
		if (SemesterId == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = SemesterId;
		}
		if (SubjectId == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = SubjectId;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = ClassId;
		}
		if (Paper == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = Paper;
		}
		if (HoP == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = HoP;
		}
		if (BOT == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = BOT;
		}
		if (MOT == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = MOT;
		}
		if (EOT == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = EOT;
		}
		if (AvMark.HasValue)
		{
			Adapter.InsertCommand.Parameters[9].Value = AvMark.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		if (Category == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = Category;
		}
		if (Grade == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = Grade;
		}
		if (Comment == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = Comment;
		}
		if (Initial == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = Initial;
		}
		if (SubGroup == null)
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = SubGroup;
		}
		if (Points.HasValue)
		{
			Adapter.InsertCommand.Parameters[15].Value = Points.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		Adapter.InsertCommand.Parameters[16].Value = Totals;
		if (promoStatus == null)
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = promoStatus;
		}
		if (HeadTeacherComments == null)
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = HeadTeacherComments;
		}
		if (DOSComments == null)
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = DOSComments;
		}
		if (ClassTeacherComments == null)
		{
			Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[20].Value = ClassTeacherComments;
		}
		if (Comment4 == null)
		{
			Adapter.InsertCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[21].Value = Comment4;
		}
		if (AverageMark.HasValue)
		{
			Adapter.InsertCommand.Parameters[22].Value = AverageMark.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[22].Value = DBNull.Value;
		}
		if (CategoryPoints == null)
		{
			Adapter.InsertCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[23].Value = CategoryPoints;
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
}
