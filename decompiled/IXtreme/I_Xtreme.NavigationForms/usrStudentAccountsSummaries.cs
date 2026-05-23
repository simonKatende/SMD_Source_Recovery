using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrStudentAccountsSummaries : XtraUserControl
{
	private IContainer components = null;

	private PivotGridControl pivotGridControl1;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField8;

	private PivotGridField pivotGridField9;

	private PivotGridField pivotGridField10;

	private PivotGridField pivotGridField11;

	private PivotGridField pivotGridField12;

	private SplitContainerControl splitContainerControl1;

	private PivotGridControl pivotGridControl2;

	private PivotGridField pivotGridFieldClass;

	private PivotGridField pivotGridFieldBF;

	private PivotGridField pivotGridFieldRequired;

	private PivotGridField pivotGridFieldTotalRequired;

	private PivotGridField pivotGridFieldPaid;

	private PivotGridField pivotGridFieldBalance;

	private PivotGridField pivotGridFieldStudentNo;

	private PivotGridField pivotGridFielStudentNo;

	private DataTable FeesAndOtherRequirement
	{
		get
		{
			string connectionString = DataConnection.ConnectToDatabase();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Class", typeof(string));
			dataTable.Columns.Add("Semester", typeof(string));
			dataTable.Columns.Add("B/F", typeof(double));
			dataTable.Columns.Add("Required", typeof(double));
			dataTable.Columns.Add("TotalRequired", typeof(double));
			dataTable.Columns.Add("Paid", typeof(double));
			dataTable.Columns.Add("Balance", typeof(double));
			dataTable.Columns.Add("StudentNo", typeof(string));
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT StudentNumber AS StudentNo,ClassId FROM tbl_Stud",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					while (sqlDataReader.Read())
					{
						object arg = sqlDataReader["StudentNo"];
						object obj = sqlDataReader["ClassId"];
						using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
						sqlConnection2.Open();
						using SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = $"SELECT TOP (100) PERCENT PaymentId, SemesterId, StudentNumber, Balance AS PreviousBalance FROM  FeesPayment AS FeesPayment_1 WHERE (PaymentId IN (SELECT MAX(PaymentId) AS PaymentId FROM FeesPayment AS FeesPayment  WHERE (StudentNumber = '{arg}') AND (SemesterId = '{GetPreviousSemester(StudentOptions.ActiveSemester())}')))",
							CommandType = CommandType.Text
						};
						using SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
						if (sqlDataReader2.HasRows)
						{
							while (sqlDataReader2.Read())
							{
								using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
								sqlConnection3.Open();
								using SqlCommand sqlCommand3 = new SqlCommand
								{
									Connection = sqlConnection3,
									CommandText = $"SELECT StudentNumber, SemesterId, SUM(Debit) AS Required, SUM(Credit) AS Paid FROM FeesPayment GROUP BY StudentNumber, SemesterId HAVING (StudentNumber = '{arg}') AND (SemesterId = '{StudentOptions.ActiveSemester()}')",
									CommandType = CommandType.Text
								};
								using SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
								while (sqlDataReader3.Read())
								{
									double num = Convert.ToDouble(sqlDataReader2["PreviousBalance"]);
									double num2 = Convert.ToDouble(sqlDataReader3["Required"]);
									double num3 = Convert.ToDouble(sqlDataReader2["PreviousBalance"]) + Convert.ToDouble(sqlDataReader3["Required"]);
									double num4 = Convert.ToDouble(sqlDataReader3["Paid"]);
									double num5 = num3 - num4;
									dataTable.Rows.Add(obj, StudentOptions.ActiveSemester(), num, num2, num3, num4, num5, sqlDataReader3["StudentNumber"].ToString());
								}
							}
							continue;
						}
						using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
						sqlConnection4.Open();
						using SqlCommand sqlCommand4 = new SqlCommand
						{
							Connection = sqlConnection4,
							CommandType = CommandType.Text,
							CommandText = $"SELECT StudentNumber, SemesterId, SUM(Debit) AS Required, SUM(Credit) AS Paid FROM FeesPayment GROUP BY StudentNumber, SemesterId HAVING (StudentNumber = '{arg}') AND (SemesterId = '{StudentOptions.ActiveSemester()}')"
						};
						using SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
						while (sqlDataReader4.Read())
						{
							double num6 = 0.0;
							double num7 = Convert.ToDouble(sqlDataReader4["Required"]);
							double num8 = Convert.ToDouble(sqlDataReader4["Required"]);
							double num9 = Convert.ToDouble(sqlDataReader4["Paid"]);
							double num10 = num8 - num9;
							dataTable.Rows.Add(obj, StudentOptions.ActiveSemester(), num6, num7, num8, num9, num10, sqlDataReader4["StudentNumber"].ToString());
						}
					}
				}
				else
				{
					Console.WriteLine("No rows found.");
				}
			}
			using (SqlConnection sqlConnection5 = new SqlConnection(connectionString))
			{
				sqlConnection5.Open();
				using SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection5,
					CommandType = CommandType.Text,
					CommandText = string.Format("SELECT UPPER(t1.StudentNumber) AS StudentNo ,SUM(t1.Debit) AS Required, SUM(t1.Credit) AS Paid,SUM(t1.Debit)-SUM(t1.Credit) AS Balance,t1.SemesterId,s.ClassId  FROM FeesPayment t1 INNER JOIN tbl_Stud s ON t1.StudentNumber=s.StudentNumber  WHERE NOT EXISTS (SELECT * FROM FeesPayment t2 WHERE t2.SemesterId='{0}' AND t1.StudentNumber=t2.StudentNumber) AND t1.SemesterId='{0}' Group by t1.StudentNumber,t1.SemesterId,s.ClassId", GetPreviousSemester(StudentOptions.ActiveSemester()), StudentOptions.ActiveSemester())
				};
				using SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				while (sqlDataReader5.Read())
				{
					double num11 = 0.0;
					double num12 = Convert.ToDouble(sqlDataReader5["Required"]);
					double num13 = num11 + Convert.ToDouble(sqlDataReader5["Required"]);
					double num14 = Convert.ToDouble(sqlDataReader5["Paid"]);
					double num15 = num13 - num14;
					dataTable.Rows.Add(sqlDataReader5["ClassId"], StudentOptions.ActiveSemester(), num11, num12, num13, num14, num15, sqlDataReader5["StudentNo"].ToString());
				}
			}
			return dataTable;
		}
	}

	public usrStudentAccountsSummaries()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Generating fees collection analysis...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.InitializeFeesSummaries, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadStudentLists();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private static string GetPreviousSemester(string currentSemester)
	{
		string text = currentSemester.Substring(0, currentSemester.IndexOf('-'));
		int num = Convert.ToInt32(currentSemester.Substring(currentSemester.IndexOf('-') + 1, 4));
		string result = string.Empty;
		if (currentSemester.Length == 10)
		{
			result = "TermIII-" + (num - 1);
		}
		else if (currentSemester.Length == 11)
		{
			result = "TermI-" + num;
		}
		else if (currentSemester.Length == 12)
		{
			result = "TermII-" + num;
		}
		return result;
	}

	private void LoadStudentLists()
	{
		try
		{
			pivotGridControl1.DataSource = FeesAndOtherRequirement;
			pivotGridControl2.DataSource = FeesAndOtherRequirement;
			ActiveFormSelected.SetActiveForm("Fees Collection Analysis");
			PrintableControl.SavePrintableControl(pivotGridControl1, pivotGridControl2);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldStudentNo = new DevExpress.XtraPivotGrid.PivotGridField();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.pivotGridControl2 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridFieldClass = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldBF = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldRequired = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldTotalRequired = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldPaid = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldBalance = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFielStudentNo = new DevExpress.XtraPivotGrid.PivotGridField();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).BeginInit();
		base.SuspendLayout();
		this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[7] { this.pivotGridField3, this.pivotGridField8, this.pivotGridField9, this.pivotGridField10, this.pivotGridField11, this.pivotGridField12, this.pivotGridFieldStudentNo });
		this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsChartDataSource.AutoTransposeChart = true;
		this.pivotGridControl1.OptionsCustomization.AllowEdit = false;
		this.pivotGridControl1.OptionsCustomization.AllowExpandOnDoubleClick = false;
		this.pivotGridControl1.OptionsCustomization.AllowFilter = false;
		this.pivotGridControl1.OptionsCustomization.AllowFilterBySummary = false;
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(774, 244);
		this.pivotGridControl1.TabIndex = 0;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField3.AreaIndex = 0;
		this.pivotGridField3.Caption = "Class";
		this.pivotGridField3.FieldName = "Class";
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField8.AreaIndex = 1;
		this.pivotGridField8.Caption = "B/F";
		this.pivotGridField8.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField8.FieldName = "B/F";
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField9.AreaIndex = 2;
		this.pivotGridField9.Caption = "Required";
		this.pivotGridField9.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField9.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField9.FieldName = "Required";
		this.pivotGridField9.Name = "pivotGridField9";
		this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField10.AreaIndex = 3;
		this.pivotGridField10.Caption = "Total Required";
		this.pivotGridField10.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField10.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField10.FieldName = "TotalRequired";
		this.pivotGridField10.Name = "pivotGridField10";
		this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField11.AreaIndex = 4;
		this.pivotGridField11.Caption = "Paid";
		this.pivotGridField11.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField11.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField11.FieldName = "Paid";
		this.pivotGridField11.Name = "pivotGridField11";
		this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField12.AreaIndex = 5;
		this.pivotGridField12.Caption = "Balance";
		this.pivotGridField12.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField12.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField12.FieldName = "Balance";
		this.pivotGridField12.Name = "pivotGridField12";
		this.pivotGridFieldStudentNo.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldStudentNo.AreaIndex = 0;
		this.pivotGridFieldStudentNo.Caption = "Total Students";
		this.pivotGridFieldStudentNo.FieldName = "StudentNo";
		this.pivotGridFieldStudentNo.Name = "pivotGridFieldStudentNo";
		this.pivotGridFieldStudentNo.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.Horizontal = false;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.pivotGridControl1);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.pivotGridControl2);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(774, 518);
		this.splitContainerControl1.SplitterPosition = 244;
		this.splitContainerControl1.TabIndex = 2;
		this.splitContainerControl1.Text = "splitContainerControl1";
		this.pivotGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridControl2.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[7] { this.pivotGridFieldClass, this.pivotGridFieldBF, this.pivotGridFieldRequired, this.pivotGridFieldTotalRequired, this.pivotGridFieldPaid, this.pivotGridFieldBalance, this.pivotGridFielStudentNo });
		this.pivotGridControl2.Location = new System.Drawing.Point(0, 0);
		this.pivotGridControl2.Name = "pivotGridControl2";
		this.pivotGridControl2.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl2.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl2.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl2.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl2.Size = new System.Drawing.Size(774, 262);
		this.pivotGridControl2.TabIndex = 0;
		this.pivotGridFieldClass.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridFieldClass.AreaIndex = 0;
		this.pivotGridFieldClass.FieldName = "Class";
		this.pivotGridFieldClass.Name = "pivotGridFieldClass";
		this.pivotGridFieldBF.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldBF.AreaIndex = 1;
		this.pivotGridFieldBF.Caption = "B/F";
		this.pivotGridFieldBF.FieldName = "B/F";
		this.pivotGridFieldBF.Name = "pivotGridFieldBF";
		this.pivotGridFieldBF.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumnGrandTotal;
		this.pivotGridFieldRequired.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldRequired.AreaIndex = 2;
		this.pivotGridFieldRequired.FieldName = "Required";
		this.pivotGridFieldRequired.Name = "pivotGridFieldRequired";
		this.pivotGridFieldRequired.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumnGrandTotal;
		this.pivotGridFieldTotalRequired.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldTotalRequired.AreaIndex = 3;
		this.pivotGridFieldTotalRequired.Caption = "Total Required";
		this.pivotGridFieldTotalRequired.FieldName = "TotalRequired";
		this.pivotGridFieldTotalRequired.Name = "pivotGridFieldTotalRequired";
		this.pivotGridFieldTotalRequired.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumnGrandTotal;
		this.pivotGridFieldPaid.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldPaid.AreaIndex = 4;
		this.pivotGridFieldPaid.FieldName = "Paid";
		this.pivotGridFieldPaid.Name = "pivotGridFieldPaid";
		this.pivotGridFieldPaid.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumnGrandTotal;
		this.pivotGridFieldBalance.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldBalance.AreaIndex = 5;
		this.pivotGridFieldBalance.FieldName = "Balance";
		this.pivotGridFieldBalance.Name = "pivotGridFieldBalance";
		this.pivotGridFieldBalance.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumnGrandTotal;
		this.pivotGridFielStudentNo.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFielStudentNo.AreaIndex = 0;
		this.pivotGridFielStudentNo.Caption = "Students (%)";
		this.pivotGridFielStudentNo.FieldName = "StudentNo";
		this.pivotGridFielStudentNo.Name = "pivotGridFielStudentNo";
		this.pivotGridFielStudentNo.SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumnGrandTotal;
		this.pivotGridFielStudentNo.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.splitContainerControl1);
		base.Name = "usrStudentAccountsSummaries";
		base.Size = new System.Drawing.Size(774, 518);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).EndInit();
		base.ResumeLayout(false);
	}
}
