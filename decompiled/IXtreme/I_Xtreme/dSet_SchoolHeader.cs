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
[XmlRoot("dSet_SchoolHeader")]
[HelpKeyword("vs.data.DataSet")]
public class dSet_SchoolHeader : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void SchoolDetailsRowChangeEventHandler(object sender, SchoolDetailsRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class SchoolDetailsDataTable : TypedTableBase<SchoolDetailsRow>
	{
		private DataColumn columnDetailId;

		private DataColumn columnSchoolName;

		private DataColumn columnschoolMotto;

		private DataColumn columnboxNumber;

		private DataColumn columnlocation;

		private DataColumn columnmobileContact;

		private DataColumn columnofficeContact;

		private DataColumn columnemailAddress;

		private DataColumn columnwebAddress;

		private DataColumn columnnetAddress;

		private DataColumn columnfullContact;

		private DataColumn columnlogo;

		private DataColumn columndistrict;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DetailIdColumn => columnDetailId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SchoolNameColumn => columnSchoolName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn schoolMottoColumn => columnschoolMotto;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn boxNumberColumn => columnboxNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn locationColumn => columnlocation;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn mobileContactColumn => columnmobileContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn officeContactColumn => columnofficeContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn emailAddressColumn => columnemailAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn webAddressColumn => columnwebAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn netAddressColumn => columnnetAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fullContactColumn => columnfullContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn logoColumn => columnlogo;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn districtColumn => columndistrict;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsRow this[int index] => (SchoolDetailsRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event SchoolDetailsRowChangeEventHandler SchoolDetailsRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event SchoolDetailsRowChangeEventHandler SchoolDetailsRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event SchoolDetailsRowChangeEventHandler SchoolDetailsRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event SchoolDetailsRowChangeEventHandler SchoolDetailsRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsDataTable()
		{
			base.TableName = "SchoolDetails";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal SchoolDetailsDataTable(DataTable table)
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
		protected SchoolDetailsDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddSchoolDetailsRow(SchoolDetailsRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsRow AddSchoolDetailsRow(string SchoolName, string schoolMotto, string boxNumber, string location, string mobileContact, string officeContact, string emailAddress, string webAddress, string netAddress, string fullContact, byte[] logo, string district)
		{
			SchoolDetailsRow schoolDetailsRow = (SchoolDetailsRow)NewRow();
			object[] itemArray = new object[13]
			{
				null, SchoolName, schoolMotto, boxNumber, location, mobileContact, officeContact, emailAddress, webAddress, netAddress,
				fullContact, logo, district
			};
			schoolDetailsRow.ItemArray = itemArray;
			base.Rows.Add(schoolDetailsRow);
			return schoolDetailsRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsRow FindByDetailId(int DetailId)
		{
			return (SchoolDetailsRow)base.Rows.Find(new object[1] { DetailId });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			SchoolDetailsDataTable schoolDetailsDataTable = (SchoolDetailsDataTable)base.Clone();
			schoolDetailsDataTable.InitVars();
			return schoolDetailsDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new SchoolDetailsDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnDetailId = base.Columns["DetailId"];
			columnSchoolName = base.Columns["SchoolName"];
			columnschoolMotto = base.Columns["schoolMotto"];
			columnboxNumber = base.Columns["boxNumber"];
			columnlocation = base.Columns["location"];
			columnmobileContact = base.Columns["mobileContact"];
			columnofficeContact = base.Columns["officeContact"];
			columnemailAddress = base.Columns["emailAddress"];
			columnwebAddress = base.Columns["webAddress"];
			columnnetAddress = base.Columns["netAddress"];
			columnfullContact = base.Columns["fullContact"];
			columnlogo = base.Columns["logo"];
			columndistrict = base.Columns["district"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnDetailId = new DataColumn("DetailId", typeof(int), null, MappingType.Element);
			base.Columns.Add(columnDetailId);
			columnSchoolName = new DataColumn("SchoolName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSchoolName);
			columnschoolMotto = new DataColumn("schoolMotto", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnschoolMotto);
			columnboxNumber = new DataColumn("boxNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnboxNumber);
			columnlocation = new DataColumn("location", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnlocation);
			columnmobileContact = new DataColumn("mobileContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmobileContact);
			columnofficeContact = new DataColumn("officeContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnofficeContact);
			columnemailAddress = new DataColumn("emailAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnemailAddress);
			columnwebAddress = new DataColumn("webAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnwebAddress);
			columnnetAddress = new DataColumn("netAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnnetAddress);
			columnfullContact = new DataColumn("fullContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfullContact);
			columnlogo = new DataColumn("logo", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnlogo);
			columndistrict = new DataColumn("district", typeof(string), null, MappingType.Element);
			base.Columns.Add(columndistrict);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnDetailId }, isPrimaryKey: true));
			columnDetailId.AutoIncrement = true;
			columnDetailId.AllowDBNull = false;
			columnDetailId.ReadOnly = true;
			columnDetailId.Unique = true;
			columnSchoolName.MaxLength = 80;
			columnschoolMotto.MaxLength = 60;
			columnboxNumber.MaxLength = 15;
			columnlocation.MaxLength = 200;
			columnmobileContact.MaxLength = 35;
			columnofficeContact.MaxLength = 35;
			columnemailAddress.MaxLength = 80;
			columnwebAddress.MaxLength = 80;
			columnnetAddress.MaxLength = 200;
			columnfullContact.MaxLength = 300;
			columndistrict.MaxLength = 30;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsRow NewSchoolDetailsRow()
		{
			return (SchoolDetailsRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new SchoolDetailsRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(SchoolDetailsRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.SchoolDetailsRowChanged != null)
			{
				this.SchoolDetailsRowChanged(this, new SchoolDetailsRowChangeEvent((SchoolDetailsRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.SchoolDetailsRowChanging != null)
			{
				this.SchoolDetailsRowChanging(this, new SchoolDetailsRowChangeEvent((SchoolDetailsRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.SchoolDetailsRowDeleted != null)
			{
				this.SchoolDetailsRowDeleted(this, new SchoolDetailsRowChangeEvent((SchoolDetailsRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.SchoolDetailsRowDeleting != null)
			{
				this.SchoolDetailsRowDeleting(this, new SchoolDetailsRowChangeEvent((SchoolDetailsRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveSchoolDetailsRow(SchoolDetailsRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			dSet_SchoolHeader dSet_SchoolHeader2 = new dSet_SchoolHeader();
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
			xmlSchemaAttribute.FixedValue = dSet_SchoolHeader2.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "SchoolDetailsDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = dSet_SchoolHeader2.GetSchemaSerializable();
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

	public class SchoolDetailsRow : DataRow
	{
		private SchoolDetailsDataTable tableSchoolDetails;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public int DetailId
		{
			get
			{
				return (int)base[tableSchoolDetails.DetailIdColumn];
			}
			set
			{
				base[tableSchoolDetails.DetailIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SchoolName
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.SchoolNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SchoolName' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.SchoolNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string schoolMotto
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.schoolMottoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'schoolMotto' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.schoolMottoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string boxNumber
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.boxNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'boxNumber' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.boxNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string location
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.locationColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'location' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.locationColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string mobileContact
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.mobileContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'mobileContact' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.mobileContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string officeContact
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.officeContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'officeContact' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.officeContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string emailAddress
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.emailAddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'emailAddress' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.emailAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string webAddress
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.webAddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'webAddress' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.webAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string netAddress
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.netAddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'netAddress' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.netAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fullContact
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.fullContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullContact' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.fullContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public byte[] logo
		{
			get
			{
				try
				{
					return (byte[])base[tableSchoolDetails.logoColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'logo' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.logoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string district
		{
			get
			{
				try
				{
					return (string)base[tableSchoolDetails.districtColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'district' in table 'SchoolDetails' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableSchoolDetails.districtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal SchoolDetailsRow(DataRowBuilder rb)
			: base(rb)
		{
			tableSchoolDetails = (SchoolDetailsDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSchoolNameNull()
		{
			return IsNull(tableSchoolDetails.SchoolNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSchoolNameNull()
		{
			base[tableSchoolDetails.SchoolNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsschoolMottoNull()
		{
			return IsNull(tableSchoolDetails.schoolMottoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetschoolMottoNull()
		{
			base[tableSchoolDetails.schoolMottoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsboxNumberNull()
		{
			return IsNull(tableSchoolDetails.boxNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetboxNumberNull()
		{
			base[tableSchoolDetails.boxNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IslocationNull()
		{
			return IsNull(tableSchoolDetails.locationColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetlocationNull()
		{
			base[tableSchoolDetails.locationColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsmobileContactNull()
		{
			return IsNull(tableSchoolDetails.mobileContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetmobileContactNull()
		{
			base[tableSchoolDetails.mobileContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsofficeContactNull()
		{
			return IsNull(tableSchoolDetails.officeContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetofficeContactNull()
		{
			base[tableSchoolDetails.officeContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsemailAddressNull()
		{
			return IsNull(tableSchoolDetails.emailAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetemailAddressNull()
		{
			base[tableSchoolDetails.emailAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IswebAddressNull()
		{
			return IsNull(tableSchoolDetails.webAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetwebAddressNull()
		{
			base[tableSchoolDetails.webAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsnetAddressNull()
		{
			return IsNull(tableSchoolDetails.netAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetnetAddressNull()
		{
			base[tableSchoolDetails.netAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullContactNull()
		{
			return IsNull(tableSchoolDetails.fullContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullContactNull()
		{
			base[tableSchoolDetails.fullContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IslogoNull()
		{
			return IsNull(tableSchoolDetails.logoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetlogoNull()
		{
			base[tableSchoolDetails.logoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsdistrictNull()
		{
			return IsNull(tableSchoolDetails.districtColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetdistrictNull()
		{
			base[tableSchoolDetails.districtColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class SchoolDetailsRowChangeEvent : EventArgs
	{
		private SchoolDetailsRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public SchoolDetailsRowChangeEvent(SchoolDetailsRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private SchoolDetailsDataTable tableSchoolDetails;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public SchoolDetailsDataTable SchoolDetails => tableSchoolDetails;

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
	public dSet_SchoolHeader()
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
	protected dSet_SchoolHeader(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["SchoolDetails"] != null)
			{
				base.Tables.Add(new SchoolDetailsDataTable(dataSet.Tables["SchoolDetails"]));
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
		dSet_SchoolHeader dSet_SchoolHeader2 = (dSet_SchoolHeader)base.Clone();
		dSet_SchoolHeader2.InitVars();
		dSet_SchoolHeader2.SchemaSerializationMode = SchemaSerializationMode;
		return dSet_SchoolHeader2;
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
			if (dataSet.Tables["SchoolDetails"] != null)
			{
				base.Tables.Add(new SchoolDetailsDataTable(dataSet.Tables["SchoolDetails"]));
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
		tableSchoolDetails = (SchoolDetailsDataTable)base.Tables["SchoolDetails"];
		if (initTable && tableSchoolDetails != null)
		{
			tableSchoolDetails.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "dSet_SchoolHeader";
		base.Prefix = "";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableSchoolDetails = new SchoolDetailsDataTable();
		base.Tables.Add(tableSchoolDetails);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeSchoolDetails()
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
		dSet_SchoolHeader dSet_SchoolHeader2 = new dSet_SchoolHeader();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = dSet_SchoolHeader2.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = dSet_SchoolHeader2.GetSchemaSerializable();
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
