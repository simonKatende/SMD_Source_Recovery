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
[XmlRoot("StudentPreviewSource")]
[HelpKeyword("vs.data.DataSet")]
public class StudentPreviewSource : DataSet
{
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public delegate void StudentPreviewSourceRowChangeEventHandler(object sender, StudentPreviewSourceRowChangeEvent e);

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class StudentPreviewSourceDataTable : TypedTableBase<StudentPreviewSourceRow>
	{
		private DataColumn columnStudentNumber;

		private DataColumn columnauto;

		private DataColumn columnOid;

		private DataColumn columnStudentID;

		private DataColumn columnfullName;

		private DataColumn columnfullNameAr;

		private DataColumn columnClassId;

		private DataColumn columnClassIdEn;

		private DataColumn columnClassIdAr;

		private DataColumn columnStreamId;

		private DataColumn columnStreamAr;

		private DataColumn columnSex;

		private DataColumn columnStudyStatus;

		private DataColumn columnHouseId;

		private DataColumn columnReligion;

		private DataColumn columnGuardian;

		private DataColumn columnFormerSchool;

		private DataColumn columnBursaryStatus;

		private DataColumn columnBursaryProvider;

		private DataColumn columnAdmissionDate;

		private DataColumn columnPicture;

		private DataColumn columnHomeCountry;

		private DataColumn columnStatus;

		private DataColumn columnNotes;

		private DataColumn columnRequiredFees;

		private DataColumn columncashOnAccount;

		private DataColumn columnFeesDiscount;

		private DataColumn columnvID;

		private DataColumn columntagged;

		private DataColumn columnComb;

		private DataColumn columnSubjectString;

		private DataColumn columnfName;

		private DataColumn columnfAddress;

		private DataColumn columnfContact;

		private DataColumn columnfEmail;

		private DataColumn columnmName;

		private DataColumn columnmAddress;

		private DataColumn columnmContact;

		private DataColumn columnmEmail;

		private DataColumn columnDOB;

		private DataColumn columnIsTheologyStud;

		private DataColumn columnPrimaryScores1;

		private DataColumn columnPrimaryScores2;

		private DataColumn columnPrimaryScores3;

		private DataColumn columnIsSynched;

		private DataColumn columnSponsor;

		private DataColumn columnSponsorContact;

		private DataColumn columnmNIN;

		private DataColumn columnfNIN;

		private DataColumn columnsNIN;

		private DataColumn columnPriorityContact;

		private DataColumn columnOtherContact;

		private DataColumn columnGuardianAddress;

		private DataColumn columnEmail;

		private DataColumn columnGamesAndSports;

		private DataColumn columnClubs;

		private DataColumn columnStreamEn;

		private DataColumn columnSexAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentNumberColumn => columnStudentNumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn autoColumn => columnauto;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OidColumn => columnOid;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StudentIDColumn => columnStudentID;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fullNameColumn => columnfullName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fullNameArColumn => columnfullNameAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdColumn => columnClassId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdEnColumn => columnClassIdEn;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClassIdArColumn => columnClassIdAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamIdColumn => columnStreamId;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamArColumn => columnStreamAr;

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
		public DataColumn ReligionColumn => columnReligion;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GuardianColumn => columnGuardian;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FormerSchoolColumn => columnFormerSchool;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn BursaryStatusColumn => columnBursaryStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn BursaryProviderColumn => columnBursaryProvider;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn AdmissionDateColumn => columnAdmissionDate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PictureColumn => columnPicture;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn HomeCountryColumn => columnHomeCountry;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StatusColumn => columnStatus;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn NotesColumn => columnNotes;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn RequiredFeesColumn => columnRequiredFees;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn cashOnAccountColumn => columncashOnAccount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn FeesDiscountColumn => columnFeesDiscount;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn vIDColumn => columnvID;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn taggedColumn => columntagged;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn CombColumn => columnComb;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SubjectStringColumn => columnSubjectString;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fNameColumn => columnfName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fAddressColumn => columnfAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fContactColumn => columnfContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fEmailColumn => columnfEmail;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn mNameColumn => columnmName;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn mAddressColumn => columnmAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn mContactColumn => columnmContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn mEmailColumn => columnmEmail;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn DOBColumn => columnDOB;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IsTheologyStudColumn => columnIsTheologyStud;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PrimaryScores1Column => columnPrimaryScores1;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PrimaryScores2Column => columnPrimaryScores2;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PrimaryScores3Column => columnPrimaryScores3;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn IsSynchedColumn => columnIsSynched;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SponsorColumn => columnSponsor;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SponsorContactColumn => columnSponsorContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn mNINColumn => columnmNIN;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn fNINColumn => columnfNIN;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn sNINColumn => columnsNIN;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn PriorityContactColumn => columnPriorityContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn OtherContactColumn => columnOtherContact;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GuardianAddressColumn => columnGuardianAddress;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn EmailColumn => columnEmail;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn GamesAndSportsColumn => columnGamesAndSports;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn ClubsColumn => columnClubs;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn StreamEnColumn => columnStreamEn;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataColumn SexArColumn => columnSexAr;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		[Browsable(false)]
		public int Count => base.Rows.Count;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceRow this[int index] => (StudentPreviewSourceRow)base.Rows[index];

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentPreviewSourceRowChangeEventHandler StudentPreviewSourceRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentPreviewSourceRowChangeEventHandler StudentPreviewSourceRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentPreviewSourceRowChangeEventHandler StudentPreviewSourceRowDeleting;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public event StudentPreviewSourceRowChangeEventHandler StudentPreviewSourceRowDeleted;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceDataTable()
		{
			base.TableName = "StudentPreviewSource";
			BeginInit();
			InitClass();
			EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal StudentPreviewSourceDataTable(DataTable table)
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
		protected StudentPreviewSourceDataTable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void AddStudentPreviewSourceRow(StudentPreviewSourceRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceRow AddStudentPreviewSourceRow(string StudentNumber, Guid Oid, string StudentID, string fullName, string fullNameAr, string ClassId, string ClassIdEn, string ClassIdAr, string StreamId, string StreamAr, string Sex, string StudyStatus, string HouseId, string Religion, string Guardian, string FormerSchool, bool BursaryStatus, string BursaryProvider, string AdmissionDate, byte[] Picture, string HomeCountry, string Status, string Notes, decimal RequiredFees, decimal cashOnAccount, decimal FeesDiscount, bool vID, bool tagged, string Comb, string SubjectString, string fName, string fAddress, string fContact, string fEmail, string mName, string mAddress, string mContact, string mEmail, DateTime DOB, bool IsTheologyStud, string PrimaryScores1, string PrimaryScores2, string PrimaryScores3, bool IsSynched, string Sponsor, string SponsorContact, string mNIN, string fNIN, string sNIN, string PriorityContact, string OtherContact, string GuardianAddress, string Email, string GamesAndSports, string Clubs, string StreamEn, string SexAr)
		{
			StudentPreviewSourceRow studentPreviewSourceRow = (StudentPreviewSourceRow)NewRow();
			object[] itemArray = new object[58]
			{
				StudentNumber, null, Oid, StudentID, fullName, fullNameAr, ClassId, ClassIdEn, ClassIdAr, StreamId,
				StreamAr, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, BursaryStatus, BursaryProvider, AdmissionDate,
				Picture, HomeCountry, Status, Notes, RequiredFees, cashOnAccount, FeesDiscount, vID, tagged, Comb,
				SubjectString, fName, fAddress, fContact, fEmail, mName, mAddress, mContact, mEmail, DOB,
				IsTheologyStud, PrimaryScores1, PrimaryScores2, PrimaryScores3, IsSynched, Sponsor, SponsorContact, mNIN, fNIN, sNIN,
				PriorityContact, OtherContact, GuardianAddress, Email, GamesAndSports, Clubs, StreamEn, SexAr
			};
			studentPreviewSourceRow.ItemArray = itemArray;
			base.Rows.Add(studentPreviewSourceRow);
			return studentPreviewSourceRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceRow FindByStudentNumberautoOid(string StudentNumber, long auto, Guid Oid)
		{
			return (StudentPreviewSourceRow)base.Rows.Find(new object[3] { StudentNumber, auto, Oid });
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public override DataTable Clone()
		{
			StudentPreviewSourceDataTable studentPreviewSourceDataTable = (StudentPreviewSourceDataTable)base.Clone();
			studentPreviewSourceDataTable.InitVars();
			return studentPreviewSourceDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new StudentPreviewSourceDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal void InitVars()
		{
			columnStudentNumber = base.Columns["StudentNumber"];
			columnauto = base.Columns["auto"];
			columnOid = base.Columns["Oid"];
			columnStudentID = base.Columns["StudentID"];
			columnfullName = base.Columns["fullName"];
			columnfullNameAr = base.Columns["fullNameAr"];
			columnClassId = base.Columns["ClassId"];
			columnClassIdEn = base.Columns["ClassIdEn"];
			columnClassIdAr = base.Columns["ClassIdAr"];
			columnStreamId = base.Columns["StreamId"];
			columnStreamAr = base.Columns["StreamAr"];
			columnSex = base.Columns["Sex"];
			columnStudyStatus = base.Columns["StudyStatus"];
			columnHouseId = base.Columns["HouseId"];
			columnReligion = base.Columns["Religion"];
			columnGuardian = base.Columns["Guardian"];
			columnFormerSchool = base.Columns["FormerSchool"];
			columnBursaryStatus = base.Columns["BursaryStatus"];
			columnBursaryProvider = base.Columns["BursaryProvider"];
			columnAdmissionDate = base.Columns["AdmissionDate"];
			columnPicture = base.Columns["Picture"];
			columnHomeCountry = base.Columns["HomeCountry"];
			columnStatus = base.Columns["Status"];
			columnNotes = base.Columns["Notes"];
			columnRequiredFees = base.Columns["RequiredFees"];
			columncashOnAccount = base.Columns["cashOnAccount"];
			columnFeesDiscount = base.Columns["FeesDiscount"];
			columnvID = base.Columns["vID"];
			columntagged = base.Columns["tagged"];
			columnComb = base.Columns["Comb"];
			columnSubjectString = base.Columns["SubjectString"];
			columnfName = base.Columns["fName"];
			columnfAddress = base.Columns["fAddress"];
			columnfContact = base.Columns["fContact"];
			columnfEmail = base.Columns["fEmail"];
			columnmName = base.Columns["mName"];
			columnmAddress = base.Columns["mAddress"];
			columnmContact = base.Columns["mContact"];
			columnmEmail = base.Columns["mEmail"];
			columnDOB = base.Columns["DOB"];
			columnIsTheologyStud = base.Columns["IsTheologyStud"];
			columnPrimaryScores1 = base.Columns["PrimaryScores1"];
			columnPrimaryScores2 = base.Columns["PrimaryScores2"];
			columnPrimaryScores3 = base.Columns["PrimaryScores3"];
			columnIsSynched = base.Columns["IsSynched"];
			columnSponsor = base.Columns["Sponsor"];
			columnSponsorContact = base.Columns["SponsorContact"];
			columnmNIN = base.Columns["mNIN"];
			columnfNIN = base.Columns["fNIN"];
			columnsNIN = base.Columns["sNIN"];
			columnPriorityContact = base.Columns["PriorityContact"];
			columnOtherContact = base.Columns["OtherContact"];
			columnGuardianAddress = base.Columns["GuardianAddress"];
			columnEmail = base.Columns["Email"];
			columnGamesAndSports = base.Columns["GamesAndSports"];
			columnClubs = base.Columns["Clubs"];
			columnStreamEn = base.Columns["StreamEn"];
			columnSexAr = base.Columns["SexAr"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		private void InitClass()
		{
			columnStudentNumber = new DataColumn("StudentNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentNumber);
			columnauto = new DataColumn("auto", typeof(long), null, MappingType.Element);
			base.Columns.Add(columnauto);
			columnOid = new DataColumn("Oid", typeof(Guid), null, MappingType.Element);
			base.Columns.Add(columnOid);
			columnStudentID = new DataColumn("StudentID", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudentID);
			columnfullName = new DataColumn("fullName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfullName);
			columnfullNameAr = new DataColumn("fullNameAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfullNameAr);
			columnClassId = new DataColumn("ClassId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassId);
			columnClassIdEn = new DataColumn("ClassIdEn", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassIdEn);
			columnClassIdAr = new DataColumn("ClassIdAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClassIdAr);
			columnStreamId = new DataColumn("StreamId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStreamId);
			columnStreamAr = new DataColumn("StreamAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStreamAr);
			columnSex = new DataColumn("Sex", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSex);
			columnStudyStatus = new DataColumn("StudyStatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStudyStatus);
			columnHouseId = new DataColumn("HouseId", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHouseId);
			columnReligion = new DataColumn("Religion", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnReligion);
			columnGuardian = new DataColumn("Guardian", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGuardian);
			columnFormerSchool = new DataColumn("FormerSchool", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnFormerSchool);
			columnBursaryStatus = new DataColumn("BursaryStatus", typeof(bool), null, MappingType.Element);
			base.Columns.Add(columnBursaryStatus);
			columnBursaryProvider = new DataColumn("BursaryProvider", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnBursaryProvider);
			columnAdmissionDate = new DataColumn("AdmissionDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnAdmissionDate);
			columnPicture = new DataColumn("Picture", typeof(byte[]), null, MappingType.Element);
			base.Columns.Add(columnPicture);
			columnHomeCountry = new DataColumn("HomeCountry", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnHomeCountry);
			columnStatus = new DataColumn("Status", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStatus);
			columnNotes = new DataColumn("Notes", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnNotes);
			columnRequiredFees = new DataColumn("RequiredFees", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnRequiredFees);
			columncashOnAccount = new DataColumn("cashOnAccount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columncashOnAccount);
			columnFeesDiscount = new DataColumn("FeesDiscount", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(columnFeesDiscount);
			columnvID = new DataColumn("vID", typeof(bool), null, MappingType.Element);
			base.Columns.Add(columnvID);
			columntagged = new DataColumn("tagged", typeof(bool), null, MappingType.Element);
			base.Columns.Add(columntagged);
			columnComb = new DataColumn("Comb", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnComb);
			columnSubjectString = new DataColumn("SubjectString", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSubjectString);
			columnfName = new DataColumn("fName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfName);
			columnfAddress = new DataColumn("fAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfAddress);
			columnfContact = new DataColumn("fContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfContact);
			columnfEmail = new DataColumn("fEmail", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfEmail);
			columnmName = new DataColumn("mName", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmName);
			columnmAddress = new DataColumn("mAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmAddress);
			columnmContact = new DataColumn("mContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmContact);
			columnmEmail = new DataColumn("mEmail", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmEmail);
			columnDOB = new DataColumn("DOB", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(columnDOB);
			columnIsTheologyStud = new DataColumn("IsTheologyStud", typeof(bool), null, MappingType.Element);
			base.Columns.Add(columnIsTheologyStud);
			columnPrimaryScores1 = new DataColumn("PrimaryScores1", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPrimaryScores1);
			columnPrimaryScores2 = new DataColumn("PrimaryScores2", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPrimaryScores2);
			columnPrimaryScores3 = new DataColumn("PrimaryScores3", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPrimaryScores3);
			columnIsSynched = new DataColumn("IsSynched", typeof(bool), null, MappingType.Element);
			base.Columns.Add(columnIsSynched);
			columnSponsor = new DataColumn("Sponsor", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSponsor);
			columnSponsorContact = new DataColumn("SponsorContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSponsorContact);
			columnmNIN = new DataColumn("mNIN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnmNIN);
			columnfNIN = new DataColumn("fNIN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnfNIN);
			columnsNIN = new DataColumn("sNIN", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnsNIN);
			columnPriorityContact = new DataColumn("PriorityContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnPriorityContact);
			columnOtherContact = new DataColumn("OtherContact", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnOtherContact);
			columnGuardianAddress = new DataColumn("GuardianAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGuardianAddress);
			columnEmail = new DataColumn("Email", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnEmail);
			columnGamesAndSports = new DataColumn("GamesAndSports", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnGamesAndSports);
			columnClubs = new DataColumn("Clubs", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnClubs);
			columnStreamEn = new DataColumn("StreamEn", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnStreamEn);
			columnSexAr = new DataColumn("SexAr", typeof(string), null, MappingType.Element);
			base.Columns.Add(columnSexAr);
			base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[3] { columnStudentNumber, columnauto, columnOid }, isPrimaryKey: true));
			columnStudentNumber.AllowDBNull = false;
			columnStudentNumber.MaxLength = 12;
			columnauto.AutoIncrement = true;
			columnauto.AutoIncrementSeed = -1L;
			columnauto.AutoIncrementStep = -1L;
			columnauto.AllowDBNull = false;
			columnauto.ReadOnly = true;
			columnOid.AllowDBNull = false;
			columnStudentID.MaxLength = 12;
			columnfullName.MaxLength = 50;
			columnfullNameAr.MaxLength = 50;
			columnClassId.MaxLength = 8;
			columnClassIdEn.MaxLength = 20;
			columnClassIdAr.MaxLength = 20;
			columnStreamId.MaxLength = 8;
			columnStreamAr.MaxLength = 8;
			columnSex.MaxLength = 1;
			columnStudyStatus.MaxLength = 1;
			columnHouseId.MaxLength = 25;
			columnReligion.MaxLength = 15;
			columnGuardian.MaxLength = 50;
			columnFormerSchool.MaxLength = 50;
			columnBursaryProvider.MaxLength = 50;
			columnAdmissionDate.MaxLength = 4;
			columnHomeCountry.MaxLength = 15;
			columnStatus.MaxLength = 15;
			columnNotes.MaxLength = int.MaxValue;
			columnComb.MaxLength = 12;
			columnSubjectString.MaxLength = 50;
			columnfName.MaxLength = 50;
			columnfAddress.MaxLength = 50;
			columnfContact.MaxLength = 10;
			columnfEmail.MaxLength = 50;
			columnmName.MaxLength = 50;
			columnmAddress.MaxLength = 50;
			columnmContact.MaxLength = 10;
			columnmEmail.MaxLength = 50;
			columnPrimaryScores1.MaxLength = 50;
			columnPrimaryScores2.MaxLength = 50;
			columnPrimaryScores3.MaxLength = 50;
			columnSponsor.MaxLength = 100;
			columnSponsorContact.MaxLength = 50;
			columnmNIN.MaxLength = 100;
			columnfNIN.MaxLength = 100;
			columnsNIN.MaxLength = 100;
			columnPriorityContact.MaxLength = 11;
			columnOtherContact.MaxLength = 11;
			columnGuardianAddress.MaxLength = 50;
			columnEmail.MaxLength = 100;
			columnGamesAndSports.MaxLength = 2000;
			columnClubs.MaxLength = 2000;
			columnStreamEn.MaxLength = 50;
			columnSexAr.MaxLength = 50;
			base.ExtendedProperties.Add("Generator_TablePropName", "_StudentPreviewSource");
			base.ExtendedProperties.Add("Generator_UserTableName", "StudentPreviewSource");
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceRow NewStudentPreviewSourceRow()
		{
			return (StudentPreviewSourceRow)NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new StudentPreviewSourceRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(StudentPreviewSourceRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.StudentPreviewSourceRowChanged != null)
			{
				this.StudentPreviewSourceRowChanged(this, new StudentPreviewSourceRowChangeEvent((StudentPreviewSourceRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.StudentPreviewSourceRowChanging != null)
			{
				this.StudentPreviewSourceRowChanging(this, new StudentPreviewSourceRowChangeEvent((StudentPreviewSourceRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.StudentPreviewSourceRowDeleted != null)
			{
				this.StudentPreviewSourceRowDeleted(this, new StudentPreviewSourceRowChangeEvent((StudentPreviewSourceRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.StudentPreviewSourceRowDeleting != null)
			{
				this.StudentPreviewSourceRowDeleting(this, new StudentPreviewSourceRowChangeEvent((StudentPreviewSourceRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void RemoveStudentPreviewSourceRow(StudentPreviewSourceRow row)
		{
			base.Rows.Remove(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			StudentPreviewSource studentPreviewSource = new StudentPreviewSource();
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
			xmlSchemaAttribute.FixedValue = studentPreviewSource.Namespace;
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute2 = new XmlSchemaAttribute();
			xmlSchemaAttribute2.Name = "tableTypeName";
			xmlSchemaAttribute2.FixedValue = "StudentPreviewSourceDataTable";
			xmlSchemaComplexType.Attributes.Add(xmlSchemaAttribute2);
			xmlSchemaComplexType.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = studentPreviewSource.GetSchemaSerializable();
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

	public class StudentPreviewSourceRow : DataRow
	{
		private StudentPreviewSourceDataTable tableStudentPreviewSource;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StudentNumber
		{
			get
			{
				return (string)base[tableStudentPreviewSource.StudentNumberColumn];
			}
			set
			{
				base[tableStudentPreviewSource.StudentNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public long auto
		{
			get
			{
				return (long)base[tableStudentPreviewSource.autoColumn];
			}
			set
			{
				base[tableStudentPreviewSource.autoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public Guid Oid
		{
			get
			{
				return (Guid)base[tableStudentPreviewSource.OidColumn];
			}
			set
			{
				base[tableStudentPreviewSource.OidColumn] = value;
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
					return (string)base[tableStudentPreviewSource.StudentIDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudentID' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.StudentIDColumn] = value;
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
					return (string)base[tableStudentPreviewSource.fullNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullName' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fullNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fullNameAr
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.fullNameArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fullNameAr' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fullNameArColumn] = value;
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
					return (string)base[tableStudentPreviewSource.ClassIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassId' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.ClassIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassIdEn
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.ClassIdEnColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassIdEn' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.ClassIdEnColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string ClassIdAr
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.ClassIdArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'ClassIdAr' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.ClassIdArColumn] = value;
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
					return (string)base[tableStudentPreviewSource.StreamIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamId' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.StreamIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StreamAr
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.StreamArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamAr' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.StreamArColumn] = value;
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
					return (string)base[tableStudentPreviewSource.SexColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sex' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.SexColumn] = value;
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
					return (string)base[tableStudentPreviewSource.StudyStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StudyStatus' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.StudyStatusColumn] = value;
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
					return (string)base[tableStudentPreviewSource.HouseIdColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HouseId' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.HouseIdColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Religion
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.ReligionColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Religion' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.ReligionColumn] = value;
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
					return (string)base[tableStudentPreviewSource.GuardianColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Guardian' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.GuardianColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string FormerSchool
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.FormerSchoolColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FormerSchool' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.FormerSchoolColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool BursaryStatus
		{
			get
			{
				try
				{
					return (bool)base[tableStudentPreviewSource.BursaryStatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BursaryStatus' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.BursaryStatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string BursaryProvider
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.BursaryProviderColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'BursaryProvider' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.BursaryProviderColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string AdmissionDate
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.AdmissionDateColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'AdmissionDate' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.AdmissionDateColumn] = value;
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
					return (byte[])base[tableStudentPreviewSource.PictureColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Picture' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.PictureColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string HomeCountry
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.HomeCountryColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'HomeCountry' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.HomeCountryColumn] = value;
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
					return (string)base[tableStudentPreviewSource.StatusColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Status' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.StatusColumn] = value;
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
					return (string)base[tableStudentPreviewSource.NotesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Notes' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.NotesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal RequiredFees
		{
			get
			{
				try
				{
					return (decimal)base[tableStudentPreviewSource.RequiredFeesColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'RequiredFees' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.RequiredFeesColumn] = value;
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
					return (decimal)base[tableStudentPreviewSource.cashOnAccountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'cashOnAccount' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.cashOnAccountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public decimal FeesDiscount
		{
			get
			{
				try
				{
					return (decimal)base[tableStudentPreviewSource.FeesDiscountColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'FeesDiscount' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.FeesDiscountColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool vID
		{
			get
			{
				try
				{
					return (bool)base[tableStudentPreviewSource.vIDColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'vID' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.vIDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool tagged
		{
			get
			{
				try
				{
					return (bool)base[tableStudentPreviewSource.taggedColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'tagged' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.taggedColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Comb
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.CombColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Comb' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.CombColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SubjectString
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.SubjectStringColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SubjectString' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.SubjectStringColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fName
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.fNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fName' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fAddress
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.fAddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fAddress' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fContact
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.fContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fContact' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fEmail
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.fEmailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fEmail' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fEmailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string mName
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.mNameColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'mName' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.mNameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string mAddress
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.mAddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'mAddress' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.mAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string mContact
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.mContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'mContact' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.mContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string mEmail
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.mEmailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'mEmail' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.mEmailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DateTime DOB
		{
			get
			{
				try
				{
					return (DateTime)base[tableStudentPreviewSource.DOBColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'DOB' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.DOBColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsTheologyStud
		{
			get
			{
				try
				{
					return (bool)base[tableStudentPreviewSource.IsTheologyStudColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsTheologyStud' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.IsTheologyStudColumn] = value;
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
					return (string)base[tableStudentPreviewSource.PrimaryScores1Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PrimaryScores1' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.PrimaryScores1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string PrimaryScores2
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.PrimaryScores2Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PrimaryScores2' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.PrimaryScores2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string PrimaryScores3
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.PrimaryScores3Column];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PrimaryScores3' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.PrimaryScores3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSynched
		{
			get
			{
				try
				{
					return (bool)base[tableStudentPreviewSource.IsSynchedColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'IsSynched' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.IsSynchedColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string Sponsor
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.SponsorColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Sponsor' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.SponsorColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SponsorContact
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.SponsorContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SponsorContact' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.SponsorContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string mNIN
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.mNINColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'mNIN' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.mNINColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string fNIN
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.fNINColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'fNIN' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.fNINColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string sNIN
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.sNINColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'sNIN' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.sNINColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string PriorityContact
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.PriorityContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'PriorityContact' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.PriorityContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string OtherContact
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.OtherContactColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'OtherContact' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.OtherContactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string GuardianAddress
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.GuardianAddressColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GuardianAddress' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.GuardianAddressColumn] = value;
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
					return (string)base[tableStudentPreviewSource.EmailColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Email' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.EmailColumn] = value;
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
					return (string)base[tableStudentPreviewSource.GamesAndSportsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'GamesAndSports' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.GamesAndSportsColumn] = value;
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
					return (string)base[tableStudentPreviewSource.ClubsColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'Clubs' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.ClubsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string StreamEn
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.StreamEnColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'StreamEn' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.StreamEnColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public string SexAr
		{
			get
			{
				try
				{
					return (string)base[tableStudentPreviewSource.SexArColumn];
				}
				catch (InvalidCastException innerException)
				{
					throw new StrongTypingException("The value for column 'SexAr' in table 'StudentPreviewSource' is DBNull.", innerException);
				}
			}
			set
			{
				base[tableStudentPreviewSource.SexArColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		internal StudentPreviewSourceRow(DataRowBuilder rb)
			: base(rb)
		{
			tableStudentPreviewSource = (StudentPreviewSourceDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudentIDNull()
		{
			return IsNull(tableStudentPreviewSource.StudentIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudentIDNull()
		{
			base[tableStudentPreviewSource.StudentIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameNull()
		{
			return IsNull(tableStudentPreviewSource.fullNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameNull()
		{
			base[tableStudentPreviewSource.fullNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfullNameArNull()
		{
			return IsNull(tableStudentPreviewSource.fullNameArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfullNameArNull()
		{
			base[tableStudentPreviewSource.fullNameArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdNull()
		{
			return IsNull(tableStudentPreviewSource.ClassIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdNull()
		{
			base[tableStudentPreviewSource.ClassIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdEnNull()
		{
			return IsNull(tableStudentPreviewSource.ClassIdEnColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdEnNull()
		{
			base[tableStudentPreviewSource.ClassIdEnColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClassIdArNull()
		{
			return IsNull(tableStudentPreviewSource.ClassIdArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClassIdArNull()
		{
			base[tableStudentPreviewSource.ClassIdArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamIdNull()
		{
			return IsNull(tableStudentPreviewSource.StreamIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamIdNull()
		{
			base[tableStudentPreviewSource.StreamIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamArNull()
		{
			return IsNull(tableStudentPreviewSource.StreamArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamArNull()
		{
			base[tableStudentPreviewSource.StreamArColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexNull()
		{
			return IsNull(tableStudentPreviewSource.SexColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexNull()
		{
			base[tableStudentPreviewSource.SexColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStudyStatusNull()
		{
			return IsNull(tableStudentPreviewSource.StudyStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStudyStatusNull()
		{
			base[tableStudentPreviewSource.StudyStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHouseIdNull()
		{
			return IsNull(tableStudentPreviewSource.HouseIdColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHouseIdNull()
		{
			base[tableStudentPreviewSource.HouseIdColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsReligionNull()
		{
			return IsNull(tableStudentPreviewSource.ReligionColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetReligionNull()
		{
			base[tableStudentPreviewSource.ReligionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGuardianNull()
		{
			return IsNull(tableStudentPreviewSource.GuardianColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGuardianNull()
		{
			base[tableStudentPreviewSource.GuardianColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFormerSchoolNull()
		{
			return IsNull(tableStudentPreviewSource.FormerSchoolColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFormerSchoolNull()
		{
			base[tableStudentPreviewSource.FormerSchoolColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBursaryStatusNull()
		{
			return IsNull(tableStudentPreviewSource.BursaryStatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBursaryStatusNull()
		{
			base[tableStudentPreviewSource.BursaryStatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsBursaryProviderNull()
		{
			return IsNull(tableStudentPreviewSource.BursaryProviderColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetBursaryProviderNull()
		{
			base[tableStudentPreviewSource.BursaryProviderColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsAdmissionDateNull()
		{
			return IsNull(tableStudentPreviewSource.AdmissionDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetAdmissionDateNull()
		{
			base[tableStudentPreviewSource.AdmissionDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPictureNull()
		{
			return IsNull(tableStudentPreviewSource.PictureColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPictureNull()
		{
			base[tableStudentPreviewSource.PictureColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsHomeCountryNull()
		{
			return IsNull(tableStudentPreviewSource.HomeCountryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetHomeCountryNull()
		{
			base[tableStudentPreviewSource.HomeCountryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStatusNull()
		{
			return IsNull(tableStudentPreviewSource.StatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStatusNull()
		{
			base[tableStudentPreviewSource.StatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsNotesNull()
		{
			return IsNull(tableStudentPreviewSource.NotesColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetNotesNull()
		{
			base[tableStudentPreviewSource.NotesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsRequiredFeesNull()
		{
			return IsNull(tableStudentPreviewSource.RequiredFeesColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetRequiredFeesNull()
		{
			base[tableStudentPreviewSource.RequiredFeesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IscashOnAccountNull()
		{
			return IsNull(tableStudentPreviewSource.cashOnAccountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetcashOnAccountNull()
		{
			base[tableStudentPreviewSource.cashOnAccountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsFeesDiscountNull()
		{
			return IsNull(tableStudentPreviewSource.FeesDiscountColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetFeesDiscountNull()
		{
			base[tableStudentPreviewSource.FeesDiscountColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsvIDNull()
		{
			return IsNull(tableStudentPreviewSource.vIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetvIDNull()
		{
			base[tableStudentPreviewSource.vIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IstaggedNull()
		{
			return IsNull(tableStudentPreviewSource.taggedColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SettaggedNull()
		{
			base[tableStudentPreviewSource.taggedColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsCombNull()
		{
			return IsNull(tableStudentPreviewSource.CombColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetCombNull()
		{
			base[tableStudentPreviewSource.CombColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSubjectStringNull()
		{
			return IsNull(tableStudentPreviewSource.SubjectStringColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSubjectStringNull()
		{
			base[tableStudentPreviewSource.SubjectStringColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfNameNull()
		{
			return IsNull(tableStudentPreviewSource.fNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfNameNull()
		{
			base[tableStudentPreviewSource.fNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfAddressNull()
		{
			return IsNull(tableStudentPreviewSource.fAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfAddressNull()
		{
			base[tableStudentPreviewSource.fAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfContactNull()
		{
			return IsNull(tableStudentPreviewSource.fContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfContactNull()
		{
			base[tableStudentPreviewSource.fContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfEmailNull()
		{
			return IsNull(tableStudentPreviewSource.fEmailColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfEmailNull()
		{
			base[tableStudentPreviewSource.fEmailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsmNameNull()
		{
			return IsNull(tableStudentPreviewSource.mNameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetmNameNull()
		{
			base[tableStudentPreviewSource.mNameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsmAddressNull()
		{
			return IsNull(tableStudentPreviewSource.mAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetmAddressNull()
		{
			base[tableStudentPreviewSource.mAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsmContactNull()
		{
			return IsNull(tableStudentPreviewSource.mContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetmContactNull()
		{
			base[tableStudentPreviewSource.mContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsmEmailNull()
		{
			return IsNull(tableStudentPreviewSource.mEmailColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetmEmailNull()
		{
			base[tableStudentPreviewSource.mEmailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsDOBNull()
		{
			return IsNull(tableStudentPreviewSource.DOBColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetDOBNull()
		{
			base[tableStudentPreviewSource.DOBColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsIsTheologyStudNull()
		{
			return IsNull(tableStudentPreviewSource.IsTheologyStudColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetIsTheologyStudNull()
		{
			base[tableStudentPreviewSource.IsTheologyStudColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPrimaryScores1Null()
		{
			return IsNull(tableStudentPreviewSource.PrimaryScores1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPrimaryScores1Null()
		{
			base[tableStudentPreviewSource.PrimaryScores1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPrimaryScores2Null()
		{
			return IsNull(tableStudentPreviewSource.PrimaryScores2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPrimaryScores2Null()
		{
			base[tableStudentPreviewSource.PrimaryScores2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPrimaryScores3Null()
		{
			return IsNull(tableStudentPreviewSource.PrimaryScores3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPrimaryScores3Null()
		{
			base[tableStudentPreviewSource.PrimaryScores3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsIsSynchedNull()
		{
			return IsNull(tableStudentPreviewSource.IsSynchedColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetIsSynchedNull()
		{
			base[tableStudentPreviewSource.IsSynchedColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSponsorNull()
		{
			return IsNull(tableStudentPreviewSource.SponsorColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSponsorNull()
		{
			base[tableStudentPreviewSource.SponsorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSponsorContactNull()
		{
			return IsNull(tableStudentPreviewSource.SponsorContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSponsorContactNull()
		{
			base[tableStudentPreviewSource.SponsorContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsmNINNull()
		{
			return IsNull(tableStudentPreviewSource.mNINColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetmNINNull()
		{
			base[tableStudentPreviewSource.mNINColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsfNINNull()
		{
			return IsNull(tableStudentPreviewSource.fNINColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetfNINNull()
		{
			base[tableStudentPreviewSource.fNINColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IssNINNull()
		{
			return IsNull(tableStudentPreviewSource.sNINColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetsNINNull()
		{
			base[tableStudentPreviewSource.sNINColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsPriorityContactNull()
		{
			return IsNull(tableStudentPreviewSource.PriorityContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetPriorityContactNull()
		{
			base[tableStudentPreviewSource.PriorityContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsOtherContactNull()
		{
			return IsNull(tableStudentPreviewSource.OtherContactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetOtherContactNull()
		{
			base[tableStudentPreviewSource.OtherContactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGuardianAddressNull()
		{
			return IsNull(tableStudentPreviewSource.GuardianAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGuardianAddressNull()
		{
			base[tableStudentPreviewSource.GuardianAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsEmailNull()
		{
			return IsNull(tableStudentPreviewSource.EmailColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetEmailNull()
		{
			base[tableStudentPreviewSource.EmailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsGamesAndSportsNull()
		{
			return IsNull(tableStudentPreviewSource.GamesAndSportsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetGamesAndSportsNull()
		{
			base[tableStudentPreviewSource.GamesAndSportsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsClubsNull()
		{
			return IsNull(tableStudentPreviewSource.ClubsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetClubsNull()
		{
			base[tableStudentPreviewSource.ClubsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsStreamEnNull()
		{
			return IsNull(tableStudentPreviewSource.StreamEnColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetStreamEnNull()
		{
			base[tableStudentPreviewSource.StreamEnColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public bool IsSexArNull()
		{
			return IsNull(tableStudentPreviewSource.SexArColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public void SetSexArNull()
		{
			base[tableStudentPreviewSource.SexArColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public class StudentPreviewSourceRowChangeEvent : EventArgs
	{
		private StudentPreviewSourceRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceRow Row => eventRow;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public DataRowAction Action => eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
		public StudentPreviewSourceRowChangeEvent(StudentPreviewSourceRow row, DataRowAction action)
		{
			eventRow = row;
			eventAction = action;
		}
	}

	private StudentPreviewSourceDataTable tableStudentPreviewSource;

	private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public StudentPreviewSourceDataTable _StudentPreviewSource => tableStudentPreviewSource;

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
	public StudentPreviewSource()
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
	protected StudentPreviewSource(SerializationInfo info, StreamingContext context)
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
			if (dataSet.Tables["StudentPreviewSource"] != null)
			{
				base.Tables.Add(new StudentPreviewSourceDataTable(dataSet.Tables["StudentPreviewSource"]));
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
		StudentPreviewSource studentPreviewSource = (StudentPreviewSource)base.Clone();
		studentPreviewSource.InitVars();
		studentPreviewSource.SchemaSerializationMode = SchemaSerializationMode;
		return studentPreviewSource;
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
			if (dataSet.Tables["StudentPreviewSource"] != null)
			{
				base.Tables.Add(new StudentPreviewSourceDataTable(dataSet.Tables["StudentPreviewSource"]));
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
		tableStudentPreviewSource = (StudentPreviewSourceDataTable)base.Tables["StudentPreviewSource"];
		if (initTable && tableStudentPreviewSource != null)
		{
			tableStudentPreviewSource.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "StudentPreviewSource";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/StudentPreviewSource.xsd";
		base.EnforceConstraints = true;
		SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tableStudentPreviewSource = new StudentPreviewSourceDataTable();
		base.Tables.Add(tableStudentPreviewSource);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private bool ShouldSerialize_StudentPreviewSource()
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
		StudentPreviewSource studentPreviewSource = new StudentPreviewSource();
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.Namespace = studentPreviewSource.Namespace;
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = studentPreviewSource.GetSchemaSerializable();
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
