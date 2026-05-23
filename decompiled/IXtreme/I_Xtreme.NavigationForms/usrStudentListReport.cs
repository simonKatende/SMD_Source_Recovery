using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Data.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using SMDFastLane.AppData;
using SMDFastLane.Models;

namespace I_Xtreme.NavigationForms;

public class usrStudentListReport : XtraUserControl
{
	private string StudentClass = string.Empty;

	private string connection = string.Empty;

	private IContainer components = null;

	private MyGridControl gridStudentRecords;

	private MyGridView gv;

	private GridColumn colName;

	private GridColumn colStudentNo;

	private GridColumn colStream;

	private GridColumn colDB;

	private GridColumn colSex;

	private GridColumn colStudNotes;

	private GridColumn colPicture;

	private GridColumn colBursaryStatus;

	private GridColumn colBursaryProvider;

	private GridColumn colFees;

	private GridColumn colFormerSchool;

	private GridColumn colAdmitDate;

	private GridColumn colHouse;

	private GridColumn colGuardian;

	private GridColumn colReligion;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem2;

	private GridColumn colNo;

	private GridColumn colFeesBalance;

	private GridColumn colGuardianContact;

	private GridColumn DOB;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn1;

	private GridColumn gridColClass;

	private GridColumn gridColumn9;

	private EntityInstantFeedbackSource entityInstantFeedbackSource1;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private GridColumn gridColumn12;

	private GridColumn gridColumn13;

	private GridColumn gridColumn14;

	private GridColumn gridColumn15;

	private GridColumn gridColumn16;

	private GridColumn gridColumn17;

	public usrStudentListReport(string StudentClass)
	{
		InitializeComponent();
		this.StudentClass = StudentClass;
		LoadStudents();
	}

	private void EntityInstantFeedbackSource1_DismissQueryable(object sender, GetQueryableEventArgs e)
	{
		((SMDDBContext)e.Tag).Dispose();
	}

	private void EntityInstantFeedbackSource1_GetQueryable(object sender, GetQueryableEventArgs e)
	{
		try
		{
			if (StudentOptions.LoadingMode() == "Auto")
			{
				string[] array = Classes.ListOfClasses().Split();
				foreach (string _class in array)
				{
					SMDDBContext sMDDBContext = new SMDDBContext();
					IQueryable<Student> source = sMDDBContext.Students.Where((Student p) => p.ClassId.Equals(_class));
					int num = source.Count();
					e.QueryableSource = source.AsQueryable();
					e.Tag = sMDDBContext;
					if (num > 0)
					{
						StudentClass = _class;
						break;
					}
				}
			}
			else
			{
				if (!(StudentOptions.LoadingMode() == "Custom"))
				{
					return;
				}
				if (StudentClass == "All")
				{
					SMDDBContext sMDDBContext2 = new SMDDBContext();
					IQueryable<Student> source2 = sMDDBContext2.Students.Select((Student p) => p);
					e.QueryableSource = source2.AsQueryable();
					e.Tag = sMDDBContext2;
				}
				else
				{
					SMDDBContext sMDDBContext3 = new SMDDBContext();
					IQueryable<Student> source3 = sMDDBContext3.Students.Where((Student p) => p.ClassId.Equals(StudentClass));
					e.QueryableSource = source3.AsQueryable();
					e.Tag = sMDDBContext3;
				}
				StudentOptions.SetActiveClass(StudentClass);
				ActiveFormSelected.SetActiveForm(StudentClass + " Students' List");
				PrintableControl.SavePrintableControl(gridStudentRecords);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.InnerException.Message.ToString());
		}
	}

	private void LoadStudents()
	{
		entityInstantFeedbackSource1.GetQueryable += EntityInstantFeedbackSource1_GetQueryable;
		entityInstantFeedbackSource1.DismissQueryable += EntityInstantFeedbackSource1_DismissQueryable;
	}

	public void StudentCallBackFN(bool timerStatus)
	{
		if (timerStatus)
		{
			LoadStudents();
		}
	}

	private void dgRecords_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo")
		{
			e.DisplayText = (gv.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
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
		this.gridStudentRecords = new AlienAge.CustomGrid.MyGridControl();
		this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
		this.gv = new AlienAge.CustomGrid.MyGridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStudentNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColClass = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStream = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colDB = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStudNotes = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colPicture = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colBursaryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colBursaryProvider = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colFees = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colFeesBalance = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colFormerSchool = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colHouse = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colGuardian = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colReligion = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colGuardianContact = new DevExpress.XtraGrid.Columns.GridColumn();
		this.DOB = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gv).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.gridStudentRecords.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridStudentRecords.DataSource = this.entityInstantFeedbackSource1;
		this.gridStudentRecords.Location = new System.Drawing.Point(7, 7);
		this.gridStudentRecords.MainView = this.gv;
		this.gridStudentRecords.Name = "gridStudentRecords";
		this.gridStudentRecords.Size = new System.Drawing.Size(932, 503);
		this.gridStudentRecords.TabIndex = 0;
		this.gridStudentRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gv });
		this.entityInstantFeedbackSource1.AreSourceRowsThreadSafe = true;
		this.entityInstantFeedbackSource1.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(EntityInstantFeedbackSource1_GetQueryable);
		this.entityInstantFeedbackSource1.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(EntityInstantFeedbackSource1_DismissQueryable);
		this.gv.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gv.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gv.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gv.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.DetailTip.Options.UseFont = true;
		this.gv.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.Empty.Options.UseFont = true;
		this.gv.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gv.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.EvenRow.Options.UseBackColor = true;
		this.gv.Appearance.EvenRow.Options.UseFont = true;
		this.gv.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gv.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.FilterPanel.Options.UseFont = true;
		this.gv.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.FixedLine.Options.UseFont = true;
		this.gv.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gv.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gv.Appearance.FocusedCell.Options.UseFont = true;
		this.gv.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gv.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gv.Appearance.FocusedRow.Options.UseFont = true;
		this.gv.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.FooterPanel.Options.UseFont = true;
		this.gv.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.GroupButton.Options.UseFont = true;
		this.gv.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.GroupFooter.Options.UseFont = true;
		this.gv.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.GroupPanel.Options.UseFont = true;
		this.gv.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.GroupRow.Options.UseFont = true;
		this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.HeaderPanel.Options.UseFont = true;
		this.gv.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gv.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gv.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.HorzLine.Options.UseFont = true;
		this.gv.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.OddRow.Options.UseFont = true;
		this.gv.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.Preview.Options.UseFont = true;
		this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.Row.Options.UseFont = true;
		this.gv.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.RowSeparator.Options.UseFont = true;
		this.gv.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gv.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gv.Appearance.SelectedRow.Options.UseFont = true;
		this.gv.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.TopNewRow.Options.UseFont = true;
		this.gv.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.VertLine.Options.UseFont = true;
		this.gv.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.Appearance.ViewCaption.Options.UseFont = true;
		this.gv.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gv.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gv.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gv.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gv.AppearancePrint.FilterPanel.Options.UseTextOptions = true;
		this.gv.AppearancePrint.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gv.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gv.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gv.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gv.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gv.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.Lines.Options.UseFont = true;
		this.gv.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.OddRow.Options.UseFont = true;
		this.gv.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.Preview.Options.UseFont = true;
		this.gv.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gv.AppearancePrint.Row.Options.UseFont = true;
		this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[37]
		{
			this.colNo, this.colName, this.gridColumn16, this.colStudentNo, this.gridColClass, this.colStream, this.colDB, this.colSex, this.colStudNotes, this.colPicture,
			this.colBursaryStatus, this.colBursaryProvider, this.colFees, this.colFeesBalance, this.colFormerSchool, this.colAdmitDate, this.colHouse, this.colGuardian, this.colReligion, this.colGuardianContact,
			this.DOB, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn8, this.gridColumn1, this.gridColumn9,
			this.gridColumn10, this.gridColumn11, this.gridColumn12, this.gridColumn13, this.gridColumn14, this.gridColumn15, this.gridColumn17
		});
		this.gv.GridControl = this.gridStudentRecords;
		this.gv.IndicatorWidth = 35;
		this.gv.Name = "gv";
		this.gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv.OptionsBehavior.Editable = false;
		this.gv.OptionsCustomization.AllowGroup = false;
		this.gv.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
		this.gv.OptionsFind.AlwaysVisible = true;
		this.gv.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gv.OptionsPrint.PrintFilterInfo = true;
		this.gv.OptionsPrint.PrintGroupFooter = false;
		this.gv.OptionsPrint.PrintHorzLines = false;
		this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gv.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
		this.gv.OptionsView.EnableAppearanceEvenRow = true;
		this.gv.OptionsView.ShowFooter = true;
		this.gv.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gv.OptionsView.ShowIndicator = false;
		this.gv.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gv.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(dgRecords_CustomColumnDisplayText);
		this.colNo.Caption = "#";
		this.colNo.Name = "colNo";
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 35;
		this.colName.Caption = "Name";
		this.colName.FieldName = "fullName";
		this.colName.Name = "colName";
		this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "fullName", "TOTAL STUDENTS: {0:#,#}")
		});
		this.colName.Visible = true;
		this.colName.VisibleIndex = 1;
		this.colName.Width = 202;
		this.gridColumn16.Caption = "Student ID";
		this.gridColumn16.FieldName = "StudentID";
		this.gridColumn16.Name = "gridColumn16";
		this.gridColumn16.Visible = true;
		this.gridColumn16.VisibleIndex = 2;
		this.gridColumn16.Width = 89;
		this.colStudentNo.Caption = "StudentNo";
		this.colStudentNo.FieldName = "StudentNumber";
		this.colStudentNo.Name = "colStudentNo";
		this.colStudentNo.Width = 180;
		this.gridColClass.Caption = "Class";
		this.gridColClass.FieldName = "ClassId";
		this.gridColClass.Name = "gridColClass";
		this.gridColClass.Visible = true;
		this.gridColClass.VisibleIndex = 3;
		this.gridColClass.Width = 37;
		this.colStream.Caption = "Stream";
		this.colStream.FieldName = "StreamId";
		this.colStream.Name = "colStream";
		this.colStream.Visible = true;
		this.colStream.VisibleIndex = 4;
		this.colStream.Width = 34;
		this.colDB.Caption = "DB";
		this.colDB.FieldName = "StudyStatus";
		this.colDB.Name = "colDB";
		this.colDB.Visible = true;
		this.colDB.VisibleIndex = 5;
		this.colDB.Width = 31;
		this.colSex.Caption = "Sex";
		this.colSex.FieldName = "Sex";
		this.colSex.Name = "colSex";
		this.colSex.Visible = true;
		this.colSex.VisibleIndex = 6;
		this.colSex.Width = 31;
		this.colStudNotes.Caption = "Notes";
		this.colStudNotes.FieldName = "Notes";
		this.colStudNotes.Name = "colStudNotes";
		this.colPicture.Caption = "Picture";
		this.colPicture.FieldName = "Picture";
		this.colPicture.Name = "colPicture";
		this.colBursaryStatus.Caption = "Bursary status";
		this.colBursaryStatus.FieldName = "BursaryStatus";
		this.colBursaryStatus.Name = "colBursaryStatus";
		this.colBursaryProvider.Caption = "Bursary prov";
		this.colBursaryProvider.FieldName = "BursaryProvider";
		this.colBursaryProvider.Name = "colBursaryProvider";
		this.colFees.Caption = "Fees";
		this.colFees.DisplayFormat.FormatString = "{0:#,#.0}";
		this.colFees.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colFees.FieldName = "RequiredFees";
		this.colFees.Name = "colFees";
		this.colFeesBalance.Caption = "Fees Balance";
		this.colFeesBalance.DisplayFormat.FormatString = "{0:#,#.0}";
		this.colFeesBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colFeesBalance.FieldName = "cashOnAccount";
		this.colFeesBalance.Name = "colFeesBalance";
		this.colFormerSchool.Caption = "Former school";
		this.colFormerSchool.FieldName = "FormerSchool";
		this.colFormerSchool.Name = "colFormerSchool";
		this.colAdmitDate.Caption = "Admit date";
		this.colAdmitDate.FieldName = "AdmissionDate";
		this.colAdmitDate.Name = "colAdmitDate";
		this.colHouse.Caption = "House";
		this.colHouse.FieldName = "HouseId";
		this.colHouse.Name = "colHouse";
		this.colHouse.Visible = true;
		this.colHouse.VisibleIndex = 7;
		this.colHouse.Width = 70;
		this.colGuardian.Caption = "Guardian";
		this.colGuardian.FieldName = "Guardian";
		this.colGuardian.Name = "colGuardian";
		this.colReligion.Caption = "Religion";
		this.colReligion.FieldName = "Religion";
		this.colReligion.Name = "colReligion";
		this.colReligion.Width = 211;
		this.colGuardianContact.Caption = "Contact#";
		this.colGuardianContact.FieldName = "PriorityContact";
		this.colGuardianContact.Name = "colGuardianContact";
		this.colGuardianContact.Visible = true;
		this.colGuardianContact.VisibleIndex = 8;
		this.colGuardianContact.Width = 41;
		this.DOB.Caption = "DOB";
		this.DOB.FieldName = "DOB";
		this.DOB.Name = "DOB";
		this.gridColumn2.Caption = "Father's Name";
		this.gridColumn2.FieldName = "fName";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn3.Caption = "Father's Address";
		this.gridColumn3.FieldName = "fAddress";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn4.Caption = "Father's Email";
		this.gridColumn4.FieldName = "fEmail";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn5.Caption = "Father's Contact";
		this.gridColumn5.FieldName = "fContact";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn6.Caption = "Mother's Name";
		this.gridColumn6.FieldName = "mName";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn7.Caption = "Mother's Address";
		this.gridColumn7.FieldName = "mAddress";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn8.Caption = "Mother's Email";
		this.gridColumn8.FieldName = "mEmail";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn1.Caption = "Mother's Contact";
		this.gridColumn1.FieldName = "mContact";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn9.Caption = "OID";
		this.gridColumn9.FieldName = "Oid";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn10.Caption = "gridColumn10";
		this.gridColumn10.FieldName = "Picture";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn11.Caption = "Email";
		this.gridColumn11.FieldName = "Email";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn12.Caption = "Other Contact";
		this.gridColumn12.FieldName = "OtherContact";
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn13.Caption = "Sponsor";
		this.gridColumn13.FieldName = "Sponsor";
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn14.Caption = "SponsorContact";
		this.gridColumn14.FieldName = "SponsorContact";
		this.gridColumn14.Name = "gridColumn14";
		this.gridColumn15.Caption = "GuardianAddress";
		this.gridColumn15.FieldName = "GuardianAddress";
		this.gridColumn15.Name = "gridColumn15";
		this.layoutControl1.Controls.Add(this.gridStudentRecords);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(420, 288, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(946, 517);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
		this.layoutControlGroup1.Size = new System.Drawing.Size(946, 517);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.gridStudentRecords;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(936, 507);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.gridColumn17.Caption = "Combination";
		this.gridColumn17.FieldName = "Comb";
		this.gridColumn17.Name = "gridColumn17";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrStudentListReport";
		base.Size = new System.Drawing.Size(946, 517);
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gv).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
