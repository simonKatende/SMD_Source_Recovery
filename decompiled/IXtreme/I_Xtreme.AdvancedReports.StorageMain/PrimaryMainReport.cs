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

namespace I_Xtreme.AdvancedReports.StorageMain;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("PrimaryMainReport")]
[HelpKeyword("vs.data.DataSet")]
public class PrimaryMainReport : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void PrimaryMainReportRowChangeEventHandler(object sender, PrimaryMainReportRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class PrimaryMainReportDataTable : TypedTableBase<PrimaryMainReportRow>
	{
		private DataColumn columnStudentNumber;

		private DataColumn columnfullName;

		private DataColumn columnClassId;

		private DataColumn columnStreamId;

		private DataColumn columnSex;

		private DataColumn columnStudyStatus;

		private DataColumn columnHouseId;

		private DataColumn columnReligion;

		private DataColumn columnPicture;

		private DataColumn columnRequiredFees;

		private DataColumn columncashOnAccount;

		private DataColumn columnFeesDiscount;

		private DataColumn columnPosition;

		private DataColumn columnOutOf;

		private DataColumn columnPositionInStream;

		private DataColumn columnStudentsInStream;

		private DataColumn columnBestinEight;

		private DataColumn columnAgg;

		private DataColumn columnDiv;

		private DataColumn columnClassTeacherComment;

		private DataColumn columnHeadTeacherComment;

		private DataColumn columnDOSComment;

		private DataColumn columnComment4;

		private DataColumn columnTotalMark;

		private DataColumn columnAvMark;

		private DataColumn columnpromoStatus;

		private DataColumn columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fullNameColumn => columnfullName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdColumn => columnClassId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamIdColumn => columnStreamId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SexColumn => columnSex;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudyStatusColumn => columnStudyStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HouseIdColumn => columnHouseId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ReligionColumn => columnReligion;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PictureColumn => columnPicture;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn RequiredFeesColumn => columnRequiredFees;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn cashOnAccountColumn => columncashOnAccount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FeesDiscountColumn => columnFeesDiscount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PositionColumn => columnPosition;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OutOfColumn => columnOutOf;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PositionInStreamColumn => columnPositionInStream;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentsInStreamColumn => columnStudentsInStream;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn BestinEightColumn => columnBestinEight;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AggColumn => columnAgg;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DivColumn => columnDiv;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassTeacherCommentColumn => columnClassTeacherComment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HeadTeacherCommentColumn => columnHeadTeacherComment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DOSCommentColumn => columnDOSComment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Comment4Column => columnComment4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn TotalMarkColumn => columnTotalMark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AvMarkColumn => columnAvMark;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn promoStatusColumn => columnpromoStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SemesterIdColumn => columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryMainReportRow this[int index] => (PrimaryMainReportRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryMainReportRowChangeEventHandler PrimaryMainReportRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryMainReportRowChangeEventHandler PrimaryMainReportRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryMainReportRowChangeEventHandler PrimaryMainReportRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryMainReportRowChangeEventHandler PrimaryMainReportRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryMainReportDataTable()
		{
			base.TableName = "PrimaryMainReport";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal PrimaryMainReportDataTable(DataTable table)
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
		protected PrimaryMainReportDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddPrimaryMainReportRow(PrimaryMainReportRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryMainReportRow AddPrimaryMainReportRow(string StudentNumber, string fullName, string ClassId, string StreamId, string Sex, string StudyStatus, string HouseId, string Religion, byte[] Picture, decimal RequiredFees, decimal cashOnAccount, decimal FeesDiscount, int Position, int OutOf, int PositionInStream, int StudentsInStream, int BestinEight, int Agg, string Div, string ClassTeacherComment, string HeadTeacherComment, string DOSComment, string Comment4, double TotalMark, double AvMark, string promoStatus, string SemesterId)
		{
			PrimaryMainReportRow primaryMainReportRow = (PrimaryMainReportRow)NewRow();
			object[] itemArray = new object[27]
			{
				StudentNumber, fullName, ClassId, StreamId, Sex, StudyStatus, HouseId, Religion, Picture, RequiredFees,
				cashOnAccount, FeesDiscount, Position, OutOf, PositionInStream, StudentsInStream, BestinEight, Agg, Div, ClassTeacherComment,
				HeadTeacherComment, DOSComment, Comment4, TotalMark, AvMark, promoStatus, SemesterId
			};
			primaryMainReportRow.ItemArray = itemArray;
			base.Rows.Add(primaryMainReportRow);
			return primaryMainReportRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			PrimaryMainReportDataTable primaryMainReportDataTable = (PrimaryMainReportDataTable)base.Clone();
			primaryMainReportDataTable.InitVars();
			return primaryMainReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new PrimaryMainReportDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnStudentNumber = base.Columns["StudentNumber"];
			columnfullName = base.Columns["fullName"];
			columnClassId = base.Columns["ClassId"];
			columnStreamId = base.Columns["StreamId"];
			columnSex = base.Columns["Sex"];
			columnStudyStatus = base.Columns["StudyStatus"];
			columnHouseId = base.Columns["HouseId"];
			columnReligion = base.Columns["Religion"];
			columnPicture = base.Columns["Picture"];
			columnRequiredFees = base.Columns["RequiredFees"];
			columncashOnAccount = base.Columns["cashOnAccount"];
			columnFeesDiscount = base.Columns["FeesDiscount"];
			columnPosition = base.Columns["Position"];
			columnOutOf = base.Columns["OutOf"];
			columnPositionInStream = base.Columns["PositionInStream"];
			columnStudentsInStream = base.Columns["StudentsInStream"];
			columnBestinEight = base.Columns["BestinEight"];
			columnAgg = base.Columns["Agg"];
			columnDiv = base.Columns["Div"];
			columnClassTeacherComment = base.Columns["ClassTeacherComment"];
			columnHeadTeacherComment = base.Columns["HeadTeacherComment"];
			columnDOSComment = base.Columns["DOSComment"];
			columnComment4 = base.Columns["Comment4"];
			columnTotalMark = base.Columns["TotalMark"];
			columnAvMark = base.Columns["AvMark"];
			columnpromoStatus = base.Columns["promoStatus"];
			columnSemesterId = base.Columns["SemesterId"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnfullName = new DataColumn("fullName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfullName);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
			columnStreamId = new DataColumn("StreamId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStreamId);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnStudyStatus = new DataColumn("StudyStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudyStatus);
			columnHouseId = new DataColumn("HouseId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHouseId);
			columnReligion = new DataColumn("Religion", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnReligion);
			columnPicture = new DataColumn("Picture", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPicture);
			columnRequiredFees = new DataColumn("RequiredFees", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnRequiredFees);
			columncashOnAccount = new DataColumn("cashOnAccount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columncashOnAccount);
			columnFeesDiscount = new DataColumn("FeesDiscount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnFeesDiscount);
			columnPosition = new DataColumn("Position", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPosition);
			columnOutOf = new DataColumn("OutOf", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnOutOf);
			columnPositionInStream = new DataColumn("PositionInStream", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnPositionInStream);
			columnStudentsInStream = new DataColumn("StudentsInStream", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnStudentsInStream);
			columnBestinEight = new DataColumn("BestinEight", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnBestinEight);
			columnAgg = new DataColumn("Agg", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnAgg);
			columnDiv = new DataColumn("Div", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDiv);
			columnClassTeacherComment = new DataColumn("ClassTeacherComment", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassTeacherComment);
			columnHeadTeacherComment = new DataColumn("HeadTeacherComment", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHeadTeacherComment);
			columnDOSComment = new DataColumn("DOSComment", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDOSComment);
			columnComment4 = new DataColumn("Comment4", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnComment4);
			columnTotalMark = new DataColumn("TotalMark", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnTotalMark);
			columnAvMark = new DataColumn("AvMark", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnAvMark);
			columnpromoStatus = new DataColumn("promoStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnpromoStatus);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnStudentNumber.AllowDBNull = false;
			columnStudentNumber.MaxLength = 12;
			columnfullName.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnStreamId.MaxLength = 8;
			columnSex.MaxLength = 1;
			columnStudyStatus.MaxLength = 1;
			columnHouseId.MaxLength = 25;
			columnReligion.MaxLength = 15;
			columnDiv.MaxLength = 3;
			columnClassTeacherComment.MaxLength = 80;
			columnHeadTeacherComment.MaxLength = 80;
			columnDOSComment.MaxLength = 80;
			columnComment4.MaxLength = 80;
			columnpromoStatus.MaxLength = 50;
			columnSemesterId.MaxLength = 12;
			base.ExtendedProperties.Add("Generator_TablePropName", "_PrimaryMainReport");
			base.ExtendedProperties.Add("Generator_UserTableName", "PrimaryMainReport");
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryMainReportRow NewPrimaryMainReportRow()
		{
			return (PrimaryMainReportRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new PrimaryMainReportRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(PrimaryMainReportRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PrimaryMainReportRowChanged != null)
			{
				this.PrimaryMainReportRowChanged(this, new PrimaryMainReportRowChangeEvent((PrimaryMainReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PrimaryMainReportRowChanging != null)
			{
				this.PrimaryMainReportRowChanging(this, new PrimaryMainReportRowChangeEvent((PrimaryMainReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PrimaryMainReportRowDeleted != null)
			{
				this.PrimaryMainReportRowDeleted(this, new PrimaryMainReportRowChangeEvent((PrimaryMainReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PrimaryMainReportRowDeleting != null)
			{
				this.PrimaryMainReportRowDeleting(this, new PrimaryMainReportRowChangeEvent((PrimaryMainReportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemovePrimaryMainReportRow(PrimaryMainReportRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			PrimaryMainReport primaryMainReport = new PrimaryMainReport();
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
			xmlSchemaAttribute.FixedValue = primaryMainReport.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "PrimaryMainReportDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = primaryMainReport.GetSchemaSerializable();
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

	public class PrimaryMainReportRow : DataRow
	{
		private PrimaryMainReportDataTable tablePrimaryMainReport;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				return (string)base[tablePrimaryMainReport.StudentNumberColumn];
			}
			set
			{
				base[tablePrimaryMainReport.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fullName
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.fullNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullName' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.fullNameColumn] = value;
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
					return (string)base[tablePrimaryMainReport.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.ClassIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StreamId
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.StreamIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Sex
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.SexColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudyStatus
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.StudyStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudyStatus' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.StudyStatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HouseId
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.HouseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseId' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.HouseIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Religion
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.ReligionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Religion' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.ReligionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public byte[] Picture
		{
			get
			{
				try
				{
					return (byte[])base[tablePrimaryMainReport.PictureColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Picture' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.PictureColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal RequiredFees
		{
			get
			{
				try
				{
					return (decimal)base[tablePrimaryMainReport.RequiredFeesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RequiredFees' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.RequiredFeesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal cashOnAccount
		{
			get
			{
				try
				{
					return (decimal)base[tablePrimaryMainReport.cashOnAccountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'cashOnAccount' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.cashOnAccountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal FeesDiscount
		{
			get
			{
				try
				{
					return (decimal)base[tablePrimaryMainReport.FeesDiscountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FeesDiscount' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.FeesDiscountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int Position
		{
			get
			{
				try
				{
					return (int)base[tablePrimaryMainReport.PositionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Position' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.PositionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int OutOf
		{
			get
			{
				try
				{
					return (int)base[tablePrimaryMainReport.OutOfColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OutOf' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.OutOfColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int PositionInStream
		{
			get
			{
				try
				{
					return (int)base[tablePrimaryMainReport.PositionInStreamColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PositionInStream' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.PositionInStreamColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int StudentsInStream
		{
			get
			{
				try
				{
					return (int)base[tablePrimaryMainReport.StudentsInStreamColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentsInStream' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.StudentsInStreamColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int BestinEight
		{
			get
			{
				try
				{
					return (int)base[tablePrimaryMainReport.BestinEightColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BestinEight' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.BestinEightColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int Agg
		{
			get
			{
				try
				{
					return (int)base[tablePrimaryMainReport.AggColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Agg' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.AggColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Div
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.DivColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Div' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.DivColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassTeacherComment
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.ClassTeacherCommentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassTeacherComment' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.ClassTeacherCommentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HeadTeacherComment
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.HeadTeacherCommentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HeadTeacherComment' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.HeadTeacherCommentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string DOSComment
		{
			get
			{
				try
				{
					return (string)base[tablePrimaryMainReport.DOSCommentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DOSComment' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.DOSCommentColumn] = value;
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
					return (string)base[tablePrimaryMainReport.Comment4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment4' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.Comment4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double TotalMark
		{
			get
			{
				try
				{
					return (double)base[tablePrimaryMainReport.TotalMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'TotalMark' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.TotalMarkColumn] = value;
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
					return (double)base[tablePrimaryMainReport.AvMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvMark' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.AvMarkColumn] = value;
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
					return (string)base[tablePrimaryMainReport.promoStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'promoStatus' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.promoStatusColumn] = value;
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
					return (string)base[tablePrimaryMainReport.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'PrimaryMainReport' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryMainReport.SemesterIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal PrimaryMainReportRow(DataRowBuilder rb)
			: base(rb)
		{
			tablePrimaryMainReport = (PrimaryMainReportDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameNull()
		{
			return IsNull(tablePrimaryMainReport.fullNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameNull()
		{
			base[tablePrimaryMainReport.fullNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tablePrimaryMainReport.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tablePrimaryMainReport.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tablePrimaryMainReport.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tablePrimaryMainReport.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tablePrimaryMainReport.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tablePrimaryMainReport.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudyStatusNull()
		{
			return IsNull(tablePrimaryMainReport.StudyStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudyStatusNull()
		{
			base[tablePrimaryMainReport.StudyStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHouseIdNull()
		{
			return IsNull(tablePrimaryMainReport.HouseIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHouseIdNull()
		{
			base[tablePrimaryMainReport.HouseIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsReligionNull()
		{
			return IsNull(tablePrimaryMainReport.ReligionColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetReligionNull()
		{
			base[tablePrimaryMainReport.ReligionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPictureNull()
		{
			return IsNull(tablePrimaryMainReport.PictureColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPictureNull()
		{
			base[tablePrimaryMainReport.PictureColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsRequiredFeesNull()
		{
			return IsNull(tablePrimaryMainReport.RequiredFeesColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetRequiredFeesNull()
		{
			base[tablePrimaryMainReport.RequiredFeesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IscashOnAccountNull()
		{
			return IsNull(tablePrimaryMainReport.cashOnAccountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetcashOnAccountNull()
		{
			base[tablePrimaryMainReport.cashOnAccountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFeesDiscountNull()
		{
			return IsNull(tablePrimaryMainReport.FeesDiscountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFeesDiscountNull()
		{
			base[tablePrimaryMainReport.FeesDiscountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPositionNull()
		{
			return IsNull(tablePrimaryMainReport.PositionColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPositionNull()
		{
			base[tablePrimaryMainReport.PositionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOutOfNull()
		{
			return IsNull(tablePrimaryMainReport.OutOfColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOutOfNull()
		{
			base[tablePrimaryMainReport.OutOfColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPositionInStreamNull()
		{
			return IsNull(tablePrimaryMainReport.PositionInStreamColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPositionInStreamNull()
		{
			base[tablePrimaryMainReport.PositionInStreamColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentsInStreamNull()
		{
			return IsNull(tablePrimaryMainReport.StudentsInStreamColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentsInStreamNull()
		{
			base[tablePrimaryMainReport.StudentsInStreamColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBestinEightNull()
		{
			return IsNull(tablePrimaryMainReport.BestinEightColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBestinEightNull()
		{
			base[tablePrimaryMainReport.BestinEightColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAggNull()
		{
			return IsNull(tablePrimaryMainReport.AggColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAggNull()
		{
			base[tablePrimaryMainReport.AggColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDivNull()
		{
			return IsNull(tablePrimaryMainReport.DivColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDivNull()
		{
			base[tablePrimaryMainReport.DivColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassTeacherCommentNull()
		{
			return IsNull(tablePrimaryMainReport.ClassTeacherCommentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassTeacherCommentNull()
		{
			base[tablePrimaryMainReport.ClassTeacherCommentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHeadTeacherCommentNull()
		{
			return IsNull(tablePrimaryMainReport.HeadTeacherCommentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHeadTeacherCommentNull()
		{
			base[tablePrimaryMainReport.HeadTeacherCommentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDOSCommentNull()
		{
			return IsNull(tablePrimaryMainReport.DOSCommentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDOSCommentNull()
		{
			base[tablePrimaryMainReport.DOSCommentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsComment4Null()
		{
			return IsNull(tablePrimaryMainReport.Comment4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetComment4Null()
		{
			base[tablePrimaryMainReport.Comment4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTotalMarkNull()
		{
			return IsNull(tablePrimaryMainReport.TotalMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetTotalMarkNull()
		{
			base[tablePrimaryMainReport.TotalMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvMarkNull()
		{
			return IsNull(tablePrimaryMainReport.AvMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvMarkNull()
		{
			base[tablePrimaryMainReport.AvMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IspromoStatusNull()
		{
			return IsNull(tablePrimaryMainReport.promoStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetpromoStatusNull()
		{
			base[tablePrimaryMainReport.promoStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tablePrimaryMainReport.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tablePrimaryMainReport.SemesterIdColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class PrimaryMainReportRowChangeEvent : EventArgs
	{
		private PrimaryMainReportRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryMainReportRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryMainReportRowChangeEvent(PrimaryMainReportRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private PrimaryMainReportDataTable tablePrimaryMainReport;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PrimaryMainReportDataTable _PrimaryMainReport => tablePrimaryMainReport;

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
	public PrimaryMainReport()
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
	protected PrimaryMainReport(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["PrimaryMainReport"] != null)
			{
				base.Tables.Add(new PrimaryMainReportDataTable(dataSet.Tables["PrimaryMainReport"]));
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
		PrimaryMainReport primaryMainReport = (PrimaryMainReport)base.Clone();
		primaryMainReport.InitVars();
		primaryMainReport.SchemaSerializationMode = SchemaSerializationMode;
		return primaryMainReport;
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
			if (dataSet.Tables["PrimaryMainReport"] != null)
			{
				base.Tables.Add(new PrimaryMainReportDataTable(dataSet.Tables["PrimaryMainReport"]));
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
		tablePrimaryMainReport = (PrimaryMainReportDataTable)base.Tables["PrimaryMainReport"];
		if (initTable && tablePrimaryMainReport != null)
		{
			tablePrimaryMainReport.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "PrimaryMainReport";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PrimaryMainReport.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tablePrimaryMainReport = new PrimaryMainReportDataTable();
		base.Tables.Add(tablePrimaryMainReport);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerialize_PrimaryMainReport()
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
		PrimaryMainReport primaryMainReport = new PrimaryMainReport();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = primaryMainReport.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = primaryMainReport.GetSchemaSerializable();
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
