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

namespace I_Xtreme.AdvancedReports.StorageSub;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("ALevelReportSub")]
[HelpKeyword("vs.data.DataSet")]
public class ALevelReportSub : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void ALevelReportSubRowChangeEventHandler(object sender, ALevelReportSubRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class ALevelReportSubDataTable : TypedTableBase<ALevelReportSubRow>
	{
		private DataColumn columnid;

		private DataColumn columnStudentNumber;

		private DataColumn columnSemesterId;

		private DataColumn columnSubjectId;

		private DataColumn columnClassId;

		private DataColumn columnPaper;

		private DataColumn columnHoP;

		private DataColumn columnBOT;

		private DataColumn columnMOT;

		private DataColumn columnEOT;

		private DataColumn columnAvMark;

		private DataColumn columnCategory;

		private DataColumn columnGrade;

		private DataColumn columnComment;

		private DataColumn columnInitial;

		private DataColumn columnSubGroup;

		private DataColumn columnPoints;

		private DataColumn columnpromoStatus;

		private DataColumn columnHeadTeacherComments;

		private DataColumn columnDOSComments;

		private DataColumn columnClassTeacherComments;

		private DataColumn columnComment4;

		private DataColumn columnAverageMark;

		private DataColumn columnCategoryPoints;

		private DataColumn columnTotals;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn idColumn => columnid;

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
		public DataColumn PaperColumn => columnPaper;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HoPColumn => columnHoP;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn BOTColumn => columnBOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn MOTColumn => columnMOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn EOTColumn => columnEOT;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvMarkColumn => columnAvMark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CategoryColumn => columnCategory;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GradeColumn => columnGrade;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CommentColumn => columnComment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn InitialColumn => columnInitial;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubGroupColumn => columnSubGroup;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PointsColumn => columnPoints;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn promoStatusColumn => columnpromoStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HeadTeacherCommentsColumn => columnHeadTeacherComments;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DOSCommentsColumn => columnDOSComments;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassTeacherCommentsColumn => columnClassTeacherComments;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Comment4Column => columnComment4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AverageMarkColumn => columnAverageMark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CategoryPointsColumn => columnCategoryPoints;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TotalsColumn => columnTotals;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public ALevelReportSubRow this[int index] => (ALevelReportSubRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event ALevelReportSubRowChangeEventHandler ALevelReportSubRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event ALevelReportSubRowChangeEventHandler ALevelReportSubRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event ALevelReportSubRowChangeEventHandler ALevelReportSubRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event ALevelReportSubRowChangeEventHandler ALevelReportSubRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public ALevelReportSubDataTable()
		{
			base.TableName = "ALevelReportSub";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal ALevelReportSubDataTable(DataTable table)
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
		protected ALevelReportSubDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddALevelReportSubRow(ALevelReportSubRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public ALevelReportSubRow AddALevelReportSubRow(string StudentNumber, string SemesterId, string SubjectId, string ClassId, string Paper, string HoP, string BOT, string MOT, string EOT, double AvMark, string Category, string Grade, string Comment, string Initial, string SubGroup, double Points, string promoStatus, string HeadTeacherComments, string DOSComments, string ClassTeacherComments, string Comment4, double AverageMark, string CategoryPoints, double Totals)
		{
			ALevelReportSubRow aLevelReportSubRow = (ALevelReportSubRow)NewRow();
			object[] itemArray = new object[25]
			{
				null, StudentNumber, SemesterId, SubjectId, ClassId, Paper, HoP, BOT, MOT, EOT,
				AvMark, Category, Grade, Comment, Initial, SubGroup, Points, promoStatus, HeadTeacherComments, DOSComments,
				ClassTeacherComments, Comment4, AverageMark, CategoryPoints, Totals
			};
			aLevelReportSubRow.ItemArray = itemArray;
			base.Rows.Add(aLevelReportSubRow);
			return aLevelReportSubRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			ALevelReportSubDataTable aLevelReportSubDataTable = (ALevelReportSubDataTable)base.Clone();
			aLevelReportSubDataTable.InitVars();
			return aLevelReportSubDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new ALevelReportSubDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnid = base.Columns["id"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnSemesterId = base.Columns["SemesterId"];
			columnSubjectId = base.Columns["SubjectId"];
			columnClassId = base.Columns["ClassId"];
			columnPaper = base.Columns["Paper"];
			columnHoP = base.Columns["HoP"];
			columnBOT = base.Columns["BOT"];
			columnMOT = base.Columns["MOT"];
			columnEOT = base.Columns["EOT"];
			columnAvMark = base.Columns["AvMark"];
			columnCategory = base.Columns["Category"];
			columnGrade = base.Columns["Grade"];
			columnComment = base.Columns["Comment"];
			columnInitial = base.Columns["Initial"];
			columnSubGroup = base.Columns["SubGroup"];
			columnPoints = base.Columns["Points"];
			columnpromoStatus = base.Columns["promoStatus"];
			columnHeadTeacherComments = base.Columns["HeadTeacherComments"];
			columnDOSComments = base.Columns["DOSComments"];
			columnClassTeacherComments = base.Columns["ClassTeacherComments"];
			columnComment4 = base.Columns["Comment4"];
			columnAverageMark = base.Columns["AverageMark"];
			columnCategoryPoints = base.Columns["CategoryPoints"];
			columnTotals = base.Columns["Totals"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnid = new DataColumn("id", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnid);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnSubjectId = new DataColumn("SubjectId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectId);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
			columnPaper = new DataColumn("Paper", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPaper);
			columnHoP = new DataColumn("HoP", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHoP);
			columnBOT = new DataColumn("BOT", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBOT);
			columnMOT = new DataColumn("MOT", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMOT);
			columnEOT = new DataColumn("EOT", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEOT);
			columnAvMark = new DataColumn("AvMark", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvMark);
			columnCategory = new DataColumn("Category", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCategory);
			columnGrade = new DataColumn("Grade", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGrade);
			columnComment = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnComment);
			columnInitial = new DataColumn("Initial", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInitial);
			columnSubGroup = new DataColumn("SubGroup", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubGroup);
			columnPoints = new DataColumn("Points", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnPoints);
			columnpromoStatus = new DataColumn("promoStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnpromoStatus);
			columnHeadTeacherComments = new DataColumn("HeadTeacherComments", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeadTeacherComments);
			columnDOSComments = new DataColumn("DOSComments", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDOSComments);
			columnClassTeacherComments = new DataColumn("ClassTeacherComments", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassTeacherComments);
			columnComment4 = new DataColumn("Comment4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnComment4);
			columnAverageMark = new DataColumn("AverageMark", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAverageMark);
			columnCategoryPoints = new DataColumn("CategoryPoints", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCategoryPoints);
			columnTotals = new DataColumn("Totals", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotals);
			columnid.AutoIncrement = true;
			columnid.AutoIncrementSeed = -1L;
			columnid.AutoIncrementStep = -1L;
			columnid.AllowDBNull = false;
			columnid.ReadOnly = true;
			columnStudentNumber.MaxLength = 12;
			columnSemesterId.MaxLength = 12;
			columnSubjectId.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnPaper.MaxLength = 15;
			columnHoP.MaxLength = 5;
			columnBOT.MaxLength = 5;
			columnMOT.MaxLength = 5;
			columnEOT.MaxLength = 5;
			columnCategory.MaxLength = 2;
			columnGrade.MaxLength = 3;
			columnComment.MaxLength = 80;
			columnInitial.MaxLength = 5;
			columnSubGroup.MaxLength = 7;
			columnpromoStatus.MaxLength = 80;
			columnHeadTeacherComments.MaxLength = 80;
			columnDOSComments.MaxLength = 80;
			columnClassTeacherComments.MaxLength = 80;
			columnComment4.MaxLength = 80;
			columnCategoryPoints.MaxLength = 1;
			base.ExtendedProperties.Add("Generator_TablePropName", "_ALevelReportSub");
			base.ExtendedProperties.Add("Generator_UserTableName", "ALevelReportSub");
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public ALevelReportSubRow NewALevelReportSubRow()
		{
			return (ALevelReportSubRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new ALevelReportSubRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(ALevelReportSubRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.ALevelReportSubRowChanged != null)
			{
				this.ALevelReportSubRowChanged(this, new ALevelReportSubRowChangeEvent((ALevelReportSubRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.ALevelReportSubRowChanging != null)
			{
				this.ALevelReportSubRowChanging(this, new ALevelReportSubRowChangeEvent((ALevelReportSubRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.ALevelReportSubRowDeleted != null)
			{
				this.ALevelReportSubRowDeleted(this, new ALevelReportSubRowChangeEvent((ALevelReportSubRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.ALevelReportSubRowDeleting != null)
			{
				this.ALevelReportSubRowDeleting(this, new ALevelReportSubRowChangeEvent((ALevelReportSubRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveALevelReportSubRow(ALevelReportSubRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			ALevelReportSub aLevelReportSub = new ALevelReportSub();
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
			xmlSchemaAttribute.FixedValue = aLevelReportSub.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "ALevelReportSubDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = aLevelReportSub.GetSchemaSerializable();
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

	public class ALevelReportSubRow : DataRow
	{
		private ALevelReportSubDataTable tableALevelReportSub;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long id
		{
			get
			{
				return (long)base[tableALevelReportSub.idColumn];
			}
			set
			{
				base[tableALevelReportSub.idColumn] = value;
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
					return (string)base[tableALevelReportSub.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.StudentNumberColumn] = value;
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
					return (string)base[tableALevelReportSub.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.SemesterIdColumn] = value;
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
					return (string)base[tableALevelReportSub.SubjectIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectId' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.SubjectIdColumn] = value;
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
					return (string)base[tableALevelReportSub.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.ClassIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Paper
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.PaperColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Paper' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.PaperColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HoP
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.HoPColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HoP' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.HoPColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string BOT
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.BOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BOT' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.BOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string MOT
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.MOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MOT' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.MOTColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string EOT
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.EOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EOT' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.EOTColumn] = value;
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
					return (double)base[tableALevelReportSub.AvMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvMark' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.AvMarkColumn] = value;
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
					return (string)base[tableALevelReportSub.CategoryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Category' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.CategoryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Grade
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.GradeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Grade' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.GradeColumn] = value;
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
					return (string)base[tableALevelReportSub.CommentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.CommentColumn] = value;
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
					return (string)base[tableALevelReportSub.InitialColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Initial' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.InitialColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SubGroup
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.SubGroupColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubGroup' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.SubGroupColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double Points
		{
			get
			{
				try
				{
					return (double)base[tableALevelReportSub.PointsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Points' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.PointsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string promoStatus
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.promoStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'promoStatus' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.promoStatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HeadTeacherComments
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.HeadTeacherCommentsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeadTeacherComments' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.HeadTeacherCommentsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string DOSComments
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.DOSCommentsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DOSComments' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.DOSCommentsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassTeacherComments
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.ClassTeacherCommentsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassTeacherComments' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.ClassTeacherCommentsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Comment4
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.Comment4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment4' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.Comment4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double AverageMark
		{
			get
			{
				try
				{
					return (double)base[tableALevelReportSub.AverageMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AverageMark' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.AverageMarkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string CategoryPoints
		{
			get
			{
				try
				{
					return (string)base[tableALevelReportSub.CategoryPointsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CategoryPoints' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.CategoryPointsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double Totals
		{
			get
			{
				try
				{
					return (double)base[tableALevelReportSub.TotalsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Totals' in table 'ALevelReportSub' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableALevelReportSub.TotalsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal ALevelReportSubRow(DataRowBuilder rb)
			: base(rb)
		{
			tableALevelReportSub = (ALevelReportSubDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tableALevelReportSub.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tableALevelReportSub.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tableALevelReportSub.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tableALevelReportSub.SemesterIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectIdNull()
		{
			return IsNull(tableALevelReportSub.SubjectIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectIdNull()
		{
			base[tableALevelReportSub.SubjectIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tableALevelReportSub.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tableALevelReportSub.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPaperNull()
		{
			return IsNull(tableALevelReportSub.PaperColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPaperNull()
		{
			base[tableALevelReportSub.PaperColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHoPNull()
		{
			return IsNull(tableALevelReportSub.HoPColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHoPNull()
		{
			base[tableALevelReportSub.HoPColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBOTNull()
		{
			return IsNull(tableALevelReportSub.BOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBOTNull()
		{
			base[tableALevelReportSub.BOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsMOTNull()
		{
			return IsNull(tableALevelReportSub.MOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetMOTNull()
		{
			base[tableALevelReportSub.MOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsEOTNull()
		{
			return IsNull(tableALevelReportSub.EOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetEOTNull()
		{
			base[tableALevelReportSub.EOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvMarkNull()
		{
			return IsNull(tableALevelReportSub.AvMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvMarkNull()
		{
			base[tableALevelReportSub.AvMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCategoryNull()
		{
			return IsNull(tableALevelReportSub.CategoryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCategoryNull()
		{
			base[tableALevelReportSub.CategoryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGradeNull()
		{
			return IsNull(tableALevelReportSub.GradeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGradeNull()
		{
			base[tableALevelReportSub.GradeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCommentNull()
		{
			return IsNull(tableALevelReportSub.CommentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCommentNull()
		{
			base[tableALevelReportSub.CommentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsInitialNull()
		{
			return IsNull(tableALevelReportSub.InitialColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetInitialNull()
		{
			base[tableALevelReportSub.InitialColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubGroupNull()
		{
			return IsNull(tableALevelReportSub.SubGroupColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubGroupNull()
		{
			base[tableALevelReportSub.SubGroupColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPointsNull()
		{
			return IsNull(tableALevelReportSub.PointsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPointsNull()
		{
			base[tableALevelReportSub.PointsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IspromoStatusNull()
		{
			return IsNull(tableALevelReportSub.promoStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetpromoStatusNull()
		{
			base[tableALevelReportSub.promoStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHeadTeacherCommentsNull()
		{
			return IsNull(tableALevelReportSub.HeadTeacherCommentsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHeadTeacherCommentsNull()
		{
			base[tableALevelReportSub.HeadTeacherCommentsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDOSCommentsNull()
		{
			return IsNull(tableALevelReportSub.DOSCommentsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDOSCommentsNull()
		{
			base[tableALevelReportSub.DOSCommentsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassTeacherCommentsNull()
		{
			return IsNull(tableALevelReportSub.ClassTeacherCommentsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassTeacherCommentsNull()
		{
			base[tableALevelReportSub.ClassTeacherCommentsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsComment4Null()
		{
			return IsNull(tableALevelReportSub.Comment4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetComment4Null()
		{
			base[tableALevelReportSub.Comment4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAverageMarkNull()
		{
			return IsNull(tableALevelReportSub.AverageMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAverageMarkNull()
		{
			base[tableALevelReportSub.AverageMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCategoryPointsNull()
		{
			return IsNull(tableALevelReportSub.CategoryPointsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCategoryPointsNull()
		{
			base[tableALevelReportSub.CategoryPointsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTotalsNull()
		{
			return IsNull(tableALevelReportSub.TotalsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTotalsNull()
		{
			base[tableALevelReportSub.TotalsColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class ALevelReportSubRowChangeEvent : EventArgs
	{
		private ALevelReportSubRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public ALevelReportSubRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public ALevelReportSubRowChangeEvent(ALevelReportSubRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private ALevelReportSubDataTable tableALevelReportSub;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public ALevelReportSubDataTable _ALevelReportSub => tableALevelReportSub;

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
	public ALevelReportSub()
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
	protected ALevelReportSub(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["ALevelReportSub"] != null)
			{
				base.Tables.Add(new ALevelReportSubDataTable(dataSet.Tables["ALevelReportSub"]));
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
		ALevelReportSub aLevelReportSub = (ALevelReportSub)base.Clone();
		aLevelReportSub.InitVars();
		aLevelReportSub.SchemaSerializationMode = SchemaSerializationMode;
		return aLevelReportSub;
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
			if (dataSet.Tables["ALevelReportSub"] != null)
			{
				base.Tables.Add(new ALevelReportSubDataTable(dataSet.Tables["ALevelReportSub"]));
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
		tableALevelReportSub = (ALevelReportSubDataTable)base.Tables["ALevelReportSub"];
		if (initTable && tableALevelReportSub != null)
		{
			tableALevelReportSub.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "ALevelReportSub";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/ALevelReportSub.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableALevelReportSub = new ALevelReportSubDataTable();
		base.Tables.Add(tableALevelReportSub);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerialize_ALevelReportSub()
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
		ALevelReportSub aLevelReportSub = new ALevelReportSub();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = aLevelReportSub.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = aLevelReportSub.GetSchemaSerializable();
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
