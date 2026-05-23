using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.NewCurriculumReports.ReportDatasets.DescriptiveUltimateReportTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class adapterDescriptiveUltimateReport : Component
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
	public adapterDescriptiveUltimateReport()
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
		dataTableMapping.DataSetTable = "DescriptiveUltimateReportDS";
		dataTableMapping.ColumnMappings.Add("SubjectId", "SubjectId");
		dataTableMapping.ColumnMappings.Add("Chapter", "Chapter");
		dataTableMapping.ColumnMappings.Add("Topic", "Topic");
		dataTableMapping.ColumnMappings.Add("Competence", "Competence");
		dataTableMapping.ColumnMappings.Add("Descriptor", "Descriptor");
		dataTableMapping.ColumnMappings.Add("LO", "LO");
		dataTableMapping.ColumnMappings.Add("TS", "TS");
		dataTableMapping.ColumnMappings.Add("AvLO", "AvLO");
		dataTableMapping.ColumnMappings.Add("AvTS", "AvTS");
		dataTableMapping.ColumnMappings.Add("Identifier", "Identifier");
		dataTableMapping.ColumnMappings.Add("GenDescriptor", "GenDescriptor");
		dataTableMapping.ColumnMappings.Add("TeacherRemarks", "TeacherRemarks");
		dataTableMapping.ColumnMappings.Add("TUnits", "TUnits");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("Initial", "Initial");
		dataTableMapping.ColumnMappings.Add("GenGenericSkill", "GenGenericSkill");
		dataTableMapping.ColumnMappings.Add("ClassteacherRemark", "ClassteacherRemark");
		dataTableMapping.ColumnMappings.Add("HeadteacherRemark", "HeadteacherRemark");
		dataTableMapping.ColumnMappings.Add("P1", "P1");
		dataTableMapping.ColumnMappings.Add("AvMark", "AvMark");
		dataTableMapping.ColumnMappings.Add("ETA80", "ETA80");
		dataTableMapping.ColumnMappings.Add("Total", "Total");
		dataTableMapping.ColumnMappings.Add("Category", "Category");
		dataTableMapping.ColumnMappings.Add("RemarkOnCompetence", "RemarkOnCompetence");
		dataTableMapping.ColumnMappings.Add("GenericSkill", "GenericSkill");
		dataTableMapping.ColumnMappings.Add("OverallPerformance", "OverallPerformance");
		dataTableMapping.ColumnMappings.Add("OtherRequirements", "OtherRequirements");
		dataTableMapping.ColumnMappings.Add("TeacherRemarksDesc", "TeacherRemarksDesc");
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
		_commandCollection[0].CommandText = string.Format("SELECT SubjectId, '1' AS Chapter, Topic_1 AS Topic, Competence_1 AS Competence, Descriptor_1 AS Descriptor, U1 AS LO, T1 AS TS, AvLO, OutOfTen AS AvTS, Identifier, Comment AS GenDescriptor, TeacherRemarks,TeacherRemarksDesc, TUnits, \r\n                         StudentNumber,OverallPerformance,OtherRequirements, Initial, GenericSkills AS GenGenericSkill, ClassteacherRemark, HeadteacherRemark, P1, AvMark, ETA80, ETAv AS Total, Category, P6 AS RemarkOnCompetence, GenericSkill_1 AS GenericSkill\r\nFROM            tbl_Scores_OL_Report\r\nWHERE        (ClassId = '{0}') AND (SemesterId = '{1}')\r\nUNION ALL\r\nSELECT        SubjectId, '2' AS Chapter, Topic_2 AS Topic, Competence_2 AS Competence, Descriptor_2 AS Descriptor, U2 AS LO, T2 AS TS, AvLO, OutOfTen AS AvTS, Identifier, Comment AS GenDescriptor, TeacherRemarks, TeacherRemarksDesc,TUnits, \r\n                         StudentNumber,OverallPerformance,OtherRequirements, Initial, GenericSkills AS GenGenericSkill, ClassteacherRemark, HeadteacherRemark, P1, AvMark, ETA80, ETAv AS Total, Category, P6 AS RemarkOnCompetence, GenericSkill_2 AS GenericSkill\r\nFROM            tbl_Scores_OL_Report AS tbl_Scores_OL_Report_3\r\nWHERE        (ClassId = '{0}') AND (SemesterId = '{1}') AND (TUnits >= 2)\r\nUNION ALL\r\nSELECT        SubjectId, '3' AS Chapter, Topic_3 AS Topic, Competence_3 AS Competence, Descriptor_3 AS Descriptor, U3 AS LO, T3 AS TS, AvLO, OutOfTen AS AvTS, Identifier, Comment AS GenDescriptor, TeacherRemarks, TeacherRemarksDesc,TUnits, \r\n                         StudentNumber,OverallPerformance,OtherRequirements, Initial, GenericSkills AS GenGenericSkill, ClassteacherRemark, HeadteacherRemark, P1, AvMark, ETA80, ETAv AS Total, Category, P6 AS RemarkOnCompetence, GenericSkill_3 AS GenericSkill\r\nFROM            tbl_Scores_OL_Report AS tbl_Scores_OL_Report_2\r\nWHERE        (ClassId = '{0}') AND (SemesterId = '{1}') AND (TUnits >= 3)\r\nUNION ALL\r\nSELECT        SubjectId, '4' AS Chapter, Topic_4 AS Topic, Competence_4 AS Competence, Descriptor_4 AS Descriptor, U4 AS LO, T4 AS TS, AvLO, OutOfTen AS AvTS, Identifier, Comment AS GenDescriptor, TeacherRemarks, TeacherRemarksDesc,TUnits, \r\n                         StudentNumber,OverallPerformance,OtherRequirements, Initial, GenericSkills AS GenGenericSkill, ClassteacherRemark, HeadteacherRemark, P1, AvMark, ETA80, ETAv AS Total, Category, P6 AS RemarkOnCompetence, GenericSkill_4 AS GenericSkill\r\nFROM            tbl_Scores_OL_Report AS tbl_Scores_OL_Report_1\r\nWHERE        (ClassId = '{0}') AND (SemesterId = '{1}') AND (TUnits >= 4)\r\nORDER BY SubjectId, Chapter\r\n                ", ReportParameters.Class, ReportParameters.Semester);
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(DescriptiveUltimateReport.DescriptiveUltimateReportDSDataTable dataTable)
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
	public virtual DescriptiveUltimateReport.DescriptiveUltimateReportDSDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		DescriptiveUltimateReport.DescriptiveUltimateReportDSDataTable descriptiveUltimateReportDSDataTable = new DescriptiveUltimateReport.DescriptiveUltimateReportDSDataTable();
		Adapter.Fill(descriptiveUltimateReportDSDataTable);
		return descriptiveUltimateReportDSDataTable;
	}
}
