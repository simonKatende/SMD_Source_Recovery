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
[XmlRoot("StudentsSourceDS")]
[HelpKeyword("vs.data.DataSet")]
public class StudentsSourceDS : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void StudentsDSRowChangeEventHandler(object sender, StudentsDSRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class StudentsDSDataTable : TypedTableBase<StudentsDSRow>
	{
		private DataColumn columnStudentNumber;

		private DataColumn columnfullName;

		private DataColumn columnClassId;

		private DataColumn columnStreamId;

		private DataColumn columnStudyStatus;

		private DataColumn columnSex;

		private DataColumn columnHouseId;

		private DataColumn columnPicture;

		private DataColumn columncashOnAccount;

		private DataColumn columnPrimaryScores1;

		private DataColumn columnauto;

		private DataColumn columnStudentID;

		private DataColumn columnGamesAndSports;

		private DataColumn columnClubs;

		private DataColumn columnStatus;

		private DataColumn columnLIN;

		private DataColumn columnFeesNextTerm;

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
		public DataColumn StudyStatusColumn => columnStudyStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SexColumn => columnSex;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HouseIdColumn => columnHouseId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PictureColumn => columnPicture;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn cashOnAccountColumn => columncashOnAccount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PrimaryScores1Column => columnPrimaryScores1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn autoColumn => columnauto;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentIDColumn => columnStudentID;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GamesAndSportsColumn => columnGamesAndSports;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClubsColumn => columnClubs;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StatusColumn => columnStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn LINColumn => columnLIN;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FeesNextTermColumn => columnFeesNextTerm;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSRow this[int index] => (StudentsDSRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentsDSRowChangeEventHandler StudentsDSRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentsDSRowChangeEventHandler StudentsDSRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentsDSRowChangeEventHandler StudentsDSRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentsDSRowChangeEventHandler StudentsDSRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSDataTable()
		{
			base.TableName = "StudentsDS";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal StudentsDSDataTable(DataTable table)
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
		protected StudentsDSDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddStudentsDSRow(StudentsDSRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSRow AddStudentsDSRow(string StudentNumber, string fullName, string ClassId, string StreamId, string StudyStatus, string Sex, string HouseId, byte[] Picture, decimal cashOnAccount, string PrimaryScores1, string StudentID, string GamesAndSports, string Clubs, string Status, string LIN, decimal FeesNextTerm)
		{
			StudentsDSRow studentsDSRow = (StudentsDSRow)NewRow();
			object[] itemArray = new object[17]
			{
				StudentNumber, fullName, ClassId, StreamId, StudyStatus, Sex, HouseId, Picture, cashOnAccount, PrimaryScores1,
				null, StudentID, GamesAndSports, Clubs, Status, LIN, FeesNextTerm
			};
			studentsDSRow.ItemArray = itemArray;
			base.Rows.Add(studentsDSRow);
			return studentsDSRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSRow FindByauto(long auto)
		{
			return (StudentsDSRow)base.Rows.Find(new object[1] { auto });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			StudentsDSDataTable studentsDSDataTable = (StudentsDSDataTable)base.Clone();
			studentsDSDataTable.InitVars();
			return studentsDSDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new StudentsDSDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnStudentNumber = base.Columns["StudentNumber"];
			columnfullName = base.Columns["fullName"];
			columnClassId = base.Columns["ClassId"];
			columnStreamId = base.Columns["StreamId"];
			columnStudyStatus = base.Columns["StudyStatus"];
			columnSex = base.Columns["Sex"];
			columnHouseId = base.Columns["HouseId"];
			columnPicture = base.Columns["Picture"];
			columncashOnAccount = base.Columns["cashOnAccount"];
			columnPrimaryScores1 = base.Columns["PrimaryScores1"];
			columnauto = base.Columns["auto"];
			columnStudentID = base.Columns["StudentID"];
			columnGamesAndSports = base.Columns["GamesAndSports"];
			columnClubs = base.Columns["Clubs"];
			columnStatus = base.Columns["Status"];
			columnLIN = base.Columns["LIN"];
			columnFeesNextTerm = base.Columns["FeesNextTerm"];
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
			columnStudyStatus = new DataColumn("StudyStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudyStatus);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnHouseId = new DataColumn("HouseId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHouseId);
			columnPicture = new DataColumn("Picture", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPicture);
			columncashOnAccount = new DataColumn("cashOnAccount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columncashOnAccount);
			columnPrimaryScores1 = new DataColumn("PrimaryScores1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPrimaryScores1);
			columnauto = new DataColumn("auto", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnauto);
			columnStudentID = new DataColumn("StudentID", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentID);
			columnGamesAndSports = new DataColumn("GamesAndSports", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGamesAndSports);
			columnClubs = new DataColumn("Clubs", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClubs);
			columnStatus = new DataColumn("Status", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStatus);
			columnLIN = new DataColumn("LIN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLIN);
			columnFeesNextTerm = new DataColumn("FeesNextTerm", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnFeesNextTerm);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnauto }, isPrimaryKey: true));
			columnStudentNumber.AllowDBNull = false;
			columnStudentNumber.MaxLength = 12;
			columnfullName.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnStreamId.MaxLength = 8;
			columnStudyStatus.MaxLength = 1;
			columnSex.MaxLength = 1;
			columnHouseId.MaxLength = 25;
			columnPrimaryScores1.MaxLength = 50;
			columnauto.AutoIncrement = true;
			columnauto.AutoIncrementSeed = -1L;
			columnauto.AutoIncrementStep = -1L;
			columnauto.AllowDBNull = false;
			columnauto.ReadOnly = true;
			columnauto.Unique = true;
			columnStudentID.MaxLength = 12;
			columnGamesAndSports.MaxLength = 2000;
			columnClubs.MaxLength = 2000;
			columnStatus.MaxLength = 15;
			columnLIN.MaxLength = 50;
			columnFeesNextTerm.ReadOnly = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSRow NewStudentsDSRow()
		{
			return (StudentsDSRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new StudentsDSRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(StudentsDSRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.StudentsDSRowChanged != null)
			{
				this.StudentsDSRowChanged(this, new StudentsDSRowChangeEvent((StudentsDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.StudentsDSRowChanging != null)
			{
				this.StudentsDSRowChanging(this, new StudentsDSRowChangeEvent((StudentsDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.StudentsDSRowDeleted != null)
			{
				this.StudentsDSRowDeleted(this, new StudentsDSRowChangeEvent((StudentsDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.StudentsDSRowDeleting != null)
			{
				this.StudentsDSRowDeleting(this, new StudentsDSRowChangeEvent((StudentsDSRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveStudentsDSRow(StudentsDSRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			StudentsSourceDS studentsSourceDS = new StudentsSourceDS();
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
			xmlSchemaAttribute.FixedValue = studentsSourceDS.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "StudentsDSDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = studentsSourceDS.GetSchemaSerializable();
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

	public class StudentsDSRow : DataRow
	{
		private StudentsDSDataTable tableStudentsDS;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				return (string)base[tableStudentsDS.StudentNumberColumn];
			}
			set
			{
				base[tableStudentsDS.StudentNumberColumn] = value;
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
					return (string)base[tableStudentsDS.fullNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullName' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.fullNameColumn] = value;
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
					return (string)base[tableStudentsDS.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.ClassIdColumn] = value;
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
					return (string)base[tableStudentsDS.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.StreamIdColumn] = value;
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
					return (string)base[tableStudentsDS.StudyStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudyStatus' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.StudyStatusColumn] = value;
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
					return (string)base[tableStudentsDS.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.SexColumn] = value;
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
					return (string)base[tableStudentsDS.HouseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseId' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.HouseIdColumn] = value;
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
					return (byte[])base[tableStudentsDS.PictureColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Picture' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.PictureColumn] = value;
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
					return (decimal)base[tableStudentsDS.cashOnAccountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'cashOnAccount' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.cashOnAccountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string PrimaryScores1
		{
			get
			{
				try
				{
					return (string)base[tableStudentsDS.PrimaryScores1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PrimaryScores1' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.PrimaryScores1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long auto
		{
			get
			{
				return (long)base[tableStudentsDS.autoColumn];
			}
			set
			{
				base[tableStudentsDS.autoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentID
		{
			get
			{
				try
				{
					return (string)base[tableStudentsDS.StudentIDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentID' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.StudentIDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string GamesAndSports
		{
			get
			{
				try
				{
					return (string)base[tableStudentsDS.GamesAndSportsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GamesAndSports' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.GamesAndSportsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Clubs
		{
			get
			{
				try
				{
					return (string)base[tableStudentsDS.ClubsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Clubs' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.ClubsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Status
		{
			get
			{
				try
				{
					return (string)base[tableStudentsDS.StatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Status' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.StatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string LIN
		{
			get
			{
				try
				{
					return (string)base[tableStudentsDS.LINColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LIN' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.LINColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal FeesNextTerm
		{
			get
			{
				try
				{
					return (decimal)base[tableStudentsDS.FeesNextTermColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FeesNextTerm' in table 'StudentsDS' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentsDS.FeesNextTermColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal StudentsDSRow(DataRowBuilder rb)
			: base(rb)
		{
			tableStudentsDS = (StudentsDSDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameNull()
		{
			return IsNull(tableStudentsDS.fullNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameNull()
		{
			base[tableStudentsDS.fullNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tableStudentsDS.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tableStudentsDS.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tableStudentsDS.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tableStudentsDS.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudyStatusNull()
		{
			return IsNull(tableStudentsDS.StudyStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudyStatusNull()
		{
			base[tableStudentsDS.StudyStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tableStudentsDS.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tableStudentsDS.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHouseIdNull()
		{
			return IsNull(tableStudentsDS.HouseIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHouseIdNull()
		{
			base[tableStudentsDS.HouseIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPictureNull()
		{
			return IsNull(tableStudentsDS.PictureColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPictureNull()
		{
			base[tableStudentsDS.PictureColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IscashOnAccountNull()
		{
			return IsNull(tableStudentsDS.cashOnAccountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetcashOnAccountNull()
		{
			base[tableStudentsDS.cashOnAccountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPrimaryScores1Null()
		{
			return IsNull(tableStudentsDS.PrimaryScores1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPrimaryScores1Null()
		{
			base[tableStudentsDS.PrimaryScores1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentIDNull()
		{
			return IsNull(tableStudentsDS.StudentIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentIDNull()
		{
			base[tableStudentsDS.StudentIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGamesAndSportsNull()
		{
			return IsNull(tableStudentsDS.GamesAndSportsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGamesAndSportsNull()
		{
			base[tableStudentsDS.GamesAndSportsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClubsNull()
		{
			return IsNull(tableStudentsDS.ClubsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClubsNull()
		{
			base[tableStudentsDS.ClubsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStatusNull()
		{
			return IsNull(tableStudentsDS.StatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStatusNull()
		{
			base[tableStudentsDS.StatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsLINNull()
		{
			return IsNull(tableStudentsDS.LINColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetLINNull()
		{
			base[tableStudentsDS.LINColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFeesNextTermNull()
		{
			return IsNull(tableStudentsDS.FeesNextTermColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFeesNextTermNull()
		{
			base[tableStudentsDS.FeesNextTermColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class StudentsDSRowChangeEvent : EventArgs
	{
		private StudentsDSRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentsDSRowChangeEvent(StudentsDSRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private StudentsDSDataTable tableStudentsDS;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public StudentsDSDataTable StudentsDS => tableStudentsDS;

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
	public StudentsSourceDS()
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
	protected StudentsSourceDS(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["StudentsDS"] != null)
			{
				base.Tables.Add(new StudentsDSDataTable(dataSet.Tables["StudentsDS"]));
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
		StudentsSourceDS studentsSourceDS = (StudentsSourceDS)base.Clone();
		studentsSourceDS.InitVars();
		studentsSourceDS.SchemaSerializationMode = SchemaSerializationMode;
		return studentsSourceDS;
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
			if (dataSet.Tables["StudentsDS"] != null)
			{
				base.Tables.Add(new StudentsDSDataTable(dataSet.Tables["StudentsDS"]));
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
		tableStudentsDS = (StudentsDSDataTable)base.Tables["StudentsDS"];
		if (initTable && tableStudentsDS != null)
		{
			tableStudentsDS.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "StudentsSourceDS";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/StudentsSourceDS.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableStudentsDS = new StudentsDSDataTable();
		base.Tables.Add(tableStudentsDS);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeStudentsDS()
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
		StudentsSourceDS studentsSourceDS = new StudentsSourceDS();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = studentsSourceDS.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = studentsSourceDS.GetSchemaSerializable();
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
