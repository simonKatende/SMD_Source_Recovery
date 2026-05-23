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
[XmlRoot("dSetStaff")]
[HelpKeyword("vs.data.DataSet")]
public class dSetStaff : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void StaffRowChangeEventHandler(object sender, StaffRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class StaffDataTable : TypedTableBase<StaffRow>
	{
		private DataColumn columnStaffName;

		private DataColumn columnStaffId;

		private DataColumn columnFirstName;

		private DataColumn columnLastName;

		private DataColumn columnContactNumber;

		private DataColumn columnAddress;

		private DataColumn columnSex;

		private DataColumn columnResponsibility;

		private DataColumn columnHouseId;

		private DataColumn columnQualification;

		private DataColumn columnDateOfHire;

		private DataColumn columnSalaryAmount;

		private DataColumn columnunTaxableAmount;

		private DataColumn columnpayeeRate;

		private DataColumn columnpayee;

		private DataColumn columnNetPay;

		private DataColumn columnWorkingStatus;

		private DataColumn columnPic;

		private DataColumn columnFormerEmployee;

		private DataColumn columnstatus;

		private DataColumn columnNSSF;

		private DataColumn columnNSSFRate;

		private DataColumn columnNotes;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StaffNameColumn => columnStaffName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StaffIdColumn => columnStaffId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FirstNameColumn => columnFirstName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn LastNameColumn => columnLastName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ContactNumberColumn => columnContactNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AddressColumn => columnAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SexColumn => columnSex;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ResponsibilityColumn => columnResponsibility;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HouseIdColumn => columnHouseId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn QualificationColumn => columnQualification;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DateOfHireColumn => columnDateOfHire;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SalaryAmountColumn => columnSalaryAmount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn unTaxableAmountColumn => columnunTaxableAmount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn payeeRateColumn => columnpayeeRate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn payeeColumn => columnpayee;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NetPayColumn => columnNetPay;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn WorkingStatusColumn => columnWorkingStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PicColumn => columnPic;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FormerEmployeeColumn => columnFormerEmployee;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn statusColumn => columnstatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NSSFColumn => columnNSSF;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NSSFRateColumn => columnNSSFRate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NotesColumn => columnNotes;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffRow this[int index] => (StaffRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StaffRowChangeEventHandler StaffRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StaffRowChangeEventHandler StaffRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StaffRowChangeEventHandler StaffRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StaffRowChangeEventHandler StaffRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffDataTable()
		{
			base.TableName = "Staff";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal StaffDataTable(DataTable table)
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
		protected StaffDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddStaffRow(StaffRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffRow AddStaffRow(string StaffName, string StaffId, string FirstName, string LastName, string ContactNumber, string Address, string Sex, string Responsibility, string HouseId, string Qualification, DateTime DateOfHire, decimal SalaryAmount, decimal unTaxableAmount, double payeeRate, decimal payee, decimal NetPay, string WorkingStatus, byte[] Pic, string FormerEmployee, string status, decimal NSSF, double NSSFRate, string Notes)
		{
			StaffRow staffRow = (StaffRow)NewRow();
			object[] itemArray = new object[23]
			{
				StaffName, StaffId, FirstName, LastName, ContactNumber, Address, Sex, Responsibility, HouseId, Qualification,
				DateOfHire, SalaryAmount, unTaxableAmount, payeeRate, payee, NetPay, WorkingStatus, Pic, FormerEmployee, status,
				NSSF, NSSFRate, Notes
			};
			staffRow.ItemArray = itemArray;
			base.Rows.Add(staffRow);
			return staffRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffRow FindByStaffId(string StaffId)
		{
			return (StaffRow)base.Rows.Find(new object[1] { StaffId });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			StaffDataTable staffDataTable = (StaffDataTable)base.Clone();
			staffDataTable.InitVars();
			return staffDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new StaffDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnStaffName = base.Columns["StaffName"];
			columnStaffId = base.Columns["StaffId"];
			columnFirstName = base.Columns["FirstName"];
			columnLastName = base.Columns["LastName"];
			columnContactNumber = base.Columns["ContactNumber"];
			columnAddress = base.Columns["Address"];
			columnSex = base.Columns["Sex"];
			columnResponsibility = base.Columns["Responsibility"];
			columnHouseId = base.Columns["HouseId"];
			columnQualification = base.Columns["Qualification"];
			columnDateOfHire = base.Columns["DateOfHire"];
			columnSalaryAmount = base.Columns["SalaryAmount"];
			columnunTaxableAmount = base.Columns["unTaxableAmount"];
			columnpayeeRate = base.Columns["payeeRate"];
			columnpayee = base.Columns["payee"];
			columnNetPay = base.Columns["NetPay"];
			columnWorkingStatus = base.Columns["WorkingStatus"];
			columnPic = base.Columns["Pic"];
			columnFormerEmployee = base.Columns["FormerEmployee"];
			columnstatus = base.Columns["status"];
			columnNSSF = base.Columns["NSSF"];
			columnNSSFRate = base.Columns["NSSFRate"];
			columnNotes = base.Columns["Notes"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnStaffName = new DataColumn("StaffName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStaffName);
			columnStaffId = new DataColumn("StaffId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStaffId);
			columnFirstName = new DataColumn("FirstName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFirstName);
			columnLastName = new DataColumn("LastName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnLastName);
			columnContactNumber = new DataColumn("ContactNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnContactNumber);
			columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAddress);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnResponsibility = new DataColumn("Responsibility", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnResponsibility);
			columnHouseId = new DataColumn("HouseId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHouseId);
			columnQualification = new DataColumn("Qualification", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnQualification);
			columnDateOfHire = new DataColumn("DateOfHire", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDateOfHire);
			columnSalaryAmount = new DataColumn("SalaryAmount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnSalaryAmount);
			columnunTaxableAmount = new DataColumn("unTaxableAmount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnunTaxableAmount);
			columnpayeeRate = new DataColumn("payeeRate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnpayeeRate);
			columnpayee = new DataColumn("payee", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnpayee);
			columnNetPay = new DataColumn("NetPay", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnNetPay);
			columnWorkingStatus = new DataColumn("WorkingStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnWorkingStatus);
			columnPic = new DataColumn("Pic", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPic);
			columnFormerEmployee = new DataColumn("FormerEmployee", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFormerEmployee);
			columnstatus = new DataColumn("status", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnstatus);
			columnNSSF = new DataColumn("NSSF", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnNSSF);
			columnNSSFRate = new DataColumn("NSSFRate", typeof(double), null, MappingType.Element);
			base.Columns.Add(columnNSSFRate);
			columnNotes = new DataColumn("Notes", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNotes);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnStaffId }, isPrimaryKey: true));
			columnStaffName.MaxLength = 80;
			columnStaffId.AllowDBNull = false;
			columnStaffId.Unique = true;
			columnStaffId.MaxLength = 50;
			columnFirstName.MaxLength = 50;
			columnLastName.MaxLength = 50;
			columnContactNumber.MaxLength = 50;
			columnAddress.MaxLength = 50;
			columnSex.MaxLength = 1;
			columnResponsibility.MaxLength = 50;
			columnHouseId.MaxLength = 50;
			columnQualification.MaxLength = 50;
			columnWorkingStatus.MaxLength = 25;
			columnFormerEmployee.MaxLength = 50;
			columnstatus.MaxLength = 20;
			columnNotes.MaxLength = int.MaxValue;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffRow NewStaffRow()
		{
			return (StaffRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new StaffRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(StaffRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.StaffRowChanged != null)
			{
				this.StaffRowChanged(this, new StaffRowChangeEvent((StaffRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.StaffRowChanging != null)
			{
				this.StaffRowChanging(this, new StaffRowChangeEvent((StaffRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.StaffRowDeleted != null)
			{
				this.StaffRowDeleted(this, new StaffRowChangeEvent((StaffRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.StaffRowDeleting != null)
			{
				this.StaffRowDeleting(this, new StaffRowChangeEvent((StaffRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveStaffRow(StaffRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			dSetStaff dSetStaff2 = new dSetStaff();
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
			xmlSchemaAttribute.FixedValue = dSetStaff2.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "StaffDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dSetStaff2.GetSchemaSerializable();
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

	public class StaffRow : DataRow
	{
		private StaffDataTable tableStaff;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StaffName
		{
			get
			{
				try
				{
					return (string)base[tableStaff.StaffNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StaffName' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.StaffNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StaffId
		{
			get
			{
				return (string)base[tableStaff.StaffIdColumn];
			}
			set
			{
				base[tableStaff.StaffIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string FirstName
		{
			get
			{
				try
				{
					return (string)base[tableStaff.FirstNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FirstName' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.FirstNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string LastName
		{
			get
			{
				try
				{
					return (string)base[tableStaff.LastNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'LastName' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.LastNameColumn] = value;
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
					return (string)base[tableStaff.ContactNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ContactNumber' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.ContactNumberColumn] = value;
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
					return (string)base[tableStaff.AddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Address' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.AddressColumn] = value;
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
					return (string)base[tableStaff.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.SexColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Responsibility
		{
			get
			{
				try
				{
					return (string)base[tableStaff.ResponsibilityColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Responsibility' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.ResponsibilityColumn] = value;
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
					return (string)base[tableStaff.HouseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseId' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.HouseIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Qualification
		{
			get
			{
				try
				{
					return (string)base[tableStaff.QualificationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Qualification' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.QualificationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime DateOfHire
		{
			get
			{
				try
				{
					return (DateTime)base[tableStaff.DateOfHireColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DateOfHire' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.DateOfHireColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal SalaryAmount
		{
			get
			{
				try
				{
					return (decimal)base[tableStaff.SalaryAmountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SalaryAmount' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.SalaryAmountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal unTaxableAmount
		{
			get
			{
				try
				{
					return (decimal)base[tableStaff.unTaxableAmountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'unTaxableAmount' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.unTaxableAmountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double payeeRate
		{
			get
			{
				try
				{
					return (double)base[tableStaff.payeeRateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'payeeRate' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.payeeRateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal payee
		{
			get
			{
				try
				{
					return (decimal)base[tableStaff.payeeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'payee' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.payeeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal NetPay
		{
			get
			{
				try
				{
					return (decimal)base[tableStaff.NetPayColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NetPay' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.NetPayColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string WorkingStatus
		{
			get
			{
				try
				{
					return (string)base[tableStaff.WorkingStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'WorkingStatus' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.WorkingStatusColumn] = value;
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
					return (byte[])base[tableStaff.PicColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Pic' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.PicColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string FormerEmployee
		{
			get
			{
				try
				{
					return (string)base[tableStaff.FormerEmployeeColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FormerEmployee' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.FormerEmployeeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string status
		{
			get
			{
				try
				{
					return (string)base[tableStaff.statusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'status' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.statusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal NSSF
		{
			get
			{
				try
				{
					return (decimal)base[tableStaff.NSSFColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NSSF' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.NSSFColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public double NSSFRate
		{
			get
			{
				try
				{
					return (double)base[tableStaff.NSSFRateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'NSSFRate' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.NSSFRateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Notes
		{
			get
			{
				try
				{
					return (string)base[tableStaff.NotesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Notes' in table 'Staff' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStaff.NotesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal StaffRow(DataRowBuilder rb)
			: base(rb)
		{
			tableStaff = (StaffDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStaffNameNull()
		{
			return IsNull(tableStaff.StaffNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStaffNameNull()
		{
			base[tableStaff.StaffNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFirstNameNull()
		{
			return IsNull(tableStaff.FirstNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFirstNameNull()
		{
			base[tableStaff.FirstNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsLastNameNull()
		{
			return IsNull(tableStaff.LastNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetLastNameNull()
		{
			base[tableStaff.LastNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsContactNumberNull()
		{
			return IsNull(tableStaff.ContactNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetContactNumberNull()
		{
			base[tableStaff.ContactNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAddressNull()
		{
			return IsNull(tableStaff.AddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAddressNull()
		{
			base[tableStaff.AddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tableStaff.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tableStaff.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsResponsibilityNull()
		{
			return IsNull(tableStaff.ResponsibilityColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetResponsibilityNull()
		{
			base[tableStaff.ResponsibilityColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHouseIdNull()
		{
			return IsNull(tableStaff.HouseIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHouseIdNull()
		{
			base[tableStaff.HouseIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsQualificationNull()
		{
			return IsNull(tableStaff.QualificationColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetQualificationNull()
		{
			base[tableStaff.QualificationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDateOfHireNull()
		{
			return IsNull(tableStaff.DateOfHireColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDateOfHireNull()
		{
			base[tableStaff.DateOfHireColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSalaryAmountNull()
		{
			return IsNull(tableStaff.SalaryAmountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSalaryAmountNull()
		{
			base[tableStaff.SalaryAmountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsunTaxableAmountNull()
		{
			return IsNull(tableStaff.unTaxableAmountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetunTaxableAmountNull()
		{
			base[tableStaff.unTaxableAmountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IspayeeRateNull()
		{
			return IsNull(tableStaff.payeeRateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetpayeeRateNull()
		{
			base[tableStaff.payeeRateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IspayeeNull()
		{
			return IsNull(tableStaff.payeeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetpayeeNull()
		{
			base[tableStaff.payeeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNetPayNull()
		{
			return IsNull(tableStaff.NetPayColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNetPayNull()
		{
			base[tableStaff.NetPayColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsWorkingStatusNull()
		{
			return IsNull(tableStaff.WorkingStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetWorkingStatusNull()
		{
			base[tableStaff.WorkingStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPicNull()
		{
			return IsNull(tableStaff.PicColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPicNull()
		{
			base[tableStaff.PicColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFormerEmployeeNull()
		{
			return IsNull(tableStaff.FormerEmployeeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFormerEmployeeNull()
		{
			base[tableStaff.FormerEmployeeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsstatusNull()
		{
			return IsNull(tableStaff.statusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetstatusNull()
		{
			base[tableStaff.statusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNSSFNull()
		{
			return IsNull(tableStaff.NSSFColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNSSFNull()
		{
			base[tableStaff.NSSFColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNSSFRateNull()
		{
			return IsNull(tableStaff.NSSFRateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNSSFRateNull()
		{
			base[tableStaff.NSSFRateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNotesNull()
		{
			return IsNull(tableStaff.NotesColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNotesNull()
		{
			base[tableStaff.NotesColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class StaffRowChangeEvent : EventArgs
	{
		private StaffRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StaffRowChangeEvent(StaffRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private StaffDataTable tableStaff;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public StaffDataTable Staff => tableStaff;

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
	public dSetStaff()
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
	protected dSetStaff(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["Staff"] != null)
			{
				base.Tables.Add(new StaffDataTable(dataSet.Tables["Staff"]));
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
		dSetStaff dSetStaff2 = (dSetStaff)base.Clone();
		dSetStaff2.InitVars();
		dSetStaff2.SchemaSerializationMode = SchemaSerializationMode;
		return dSetStaff2;
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
			if (dataSet.Tables["Staff"] != null)
			{
				base.Tables.Add(new StaffDataTable(dataSet.Tables["Staff"]));
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
		tableStaff = (StaffDataTable)base.Tables["Staff"];
		if (initTable && tableStaff != null)
		{
			tableStaff.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "dSetStaff";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/dSetStaff.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableStaff = new StaffDataTable();
		base.Tables.Add(tableStaff);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeStaff()
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
		dSetStaff dSetStaff2 = new dSetStaff();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = dSetStaff2.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = dSetStaff2.GetSchemaSerializable();
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
