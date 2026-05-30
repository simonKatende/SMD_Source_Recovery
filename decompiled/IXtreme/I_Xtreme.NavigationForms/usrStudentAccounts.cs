using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrStudentAccounts : XtraUserControl
{
	private int hotTrackRow = int.MinValue;

	private readonly string _classScope;

	private IContainer components = null;

	private MyGridControl f;

	private MyGridView gridViewStudentLists;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColNo;

	private GridColumn gridColName;

	private GridColumn gridColStudentNo;

	private GridColumn gridColStream;

	private GridColumn gridColSex;

	private GridColumn gridColDB;

	private GridColumn gridColClass;

	private GridColumn gridColSemester;

	private GridColumn gridColBF;

	private GridColumn gridColRequired;

	private GridColumn gridColTotalRequired;

	private GridColumn gridColPaid;

	private GridColumn gridColBalance;

	private System.Windows.Forms.Timer timer1;

	private GridColumn gridColumn1;

	private DataTable FeesAndOtherRequirement
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("StudentNo", typeof(string));
			dataTable.Columns.Add("StudentID", typeof(string));
			dataTable.Columns.Add("Stream", typeof(string));
			dataTable.Columns.Add("Sex", typeof(string));
			dataTable.Columns.Add("DB", typeof(string));
			dataTable.Columns.Add("Class", typeof(string));
			dataTable.Columns.Add("Semester", typeof(string));
			dataTable.Columns.Add("B/F", typeof(double));
			dataTable.Columns.Add("Required", typeof(double));
			dataTable.Columns.Add("TotalRequired", typeof(double));
			dataTable.Columns.Add("Paid", typeof(double));
			dataTable.Columns.Add("Balance", typeof(double));
			string classFilter = (_classScope == "All Classes") ? "" : $" WHERE ClassId='{_classScope}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT UPPER(fullName) AS Name, StudentNumber AS StudentNo, StreamId AS Stream,ClassId,Sex,StudentID, StudyStatus AS DB FROM tbl_Stud{classFilter}", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "studentsList");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT TOP (100) PERCENT PaymentId, SemesterId, StudentNumber, Balance AS PreviousBalance FROM  FeesPayment AS FeesPayment_1 WHERE (PaymentId IN (SELECT MAX(PaymentId) AS PaymentId FROM FeesPayment AS FeesPayment  WHERE (StudentNumber = '{0}') AND (SemesterId = '{1}')))", row["StudentNo"], GetPreviousSemester(StudentOptions.ActiveSemester())), DataConnection.ConnectToDatabase());
				using DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "PreviousBalance");
				DataTable dataTable3 = new DataTable();
				dataTable3 = dataSet2.Tables[0];
				if (dataTable3.Rows.Count > 0)
				{
					foreach (DataRow row2 in dataTable3.Rows)
					{
						string selectCommandText = string.Format("SELECT StudentNumber, SemesterId, SUM(Debit) AS Required, SUM(Credit) AS Paid FROM FeesPayment GROUP BY StudentNumber, SemesterId HAVING (StudentNumber = '{0}') AND (SemesterId = '{1}')", row["StudentNo"], StudentOptions.ActiveSemester());
						using SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
						using DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3, "NewBalance");
						DataTable dataTable4 = new DataTable();
						dataTable4 = dataSet3.Tables[0];
						foreach (DataRow row3 in dataTable4.Rows)
						{
							double num = Convert.ToDouble(row2["PreviousBalance"]);
							double num2 = Convert.ToDouble(row3["Required"]);
							double num3 = Convert.ToDouble(row2["PreviousBalance"]) + Convert.ToDouble(row3["Required"]);
							double num4 = Convert.ToDouble(row3["Paid"]);
							double num5 = num3 - num4;
							dataTable.Rows.Add(row["Name"], row["StudentNo"], row["StudentID"], row["Stream"], row["Sex"], row["DB"], row["ClassId"], StudentOptions.ActiveSemester(), num, num2, num3, num4, num5);
						}
					}
				}
				else
				{
					if (dataTable3.Rows.Count != 0)
					{
						continue;
					}
					string selectCommandText2 = string.Format("SELECT StudentNumber, SemesterId, SUM(Debit) AS Required, SUM(Credit) AS Paid FROM FeesPayment GROUP BY StudentNumber, SemesterId HAVING (StudentNumber = '{0}') AND (SemesterId = '{1}')", row["StudentNo"], StudentOptions.ActiveSemester());
					using (SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText2, DataConnection.ConnectToDatabase()))
					{
						using DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4, "NewBalance");
						DataTable dataTable5 = new DataTable();
						dataTable5 = dataSet4.Tables[0];
						foreach (DataRow row4 in dataTable5.Rows)
						{
							double num6 = 0.0;
							double num7 = Convert.ToDouble(row4["Required"]);
							double num8 = Convert.ToDouble(row4["Required"]);
							double num9 = Convert.ToDouble(row4["Paid"]);
							double num10 = num8 - num9;
							dataTable.Rows.Add(row["Name"], row["StudentNo"], row["StudentID"], row["Stream"], row["Sex"], row["DB"], row["ClassId"], StudentOptions.ActiveSemester(), num6, num7, num8, num9, num10);
						}
					}
					continue;
				}
			}
			string classFilter3 = (_classScope == "All Classes") ? "" : " AND ClassId='{1}'";
			string selectCommandText3 = string.Format("SELECT UPPER(t1.StudentNumber) AS StudentNo,s.StudentID,SUM(t1.Debit) AS Required, SUM(t1.Credit) AS Paid,SUM(t1.Debit)-SUM(t1.Credit) AS Balance,UPPER(s.fullName) AS Name,(s.StreamId) AS Stream,(s.StudyStatus) AS DB,t1.SemesterId,s.Sex,s.ClassId  FROM FeesPayment t1 INNER JOIN tbl_Stud s ON t1.StudentNumber=s.StudentNumber  WHERE NOT EXISTS (SELECT * FROM FeesPayment t2 WHERE t2.SemesterId='{0}' AND t1.StudentNumber=t2.StudentNumber) AND t1.SemesterId='{0}'" + classFilter3 + " Group by t1.StudentNumber,s.fullName,s.StreamId,s.StudyStatus,t1.SemesterId,s.Sex,s.ClassId,s.StudentID", GetPreviousSemester(StudentOptions.ActiveSemester()), StudentOptions.ActiveSemester());
			using (SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText3, DataConnection.ConnectToDatabase()))
			{
				using DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5, "NewStudentBalance");
				DataTable dataTable6 = new DataTable();
				dataTable6 = dataSet5.Tables[0];
				foreach (DataRow row5 in dataTable6.Rows)
				{
					double num11 = 0.0;
					double num12 = Convert.ToDouble(row5["Required"]);
					double num13 = num11 + Convert.ToDouble(row5["Required"]);
					double num14 = Convert.ToDouble(row5["Paid"]);
					double num15 = num13 - num14;
					dataTable.Rows.Add(row5["Name"], row5["StudentNo"], row5["StudentID"], row5["Stream"], row5["Sex"], row5["DB"], row5["ClassId"], StudentOptions.ActiveSemester(), num11, num12, num13, num14, num15);
				}
			}
			return dataTable;
		}
	}

	private int HotTrackRow
	{
		get
		{
			return hotTrackRow;
		}
		set
		{
			if (hotTrackRow != value)
			{
				int rowHandle = hotTrackRow;
				hotTrackRow = value;
				gridViewStudentLists.RefreshRow(rowHandle);
				gridViewStudentLists.RefreshRow(hotTrackRow);
				if (hotTrackRow >= 0)
				{
					f.Cursor = Cursors.Hand;
				}
				else
				{
					f.Cursor = Cursors.Default;
				}
			}
		}
	}

	public usrStudentAccounts(string classScope)
	{
		_classScope = classScope;
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading " + classScope + " Fees Tracking Sheet...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.InitializeFeesTrackingSheet, 0);
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
			f.DataSource = FeesAndOtherRequirement;
			ActiveFormSelected.SetActiveForm(_classScope + " Fees Tracking Sheet");
			PrintableControl.SavePrintableControl(f);
			PrintableControl.SavePrintableControl(gridViewStudentLists);
			timer1.Enabled = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridViewStudentLists_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (gridViewStudentLists.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	public void StudentFeesCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void gridViewStudentLists_DoubleClick(object sender, EventArgs e)
	{
		if (gridViewStudentLists.GetFocusedDataSourceRowIndex() > -1)
		{
			StudentOptions.SetActiveStudent(gridViewStudentLists.GetRowCellValue(gridViewStudentLists.FocusedRowHandle, "StudentNo").ToString());
			StudentOptions.SetPaymentMode("SingleStudent");
			using StudentFeesPayment studentFeesPayment = new StudentFeesPayment("StudentList");
			studentFeesPayment.RefreshList = StudentFeesCallBackFN;
			studentFeesPayment.ShowDialog();
		}
	}

	private void f_KeyDown(object sender, KeyEventArgs e)
	{
		if (gridViewStudentLists.GetFocusedDataSourceRowIndex() > -1 && e.KeyCode == Keys.Return)
		{
			DataRow dataRow = FeesAndOtherRequirement.Rows[gridViewStudentLists.GetFocusedDataSourceRowIndex()];
			StudentOptions.SetActiveStudent(dataRow["StudentNo"].ToString());
			StudentOptions.SetPaymentMode("SingleStudent");
			using StudentFeesPayment studentFeesPayment = new StudentFeesPayment("SingleStudentPayment");
			studentFeesPayment.ShowDialog();
		}
	}

	private void gridViewStudentLists_MouseMove(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		GridHitInfo gridHitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
		if (gridHitInfo.InRowCell)
		{
			HotTrackRow = gridHitInfo.RowHandle;
		}
		else
		{
			HotTrackRow = int.MinValue;
		}
	}

	private double _balanceSummaryAccum;
	private void gridViewStudentLists_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
	{
		switch (e.SummaryProcess)
		{
			case DevExpress.Data.CustomSummaryProcess.Start:
				_balanceSummaryAccum = 0;
				break;
			case DevExpress.Data.CustomSummaryProcess.Calculate:
				double v = Convert.ToDouble(e.FieldValue);
				if (v > 0) _balanceSummaryAccum += v;
				break;
			case DevExpress.Data.CustomSummaryProcess.Finalize:
				e.TotalValue = _balanceSummaryAccum;
				break;
		}
	}

	private void gridViewStudentLists_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
		if (e.RowHandle == HotTrackRow)
		{
			e.Appearance.BackColor = Color.Magenta;
			e.Appearance.BackColor2 = Color.Magenta;
			e.Appearance.ForeColor = Color.White;
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Refreshing " + _classScope + " Fees Tracking Sheet...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.InitializeFeesTrackingSheet, 0);
		Thread.Sleep(25);
		LoadStudentLists();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
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
		this.components = new System.ComponentModel.Container();
		this.f = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewStudentLists = new AlienAge.CustomGrid.MyGridView();
		this.gridColNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColStudentNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColStream = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColSex = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColDB = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColClass = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColSemester = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBF = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColRequired = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColTotalRequired = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColPaid = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBalance = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.f).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentLists).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.f.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.f.Location = new System.Drawing.Point(2, 2);
		this.f.MainView = this.gridViewStudentLists;
		this.f.Name = "f";
		this.f.Size = new System.Drawing.Size(866, 533);
		this.f.TabIndex = 2;
		this.f.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewStudentLists });
		this.f.KeyDown += new System.Windows.Forms.KeyEventHandler(f_KeyDown);
		this.gridViewStudentLists.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.gridViewStudentLists.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridViewStudentLists.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.HotTrack;
		this.gridViewStudentLists.Appearance.FocusedCell.BackColor2 = System.Drawing.SystemColors.HotTrack;
		this.gridViewStudentLists.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
		this.gridViewStudentLists.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewStudentLists.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridViewStudentLists.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.HotTrack;
		this.gridViewStudentLists.Appearance.FocusedRow.BackColor2 = System.Drawing.SystemColors.HotTrack;
		this.gridViewStudentLists.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
		this.gridViewStudentLists.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewStudentLists.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridViewStudentLists.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.HotTrack;
		this.gridViewStudentLists.Appearance.SelectedRow.BackColor2 = System.Drawing.SystemColors.HotTrack;
		this.gridViewStudentLists.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
		this.gridViewStudentLists.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewStudentLists.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridViewStudentLists.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.gridViewStudentLists.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridViewStudentLists.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[14]
		{
			this.gridColNo, this.gridColName, this.gridColumn1, this.gridColStudentNo, this.gridColStream, this.gridColSex, this.gridColDB, this.gridColClass, this.gridColSemester, this.gridColBF,
			this.gridColRequired, this.gridColTotalRequired, this.gridColPaid, this.gridColBalance
		});
		this.gridViewStudentLists.GridControl = this.f;
		this.gridViewStudentLists.IndicatorWidth = 30;
		this.gridViewStudentLists.Name = "gridViewStudentLists";
		this.gridViewStudentLists.OptionsBehavior.Editable = false;
		this.gridViewStudentLists.OptionsCustomization.AllowGroup = false;
		this.gridViewStudentLists.OptionsFind.AlwaysVisible = true;
		this.gridViewStudentLists.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridViewStudentLists.OptionsPrint.PrintFilterInfo = true;
		this.gridViewStudentLists.OptionsPrint.PrintHorzLines = false;
		this.gridViewStudentLists.OptionsView.ShowFooter = true;
		this.gridViewStudentLists.OptionsView.ShowGroupPanel = false;
		this.gridViewStudentLists.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewStudentLists.OptionsView.ShowIndicator = false;
		this.gridViewStudentLists.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridViewStudentLists_RowCellStyle);
		this.gridViewStudentLists.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridViewStudentLists_CustomColumnDisplayText);
		this.gridViewStudentLists.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridViewStudentLists_CustomSummaryCalculate);
		this.gridViewStudentLists.MouseMove += new System.Windows.Forms.MouseEventHandler(gridViewStudentLists_MouseMove);
		this.gridViewStudentLists.DoubleClick += new System.EventHandler(gridViewStudentLists_DoubleClick);
		this.gridColNo.Caption = "No";
		this.gridColNo.Name = "gridColNo";
		this.gridColNo.Visible = true;
		this.gridColNo.VisibleIndex = 0;
		this.gridColNo.Width = 27;
		this.gridColName.Caption = "Name";
		this.gridColName.FieldName = "Name";
		this.gridColName.Name = "gridColName";
		this.gridColName.Visible = true;
		this.gridColName.VisibleIndex = 1;
		this.gridColName.Width = 156;
		this.gridColStudentNo.Caption = "StudentID";
		this.gridColStudentNo.FieldName = "StudentID";
		this.gridColStudentNo.Name = "gridColStudentNo";
		this.gridColStudentNo.Visible = true;
		this.gridColStudentNo.VisibleIndex = 3;
		this.gridColStudentNo.Width = 55;
		this.gridColStream.Caption = "Stream";
		this.gridColStream.FieldName = "Stream";
		this.gridColStream.Name = "gridColStream";
		this.gridColStream.Visible = true;
		this.gridColStream.VisibleIndex = 4;
		this.gridColStream.Width = 36;
		this.gridColSex.Caption = "Sex";
		this.gridColSex.FieldName = "Sex";
		this.gridColSex.Name = "gridColSex";
		this.gridColSex.Visible = true;
		this.gridColSex.VisibleIndex = 5;
		this.gridColSex.Width = 27;
		this.gridColDB.Caption = "DB";
		this.gridColDB.FieldName = "DB";
		this.gridColDB.Name = "gridColDB";
		this.gridColDB.Visible = true;
		this.gridColDB.VisibleIndex = 6;
		this.gridColDB.Width = 27;
		this.gridColClass.Caption = "Class";
		this.gridColClass.FieldName = "Class";
		this.gridColClass.Name = "gridColClass";
		this.gridColClass.Visible = true;
		this.gridColClass.VisibleIndex = 12;
		this.gridColClass.Width = 50;
		this.gridColSemester.Caption = "Semester";
		this.gridColSemester.FieldName = "Semester";
		this.gridColSemester.Name = "gridColSemester";
		this.gridColSemester.Width = 87;
		this.gridColBF.Caption = "Fees B/F";
		this.gridColBF.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBF.FieldName = "B/F";
		this.gridColBF.Name = "gridColBF";
		this.gridColBF.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "B/F", "{0:#,#.0}")
		});
		this.gridColBF.Visible = true;
		this.gridColBF.VisibleIndex = 7;
		this.gridColBF.Width = 93;
		this.gridColRequired.Caption = "Fees Payable";
		this.gridColRequired.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColRequired.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColRequired.FieldName = "Required";
		this.gridColRequired.Name = "gridColRequired";
		this.gridColRequired.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Required", "{0:#,#.0}")
		});
		this.gridColRequired.Visible = true;
		this.gridColRequired.VisibleIndex = 8;
		this.gridColRequired.Width = 93;
		this.gridColTotalRequired.Caption = "Ttl Payable";
		this.gridColTotalRequired.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColTotalRequired.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColTotalRequired.FieldName = "TotalRequired";
		this.gridColTotalRequired.Name = "gridColTotalRequired";
		this.gridColTotalRequired.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalRequired", "{0:#,#.0}")
		});
		this.gridColTotalRequired.Visible = true;
		this.gridColTotalRequired.VisibleIndex = 9;
		this.gridColTotalRequired.Width = 93;
		this.gridColPaid.Caption = "Ttl Paid";
		this.gridColPaid.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColPaid.FieldName = "Paid";
		this.gridColPaid.Name = "gridColPaid";
		this.gridColPaid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Paid", "{0:#,#.0}")
		});
		this.gridColPaid.Visible = true;
		this.gridColPaid.VisibleIndex = 10;
		this.gridColPaid.Width = 93;
		this.gridColBalance.Caption = "Balance";
		this.gridColBalance.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBalance.FieldName = "Balance";
		this.gridColBalance.Name = "gridColBalance";
		this.gridColBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Balance", "{0:#,#.0}")
		});
		this.gridColBalance.Visible = true;
		this.gridColBalance.VisibleIndex = 11;
		this.gridColBalance.Width = 104;
		this.layoutControl1.Controls.Add(this.f);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(870, 537);
		this.layoutControl1.TabIndex = 3;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(870, 537);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.f;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(870, 537);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.gridColumn1.Caption = "Student No.";
		this.gridColumn1.FieldName = "StudentNo";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 2;
		this.gridColumn1.Width = 60;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrStudentAccounts";
		base.Size = new System.Drawing.Size(870, 537);
		((System.ComponentModel.ISupportInitialize)this.f).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentLists).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
