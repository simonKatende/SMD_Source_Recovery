using System;

namespace I_Xtreme.Models;

public enum ContactChannel { SMS, Phone, InPerson }

public enum ContactOutcome { NoAnswer, Contacted, Promised, Refused, WrongContact }

public class FeesContactLog
{
    public int ContactId { get; set; }
    public string StudentNumber { get; set; }
    public DateTime ContactDate { get; set; }
    public string LoggedBy { get; set; }
    public ContactChannel Channel { get; set; }
    public ContactOutcome Outcome { get; set; }
    public string Note { get; set; }
    public DateTime? PromiseDate { get; set; }
    public decimal? PromiseAmount { get; set; }
}

public class StudentDetail
{
    public byte[]  Photo                { get; set; }
    public string  FullName             { get; set; }
    public string  StudentNumber        { get; set; }
    public string  ClassId              { get; set; }
    public string  GuardianContact1     { get; set; }  // tbl_Stud.PriorityContact
    public string  GuardianContact2     { get; set; }  // tbl_Stud.OtherContact
    public string  GuardianRelationship { get; set; }  // tbl_Stud.Guardian (name/relationship)
}
