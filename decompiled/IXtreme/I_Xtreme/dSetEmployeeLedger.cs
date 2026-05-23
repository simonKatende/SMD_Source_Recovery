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

namespace I_Xtreme;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("dSetEmployeeLedger")]
[HelpKeyword("vs.data.DataSet")]
public class dSetEmployeeLedger : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void tbl_EmployeeLedgerRowChangeEventHandler(object sender, tbl_EmployeeLedgerRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class tbl_EmployeeLedgerDataTable : TypedTableBase<tbl_EmployeeLedgerRow>
	{
		private DataColumn columnEmployeeNumber;

		private DataColumn columnStaffName;

		private DataColumn columnStaffId;

		private DataColumn columnPic;

		private DataColumn columnHomePhone;

		private DataColumn columnEmail;

		private DataColumn columnContactNumber;

		private DataColumn columnRef;

		private DataColumn columnDate;

		private DataColumn columnParticulars;

		private DataColumn columnMonth;

		private DataColumn columnDebit;

		private DataColumn columnCredit;

		private DataColumn columnBalance;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn EmployeeNumberColumn => columnEmployeeNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StaffNameColumn => columnStaffName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StaffIdColumn => columnStaffId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PicColumn => columnPic;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HomePhoneColumn => columnHomePhone;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn EmailColumn => columnEmail;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ContactNumberColumn => columnContactNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn RefColumn => columnRef;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DateColumn => columnDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ParticularsColumn => columnParticulars;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn MonthColumn => columnMonth;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DebitColumn => columnDebit;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CreditColumn => columnCredit;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn BalanceColumn => columnBalance;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerRow this[int index] => (tbl_EmployeeLedgerRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_EmployeeLedgerRowChangeEventHandler tbl_EmployeeLedgerRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_EmployeeLedgerRowChangeEventHandler tbl_EmployeeLedgerRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_EmployeeLedgerRowChangeEventHandler tbl_EmployeeLedgerRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event tbl_EmployeeLedgerRowChangeEventHandler tbl_EmployeeLedgerRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerDataTable()
		{
			base.TableName = "tbl_EmployeeLedger";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_EmployeeLedgerDataTable(DataTable table)
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
		protected tbl_EmployeeLedgerDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Addtbl_EmployeeLedgerRow(tbl_EmployeeLedgerRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerRow Addtbl_EmployeeLedgerRow(string EmployeeNumber, string StaffName, string StaffId, byte[] Pic, string HomePhone, string Email, string ContactNumber, DateTime Date, string Particulars, string Month, decimal Debit, decimal Credit, decimal Balance)
		{
			tbl_EmployeeLedgerRow tbl_EmployeeLedgerRow = (tbl_EmployeeLedgerRow)NewRow();
			object[] itemArray = new object[14]
			{
				EmployeeNumber, StaffName, StaffId, Pic, HomePhone, Email, ContactNumber, null, Date, Particulars,
				Month, Debit, Credit, Balance
			};
			tbl_EmployeeLedgerRow.ItemArray = itemArray;
			base.Rows.Add(tbl_EmployeeLedgerRow);
			return tbl_EmployeeLedgerRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerRow FindByStaffId(string StaffId)
		{
			return (tbl_EmployeeLedgerRow)base.Rows.Find(new object[1] { StaffId });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			tbl_EmployeeLedgerDataTable tbl_EmployeeLedgerDataTable = (tbl_EmployeeLedgerDataTable)base.Clone();
			tbl_EmployeeLedgerDataTable.InitVars();
			return tbl_EmployeeLedgerDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new tbl_EmployeeLedgerDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnEmployeeNumber = base.Columns["EmployeeNumber"];
			columnStaffName = base.Columns["StaffName"];
			columnStaffId = base.Columns["StaffId"];
			columnPic = base.Columns["Pic"];
			columnHomePhone = base.Columns["HomePhone"];
			columnEmail = base.Columns["Email"];
			columnContactNumber = base.Columns["ContactNumber"];
			columnRef = base.Columns["Ref"];
			columnDate = base.Columns["Date"];
			columnParticulars = base.Columns["Particulars"];
			columnMonth = base.Columns["Month"];
			columnDebit = base.Columns["Debit"];
			columnCredit = base.Columns["Credit"];
			columnBalance = base.Columns["Balance"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnEmployeeNumber = new DataColumn("EmployeeNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmployeeNumber);
			columnStaffName = new DataColumn("StaffName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStaffName);
			columnStaffId = new DataColumn("StaffId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStaffId);
			columnPic = new DataColumn("Pic", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPic);
			columnHomePhone = new DataColumn("HomePhone", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHomePhone);
			columnEmail = new DataColumn("Email", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmail);
			columnContactNumber = new DataColumn("ContactNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactNumber);
			columnRef = new DataColumn("Ref", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnRef);
			columnDate = new DataColumn("Date", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate);
			columnParticulars = new DataColumn("Particulars", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnParticulars);
			columnMonth = new DataColumn("Month", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnMonth);
			columnDebit = new DataColumn("Debit", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnDebit);
			columnCredit = new DataColumn("Credit", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnCredit);
			columnBalance = new DataColumn("Balance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnBalance);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnStaffId }, isPrimaryKey: true));
			columnEmployeeNumber.MaxLength = 50;
			columnStaffName.MaxLength = 80;
			columnStaffId.AllowDBNull = false;
			columnStaffId.Unique = true;
			columnStaffId.MaxLength = 50;
			columnHomePhone.MaxLength = 25;
			columnEmail.MaxLength = 80;
			columnContactNumber.MaxLength = 50;
			columnRef.AutoIncrement = true;
			columnRef.AutoIncrementSeed = -1L;
			columnRef.AutoIncrementStep = -1L;
			columnRef.AllowDBNull = false;
			columnRef.ReadOnly = true;
			columnParticulars.MaxLength = 50;
			columnMonth.MaxLength = 15;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerRow Newtbl_EmployeeLedgerRow()
		{
			return (tbl_EmployeeLedgerRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new tbl_EmployeeLedgerRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(tbl_EmployeeLedgerRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.tbl_EmployeeLedgerRowChanged != null)
			{
				this.tbl_EmployeeLedgerRowChanged(this, new tbl_EmployeeLedgerRowChangeEvent((tbl_EmployeeLedgerRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.tbl_EmployeeLedgerRowChanging != null)
			{
				this.tbl_EmployeeLedgerRowChanging(this, new tbl_EmployeeLedgerRowChangeEvent((tbl_EmployeeLedgerRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.tbl_EmployeeLedgerRowDeleted != null)
			{
				this.tbl_EmployeeLedgerRowDeleted(this, new tbl_EmployeeLedgerRowChangeEvent((tbl_EmployeeLedgerRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.tbl_EmployeeLedgerRowDeleting != null)
			{
				this.tbl_EmployeeLedgerRowDeleting(this, new tbl_EmployeeLedgerRowChangeEvent((tbl_EmployeeLedgerRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void Removetbl_EmployeeLedgerRow(tbl_EmployeeLedgerRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			dSetEmployeeLedger dSetEmployeeLedger2 = new dSetEmployeeLedger();
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
			xmlSchemaAttribute.FixedValue = dSetEmployeeLedger2.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "tbl_EmployeeLedgerDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dSetEmployeeLedger2.GetSchemaSerializable();
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

	public class tbl_EmployeeLedgerRow : DataRow
	{
		private tbl_EmployeeLedgerDataTable tabletbl_EmployeeLedger;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string EmployeeNumber
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.EmployeeNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'EmployeeNumber' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.EmployeeNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StaffName
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.StaffNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StaffName' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.StaffNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StaffId
		{
			get
			{
				return (string)base[tabletbl_EmployeeLedger.StaffIdColumn];
			}
			set
			{
				base[tabletbl_EmployeeLedger.StaffIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public byte[] Pic
		{
			get
			{
				try
				{
					return (byte[])base[tabletbl_EmployeeLedger.PicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Pic' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.PicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HomePhone
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.HomePhoneColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HomePhone' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.HomePhoneColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Email
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.EmailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Email' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.EmailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ContactNumber
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.ContactNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ContactNumber' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.ContactNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long Ref
		{
			get
			{
				return (long)base[tabletbl_EmployeeLedger.RefColumn];
			}
			set
			{
				base[tabletbl_EmployeeLedger.RefColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date
		{
			get
			{
				try
				{
					return (DateTime)base[tabletbl_EmployeeLedger.DateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.DateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Particulars
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.ParticularsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Particulars' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.ParticularsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Month
		{
			get
			{
				try
				{
					return (string)base[tabletbl_EmployeeLedger.MonthColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Month' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.MonthColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal Debit
		{
			get
			{
				try
				{
					return (decimal)base[tabletbl_EmployeeLedger.DebitColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Debit' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.DebitColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal Credit
		{
			get
			{
				try
				{
					return (decimal)base[tabletbl_EmployeeLedger.CreditColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Credit' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.CreditColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal Balance
		{
			get
			{
				try
				{
					return (decimal)base[tabletbl_EmployeeLedger.BalanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Balance' in table 'tbl_EmployeeLedger' is DBNull.", innerException);
				}
			}
			set
			{
				base[tabletbl_EmployeeLedger.BalanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal tbl_EmployeeLedgerRow(DataRowBuilder rb)
			: base(rb)
		{
			tabletbl_EmployeeLedger = (tbl_EmployeeLedgerDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsEmployeeNumberNull()
		{
			return IsNull(tabletbl_EmployeeLedger.EmployeeNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetEmployeeNumberNull()
		{
			base[tabletbl_EmployeeLedger.EmployeeNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStaffNameNull()
		{
			return IsNull(tabletbl_EmployeeLedger.StaffNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStaffNameNull()
		{
			base[tabletbl_EmployeeLedger.StaffNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPicNull()
		{
			return IsNull(tabletbl_EmployeeLedger.PicColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPicNull()
		{
			base[tabletbl_EmployeeLedger.PicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHomePhoneNull()
		{
			return IsNull(tabletbl_EmployeeLedger.HomePhoneColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHomePhoneNull()
		{
			base[tabletbl_EmployeeLedger.HomePhoneColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsEmailNull()
		{
			return IsNull(tabletbl_EmployeeLedger.EmailColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetEmailNull()
		{
			base[tabletbl_EmployeeLedger.EmailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsContactNumberNull()
		{
			return IsNull(tabletbl_EmployeeLedger.ContactNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetContactNumberNull()
		{
			base[tabletbl_EmployeeLedger.ContactNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDateNull()
		{
			return IsNull(tabletbl_EmployeeLedger.DateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDateNull()
		{
			base[tabletbl_EmployeeLedger.DateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsParticularsNull()
		{
			return IsNull(tabletbl_EmployeeLedger.ParticularsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetParticularsNull()
		{
			base[tabletbl_EmployeeLedger.ParticularsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsMonthNull()
		{
			return IsNull(tabletbl_EmployeeLedger.MonthColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetMonthNull()
		{
			base[tabletbl_EmployeeLedger.MonthColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDebitNull()
		{
			return IsNull(tabletbl_EmployeeLedger.DebitColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDebitNull()
		{
			base[tabletbl_EmployeeLedger.DebitColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCreditNull()
		{
			return IsNull(tabletbl_EmployeeLedger.CreditColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCreditNull()
		{
			base[tabletbl_EmployeeLedger.CreditColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBalanceNull()
		{
			return IsNull(tabletbl_EmployeeLedger.BalanceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBalanceNull()
		{
			base[tabletbl_EmployeeLedger.BalanceColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class tbl_EmployeeLedgerRowChangeEvent : EventArgs
	{
		private tbl_EmployeeLedgerRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public tbl_EmployeeLedgerRowChangeEvent(tbl_EmployeeLedgerRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private tbl_EmployeeLedgerDataTable tabletbl_EmployeeLedger;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public tbl_EmployeeLedgerDataTable tbl_EmployeeLedger => tabletbl_EmployeeLedger;

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
	public dSetEmployeeLedger()
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
	protected dSetEmployeeLedger(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["tbl_EmployeeLedger"] != null)
			{
				base.Tables.Add(new tbl_EmployeeLedgerDataTable(dataSet.Tables["tbl_EmployeeLedger"]));
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
		dSetEmployeeLedger dSetEmployeeLedger2 = (dSetEmployeeLedger)base.Clone();
		dSetEmployeeLedger2.InitVars();
		dSetEmployeeLedger2.SchemaSerializationMode = SchemaSerializationMode;
		return dSetEmployeeLedger2;
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
			if (dataSet.Tables["tbl_EmployeeLedger"] != null)
			{
				base.Tables.Add(new tbl_EmployeeLedgerDataTable(dataSet.Tables["tbl_EmployeeLedger"]));
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
		tabletbl_EmployeeLedger = (tbl_EmployeeLedgerDataTable)base.Tables["tbl_EmployeeLedger"];
		if (initTable && tabletbl_EmployeeLedger != null)
		{
			tabletbl_EmployeeLedger.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "dSetEmployeeLedger";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/dSetEmployeeLedger.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tabletbl_EmployeeLedger = new tbl_EmployeeLedgerDataTable();
		base.Tables.Add(tabletbl_EmployeeLedger);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializetbl_EmployeeLedger()
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
		dSetEmployeeLedger dSetEmployeeLedger2 = new dSetEmployeeLedger();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = dSetEmployeeLedger2.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = dSetEmployeeLedger2.GetSchemaSerializable();
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
