using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMDFastLane.Models;

[Table("tbl_Stud")]
public class Student
{
	[Key]
	[Column(Order = 0)]
	public long auto { get; set; }

	[Key]
	[Column(Order = 1)]
	[StringLength(12)]
	public string StudentNumber { get; set; }

	[Key]
	[Column(Order = 2)]
	public Guid Oid { get; set; }

	[StringLength(50)]
	public string fullName { get; set; }

	[StringLength(50)]
	public string fullNameAr { get; set; }

	[StringLength(8)]
	public string ClassId { get; set; }

	[StringLength(20)]
	public string ClassIdEn { get; set; }

	[StringLength(20)]
	public string ClassIdAr { get; set; }

	[StringLength(8)]
	public string StreamId { get; set; }

	[StringLength(8)]
	public string StreamAr { get; set; }

	[StringLength(1)]
	public string Sex { get; set; }

	[StringLength(1)]
	public string StudyStatus { get; set; }

	[StringLength(25)]
	public string HouseId { get; set; }

	[StringLength(15)]
	public string Religion { get; set; }

	[StringLength(50)]
	public string Guardian { get; set; }

	[StringLength(50)]
	public string FormerSchool { get; set; }

	public bool? BursaryStatus { get; set; }

	[StringLength(50)]
	public string BursaryProvider { get; set; }

	[StringLength(4)]
	public string AdmissionDate { get; set; }

	[Column(TypeName = "image")]
	public byte[] Picture { get; set; }

	[StringLength(15)]
	public string HomeCountry { get; set; }

	[StringLength(15)]
	public string Status { get; set; }

	public string Notes { get; set; }

	[Column(TypeName = "money")]
	public decimal? RequiredFees { get; set; }

	[Column(TypeName = "money")]
	public decimal? cashOnAccount { get; set; }

	[Column(TypeName = "money")]
	public decimal? FeesDiscount { get; set; }

	public bool? vID { get; set; }

	public bool? tagged { get; set; }

	[StringLength(12)]
	public string Comb { get; set; }

	[StringLength(50)]
	public string SubjectString { get; set; }

	[StringLength(50)]
	public string fName { get; set; }

	[StringLength(50)]
	public string fAddress { get; set; }

	[StringLength(10)]
	public string fContact { get; set; }

	[StringLength(50)]
	public string fEmail { get; set; }

	[StringLength(50)]
	public string mName { get; set; }

	[StringLength(50)]
	public string mAddress { get; set; }

	[StringLength(10)]
	public string mContact { get; set; }

	[StringLength(50)]
	public string mEmail { get; set; }

	public DateTime? DOB { get; set; }

	public bool? IsTheologyStud { get; set; }

	[StringLength(50)]
	public string PrimaryScores1 { get; set; }

	[StringLength(50)]
	public string PrimaryScores2 { get; set; }

	[StringLength(50)]
	public string PrimaryScores3 { get; set; }

	public bool? IsSynched { get; set; }

	[StringLength(12)]
	public string StudentID { get; set; }

	[StringLength(50)]
	public string Sponsor { get; set; }

	[StringLength(50)]
	public string SponsorContact { get; set; }

	[StringLength(100)]
	public string mNIN { get; set; }

	[StringLength(100)]
	public string fNIN { get; set; }

	[StringLength(100)]
	public string sNIN { get; set; }

	[StringLength(11)]
	public string PriorityContact { get; set; }

	[StringLength(11)]
	public string OtherContact { get; set; }

	[StringLength(50)]
	public string GuardianAddress { get; set; }

	[StringLength(100)]
	public string Email { get; set; }

	[StringLength(2000)]
	public string GamesAndSports { get; set; }

	[StringLength(2000)]
	public string Clubs { get; set; }

	[StringLength(50)]
	public string StreamEn { get; set; }

	[StringLength(50)]
	public string SexAr { get; set; }

	[StringLength(50)]
	public string LIN { get; set; }

	[StringLength(100)]
	public string ReportCentre { get; set; }

	[StringLength(100)]
	public string Cocurricular { get; set; }

	[StringLength(100)]
	public string HealthStatus { get; set; }

	[StringLength(100)]
	public string GuardianRelation { get; set; }

	[Column(TypeName = "image")]
	public byte[] GuardianPic { get; set; }
}
