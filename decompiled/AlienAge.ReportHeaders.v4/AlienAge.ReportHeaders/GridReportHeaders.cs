using DevExpress.XtraPrinting;

namespace AlienAge.ReportHeaders;

public class GridReportHeaders
{
	public static string Header(PrintableComponentLink _printableLink, string ReportCategory, string ReportOwner, string ReportOwnerId)
	{
		return _printableLink.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs22 {ReportHeader.SchoolName}\\par\r\n{ReportHeader.SchoolFullAddress}\\par\r\n{ReportHeader.SchoolLocation}\\par\r\n{ReportHeader.SchoolBoxNo}\\par\r\n\\par\r\n{ReportCategory}\\par\r\n------------------------------------------------------------------------------------------------------------------------------------------------\\par\r\n{ReportOwner}\\par\r\n{ReportOwnerId}\\par\r\n}}\r\n";
	}
}
