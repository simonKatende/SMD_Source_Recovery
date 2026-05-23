using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.NewCurriculumReports.ReportDatasets.NewCurriculumSubReportTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class adapterNewCurriculumSubAssessed : Component
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
	public adapterNewCurriculumSubAssessed()
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
		dataTableMapping.DataSetTable = "tbl_Scores_OL_Report";
		dataTableMapping.ColumnMappings.Add("Id", "Id");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("SemesterId", "SemesterId");
		dataTableMapping.ColumnMappings.Add("SubjectId", "SubjectId");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("U1", "U1");
		dataTableMapping.ColumnMappings.Add("U2", "U2");
		dataTableMapping.ColumnMappings.Add("U3", "U3");
		dataTableMapping.ColumnMappings.Add("U4", "U4");
		dataTableMapping.ColumnMappings.Add("U5", "U5");
		dataTableMapping.ColumnMappings.Add("T1", "T1");
		dataTableMapping.ColumnMappings.Add("T2", "T2");
		dataTableMapping.ColumnMappings.Add("T3", "T3");
		dataTableMapping.ColumnMappings.Add("T4", "T4");
		dataTableMapping.ColumnMappings.Add("T5", "T5");
		dataTableMapping.ColumnMappings.Add("Score1", "Score1");
		dataTableMapping.ColumnMappings.Add("Score2", "Score2");
		dataTableMapping.ColumnMappings.Add("Score3", "Score3");
		dataTableMapping.ColumnMappings.Add("Expr1", "Expr1");
		dataTableMapping.ColumnMappings.Add("Score5", "Score5");
		dataTableMapping.ColumnMappings.Add("TUnits", "TUnits");
		dataTableMapping.ColumnMappings.Add("Initial", "Initial");
		dataTableMapping.ColumnMappings.Add("Grade", "Grade");
		dataTableMapping.ColumnMappings.Add("Category", "Category");
		dataTableMapping.ColumnMappings.Add("ETA", "ETA");
		dataTableMapping.ColumnMappings.Add("ETAv", "ETAv");
		dataTableMapping.ColumnMappings.Add("Comment", "Comment");
		dataTableMapping.ColumnMappings.Add("ETA80", "ETA80");
		dataTableMapping.ColumnMappings.Add("AvMark", "AvMark");
		dataTableMapping.ColumnMappings.Add("AvLO", "AvLO");
		dataTableMapping.ColumnMappings.Add("Identifier", "Identifier");
		dataTableMapping.ColumnMappings.Add("EOTRemark", "EOTRemark");
		dataTableMapping.ColumnMappings.Add("P1", "P1");
		dataTableMapping.ColumnMappings.Add("P2", "P2");
		dataTableMapping.ColumnMappings.Add("P3", "P3");
		dataTableMapping.ColumnMappings.Add("P4", "P4");
		dataTableMapping.ColumnMappings.Add("P5", "P5");
		dataTableMapping.ColumnMappings.Add("P6", "P6");
		dataTableMapping.ColumnMappings.Add("Identifier100", "Identifier100");
		dataTableMapping.ColumnMappings.Add("TeacherRemarks", "TeacherRemarks");
		dataTableMapping.ColumnMappings.Add("ClassteacherRemark", "ClassteacherRemark");
		dataTableMapping.ColumnMappings.Add("HeadteacherRemark", "HeadteacherRemark");
		dataTableMapping.ColumnMappings.Add("OutOfTwenty", "OutOfTwenty");
		dataTableMapping.ColumnMappings.Add("OutOfTen", "OutOfTen");
		dataTableMapping.ColumnMappings.Add("Descriptor100", "Descriptor100");
		dataTableMapping.ColumnMappings.Add("Score100", "Score100");
		dataTableMapping.ColumnMappings.Add("OverallPerformance", "OverallPerformance");
		dataTableMapping.ColumnMappings.Add("OtherRequirements", "OtherRequirements");
		dataTableMapping.ColumnMappings.Add("ProjAv", "ProjAv");
		dataTableMapping.ColumnMappings.Add("ProjLO", "ProjLO");
		dataTableMapping.ColumnMappings.Add("ProjIdentify", "ProjIdentify");
		dataTableMapping.ColumnMappings.Add("ProjRemark", "ProjRemark");
		dataTableMapping.ColumnMappings.Add("ClassTeacherProject", "ClassTeacherProject");
		dataTableMapping.ColumnMappings.Add("HeadTeacherProject", "HeadTeacherProject");
		dataTableMapping.ColumnMappings.Add("OverallPerformanceLO", "OverallPerformanceLO");
		dataTableMapping.ColumnMappings.Add("OverallPerformance100", "OverallPerformance100");
		dataTableMapping.ColumnMappings.Add("TeacherRemarksAIOnly", "TeacherRemarksAIOnly");
		dataTableMapping.ColumnMappings.Add("CategoryAIOnly", "CategoryAIOnly");
		dataTableMapping.ColumnMappings.Add("SIC", "SIC");
		dataTableMapping.ColumnMappings.Add("SIS", "SIS");
		dataTableMapping.ColumnMappings.Add("SubjectRank", "SubjectRank");
		dataTableMapping.ColumnMappings.Add("GrandAvg", "GrandAvg");
		dataTableMapping.ColumnMappings.Add("SubPosLO", "SubPosLO");
		dataTableMapping.ColumnMappings.Add("SubPosEOT", "SubPosEOT");
		dataTableMapping.ColumnMappings.Add("SubPosLOEOT", "SubPosLOEOT");
		dataTableMapping.ColumnMappings.Add("ClassteacherRemarkFA", "ClassteacherRemarkFA");
		dataTableMapping.ColumnMappings.Add("HeadteacherRemarkFA", "HeadteacherRemarkFA");
		dataTableMapping.ColumnMappings.Add("GenericSkills", "GenericSkills");
		dataTableMapping.ColumnMappings.Add("PICLO", "PICLO");
		dataTableMapping.ColumnMappings.Add("PISLO", "PISLO");
		dataTableMapping.ColumnMappings.Add("PICLOEOT", "PICLOEOT");
		dataTableMapping.ColumnMappings.Add("PICEOT", "PICEOT");
		dataTableMapping.ColumnMappings.Add("PISLOEOT", "PISLOEOT");
		dataTableMapping.ColumnMappings.Add("PISEOT", "PISEOT");
		dataTableMapping.ColumnMappings.Add("TotalStudents", "TotalStudents");
		dataTableMapping.ColumnMappings.Add("GrandAvgLO", "GrandAvgLO");
		dataTableMapping.ColumnMappings.Add("GrandAvgEOT", "GrandAvgEOT");
		dataTableMapping.ColumnMappings.Add("P7", "P7");
		dataTableMapping.ColumnMappings.Add("Score4", "Score4");
		dataTableMapping.ColumnMappings.Add("Hund1", "Hund1");
		dataTableMapping.ColumnMappings.Add("Hund2", "Hund2");
		dataTableMapping.ColumnMappings.Add("Hund3", "Hund3");
		dataTableMapping.ColumnMappings.Add("Hund4", "Hund4");
		dataTableMapping.ColumnMappings.Add("Hund5", "Hund5");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_Scores_OL_Report] WHERE (([Id] = @Original_Id) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_SubjectId = 1 AND [SubjectId] IS NULL) OR ([SubjectId] = @Original_SubjectId)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_U1 = 1 AND [U1] IS NULL) OR ([U1] = @Original_U1)) AND ((@IsNull_U2 = 1 AND [U2] IS NULL) OR ([U2] = @Original_U2)) AND ((@IsNull_U3 = 1 AND [U3] IS NULL) OR ([U3] = @Original_U3)) AND ((@IsNull_U4 = 1 AND [U4] IS NULL) OR ([U4] = @Original_U4)) AND ((@IsNull_U5 = 1 AND [U5] IS NULL) OR ([U5] = @Original_U5)) AND ((@IsNull_T1 = 1 AND [T1] IS NULL) OR ([T1] = @Original_T1)) AND ((@IsNull_T2 = 1 AND [T2] IS NULL) OR ([T2] = @Original_T2)) AND ((@IsNull_T3 = 1 AND [T3] IS NULL) OR ([T3] = @Original_T3)) AND ((@IsNull_T4 = 1 AND [T4] IS NULL) OR ([T4] = @Original_T4)) AND ((@IsNull_T5 = 1 AND [T5] IS NULL) OR ([T5] = @Original_T5)) AND ((@IsNull_Score1 = 1 AND [Score1] IS NULL) OR ([Score1] = @Original_Score1)) AND ((@IsNull_Score2 = 1 AND [Score2] IS NULL) OR ([Score2] = @Original_Score2)) AND ((@IsNull_Score3 = 1 AND [Score3] IS NULL) OR ([Score3] = @Original_Score3)) AND ((@IsNull_Expr1 = 1 AND [Score3] IS NULL) OR ([Score3] = @Original_Expr1)) AND ((@IsNull_Score5 = 1 AND [Score5] IS NULL) OR ([Score5] = @Original_Score5)) AND ((@IsNull_TUnits = 1 AND [TUnits] IS NULL) OR ([TUnits] = @Original_TUnits)) AND ((@IsNull_Initial = 1 AND [Initial] IS NULL) OR ([Initial] = @Original_Initial)) AND ((@IsNull_Grade = 1 AND [Grade] IS NULL) OR ([Grade] = @Original_Grade)) AND ((@IsNull_Category = 1 AND [Category] IS NULL) OR ([Category] = @Original_Category)) AND ((@IsNull_ETA = 1 AND [ETA] IS NULL) OR ([ETA] = @Original_ETA)) AND ((@IsNull_ETAv = 1 AND [ETAv] IS NULL) OR ([ETAv] = @Original_ETAv)) AND ((@IsNull_Comment = 1 AND [Comment] IS NULL) OR ([Comment] = @Original_Comment)) AND ((@IsNull_ETA80 = 1 AND [ETA80] IS NULL) OR ([ETA80] = @Original_ETA80)) AND ((@IsNull_AvMark = 1 AND [AvMark] IS NULL) OR ([AvMark] = @Original_AvMark)) AND ((@IsNull_AvLO = 1 AND [AvLO] IS NULL) OR ([AvLO] = @Original_AvLO)) AND ((@IsNull_Identifier = 1 AND [Identifier] IS NULL) OR ([Identifier] = @Original_Identifier)) AND ((@IsNull_EOTRemark = 1 AND [EOTRemark] IS NULL) OR ([EOTRemark] = @Original_EOTRemark)) AND ((@IsNull_P1 = 1 AND [P1] IS NULL) OR ([P1] = @Original_P1)) AND ((@IsNull_P2 = 1 AND [P2] IS NULL) OR ([P2] = @Original_P2)) AND ((@IsNull_P3 = 1 AND [P3] IS NULL) OR ([P3] = @Original_P3)) AND ((@IsNull_P4 = 1 AND [P4] IS NULL) OR ([P4] = @Original_P4)) AND ((@IsNull_P5 = 1 AND [P5] IS NULL) OR ([P5] = @Original_P5)) AND ((@IsNull_P6 = 1 AND [P6] IS NULL) OR ([P6] = @Original_P6)) AND ((@IsNull_Identifier100 = 1 AND [Identifier100] IS NULL) OR ([Identifier100] = @Original_Identifier100)) AND ((@IsNull_TeacherRemarks = 1 AND [TeacherRemarks] IS NULL) OR ([TeacherRemarks] = @Original_TeacherRemarks)) AND ((@IsNull_ClassteacherRemark = 1 AND [ClassteacherRemark] IS NULL) OR ([ClassteacherRemark] = @Original_ClassteacherRemark)) AND ((@IsNull_HeadteacherRemark = 1 AND [HeadteacherRemark] IS NULL) OR ([HeadteacherRemark] = @Original_HeadteacherRemark)) AND ((@IsNull_OutOfTwenty = 1 AND [OutOfTwenty] IS NULL) OR ([OutOfTwenty] = @Original_OutOfTwenty)) AND ((@IsNull_OutOfTen = 1 AND [OutOfTen] IS NULL) OR ([OutOfTen] = @Original_OutOfTen)) AND ((@IsNull_Descriptor100 = 1 AND [Descriptor100] IS NULL) OR ([Descriptor100] = @Original_Descriptor100)) AND ((@IsNull_Score100 = 1 AND [Score100] IS NULL) OR ([Score100] = @Original_Score100)) AND ((@IsNull_OverallPerformance = 1 AND [OverallPerformance] IS NULL) OR ([OverallPerformance] = @Original_OverallPerformance)) AND ((@IsNull_OtherRequirements = 1 AND [OtherRequirements] IS NULL) OR ([OtherRequirements] = @Original_OtherRequirements)) AND ((@IsNull_ProjAv = 1 AND [ProjAv] IS NULL) OR ([ProjAv] = @Original_ProjAv)) AND ((@IsNull_ProjLO = 1 AND [ProjLO] IS NULL) OR ([ProjLO] = @Original_ProjLO)) AND ((@IsNull_ProjIdentify = 1 AND [ProjIdentify] IS NULL) OR ([ProjIdentify] = @Original_ProjIdentify)) AND ((@IsNull_ProjRemark = 1 AND [ProjRemark] IS NULL) OR ([ProjRemark] = @Original_ProjRemark)) AND ((@IsNull_ClassTeacherProject = 1 AND [ClassTeacherProject] IS NULL) OR ([ClassTeacherProject] = @Original_ClassTeacherProject)) AND ((@IsNull_HeadTeacherProject = 1 AND [HeadTeacherProject] IS NULL) OR ([HeadTeacherProject] = @Original_HeadTeacherProject)) AND ((@IsNull_OverallPerformanceLO = 1 AND [OverallPerformanceLO] IS NULL) OR ([OverallPerformanceLO] = @Original_OverallPerformanceLO)) AND ((@IsNull_OverallPerformance100 = 1 AND [OverallPerformance100] IS NULL) OR ([OverallPerformance100] = @Original_OverallPerformance100)) AND ((@IsNull_TeacherRemarksAIOnly = 1 AND [TeacherRemarksAIOnly] IS NULL) OR ([TeacherRemarksAIOnly] = @Original_TeacherRemarksAIOnly)) AND ((@IsNull_CategoryAIOnly = 1 AND [CategoryAIOnly] IS NULL) OR ([CategoryAIOnly] = @Original_CategoryAIOnly)) AND ((@IsNull_SIC = 1 AND [SIC] IS NULL) OR ([SIC] = @Original_SIC)) AND ((@IsNull_SIS = 1 AND [SIS] IS NULL) OR ([SIS] = @Original_SIS)) AND ((@IsNull_SubjectRank = 1 AND [SubjectRank] IS NULL) OR ([SubjectRank] = @Original_SubjectRank)) AND ((@IsNull_GrandAvg = 1 AND [GrandAvg] IS NULL) OR ([GrandAvg] = @Original_GrandAvg)) AND ((@IsNull_SubPosLO = 1 AND [SubPosLO] IS NULL) OR ([SubPosLO] = @Original_SubPosLO)) AND ((@IsNull_SubPosEOT = 1 AND [SubPosEOT] IS NULL) OR ([SubPosEOT] = @Original_SubPosEOT)) AND ((@IsNull_SubPosLOEOT = 1 AND [SubPosLOEOT] IS NULL) OR ([SubPosLOEOT] = @Original_SubPosLOEOT)) AND ((@IsNull_ClassteacherRemarkFA = 1 AND [ClassteacherRemarkFA] IS NULL) OR ([ClassteacherRemarkFA] = @Original_ClassteacherRemarkFA)) AND ((@IsNull_HeadteacherRemarkFA = 1 AND [HeadteacherRemarkFA] IS NULL) OR ([HeadteacherRemarkFA] = @Original_HeadteacherRemarkFA)) AND ((@IsNull_GenericSkills = 1 AND [GenericSkills] IS NULL) OR ([GenericSkills] = @Original_GenericSkills)) AND ((@IsNull_PICLO = 1 AND [PICLO] IS NULL) OR ([PICLO] = @Original_PICLO)) AND ((@IsNull_PISLO = 1 AND [PISLO] IS NULL) OR ([PISLO] = @Original_PISLO)) AND ((@IsNull_PICLOEOT = 1 AND [PICLOEOT] IS NULL) OR ([PICLOEOT] = @Original_PICLOEOT)) AND ((@IsNull_PICEOT = 1 AND [PICEOT] IS NULL) OR ([PICEOT] = @Original_PICEOT)) AND ((@IsNull_PISLOEOT = 1 AND [PISLOEOT] IS NULL) OR ([PISLOEOT] = @Original_PISLOEOT)) AND ((@IsNull_PISEOT = 1 AND [PISEOT] IS NULL) OR ([PISEOT] = @Original_PISEOT)) AND ((@IsNull_TotalStudents = 1 AND [TotalStudents] IS NULL) OR ([TotalStudents] = @Original_TotalStudents)) AND ((@IsNull_GrandAvgLO = 1 AND [GrandAvgLO] IS NULL) OR ([GrandAvgLO] = @Original_GrandAvgLO)) AND ((@IsNull_GrandAvgEOT = 1 AND [GrandAvgEOT] IS NULL) OR ([GrandAvgEOT] = @Original_GrandAvgEOT)) AND ((@IsNull_P7 = 1 AND [P7] IS NULL) OR ([P7] = @Original_P7)) AND ((@IsNull_Score4 = 1 AND [Score4] IS NULL) OR ([Score4] = @Original_Score4)) AND ((@IsNull_Hund1 = 1 AND [Hund1] IS NULL) OR ([Hund1] = @Original_Hund1)) AND ((@IsNull_Hund2 = 1 AND [Hund2] IS NULL) OR ([Hund2] = @Original_Hund2)) AND ((@IsNull_Hund3 = 1 AND [Hund3] IS NULL) OR ([Hund3] = @Original_Hund3)) AND ((@IsNull_Hund4 = 1 AND [Hund4] IS NULL) OR ([Hund4] = @Original_Hund4)) AND ((@IsNull_Hund5 = 1 AND [Hund5] IS NULL) OR ([Hund5] = @Original_Hund5)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_U1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_U1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_U2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_U2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_U3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_U3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_U4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_U4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_U5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_U5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_T1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_T1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_T2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_T2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_T3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_T3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_T4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_T4", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_T5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_T5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Score1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Score1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Score2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Score2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Score3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Score3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Expr1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Expr1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Expr1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Expr1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Score5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Score5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_TUnits", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TUnits", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_TUnits", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TUnits", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Initial", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ETA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ETA", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ETA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ETA", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ETAv", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ETAv", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ETAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETAv", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Comment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ETA80", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ETA80", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ETA80", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETA80", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_AvMark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_AvLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AvLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_AvLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Identifier", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Identifier", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_EOTRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EOTRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_EOTRemark", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOTRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P6", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P6", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P6", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P6", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Identifier100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Identifier100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_TeacherRemarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TeacherRemarks", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_TeacherRemarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarks", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassteacherRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HeadteacherRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HeadteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OutOfTwenty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OutOfTwenty", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OutOfTwenty", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTwenty", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OutOfTen", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OutOfTen", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OutOfTen", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTen", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Descriptor100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Descriptor100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Descriptor100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Descriptor100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Score100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Score100", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Score100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OverallPerformance", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OverallPerformance", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OverallPerformance", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OtherRequirements", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherRequirements", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OtherRequirements", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherRequirements", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ProjAv", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjAv", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ProjAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjAv", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ProjLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ProjLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ProjIdentify", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjIdentify", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ProjIdentify", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjIdentify", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ProjRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ProjRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ProjRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassTeacherProject", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HeadTeacherProject", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HeadTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HeadTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OverallPerformanceLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OverallPerformanceLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OverallPerformanceLO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformanceLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_OverallPerformance100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OverallPerformance100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_OverallPerformance100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_TeacherRemarksAIOnly", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TeacherRemarksAIOnly", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_TeacherRemarksAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarksAIOnly", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_CategoryAIOnly", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CategoryAIOnly", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_CategoryAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CategoryAIOnly", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SIC", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIC", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SIC", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIC", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SIS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIS", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SIS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIS", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectRank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectRank", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubjectRank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectRank", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_GrandAvg", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandAvg", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GrandAvg", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvg", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubPosLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubPosLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubPosEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubPosEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SubPosLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLOEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SubPosLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLOEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassteacherRemarkFA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HeadteacherRemarkFA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HeadteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_GenericSkills", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GenericSkills", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GenericSkills", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "GenericSkills", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PICLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PICLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PISLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PISLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PICLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLOEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PICLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLOEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PICEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PICEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PISLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLOEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PISLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLOEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PISEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PISEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_TotalStudents", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalStudents", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_TotalStudents", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalStudents", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_GrandAvgLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandAvgLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GrandAvgLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_GrandAvgEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandAvgEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_GrandAvgEOT", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_P7", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P7", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_P7", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P7", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Score4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Score4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Hund1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Hund1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Hund2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Hund2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Hund3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Hund3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Hund4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Hund4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Hund5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Hund5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_Scores_OL_Report] ([StudentNumber], [SemesterId], [SubjectId], [ClassId], [U1], [U2], [U3], [U4], [U5], [T1], [T2], [T3], [T4], [T5], [Score1], [Score2], [Score3], [Score3], [Score5], [TUnits], [Initial], [Grade], [Category], [ETA], [ETAv], [Comment], [ETA80], [AvMark], [AvLO], [Identifier], [EOTRemark], [P1], [P2], [P3], [P4], [P5], [P6], [Identifier100], [TeacherRemarks], [ClassteacherRemark], [HeadteacherRemark], [OutOfTwenty], [OutOfTen], [Descriptor100], [Score100], [OverallPerformance], [OtherRequirements], [ProjAv], [ProjLO], [ProjIdentify], [ProjRemark], [ClassTeacherProject], [HeadTeacherProject], [OverallPerformanceLO], [OverallPerformance100], [TeacherRemarksAIOnly], [CategoryAIOnly], [SIC], [SIS], [SubjectRank], [GrandAvg], [SubPosLO], [SubPosEOT], [SubPosLOEOT], [ClassteacherRemarkFA], [HeadteacherRemarkFA], [GenericSkills], [PICLO], [PISLO], [PICLOEOT], [PICEOT], [PISLOEOT], [PISEOT], [TotalStudents], [GrandAvgLO], [GrandAvgEOT], [P7], [Score4], [Hund1], [Hund2], [Hund3], [Hund4], [Hund5]) VALUES (@StudentNumber, @SemesterId, @SubjectId, @ClassId, @U1, @U2, @U3, @U4, @U5, @T1, @T2, @T3, @T4, @T5, @Score1, @Score2, @Score3, @Expr1, @Score5, @TUnits, @Initial, @Grade, @Category, @ETA, @ETAv, @Comment, @ETA80, @AvMark, @AvLO, @Identifier, @EOTRemark, @P1, @P2, @P3, @P4, @P5, @P6, @Identifier100, @TeacherRemarks, @ClassteacherRemark, @HeadteacherRemark, @OutOfTwenty, @OutOfTen, @Descriptor100, @Score100, @OverallPerformance, @OtherRequirements, @ProjAv, @ProjLO, @ProjIdentify, @ProjRemark, @ClassTeacherProject, @HeadTeacherProject, @OverallPerformanceLO, @OverallPerformance100, @TeacherRemarksAIOnly, @CategoryAIOnly, @SIC, @SIS, @SubjectRank, @GrandAvg, @SubPosLO, @SubPosEOT, @SubPosLOEOT, @ClassteacherRemarkFA, @HeadteacherRemarkFA, @GenericSkills, @PICLO, @PISLO, @PICLOEOT, @PICEOT, @PISLOEOT, @PISEOT, @TotalStudents, @GrandAvgLO, @GrandAvgEOT, @P7, @Score4, @Hund1, @Hund2, @Hund3, @Hund4, @Hund5);\r\nSELECT Id, StudentNumber, SemesterId, SubjectId, ClassId, U1, U2, U3, U4, U5, T1, T2, T3, T4, T5, Score1, Score2, Score3, Score3 AS Expr1, Score5, TUnits, Initial, Grade, Category, ETA, ETAv, Comment, ETA80, AvMark, AvLO, Identifier, EOTRemark, P1, P2, P3, P4, P5, P6, Identifier100, TeacherRemarks, ClassteacherRemark, HeadteacherRemark, OutOfTwenty, OutOfTen, Descriptor100, Score100, OverallPerformance, OtherRequirements, ProjAv, ProjLO, ProjIdentify, ProjRemark, ClassTeacherProject, HeadTeacherProject, OverallPerformanceLO, OverallPerformance100, TeacherRemarksAIOnly, CategoryAIOnly, SIC, SIS, SubjectRank, GrandAvg, SubPosLO, SubPosEOT, SubPosLOEOT, ClassteacherRemarkFA, HeadteacherRemarkFA, GenericSkills, PICLO, PISLO, PICLOEOT, PICEOT, PISLOEOT, PISEOT, TotalStudents, GrandAvgLO, GrandAvgEOT, P7, Score4, Hund1, Hund2, Hund3, Hund4, Hund5 FROM tbl_Scores_OL_Report WHERE (Id = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@U1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@U2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@U3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@U4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@U5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@T1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@T2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@T3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@T4", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@T5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Score1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Score2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Score3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Expr1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Expr1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Score5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@TUnits", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TUnits", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ETA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ETA", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ETAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETAv", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ETA80", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETA80", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@AvLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Identifier", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@EOTRemark", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOTRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P6", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P6", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Identifier100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@TeacherRemarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarks", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HeadteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OutOfTwenty", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTwenty", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OutOfTen", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTen", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descriptor100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Descriptor100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Score100", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Score100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OverallPerformance", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OtherRequirements", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherRequirements", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProjAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjAv", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProjLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProjIdentify", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjIdentify", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProjRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ProjRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassTeacherProject", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HeadTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadTeacherProject", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OverallPerformanceLO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformanceLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@OverallPerformance100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@TeacherRemarksAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarksAIOnly", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@CategoryAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CategoryAIOnly", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SIC", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIC", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SIS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIS", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubjectRank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectRank", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@GrandAvg", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvg", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubPosLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubPosEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubPosLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLOEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemarkFA", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HeadteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemarkFA", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@GenericSkills", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "GenericSkills", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PICLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PISLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PICLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLOEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PICEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PISLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLOEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PISEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@TotalStudents", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalStudents", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@GrandAvgLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@GrandAvgEOT", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@P7", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P7", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Score4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Hund1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Hund2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Hund3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Hund4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Hund5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_Scores_OL_Report] SET [StudentNumber] = @StudentNumber, [SemesterId] = @SemesterId, [SubjectId] = @SubjectId, [ClassId] = @ClassId, [U1] = @U1, [U2] = @U2, [U3] = @U3, [U4] = @U4, [U5] = @U5, [T1] = @T1, [T2] = @T2, [T3] = @T3, [T4] = @T4, [T5] = @T5, [Score1] = @Score1, [Score2] = @Score2, [Score3] = @Score3, [Score3] = @Expr1, [Score5] = @Score5, [TUnits] = @TUnits, [Initial] = @Initial, [Grade] = @Grade, [Category] = @Category, [ETA] = @ETA, [ETAv] = @ETAv, [Comment] = @Comment, [ETA80] = @ETA80, [AvMark] = @AvMark, [AvLO] = @AvLO, [Identifier] = @Identifier, [EOTRemark] = @EOTRemark, [P1] = @P1, [P2] = @P2, [P3] = @P3, [P4] = @P4, [P5] = @P5, [P6] = @P6, [Identifier100] = @Identifier100, [TeacherRemarks] = @TeacherRemarks, [ClassteacherRemark] = @ClassteacherRemark, [HeadteacherRemark] = @HeadteacherRemark, [OutOfTwenty] = @OutOfTwenty, [OutOfTen] = @OutOfTen, [Descriptor100] = @Descriptor100, [Score100] = @Score100, [OverallPerformance] = @OverallPerformance, [OtherRequirements] = @OtherRequirements, [ProjAv] = @ProjAv, [ProjLO] = @ProjLO, [ProjIdentify] = @ProjIdentify, [ProjRemark] = @ProjRemark, [ClassTeacherProject] = @ClassTeacherProject, [HeadTeacherProject] = @HeadTeacherProject, [OverallPerformanceLO] = @OverallPerformanceLO, [OverallPerformance100] = @OverallPerformance100, [TeacherRemarksAIOnly] = @TeacherRemarksAIOnly, [CategoryAIOnly] = @CategoryAIOnly, [SIC] = @SIC, [SIS] = @SIS, [SubjectRank] = @SubjectRank, [GrandAvg] = @GrandAvg, [SubPosLO] = @SubPosLO, [SubPosEOT] = @SubPosEOT, [SubPosLOEOT] = @SubPosLOEOT, [ClassteacherRemarkFA] = @ClassteacherRemarkFA, [HeadteacherRemarkFA] = @HeadteacherRemarkFA, [GenericSkills] = @GenericSkills, [PICLO] = @PICLO, [PISLO] = @PISLO, [PICLOEOT] = @PICLOEOT, [PICEOT] = @PICEOT, [PISLOEOT] = @PISLOEOT, [PISEOT] = @PISEOT, [TotalStudents] = @TotalStudents, [GrandAvgLO] = @GrandAvgLO, [GrandAvgEOT] = @GrandAvgEOT, [P7] = @P7, [Score4] = @Score4, [Hund1] = @Hund1, [Hund2] = @Hund2, [Hund3] = @Hund3, [Hund4] = @Hund4, [Hund5] = @Hund5 WHERE (([Id] = @Original_Id) AND ((@IsNull_StudentNumber = 1 AND [StudentNumber] IS NULL) OR ([StudentNumber] = @Original_StudentNumber)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_SubjectId = 1 AND [SubjectId] IS NULL) OR ([SubjectId] = @Original_SubjectId)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_U1 = 1 AND [U1] IS NULL) OR ([U1] = @Original_U1)) AND ((@IsNull_U2 = 1 AND [U2] IS NULL) OR ([U2] = @Original_U2)) AND ((@IsNull_U3 = 1 AND [U3] IS NULL) OR ([U3] = @Original_U3)) AND ((@IsNull_U4 = 1 AND [U4] IS NULL) OR ([U4] = @Original_U4)) AND ((@IsNull_U5 = 1 AND [U5] IS NULL) OR ([U5] = @Original_U5)) AND ((@IsNull_T1 = 1 AND [T1] IS NULL) OR ([T1] = @Original_T1)) AND ((@IsNull_T2 = 1 AND [T2] IS NULL) OR ([T2] = @Original_T2)) AND ((@IsNull_T3 = 1 AND [T3] IS NULL) OR ([T3] = @Original_T3)) AND ((@IsNull_T4 = 1 AND [T4] IS NULL) OR ([T4] = @Original_T4)) AND ((@IsNull_T5 = 1 AND [T5] IS NULL) OR ([T5] = @Original_T5)) AND ((@IsNull_Score1 = 1 AND [Score1] IS NULL) OR ([Score1] = @Original_Score1)) AND ((@IsNull_Score2 = 1 AND [Score2] IS NULL) OR ([Score2] = @Original_Score2)) AND ((@IsNull_Score3 = 1 AND [Score3] IS NULL) OR ([Score3] = @Original_Score3)) AND ((@IsNull_Expr1 = 1 AND [Score3] IS NULL) OR ([Score3] = @Original_Expr1)) AND ((@IsNull_Score5 = 1 AND [Score5] IS NULL) OR ([Score5] = @Original_Score5)) AND ((@IsNull_TUnits = 1 AND [TUnits] IS NULL) OR ([TUnits] = @Original_TUnits)) AND ((@IsNull_Initial = 1 AND [Initial] IS NULL) OR ([Initial] = @Original_Initial)) AND ((@IsNull_Grade = 1 AND [Grade] IS NULL) OR ([Grade] = @Original_Grade)) AND ((@IsNull_Category = 1 AND [Category] IS NULL) OR ([Category] = @Original_Category)) AND ((@IsNull_ETA = 1 AND [ETA] IS NULL) OR ([ETA] = @Original_ETA)) AND ((@IsNull_ETAv = 1 AND [ETAv] IS NULL) OR ([ETAv] = @Original_ETAv)) AND ((@IsNull_Comment = 1 AND [Comment] IS NULL) OR ([Comment] = @Original_Comment)) AND ((@IsNull_ETA80 = 1 AND [ETA80] IS NULL) OR ([ETA80] = @Original_ETA80)) AND ((@IsNull_AvMark = 1 AND [AvMark] IS NULL) OR ([AvMark] = @Original_AvMark)) AND ((@IsNull_AvLO = 1 AND [AvLO] IS NULL) OR ([AvLO] = @Original_AvLO)) AND ((@IsNull_Identifier = 1 AND [Identifier] IS NULL) OR ([Identifier] = @Original_Identifier)) AND ((@IsNull_EOTRemark = 1 AND [EOTRemark] IS NULL) OR ([EOTRemark] = @Original_EOTRemark)) AND ((@IsNull_P1 = 1 AND [P1] IS NULL) OR ([P1] = @Original_P1)) AND ((@IsNull_P2 = 1 AND [P2] IS NULL) OR ([P2] = @Original_P2)) AND ((@IsNull_P3 = 1 AND [P3] IS NULL) OR ([P3] = @Original_P3)) AND ((@IsNull_P4 = 1 AND [P4] IS NULL) OR ([P4] = @Original_P4)) AND ((@IsNull_P5 = 1 AND [P5] IS NULL) OR ([P5] = @Original_P5)) AND ((@IsNull_P6 = 1 AND [P6] IS NULL) OR ([P6] = @Original_P6)) AND ((@IsNull_Identifier100 = 1 AND [Identifier100] IS NULL) OR ([Identifier100] = @Original_Identifier100)) AND ((@IsNull_TeacherRemarks = 1 AND [TeacherRemarks] IS NULL) OR ([TeacherRemarks] = @Original_TeacherRemarks)) AND ((@IsNull_ClassteacherRemark = 1 AND [ClassteacherRemark] IS NULL) OR ([ClassteacherRemark] = @Original_ClassteacherRemark)) AND ((@IsNull_HeadteacherRemark = 1 AND [HeadteacherRemark] IS NULL) OR ([HeadteacherRemark] = @Original_HeadteacherRemark)) AND ((@IsNull_OutOfTwenty = 1 AND [OutOfTwenty] IS NULL) OR ([OutOfTwenty] = @Original_OutOfTwenty)) AND ((@IsNull_OutOfTen = 1 AND [OutOfTen] IS NULL) OR ([OutOfTen] = @Original_OutOfTen)) AND ((@IsNull_Descriptor100 = 1 AND [Descriptor100] IS NULL) OR ([Descriptor100] = @Original_Descriptor100)) AND ((@IsNull_Score100 = 1 AND [Score100] IS NULL) OR ([Score100] = @Original_Score100)) AND ((@IsNull_OverallPerformance = 1 AND [OverallPerformance] IS NULL) OR ([OverallPerformance] = @Original_OverallPerformance)) AND ((@IsNull_OtherRequirements = 1 AND [OtherRequirements] IS NULL) OR ([OtherRequirements] = @Original_OtherRequirements)) AND ((@IsNull_ProjAv = 1 AND [ProjAv] IS NULL) OR ([ProjAv] = @Original_ProjAv)) AND ((@IsNull_ProjLO = 1 AND [ProjLO] IS NULL) OR ([ProjLO] = @Original_ProjLO)) AND ((@IsNull_ProjIdentify = 1 AND [ProjIdentify] IS NULL) OR ([ProjIdentify] = @Original_ProjIdentify)) AND ((@IsNull_ProjRemark = 1 AND [ProjRemark] IS NULL) OR ([ProjRemark] = @Original_ProjRemark)) AND ((@IsNull_ClassTeacherProject = 1 AND [ClassTeacherProject] IS NULL) OR ([ClassTeacherProject] = @Original_ClassTeacherProject)) AND ((@IsNull_HeadTeacherProject = 1 AND [HeadTeacherProject] IS NULL) OR ([HeadTeacherProject] = @Original_HeadTeacherProject)) AND ((@IsNull_OverallPerformanceLO = 1 AND [OverallPerformanceLO] IS NULL) OR ([OverallPerformanceLO] = @Original_OverallPerformanceLO)) AND ((@IsNull_OverallPerformance100 = 1 AND [OverallPerformance100] IS NULL) OR ([OverallPerformance100] = @Original_OverallPerformance100)) AND ((@IsNull_TeacherRemarksAIOnly = 1 AND [TeacherRemarksAIOnly] IS NULL) OR ([TeacherRemarksAIOnly] = @Original_TeacherRemarksAIOnly)) AND ((@IsNull_CategoryAIOnly = 1 AND [CategoryAIOnly] IS NULL) OR ([CategoryAIOnly] = @Original_CategoryAIOnly)) AND ((@IsNull_SIC = 1 AND [SIC] IS NULL) OR ([SIC] = @Original_SIC)) AND ((@IsNull_SIS = 1 AND [SIS] IS NULL) OR ([SIS] = @Original_SIS)) AND ((@IsNull_SubjectRank = 1 AND [SubjectRank] IS NULL) OR ([SubjectRank] = @Original_SubjectRank)) AND ((@IsNull_GrandAvg = 1 AND [GrandAvg] IS NULL) OR ([GrandAvg] = @Original_GrandAvg)) AND ((@IsNull_SubPosLO = 1 AND [SubPosLO] IS NULL) OR ([SubPosLO] = @Original_SubPosLO)) AND ((@IsNull_SubPosEOT = 1 AND [SubPosEOT] IS NULL) OR ([SubPosEOT] = @Original_SubPosEOT)) AND ((@IsNull_SubPosLOEOT = 1 AND [SubPosLOEOT] IS NULL) OR ([SubPosLOEOT] = @Original_SubPosLOEOT)) AND ((@IsNull_ClassteacherRemarkFA = 1 AND [ClassteacherRemarkFA] IS NULL) OR ([ClassteacherRemarkFA] = @Original_ClassteacherRemarkFA)) AND ((@IsNull_HeadteacherRemarkFA = 1 AND [HeadteacherRemarkFA] IS NULL) OR ([HeadteacherRemarkFA] = @Original_HeadteacherRemarkFA)) AND ((@IsNull_GenericSkills = 1 AND [GenericSkills] IS NULL) OR ([GenericSkills] = @Original_GenericSkills)) AND ((@IsNull_PICLO = 1 AND [PICLO] IS NULL) OR ([PICLO] = @Original_PICLO)) AND ((@IsNull_PISLO = 1 AND [PISLO] IS NULL) OR ([PISLO] = @Original_PISLO)) AND ((@IsNull_PICLOEOT = 1 AND [PICLOEOT] IS NULL) OR ([PICLOEOT] = @Original_PICLOEOT)) AND ((@IsNull_PICEOT = 1 AND [PICEOT] IS NULL) OR ([PICEOT] = @Original_PICEOT)) AND ((@IsNull_PISLOEOT = 1 AND [PISLOEOT] IS NULL) OR ([PISLOEOT] = @Original_PISLOEOT)) AND ((@IsNull_PISEOT = 1 AND [PISEOT] IS NULL) OR ([PISEOT] = @Original_PISEOT)) AND ((@IsNull_TotalStudents = 1 AND [TotalStudents] IS NULL) OR ([TotalStudents] = @Original_TotalStudents)) AND ((@IsNull_GrandAvgLO = 1 AND [GrandAvgLO] IS NULL) OR ([GrandAvgLO] = @Original_GrandAvgLO)) AND ((@IsNull_GrandAvgEOT = 1 AND [GrandAvgEOT] IS NULL) OR ([GrandAvgEOT] = @Original_GrandAvgEOT)) AND ((@IsNull_P7 = 1 AND [P7] IS NULL) OR ([P7] = @Original_P7)) AND ((@IsNull_Score4 = 1 AND [Score4] IS NULL) OR ([Score4] = @Original_Score4)) AND ((@IsNull_Hund1 = 1 AND [Hund1] IS NULL) OR ([Hund1] = @Original_Hund1)) AND ((@IsNull_Hund2 = 1 AND [Hund2] IS NULL) OR ([Hund2] = @Original_Hund2)) AND ((@IsNull_Hund3 = 1 AND [Hund3] IS NULL) OR ([Hund3] = @Original_Hund3)) AND ((@IsNull_Hund4 = 1 AND [Hund4] IS NULL) OR ([Hund4] = @Original_Hund4)) AND ((@IsNull_Hund5 = 1 AND [Hund5] IS NULL) OR ([Hund5] = @Original_Hund5)));\r\nSELECT Id, StudentNumber, SemesterId, SubjectId, ClassId, U1, U2, U3, U4, U5, T1, T2, T3, T4, T5, Score1, Score2, Score3, Score3 AS Expr1, Score5, TUnits, Initial, Grade, Category, ETA, ETAv, Comment, ETA80, AvMark, AvLO, Identifier, EOTRemark, P1, P2, P3, P4, P5, P6, Identifier100, TeacherRemarks, ClassteacherRemark, HeadteacherRemark, OutOfTwenty, OutOfTen, Descriptor100, Score100, OverallPerformance, OtherRequirements, ProjAv, ProjLO, ProjIdentify, ProjRemark, ClassTeacherProject, HeadTeacherProject, OverallPerformanceLO, OverallPerformance100, TeacherRemarksAIOnly, CategoryAIOnly, SIC, SIS, SubjectRank, GrandAvg, SubPosLO, SubPosEOT, SubPosLOEOT, ClassteacherRemarkFA, HeadteacherRemarkFA, GenericSkills, PICLO, PISLO, PICLOEOT, PICEOT, PISLOEOT, PISEOT, TotalStudents, GrandAvgLO, GrandAvgEOT, P7, Score4, Hund1, Hund2, Hund3, Hund4, Hund5 FROM tbl_Scores_OL_Report WHERE (Id = @Id)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@U1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@U2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@U3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@U4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@U5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@T1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@T2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@T3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@T4", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@T5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Score1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Score2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Score3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Expr1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Expr1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Score5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TUnits", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TUnits", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ETA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ETA", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ETAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETAv", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ETA80", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETA80", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@AvLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Identifier", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EOTRemark", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOTRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P6", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P6", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Identifier100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TeacherRemarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarks", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HeadteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OutOfTwenty", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTwenty", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OutOfTen", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTen", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descriptor100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Descriptor100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Score100", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Score100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OverallPerformance", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OtherRequirements", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherRequirements", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProjAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjAv", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProjLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProjIdentify", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjIdentify", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProjRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ProjRemark", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassTeacherProject", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HeadTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadTeacherProject", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OverallPerformanceLO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformanceLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OverallPerformance100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance100", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TeacherRemarksAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarksAIOnly", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CategoryAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CategoryAIOnly", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SIC", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIC", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SIS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIS", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubjectRank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectRank", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GrandAvg", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvg", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubPosLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubPosEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubPosLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLOEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemarkFA", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HeadteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemarkFA", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GenericSkills", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "GenericSkills", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PICLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PISLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PICLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLOEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PICEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PISLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLOEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PISEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TotalStudents", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalStudents", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GrandAvgLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgLO", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GrandAvgEOT", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgEOT", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@P7", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P7", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Score4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Hund1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund1", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Hund2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund2", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Hund3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund3", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Hund4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund4", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Hund5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund5", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubjectId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SubjectId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_U1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_U1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_U2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_U2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_U3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_U3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_U4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_U4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_U5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "U5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_U5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "U5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_T1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_T1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_T2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_T2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_T3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_T3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_T4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_T4", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_T5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_T5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "T5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Score1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Score1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Score2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Score2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Score3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Score3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Expr1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Expr1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Expr1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Expr1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Score5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Score5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_TUnits", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TUnits", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_TUnits", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TUnits", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Initial", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Initial", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Initial", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Grade", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Grade", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Category", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Category", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ETA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ETA", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ETA", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ETA", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ETAv", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ETAv", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ETAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETAv", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Comment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Comment", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Comment", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ETA80", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ETA80", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ETA80", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ETA80", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_AvMark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_AvMark", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvMark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_AvLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AvLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_AvLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "AvLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Identifier", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Identifier", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_EOTRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EOTRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_EOTRemark", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "EOTRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P1", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P2", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P3", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P5", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P6", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P6", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P6", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "P6", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Identifier100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Identifier100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Identifier100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_TeacherRemarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TeacherRemarks", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_TeacherRemarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarks", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassteacherRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HeadteacherRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HeadteacherRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OutOfTwenty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OutOfTwenty", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OutOfTwenty", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTwenty", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OutOfTen", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OutOfTen", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OutOfTen", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "OutOfTen", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Descriptor100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Descriptor100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Descriptor100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Descriptor100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Score100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Score100", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "Score100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OverallPerformance", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OverallPerformance", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OverallPerformance", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OtherRequirements", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherRequirements", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OtherRequirements", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OtherRequirements", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ProjAv", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjAv", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ProjAv", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjAv", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ProjLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ProjLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "ProjLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ProjIdentify", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjIdentify", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ProjIdentify", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjIdentify", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ProjRemark", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProjRemark", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ProjRemark", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ProjRemark", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassTeacherProject", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HeadTeacherProject", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HeadTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HeadTeacherProject", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadTeacherProject", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OverallPerformanceLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OverallPerformanceLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OverallPerformanceLO", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformanceLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_OverallPerformance100", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OverallPerformance100", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_OverallPerformance100", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "OverallPerformance100", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_TeacherRemarksAIOnly", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TeacherRemarksAIOnly", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_TeacherRemarksAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TeacherRemarksAIOnly", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_CategoryAIOnly", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CategoryAIOnly", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_CategoryAIOnly", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "CategoryAIOnly", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SIC", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIC", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SIC", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIC", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SIS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIS", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SIS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SIS", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubjectRank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectRank", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubjectRank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubjectRank", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_GrandAvg", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandAvg", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GrandAvg", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvg", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubPosLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubPosLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubPosEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubPosEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SubPosLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLOEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SubPosLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubPosLOEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassteacherRemarkFA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ClassteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HeadteacherRemarkFA", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HeadteacherRemarkFA", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "HeadteacherRemarkFA", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_GenericSkills", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GenericSkills", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GenericSkills", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "GenericSkills", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PICLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PICLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PISLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PISLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PICLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLOEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PICLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICLOEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PICEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PICEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PICEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PISLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLOEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PISLOEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISLOEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PISEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PISEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PISEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_TotalStudents", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalStudents", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_TotalStudents", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalStudents", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_GrandAvgLO", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandAvgLO", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GrandAvgLO", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgLO", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_GrandAvgEOT", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandAvgEOT", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_GrandAvgEOT", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "GrandAvgEOT", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_P7", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "P7", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_P7", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "P7", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Score4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Score4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Score4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Score4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Hund1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund1", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Hund1", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund1", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Hund2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund2", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Hund2", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund2", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Hund3", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund3", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Hund3", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund3", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Hund4", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund4", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Hund4", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund4", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Hund5", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Hund5", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Hund5", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Hund5", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT        Id, StudentNumber, SemesterId, SubjectId, ClassId, U1, U2, U3, U4, U5, T1, T2, T3, T4, T5, Score1, Score2, Score3, Score3 AS Expr1, Score5, TUnits, Initial, Grade, Category, ETA, ETAv, Comment, ETA80, AvMark, AvLO, Identifier,\r\n                          EOTRemark, P1, P2, P3, P4, P5, P6, Identifier100, TeacherRemarks, ClassteacherRemark, HeadteacherRemark, OutOfTwenty, OutOfTen, Descriptor100, Score100, OverallPerformance, OtherRequirements, ProjAv, ProjLO, \r\n                         ProjIdentify, ProjRemark, ClassTeacherProject, HeadTeacherProject, OverallPerformanceLO, OverallPerformance100, TeacherRemarksAIOnly, CategoryAIOnly, SIC, SIS, SubjectRank, GrandAvg, SubPosLO, SubPosEOT, \r\n                         SubPosLOEOT, ClassteacherRemarkFA, HeadteacherRemarkFA, GenericSkills, PICLO, PISLO, PICLOEOT, PICEOT, PISLOEOT, PISEOT, TotalStudents, GrandAvgLO, GrandAvgEOT, P7, Score4, Hund1, Hund2, Hund3, Hund4, \r\n                         Hund5\r\nFROM            tbl_Scores_OL_Report\r\nWHERE        (ClassId = '{ReportParameters.Class}') AND (SemesterId = '{ReportParameters.Semester}') AND (IsAssessed = 1)";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(NewCurriculumSubReport.tbl_Scores_OL_ReportDataTable dataTable)
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
	public virtual NewCurriculumSubReport.tbl_Scores_OL_ReportDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		NewCurriculumSubReport.tbl_Scores_OL_ReportDataTable tbl_Scores_OL_ReportDataTable = new NewCurriculumSubReport.tbl_Scores_OL_ReportDataTable();
		Adapter.Fill(tbl_Scores_OL_ReportDataTable);
		return tbl_Scores_OL_ReportDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(NewCurriculumSubReport.tbl_Scores_OL_ReportDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(NewCurriculumSubReport dataSet)
	{
		return Adapter.Update(dataSet, "tbl_Scores_OL_Report");
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
	public virtual int Delete(long Original_Id, string Original_StudentNumber, string Original_SemesterId, string Original_SubjectId, string Original_ClassId, string Original_U1, string Original_U2, string Original_U3, string Original_U4, string Original_U5, string Original_T1, string Original_T2, string Original_T3, string Original_T4, string Original_T5, string Original_Score1, string Original_Score2, string Original_Score3, string Original_Expr1, string Original_Score5, int? Original_TUnits, string Original_Initial, int? Original_Grade, string Original_Category, string Original_ETA, double? Original_ETAv, string Original_Comment, double? Original_ETA80, double? Original_AvMark, double? Original_AvLO, int? Original_Identifier, string Original_EOTRemark, string Original_P1, string Original_P2, string Original_P3, string Original_P4, string Original_P5, string Original_P6, int? Original_Identifier100, string Original_TeacherRemarks, string Original_ClassteacherRemark, string Original_HeadteacherRemark, double? Original_OutOfTwenty, double? Original_OutOfTen, string Original_Descriptor100, double? Original_Score100, string Original_OverallPerformance, string Original_OtherRequirements, double? Original_ProjAv, double? Original_ProjLO, int? Original_ProjIdentify, string Original_ProjRemark, string Original_ClassTeacherProject, string Original_HeadTeacherProject, string Original_OverallPerformanceLO, string Original_OverallPerformance100, string Original_TeacherRemarksAIOnly, string Original_CategoryAIOnly, int? Original_SIC, int? Original_SIS, int? Original_SubjectRank, double? Original_GrandAvg, int? Original_SubPosLO, int? Original_SubPosEOT, int? Original_SubPosLOEOT, string Original_ClassteacherRemarkFA, string Original_HeadteacherRemarkFA, string Original_GenericSkills, int? Original_PICLO, int? Original_PISLO, int? Original_PICLOEOT, int? Original_PICEOT, int? Original_PISLOEOT, int? Original_PISEOT, int? Original_TotalStudents, double? Original_GrandAvgLO, double? Original_GrandAvgEOT, string Original_P7, string Original_Score4, string Original_Hund1, string Original_Hund2, string Original_Hund3, string Original_Hund4, string Original_Hund5)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_Id;
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
		if (Original_SemesterId == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_SemesterId;
		}
		if (Original_SubjectId == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_SubjectId;
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
		if (Original_U1 == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_U1;
		}
		if (Original_U2 == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_U2;
		}
		if (Original_U3 == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_U3;
		}
		if (Original_U4 == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_U4;
		}
		if (Original_U5 == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_U5;
		}
		if (Original_T1 == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_T1;
		}
		if (Original_T2 == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_T2;
		}
		if (Original_T3 == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_T3;
		}
		if (Original_T4 == null)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_T4;
		}
		if (Original_T5 == null)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_T5;
		}
		if (Original_Score1 == null)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_Score1;
		}
		if (Original_Score2 == null)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_Score2;
		}
		if (Original_Score3 == null)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_Score3;
		}
		if (Original_Expr1 == null)
		{
			throw new ArgumentNullException("Original_Expr1");
		}
		Adapter.DeleteCommand.Parameters[35].Value = 0;
		Adapter.DeleteCommand.Parameters[36].Value = Original_Expr1;
		if (Original_Score5 == null)
		{
			Adapter.DeleteCommand.Parameters[37].Value = 1;
			Adapter.DeleteCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[37].Value = 0;
			Adapter.DeleteCommand.Parameters[38].Value = Original_Score5;
		}
		if (Original_TUnits.HasValue)
		{
			Adapter.DeleteCommand.Parameters[39].Value = 0;
			Adapter.DeleteCommand.Parameters[40].Value = Original_TUnits.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[39].Value = 1;
			Adapter.DeleteCommand.Parameters[40].Value = DBNull.Value;
		}
		if (Original_Initial == null)
		{
			Adapter.DeleteCommand.Parameters[41].Value = 1;
			Adapter.DeleteCommand.Parameters[42].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[41].Value = 0;
			Adapter.DeleteCommand.Parameters[42].Value = Original_Initial;
		}
		if (Original_Grade.HasValue)
		{
			Adapter.DeleteCommand.Parameters[43].Value = 0;
			Adapter.DeleteCommand.Parameters[44].Value = Original_Grade.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[43].Value = 1;
			Adapter.DeleteCommand.Parameters[44].Value = DBNull.Value;
		}
		if (Original_Category == null)
		{
			Adapter.DeleteCommand.Parameters[45].Value = 1;
			Adapter.DeleteCommand.Parameters[46].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[45].Value = 0;
			Adapter.DeleteCommand.Parameters[46].Value = Original_Category;
		}
		if (Original_ETA == null)
		{
			Adapter.DeleteCommand.Parameters[47].Value = 1;
			Adapter.DeleteCommand.Parameters[48].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[47].Value = 0;
			Adapter.DeleteCommand.Parameters[48].Value = Original_ETA;
		}
		if (Original_ETAv.HasValue)
		{
			Adapter.DeleteCommand.Parameters[49].Value = 0;
			Adapter.DeleteCommand.Parameters[50].Value = Original_ETAv.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[49].Value = 1;
			Adapter.DeleteCommand.Parameters[50].Value = DBNull.Value;
		}
		if (Original_Comment == null)
		{
			Adapter.DeleteCommand.Parameters[51].Value = 1;
			Adapter.DeleteCommand.Parameters[52].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[51].Value = 0;
			Adapter.DeleteCommand.Parameters[52].Value = Original_Comment;
		}
		if (Original_ETA80.HasValue)
		{
			Adapter.DeleteCommand.Parameters[53].Value = 0;
			Adapter.DeleteCommand.Parameters[54].Value = Original_ETA80.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[53].Value = 1;
			Adapter.DeleteCommand.Parameters[54].Value = DBNull.Value;
		}
		if (Original_AvMark.HasValue)
		{
			Adapter.DeleteCommand.Parameters[55].Value = 0;
			Adapter.DeleteCommand.Parameters[56].Value = Original_AvMark.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[55].Value = 1;
			Adapter.DeleteCommand.Parameters[56].Value = DBNull.Value;
		}
		if (Original_AvLO.HasValue)
		{
			Adapter.DeleteCommand.Parameters[57].Value = 0;
			Adapter.DeleteCommand.Parameters[58].Value = Original_AvLO.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[57].Value = 1;
			Adapter.DeleteCommand.Parameters[58].Value = DBNull.Value;
		}
		if (Original_Identifier.HasValue)
		{
			Adapter.DeleteCommand.Parameters[59].Value = 0;
			Adapter.DeleteCommand.Parameters[60].Value = Original_Identifier.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[59].Value = 1;
			Adapter.DeleteCommand.Parameters[60].Value = DBNull.Value;
		}
		if (Original_EOTRemark == null)
		{
			Adapter.DeleteCommand.Parameters[61].Value = 1;
			Adapter.DeleteCommand.Parameters[62].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[61].Value = 0;
			Adapter.DeleteCommand.Parameters[62].Value = Original_EOTRemark;
		}
		if (Original_P1 == null)
		{
			Adapter.DeleteCommand.Parameters[63].Value = 1;
			Adapter.DeleteCommand.Parameters[64].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[63].Value = 0;
			Adapter.DeleteCommand.Parameters[64].Value = Original_P1;
		}
		if (Original_P2 == null)
		{
			Adapter.DeleteCommand.Parameters[65].Value = 1;
			Adapter.DeleteCommand.Parameters[66].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[65].Value = 0;
			Adapter.DeleteCommand.Parameters[66].Value = Original_P2;
		}
		if (Original_P3 == null)
		{
			Adapter.DeleteCommand.Parameters[67].Value = 1;
			Adapter.DeleteCommand.Parameters[68].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[67].Value = 0;
			Adapter.DeleteCommand.Parameters[68].Value = Original_P3;
		}
		if (Original_P4 == null)
		{
			Adapter.DeleteCommand.Parameters[69].Value = 1;
			Adapter.DeleteCommand.Parameters[70].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[69].Value = 0;
			Adapter.DeleteCommand.Parameters[70].Value = Original_P4;
		}
		if (Original_P5 == null)
		{
			Adapter.DeleteCommand.Parameters[71].Value = 1;
			Adapter.DeleteCommand.Parameters[72].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[71].Value = 0;
			Adapter.DeleteCommand.Parameters[72].Value = Original_P5;
		}
		if (Original_P6 == null)
		{
			Adapter.DeleteCommand.Parameters[73].Value = 1;
			Adapter.DeleteCommand.Parameters[74].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[73].Value = 0;
			Adapter.DeleteCommand.Parameters[74].Value = Original_P6;
		}
		if (Original_Identifier100.HasValue)
		{
			Adapter.DeleteCommand.Parameters[75].Value = 0;
			Adapter.DeleteCommand.Parameters[76].Value = Original_Identifier100.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[75].Value = 1;
			Adapter.DeleteCommand.Parameters[76].Value = DBNull.Value;
		}
		if (Original_TeacherRemarks == null)
		{
			Adapter.DeleteCommand.Parameters[77].Value = 1;
			Adapter.DeleteCommand.Parameters[78].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[77].Value = 0;
			Adapter.DeleteCommand.Parameters[78].Value = Original_TeacherRemarks;
		}
		if (Original_ClassteacherRemark == null)
		{
			Adapter.DeleteCommand.Parameters[79].Value = 1;
			Adapter.DeleteCommand.Parameters[80].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[79].Value = 0;
			Adapter.DeleteCommand.Parameters[80].Value = Original_ClassteacherRemark;
		}
		if (Original_HeadteacherRemark == null)
		{
			Adapter.DeleteCommand.Parameters[81].Value = 1;
			Adapter.DeleteCommand.Parameters[82].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[81].Value = 0;
			Adapter.DeleteCommand.Parameters[82].Value = Original_HeadteacherRemark;
		}
		if (Original_OutOfTwenty.HasValue)
		{
			Adapter.DeleteCommand.Parameters[83].Value = 0;
			Adapter.DeleteCommand.Parameters[84].Value = Original_OutOfTwenty.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[83].Value = 1;
			Adapter.DeleteCommand.Parameters[84].Value = DBNull.Value;
		}
		if (Original_OutOfTen.HasValue)
		{
			Adapter.DeleteCommand.Parameters[85].Value = 0;
			Adapter.DeleteCommand.Parameters[86].Value = Original_OutOfTen.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[85].Value = 1;
			Adapter.DeleteCommand.Parameters[86].Value = DBNull.Value;
		}
		if (Original_Descriptor100 == null)
		{
			Adapter.DeleteCommand.Parameters[87].Value = 1;
			Adapter.DeleteCommand.Parameters[88].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[87].Value = 0;
			Adapter.DeleteCommand.Parameters[88].Value = Original_Descriptor100;
		}
		if (Original_Score100.HasValue)
		{
			Adapter.DeleteCommand.Parameters[89].Value = 0;
			Adapter.DeleteCommand.Parameters[90].Value = Original_Score100.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[89].Value = 1;
			Adapter.DeleteCommand.Parameters[90].Value = DBNull.Value;
		}
		if (Original_OverallPerformance == null)
		{
			Adapter.DeleteCommand.Parameters[91].Value = 1;
			Adapter.DeleteCommand.Parameters[92].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[91].Value = 0;
			Adapter.DeleteCommand.Parameters[92].Value = Original_OverallPerformance;
		}
		if (Original_OtherRequirements == null)
		{
			Adapter.DeleteCommand.Parameters[93].Value = 1;
			Adapter.DeleteCommand.Parameters[94].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[93].Value = 0;
			Adapter.DeleteCommand.Parameters[94].Value = Original_OtherRequirements;
		}
		if (Original_ProjAv.HasValue)
		{
			Adapter.DeleteCommand.Parameters[95].Value = 0;
			Adapter.DeleteCommand.Parameters[96].Value = Original_ProjAv.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[95].Value = 1;
			Adapter.DeleteCommand.Parameters[96].Value = DBNull.Value;
		}
		if (Original_ProjLO.HasValue)
		{
			Adapter.DeleteCommand.Parameters[97].Value = 0;
			Adapter.DeleteCommand.Parameters[98].Value = Original_ProjLO.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[97].Value = 1;
			Adapter.DeleteCommand.Parameters[98].Value = DBNull.Value;
		}
		if (Original_ProjIdentify.HasValue)
		{
			Adapter.DeleteCommand.Parameters[99].Value = 0;
			Adapter.DeleteCommand.Parameters[100].Value = Original_ProjIdentify.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[99].Value = 1;
			Adapter.DeleteCommand.Parameters[100].Value = DBNull.Value;
		}
		if (Original_ProjRemark == null)
		{
			Adapter.DeleteCommand.Parameters[101].Value = 1;
			Adapter.DeleteCommand.Parameters[102].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[101].Value = 0;
			Adapter.DeleteCommand.Parameters[102].Value = Original_ProjRemark;
		}
		if (Original_ClassTeacherProject == null)
		{
			Adapter.DeleteCommand.Parameters[103].Value = 1;
			Adapter.DeleteCommand.Parameters[104].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[103].Value = 0;
			Adapter.DeleteCommand.Parameters[104].Value = Original_ClassTeacherProject;
		}
		if (Original_HeadTeacherProject == null)
		{
			Adapter.DeleteCommand.Parameters[105].Value = 1;
			Adapter.DeleteCommand.Parameters[106].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[105].Value = 0;
			Adapter.DeleteCommand.Parameters[106].Value = Original_HeadTeacherProject;
		}
		if (Original_OverallPerformanceLO == null)
		{
			Adapter.DeleteCommand.Parameters[107].Value = 1;
			Adapter.DeleteCommand.Parameters[108].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[107].Value = 0;
			Adapter.DeleteCommand.Parameters[108].Value = Original_OverallPerformanceLO;
		}
		if (Original_OverallPerformance100 == null)
		{
			Adapter.DeleteCommand.Parameters[109].Value = 1;
			Adapter.DeleteCommand.Parameters[110].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[109].Value = 0;
			Adapter.DeleteCommand.Parameters[110].Value = Original_OverallPerformance100;
		}
		if (Original_TeacherRemarksAIOnly == null)
		{
			Adapter.DeleteCommand.Parameters[111].Value = 1;
			Adapter.DeleteCommand.Parameters[112].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[111].Value = 0;
			Adapter.DeleteCommand.Parameters[112].Value = Original_TeacherRemarksAIOnly;
		}
		if (Original_CategoryAIOnly == null)
		{
			Adapter.DeleteCommand.Parameters[113].Value = 1;
			Adapter.DeleteCommand.Parameters[114].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[113].Value = 0;
			Adapter.DeleteCommand.Parameters[114].Value = Original_CategoryAIOnly;
		}
		if (Original_SIC.HasValue)
		{
			Adapter.DeleteCommand.Parameters[115].Value = 0;
			Adapter.DeleteCommand.Parameters[116].Value = Original_SIC.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[115].Value = 1;
			Adapter.DeleteCommand.Parameters[116].Value = DBNull.Value;
		}
		if (Original_SIS.HasValue)
		{
			Adapter.DeleteCommand.Parameters[117].Value = 0;
			Adapter.DeleteCommand.Parameters[118].Value = Original_SIS.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[117].Value = 1;
			Adapter.DeleteCommand.Parameters[118].Value = DBNull.Value;
		}
		if (Original_SubjectRank.HasValue)
		{
			Adapter.DeleteCommand.Parameters[119].Value = 0;
			Adapter.DeleteCommand.Parameters[120].Value = Original_SubjectRank.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[119].Value = 1;
			Adapter.DeleteCommand.Parameters[120].Value = DBNull.Value;
		}
		if (Original_GrandAvg.HasValue)
		{
			Adapter.DeleteCommand.Parameters[121].Value = 0;
			Adapter.DeleteCommand.Parameters[122].Value = Original_GrandAvg.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[121].Value = 1;
			Adapter.DeleteCommand.Parameters[122].Value = DBNull.Value;
		}
		if (Original_SubPosLO.HasValue)
		{
			Adapter.DeleteCommand.Parameters[123].Value = 0;
			Adapter.DeleteCommand.Parameters[124].Value = Original_SubPosLO.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[123].Value = 1;
			Adapter.DeleteCommand.Parameters[124].Value = DBNull.Value;
		}
		if (Original_SubPosEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[125].Value = 0;
			Adapter.DeleteCommand.Parameters[126].Value = Original_SubPosEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[125].Value = 1;
			Adapter.DeleteCommand.Parameters[126].Value = DBNull.Value;
		}
		if (Original_SubPosLOEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[127].Value = 0;
			Adapter.DeleteCommand.Parameters[128].Value = Original_SubPosLOEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[127].Value = 1;
			Adapter.DeleteCommand.Parameters[128].Value = DBNull.Value;
		}
		if (Original_ClassteacherRemarkFA == null)
		{
			Adapter.DeleteCommand.Parameters[129].Value = 1;
			Adapter.DeleteCommand.Parameters[130].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[129].Value = 0;
			Adapter.DeleteCommand.Parameters[130].Value = Original_ClassteacherRemarkFA;
		}
		if (Original_HeadteacherRemarkFA == null)
		{
			Adapter.DeleteCommand.Parameters[131].Value = 1;
			Adapter.DeleteCommand.Parameters[132].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[131].Value = 0;
			Adapter.DeleteCommand.Parameters[132].Value = Original_HeadteacherRemarkFA;
		}
		if (Original_GenericSkills == null)
		{
			Adapter.DeleteCommand.Parameters[133].Value = 1;
			Adapter.DeleteCommand.Parameters[134].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[133].Value = 0;
			Adapter.DeleteCommand.Parameters[134].Value = Original_GenericSkills;
		}
		if (Original_PICLO.HasValue)
		{
			Adapter.DeleteCommand.Parameters[135].Value = 0;
			Adapter.DeleteCommand.Parameters[136].Value = Original_PICLO.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[135].Value = 1;
			Adapter.DeleteCommand.Parameters[136].Value = DBNull.Value;
		}
		if (Original_PISLO.HasValue)
		{
			Adapter.DeleteCommand.Parameters[137].Value = 0;
			Adapter.DeleteCommand.Parameters[138].Value = Original_PISLO.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[137].Value = 1;
			Adapter.DeleteCommand.Parameters[138].Value = DBNull.Value;
		}
		if (Original_PICLOEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[139].Value = 0;
			Adapter.DeleteCommand.Parameters[140].Value = Original_PICLOEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[139].Value = 1;
			Adapter.DeleteCommand.Parameters[140].Value = DBNull.Value;
		}
		if (Original_PICEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[141].Value = 0;
			Adapter.DeleteCommand.Parameters[142].Value = Original_PICEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[141].Value = 1;
			Adapter.DeleteCommand.Parameters[142].Value = DBNull.Value;
		}
		if (Original_PISLOEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[143].Value = 0;
			Adapter.DeleteCommand.Parameters[144].Value = Original_PISLOEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[143].Value = 1;
			Adapter.DeleteCommand.Parameters[144].Value = DBNull.Value;
		}
		if (Original_PISEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[145].Value = 0;
			Adapter.DeleteCommand.Parameters[146].Value = Original_PISEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[145].Value = 1;
			Adapter.DeleteCommand.Parameters[146].Value = DBNull.Value;
		}
		if (Original_TotalStudents.HasValue)
		{
			Adapter.DeleteCommand.Parameters[147].Value = 0;
			Adapter.DeleteCommand.Parameters[148].Value = Original_TotalStudents.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[147].Value = 1;
			Adapter.DeleteCommand.Parameters[148].Value = DBNull.Value;
		}
		if (Original_GrandAvgLO.HasValue)
		{
			Adapter.DeleteCommand.Parameters[149].Value = 0;
			Adapter.DeleteCommand.Parameters[150].Value = Original_GrandAvgLO.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[149].Value = 1;
			Adapter.DeleteCommand.Parameters[150].Value = DBNull.Value;
		}
		if (Original_GrandAvgEOT.HasValue)
		{
			Adapter.DeleteCommand.Parameters[151].Value = 0;
			Adapter.DeleteCommand.Parameters[152].Value = Original_GrandAvgEOT.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[151].Value = 1;
			Adapter.DeleteCommand.Parameters[152].Value = DBNull.Value;
		}
		if (Original_P7 == null)
		{
			Adapter.DeleteCommand.Parameters[153].Value = 1;
			Adapter.DeleteCommand.Parameters[154].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[153].Value = 0;
			Adapter.DeleteCommand.Parameters[154].Value = Original_P7;
		}
		if (Original_Score4 == null)
		{
			Adapter.DeleteCommand.Parameters[155].Value = 1;
			Adapter.DeleteCommand.Parameters[156].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[155].Value = 0;
			Adapter.DeleteCommand.Parameters[156].Value = Original_Score4;
		}
		if (Original_Hund1 == null)
		{
			Adapter.DeleteCommand.Parameters[157].Value = 1;
			Adapter.DeleteCommand.Parameters[158].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[157].Value = 0;
			Adapter.DeleteCommand.Parameters[158].Value = Original_Hund1;
		}
		if (Original_Hund2 == null)
		{
			Adapter.DeleteCommand.Parameters[159].Value = 1;
			Adapter.DeleteCommand.Parameters[160].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[159].Value = 0;
			Adapter.DeleteCommand.Parameters[160].Value = Original_Hund2;
		}
		if (Original_Hund3 == null)
		{
			Adapter.DeleteCommand.Parameters[161].Value = 1;
			Adapter.DeleteCommand.Parameters[162].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[161].Value = 0;
			Adapter.DeleteCommand.Parameters[162].Value = Original_Hund3;
		}
		if (Original_Hund4 == null)
		{
			Adapter.DeleteCommand.Parameters[163].Value = 1;
			Adapter.DeleteCommand.Parameters[164].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[163].Value = 0;
			Adapter.DeleteCommand.Parameters[164].Value = Original_Hund4;
		}
		if (Original_Hund5 == null)
		{
			Adapter.DeleteCommand.Parameters[165].Value = 1;
			Adapter.DeleteCommand.Parameters[166].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[165].Value = 0;
			Adapter.DeleteCommand.Parameters[166].Value = Original_Hund5;
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
	public virtual int Insert(string StudentNumber, string SemesterId, string SubjectId, string ClassId, string U1, string U2, string U3, string U4, string U5, string T1, string T2, string T3, string T4, string T5, string Score1, string Score2, string Score3, string Expr1, string Score5, int? TUnits, string Initial, int? Grade, string Category, string ETA, double? ETAv, string Comment, double? ETA80, double? AvMark, double? AvLO, int? Identifier, string EOTRemark, string P1, string P2, string P3, string P4, string P5, string P6, int? Identifier100, string TeacherRemarks, string ClassteacherRemark, string HeadteacherRemark, double? OutOfTwenty, double? OutOfTen, string Descriptor100, double? Score100, string OverallPerformance, string OtherRequirements, double? ProjAv, double? ProjLO, int? ProjIdentify, string ProjRemark, string ClassTeacherProject, string HeadTeacherProject, string OverallPerformanceLO, string OverallPerformance100, string TeacherRemarksAIOnly, string CategoryAIOnly, int? SIC, int? SIS, int? SubjectRank, double? GrandAvg, int? SubPosLO, int? SubPosEOT, int? SubPosLOEOT, string ClassteacherRemarkFA, string HeadteacherRemarkFA, string GenericSkills, int? PICLO, int? PISLO, int? PICLOEOT, int? PICEOT, int? PISLOEOT, int? PISEOT, int? TotalStudents, double? GrandAvgLO, double? GrandAvgEOT, string P7, string Score4, string Hund1, string Hund2, string Hund3, string Hund4, string Hund5)
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
		if (U1 == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = U1;
		}
		if (U2 == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = U2;
		}
		if (U3 == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = U3;
		}
		if (U4 == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = U4;
		}
		if (U5 == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = U5;
		}
		if (T1 == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = T1;
		}
		if (T2 == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = T2;
		}
		if (T3 == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = T3;
		}
		if (T4 == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = T4;
		}
		if (T5 == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = T5;
		}
		if (Score1 == null)
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = Score1;
		}
		if (Score2 == null)
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = Score2;
		}
		if (Score3 == null)
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = Score3;
		}
		if (Expr1 == null)
		{
			throw new ArgumentNullException("Expr1");
		}
		Adapter.InsertCommand.Parameters[17].Value = Expr1;
		if (Score5 == null)
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = Score5;
		}
		if (TUnits.HasValue)
		{
			Adapter.InsertCommand.Parameters[19].Value = TUnits.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		if (Initial == null)
		{
			Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[20].Value = Initial;
		}
		if (Grade.HasValue)
		{
			Adapter.InsertCommand.Parameters[21].Value = Grade.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[21].Value = DBNull.Value;
		}
		if (Category == null)
		{
			Adapter.InsertCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[22].Value = Category;
		}
		if (ETA == null)
		{
			Adapter.InsertCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[23].Value = ETA;
		}
		if (ETAv.HasValue)
		{
			Adapter.InsertCommand.Parameters[24].Value = ETAv.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[24].Value = DBNull.Value;
		}
		if (Comment == null)
		{
			Adapter.InsertCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[25].Value = Comment;
		}
		if (ETA80.HasValue)
		{
			Adapter.InsertCommand.Parameters[26].Value = ETA80.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[26].Value = DBNull.Value;
		}
		if (AvMark.HasValue)
		{
			Adapter.InsertCommand.Parameters[27].Value = AvMark.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[27].Value = DBNull.Value;
		}
		if (AvLO.HasValue)
		{
			Adapter.InsertCommand.Parameters[28].Value = AvLO.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[28].Value = DBNull.Value;
		}
		if (Identifier.HasValue)
		{
			Adapter.InsertCommand.Parameters[29].Value = Identifier.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[29].Value = DBNull.Value;
		}
		if (EOTRemark == null)
		{
			Adapter.InsertCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[30].Value = EOTRemark;
		}
		if (P1 == null)
		{
			Adapter.InsertCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[31].Value = P1;
		}
		if (P2 == null)
		{
			Adapter.InsertCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[32].Value = P2;
		}
		if (P3 == null)
		{
			Adapter.InsertCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[33].Value = P3;
		}
		if (P4 == null)
		{
			Adapter.InsertCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[34].Value = P4;
		}
		if (P5 == null)
		{
			Adapter.InsertCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[35].Value = P5;
		}
		if (P6 == null)
		{
			Adapter.InsertCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[36].Value = P6;
		}
		if (Identifier100.HasValue)
		{
			Adapter.InsertCommand.Parameters[37].Value = Identifier100.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[37].Value = DBNull.Value;
		}
		if (TeacherRemarks == null)
		{
			Adapter.InsertCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[38].Value = TeacherRemarks;
		}
		if (ClassteacherRemark == null)
		{
			Adapter.InsertCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[39].Value = ClassteacherRemark;
		}
		if (HeadteacherRemark == null)
		{
			Adapter.InsertCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[40].Value = HeadteacherRemark;
		}
		if (OutOfTwenty.HasValue)
		{
			Adapter.InsertCommand.Parameters[41].Value = OutOfTwenty.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[41].Value = DBNull.Value;
		}
		if (OutOfTen.HasValue)
		{
			Adapter.InsertCommand.Parameters[42].Value = OutOfTen.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[42].Value = DBNull.Value;
		}
		if (Descriptor100 == null)
		{
			Adapter.InsertCommand.Parameters[43].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[43].Value = Descriptor100;
		}
		if (Score100.HasValue)
		{
			Adapter.InsertCommand.Parameters[44].Value = Score100.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[44].Value = DBNull.Value;
		}
		if (OverallPerformance == null)
		{
			Adapter.InsertCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[45].Value = OverallPerformance;
		}
		if (OtherRequirements == null)
		{
			Adapter.InsertCommand.Parameters[46].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[46].Value = OtherRequirements;
		}
		if (ProjAv.HasValue)
		{
			Adapter.InsertCommand.Parameters[47].Value = ProjAv.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[47].Value = DBNull.Value;
		}
		if (ProjLO.HasValue)
		{
			Adapter.InsertCommand.Parameters[48].Value = ProjLO.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[48].Value = DBNull.Value;
		}
		if (ProjIdentify.HasValue)
		{
			Adapter.InsertCommand.Parameters[49].Value = ProjIdentify.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[49].Value = DBNull.Value;
		}
		if (ProjRemark == null)
		{
			Adapter.InsertCommand.Parameters[50].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[50].Value = ProjRemark;
		}
		if (ClassTeacherProject == null)
		{
			Adapter.InsertCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[51].Value = ClassTeacherProject;
		}
		if (HeadTeacherProject == null)
		{
			Adapter.InsertCommand.Parameters[52].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[52].Value = HeadTeacherProject;
		}
		if (OverallPerformanceLO == null)
		{
			Adapter.InsertCommand.Parameters[53].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[53].Value = OverallPerformanceLO;
		}
		if (OverallPerformance100 == null)
		{
			Adapter.InsertCommand.Parameters[54].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[54].Value = OverallPerformance100;
		}
		if (TeacherRemarksAIOnly == null)
		{
			Adapter.InsertCommand.Parameters[55].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[55].Value = TeacherRemarksAIOnly;
		}
		if (CategoryAIOnly == null)
		{
			Adapter.InsertCommand.Parameters[56].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[56].Value = CategoryAIOnly;
		}
		if (SIC.HasValue)
		{
			Adapter.InsertCommand.Parameters[57].Value = SIC.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[57].Value = DBNull.Value;
		}
		if (SIS.HasValue)
		{
			Adapter.InsertCommand.Parameters[58].Value = SIS.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[58].Value = DBNull.Value;
		}
		if (SubjectRank.HasValue)
		{
			Adapter.InsertCommand.Parameters[59].Value = SubjectRank.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[59].Value = DBNull.Value;
		}
		if (GrandAvg.HasValue)
		{
			Adapter.InsertCommand.Parameters[60].Value = GrandAvg.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[60].Value = DBNull.Value;
		}
		if (SubPosLO.HasValue)
		{
			Adapter.InsertCommand.Parameters[61].Value = SubPosLO.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[61].Value = DBNull.Value;
		}
		if (SubPosEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[62].Value = SubPosEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[62].Value = DBNull.Value;
		}
		if (SubPosLOEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[63].Value = SubPosLOEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[63].Value = DBNull.Value;
		}
		if (ClassteacherRemarkFA == null)
		{
			Adapter.InsertCommand.Parameters[64].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[64].Value = ClassteacherRemarkFA;
		}
		if (HeadteacherRemarkFA == null)
		{
			Adapter.InsertCommand.Parameters[65].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[65].Value = HeadteacherRemarkFA;
		}
		if (GenericSkills == null)
		{
			Adapter.InsertCommand.Parameters[66].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[66].Value = GenericSkills;
		}
		if (PICLO.HasValue)
		{
			Adapter.InsertCommand.Parameters[67].Value = PICLO.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[67].Value = DBNull.Value;
		}
		if (PISLO.HasValue)
		{
			Adapter.InsertCommand.Parameters[68].Value = PISLO.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[68].Value = DBNull.Value;
		}
		if (PICLOEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[69].Value = PICLOEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[69].Value = DBNull.Value;
		}
		if (PICEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[70].Value = PICEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[70].Value = DBNull.Value;
		}
		if (PISLOEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[71].Value = PISLOEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[71].Value = DBNull.Value;
		}
		if (PISEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[72].Value = PISEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[72].Value = DBNull.Value;
		}
		if (TotalStudents.HasValue)
		{
			Adapter.InsertCommand.Parameters[73].Value = TotalStudents.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[73].Value = DBNull.Value;
		}
		if (GrandAvgLO.HasValue)
		{
			Adapter.InsertCommand.Parameters[74].Value = GrandAvgLO.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[74].Value = DBNull.Value;
		}
		if (GrandAvgEOT.HasValue)
		{
			Adapter.InsertCommand.Parameters[75].Value = GrandAvgEOT.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[75].Value = DBNull.Value;
		}
		if (P7 == null)
		{
			Adapter.InsertCommand.Parameters[76].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[76].Value = P7;
		}
		if (Score4 == null)
		{
			Adapter.InsertCommand.Parameters[77].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[77].Value = Score4;
		}
		if (Hund1 == null)
		{
			Adapter.InsertCommand.Parameters[78].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[78].Value = Hund1;
		}
		if (Hund2 == null)
		{
			Adapter.InsertCommand.Parameters[79].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[79].Value = Hund2;
		}
		if (Hund3 == null)
		{
			Adapter.InsertCommand.Parameters[80].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[80].Value = Hund3;
		}
		if (Hund4 == null)
		{
			Adapter.InsertCommand.Parameters[81].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[81].Value = Hund4;
		}
		if (Hund5 == null)
		{
			Adapter.InsertCommand.Parameters[82].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[82].Value = Hund5;
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
	public virtual int Update(string StudentNumber, string SemesterId, string SubjectId, string ClassId, string U1, string U2, string U3, string U4, string U5, string T1, string T2, string T3, string T4, string T5, string Score1, string Score2, string Score3, string Expr1, string Score5, int? TUnits, string Initial, int? Grade, string Category, string ETA, double? ETAv, string Comment, double? ETA80, double? AvMark, double? AvLO, int? Identifier, string EOTRemark, string P1, string P2, string P3, string P4, string P5, string P6, int? Identifier100, string TeacherRemarks, string ClassteacherRemark, string HeadteacherRemark, double? OutOfTwenty, double? OutOfTen, string Descriptor100, double? Score100, string OverallPerformance, string OtherRequirements, double? ProjAv, double? ProjLO, int? ProjIdentify, string ProjRemark, string ClassTeacherProject, string HeadTeacherProject, string OverallPerformanceLO, string OverallPerformance100, string TeacherRemarksAIOnly, string CategoryAIOnly, int? SIC, int? SIS, int? SubjectRank, double? GrandAvg, int? SubPosLO, int? SubPosEOT, int? SubPosLOEOT, string ClassteacherRemarkFA, string HeadteacherRemarkFA, string GenericSkills, int? PICLO, int? PISLO, int? PICLOEOT, int? PICEOT, int? PISLOEOT, int? PISEOT, int? TotalStudents, double? GrandAvgLO, double? GrandAvgEOT, string P7, string Score4, string Hund1, string Hund2, string Hund3, string Hund4, string Hund5, long Original_Id, string Original_StudentNumber, string Original_SemesterId, string Original_SubjectId, string Original_ClassId, string Original_U1, string Original_U2, string Original_U3, string Original_U4, string Original_U5, string Original_T1, string Original_T2, string Original_T3, string Original_T4, string Original_T5, string Original_Score1, string Original_Score2, string Original_Score3, string Original_Expr1, string Original_Score5, int? Original_TUnits, string Original_Initial, int? Original_Grade, string Original_Category, string Original_ETA, double? Original_ETAv, string Original_Comment, double? Original_ETA80, double? Original_AvMark, double? Original_AvLO, int? Original_Identifier, string Original_EOTRemark, string Original_P1, string Original_P2, string Original_P3, string Original_P4, string Original_P5, string Original_P6, int? Original_Identifier100, string Original_TeacherRemarks, string Original_ClassteacherRemark, string Original_HeadteacherRemark, double? Original_OutOfTwenty, double? Original_OutOfTen, string Original_Descriptor100, double? Original_Score100, string Original_OverallPerformance, string Original_OtherRequirements, double? Original_ProjAv, double? Original_ProjLO, int? Original_ProjIdentify, string Original_ProjRemark, string Original_ClassTeacherProject, string Original_HeadTeacherProject, string Original_OverallPerformanceLO, string Original_OverallPerformance100, string Original_TeacherRemarksAIOnly, string Original_CategoryAIOnly, int? Original_SIC, int? Original_SIS, int? Original_SubjectRank, double? Original_GrandAvg, int? Original_SubPosLO, int? Original_SubPosEOT, int? Original_SubPosLOEOT, string Original_ClassteacherRemarkFA, string Original_HeadteacherRemarkFA, string Original_GenericSkills, int? Original_PICLO, int? Original_PISLO, int? Original_PICLOEOT, int? Original_PICEOT, int? Original_PISLOEOT, int? Original_PISEOT, int? Original_TotalStudents, double? Original_GrandAvgLO, double? Original_GrandAvgEOT, string Original_P7, string Original_Score4, string Original_Hund1, string Original_Hund2, string Original_Hund3, string Original_Hund4, string Original_Hund5, long Id)
	{
		if (StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		}
		if (SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = SemesterId;
		}
		if (SubjectId == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = SubjectId;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = ClassId;
		}
		if (U1 == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = U1;
		}
		if (U2 == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = U2;
		}
		if (U3 == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = U3;
		}
		if (U4 == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = U4;
		}
		if (U5 == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = U5;
		}
		if (T1 == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = T1;
		}
		if (T2 == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = T2;
		}
		if (T3 == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = T3;
		}
		if (T4 == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = T4;
		}
		if (T5 == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = T5;
		}
		if (Score1 == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = Score1;
		}
		if (Score2 == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = Score2;
		}
		if (Score3 == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = Score3;
		}
		if (Expr1 == null)
		{
			throw new ArgumentNullException("Expr1");
		}
		Adapter.UpdateCommand.Parameters[17].Value = Expr1;
		if (Score5 == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = Score5;
		}
		if (TUnits.HasValue)
		{
			Adapter.UpdateCommand.Parameters[19].Value = TUnits.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		if (Initial == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = Initial;
		}
		if (Grade.HasValue)
		{
			Adapter.UpdateCommand.Parameters[21].Value = Grade.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		if (Category == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = Category;
		}
		if (ETA == null)
		{
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[23].Value = ETA;
		}
		if (ETAv.HasValue)
		{
			Adapter.UpdateCommand.Parameters[24].Value = ETAv.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = DBNull.Value;
		}
		if (Comment == null)
		{
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[25].Value = Comment;
		}
		if (ETA80.HasValue)
		{
			Adapter.UpdateCommand.Parameters[26].Value = ETA80.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = DBNull.Value;
		}
		if (AvMark.HasValue)
		{
			Adapter.UpdateCommand.Parameters[27].Value = AvMark.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		if (AvLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[28].Value = AvLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = DBNull.Value;
		}
		if (Identifier.HasValue)
		{
			Adapter.UpdateCommand.Parameters[29].Value = Identifier.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		if (EOTRemark == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = EOTRemark;
		}
		if (P1 == null)
		{
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[31].Value = P1;
		}
		if (P2 == null)
		{
			Adapter.UpdateCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = P2;
		}
		if (P3 == null)
		{
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[33].Value = P3;
		}
		if (P4 == null)
		{
			Adapter.UpdateCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = P4;
		}
		if (P5 == null)
		{
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[35].Value = P5;
		}
		if (P6 == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = P6;
		}
		if (Identifier100.HasValue)
		{
			Adapter.UpdateCommand.Parameters[37].Value = Identifier100.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		if (TeacherRemarks == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = TeacherRemarks;
		}
		if (ClassteacherRemark == null)
		{
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[39].Value = ClassteacherRemark;
		}
		if (HeadteacherRemark == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = HeadteacherRemark;
		}
		if (OutOfTwenty.HasValue)
		{
			Adapter.UpdateCommand.Parameters[41].Value = OutOfTwenty.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		if (OutOfTen.HasValue)
		{
			Adapter.UpdateCommand.Parameters[42].Value = OutOfTen.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = DBNull.Value;
		}
		if (Descriptor100 == null)
		{
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[43].Value = Descriptor100;
		}
		if (Score100.HasValue)
		{
			Adapter.UpdateCommand.Parameters[44].Value = Score100.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = DBNull.Value;
		}
		if (OverallPerformance == null)
		{
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[45].Value = OverallPerformance;
		}
		if (OtherRequirements == null)
		{
			Adapter.UpdateCommand.Parameters[46].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = OtherRequirements;
		}
		if (ProjAv.HasValue)
		{
			Adapter.UpdateCommand.Parameters[47].Value = ProjAv.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		if (ProjLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[48].Value = ProjLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = DBNull.Value;
		}
		if (ProjIdentify.HasValue)
		{
			Adapter.UpdateCommand.Parameters[49].Value = ProjIdentify.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		if (ProjRemark == null)
		{
			Adapter.UpdateCommand.Parameters[50].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = ProjRemark;
		}
		if (ClassTeacherProject == null)
		{
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[51].Value = ClassTeacherProject;
		}
		if (HeadTeacherProject == null)
		{
			Adapter.UpdateCommand.Parameters[52].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[52].Value = HeadTeacherProject;
		}
		if (OverallPerformanceLO == null)
		{
			Adapter.UpdateCommand.Parameters[53].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[53].Value = OverallPerformanceLO;
		}
		if (OverallPerformance100 == null)
		{
			Adapter.UpdateCommand.Parameters[54].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[54].Value = OverallPerformance100;
		}
		if (TeacherRemarksAIOnly == null)
		{
			Adapter.UpdateCommand.Parameters[55].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[55].Value = TeacherRemarksAIOnly;
		}
		if (CategoryAIOnly == null)
		{
			Adapter.UpdateCommand.Parameters[56].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[56].Value = CategoryAIOnly;
		}
		if (SIC.HasValue)
		{
			Adapter.UpdateCommand.Parameters[57].Value = SIC.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[57].Value = DBNull.Value;
		}
		if (SIS.HasValue)
		{
			Adapter.UpdateCommand.Parameters[58].Value = SIS.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[58].Value = DBNull.Value;
		}
		if (SubjectRank.HasValue)
		{
			Adapter.UpdateCommand.Parameters[59].Value = SubjectRank.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[59].Value = DBNull.Value;
		}
		if (GrandAvg.HasValue)
		{
			Adapter.UpdateCommand.Parameters[60].Value = GrandAvg.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[60].Value = DBNull.Value;
		}
		if (SubPosLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[61].Value = SubPosLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[61].Value = DBNull.Value;
		}
		if (SubPosEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[62].Value = SubPosEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[62].Value = DBNull.Value;
		}
		if (SubPosLOEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[63].Value = SubPosLOEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[63].Value = DBNull.Value;
		}
		if (ClassteacherRemarkFA == null)
		{
			Adapter.UpdateCommand.Parameters[64].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[64].Value = ClassteacherRemarkFA;
		}
		if (HeadteacherRemarkFA == null)
		{
			Adapter.UpdateCommand.Parameters[65].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[65].Value = HeadteacherRemarkFA;
		}
		if (GenericSkills == null)
		{
			Adapter.UpdateCommand.Parameters[66].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[66].Value = GenericSkills;
		}
		if (PICLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[67].Value = PICLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[67].Value = DBNull.Value;
		}
		if (PISLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[68].Value = PISLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[68].Value = DBNull.Value;
		}
		if (PICLOEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[69].Value = PICLOEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[69].Value = DBNull.Value;
		}
		if (PICEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[70].Value = PICEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[70].Value = DBNull.Value;
		}
		if (PISLOEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[71].Value = PISLOEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[71].Value = DBNull.Value;
		}
		if (PISEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[72].Value = PISEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[72].Value = DBNull.Value;
		}
		if (TotalStudents.HasValue)
		{
			Adapter.UpdateCommand.Parameters[73].Value = TotalStudents.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[73].Value = DBNull.Value;
		}
		if (GrandAvgLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[74].Value = GrandAvgLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[74].Value = DBNull.Value;
		}
		if (GrandAvgEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[75].Value = GrandAvgEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[75].Value = DBNull.Value;
		}
		if (P7 == null)
		{
			Adapter.UpdateCommand.Parameters[76].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[76].Value = P7;
		}
		if (Score4 == null)
		{
			Adapter.UpdateCommand.Parameters[77].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[77].Value = Score4;
		}
		if (Hund1 == null)
		{
			Adapter.UpdateCommand.Parameters[78].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[78].Value = Hund1;
		}
		if (Hund2 == null)
		{
			Adapter.UpdateCommand.Parameters[79].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[79].Value = Hund2;
		}
		if (Hund3 == null)
		{
			Adapter.UpdateCommand.Parameters[80].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[80].Value = Hund3;
		}
		if (Hund4 == null)
		{
			Adapter.UpdateCommand.Parameters[81].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[81].Value = Hund4;
		}
		if (Hund5 == null)
		{
			Adapter.UpdateCommand.Parameters[82].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[82].Value = Hund5;
		}
		Adapter.UpdateCommand.Parameters[83].Value = Original_Id;
		if (Original_StudentNumber == null)
		{
			Adapter.UpdateCommand.Parameters[84].Value = 1;
			Adapter.UpdateCommand.Parameters[85].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[84].Value = 0;
			Adapter.UpdateCommand.Parameters[85].Value = Original_StudentNumber;
		}
		if (Original_SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[86].Value = 1;
			Adapter.UpdateCommand.Parameters[87].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[86].Value = 0;
			Adapter.UpdateCommand.Parameters[87].Value = Original_SemesterId;
		}
		if (Original_SubjectId == null)
		{
			Adapter.UpdateCommand.Parameters[88].Value = 1;
			Adapter.UpdateCommand.Parameters[89].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[88].Value = 0;
			Adapter.UpdateCommand.Parameters[89].Value = Original_SubjectId;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[90].Value = 1;
			Adapter.UpdateCommand.Parameters[91].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[90].Value = 0;
			Adapter.UpdateCommand.Parameters[91].Value = Original_ClassId;
		}
		if (Original_U1 == null)
		{
			Adapter.UpdateCommand.Parameters[92].Value = 1;
			Adapter.UpdateCommand.Parameters[93].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[92].Value = 0;
			Adapter.UpdateCommand.Parameters[93].Value = Original_U1;
		}
		if (Original_U2 == null)
		{
			Adapter.UpdateCommand.Parameters[94].Value = 1;
			Adapter.UpdateCommand.Parameters[95].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[94].Value = 0;
			Adapter.UpdateCommand.Parameters[95].Value = Original_U2;
		}
		if (Original_U3 == null)
		{
			Adapter.UpdateCommand.Parameters[96].Value = 1;
			Adapter.UpdateCommand.Parameters[97].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[96].Value = 0;
			Adapter.UpdateCommand.Parameters[97].Value = Original_U3;
		}
		if (Original_U4 == null)
		{
			Adapter.UpdateCommand.Parameters[98].Value = 1;
			Adapter.UpdateCommand.Parameters[99].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[98].Value = 0;
			Adapter.UpdateCommand.Parameters[99].Value = Original_U4;
		}
		if (Original_U5 == null)
		{
			Adapter.UpdateCommand.Parameters[100].Value = 1;
			Adapter.UpdateCommand.Parameters[101].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[100].Value = 0;
			Adapter.UpdateCommand.Parameters[101].Value = Original_U5;
		}
		if (Original_T1 == null)
		{
			Adapter.UpdateCommand.Parameters[102].Value = 1;
			Adapter.UpdateCommand.Parameters[103].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[102].Value = 0;
			Adapter.UpdateCommand.Parameters[103].Value = Original_T1;
		}
		if (Original_T2 == null)
		{
			Adapter.UpdateCommand.Parameters[104].Value = 1;
			Adapter.UpdateCommand.Parameters[105].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[104].Value = 0;
			Adapter.UpdateCommand.Parameters[105].Value = Original_T2;
		}
		if (Original_T3 == null)
		{
			Adapter.UpdateCommand.Parameters[106].Value = 1;
			Adapter.UpdateCommand.Parameters[107].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[106].Value = 0;
			Adapter.UpdateCommand.Parameters[107].Value = Original_T3;
		}
		if (Original_T4 == null)
		{
			Adapter.UpdateCommand.Parameters[108].Value = 1;
			Adapter.UpdateCommand.Parameters[109].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[108].Value = 0;
			Adapter.UpdateCommand.Parameters[109].Value = Original_T4;
		}
		if (Original_T5 == null)
		{
			Adapter.UpdateCommand.Parameters[110].Value = 1;
			Adapter.UpdateCommand.Parameters[111].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[110].Value = 0;
			Adapter.UpdateCommand.Parameters[111].Value = Original_T5;
		}
		if (Original_Score1 == null)
		{
			Adapter.UpdateCommand.Parameters[112].Value = 1;
			Adapter.UpdateCommand.Parameters[113].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[112].Value = 0;
			Adapter.UpdateCommand.Parameters[113].Value = Original_Score1;
		}
		if (Original_Score2 == null)
		{
			Adapter.UpdateCommand.Parameters[114].Value = 1;
			Adapter.UpdateCommand.Parameters[115].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[114].Value = 0;
			Adapter.UpdateCommand.Parameters[115].Value = Original_Score2;
		}
		if (Original_Score3 == null)
		{
			Adapter.UpdateCommand.Parameters[116].Value = 1;
			Adapter.UpdateCommand.Parameters[117].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[116].Value = 0;
			Adapter.UpdateCommand.Parameters[117].Value = Original_Score3;
		}
		if (Original_Expr1 == null)
		{
			throw new ArgumentNullException("Original_Expr1");
		}
		Adapter.UpdateCommand.Parameters[118].Value = 0;
		Adapter.UpdateCommand.Parameters[119].Value = Original_Expr1;
		if (Original_Score5 == null)
		{
			Adapter.UpdateCommand.Parameters[120].Value = 1;
			Adapter.UpdateCommand.Parameters[121].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[120].Value = 0;
			Adapter.UpdateCommand.Parameters[121].Value = Original_Score5;
		}
		if (Original_TUnits.HasValue)
		{
			Adapter.UpdateCommand.Parameters[122].Value = 0;
			Adapter.UpdateCommand.Parameters[123].Value = Original_TUnits.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[122].Value = 1;
			Adapter.UpdateCommand.Parameters[123].Value = DBNull.Value;
		}
		if (Original_Initial == null)
		{
			Adapter.UpdateCommand.Parameters[124].Value = 1;
			Adapter.UpdateCommand.Parameters[125].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[124].Value = 0;
			Adapter.UpdateCommand.Parameters[125].Value = Original_Initial;
		}
		if (Original_Grade.HasValue)
		{
			Adapter.UpdateCommand.Parameters[126].Value = 0;
			Adapter.UpdateCommand.Parameters[127].Value = Original_Grade.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[126].Value = 1;
			Adapter.UpdateCommand.Parameters[127].Value = DBNull.Value;
		}
		if (Original_Category == null)
		{
			Adapter.UpdateCommand.Parameters[128].Value = 1;
			Adapter.UpdateCommand.Parameters[129].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[128].Value = 0;
			Adapter.UpdateCommand.Parameters[129].Value = Original_Category;
		}
		if (Original_ETA == null)
		{
			Adapter.UpdateCommand.Parameters[130].Value = 1;
			Adapter.UpdateCommand.Parameters[131].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[130].Value = 0;
			Adapter.UpdateCommand.Parameters[131].Value = Original_ETA;
		}
		if (Original_ETAv.HasValue)
		{
			Adapter.UpdateCommand.Parameters[132].Value = 0;
			Adapter.UpdateCommand.Parameters[133].Value = Original_ETAv.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[132].Value = 1;
			Adapter.UpdateCommand.Parameters[133].Value = DBNull.Value;
		}
		if (Original_Comment == null)
		{
			Adapter.UpdateCommand.Parameters[134].Value = 1;
			Adapter.UpdateCommand.Parameters[135].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[134].Value = 0;
			Adapter.UpdateCommand.Parameters[135].Value = Original_Comment;
		}
		if (Original_ETA80.HasValue)
		{
			Adapter.UpdateCommand.Parameters[136].Value = 0;
			Adapter.UpdateCommand.Parameters[137].Value = Original_ETA80.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[136].Value = 1;
			Adapter.UpdateCommand.Parameters[137].Value = DBNull.Value;
		}
		if (Original_AvMark.HasValue)
		{
			Adapter.UpdateCommand.Parameters[138].Value = 0;
			Adapter.UpdateCommand.Parameters[139].Value = Original_AvMark.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[138].Value = 1;
			Adapter.UpdateCommand.Parameters[139].Value = DBNull.Value;
		}
		if (Original_AvLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[140].Value = 0;
			Adapter.UpdateCommand.Parameters[141].Value = Original_AvLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[140].Value = 1;
			Adapter.UpdateCommand.Parameters[141].Value = DBNull.Value;
		}
		if (Original_Identifier.HasValue)
		{
			Adapter.UpdateCommand.Parameters[142].Value = 0;
			Adapter.UpdateCommand.Parameters[143].Value = Original_Identifier.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[142].Value = 1;
			Adapter.UpdateCommand.Parameters[143].Value = DBNull.Value;
		}
		if (Original_EOTRemark == null)
		{
			Adapter.UpdateCommand.Parameters[144].Value = 1;
			Adapter.UpdateCommand.Parameters[145].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[144].Value = 0;
			Adapter.UpdateCommand.Parameters[145].Value = Original_EOTRemark;
		}
		if (Original_P1 == null)
		{
			Adapter.UpdateCommand.Parameters[146].Value = 1;
			Adapter.UpdateCommand.Parameters[147].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[146].Value = 0;
			Adapter.UpdateCommand.Parameters[147].Value = Original_P1;
		}
		if (Original_P2 == null)
		{
			Adapter.UpdateCommand.Parameters[148].Value = 1;
			Adapter.UpdateCommand.Parameters[149].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[148].Value = 0;
			Adapter.UpdateCommand.Parameters[149].Value = Original_P2;
		}
		if (Original_P3 == null)
		{
			Adapter.UpdateCommand.Parameters[150].Value = 1;
			Adapter.UpdateCommand.Parameters[151].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[150].Value = 0;
			Adapter.UpdateCommand.Parameters[151].Value = Original_P3;
		}
		if (Original_P4 == null)
		{
			Adapter.UpdateCommand.Parameters[152].Value = 1;
			Adapter.UpdateCommand.Parameters[153].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[152].Value = 0;
			Adapter.UpdateCommand.Parameters[153].Value = Original_P4;
		}
		if (Original_P5 == null)
		{
			Adapter.UpdateCommand.Parameters[154].Value = 1;
			Adapter.UpdateCommand.Parameters[155].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[154].Value = 0;
			Adapter.UpdateCommand.Parameters[155].Value = Original_P5;
		}
		if (Original_P6 == null)
		{
			Adapter.UpdateCommand.Parameters[156].Value = 1;
			Adapter.UpdateCommand.Parameters[157].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[156].Value = 0;
			Adapter.UpdateCommand.Parameters[157].Value = Original_P6;
		}
		if (Original_Identifier100.HasValue)
		{
			Adapter.UpdateCommand.Parameters[158].Value = 0;
			Adapter.UpdateCommand.Parameters[159].Value = Original_Identifier100.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[158].Value = 1;
			Adapter.UpdateCommand.Parameters[159].Value = DBNull.Value;
		}
		if (Original_TeacherRemarks == null)
		{
			Adapter.UpdateCommand.Parameters[160].Value = 1;
			Adapter.UpdateCommand.Parameters[161].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[160].Value = 0;
			Adapter.UpdateCommand.Parameters[161].Value = Original_TeacherRemarks;
		}
		if (Original_ClassteacherRemark == null)
		{
			Adapter.UpdateCommand.Parameters[162].Value = 1;
			Adapter.UpdateCommand.Parameters[163].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[162].Value = 0;
			Adapter.UpdateCommand.Parameters[163].Value = Original_ClassteacherRemark;
		}
		if (Original_HeadteacherRemark == null)
		{
			Adapter.UpdateCommand.Parameters[164].Value = 1;
			Adapter.UpdateCommand.Parameters[165].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[164].Value = 0;
			Adapter.UpdateCommand.Parameters[165].Value = Original_HeadteacherRemark;
		}
		if (Original_OutOfTwenty.HasValue)
		{
			Adapter.UpdateCommand.Parameters[166].Value = 0;
			Adapter.UpdateCommand.Parameters[167].Value = Original_OutOfTwenty.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[166].Value = 1;
			Adapter.UpdateCommand.Parameters[167].Value = DBNull.Value;
		}
		if (Original_OutOfTen.HasValue)
		{
			Adapter.UpdateCommand.Parameters[168].Value = 0;
			Adapter.UpdateCommand.Parameters[169].Value = Original_OutOfTen.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[168].Value = 1;
			Adapter.UpdateCommand.Parameters[169].Value = DBNull.Value;
		}
		if (Original_Descriptor100 == null)
		{
			Adapter.UpdateCommand.Parameters[170].Value = 1;
			Adapter.UpdateCommand.Parameters[171].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[170].Value = 0;
			Adapter.UpdateCommand.Parameters[171].Value = Original_Descriptor100;
		}
		if (Original_Score100.HasValue)
		{
			Adapter.UpdateCommand.Parameters[172].Value = 0;
			Adapter.UpdateCommand.Parameters[173].Value = Original_Score100.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[172].Value = 1;
			Adapter.UpdateCommand.Parameters[173].Value = DBNull.Value;
		}
		if (Original_OverallPerformance == null)
		{
			Adapter.UpdateCommand.Parameters[174].Value = 1;
			Adapter.UpdateCommand.Parameters[175].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[174].Value = 0;
			Adapter.UpdateCommand.Parameters[175].Value = Original_OverallPerformance;
		}
		if (Original_OtherRequirements == null)
		{
			Adapter.UpdateCommand.Parameters[176].Value = 1;
			Adapter.UpdateCommand.Parameters[177].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[176].Value = 0;
			Adapter.UpdateCommand.Parameters[177].Value = Original_OtherRequirements;
		}
		if (Original_ProjAv.HasValue)
		{
			Adapter.UpdateCommand.Parameters[178].Value = 0;
			Adapter.UpdateCommand.Parameters[179].Value = Original_ProjAv.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[178].Value = 1;
			Adapter.UpdateCommand.Parameters[179].Value = DBNull.Value;
		}
		if (Original_ProjLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[180].Value = 0;
			Adapter.UpdateCommand.Parameters[181].Value = Original_ProjLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[180].Value = 1;
			Adapter.UpdateCommand.Parameters[181].Value = DBNull.Value;
		}
		if (Original_ProjIdentify.HasValue)
		{
			Adapter.UpdateCommand.Parameters[182].Value = 0;
			Adapter.UpdateCommand.Parameters[183].Value = Original_ProjIdentify.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[182].Value = 1;
			Adapter.UpdateCommand.Parameters[183].Value = DBNull.Value;
		}
		if (Original_ProjRemark == null)
		{
			Adapter.UpdateCommand.Parameters[184].Value = 1;
			Adapter.UpdateCommand.Parameters[185].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[184].Value = 0;
			Adapter.UpdateCommand.Parameters[185].Value = Original_ProjRemark;
		}
		if (Original_ClassTeacherProject == null)
		{
			Adapter.UpdateCommand.Parameters[186].Value = 1;
			Adapter.UpdateCommand.Parameters[187].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[186].Value = 0;
			Adapter.UpdateCommand.Parameters[187].Value = Original_ClassTeacherProject;
		}
		if (Original_HeadTeacherProject == null)
		{
			Adapter.UpdateCommand.Parameters[188].Value = 1;
			Adapter.UpdateCommand.Parameters[189].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[188].Value = 0;
			Adapter.UpdateCommand.Parameters[189].Value = Original_HeadTeacherProject;
		}
		if (Original_OverallPerformanceLO == null)
		{
			Adapter.UpdateCommand.Parameters[190].Value = 1;
			Adapter.UpdateCommand.Parameters[191].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[190].Value = 0;
			Adapter.UpdateCommand.Parameters[191].Value = Original_OverallPerformanceLO;
		}
		if (Original_OverallPerformance100 == null)
		{
			Adapter.UpdateCommand.Parameters[192].Value = 1;
			Adapter.UpdateCommand.Parameters[193].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[192].Value = 0;
			Adapter.UpdateCommand.Parameters[193].Value = Original_OverallPerformance100;
		}
		if (Original_TeacherRemarksAIOnly == null)
		{
			Adapter.UpdateCommand.Parameters[194].Value = 1;
			Adapter.UpdateCommand.Parameters[195].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[194].Value = 0;
			Adapter.UpdateCommand.Parameters[195].Value = Original_TeacherRemarksAIOnly;
		}
		if (Original_CategoryAIOnly == null)
		{
			Adapter.UpdateCommand.Parameters[196].Value = 1;
			Adapter.UpdateCommand.Parameters[197].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[196].Value = 0;
			Adapter.UpdateCommand.Parameters[197].Value = Original_CategoryAIOnly;
		}
		if (Original_SIC.HasValue)
		{
			Adapter.UpdateCommand.Parameters[198].Value = 0;
			Adapter.UpdateCommand.Parameters[199].Value = Original_SIC.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[198].Value = 1;
			Adapter.UpdateCommand.Parameters[199].Value = DBNull.Value;
		}
		if (Original_SIS.HasValue)
		{
			Adapter.UpdateCommand.Parameters[200].Value = 0;
			Adapter.UpdateCommand.Parameters[201].Value = Original_SIS.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[200].Value = 1;
			Adapter.UpdateCommand.Parameters[201].Value = DBNull.Value;
		}
		if (Original_SubjectRank.HasValue)
		{
			Adapter.UpdateCommand.Parameters[202].Value = 0;
			Adapter.UpdateCommand.Parameters[203].Value = Original_SubjectRank.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[202].Value = 1;
			Adapter.UpdateCommand.Parameters[203].Value = DBNull.Value;
		}
		if (Original_GrandAvg.HasValue)
		{
			Adapter.UpdateCommand.Parameters[204].Value = 0;
			Adapter.UpdateCommand.Parameters[205].Value = Original_GrandAvg.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[204].Value = 1;
			Adapter.UpdateCommand.Parameters[205].Value = DBNull.Value;
		}
		if (Original_SubPosLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[206].Value = 0;
			Adapter.UpdateCommand.Parameters[207].Value = Original_SubPosLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[206].Value = 1;
			Adapter.UpdateCommand.Parameters[207].Value = DBNull.Value;
		}
		if (Original_SubPosEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[208].Value = 0;
			Adapter.UpdateCommand.Parameters[209].Value = Original_SubPosEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[208].Value = 1;
			Adapter.UpdateCommand.Parameters[209].Value = DBNull.Value;
		}
		if (Original_SubPosLOEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[210].Value = 0;
			Adapter.UpdateCommand.Parameters[211].Value = Original_SubPosLOEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[210].Value = 1;
			Adapter.UpdateCommand.Parameters[211].Value = DBNull.Value;
		}
		if (Original_ClassteacherRemarkFA == null)
		{
			Adapter.UpdateCommand.Parameters[212].Value = 1;
			Adapter.UpdateCommand.Parameters[213].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[212].Value = 0;
			Adapter.UpdateCommand.Parameters[213].Value = Original_ClassteacherRemarkFA;
		}
		if (Original_HeadteacherRemarkFA == null)
		{
			Adapter.UpdateCommand.Parameters[214].Value = 1;
			Adapter.UpdateCommand.Parameters[215].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[214].Value = 0;
			Adapter.UpdateCommand.Parameters[215].Value = Original_HeadteacherRemarkFA;
		}
		if (Original_GenericSkills == null)
		{
			Adapter.UpdateCommand.Parameters[216].Value = 1;
			Adapter.UpdateCommand.Parameters[217].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[216].Value = 0;
			Adapter.UpdateCommand.Parameters[217].Value = Original_GenericSkills;
		}
		if (Original_PICLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[218].Value = 0;
			Adapter.UpdateCommand.Parameters[219].Value = Original_PICLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[218].Value = 1;
			Adapter.UpdateCommand.Parameters[219].Value = DBNull.Value;
		}
		if (Original_PISLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[220].Value = 0;
			Adapter.UpdateCommand.Parameters[221].Value = Original_PISLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[220].Value = 1;
			Adapter.UpdateCommand.Parameters[221].Value = DBNull.Value;
		}
		if (Original_PICLOEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[222].Value = 0;
			Adapter.UpdateCommand.Parameters[223].Value = Original_PICLOEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[222].Value = 1;
			Adapter.UpdateCommand.Parameters[223].Value = DBNull.Value;
		}
		if (Original_PICEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[224].Value = 0;
			Adapter.UpdateCommand.Parameters[225].Value = Original_PICEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[224].Value = 1;
			Adapter.UpdateCommand.Parameters[225].Value = DBNull.Value;
		}
		if (Original_PISLOEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[226].Value = 0;
			Adapter.UpdateCommand.Parameters[227].Value = Original_PISLOEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[226].Value = 1;
			Adapter.UpdateCommand.Parameters[227].Value = DBNull.Value;
		}
		if (Original_PISEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[228].Value = 0;
			Adapter.UpdateCommand.Parameters[229].Value = Original_PISEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[228].Value = 1;
			Adapter.UpdateCommand.Parameters[229].Value = DBNull.Value;
		}
		if (Original_TotalStudents.HasValue)
		{
			Adapter.UpdateCommand.Parameters[230].Value = 0;
			Adapter.UpdateCommand.Parameters[231].Value = Original_TotalStudents.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[230].Value = 1;
			Adapter.UpdateCommand.Parameters[231].Value = DBNull.Value;
		}
		if (Original_GrandAvgLO.HasValue)
		{
			Adapter.UpdateCommand.Parameters[232].Value = 0;
			Adapter.UpdateCommand.Parameters[233].Value = Original_GrandAvgLO.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[232].Value = 1;
			Adapter.UpdateCommand.Parameters[233].Value = DBNull.Value;
		}
		if (Original_GrandAvgEOT.HasValue)
		{
			Adapter.UpdateCommand.Parameters[234].Value = 0;
			Adapter.UpdateCommand.Parameters[235].Value = Original_GrandAvgEOT.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[234].Value = 1;
			Adapter.UpdateCommand.Parameters[235].Value = DBNull.Value;
		}
		if (Original_P7 == null)
		{
			Adapter.UpdateCommand.Parameters[236].Value = 1;
			Adapter.UpdateCommand.Parameters[237].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[236].Value = 0;
			Adapter.UpdateCommand.Parameters[237].Value = Original_P7;
		}
		if (Original_Score4 == null)
		{
			Adapter.UpdateCommand.Parameters[238].Value = 1;
			Adapter.UpdateCommand.Parameters[239].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[238].Value = 0;
			Adapter.UpdateCommand.Parameters[239].Value = Original_Score4;
		}
		if (Original_Hund1 == null)
		{
			Adapter.UpdateCommand.Parameters[240].Value = 1;
			Adapter.UpdateCommand.Parameters[241].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[240].Value = 0;
			Adapter.UpdateCommand.Parameters[241].Value = Original_Hund1;
		}
		if (Original_Hund2 == null)
		{
			Adapter.UpdateCommand.Parameters[242].Value = 1;
			Adapter.UpdateCommand.Parameters[243].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[242].Value = 0;
			Adapter.UpdateCommand.Parameters[243].Value = Original_Hund2;
		}
		if (Original_Hund3 == null)
		{
			Adapter.UpdateCommand.Parameters[244].Value = 1;
			Adapter.UpdateCommand.Parameters[245].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[244].Value = 0;
			Adapter.UpdateCommand.Parameters[245].Value = Original_Hund3;
		}
		if (Original_Hund4 == null)
		{
			Adapter.UpdateCommand.Parameters[246].Value = 1;
			Adapter.UpdateCommand.Parameters[247].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[246].Value = 0;
			Adapter.UpdateCommand.Parameters[247].Value = Original_Hund4;
		}
		if (Original_Hund5 == null)
		{
			Adapter.UpdateCommand.Parameters[248].Value = 1;
			Adapter.UpdateCommand.Parameters[249].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[248].Value = 0;
			Adapter.UpdateCommand.Parameters[249].Value = Original_Hund5;
		}
		Adapter.UpdateCommand.Parameters[250].Value = Id;
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
	public virtual int Update(string StudentNumber, string SemesterId, string SubjectId, string ClassId, string U1, string U2, string U3, string U4, string U5, string T1, string T2, string T3, string T4, string T5, string Score1, string Score2, string Score3, string Expr1, string Score5, int? TUnits, string Initial, int? Grade, string Category, string ETA, double? ETAv, string Comment, double? ETA80, double? AvMark, double? AvLO, int? Identifier, string EOTRemark, string P1, string P2, string P3, string P4, string P5, string P6, int? Identifier100, string TeacherRemarks, string ClassteacherRemark, string HeadteacherRemark, double? OutOfTwenty, double? OutOfTen, string Descriptor100, double? Score100, string OverallPerformance, string OtherRequirements, double? ProjAv, double? ProjLO, int? ProjIdentify, string ProjRemark, string ClassTeacherProject, string HeadTeacherProject, string OverallPerformanceLO, string OverallPerformance100, string TeacherRemarksAIOnly, string CategoryAIOnly, int? SIC, int? SIS, int? SubjectRank, double? GrandAvg, int? SubPosLO, int? SubPosEOT, int? SubPosLOEOT, string ClassteacherRemarkFA, string HeadteacherRemarkFA, string GenericSkills, int? PICLO, int? PISLO, int? PICLOEOT, int? PICEOT, int? PISLOEOT, int? PISEOT, int? TotalStudents, double? GrandAvgLO, double? GrandAvgEOT, string P7, string Score4, string Hund1, string Hund2, string Hund3, string Hund4, string Hund5, long Original_Id, string Original_StudentNumber, string Original_SemesterId, string Original_SubjectId, string Original_ClassId, string Original_U1, string Original_U2, string Original_U3, string Original_U4, string Original_U5, string Original_T1, string Original_T2, string Original_T3, string Original_T4, string Original_T5, string Original_Score1, string Original_Score2, string Original_Score3, string Original_Expr1, string Original_Score5, int? Original_TUnits, string Original_Initial, int? Original_Grade, string Original_Category, string Original_ETA, double? Original_ETAv, string Original_Comment, double? Original_ETA80, double? Original_AvMark, double? Original_AvLO, int? Original_Identifier, string Original_EOTRemark, string Original_P1, string Original_P2, string Original_P3, string Original_P4, string Original_P5, string Original_P6, int? Original_Identifier100, string Original_TeacherRemarks, string Original_ClassteacherRemark, string Original_HeadteacherRemark, double? Original_OutOfTwenty, double? Original_OutOfTen, string Original_Descriptor100, double? Original_Score100, string Original_OverallPerformance, string Original_OtherRequirements, double? Original_ProjAv, double? Original_ProjLO, int? Original_ProjIdentify, string Original_ProjRemark, string Original_ClassTeacherProject, string Original_HeadTeacherProject, string Original_OverallPerformanceLO, string Original_OverallPerformance100, string Original_TeacherRemarksAIOnly, string Original_CategoryAIOnly, int? Original_SIC, int? Original_SIS, int? Original_SubjectRank, double? Original_GrandAvg, int? Original_SubPosLO, int? Original_SubPosEOT, int? Original_SubPosLOEOT, string Original_ClassteacherRemarkFA, string Original_HeadteacherRemarkFA, string Original_GenericSkills, int? Original_PICLO, int? Original_PISLO, int? Original_PICLOEOT, int? Original_PICEOT, int? Original_PISLOEOT, int? Original_PISEOT, int? Original_TotalStudents, double? Original_GrandAvgLO, double? Original_GrandAvgEOT, string Original_P7, string Original_Score4, string Original_Hund1, string Original_Hund2, string Original_Hund3, string Original_Hund4, string Original_Hund5)
	{
		return Update(StudentNumber, SemesterId, SubjectId, ClassId, U1, U2, U3, U4, U5, T1, T2, T3, T4, T5, Score1, Score2, Score3, Expr1, Score5, TUnits, Initial, Grade, Category, ETA, ETAv, Comment, ETA80, AvMark, AvLO, Identifier, EOTRemark, P1, P2, P3, P4, P5, P6, Identifier100, TeacherRemarks, ClassteacherRemark, HeadteacherRemark, OutOfTwenty, OutOfTen, Descriptor100, Score100, OverallPerformance, OtherRequirements, ProjAv, ProjLO, ProjIdentify, ProjRemark, ClassTeacherProject, HeadTeacherProject, OverallPerformanceLO, OverallPerformance100, TeacherRemarksAIOnly, CategoryAIOnly, SIC, SIS, SubjectRank, GrandAvg, SubPosLO, SubPosEOT, SubPosLOEOT, ClassteacherRemarkFA, HeadteacherRemarkFA, GenericSkills, PICLO, PISLO, PICLOEOT, PICEOT, PISLOEOT, PISEOT, TotalStudents, GrandAvgLO, GrandAvgEOT, P7, Score4, Hund1, Hund2, Hund3, Hund4, Hund5, Original_Id, Original_StudentNumber, Original_SemesterId, Original_SubjectId, Original_ClassId, Original_U1, Original_U2, Original_U3, Original_U4, Original_U5, Original_T1, Original_T2, Original_T3, Original_T4, Original_T5, Original_Score1, Original_Score2, Original_Score3, Original_Expr1, Original_Score5, Original_TUnits, Original_Initial, Original_Grade, Original_Category, Original_ETA, Original_ETAv, Original_Comment, Original_ETA80, Original_AvMark, Original_AvLO, Original_Identifier, Original_EOTRemark, Original_P1, Original_P2, Original_P3, Original_P4, Original_P5, Original_P6, Original_Identifier100, Original_TeacherRemarks, Original_ClassteacherRemark, Original_HeadteacherRemark, Original_OutOfTwenty, Original_OutOfTen, Original_Descriptor100, Original_Score100, Original_OverallPerformance, Original_OtherRequirements, Original_ProjAv, Original_ProjLO, Original_ProjIdentify, Original_ProjRemark, Original_ClassTeacherProject, Original_HeadTeacherProject, Original_OverallPerformanceLO, Original_OverallPerformance100, Original_TeacherRemarksAIOnly, Original_CategoryAIOnly, Original_SIC, Original_SIS, Original_SubjectRank, Original_GrandAvg, Original_SubPosLO, Original_SubPosEOT, Original_SubPosLOEOT, Original_ClassteacherRemarkFA, Original_HeadteacherRemarkFA, Original_GenericSkills, Original_PICLO, Original_PISLO, Original_PICLOEOT, Original_PICEOT, Original_PISLOEOT, Original_PISEOT, Original_TotalStudents, Original_GrandAvgLO, Original_GrandAvgEOT, Original_P7, Original_Score4, Original_Hund1, Original_Hund2, Original_Hund3, Original_Hund4, Original_Hund5, Original_Id);
	}
}
