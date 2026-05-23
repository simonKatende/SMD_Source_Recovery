using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.IslamicTheology.TheologySubDSTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class tbl_Scores_OL_ReportTHTableAdapter : Component
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
	public tbl_Scores_OL_ReportTHTableAdapter()
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
		dataTableMapping.DataSetTable = "tbl_Scores_OL_ReportTH";
		dataTableMapping.ColumnMappings.Add("SubjectId", "SubjectId");
		dataTableMapping.ColumnMappings.Add("SubjectIdAr", "SubjectIdAr");
		dataTableMapping.ColumnMappings.Add("Chapter", "Chapter");
		dataTableMapping.ColumnMappings.Add("Topic", "Topic");
		dataTableMapping.ColumnMappings.Add("TopicAr", "TopicAr");
		dataTableMapping.ColumnMappings.Add("LO", "LO");
		dataTableMapping.ColumnMappings.Add("LOAr", "LOAr");
		dataTableMapping.ColumnMappings.Add("TS", "TS");
		dataTableMapping.ColumnMappings.Add("TSAr", "TSAr");
		dataTableMapping.ColumnMappings.Add("AvLO", "AvLO");
		dataTableMapping.ColumnMappings.Add("AvLOAr", "AvLOAr");
		dataTableMapping.ColumnMappings.Add("AvTS", "AvTS");
		dataTableMapping.ColumnMappings.Add("AvTSAr", "AvTSAr");
		dataTableMapping.ColumnMappings.Add("TeacherRemarks", "TeacherRemarks");
		dataTableMapping.ColumnMappings.Add("TeacherRemarksAr", "TeacherRemarksAr");
		dataTableMapping.ColumnMappings.Add("TUnits", "TUnits");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("Initial", "Initial");
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
		_commandCollection[0].CommandText = string.Format("SELECT  SubjectId,SubjectIdAr,'1' AS Chapter,Topic_1 AS Topic,Topic_1Ar AS TopicAr, U1 AS LO,U1 AS LOAr, T1 AS TS,T1Ar AS TSAr, \r\nAvLO,AvLOAr, OutOfTen AS AvTS,OutOfTenAr AS AvTSAr, TeacherRemarks,TeacherRemarksAr,TUnits, StudentNumber, Initial \r\nFROM tbl_Scores_OL_ReportTH WHERE ClassId = '{0}' AND SemesterId = '{1}' UNION ALL \r\nSELECT  SubjectId,SubjectIdAr,'2' AS Chapter,Topic_2 AS Topic,Topic_2Ar AS TopicAr, U2 AS LO,U2 AS LOAr, T2 AS TS,T2Ar AS TSAr, \r\nAvLO,AvLOAr, OutOfTen AS AvTS,OutOfTenAr AS AvTSAr,TeacherRemarks,TeacherRemarksAr, TUnits, StudentNumber, Initial \r\nFROM tbl_Scores_OL_ReportTH WHERE ClassId = '{0}' AND SemesterId = '{1}' AND TUnits >= 2 UNION ALL \r\nSELECT  SubjectId,SubjectIdAr,'3' AS Chapter,Topic_2 AS Topic,Topic_3Ar AS TopicAr, U3 AS LO,U3 AS LOAr, T3 AS TS,T3Ar AS TSAr, \r\nAvLO,AvLOAr, OutOfTen AS AvTS,OutOfTenAr AS AvTSAr,TeacherRemarks,TeacherRemarksAr, TUnits, StudentNumber, Initial \r\nFROM tbl_Scores_OL_ReportTH WHERE ClassId = '{0}' AND SemesterId = '{1}' AND TUnits >= 3 UNION ALL \r\nSELECT  SubjectId,SubjectIdAr,'4' AS Chapter,Topic_4 AS Topic,Topic_4Ar AS TopicAr, U4 AS LO,U4 AS LOAr, T4 AS TS,T4Ar AS TSAr, \r\nAvLO,AvLOAr, OutOfTen AS AvTS,OutOfTenAr AS AvTSAr,TeacherRemarks,TeacherRemarksAr, TUnits, StudentNumber, Initial \r\nFROM tbl_Scores_OL_ReportTH WHERE ClassId = '{0}' AND SemesterId = '{1}' AND TUnits >= 4 ORDER By SubjectId, Chapter", ReportParameters.Class, ReportParameters.Semester);
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(TheologySubDS.tbl_Scores_OL_ReportTHDataTable dataTable)
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
	public virtual TheologySubDS.tbl_Scores_OL_ReportTHDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		TheologySubDS.tbl_Scores_OL_ReportTHDataTable tbl_Scores_OL_ReportTHDataTable = new TheologySubDS.tbl_Scores_OL_ReportTHDataTable();
		Adapter.Fill(tbl_Scores_OL_ReportTHDataTable);
		return tbl_Scores_OL_ReportTHDataTable;
	}
}
