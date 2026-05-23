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

namespace I_Xtreme.PaymentVoucher;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("PaymentVoucher")]
[HelpKeyword("vs.data.DataSet")]
public class PaymentVoucher : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void PaymentVoucherRowChangeEventHandler(object sender, PaymentVoucherRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class PaymentVoucherDataTable : TypedTableBase<PaymentVoucherRow>
	{
		private DataColumn columnExpenseid;

		private DataColumn columnExpenseName;

		private DataColumn columnexpenseSource;

		private DataColumn columnqty;

		private DataColumn columnunits;

		private DataColumn columnPaymentMode;

		private DataColumn columnChequeNo;

		private DataColumn columnVoucherNo;

		private DataColumn columnExpenseValue;

		private DataColumn columnDateOfExpense;

		private DataColumn columnSemesterId;

		private DataColumn columnNarration;

		private DataColumn columnDebitor;

		private DataColumn columnCaptureDate;

		private DataColumn columnNarrationBig;

		private DataColumn columnContact;

		private DataColumn columnAddress;

		private DataColumn columnPayee;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ExpenseidColumn => columnExpenseid;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ExpenseNameColumn => columnExpenseName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn expenseSourceColumn => columnexpenseSource;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn qtyColumn => columnqty;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn unitsColumn => columnunits;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PaymentModeColumn => columnPaymentMode;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ChequeNoColumn => columnChequeNo;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn VoucherNoColumn => columnVoucherNo;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ExpenseValueColumn => columnExpenseValue;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DateOfExpenseColumn => columnDateOfExpense;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SemesterIdColumn => columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NarrationColumn => columnNarration;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DebitorColumn => columnDebitor;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CaptureDateColumn => columnCaptureDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NarrationBigColumn => columnNarrationBig;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ContactColumn => columnContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AddressColumn => columnAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PayeeColumn => columnPayee;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherRow this[int index] => (PaymentVoucherRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PaymentVoucherRowChangeEventHandler PaymentVoucherRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PaymentVoucherRowChangeEventHandler PaymentVoucherRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PaymentVoucherRowChangeEventHandler PaymentVoucherRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event PaymentVoucherRowChangeEventHandler PaymentVoucherRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherDataTable()
		{
			base.TableName = "PaymentVoucher";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal PaymentVoucherDataTable(DataTable table)
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
		protected PaymentVoucherDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddPaymentVoucherRow(PaymentVoucherRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherRow AddPaymentVoucherRow(string ExpenseName, string expenseSource, int qty, string units, string PaymentMode, string ChequeNo, string VoucherNo, decimal ExpenseValue, DateTime DateOfExpense, string SemesterId, string Narration, string Debitor, string CaptureDate, string NarrationBig, string Contact, string Address, string Payee)
		{
			PaymentVoucherRow paymentVoucherRow = (PaymentVoucherRow)NewRow();
			object[] itemArray = new object[18]
			{
				null, ExpenseName, expenseSource, qty, units, PaymentMode, ChequeNo, VoucherNo, ExpenseValue, DateOfExpense,
				SemesterId, Narration, Debitor, CaptureDate, NarrationBig, Contact, Address, Payee
			};
			paymentVoucherRow.ItemArray = itemArray;
			base.Rows.Add(paymentVoucherRow);
			return paymentVoucherRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherRow FindByExpenseid(long Expenseid)
		{
			return (PaymentVoucherRow)base.Rows.Find(new object[1] { Expenseid });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			PaymentVoucherDataTable paymentVoucherDataTable = (PaymentVoucherDataTable)base.Clone();
			paymentVoucherDataTable.InitVars();
			return paymentVoucherDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new PaymentVoucherDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnExpenseid = base.Columns["Expenseid"];
			columnExpenseName = base.Columns["ExpenseName"];
			columnexpenseSource = base.Columns["expenseSource"];
			columnqty = base.Columns["qty"];
			columnunits = base.Columns["units"];
			columnPaymentMode = base.Columns["PaymentMode"];
			columnChequeNo = base.Columns["ChequeNo"];
			columnVoucherNo = base.Columns["VoucherNo"];
			columnExpenseValue = base.Columns["ExpenseValue"];
			columnDateOfExpense = base.Columns["DateOfExpense"];
			columnSemesterId = base.Columns["SemesterId"];
			columnNarration = base.Columns["Narration"];
			columnDebitor = base.Columns["Debitor"];
			columnCaptureDate = base.Columns["CaptureDate"];
			columnNarrationBig = base.Columns["NarrationBig"];
			columnContact = base.Columns["Contact"];
			columnAddress = base.Columns["Address"];
			columnPayee = base.Columns["Payee"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnExpenseid = new DataColumn("Expenseid", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnExpenseid);
			columnExpenseName = new DataColumn("ExpenseName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnExpenseName);
			columnexpenseSource = new DataColumn("expenseSource", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnexpenseSource);
			columnqty = new DataColumn("qty", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnqty);
			columnunits = new DataColumn("units", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnunits);
			columnPaymentMode = new DataColumn("PaymentMode", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPaymentMode);
			columnChequeNo = new DataColumn("ChequeNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnChequeNo);
			columnVoucherNo = new DataColumn("VoucherNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnVoucherNo);
			columnExpenseValue = new DataColumn("ExpenseValue", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnExpenseValue);
			columnDateOfExpense = new DataColumn("DateOfExpense", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDateOfExpense);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnNarration = new DataColumn("Narration", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNarration);
			columnDebitor = new DataColumn("Debitor", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnDebitor);
			columnCaptureDate = new DataColumn("CaptureDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnCaptureDate);
			columnNarrationBig = new DataColumn("NarrationBig", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNarrationBig);
			columnContact = new DataColumn("Contact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContact);
			columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAddress);
			columnPayee = new DataColumn("Payee", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPayee);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnExpenseid }, isPrimaryKey: true));
			columnExpenseid.AutoIncrement = true;
			columnExpenseid.AutoIncrementSeed = -1L;
			columnExpenseid.AutoIncrementStep = -1L;
			columnExpenseid.AllowDBNull = false;
			columnExpenseid.ReadOnly = true;
			columnExpenseid.Unique = true;
			columnExpenseName.MaxLength = 50;
			columnexpenseSource.MaxLength = 50;
			columnunits.MaxLength = 35;
			columnPaymentMode.MaxLength = 20;
			columnChequeNo.MaxLength = 20;
			columnVoucherNo.MaxLength = 20;
			columnSemesterId.MaxLength = 50;
			columnNarration.MaxLength = 80;
			columnDebitor.MaxLength = 80;
			columnCaptureDate.MaxLength = 50;
			columnNarrationBig.MaxLength = 200;
			columnContact.MaxLength = 11;
			columnAddress.MaxLength = 100;
			columnPayee.MaxLength = 100;
			base.ExtendedProperties.Add("Generator_TablePropName", "_PaymentVoucher");
			base.ExtendedProperties.Add("Generator_UserTableName", "PaymentVoucher");
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherRow NewPaymentVoucherRow()
		{
			return (PaymentVoucherRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new PaymentVoucherRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(PaymentVoucherRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PaymentVoucherRowChanged != null)
			{
				this.PaymentVoucherRowChanged(this, new PaymentVoucherRowChangeEvent((PaymentVoucherRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PaymentVoucherRowChanging != null)
			{
				this.PaymentVoucherRowChanging(this, new PaymentVoucherRowChangeEvent((PaymentVoucherRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PaymentVoucherRowDeleted != null)
			{
				this.PaymentVoucherRowDeleted(this, new PaymentVoucherRowChangeEvent((PaymentVoucherRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PaymentVoucherRowDeleting != null)
			{
				this.PaymentVoucherRowDeleting(this, new PaymentVoucherRowChangeEvent((PaymentVoucherRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemovePaymentVoucherRow(PaymentVoucherRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			PaymentVoucher paymentVoucher = new PaymentVoucher();
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
			xmlSchemaAttribute.FixedValue = paymentVoucher.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "PaymentVoucherDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = paymentVoucher.GetSchemaSerializable();
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

	public class PaymentVoucherRow : DataRow
	{
		private PaymentVoucherDataTable tablePaymentVoucher;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long Expenseid
		{
			get
			{
				return (long)base[tablePaymentVoucher.ExpenseidColumn];
			}
			set
			{
				base[tablePaymentVoucher.ExpenseidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ExpenseName
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.ExpenseNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExpenseName' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.ExpenseNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string expenseSource
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.expenseSourceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'expenseSource' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.expenseSourceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int qty
		{
			get
			{
				try
				{
					return (int)base[tablePaymentVoucher.qtyColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'qty' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.qtyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string units
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.unitsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'units' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.unitsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string PaymentMode
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.PaymentModeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PaymentMode' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.PaymentModeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ChequeNo
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.ChequeNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ChequeNo' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.ChequeNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string VoucherNo
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.VoucherNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'VoucherNo' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.VoucherNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal ExpenseValue
		{
			get
			{
				try
				{
					return (decimal)base[tablePaymentVoucher.ExpenseValueColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ExpenseValue' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.ExpenseValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime DateOfExpense
		{
			get
			{
				try
				{
					return (DateTime)base[tablePaymentVoucher.DateOfExpenseColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOfExpense' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.DateOfExpenseColumn] = value;
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
					return (string)base[tablePaymentVoucher.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.SemesterIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Narration
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.NarrationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Narration' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.NarrationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Debitor
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.DebitorColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Debitor' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.DebitorColumn] = value;
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
					return (string)base[tablePaymentVoucher.CaptureDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'CaptureDate' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.CaptureDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string NarrationBig
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.NarrationBigColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NarrationBig' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.NarrationBigColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Contact
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.ContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Contact' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.ContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Address
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.AddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Address' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.AddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Payee
		{
			get
			{
				try
				{
					return (string)base[tablePaymentVoucher.PayeeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Payee' in table 'PaymentVoucher' is DBNull.", innerException);
				}
			}
			set
			{
				base[tablePaymentVoucher.PayeeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal PaymentVoucherRow(DataRowBuilder rb)
			: base(rb)
		{
			tablePaymentVoucher = (PaymentVoucherDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsExpenseNameNull()
		{
			return IsNull(tablePaymentVoucher.ExpenseNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetExpenseNameNull()
		{
			base[tablePaymentVoucher.ExpenseNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsexpenseSourceNull()
		{
			return IsNull(tablePaymentVoucher.expenseSourceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetexpenseSourceNull()
		{
			base[tablePaymentVoucher.expenseSourceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsqtyNull()
		{
			return IsNull(tablePaymentVoucher.qtyColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetqtyNull()
		{
			base[tablePaymentVoucher.qtyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsunitsNull()
		{
			return IsNull(tablePaymentVoucher.unitsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetunitsNull()
		{
			base[tablePaymentVoucher.unitsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPaymentModeNull()
		{
			return IsNull(tablePaymentVoucher.PaymentModeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPaymentModeNull()
		{
			base[tablePaymentVoucher.PaymentModeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsChequeNoNull()
		{
			return IsNull(tablePaymentVoucher.ChequeNoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetChequeNoNull()
		{
			base[tablePaymentVoucher.ChequeNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsVoucherNoNull()
		{
			return IsNull(tablePaymentVoucher.VoucherNoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetVoucherNoNull()
		{
			base[tablePaymentVoucher.VoucherNoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsExpenseValueNull()
		{
			return IsNull(tablePaymentVoucher.ExpenseValueColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetExpenseValueNull()
		{
			base[tablePaymentVoucher.ExpenseValueColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDateOfExpenseNull()
		{
			return IsNull(tablePaymentVoucher.DateOfExpenseColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDateOfExpenseNull()
		{
			base[tablePaymentVoucher.DateOfExpenseColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tablePaymentVoucher.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tablePaymentVoucher.SemesterIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNarrationNull()
		{
			return IsNull(tablePaymentVoucher.NarrationColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNarrationNull()
		{
			base[tablePaymentVoucher.NarrationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDebitorNull()
		{
			return IsNull(tablePaymentVoucher.DebitorColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDebitorNull()
		{
			base[tablePaymentVoucher.DebitorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCaptureDateNull()
		{
			return IsNull(tablePaymentVoucher.CaptureDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCaptureDateNull()
		{
			base[tablePaymentVoucher.CaptureDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNarrationBigNull()
		{
			return IsNull(tablePaymentVoucher.NarrationBigColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNarrationBigNull()
		{
			base[tablePaymentVoucher.NarrationBigColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsContactNull()
		{
			return IsNull(tablePaymentVoucher.ContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetContactNull()
		{
			base[tablePaymentVoucher.ContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAddressNull()
		{
			return IsNull(tablePaymentVoucher.AddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAddressNull()
		{
			base[tablePaymentVoucher.AddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPayeeNull()
		{
			return IsNull(tablePaymentVoucher.PayeeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPayeeNull()
		{
			base[tablePaymentVoucher.PayeeColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class PaymentVoucherRowChangeEvent : EventArgs
	{
		private PaymentVoucherRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public PaymentVoucherRowChangeEvent(PaymentVoucherRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private PaymentVoucherDataTable tablePaymentVoucher;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaymentVoucherDataTable _PaymentVoucher => tablePaymentVoucher;

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
	public PaymentVoucher()
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
	protected PaymentVoucher(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["PaymentVoucher"] != null)
			{
				base.Tables.Add(new PaymentVoucherDataTable(dataSet.Tables["PaymentVoucher"]));
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
		PaymentVoucher paymentVoucher = (PaymentVoucher)base.Clone();
		paymentVoucher.InitVars();
		paymentVoucher.SchemaSerializationMode = SchemaSerializationMode;
		return paymentVoucher;
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
			if (dataSet.Tables["PaymentVoucher"] != null)
			{
				base.Tables.Add(new PaymentVoucherDataTable(dataSet.Tables["PaymentVoucher"]));
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
		tablePaymentVoucher = (PaymentVoucherDataTable)base.Tables["PaymentVoucher"];
		if (initTable && tablePaymentVoucher != null)
		{
			tablePaymentVoucher.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "PaymentVoucher";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/PaymentVoucher.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tablePaymentVoucher = new PaymentVoucherDataTable();
		base.Tables.Add(tablePaymentVoucher);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerialize_PaymentVoucher()
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
		PaymentVoucher paymentVoucher = new PaymentVoucher();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = paymentVoucher.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = paymentVoucher.GetSchemaSerializable();
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
