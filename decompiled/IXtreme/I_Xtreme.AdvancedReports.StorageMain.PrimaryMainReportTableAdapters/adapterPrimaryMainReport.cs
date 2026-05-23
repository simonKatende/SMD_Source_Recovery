using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.AdvancedReports.StorageMain.PrimaryMainReportTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class adapterPrimaryMainReport : Component
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
	public adapterPrimaryMainReport()
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
		dataTableMapping.DataSetTable = "PrimaryMainReport";
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("StudyStatus", "StudyStatus");
		dataTableMapping.ColumnMappings.Add("HouseId", "HouseId");
		dataTableMapping.ColumnMappings.Add("Religion", "Religion");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("RequiredFees", "RequiredFees");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		dataTableMapping.ColumnMappings.Add("FeesDiscount", "FeesDiscount");
		dataTableMapping.ColumnMappings.Add("Position", "Position");
		dataTableMapping.ColumnMappings.Add("OutOf", "OutOf");
		dataTableMapping.ColumnMappings.Add("PositionInStream", "PositionInStream");
		dataTableMapping.ColumnMappings.Add("StudentsInStream", "StudentsInStream");
		dataTableMapping.ColumnMappings.Add("BestinEight", "BestinEight");
		dataTableMapping.ColumnMappings.Add("Agg", "Agg");
		dataTableMapping.ColumnMappings.Add("Div", "Div");
		dataTableMapping.ColumnMappings.Add("ClassTeacherComment", "ClassTeacherComment");
		dataTableMapping.ColumnMappings.Add("HeadTeacherComment", "HeadTeacherComment");
		dataTableMapping.ColumnMappings.Add("DOSComment", "DOSComment");
		dataTableMapping.ColumnMappings.Add("Comment4", "Comment4");
		dataTableMapping.ColumnMappings.Add("TotalMark", "TotalMark");
		dataTableMapping.ColumnMappings.Add("AvMark", "AvMark");
		dataTableMapping.ColumnMappings.Add("promoStatus", "promoStatus");
		dataTableMapping.ColumnMappings.Add("SemesterId", "SemesterId");
		_adapter.TableMappings.Add(dataTableMapping);
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
		_commandCollection[0].CommandText = $"SELECT s.StudentNumber, s.fullName, s.ClassId, s.StreamId, s.Sex, s.StudyStatus, s.HouseId, s.Religion, s.Picture, s.RequiredFees, s.cashOnAccount, s.FeesDiscount, g.Position, g.OutOf, g.PositionInStream, g.StudentsInStream, g.BestinEight, g.Agg, g.Div, \r\n             g.ClassTeacherComment, g.HeadTeacherComment, g.DOSComment, g.Comment4, g.TotalMark, g.AvMark, g.promoStatus, g.SemesterId\r\nFROM   tbl_Stud AS s INNER JOIN\r\n             tbl_GeneralReports_Grading_Primary AS g ON s.StudentNumber = g.StudentNumber AND s.ClassId = g.ClassId\r\nWHERE (g.SemesterId = '{ReportParameters.Semester}') AND (s.ClassId = '{ReportParameters.Class}') AND (s.StreamId = '{ReportParameters.Stream}')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(PrimaryMainReport.PrimaryMainReportDataTable dataTable)
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
	public virtual PrimaryMainReport.PrimaryMainReportDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		PrimaryMainReport.PrimaryMainReportDataTable primaryMainReportDataTable = new PrimaryMainReport.PrimaryMainReportDataTable();
		Adapter.Fill(primaryMainReportDataTable);
		return primaryMainReportDataTable;
	}
}
