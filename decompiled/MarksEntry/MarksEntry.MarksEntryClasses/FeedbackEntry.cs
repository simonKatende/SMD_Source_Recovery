namespace MarksEntry.MarksEntryClasses;

internal class FeedbackEntry
{
	public string Group { get; set; }

	public string Remark { get; set; }

	public FeedbackEntry(string group, string remark)
	{
		Group = group;
		Remark = remark;
	}
}
