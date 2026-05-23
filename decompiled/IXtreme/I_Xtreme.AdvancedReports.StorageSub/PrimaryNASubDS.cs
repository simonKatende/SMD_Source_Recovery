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
[XmlRoot("PrimaryNASubDS")]
[HelpKeyword("vs.data.DataSet")]
public class PrimaryNASubDS : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void PrimaryNASubDSRowChangeEventHandler(object sender, PrimaryNASubDSRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class PrimaryNASubDSDataTable : TypedTableBase<PrimaryNASubDSRow>
	{
		private DataColumn columnid;

		private DataColumn columnStudentNumber;

		private DataColumn columnSubjectId;

		private DataColumn columnClassId;

		private DataColumn columnHoP;

		private DataColumn columnBOT;

		private DataColumn columnMOT;

		private DataColumn columnEOT;

		private DataColumn columnAvMark;

		private DataColumn columnGrade;

		private DataColumn columnCategory;

		private DataColumn columnInitial;

		private DataColumn columnSemesterId;

		private DataColumn columnComment;

		private DataColumn columnIsAssessed;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn idColumn => columnid;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectIdColumn => columnSubjectId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdColumn => columnClassId;

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
		public DataColumn GradeColumn => columnGrade;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CategoryColumn => columnCategory;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn InitialColumn => columnInitial;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SemesterIdColumn => columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CommentColumn => columnComment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IsAssessedColumn => columnIsAssessed;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSRow this[int index] => (PrimaryNASubDSRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryNASubDSRowChangeEventHandler PrimaryNASubDSRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryNASubDSRowChangeEventHandler PrimaryNASubDSRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryNASubDSRowChangeEventHandler PrimaryNASubDSRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PrimaryNASubDSRowChangeEventHandler PrimaryNASubDSRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSDataTable()
		{
			base.TableName = "PrimaryNASubDS";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal PrimaryNASubDSDataTable(DataTable table)
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
		protected PrimaryNASubDSDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddPrimaryNASubDSRow(PrimaryNASubDSRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSRow AddPrimaryNASubDSRow(string StudentNumber, string SubjectId, string ClassId, string HoP, string BOT, string MOT, string EOT, double AvMark, int Grade, string Category, string Initial, string SemesterId, string Comment, bool IsAssessed)
		{
			PrimaryNASubDSRow primaryNASubDSRow = (PrimaryNASubDSRow)NewRow();
			object[] itemArray = new object[15]
			{
				null, StudentNumber, SubjectId, ClassId, HoP, BOT, MOT, EOT, AvMark, Grade,
				Category, Initial, SemesterId, Comment, IsAssessed
			};
			primaryNASubDSRow.ItemArray = itemArray;
			base.Rows.Add(primaryNASubDSRow);
			return primaryNASubDSRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSRow FindByid(long id)
		{
			return (PrimaryNASubDSRow)base.Rows.Find(new object[1] { id });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			PrimaryNASubDSDataTable primaryNASubDSDataTable = (PrimaryNASubDSDataTable)base.Clone();
			primaryNASubDSDataTable.InitVars();
			return primaryNASubDSDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new PrimaryNASubDSDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnid = base.Columns["id"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnSubjectId = base.Columns["SubjectId"];
			columnClassId = base.Columns["ClassId"];
			columnHoP = base.Columns["HoP"];
			columnBOT = base.Columns["BOT"];
			columnMOT = base.Columns["MOT"];
			columnEOT = base.Columns["EOT"];
			columnAvMark = base.Columns["AvMark"];
			columnGrade = base.Columns["Grade"];
			columnCategory = base.Columns["Category"];
			columnInitial = base.Columns["Initial"];
			columnSemesterId = base.Columns["SemesterId"];
			columnComment = base.Columns["Comment"];
			columnIsAssessed = base.Columns["IsAssessed"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnid = new DataColumn("id", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnid);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnSubjectId = new DataColumn("SubjectId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectId);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
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
			columnGrade = new DataColumn("Grade", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnGrade);
			columnCategory = new DataColumn("Category", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCategory);
			columnInitial = new DataColumn("Initial", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnInitial);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnComment = new DataColumn("Comment", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnComment);
			columnIsAssessed = new DataColumn("IsAssessed", typeof(bool), null, MappingType.Element);
			base.Columns.Add(columnIsAssessed);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnid }, isPrimaryKey: true));
			columnid.AutoIncrement = true;
			columnid.AutoIncrementSeed = -1L;
			columnid.AutoIncrementStep = -1L;
			columnid.AllowDBNull = false;
			columnid.ReadOnly = true;
			columnid.Unique = true;
			columnStudentNumber.MaxLength = 12;
			columnSubjectId.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnHoP.MaxLength = 4;
			columnBOT.MaxLength = 4;
			columnMOT.MaxLength = 4;
			columnEOT.MaxLength = 4;
			columnCategory.MaxLength = 3;
			columnInitial.MaxLength = 3;
			columnSemesterId.MaxLength = 12;
			columnComment.MaxLength = 100;
			base.ExtendedProperties.Add("Generator_TablePropName", "_PrimaryNASubDS");
			base.ExtendedProperties.Add("Generator_UserTableName", "PrimaryNASubDS");
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSRow NewPrimaryNASubDSRow()
		{
			return (PrimaryNASubDSRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new PrimaryNASubDSRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(PrimaryNASubDSRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PrimaryNASubDSRowChanged != null)
			{
				this.PrimaryNASubDSRowChanged(this, new PrimaryNASubDSRowChangeEvent((PrimaryNASubDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PrimaryNASubDSRowChanging != null)
			{
				this.PrimaryNASubDSRowChanging(this, new PrimaryNASubDSRowChangeEvent((PrimaryNASubDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PrimaryNASubDSRowDeleted != null)
			{
				this.PrimaryNASubDSRowDeleted(this, new PrimaryNASubDSRowChangeEvent((PrimaryNASubDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PrimaryNASubDSRowDeleting != null)
			{
				this.PrimaryNASubDSRowDeleting(this, new PrimaryNASubDSRowChangeEvent((PrimaryNASubDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemovePrimaryNASubDSRow(PrimaryNASubDSRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			PrimaryNASubDS primaryNASubDS = new PrimaryNASubDS();
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
			xmlSchemaAttribute.FixedValue = primaryNASubDS.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "PrimaryNASubDSDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = primaryNASubDS.GetSchemaSerializable();
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

	public class PrimaryNASubDSRow : DataRow
	{
		private PrimaryNASubDSDataTable tablePrimaryNASubDS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long id
		{
			get
			{
				return (long)base[tablePrimaryNASubDS.idColumn];
			}
			set
			{
				base[tablePrimaryNASubDS.idColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.StudentNumberColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.SubjectIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectId' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.SubjectIdColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.ClassIdColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.HoPColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HoP' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.HoPColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.BOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BOT' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.BOTColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.MOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'MOT' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.MOTColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.EOTColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EOT' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.EOTColumn] = value;
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
					return (double)base[tablePrimaryNASubDS.AvMarkColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AvMark' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.AvMarkColumn] = value;
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
					return (int)base[tablePrimaryNASubDS.GradeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Grade' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.GradeColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.CategoryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Category' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.CategoryColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.InitialColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Initial' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.InitialColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.SemesterIdColumn] = value;
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
					return (string)base[tablePrimaryNASubDS.CommentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comment' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.CommentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAssessed
		{
			get
			{
				try
				{
					return (bool)base[tablePrimaryNASubDS.IsAssessedColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsAssessed' in table 'PrimaryNASubDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePrimaryNASubDS.IsAssessedColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal PrimaryNASubDSRow(DataRowBuilder rb)
			: base(rb)
		{
			tablePrimaryNASubDS = (PrimaryNASubDSDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tablePrimaryNASubDS.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tablePrimaryNASubDS.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectIdNull()
		{
			return IsNull(tablePrimaryNASubDS.SubjectIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectIdNull()
		{
			base[tablePrimaryNASubDS.SubjectIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tablePrimaryNASubDS.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tablePrimaryNASubDS.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHoPNull()
		{
			return IsNull(tablePrimaryNASubDS.HoPColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHoPNull()
		{
			base[tablePrimaryNASubDS.HoPColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBOTNull()
		{
			return IsNull(tablePrimaryNASubDS.BOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBOTNull()
		{
			base[tablePrimaryNASubDS.BOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsMOTNull()
		{
			return IsNull(tablePrimaryNASubDS.MOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetMOTNull()
		{
			base[tablePrimaryNASubDS.MOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsEOTNull()
		{
			return IsNull(tablePrimaryNASubDS.EOTColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetEOTNull()
		{
			base[tablePrimaryNASubDS.EOTColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAvMarkNull()
		{
			return IsNull(tablePrimaryNASubDS.AvMarkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAvMarkNull()
		{
			base[tablePrimaryNASubDS.AvMarkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGradeNull()
		{
			return IsNull(tablePrimaryNASubDS.GradeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGradeNull()
		{
			base[tablePrimaryNASubDS.GradeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCategoryNull()
		{
			return IsNull(tablePrimaryNASubDS.CategoryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCategoryNull()
		{
			base[tablePrimaryNASubDS.CategoryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsInitialNull()
		{
			return IsNull(tablePrimaryNASubDS.InitialColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetInitialNull()
		{
			base[tablePrimaryNASubDS.InitialColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tablePrimaryNASubDS.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tablePrimaryNASubDS.SemesterIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCommentNull()
		{
			return IsNull(tablePrimaryNASubDS.CommentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCommentNull()
		{
			base[tablePrimaryNASubDS.CommentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsIsAssessedNull()
		{
			return IsNull(tablePrimaryNASubDS.IsAssessedColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetIsAssessedNull()
		{
			base[tablePrimaryNASubDS.IsAssessedColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class PrimaryNASubDSRowChangeEvent : EventArgs
	{
		private PrimaryNASubDSRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PrimaryNASubDSRowChangeEvent(PrimaryNASubDSRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private PrimaryNASubDSDataTable tablePrimaryNASubDS;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PrimaryNASubDSDataTable _PrimaryNASubDS => tablePrimaryNASubDS;

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
	public PrimaryNASubDS()
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
	protected PrimaryNASubDS(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["PrimaryNASubDS"] != null)
			{
				base.Tables.Add(new PrimaryNASubDSDataTable(dataSet.Tables["PrimaryNASubDS"]));
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
		PrimaryNASubDS primaryNASubDS = (PrimaryNASubDS)base.Clone();
		primaryNASubDS.InitVars();
		primaryNASubDS.SchemaSerializationMode = SchemaSerializationMode;
		return primaryNASubDS;
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
			if (dataSet.Tables["PrimaryNASubDS"] != null)
			{
				base.Tables.Add(new PrimaryNASubDSDataTable(dataSet.Tables["PrimaryNASubDS"]));
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
		tablePrimaryNASubDS = (PrimaryNASubDSDataTable)base.Tables["PrimaryNASubDS"];
		if (initTable && tablePrimaryNASubDS != null)
		{
			tablePrimaryNASubDS.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "PrimaryNASubDS";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PrimaryNASubDS.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tablePrimaryNASubDS = new PrimaryNASubDSDataTable();
		base.Tables.Add(tablePrimaryNASubDS);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerialize_PrimaryNASubDS()
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
		PrimaryNASubDS primaryNASubDS = new PrimaryNASubDS();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = primaryNASubDS.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = primaryNASubDS.GetSchemaSerializable();
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
