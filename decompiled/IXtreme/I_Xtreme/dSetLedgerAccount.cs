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
[XmlRoot("dSetLedgerAccount")]
[HelpKeyword("vs.data.DataSet")]
public class dSetLedgerAccount : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void View_Studentledger_FinalRowChangeEventHandler(object sender, View_Studentledger_FinalRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class View_Studentledger_FinalDataTable : TypedTableBase<View_Studentledger_FinalRow>
	{
		private DataColumn columnfullName;

		private DataColumn columnClassId;

		private DataColumn columnStreamId;

		private DataColumn columnStudyStatus;

		private DataColumn columnSex;

		private DataColumn columnPicture;

		private DataColumn columnStudentNumber;

		private DataColumn columnPaymentId;

		private DataColumn columnDateOfPayment;

		private DataColumn columnSemesterId;

		private DataColumn columnParticulars;

		private DataColumn columnDebit;

		private DataColumn columnCredit;

		private DataColumn columnBalance;

		private DataColumn columnBankSlipNo;

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
		public DataColumn PictureColumn => columnPicture;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PaymentIdColumn => columnPaymentId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DateOfPaymentColumn => columnDateOfPayment;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SemesterIdColumn => columnSemesterId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ParticularsColumn => columnParticulars;

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
		public DataColumn BankSlipNoColumn => columnBankSlipNo;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalRow this[int index] => (View_Studentledger_FinalRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event View_Studentledger_FinalRowChangeEventHandler View_Studentledger_FinalRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event View_Studentledger_FinalRowChangeEventHandler View_Studentledger_FinalRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event View_Studentledger_FinalRowChangeEventHandler View_Studentledger_FinalRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event View_Studentledger_FinalRowChangeEventHandler View_Studentledger_FinalRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalDataTable()
		{
			base.TableName = "View_Studentledger_Final";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal View_Studentledger_FinalDataTable(DataTable table)
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
		protected View_Studentledger_FinalDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddView_Studentledger_FinalRow(View_Studentledger_FinalRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalRow AddView_Studentledger_FinalRow(string fullName, string ClassId, string StreamId, string StudyStatus, string Sex, byte[] Picture, string StudentNumber, long PaymentId, DateTime DateOfPayment, string SemesterId, string Particulars, decimal Debit, decimal Credit, decimal Balance, string BankSlipNo)
		{
			View_Studentledger_FinalRow view_Studentledger_FinalRow = (View_Studentledger_FinalRow)NewRow();
			object[] itemArray = new object[15]
			{
				fullName, ClassId, StreamId, StudyStatus, Sex, Picture, StudentNumber, PaymentId, DateOfPayment, SemesterId,
				Particulars, Debit, Credit, Balance, BankSlipNo
			};
			view_Studentledger_FinalRow.ItemArray = itemArray;
			base.Rows.Add(view_Studentledger_FinalRow);
			return view_Studentledger_FinalRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalRow FindByStudentNumberPaymentId(string StudentNumber, long PaymentId)
		{
			return (View_Studentledger_FinalRow)base.Rows.Find(new object[2] { StudentNumber, PaymentId });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			View_Studentledger_FinalDataTable view_Studentledger_FinalDataTable = (View_Studentledger_FinalDataTable)base.Clone();
			view_Studentledger_FinalDataTable.InitVars();
			return view_Studentledger_FinalDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new View_Studentledger_FinalDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnfullName = base.Columns["fullName"];
			columnClassId = base.Columns["ClassId"];
			columnStreamId = base.Columns["StreamId"];
			columnStudyStatus = base.Columns["StudyStatus"];
			columnSex = base.Columns["Sex"];
			columnPicture = base.Columns["Picture"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnPaymentId = base.Columns["PaymentId"];
			columnDateOfPayment = base.Columns["DateOfPayment"];
			columnSemesterId = base.Columns["SemesterId"];
			columnParticulars = base.Columns["Particulars"];
			columnDebit = base.Columns["Debit"];
			columnCredit = base.Columns["Credit"];
			columnBalance = base.Columns["Balance"];
			columnBankSlipNo = base.Columns["BankSlipNo"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
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
			columnPicture = new DataColumn("Picture", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPicture);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnPaymentId = new DataColumn("PaymentId", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnPaymentId);
			columnDateOfPayment = new DataColumn("DateOfPayment", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDateOfPayment);
			columnSemesterId = new DataColumn("SemesterId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSemesterId);
			columnParticulars = new DataColumn("Particulars", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnParticulars);
			columnDebit = new DataColumn("Debit", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnDebit);
			columnCredit = new DataColumn("Credit", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnCredit);
			columnBalance = new DataColumn("Balance", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnBalance);
			columnBankSlipNo = new DataColumn("BankSlipNo", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBankSlipNo);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[2] { columnStudentNumber, columnPaymentId }, isPrimaryKey: true));
			columnfullName.MaxLength = 100;
			columnClassId.MaxLength = 50;
			columnStreamId.MaxLength = 50;
			columnStudyStatus.MaxLength = 1;
			columnSex.MaxLength = 1;
			columnStudentNumber.AllowDBNull = false;
			columnStudentNumber.MaxLength = 50;
			columnPaymentId.AllowDBNull = false;
			columnSemesterId.MaxLength = 18;
			columnParticulars.MaxLength = 50;
			columnBankSlipNo.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalRow NewView_Studentledger_FinalRow()
		{
			return (View_Studentledger_FinalRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new View_Studentledger_FinalRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(View_Studentledger_FinalRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.View_Studentledger_FinalRowChanged != null)
			{
				this.View_Studentledger_FinalRowChanged(this, new View_Studentledger_FinalRowChangeEvent((View_Studentledger_FinalRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.View_Studentledger_FinalRowChanging != null)
			{
				this.View_Studentledger_FinalRowChanging(this, new View_Studentledger_FinalRowChangeEvent((View_Studentledger_FinalRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.View_Studentledger_FinalRowDeleted != null)
			{
				this.View_Studentledger_FinalRowDeleted(this, new View_Studentledger_FinalRowChangeEvent((View_Studentledger_FinalRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.View_Studentledger_FinalRowDeleting != null)
			{
				this.View_Studentledger_FinalRowDeleting(this, new View_Studentledger_FinalRowChangeEvent((View_Studentledger_FinalRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveView_Studentledger_FinalRow(View_Studentledger_FinalRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			dSetLedgerAccount dSetLedgerAccount2 = new dSetLedgerAccount();
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
			xmlSchemaAttribute.FixedValue = dSetLedgerAccount2.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "View_Studentledger_FinalDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dSetLedgerAccount2.GetSchemaSerializable();
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

	public class View_Studentledger_FinalRow : DataRow
	{
		private View_Studentledger_FinalDataTable tableView_Studentledger_Final;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fullName
		{
			get
			{
				try
				{
					return (string)base[tableView_Studentledger_Final.fullNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullName' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.fullNameColumn] = value;
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
					return (string)base[tableView_Studentledger_Final.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.ClassIdColumn] = value;
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
					return (string)base[tableView_Studentledger_Final.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.StreamIdColumn] = value;
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
					return (string)base[tableView_Studentledger_Final.StudyStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudyStatus' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.StudyStatusColumn] = value;
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
					return (string)base[tableView_Studentledger_Final.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.SexColumn] = value;
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
					return (byte[])base[tableView_Studentledger_Final.PictureColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Picture' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.PictureColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				return (string)base[tableView_Studentledger_Final.StudentNumberColumn];
			}
			set
			{
				base[tableView_Studentledger_Final.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long PaymentId
		{
			get
			{
				return (long)base[tableView_Studentledger_Final.PaymentIdColumn];
			}
			set
			{
				base[tableView_Studentledger_Final.PaymentIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime DateOfPayment
		{
			get
			{
				try
				{
					return (DateTime)base[tableView_Studentledger_Final.DateOfPaymentColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOfPayment' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.DateOfPaymentColumn] = value;
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
					return (string)base[tableView_Studentledger_Final.SemesterIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SemesterId' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.SemesterIdColumn] = value;
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
					return (string)base[tableView_Studentledger_Final.ParticularsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Particulars' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.ParticularsColumn] = value;
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
					return (decimal)base[tableView_Studentledger_Final.DebitColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Debit' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.DebitColumn] = value;
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
					return (decimal)base[tableView_Studentledger_Final.CreditColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Credit' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.CreditColumn] = value;
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
					return (decimal)base[tableView_Studentledger_Final.BalanceColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Balance' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.BalanceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string BankSlipNo
		{
			get
			{
				try
				{
					return (string)base[tableView_Studentledger_Final.BankSlipNoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BankSlipNo' in table 'View_Studentledger_Final' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableView_Studentledger_Final.BankSlipNoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal View_Studentledger_FinalRow(DataRowBuilder rb)
			: base(rb)
		{
			tableView_Studentledger_Final = (View_Studentledger_FinalDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameNull()
		{
			return IsNull(tableView_Studentledger_Final.fullNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameNull()
		{
			base[tableView_Studentledger_Final.fullNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tableView_Studentledger_Final.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tableView_Studentledger_Final.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tableView_Studentledger_Final.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tableView_Studentledger_Final.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudyStatusNull()
		{
			return IsNull(tableView_Studentledger_Final.StudyStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudyStatusNull()
		{
			base[tableView_Studentledger_Final.StudyStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tableView_Studentledger_Final.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tableView_Studentledger_Final.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPictureNull()
		{
			return IsNull(tableView_Studentledger_Final.PictureColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPictureNull()
		{
			base[tableView_Studentledger_Final.PictureColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDateOfPaymentNull()
		{
			return IsNull(tableView_Studentledger_Final.DateOfPaymentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDateOfPaymentNull()
		{
			base[tableView_Studentledger_Final.DateOfPaymentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSemesterIdNull()
		{
			return IsNull(tableView_Studentledger_Final.SemesterIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSemesterIdNull()
		{
			base[tableView_Studentledger_Final.SemesterIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsParticularsNull()
		{
			return IsNull(tableView_Studentledger_Final.ParticularsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetParticularsNull()
		{
			base[tableView_Studentledger_Final.ParticularsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDebitNull()
		{
			return IsNull(tableView_Studentledger_Final.DebitColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDebitNull()
		{
			base[tableView_Studentledger_Final.DebitColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCreditNull()
		{
			return IsNull(tableView_Studentledger_Final.CreditColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCreditNull()
		{
			base[tableView_Studentledger_Final.CreditColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBalanceNull()
		{
			return IsNull(tableView_Studentledger_Final.BalanceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBalanceNull()
		{
			base[tableView_Studentledger_Final.BalanceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBankSlipNoNull()
		{
			return IsNull(tableView_Studentledger_Final.BankSlipNoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBankSlipNoNull()
		{
			base[tableView_Studentledger_Final.BankSlipNoColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class View_Studentledger_FinalRowChangeEvent : EventArgs
	{
		private View_Studentledger_FinalRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public View_Studentledger_FinalRowChangeEvent(View_Studentledger_FinalRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private View_Studentledger_FinalDataTable tableView_Studentledger_Final;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public View_Studentledger_FinalDataTable View_Studentledger_Final => tableView_Studentledger_Final;

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
	public dSetLedgerAccount()
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
	protected dSetLedgerAccount(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["View_Studentledger_Final"] != null)
			{
				base.Tables.Add(new View_Studentledger_FinalDataTable(dataSet.Tables["View_Studentledger_Final"]));
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
		dSetLedgerAccount dSetLedgerAccount2 = (dSetLedgerAccount)base.Clone();
		dSetLedgerAccount2.InitVars();
		dSetLedgerAccount2.SchemaSerializationMode = SchemaSerializationMode;
		return dSetLedgerAccount2;
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
			if (dataSet.Tables["View_Studentledger_Final"] != null)
			{
				base.Tables.Add(new View_Studentledger_FinalDataTable(dataSet.Tables["View_Studentledger_Final"]));
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
		tableView_Studentledger_Final = (View_Studentledger_FinalDataTable)base.Tables["View_Studentledger_Final"];
		if (initTable && tableView_Studentledger_Final != null)
		{
			tableView_Studentledger_Final.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "dSetLedgerAccount";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/dSetLedgerAccount.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableView_Studentledger_Final = new View_Studentledger_FinalDataTable();
		base.Tables.Add(tableView_Studentledger_Final);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeView_Studentledger_Final()
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
		dSetLedgerAccount dSetLedgerAccount2 = new dSetLedgerAccount();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = dSetLedgerAccount2.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = dSetLedgerAccount2.GetSchemaSerializable();
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
