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

namespace I_Xtreme.IslamicTheology;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("TheologySubDS")]
[HelpKeyword("vs.data.DataSet")]
public class TheologySubDS : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void tbl_Scores_OL_ReportTHRowChangeEventHandler(object sender, tbl_Scores_OL_ReportTHRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class tbl_Scores_OL_ReportTHDataTable : TypedTableBase<tbl_Scores_OL_ReportTHRow>
	{
		private DataColumn columnSubjectId;

		private DataColumn columnSubjectIdAr;

		private DataColumn columnChapter;

		private DataColumn columnTopic;

		private DataColumn columnTopicAr;

		private DataColumn columnLO;

		private DataColumn columnLOAr;

		private DataColumn columnTS;

		private DataColumn columnTSAr;

		private DataColumn columnAvLO;

		private DataColumn columnAvLOAr;

		private DataColumn columnAvTS;

		private DataColumn columnAvTSAr;

		private DataColumn columnTeacherRemarks;

		private DataColumn columnTeacherRemarksAr;

		private DataColumn columnTUnits;

		private DataColumn columnStudentNumber;

		private DataColumn columnInitial;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectIdColumn => columnSubjectId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectIdArColumn => columnSubjectIdAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ChapterColumn => columnChapter;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TopicColumn => columnTopic;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TopicArColumn => columnTopicAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn LOColumn => columnLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn LOArColumn => columnLOAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TSColumn => columnTS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TSArColumn => columnTSAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvLOColumn => columnAvLO;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvLOArColumn => columnAvLOAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvTSColumn => columnAvTS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvTSArColumn => columnAvTSAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TeacherRemarksColumn => columnTeacherRemarks;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TeacherRemarksArColumn => columnTeacherRemarksAr;

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
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportTHRow this[int index] => (tbl_Scores_OL_ReportTHRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportTHRowChangeEventHandler tbl_Scores_OL_ReportTHRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportTHRowChangeEventHandler tbl_Scores_OL_ReportTHRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportTHRowChangeEventHandler tbl_Scores_OL_ReportTHRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_Scores_OL_ReportTHRowChangeEventHandler tbl_Scores_OL_ReportTHRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportTHDataTable()
		{
			base.TableName = "tbl_Scores_OL_ReportTH";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_Scores_OL_ReportTHDataTable(DataTable table)
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
		protected tbl_Scores_OL_ReportTHDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Addtbl_Scores_OL_ReportTHRow(tbl_Scores_OL_ReportTHRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportTHRow Addtbl_Scores_OL_ReportTHRow(string SubjectId, string SubjectIdAr, string Chapter, string Topic, string TopicAr, string LO, string LOAr, string TS, string TSAr, double AvLO, string AvLOAr, double AvTS, string AvTSAr, string TeacherRemarks, string TeacherRemarksAr, int TUnits, string StudentNumber, string Initial)
		{
			tbl_Scores_OL_ReportTHRow tbl_Scores_OL_ReportTHRow = (tbl_Scores_OL_ReportTHRow)NewRow();
			object[] itemArray = new object[18]
			{
				SubjectId, SubjectIdAr, Chapter, Topic, TopicAr, LO, LOAr, TS, TSAr, AvLO,
				AvLOAr, AvTS, AvTSAr, TeacherRemarks, TeacherRemarksAr, TUnits, StudentNumber, Initial
			};
			tbl_Scores_OL_ReportTHRow.ItemArray = itemArray;
			base.Rows.Add(tbl_Scores_OL_ReportTHRow);
			return tbl_Scores_OL_ReportTHRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			tbl_Scores_OL_ReportTHDataTable tbl_Scores_OL_ReportTHDataTable = (tbl_Scores_OL_ReportTHDataTable)base.Clone();
			tbl_Scores_OL_ReportTHDataTable.InitVars();
			return tbl_Scores_OL_ReportTHDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new tbl_Scores_OL_ReportTHDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnSubjectId = base.Columns["SubjectId"];
			columnSubjectIdAr = base.Columns["SubjectIdAr"];
			columnChapter = base.Columns["Chapter"];
			columnTopic = base.Columns["Topic"];
			columnTopicAr = base.Columns["TopicAr"];
			columnLO = base.Columns["LO"];
			columnLOAr = base.Columns["LOAr"];
			columnTS = base.Columns["TS"];
			columnTSAr = base.Columns["TSAr"];
			columnAvLO = base.Columns["AvLO"];
			columnAvLOAr = base.Columns["AvLOAr"];
			columnAvTS = base.Columns["AvTS"];
			columnAvTSAr = base.Columns["AvTSAr"];
			columnTeacherRemarks = base.Columns["TeacherRemarks"];
			columnTeacherRemarksAr = base.Columns["TeacherRemarksAr"];
			columnTUnits = base.Columns["TUnits"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnInitial = base.Columns["Initial"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnSubjectId = new DataColumn("SubjectId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectId);
			columnSubjectIdAr = new DataColumn("SubjectIdAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectIdAr);
			columnChapter = new DataColumn("Chapter", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnChapter);
			columnTopic = new DataColumn("Topic", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTopic);
			columnTopicAr = new DataColumn("TopicAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTopicAr);
			columnLO = new DataColumn("LO", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLO);
			columnLOAr = new DataColumn("LOAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLOAr);
			columnTS = new DataColumn("TS", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTS);
			columnTSAr = new DataColumn("TSAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTSAr);
			columnAvLO = new DataColumn("AvLO", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvLO);
			columnAvLOAr = new DataColumn("AvLOAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAvLOAr);
			columnAvTS = new DataColumn("AvTS", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvTS);
			columnAvTSAr = new DataColumn("AvTSAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAvTSAr);
			columnTeacherRemarks = new DataColumn("TeacherRemarks", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTeacherRemarks);
			columnTeacherRemarksAr = new DataColumn("TeacherRemarksAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnTeacherRemarksAr);
			columnTUnits = new DataColumn("TUnits", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnTUnits);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnInitial = new DataColumn("Initial", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInitial);
			columnSubjectId.ReadOnly = true;
			columnSubjectId.MaxLength = 50;
			columnSubjectIdAr.ReadOnly = true;
			columnSubjectIdAr.MaxLength = 50;
			columnChapter.ReadOnly = true;
			columnChapter.MaxLength = 1;
			columnTopic.ReadOnly = true;
			columnTopic.MaxLength = 200;
			columnTopicAr.ReadOnly = true;
			columnTopicAr.MaxLength = 200;
			columnLO.ReadOnly = true;
			columnLO.MaxLength = 3;
			columnLOAr.ReadOnly = true;
			columnLOAr.MaxLength = 3;
			columnTS.ReadOnly = true;
			columnTS.MaxLength = 4;
			columnTSAr.ReadOnly = true;
			columnTSAr.MaxLength = 4;
			columnAvLO.ReadOnly = true;
			columnAvLOAr.ReadOnly = true;
			columnAvLOAr.MaxLength = 4;
			columnAvTS.ReadOnly = true;
			columnAvTSAr.ReadOnly = true;
			columnAvTSAr.MaxLength = 4;
			columnTeacherRemarks.ReadOnly = true;
			columnTeacherRemarks.MaxLength = 500;
			columnTeacherRemarksAr.ReadOnly = true;
			columnTeacherRemarksAr.MaxLength = 500;
			columnTUnits.ReadOnly = true;
			columnStudentNumber.ReadOnly = true;
			columnStudentNumber.MaxLength = 12;
			columnInitial.ReadOnly = true;
			columnInitial.MaxLength = 3;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportTHRow Newtbl_Scores_OL_ReportTHRow()
		{
			return (tbl_Scores_OL_ReportTHRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new tbl_Scores_OL_ReportTHRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(tbl_Scores_OL_ReportTHRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.tbl_Scores_OL_ReportTHRowChanged != null)
			{
				this.tbl_Scores_OL_ReportTHRowChanged(this, new tbl_Scores_OL_ReportTHRowChangeEvent((tbl_Scores_OL_ReportTHRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.tbl_Scores_OL_ReportTHRowChanging != null)
			{
				this.tbl_Scores_OL_ReportTHRowChanging(this, new tbl_Scores_OL_ReportTHRowChangeEvent((tbl_Scores_OL_ReportTHRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.tbl_Scores_OL_ReportTHRowDeleted != null)
			{
				this.tbl_Scores_OL_ReportTHRowDeleted(this, new tbl_Scores_OL_ReportTHRowChangeEvent((tbl_Scores_OL_ReportTHRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.tbl_Scores_OL_ReportTHRowDeleting != null)
			{
				this.tbl_Scores_OL_ReportTHRowDeleting(this, new tbl_Scores_OL_ReportTHRowChangeEvent((tbl_Scores_OL_ReportTHRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Removetbl_Scores_OL_ReportTHRow(tbl_Scores_OL_ReportTHRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			TheologySubDS theologySubDS = new TheologySubDS();
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
			xmlSchemaAttribute.FixedValue = theologySubDS.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "tbl_Scores_OL_ReportTHDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = theologySubDS.GetSchemaSerializable();
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

	public class tbl_Scores_OL_ReportTHRow : DataRow
	{
		private tbl_Scores_OL_ReportTHDataTable tabletbl_Scores_OL_ReportTH;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SubjectId
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.SubjectIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectId' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.SubjectIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SubjectIdAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.SubjectIdArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectIdAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.SubjectIdArColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.ChapterColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Chapter' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.ChapterColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.TopicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Topic' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TopicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TopicAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.TopicArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TopicAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TopicArColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.LOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LO' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.LOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string LOAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.LOArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LOAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.LOArColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.TSColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TS' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TSColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TSAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.TSArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TSAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TSArColumn] = value;
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
					return (double)base[tabletbl_Scores_OL_ReportTH.AvLOColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvLO' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.AvLOColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string AvLOAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.AvLOArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvLOAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.AvLOArColumn] = value;
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
					return (double)base[tabletbl_Scores_OL_ReportTH.AvTSColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvTS' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.AvTSColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string AvTSAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.AvTSArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvTSAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.AvTSArColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.TeacherRemarksColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TeacherRemarks' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TeacherRemarksColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string TeacherRemarksAr
		{
			get
			{
				try
				{
					return (string)base[tabletbl_Scores_OL_ReportTH.TeacherRemarksArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TeacherRemarksAr' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TeacherRemarksArColumn] = value;
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
					return (int)base[tabletbl_Scores_OL_ReportTH.TUnitsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TUnits' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.TUnitsColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.StudentNumberColumn] = value;
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
					return (string)base[tabletbl_Scores_OL_ReportTH.InitialColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Initial' in table 'tbl_Scores_OL_ReportTH' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Scores_OL_ReportTH.InitialColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_Scores_OL_ReportTHRow(DataRowBuilder rb)
			: base(rb)
		{
			tabletbl_Scores_OL_ReportTH = (tbl_Scores_OL_ReportTHDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectIdNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.SubjectIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectIdNull()
		{
			base[tabletbl_Scores_OL_ReportTH.SubjectIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectIdArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.SubjectIdArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectIdArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.SubjectIdArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsChapterNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.ChapterColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetChapterNull()
		{
			base[tabletbl_Scores_OL_ReportTH.ChapterColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTopicNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TopicColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTopicNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TopicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTopicArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TopicArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTopicArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TopicArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsLONull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.LOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetLONull()
		{
			base[tabletbl_Scores_OL_ReportTH.LOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsLOArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.LOArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetLOArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.LOArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTSNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TSColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTSNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TSColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTSArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TSArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTSArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TSArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvLONull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.AvLOColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvLONull()
		{
			base[tabletbl_Scores_OL_ReportTH.AvLOColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvLOArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.AvLOArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvLOArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.AvLOArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvTSNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.AvTSColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvTSNull()
		{
			base[tabletbl_Scores_OL_ReportTH.AvTSColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvTSArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.AvTSArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvTSArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.AvTSArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTeacherRemarksNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TeacherRemarksColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTeacherRemarksNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TeacherRemarksColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTeacherRemarksArNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TeacherRemarksArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTeacherRemarksArNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TeacherRemarksArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTUnitsNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.TUnitsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTUnitsNull()
		{
			base[tabletbl_Scores_OL_ReportTH.TUnitsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tabletbl_Scores_OL_ReportTH.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsInitialNull()
		{
			return IsNull(tabletbl_Scores_OL_ReportTH.InitialColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetInitialNull()
		{
			base[tabletbl_Scores_OL_ReportTH.InitialColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class tbl_Scores_OL_ReportTHRowChangeEvent : EventArgs
	{
		private tbl_Scores_OL_ReportTHRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportTHRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_Scores_OL_ReportTHRowChangeEvent(tbl_Scores_OL_ReportTHRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private tbl_Scores_OL_ReportTHDataTable tabletbl_Scores_OL_ReportTH;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public tbl_Scores_OL_ReportTHDataTable tbl_Scores_OL_ReportTH => tabletbl_Scores_OL_ReportTH;

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
	public TheologySubDS()
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
	protected TheologySubDS(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["tbl_Scores_OL_ReportTH"] != null)
			{
				base.Tables.Add(new tbl_Scores_OL_ReportTHDataTable(dataSet.Tables["tbl_Scores_OL_ReportTH"]));
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
		TheologySubDS theologySubDS = (TheologySubDS)base.Clone();
		theologySubDS.InitVars();
		theologySubDS.SchemaSerializationMode = SchemaSerializationMode;
		return theologySubDS;
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
			if (dataSet.Tables["tbl_Scores_OL_ReportTH"] != null)
			{
				base.Tables.Add(new tbl_Scores_OL_ReportTHDataTable(dataSet.Tables["tbl_Scores_OL_ReportTH"]));
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
		tabletbl_Scores_OL_ReportTH = (tbl_Scores_OL_ReportTHDataTable)base.Tables["tbl_Scores_OL_ReportTH"];
		if (initTable && tabletbl_Scores_OL_ReportTH != null)
		{
			tabletbl_Scores_OL_ReportTH.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "TheologySubDS";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/TheologySubDS.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tabletbl_Scores_OL_ReportTH = new tbl_Scores_OL_ReportTHDataTable();
		base.Tables.Add(tabletbl_Scores_OL_ReportTH);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializetbl_Scores_OL_ReportTH()
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
		TheologySubDS theologySubDS = new TheologySubDS();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = theologySubDS.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = theologySubDS.GetSchemaSerializable();
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
