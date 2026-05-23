using System.Data.Entity;
using AlienAge.Connectivity;
using SMDFastLane.Models;

namespace SMDFastLane.AppData;

public class SMDDBContext : DbContext
{
	public virtual DbSet<Student> Students { get; set; }

	public SMDDBContext()
	{
		base.Database.Connection.ConnectionString = DataConnection.ConnectToDatabase();
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Student>().Property((Student e) => e.StudentNumber).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.fullName).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.ClassId).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.ClassIdEn).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.StreamId).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.Sex).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.StudyStatus).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.HouseId).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.Religion).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.Guardian).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.FormerSchool).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.BursaryProvider).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.AdmissionDate).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.HomeCountry).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.Status).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.Notes).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.RequiredFees).HasPrecision(19, 4);
		modelBuilder.Entity<Student>().Property((Student e) => e.cashOnAccount).HasPrecision(19, 4);
		modelBuilder.Entity<Student>().Property((Student e) => e.FeesDiscount).HasPrecision(19, 4);
		modelBuilder.Entity<Student>().Property((Student e) => e.Comb).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.SubjectString).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.fName).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.fAddress).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.fContact).IsFixedLength()
			.IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.fEmail).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.mName).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.mAddress).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.mContact).IsFixedLength()
			.IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.mEmail).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.PrimaryScores1).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.PrimaryScores2).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.PrimaryScores3).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.StudentID).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.Sponsor).IsUnicode(false);
		modelBuilder.Entity<Student>().Property((Student e) => e.SponsorContact).IsUnicode(false);
	}
}
