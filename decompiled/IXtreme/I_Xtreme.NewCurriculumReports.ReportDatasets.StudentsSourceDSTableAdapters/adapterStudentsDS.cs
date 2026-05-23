using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.NewCurriculumReports.ReportDatasets.StudentsSourceDSTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class adapterStudentsDS : Component
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
	public adapterStudentsDS()
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
		dataTableMapping.DataSetTable = "StudentsDS";
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("StudyStatus", "StudyStatus");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("HouseId", "HouseId");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		dataTableMapping.ColumnMappings.Add("PrimaryScores1", "PrimaryScores1");
		dataTableMapping.ColumnMappings.Add("auto", "auto");
		dataTableMapping.ColumnMappings.Add("StudentID", "StudentID");
		dataTableMapping.ColumnMappings.Add("GamesAndSports", "GamesAndSports");
		dataTableMapping.ColumnMappings.Add("Clubs", "Clubs");
		dataTableMapping.ColumnMappings.Add("Status", "Status");
		dataTableMapping.ColumnMappings.Add("LIN", "LIN");
		dataTableMapping.ColumnMappings.Add("FeesNextTerm", "FeesNextTerm");
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
		_commandCollection[0].CommandText = $"SELECT        auto, StudentNumber, StudentID, GamesAndSports, Clubs, fullName, ClassId, StreamId, StudyStatus, Sex, HouseId, Picture, cashOnAccount, PrimaryScores1, Status, LIN, ISNULL(RequiredFees, 0) - ISNULL(FeesDiscount, 0) \r\n                         AS FeesNextTerm\r\nFROM            tbl_Stud\r\nWHERE        (ClassId = '{ReportParameters.Class}') AND (StreamId = '{ReportParameters.Stream}') AND (Status = 'Active')";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(StudentsSourceDS.StudentsDSDataTable dataTable)
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
	public virtual StudentsSourceDS.StudentsDSDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		StudentsSourceDS.StudentsDSDataTable studentsDSDataTable = new StudentsSourceDS.StudentsDSDataTable();
		Adapter.Fill(studentsDSDataTable);
		return studentsDSDataTable;
	}
}
