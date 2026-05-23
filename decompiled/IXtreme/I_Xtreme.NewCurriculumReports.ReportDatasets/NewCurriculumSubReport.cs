using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace I_Xtreme.NewCurriculumReports.ReportDatasets;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("NewCurriculumSubReport")]
[HelpKeyword("vs.data.DataSet")]
public class NewCurriculumSubReport : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void tbl_Scores_OL_ReportRowChangeEventHandler(object sender, tbl_Scores_OL_ReportRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class tbl_Scores_OL_ReportDataTable : TypedTableBase<tbl_Scores_OL_ReportRow>
	{
		private DataColumn columnId;

		private DataColumn columnStudentNumber;

		private DataColumn columnSemesterId;

		private DataColumn columnSubjectId;

		private DataColumn columnClassId;

		private DataColumn columnU1;

		private DataColumn columnU2;

		private DataColumn columnU3;

		private DataColumn columnU4;

		private DataColumn columnU5;

		private DataColumn columnT1;

		private DataColumn columnT2;

		private DataColumn columnT3;

		private DataColumn columnT4;

		private DataColumn columnT5;

		private DataColumn columnScore1;

		private DataColumn columnScore2;

		private DataColumn columnScore3;

		private DataColumn columnExpr1;

		private DataColumn columnScore5;

		private DataColumn columnTUnits;

		private DataColumn columnInitial;

		private DataColumn columnGrade;

		private DataColumn columnCategory;

		private DataColumn columnETA;

		private DataColumn columnETAv;

		private DataColumn columnComment;

		private DataColumn columnETA80;

		private DataColumn columnAvMark;

		private DataColumn columnAvLO;

		private DataColumn columnIdentifier;

		private DataColumn columnEOTRemark;

		private DataColumn columnP1;

		private DataColumn columnP2;

		private DataColumn columnP3;

		private DataColumn columnP4;

		private DataColumn columnP5;

		private DataColumn columnP6;

		private DataColumn columnIdentifier100;

		private DataColumn columnTeacherRemarks;

		private DataColumn columnClassteacherRemark;

		private DataColumn columnHeadteacherRemark;

		private DataColumn columnOutOfTwenty;

		private DataColumn columnOutOfTen;

		private DataColumn columnDescriptor100;

		private DataColumn columnScore100;

		private DataColumn columnOverallPerformance;

		private DataColumn columnOtherRequirements;

		private DataColumn columnProjAv;

		private DataColumn columnProjLO;

		private DataColumn columnProjIdentify;

		private DataColumn columnProjRemark;

		private DataColumn columnClassTeacherProject;

		private DataColumn columnHeadTeacherProject;

		private DataColumn columnOverallPerformanceLO;

		private DataColumn columnOverallPerformance100;

		private DataColumn columnTeacherRemarksAIOnly;

		private DataColumn columnCategoryAIOnly;

		private DataColumn columnSIC;

		private DataColumn columnSIS;

		private DataColumn columnSubjectRank;

		private DataColumn columnGrandAvg;

		private DataColumn columnSubPosLO;

		private DataColumn columnSubPosEOT;

		private DataColumn columnSubPosLOEOT;

		private DataColumn columnClassteacherRemarkFA;

		private DataColumn columnHeadteacherRemarkFA;

		private DataColumn columnGenericSkills;

		private DataColumn columnPICLO;

		private DataColumn columnPISLO;

		private DataColumn columnPICLOEOT;

		private DataColumn columnPICEOT;

		private DataColumn columnPISLOEOT;

		private DataColumn columnPISEOT;

		private DataColumn columnTotalStudents;

		private DataColumn columnGrandAvgLO;

		private DataColumn columnGrandAvgEOT;

		private DataColumn columnP7;

		private DataColumn columnScore4;

		private DataColumn columnHund1;

		private DataColumn columnHund2;

		private DataColumn columnHund3;

		private DataColumn columnHund4;

		private DataColumn columnHund5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SemesterIdColumn => columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectIdColumn => columnSubjectId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdColumn => columnClassId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn U1Column => columnU1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn U2Column => columnU2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn U3Column => columnU3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn U4Column => columnU4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn U5Column => columnU5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn T1Column => columnT1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn T2Column => columnT2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn T3Column => columnT3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn T4Column => columnT4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn T5Column => columnT5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Score1Column => columnScore1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Score2Column => columnScore2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Score3Column => columnScore3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Expr1Column => columnExpr1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Score5Column => columnScore5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TUnitsColumn => columnTUnits;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn InitialColumn => columnInitial;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GradeColumn => columnGrade;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CategoryColumn => columnCategory;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ETAColumn => columnETA;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ETAvColumn => columnETAv;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CommentColumn => columnComment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ETA80Column => columnETA80;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvMarkColumn => columnAvMark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvLOColumn => columnAvLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IdentifierColumn => columnIdentifier;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn EOTRemarkColumn => columnEOTRemark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P1Column => columnP1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P2Column => columnP2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P3Column => columnP3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P4Column => columnP4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P5Column => columnP5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P6Column => columnP6;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Identifier100Column => columnIdentifier100;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TeacherRemarksColumn => columnTeacherRemarks;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassteacherRemarkColumn => columnClassteacherRemark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HeadteacherRemarkColumn => columnHeadteacherRemark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OutOfTwentyColumn => columnOutOfTwenty;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OutOfTenColumn => columnOutOfTen;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Descriptor100Column => columnDescriptor100;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Score100Column => columnScore100;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OverallPerformanceColumn => columnOverallPerformance;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OtherRequirementsColumn => columnOtherRequirements;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ProjAvColumn => columnProjAv;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ProjLOColumn => columnProjLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ProjIdentifyColumn => columnProjIdentify;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ProjRemarkColumn => columnProjRemark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassTeacherProjectColumn => columnClassTeacherProject;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HeadTeacherProjectColumn => columnHeadTeacherProject;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OverallPerformanceLOColumn => columnOverallPerformanceLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OverallPerformance100Column => columnOverallPerformance100;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TeacherRemarksAIOnlyColumn => columnTeacherRemarksAIOnly;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CategoryAIOnlyColumn => columnCategoryAIOnly;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SICColumn => columnSIC;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SISColumn => columnSIS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectRankColumn => columnSubjectRank;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GrandAvgColumn => columnGrandAvg;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubPosLOColumn => columnSubPosLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubPosEOTColumn => columnSubPosEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubPosLOEOTColumn => columnSubPosLOEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassteacherRemarkFAColumn => columnClassteacherRemarkFA;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HeadteacherRemarkFAColumn => columnHeadteacherRemarkFA;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GenericSkillsColumn => columnGenericSkills;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PICLOColumn => columnPICLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PISLOColumn => columnPISLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PICLOEOTColumn => columnPICLOEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PICEOTColumn => columnPICEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PISLOEOTColumn => columnPISLOEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PISEOTColumn => columnPISEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TotalStudentsColumn => columnTotalStudents;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GrandAvgLOColumn => columnGrandAvgLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GrandAvgEOTColumn => columnGrandAvgEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P7Column => columnP7;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Score4Column => columnScore4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Hund1Column => columnHund1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Hund2Column => columnHund2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Hund3Column => columnHund3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Hund4Column => columnHund4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Hund5Column => columnHund5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportRow this[int index] => (tbl_Scores_OL_ReportRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportRowChangeEventHandler tbl_Scores_OL_ReportRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportRowChangeEventHandler tbl_Scores_OL_ReportRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportRowChangeEventHandler tbl_Scores_OL_ReportRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportRowChangeEventHandler tbl_Scores_OL_ReportRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportDataTable()
		{
			base.TableName = "tbl_Scores_OL_Report";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_Scores_OL_ReportDataTable(DataTable table)
		{
			base.TableName = table.TableName;
			if (table.CaseSensitive != table.DataSet.CaseSensitive)
			{
				base.CaseSensitive = table.CaseSensitive;
			}
			if (table.Locale.ToString() != table.DataSet.Locale.ToString())
			{
				base.Locale = table.Locale;
			}
			if (table.Namespace != table.DataSet.Namespace)
			{
				base.Namespace = table.Namespace;
			}
			base.Prefix = table.Prefix;
			base.MinimumCapacity = table.MinimumCapacity;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected tbl_Scores_OL_ReportDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Addtbl_Scores_OL_ReportRow(tbl_Scores_OL_ReportRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportRow Addtbl_Scores_OL_ReportRow(string StudentNumber, string SemesterId, string SubjectId, string ClassId, string U1, string U2, string U3, string U4, string U5, string T1, string T2, string T3, string T4, string T5, string Score1, string Score2, string Score3, string Expr1, string Score5, int TUnits, string Initial, int Grade, string Category, string ETA, double ETAv, string Comment, double ETA80, double AvMark, double AvLO, int Identifier, string EOTRemark, string P1, string P2, string P3, string P4, string P5, string P6, int Identifier100, string TeacherRemarks, string ClassteacherRemark, string HeadteacherRemark, double OutOfTwenty, double OutOfTen, string Descriptor100, double Score100, string OverallPerformance, string OtherRequirements, double ProjAv, double ProjLO, int ProjIdentify, string ProjRemark, string ClassTeacherProject, string HeadTeacherProject, string OverallPerformanceLO, string OverallPerformance100, string TeacherRemarksAIOnly, string CategoryAIOnly, int SIC, int SIS, int SubjectRank, double GrandAvg, int SubPosLO, int SubPosEOT, int SubPosLOEOT, string ClassteacherRemarkFA, string HeadteacherRemarkFA, string GenericSkills, int PICLO, int PISLO, int PICLOEOT, int PICEOT, int PISLOEOT, int PISEOT, int TotalStudents, double GrandAvgLO, double GrandAvgEOT, string P7, string Score4, string Hund1, string Hund2, string Hund3, string Hund4, string Hund5)
		{
			tbl_Scores_OL_ReportRow tbl_Scores_OL_ReportRow = (tbl_Scores_OL_ReportRow)NewRow();
			object[] itemArray = new object[84]
			{
				null, StudentNumber, SemesterId, SubjectId, ClassId, U1, U2, U3, U4, U5,
				T1, T2, T3, T4, T5, Score1, Score2, Score3, Expr1, Score5,
				TUnits, Initial, Grade, Category, ETA, ETAv, Comment, ETA80, AvMark, AvLO,
				Identifier, EOTRemark, P1, P2, P3, P4, P5, P6, Identifier100, TeacherRemarks,
				ClassteacherRemark, HeadteacherRemark, OutOfTwenty, OutOfTen, Descriptor100, Score100, OverallPerformance, OtherRequirements, ProjAv, ProjLO,
				ProjIdentify, ProjRemark, ClassTeacherProject, HeadTeacherProject, OverallPerformanceLO, OverallPerformance100, TeacherRemarksAIOnly, CategoryAIOnly, SIC, SIS,
				SubjectRank, GrandAvg, SubPosLO, SubPosEOT, SubPosLOEOT, ClassteacherRemarkFA, HeadteacherRemarkFA, GenericSkills, PICLO, PISLO,
				PICLOEOT, PICEOT, PISLOEOT, PISEOT, TotalStudents, GrandAvgLO, GrandAvgEOT, P7, Score4, Hund1,
				Hund2, Hund3, Hund4, Hund5
			};
			tbl_Scores_OL_ReportRow.ItemArray = itemArray;
			base.Rows.Add(tbl_Scores_OL_ReportRow);
			return tbl_Scores_OL_ReportRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportRow FindById(long Id)
		{
			return (tbl_Scores_OL_ReportRow)base.Rows.Find(new object[1] { Id });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			tbl_Scores_OL_ReportDataTable tbl_Scores_OL_ReportDataTable = (tbl_Scores_OL_ReportDataTable)base.Clone();
			tbl_Scores_OL_ReportDataTable.InitVars();
			return tbl_Scores_OL_ReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new tbl_Scores_OL_ReportDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnId = base.Columns["Id"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnSemesterId = base.Columns["SemesterId"];
			columnSubjectId = base.Columns["SubjectId"];
			columnClassId = base.Columns["ClassId"];
			columnU1 = base.Columns["U1"];
			columnU2 = base.Columns["U2"];
			columnU3 = base.Columns["U3"];
			columnU4 = base.Columns["U4"];
			columnU5 = base.Columns["U5"];
			columnT1 = base.Columns["T1"];
			columnT2 = base.Columns["T2"];
			columnT3 = base.Columns["T3"];
			columnT4 = base.Columns["T4"];
			columnT5 = base.Columns["T5"];
			columnScore1 = base.Columns["Score1"];
			columnScore2 = base.Columns["Score2"];
			columnScore3 = base.Columns["Score3"];
			columnExpr1 = base.Columns["Expr1"];
			columnScore5 = base.Columns["Score5"];
			columnTUnits = base.Columns["TUnits"];
			columnInitial = base.Columns["Initial"];
			columnGrade = base.Columns["Grade"];
			columnCategory = base.Columns["Category"];
			columnETA = base.Columns["ETA"];
			columnETAv = base.Columns["ETAv"];
			columnComment = base.Columns["Comment"];
			columnETA80 = base.Columns["ETA80"];
			columnAvMark = base.Columns["AvMark"];
			columnAvLO = base.Columns["AvLO"];
			columnIdentifier = base.Columns["Identifier"];
			columnEOTRemark = base.Columns["EOTRemark"];
			columnP1 = base.Columns["P1"];
			columnP2 = base.Columns["P2"];
			columnP3 = base.Columns["P3"];
			columnP4 = base.Columns["P4"];
			columnP5 = base.Columns["P5"];
			columnP6 = base.Columns["P6"];
			columnIdentifier100 = base.Columns["Identifier100"];
			columnTeacherRemarks = base.Columns["TeacherRemarks"];
			columnClassteacherRemark = base.Columns["ClassteacherRemark"];
			columnHeadteacherRemark = base.Columns["HeadteacherRemark"];
			columnOutOfTwenty = base.Columns["OutOfTwenty"];
			columnOutOfTen = base.Columns["OutOfTen"];
			columnDescriptor100 = base.Columns["Descriptor100"];
			columnScore100 = base.Columns["Score100"];
			columnOverallPerformance = base.Columns["OverallPerformance"];
			columnOtherRequirements = base.Columns["OtherRequirements"];
			columnProjAv = base.Columns["ProjAv"];
			columnProjLO = base.Columns["ProjLO"];
			columnProjIdentify = base.Columns["ProjIdentify"];
			columnProjRemark = base.Columns["ProjRemark"];
			columnClassTeacherProject = base.Columns["ClassTeacherProject"];
			columnHeadTeacherProject = base.Columns["HeadTeacherProject"];
			columnOverallPerformanceLO = base.Columns["OverallPerformanceLO"];
			columnOverallPerformance100 = base.Columns["OverallPerformance100"];
			columnTeacherRemarksAIOnly = base.Columns["TeacherRemarksAIOnly"];
			columnCategoryAIOnly = base.Columns["CategoryAIOnly"];
			columnSIC = base.Columns["SIC"];
			columnSIS = base.Columns["SIS"];
			columnSubjectRank = base.Columns["SubjectRank"];
			columnGrandAvg = base.Columns["GrandAvg"];
			columnSubPosLO = base.Columns["SubPosLO"];
			columnSubPosEOT = base.Columns["SubPosEOT"];
			columnSubPosLOEOT = base.Columns["SubPosLOEOT"];
			columnClassteacherRemarkFA = base.Columns["ClassteacherRemarkFA"];
			columnHeadteacherRemarkFA = base.Columns["HeadteacherRemarkFA"];
			columnGenericSkills = base.Columns["GenericSkills"];
			columnPICLO = base.Columns["PICLO"];
			columnPISLO = base.Columns["PISLO"];
			columnPICLOEOT = base.Columns["PICLOEOT"];
			columnPICEOT = base.Columns["PICEOT"];
			columnPISLOEOT = base.Columns["PISLOEOT"];
			columnPISEOT = base.Columns["PISEOT"];
			columnTotalStudents = base.Columns["TotalStudents"];
			columnGrandAvgLO = base.Columns["GrandAvgLO"];
			columnGrandAvgEOT = base.Columns["GrandAvgEOT"];
			columnP7 = base.Columns["P7"];
			columnScore4 = base.Columns["Score4"];
			columnHund1 = base.Columns["Hund1"];
			columnHund2 = base.Columns["Hund2"];
			columnHund3 = base.Columns["Hund3"];
			columnHund4 = base.Columns["Hund4"];
			columnHund5 = base.Columns["Hund5"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnSubjectId = new DataColumn("SubjectId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectId);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
			columnU1 = new DataColumn("U1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnU1);
			columnU2 = new DataColumn("U2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnU2);
			columnU3 = new DataColumn("U3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnU3);
			columnU4 = new DataColumn("U4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnU4);
			columnU5 = new DataColumn("U5", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnU5);
			columnT1 = new DataColumn("T1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnT1);
			columnT2 = new DataColumn("T2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnT2);
			columnT3 = new DataColumn("T3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnT3);
			columnT4 = new DataColumn("T4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnT4);
			columnT5 = new DataColumn("T5", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnT5);
			columnScore1 = new DataColumn("Score1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnScore1);
			columnScore2 = new DataColumn("Score2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnScore2);
			columnScore3 = new DataColumn("Score3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnScore3);
			columnExpr1 = new DataColumn("Expr1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExpr1);
			columnScore5 = new DataColumn("Score5", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnScore5);
			columnTUnits = new DataColumn("TUnits", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnTUnits);
			columnInitial = new DataColumn("Initial", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInitial);
			columnGrade = new DataColumn("Grade", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnGrade);
			columnCategory = new DataColumn("Category", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCategory);
			columnETA = new DataColumn("ETA", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnETA);
			columnETAv = new DataColumn("ETAv", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETAv);
			columnComment = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnComment);
			columnETA80 = new DataColumn("ETA80", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETA80);
			columnAvMark = new DataColumn("AvMark", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvMark);
			columnAvLO = new DataColumn("AvLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvLO);
			columnIdentifier = new DataColumn("Identifier", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnIdentifier);
			columnEOTRemark = new DataColumn("EOTRemark", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEOTRemark);
			columnP1 = new DataColumn("P1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP1);
			columnP2 = new DataColumn("P2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP2);
			columnP3 = new DataColumn("P3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP3);
			columnP4 = new DataColumn("P4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP4);
			columnP5 = new DataColumn("P5", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP5);
			columnP6 = new DataColumn("P6", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP6);
			columnIdentifier100 = new DataColumn("Identifier100", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnIdentifier100);
			columnTeacherRemarks = new DataColumn("TeacherRemarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTeacherRemarks);
			columnClassteacherRemark = new DataColumn("ClassteacherRemark", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassteacherRemark);
			columnHeadteacherRemark = new DataColumn("HeadteacherRemark", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeadteacherRemark);
			columnOutOfTwenty = new DataColumn("OutOfTwenty", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOutOfTwenty);
			columnOutOfTen = new DataColumn("OutOfTen", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnOutOfTen);
			columnDescriptor100 = new DataColumn("Descriptor100", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDescriptor100);
			columnScore100 = new DataColumn("Score100", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnScore100);
			columnOverallPerformance = new DataColumn("OverallPerformance", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOverallPerformance);
			columnOtherRequirements = new DataColumn("OtherRequirements", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOtherRequirements);
			columnProjAv = new DataColumn("ProjAv", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnProjAv);
			columnProjLO = new DataColumn("ProjLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnProjLO);
			columnProjIdentify = new DataColumn("ProjIdentify", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnProjIdentify);
			columnProjRemark = new DataColumn("ProjRemark", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnProjRemark);
			columnClassTeacherProject = new DataColumn("ClassTeacherProject", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassTeacherProject);
			columnHeadTeacherProject = new DataColumn("HeadTeacherProject", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeadTeacherProject);
			columnOverallPerformanceLO = new DataColumn("OverallPerformanceLO", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOverallPerformanceLO);
			columnOverallPerformance100 = new DataColumn("OverallPerformance100", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOverallPerformance100);
			columnTeacherRemarksAIOnly = new DataColumn("TeacherRemarksAIOnly", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTeacherRemarksAIOnly);
			columnCategoryAIOnly = new DataColumn("CategoryAIOnly", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCategoryAIOnly);
			columnSIC = new DataColumn("SIC", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSIC);
			columnSIS = new DataColumn("SIS", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSIS);
			columnSubjectRank = new DataColumn("SubjectRank", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSubjectRank);
			columnGrandAvg = new DataColumn("GrandAvg", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGrandAvg);
			columnSubPosLO = new DataColumn("SubPosLO", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSubPosLO);
			columnSubPosEOT = new DataColumn("SubPosEOT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSubPosEOT);
			columnSubPosLOEOT = new DataColumn("SubPosLOEOT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnSubPosLOEOT);
			columnClassteacherRemarkFA = new DataColumn("ClassteacherRemarkFA", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassteacherRemarkFA);
			columnHeadteacherRemarkFA = new DataColumn("HeadteacherRemarkFA", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeadteacherRemarkFA);
			columnGenericSkills = new DataColumn("GenericSkills", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGenericSkills);
			columnPICLO = new DataColumn("PICLO", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPICLO);
			columnPISLO = new DataColumn("PISLO", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPISLO);
			columnPICLOEOT = new DataColumn("PICLOEOT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPICLOEOT);
			columnPICEOT = new DataColumn("PICEOT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPICEOT);
			columnPISLOEOT = new DataColumn("PISLOEOT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPISLOEOT);
			columnPISEOT = new DataColumn("PISEOT", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPISEOT);
			columnTotalStudents = new DataColumn("TotalStudents", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnTotalStudents);
			columnGrandAvgLO = new DataColumn("GrandAvgLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGrandAvgLO);
			columnGrandAvgEOT = new DataColumn("GrandAvgEOT", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnGrandAvgEOT);
			columnP7 = new DataColumn("P7", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP7);
			columnScore4 = new DataColumn("Score4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnScore4);
			columnHund1 = new DataColumn("Hund1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHund1);
			columnHund2 = new DataColumn("Hund2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHund2);
			columnHund3 = new DataColumn("Hund3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHund3);
			columnHund4 = new DataColumn("Hund4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHund4);
			columnHund5 = new DataColumn("Hund5", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHund5);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnId }, isPrimaryKey: true));
			columnId.AutoIncrement = true;
			columnId.AutoIncrementSeed = -1L;
			columnId.AutoIncrementStep = -1L;
			columnId.AllowDBNull = false;
			columnId.ReadOnly = true;
			columnId.Unique = true;
			columnStudentNumber.MaxLength = 12;
			columnSemesterId.MaxLength = 12;
			columnSubjectId.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnU1.MaxLength = 3;
			columnU2.MaxLength = 3;
			columnU3.MaxLength = 3;
			columnU4.MaxLength = 3;
			columnU5.MaxLength = 3;
			columnT1.MaxLength = 4;
			columnT2.MaxLength = 4;
			columnT3.MaxLength = 4;
			columnT4.MaxLength = 4;
			columnT5.MaxLength = 4;
			columnScore1.MaxLength = 4;
			columnScore2.MaxLength = 4;
			columnScore3.MaxLength = 4;
			columnExpr1.MaxLength = 4;
			columnScore5.MaxLength = 4;
			columnInitial.MaxLength = 3;
			columnCategory.MaxLength = 2;
			columnETA.MaxLength = 3;
			columnComment.MaxLength = 80;
			columnEOTRemark.MaxLength = 80;
			columnP1.MaxLength = 4;
			columnP2.MaxLength = 4;
			columnP3.MaxLength = 4;
			columnP4.MaxLength = 100;
			columnP5.MaxLength = 4;
			columnP6.MaxLength = 500;
			columnTeacherRemarks.MaxLength = 200;
			columnClassteacherRemark.MaxLength = 200;
			columnHeadteacherRemark.MaxLength = 200;
			columnDescriptor100.MaxLength = 80;
			columnOverallPerformance.MaxLength = 50;
			columnOtherRequirements.MaxLength = 2000;
			columnProjRemark.MaxLength = 200;
			columnClassTeacherProject.MaxLength = 200;
			columnHeadTeacherProject.MaxLength = 200;
			columnOverallPerformanceLO.MaxLength = 50;
			columnOverallPerformance100.MaxLength = 50;
			columnTeacherRemarksAIOnly.MaxLength = 200;
			columnCategoryAIOnly.MaxLength = 3;
			columnClassteacherRemarkFA.MaxLength = 200;
			columnHeadteacherRemarkFA.MaxLength = 200;
			columnGenericSkills.MaxLength = 2000;
			columnP7.MaxLength = 4;
			columnScore4.MaxLength = 4;
			columnHund1.MaxLength = 3;
			columnHund2.MaxLength = 3;
			columnHund3.MaxLength = 3;
			columnHund4.MaxLength = 3;
			columnHund5.MaxLength = 3;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportRow Newtbl_Scores_OL_ReportRow()
		{
			return (tbl_Scores_OL_ReportRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new tbl_Scores_OL_ReportRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(tbl_Scores_OL_ReportRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.tbl_Scores_OL_ReportRowChanged != null)
			{
				this.tbl_Scores_OL_ReportRowChanged(this, new tbl_Scores_OL_ReportRowChangeEvent((tbl_Scores_OL_ReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.tbl_Scores_OL_ReportRowChanging != null)
			{
				this.tbl_Scores_OL_ReportRowChanging(this, new tbl_Scores_OL_ReportRowChangeEvent((tbl_Scores_OL_ReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.tbl_Scores_OL_ReportRowDeleted != null)
			{
				this.tbl_Scores_OL_ReportRowDeleted(this, new tbl_Scores_OL_ReportRowChangeEvent((tbl_Scores_OL_ReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.tbl_Scores_OL_ReportRowDeleting != null)
			{
				this.tbl_Scores_OL_ReportRowDeleting(this, new tbl_Scores_OL_ReportRowChangeEvent((tbl_Scores_OL_ReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Removetbl_Scores_OL_ReportRow(tbl_Scores_OL_ReportRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			NewCurriculumSubReport newCurriculumSubReport = new NewCurriculumSubReport();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
			xmlSchemaAny.Namespace = "http://www.w3.org/2001/XMLSchema";
			xmlSchemaAny.MinOccurs = 0m;
			xmlSchemaAny.MaxOccurs = decimal.MaxValue;
			xmlSchemaAny.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
			xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			xmlSchemaAny2.MinOccurs = 1m;
			xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
			xmlSchemaSequence.Items.Add(xmlSchemaAny2);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute();
			xmlSchemaAttribute.Name = "namespace";
			xmlSchemaAttribute.FixedValue = newCurriculumSubReport.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "tbl_Scores_OL_ReportDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = newCurriculumSubReport.GetSchemaSerializable();
			if (xs.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					XmlSchema xmlSchema = null;
					schemaSerializable.Write(memoryStream);
					IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
					while (enumerator.MoveNext())
					{
						xmlSchema = (XmlSchema)enumerator.Current;
						memoryStream2.SetLength(0L);
						xmlSchema.Write(memoryStream2);
						if (memoryStream.Length == memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							memoryStream2.Position = 0L;
							while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream2.ReadByte())
							{
							}
							if (memoryStream.Position == memoryStream.Length)
							{
								return xmlSchemaComplexType;
							}
						}
					}
				}
				finally
				{
					memoryStream?.Close();
					memoryStream2?.Close();
				}
			}
			xs.Add(schemaSerializable);
			return xmlSchemaComplexType;
		}
	}

	public class tbl_Scores_OL_ReportRow : DataRow
	{
		private tbl_Scores_OL_ReportDataTable tabletbl_Scores_OL_Report;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long Id
		{
			get
			{
				return (long)base[tabletbl_Scores_OL_Report.IdColumn];
			}
			set
			{
				base[tabletbl_Scores_OL_Report.IdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SemesterId
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SemesterIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SubjectId
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.SubjectIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectId' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SubjectIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassId
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ClassIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string U1
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.U1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'U1' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.U1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string U2
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.U2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'U2' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.U2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string U3
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.U3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'U3' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.U3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string U4
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.U4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'U4' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.U4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string U5
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.U5Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'U5' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.U5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string T1
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.T1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'T1' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.T1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string T2
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.T2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'T2' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.T2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string T3
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.T3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'T3' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.T3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string T4
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.T4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'T4' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.T4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string T5
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.T5Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'T5' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.T5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Score1
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Score1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Score1' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Score1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Score2
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Score2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Score2' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Score2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Score3
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Score3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Score3' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Score3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Expr1
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Expr1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Expr1' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Expr1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Score5
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Score5Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Score5' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Score5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int TUnits
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.TUnitsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TUnits' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.TUnitsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Initial
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.InitialColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Initial' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.InitialColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int Grade
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.GradeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Grade' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.GradeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Category
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.CategoryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Category' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.CategoryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ETA
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.ETAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETA' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ETAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double ETAv
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.ETAvColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETAv' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ETAvColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Comment
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.CommentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.CommentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double ETA80
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.ETA80Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETA80' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ETA80Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double AvMark
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.AvMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvMark' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.AvMarkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double AvLO
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.AvLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.AvLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int Identifier
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.IdentifierColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Identifier' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.IdentifierColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string EOTRemark
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.EOTRemarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EOTRemark' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.EOTRemarkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P1
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P1' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P2
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P2' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P3
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P3' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P4
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P4' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P5
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P5Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P5' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P6
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P6Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P6' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int Identifier100
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.Identifier100Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Identifier100' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Identifier100Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TeacherRemarks
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.TeacherRemarksColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TeacherRemarks' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.TeacherRemarksColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassteacherRemark
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.ClassteacherRemarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassteacherRemark' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ClassteacherRemarkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HeadteacherRemark
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.HeadteacherRemarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeadteacherRemark' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.HeadteacherRemarkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double OutOfTwenty
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.OutOfTwentyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OutOfTwenty' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.OutOfTwentyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double OutOfTen
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.OutOfTenColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OutOfTen' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.OutOfTenColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Descriptor100
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Descriptor100Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Descriptor100' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Descriptor100Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double Score100
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.Score100Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Score100' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Score100Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string OverallPerformance
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.OverallPerformanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OverallPerformance' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.OverallPerformanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string OtherRequirements
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.OtherRequirementsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherRequirements' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.OtherRequirementsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double ProjAv
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.ProjAvColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ProjAv' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ProjAvColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double ProjLO
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.ProjLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ProjLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ProjLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int ProjIdentify
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.ProjIdentifyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ProjIdentify' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ProjIdentifyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ProjRemark
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.ProjRemarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ProjRemark' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ProjRemarkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassTeacherProject
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.ClassTeacherProjectColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassTeacherProject' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ClassTeacherProjectColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HeadTeacherProject
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.HeadTeacherProjectColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeadTeacherProject' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.HeadTeacherProjectColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string OverallPerformanceLO
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.OverallPerformanceLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OverallPerformanceLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.OverallPerformanceLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string OverallPerformance100
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.OverallPerformance100Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OverallPerformance100' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.OverallPerformance100Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TeacherRemarksAIOnly
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.TeacherRemarksAIOnlyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TeacherRemarksAIOnly' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.TeacherRemarksAIOnlyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string CategoryAIOnly
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.CategoryAIOnlyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CategoryAIOnly' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.CategoryAIOnlyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int SIC
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.SICColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SIC' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SICColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int SIS
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.SISColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SIS' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SISColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int SubjectRank
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.SubjectRankColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectRank' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SubjectRankColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double GrandAvg
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.GrandAvgColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GrandAvg' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.GrandAvgColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int SubPosLO
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.SubPosLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubPosLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SubPosLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int SubPosEOT
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.SubPosEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubPosEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SubPosEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int SubPosLOEOT
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.SubPosLOEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubPosLOEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.SubPosLOEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassteacherRemarkFA
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.ClassteacherRemarkFAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassteacherRemarkFA' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.ClassteacherRemarkFAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HeadteacherRemarkFA
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.HeadteacherRemarkFAColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeadteacherRemarkFA' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.HeadteacherRemarkFAColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string GenericSkills
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.GenericSkillsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GenericSkills' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.GenericSkillsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PICLO
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.PICLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PICLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.PICLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PISLO
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.PISLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PISLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.PISLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PICLOEOT
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.PICLOEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PICLOEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.PICLOEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PICEOT
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.PICEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PICEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.PICEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PISLOEOT
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.PISLOEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PISLOEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.PISLOEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PISEOT
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.PISEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PISEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.PISEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int TotalStudents
		{
			get
			{
				try
				{
					return (int)base[tabletbl_Scores_OL_Report.TotalStudentsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotalStudents' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.TotalStudentsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double GrandAvgLO
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.GrandAvgLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GrandAvgLO' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.GrandAvgLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double GrandAvgEOT
		{
			get
			{
				try
				{
					return (double)base[tabletbl_Scores_OL_Report.GrandAvgEOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GrandAvgEOT' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.GrandAvgEOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string P7
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.P7Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P7' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.P7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Score4
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Score4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Score4' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Score4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Hund1
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Hund1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Hund1' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Hund1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Hund2
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Hund2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Hund2' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Hund2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Hund3
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Hund3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Hund3' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Hund3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Hund4
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Hund4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Hund4' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Hund4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Hund5
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_Report.Hund5Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Hund5' in table 'tbl_Scores_OL_Report' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_Report.Hund5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_Scores_OL_ReportRow(DataRowBuilder rb)
			: base(rb)
		{
			tabletbl_Scores_OL_Report = (tbl_Scores_OL_ReportDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tabletbl_Scores_OL_Report.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tabletbl_Scores_OL_Report.SemesterIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectIdNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SubjectIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectIdNull()
		{
			base[tabletbl_Scores_OL_Report.SubjectIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tabletbl_Scores_OL_Report.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsU1Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.U1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetU1Null()
		{
			base[tabletbl_Scores_OL_Report.U1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsU2Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.U2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetU2Null()
		{
			base[tabletbl_Scores_OL_Report.U2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsU3Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.U3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetU3Null()
		{
			base[tabletbl_Scores_OL_Report.U3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsU4Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.U4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetU4Null()
		{
			base[tabletbl_Scores_OL_Report.U4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsU5Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.U5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetU5Null()
		{
			base[tabletbl_Scores_OL_Report.U5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsT1Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.T1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetT1Null()
		{
			base[tabletbl_Scores_OL_Report.T1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsT2Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.T2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetT2Null()
		{
			base[tabletbl_Scores_OL_Report.T2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsT3Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.T3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetT3Null()
		{
			base[tabletbl_Scores_OL_Report.T3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsT4Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.T4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetT4Null()
		{
			base[tabletbl_Scores_OL_Report.T4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsT5Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.T5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetT5Null()
		{
			base[tabletbl_Scores_OL_Report.T5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsScore1Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Score1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetScore1Null()
		{
			base[tabletbl_Scores_OL_Report.Score1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsScore2Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Score2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetScore2Null()
		{
			base[tabletbl_Scores_OL_Report.Score2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsScore3Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Score3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetScore3Null()
		{
			base[tabletbl_Scores_OL_Report.Score3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsExpr1Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Expr1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetExpr1Null()
		{
			base[tabletbl_Scores_OL_Report.Expr1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsScore5Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Score5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetScore5Null()
		{
			base[tabletbl_Scores_OL_Report.Score5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTUnitsNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.TUnitsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTUnitsNull()
		{
			base[tabletbl_Scores_OL_Report.TUnitsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsInitialNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.InitialColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetInitialNull()
		{
			base[tabletbl_Scores_OL_Report.InitialColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGradeNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.GradeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGradeNull()
		{
			base[tabletbl_Scores_OL_Report.GradeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCategoryNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.CategoryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCategoryNull()
		{
			base[tabletbl_Scores_OL_Report.CategoryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsETANull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ETAColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetETANull()
		{
			base[tabletbl_Scores_OL_Report.ETAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsETAvNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ETAvColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetETAvNull()
		{
			base[tabletbl_Scores_OL_Report.ETAvColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCommentNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.CommentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCommentNull()
		{
			base[tabletbl_Scores_OL_Report.CommentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsETA80Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.ETA80Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetETA80Null()
		{
			base[tabletbl_Scores_OL_Report.ETA80Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvMarkNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.AvMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvMarkNull()
		{
			base[tabletbl_Scores_OL_Report.AvMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.AvLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvLONull()
		{
			base[tabletbl_Scores_OL_Report.AvLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsIdentifierNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.IdentifierColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetIdentifierNull()
		{
			base[tabletbl_Scores_OL_Report.IdentifierColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsEOTRemarkNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.EOTRemarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetEOTRemarkNull()
		{
			base[tabletbl_Scores_OL_Report.EOTRemarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP1Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP1Null()
		{
			base[tabletbl_Scores_OL_Report.P1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP2Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP2Null()
		{
			base[tabletbl_Scores_OL_Report.P2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP3Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP3Null()
		{
			base[tabletbl_Scores_OL_Report.P3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP4Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP4Null()
		{
			base[tabletbl_Scores_OL_Report.P4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP5Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP5Null()
		{
			base[tabletbl_Scores_OL_Report.P5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP6Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP6Null()
		{
			base[tabletbl_Scores_OL_Report.P6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsIdentifier100Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Identifier100Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetIdentifier100Null()
		{
			base[tabletbl_Scores_OL_Report.Identifier100Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTeacherRemarksNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.TeacherRemarksColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTeacherRemarksNull()
		{
			base[tabletbl_Scores_OL_Report.TeacherRemarksColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassteacherRemarkNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ClassteacherRemarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassteacherRemarkNull()
		{
			base[tabletbl_Scores_OL_Report.ClassteacherRemarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHeadteacherRemarkNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.HeadteacherRemarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHeadteacherRemarkNull()
		{
			base[tabletbl_Scores_OL_Report.HeadteacherRemarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOutOfTwentyNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.OutOfTwentyColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOutOfTwentyNull()
		{
			base[tabletbl_Scores_OL_Report.OutOfTwentyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOutOfTenNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.OutOfTenColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOutOfTenNull()
		{
			base[tabletbl_Scores_OL_Report.OutOfTenColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDescriptor100Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Descriptor100Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDescriptor100Null()
		{
			base[tabletbl_Scores_OL_Report.Descriptor100Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsScore100Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Score100Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetScore100Null()
		{
			base[tabletbl_Scores_OL_Report.Score100Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOverallPerformanceNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.OverallPerformanceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOverallPerformanceNull()
		{
			base[tabletbl_Scores_OL_Report.OverallPerformanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOtherRequirementsNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.OtherRequirementsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOtherRequirementsNull()
		{
			base[tabletbl_Scores_OL_Report.OtherRequirementsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsProjAvNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ProjAvColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetProjAvNull()
		{
			base[tabletbl_Scores_OL_Report.ProjAvColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsProjLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ProjLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetProjLONull()
		{
			base[tabletbl_Scores_OL_Report.ProjLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsProjIdentifyNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ProjIdentifyColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetProjIdentifyNull()
		{
			base[tabletbl_Scores_OL_Report.ProjIdentifyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsProjRemarkNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ProjRemarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetProjRemarkNull()
		{
			base[tabletbl_Scores_OL_Report.ProjRemarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassTeacherProjectNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ClassTeacherProjectColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassTeacherProjectNull()
		{
			base[tabletbl_Scores_OL_Report.ClassTeacherProjectColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHeadTeacherProjectNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.HeadTeacherProjectColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHeadTeacherProjectNull()
		{
			base[tabletbl_Scores_OL_Report.HeadTeacherProjectColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOverallPerformanceLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.OverallPerformanceLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOverallPerformanceLONull()
		{
			base[tabletbl_Scores_OL_Report.OverallPerformanceLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOverallPerformance100Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.OverallPerformance100Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOverallPerformance100Null()
		{
			base[tabletbl_Scores_OL_Report.OverallPerformance100Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTeacherRemarksAIOnlyNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.TeacherRemarksAIOnlyColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTeacherRemarksAIOnlyNull()
		{
			base[tabletbl_Scores_OL_Report.TeacherRemarksAIOnlyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCategoryAIOnlyNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.CategoryAIOnlyColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCategoryAIOnlyNull()
		{
			base[tabletbl_Scores_OL_Report.CategoryAIOnlyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSICNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SICColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSICNull()
		{
			base[tabletbl_Scores_OL_Report.SICColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSISNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SISColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSISNull()
		{
			base[tabletbl_Scores_OL_Report.SISColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectRankNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SubjectRankColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectRankNull()
		{
			base[tabletbl_Scores_OL_Report.SubjectRankColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGrandAvgNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.GrandAvgColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGrandAvgNull()
		{
			base[tabletbl_Scores_OL_Report.GrandAvgColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubPosLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SubPosLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubPosLONull()
		{
			base[tabletbl_Scores_OL_Report.SubPosLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubPosEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SubPosEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubPosEOTNull()
		{
			base[tabletbl_Scores_OL_Report.SubPosEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubPosLOEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.SubPosLOEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubPosLOEOTNull()
		{
			base[tabletbl_Scores_OL_Report.SubPosLOEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassteacherRemarkFANull()
		{
			return IsNull(tabletbl_Scores_OL_Report.ClassteacherRemarkFAColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassteacherRemarkFANull()
		{
			base[tabletbl_Scores_OL_Report.ClassteacherRemarkFAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHeadteacherRemarkFANull()
		{
			return IsNull(tabletbl_Scores_OL_Report.HeadteacherRemarkFAColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHeadteacherRemarkFANull()
		{
			base[tabletbl_Scores_OL_Report.HeadteacherRemarkFAColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGenericSkillsNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.GenericSkillsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGenericSkillsNull()
		{
			base[tabletbl_Scores_OL_Report.GenericSkillsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPICLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.PICLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPICLONull()
		{
			base[tabletbl_Scores_OL_Report.PICLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPISLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.PISLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPISLONull()
		{
			base[tabletbl_Scores_OL_Report.PISLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPICLOEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.PICLOEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPICLOEOTNull()
		{
			base[tabletbl_Scores_OL_Report.PICLOEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPICEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.PICEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPICEOTNull()
		{
			base[tabletbl_Scores_OL_Report.PICEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPISLOEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.PISLOEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPISLOEOTNull()
		{
			base[tabletbl_Scores_OL_Report.PISLOEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPISEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.PISEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPISEOTNull()
		{
			base[tabletbl_Scores_OL_Report.PISEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTotalStudentsNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.TotalStudentsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTotalStudentsNull()
		{
			base[tabletbl_Scores_OL_Report.TotalStudentsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGrandAvgLONull()
		{
			return IsNull(tabletbl_Scores_OL_Report.GrandAvgLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGrandAvgLONull()
		{
			base[tabletbl_Scores_OL_Report.GrandAvgLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGrandAvgEOTNull()
		{
			return IsNull(tabletbl_Scores_OL_Report.GrandAvgEOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGrandAvgEOTNull()
		{
			base[tabletbl_Scores_OL_Report.GrandAvgEOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP7Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.P7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP7Null()
		{
			base[tabletbl_Scores_OL_Report.P7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsScore4Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Score4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetScore4Null()
		{
			base[tabletbl_Scores_OL_Report.Score4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHund1Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Hund1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHund1Null()
		{
			base[tabletbl_Scores_OL_Report.Hund1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHund2Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Hund2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHund2Null()
		{
			base[tabletbl_Scores_OL_Report.Hund2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHund3Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Hund3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHund3Null()
		{
			base[tabletbl_Scores_OL_Report.Hund3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHund4Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Hund4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHund4Null()
		{
			base[tabletbl_Scores_OL_Report.Hund4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHund5Null()
		{
			return IsNull(tabletbl_Scores_OL_Report.Hund5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHund5Null()
		{
			base[tabletbl_Scores_OL_Report.Hund5Column] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class tbl_Scores_OL_ReportRowChangeEvent : EventArgs
	{
		private tbl_Scores_OL_ReportRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportRowChangeEvent(tbl_Scores_OL_ReportRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private tbl_Scores_OL_ReportDataTable tabletbl_Scores_OL_Report;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public tbl_Scores_OL_ReportDataTable tbl_Scores_OL_Report => tabletbl_Scores_OL_Report;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override SchemaSerializationMode SchemaSerializationMode
	{
		get
		{
			return _schemaSerializationMode;
		}
		set
		{
			_schemaSerializationMode = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations => base.Relations;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public NewCurriculumSubReport()
	{
		BeginInit();
		InitClass();
		CollectionChangeEventHandler value = SchemaChanged;
		base.Tables.CollectionChanged += value;
		base.Relations.CollectionChanged += value;
		EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected NewCurriculumSubReport(SerializationInfo info, StreamingContext context)
		: base(info, context, ConstructSchema: false)
	{
		if (IsBinarySerialized(info, context))
		{
			InitVars(initTable: false);
			CollectionChangeEventHandler value = SchemaChanged;
			Tables.CollectionChanged += value;
			Relations.CollectionChanged += value;
			return;
		}
		string s = (string)info.GetValue("XmlSchema", typeof(string));
		if (DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
			if (dataSet.Tables["tbl_Scores_OL_Report"] != null)
			{
				base.Tables.Add(new tbl_Scores_OL_ReportDataTable(dataSet.Tables["tbl_Scores_OL_Report"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			Merge(dataSet, preserveChanges: false, MissingSchemaAction.Add);
			InitVars();
		}
		else
		{
			ReadXmlSchema(new XmlTextReader(new StringReader(s)));
		}
		GetSerializationData(info, context);
		CollectionChangeEventHandler value2 = SchemaChanged;
		base.Tables.CollectionChanged += value2;
		Relations.CollectionChanged += value2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected override void InitializeDerivedDataSet()
	{
		BeginInit();
		InitClass();
		EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public override DataSet Clone()
	{
		NewCurriculumSubReport newCurriculumSubReport = (NewCurriculumSubReport)base.Clone();
		newCurriculumSubReport.InitVars();
		newCurriculumSubReport.SchemaSerializationMode = SchemaSerializationMode;
		return newCurriculumSubReport;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected override bool ShouldSerializeTables()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected override bool ShouldSerializeRelations()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected override void ReadXmlSerializable(XmlReader reader)
	{
		if (DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
		{
			Reset();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(reader);
			if (dataSet.Tables["tbl_Scores_OL_Report"] != null)
			{
				base.Tables.Add(new tbl_Scores_OL_ReportDataTable(dataSet.Tables["tbl_Scores_OL_Report"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			Merge(dataSet, preserveChanges: false, MissingSchemaAction.Add);
			InitVars();
		}
		else
		{
			ReadXml(reader);
			InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected override XmlSchema GetSchemaSerializable()
	{
		MemoryStream memoryStream = new MemoryStream();
		WriteXmlSchema(new XmlTextWriter(memoryStream, null));
		memoryStream.Position = 0L;
		return XmlSchema.Read(new XmlTextReader(memoryStream), null);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	internal void InitVars()
	{
		InitVars(initTable: true);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	internal void InitVars(bool initTable)
	{
		tabletbl_Scores_OL_Report = (tbl_Scores_OL_ReportDataTable)base.Tables["tbl_Scores_OL_Report"];
		if (initTable && tabletbl_Scores_OL_Report != null)
		{
			tabletbl_Scores_OL_Report.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "NewCurriculumSubReport";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/NewCurriculumSubReport.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tabletbl_Scores_OL_Report = new tbl_Scores_OL_ReportDataTable();
		base.Tables.Add(tabletbl_Scores_OL_Report);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializetbl_Scores_OL_Report()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void SchemaChanged(object sender, CollectionChangeEventArgs e)
	{
		if (e.Action == CollectionChangeAction.Remove)
		{
			InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
	{
		NewCurriculumSubReport newCurriculumSubReport = new NewCurriculumSubReport();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = newCurriculumSubReport.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = newCurriculumSubReport.GetSchemaSerializable();
		if (xs.Contains(schemaSerializable.TargetNamespace))
		{
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2 = new MemoryStream();
			try
			{
				XmlSchema xmlSchema = null;
				schemaSerializable.Write(memoryStream);
				IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
				while (enumerator.MoveNext())
				{
					xmlSchema = (XmlSchema)enumerator.Current;
					memoryStream2.SetLength(0L);
					xmlSchema.Write(memoryStream2);
					if (memoryStream.Length == memoryStream2.Length)
					{
						memoryStream.Position = 0L;
						memoryStream2.Position = 0L;
						while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream2.ReadByte())
						{
						}
						if (memoryStream.Position == memoryStream.Length)
						{
							return xmlSchemaComplexType;
						}
					}
				}
			}
			finally
			{
				memoryStream?.Close();
				memoryStream2?.Close();
			}
		}
		xs.Add(schemaSerializable);
		return xmlSchemaComplexType;
	}
}
