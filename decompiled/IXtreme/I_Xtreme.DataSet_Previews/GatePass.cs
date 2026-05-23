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

namespace I_Xtreme.DataSet_Previews;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("GatePass")]
[HelpKeyword("vs.data.DataSet")]
public class GatePass : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void tbl_GatePassRowChangeEventHandler(object sender, tbl_GatePassRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class tbl_GatePassDataTable : TypedTableBase<tbl_GatePassRow>
	{
		private DataColumn columnpassNo;

		private DataColumn columnStudentNumber;

		private DataColumn columnName;

		private DataColumn columnClass;

		private DataColumn columnStream;

		private DataColumn columnSex;

		private DataColumn columnDB;

		private DataColumn columnGuardian;

		private DataColumn columnCreatedBy;

		private DataColumn columnSemesterId;

		private DataColumn columnCreateDate;

		private DataColumn columnPassType;

		private DataColumn columnDestination;

		private DataColumn columnReturnDate;

		private DataColumn columnReturnTime;

		private DataColumn columnamount;

		private DataColumn columnamountInWords;

		private DataColumn columnpic;

		private DataColumn columnCaptureDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn passNoColumn => columnpassNo;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NameColumn => columnName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassColumn => columnClass;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamColumn => columnStream;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SexColumn => columnSex;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DBColumn => columnDB;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GuardianColumn => columnGuardian;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CreatedByColumn => columnCreatedBy;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SemesterIdColumn => columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CreateDateColumn => columnCreateDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PassTypeColumn => columnPassType;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DestinationColumn => columnDestination;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ReturnDateColumn => columnReturnDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ReturnTimeColumn => columnReturnTime;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn amountColumn => columnamount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn amountInWordsColumn => columnamountInWords;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn picColumn => columnpic;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CaptureDateColumn => columnCaptureDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassRow this[int index] => (tbl_GatePassRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_GatePassRowChangeEventHandler tbl_GatePassRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_GatePassRowChangeEventHandler tbl_GatePassRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_GatePassRowChangeEventHandler tbl_GatePassRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_GatePassRowChangeEventHandler tbl_GatePassRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassDataTable()
		{
			base.TableName = "tbl_GatePass";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_GatePassDataTable(DataTable table)
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
		protected tbl_GatePassDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Addtbl_GatePassRow(tbl_GatePassRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassRow Addtbl_GatePassRow(string StudentNumber, string Name, string Class, string Stream, string Sex, string DB, string Guardian, string CreatedBy, string SemesterId, DateTime CreateDate, string PassType, string Destination, DateTime ReturnDate, DateTime ReturnTime, decimal amount, string amountInWords, byte[] pic, string CaptureDate)
		{
			tbl_GatePassRow tbl_GatePassRow = (tbl_GatePassRow)NewRow();
			object[] itemArray = new object[19]
			{
				null, StudentNumber, Name, Class, Stream, Sex, DB, Guardian, CreatedBy, SemesterId,
				CreateDate, PassType, Destination, ReturnDate, ReturnTime, amount, amountInWords, pic, CaptureDate
			};
			tbl_GatePassRow.ItemArray = itemArray;
			base.Rows.Add(tbl_GatePassRow);
			return tbl_GatePassRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassRow FindBypassNo(long passNo)
		{
			return (tbl_GatePassRow)base.Rows.Find(new object[1] { passNo });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			tbl_GatePassDataTable tbl_GatePassDataTable = (tbl_GatePassDataTable)base.Clone();
			tbl_GatePassDataTable.InitVars();
			return tbl_GatePassDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new tbl_GatePassDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnpassNo = base.Columns["passNo"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnName = base.Columns["Name"];
			columnClass = base.Columns["Class"];
			columnStream = base.Columns["Stream"];
			columnSex = base.Columns["Sex"];
			columnDB = base.Columns["DB"];
			columnGuardian = base.Columns["Guardian"];
			columnCreatedBy = base.Columns["CreatedBy"];
			columnSemesterId = base.Columns["SemesterId"];
			columnCreateDate = base.Columns["CreateDate"];
			columnPassType = base.Columns["PassType"];
			columnDestination = base.Columns["Destination"];
			columnReturnDate = base.Columns["ReturnDate"];
			columnReturnTime = base.Columns["ReturnTime"];
			columnamount = base.Columns["amount"];
			columnamountInWords = base.Columns["amountInWords"];
			columnpic = base.Columns["pic"];
			columnCaptureDate = base.Columns["CaptureDate"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnpassNo = new DataColumn("passNo", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnpassNo);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnName = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnName);
			columnClass = new DataColumn("Class", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClass);
			columnStream = new DataColumn("Stream", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStream);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnDB = new DataColumn("DB", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDB);
			columnGuardian = new DataColumn("Guardian", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGuardian);
			columnCreatedBy = new DataColumn("CreatedBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCreatedBy);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnCreateDate = new DataColumn("CreateDate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnCreateDate);
			columnPassType = new DataColumn("PassType", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPassType);
			columnDestination = new DataColumn("Destination", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDestination);
			columnReturnDate = new DataColumn("ReturnDate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnReturnDate);
			columnReturnTime = new DataColumn("ReturnTime", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnReturnTime);
			columnamount = new DataColumn("amount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnamount);
			columnamountInWords = new DataColumn("amountInWords", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnamountInWords);
			columnpic = new DataColumn("pic", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnpic);
			columnCaptureDate = new DataColumn("CaptureDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCaptureDate);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnpassNo }, isPrimaryKey: true));
			columnpassNo.AutoIncrement = true;
			columnpassNo.AutoIncrementSeed = -1L;
			columnpassNo.AutoIncrementStep = -1L;
			columnpassNo.AllowDBNull = false;
			columnpassNo.ReadOnly = true;
			columnpassNo.Unique = true;
			columnStudentNumber.MaxLength = 12;
			columnName.MaxLength = 50;
			columnClass.MaxLength = 3;
			columnStream.MaxLength = 50;
			columnSex.MaxLength = 1;
			columnDB.MaxLength = 1;
			columnGuardian.MaxLength = 50;
			columnCreatedBy.MaxLength = 30;
			columnSemesterId.MaxLength = 20;
			columnPassType.MaxLength = 50;
			columnDestination.MaxLength = 50;
			columnamountInWords.MaxLength = int.MaxValue;
			columnCaptureDate.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassRow Newtbl_GatePassRow()
		{
			return (tbl_GatePassRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new tbl_GatePassRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(tbl_GatePassRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.tbl_GatePassRowChanged != null)
			{
				this.tbl_GatePassRowChanged(this, new tbl_GatePassRowChangeEvent((tbl_GatePassRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.tbl_GatePassRowChanging != null)
			{
				this.tbl_GatePassRowChanging(this, new tbl_GatePassRowChangeEvent((tbl_GatePassRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.tbl_GatePassRowDeleted != null)
			{
				this.tbl_GatePassRowDeleted(this, new tbl_GatePassRowChangeEvent((tbl_GatePassRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.tbl_GatePassRowDeleting != null)
			{
				this.tbl_GatePassRowDeleting(this, new tbl_GatePassRowChangeEvent((tbl_GatePassRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Removetbl_GatePassRow(tbl_GatePassRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			GatePass gatePass = new GatePass();
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
			xmlSchemaAttribute.FixedValue = gatePass.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "tbl_GatePassDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = gatePass.GetSchemaSerializable();
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

	public class tbl_GatePassRow : DataRow
	{
		private tbl_GatePassDataTable tabletbl_GatePass;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long passNo
		{
			get
			{
				return (long)base[tabletbl_GatePass.passNoColumn];
			}
			set
			{
				base[tabletbl_GatePass.passNoColumn] = value;
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
					return (string)base[tabletbl_GatePass.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Name
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.NameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.NameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Class
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.ClassColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Class' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.ClassColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Stream
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.StreamColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Stream' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.StreamColumn] = value;
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
					return (string)base[tabletbl_GatePass.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.SexColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string DB
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.DBColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DB' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.DBColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Guardian
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.GuardianColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Guardian' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.GuardianColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string CreatedBy
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.CreatedByColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CreatedBy' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.CreatedByColumn] = value;
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
					return (string)base[tabletbl_GatePass.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.SemesterIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime CreateDate
		{
			get
			{
				try
				{
					return (DateTime)base[tabletbl_GatePass.CreateDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CreateDate' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.CreateDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string PassType
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.PassTypeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PassType' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.PassTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Destination
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.DestinationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Destination' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.DestinationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime ReturnDate
		{
			get
			{
				try
				{
					return (DateTime)base[tabletbl_GatePass.ReturnDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ReturnDate' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.ReturnDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime ReturnTime
		{
			get
			{
				try
				{
					return (DateTime)base[tabletbl_GatePass.ReturnTimeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ReturnTime' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.ReturnTimeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal amount
		{
			get
			{
				try
				{
					return (decimal)base[tabletbl_GatePass.amountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'amount' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.amountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string amountInWords
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.amountInWordsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'amountInWords' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.amountInWordsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public byte[] pic
		{
			get
			{
				try
				{
					return (byte[])base[tabletbl_GatePass.picColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'pic' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.picColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string CaptureDate
		{
			get
			{
				try
				{
					return (string)base[tabletbl_GatePass.CaptureDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CaptureDate' in table 'tbl_GatePass' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_GatePass.CaptureDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_GatePassRow(DataRowBuilder rb)
			: base(rb)
		{
			tabletbl_GatePass = (tbl_GatePassDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tabletbl_GatePass.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tabletbl_GatePass.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNameNull()
		{
			return IsNull(tabletbl_GatePass.NameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNameNull()
		{
			base[tabletbl_GatePass.NameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassNull()
		{
			return IsNull(tabletbl_GatePass.ClassColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassNull()
		{
			base[tabletbl_GatePass.ClassColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamNull()
		{
			return IsNull(tabletbl_GatePass.StreamColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamNull()
		{
			base[tabletbl_GatePass.StreamColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tabletbl_GatePass.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tabletbl_GatePass.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDBNull()
		{
			return IsNull(tabletbl_GatePass.DBColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDBNull()
		{
			base[tabletbl_GatePass.DBColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGuardianNull()
		{
			return IsNull(tabletbl_GatePass.GuardianColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGuardianNull()
		{
			base[tabletbl_GatePass.GuardianColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCreatedByNull()
		{
			return IsNull(tabletbl_GatePass.CreatedByColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCreatedByNull()
		{
			base[tabletbl_GatePass.CreatedByColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tabletbl_GatePass.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tabletbl_GatePass.SemesterIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCreateDateNull()
		{
			return IsNull(tabletbl_GatePass.CreateDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCreateDateNull()
		{
			base[tabletbl_GatePass.CreateDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPassTypeNull()
		{
			return IsNull(tabletbl_GatePass.PassTypeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPassTypeNull()
		{
			base[tabletbl_GatePass.PassTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDestinationNull()
		{
			return IsNull(tabletbl_GatePass.DestinationColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDestinationNull()
		{
			base[tabletbl_GatePass.DestinationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsReturnDateNull()
		{
			return IsNull(tabletbl_GatePass.ReturnDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetReturnDateNull()
		{
			base[tabletbl_GatePass.ReturnDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsReturnTimeNull()
		{
			return IsNull(tabletbl_GatePass.ReturnTimeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetReturnTimeNull()
		{
			base[tabletbl_GatePass.ReturnTimeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsamountNull()
		{
			return IsNull(tabletbl_GatePass.amountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetamountNull()
		{
			base[tabletbl_GatePass.amountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsamountInWordsNull()
		{
			return IsNull(tabletbl_GatePass.amountInWordsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetamountInWordsNull()
		{
			base[tabletbl_GatePass.amountInWordsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IspicNull()
		{
			return IsNull(tabletbl_GatePass.picColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetpicNull()
		{
			base[tabletbl_GatePass.picColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCaptureDateNull()
		{
			return IsNull(tabletbl_GatePass.CaptureDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCaptureDateNull()
		{
			base[tabletbl_GatePass.CaptureDateColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class tbl_GatePassRowChangeEvent : EventArgs
	{
		private tbl_GatePassRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_GatePassRowChangeEvent(tbl_GatePassRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private tbl_GatePassDataTable tabletbl_GatePass;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public tbl_GatePassDataTable tbl_GatePass => tabletbl_GatePass;

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
	public GatePass()
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
	protected GatePass(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["tbl_GatePass"] != null)
			{
				base.Tables.Add(new tbl_GatePassDataTable(dataSet.Tables["tbl_GatePass"]));
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
		GatePass gatePass = (GatePass)base.Clone();
		gatePass.InitVars();
		gatePass.SchemaSerializationMode = SchemaSerializationMode;
		return gatePass;
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
			if (dataSet.Tables["tbl_GatePass"] != null)
			{
				base.Tables.Add(new tbl_GatePassDataTable(dataSet.Tables["tbl_GatePass"]));
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
		tabletbl_GatePass = (tbl_GatePassDataTable)base.Tables["tbl_GatePass"];
		if (initTable && tabletbl_GatePass != null)
		{
			tabletbl_GatePass.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "GatePass";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/GatePass.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tabletbl_GatePass = new tbl_GatePassDataTable();
		base.Tables.Add(tabletbl_GatePass);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializetbl_GatePass()
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
		GatePass gatePass = new GatePass();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = gatePass.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = gatePass.GetSchemaSerializable();
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
