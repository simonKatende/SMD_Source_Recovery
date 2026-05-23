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

namespace I_Xtreme.ClearanceCards;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("KTBFeesCards")]
[HelpKeyword("vs.data.DataSet")]
public class KTBFeesCards : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void tbl_StudRowChangeEventHandler(object sender, tbl_StudRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class tbl_StudDataTable : TypedTableBase<tbl_StudRow>
	{
		private DataColumn columnauto;

		private DataColumn columnStudentNumber;

		private DataColumn columnfullName;

		private DataColumn columnClassId;

		private DataColumn columnStreamId;

		private DataColumn columnSex;

		private DataColumn columnStudyStatus;

		private DataColumn columnHouseId;

		private DataColumn columnPicture;

		private DataColumn columnStatus;

		private DataColumn columnStudentID;

		private DataColumn columnLIN;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn autoColumn => columnauto;

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
		public DataColumn PictureColumn => columnPicture;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StatusColumn => columnStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentIDColumn => columnStudentID;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn LINColumn => columnLIN;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_StudRow this[int index] => (tbl_StudRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_StudRowChangeEventHandler tbl_StudRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_StudRowChangeEventHandler tbl_StudRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_StudRowChangeEventHandler tbl_StudRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_StudRowChangeEventHandler tbl_StudRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_StudDataTable()
		{
			base.TableName = "tbl_Stud";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_StudDataTable(DataTable table)
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
		protected tbl_StudDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Addtbl_StudRow(tbl_StudRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_StudRow Addtbl_StudRow(string StudentNumber, string fullName, string ClassId, string StreamId, string Sex, string StudyStatus, string HouseId, byte[] Picture, string Status, string StudentID, string LIN)
		{
			tbl_StudRow tbl_StudRow = (tbl_StudRow)NewRow();
			object[] itemArray = new object[12]
			{
				null, StudentNumber, fullName, ClassId, StreamId, Sex, StudyStatus, HouseId, Picture, Status,
				StudentID, LIN
			};
			tbl_StudRow.ItemArray = itemArray;
			base.Rows.Add(tbl_StudRow);
			return tbl_StudRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			tbl_StudDataTable tbl_StudDataTable = (tbl_StudDataTable)base.Clone();
			tbl_StudDataTable.InitVars();
			return tbl_StudDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new tbl_StudDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnauto = base.Columns["auto"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnfullName = base.Columns["fullName"];
			columnClassId = base.Columns["ClassId"];
			columnStreamId = base.Columns["StreamId"];
			columnSex = base.Columns["Sex"];
			columnStudyStatus = base.Columns["StudyStatus"];
			columnHouseId = base.Columns["HouseId"];
			columnPicture = base.Columns["Picture"];
			columnStatus = base.Columns["Status"];
			columnStudentID = base.Columns["StudentID"];
			columnLIN = base.Columns["LIN"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnauto = new DataColumn("auto", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnauto);
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
			columnPicture = new DataColumn("Picture", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPicture);
			columnStatus = new DataColumn("Status", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStatus);
			columnStudentID = new DataColumn("StudentID", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentID);
			columnLIN = new DataColumn("LIN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLIN);
			columnauto.AutoIncrement = true;
			columnauto.AutoIncrementSeed = -1L;
			columnauto.AutoIncrementStep = -1L;
			columnauto.AllowDBNull = false;
			columnauto.ReadOnly = true;
			columnStudentNumber.AllowDBNull = false;
			columnStudentNumber.MaxLength = 12;
			columnfullName.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnStreamId.MaxLength = 8;
			columnSex.MaxLength = 1;
			columnStudyStatus.MaxLength = 1;
			columnHouseId.MaxLength = 25;
			columnStatus.MaxLength = 15;
			columnStudentID.MaxLength = 12;
			columnLIN.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_StudRow Newtbl_StudRow()
		{
			return (tbl_StudRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new tbl_StudRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(tbl_StudRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.tbl_StudRowChanged != null)
			{
				this.tbl_StudRowChanged(this, new tbl_StudRowChangeEvent((tbl_StudRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.tbl_StudRowChanging != null)
			{
				this.tbl_StudRowChanging(this, new tbl_StudRowChangeEvent((tbl_StudRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.tbl_StudRowDeleted != null)
			{
				this.tbl_StudRowDeleted(this, new tbl_StudRowChangeEvent((tbl_StudRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.tbl_StudRowDeleting != null)
			{
				this.tbl_StudRowDeleting(this, new tbl_StudRowChangeEvent((tbl_StudRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Removetbl_StudRow(tbl_StudRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			KTBFeesCards kTBFeesCards = new KTBFeesCards();
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
			xmlSchemaAttribute.FixedValue = kTBFeesCards.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "tbl_StudDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = kTBFeesCards.GetSchemaSerializable();
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

	public class tbl_StudRow : DataRow
	{
		private tbl_StudDataTable tabletbl_Stud;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long auto
		{
			get
			{
				return (long)base[tabletbl_Stud.autoColumn];
			}
			set
			{
				base[tabletbl_Stud.autoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				return (string)base[tabletbl_Stud.StudentNumberColumn];
			}
			set
			{
				base[tabletbl_Stud.StudentNumberColumn] = value;
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
					return (string)base[tabletbl_Stud.fullNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullName' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.fullNameColumn] = value;
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
					return (string)base[tabletbl_Stud.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.ClassIdColumn] = value;
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
					return (string)base[tabletbl_Stud.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.StreamIdColumn] = value;
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
					return (string)base[tabletbl_Stud.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.SexColumn] = value;
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
					return (string)base[tabletbl_Stud.StudyStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudyStatus' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.StudyStatusColumn] = value;
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
					return (string)base[tabletbl_Stud.HouseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseId' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.HouseIdColumn] = value;
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
					return (byte[])base[tabletbl_Stud.PictureColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Picture' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.PictureColumn] = value;
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
					return (string)base[tabletbl_Stud.StatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Status' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.StatusColumn] = value;
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
					return (string)base[tabletbl_Stud.StudentIDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentID' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.StudentIDColumn] = value;
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
					return (string)base[tabletbl_Stud.LINColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LIN' in table 'tbl_Stud' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_Stud.LINColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_StudRow(DataRowBuilder rb)
			: base(rb)
		{
			tabletbl_Stud = (tbl_StudDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameNull()
		{
			return IsNull(tabletbl_Stud.fullNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameNull()
		{
			base[tabletbl_Stud.fullNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tabletbl_Stud.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tabletbl_Stud.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tabletbl_Stud.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tabletbl_Stud.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tabletbl_Stud.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tabletbl_Stud.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudyStatusNull()
		{
			return IsNull(tabletbl_Stud.StudyStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudyStatusNull()
		{
			base[tabletbl_Stud.StudyStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHouseIdNull()
		{
			return IsNull(tabletbl_Stud.HouseIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHouseIdNull()
		{
			base[tabletbl_Stud.HouseIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPictureNull()
		{
			return IsNull(tabletbl_Stud.PictureColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPictureNull()
		{
			base[tabletbl_Stud.PictureColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStatusNull()
		{
			return IsNull(tabletbl_Stud.StatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStatusNull()
		{
			base[tabletbl_Stud.StatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentIDNull()
		{
			return IsNull(tabletbl_Stud.StudentIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentIDNull()
		{
			base[tabletbl_Stud.StudentIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsLINNull()
		{
			return IsNull(tabletbl_Stud.LINColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetLINNull()
		{
			base[tabletbl_Stud.LINColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class tbl_StudRowChangeEvent : EventArgs
	{
		private tbl_StudRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_StudRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_StudRowChangeEvent(tbl_StudRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private tbl_StudDataTable tabletbl_Stud;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public tbl_StudDataTable tbl_Stud => tabletbl_Stud;

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
	public KTBFeesCards()
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
	protected KTBFeesCards(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["tbl_Stud"] != null)
			{
				base.Tables.Add(new tbl_StudDataTable(dataSet.Tables["tbl_Stud"]));
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
		KTBFeesCards kTBFeesCards = (KTBFeesCards)base.Clone();
		kTBFeesCards.InitVars();
		kTBFeesCards.SchemaSerializationMode = SchemaSerializationMode;
		return kTBFeesCards;
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
			if (dataSet.Tables["tbl_Stud"] != null)
			{
				base.Tables.Add(new tbl_StudDataTable(dataSet.Tables["tbl_Stud"]));
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
		tabletbl_Stud = (tbl_StudDataTable)base.Tables["tbl_Stud"];
		if (initTable && tabletbl_Stud != null)
		{
			tabletbl_Stud.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "KTBFeesCards";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/KTBFeesCards.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tabletbl_Stud = new tbl_StudDataTable();
		base.Tables.Add(tabletbl_Stud);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializetbl_Stud()
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
		KTBFeesCards kTBFeesCards = new KTBFeesCards();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = kTBFeesCards.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = kTBFeesCards.GetSchemaSerializable();
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
