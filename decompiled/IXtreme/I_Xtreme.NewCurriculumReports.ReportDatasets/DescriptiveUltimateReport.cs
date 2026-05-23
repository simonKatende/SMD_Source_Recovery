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
[XmlRoot("DescriptiveUltimateReport")]
[HelpKeyword("vs.data.DataSet")]
public class DescriptiveUltimateReport : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void DescriptiveUltimateReportDSRowChangeEventHandler(object sender, DescriptiveUltimateReportDSRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class DescriptiveUltimateReportDSDataTable : TypedTableBase<DescriptiveUltimateReportDSRow>
	{
		private DataColumn columnSubjectId;

		private DataColumn columnChapter;

		private DataColumn columnTopic;

		private DataColumn columnCompetence;

		private DataColumn columnDescriptor;

		private DataColumn columnLO;

		private DataColumn columnTS;

		private DataColumn columnAvLO;

		private DataColumn columnAvTS;

		private DataColumn columnIdentifier;

		private DataColumn columnGenDescriptor;

		private DataColumn columnTeacherRemarks;

		private DataColumn columnTUnits;

		private DataColumn columnStudentNumber;

		private DataColumn columnInitial;

		private DataColumn columnGenGenericSkill;

		private DataColumn columnClassteacherRemark;

		private DataColumn columnHeadteacherRemark;

		private DataColumn columnP1;

		private DataColumn columnAvMark;

		private DataColumn columnETA80;

		private DataColumn columnTotal;

		private DataColumn columnCategory;

		private DataColumn columnRemarkOnCompetence;

		private DataColumn columnGenericSkill;

		private DataColumn columnOverallPerformance;

		private DataColumn columnOtherRequirements;

		private DataColumn columnTeacherRemarksDesc;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectIdColumn => columnSubjectId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ChapterColumn => columnChapter;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TopicColumn => columnTopic;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CompetenceColumn => columnCompetence;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DescriptorColumn => columnDescriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn LOColumn => columnLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TSColumn => columnTS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvLOColumn => columnAvLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvTSColumn => columnAvTS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IdentifierColumn => columnIdentifier;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GenDescriptorColumn => columnGenDescriptor;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TeacherRemarksColumn => columnTeacherRemarks;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TUnitsColumn => columnTUnits;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn InitialColumn => columnInitial;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GenGenericSkillColumn => columnGenGenericSkill;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassteacherRemarkColumn => columnClassteacherRemark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HeadteacherRemarkColumn => columnHeadteacherRemark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn P1Column => columnP1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvMarkColumn => columnAvMark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ETA80Column => columnETA80;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TotalColumn => columnTotal;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CategoryColumn => columnCategory;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn RemarkOnCompetenceColumn => columnRemarkOnCompetence;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GenericSkillColumn => columnGenericSkill;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OverallPerformanceColumn => columnOverallPerformance;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OtherRequirementsColumn => columnOtherRequirements;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TeacherRemarksDescColumn => columnTeacherRemarksDesc;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DescriptiveUltimateReportDSRow this[int index] => (DescriptiveUltimateReportDSRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event DescriptiveUltimateReportDSRowChangeEventHandler DescriptiveUltimateReportDSRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event DescriptiveUltimateReportDSRowChangeEventHandler DescriptiveUltimateReportDSRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event DescriptiveUltimateReportDSRowChangeEventHandler DescriptiveUltimateReportDSRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event DescriptiveUltimateReportDSRowChangeEventHandler DescriptiveUltimateReportDSRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DescriptiveUltimateReportDSDataTable()
		{
			base.TableName = "DescriptiveUltimateReportDS";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal DescriptiveUltimateReportDSDataTable(DataTable table)
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
		protected DescriptiveUltimateReportDSDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddDescriptiveUltimateReportDSRow(DescriptiveUltimateReportDSRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DescriptiveUltimateReportDSRow AddDescriptiveUltimateReportDSRow(string SubjectId, string Chapter, string Topic, string Competence, string Descriptor, string LO, string TS, double AvLO, double AvTS, int Identifier, string GenDescriptor, string TeacherRemarks, int TUnits, string StudentNumber, string Initial, string GenGenericSkill, string ClassteacherRemark, string HeadteacherRemark, string P1, double AvMark, double ETA80, double Total, string Category, string RemarkOnCompetence, string GenericSkill, string OverallPerformance, string OtherRequirements, string TeacherRemarksDesc)
		{
			DescriptiveUltimateReportDSRow descriptiveUltimateReportDSRow = (DescriptiveUltimateReportDSRow)NewRow();
			object[] itemArray = new object[28]
			{
				SubjectId, Chapter, Topic, Competence, Descriptor, LO, TS, AvLO, AvTS, Identifier,
				GenDescriptor, TeacherRemarks, TUnits, StudentNumber, Initial, GenGenericSkill, ClassteacherRemark, HeadteacherRemark, P1, AvMark,
				ETA80, Total, Category, RemarkOnCompetence, GenericSkill, OverallPerformance, OtherRequirements, TeacherRemarksDesc
			};
			descriptiveUltimateReportDSRow.ItemArray = itemArray;
			base.Rows.Add(descriptiveUltimateReportDSRow);
			return descriptiveUltimateReportDSRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			DescriptiveUltimateReportDSDataTable descriptiveUltimateReportDSDataTable = (DescriptiveUltimateReportDSDataTable)base.Clone();
			descriptiveUltimateReportDSDataTable.InitVars();
			return descriptiveUltimateReportDSDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new DescriptiveUltimateReportDSDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnSubjectId = base.Columns["SubjectId"];
			columnChapter = base.Columns["Chapter"];
			columnTopic = base.Columns["Topic"];
			columnCompetence = base.Columns["Competence"];
			columnDescriptor = base.Columns["Descriptor"];
			columnLO = base.Columns["LO"];
			columnTS = base.Columns["TS"];
			columnAvLO = base.Columns["AvLO"];
			columnAvTS = base.Columns["AvTS"];
			columnIdentifier = base.Columns["Identifier"];
			columnGenDescriptor = base.Columns["GenDescriptor"];
			columnTeacherRemarks = base.Columns["TeacherRemarks"];
			columnTUnits = base.Columns["TUnits"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnInitial = base.Columns["Initial"];
			columnGenGenericSkill = base.Columns["GenGenericSkill"];
			columnClassteacherRemark = base.Columns["ClassteacherRemark"];
			columnHeadteacherRemark = base.Columns["HeadteacherRemark"];
			columnP1 = base.Columns["P1"];
			columnAvMark = base.Columns["AvMark"];
			columnETA80 = base.Columns["ETA80"];
			columnTotal = base.Columns["Total"];
			columnCategory = base.Columns["Category"];
			columnRemarkOnCompetence = base.Columns["RemarkOnCompetence"];
			columnGenericSkill = base.Columns["GenericSkill"];
			columnOverallPerformance = base.Columns["OverallPerformance"];
			columnOtherRequirements = base.Columns["OtherRequirements"];
			columnTeacherRemarksDesc = base.Columns["TeacherRemarksDesc"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnSubjectId = new DataColumn("SubjectId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectId);
			columnChapter = new DataColumn("Chapter", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnChapter);
			columnTopic = new DataColumn("Topic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTopic);
			columnCompetence = new DataColumn("Competence", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCompetence);
			columnDescriptor = new DataColumn("Descriptor", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDescriptor);
			columnLO = new DataColumn("LO", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLO);
			columnTS = new DataColumn("TS", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTS);
			columnAvLO = new DataColumn("AvLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvLO);
			columnAvTS = new DataColumn("AvTS", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvTS);
			columnIdentifier = new DataColumn("Identifier", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnIdentifier);
			columnGenDescriptor = new DataColumn("GenDescriptor", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGenDescriptor);
			columnTeacherRemarks = new DataColumn("TeacherRemarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTeacherRemarks);
			columnTUnits = new DataColumn("TUnits", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnTUnits);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnInitial = new DataColumn("Initial", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInitial);
			columnGenGenericSkill = new DataColumn("GenGenericSkill", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGenGenericSkill);
			columnClassteacherRemark = new DataColumn("ClassteacherRemark", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassteacherRemark);
			columnHeadteacherRemark = new DataColumn("HeadteacherRemark", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeadteacherRemark);
			columnP1 = new DataColumn("P1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnP1);
			columnAvMark = new DataColumn("AvMark", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvMark);
			columnETA80 = new DataColumn("ETA80", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnETA80);
			columnTotal = new DataColumn("Total", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotal);
			columnCategory = new DataColumn("Category", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCategory);
			columnRemarkOnCompetence = new DataColumn("RemarkOnCompetence", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnRemarkOnCompetence);
			columnGenericSkill = new DataColumn("GenericSkill", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGenericSkill);
			columnOverallPerformance = new DataColumn("OverallPerformance", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOverallPerformance);
			columnOtherRequirements = new DataColumn("OtherRequirements", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOtherRequirements);
			columnTeacherRemarksDesc = new DataColumn("TeacherRemarksDesc", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTeacherRemarksDesc);
			columnSubjectId.ReadOnly = true;
			columnSubjectId.MaxLength = 50;
			columnChapter.ReadOnly = true;
			columnChapter.MaxLength = 1;
			columnTopic.ReadOnly = true;
			columnTopic.MaxLength = 200;
			columnCompetence.ReadOnly = true;
			columnCompetence.MaxLength = int.MaxValue;
			columnDescriptor.ReadOnly = true;
			columnDescriptor.MaxLength = 100;
			columnLO.ReadOnly = true;
			columnLO.MaxLength = 3;
			columnTS.ReadOnly = true;
			columnTS.MaxLength = 4;
			columnAvLO.ReadOnly = true;
			columnAvTS.ReadOnly = true;
			columnIdentifier.ReadOnly = true;
			columnGenDescriptor.ReadOnly = true;
			columnGenDescriptor.MaxLength = 80;
			columnTeacherRemarks.ReadOnly = true;
			columnTeacherRemarks.MaxLength = int.MaxValue;
			columnTUnits.ReadOnly = true;
			columnStudentNumber.ReadOnly = true;
			columnStudentNumber.MaxLength = 12;
			columnInitial.ReadOnly = true;
			columnInitial.MaxLength = 3;
			columnGenGenericSkill.ReadOnly = true;
			columnGenGenericSkill.MaxLength = 200;
			columnClassteacherRemark.ReadOnly = true;
			columnClassteacherRemark.MaxLength = 200;
			columnHeadteacherRemark.ReadOnly = true;
			columnHeadteacherRemark.MaxLength = 200;
			columnP1.ReadOnly = true;
			columnP1.MaxLength = 4;
			columnAvMark.ReadOnly = true;
			columnETA80.ReadOnly = true;
			columnTotal.ReadOnly = true;
			columnCategory.ReadOnly = true;
			columnCategory.MaxLength = 2;
			columnRemarkOnCompetence.ReadOnly = true;
			columnRemarkOnCompetence.MaxLength = 500;
			columnGenericSkill.ReadOnly = true;
			columnGenericSkill.MaxLength = 2000;
			columnOverallPerformance.ReadOnly = true;
			columnOverallPerformance.MaxLength = 50;
			columnOtherRequirements.ReadOnly = true;
			columnOtherRequirements.MaxLength = 2000;
			columnTeacherRemarksDesc.ReadOnly = true;
			columnTeacherRemarksDesc.MaxLength = 200;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DescriptiveUltimateReportDSRow NewDescriptiveUltimateReportDSRow()
		{
			return (DescriptiveUltimateReportDSRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new DescriptiveUltimateReportDSRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(DescriptiveUltimateReportDSRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.DescriptiveUltimateReportDSRowChanged != null)
			{
				this.DescriptiveUltimateReportDSRowChanged(this, new DescriptiveUltimateReportDSRowChangeEvent((DescriptiveUltimateReportDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.DescriptiveUltimateReportDSRowChanging != null)
			{
				this.DescriptiveUltimateReportDSRowChanging(this, new DescriptiveUltimateReportDSRowChangeEvent((DescriptiveUltimateReportDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.DescriptiveUltimateReportDSRowDeleted != null)
			{
				this.DescriptiveUltimateReportDSRowDeleted(this, new DescriptiveUltimateReportDSRowChangeEvent((DescriptiveUltimateReportDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.DescriptiveUltimateReportDSRowDeleting != null)
			{
				this.DescriptiveUltimateReportDSRowDeleting(this, new DescriptiveUltimateReportDSRowChangeEvent((DescriptiveUltimateReportDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveDescriptiveUltimateReportDSRow(DescriptiveUltimateReportDSRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DescriptiveUltimateReport descriptiveUltimateReport = new DescriptiveUltimateReport();
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
			xmlSchemaAttribute.FixedValue = descriptiveUltimateReport.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "DescriptiveUltimateReportDSDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = descriptiveUltimateReport.GetSchemaSerializable();
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

	public class DescriptiveUltimateReportDSRow : DataRow
	{
		private DescriptiveUltimateReportDSDataTable tableDescriptiveUltimateReportDS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SubjectId
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.SubjectIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectId' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.SubjectIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Chapter
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.ChapterColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Chapter' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.ChapterColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Topic
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.TopicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Topic' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.TopicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Competence
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.CompetenceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Competence' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.CompetenceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Descriptor
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.DescriptorColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Descriptor' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.DescriptorColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string LO
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.LOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LO' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.LOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TS
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.TSColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TS' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.TSColumn] = value;
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
					return (double)base[tableDescriptiveUltimateReportDS.AvLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvLO' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.AvLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double AvTS
		{
			get
			{
				try
				{
					return (double)base[tableDescriptiveUltimateReportDS.AvTSColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvTS' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.AvTSColumn] = value;
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
					return (int)base[tableDescriptiveUltimateReportDS.IdentifierColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Identifier' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.IdentifierColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string GenDescriptor
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.GenDescriptorColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GenDescriptor' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.GenDescriptorColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.TeacherRemarksColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TeacherRemarks' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.TeacherRemarksColumn] = value;
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
					return (int)base[tableDescriptiveUltimateReportDS.TUnitsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TUnits' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.TUnitsColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.StudentNumberColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.InitialColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Initial' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.InitialColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string GenGenericSkill
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.GenGenericSkillColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GenGenericSkill' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.GenGenericSkillColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.ClassteacherRemarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassteacherRemark' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.ClassteacherRemarkColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.HeadteacherRemarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeadteacherRemark' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.HeadteacherRemarkColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.P1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'P1' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.P1Column] = value;
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
					return (double)base[tableDescriptiveUltimateReportDS.AvMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvMark' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.AvMarkColumn] = value;
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
					return (double)base[tableDescriptiveUltimateReportDS.ETA80Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ETA80' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.ETA80Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double Total
		{
			get
			{
				try
				{
					return (double)base[tableDescriptiveUltimateReportDS.TotalColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Total' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.TotalColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.CategoryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Category' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.CategoryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string RemarkOnCompetence
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.RemarkOnCompetenceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RemarkOnCompetence' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.RemarkOnCompetenceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string GenericSkill
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.GenericSkillColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GenericSkill' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.GenericSkillColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.OverallPerformanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OverallPerformance' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.OverallPerformanceColumn] = value;
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
					return (string)base[tableDescriptiveUltimateReportDS.OtherRequirementsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherRequirements' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.OtherRequirementsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TeacherRemarksDesc
		{
			get
			{
				try
				{
					return (string)base[tableDescriptiveUltimateReportDS.TeacherRemarksDescColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TeacherRemarksDesc' in table 'DescriptiveUltimateReportDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableDescriptiveUltimateReportDS.TeacherRemarksDescColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal DescriptiveUltimateReportDSRow(DataRowBuilder rb)
			: base(rb)
		{
			tableDescriptiveUltimateReportDS = (DescriptiveUltimateReportDSDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectIdNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.SubjectIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectIdNull()
		{
			base[tableDescriptiveUltimateReportDS.SubjectIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsChapterNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.ChapterColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetChapterNull()
		{
			base[tableDescriptiveUltimateReportDS.ChapterColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTopicNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.TopicColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTopicNull()
		{
			base[tableDescriptiveUltimateReportDS.TopicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCompetenceNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.CompetenceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCompetenceNull()
		{
			base[tableDescriptiveUltimateReportDS.CompetenceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDescriptorNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.DescriptorColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDescriptorNull()
		{
			base[tableDescriptiveUltimateReportDS.DescriptorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsLONull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.LOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetLONull()
		{
			base[tableDescriptiveUltimateReportDS.LOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTSNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.TSColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTSNull()
		{
			base[tableDescriptiveUltimateReportDS.TSColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvLONull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.AvLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvLONull()
		{
			base[tableDescriptiveUltimateReportDS.AvLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvTSNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.AvTSColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvTSNull()
		{
			base[tableDescriptiveUltimateReportDS.AvTSColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsIdentifierNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.IdentifierColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetIdentifierNull()
		{
			base[tableDescriptiveUltimateReportDS.IdentifierColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGenDescriptorNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.GenDescriptorColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGenDescriptorNull()
		{
			base[tableDescriptiveUltimateReportDS.GenDescriptorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTeacherRemarksNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.TeacherRemarksColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTeacherRemarksNull()
		{
			base[tableDescriptiveUltimateReportDS.TeacherRemarksColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTUnitsNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.TUnitsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTUnitsNull()
		{
			base[tableDescriptiveUltimateReportDS.TUnitsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tableDescriptiveUltimateReportDS.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsInitialNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.InitialColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetInitialNull()
		{
			base[tableDescriptiveUltimateReportDS.InitialColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGenGenericSkillNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.GenGenericSkillColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGenGenericSkillNull()
		{
			base[tableDescriptiveUltimateReportDS.GenGenericSkillColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassteacherRemarkNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.ClassteacherRemarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassteacherRemarkNull()
		{
			base[tableDescriptiveUltimateReportDS.ClassteacherRemarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHeadteacherRemarkNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.HeadteacherRemarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHeadteacherRemarkNull()
		{
			base[tableDescriptiveUltimateReportDS.HeadteacherRemarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsP1Null()
		{
			return IsNull(tableDescriptiveUltimateReportDS.P1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetP1Null()
		{
			base[tableDescriptiveUltimateReportDS.P1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvMarkNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.AvMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvMarkNull()
		{
			base[tableDescriptiveUltimateReportDS.AvMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsETA80Null()
		{
			return IsNull(tableDescriptiveUltimateReportDS.ETA80Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetETA80Null()
		{
			base[tableDescriptiveUltimateReportDS.ETA80Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTotalNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.TotalColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTotalNull()
		{
			base[tableDescriptiveUltimateReportDS.TotalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCategoryNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.CategoryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCategoryNull()
		{
			base[tableDescriptiveUltimateReportDS.CategoryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsRemarkOnCompetenceNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.RemarkOnCompetenceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetRemarkOnCompetenceNull()
		{
			base[tableDescriptiveUltimateReportDS.RemarkOnCompetenceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGenericSkillNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.GenericSkillColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGenericSkillNull()
		{
			base[tableDescriptiveUltimateReportDS.GenericSkillColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOverallPerformanceNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.OverallPerformanceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOverallPerformanceNull()
		{
			base[tableDescriptiveUltimateReportDS.OverallPerformanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOtherRequirementsNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.OtherRequirementsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOtherRequirementsNull()
		{
			base[tableDescriptiveUltimateReportDS.OtherRequirementsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTeacherRemarksDescNull()
		{
			return IsNull(tableDescriptiveUltimateReportDS.TeacherRemarksDescColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTeacherRemarksDescNull()
		{
			base[tableDescriptiveUltimateReportDS.TeacherRemarksDescColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class DescriptiveUltimateReportDSRowChangeEvent : EventArgs
	{
		private DescriptiveUltimateReportDSRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DescriptiveUltimateReportDSRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DescriptiveUltimateReportDSRowChangeEvent(DescriptiveUltimateReportDSRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private DescriptiveUltimateReportDSDataTable tableDescriptiveUltimateReportDS;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DescriptiveUltimateReportDSDataTable DescriptiveUltimateReportDS => tableDescriptiveUltimateReportDS;

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
	public DescriptiveUltimateReport()
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
	protected DescriptiveUltimateReport(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["DescriptiveUltimateReportDS"] != null)
			{
				base.Tables.Add(new DescriptiveUltimateReportDSDataTable(dataSet.Tables["DescriptiveUltimateReportDS"]));
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
		DescriptiveUltimateReport descriptiveUltimateReport = (DescriptiveUltimateReport)base.Clone();
		descriptiveUltimateReport.InitVars();
		descriptiveUltimateReport.SchemaSerializationMode = SchemaSerializationMode;
		return descriptiveUltimateReport;
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
			if (dataSet.Tables["DescriptiveUltimateReportDS"] != null)
			{
				base.Tables.Add(new DescriptiveUltimateReportDSDataTable(dataSet.Tables["DescriptiveUltimateReportDS"]));
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
		tableDescriptiveUltimateReportDS = (DescriptiveUltimateReportDSDataTable)base.Tables["DescriptiveUltimateReportDS"];
		if (initTable && tableDescriptiveUltimateReportDS != null)
		{
			tableDescriptiveUltimateReportDS.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "DescriptiveUltimateReport";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/DescriptiveUltimateReport.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableDescriptiveUltimateReportDS = new DescriptiveUltimateReportDSDataTable();
		base.Tables.Add(tableDescriptiveUltimateReportDS);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeDescriptiveUltimateReportDS()
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
		DescriptiveUltimateReport descriptiveUltimateReport = new DescriptiveUltimateReport();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = descriptiveUltimateReport.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = descriptiveUltimateReport.GetSchemaSerializable();
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
