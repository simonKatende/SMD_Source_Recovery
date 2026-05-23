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

namespace I_Xtreme.StudentID_Datasets;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("DataSet_S1")]
[HelpKeyword("vs.data.DataSet")]
public class DataSet_S1 : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void S_1ID_DataTable1RowChangeEventHandler(object sender, S_1ID_DataTable1RowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class S_1ID_DataTable1DataTable : TypedTableBase<S_1ID_DataTable1Row>
	{
		private DataColumn columnfullName;

		private DataColumn columnPicture;

		private DataColumn columnStudentNumber;

		private DataColumn columnauto;

		private DataColumn columnStreamId;

		private DataColumn columncashOnAccount;

		private DataColumn columnClassId;

		private DataColumn columnSex;

		private DataColumn columnStudyStatus;

		private DataColumn columnHouseId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fullNameColumn => columnfullName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PictureColumn => columnPicture;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn autoColumn => columnauto;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamIdColumn => columnStreamId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn cashOnAccountColumn => columncashOnAccount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdColumn => columnClassId;

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
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1Row this[int index] => (S_1ID_DataTable1Row)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event S_1ID_DataTable1RowChangeEventHandler S_1ID_DataTable1RowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event S_1ID_DataTable1RowChangeEventHandler S_1ID_DataTable1RowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event S_1ID_DataTable1RowChangeEventHandler S_1ID_DataTable1RowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event S_1ID_DataTable1RowChangeEventHandler S_1ID_DataTable1RowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1DataTable()
		{
			base.TableName = "S_1ID_DataTable1";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal S_1ID_DataTable1DataTable(DataTable table)
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
		protected S_1ID_DataTable1DataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddS_1ID_DataTable1Row(S_1ID_DataTable1Row row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1Row AddS_1ID_DataTable1Row(string fullName, byte[] Picture, string StudentNumber, string StreamId, decimal cashOnAccount, string ClassId, string Sex, string StudyStatus, string HouseId)
		{
			S_1ID_DataTable1Row s_1ID_DataTable1Row = (S_1ID_DataTable1Row)NewRow();
			object[] itemArray = new object[10] { fullName, Picture, StudentNumber, null, StreamId, cashOnAccount, ClassId, Sex, StudyStatus, HouseId };
			s_1ID_DataTable1Row.ItemArray = itemArray;
			base.Rows.Add(s_1ID_DataTable1Row);
			return s_1ID_DataTable1Row;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1Row FindByStudentNumber(string StudentNumber)
		{
			return (S_1ID_DataTable1Row)base.Rows.Find(new object[1] { StudentNumber });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			S_1ID_DataTable1DataTable s_1ID_DataTable1DataTable = (S_1ID_DataTable1DataTable)base.Clone();
			s_1ID_DataTable1DataTable.InitVars();
			return s_1ID_DataTable1DataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new S_1ID_DataTable1DataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnfullName = base.Columns["fullName"];
			columnPicture = base.Columns["Picture"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnauto = base.Columns["auto"];
			columnStreamId = base.Columns["StreamId"];
			columncashOnAccount = base.Columns["cashOnAccount"];
			columnClassId = base.Columns["ClassId"];
			columnSex = base.Columns["Sex"];
			columnStudyStatus = base.Columns["StudyStatus"];
			columnHouseId = base.Columns["HouseId"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnfullName = new DataColumn("fullName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfullName);
			columnPicture = new DataColumn("Picture", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPicture);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnauto = new DataColumn("auto", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnauto);
			columnStreamId = new DataColumn("StreamId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStreamId);
			columncashOnAccount = new DataColumn("cashOnAccount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columncashOnAccount);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnStudyStatus = new DataColumn("StudyStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudyStatus);
			columnHouseId = new DataColumn("HouseId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHouseId);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnStudentNumber }, isPrimaryKey: true));
			columnfullName.MaxLength = 100;
			columnStudentNumber.AllowDBNull = false;
			columnStudentNumber.Unique = true;
			columnStudentNumber.MaxLength = 50;
			columnauto.AutoIncrement = true;
			columnauto.AutoIncrementSeed = -1L;
			columnauto.AutoIncrementStep = -1L;
			columnauto.AllowDBNull = false;
			columnauto.ReadOnly = true;
			columnStreamId.MaxLength = 8;
			columnClassId.MaxLength = 8;
			columnSex.MaxLength = 1;
			columnStudyStatus.MaxLength = 1;
			columnHouseId.MaxLength = 25;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1Row NewS_1ID_DataTable1Row()
		{
			return (S_1ID_DataTable1Row)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new S_1ID_DataTable1Row(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(S_1ID_DataTable1Row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.S_1ID_DataTable1RowChanged != null)
			{
				this.S_1ID_DataTable1RowChanged(this, new S_1ID_DataTable1RowChangeEvent((S_1ID_DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.S_1ID_DataTable1RowChanging != null)
			{
				this.S_1ID_DataTable1RowChanging(this, new S_1ID_DataTable1RowChangeEvent((S_1ID_DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.S_1ID_DataTable1RowDeleted != null)
			{
				this.S_1ID_DataTable1RowDeleted(this, new S_1ID_DataTable1RowChangeEvent((S_1ID_DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.S_1ID_DataTable1RowDeleting != null)
			{
				this.S_1ID_DataTable1RowDeleting(this, new S_1ID_DataTable1RowChangeEvent((S_1ID_DataTable1Row)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveS_1ID_DataTable1Row(S_1ID_DataTable1Row row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			DataSet_S1 dataSet_S = new DataSet_S1();
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
			xmlSchemaAttribute.FixedValue = dataSet_S.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "S_1ID_DataTable1DataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dataSet_S.GetSchemaSerializable();
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

	public class S_1ID_DataTable1Row : DataRow
	{
		private S_1ID_DataTable1DataTable tableS_1ID_DataTable1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fullName
		{
			get
			{
				try
				{
					return (string)base[tableS_1ID_DataTable1.fullNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullName' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.fullNameColumn] = value;
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
					return (byte[])base[tableS_1ID_DataTable1.PictureColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Picture' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.PictureColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				return (string)base[tableS_1ID_DataTable1.StudentNumberColumn];
			}
			set
			{
				base[tableS_1ID_DataTable1.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long auto
		{
			get
			{
				return (long)base[tableS_1ID_DataTable1.autoColumn];
			}
			set
			{
				base[tableS_1ID_DataTable1.autoColumn] = value;
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
					return (string)base[tableS_1ID_DataTable1.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.StreamIdColumn] = value;
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
					return (decimal)base[tableS_1ID_DataTable1.cashOnAccountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'cashOnAccount' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.cashOnAccountColumn] = value;
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
					return (string)base[tableS_1ID_DataTable1.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.ClassIdColumn] = value;
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
					return (string)base[tableS_1ID_DataTable1.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.SexColumn] = value;
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
					return (string)base[tableS_1ID_DataTable1.StudyStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudyStatus' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.StudyStatusColumn] = value;
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
					return (string)base[tableS_1ID_DataTable1.HouseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseId' in table 'S_1ID_DataTable1' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableS_1ID_DataTable1.HouseIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal S_1ID_DataTable1Row(DataRowBuilder rb)
			: base(rb)
		{
			tableS_1ID_DataTable1 = (S_1ID_DataTable1DataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameNull()
		{
			return IsNull(tableS_1ID_DataTable1.fullNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameNull()
		{
			base[tableS_1ID_DataTable1.fullNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPictureNull()
		{
			return IsNull(tableS_1ID_DataTable1.PictureColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPictureNull()
		{
			base[tableS_1ID_DataTable1.PictureColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tableS_1ID_DataTable1.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tableS_1ID_DataTable1.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IscashOnAccountNull()
		{
			return IsNull(tableS_1ID_DataTable1.cashOnAccountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetcashOnAccountNull()
		{
			base[tableS_1ID_DataTable1.cashOnAccountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tableS_1ID_DataTable1.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tableS_1ID_DataTable1.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tableS_1ID_DataTable1.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tableS_1ID_DataTable1.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudyStatusNull()
		{
			return IsNull(tableS_1ID_DataTable1.StudyStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudyStatusNull()
		{
			base[tableS_1ID_DataTable1.StudyStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHouseIdNull()
		{
			return IsNull(tableS_1ID_DataTable1.HouseIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHouseIdNull()
		{
			base[tableS_1ID_DataTable1.HouseIdColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class S_1ID_DataTable1RowChangeEvent : EventArgs
	{
		private S_1ID_DataTable1Row eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1Row Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public S_1ID_DataTable1RowChangeEvent(S_1ID_DataTable1Row row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private S_1ID_DataTable1DataTable tableS_1ID_DataTable1;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public S_1ID_DataTable1DataTable S_1ID_DataTable1 => tableS_1ID_DataTable1;

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
	public DataSet_S1()
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
	protected DataSet_S1(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["S_1ID_DataTable1"] != null)
			{
				base.Tables.Add(new S_1ID_DataTable1DataTable(dataSet.Tables["S_1ID_DataTable1"]));
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
		DataSet_S1 dataSet_S = (DataSet_S1)base.Clone();
		dataSet_S.InitVars();
		dataSet_S.SchemaSerializationMode = SchemaSerializationMode;
		return dataSet_S;
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
			if (dataSet.Tables["S_1ID_DataTable1"] != null)
			{
				base.Tables.Add(new S_1ID_DataTable1DataTable(dataSet.Tables["S_1ID_DataTable1"]));
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
		tableS_1ID_DataTable1 = (S_1ID_DataTable1DataTable)base.Tables["S_1ID_DataTable1"];
		if (initTable && tableS_1ID_DataTable1 != null)
		{
			tableS_1ID_DataTable1.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "DataSet_S1";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/DataSet_S1.xsd";
		base.EnforceConstraints = false;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableS_1ID_DataTable1 = new S_1ID_DataTable1DataTable();
		base.Tables.Add(tableS_1ID_DataTable1);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeS_1ID_DataTable1()
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
		DataSet_S1 dataSet_S = new DataSet_S1();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = dataSet_S.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = dataSet_S.GetSchemaSerializable();
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
