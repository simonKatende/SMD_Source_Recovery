using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.ReportHeaders;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using I_Xtreme.Receipts;
using Microsoft.Win32;

namespace I_Xtreme;

internal class Receipt
{
	private static string boxNo = ReportHeader.SchoolBoxNo;

	private static string location = ReportHeader.SchoolLocation;

	private static string shortName = ReportHeader.ShortName;

	private static string receiptHeader = "PAYMENT RECEIPT";

	public static string ReceiptPrinter
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
			return registryKey.GetValue("PrinterName").ToString();
		}
	}

	public static string PaperSize
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
			return registryKey.GetValue("PaperSize").ToString();
		}
	}

	public static bool AlwaysPrintReceipt
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
			if (!int.TryParse(registryKey.GetValue("alwaysPrintReceipt").ToString(), out var result) || result == 0)
			{
				return false;
			}
			return true;
		}
	}

	public static int NumberOfCopies
	{
		get
		{
			int result = 1;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
				return (!int.TryParse(registryKey.GetValue("PrintingCopies").ToString(), out result)) ? 1 : result;
			}
			catch (Exception)
			{
				return 1;
			}
		}
	}

	private static string ReceiptHeader()
	{
		string arg = string.Empty;
		string arg2 = string.Empty;
		string arg3 = string.Empty;
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ShortName,fullContact,location,SchoolName FROM SchoolDetails", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "header");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				arg = row["fullContact"].ToString();
				arg2 = row["location"].ToString();
				arg3 = row["SchoolName"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return $"{arg3}\n{arg2}\n{arg}";
	}

	public static void CanPrintReceipt(int canPrint)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
		registryKey.SetValue("alwaysPrintReceipt", canPrint);
	}

	public static void SetPrintingParameters(string _printerName, int noOfCopies, string PaperSize)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
		registryKey.SetValue("PrinterName", _printerName);
		RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
		registryKey2.SetValue("PrintingCopies", noOfCopies);
		RegistryKey registryKey3 = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Receipt printer");
		registryKey2.SetValue("PaperSize", PaperSize);
	}

	private static string SpacedString(string myOldString)
	{
		StringBuilder stringBuilder = new StringBuilder(string.Empty);
		char[] array = myOldString.ToCharArray();
		foreach (char c in array)
		{
			stringBuilder.Append(c + " ");
		}
		string result = string.Empty;
		if (stringBuilder.Length > 0)
		{
			result = stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
		}
		return result;
	}

	public static void PrintReceipt(string studentNumber, string s_name, string s_class, string s_stream, string s_studyStatus, string _receiptNo)
	{
		try
		{
			ReceiptParameters.ClassId = s_class;
			ReceiptParameters.ReceiptNo = _receiptNo;
			ReceiptParameters.StreamId = s_stream;
			ReceiptParameters.StudentNo = studentNumber;
			if (PaperSize == "A5 Landscape")
			{
				A5Receipt report = new A5Receipt(studentNumber, _receiptNo, PrintImage: true);
				ReportPrintTool reportPrintTool = new ReportPrintTool(report);
				reportPrintTool.Print(ReceiptPrinter);
				return;
			}
			if (PaperSize == "A5 Landscape (Plain)")
			{
				A5Receipt report2 = new A5Receipt(studentNumber, _receiptNo, PrintImage: false);
				ReportPrintTool reportPrintTool2 = new ReportPrintTool(report2);
				reportPrintTool2.Print(ReceiptPrinter);
				return;
			}
			double result = 0.0;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SUM(Debit) - SUM(Credit) AS cashOnAccount FROM    FeesPayment GROUP BY StudentNumber HAVING (StudentNumber = '{studentNumber}')", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "FeesBalance");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					result = (double.TryParse(row["cashOnAccount"].ToString(), out result) ? result : 0.0);
				}
			}
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT TOP (100) PERCENT PaymentId,Particulars,StudentNumber,ModeOfPayment, Debit, Credit, Balance,DateOfPayment,CaptureDate,BankSlipNo FROM FeesPayment AS FeesPayment_1 WHERE (PaymentId IN (SELECT MAX(PaymentId) AS PaymentId FROM FeesPayment AS FeesPayment WHERE StudentNumber = '{studentNumber}'))";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "ReceiptData");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet2.Tables[0];
			string text = string.Empty;
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			DateTime dateTime = DateTime.Now;
			string text2 = string.Empty;
			string empty5 = string.Empty;
			string text3 = string.Empty;
			NumberToWordsConverter numberToWordsConverter = new NumberToWordsConverter();
			string s = string.Empty;
			List<string> list = new List<string>();
			double[] array = new double[0];
			List<double> list2 = new List<double>();
			foreach (DataRow row2 in dataTable2.Rows)
			{
				using (SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter($"SELECT * FROM FeesPayment WHERE BankSlipNo='{_receiptNo}'", DataConnection.ConnectToDatabase()))
				{
					using DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "ItemsOnReceipt");
					foreach (DataRow row3 in dataSet3.Tables[0].Rows)
					{
						list.Add(string.Format("{0}|{1,10}", row3["Particulars"].ToString().PadRight(16).Substring(0, 16), Convert.ToDouble(row3["Credit"]).ToString("#,#.0")));
						list2.Add(Convert.ToDouble(row3["Credit"]));
					}
				}
				empty2 = s_class;
				empty4 = s_studyStatus;
				empty3 = s_stream;
				empty = s_name;
				text2 = _receiptNo;
				dateTime = Convert.ToDateTime(row2["DateOfPayment"].ToString());
				text = result.ToString("#,#.0");
				empty5 = row2["StudentNumber"].ToString();
				text3 = row2["ModeOfPayment"].ToString();
			}
			array = list2.ToArray();
			double num = array.Sum();
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			string text4 = "Balance:";
			string text5 = "Total:";
			string text6 = string.Empty;
			for (int i = 0; i < list.Count; i++)
			{
				text6 = text6 + list[i] + "\n";
			}
			string text7 = "THANK YOU";
			s = string.Format("{0}\n{1}\n{2}\n\n{3}\n---------------------------\nNo.{4}\tDT:{5}\n\nName:{6,13}\nClass:{7,2}{8}\n---------------------------\nItems\t\t\tAmount\n---------------------------\n{9}\n{10}{11,9}\n{12}{13,10}\n\nPayment Mode:\n{14}\nCashier's Name:\n{15}\n\nSignature:______________\n\t{16}", shortName, location, boxNo, receiptHeader, text2, dateTime.ToString("dd-MMM-yy"), s_name, s_class, s_stream, text6, text5.PadRight(18), num.ToString("#,#.0"), text4.PadRight(17), text, text3, CurrentUser.GetSystemUser(), text7);
			PrintDocument p = new PrintDocument();
			try
			{
				p.PrinterSettings.PrinterName = ReceiptPrinter;
				p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
				{
					e1.Graphics.DrawString(s, new Font("Consolas", 10f), new SolidBrush(Color.Black), new RectangleF(0f, 0f, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
				};
				p.Print();
			}
			finally
			{
				if (p != null)
				{
					((IDisposable)p).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
