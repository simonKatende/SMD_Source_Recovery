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

namespace I_Xtreme.RollCalls;

[Serializable]
[DesignerCategory("code")]
[ToolboxItem(true)]
[XmlSchemaProvider("GetTypedDataSetSchema")]
[XmlRoot("RollCallSource")]
[HelpKeyword("vs.data.DataSet")]
public class RollCallSource : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void AttendanceSheetRollCallRowChangeEventHandler(object sender, AttendanceSheetRollCallRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class AttendanceSheetRollCallDataTable : TypedTableBase<AttendanceSheetRollCallRow>
	{
		private DataColumn columnId;

		private DataColumn columnName;

		private DataColumn columnStudentNumber;

		private DataColumn columnStudentId;

		private DataColumn columnClassId;

		private DataColumn columnStreamId;

		private DataColumn columnDate1;

		private DataColumn columnDate2;

		private DataColumn columnDate3;

		private DataColumn columnDate4;

		private DataColumn columnDate5;

		private DataColumn columnDate6;

		private DataColumn columnDate7;

		private DataColumn columnFlag;

		private DataColumn columnDate8;

		private DataColumn columnDate9;

		private DataColumn columnDate10;

		private DataColumn columnDate11;

		private DataColumn columnDate12;

		private DataColumn columnDate13;

		private DataColumn columnDate14;

		private DataColumn columnDate15;

		private DataColumn columnDate16;

		private DataColumn columnDate17;

		private DataColumn columnDate18;

		private DataColumn columnDate19;

		private DataColumn columnDate20;

		private DataColumn columnDate21;

		private DataColumn columnDate22;

		private DataColumn columnDate23;

		private DataColumn columnDate24;

		private DataColumn columnDate25;

		private DataColumn columnDate26;

		private DataColumn columnDate27;

		private DataColumn columnDate28;

		private DataColumn columnDate29;

		private DataColumn columnDate30;

		private DataColumn columnDate31;

		private DataColumn columnSex;

		private DataColumn columnUserId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IdColumn => columnId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NameColumn => columnName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentIdColumn => columnStudentId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdColumn => columnClassId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamIdColumn => columnStreamId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date1Column => columnDate1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date2Column => columnDate2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date3Column => columnDate3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date4Column => columnDate4;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date5Column => columnDate5;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date6Column => columnDate6;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date7Column => columnDate7;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FlagColumn => columnFlag;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date8Column => columnDate8;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date9Column => columnDate9;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date10Column => columnDate10;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date11Column => columnDate11;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date12Column => columnDate12;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date13Column => columnDate13;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date14Column => columnDate14;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date15Column => columnDate15;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date16Column => columnDate16;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date17Column => columnDate17;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date18Column => columnDate18;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date19Column => columnDate19;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date20Column => columnDate20;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date21Column => columnDate21;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date22Column => columnDate22;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date23Column => columnDate23;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date24Column => columnDate24;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date25Column => columnDate25;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date26Column => columnDate26;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date27Column => columnDate27;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date28Column => columnDate28;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date29Column => columnDate29;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date30Column => columnDate30;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn Date31Column => columnDate31;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SexColumn => columnSex;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn UserIdColumn => columnUserId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallRow this[int index] => (AttendanceSheetRollCallRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event AttendanceSheetRollCallRowChangeEventHandler AttendanceSheetRollCallRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event AttendanceSheetRollCallRowChangeEventHandler AttendanceSheetRollCallRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event AttendanceSheetRollCallRowChangeEventHandler AttendanceSheetRollCallRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event AttendanceSheetRollCallRowChangeEventHandler AttendanceSheetRollCallRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallDataTable()
		{
			base.TableName = "AttendanceSheetRollCall";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal AttendanceSheetRollCallDataTable(DataTable table)
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
		protected AttendanceSheetRollCallDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddAttendanceSheetRollCallRow(AttendanceSheetRollCallRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallRow AddAttendanceSheetRollCallRow(string Name, string StudentNumber, string StudentId, string ClassId, string StreamId, DateTime Date1, DateTime Date2, DateTime Date3, DateTime Date4, DateTime Date5, DateTime Date6, DateTime Date7, string Flag, DateTime Date8, DateTime Date9, DateTime Date10, DateTime Date11, DateTime Date12, DateTime Date13, DateTime Date14, DateTime Date15, DateTime Date16, DateTime Date17, DateTime Date18, DateTime Date19, DateTime Date20, DateTime Date21, DateTime Date22, DateTime Date23, DateTime Date24, DateTime Date25, DateTime Date26, DateTime Date27, DateTime Date28, DateTime Date29, DateTime Date30, DateTime Date31, string Sex, string UserId)
		{
			AttendanceSheetRollCallRow attendanceSheetRollCallRow = (AttendanceSheetRollCallRow)NewRow();
			object[] itemArray = new object[40]
			{
				null, Name, StudentNumber, StudentId, ClassId, StreamId, Date1, Date2, Date3, Date4,
				Date5, Date6, Date7, Flag, Date8, Date9, Date10, Date11, Date12, Date13,
				Date14, Date15, Date16, Date17, Date18, Date19, Date20, Date21, Date22, Date23,
				Date24, Date25, Date26, Date27, Date28, Date29, Date30, Date31, Sex, UserId
			};
			attendanceSheetRollCallRow.ItemArray = itemArray;
			base.Rows.Add(attendanceSheetRollCallRow);
			return attendanceSheetRollCallRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallRow FindById(long Id)
		{
			return (AttendanceSheetRollCallRow)base.Rows.Find(new object[1] { Id });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			AttendanceSheetRollCallDataTable attendanceSheetRollCallDataTable = (AttendanceSheetRollCallDataTable)base.Clone();
			attendanceSheetRollCallDataTable.InitVars();
			return attendanceSheetRollCallDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new AttendanceSheetRollCallDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnId = base.Columns["Id"];
			columnName = base.Columns["Name"];
			columnStudentNumber = base.Columns["StudentNumber"];
			columnStudentId = base.Columns["StudentId"];
			columnClassId = base.Columns["ClassId"];
			columnStreamId = base.Columns["StreamId"];
			columnDate1 = base.Columns["Date1"];
			columnDate2 = base.Columns["Date2"];
			columnDate3 = base.Columns["Date3"];
			columnDate4 = base.Columns["Date4"];
			columnDate5 = base.Columns["Date5"];
			columnDate6 = base.Columns["Date6"];
			columnDate7 = base.Columns["Date7"];
			columnFlag = base.Columns["Flag"];
			columnDate8 = base.Columns["Date8"];
			columnDate9 = base.Columns["Date9"];
			columnDate10 = base.Columns["Date10"];
			columnDate11 = base.Columns["Date11"];
			columnDate12 = base.Columns["Date12"];
			columnDate13 = base.Columns["Date13"];
			columnDate14 = base.Columns["Date14"];
			columnDate15 = base.Columns["Date15"];
			columnDate16 = base.Columns["Date16"];
			columnDate17 = base.Columns["Date17"];
			columnDate18 = base.Columns["Date18"];
			columnDate19 = base.Columns["Date19"];
			columnDate20 = base.Columns["Date20"];
			columnDate21 = base.Columns["Date21"];
			columnDate22 = base.Columns["Date22"];
			columnDate23 = base.Columns["Date23"];
			columnDate24 = base.Columns["Date24"];
			columnDate25 = base.Columns["Date25"];
			columnDate26 = base.Columns["Date26"];
			columnDate27 = base.Columns["Date27"];
			columnDate28 = base.Columns["Date28"];
			columnDate29 = base.Columns["Date29"];
			columnDate30 = base.Columns["Date30"];
			columnDate31 = base.Columns["Date31"];
			columnSex = base.Columns["Sex"];
			columnUserId = base.Columns["UserId"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnId = new DataColumn("Id", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnId);
			columnName = new DataColumn("Name", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnName);
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnStudentId = new DataColumn("StudentId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentId);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
			columnStreamId = new DataColumn("StreamId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStreamId);
			columnDate1 = new DataColumn("Date1", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate1);
			columnDate2 = new DataColumn("Date2", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate2);
			columnDate3 = new DataColumn("Date3", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate3);
			columnDate4 = new DataColumn("Date4", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate4);
			columnDate5 = new DataColumn("Date5", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate5);
			columnDate6 = new DataColumn("Date6", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate6);
			columnDate7 = new DataColumn("Date7", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate7);
			columnFlag = new DataColumn("Flag", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFlag);
			columnDate8 = new DataColumn("Date8", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate8);
			columnDate9 = new DataColumn("Date9", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate9);
			columnDate10 = new DataColumn("Date10", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate10);
			columnDate11 = new DataColumn("Date11", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate11);
			columnDate12 = new DataColumn("Date12", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate12);
			columnDate13 = new DataColumn("Date13", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate13);
			columnDate14 = new DataColumn("Date14", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate14);
			columnDate15 = new DataColumn("Date15", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate15);
			columnDate16 = new DataColumn("Date16", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate16);
			columnDate17 = new DataColumn("Date17", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate17);
			columnDate18 = new DataColumn("Date18", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate18);
			columnDate19 = new DataColumn("Date19", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate19);
			columnDate20 = new DataColumn("Date20", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate20);
			columnDate21 = new DataColumn("Date21", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate21);
			columnDate22 = new DataColumn("Date22", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate22);
			columnDate23 = new DataColumn("Date23", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate23);
			columnDate24 = new DataColumn("Date24", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate24);
			columnDate25 = new DataColumn("Date25", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate25);
			columnDate26 = new DataColumn("Date26", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate26);
			columnDate27 = new DataColumn("Date27", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate27);
			columnDate28 = new DataColumn("Date28", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate28);
			columnDate29 = new DataColumn("Date29", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate29);
			columnDate30 = new DataColumn("Date30", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate30);
			columnDate31 = new DataColumn("Date31", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDate31);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnUserId = new DataColumn("UserId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnUserId);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[1] { columnId }, isPrimaryKey: true));
			columnId.AutoIncrement = true;
			columnId.AutoIncrementSeed = -1L;
			columnId.AutoIncrementStep = -1L;
			columnId.AllowDBNull = false;
			columnId.ReadOnly = true;
			columnId.Unique = true;
			columnName.MaxLength = 200;
			columnStudentNumber.MaxLength = 50;
			columnStudentId.MaxLength = 50;
			columnClassId.MaxLength = 50;
			columnStreamId.MaxLength = 50;
			columnFlag.MaxLength = 1;
			columnSex.MaxLength = 1;
			columnUserId.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallRow NewAttendanceSheetRollCallRow()
		{
			return (AttendanceSheetRollCallRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new AttendanceSheetRollCallRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(AttendanceSheetRollCallRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.AttendanceSheetRollCallRowChanged != null)
			{
				this.AttendanceSheetRollCallRowChanged(this, new AttendanceSheetRollCallRowChangeEvent((AttendanceSheetRollCallRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.AttendanceSheetRollCallRowChanging != null)
			{
				this.AttendanceSheetRollCallRowChanging(this, new AttendanceSheetRollCallRowChangeEvent((AttendanceSheetRollCallRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.AttendanceSheetRollCallRowDeleted != null)
			{
				this.AttendanceSheetRollCallRowDeleted(this, new AttendanceSheetRollCallRowChangeEvent((AttendanceSheetRollCallRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.AttendanceSheetRollCallRowDeleting != null)
			{
				this.AttendanceSheetRollCallRowDeleting(this, new AttendanceSheetRollCallRowChangeEvent((AttendanceSheetRollCallRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveAttendanceSheetRollCallRow(AttendanceSheetRollCallRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			RollCallSource rollCallSource = new RollCallSource();
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
			xmlSchemaAttribute.FixedValue = rollCallSource.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "AttendanceSheetRollCallDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = rollCallSource.GetSchemaSerializable();
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

	public class AttendanceSheetRollCallRow : DataRow
	{
		private AttendanceSheetRollCallDataTable tableAttendanceSheetRollCall;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long Id
		{
			get
			{
				return (long)base[tableAttendanceSheetRollCall.IdColumn];
			}
			set
			{
				base[tableAttendanceSheetRollCall.IdColumn] = value;
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
					return (string)base[tableAttendanceSheetRollCall.NameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Name' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.NameColumn] = value;
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
					return (string)base[tableAttendanceSheetRollCall.StudentNumberColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentNumber' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentId
		{
			get
			{
				try
				{
					return (string)base[tableAttendanceSheetRollCall.StudentIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentId' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.StudentIdColumn] = value;
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
					return (string)base[tableAttendanceSheetRollCall.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.ClassIdColumn] = value;
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
					return (string)base[tableAttendanceSheetRollCall.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.StreamIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date1
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date1' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date2
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date2' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date3
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date3' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date4
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date4Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date4' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date5
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date5Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date5' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date6
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date6Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date6' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date7
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date7Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date7' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Flag
		{
			get
			{
				try
				{
					return (string)base[tableAttendanceSheetRollCall.FlagColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Flag' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.FlagColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date8
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date8Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date8' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date9
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date9Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date9' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date9Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date10
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date10Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date10' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date10Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date11
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date11Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date11' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date11Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date12
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date12Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date12' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date12Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date13
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date13Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date13' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date13Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date14
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date14Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date14' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date14Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date15
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date15Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date15' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date15Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date16
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date16Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date16' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date16Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date17
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date17Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date17' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date17Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date18
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date18Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date18' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date18Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date19
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date19Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date19' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date19Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date20
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date20Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date20' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date20Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date21
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date21Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date21' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date21Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date22
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date22Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date22' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date22Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date23
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date23Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date23' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date23Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date24
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date24Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date24' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date24Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date25
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date25Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date25' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date25Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date26
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date26Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date26' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date26Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date27
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date27Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date27' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date27Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date28
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date28Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date28' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date28Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date29
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date29Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date29' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date29Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date30
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date30Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date30' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date30Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime Date31
		{
			get
			{
				try
				{
					return (DateTime)base[tableAttendanceSheetRollCall.Date31Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Date31' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.Date31Column] = value;
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
					return (string)base[tableAttendanceSheetRollCall.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.SexColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string UserId
		{
			get
			{
				try
				{
					return (string)base[tableAttendanceSheetRollCall.UserIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'UserId' in table 'AttendanceSheetRollCall' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableAttendanceSheetRollCall.UserIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal AttendanceSheetRollCallRow(DataRowBuilder rb)
			: base(rb)
		{
			tableAttendanceSheetRollCall = (AttendanceSheetRollCallDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNameNull()
		{
			return IsNull(tableAttendanceSheetRollCall.NameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNameNull()
		{
			base[tableAttendanceSheetRollCall.NameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentNumberNull()
		{
			return IsNull(tableAttendanceSheetRollCall.StudentNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentNumberNull()
		{
			base[tableAttendanceSheetRollCall.StudentNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentIdNull()
		{
			return IsNull(tableAttendanceSheetRollCall.StudentIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentIdNull()
		{
			base[tableAttendanceSheetRollCall.StudentIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tableAttendanceSheetRollCall.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tableAttendanceSheetRollCall.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tableAttendanceSheetRollCall.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tableAttendanceSheetRollCall.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate1Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate1Null()
		{
			base[tableAttendanceSheetRollCall.Date1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate2Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate2Null()
		{
			base[tableAttendanceSheetRollCall.Date2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate3Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate3Null()
		{
			base[tableAttendanceSheetRollCall.Date3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate4Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate4Null()
		{
			base[tableAttendanceSheetRollCall.Date4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate5Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate5Null()
		{
			base[tableAttendanceSheetRollCall.Date5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate6Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate6Null()
		{
			base[tableAttendanceSheetRollCall.Date6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate7Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate7Null()
		{
			base[tableAttendanceSheetRollCall.Date7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFlagNull()
		{
			return IsNull(tableAttendanceSheetRollCall.FlagColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFlagNull()
		{
			base[tableAttendanceSheetRollCall.FlagColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate8Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate8Null()
		{
			base[tableAttendanceSheetRollCall.Date8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate9Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date9Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate9Null()
		{
			base[tableAttendanceSheetRollCall.Date9Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate10Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date10Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate10Null()
		{
			base[tableAttendanceSheetRollCall.Date10Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate11Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date11Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate11Null()
		{
			base[tableAttendanceSheetRollCall.Date11Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate12Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date12Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate12Null()
		{
			base[tableAttendanceSheetRollCall.Date12Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate13Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date13Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate13Null()
		{
			base[tableAttendanceSheetRollCall.Date13Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate14Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date14Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate14Null()
		{
			base[tableAttendanceSheetRollCall.Date14Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate15Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date15Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate15Null()
		{
			base[tableAttendanceSheetRollCall.Date15Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate16Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date16Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate16Null()
		{
			base[tableAttendanceSheetRollCall.Date16Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate17Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date17Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate17Null()
		{
			base[tableAttendanceSheetRollCall.Date17Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate18Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date18Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate18Null()
		{
			base[tableAttendanceSheetRollCall.Date18Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate19Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date19Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate19Null()
		{
			base[tableAttendanceSheetRollCall.Date19Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate20Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date20Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate20Null()
		{
			base[tableAttendanceSheetRollCall.Date20Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate21Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date21Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate21Null()
		{
			base[tableAttendanceSheetRollCall.Date21Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate22Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date22Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate22Null()
		{
			base[tableAttendanceSheetRollCall.Date22Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate23Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date23Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate23Null()
		{
			base[tableAttendanceSheetRollCall.Date23Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate24Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date24Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate24Null()
		{
			base[tableAttendanceSheetRollCall.Date24Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate25Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date25Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate25Null()
		{
			base[tableAttendanceSheetRollCall.Date25Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate26Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date26Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate26Null()
		{
			base[tableAttendanceSheetRollCall.Date26Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate27Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date27Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate27Null()
		{
			base[tableAttendanceSheetRollCall.Date27Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate28Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date28Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate28Null()
		{
			base[tableAttendanceSheetRollCall.Date28Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate29Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date29Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate29Null()
		{
			base[tableAttendanceSheetRollCall.Date29Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate30Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date30Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate30Null()
		{
			base[tableAttendanceSheetRollCall.Date30Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDate31Null()
		{
			return IsNull(tableAttendanceSheetRollCall.Date31Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDate31Null()
		{
			base[tableAttendanceSheetRollCall.Date31Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tableAttendanceSheetRollCall.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tableAttendanceSheetRollCall.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsUserIdNull()
		{
			return IsNull(tableAttendanceSheetRollCall.UserIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetUserIdNull()
		{
			base[tableAttendanceSheetRollCall.UserIdColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class AttendanceSheetRollCallRowChangeEvent : EventArgs
	{
		private AttendanceSheetRollCallRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public AttendanceSheetRollCallRowChangeEvent(AttendanceSheetRollCallRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private AttendanceSheetRollCallDataTable tableAttendanceSheetRollCall;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public AttendanceSheetRollCallDataTable AttendanceSheetRollCall => tableAttendanceSheetRollCall;

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
	public RollCallSource()
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
	protected RollCallSource(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["AttendanceSheetRollCall"] != null)
			{
				base.Tables.Add(new AttendanceSheetRollCallDataTable(dataSet.Tables["AttendanceSheetRollCall"]));
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
		RollCallSource rollCallSource = (RollCallSource)base.Clone();
		rollCallSource.InitVars();
		rollCallSource.SchemaSerializationMode = SchemaSerializationMode;
		return rollCallSource;
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
			if (dataSet.Tables["AttendanceSheetRollCall"] != null)
			{
				base.Tables.Add(new AttendanceSheetRollCallDataTable(dataSet.Tables["AttendanceSheetRollCall"]));
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
		tableAttendanceSheetRollCall = (AttendanceSheetRollCallDataTable)base.Tables["AttendanceSheetRollCall"];
		if (initTable && tableAttendanceSheetRollCall != null)
		{
			tableAttendanceSheetRollCall.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "RollCallSource";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/RollCallSource.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableAttendanceSheetRollCall = new AttendanceSheetRollCallDataTable();
		base.Tables.Add(tableAttendanceSheetRollCall);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerializeAttendanceSheetRollCall()
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
		RollCallSource rollCallSource = new RollCallSource();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = rollCallSource.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = rollCallSource.GetSchemaSerializable();
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
