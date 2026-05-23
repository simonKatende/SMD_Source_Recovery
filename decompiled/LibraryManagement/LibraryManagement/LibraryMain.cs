using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using LibraryManagement.DialogForms;
using LibraryManagement.NavigationForms;
using LibraryManagement.Properties;

namespace LibraryManagement;

public class LibraryMain : RibbonForm
{
	private DataTable libGrids;

	private usrBooks _usrBooks;

	private usrCategories _usrCategories;

	private usrMainDashBoard _usrMainDashBoard;

	private usrLocation _usrLocation;

	private usrReturns _usrReturns;

	private IContainer components = null;

	private RibbonControl ribbon;

	private RibbonPage ribbonPageLib;

	private RibbonStatusBar ribbonStatusBar;

	private RibbonPageGroup ribbonPageGroup28;

	private RibbonPageGroup ribbonPageGroup2;

	private RibbonPageGroup ribbonPageGroup3;

	private RibbonPageGroup ribbonPageGroup4;

	private BarButtonItem btnAddBook;

	private GridControl gridBorrorRecords;

	private GridView gridView6;

	private GroupControl groupControl14;

	private LabelControl labelControl35;

	private LabelControl labelControl32;

	private LabelControl labelControl31;

	private LabelControl labelControl30;

	private TextEdit txtNoOfCopies;

	private DateEdit dtReturnDate;

	private TextEdit txtBookReference;

	private LookUpEdit lookUpBooks;

	private LabelControl labelControl34;

	private ComboBoxEdit comboBoxEdit1;

	private LabelControl labelControl33;

	private DateEdit dtBorrowDate;

	private SimpleButton btnIssueBook;

	private GroupControl groupControl12;

	private PictureEdit pictureEdit1;

	private LookUpEdit lookUpStudent;

	private TextEdit txtReservationStatus;

	public TextEdit txtReservationCode;

	private XtraTabControl xtraTabControl1;

	private XtraTabPage tabOrderDetails;

	private SimpleButton simpleButton3;

	public LabelControl lblNameItem;

	public LabelControl lblCodeItem;

	private SimpleButton btnRemoveItem;

	private SimpleButton btnAddToList;

	private GroupControl groupControl2;

	private GridControl gridItems;

	private GridView gridViewItems;

	private XtraTabControl xtraTabControl4;

	private XtraTabPage tabNewOrders;

	public TextEdit txtSupplierId;

	public TextEdit txtSupplyId;

	private LabelControl labelControl39;

	private LabelControl labelControl41;

	private TextEdit textEdit1;

	private LabelControl labelControl42;

	private LabelControl labelControl43;

	private LabelControl labelControl44;

	private GridControl gridSales;

	private GridView gridViewSales;

	private DateEdit dtOrderDate;

	private LookUpEdit lookUpSupplier;

	private SimpleButton simpleButton30;

	private SimpleButton simpleButton29;

	private XtraTabPage tabStudentAdmission;

	private LabelControl lblGuardianId;

	private LabelControl lblStudyStatus;

	private LabelControl lblBursaryStatus;

	private GroupControl groupControl5;

	private SimpleButton btnFind;

	private SimpleButton btnEditStudent;

	private TextEdit txtStudentNumberSearch;

	private TextEdit txtStudentNameSearch;

	private LabelControl labelControl4;

	private LabelControl labelControl3;

	private PictureEdit picStudent;

	private XtraTabControl xtraTabControl2;

	private XtraTabPage tabStudyInformation;

	private LayoutControl layoutFeesStatus;

	private ComboBoxEdit cboStatus;

	private TextEdit txtRequiredFees;

	private MemoEdit memoEdit1;

	private ComboBoxEdit cboBursaryProvider;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem15;

	private LayoutControlItem layoutControlItem16;

	private LayoutControlItem layoutControlItem36;

	private GroupControl groupControl3;

	private RadioGroup radioGroupStudyStatus;

	private ComboBoxEdit cboStream;

	private LabelControl labelControl2;

	private ComboBoxEdit cboClass;

	private GroupControl groupControl4;

	private RadioGroup radioGroupBursaryStatus;

	private LabelControl labelControl1;

	private LayoutControl layoutPersonData;

	private TextEdit txtGuardianContact;

	private ComboBoxEdit cboReligion;

	private ComboBoxEdit cboHall;

	private ComboBoxEdit cboNationality;

	private TextEdit txtFormerSchool;

	private TextEdit txtAdmissionDate;

	private ComboBoxEdit cboSex;

	private TextEdit txtGurdianAddress;

	private TextEdit txtGuardian;

	private TextEdit txtLastName;

	private TextEdit txtStudentNumber;

	private TextEdit txtFirstName;

	private LayoutControlGroup layout;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem13;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem14;

	private LayoutControlItem layoutControlItem12;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem34;

	private PanelControl panelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private SimpleButton btnUpdate;

	private SimpleButton btnSave;

	private XtraTabPage tabEmployeeAdmission;

	private LayoutControl layoutEmployeeData;

	private ComboBoxEdit cboEmplHouse;

	private CheckEdit chkStatus;

	private TextEdit txtEmplFormerEmployee;

	private TextEdit textEdit22;

	private TextEdit txtEmplAddress;

	private TextEdit txtEmplContactNumber;

	private TextEdit txtEmplFirstName;

	private TextEdit txtStaffNumber;

	private DateEdit dtEmplHireDate;

	private TextEdit txtResponsibility;

	private TextEdit txtQualification;

	private TextEdit txtEmplLastName;

	private ComboBoxEdit cboEmplSex;

	private LayoutControlGroup layoutControlGroup5;

	private LayoutControlItem layoutControlItem23;

	private LayoutControlItem layoutControlItem24;

	private LayoutControlItem layoutControlItem25;

	private LayoutControlItem layoutControlItem26;

	private LayoutControlItem layoutControlItem27;

	private LayoutControlItem layoutControlItem28;

	private LayoutControlItem layoutControlItem29;

	private LayoutControlItem layoutControlItem30;

	private LayoutControlItem layoutControlItem31;

	private LayoutControlItem layoutControlItem32;

	private LayoutControlItem layoutControlItem33;

	private LayoutControlItem layoutControlItem35;

	private LayoutControlItem layoutControlItem93;

	private GroupControl groupControl1;

	private SimpleButton btnFindEmployee;

	private SimpleButton btnEmployEdit;

	private TextEdit txtStaffNumberSearch;

	private TextEdit txtStaffNameSearch;

	private LabelControl labelControl5;

	private LabelControl labelControl6;

	private PictureEdit picStaff;

	private XtraTabControl xtraTabControl3;

	private XtraTabPage tabSalaryInformation;

	private LayoutControl layoutControl1;

	private TextEdit txtUnTaxable;

	private TextEdit txtNSSFAmount;

	private TextEdit txtPAYE;

	private TextEdit txtNetPay;

	private TextEdit txtNSSFRate;

	private TextEdit txtPAYECalc;

	private TextEdit txtEmplSalaryAmount;

	private MemoEdit txtEmplNotes;

	private LayoutControlGroup layoutControlGroup3;

	private LayoutControlItem layoutControlItem18;

	private LayoutControlItem layoutControlItem19;

	private LayoutControlItem layoutControlItem37;

	private LayoutControlItem layoutControlItem40;

	private LayoutControlItem layoutControlItem43;

	private LayoutControlItem layoutControlItem38;

	private LayoutControlItem layoutControlItem39;

	private LayoutControlItem layoutControlItem17;

	private GroupControl groupControl8;

	private LabelControl lblWorkingStatus;

	private RadioGroup radioGroup6;

	private PanelControl panelControl3;

	private SimpleButton btnEmplUpdate;

	private SimpleButton btnEmplAdmit;

	private XtraTabPage tabStudentPayments;

	private GridControl gridStudentPayment;

	private GridView gridViewStudentPayment;

	private LayoutControl layoutStudentPayment;

	private TextEdit txtStudentFees;

	private TextEdit txtStudentBursaryStatus;

	private TextEdit txtStudentStream;

	private TextEdit txtStudentClass;

	private TextEdit txtStudentFirstName;

	private TextEdit txtConfirmStudentNumber;

	private TextEdit txtStudentLastName;

	private TextEdit txtStudentSex;

	private TextEdit txtStudentStudyStatus;

	private TextEdit txtStudentReligion;

	private TextEdit txtStudentHomeCountry;

	private LayoutControlGroup layoutControlGroup7;

	private LayoutControlItem layoutControlItem46;

	private LayoutControlItem layoutControlItem47;

	private LayoutControlItem layoutControlItem48;

	private LayoutControlItem layoutControlItem49;

	private LayoutControlItem layoutControlItem50;

	private LayoutControlItem layoutControlItem51;

	private LayoutControlItem layoutControlItem52;

	private LayoutControlItem layoutControlItem53;

	private LayoutControlItem layoutControlItem54;

	private LayoutControlItem layoutControlItem55;

	private LayoutControlItem layoutControlItem56;

	private GroupControl lblCurrentBank;

	private CheckEdit chkBankCharges;

	private CheckEdit chkPrintReceipt;

	private LabelControl labelControl132;

	private TextEdit txtAmountPaid;

	private LabelControl labelControl131;

	private SimpleButton btnProcessPayment;

	private LabelControl labelControl130;

	private TextEdit txtReceiptNumber;

	private GroupControl groupControl7;

	private LabelControl lblCurrentBankFP;

	private RadioGroup radioGroup4;

	private GroupControl groupControl11;

	private ListBoxControl lbRequirements;

	private CheckEdit chkRememberSem;

	private LabelControl labelControl7;

	private LabelControl labelControl8;

	private ComboBoxEdit cboTermOfStudy;

	private DateEdit dtPayment;

	private LookUpEdit lookUpEdit;

	private PictureEdit picStudentPicture;

	private XtraTabPage tabReports;

	private PanelControl panelControl2;

	private XtraTabPage tabEmployeePayments;

	private GridControl gridEmpSalary;

	private GridView gridViewESalary;

	private LayoutControl layoutControl5;

	private CheckEdit chkPayStatus;

	private TextEdit txtPayEmplType;

	private TextEdit txtPayResponsibility;

	private TextEdit txtPayAddress;

	private TextEdit txtPayTelephone;

	private TextEdit txtPaySurname;

	private TextEdit txtPayEmployeeNo;

	private TextEdit txtPayOtherNames;

	private TextEdit txtPayNSSF;

	private TextEdit txtPayNetPay;

	private TextEdit txtPayBasicPay;

	private TextEdit txtPayPaye;

	private LayoutControlGroup layoutControlGroup9;

	private LayoutControlItem layoutControlItem74;

	private LayoutControlItem layoutControlItem75;

	private LayoutControlItem layoutControlItem76;

	private LayoutControlItem layoutControlItem77;

	private LayoutControlItem layoutControlItem78;

	private LayoutControlItem layoutControlItem79;

	private LayoutControlItem layoutControlItem80;

	private LayoutControlItem layoutControlItem81;

	private LayoutControlItem layoutControlItem82;

	private LayoutControlItem layoutControlItem83;

	private LayoutControlItem layoutControlItem84;

	private LayoutControlItem layoutControlItem85;

	private GroupControl groupControl10;

	private LabelControl labelControl135;

	private SimpleButton btnPaySalary;

	private LabelControl labelControl22;

	private CheckEdit checkEdit4;

	private MemoEdit txtPayNarration;

	private LabelControl labelControl134;

	private LookUpEdit lookUpStaff;

	private LabelControl labelControl133;

	private ComboBoxEdit cboPaySemester;

	private LabelControl labelControl24;

	private ComboBoxEdit cboPayMonth;

	private LabelControl labelControl25;

	private TextEdit txtPayAMount;

	private LabelControl labelControl26;

	private DateEdit dtPayDate;

	private ComboBoxEdit cboPayItem;

	private PictureEdit picStaffPay;

	private XtraTabPage tabSuppliers;

	private PanelControl panelControl15;

	private SimpleButton btnDeleteSupplier;

	private SimpleButton btnNewSupplier;

	private SimpleButton btnSaveSupplier;

	private GridControl gridSuppliers;

	private GridView gridViewSuppliers;

	private XtraTabControl xtraTabControl5;

	private XtraTabPage tabSupplierDetails;

	private LabelControl lblSupplierCode;

	private LabelControl labelControl62;

	private LabelControl labelControl61;

	private LabelControl labelControl60;

	private LabelControl labelControl59;

	private LabelControl labelControl58;

	private LabelControl labelControl57;

	private LabelControl labelControl56;

	private LabelControl labelControl55;

	private LabelControl labelControl54;

	private LabelControl labelControl53;

	private LabelControl labelControl52;

	private LabelControl labelControl51;

	private LabelControl labelControl50;

	private TextEdit txtSupplierSurname;

	private MemoEdit txtSupplierNotes;

	private TextEdit txtSupplierPhone;

	private TextEdit txtSupplierBoxNo;

	private TextEdit txtSupplierFax;

	private TextEdit txtSupplierJobTitle;

	private TextEdit txtSupplierCompany;

	private TextEdit txtSupplierStreet;

	private TextEdit txtSupplierStreet1;

	private TextEdit txtSupplierMobile;

	private TextEdit txtSupplierEmail;

	private TextEdit txtSupplierOthername;

	private TextEdit txtSupplierCity;

	private XtraTabPage tabOrderLists;

	private GroupControl groupControl6;

	private LabelControl labelControl138;

	private MemoEdit txtPaySupplierNarration;

	private ComboBoxEdit cboPaySupplierSemester;

	private LabelControl labelControl137;

	private CheckEdit chkPrintVoucherS;

	private LabelControl labelControl136;

	private LabelControl labelControl46;

	private SimpleButton btnPayBills;

	private TextEdit txtPaySupplierAmount;

	private DateEdit dtPaySupplier;

	private LabelControl labelControl49;

	private MemoEdit txtPaySupplierAddress;

	private LabelControl labelControl48;

	private LabelControl labelControl47;

	private LabelControl labelControl45;

	private TextEdit txtPaySupplierOffice;

	private TextEdit txtPaySupplierMob;

	private TextEdit txtPaySupplierOtherName;

	private TextEdit txtPaySupplierSurname;

	private TextEdit txtPaySupplierName;

	private LabelControl labelControl40;

	private LookUpEdit lookUpSupplierPayment;

	private GridControl gridSupplierLedger;

	private GridView gridViewSL;

	private XtraTabPage tabBudgetCreattion;

	private GroupControl groupControl23;

	private SimpleButton btnAdd;

	private LabelControl labelControl86;

	private TextEdit txtTotal;

	private TextEdit txtYear;

	private LabelControl labelControl85;

	private LabelControl labelControl84;

	private TextEdit txtRate;

	private TextEdit txtQuantity;

	private LabelControl labelControl83;

	private LabelControl labelControl82;

	private LabelControl labelControl81;

	private LabelControl labelControl75;

	private ComboBoxEdit cboUnits;

	private ComboBoxEdit cboItems;

	private ComboBoxEdit cboCategories;

	private ComboBoxEdit cboSemester3;

	private XtraTabPage tabBudgetReports;

	private XtraTabPage tabStudentLists;

	private PanelControl panelControl20;

	private LabelControl lblRequiredFees;

	private LabelControl lblStudentStream;

	private LabelControl lblStudentClass;

	private LabelControl lblSelectionAction;

	private SimpleButton btnChooseStudent;

	private LabelControl lblStudentName;

	private LabelControl lblStudentNumber;

	private SimpleButton simpleButton46;

	private GridControl gridStudentRecords;

	private GridView dgRecords;

	private XtraTabPage tabEmployeeLists;

	private PanelControl panelControl21;

	private SimpleButton btnChooseEmployee;

	private LabelControl lblEmployeeNumber;

	private LabelControl lblEmployeeName;

	private SimpleButton simpleButton49;

	private GridControl dgRecords_emp;

	private GridView gridViewEmployees;

	private XtraTabPage tabReceiveVouchers;

	private PanelControl panelControl16;

	private SimpleButton simpleButton69;

	private SimpleButton simpleButton71;

	private SimpleButton simpleButton70;

	private GridControl gridControl26;

	private GridView gridView26;

	private XtraTabPage tabReceiveVouchersDetails;

	private PanelControl panelControl17;

	private SimpleButton simpleButton77;

	private SimpleButton simpleButton76;

	private SimpleButton simpleButton75;

	private SimpleButton simpleButton74;

	private SimpleButton btnDeleteReceivingVoucher;

	private SimpleButton btnAddReceivingVoucher;

	private SimpleButton btnSearchSupplierVouchers;

	private TextEdit textEdit60;

	private LabelControl labelControl90;

	private DateEdit dateEdit6;

	private LabelControl labelControl91;

	private LabelControl labelControl92;

	private LabelControl labelControl93;

	private TextEdit textEdit61;

	private TextEdit textEdit62;

	private GridControl gridControl27;

	private GridView gridView27;

	private TextEdit textEdit63;

	private TextEdit textEdit64;

	private TextEdit textEdit65;

	private TextEdit textEdit66;

	private TextEdit textEdit67;

	private TextEdit textEdit68;

	private LabelControl labelControl94;

	private LabelControl labelControl95;

	private LabelControl labelControl96;

	private LabelControl labelControl97;

	private LabelControl labelControl98;

	private LabelControl labelControl99;

	private MemoEdit memoEdit8;

	private LabelControl labelControl100;

	private SimpleButton simpleButton73;

	private XtraTabPage tabReturnVouchers;

	private PanelControl panelControl18;

	private SimpleButton simpleButton72;

	private SimpleButton simpleButton79;

	private SimpleButton simpleButton78;

	private GridControl gridControl28;

	private GridView gridView28;

	private XtraTabPage tabReturnVouchersDetails;

	private PanelControl panelControl26;

	private PanelControl panelControl19;

	private SimpleButton simpleButton84;

	private SimpleButton simpleButton83;

	private SimpleButton simpleButton82;

	private SimpleButton simpleButton81;

	private SimpleButton simpleButton5;

	private SimpleButton simpleButton4;

	private TextEdit textEdit6;

	private LabelControl labelControl11;

	private DateEdit dateEdit1;

	private LabelControl labelControl12;

	private LabelControl labelControl13;

	private LabelControl labelControl14;

	private TextEdit textEdit7;

	private TextEdit textEdit8;

	private TextEdit textEdit9;

	private TextEdit textEdit10;

	private TextEdit textEdit11;

	private TextEdit textEdit12;

	private TextEdit textEdit13;

	private TextEdit textEdit26;

	private LabelControl labelControl15;

	private LabelControl labelControl16;

	private LabelControl labelControl17;

	private LabelControl labelControl18;

	private LabelControl labelControl19;

	private LabelControl labelControl20;

	private MemoEdit memoEdit4;

	private LabelControl labelControl21;

	private SimpleButton simpleButton6;

	private SimpleButton simpleButton7;

	private GridControl gridControl7;

	private GridView gridView7;

	private TextEdit textEdit72;

	private TextEdit textEdit73;

	private TextEdit textEdit74;

	private TextEdit textEdit75;

	private TextEdit textEdit76;

	private TextEdit textEdit77;

	private LabelControl labelControl105;

	private LabelControl labelControl106;

	private LabelControl labelControl107;

	private LabelControl labelControl108;

	private LabelControl labelControl109;

	private LabelControl labelControl110;

	private MemoEdit memoEdit9;

	private LabelControl labelControl111;

	private SimpleButton btnReturningOrders;

	private SimpleButton btnDeleteReturningOrder;

	private SimpleButton btnAddReturningOrder;

	private GridControl gridControl29;

	private GridView gridView29;

	private SimpleButton btnSearchReturningOrders;

	private TextEdit textEdit69;

	private LabelControl labelControl101;

	private DateEdit dateEdit7;

	private LabelControl labelControl102;

	private LabelControl labelControl103;

	private LabelControl labelControl104;

	private TextEdit textEdit70;

	private TextEdit textEdit71;

	private XtraTabPage tabInfirmaryDiagnosis;

	private PanelControl panelControl6;

	private CheckEdit checkEdit5;

	private SimpleButton simpleButton10;

	private SimpleButton simpleButton13;

	private XtraTabControl xtraTabControl7;

	private XtraTabPage xtraTabPage3;

	private LayoutControl layoutControl7;

	private MemoEdit txtRecommendation;

	private MemoEdit txtTreatment;

	private MemoEdit txtDiagnosis;

	private LayoutControlGroup layoutControlGroup11;

	private LayoutControlItem layoutControlItem101;

	private LayoutControlItem layoutControlItem102;

	private LayoutControlItem layoutControlItem103;

	private LabelControl labelControl23;

	private ComboBoxEdit cboSemester;

	private LabelControl labelControl27;

	private DateEdit dt2;

	private LayoutControl layoutControl6;

	private TextEdit txtHall;

	private TextEdit txtName;

	private TextEdit txtPersonId;

	private TextEdit txtContact;

	private TextEdit txtStatus;

	private LayoutControlGroup layoutControlGroup10;

	private LayoutControlItem layoutControlItem89;

	private LayoutControlItem layoutControlItem90;

	private LayoutControlItem layoutControlItem91;

	private LayoutControlItem layoutControlItem92;

	private LayoutControlItem layoutControlItem100;

	private PictureEdit picPerson;

	private GroupControl groupControl13;

	private LabelControl labelControl28;

	private ListBoxControl listBoxControl1;

	private TextEdit txtIDNumber;

	private Label label1;

	private RadioGroup radioGroup7;

	private XtraTabPage tabBorrowRecords;

	private PanelControl panelControl8;

	private SimpleButton simpleButton21;

	private SimpleButton simpleButton19;

	private SimpleButton simpleButton20;

	private GridControl gridControl12;

	private GridView gridView12;

	private XtraTabPage xtraTabPage1;

	private XtraTabPage tabStudentRegistrationStandard;

	private SimpleButton simpleButton27;

	private SimpleButton simpleButton26;

	private PanelControl panelControl9;

	private LayoutControl layoutControl9;

	private PanelControl panelControl22;

	private LabelControl lblClass;

	private LabelControl lblClassForRegistration;

	private SimpleButton btnRegisterStudents;

	private SimpleButton btnFindStudent;

	private TextEdit txtStudentNumberRegister;

	private ComboBoxEdit cboClassR;

	private ComboBoxEdit cboTermOfStudyRegister;

	private LayoutControlGroup layoutControlGroup13;

	private LayoutControlItem layoutControlItem110;

	private LayoutControlItem layoutControlItem111;

	private LayoutControlItem layoutControlItem112;

	private LayoutControlItem layoutControlItem113;

	private LayoutControlItem layoutControlItem94;

	private LayoutControlItem layoutControlItem95;

	private GroupControl groupControl17;

	private CheckedListBoxControl chkLstSubjects;

	private CheckEdit chkSelectAll;

	private GroupControl groupControl16;

	private RadioGroup radioGroupMode;

	private GroupControl groupControl15;

	private RadioGroup radioGroupLevelToRegister;

	private XtraTabPage tabStudentRegistrationAdvanced;

	private ComboBoxEdit comboBoxEdit10;

	private ComboBoxEdit comboBoxEdit5;

	private LabelControl labelControl63;

	private LabelControl labelControl38;

	private PanelControl panelControl10;

	private SimpleButton simpleButton33;

	private XtraTabPage tabSelectSubjects;

	private ListBoxControl lbSubjectsSelected;

	private SimpleButton btnAppend;

	private LabelControl lblStatus;

	private SimpleButton simpleButton35;

	private SimpleButton simpleButton34;

	private SimpleButton simpleButton32;

	private SimpleButton simpleButton31;

	private CheckedListBoxControl lbSubjects;

	private GroupControl groupControl18;

	private RadioGroup radioGroupLevel;

	private XtraTabPage tabOLevelGradingScale;

	private XtraTabControl tabMainGradings;

	private XtraTabPage tabGradings1;

	private GridControl dgOLevelGrades;

	private GridView gridViewOLevelGrades;

	private XtraTabPage tabGradings2;

	private GridControl gridOLevelGrading;

	private GridView gridViewOLevelGrading;

	private XtraTabControl tabOLevelScales;

	private XtraTabPage tabGradingScale;

	private LabelControl lblOLevelGSId;

	private LabelControl labelControl123;

	private LabelControl labelControl122;

	private TextEdit txtOLevelComment3;

	private TextEdit txtOLevelComment2;

	private TextEdit txtOLevelComment;

	private LabelControl labelControl71;

	private TextEdit txtGradePoints;

	private LabelControl labelControl70;

	private SimpleButton btnUpdateGradingScale;

	private LabelControl labelControl67;

	private LabelControl labelControl68;

	private LabelControl labelControl69;

	private TextEdit txtGradeEnd;

	private TextEdit txtGradeDebut;

	private TextEdit txtGradeCategory;

	private XtraTabPage tabDivisionScale;

	private LabelControl lblGrade;

	private LabelControl labelControl128;

	private LabelControl labelControl127;

	private LabelControl labelControl126;

	private TextEdit txtHeadTeacherComment;

	private TextEdit txtDOSComment;

	private TextEdit txtClassTeacherComment;

	private SimpleButton btnUpdateGrades;

	private LabelControl labelControl66;

	private LabelControl labelControl65;

	private LabelControl labelControl64;

	private TextEdit txtEnd;

	private TextEdit txtDebut;

	private TextEdit txtCategory;

	private XtraTabPage tabALevelGradingScale;

	private XtraTabControl tabALevelGrading;

	private XtraTabPage tabALevelGradings1;

	private GridControl dgALevelGrades;

	private GridView gridViewALGrades;

	private XtraTabPage tabALevelGrading2;

	private GridControl dgALevelGrades2;

	private GridView gridViewALGrades2;

	private XtraTabControl tabALevelScales;

	private XtraTabPage tabPaperBalancingScale;

	private LabelControl lblGradeIdAA;

	private LabelControl labelControl121;

	private LabelControl labelControl120;

	private LabelControl labelControl119;

	private TextEdit txtALevelComment3;

	private TextEdit txtALevelComment2;

	private TextEdit txtALevelComment;

	private LabelControl labelControl72;

	private TextEdit txtAPoints;

	private LabelControl labelControl73;

	private LabelControl labelControl74;

	private LabelControl labelControl80;

	private TextEdit txtAEnd;

	private TextEdit txtADebut;

	private TextEdit txtACategory;

	private SimpleButton btnUpdateALevelGradingScale;

	private XtraTabPage tabGradingScaleA;

	private LabelControl lblGradeIdAAA;

	private TextEdit txtPointsAA;

	private LabelControl labelControl76;

	private SimpleButton btnUpdateA;

	private LabelControl labelControl77;

	private LabelControl labelControl78;

	private LabelControl labelControl79;

	private TextEdit txtEndAA;

	private TextEdit txtDebutAA;

	private TextEdit txtCategoryAA;

	private XtraTabPage tabPersonalRequirements;

	private GroupControl groupControl27;

	private TextEdit txtStudentStreamAppend;

	private TextEdit txtStudentClassAppend;

	private TextEdit txtStudentNameAppend;

	private LabelControl labelControl129;

	private LabelControl labelControl125;

	private LabelControl labelControl124;

	private SimpleButton simpleButton41;

	private LabelControl labelControl113;

	private TextEdit txtAppendAmount;

	private LabelControl labelControl112;

	private LabelControl labelControl89;

	private LabelControl labelControl88;

	private LabelControl labelControl87;

	private ComboBoxEdit cboAppItem;

	private ComboBoxEdit cboSemesterApp;

	private ComboBoxEdit cboClassAppend;

	private GroupControl groupControl26;

	private CheckedListBoxControl chkCustomList;

	private GroupControl groupControl25;

	private RadioGroup radioGroupAppendTo;

	private GroupControl groupControl24;

	private RadioGroup radioGrCat;

	private LookUpEdit txtStudentNoAppend;

	private XtraTabPage tabEmployeeDebts;

	private GroupControl groupControl28;

	private LabelControl lblEmplResponsibility;

	private LabelControl lblEmplContact;

	private LabelControl lblEmplSex;

	private LabelControl lblEmplName;

	private SimpleButton simpleButton42;

	private LabelControl labelControl114;

	private TextEdit txtAmountAppend;

	private LabelControl labelControl115;

	private LabelControl labelControl116;

	private LabelControl labelControl117;

	private LabelControl labelControl118;

	private ComboBoxEdit cboSemesterAppend;

	private ComboBoxEdit cboMonthAppend;

	private ComboBoxEdit cboItemAppend;

	private GroupControl groupControl29;

	private CheckedListBoxControl chkEmployeeList;

	private GroupControl groupControl30;

	private RadioGroup rdEmployeeItems;

	private GroupControl groupControl31;

	private CheckEdit chkCheckAll;

	private RadioGroup rdAppendTo;

	private LookUpEdit lookUpEmployee;

	private XtraTabPage tabQuickExpenses;

	private PanelControl panelControl11;

	private SimpleButton btnMakeExpenses;

	private GroupControl groupControl32;

	private LayoutControl layoutControl10;

	private CheckEdit checkEdit8;

	private TextEdit txtEAmount;

	private TextEdit txtEQty;

	private TextEdit txtEPayeQuick;

	private MemoEdit txtENarration;

	private ComboBoxEdit cboCategoriesQuick;

	private ComboBoxEdit cboItemsQuick;

	private ComboBoxEdit cboSemesterQuick;

	private ComboBoxEdit cboUnitsQuick;

	private DateEdit dateTimePicker1;

	private LayoutControlGroup layoutControlGroup14;

	private LayoutControlItem layoutControlItem115;

	private LayoutControlItem layoutControlItem116;

	private LayoutControlItem layoutControlItem117;

	private LayoutControlItem layoutControlItem118;

	private LayoutControlItem layoutControlItem119;

	private LayoutControlItem layoutControlItem120;

	private LayoutControlItem layoutControlItem121;

	private LayoutControlItem layoutControlItem122;

	private LayoutControlItem layoutControlItem123;

	private LayoutControlItem layoutControlItem129;

	private XtraTabPage tabQuickIncome;

	private PanelControl panelControl12;

	private SimpleButton btnAddIncome;

	private GroupControl groupControl33;

	private LayoutControl layoutControl11;

	private CheckEdit checkEdit7;

	private TextEdit txtAmountIncome;

	private TextEdit txtCreditor;

	private MemoEdit txtNarrationQuick;

	private ComboBoxEdit cboIncomeSource;

	private ComboBoxEdit cboSemesterIQuick;

	private DateEdit dtDateQuick;

	private LayoutControlGroup layoutControlGroup15;

	private LayoutControlItem layoutControlItem125;

	private LayoutControlItem layoutControlItem126;

	private LayoutControlItem layoutControlItem127;

	private LayoutControlItem layoutControlItem128;

	private LayoutControlItem layoutControlItem131;

	private LayoutControlItem layoutControlItem132;

	private LayoutControlItem layoutControlItem124;

	private XtraTabPage tabProcessOLevel;

	private PanelControl panelControl30;

	private LayoutControl layoutControl12;

	private CheckEdit chkF9InSCI;

	private PanelControl panelControl23;

	private CheckEdit chkOLevel;

	private SimpleButton btnAdvanced;

	private DateEdit dtEnds;

	private DateEdit dtBegins;

	private PanelControl panelControl24;

	private CheckEdit chkMandatory;

	private CheckEdit chkF9InMathematics;

	private CheckEdit chkP7nP8InEnglish;

	private CheckEdit chkF9English;

	private TextEdit txtReportHeader2;

	private ComboBoxEdit cboSemesterProcess;

	private ComboBoxEdit cboClassProcess;

	private LayoutControlGroup layoutControlGroup16;

	private LayoutControlItem layoutControlItem96;

	private LayoutControlItem layoutControlItem97;

	private LayoutControlItem layoutControlItem98;

	private LayoutControlItem layoutControlItem99;

	private LayoutControlItem layoutControlItem114;

	private LayoutControlItem layoutControlItem130;

	private LayoutControlItem layoutControlItem133;

	private LayoutControlItem layoutControlItem134;

	private LayoutControlItem layoutControlItem135;

	private LayoutControlItem layoutControlItem136;

	private LayoutControlItem layoutControlItem137;

	private LayoutControlItem layoutControlItem138;

	private LayoutControlItem layoutControlItem139;

	private LayoutControlItem layoutControlItem152;

	private PanelControl panelControl25;

	private SimpleButton btnProcessOLevelReports;

	private XtraTabPage tabProcessALevel;

	private PanelControl panelControl29;

	private LayoutControl layoutControl13;

	private PanelControl panelControl28;

	private CheckEdit chkALevel;

	private SimpleButton button4;

	private DateEdit dtAEnds;

	private DateEdit dtABegins;

	private TextEdit txtReportHeader;

	private ComboBoxEdit cboALevelSemester;

	private ComboBoxEdit cboALevelClass;

	private LayoutControlGroup layoutControlGroup17;

	private LayoutControlItem layoutControlItem140;

	private LayoutControlItem layoutControlItem141;

	private LayoutControlItem layoutControlItem142;

	private LayoutControlItem layoutControlItem143;

	private LayoutControlItem layoutControlItem144;

	private LayoutControlItem layoutControlItem145;

	private LayoutControlItem layoutControlItem146;

	private LayoutControlItem layoutControlItem147;

	private BarButtonItem btnIssueBooks;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem3;

	private RibbonPageGroup ManagementAndSetup;

	private RibbonPageGroup ribbonPageGroup1;

	private BarButtonItem barButtonItem10;

	private BarButtonItem btnReturnBooks;

	private BarButtonItem btnLibrarycards;

	private BarButtonItem barButtonItem11;

	private LayoutControl layoutControl2;

	private LayoutControlGroup layoutControlGroup1;

	private GroupControl groupControl21;

	private LayoutControlItem layoutControlItem20;

	private PrintPreviewStaticItem printPreviewStaticItem3;

	private BarStaticItem barStaticItem2;

	private RepositoryItemProgressBar repositoryItemProgressBar2;

	private BarButtonItem barButtonItem13;

	private PrintPreviewStaticItem printPreviewStaticItem4;

	private RepositoryItemZoomTrackBar repositoryItemZoomTrackBar2;

	private PanelControl pnlMain;

	private LayoutControlItem layoutControlItem1;

	private BarButtonItem barButtonItem19;

	private BarButtonItem barButtonItem20;

	private BarButtonItem barButtonItem21;

	private BarButtonItem barButtonItem22;

	private BarButtonItem barButtonItem23;

	private BarButtonItem barButtonItem24;

	private BarButtonItem barButtonItem25;

	private RibbonPageCategory ribbonPageCatBooksManage;

	private RibbonPage ribbonPageBooks;

	private RibbonPageGroup ribbonPageGroup6;

	private RibbonPageGroup ribbonPageGroup7;

	private RibbonPageGroup ribbonPageGroup8;

	private BarButtonItem barButtonItem26;

	private BarButtonItem barButtonItem27;

	private BarButtonItem barButtonItem28;

	private BarButtonItem barButtonItem29;

	private RibbonPage ribbonPageIssuesReturns;

	private RibbonPageGroup ribbonPageGroup9;

	private RibbonPageGroup ribbonPageGroup10;

	private RibbonPageGroup ribbonPageGroup11;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem14;

	private BarButtonItem barButtonItem15;

	private BarButtonItem barButtonItem16;

	private BarButtonItem barButtonItem17;

	private BarButtonItem barButtonItem18;

	private BarButtonItem barButtonItem30;

	private BarButtonItem barButtonItem31;

	private BarButtonItem barButtonItem32;

	private BarButtonItem barButtonItem33;

	private BarButtonItem barButtonItem34;

	private BarButtonItem barButtonItem35;

	private RibbonPage ribbonPageCategories;

	private RibbonPageGroup ribbonPageGroup5;

	private RibbonPageGroup ribbonPageGroup12;

	private RibbonPageGroup ribbonPageGroup13;

	private RibbonPageCategory ribbonPageCatLocation;

	private RibbonPage ribbonPageLocations;

	private RibbonPageGroup ribbonPageGroup14;

	private RibbonPageGroup ribbonPageGroup15;

	private RibbonPageGroup ribbonPageGroup16;

	private BarButtonItem barButtonItem6;

	private BarButtonItem barButtonItem36;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem8;

	private BarButtonItem barButtonItem9;

	private BarButtonItem barButtonItem12;

	private RibbonPageGroup ribbonPageGroup17;

	private RibbonPageGroup ribbonPageGroup18;

	private RibbonPageGroup ribbonPageGroup19;

	private RibbonPageGroup ribbonPageGroup20;

	private RibbonPageCategory ribbonPageCatBorrows;

	private RibbonPageCategory ribbonPageCat_CatManage;

	private BarButtonItem barButtonItem37;

	public LibraryMain()
	{
		SplashScreenManager.ShowForm(this, typeof(SplashScreen1), useFadeIn: true, useFadeOut: true, throwExceptionIfAlreadyOpened: false);
		SplashScreenManager.Default.SendCommand(SplashScreen1.SplashScreenCommand.InitializeLibrary, 0);
		Thread.Sleep(25);
		InitializeComponent();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void NavigateHome()
	{
		ribbonPageCatBooksManage.Visible = false;
		ribbonPageCatLocation.Visible = false;
		ribbonPageCatBorrows.Visible = false;
		ribbonPageCat_CatManage.Visible = false;
		ribbon.SelectedPage = ribbonPageLib;
	}

	private void gridViewLibrary_RowClick(object sender, RowClickEventArgs e)
	{
	}

	private void LoadBorrowRecords(string studentNumber)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT b.Category, b.Title,bi.BookRef AS RefNo,bi.Date AS BorrowDate,bi.DueDate,bi.NoOfDays,bi.Status FROM tbl_Books b full outer join tbl_BookIssue bi ON bi.BookRef=b.Ref WHERE bi.StudentNumber='{studentNumber}'";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "borrowRecords");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnAddBook_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void simpleButton8_Click(object sender, EventArgs e)
	{
	}

	private static void LoadLookUp(LookUpEdit lookUpEdit)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT fullName AS Name, StudentNumber AS StudentNo,ClassId AS Class,Picture FROM tbl_Stud", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpEdit.Properties.DataSource = dataTable;
			lookUpEdit.Properties.DisplayMember = "StudentNo";
			lookUpEdit.Properties.ValueMember = "Name";
			LookUpColumnInfoCollection columns = lookUpEdit.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Name", 0));
			columns.Add(new LookUpColumnInfo("StudentNo", 0));
			columns.Add(new LookUpColumnInfo("Class", 0));
			lookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpEdit.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpEdit.Properties.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
	{
	}

	private void LibraryMain_Load(object sender, EventArgs e)
	{
	}

	private void btnIssueBooks_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void LoadLibraryGrids(string cmdText, GridControl gridControl)
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdText, selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "LibGrids");
		libGrids = new DataTable();
		libGrids = dataSet.Tables[0];
		gridControl.DataSource = libGrids.DefaultView;
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		_usrLocation = new usrLocation();
		CurrentControl.LoadControl(_usrLocation, pnlMain);
		ribbonPageCatLocation.Visible = true;
		ribbon.SelectedPage = ribbonPageLocations;
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		_usrCategories = new usrCategories();
		CurrentControl.LoadControl(_usrCategories, pnlMain);
		ribbonPageCat_CatManage.Visible = true;
		ribbon.SelectedPage = ribbonPageCategories;
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void cboBookCategories_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		using AddBooks addBooks = new AddBooks();
		addBooks.Text = "Add New Book";
		addBooks.StartTimer = _usrBooks.BooksCallBackFN;
		addBooks.ShowDialog();
	}

	private void lookUpBooksBorrow_EditValueChanged(object sender, EventArgs e)
	{
	}

	private void btnReturnBooks_ItemClick(object sender, ItemClickEventArgs e)
	{
		using ReturnBooks returnBooks = new ReturnBooks();
		returnBooks.ShowDialog();
	}

	private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
	{
		using PayFine payFine = new PayFine();
		payFine.ShowDialog();
	}

	private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		using libraryManagement libraryManagement2 = new libraryManagement();
		libraryManagement2.ShowDialog();
	}

	private void navBarItem3_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
	}

	private void navBarItem5_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
	}

	private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
	}

	private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
	}

	private void navBarItem9_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
	}

	private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void printPreviewBarItem53_ItemClick(object sender, ItemClickEventArgs e)
	{
		ribbon.SelectedPage = ribbonPageLib;
	}

	private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void tabBookVendors_Paint(object sender, PaintEventArgs e)
	{
	}

	private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
	{
		using AddBooks addBooks = new AddBooks();
		addBooks.Text = "Update Book Info";
		addBooks.StartTimer = _usrBooks.BooksCallBackFN;
		addBooks.ShowDialog();
	}

	private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		_usrBooks = new usrBooks();
		CurrentControl.LoadControl(_usrBooks, pnlMain);
		ribbonPageCatBooksManage.Visible = true;
		ribbon.SelectedPage = ribbonPageBooks;
	}

	private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
	{
		_usrReturns = new usrReturns();
		CurrentControl.LoadControl(_usrReturns, pnlMain);
		ribbonPageCatBorrows.Visible = true;
		ribbon.SelectedPage = ribbonPageIssuesReturns;
	}

	private void barButtonItem15_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		using AddCategory addCategory = new AddCategory();
		addCategory.addMethod = "fullList";
		addCategory.Text = "Add Category";
		addCategory.StartTimer = _usrCategories.CategoryCallBackFN;
		addCategory.ShowDialog();
	}

	private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
	{
		using AddLocations addLocations = new AddLocations();
		addLocations.addMethod = "fullList";
		addLocations.Text = "Add Book Location";
		addLocations.StartTimer = _usrLocation.LocationCallBackFN;
		addLocations.ShowDialog();
	}

	private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem18_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void ribbon_SelectedPageChanged(object sender, EventArgs e)
	{
		EditableFields.SetEditableFieldValues(-99999L, "Nothing_Selected");
		if (ribbon.SelectedPage == ribbonPageLib)
		{
			NavigateHome();
			_usrMainDashBoard = new usrMainDashBoard();
			CurrentControl.LoadControl(_usrMainDashBoard, pnlMain);
		}
	}

	private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
	{
		PrintableControl.PrintableGridControl.ShowPrintPreview();
	}

	private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
	{
		PrintableControl.PrintableGridControl.PrintDialog();
	}

	private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
	{
		using BooksImport booksImport = new BooksImport();
		booksImport.StartTimer = _usrBooks.BooksCallBackFN;
		booksImport.ShowDialog();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryManagement.LibraryMain));
		this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.btnAddBook = new DevExpress.XtraBars.BarButtonItem();
		this.btnIssueBooks = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.btnReturnBooks = new DevExpress.XtraBars.BarButtonItem();
		this.btnLibrarycards = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
		this.printPreviewStaticItem3 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
		this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
		this.printPreviewStaticItem4 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
		this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem21 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem24 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem26 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem28 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem29 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem30 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem31 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem32 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem33 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem34 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem35 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem36 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem37 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageCatBooksManage = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
		this.ribbonPageBooks = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageCatLocation = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
		this.ribbonPageLocations = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageCatBorrows = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
		this.ribbonPageIssuesReturns = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup20 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageCat_CatManage = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
		this.ribbonPageCategories = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup19 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageLib = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ManagementAndSetup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
		this.repositoryItemZoomTrackBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
		this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
		this.ribbonPageGroup28 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.gridBorrorRecords = new DevExpress.XtraGrid.GridControl();
		this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.groupControl14 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl32 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
		this.txtNoOfCopies = new DevExpress.XtraEditors.TextEdit();
		this.dtReturnDate = new DevExpress.XtraEditors.DateEdit();
		this.txtBookReference = new DevExpress.XtraEditors.TextEdit();
		this.lookUpBooks = new DevExpress.XtraEditors.LookUpEdit();
		this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
		this.dtBorrowDate = new DevExpress.XtraEditors.DateEdit();
		this.btnIssueBook = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl12 = new DevExpress.XtraEditors.GroupControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.lookUpStudent = new DevExpress.XtraEditors.LookUpEdit();
		this.txtReservationStatus = new DevExpress.XtraEditors.TextEdit();
		this.txtReservationCode = new DevExpress.XtraEditors.TextEdit();
		this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
		this.tabOrderDetails = new DevExpress.XtraTab.XtraTabPage();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.lblNameItem = new DevExpress.XtraEditors.LabelControl();
		this.lblCodeItem = new DevExpress.XtraEditors.LabelControl();
		this.btnRemoveItem = new DevExpress.XtraEditors.SimpleButton();
		this.btnAddToList = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
		this.gridItems = new DevExpress.XtraGrid.GridControl();
		this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.xtraTabControl4 = new DevExpress.XtraTab.XtraTabControl();
		this.tabNewOrders = new DevExpress.XtraTab.XtraTabPage();
		this.txtSupplierId = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplyId = new DevExpress.XtraEditors.TextEdit();
		this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl41 = new DevExpress.XtraEditors.LabelControl();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl43 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl44 = new DevExpress.XtraEditors.LabelControl();
		this.gridSales = new DevExpress.XtraGrid.GridControl();
		this.gridViewSales = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.dtOrderDate = new DevExpress.XtraEditors.DateEdit();
		this.lookUpSupplier = new DevExpress.XtraEditors.LookUpEdit();
		this.simpleButton30 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton29 = new DevExpress.XtraEditors.SimpleButton();
		this.tabStudentAdmission = new DevExpress.XtraTab.XtraTabPage();
		this.lblGuardianId = new DevExpress.XtraEditors.LabelControl();
		this.lblStudyStatus = new DevExpress.XtraEditors.LabelControl();
		this.lblBursaryStatus = new DevExpress.XtraEditors.LabelControl();
		this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
		this.btnFind = new DevExpress.XtraEditors.SimpleButton();
		this.btnEditStudent = new DevExpress.XtraEditors.SimpleButton();
		this.txtStudentNumberSearch = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentNameSearch = new DevExpress.XtraEditors.TextEdit();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.picStudent = new DevExpress.XtraEditors.PictureEdit();
		this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
		this.tabStudyInformation = new DevExpress.XtraTab.XtraTabPage();
		this.layoutFeesStatus = new DevExpress.XtraLayout.LayoutControl();
		this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtRequiredFees = new DevExpress.XtraEditors.TextEdit();
		this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
		this.cboBursaryProvider = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
		this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupStudyStatus = new DevExpress.XtraEditors.RadioGroup();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupBursaryStatus = new DevExpress.XtraEditors.RadioGroup();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutPersonData = new DevExpress.XtraLayout.LayoutControl();
		this.txtGuardianContact = new DevExpress.XtraEditors.TextEdit();
		this.cboReligion = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboHall = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboNationality = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtFormerSchool = new DevExpress.XtraEditors.TextEdit();
		this.txtAdmissionDate = new DevExpress.XtraEditors.TextEdit();
		this.cboSex = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtGurdianAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtGuardian = new DevExpress.XtraEditors.TextEdit();
		this.txtLastName = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentNumber = new DevExpress.XtraEditors.TextEdit();
		this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
		this.layout = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
		this.btnSave = new DevExpress.XtraEditors.SimpleButton();
		this.tabEmployeeAdmission = new DevExpress.XtraTab.XtraTabPage();
		this.layoutEmployeeData = new DevExpress.XtraLayout.LayoutControl();
		this.cboEmplHouse = new DevExpress.XtraEditors.ComboBoxEdit();
		this.chkStatus = new DevExpress.XtraEditors.CheckEdit();
		this.txtEmplFormerEmployee = new DevExpress.XtraEditors.TextEdit();
		this.textEdit22 = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplContactNumber = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplFirstName = new DevExpress.XtraEditors.TextEdit();
		this.txtStaffNumber = new DevExpress.XtraEditors.TextEdit();
		this.dtEmplHireDate = new DevExpress.XtraEditors.DateEdit();
		this.txtResponsibility = new DevExpress.XtraEditors.TextEdit();
		this.txtQualification = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplLastName = new DevExpress.XtraEditors.TextEdit();
		this.cboEmplSex = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem93 = new DevExpress.XtraLayout.LayoutControlItem();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.btnFindEmployee = new DevExpress.XtraEditors.SimpleButton();
		this.btnEmployEdit = new DevExpress.XtraEditors.SimpleButton();
		this.txtStaffNumberSearch = new DevExpress.XtraEditors.TextEdit();
		this.txtStaffNameSearch = new DevExpress.XtraEditors.TextEdit();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.picStaff = new DevExpress.XtraEditors.PictureEdit();
		this.xtraTabControl3 = new DevExpress.XtraTab.XtraTabControl();
		this.tabSalaryInformation = new DevExpress.XtraTab.XtraTabPage();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtUnTaxable = new DevExpress.XtraEditors.TextEdit();
		this.txtNSSFAmount = new DevExpress.XtraEditors.TextEdit();
		this.txtPAYE = new DevExpress.XtraEditors.TextEdit();
		this.txtNetPay = new DevExpress.XtraEditors.TextEdit();
		this.txtNSSFRate = new DevExpress.XtraEditors.TextEdit();
		this.txtPAYECalc = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplSalaryAmount = new DevExpress.XtraEditors.TextEdit();
		this.txtEmplNotes = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
		this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
		this.lblWorkingStatus = new DevExpress.XtraEditors.LabelControl();
		this.radioGroup6 = new DevExpress.XtraEditors.RadioGroup();
		this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
		this.btnEmplUpdate = new DevExpress.XtraEditors.SimpleButton();
		this.btnEmplAdmit = new DevExpress.XtraEditors.SimpleButton();
		this.tabStudentPayments = new DevExpress.XtraTab.XtraTabPage();
		this.gridStudentPayment = new DevExpress.XtraGrid.GridControl();
		this.gridViewStudentPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutStudentPayment = new DevExpress.XtraLayout.LayoutControl();
		this.txtStudentFees = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentBursaryStatus = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentStream = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentClass = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentFirstName = new DevExpress.XtraEditors.TextEdit();
		this.txtConfirmStudentNumber = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentLastName = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentSex = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentStudyStatus = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentReligion = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentHomeCountry = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
		this.lblCurrentBank = new DevExpress.XtraEditors.GroupControl();
		this.chkBankCharges = new DevExpress.XtraEditors.CheckEdit();
		this.chkPrintReceipt = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl132 = new DevExpress.XtraEditors.LabelControl();
		this.txtAmountPaid = new DevExpress.XtraEditors.TextEdit();
		this.labelControl131 = new DevExpress.XtraEditors.LabelControl();
		this.btnProcessPayment = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl130 = new DevExpress.XtraEditors.LabelControl();
		this.txtReceiptNumber = new DevExpress.XtraEditors.TextEdit();
		this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
		this.lblCurrentBankFP = new DevExpress.XtraEditors.LabelControl();
		this.radioGroup4 = new DevExpress.XtraEditors.RadioGroup();
		this.groupControl11 = new DevExpress.XtraEditors.GroupControl();
		this.lbRequirements = new DevExpress.XtraEditors.ListBoxControl();
		this.chkRememberSem = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
		this.cboTermOfStudy = new DevExpress.XtraEditors.ComboBoxEdit();
		this.dtPayment = new DevExpress.XtraEditors.DateEdit();
		this.lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
		this.picStudentPicture = new DevExpress.XtraEditors.PictureEdit();
		this.tabReports = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
		this.tabEmployeePayments = new DevExpress.XtraTab.XtraTabPage();
		this.gridEmpSalary = new DevExpress.XtraGrid.GridControl();
		this.gridViewESalary = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControl5 = new DevExpress.XtraLayout.LayoutControl();
		this.chkPayStatus = new DevExpress.XtraEditors.CheckEdit();
		this.txtPayEmplType = new DevExpress.XtraEditors.TextEdit();
		this.txtPayResponsibility = new DevExpress.XtraEditors.TextEdit();
		this.txtPayAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtPayTelephone = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySurname = new DevExpress.XtraEditors.TextEdit();
		this.txtPayEmployeeNo = new DevExpress.XtraEditors.TextEdit();
		this.txtPayOtherNames = new DevExpress.XtraEditors.TextEdit();
		this.txtPayNSSF = new DevExpress.XtraEditors.TextEdit();
		this.txtPayNetPay = new DevExpress.XtraEditors.TextEdit();
		this.txtPayBasicPay = new DevExpress.XtraEditors.TextEdit();
		this.txtPayPaye = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem74 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem75 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem76 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem78 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem79 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem80 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem81 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem82 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem83 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem84 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem85 = new DevExpress.XtraLayout.LayoutControlItem();
		this.groupControl10 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl135 = new DevExpress.XtraEditors.LabelControl();
		this.btnPaySalary = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
		this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
		this.txtPayNarration = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl134 = new DevExpress.XtraEditors.LabelControl();
		this.lookUpStaff = new DevExpress.XtraEditors.LookUpEdit();
		this.labelControl133 = new DevExpress.XtraEditors.LabelControl();
		this.cboPaySemester = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
		this.cboPayMonth = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
		this.txtPayAMount = new DevExpress.XtraEditors.TextEdit();
		this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
		this.dtPayDate = new DevExpress.XtraEditors.DateEdit();
		this.cboPayItem = new DevExpress.XtraEditors.ComboBoxEdit();
		this.picStaffPay = new DevExpress.XtraEditors.PictureEdit();
		this.tabSuppliers = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl15 = new DevExpress.XtraEditors.PanelControl();
		this.btnDeleteSupplier = new DevExpress.XtraEditors.SimpleButton();
		this.btnNewSupplier = new DevExpress.XtraEditors.SimpleButton();
		this.btnSaveSupplier = new DevExpress.XtraEditors.SimpleButton();
		this.gridSuppliers = new DevExpress.XtraGrid.GridControl();
		this.gridViewSuppliers = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.xtraTabControl5 = new DevExpress.XtraTab.XtraTabControl();
		this.tabSupplierDetails = new DevExpress.XtraTab.XtraTabPage();
		this.lblSupplierCode = new DevExpress.XtraEditors.LabelControl();
		this.labelControl62 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl61 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl60 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl59 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl58 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl57 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl56 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl55 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl54 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl52 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl51 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl50 = new DevExpress.XtraEditors.LabelControl();
		this.txtSupplierSurname = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierNotes = new DevExpress.XtraEditors.MemoEdit();
		this.txtSupplierPhone = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierBoxNo = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierFax = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierJobTitle = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierCompany = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierStreet = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierStreet1 = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierMobile = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierEmail = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierOthername = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierCity = new DevExpress.XtraEditors.TextEdit();
		this.tabOrderLists = new DevExpress.XtraTab.XtraTabPage();
		this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl138 = new DevExpress.XtraEditors.LabelControl();
		this.txtPaySupplierNarration = new DevExpress.XtraEditors.MemoEdit();
		this.cboPaySupplierSemester = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl137 = new DevExpress.XtraEditors.LabelControl();
		this.chkPrintVoucherS = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl136 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl46 = new DevExpress.XtraEditors.LabelControl();
		this.btnPayBills = new DevExpress.XtraEditors.SimpleButton();
		this.txtPaySupplierAmount = new DevExpress.XtraEditors.TextEdit();
		this.dtPaySupplier = new DevExpress.XtraEditors.DateEdit();
		this.labelControl49 = new DevExpress.XtraEditors.LabelControl();
		this.txtPaySupplierAddress = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl48 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl47 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl45 = new DevExpress.XtraEditors.LabelControl();
		this.txtPaySupplierOffice = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierMob = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierOtherName = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierSurname = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierName = new DevExpress.XtraEditors.TextEdit();
		this.labelControl40 = new DevExpress.XtraEditors.LabelControl();
		this.lookUpSupplierPayment = new DevExpress.XtraEditors.LookUpEdit();
		this.gridSupplierLedger = new DevExpress.XtraGrid.GridControl();
		this.gridViewSL = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabBudgetCreattion = new DevExpress.XtraTab.XtraTabPage();
		this.groupControl23 = new DevExpress.XtraEditors.GroupControl();
		this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl86 = new DevExpress.XtraEditors.LabelControl();
		this.txtTotal = new DevExpress.XtraEditors.TextEdit();
		this.txtYear = new DevExpress.XtraEditors.TextEdit();
		this.labelControl85 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl84 = new DevExpress.XtraEditors.LabelControl();
		this.txtRate = new DevExpress.XtraEditors.TextEdit();
		this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
		this.labelControl83 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl82 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl81 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl75 = new DevExpress.XtraEditors.LabelControl();
		this.cboUnits = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboItems = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboCategories = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSemester3 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.tabBudgetReports = new DevExpress.XtraTab.XtraTabPage();
		this.tabStudentLists = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl20 = new DevExpress.XtraEditors.PanelControl();
		this.lblRequiredFees = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentStream = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentClass = new DevExpress.XtraEditors.LabelControl();
		this.lblSelectionAction = new DevExpress.XtraEditors.LabelControl();
		this.btnChooseStudent = new DevExpress.XtraEditors.SimpleButton();
		this.lblStudentName = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentNumber = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton46 = new DevExpress.XtraEditors.SimpleButton();
		this.gridStudentRecords = new DevExpress.XtraGrid.GridControl();
		this.dgRecords = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabEmployeeLists = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl21 = new DevExpress.XtraEditors.PanelControl();
		this.btnChooseEmployee = new DevExpress.XtraEditors.SimpleButton();
		this.lblEmployeeNumber = new DevExpress.XtraEditors.LabelControl();
		this.lblEmployeeName = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton49 = new DevExpress.XtraEditors.SimpleButton();
		this.dgRecords_emp = new DevExpress.XtraGrid.GridControl();
		this.gridViewEmployees = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabReceiveVouchers = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl16 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton69 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton71 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton70 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl26 = new DevExpress.XtraGrid.GridControl();
		this.gridView26 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabReceiveVouchersDetails = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl17 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton77 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton76 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton75 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton74 = new DevExpress.XtraEditors.SimpleButton();
		this.btnDeleteReceivingVoucher = new DevExpress.XtraEditors.SimpleButton();
		this.btnAddReceivingVoucher = new DevExpress.XtraEditors.SimpleButton();
		this.btnSearchSupplierVouchers = new DevExpress.XtraEditors.SimpleButton();
		this.textEdit60 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl90 = new DevExpress.XtraEditors.LabelControl();
		this.dateEdit6 = new DevExpress.XtraEditors.DateEdit();
		this.labelControl91 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl92 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl93 = new DevExpress.XtraEditors.LabelControl();
		this.textEdit61 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit62 = new DevExpress.XtraEditors.TextEdit();
		this.gridControl27 = new DevExpress.XtraGrid.GridControl();
		this.gridView27 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.textEdit63 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit64 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit65 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit66 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit67 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit68 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl94 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl95 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl96 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl97 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl98 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl99 = new DevExpress.XtraEditors.LabelControl();
		this.memoEdit8 = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl100 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton73 = new DevExpress.XtraEditors.SimpleButton();
		this.tabReturnVouchers = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl18 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton72 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton79 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton78 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl28 = new DevExpress.XtraGrid.GridControl();
		this.gridView28 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabReturnVouchersDetails = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl26 = new DevExpress.XtraEditors.PanelControl();
		this.panelControl19 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton84 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton83 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton82 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton81 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
		this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
		this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
		this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit8 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit9 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit10 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit11 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit12 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit13 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit26 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
		this.memoEdit4 = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl7 = new DevExpress.XtraGrid.GridControl();
		this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.textEdit72 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit73 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit74 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit75 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit76 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit77 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl105 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl106 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl107 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl108 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl109 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl110 = new DevExpress.XtraEditors.LabelControl();
		this.memoEdit9 = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl111 = new DevExpress.XtraEditors.LabelControl();
		this.btnReturningOrders = new DevExpress.XtraEditors.SimpleButton();
		this.btnDeleteReturningOrder = new DevExpress.XtraEditors.SimpleButton();
		this.btnAddReturningOrder = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl29 = new DevExpress.XtraGrid.GridControl();
		this.gridView29 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.btnSearchReturningOrders = new DevExpress.XtraEditors.SimpleButton();
		this.textEdit69 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl101 = new DevExpress.XtraEditors.LabelControl();
		this.dateEdit7 = new DevExpress.XtraEditors.DateEdit();
		this.labelControl102 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl103 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl104 = new DevExpress.XtraEditors.LabelControl();
		this.textEdit70 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit71 = new DevExpress.XtraEditors.TextEdit();
		this.tabInfirmaryDiagnosis = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
		this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
		this.simpleButton10 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton13 = new DevExpress.XtraEditors.SimpleButton();
		this.xtraTabControl7 = new DevExpress.XtraTab.XtraTabControl();
		this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
		this.layoutControl7 = new DevExpress.XtraLayout.LayoutControl();
		this.txtRecommendation = new DevExpress.XtraEditors.MemoEdit();
		this.txtTreatment = new DevExpress.XtraEditors.MemoEdit();
		this.txtDiagnosis = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem101 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem102 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem103 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
		this.cboSemester = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
		this.dt2 = new DevExpress.XtraEditors.DateEdit();
		this.layoutControl6 = new DevExpress.XtraLayout.LayoutControl();
		this.txtHall = new DevExpress.XtraEditors.TextEdit();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.txtPersonId = new DevExpress.XtraEditors.TextEdit();
		this.txtContact = new DevExpress.XtraEditors.TextEdit();
		this.txtStatus = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem89 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem90 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem91 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem92 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem100 = new DevExpress.XtraLayout.LayoutControlItem();
		this.picPerson = new DevExpress.XtraEditors.PictureEdit();
		this.groupControl13 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
		this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
		this.txtIDNumber = new DevExpress.XtraEditors.TextEdit();
		this.label1 = new System.Windows.Forms.Label();
		this.radioGroup7 = new DevExpress.XtraEditors.RadioGroup();
		this.tabBorrowRecords = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl8 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton21 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton19 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton20 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl12 = new DevExpress.XtraGrid.GridControl();
		this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
		this.tabStudentRegistrationStandard = new DevExpress.XtraTab.XtraTabPage();
		this.simpleButton27 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton26 = new DevExpress.XtraEditors.SimpleButton();
		this.panelControl9 = new DevExpress.XtraEditors.PanelControl();
		this.layoutControl9 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl22 = new DevExpress.XtraEditors.PanelControl();
		this.lblClass = new DevExpress.XtraEditors.LabelControl();
		this.lblClassForRegistration = new DevExpress.XtraEditors.LabelControl();
		this.btnRegisterStudents = new DevExpress.XtraEditors.SimpleButton();
		this.btnFindStudent = new DevExpress.XtraEditors.SimpleButton();
		this.txtStudentNumberRegister = new DevExpress.XtraEditors.TextEdit();
		this.cboClassR = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboTermOfStudyRegister = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem110 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem111 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem112 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem113 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem94 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem95 = new DevExpress.XtraLayout.LayoutControlItem();
		this.groupControl17 = new DevExpress.XtraEditors.GroupControl();
		this.chkLstSubjects = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
		this.groupControl16 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupMode = new DevExpress.XtraEditors.RadioGroup();
		this.groupControl15 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupLevelToRegister = new DevExpress.XtraEditors.RadioGroup();
		this.tabStudentRegistrationAdvanced = new DevExpress.XtraTab.XtraTabPage();
		this.comboBoxEdit10 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.comboBoxEdit5 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl63 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
		this.panelControl10 = new DevExpress.XtraEditors.PanelControl();
		this.simpleButton33 = new DevExpress.XtraEditors.SimpleButton();
		this.tabSelectSubjects = new DevExpress.XtraTab.XtraTabPage();
		this.lbSubjectsSelected = new DevExpress.XtraEditors.ListBoxControl();
		this.btnAppend = new DevExpress.XtraEditors.SimpleButton();
		this.lblStatus = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton35 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton34 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton32 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton31 = new DevExpress.XtraEditors.SimpleButton();
		this.lbSubjects = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.groupControl18 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupLevel = new DevExpress.XtraEditors.RadioGroup();
		this.tabOLevelGradingScale = new DevExpress.XtraTab.XtraTabPage();
		this.tabMainGradings = new DevExpress.XtraTab.XtraTabControl();
		this.tabGradings1 = new DevExpress.XtraTab.XtraTabPage();
		this.dgOLevelGrades = new DevExpress.XtraGrid.GridControl();
		this.gridViewOLevelGrades = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabGradings2 = new DevExpress.XtraTab.XtraTabPage();
		this.gridOLevelGrading = new DevExpress.XtraGrid.GridControl();
		this.gridViewOLevelGrading = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabOLevelScales = new DevExpress.XtraTab.XtraTabControl();
		this.tabGradingScale = new DevExpress.XtraTab.XtraTabPage();
		this.lblOLevelGSId = new DevExpress.XtraEditors.LabelControl();
		this.labelControl123 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl122 = new DevExpress.XtraEditors.LabelControl();
		this.txtOLevelComment3 = new DevExpress.XtraEditors.TextEdit();
		this.txtOLevelComment2 = new DevExpress.XtraEditors.TextEdit();
		this.txtOLevelComment = new DevExpress.XtraEditors.TextEdit();
		this.labelControl71 = new DevExpress.XtraEditors.LabelControl();
		this.txtGradePoints = new DevExpress.XtraEditors.TextEdit();
		this.labelControl70 = new DevExpress.XtraEditors.LabelControl();
		this.btnUpdateGradingScale = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl67 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl68 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl69 = new DevExpress.XtraEditors.LabelControl();
		this.txtGradeEnd = new DevExpress.XtraEditors.TextEdit();
		this.txtGradeDebut = new DevExpress.XtraEditors.TextEdit();
		this.txtGradeCategory = new DevExpress.XtraEditors.TextEdit();
		this.tabDivisionScale = new DevExpress.XtraTab.XtraTabPage();
		this.lblGrade = new DevExpress.XtraEditors.LabelControl();
		this.labelControl128 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl127 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl126 = new DevExpress.XtraEditors.LabelControl();
		this.txtHeadTeacherComment = new DevExpress.XtraEditors.TextEdit();
		this.txtDOSComment = new DevExpress.XtraEditors.TextEdit();
		this.txtClassTeacherComment = new DevExpress.XtraEditors.TextEdit();
		this.btnUpdateGrades = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl66 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl65 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl64 = new DevExpress.XtraEditors.LabelControl();
		this.txtEnd = new DevExpress.XtraEditors.TextEdit();
		this.txtDebut = new DevExpress.XtraEditors.TextEdit();
		this.txtCategory = new DevExpress.XtraEditors.TextEdit();
		this.tabALevelGradingScale = new DevExpress.XtraTab.XtraTabPage();
		this.tabALevelGrading = new DevExpress.XtraTab.XtraTabControl();
		this.tabALevelGradings1 = new DevExpress.XtraTab.XtraTabPage();
		this.dgALevelGrades = new DevExpress.XtraGrid.GridControl();
		this.gridViewALGrades = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabALevelGrading2 = new DevExpress.XtraTab.XtraTabPage();
		this.dgALevelGrades2 = new DevExpress.XtraGrid.GridControl();
		this.gridViewALGrades2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tabALevelScales = new DevExpress.XtraTab.XtraTabControl();
		this.tabPaperBalancingScale = new DevExpress.XtraTab.XtraTabPage();
		this.lblGradeIdAA = new DevExpress.XtraEditors.LabelControl();
		this.labelControl121 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl120 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl119 = new DevExpress.XtraEditors.LabelControl();
		this.txtALevelComment3 = new DevExpress.XtraEditors.TextEdit();
		this.txtALevelComment2 = new DevExpress.XtraEditors.TextEdit();
		this.txtALevelComment = new DevExpress.XtraEditors.TextEdit();
		this.labelControl72 = new DevExpress.XtraEditors.LabelControl();
		this.txtAPoints = new DevExpress.XtraEditors.TextEdit();
		this.labelControl73 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl74 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl80 = new DevExpress.XtraEditors.LabelControl();
		this.txtAEnd = new DevExpress.XtraEditors.TextEdit();
		this.txtADebut = new DevExpress.XtraEditors.TextEdit();
		this.txtACategory = new DevExpress.XtraEditors.TextEdit();
		this.btnUpdateALevelGradingScale = new DevExpress.XtraEditors.SimpleButton();
		this.tabGradingScaleA = new DevExpress.XtraTab.XtraTabPage();
		this.lblGradeIdAAA = new DevExpress.XtraEditors.LabelControl();
		this.txtPointsAA = new DevExpress.XtraEditors.TextEdit();
		this.labelControl76 = new DevExpress.XtraEditors.LabelControl();
		this.btnUpdateA = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl77 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl78 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl79 = new DevExpress.XtraEditors.LabelControl();
		this.txtEndAA = new DevExpress.XtraEditors.TextEdit();
		this.txtDebutAA = new DevExpress.XtraEditors.TextEdit();
		this.txtCategoryAA = new DevExpress.XtraEditors.TextEdit();
		this.tabPersonalRequirements = new DevExpress.XtraTab.XtraTabPage();
		this.groupControl27 = new DevExpress.XtraEditors.GroupControl();
		this.txtStudentStreamAppend = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentClassAppend = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentNameAppend = new DevExpress.XtraEditors.TextEdit();
		this.labelControl129 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl125 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl124 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton41 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl113 = new DevExpress.XtraEditors.LabelControl();
		this.txtAppendAmount = new DevExpress.XtraEditors.TextEdit();
		this.labelControl112 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl89 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl88 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl87 = new DevExpress.XtraEditors.LabelControl();
		this.cboAppItem = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSemesterApp = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboClassAppend = new DevExpress.XtraEditors.ComboBoxEdit();
		this.groupControl26 = new DevExpress.XtraEditors.GroupControl();
		this.chkCustomList = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.groupControl25 = new DevExpress.XtraEditors.GroupControl();
		this.radioGroupAppendTo = new DevExpress.XtraEditors.RadioGroup();
		this.groupControl24 = new DevExpress.XtraEditors.GroupControl();
		this.radioGrCat = new DevExpress.XtraEditors.RadioGroup();
		this.txtStudentNoAppend = new DevExpress.XtraEditors.LookUpEdit();
		this.tabEmployeeDebts = new DevExpress.XtraTab.XtraTabPage();
		this.groupControl28 = new DevExpress.XtraEditors.GroupControl();
		this.lblEmplResponsibility = new DevExpress.XtraEditors.LabelControl();
		this.lblEmplContact = new DevExpress.XtraEditors.LabelControl();
		this.lblEmplSex = new DevExpress.XtraEditors.LabelControl();
		this.lblEmplName = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton42 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl114 = new DevExpress.XtraEditors.LabelControl();
		this.txtAmountAppend = new DevExpress.XtraEditors.TextEdit();
		this.labelControl115 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl116 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl117 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl118 = new DevExpress.XtraEditors.LabelControl();
		this.cboSemesterAppend = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboMonthAppend = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboItemAppend = new DevExpress.XtraEditors.ComboBoxEdit();
		this.groupControl29 = new DevExpress.XtraEditors.GroupControl();
		this.chkEmployeeList = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.groupControl30 = new DevExpress.XtraEditors.GroupControl();
		this.rdEmployeeItems = new DevExpress.XtraEditors.RadioGroup();
		this.groupControl31 = new DevExpress.XtraEditors.GroupControl();
		this.chkCheckAll = new DevExpress.XtraEditors.CheckEdit();
		this.rdAppendTo = new DevExpress.XtraEditors.RadioGroup();
		this.lookUpEmployee = new DevExpress.XtraEditors.LookUpEdit();
		this.tabQuickExpenses = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl11 = new DevExpress.XtraEditors.PanelControl();
		this.btnMakeExpenses = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl32 = new DevExpress.XtraEditors.GroupControl();
		this.layoutControl10 = new DevExpress.XtraLayout.LayoutControl();
		this.checkEdit8 = new DevExpress.XtraEditors.CheckEdit();
		this.txtEAmount = new DevExpress.XtraEditors.TextEdit();
		this.txtEQty = new DevExpress.XtraEditors.TextEdit();
		this.txtEPayeQuick = new DevExpress.XtraEditors.TextEdit();
		this.txtENarration = new DevExpress.XtraEditors.MemoEdit();
		this.cboCategoriesQuick = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboItemsQuick = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSemesterQuick = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboUnitsQuick = new DevExpress.XtraEditors.ComboBoxEdit();
		this.dateTimePicker1 = new DevExpress.XtraEditors.DateEdit();
		this.layoutControlGroup14 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem115 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem116 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem117 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem118 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem119 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem120 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem121 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem122 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem123 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem129 = new DevExpress.XtraLayout.LayoutControlItem();
		this.tabQuickIncome = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl12 = new DevExpress.XtraEditors.PanelControl();
		this.btnAddIncome = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl33 = new DevExpress.XtraEditors.GroupControl();
		this.layoutControl11 = new DevExpress.XtraLayout.LayoutControl();
		this.checkEdit7 = new DevExpress.XtraEditors.CheckEdit();
		this.txtAmountIncome = new DevExpress.XtraEditors.TextEdit();
		this.txtCreditor = new DevExpress.XtraEditors.TextEdit();
		this.txtNarrationQuick = new DevExpress.XtraEditors.MemoEdit();
		this.cboIncomeSource = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSemesterIQuick = new DevExpress.XtraEditors.ComboBoxEdit();
		this.dtDateQuick = new DevExpress.XtraEditors.DateEdit();
		this.layoutControlGroup15 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem125 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem126 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem127 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem128 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem131 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem132 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem124 = new DevExpress.XtraLayout.LayoutControlItem();
		this.tabProcessOLevel = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl30 = new DevExpress.XtraEditors.PanelControl();
		this.layoutControl12 = new DevExpress.XtraLayout.LayoutControl();
		this.chkF9InSCI = new DevExpress.XtraEditors.CheckEdit();
		this.panelControl23 = new DevExpress.XtraEditors.PanelControl();
		this.chkOLevel = new DevExpress.XtraEditors.CheckEdit();
		this.btnAdvanced = new DevExpress.XtraEditors.SimpleButton();
		this.dtEnds = new DevExpress.XtraEditors.DateEdit();
		this.dtBegins = new DevExpress.XtraEditors.DateEdit();
		this.panelControl24 = new DevExpress.XtraEditors.PanelControl();
		this.chkMandatory = new DevExpress.XtraEditors.CheckEdit();
		this.chkF9InMathematics = new DevExpress.XtraEditors.CheckEdit();
		this.chkP7nP8InEnglish = new DevExpress.XtraEditors.CheckEdit();
		this.chkF9English = new DevExpress.XtraEditors.CheckEdit();
		this.txtReportHeader2 = new DevExpress.XtraEditors.TextEdit();
		this.cboSemesterProcess = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboClassProcess = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup16 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem96 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem97 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem98 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem99 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem114 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem130 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem133 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem134 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem135 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem136 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem137 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem138 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem139 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem152 = new DevExpress.XtraLayout.LayoutControlItem();
		this.panelControl25 = new DevExpress.XtraEditors.PanelControl();
		this.btnProcessOLevelReports = new DevExpress.XtraEditors.SimpleButton();
		this.tabProcessALevel = new DevExpress.XtraTab.XtraTabPage();
		this.panelControl29 = new DevExpress.XtraEditors.PanelControl();
		this.layoutControl13 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl28 = new DevExpress.XtraEditors.PanelControl();
		this.chkALevel = new DevExpress.XtraEditors.CheckEdit();
		this.button4 = new DevExpress.XtraEditors.SimpleButton();
		this.dtAEnds = new DevExpress.XtraEditors.DateEdit();
		this.dtABegins = new DevExpress.XtraEditors.DateEdit();
		this.txtReportHeader = new DevExpress.XtraEditors.TextEdit();
		this.cboALevelSemester = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboALevelClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup17 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem140 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem141 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem142 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem143 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem144 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem145 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem146 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem147 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
		this.pnlMain = new DevExpress.XtraEditors.PanelControl();
		this.groupControl21 = new DevExpress.XtraEditors.GroupControl();
		this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.ribbon).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemProgressBar2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemZoomTrackBar2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridBorrorRecords).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl14).BeginInit();
		this.groupControl14.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtNoOfCopies.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookReference.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpBooks.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBorrowDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBorrowDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl12).BeginInit();
		this.groupControl12.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpStudent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReservationStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReservationCode.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
		this.tabOrderDetails.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).BeginInit();
		this.groupControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl4).BeginInit();
		this.xtraTabControl4.SuspendLayout();
		this.tabNewOrders.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplyId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridSales).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSales).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtOrderDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtOrderDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpSupplier.Properties).BeginInit();
		this.tabStudentAdmission.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl5).BeginInit();
		this.groupControl5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumberSearch.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNameSearch.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStudent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl2).BeginInit();
		this.xtraTabControl2.SuspendLayout();
		this.tabStudyInformation.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutFeesStatus).BeginInit();
		this.layoutFeesStatus.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRequiredFees.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboBursaryProvider.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem36).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl3).BeginInit();
		this.groupControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupStudyStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl4).BeginInit();
		this.groupControl4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupBursaryStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutPersonData).BeginInit();
		this.layoutPersonData.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtGuardianContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboReligion.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboHall.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboNationality.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFormerSchool.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAdmissionDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSex.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGurdianAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGuardian.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLastName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFirstName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layout).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem34).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		this.tabEmployeeAdmission.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutEmployeeData).BeginInit();
		this.layoutEmployeeData.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboEmplHouse.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplFormerEmployee.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit22.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplContactNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplFirstName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtResponsibility.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQualification.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplLastName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboEmplSex.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem24).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem25).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem27).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem29).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem30).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem31).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem32).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem33).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem35).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem93).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNumberSearch.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNameSearch.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStaff.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl3).BeginInit();
		this.xtraTabControl3.SuspendLayout();
		this.tabSalaryInformation.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtUnTaxable.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNSSFAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPAYE.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNetPay.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNSSFRate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPAYECalc.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplSalaryAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplNotes.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem37).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem40).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem43).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem38).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem39).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl8).BeginInit();
		this.groupControl8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroup6.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl3).BeginInit();
		this.panelControl3.SuspendLayout();
		this.tabStudentPayments.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridStudentPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutStudentPayment).BeginInit();
		this.layoutStudentPayment.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentFees.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentBursaryStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentFirstName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtConfirmStudentNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentLastName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentSex.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentStudyStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentReligion.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentHomeCountry.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem46).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem47).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem48).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem49).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem50).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem51).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem52).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem53).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem54).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem55).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem56).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lblCurrentBank).BeginInit();
		this.lblCurrentBank.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkBankCharges.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintReceipt.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmountPaid.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceiptNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl7).BeginInit();
		this.groupControl7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroup4.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl11).BeginInit();
		this.groupControl11.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.lbRequirements).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkRememberSem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTermOfStudy.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpEdit.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStudentPicture.Properties).BeginInit();
		this.tabReports.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl2).BeginInit();
		this.tabEmployeePayments.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridEmpSalary).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewESalary).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl5).BeginInit();
		this.layoutControl5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkPayStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayEmplType.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayResponsibility.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayTelephone.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySurname.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayEmployeeNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayOtherNames.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayNSSF.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayNetPay.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayBasicPay.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayPaye.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem74).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem75).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem76).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem77).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem78).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem79).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem80).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem81).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem82).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem83).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem84).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem85).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl10).BeginInit();
		this.groupControl10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit4.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayNarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpStaff.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboPaySemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboPayMonth.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayAMount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboPayItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStaffPay.Properties).BeginInit();
		this.tabSuppliers.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl15).BeginInit();
		this.panelControl15.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridSuppliers).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSuppliers).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl5).BeginInit();
		this.xtraTabControl5.SuspendLayout();
		this.tabSupplierDetails.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierSurname.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierNotes.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierPhone.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierBoxNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierFax.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierJobTitle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCompany.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierMobile.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierEmail.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierOthername.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCity.Properties).BeginInit();
		this.tabOrderLists.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl6).BeginInit();
		this.groupControl6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierNarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboPaySupplierSemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintVoucherS.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOffice.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierMob.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOtherName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierSurname.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpSupplierPayment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLedger).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSL).BeginInit();
		this.tabBudgetCreattion.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl23).BeginInit();
		this.groupControl23.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtTotal.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtYear.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQuantity.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboUnits.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboItems.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboCategories.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemester3.Properties).BeginInit();
		this.tabStudentLists.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl20).BeginInit();
		this.panelControl20.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgRecords).BeginInit();
		this.tabEmployeeLists.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl21).BeginInit();
		this.panelControl21.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgRecords_emp).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewEmployees).BeginInit();
		this.tabReceiveVouchers.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl16).BeginInit();
		this.panelControl16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView26).BeginInit();
		this.tabReceiveVouchersDetails.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl17).BeginInit();
		this.panelControl17.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.textEdit60.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit6.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit6.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit61.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit62.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl27).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView27).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit63.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit64.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit65.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit66.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit67.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit68.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit8.Properties).BeginInit();
		this.tabReturnVouchers.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl18).BeginInit();
		this.panelControl18.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl28).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView28).BeginInit();
		this.tabReturnVouchersDetails.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl26).BeginInit();
		this.panelControl26.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl19).BeginInit();
		this.panelControl19.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.textEdit6.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit7.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit8.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit9.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit10.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit11.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit12.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit13.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit26.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit4.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit72.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit73.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit74.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit75.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit76.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit77.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit9.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl29).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView29).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit69.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit7.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit7.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit70.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit71.Properties).BeginInit();
		this.tabInfirmaryDiagnosis.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl6).BeginInit();
		this.panelControl6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit5.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl7).BeginInit();
		this.xtraTabControl7.SuspendLayout();
		this.xtraTabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl7).BeginInit();
		this.layoutControl7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtRecommendation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTreatment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiagnosis.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem101).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem102).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem103).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dt2.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dt2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl6).BeginInit();
		this.layoutControl6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtHall.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPersonId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem89).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem90).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem91).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem92).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem100).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picPerson.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl13).BeginInit();
		this.groupControl13.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtIDNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup7.Properties).BeginInit();
		this.tabBorrowRecords.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl8).BeginInit();
		this.panelControl8.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView12).BeginInit();
		this.xtraTabPage1.SuspendLayout();
		this.tabStudentRegistrationStandard.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl9).BeginInit();
		this.panelControl9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl9).BeginInit();
		this.layoutControl9.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl22).BeginInit();
		this.panelControl22.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumberRegister.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassR.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTermOfStudyRegister.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem110).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem111).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem112).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem113).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem94).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem95).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl17).BeginInit();
		this.groupControl17.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkLstSubjects).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkSelectAll.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl16).BeginInit();
		this.groupControl16.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupMode.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl15).BeginInit();
		this.groupControl15.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupLevelToRegister.Properties).BeginInit();
		this.tabStudentRegistrationAdvanced.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit10.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit5.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl10).BeginInit();
		this.panelControl10.SuspendLayout();
		this.tabSelectSubjects.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.lbSubjectsSelected).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lbSubjects).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl18).BeginInit();
		this.groupControl18.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupLevel.Properties).BeginInit();
		this.tabOLevelGradingScale.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.tabMainGradings).BeginInit();
		this.tabMainGradings.SuspendLayout();
		this.tabGradings1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).BeginInit();
		this.tabGradings2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridOLevelGrading).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrading).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.tabOLevelScales).BeginInit();
		this.tabOLevelScales.SuspendLayout();
		this.tabGradingScale.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradePoints.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeEnd.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeDebut.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeCategory.Properties).BeginInit();
		this.tabDivisionScale.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtHeadTeacherComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDOSComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtClassTeacherComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEnd.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebut.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategory.Properties).BeginInit();
		this.tabALevelGradingScale.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.tabALevelGrading).BeginInit();
		this.tabALevelGrading.SuspendLayout();
		this.tabALevelGradings1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades).BeginInit();
		this.tabALevelGrading2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.tabALevelScales).BeginInit();
		this.tabALevelScales.SuspendLayout();
		this.tabPaperBalancingScale.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAPoints.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAEnd.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtADebut.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtACategory.Properties).BeginInit();
		this.tabGradingScaleA.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPointsAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEndAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebutAA.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategoryAA.Properties).BeginInit();
		this.tabPersonalRequirements.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl27).BeginInit();
		this.groupControl27.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentStreamAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentClassAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNameAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAppendAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboAppItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterApp.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl26).BeginInit();
		this.groupControl26.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkCustomList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl25).BeginInit();
		this.groupControl25.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroupAppendTo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl24).BeginInit();
		this.groupControl24.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGrCat.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNoAppend.Properties).BeginInit();
		this.tabEmployeeDebts.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl28).BeginInit();
		this.groupControl28.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAmountAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboMonthAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboItemAppend.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl29).BeginInit();
		this.groupControl29.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkEmployeeList).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl30).BeginInit();
		this.groupControl30.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.rdEmployeeItems.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl31).BeginInit();
		this.groupControl31.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkCheckAll.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.rdAppendTo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpEmployee.Properties).BeginInit();
		this.tabQuickExpenses.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl11).BeginInit();
		this.panelControl11.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl32).BeginInit();
		this.groupControl32.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl10).BeginInit();
		this.layoutControl10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit8.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEQty.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEPayeQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtENarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboCategoriesQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboItemsQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboUnitsQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateTimePicker1.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dateTimePicker1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem115).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem116).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem117).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem118).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem119).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem120).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem121).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem122).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem123).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem129).BeginInit();
		this.tabQuickIncome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl12).BeginInit();
		this.panelControl12.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl33).BeginInit();
		this.groupControl33.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl11).BeginInit();
		this.layoutControl11.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit7.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmountIncome.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtCreditor.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarrationQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboIncomeSource.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterIQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDateQuick.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDateQuick.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem125).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem126).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem127).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem128).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem131).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem132).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem124).BeginInit();
		this.tabProcessOLevel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl30).BeginInit();
		this.panelControl30.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl12).BeginInit();
		this.layoutControl12.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkF9InSCI.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl23).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkOLevel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEnds.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEnds.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl24).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkMandatory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9InMathematics.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkP7nP8InEnglish.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9English.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterProcess.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassProcess.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem96).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem97).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem98).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem99).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem114).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem130).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem133).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem134).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem135).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem136).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem137).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem138).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem139).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem152).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl25).BeginInit();
		this.panelControl25.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl29).BeginInit();
		this.panelControl29.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl13).BeginInit();
		this.layoutControl13.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl28).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkALevel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtAEnds.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtAEnds.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtABegins.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtABegins.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboALevelSemester.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboALevelClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem140).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem141).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem142).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem143).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem144).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem145).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem146).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem147).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).BeginInit();
		this.layoutControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pnlMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.ribbon.ApplicationButtonText = null;
		this.ribbon.ExpandCollapseItem.Id = 0;
		this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[45]
		{
			this.ribbon.ExpandCollapseItem,
			this.btnAddBook,
			this.btnIssueBooks,
			this.barButtonItem1,
			this.barButtonItem3,
			this.barButtonItem10,
			this.btnReturnBooks,
			this.btnLibrarycards,
			this.barButtonItem11,
			this.printPreviewStaticItem3,
			this.barStaticItem2,
			this.barButtonItem13,
			this.printPreviewStaticItem4,
			this.barButtonItem19,
			this.barButtonItem20,
			this.barButtonItem21,
			this.barButtonItem22,
			this.barButtonItem23,
			this.barButtonItem24,
			this.barButtonItem25,
			this.barButtonItem26,
			this.barButtonItem27,
			this.barButtonItem28,
			this.barButtonItem29,
			this.barButtonItem2,
			this.barButtonItem4,
			this.barButtonItem5,
			this.barButtonItem14,
			this.barButtonItem15,
			this.barButtonItem16,
			this.barButtonItem17,
			this.barButtonItem18,
			this.barButtonItem30,
			this.barButtonItem31,
			this.barButtonItem32,
			this.barButtonItem33,
			this.barButtonItem34,
			this.barButtonItem35,
			this.barButtonItem6,
			this.barButtonItem36,
			this.barButtonItem7,
			this.barButtonItem8,
			this.barButtonItem9,
			this.barButtonItem12,
			this.barButtonItem37
		});
		this.ribbon.Location = new System.Drawing.Point(0, 0);
		this.ribbon.MaxItemId = 111;
		this.ribbon.Name = "ribbon";
		this.ribbon.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[4] { this.ribbonPageCatBooksManage, this.ribbonPageCatLocation, this.ribbonPageCatBorrows, this.ribbonPageCat_CatManage });
		this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPageLib });
		this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemProgressBar2, this.repositoryItemZoomTrackBar2 });
		this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbon.ShowCategoryInCaption = false;
		this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbon.ShowToolbarCustomizeItem = false;
		this.ribbon.Size = new System.Drawing.Size(851, 146);
		this.ribbon.StatusBar = this.ribbonStatusBar;
		this.ribbon.Toolbar.ShowCustomizeItem = false;
		this.ribbon.TransparentEditors = true;
		this.ribbon.SelectedPageChanged += new System.EventHandler(ribbon_SelectedPageChanged);
		this.btnAddBook.Caption = "Delete";
		this.btnAddBook.Glyph = LibraryManagement.Properties.Resources.bookList16;
		this.btnAddBook.Id = 1;
		this.btnAddBook.LargeGlyph = LibraryManagement.Properties.Resources.bookList;
		this.btnAddBook.Name = "btnAddBook";
		this.btnAddBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnAddBook_ItemClick);
		this.btnIssueBooks.Caption = "Issue Books";
		this.btnIssueBooks.Glyph = LibraryManagement.Properties.Resources.bookIssue16;
		this.btnIssueBooks.Id = 2;
		this.btnIssueBooks.Name = "btnIssueBooks";
		this.btnIssueBooks.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.btnIssueBooks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnIssueBooks_ItemClick);
		this.barButtonItem1.Caption = "Categories";
		this.barButtonItem1.Glyph = LibraryManagement.Properties.Resources.bookCats16;
		this.barButtonItem1.Id = 3;
		this.barButtonItem1.LargeGlyph = LibraryManagement.Properties.Resources.bookCats;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.All;
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem3.Caption = "Locations";
		this.barButtonItem3.Glyph = LibraryManagement.Properties.Resources.bookLocation16;
		this.barButtonItem3.Id = 5;
		this.barButtonItem3.LargeGlyph = LibraryManagement.Properties.Resources.bookLocation;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem10.Caption = "Add New";
		this.barButtonItem10.Glyph = LibraryManagement.Properties.Resources.addBook16;
		this.barButtonItem10.Id = 12;
		this.barButtonItem10.LargeGlyph = LibraryManagement.Properties.Resources.addBook;
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.btnReturnBooks.Caption = "Return book";
		this.btnReturnBooks.Glyph = LibraryManagement.Properties.Resources.bookReturn16;
		this.btnReturnBooks.Id = 13;
		this.btnReturnBooks.Name = "btnReturnBooks";
		this.btnReturnBooks.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.btnReturnBooks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnReturnBooks_ItemClick);
		this.btnLibrarycards.Caption = "Library Cards";
		this.btnLibrarycards.Glyph = (System.Drawing.Image)resources.GetObject("btnLibrarycards.Glyph");
		this.btnLibrarycards.Id = 14;
		this.btnLibrarycards.LargeGlyph = LibraryManagement.Properties.Resources.libCard;
		this.btnLibrarycards.Name = "btnLibrarycards";
		this.barButtonItem11.Caption = "Pay Fine";
		this.barButtonItem11.Glyph = LibraryManagement.Properties.Resources.payFine16;
		this.barButtonItem11.Id = 15;
		this.barButtonItem11.Name = "barButtonItem11";
		this.barButtonItem11.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem11_ItemClick);
		this.printPreviewStaticItem3.Caption = "Nothing";
		this.printPreviewStaticItem3.Id = 63;
		this.printPreviewStaticItem3.LeftIndent = 1;
		this.printPreviewStaticItem3.Name = "printPreviewStaticItem3";
		this.printPreviewStaticItem3.RightIndent = 1;
		this.printPreviewStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
		this.printPreviewStaticItem3.Type = "PageOfPages";
		this.barStaticItem2.Id = 64;
		this.barStaticItem2.Name = "barStaticItem2";
		this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
		this.barStaticItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.barButtonItem13.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
		this.barButtonItem13.Enabled = false;
		this.barButtonItem13.Id = 67;
		this.barButtonItem13.Name = "barButtonItem13";
		this.barButtonItem13.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.printPreviewStaticItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.printPreviewStaticItem4.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.printPreviewStaticItem4.Caption = "100%";
		this.printPreviewStaticItem4.Id = 68;
		this.printPreviewStaticItem4.Name = "printPreviewStaticItem4";
		this.printPreviewStaticItem4.TextAlignment = System.Drawing.StringAlignment.Near;
		this.printPreviewStaticItem4.Type = "ZoomFactorText";
		this.printPreviewStaticItem4.Width = 42;
		this.barButtonItem19.Caption = "Edit";
		this.barButtonItem19.Id = 78;
		this.barButtonItem19.Name = "barButtonItem19";
		this.barButtonItem19.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem19_ItemClick);
		this.barButtonItem20.Caption = "Update Stock";
		this.barButtonItem20.Id = 79;
		this.barButtonItem20.Name = "barButtonItem20";
		this.barButtonItem21.Caption = "Dispose";
		this.barButtonItem21.Id = 80;
		this.barButtonItem21.Name = "barButtonItem21";
		this.barButtonItem22.Caption = "Home";
		this.barButtonItem22.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem22.Glyph");
		this.barButtonItem22.Id = 81;
		this.barButtonItem22.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem22.LargeGlyph");
		this.barButtonItem22.Name = "barButtonItem22";
		this.barButtonItem22.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem22_ItemClick);
		this.barButtonItem23.Caption = "Print";
		this.barButtonItem23.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem23.Glyph");
		this.barButtonItem23.Id = 82;
		this.barButtonItem23.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem23.LargeGlyph");
		this.barButtonItem23.Name = "barButtonItem23";
		this.barButtonItem23.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem23_ItemClick);
		this.barButtonItem24.Caption = "Preview";
		this.barButtonItem24.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem24.Glyph");
		this.barButtonItem24.Id = 83;
		this.barButtonItem24.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem24.LargeGlyph");
		this.barButtonItem24.Name = "barButtonItem24";
		this.barButtonItem24.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem24_ItemClick);
		this.barButtonItem25.Caption = "Export";
		this.barButtonItem25.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem25.Glyph");
		this.barButtonItem25.Id = 84;
		this.barButtonItem25.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem25.LargeGlyph");
		this.barButtonItem25.Name = "barButtonItem25";
		this.barButtonItem26.Caption = "Home";
		this.barButtonItem26.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem26.Glyph");
		this.barButtonItem26.Id = 85;
		this.barButtonItem26.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem26.LargeGlyph");
		this.barButtonItem26.Name = "barButtonItem26";
		this.barButtonItem26.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem26_ItemClick);
		this.barButtonItem27.Caption = "Print";
		this.barButtonItem27.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem27.Glyph");
		this.barButtonItem27.Id = 86;
		this.barButtonItem27.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem27.LargeGlyph");
		this.barButtonItem27.Name = "barButtonItem27";
		this.barButtonItem28.Caption = "Preview";
		this.barButtonItem28.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem28.Glyph");
		this.barButtonItem28.Id = 87;
		this.barButtonItem28.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem28.LargeGlyph");
		this.barButtonItem28.Name = "barButtonItem28";
		this.barButtonItem29.Caption = "Export";
		this.barButtonItem29.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem29.Glyph");
		this.barButtonItem29.Id = 88;
		this.barButtonItem29.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem29.LargeGlyph");
		this.barButtonItem29.Name = "barButtonItem29";
		this.barButtonItem2.Caption = "Home";
		this.barButtonItem2.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem2.Glyph");
		this.barButtonItem2.Id = 89;
		this.barButtonItem2.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem2.LargeGlyph");
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick_1);
		this.barButtonItem4.Caption = "Print";
		this.barButtonItem4.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem4.Glyph");
		this.barButtonItem4.Id = 90;
		this.barButtonItem4.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem4.LargeGlyph");
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem5.Caption = "Preview";
		this.barButtonItem5.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem5.Glyph");
		this.barButtonItem5.Id = 91;
		this.barButtonItem5.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem5.LargeGlyph");
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem14.Caption = "Export";
		this.barButtonItem14.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem14.Glyph");
		this.barButtonItem14.Id = 92;
		this.barButtonItem14.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem14.LargeGlyph");
		this.barButtonItem14.Name = "barButtonItem14";
		this.barButtonItem15.Caption = "Add New";
		this.barButtonItem15.Id = 93;
		this.barButtonItem15.Name = "barButtonItem15";
		this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem15_ItemClick_1);
		this.barButtonItem16.Caption = "Edit";
		this.barButtonItem16.Id = 94;
		this.barButtonItem16.Name = "barButtonItem16";
		this.barButtonItem17.Caption = "Delete";
		this.barButtonItem17.Id = 95;
		this.barButtonItem17.Name = "barButtonItem17";
		this.barButtonItem18.Caption = "Home";
		this.barButtonItem18.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem18.Glyph");
		this.barButtonItem18.Id = 96;
		this.barButtonItem18.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem18.LargeGlyph");
		this.barButtonItem18.Name = "barButtonItem18";
		this.barButtonItem18.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem18_ItemClick_1);
		this.barButtonItem30.Caption = "Add New";
		this.barButtonItem30.Id = 97;
		this.barButtonItem30.Name = "barButtonItem30";
		this.barButtonItem30.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem30_ItemClick);
		this.barButtonItem31.Caption = "Edit";
		this.barButtonItem31.Id = 98;
		this.barButtonItem31.Name = "barButtonItem31";
		this.barButtonItem32.Caption = "Delete";
		this.barButtonItem32.Id = 100;
		this.barButtonItem32.Name = "barButtonItem32";
		this.barButtonItem33.Caption = "Print";
		this.barButtonItem33.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem33.Glyph");
		this.barButtonItem33.Id = 101;
		this.barButtonItem33.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem33.LargeGlyph");
		this.barButtonItem33.Name = "barButtonItem33";
		this.barButtonItem34.Caption = "Preview";
		this.barButtonItem34.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem34.Glyph");
		this.barButtonItem34.Id = 102;
		this.barButtonItem34.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem34.LargeGlyph");
		this.barButtonItem34.Name = "barButtonItem34";
		this.barButtonItem35.Caption = "Export";
		this.barButtonItem35.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem35.Glyph");
		this.barButtonItem35.Id = 103;
		this.barButtonItem35.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem35.LargeGlyph");
		this.barButtonItem35.Name = "barButtonItem35";
		this.barButtonItem6.Caption = "Books";
		this.barButtonItem6.Id = 104;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick_1);
		this.barButtonItem36.Caption = "Issue/Return Books";
		this.barButtonItem36.Id = 105;
		this.barButtonItem36.Name = "barButtonItem36";
		this.barButtonItem36.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem36_ItemClick);
		this.barButtonItem7.Caption = "Close";
		this.barButtonItem7.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem7.Glyph");
		this.barButtonItem7.Id = 106;
		this.barButtonItem7.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem7.LargeGlyph");
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.barButtonItem8.Caption = "Close";
		this.barButtonItem8.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem8.Glyph");
		this.barButtonItem8.Id = 107;
		this.barButtonItem8.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem8.LargeGlyph");
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem8_ItemClick);
		this.barButtonItem9.Caption = "Close";
		this.barButtonItem9.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem9.Glyph");
		this.barButtonItem9.Id = 108;
		this.barButtonItem9.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem9.LargeGlyph");
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.barButtonItem12.Caption = "Close";
		this.barButtonItem12.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem12.Glyph");
		this.barButtonItem12.Id = 109;
		this.barButtonItem12.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem12.LargeGlyph");
		this.barButtonItem12.Name = "barButtonItem12";
		this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem12_ItemClick);
		this.barButtonItem37.Caption = "Import Books";
		this.barButtonItem37.Id = 110;
		this.barButtonItem37.Name = "barButtonItem37";
		this.barButtonItem37.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem37_ItemClick);
		this.ribbonPageCatBooksManage.Color = System.Drawing.Color.FromArgb(255, 128, 255);
		this.ribbonPageCatBooksManage.Name = "ribbonPageCatBooksManage";
		this.ribbonPageCatBooksManage.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPageBooks });
		this.ribbonPageCatBooksManage.Text = "Books Management";
		this.ribbonPageCatBooksManage.Visible = false;
		this.ribbonPageBooks.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup6, this.ribbonPageGroup7, this.ribbonPageGroup8, this.ribbonPageGroup17 });
		this.ribbonPageBooks.Name = "ribbonPageBooks";
		this.ribbonPageBooks.Text = "Books Management";
		this.ribbonPageBooks.Visible = false;
		this.ribbonPageGroup6.AllowTextClipping = false;
		this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem22);
		this.ribbonPageGroup6.Name = "ribbonPageGroup6";
		this.ribbonPageGroup6.ShowCaptionButton = false;
		this.ribbonPageGroup6.Text = "Home";
		this.ribbonPageGroup7.AllowTextClipping = false;
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem10);
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem37);
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem19);
		this.ribbonPageGroup7.ItemLinks.Add(this.btnAddBook);
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem20);
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem21);
		this.ribbonPageGroup7.Name = "ribbonPageGroup7";
		this.ribbonPageGroup7.ShowCaptionButton = false;
		this.ribbonPageGroup7.Text = "Books Management";
		this.ribbonPageGroup8.AllowTextClipping = false;
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem23);
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem24);
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem25);
		this.ribbonPageGroup8.Name = "ribbonPageGroup8";
		this.ribbonPageGroup8.ShowCaptionButton = false;
		this.ribbonPageGroup8.Text = "Printing && Exporting";
		this.ribbonPageGroup17.AllowTextClipping = false;
		this.ribbonPageGroup17.ItemLinks.Add(this.barButtonItem12);
		this.ribbonPageGroup17.Name = "ribbonPageGroup17";
		this.ribbonPageGroup17.ShowCaptionButton = false;
		this.ribbonPageGroup17.Text = "Close";
		this.ribbonPageCatLocation.Color = System.Drawing.Color.FromArgb(255, 128, 255);
		this.ribbonPageCatLocation.Name = "ribbonPageCatLocation";
		this.ribbonPageCatLocation.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPageLocations });
		this.ribbonPageCatLocation.Text = "Library Management";
		this.ribbonPageCatLocation.Visible = false;
		this.ribbonPageLocations.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup14, this.ribbonPageGroup15, this.ribbonPageGroup16, this.ribbonPageGroup18 });
		this.ribbonPageLocations.Name = "ribbonPageLocations";
		this.ribbonPageLocations.Text = "Books Locations";
		this.ribbonPageLocations.Visible = false;
		this.ribbonPageGroup14.AllowTextClipping = false;
		this.ribbonPageGroup14.ItemLinks.Add(this.barButtonItem18);
		this.ribbonPageGroup14.Name = "ribbonPageGroup14";
		this.ribbonPageGroup14.ShowCaptionButton = false;
		this.ribbonPageGroup14.Text = "Home";
		this.ribbonPageGroup15.AllowTextClipping = false;
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem30);
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem31);
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem32);
		this.ribbonPageGroup15.Name = "ribbonPageGroup15";
		this.ribbonPageGroup15.ShowCaptionButton = false;
		this.ribbonPageGroup15.Text = "Locations Management";
		this.ribbonPageGroup16.AllowTextClipping = false;
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem33);
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem34);
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem35);
		this.ribbonPageGroup16.Name = "ribbonPageGroup16";
		this.ribbonPageGroup16.ShowCaptionButton = false;
		this.ribbonPageGroup16.Text = "Printing && Exporting";
		this.ribbonPageGroup18.AllowTextClipping = false;
		this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem9);
		this.ribbonPageGroup18.Name = "ribbonPageGroup18";
		this.ribbonPageGroup18.ShowCaptionButton = false;
		this.ribbonPageGroup18.Text = "Close";
		this.ribbonPageCatBorrows.Color = System.Drawing.Color.FromArgb(255, 128, 255);
		this.ribbonPageCatBorrows.Name = "ribbonPageCatBorrows";
		this.ribbonPageCatBorrows.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPageIssuesReturns });
		this.ribbonPageCatBorrows.Text = "Book Borrows";
		this.ribbonPageCatBorrows.Visible = false;
		this.ribbonPageIssuesReturns.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup9, this.ribbonPageGroup10, this.ribbonPageGroup11, this.ribbonPageGroup20 });
		this.ribbonPageIssuesReturns.Name = "ribbonPageIssuesReturns";
		this.ribbonPageIssuesReturns.Text = "Borrows and Retuns";
		this.ribbonPageIssuesReturns.Visible = false;
		this.ribbonPageGroup9.AllowTextClipping = false;
		this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem26);
		this.ribbonPageGroup9.Name = "ribbonPageGroup9";
		this.ribbonPageGroup9.ShowCaptionButton = false;
		this.ribbonPageGroup9.Text = "Home";
		this.ribbonPageGroup10.AllowTextClipping = false;
		this.ribbonPageGroup10.ItemLinks.Add(this.btnIssueBooks);
		this.ribbonPageGroup10.ItemLinks.Add(this.btnReturnBooks);
		this.ribbonPageGroup10.ItemLinks.Add(this.barButtonItem11);
		this.ribbonPageGroup10.Name = "ribbonPageGroup10";
		this.ribbonPageGroup10.ShowCaptionButton = false;
		this.ribbonPageGroup10.Text = "Issue && Returns Management";
		this.ribbonPageGroup11.AllowTextClipping = false;
		this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem27);
		this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem28);
		this.ribbonPageGroup11.ItemLinks.Add(this.barButtonItem29);
		this.ribbonPageGroup11.Name = "ribbonPageGroup11";
		this.ribbonPageGroup11.ShowCaptionButton = false;
		this.ribbonPageGroup11.Text = "Printing && Exporting";
		this.ribbonPageGroup20.AllowTextClipping = false;
		this.ribbonPageGroup20.ItemLinks.Add(this.barButtonItem7);
		this.ribbonPageGroup20.Name = "ribbonPageGroup20";
		this.ribbonPageGroup20.ShowCaptionButton = false;
		this.ribbonPageGroup20.Text = "Close";
		this.ribbonPageCat_CatManage.Color = System.Drawing.Color.FromArgb(255, 128, 255);
		this.ribbonPageCat_CatManage.Name = "ribbonPageCat_CatManage";
		this.ribbonPageCat_CatManage.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPageCategories });
		this.ribbonPageCat_CatManage.Text = "Category Management";
		this.ribbonPageCat_CatManage.Visible = false;
		this.ribbonPageCategories.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup5, this.ribbonPageGroup12, this.ribbonPageGroup13, this.ribbonPageGroup19 });
		this.ribbonPageCategories.Name = "ribbonPageCategories";
		this.ribbonPageCategories.Text = "Books Categories";
		this.ribbonPageCategories.Visible = false;
		this.ribbonPageGroup5.AllowTextClipping = false;
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
		this.ribbonPageGroup5.Name = "ribbonPageGroup5";
		this.ribbonPageGroup5.ShowCaptionButton = false;
		this.ribbonPageGroup5.Text = "Home";
		this.ribbonPageGroup12.AllowTextClipping = false;
		this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem15);
		this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem16);
		this.ribbonPageGroup12.ItemLinks.Add(this.barButtonItem17);
		this.ribbonPageGroup12.Name = "ribbonPageGroup12";
		this.ribbonPageGroup12.ShowCaptionButton = false;
		this.ribbonPageGroup12.Text = "Categories Management";
		this.ribbonPageGroup13.AllowTextClipping = false;
		this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem5);
		this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem14);
		this.ribbonPageGroup13.Name = "ribbonPageGroup13";
		this.ribbonPageGroup13.ShowCaptionButton = false;
		this.ribbonPageGroup13.Text = "Printing && Exporting";
		this.ribbonPageGroup19.AllowTextClipping = false;
		this.ribbonPageGroup19.ItemLinks.Add(this.barButtonItem8);
		this.ribbonPageGroup19.Name = "ribbonPageGroup19";
		this.ribbonPageGroup19.ShowCaptionButton = false;
		this.ribbonPageGroup19.Text = "Close";
		this.ribbonPageLib.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[2] { this.ManagementAndSetup, this.ribbonPageGroup1 });
		this.ribbonPageLib.Name = "ribbonPageLib";
		this.ribbonPageLib.Text = "Library";
		this.ManagementAndSetup.AllowTextClipping = false;
		this.ManagementAndSetup.ItemLinks.Add(this.barButtonItem1);
		this.ManagementAndSetup.ItemLinks.Add(this.barButtonItem6);
		this.ManagementAndSetup.ItemLinks.Add(this.barButtonItem36);
		this.ManagementAndSetup.ItemLinks.Add(this.barButtonItem3);
		this.ManagementAndSetup.Name = "ManagementAndSetup";
		this.ManagementAndSetup.ShowCaptionButton = false;
		this.ManagementAndSetup.Text = "Xtreme Library Management";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.ItemLinks.Add(this.btnLibrarycards);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.ShowCaptionButton = false;
		this.ribbonPageGroup1.Text = "Library Cards";
		this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
		this.repositoryItemZoomTrackBar2.Alignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemZoomTrackBar2.AllowFocused = false;
		this.repositoryItemZoomTrackBar2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.repositoryItemZoomTrackBar2.Maximum = 180;
		this.repositoryItemZoomTrackBar2.Middle = 5;
		this.repositoryItemZoomTrackBar2.Name = "repositoryItemZoomTrackBar2";
		this.repositoryItemZoomTrackBar2.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
		this.ribbonStatusBar.ItemLinks.Add(this.printPreviewStaticItem3);
		this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem2, true);
		this.ribbonStatusBar.ItemLinks.Add(this.barButtonItem13);
		this.ribbonStatusBar.ItemLinks.Add(this.printPreviewStaticItem4);
		this.ribbonStatusBar.Location = new System.Drawing.Point(0, 656);
		this.ribbonStatusBar.Name = "ribbonStatusBar";
		this.ribbonStatusBar.Ribbon = this.ribbon;
		this.ribbonStatusBar.Size = new System.Drawing.Size(851, 27);
		this.ribbonPageGroup28.AllowTextClipping = false;
		this.ribbonPageGroup28.Name = "ribbonPageGroup28";
		this.ribbonPageGroup28.ShowCaptionButton = false;
		this.ribbonPageGroup28.Text = "Books";
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.ShowCaptionButton = false;
		this.ribbonPageGroup2.Text = "Books";
		this.ribbonPageGroup3.AllowTextClipping = false;
		this.ribbonPageGroup3.Name = "ribbonPageGroup3";
		this.ribbonPageGroup3.ShowCaptionButton = false;
		this.ribbonPageGroup3.Text = "Books";
		this.ribbonPageGroup4.AllowTextClipping = false;
		this.ribbonPageGroup4.Name = "ribbonPageGroup4";
		this.ribbonPageGroup4.ShowCaptionButton = false;
		this.ribbonPageGroup4.Text = "Books";
		this.gridBorrorRecords.Location = new System.Drawing.Point(213, 4);
		this.gridBorrorRecords.MainView = this.gridView6;
		this.gridBorrorRecords.MenuManager = this.ribbon;
		this.gridBorrorRecords.Name = "gridBorrorRecords";
		this.gridBorrorRecords.Size = new System.Drawing.Size(635, 477);
		this.gridBorrorRecords.TabIndex = 45;
		this.gridBorrorRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView6 });
		this.gridView6.GridControl = this.gridBorrorRecords;
		this.gridView6.Name = "gridView6";
		this.gridView6.OptionsCustomization.AllowGroup = false;
		this.gridView6.OptionsView.ShowGroupPanel = false;
		this.groupControl14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl14.Controls.Add(this.labelControl35);
		this.groupControl14.Controls.Add(this.labelControl32);
		this.groupControl14.Controls.Add(this.labelControl31);
		this.groupControl14.Controls.Add(this.labelControl30);
		this.groupControl14.Controls.Add(this.txtNoOfCopies);
		this.groupControl14.Controls.Add(this.dtReturnDate);
		this.groupControl14.Controls.Add(this.txtBookReference);
		this.groupControl14.Controls.Add(this.lookUpBooks);
		this.groupControl14.Controls.Add(this.labelControl34);
		this.groupControl14.Controls.Add(this.comboBoxEdit1);
		this.groupControl14.Controls.Add(this.labelControl33);
		this.groupControl14.Controls.Add(this.dtBorrowDate);
		this.groupControl14.Controls.Add(this.btnIssueBook);
		this.groupControl14.Location = new System.Drawing.Point(4, 279);
		this.groupControl14.Name = "groupControl14";
		this.groupControl14.Size = new System.Drawing.Size(208, 202);
		this.groupControl14.TabIndex = 44;
		this.groupControl14.Text = "Books and Issuing";
		this.labelControl35.Location = new System.Drawing.Point(6, 101);
		this.labelControl35.Name = "labelControl35";
		this.labelControl35.Size = new System.Drawing.Size(40, 13);
		this.labelControl35.TabIndex = 43;
		this.labelControl35.Text = "Location";
		this.labelControl32.Location = new System.Drawing.Point(6, 78);
		this.labelControl32.Name = "labelControl32";
		this.labelControl32.Size = new System.Drawing.Size(47, 13);
		this.labelControl32.TabIndex = 42;
		this.labelControl32.Text = "Book Ref.";
		this.labelControl31.Location = new System.Drawing.Point(6, 56);
		this.labelControl31.Name = "labelControl31";
		this.labelControl31.Size = new System.Drawing.Size(28, 13);
		this.labelControl31.TabIndex = 41;
		this.labelControl31.Text = "Books";
		this.labelControl30.Location = new System.Drawing.Point(6, 33);
		this.labelControl30.Name = "labelControl30";
		this.labelControl30.Size = new System.Drawing.Size(45, 13);
		this.labelControl30.TabIndex = 40;
		this.labelControl30.Text = "Category";
		this.txtNoOfCopies.Location = new System.Drawing.Point(57, 94);
		this.txtNoOfCopies.MenuManager = this.ribbon;
		this.txtNoOfCopies.Name = "txtNoOfCopies";
		this.txtNoOfCopies.Size = new System.Drawing.Size(146, 20);
		this.txtNoOfCopies.TabIndex = 3;
		this.dtReturnDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.dtReturnDate.EditValue = null;
		this.dtReturnDate.Location = new System.Drawing.Point(57, 142);
		this.dtReturnDate.Name = "dtReturnDate";
		this.dtReturnDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtReturnDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtReturnDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtReturnDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtReturnDate.Size = new System.Drawing.Size(101, 20);
		this.dtReturnDate.TabIndex = 29;
		this.txtBookReference.Location = new System.Drawing.Point(57, 71);
		this.txtBookReference.MenuManager = this.ribbon;
		this.txtBookReference.Name = "txtBookReference";
		this.txtBookReference.Size = new System.Drawing.Size(146, 20);
		this.txtBookReference.TabIndex = 2;
		this.lookUpBooks.Location = new System.Drawing.Point(57, 49);
		this.lookUpBooks.MenuManager = this.ribbon;
		this.lookUpBooks.Name = "lookUpBooks";
		this.lookUpBooks.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpBooks.Size = new System.Drawing.Size(146, 20);
		this.lookUpBooks.TabIndex = 1;
		this.labelControl34.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.labelControl34.Location = new System.Drawing.Point(6, 149);
		this.labelControl34.Name = "labelControl34";
		this.labelControl34.Size = new System.Drawing.Size(44, 13);
		this.labelControl34.TabIndex = 27;
		this.labelControl34.Text = "Due date";
		this.comboBoxEdit1.Location = new System.Drawing.Point(57, 26);
		this.comboBoxEdit1.MenuManager = this.ribbon;
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Size = new System.Drawing.Size(146, 20);
		this.comboBoxEdit1.TabIndex = 0;
		this.labelControl33.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.labelControl33.Location = new System.Drawing.Point(6, 125);
		this.labelControl33.Name = "labelControl33";
		this.labelControl33.Size = new System.Drawing.Size(23, 13);
		this.labelControl33.TabIndex = 26;
		this.labelControl33.Text = "Date";
		this.dtBorrowDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.dtBorrowDate.EditValue = null;
		this.dtBorrowDate.Location = new System.Drawing.Point(57, 118);
		this.dtBorrowDate.Name = "dtBorrowDate";
		this.dtBorrowDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtBorrowDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtBorrowDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtBorrowDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtBorrowDate.Size = new System.Drawing.Size(101, 20);
		this.dtBorrowDate.TabIndex = 28;
		this.btnIssueBook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.btnIssueBook.Location = new System.Drawing.Point(58, 174);
		this.btnIssueBook.Name = "btnIssueBook";
		this.btnIssueBook.Size = new System.Drawing.Size(100, 23);
		this.btnIssueBook.TabIndex = 39;
		this.btnIssueBook.Text = "Issue Book";
		this.groupControl12.Controls.Add(this.pictureEdit1);
		this.groupControl12.Controls.Add(this.lookUpStudent);
		this.groupControl12.Controls.Add(this.txtReservationStatus);
		this.groupControl12.Controls.Add(this.txtReservationCode);
		this.groupControl12.Location = new System.Drawing.Point(4, 4);
		this.groupControl12.Name = "groupControl12";
		this.groupControl12.Size = new System.Drawing.Size(208, 268);
		this.groupControl12.TabIndex = 43;
		this.groupControl12.Text = "Student details";
		this.pictureEdit1.Location = new System.Drawing.Point(6, 26);
		this.pictureEdit1.MenuManager = this.ribbon;
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Size = new System.Drawing.Size(197, 165);
		this.pictureEdit1.TabIndex = 36;
		this.lookUpStudent.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lookUpStudent.Location = new System.Drawing.Point(6, 194);
		this.lookUpStudent.Name = "lookUpStudent";
		this.lookUpStudent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpStudent.Properties.NullText = "";
		this.lookUpStudent.Size = new System.Drawing.Size(197, 20);
		this.lookUpStudent.TabIndex = 33;
		this.txtReservationStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.txtReservationStatus.Location = new System.Drawing.Point(6, 243);
		this.txtReservationStatus.Name = "txtReservationStatus";
		this.txtReservationStatus.Properties.ReadOnly = true;
		this.txtReservationStatus.Size = new System.Drawing.Size(197, 20);
		this.txtReservationStatus.TabIndex = 35;
		this.txtReservationCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.txtReservationCode.Location = new System.Drawing.Point(7, 219);
		this.txtReservationCode.Name = "txtReservationCode";
		this.txtReservationCode.Properties.ReadOnly = true;
		this.txtReservationCode.Size = new System.Drawing.Size(196, 20);
		this.txtReservationCode.TabIndex = 34;
		this.xtraTabControl1.Location = new System.Drawing.Point(161, 5);
		this.xtraTabControl1.Name = "xtraTabControl1";
		this.xtraTabControl1.SelectedTabPage = this.tabOrderDetails;
		this.xtraTabControl1.Size = new System.Drawing.Size(857, 510);
		this.xtraTabControl1.TabIndex = 4;
		this.tabOrderDetails.Controls.Add(this.simpleButton3);
		this.tabOrderDetails.Controls.Add(this.lblNameItem);
		this.tabOrderDetails.Controls.Add(this.lblCodeItem);
		this.tabOrderDetails.Controls.Add(this.btnRemoveItem);
		this.tabOrderDetails.Controls.Add(this.btnAddToList);
		this.tabOrderDetails.Controls.Add(this.groupControl2);
		this.tabOrderDetails.Controls.Add(this.xtraTabControl4);
		this.tabOrderDetails.Controls.Add(this.simpleButton30);
		this.tabOrderDetails.Controls.Add(this.simpleButton29);
		this.tabOrderDetails.Name = "tabOrderDetails";
		this.tabOrderDetails.Size = new System.Drawing.Size(851, 504);
		this.tabOrderDetails.Text = "Order details";
		this.simpleButton3.Location = new System.Drawing.Point(431, 456);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(75, 23);
		this.simpleButton3.TabIndex = 64;
		this.simpleButton3.Text = "Close invoice";
		this.lblNameItem.Location = new System.Drawing.Point(429, 279);
		this.lblNameItem.Name = "lblNameItem";
		this.lblNameItem.Size = new System.Drawing.Size(0, 13);
		this.lblNameItem.TabIndex = 63;
		this.lblNameItem.Visible = false;
		this.lblCodeItem.Location = new System.Drawing.Point(429, 246);
		this.lblCodeItem.Name = "lblCodeItem";
		this.lblCodeItem.Size = new System.Drawing.Size(0, 13);
		this.lblCodeItem.TabIndex = 62;
		this.lblCodeItem.Visible = false;
		this.btnRemoveItem.Location = new System.Drawing.Point(429, 55);
		this.btnRemoveItem.Name = "btnRemoveItem";
		this.btnRemoveItem.Size = new System.Drawing.Size(75, 23);
		this.btnRemoveItem.TabIndex = 59;
		this.btnRemoveItem.Text = "Remove Item";
		this.btnAddToList.Location = new System.Drawing.Point(429, 26);
		this.btnAddToList.Name = "btnAddToList";
		this.btnAddToList.Size = new System.Drawing.Size(75, 23);
		this.btnAddToList.TabIndex = 56;
		this.btnAddToList.Text = "Add To List";
		this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupControl2.Controls.Add(this.gridItems);
		this.groupControl2.Location = new System.Drawing.Point(510, 27);
		this.groupControl2.Name = "groupControl2";
		this.groupControl2.Size = new System.Drawing.Size(338, 454);
		this.groupControl2.TabIndex = 55;
		this.groupControl2.Text = "Items";
		this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridItems.Location = new System.Drawing.Point(2, 21);
		this.gridItems.MainView = this.gridViewItems;
		this.gridItems.Name = "gridItems";
		this.gridItems.Size = new System.Drawing.Size(334, 431);
		this.gridItems.TabIndex = 0;
		this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewItems });
		this.gridViewItems.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.ColumnFilterButton.Options.UseBackColor = true;
		this.gridViewItems.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.ColumnFilterButton.Options.UseForeColor = true;
		this.gridViewItems.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
		this.gridViewItems.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
		this.gridViewItems.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
		this.gridViewItems.Appearance.Empty.Options.UseBackColor = true;
		this.gridViewItems.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
		this.gridViewItems.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.EvenRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FilterCloseButton.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FilterCloseButton.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.FilterCloseButton.Options.UseForeColor = true;
		this.gridViewItems.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
		this.gridViewItems.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FilterPanel.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FilterPanel.Options.UseForeColor = true;
		this.gridViewItems.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.gridViewItems.Appearance.FixedLine.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
		this.gridViewItems.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridViewItems.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(194, 194, 194);
		this.gridViewItems.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FooterPanel.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FooterPanel.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.FooterPanel.Options.UseForeColor = true;
		this.gridViewItems.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewItems.Appearance.GroupButton.Options.UseBackColor = true;
		this.gridViewItems.Appearance.GroupButton.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.GroupFooter.Options.UseBackColor = true;
		this.gridViewItems.Appearance.GroupFooter.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.GroupFooter.Options.UseForeColor = true;
		this.gridViewItems.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
		this.gridViewItems.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.GroupPanel.Options.UseBackColor = true;
		this.gridViewItems.Appearance.GroupPanel.Options.UseForeColor = true;
		this.gridViewItems.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.GroupRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.GroupRow.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.GroupRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewItems.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.HeaderPanel.Options.UseBackColor = true;
		this.gridViewItems.Appearance.HeaderPanel.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.HeaderPanel.Options.UseForeColor = true;
		this.gridViewItems.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gainsboro;
		this.gridViewItems.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.gridViewItems.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.HideSelectionRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(175, 175, 175);
		this.gridViewItems.Appearance.HorzLine.Options.UseBackColor = true;
		this.gridViewItems.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.OddRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.OddRow.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.OddRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
		this.gridViewItems.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5f);
		this.gridViewItems.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.gridViewItems.Appearance.Preview.Options.UseBackColor = true;
		this.gridViewItems.Appearance.Preview.Options.UseFont = true;
		this.gridViewItems.Appearance.Preview.Options.UseForeColor = true;
		this.gridViewItems.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.Row.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.Row.Options.UseBackColor = true;
		this.gridViewItems.Appearance.Row.Options.UseBorderColor = true;
		this.gridViewItems.Appearance.Row.Options.UseForeColor = true;
		this.gridViewItems.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewItems.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
		this.gridViewItems.Appearance.RowSeparator.Options.UseBackColor = true;
		this.gridViewItems.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(215, 215, 215);
		this.gridViewItems.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
		this.gridViewItems.Appearance.TopNewRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(175, 175, 175);
		this.gridViewItems.Appearance.VertLine.Options.UseBackColor = true;
		this.gridViewItems.GridControl = this.gridItems;
		this.gridViewItems.Name = "gridViewItems";
		this.gridViewItems.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridViewItems.OptionsBehavior.Editable = false;
		this.gridViewItems.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewItems.OptionsView.EnableAppearanceEvenRow = true;
		this.gridViewItems.OptionsView.EnableAppearanceOddRow = true;
		this.xtraTabControl4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.xtraTabControl4.Location = new System.Drawing.Point(4, 6);
		this.xtraTabControl4.Name = "xtraTabControl4";
		this.xtraTabControl4.SelectedTabPage = this.tabNewOrders;
		this.xtraTabControl4.Size = new System.Drawing.Size(425, 478);
		this.xtraTabControl4.TabIndex = 54;
		this.xtraTabControl4.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[1] { this.tabNewOrders });
		this.tabNewOrders.Controls.Add(this.txtSupplierId);
		this.tabNewOrders.Controls.Add(this.txtSupplyId);
		this.tabNewOrders.Controls.Add(this.labelControl39);
		this.tabNewOrders.Controls.Add(this.labelControl41);
		this.tabNewOrders.Controls.Add(this.textEdit1);
		this.tabNewOrders.Controls.Add(this.labelControl42);
		this.tabNewOrders.Controls.Add(this.labelControl43);
		this.tabNewOrders.Controls.Add(this.labelControl44);
		this.tabNewOrders.Controls.Add(this.gridSales);
		this.tabNewOrders.Controls.Add(this.dtOrderDate);
		this.tabNewOrders.Controls.Add(this.lookUpSupplier);
		this.tabNewOrders.Name = "tabNewOrders";
		this.tabNewOrders.Size = new System.Drawing.Size(419, 452);
		this.tabNewOrders.Text = "Supply details";
		this.txtSupplierId.Location = new System.Drawing.Point(75, 37);
		this.txtSupplierId.Name = "txtSupplierId";
		this.txtSupplierId.Properties.ReadOnly = true;
		this.txtSupplierId.Size = new System.Drawing.Size(340, 20);
		this.txtSupplierId.TabIndex = 19;
		this.txtSupplyId.Location = new System.Drawing.Point(75, 59);
		this.txtSupplyId.Name = "txtSupplyId";
		this.txtSupplyId.Size = new System.Drawing.Size(129, 20);
		this.txtSupplyId.TabIndex = 18;
		this.labelControl39.Location = new System.Drawing.Point(3, 22);
		this.labelControl39.Name = "labelControl39";
		this.labelControl39.Size = new System.Drawing.Size(65, 13);
		this.labelControl39.TabIndex = 17;
		this.labelControl39.Text = "Find Supplier:";
		this.labelControl41.Location = new System.Drawing.Point(218, 22);
		this.labelControl41.Name = "labelControl41";
		this.labelControl41.Size = new System.Drawing.Size(27, 13);
		this.labelControl41.TabIndex = 12;
		this.labelControl41.Text = "Date:";
		this.textEdit1.Location = new System.Drawing.Point(276, 59);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Size = new System.Drawing.Size(139, 20);
		this.textEdit1.TabIndex = 11;
		this.labelControl42.Location = new System.Drawing.Point(218, 66);
		this.labelControl42.Name = "labelControl42";
		this.labelControl42.Size = new System.Drawing.Size(52, 13);
		this.labelControl42.TabIndex = 10;
		this.labelControl42.Text = "Item code:";
		this.labelControl43.Location = new System.Drawing.Point(3, 44);
		this.labelControl43.Name = "labelControl43";
		this.labelControl43.Size = new System.Drawing.Size(42, 13);
		this.labelControl43.TabIndex = 9;
		this.labelControl43.Text = "Supplier:";
		this.labelControl44.Location = new System.Drawing.Point(4, 66);
		this.labelControl44.Name = "labelControl44";
		this.labelControl44.Size = new System.Drawing.Size(55, 13);
		this.labelControl44.TabIndex = 8;
		this.labelControl44.Text = "Invoice No:";
		this.gridSales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridSales.Location = new System.Drawing.Point(4, 86);
		this.gridSales.MainView = this.gridViewSales;
		this.gridSales.Name = "gridSales";
		this.gridSales.Size = new System.Drawing.Size(411, 360);
		this.gridSales.TabIndex = 1;
		this.gridSales.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSales });
		this.gridViewSales.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.ColumnFilterButton.Options.UseBackColor = true;
		this.gridViewSales.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.ColumnFilterButton.Options.UseForeColor = true;
		this.gridViewSales.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
		this.gridViewSales.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
		this.gridViewSales.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
		this.gridViewSales.Appearance.Empty.Options.UseBackColor = true;
		this.gridViewSales.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(248, 248, 248);
		this.gridViewSales.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.EvenRow.Options.UseForeColor = true;
		this.gridViewSales.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.FilterCloseButton.Options.UseBackColor = true;
		this.gridViewSales.Appearance.FilterCloseButton.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.FilterCloseButton.Options.UseForeColor = true;
		this.gridViewSales.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
		this.gridViewSales.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.FilterPanel.Options.UseBackColor = true;
		this.gridViewSales.Appearance.FilterPanel.Options.UseForeColor = true;
		this.gridViewSales.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.gridViewSales.Appearance.FixedLine.Options.UseBackColor = true;
		this.gridViewSales.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
		this.gridViewSales.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewSales.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridViewSales.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(194, 194, 194);
		this.gridViewSales.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridViewSales.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.FooterPanel.Options.UseBackColor = true;
		this.gridViewSales.Appearance.FooterPanel.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.FooterPanel.Options.UseForeColor = true;
		this.gridViewSales.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(243, 174, 66);
		this.gridViewSales.Appearance.GroupButton.Options.UseBackColor = true;
		this.gridViewSales.Appearance.GroupButton.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.GroupFooter.Options.UseBackColor = true;
		this.gridViewSales.Appearance.GroupFooter.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.GroupFooter.Options.UseForeColor = true;
		this.gridViewSales.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
		this.gridViewSales.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.GroupPanel.Options.UseBackColor = true;
		this.gridViewSales.Appearance.GroupPanel.Options.UseForeColor = true;
		this.gridViewSales.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.GroupRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.GroupRow.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.GroupRow.Options.UseForeColor = true;
		this.gridViewSales.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(255, 193, 95);
		this.gridViewSales.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.HeaderPanel.Options.UseBackColor = true;
		this.gridViewSales.Appearance.HeaderPanel.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.HeaderPanel.Options.UseForeColor = true;
		this.gridViewSales.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gainsboro;
		this.gridViewSales.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.gridViewSales.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.HideSelectionRow.Options.UseForeColor = true;
		this.gridViewSales.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(175, 175, 175);
		this.gridViewSales.Appearance.HorzLine.Options.UseBackColor = true;
		this.gridViewSales.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.OddRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.OddRow.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.OddRow.Options.UseForeColor = true;
		this.gridViewSales.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
		this.gridViewSales.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5f);
		this.gridViewSales.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
		this.gridViewSales.Appearance.Preview.Options.UseBackColor = true;
		this.gridViewSales.Appearance.Preview.Options.UseFont = true;
		this.gridViewSales.Appearance.Preview.Options.UseForeColor = true;
		this.gridViewSales.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.Row.BorderColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.Row.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.Row.Options.UseBackColor = true;
		this.gridViewSales.Appearance.Row.Options.UseBorderColor = true;
		this.gridViewSales.Appearance.Row.Options.UseForeColor = true;
		this.gridViewSales.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
		this.gridViewSales.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
		this.gridViewSales.Appearance.RowSeparator.Options.UseBackColor = true;
		this.gridViewSales.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(215, 215, 215);
		this.gridViewSales.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewSales.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridViewSales.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
		this.gridViewSales.Appearance.TopNewRow.Options.UseBackColor = true;
		this.gridViewSales.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(175, 175, 175);
		this.gridViewSales.Appearance.VertLine.Options.UseBackColor = true;
		this.gridViewSales.GridControl = this.gridSales;
		this.gridViewSales.Name = "gridViewSales";
		this.gridViewSales.OptionsBehavior.Editable = false;
		this.gridViewSales.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewSales.OptionsCustomization.AllowGroup = false;
		this.gridViewSales.OptionsView.EnableAppearanceEvenRow = true;
		this.gridViewSales.OptionsView.EnableAppearanceOddRow = true;
		this.gridViewSales.OptionsView.ShowFooter = true;
		this.gridViewSales.OptionsView.ShowGroupPanel = false;
		this.dtOrderDate.EditValue = null;
		this.dtOrderDate.Location = new System.Drawing.Point(276, 15);
		this.dtOrderDate.Name = "dtOrderDate";
		this.dtOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtOrderDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
		this.dtOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtOrderDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtOrderDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtOrderDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
		this.dtOrderDate.Properties.Mask.EditMask = "u";
		this.dtOrderDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
		this.dtOrderDate.Size = new System.Drawing.Size(139, 20);
		this.dtOrderDate.TabIndex = 13;
		this.lookUpSupplier.Location = new System.Drawing.Point(75, 15);
		this.lookUpSupplier.Name = "lookUpSupplier";
		this.lookUpSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpSupplier.Properties.NullText = "";
		this.lookUpSupplier.Size = new System.Drawing.Size(129, 20);
		this.lookUpSupplier.TabIndex = 16;
		this.simpleButton30.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton30.Location = new System.Drawing.Point(764, 554);
		this.simpleButton30.Name = "simpleButton30";
		this.simpleButton30.Size = new System.Drawing.Size(75, 23);
		this.simpleButton30.TabIndex = 40;
		this.simpleButton30.Text = "Delete";
		this.simpleButton29.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton29.Location = new System.Drawing.Point(683, 554);
		this.simpleButton29.Name = "simpleButton29";
		this.simpleButton29.Size = new System.Drawing.Size(75, 23);
		this.simpleButton29.TabIndex = 39;
		this.simpleButton29.Text = "New";
		this.tabStudentAdmission.Controls.Add(this.lblGuardianId);
		this.tabStudentAdmission.Controls.Add(this.lblStudyStatus);
		this.tabStudentAdmission.Controls.Add(this.lblBursaryStatus);
		this.tabStudentAdmission.Controls.Add(this.groupControl5);
		this.tabStudentAdmission.Controls.Add(this.picStudent);
		this.tabStudentAdmission.Controls.Add(this.xtraTabControl2);
		this.tabStudentAdmission.Controls.Add(this.layoutPersonData);
		this.tabStudentAdmission.Controls.Add(this.panelControl1);
		this.tabStudentAdmission.Name = "tabStudentAdmission";
		this.tabStudentAdmission.Size = new System.Drawing.Size(851, 484);
		this.tabStudentAdmission.Text = "Students Admission";
		this.lblGuardianId.Location = new System.Drawing.Point(657, 158);
		this.lblGuardianId.Name = "lblGuardianId";
		this.lblGuardianId.Size = new System.Drawing.Size(75, 13);
		this.lblGuardianId.TabIndex = 8;
		this.lblGuardianId.Text = "labelControl121";
		this.lblGuardianId.Visible = false;
		this.lblStudyStatus.Location = new System.Drawing.Point(488, 158);
		this.lblStudyStatus.Name = "lblStudyStatus";
		this.lblStudyStatus.Size = new System.Drawing.Size(75, 13);
		this.lblStudyStatus.TabIndex = 7;
		this.lblStudyStatus.Text = "labelControl120";
		this.lblStudyStatus.Visible = false;
		this.lblBursaryStatus.Location = new System.Drawing.Point(337, 160);
		this.lblBursaryStatus.Name = "lblBursaryStatus";
		this.lblBursaryStatus.Size = new System.Drawing.Size(75, 13);
		this.lblBursaryStatus.TabIndex = 6;
		this.lblBursaryStatus.Text = "labelControl119";
		this.lblBursaryStatus.Visible = false;
		this.groupControl5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl5.Controls.Add(this.btnFind);
		this.groupControl5.Controls.Add(this.btnEditStudent);
		this.groupControl5.Controls.Add(this.txtStudentNumberSearch);
		this.groupControl5.Controls.Add(this.txtStudentNameSearch);
		this.groupControl5.Controls.Add(this.labelControl4);
		this.groupControl5.Controls.Add(this.labelControl3);
		this.groupControl5.Location = new System.Drawing.Point(3, 3);
		this.groupControl5.Name = "groupControl5";
		this.groupControl5.Size = new System.Drawing.Size(163, 481);
		this.groupControl5.TabIndex = 5;
		this.groupControl5.Text = "Current student";
		this.btnFind.Location = new System.Drawing.Point(42, 76);
		this.btnFind.Name = "btnFind";
		this.btnFind.Size = new System.Drawing.Size(62, 23);
		this.btnFind.TabIndex = 10;
		this.btnFind.TabStop = false;
		this.btnFind.Text = "Find";
		this.btnEditStudent.Location = new System.Drawing.Point(110, 76);
		this.btnEditStudent.Name = "btnEditStudent";
		this.btnEditStudent.Size = new System.Drawing.Size(48, 23);
		this.btnEditStudent.TabIndex = 9;
		this.btnEditStudent.TabStop = false;
		this.btnEditStudent.Text = "Edit";
		this.txtStudentNumberSearch.Location = new System.Drawing.Point(42, 53);
		this.txtStudentNumberSearch.MenuManager = this.ribbon;
		this.txtStudentNumberSearch.Name = "txtStudentNumberSearch";
		this.txtStudentNumberSearch.Properties.ReadOnly = true;
		this.txtStudentNumberSearch.Size = new System.Drawing.Size(116, 20);
		this.txtStudentNumberSearch.TabIndex = 7;
		this.txtStudentNumberSearch.TabStop = false;
		this.txtStudentNameSearch.Location = new System.Drawing.Point(42, 25);
		this.txtStudentNameSearch.MenuManager = this.ribbon;
		this.txtStudentNameSearch.Name = "txtStudentNameSearch";
		this.txtStudentNameSearch.Properties.ReadOnly = true;
		this.txtStudentNameSearch.Size = new System.Drawing.Size(117, 20);
		this.txtStudentNameSearch.TabIndex = 8;
		this.txtStudentNameSearch.TabStop = false;
		this.labelControl4.Location = new System.Drawing.Point(3, 60);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(33, 13);
		this.labelControl4.TabIndex = 6;
		this.labelControl4.Text = "Rg. No";
		this.labelControl3.Location = new System.Drawing.Point(5, 28);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(27, 13);
		this.labelControl3.TabIndex = 5;
		this.labelControl3.Text = "Name";
		this.picStudent.Location = new System.Drawing.Point(171, 3);
		this.picStudent.MenuManager = this.ribbon;
		this.picStudent.Name = "picStudent";
		this.picStudent.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStudent.Size = new System.Drawing.Size(159, 166);
		this.picStudent.TabIndex = 4;
		this.picStudent.TabStop = true;
		this.xtraTabControl2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.xtraTabControl2.Location = new System.Drawing.Point(171, 175);
		this.xtraTabControl2.Name = "xtraTabControl2";
		this.xtraTabControl2.SelectedTabPage = this.tabStudyInformation;
		this.xtraTabControl2.Size = new System.Drawing.Size(680, 274);
		this.xtraTabControl2.TabIndex = 3;
		this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[1] { this.tabStudyInformation });
		this.tabStudyInformation.Controls.Add(this.layoutFeesStatus);
		this.tabStudyInformation.Controls.Add(this.groupControl3);
		this.tabStudyInformation.Controls.Add(this.cboStream);
		this.tabStudyInformation.Controls.Add(this.labelControl2);
		this.tabStudyInformation.Controls.Add(this.cboClass);
		this.tabStudyInformation.Controls.Add(this.groupControl4);
		this.tabStudyInformation.Controls.Add(this.labelControl1);
		this.tabStudyInformation.Name = "tabStudyInformation";
		this.tabStudyInformation.Size = new System.Drawing.Size(674, 248);
		this.tabStudyInformation.Text = "Study information";
		this.layoutFeesStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutFeesStatus.Controls.Add(this.cboStatus);
		this.layoutFeesStatus.Controls.Add(this.txtRequiredFees);
		this.layoutFeesStatus.Controls.Add(this.memoEdit1);
		this.layoutFeesStatus.Controls.Add(this.cboBursaryProvider);
		this.layoutFeesStatus.Location = new System.Drawing.Point(167, 0);
		this.layoutFeesStatus.Name = "layoutFeesStatus";
		this.layoutFeesStatus.Root = this.layoutControlGroup2;
		this.layoutFeesStatus.Size = new System.Drawing.Size(508, 248);
		this.layoutFeesStatus.TabIndex = 7;
		this.layoutFeesStatus.Text = "layoutControl1";
		this.cboStatus.EditValue = "Active";
		this.cboStatus.Location = new System.Drawing.Point(91, 224);
		this.cboStatus.MenuManager = this.ribbon;
		this.cboStatus.Name = "cboStatus";
		this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStatus.Properties.Items.AddRange(new object[3] { "Active", "Suspended", "Discontinued" });
		this.cboStatus.Size = new System.Drawing.Size(413, 20);
		this.cboStatus.StyleController = this.layoutFeesStatus;
		this.cboStatus.TabIndex = 19;
		this.txtRequiredFees.Location = new System.Drawing.Point(392, 4);
		this.txtRequiredFees.MenuManager = this.ribbon;
		this.txtRequiredFees.Name = "txtRequiredFees";
		this.txtRequiredFees.Properties.Mask.EditMask = "n";
		this.txtRequiredFees.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtRequiredFees.Size = new System.Drawing.Size(112, 20);
		this.txtRequiredFees.StyleController = this.layoutFeesStatus;
		this.txtRequiredFees.TabIndex = 17;
		this.memoEdit1.Location = new System.Drawing.Point(4, 44);
		this.memoEdit1.MenuManager = this.ribbon;
		this.memoEdit1.Name = "memoEdit1";
		this.memoEdit1.Size = new System.Drawing.Size(500, 176);
		this.memoEdit1.StyleController = this.layoutFeesStatus;
		this.memoEdit1.TabIndex = 18;
		this.cboBursaryProvider.Location = new System.Drawing.Point(91, 4);
		this.cboBursaryProvider.MenuManager = this.ribbon;
		this.cboBursaryProvider.Name = "cboBursaryProvider";
		this.cboBursaryProvider.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboBursaryProvider.Size = new System.Drawing.Size(210, 20);
		this.cboBursaryProvider.StyleController = this.layoutFeesStatus;
		this.cboBursaryProvider.TabIndex = 16;
		this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup2.GroupBordersVisible = false;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem3, this.layoutControlItem15, this.layoutControlItem16, this.layoutControlItem36 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup2.Size = new System.Drawing.Size(508, 248);
		this.layoutControlGroup2.Text = "layoutControlGroup2";
		this.layoutControlGroup2.TextVisible = false;
		this.layoutControlItem3.Control = this.cboBursaryProvider;
		this.layoutControlItem3.CustomizationFormText = "Bursary provider:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(301, 24);
		this.layoutControlItem3.Text = "Bursary provider:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 13);
		this.layoutControlItem15.Control = this.memoEdit1;
		this.layoutControlItem15.CustomizationFormText = "Notes";
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(504, 196);
		this.layoutControlItem15.Text = "Notes";
		this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem15.TextSize = new System.Drawing.Size(84, 13);
		this.layoutControlItem16.Control = this.txtRequiredFees;
		this.layoutControlItem16.CustomizationFormText = "Tuition fees:";
		this.layoutControlItem16.Location = new System.Drawing.Point(301, 0);
		this.layoutControlItem16.Name = "layoutControlItem16";
		this.layoutControlItem16.Size = new System.Drawing.Size(203, 24);
		this.layoutControlItem16.Text = "Tuition fees:";
		this.layoutControlItem16.TextSize = new System.Drawing.Size(84, 13);
		this.layoutControlItem36.Control = this.cboStatus;
		this.layoutControlItem36.CustomizationFormText = "Student status";
		this.layoutControlItem36.Location = new System.Drawing.Point(0, 220);
		this.layoutControlItem36.Name = "layoutControlItem36";
		this.layoutControlItem36.Size = new System.Drawing.Size(504, 24);
		this.layoutControlItem36.Text = "Student status";
		this.layoutControlItem36.TextSize = new System.Drawing.Size(84, 13);
		this.groupControl3.Controls.Add(this.radioGroupStudyStatus);
		this.groupControl3.Location = new System.Drawing.Point(3, 51);
		this.groupControl3.Name = "groupControl3";
		this.groupControl3.Size = new System.Drawing.Size(162, 62);
		this.groupControl3.TabIndex = 5;
		this.groupControl3.Text = "Study status";
		this.radioGroupStudyStatus.Location = new System.Drawing.Point(2, 22);
		this.radioGroupStudyStatus.MenuManager = this.ribbon;
		this.radioGroupStudyStatus.Name = "radioGroupStudyStatus";
		this.radioGroupStudyStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupStudyStatus.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupStudyStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupStudyStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Border"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Day")
		});
		this.radioGroupStudyStatus.Size = new System.Drawing.Size(113, 40);
		this.radioGroupStudyStatus.TabIndex = 14;
		this.cboStream.Location = new System.Drawing.Point(46, 25);
		this.cboStream.MenuManager = this.ribbon;
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Size = new System.Drawing.Size(119, 20);
		this.cboStream.TabIndex = 13;
		this.labelControl2.Location = new System.Drawing.Point(4, 32);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(34, 13);
		this.labelControl2.TabIndex = 3;
		this.labelControl2.Text = "Stream";
		this.cboClass.Location = new System.Drawing.Point(46, 3);
		this.cboClass.MenuManager = this.ribbon;
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Size = new System.Drawing.Size(119, 20);
		this.cboClass.TabIndex = 12;
		this.groupControl4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl4.Controls.Add(this.radioGroupBursaryStatus);
		this.groupControl4.Location = new System.Drawing.Point(4, 119);
		this.groupControl4.Name = "groupControl4";
		this.groupControl4.Size = new System.Drawing.Size(161, 126);
		this.groupControl4.TabIndex = 6;
		this.groupControl4.Text = "Bursary status";
		this.radioGroupBursaryStatus.Location = new System.Drawing.Point(2, 22);
		this.radioGroupBursaryStatus.MenuManager = this.ribbon;
		this.radioGroupBursaryStatus.Name = "radioGroupBursaryStatus";
		this.radioGroupBursaryStatus.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupBursaryStatus.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupBursaryStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupBursaryStatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[3]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "None"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Partial"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Full")
		});
		this.radioGroupBursaryStatus.Size = new System.Drawing.Size(93, 56);
		this.radioGroupBursaryStatus.TabIndex = 15;
		this.labelControl1.Location = new System.Drawing.Point(3, 10);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(25, 13);
		this.labelControl1.TabIndex = 1;
		this.labelControl1.Text = "Class";
		this.layoutPersonData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutPersonData.Controls.Add(this.txtGuardianContact);
		this.layoutPersonData.Controls.Add(this.cboReligion);
		this.layoutPersonData.Controls.Add(this.cboHall);
		this.layoutPersonData.Controls.Add(this.cboNationality);
		this.layoutPersonData.Controls.Add(this.txtFormerSchool);
		this.layoutPersonData.Controls.Add(this.txtAdmissionDate);
		this.layoutPersonData.Controls.Add(this.cboSex);
		this.layoutPersonData.Controls.Add(this.txtGurdianAddress);
		this.layoutPersonData.Controls.Add(this.txtGuardian);
		this.layoutPersonData.Controls.Add(this.txtLastName);
		this.layoutPersonData.Controls.Add(this.txtStudentNumber);
		this.layoutPersonData.Controls.Add(this.txtFirstName);
		this.layoutPersonData.Location = new System.Drawing.Point(328, 0);
		this.layoutPersonData.Margin = new System.Windows.Forms.Padding(0);
		this.layoutPersonData.Name = "layoutPersonData";
		this.layoutPersonData.Root = this.layout;
		this.layoutPersonData.Size = new System.Drawing.Size(525, 153);
		this.layoutPersonData.TabIndex = 2;
		this.layoutPersonData.Text = "layoutControl1";
		this.txtGuardianContact.Location = new System.Drawing.Point(344, 101);
		this.txtGuardianContact.MenuManager = this.ribbon;
		this.txtGuardianContact.Name = "txtGuardianContact";
		this.txtGuardianContact.Size = new System.Drawing.Size(176, 20);
		this.txtGuardianContact.StyleController = this.layoutPersonData;
		this.txtGuardianContact.TabIndex = 9;
		this.cboReligion.Location = new System.Drawing.Point(344, 77);
		this.cboReligion.MenuManager = this.ribbon;
		this.cboReligion.Name = "cboReligion";
		this.cboReligion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboReligion.Properties.Items.AddRange(new object[7] { "Religion", "Catholic", "Moslem", "Anglican", "SDA", "Born-Again", "Others" });
		this.cboReligion.Size = new System.Drawing.Size(176, 20);
		this.cboReligion.StyleController = this.layoutPersonData;
		this.cboReligion.TabIndex = 7;
		this.cboHall.Location = new System.Drawing.Point(344, 53);
		this.cboHall.MenuManager = this.ribbon;
		this.cboHall.Name = "cboHall";
		this.cboHall.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboHall.Size = new System.Drawing.Size(176, 20);
		this.cboHall.StyleController = this.layoutPersonData;
		this.cboHall.TabIndex = 6;
		this.cboNationality.Location = new System.Drawing.Point(344, 5);
		this.cboNationality.MenuManager = this.ribbon;
		this.cboNationality.Name = "cboNationality";
		this.cboNationality.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboNationality.Properties.Items.AddRange(new object[53]
		{
			"Algeria", "Angola", "Benin", "Botswana", "Burkina Faso", "Burundi", "Cameroon", "Cape Verde", "Central African Republic", "Chad",
			"Comoros", "Cote d’lvoire", "Dem. Rep. of the Congo", "Djibouti", "Egypt", "Equatorial Guinea", "Eritrea", "Ethiopia", "Gabon", "Ghana",
			"Guinea", "Guinea-Bissau", "Kenya", "Lesotho", "Liberia", "Libya", "Madagascar", "Malawi", "Mali", "Mauritania",
			"Mauritius", "Morocco", "Mozambique", "Namibia", "Niger", "Nigeria", "Republic of Congo", "Rwanda", "Sao Tome and Principe", "Senegal",
			"Seychelles", "Sierra Leone", "Somalia", "South Africa", "Sudan", "Swaziland", "Tanzania", "The Gambia", "Togo", "Tunisia",
			"Uganda", "Zambia", "Zimbabwe"
		});
		this.cboNationality.Size = new System.Drawing.Size(176, 20);
		this.cboNationality.StyleController = this.layoutPersonData;
		this.cboNationality.TabIndex = 4;
		this.txtFormerSchool.Location = new System.Drawing.Point(344, 125);
		this.txtFormerSchool.MenuManager = this.ribbon;
		this.txtFormerSchool.Name = "txtFormerSchool";
		this.txtFormerSchool.Size = new System.Drawing.Size(176, 20);
		this.txtFormerSchool.StyleController = this.layoutPersonData;
		this.txtFormerSchool.TabIndex = 11;
		this.txtAdmissionDate.Location = new System.Drawing.Point(84, 77);
		this.txtAdmissionDate.MenuManager = this.ribbon;
		this.txtAdmissionDate.Name = "txtAdmissionDate";
		this.txtAdmissionDate.Size = new System.Drawing.Size(177, 20);
		this.txtAdmissionDate.StyleController = this.layoutPersonData;
		this.txtAdmissionDate.TabIndex = 3;
		this.cboSex.Location = new System.Drawing.Point(345, 29);
		this.cboSex.MenuManager = this.ribbon;
		this.cboSex.Name = "cboSex";
		this.cboSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSex.Properties.Items.AddRange(new object[3] { "-Sex-", "Female", "Male" });
		this.cboSex.Size = new System.Drawing.Size(175, 20);
		this.cboSex.StyleController = this.layoutPersonData;
		this.cboSex.TabIndex = 5;
		this.txtGurdianAddress.Location = new System.Drawing.Point(84, 125);
		this.txtGurdianAddress.MenuManager = this.ribbon;
		this.txtGurdianAddress.Name = "txtGurdianAddress";
		this.txtGurdianAddress.Size = new System.Drawing.Size(177, 20);
		this.txtGurdianAddress.StyleController = this.layoutPersonData;
		this.txtGurdianAddress.TabIndex = 10;
		this.txtGuardian.Location = new System.Drawing.Point(84, 101);
		this.txtGuardian.MenuManager = this.ribbon;
		this.txtGuardian.Name = "txtGuardian";
		this.txtGuardian.Size = new System.Drawing.Size(177, 20);
		this.txtGuardian.StyleController = this.layoutPersonData;
		this.txtGuardian.TabIndex = 8;
		this.txtLastName.Location = new System.Drawing.Point(84, 29);
		this.txtLastName.MenuManager = this.ribbon;
		this.txtLastName.Name = "txtLastName";
		this.txtLastName.Size = new System.Drawing.Size(178, 20);
		this.txtLastName.StyleController = this.layoutPersonData;
		this.txtLastName.TabIndex = 1;
		this.txtStudentNumber.Location = new System.Drawing.Point(84, 5);
		this.txtStudentNumber.MenuManager = this.ribbon;
		this.txtStudentNumber.Name = "txtStudentNumber";
		this.txtStudentNumber.Size = new System.Drawing.Size(177, 20);
		this.txtStudentNumber.StyleController = this.layoutPersonData;
		this.txtStudentNumber.TabIndex = 0;
		this.txtFirstName.Location = new System.Drawing.Point(84, 53);
		this.txtFirstName.MenuManager = this.ribbon;
		this.txtFirstName.Name = "txtFirstName";
		this.txtFirstName.Size = new System.Drawing.Size(177, 20);
		this.txtFirstName.StyleController = this.layoutPersonData;
		this.txtFirstName.TabIndex = 2;
		this.layout.CustomizationFormText = "layout";
		this.layout.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layout.GroupBordersVisible = false;
		this.layout.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[12]
		{
			this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem13, this.layoutControlItem11, this.layoutControlItem6, this.layoutControlItem14, this.layoutControlItem12, this.layoutControlItem9, this.layoutControlItem8,
			this.layoutControlItem10, this.layoutControlItem34
		});
		this.layout.Location = new System.Drawing.Point(0, 0);
		this.layout.Name = "layout";
		this.layout.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layout.Size = new System.Drawing.Size(525, 153);
		this.layout.Text = "layout";
		this.layout.TextVisible = false;
		this.layoutControlItem4.Control = this.txtStudentNumber;
		this.layoutControlItem4.CustomizationFormText = "Student No.";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem4.Text = "Student No.";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem5.Control = this.txtLastName;
		this.layoutControlItem5.CustomizationFormText = "Surname";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(261, 24);
		this.layoutControlItem5.Text = "Surname:";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem7.Control = this.txtFirstName;
		this.layoutControlItem7.CustomizationFormText = "Sex";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem7.Text = "Other names";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem13.Control = this.txtGurdianAddress;
		this.layoutControlItem13.CustomizationFormText = "Kin address";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(260, 27);
		this.layoutControlItem13.Text = "Kin address:";
		this.layoutControlItem13.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem11.Control = this.txtGuardian;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem11.Text = "Next of kin:";
		this.layoutControlItem11.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem6.Control = this.cboSex;
		this.layoutControlItem6.CustomizationFormText = "Sex:";
		this.layoutControlItem6.Location = new System.Drawing.Point(261, 24);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(258, 24);
		this.layoutControlItem6.Text = "Sex:";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem14.Control = this.txtFormerSchool;
		this.layoutControlItem14.CustomizationFormText = "Former school:";
		this.layoutControlItem14.Location = new System.Drawing.Point(260, 120);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(259, 27);
		this.layoutControlItem14.Text = "Former school:";
		this.layoutControlItem14.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem12.Control = this.txtAdmissionDate;
		this.layoutControlItem12.CustomizationFormText = "Admission date:";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem12.Text = "Admission date:";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem9.Control = this.cboNationality;
		this.layoutControlItem9.CustomizationFormText = "Home country:";
		this.layoutControlItem9.Location = new System.Drawing.Point(260, 0);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(259, 24);
		this.layoutControlItem9.Text = "Home country:";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem8.Control = this.cboHall;
		this.layoutControlItem8.CustomizationFormText = "House:";
		this.layoutControlItem8.Location = new System.Drawing.Point(260, 48);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(259, 24);
		this.layoutControlItem8.Text = "House:";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem10.Control = this.cboReligion;
		this.layoutControlItem10.CustomizationFormText = "Religion:";
		this.layoutControlItem10.Location = new System.Drawing.Point(260, 72);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(259, 24);
		this.layoutControlItem10.Text = "Religion:";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(76, 13);
		this.layoutControlItem34.Control = this.txtGuardianContact;
		this.layoutControlItem34.CustomizationFormText = "Kin contact:";
		this.layoutControlItem34.Location = new System.Drawing.Point(260, 96);
		this.layoutControlItem34.Name = "layoutControlItem34";
		this.layoutControlItem34.Size = new System.Drawing.Size(259, 24);
		this.layoutControlItem34.Text = "Kin contact:";
		this.layoutControlItem34.TextSize = new System.Drawing.Size(76, 13);
		this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl1.Appearance.Options.UseBackColor = true;
		this.panelControl1.Controls.Add(this.simpleButton2);
		this.panelControl1.Controls.Add(this.simpleButton1);
		this.panelControl1.Controls.Add(this.btnUpdate);
		this.panelControl1.Controls.Add(this.btnSave);
		this.panelControl1.Location = new System.Drawing.Point(171, 449);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(678, 35);
		this.panelControl1.TabIndex = 1;
		this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.simpleButton2.Location = new System.Drawing.Point(6, 6);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(93, 23);
		this.simpleButton2.TabIndex = 3;
		this.simpleButton2.TabStop = false;
		this.simpleButton2.Text = "Academic records";
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.simpleButton1.Location = new System.Drawing.Point(105, 6);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(95, 23);
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.TabStop = false;
		this.simpleButton1.Text = "Account status";
		this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdate.Enabled = false;
		this.btnUpdate.Location = new System.Drawing.Point(518, 6);
		this.btnUpdate.Name = "btnUpdate";
		this.btnUpdate.Size = new System.Drawing.Size(75, 23);
		this.btnUpdate.TabIndex = 1;
		this.btnUpdate.TabStop = false;
		this.btnUpdate.Text = "Update";
		this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnSave.Location = new System.Drawing.Point(599, 6);
		this.btnSave.Name = "btnSave";
		this.btnSave.Size = new System.Drawing.Size(75, 23);
		this.btnSave.TabIndex = 20;
		this.btnSave.Text = "Save New";
		this.tabEmployeeAdmission.Controls.Add(this.layoutEmployeeData);
		this.tabEmployeeAdmission.Controls.Add(this.groupControl1);
		this.tabEmployeeAdmission.Controls.Add(this.picStaff);
		this.tabEmployeeAdmission.Controls.Add(this.xtraTabControl3);
		this.tabEmployeeAdmission.Controls.Add(this.panelControl3);
		this.tabEmployeeAdmission.Name = "tabEmployeeAdmission";
		this.tabEmployeeAdmission.Size = new System.Drawing.Size(851, 484);
		this.tabEmployeeAdmission.Text = "Employee Admission";
		this.layoutEmployeeData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutEmployeeData.Controls.Add(this.cboEmplHouse);
		this.layoutEmployeeData.Controls.Add(this.chkStatus);
		this.layoutEmployeeData.Controls.Add(this.txtEmplFormerEmployee);
		this.layoutEmployeeData.Controls.Add(this.textEdit22);
		this.layoutEmployeeData.Controls.Add(this.txtEmplAddress);
		this.layoutEmployeeData.Controls.Add(this.txtEmplContactNumber);
		this.layoutEmployeeData.Controls.Add(this.txtEmplFirstName);
		this.layoutEmployeeData.Controls.Add(this.txtStaffNumber);
		this.layoutEmployeeData.Controls.Add(this.dtEmplHireDate);
		this.layoutEmployeeData.Controls.Add(this.txtResponsibility);
		this.layoutEmployeeData.Controls.Add(this.txtQualification);
		this.layoutEmployeeData.Controls.Add(this.txtEmplLastName);
		this.layoutEmployeeData.Controls.Add(this.cboEmplSex);
		this.layoutEmployeeData.Location = new System.Drawing.Point(331, 0);
		this.layoutEmployeeData.Name = "layoutEmployeeData";
		this.layoutEmployeeData.Root = this.layoutControlGroup5;
		this.layoutEmployeeData.Size = new System.Drawing.Size(515, 156);
		this.layoutEmployeeData.TabIndex = 11;
		this.layoutEmployeeData.Text = "layoutControl1";
		this.cboEmplHouse.Location = new System.Drawing.Point(449, 29);
		this.cboEmplHouse.MenuManager = this.ribbon;
		this.cboEmplHouse.Name = "cboEmplHouse";
		this.cboEmplHouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboEmplHouse.Size = new System.Drawing.Size(61, 20);
		this.cboEmplHouse.StyleController = this.layoutEmployeeData;
		this.cboEmplHouse.TabIndex = 17;
		this.chkStatus.Location = new System.Drawing.Point(259, 5);
		this.chkStatus.MenuManager = this.ribbon;
		this.chkStatus.Name = "chkStatus";
		this.chkStatus.Properties.Caption = "Discontinued";
		this.chkStatus.Size = new System.Drawing.Size(251, 19);
		this.chkStatus.StyleController = this.layoutEmployeeData;
		this.chkStatus.TabIndex = 16;
		this.txtEmplFormerEmployee.Location = new System.Drawing.Point(294, 125);
		this.txtEmplFormerEmployee.MenuManager = this.ribbon;
		this.txtEmplFormerEmployee.Name = "txtEmplFormerEmployee";
		this.txtEmplFormerEmployee.Size = new System.Drawing.Size(216, 20);
		this.txtEmplFormerEmployee.StyleController = this.layoutEmployeeData;
		this.txtEmplFormerEmployee.TabIndex = 15;
		this.textEdit22.Location = new System.Drawing.Point(294, 101);
		this.textEdit22.MenuManager = this.ribbon;
		this.textEdit22.Name = "textEdit22";
		this.textEdit22.Size = new System.Drawing.Size(216, 20);
		this.textEdit22.StyleController = this.layoutEmployeeData;
		this.textEdit22.TabIndex = 14;
		this.txtEmplAddress.Location = new System.Drawing.Point(294, 77);
		this.txtEmplAddress.MenuManager = this.ribbon;
		this.txtEmplAddress.Name = "txtEmplAddress";
		this.txtEmplAddress.Size = new System.Drawing.Size(216, 20);
		this.txtEmplAddress.StyleController = this.layoutEmployeeData;
		this.txtEmplAddress.TabIndex = 13;
		this.txtEmplContactNumber.Location = new System.Drawing.Point(294, 53);
		this.txtEmplContactNumber.MenuManager = this.ribbon;
		this.txtEmplContactNumber.Name = "txtEmplContactNumber";
		this.txtEmplContactNumber.Size = new System.Drawing.Size(216, 20);
		this.txtEmplContactNumber.StyleController = this.layoutEmployeeData;
		this.txtEmplContactNumber.TabIndex = 12;
		this.txtEmplFirstName.Location = new System.Drawing.Point(95, 29);
		this.txtEmplFirstName.MenuManager = this.ribbon;
		this.txtEmplFirstName.Name = "txtEmplFirstName";
		this.txtEmplFirstName.Size = new System.Drawing.Size(105, 20);
		this.txtEmplFirstName.StyleController = this.layoutEmployeeData;
		this.txtEmplFirstName.TabIndex = 6;
		this.txtStaffNumber.Location = new System.Drawing.Point(95, 5);
		this.txtStaffNumber.MenuManager = this.ribbon;
		this.txtStaffNumber.Name = "txtStaffNumber";
		this.txtStaffNumber.Size = new System.Drawing.Size(160, 20);
		this.txtStaffNumber.StyleController = this.layoutEmployeeData;
		this.txtStaffNumber.TabIndex = 5;
		this.dtEmplHireDate.EditValue = null;
		this.dtEmplHireDate.Location = new System.Drawing.Point(95, 77);
		this.dtEmplHireDate.MenuManager = this.ribbon;
		this.dtEmplHireDate.Name = "dtEmplHireDate";
		this.dtEmplHireDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtEmplHireDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtEmplHireDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtEmplHireDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtEmplHireDate.Properties.Mask.EditMask = "";
		this.dtEmplHireDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.dtEmplHireDate.Size = new System.Drawing.Size(105, 20);
		this.dtEmplHireDate.StyleController = this.layoutEmployeeData;
		this.dtEmplHireDate.TabIndex = 9;
		this.txtResponsibility.Location = new System.Drawing.Point(95, 101);
		this.txtResponsibility.MenuManager = this.ribbon;
		this.txtResponsibility.Name = "txtResponsibility";
		this.txtResponsibility.Size = new System.Drawing.Size(105, 20);
		this.txtResponsibility.StyleController = this.layoutEmployeeData;
		this.txtResponsibility.TabIndex = 10;
		this.txtQualification.Location = new System.Drawing.Point(95, 125);
		this.txtQualification.MenuManager = this.ribbon;
		this.txtQualification.Name = "txtQualification";
		this.txtQualification.Size = new System.Drawing.Size(105, 20);
		this.txtQualification.StyleController = this.layoutEmployeeData;
		this.txtQualification.TabIndex = 11;
		this.txtEmplLastName.Location = new System.Drawing.Point(95, 53);
		this.txtEmplLastName.MenuManager = this.ribbon;
		this.txtEmplLastName.Name = "txtEmplLastName";
		this.txtEmplLastName.Size = new System.Drawing.Size(105, 20);
		this.txtEmplLastName.StyleController = this.layoutEmployeeData;
		this.txtEmplLastName.TabIndex = 8;
		this.cboEmplSex.Location = new System.Drawing.Point(294, 29);
		this.cboEmplSex.MenuManager = this.ribbon;
		this.cboEmplSex.Name = "cboEmplSex";
		this.cboEmplSex.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboEmplSex.Properties.Items.AddRange(new object[3] { "-Sex-", "Female", "Male" });
		this.cboEmplSex.Size = new System.Drawing.Size(61, 20);
		this.cboEmplSex.StyleController = this.layoutEmployeeData;
		this.cboEmplSex.TabIndex = 7;
		this.layoutControlGroup5.CustomizationFormText = "layout";
		this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup5.GroupBordersVisible = false;
		this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[13]
		{
			this.layoutControlItem23, this.layoutControlItem24, this.layoutControlItem25, this.layoutControlItem26, this.layoutControlItem27, this.layoutControlItem28, this.layoutControlItem29, this.layoutControlItem30, this.layoutControlItem31, this.layoutControlItem32,
			this.layoutControlItem33, this.layoutControlItem35, this.layoutControlItem93
		});
		this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup5.Name = "layout";
		this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layoutControlGroup5.Size = new System.Drawing.Size(515, 156);
		this.layoutControlGroup5.Text = "layout";
		this.layoutControlGroup5.TextVisible = false;
		this.layoutControlItem23.Control = this.txtStaffNumber;
		this.layoutControlItem23.CustomizationFormText = "Student No.";
		this.layoutControlItem23.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem23.Name = "layoutControlItem4";
		this.layoutControlItem23.Size = new System.Drawing.Size(254, 24);
		this.layoutControlItem23.Text = "Emp No.";
		this.layoutControlItem23.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem24.Control = this.txtEmplFirstName;
		this.layoutControlItem24.CustomizationFormText = "Surname";
		this.layoutControlItem24.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem24.Name = "layoutControlItem5";
		this.layoutControlItem24.Size = new System.Drawing.Size(199, 24);
		this.layoutControlItem24.Text = "Surname:";
		this.layoutControlItem24.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem25.Control = this.txtEmplLastName;
		this.layoutControlItem25.CustomizationFormText = "Sex";
		this.layoutControlItem25.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem25.Name = "layoutControlItem7";
		this.layoutControlItem25.Size = new System.Drawing.Size(199, 24);
		this.layoutControlItem25.Text = "Other names:";
		this.layoutControlItem25.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem26.Control = this.dtEmplHireDate;
		this.layoutControlItem26.CustomizationFormText = "Date of birth";
		this.layoutControlItem26.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem26.Name = "layoutControlItem8";
		this.layoutControlItem26.Size = new System.Drawing.Size(199, 24);
		this.layoutControlItem26.Text = "Date of hire:";
		this.layoutControlItem26.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem27.Control = this.txtResponsibility;
		this.layoutControlItem27.CustomizationFormText = "Religion";
		this.layoutControlItem27.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem27.Name = "layoutControlItem9";
		this.layoutControlItem27.Size = new System.Drawing.Size(199, 24);
		this.layoutControlItem27.Text = "Responsibility:";
		this.layoutControlItem27.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem28.Control = this.txtQualification;
		this.layoutControlItem28.CustomizationFormText = "Home Country";
		this.layoutControlItem28.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem28.Name = "layoutControlItem10";
		this.layoutControlItem28.Size = new System.Drawing.Size(199, 30);
		this.layoutControlItem28.Text = "Qualifications:";
		this.layoutControlItem28.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem29.Control = this.txtEmplFormerEmployee;
		this.layoutControlItem29.CustomizationFormText = "Former school";
		this.layoutControlItem29.Location = new System.Drawing.Point(199, 120);
		this.layoutControlItem29.Name = "layoutControlItem14";
		this.layoutControlItem29.Size = new System.Drawing.Size(310, 30);
		this.layoutControlItem29.Text = "Former employee:";
		this.layoutControlItem29.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem30.Control = this.textEdit22;
		this.layoutControlItem30.CustomizationFormText = "Kin address";
		this.layoutControlItem30.Location = new System.Drawing.Point(199, 96);
		this.layoutControlItem30.Name = "layoutControlItem13";
		this.layoutControlItem30.Size = new System.Drawing.Size(310, 24);
		this.layoutControlItem30.Text = "Email:";
		this.layoutControlItem30.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem31.Control = this.txtEmplAddress;
		this.layoutControlItem31.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem31.Location = new System.Drawing.Point(199, 72);
		this.layoutControlItem31.Name = "layoutControlItem12";
		this.layoutControlItem31.Size = new System.Drawing.Size(310, 24);
		this.layoutControlItem31.Text = "Address:";
		this.layoutControlItem31.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem32.Control = this.txtEmplContactNumber;
		this.layoutControlItem32.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem32.Location = new System.Drawing.Point(199, 48);
		this.layoutControlItem32.Name = "layoutControlItem11";
		this.layoutControlItem32.Size = new System.Drawing.Size(310, 24);
		this.layoutControlItem32.Text = "Telephone:";
		this.layoutControlItem32.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem33.Control = this.cboEmplSex;
		this.layoutControlItem33.CustomizationFormText = "Other names";
		this.layoutControlItem33.Location = new System.Drawing.Point(199, 24);
		this.layoutControlItem33.Name = "layoutControlItem6";
		this.layoutControlItem33.Size = new System.Drawing.Size(155, 24);
		this.layoutControlItem33.Text = "Sex:";
		this.layoutControlItem33.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem35.Control = this.chkStatus;
		this.layoutControlItem35.CustomizationFormText = "layoutControlItem35";
		this.layoutControlItem35.Location = new System.Drawing.Point(254, 0);
		this.layoutControlItem35.Name = "layoutControlItem35";
		this.layoutControlItem35.Size = new System.Drawing.Size(255, 24);
		this.layoutControlItem35.Text = "layoutControlItem35";
		this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem35.TextToControlDistance = 0;
		this.layoutControlItem35.TextVisible = false;
		this.layoutControlItem93.Control = this.cboEmplHouse;
		this.layoutControlItem93.CustomizationFormText = "House:";
		this.layoutControlItem93.Location = new System.Drawing.Point(354, 24);
		this.layoutControlItem93.Name = "layoutControlItem93";
		this.layoutControlItem93.Size = new System.Drawing.Size(155, 24);
		this.layoutControlItem93.Text = "House:";
		this.layoutControlItem93.TextSize = new System.Drawing.Size(87, 13);
		this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl1.Controls.Add(this.btnFindEmployee);
		this.groupControl1.Controls.Add(this.btnEmployEdit);
		this.groupControl1.Controls.Add(this.txtStaffNumberSearch);
		this.groupControl1.Controls.Add(this.txtStaffNameSearch);
		this.groupControl1.Controls.Add(this.labelControl5);
		this.groupControl1.Controls.Add(this.labelControl6);
		this.groupControl1.Location = new System.Drawing.Point(3, 3);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(163, 482);
		this.groupControl1.TabIndex = 10;
		this.groupControl1.Text = "Current employee";
		this.btnFindEmployee.Location = new System.Drawing.Point(42, 76);
		this.btnFindEmployee.Name = "btnFindEmployee";
		this.btnFindEmployee.Size = new System.Drawing.Size(62, 23);
		this.btnFindEmployee.TabIndex = 10;
		this.btnFindEmployee.Text = "Find";
		this.btnEmployEdit.Location = new System.Drawing.Point(110, 76);
		this.btnEmployEdit.Name = "btnEmployEdit";
		this.btnEmployEdit.Size = new System.Drawing.Size(48, 23);
		this.btnEmployEdit.TabIndex = 9;
		this.btnEmployEdit.Text = "Edit";
		this.txtStaffNumberSearch.Location = new System.Drawing.Point(42, 53);
		this.txtStaffNumberSearch.MenuManager = this.ribbon;
		this.txtStaffNumberSearch.Name = "txtStaffNumberSearch";
		this.txtStaffNumberSearch.Properties.ReadOnly = true;
		this.txtStaffNumberSearch.Size = new System.Drawing.Size(116, 20);
		this.txtStaffNumberSearch.TabIndex = 7;
		this.txtStaffNameSearch.Location = new System.Drawing.Point(42, 25);
		this.txtStaffNameSearch.MenuManager = this.ribbon;
		this.txtStaffNameSearch.Name = "txtStaffNameSearch";
		this.txtStaffNameSearch.Properties.ReadOnly = true;
		this.txtStaffNameSearch.Size = new System.Drawing.Size(117, 20);
		this.txtStaffNameSearch.TabIndex = 8;
		this.labelControl5.Location = new System.Drawing.Point(3, 60);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(33, 13);
		this.labelControl5.TabIndex = 6;
		this.labelControl5.Text = "Rg. No";
		this.labelControl6.Location = new System.Drawing.Point(5, 28);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(27, 13);
		this.labelControl6.TabIndex = 5;
		this.labelControl6.Text = "Name";
		this.picStaff.Location = new System.Drawing.Point(171, 3);
		this.picStaff.MenuManager = this.ribbon;
		this.picStaff.Name = "picStaff";
		this.picStaff.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStaff.Size = new System.Drawing.Size(159, 147);
		this.picStaff.TabIndex = 9;
		this.xtraTabControl3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.xtraTabControl3.Location = new System.Drawing.Point(171, 156);
		this.xtraTabControl3.Name = "xtraTabControl3";
		this.xtraTabControl3.SelectedTabPage = this.tabSalaryInformation;
		this.xtraTabControl3.Size = new System.Drawing.Size(673, 294);
		this.xtraTabControl3.TabIndex = 8;
		this.xtraTabControl3.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[1] { this.tabSalaryInformation });
		this.tabSalaryInformation.Controls.Add(this.layoutControl1);
		this.tabSalaryInformation.Controls.Add(this.groupControl8);
		this.tabSalaryInformation.Name = "tabSalaryInformation";
		this.tabSalaryInformation.Size = new System.Drawing.Size(667, 268);
		this.tabSalaryInformation.Text = "Salary information";
		this.layoutControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutControl1.Controls.Add(this.txtUnTaxable);
		this.layoutControl1.Controls.Add(this.txtNSSFAmount);
		this.layoutControl1.Controls.Add(this.txtPAYE);
		this.layoutControl1.Controls.Add(this.txtNetPay);
		this.layoutControl1.Controls.Add(this.txtNSSFRate);
		this.layoutControl1.Controls.Add(this.txtPAYECalc);
		this.layoutControl1.Controls.Add(this.txtEmplSalaryAmount);
		this.layoutControl1.Controls.Add(this.txtEmplNotes);
		this.layoutControl1.Location = new System.Drawing.Point(142, 1);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup3;
		this.layoutControl1.Size = new System.Drawing.Size(525, 269);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.txtUnTaxable.Location = new System.Drawing.Point(361, 4);
		this.txtUnTaxable.MenuManager = this.ribbon;
		this.txtUnTaxable.Name = "txtUnTaxable";
		this.txtUnTaxable.Properties.Mask.EditMask = "n";
		this.txtUnTaxable.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtUnTaxable.Size = new System.Drawing.Size(160, 20);
		this.txtUnTaxable.StyleController = this.layoutControl1;
		this.txtUnTaxable.TabIndex = 19;
		this.txtNSSFAmount.Location = new System.Drawing.Point(361, 52);
		this.txtNSSFAmount.MenuManager = this.ribbon;
		this.txtNSSFAmount.Name = "txtNSSFAmount";
		this.txtNSSFAmount.Properties.ReadOnly = true;
		this.txtNSSFAmount.Size = new System.Drawing.Size(160, 20);
		this.txtNSSFAmount.StyleController = this.layoutControl1;
		this.txtNSSFAmount.TabIndex = 18;
		this.txtPAYE.Location = new System.Drawing.Point(361, 28);
		this.txtPAYE.MenuManager = this.ribbon;
		this.txtPAYE.Name = "txtPAYE";
		this.txtPAYE.Properties.ReadOnly = true;
		this.txtPAYE.Size = new System.Drawing.Size(160, 20);
		this.txtPAYE.StyleController = this.layoutControl1;
		this.txtPAYE.TabIndex = 17;
		this.txtNetPay.Location = new System.Drawing.Point(101, 76);
		this.txtNetPay.MenuManager = this.ribbon;
		this.txtNetPay.Name = "txtNetPay";
		this.txtNetPay.Properties.ReadOnly = true;
		this.txtNetPay.Size = new System.Drawing.Size(420, 20);
		this.txtNetPay.StyleController = this.layoutControl1;
		this.txtNetPay.TabIndex = 16;
		this.txtNSSFRate.Location = new System.Drawing.Point(101, 52);
		this.txtNSSFRate.MenuManager = this.ribbon;
		this.txtNSSFRate.Name = "txtNSSFRate";
		this.txtNSSFRate.Properties.Mask.EditMask = "n";
		this.txtNSSFRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtNSSFRate.Size = new System.Drawing.Size(159, 20);
		this.txtNSSFRate.StyleController = this.layoutControl1;
		this.txtNSSFRate.TabIndex = 14;
		this.txtPAYECalc.Location = new System.Drawing.Point(101, 28);
		this.txtPAYECalc.MenuManager = this.ribbon;
		this.txtPAYECalc.Name = "txtPAYECalc";
		this.txtPAYECalc.Properties.Mask.EditMask = "n";
		this.txtPAYECalc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtPAYECalc.Size = new System.Drawing.Size(159, 20);
		this.txtPAYECalc.StyleController = this.layoutControl1;
		this.txtPAYECalc.TabIndex = 8;
		this.txtEmplSalaryAmount.Location = new System.Drawing.Point(101, 4);
		this.txtEmplSalaryAmount.MenuManager = this.ribbon;
		this.txtEmplSalaryAmount.Name = "txtEmplSalaryAmount";
		this.txtEmplSalaryAmount.Properties.Mask.EditMask = "n";
		this.txtEmplSalaryAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtEmplSalaryAmount.Size = new System.Drawing.Size(159, 20);
		this.txtEmplSalaryAmount.StyleController = this.layoutControl1;
		this.txtEmplSalaryAmount.TabIndex = 6;
		this.txtEmplNotes.Location = new System.Drawing.Point(4, 116);
		this.txtEmplNotes.MenuManager = this.ribbon;
		this.txtEmplNotes.Name = "txtEmplNotes";
		this.txtEmplNotes.Size = new System.Drawing.Size(517, 149);
		this.txtEmplNotes.StyleController = this.layoutControl1;
		this.txtEmplNotes.TabIndex = 5;
		this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup3.GroupBordersVisible = false;
		this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem18, this.layoutControlItem19, this.layoutControlItem37, this.layoutControlItem40, this.layoutControlItem43, this.layoutControlItem38, this.layoutControlItem39, this.layoutControlItem17 });
		this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup3.Name = "layoutControlGroup2";
		this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup3.Size = new System.Drawing.Size(525, 269);
		this.layoutControlGroup3.Text = "layoutControlGroup2";
		this.layoutControlGroup3.TextVisible = false;
		this.layoutControlItem18.Control = this.txtEmplNotes;
		this.layoutControlItem18.CustomizationFormText = "Notes";
		this.layoutControlItem18.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem18.Name = "layoutControlItem15";
		this.layoutControlItem18.Size = new System.Drawing.Size(521, 169);
		this.layoutControlItem18.Text = "Notes";
		this.layoutControlItem18.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem18.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem19.Control = this.txtEmplSalaryAmount;
		this.layoutControlItem19.CustomizationFormText = "Tuition fees:";
		this.layoutControlItem19.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem19.Name = "layoutControlItem16";
		this.layoutControlItem19.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem19.Text = "Gross salary:";
		this.layoutControlItem19.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem37.Control = this.txtPAYECalc;
		this.layoutControlItem37.CustomizationFormText = "PAYE Rate:";
		this.layoutControlItem37.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem37.Name = "layoutControlItem37";
		this.layoutControlItem37.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem37.Text = "PAYE Rate:";
		this.layoutControlItem37.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem40.Control = this.txtNSSFRate;
		this.layoutControlItem40.CustomizationFormText = "NSSF Rate:";
		this.layoutControlItem40.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem40.Name = "layoutControlItem40";
		this.layoutControlItem40.Size = new System.Drawing.Size(260, 24);
		this.layoutControlItem40.Text = "NSSF Rate:";
		this.layoutControlItem40.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem43.Control = this.txtNetPay;
		this.layoutControlItem43.CustomizationFormText = "Net monthly salary:";
		this.layoutControlItem43.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem43.Name = "layoutControlItem43";
		this.layoutControlItem43.Size = new System.Drawing.Size(521, 24);
		this.layoutControlItem43.Text = "Net monthly salary:";
		this.layoutControlItem43.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem38.Control = this.txtPAYE;
		this.layoutControlItem38.CustomizationFormText = "PAYE Amount:";
		this.layoutControlItem38.Location = new System.Drawing.Point(260, 24);
		this.layoutControlItem38.Name = "layoutControlItem38";
		this.layoutControlItem38.Size = new System.Drawing.Size(261, 24);
		this.layoutControlItem38.Text = "PAYE Amount:";
		this.layoutControlItem38.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem39.Control = this.txtNSSFAmount;
		this.layoutControlItem39.CustomizationFormText = "NSSF Amount:";
		this.layoutControlItem39.Location = new System.Drawing.Point(260, 48);
		this.layoutControlItem39.Name = "layoutControlItem39";
		this.layoutControlItem39.Size = new System.Drawing.Size(261, 24);
		this.layoutControlItem39.Text = "NSSF Amount:";
		this.layoutControlItem39.TextSize = new System.Drawing.Size(94, 13);
		this.layoutControlItem17.Control = this.txtUnTaxable;
		this.layoutControlItem17.CustomizationFormText = "UnTaxable amount:";
		this.layoutControlItem17.Location = new System.Drawing.Point(260, 0);
		this.layoutControlItem17.Name = "layoutControlItem17";
		this.layoutControlItem17.Size = new System.Drawing.Size(261, 24);
		this.layoutControlItem17.Text = "UnTaxable amount:";
		this.layoutControlItem17.TextSize = new System.Drawing.Size(94, 13);
		this.groupControl8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl8.Controls.Add(this.lblWorkingStatus);
		this.groupControl8.Controls.Add(this.radioGroup6);
		this.groupControl8.Location = new System.Drawing.Point(2, 2);
		this.groupControl8.Name = "groupControl8";
		this.groupControl8.Size = new System.Drawing.Size(138, 264);
		this.groupControl8.TabIndex = 0;
		this.groupControl8.Text = "Employee type";
		this.lblWorkingStatus.Location = new System.Drawing.Point(19, 130);
		this.lblWorkingStatus.Name = "lblWorkingStatus";
		this.lblWorkingStatus.Size = new System.Drawing.Size(75, 13);
		this.lblWorkingStatus.TabIndex = 8;
		this.lblWorkingStatus.Text = "labelControl119";
		this.lblWorkingStatus.Visible = false;
		this.radioGroup6.Location = new System.Drawing.Point(2, 22);
		this.radioGroup6.MenuManager = this.ribbon;
		this.radioGroup6.Name = "radioGroup6";
		this.radioGroup6.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroup6.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroup6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroup6.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Teaching staff"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "None teaching staff")
		});
		this.radioGroup6.Size = new System.Drawing.Size(132, 50);
		this.radioGroup6.TabIndex = 0;
		this.panelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl3.Appearance.Options.UseBackColor = true;
		this.panelControl3.Controls.Add(this.btnEmplUpdate);
		this.panelControl3.Controls.Add(this.btnEmplAdmit);
		this.panelControl3.Location = new System.Drawing.Point(170, 450);
		this.panelControl3.Name = "panelControl3";
		this.panelControl3.Size = new System.Drawing.Size(671, 35);
		this.panelControl3.TabIndex = 7;
		this.btnEmplUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnEmplUpdate.Enabled = false;
		this.btnEmplUpdate.Location = new System.Drawing.Point(511, 6);
		this.btnEmplUpdate.Name = "btnEmplUpdate";
		this.btnEmplUpdate.Size = new System.Drawing.Size(75, 23);
		this.btnEmplUpdate.TabIndex = 1;
		this.btnEmplUpdate.Text = "Update";
		this.btnEmplAdmit.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnEmplAdmit.Location = new System.Drawing.Point(592, 6);
		this.btnEmplAdmit.Name = "btnEmplAdmit";
		this.btnEmplAdmit.Size = new System.Drawing.Size(75, 23);
		this.btnEmplAdmit.TabIndex = 0;
		this.btnEmplAdmit.Text = "Save New";
		this.tabStudentPayments.Controls.Add(this.gridStudentPayment);
		this.tabStudentPayments.Controls.Add(this.layoutStudentPayment);
		this.tabStudentPayments.Controls.Add(this.lblCurrentBank);
		this.tabStudentPayments.Controls.Add(this.picStudentPicture);
		this.tabStudentPayments.Name = "tabStudentPayments";
		this.tabStudentPayments.Size = new System.Drawing.Size(851, 484);
		this.tabStudentPayments.Text = "Student payments";
		this.gridStudentPayment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridStudentPayment.Location = new System.Drawing.Point(217, 156);
		this.gridStudentPayment.MainView = this.gridViewStudentPayment;
		this.gridStudentPayment.MenuManager = this.ribbon;
		this.gridStudentPayment.Name = "gridStudentPayment";
		this.gridStudentPayment.Size = new System.Drawing.Size(631, 325);
		this.gridStudentPayment.TabIndex = 12;
		this.gridStudentPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewStudentPayment });
		this.gridViewStudentPayment.GridControl = this.gridStudentPayment;
		this.gridViewStudentPayment.Name = "gridViewStudentPayment";
		this.gridViewStudentPayment.OptionsCustomization.AllowFilter = false;
		this.gridViewStudentPayment.OptionsCustomization.AllowGroup = false;
		this.gridViewStudentPayment.OptionsCustomization.AllowSort = false;
		this.gridViewStudentPayment.OptionsView.ShowGroupPanel = false;
		this.layoutStudentPayment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutStudentPayment.Controls.Add(this.txtStudentFees);
		this.layoutStudentPayment.Controls.Add(this.txtStudentBursaryStatus);
		this.layoutStudentPayment.Controls.Add(this.txtStudentStream);
		this.layoutStudentPayment.Controls.Add(this.txtStudentClass);
		this.layoutStudentPayment.Controls.Add(this.txtStudentFirstName);
		this.layoutStudentPayment.Controls.Add(this.txtConfirmStudentNumber);
		this.layoutStudentPayment.Controls.Add(this.txtStudentLastName);
		this.layoutStudentPayment.Controls.Add(this.txtStudentSex);
		this.layoutStudentPayment.Controls.Add(this.txtStudentStudyStatus);
		this.layoutStudentPayment.Controls.Add(this.txtStudentReligion);
		this.layoutStudentPayment.Controls.Add(this.txtStudentHomeCountry);
		this.layoutStudentPayment.Location = new System.Drawing.Point(376, 0);
		this.layoutStudentPayment.Name = "layoutStudentPayment";
		this.layoutStudentPayment.Root = this.layoutControlGroup7;
		this.layoutStudentPayment.Size = new System.Drawing.Size(475, 156);
		this.layoutStudentPayment.TabIndex = 11;
		this.layoutStudentPayment.Text = "layoutControl1";
		this.txtStudentFees.Location = new System.Drawing.Point(319, 125);
		this.txtStudentFees.MenuManager = this.ribbon;
		this.txtStudentFees.Name = "txtStudentFees";
		this.txtStudentFees.Properties.ReadOnly = true;
		this.txtStudentFees.Size = new System.Drawing.Size(151, 20);
		this.txtStudentFees.StyleController = this.layoutStudentPayment;
		this.txtStudentFees.TabIndex = 15;
		this.txtStudentBursaryStatus.Location = new System.Drawing.Point(319, 101);
		this.txtStudentBursaryStatus.MenuManager = this.ribbon;
		this.txtStudentBursaryStatus.Name = "txtStudentBursaryStatus";
		this.txtStudentBursaryStatus.Properties.ReadOnly = true;
		this.txtStudentBursaryStatus.Size = new System.Drawing.Size(151, 20);
		this.txtStudentBursaryStatus.StyleController = this.layoutStudentPayment;
		this.txtStudentBursaryStatus.TabIndex = 14;
		this.txtStudentStream.Location = new System.Drawing.Point(319, 77);
		this.txtStudentStream.MenuManager = this.ribbon;
		this.txtStudentStream.Name = "txtStudentStream";
		this.txtStudentStream.Properties.ReadOnly = true;
		this.txtStudentStream.Size = new System.Drawing.Size(151, 20);
		this.txtStudentStream.StyleController = this.layoutStudentPayment;
		this.txtStudentStream.TabIndex = 13;
		this.txtStudentClass.Location = new System.Drawing.Point(319, 53);
		this.txtStudentClass.MenuManager = this.ribbon;
		this.txtStudentClass.Name = "txtStudentClass";
		this.txtStudentClass.Properties.ReadOnly = true;
		this.txtStudentClass.Size = new System.Drawing.Size(151, 20);
		this.txtStudentClass.StyleController = this.layoutStudentPayment;
		this.txtStudentClass.TabIndex = 12;
		this.txtStudentFirstName.Location = new System.Drawing.Point(83, 29);
		this.txtStudentFirstName.MenuManager = this.ribbon;
		this.txtStudentFirstName.Name = "txtStudentFirstName";
		this.txtStudentFirstName.Properties.ReadOnly = true;
		this.txtStudentFirstName.Size = new System.Drawing.Size(154, 20);
		this.txtStudentFirstName.StyleController = this.layoutStudentPayment;
		this.txtStudentFirstName.TabIndex = 6;
		this.txtConfirmStudentNumber.Location = new System.Drawing.Point(83, 5);
		this.txtConfirmStudentNumber.MenuManager = this.ribbon;
		this.txtConfirmStudentNumber.Name = "txtConfirmStudentNumber";
		this.txtConfirmStudentNumber.Properties.ReadOnly = true;
		this.txtConfirmStudentNumber.Size = new System.Drawing.Size(387, 20);
		this.txtConfirmStudentNumber.StyleController = this.layoutStudentPayment;
		this.txtConfirmStudentNumber.TabIndex = 5;
		this.txtStudentLastName.Location = new System.Drawing.Point(319, 29);
		this.txtStudentLastName.MenuManager = this.ribbon;
		this.txtStudentLastName.Name = "txtStudentLastName";
		this.txtStudentLastName.Properties.ReadOnly = true;
		this.txtStudentLastName.Size = new System.Drawing.Size(151, 20);
		this.txtStudentLastName.StyleController = this.layoutStudentPayment;
		this.txtStudentLastName.TabIndex = 7;
		this.txtStudentSex.Location = new System.Drawing.Point(83, 53);
		this.txtStudentSex.MenuManager = this.ribbon;
		this.txtStudentSex.Name = "txtStudentSex";
		this.txtStudentSex.Properties.ReadOnly = true;
		this.txtStudentSex.Size = new System.Drawing.Size(154, 20);
		this.txtStudentSex.StyleController = this.layoutStudentPayment;
		this.txtStudentSex.TabIndex = 8;
		this.txtStudentStudyStatus.Location = new System.Drawing.Point(83, 77);
		this.txtStudentStudyStatus.MenuManager = this.ribbon;
		this.txtStudentStudyStatus.Name = "txtStudentStudyStatus";
		this.txtStudentStudyStatus.Properties.ReadOnly = true;
		this.txtStudentStudyStatus.Size = new System.Drawing.Size(154, 20);
		this.txtStudentStudyStatus.StyleController = this.layoutStudentPayment;
		this.txtStudentStudyStatus.TabIndex = 9;
		this.txtStudentReligion.Location = new System.Drawing.Point(83, 101);
		this.txtStudentReligion.MenuManager = this.ribbon;
		this.txtStudentReligion.Name = "txtStudentReligion";
		this.txtStudentReligion.Properties.ReadOnly = true;
		this.txtStudentReligion.Size = new System.Drawing.Size(154, 20);
		this.txtStudentReligion.StyleController = this.layoutStudentPayment;
		this.txtStudentReligion.TabIndex = 10;
		this.txtStudentHomeCountry.Location = new System.Drawing.Point(83, 125);
		this.txtStudentHomeCountry.MenuManager = this.ribbon;
		this.txtStudentHomeCountry.Name = "txtStudentHomeCountry";
		this.txtStudentHomeCountry.Properties.ReadOnly = true;
		this.txtStudentHomeCountry.Size = new System.Drawing.Size(154, 20);
		this.txtStudentHomeCountry.StyleController = this.layoutStudentPayment;
		this.txtStudentHomeCountry.TabIndex = 11;
		this.layoutControlGroup7.CustomizationFormText = "layout";
		this.layoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup7.GroupBordersVisible = false;
		this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[11]
		{
			this.layoutControlItem46, this.layoutControlItem47, this.layoutControlItem48, this.layoutControlItem49, this.layoutControlItem50, this.layoutControlItem51, this.layoutControlItem52, this.layoutControlItem53, this.layoutControlItem54, this.layoutControlItem55,
			this.layoutControlItem56
		});
		this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup7.Name = "layout";
		this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layoutControlGroup7.Size = new System.Drawing.Size(475, 156);
		this.layoutControlGroup7.Text = "layout";
		this.layoutControlGroup7.TextVisible = false;
		this.layoutControlItem46.Control = this.txtConfirmStudentNumber;
		this.layoutControlItem46.CustomizationFormText = "Student No.";
		this.layoutControlItem46.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem46.Name = "layoutControlItem4";
		this.layoutControlItem46.Size = new System.Drawing.Size(469, 24);
		this.layoutControlItem46.Text = "Student No.";
		this.layoutControlItem46.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem47.Control = this.txtStudentFirstName;
		this.layoutControlItem47.CustomizationFormText = "Surname";
		this.layoutControlItem47.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem47.Name = "layoutControlItem5";
		this.layoutControlItem47.Size = new System.Drawing.Size(236, 24);
		this.layoutControlItem47.Text = "Surname:";
		this.layoutControlItem47.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem48.Control = this.txtStudentSex;
		this.layoutControlItem48.CustomizationFormText = "Sex";
		this.layoutControlItem48.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem48.Name = "layoutControlItem7";
		this.layoutControlItem48.Size = new System.Drawing.Size(236, 24);
		this.layoutControlItem48.Text = "Sex:";
		this.layoutControlItem48.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem49.Control = this.txtStudentStudyStatus;
		this.layoutControlItem49.CustomizationFormText = "Date of birth";
		this.layoutControlItem49.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem49.Name = "layoutControlItem8";
		this.layoutControlItem49.Size = new System.Drawing.Size(236, 24);
		this.layoutControlItem49.Text = "D/B:";
		this.layoutControlItem49.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem50.Control = this.txtStudentReligion;
		this.layoutControlItem50.CustomizationFormText = "Religion";
		this.layoutControlItem50.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem50.Name = "layoutControlItem9";
		this.layoutControlItem50.Size = new System.Drawing.Size(236, 24);
		this.layoutControlItem50.Text = "Religion:";
		this.layoutControlItem50.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem51.Control = this.txtStudentHomeCountry;
		this.layoutControlItem51.CustomizationFormText = "Home Country";
		this.layoutControlItem51.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem51.Name = "layoutControlItem10";
		this.layoutControlItem51.Size = new System.Drawing.Size(236, 30);
		this.layoutControlItem51.Text = "Home Country:";
		this.layoutControlItem51.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem52.Control = this.txtStudentFees;
		this.layoutControlItem52.CustomizationFormText = "Former school";
		this.layoutControlItem52.Location = new System.Drawing.Point(236, 120);
		this.layoutControlItem52.Name = "layoutControlItem14";
		this.layoutControlItem52.Size = new System.Drawing.Size(233, 30);
		this.layoutControlItem52.Text = "Fees:";
		this.layoutControlItem52.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem53.Control = this.txtStudentBursaryStatus;
		this.layoutControlItem53.CustomizationFormText = "Kin address";
		this.layoutControlItem53.Location = new System.Drawing.Point(236, 96);
		this.layoutControlItem53.Name = "layoutControlItem13";
		this.layoutControlItem53.Size = new System.Drawing.Size(233, 24);
		this.layoutControlItem53.Text = "Bursary Status:";
		this.layoutControlItem53.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem54.Control = this.txtStudentStream;
		this.layoutControlItem54.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem54.Location = new System.Drawing.Point(236, 72);
		this.layoutControlItem54.Name = "layoutControlItem12";
		this.layoutControlItem54.Size = new System.Drawing.Size(233, 24);
		this.layoutControlItem54.Text = "Stream:";
		this.layoutControlItem54.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem55.Control = this.txtStudentClass;
		this.layoutControlItem55.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem55.Location = new System.Drawing.Point(236, 48);
		this.layoutControlItem55.Name = "layoutControlItem11";
		this.layoutControlItem55.Size = new System.Drawing.Size(233, 24);
		this.layoutControlItem55.Text = "Class:";
		this.layoutControlItem55.TextSize = new System.Drawing.Size(75, 13);
		this.layoutControlItem56.Control = this.txtStudentLastName;
		this.layoutControlItem56.CustomizationFormText = "Other names";
		this.layoutControlItem56.Location = new System.Drawing.Point(236, 24);
		this.layoutControlItem56.Name = "layoutControlItem6";
		this.layoutControlItem56.Size = new System.Drawing.Size(233, 24);
		this.layoutControlItem56.Text = "Other names:";
		this.layoutControlItem56.TextSize = new System.Drawing.Size(75, 13);
		this.lblCurrentBank.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblCurrentBank.Controls.Add(this.chkBankCharges);
		this.lblCurrentBank.Controls.Add(this.chkPrintReceipt);
		this.lblCurrentBank.Controls.Add(this.labelControl132);
		this.lblCurrentBank.Controls.Add(this.txtAmountPaid);
		this.lblCurrentBank.Controls.Add(this.labelControl131);
		this.lblCurrentBank.Controls.Add(this.btnProcessPayment);
		this.lblCurrentBank.Controls.Add(this.labelControl130);
		this.lblCurrentBank.Controls.Add(this.txtReceiptNumber);
		this.lblCurrentBank.Controls.Add(this.groupControl7);
		this.lblCurrentBank.Controls.Add(this.groupControl11);
		this.lblCurrentBank.Controls.Add(this.chkRememberSem);
		this.lblCurrentBank.Controls.Add(this.labelControl7);
		this.lblCurrentBank.Controls.Add(this.labelControl8);
		this.lblCurrentBank.Controls.Add(this.cboTermOfStudy);
		this.lblCurrentBank.Controls.Add(this.dtPayment);
		this.lblCurrentBank.Controls.Add(this.lookUpEdit);
		this.lblCurrentBank.Location = new System.Drawing.Point(3, 3);
		this.lblCurrentBank.Name = "lblCurrentBank";
		this.lblCurrentBank.Size = new System.Drawing.Size(208, 478);
		this.lblCurrentBank.TabIndex = 10;
		this.lblCurrentBank.Text = "Search student";
		this.chkBankCharges.Enabled = false;
		this.chkBankCharges.Location = new System.Drawing.Point(7, 349);
		this.chkBankCharges.MenuManager = this.ribbon;
		this.chkBankCharges.Name = "chkBankCharges";
		this.chkBankCharges.Properties.Caption = "Deduct Bank charges";
		this.chkBankCharges.Size = new System.Drawing.Size(130, 19);
		this.chkBankCharges.TabIndex = 18;
		this.chkPrintReceipt.Location = new System.Drawing.Point(5, 454);
		this.chkPrintReceipt.MenuManager = this.ribbon;
		this.chkPrintReceipt.Name = "chkPrintReceipt";
		this.chkPrintReceipt.Properties.Caption = "Print receipt";
		this.chkPrintReceipt.Size = new System.Drawing.Size(96, 19);
		this.chkPrintReceipt.TabIndex = 17;
		this.labelControl132.Location = new System.Drawing.Point(5, 433);
		this.labelControl132.Name = "labelControl132";
		this.labelControl132.Size = new System.Drawing.Size(41, 13);
		this.labelControl132.TabIndex = 15;
		this.labelControl132.Text = "Amount:";
		this.txtAmountPaid.Location = new System.Drawing.Point(73, 426);
		this.txtAmountPaid.MenuManager = this.ribbon;
		this.txtAmountPaid.Name = "txtAmountPaid";
		this.txtAmountPaid.Properties.Mask.EditMask = "d";
		this.txtAmountPaid.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAmountPaid.Size = new System.Drawing.Size(130, 20);
		this.txtAmountPaid.TabIndex = 14;
		this.labelControl131.Location = new System.Drawing.Point(5, 407);
		this.labelControl131.Name = "labelControl131";
		this.labelControl131.Size = new System.Drawing.Size(27, 13);
		this.labelControl131.TabIndex = 13;
		this.labelControl131.Text = "Date:";
		this.btnProcessPayment.Location = new System.Drawing.Point(107, 450);
		this.btnProcessPayment.Name = "btnProcessPayment";
		this.btnProcessPayment.Size = new System.Drawing.Size(96, 23);
		this.btnProcessPayment.TabIndex = 0;
		this.btnProcessPayment.Text = "Process payment";
		this.labelControl130.Location = new System.Drawing.Point(5, 381);
		this.labelControl130.Name = "labelControl130";
		this.labelControl130.Size = new System.Drawing.Size(58, 13);
		this.labelControl130.TabIndex = 12;
		this.labelControl130.Text = "Bankslip No.";
		this.txtReceiptNumber.Location = new System.Drawing.Point(73, 374);
		this.txtReceiptNumber.MenuManager = this.ribbon;
		this.txtReceiptNumber.Name = "txtReceiptNumber";
		this.txtReceiptNumber.Size = new System.Drawing.Size(128, 20);
		this.txtReceiptNumber.TabIndex = 10;
		this.groupControl7.Controls.Add(this.lblCurrentBankFP);
		this.groupControl7.Controls.Add(this.radioGroup4);
		this.groupControl7.Location = new System.Drawing.Point(7, 227);
		this.groupControl7.Name = "groupControl7";
		this.groupControl7.Size = new System.Drawing.Size(196, 116);
		this.groupControl7.TabIndex = 8;
		this.groupControl7.Text = "Mode of payment";
		this.lblCurrentBankFP.Appearance.Font = new System.Drawing.Font("Tahoma", 8f);
		this.lblCurrentBankFP.Location = new System.Drawing.Point(53, 58);
		this.lblCurrentBankFP.Name = "lblCurrentBankFP";
		this.lblCurrentBankFP.Size = new System.Drawing.Size(0, 13);
		this.lblCurrentBankFP.TabIndex = 16;
		this.radioGroup4.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroup4.Location = new System.Drawing.Point(2, 21);
		this.radioGroup4.MenuManager = this.ribbon;
		this.radioGroup4.Name = "radioGroup4";
		this.radioGroup4.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroup4.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroup4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroup4.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[5]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cash"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "None Cash"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Bank"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cheque"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mobile money")
		});
		this.radioGroup4.Size = new System.Drawing.Size(192, 93);
		this.radioGroup4.TabIndex = 0;
		this.groupControl11.Controls.Add(this.lbRequirements);
		this.groupControl11.Location = new System.Drawing.Point(5, 101);
		this.groupControl11.Name = "groupControl11";
		this.groupControl11.Size = new System.Drawing.Size(198, 122);
		this.groupControl11.TabIndex = 0;
		this.groupControl11.Text = "Requirements";
		this.lbRequirements.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lbRequirements.Location = new System.Drawing.Point(2, 21);
		this.lbRequirements.Name = "lbRequirements";
		this.lbRequirements.Size = new System.Drawing.Size(194, 99);
		this.lbRequirements.TabIndex = 0;
		this.chkRememberSem.Location = new System.Drawing.Point(58, 50);
		this.chkRememberSem.MenuManager = this.ribbon;
		this.chkRememberSem.Name = "chkRememberSem";
		this.chkRememberSem.Properties.Caption = "Remember selection";
		this.chkRememberSem.Size = new System.Drawing.Size(145, 19);
		this.chkRememberSem.TabIndex = 9;
		this.labelControl7.Location = new System.Drawing.Point(5, 82);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(33, 13);
		this.labelControl7.TabIndex = 6;
		this.labelControl7.Text = "Rg. No";
		this.labelControl8.Location = new System.Drawing.Point(5, 34);
		this.labelControl8.Name = "labelControl8";
		this.labelControl8.Size = new System.Drawing.Size(49, 13);
		this.labelControl8.TabIndex = 5;
		this.labelControl8.Text = "Semester:";
		this.cboTermOfStudy.Location = new System.Drawing.Point(60, 27);
		this.cboTermOfStudy.MenuManager = this.ribbon;
		this.cboTermOfStudy.Name = "cboTermOfStudy";
		this.cboTermOfStudy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTermOfStudy.Size = new System.Drawing.Size(143, 20);
		this.cboTermOfStudy.TabIndex = 8;
		this.dtPayment.EditValue = null;
		this.dtPayment.Location = new System.Drawing.Point(73, 400);
		this.dtPayment.MenuManager = this.ribbon;
		this.dtPayment.Name = "dtPayment";
		this.dtPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtPayment.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtPayment.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtPayment.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtPayment.Properties.Mask.EditMask = "";
		this.dtPayment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.dtPayment.Size = new System.Drawing.Size(128, 20);
		this.dtPayment.TabIndex = 11;
		this.lookUpEdit.Location = new System.Drawing.Point(60, 75);
		this.lookUpEdit.MenuManager = this.ribbon;
		this.lookUpEdit.Name = "lookUpEdit";
		this.lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpEdit.Properties.NullText = "";
		this.lookUpEdit.Size = new System.Drawing.Size(143, 20);
		this.lookUpEdit.TabIndex = 7;
		this.picStudentPicture.Location = new System.Drawing.Point(216, 3);
		this.picStudentPicture.MenuManager = this.ribbon;
		this.picStudentPicture.Name = "picStudentPicture";
		this.picStudentPicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStudentPicture.Size = new System.Drawing.Size(154, 147);
		this.picStudentPicture.TabIndex = 9;
		this.tabReports.Controls.Add(this.panelControl2);
		this.tabReports.Name = "tabReports";
		this.tabReports.Size = new System.Drawing.Size(851, 484);
		this.tabReports.Text = "Reports";
		this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panelControl2.Location = new System.Drawing.Point(0, 0);
		this.panelControl2.Name = "panelControl2";
		this.panelControl2.Size = new System.Drawing.Size(851, 484);
		this.panelControl2.TabIndex = 0;
		this.tabEmployeePayments.Controls.Add(this.gridEmpSalary);
		this.tabEmployeePayments.Controls.Add(this.layoutControl5);
		this.tabEmployeePayments.Controls.Add(this.groupControl10);
		this.tabEmployeePayments.Controls.Add(this.picStaffPay);
		this.tabEmployeePayments.Name = "tabEmployeePayments";
		this.tabEmployeePayments.Size = new System.Drawing.Size(851, 484);
		this.tabEmployeePayments.Text = "Employee payments";
		this.gridEmpSalary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridEmpSalary.Location = new System.Drawing.Point(217, 157);
		this.gridEmpSalary.MainView = this.gridViewESalary;
		this.gridEmpSalary.Name = "gridEmpSalary";
		this.gridEmpSalary.Size = new System.Drawing.Size(631, 324);
		this.gridEmpSalary.TabIndex = 58;
		this.gridEmpSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewESalary });
		this.gridViewESalary.GridControl = this.gridEmpSalary;
		this.gridViewESalary.Name = "gridViewESalary";
		this.gridViewESalary.OptionsView.ShowGroupPanel = false;
		this.layoutControl5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutControl5.Controls.Add(this.chkPayStatus);
		this.layoutControl5.Controls.Add(this.txtPayEmplType);
		this.layoutControl5.Controls.Add(this.txtPayResponsibility);
		this.layoutControl5.Controls.Add(this.txtPayAddress);
		this.layoutControl5.Controls.Add(this.txtPayTelephone);
		this.layoutControl5.Controls.Add(this.txtPaySurname);
		this.layoutControl5.Controls.Add(this.txtPayEmployeeNo);
		this.layoutControl5.Controls.Add(this.txtPayOtherNames);
		this.layoutControl5.Controls.Add(this.txtPayNSSF);
		this.layoutControl5.Controls.Add(this.txtPayNetPay);
		this.layoutControl5.Controls.Add(this.txtPayBasicPay);
		this.layoutControl5.Controls.Add(this.txtPayPaye);
		this.layoutControl5.Location = new System.Drawing.Point(377, 1);
		this.layoutControl5.Name = "layoutControl5";
		this.layoutControl5.Root = this.layoutControlGroup9;
		this.layoutControl5.Size = new System.Drawing.Size(478, 156);
		this.layoutControl5.TabIndex = 16;
		this.layoutControl5.Text = "layoutControl1";
		this.chkPayStatus.Location = new System.Drawing.Point(242, 5);
		this.chkPayStatus.MenuManager = this.ribbon;
		this.chkPayStatus.Name = "chkPayStatus";
		this.chkPayStatus.Properties.Caption = "Discontinued";
		this.chkPayStatus.Size = new System.Drawing.Size(231, 19);
		this.chkPayStatus.StyleController = this.layoutControl5;
		this.chkPayStatus.TabIndex = 16;
		this.txtPayEmplType.Location = new System.Drawing.Point(322, 125);
		this.txtPayEmplType.MenuManager = this.ribbon;
		this.txtPayEmplType.Name = "txtPayEmplType";
		this.txtPayEmplType.Properties.ReadOnly = true;
		this.txtPayEmplType.Size = new System.Drawing.Size(151, 20);
		this.txtPayEmplType.StyleController = this.layoutControl5;
		this.txtPayEmplType.TabIndex = 15;
		this.txtPayResponsibility.Location = new System.Drawing.Point(322, 101);
		this.txtPayResponsibility.MenuManager = this.ribbon;
		this.txtPayResponsibility.Name = "txtPayResponsibility";
		this.txtPayResponsibility.Properties.ReadOnly = true;
		this.txtPayResponsibility.Size = new System.Drawing.Size(151, 20);
		this.txtPayResponsibility.StyleController = this.layoutControl5;
		this.txtPayResponsibility.TabIndex = 14;
		this.txtPayAddress.Location = new System.Drawing.Point(322, 77);
		this.txtPayAddress.MenuManager = this.ribbon;
		this.txtPayAddress.Name = "txtPayAddress";
		this.txtPayAddress.Properties.ReadOnly = true;
		this.txtPayAddress.Size = new System.Drawing.Size(151, 20);
		this.txtPayAddress.StyleController = this.layoutControl5;
		this.txtPayAddress.TabIndex = 13;
		this.txtPayTelephone.Location = new System.Drawing.Point(322, 53);
		this.txtPayTelephone.MenuManager = this.ribbon;
		this.txtPayTelephone.Name = "txtPayTelephone";
		this.txtPayTelephone.Properties.ReadOnly = true;
		this.txtPayTelephone.Size = new System.Drawing.Size(151, 20);
		this.txtPayTelephone.StyleController = this.layoutControl5;
		this.txtPayTelephone.TabIndex = 12;
		this.txtPaySurname.Location = new System.Drawing.Point(85, 29);
		this.txtPaySurname.MenuManager = this.ribbon;
		this.txtPaySurname.Name = "txtPaySurname";
		this.txtPaySurname.Properties.ReadOnly = true;
		this.txtPaySurname.Size = new System.Drawing.Size(153, 20);
		this.txtPaySurname.StyleController = this.layoutControl5;
		this.txtPaySurname.TabIndex = 6;
		this.txtPayEmployeeNo.Location = new System.Drawing.Point(85, 5);
		this.txtPayEmployeeNo.MenuManager = this.ribbon;
		this.txtPayEmployeeNo.Name = "txtPayEmployeeNo";
		this.txtPayEmployeeNo.Properties.ReadOnly = true;
		this.txtPayEmployeeNo.Size = new System.Drawing.Size(153, 20);
		this.txtPayEmployeeNo.StyleController = this.layoutControl5;
		this.txtPayEmployeeNo.TabIndex = 5;
		this.txtPayOtherNames.Location = new System.Drawing.Point(322, 29);
		this.txtPayOtherNames.MenuManager = this.ribbon;
		this.txtPayOtherNames.Name = "txtPayOtherNames";
		this.txtPayOtherNames.Properties.ReadOnly = true;
		this.txtPayOtherNames.Size = new System.Drawing.Size(151, 20);
		this.txtPayOtherNames.StyleController = this.layoutControl5;
		this.txtPayOtherNames.TabIndex = 7;
		this.txtPayNSSF.Location = new System.Drawing.Point(85, 101);
		this.txtPayNSSF.MenuManager = this.ribbon;
		this.txtPayNSSF.Name = "txtPayNSSF";
		this.txtPayNSSF.Properties.ReadOnly = true;
		this.txtPayNSSF.Size = new System.Drawing.Size(153, 20);
		this.txtPayNSSF.StyleController = this.layoutControl5;
		this.txtPayNSSF.TabIndex = 10;
		this.txtPayNetPay.Location = new System.Drawing.Point(85, 125);
		this.txtPayNetPay.MenuManager = this.ribbon;
		this.txtPayNetPay.Name = "txtPayNetPay";
		this.txtPayNetPay.Properties.ReadOnly = true;
		this.txtPayNetPay.Size = new System.Drawing.Size(153, 20);
		this.txtPayNetPay.StyleController = this.layoutControl5;
		this.txtPayNetPay.TabIndex = 11;
		this.txtPayBasicPay.Location = new System.Drawing.Point(85, 53);
		this.txtPayBasicPay.MenuManager = this.ribbon;
		this.txtPayBasicPay.Name = "txtPayBasicPay";
		this.txtPayBasicPay.Properties.ReadOnly = true;
		this.txtPayBasicPay.Size = new System.Drawing.Size(153, 20);
		this.txtPayBasicPay.StyleController = this.layoutControl5;
		this.txtPayBasicPay.TabIndex = 8;
		this.txtPayPaye.Location = new System.Drawing.Point(85, 77);
		this.txtPayPaye.MenuManager = this.ribbon;
		this.txtPayPaye.Name = "txtPayPaye";
		this.txtPayPaye.Properties.ReadOnly = true;
		this.txtPayPaye.Size = new System.Drawing.Size(153, 20);
		this.txtPayPaye.StyleController = this.layoutControl5;
		this.txtPayPaye.TabIndex = 9;
		this.layoutControlGroup9.CustomizationFormText = "layout";
		this.layoutControlGroup9.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup9.GroupBordersVisible = false;
		this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[12]
		{
			this.layoutControlItem74, this.layoutControlItem75, this.layoutControlItem76, this.layoutControlItem77, this.layoutControlItem78, this.layoutControlItem79, this.layoutControlItem80, this.layoutControlItem81, this.layoutControlItem82, this.layoutControlItem83,
			this.layoutControlItem84, this.layoutControlItem85
		});
		this.layoutControlGroup9.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup9.Name = "layout";
		this.layoutControlGroup9.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layoutControlGroup9.Size = new System.Drawing.Size(478, 156);
		this.layoutControlGroup9.Text = "layout";
		this.layoutControlGroup9.TextVisible = false;
		this.layoutControlItem74.Control = this.txtPayEmployeeNo;
		this.layoutControlItem74.CustomizationFormText = "Student No.";
		this.layoutControlItem74.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem74.Name = "layoutControlItem4";
		this.layoutControlItem74.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem74.Text = "Emp No.";
		this.layoutControlItem74.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem75.Control = this.txtPaySurname;
		this.layoutControlItem75.CustomizationFormText = "Surname";
		this.layoutControlItem75.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem75.Name = "layoutControlItem5";
		this.layoutControlItem75.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem75.Text = "Surname:";
		this.layoutControlItem75.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem76.Control = this.txtPayBasicPay;
		this.layoutControlItem76.CustomizationFormText = "Sex";
		this.layoutControlItem76.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem76.Name = "layoutControlItem7";
		this.layoutControlItem76.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem76.Text = "Basic pay:";
		this.layoutControlItem76.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem77.Control = this.txtPayPaye;
		this.layoutControlItem77.CustomizationFormText = "Date of birth";
		this.layoutControlItem77.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem77.Name = "layoutControlItem8";
		this.layoutControlItem77.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem77.Text = "PAYE:";
		this.layoutControlItem77.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem78.Control = this.txtPayNSSF;
		this.layoutControlItem78.CustomizationFormText = "Religion";
		this.layoutControlItem78.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem78.Name = "layoutControlItem9";
		this.layoutControlItem78.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem78.Text = "NSSF:";
		this.layoutControlItem78.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem79.Control = this.txtPayNetPay;
		this.layoutControlItem79.CustomizationFormText = "Home Country";
		this.layoutControlItem79.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem79.Name = "layoutControlItem10";
		this.layoutControlItem79.Size = new System.Drawing.Size(237, 30);
		this.layoutControlItem79.Text = "Net pay:";
		this.layoutControlItem79.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem80.Control = this.txtPayEmplType;
		this.layoutControlItem80.CustomizationFormText = "Former school";
		this.layoutControlItem80.Location = new System.Drawing.Point(237, 120);
		this.layoutControlItem80.Name = "layoutControlItem14";
		this.layoutControlItem80.Size = new System.Drawing.Size(235, 30);
		this.layoutControlItem80.Text = "Employee Type:";
		this.layoutControlItem80.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem81.Control = this.txtPayResponsibility;
		this.layoutControlItem81.CustomizationFormText = "Kin address";
		this.layoutControlItem81.Location = new System.Drawing.Point(237, 96);
		this.layoutControlItem81.Name = "layoutControlItem13";
		this.layoutControlItem81.Size = new System.Drawing.Size(235, 24);
		this.layoutControlItem81.Text = "Responsibility:";
		this.layoutControlItem81.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem82.Control = this.txtPayAddress;
		this.layoutControlItem82.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem82.Location = new System.Drawing.Point(237, 72);
		this.layoutControlItem82.Name = "layoutControlItem12";
		this.layoutControlItem82.Size = new System.Drawing.Size(235, 24);
		this.layoutControlItem82.Text = "Address:";
		this.layoutControlItem82.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem83.Control = this.txtPayTelephone;
		this.layoutControlItem83.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem83.Location = new System.Drawing.Point(237, 48);
		this.layoutControlItem83.Name = "layoutControlItem11";
		this.layoutControlItem83.Size = new System.Drawing.Size(235, 24);
		this.layoutControlItem83.Text = "Telephone:";
		this.layoutControlItem83.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem84.Control = this.txtPayOtherNames;
		this.layoutControlItem84.CustomizationFormText = "Other names";
		this.layoutControlItem84.Location = new System.Drawing.Point(237, 24);
		this.layoutControlItem84.Name = "layoutControlItem6";
		this.layoutControlItem84.Size = new System.Drawing.Size(235, 24);
		this.layoutControlItem84.Text = "Other names:";
		this.layoutControlItem84.TextSize = new System.Drawing.Size(77, 13);
		this.layoutControlItem85.Control = this.chkPayStatus;
		this.layoutControlItem85.CustomizationFormText = "layoutControlItem35";
		this.layoutControlItem85.Location = new System.Drawing.Point(237, 0);
		this.layoutControlItem85.Name = "layoutControlItem35";
		this.layoutControlItem85.Size = new System.Drawing.Size(235, 24);
		this.layoutControlItem85.Text = "layoutControlItem35";
		this.layoutControlItem85.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem85.TextToControlDistance = 0;
		this.layoutControlItem85.TextVisible = false;
		this.groupControl10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl10.Controls.Add(this.labelControl135);
		this.groupControl10.Controls.Add(this.btnPaySalary);
		this.groupControl10.Controls.Add(this.labelControl22);
		this.groupControl10.Controls.Add(this.checkEdit4);
		this.groupControl10.Controls.Add(this.txtPayNarration);
		this.groupControl10.Controls.Add(this.labelControl134);
		this.groupControl10.Controls.Add(this.lookUpStaff);
		this.groupControl10.Controls.Add(this.labelControl133);
		this.groupControl10.Controls.Add(this.cboPaySemester);
		this.groupControl10.Controls.Add(this.labelControl24);
		this.groupControl10.Controls.Add(this.cboPayMonth);
		this.groupControl10.Controls.Add(this.labelControl25);
		this.groupControl10.Controls.Add(this.txtPayAMount);
		this.groupControl10.Controls.Add(this.labelControl26);
		this.groupControl10.Controls.Add(this.dtPayDate);
		this.groupControl10.Controls.Add(this.cboPayItem);
		this.groupControl10.Location = new System.Drawing.Point(3, 4);
		this.groupControl10.Name = "groupControl10";
		this.groupControl10.Size = new System.Drawing.Size(208, 477);
		this.groupControl10.TabIndex = 15;
		this.groupControl10.Text = "Payment details";
		this.labelControl135.Location = new System.Drawing.Point(3, 320);
		this.labelControl135.Name = "labelControl135";
		this.labelControl135.Size = new System.Drawing.Size(49, 13);
		this.labelControl135.TabIndex = 62;
		this.labelControl135.Text = "Narration:";
		this.btnPaySalary.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnPaySalary.Enabled = false;
		this.btnPaySalary.Location = new System.Drawing.Point(64, 449);
		this.btnPaySalary.Name = "btnPaySalary";
		this.btnPaySalary.Size = new System.Drawing.Size(139, 23);
		this.btnPaySalary.TabIndex = 0;
		this.btnPaySalary.Text = "Process payment";
		this.labelControl22.Location = new System.Drawing.Point(3, 35);
		this.labelControl22.Name = "labelControl22";
		this.labelControl22.Size = new System.Drawing.Size(33, 13);
		this.labelControl22.TabIndex = 6;
		this.labelControl22.Text = "Rg. No";
		this.checkEdit4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.checkEdit4.Location = new System.Drawing.Point(62, 424);
		this.checkEdit4.MenuManager = this.ribbon;
		this.checkEdit4.Name = "checkEdit4";
		this.checkEdit4.Properties.Caption = "Print voucher";
		this.checkEdit4.Size = new System.Drawing.Size(92, 19);
		this.checkEdit4.TabIndex = 23;
		this.txtPayNarration.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtPayNarration.Location = new System.Drawing.Point(57, 308);
		this.txtPayNarration.MenuManager = this.ribbon;
		this.txtPayNarration.Name = "txtPayNarration";
		this.txtPayNarration.Size = new System.Drawing.Size(146, 92);
		this.txtPayNarration.TabIndex = 59;
		this.labelControl134.Location = new System.Drawing.Point(3, 289);
		this.labelControl134.Name = "labelControl134";
		this.labelControl134.Size = new System.Drawing.Size(41, 13);
		this.labelControl134.TabIndex = 61;
		this.labelControl134.Text = "Amount:";
		this.lookUpStaff.Location = new System.Drawing.Point(42, 28);
		this.lookUpStaff.MenuManager = this.ribbon;
		this.lookUpStaff.Name = "lookUpStaff";
		this.lookUpStaff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpStaff.Properties.NullText = "";
		this.lookUpStaff.Size = new System.Drawing.Size(161, 20);
		this.lookUpStaff.TabIndex = 7;
		this.labelControl133.Location = new System.Drawing.Point(3, 261);
		this.labelControl133.Name = "labelControl133";
		this.labelControl133.Size = new System.Drawing.Size(27, 13);
		this.labelControl133.TabIndex = 60;
		this.labelControl133.Text = "Date:";
		this.cboPaySemester.Location = new System.Drawing.Point(57, 86);
		this.cboPaySemester.MenuManager = this.ribbon;
		this.cboPaySemester.Name = "cboPaySemester";
		this.cboPaySemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboPaySemester.Size = new System.Drawing.Size(146, 20);
		this.cboPaySemester.TabIndex = 8;
		this.labelControl24.Location = new System.Drawing.Point(3, 93);
		this.labelControl24.Name = "labelControl24";
		this.labelControl24.Size = new System.Drawing.Size(49, 13);
		this.labelControl24.TabIndex = 12;
		this.labelControl24.Text = "Semester:";
		this.cboPayMonth.EditValue = "-Select Month-";
		this.cboPayMonth.Location = new System.Drawing.Point(57, 112);
		this.cboPayMonth.MenuManager = this.ribbon;
		this.cboPayMonth.Name = "cboPayMonth";
		this.cboPayMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboPayMonth.Properties.Items.AddRange(new object[13]
		{
			"-Select Month-", "January", "Febraury", "March", "April", "May", "June", "July", "August", "September",
			"October", "November", "December"
		});
		this.cboPayMonth.Size = new System.Drawing.Size(146, 20);
		this.cboPayMonth.TabIndex = 11;
		this.labelControl25.Location = new System.Drawing.Point(3, 119);
		this.labelControl25.Name = "labelControl25";
		this.labelControl25.Size = new System.Drawing.Size(34, 13);
		this.labelControl25.TabIndex = 13;
		this.labelControl25.Text = "Month:";
		this.txtPayAMount.Location = new System.Drawing.Point(57, 282);
		this.txtPayAMount.MenuManager = this.ribbon;
		this.txtPayAMount.Name = "txtPayAMount";
		this.txtPayAMount.Properties.Mask.EditMask = "n";
		this.txtPayAMount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtPayAMount.Size = new System.Drawing.Size(146, 20);
		this.txtPayAMount.TabIndex = 25;
		this.labelControl26.Location = new System.Drawing.Point(3, 145);
		this.labelControl26.Name = "labelControl26";
		this.labelControl26.Size = new System.Drawing.Size(26, 13);
		this.labelControl26.TabIndex = 14;
		this.labelControl26.Text = "Item:";
		this.dtPayDate.EditValue = null;
		this.dtPayDate.Location = new System.Drawing.Point(57, 254);
		this.dtPayDate.MenuManager = this.ribbon;
		this.dtPayDate.Name = "dtPayDate";
		this.dtPayDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtPayDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtPayDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtPayDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtPayDate.Size = new System.Drawing.Size(146, 20);
		this.dtPayDate.TabIndex = 24;
		this.cboPayItem.Location = new System.Drawing.Point(57, 138);
		this.cboPayItem.MenuManager = this.ribbon;
		this.cboPayItem.Name = "cboPayItem";
		this.cboPayItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboPayItem.Size = new System.Drawing.Size(146, 20);
		this.cboPayItem.TabIndex = 10;
		this.picStaffPay.Location = new System.Drawing.Point(217, 6);
		this.picStaffPay.MenuManager = this.ribbon;
		this.picStaffPay.Name = "picStaffPay";
		this.picStaffPay.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStaffPay.Size = new System.Drawing.Size(159, 147);
		this.picStaffPay.TabIndex = 14;
		this.tabSuppliers.Controls.Add(this.panelControl15);
		this.tabSuppliers.Controls.Add(this.gridSuppliers);
		this.tabSuppliers.Controls.Add(this.xtraTabControl5);
		this.tabSuppliers.Name = "tabSuppliers";
		this.tabSuppliers.Size = new System.Drawing.Size(851, 484);
		this.tabSuppliers.Text = "Suppliers";
		this.panelControl15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl15.Controls.Add(this.btnDeleteSupplier);
		this.panelControl15.Controls.Add(this.btnNewSupplier);
		this.panelControl15.Controls.Add(this.btnSaveSupplier);
		this.panelControl15.Location = new System.Drawing.Point(3, 445);
		this.panelControl15.Name = "panelControl15";
		this.panelControl15.Size = new System.Drawing.Size(842, 35);
		this.panelControl15.TabIndex = 28;
		this.btnDeleteSupplier.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnDeleteSupplier.Location = new System.Drawing.Point(5, 7);
		this.btnDeleteSupplier.Name = "btnDeleteSupplier";
		this.btnDeleteSupplier.Size = new System.Drawing.Size(83, 23);
		this.btnDeleteSupplier.TabIndex = 24;
		this.btnDeleteSupplier.Text = "Delete";
		this.btnNewSupplier.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNewSupplier.Location = new System.Drawing.Point(658, 7);
		this.btnNewSupplier.Name = "btnNewSupplier";
		this.btnNewSupplier.Size = new System.Drawing.Size(81, 23);
		this.btnNewSupplier.TabIndex = 25;
		this.btnNewSupplier.Text = "New";
		this.btnSaveSupplier.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnSaveSupplier.Location = new System.Drawing.Point(745, 7);
		this.btnSaveSupplier.Name = "btnSaveSupplier";
		this.btnSaveSupplier.Size = new System.Drawing.Size(92, 23);
		this.btnSaveSupplier.TabIndex = 22;
		this.btnSaveSupplier.Text = "Save";
		this.gridSuppliers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridSuppliers.Location = new System.Drawing.Point(3, 3);
		this.gridSuppliers.MainView = this.gridViewSuppliers;
		this.gridSuppliers.Name = "gridSuppliers";
		this.gridSuppliers.Size = new System.Drawing.Size(847, 197);
		this.gridSuppliers.TabIndex = 27;
		this.gridSuppliers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSuppliers });
		this.gridViewSuppliers.GridControl = this.gridSuppliers;
		this.gridViewSuppliers.Name = "gridViewSuppliers";
		this.gridViewSuppliers.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewSuppliers.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewSuppliers.OptionsBehavior.Editable = false;
		this.gridViewSuppliers.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewSuppliers.OptionsCustomization.AllowGroup = false;
		this.gridViewSuppliers.OptionsSelection.MultiSelect = true;
		this.gridViewSuppliers.OptionsView.ShowGroupPanel = false;
		this.xtraTabControl5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.xtraTabControl5.Location = new System.Drawing.Point(3, 206);
		this.xtraTabControl5.Name = "xtraTabControl5";
		this.xtraTabControl5.SelectedTabPage = this.tabSupplierDetails;
		this.xtraTabControl5.Size = new System.Drawing.Size(847, 239);
		this.xtraTabControl5.TabIndex = 26;
		this.xtraTabControl5.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[1] { this.tabSupplierDetails });
		this.tabSupplierDetails.Controls.Add(this.lblSupplierCode);
		this.tabSupplierDetails.Controls.Add(this.labelControl62);
		this.tabSupplierDetails.Controls.Add(this.labelControl61);
		this.tabSupplierDetails.Controls.Add(this.labelControl60);
		this.tabSupplierDetails.Controls.Add(this.labelControl59);
		this.tabSupplierDetails.Controls.Add(this.labelControl58);
		this.tabSupplierDetails.Controls.Add(this.labelControl57);
		this.tabSupplierDetails.Controls.Add(this.labelControl56);
		this.tabSupplierDetails.Controls.Add(this.labelControl55);
		this.tabSupplierDetails.Controls.Add(this.labelControl54);
		this.tabSupplierDetails.Controls.Add(this.labelControl53);
		this.tabSupplierDetails.Controls.Add(this.labelControl52);
		this.tabSupplierDetails.Controls.Add(this.labelControl51);
		this.tabSupplierDetails.Controls.Add(this.labelControl50);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierSurname);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierNotes);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierPhone);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierBoxNo);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierFax);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierJobTitle);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierCompany);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierStreet);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierStreet1);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierMobile);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierEmail);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierOthername);
		this.tabSupplierDetails.Controls.Add(this.txtSupplierCity);
		this.tabSupplierDetails.Name = "tabSupplierDetails";
		this.tabSupplierDetails.Size = new System.Drawing.Size(841, 213);
		this.tabSupplierDetails.Text = "General";
		this.lblSupplierCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblSupplierCode.Location = new System.Drawing.Point(653, 9);
		this.lblSupplierCode.Name = "lblSupplierCode";
		this.lblSupplierCode.Size = new System.Drawing.Size(0, 13);
		this.lblSupplierCode.TabIndex = 33;
		this.lblSupplierCode.Visible = false;
		this.labelControl62.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl62.Location = new System.Drawing.Point(432, 9);
		this.labelControl62.Name = "labelControl62";
		this.labelControl62.Size = new System.Drawing.Size(32, 13);
		this.labelControl62.TabIndex = 32;
		this.labelControl62.Text = "Notes:";
		this.labelControl61.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl61.Location = new System.Drawing.Point(216, 169);
		this.labelControl61.Name = "labelControl61";
		this.labelControl61.Size = new System.Drawing.Size(49, 13);
		this.labelControl61.TabIndex = 31;
		this.labelControl61.Text = "Company:";
		this.labelControl60.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl60.Location = new System.Drawing.Point(216, 143);
		this.labelControl60.Name = "labelControl60";
		this.labelControl60.Size = new System.Drawing.Size(28, 13);
		this.labelControl60.TabIndex = 30;
		this.labelControl60.Text = "Email:";
		this.labelControl59.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl59.Location = new System.Drawing.Point(216, 117);
		this.labelControl59.Name = "labelControl59";
		this.labelControl59.Size = new System.Drawing.Size(23, 13);
		this.labelControl59.TabIndex = 29;
		this.labelControl59.Text = "City:";
		this.labelControl58.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl58.Location = new System.Drawing.Point(216, 39);
		this.labelControl58.Name = "labelControl58";
		this.labelControl58.Size = new System.Drawing.Size(34, 13);
		this.labelControl58.TabIndex = 28;
		this.labelControl58.Text = "Mobile:";
		this.labelControl57.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl57.Location = new System.Drawing.Point(216, 17);
		this.labelControl57.Name = "labelControl57";
		this.labelControl57.Size = new System.Drawing.Size(61, 13);
		this.labelControl57.TabIndex = 27;
		this.labelControl57.Text = "Other name:";
		this.labelControl56.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl56.Location = new System.Drawing.Point(3, 169);
		this.labelControl56.Name = "labelControl56";
		this.labelControl56.Size = new System.Drawing.Size(44, 13);
		this.labelControl56.TabIndex = 26;
		this.labelControl56.Text = "Job Title:";
		this.labelControl55.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl55.Location = new System.Drawing.Point(3, 143);
		this.labelControl55.Name = "labelControl55";
		this.labelControl55.Size = new System.Drawing.Size(22, 13);
		this.labelControl55.TabIndex = 25;
		this.labelControl55.Text = "Fax:";
		this.labelControl54.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl54.Location = new System.Drawing.Point(3, 117);
		this.labelControl54.Name = "labelControl54";
		this.labelControl54.Size = new System.Drawing.Size(38, 13);
		this.labelControl54.TabIndex = 24;
		this.labelControl54.Text = "Box No.";
		this.labelControl53.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl53.Location = new System.Drawing.Point(3, 91);
		this.labelControl53.Name = "labelControl53";
		this.labelControl53.Size = new System.Drawing.Size(43, 13);
		this.labelControl53.TabIndex = 23;
		this.labelControl53.Text = "Street 1:";
		this.labelControl52.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl52.Location = new System.Drawing.Point(3, 65);
		this.labelControl52.Name = "labelControl52";
		this.labelControl52.Size = new System.Drawing.Size(34, 13);
		this.labelControl52.TabIndex = 22;
		this.labelControl52.Text = "Street:";
		this.labelControl51.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl51.Location = new System.Drawing.Point(3, 39);
		this.labelControl51.Name = "labelControl51";
		this.labelControl51.Size = new System.Drawing.Size(34, 13);
		this.labelControl51.TabIndex = 21;
		this.labelControl51.Text = "Phone:";
		this.labelControl50.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl50.Location = new System.Drawing.Point(3, 13);
		this.labelControl50.Name = "labelControl50";
		this.labelControl50.Size = new System.Drawing.Size(46, 13);
		this.labelControl50.TabIndex = 20;
		this.labelControl50.Text = "Surname:";
		this.txtSupplierSurname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierSurname.Location = new System.Drawing.Point(64, 6);
		this.txtSupplierSurname.Name = "txtSupplierSurname";
		this.txtSupplierSurname.Size = new System.Drawing.Size(142, 20);
		this.txtSupplierSurname.TabIndex = 0;
		this.txtSupplierNotes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSupplierNotes.Location = new System.Drawing.Point(431, 28);
		this.txtSupplierNotes.Name = "txtSupplierNotes";
		this.txtSupplierNotes.Size = new System.Drawing.Size(409, 177);
		this.txtSupplierNotes.TabIndex = 12;
		this.txtSupplierPhone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierPhone.Location = new System.Drawing.Point(64, 32);
		this.txtSupplierPhone.Name = "txtSupplierPhone";
		this.txtSupplierPhone.Size = new System.Drawing.Size(142, 20);
		this.txtSupplierPhone.TabIndex = 2;
		this.txtSupplierBoxNo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierBoxNo.Location = new System.Drawing.Point(64, 110);
		this.txtSupplierBoxNo.Name = "txtSupplierBoxNo";
		this.txtSupplierBoxNo.Properties.Mask.EditMask = "\\d+";
		this.txtSupplierBoxNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
		this.txtSupplierBoxNo.Size = new System.Drawing.Size(142, 20);
		this.txtSupplierBoxNo.TabIndex = 6;
		this.txtSupplierFax.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierFax.Location = new System.Drawing.Point(64, 136);
		this.txtSupplierFax.Name = "txtSupplierFax";
		this.txtSupplierFax.Size = new System.Drawing.Size(142, 20);
		this.txtSupplierFax.TabIndex = 8;
		this.txtSupplierJobTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierJobTitle.Location = new System.Drawing.Point(64, 162);
		this.txtSupplierJobTitle.Name = "txtSupplierJobTitle";
		this.txtSupplierJobTitle.Size = new System.Drawing.Size(142, 20);
		this.txtSupplierJobTitle.TabIndex = 10;
		this.txtSupplierCompany.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierCompany.Location = new System.Drawing.Point(285, 162);
		this.txtSupplierCompany.Name = "txtSupplierCompany";
		this.txtSupplierCompany.Size = new System.Drawing.Size(140, 20);
		this.txtSupplierCompany.TabIndex = 11;
		this.txtSupplierStreet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierStreet.Location = new System.Drawing.Point(64, 58);
		this.txtSupplierStreet.Name = "txtSupplierStreet";
		this.txtSupplierStreet.Size = new System.Drawing.Size(361, 20);
		this.txtSupplierStreet.TabIndex = 4;
		this.txtSupplierStreet1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierStreet1.Location = new System.Drawing.Point(64, 84);
		this.txtSupplierStreet1.Name = "txtSupplierStreet1";
		this.txtSupplierStreet1.Size = new System.Drawing.Size(361, 20);
		this.txtSupplierStreet1.TabIndex = 5;
		this.txtSupplierMobile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierMobile.Location = new System.Drawing.Point(285, 32);
		this.txtSupplierMobile.Name = "txtSupplierMobile";
		this.txtSupplierMobile.Size = new System.Drawing.Size(140, 20);
		this.txtSupplierMobile.TabIndex = 3;
		this.txtSupplierEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierEmail.Location = new System.Drawing.Point(285, 136);
		this.txtSupplierEmail.Name = "txtSupplierEmail";
		this.txtSupplierEmail.Size = new System.Drawing.Size(140, 20);
		this.txtSupplierEmail.TabIndex = 9;
		this.txtSupplierOthername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierOthername.Location = new System.Drawing.Point(285, 6);
		this.txtSupplierOthername.Name = "txtSupplierOthername";
		this.txtSupplierOthername.Size = new System.Drawing.Size(140, 20);
		this.txtSupplierOthername.TabIndex = 1;
		this.txtSupplierCity.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtSupplierCity.Location = new System.Drawing.Point(285, 110);
		this.txtSupplierCity.Name = "txtSupplierCity";
		this.txtSupplierCity.Size = new System.Drawing.Size(140, 20);
		this.txtSupplierCity.TabIndex = 7;
		this.tabOrderLists.Controls.Add(this.groupControl6);
		this.tabOrderLists.Controls.Add(this.gridSupplierLedger);
		this.tabOrderLists.Name = "tabOrderLists";
		this.tabOrderLists.Size = new System.Drawing.Size(851, 484);
		this.tabOrderLists.Text = "Orders";
		this.groupControl6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl6.Controls.Add(this.labelControl138);
		this.groupControl6.Controls.Add(this.txtPaySupplierNarration);
		this.groupControl6.Controls.Add(this.cboPaySupplierSemester);
		this.groupControl6.Controls.Add(this.labelControl137);
		this.groupControl6.Controls.Add(this.chkPrintVoucherS);
		this.groupControl6.Controls.Add(this.labelControl136);
		this.groupControl6.Controls.Add(this.labelControl46);
		this.groupControl6.Controls.Add(this.btnPayBills);
		this.groupControl6.Controls.Add(this.txtPaySupplierAmount);
		this.groupControl6.Controls.Add(this.dtPaySupplier);
		this.groupControl6.Controls.Add(this.labelControl49);
		this.groupControl6.Controls.Add(this.txtPaySupplierAddress);
		this.groupControl6.Controls.Add(this.labelControl48);
		this.groupControl6.Controls.Add(this.labelControl47);
		this.groupControl6.Controls.Add(this.labelControl45);
		this.groupControl6.Controls.Add(this.txtPaySupplierOffice);
		this.groupControl6.Controls.Add(this.txtPaySupplierMob);
		this.groupControl6.Controls.Add(this.txtPaySupplierOtherName);
		this.groupControl6.Controls.Add(this.txtPaySupplierSurname);
		this.groupControl6.Controls.Add(this.txtPaySupplierName);
		this.groupControl6.Controls.Add(this.labelControl40);
		this.groupControl6.Controls.Add(this.lookUpSupplierPayment);
		this.groupControl6.Location = new System.Drawing.Point(3, 3);
		this.groupControl6.Name = "groupControl6";
		this.groupControl6.Size = new System.Drawing.Size(208, 478);
		this.groupControl6.TabIndex = 5;
		this.groupControl6.Text = "Supplier details";
		this.labelControl138.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl138.Location = new System.Drawing.Point(5, 317);
		this.labelControl138.Name = "labelControl138";
		this.labelControl138.Size = new System.Drawing.Size(49, 13);
		this.labelControl138.TabIndex = 22;
		this.labelControl138.Text = "Narration:";
		this.txtPaySupplierNarration.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtPaySupplierNarration.Location = new System.Drawing.Point(55, 315);
		this.txtPaySupplierNarration.MenuManager = this.ribbon;
		this.txtPaySupplierNarration.Name = "txtPaySupplierNarration";
		this.txtPaySupplierNarration.Size = new System.Drawing.Size(148, 50);
		this.txtPaySupplierNarration.TabIndex = 21;
		this.cboPaySupplierSemester.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.cboPaySupplierSemester.Location = new System.Drawing.Point(55, 289);
		this.cboPaySupplierSemester.MenuManager = this.ribbon;
		this.cboPaySupplierSemester.Name = "cboPaySupplierSemester";
		this.cboPaySupplierSemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboPaySupplierSemester.Size = new System.Drawing.Size(148, 20);
		this.cboPaySupplierSemester.TabIndex = 20;
		this.labelControl137.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl137.Location = new System.Drawing.Point(5, 296);
		this.labelControl137.Name = "labelControl137";
		this.labelControl137.Size = new System.Drawing.Size(49, 13);
		this.labelControl137.TabIndex = 19;
		this.labelControl137.Text = "Semester:";
		this.chkPrintVoucherS.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.chkPrintVoucherS.Location = new System.Drawing.Point(53, 425);
		this.chkPrintVoucherS.MenuManager = this.ribbon;
		this.chkPrintVoucherS.Name = "chkPrintVoucherS";
		this.chkPrintVoucherS.Properties.Caption = "Print voucher";
		this.chkPrintVoucherS.Size = new System.Drawing.Size(106, 19);
		this.chkPrintVoucherS.TabIndex = 18;
		this.labelControl136.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl136.Location = new System.Drawing.Point(6, 378);
		this.labelControl136.Name = "labelControl136";
		this.labelControl136.Size = new System.Drawing.Size(27, 13);
		this.labelControl136.TabIndex = 17;
		this.labelControl136.Text = "Date:";
		this.labelControl46.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl46.Location = new System.Drawing.Point(6, 404);
		this.labelControl46.Name = "labelControl46";
		this.labelControl46.Size = new System.Drawing.Size(41, 13);
		this.labelControl46.TabIndex = 16;
		this.labelControl46.Text = "Amount:";
		this.btnPayBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnPayBills.Location = new System.Drawing.Point(55, 450);
		this.btnPayBills.Name = "btnPayBills";
		this.btnPayBills.Size = new System.Drawing.Size(148, 23);
		this.btnPayBills.TabIndex = 15;
		this.btnPayBills.Text = "Continue";
		this.txtPaySupplierAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtPaySupplierAmount.Location = new System.Drawing.Point(55, 397);
		this.txtPaySupplierAmount.MenuManager = this.ribbon;
		this.txtPaySupplierAmount.Name = "txtPaySupplierAmount";
		this.txtPaySupplierAmount.Properties.Mask.EditMask = "f0";
		this.txtPaySupplierAmount.Size = new System.Drawing.Size(148, 20);
		this.txtPaySupplierAmount.TabIndex = 14;
		this.dtPaySupplier.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dtPaySupplier.EditValue = null;
		this.dtPaySupplier.Location = new System.Drawing.Point(55, 371);
		this.dtPaySupplier.MenuManager = this.ribbon;
		this.dtPaySupplier.Name = "dtPaySupplier";
		this.dtPaySupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtPaySupplier.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtPaySupplier.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtPaySupplier.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtPaySupplier.Size = new System.Drawing.Size(148, 20);
		this.dtPaySupplier.TabIndex = 13;
		this.labelControl49.Location = new System.Drawing.Point(6, 208);
		this.labelControl49.Name = "labelControl49";
		this.labelControl49.Size = new System.Drawing.Size(43, 13);
		this.labelControl49.TabIndex = 12;
		this.labelControl49.Text = "Address:";
		this.txtPaySupplierAddress.Location = new System.Drawing.Point(55, 200);
		this.txtPaySupplierAddress.MenuManager = this.ribbon;
		this.txtPaySupplierAddress.Name = "txtPaySupplierAddress";
		this.txtPaySupplierAddress.Properties.ReadOnly = true;
		this.txtPaySupplierAddress.Size = new System.Drawing.Size(148, 62);
		this.txtPaySupplierAddress.TabIndex = 11;
		this.labelControl48.Location = new System.Drawing.Point(6, 181);
		this.labelControl48.Name = "labelControl48";
		this.labelControl48.Size = new System.Drawing.Size(33, 13);
		this.labelControl48.TabIndex = 10;
		this.labelControl48.Text = "Office:";
		this.labelControl47.Location = new System.Drawing.Point(6, 155);
		this.labelControl47.Name = "labelControl47";
		this.labelControl47.Size = new System.Drawing.Size(34, 13);
		this.labelControl47.TabIndex = 9;
		this.labelControl47.Text = "Mobile:";
		this.labelControl45.Location = new System.Drawing.Point(6, 105);
		this.labelControl45.Name = "labelControl45";
		this.labelControl45.Size = new System.Drawing.Size(31, 13);
		this.labelControl45.TabIndex = 7;
		this.labelControl45.Text = "Name:";
		this.txtPaySupplierOffice.Location = new System.Drawing.Point(55, 174);
		this.txtPaySupplierOffice.MenuManager = this.ribbon;
		this.txtPaySupplierOffice.Name = "txtPaySupplierOffice";
		this.txtPaySupplierOffice.Properties.ReadOnly = true;
		this.txtPaySupplierOffice.Size = new System.Drawing.Size(148, 20);
		this.txtPaySupplierOffice.TabIndex = 6;
		this.txtPaySupplierMob.Location = new System.Drawing.Point(55, 148);
		this.txtPaySupplierMob.MenuManager = this.ribbon;
		this.txtPaySupplierMob.Name = "txtPaySupplierMob";
		this.txtPaySupplierMob.Properties.ReadOnly = true;
		this.txtPaySupplierMob.Size = new System.Drawing.Size(148, 20);
		this.txtPaySupplierMob.TabIndex = 5;
		this.txtPaySupplierOtherName.Location = new System.Drawing.Point(55, 122);
		this.txtPaySupplierOtherName.MenuManager = this.ribbon;
		this.txtPaySupplierOtherName.Name = "txtPaySupplierOtherName";
		this.txtPaySupplierOtherName.Properties.ReadOnly = true;
		this.txtPaySupplierOtherName.Size = new System.Drawing.Size(148, 20);
		this.txtPaySupplierOtherName.TabIndex = 4;
		this.txtPaySupplierSurname.Location = new System.Drawing.Point(55, 98);
		this.txtPaySupplierSurname.MenuManager = this.ribbon;
		this.txtPaySupplierSurname.Name = "txtPaySupplierSurname";
		this.txtPaySupplierSurname.Properties.ReadOnly = true;
		this.txtPaySupplierSurname.Size = new System.Drawing.Size(148, 20);
		this.txtPaySupplierSurname.TabIndex = 3;
		this.txtPaySupplierName.Location = new System.Drawing.Point(6, 71);
		this.txtPaySupplierName.MenuManager = this.ribbon;
		this.txtPaySupplierName.Name = "txtPaySupplierName";
		this.txtPaySupplierName.Properties.ReadOnly = true;
		this.txtPaySupplierName.Size = new System.Drawing.Size(197, 20);
		this.txtPaySupplierName.TabIndex = 2;
		this.labelControl40.Location = new System.Drawing.Point(6, 40);
		this.labelControl40.Name = "labelControl40";
		this.labelControl40.Size = new System.Drawing.Size(64, 13);
		this.labelControl40.TabIndex = 1;
		this.labelControl40.Text = "Find supplier:";
		this.lookUpSupplierPayment.Location = new System.Drawing.Point(76, 37);
		this.lookUpSupplierPayment.MenuManager = this.ribbon;
		this.lookUpSupplierPayment.Name = "lookUpSupplierPayment";
		this.lookUpSupplierPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpSupplierPayment.Size = new System.Drawing.Size(127, 20);
		this.lookUpSupplierPayment.TabIndex = 0;
		this.gridSupplierLedger.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridSupplierLedger.Location = new System.Drawing.Point(217, 3);
		this.gridSupplierLedger.MainView = this.gridViewSL;
		this.gridSupplierLedger.Name = "gridSupplierLedger";
		this.gridSupplierLedger.Size = new System.Drawing.Size(629, 478);
		this.gridSupplierLedger.TabIndex = 4;
		this.gridSupplierLedger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSL });
		this.gridViewSL.GridControl = this.gridSupplierLedger;
		this.gridViewSL.Name = "gridViewSL";
		this.gridViewSL.OptionsView.ShowGroupPanel = false;
		this.tabBudgetCreattion.Controls.Add(this.groupControl23);
		this.tabBudgetCreattion.Name = "tabBudgetCreattion";
		this.tabBudgetCreattion.Size = new System.Drawing.Size(851, 484);
		this.tabBudgetCreattion.Text = "Create Budget";
		this.groupControl23.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl23.Controls.Add(this.btnAdd);
		this.groupControl23.Controls.Add(this.labelControl86);
		this.groupControl23.Controls.Add(this.txtTotal);
		this.groupControl23.Controls.Add(this.txtYear);
		this.groupControl23.Controls.Add(this.labelControl85);
		this.groupControl23.Controls.Add(this.labelControl84);
		this.groupControl23.Controls.Add(this.txtRate);
		this.groupControl23.Controls.Add(this.txtQuantity);
		this.groupControl23.Controls.Add(this.labelControl83);
		this.groupControl23.Controls.Add(this.labelControl82);
		this.groupControl23.Controls.Add(this.labelControl81);
		this.groupControl23.Controls.Add(this.labelControl75);
		this.groupControl23.Controls.Add(this.cboUnits);
		this.groupControl23.Controls.Add(this.cboItems);
		this.groupControl23.Controls.Add(this.cboCategories);
		this.groupControl23.Controls.Add(this.cboSemester3);
		this.groupControl23.Location = new System.Drawing.Point(234, 3);
		this.groupControl23.Name = "groupControl23";
		this.groupControl23.Size = new System.Drawing.Size(384, 482);
		this.groupControl23.TabIndex = 0;
		this.groupControl23.Text = "Budget particulars";
		this.btnAdd.Location = new System.Drawing.Point(115, 306);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Size = new System.Drawing.Size(100, 23);
		this.btnAdd.TabIndex = 15;
		this.btnAdd.Text = "Add Item";
		this.labelControl86.Location = new System.Drawing.Point(37, 268);
		this.labelControl86.Name = "labelControl86";
		this.labelControl86.Size = new System.Drawing.Size(28, 13);
		this.labelControl86.TabIndex = 14;
		this.labelControl86.Text = "Total:";
		this.txtTotal.Location = new System.Drawing.Point(115, 261);
		this.txtTotal.MenuManager = this.ribbon;
		this.txtTotal.Name = "txtTotal";
		this.txtTotal.Properties.Mask.EditMask = "n";
		this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtTotal.Properties.ReadOnly = true;
		this.txtTotal.Size = new System.Drawing.Size(100, 20);
		this.txtTotal.TabIndex = 13;
		this.txtYear.Location = new System.Drawing.Point(295, 103);
		this.txtYear.MenuManager = this.ribbon;
		this.txtYear.Name = "txtYear";
		this.txtYear.Properties.ReadOnly = true;
		this.txtYear.Size = new System.Drawing.Size(60, 20);
		this.txtYear.TabIndex = 12;
		this.labelControl85.Location = new System.Drawing.Point(37, 190);
		this.labelControl85.Name = "labelControl85";
		this.labelControl85.Size = new System.Drawing.Size(46, 13);
		this.labelControl85.TabIndex = 11;
		this.labelControl85.Text = "Quantity:";
		this.labelControl84.Location = new System.Drawing.Point(37, 242);
		this.labelControl84.Name = "labelControl84";
		this.labelControl84.Size = new System.Drawing.Size(27, 13);
		this.labelControl84.TabIndex = 10;
		this.labelControl84.Text = "Rate:";
		this.txtRate.Location = new System.Drawing.Point(115, 235);
		this.txtRate.MenuManager = this.ribbon;
		this.txtRate.Name = "txtRate";
		this.txtRate.Properties.Mask.EditMask = "n";
		this.txtRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtRate.Size = new System.Drawing.Size(100, 20);
		this.txtRate.TabIndex = 9;
		this.txtQuantity.Location = new System.Drawing.Point(115, 183);
		this.txtQuantity.MenuManager = this.ribbon;
		this.txtQuantity.Name = "txtQuantity";
		this.txtQuantity.Properties.Mask.EditMask = "n";
		this.txtQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtQuantity.Size = new System.Drawing.Size(100, 20);
		this.txtQuantity.TabIndex = 8;
		this.labelControl83.Location = new System.Drawing.Point(37, 216);
		this.labelControl83.Name = "labelControl83";
		this.labelControl83.Size = new System.Drawing.Size(28, 13);
		this.labelControl83.TabIndex = 7;
		this.labelControl83.Text = "Units:";
		this.labelControl82.Location = new System.Drawing.Point(37, 164);
		this.labelControl82.Name = "labelControl82";
		this.labelControl82.Size = new System.Drawing.Size(26, 13);
		this.labelControl82.TabIndex = 6;
		this.labelControl82.Text = "Item:";
		this.labelControl81.Location = new System.Drawing.Point(37, 137);
		this.labelControl81.Name = "labelControl81";
		this.labelControl81.Size = new System.Drawing.Size(49, 13);
		this.labelControl81.TabIndex = 5;
		this.labelControl81.Text = "Category:";
		this.labelControl75.Location = new System.Drawing.Point(37, 110);
		this.labelControl75.Name = "labelControl75";
		this.labelControl75.Size = new System.Drawing.Size(49, 13);
		this.labelControl75.TabIndex = 4;
		this.labelControl75.Text = "Semester:";
		this.cboUnits.EditValue = "-Select units-";
		this.cboUnits.Location = new System.Drawing.Point(115, 209);
		this.cboUnits.MenuManager = this.ribbon;
		this.cboUnits.Name = "cboUnits";
		this.cboUnits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboUnits.Properties.Items.AddRange(new object[19]
		{
			"-Select units-", "Bags", "Boxes", "Cards", "Containers", "g", "Gallons", "Jerrycans", "Kg", "Litres",
			"Meters", "Others", "Pairs", "Pcs", "Sachets", "Sacks", "Sets", "Tins", "Workig hours"
		});
		this.cboUnits.Size = new System.Drawing.Size(100, 20);
		this.cboUnits.TabIndex = 3;
		this.cboItems.Location = new System.Drawing.Point(115, 157);
		this.cboItems.MenuManager = this.ribbon;
		this.cboItems.Name = "cboItems";
		this.cboItems.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboItems.Size = new System.Drawing.Size(240, 20);
		this.cboItems.TabIndex = 2;
		this.cboCategories.Location = new System.Drawing.Point(115, 130);
		this.cboCategories.MenuManager = this.ribbon;
		this.cboCategories.Name = "cboCategories";
		this.cboCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCategories.Size = new System.Drawing.Size(240, 20);
		this.cboCategories.TabIndex = 1;
		this.cboSemester3.Location = new System.Drawing.Point(115, 103);
		this.cboSemester3.MenuManager = this.ribbon;
		this.cboSemester3.Name = "cboSemester3";
		this.cboSemester3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemester3.Size = new System.Drawing.Size(174, 20);
		this.cboSemester3.TabIndex = 0;
		this.tabBudgetReports.Name = "tabBudgetReports";
		this.tabBudgetReports.Size = new System.Drawing.Size(851, 484);
		this.tabBudgetReports.Text = "Budget reports";
		this.tabStudentLists.Controls.Add(this.panelControl20);
		this.tabStudentLists.Controls.Add(this.gridStudentRecords);
		this.tabStudentLists.Name = "tabStudentLists";
		this.tabStudentLists.Size = new System.Drawing.Size(851, 484);
		this.tabStudentLists.Text = "StudentLists";
		this.panelControl20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl20.Controls.Add(this.lblRequiredFees);
		this.panelControl20.Controls.Add(this.lblStudentStream);
		this.panelControl20.Controls.Add(this.lblStudentClass);
		this.panelControl20.Controls.Add(this.lblSelectionAction);
		this.panelControl20.Controls.Add(this.btnChooseStudent);
		this.panelControl20.Controls.Add(this.lblStudentName);
		this.panelControl20.Controls.Add(this.lblStudentNumber);
		this.panelControl20.Controls.Add(this.simpleButton46);
		this.panelControl20.Location = new System.Drawing.Point(3, 450);
		this.panelControl20.Name = "panelControl20";
		this.panelControl20.Size = new System.Drawing.Size(837, 35);
		this.panelControl20.TabIndex = 1;
		this.lblRequiredFees.Location = new System.Drawing.Point(583, 17);
		this.lblRequiredFees.Name = "lblRequiredFees";
		this.lblRequiredFees.Size = new System.Drawing.Size(75, 13);
		this.lblRequiredFees.TabIndex = 10;
		this.lblRequiredFees.Text = "labelControl130";
		this.lblRequiredFees.Visible = false;
		this.lblStudentStream.Location = new System.Drawing.Point(544, 17);
		this.lblStudentStream.Name = "lblStudentStream";
		this.lblStudentStream.Size = new System.Drawing.Size(0, 13);
		this.lblStudentStream.TabIndex = 9;
		this.lblStudentStream.Visible = false;
		this.lblStudentClass.Location = new System.Drawing.Point(413, 17);
		this.lblStudentClass.Name = "lblStudentClass";
		this.lblStudentClass.Size = new System.Drawing.Size(75, 13);
		this.lblStudentClass.TabIndex = 8;
		this.lblStudentClass.Text = "labelControl119";
		this.lblStudentClass.Visible = false;
		this.lblSelectionAction.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblSelectionAction.Location = new System.Drawing.Point(252, 17);
		this.lblSelectionAction.Name = "lblSelectionAction";
		this.lblSelectionAction.Size = new System.Drawing.Size(75, 13);
		this.lblSelectionAction.TabIndex = 7;
		this.lblSelectionAction.Text = "labelControl119";
		this.lblSelectionAction.Visible = false;
		this.btnChooseStudent.Location = new System.Drawing.Point(5, 7);
		this.btnChooseStudent.Name = "btnChooseStudent";
		this.btnChooseStudent.Size = new System.Drawing.Size(75, 23);
		this.btnChooseStudent.TabIndex = 6;
		this.btnChooseStudent.Text = "Choose";
		this.btnChooseStudent.Visible = false;
		this.lblStudentName.Location = new System.Drawing.Point(112, 17);
		this.lblStudentName.Name = "lblStudentName";
		this.lblStudentName.Size = new System.Drawing.Size(0, 13);
		this.lblStudentName.TabIndex = 5;
		this.lblStudentName.Visible = false;
		this.lblStudentNumber.Location = new System.Drawing.Point(230, 17);
		this.lblStudentNumber.Name = "lblStudentNumber";
		this.lblStudentNumber.Size = new System.Drawing.Size(0, 13);
		this.lblStudentNumber.TabIndex = 4;
		this.lblStudentNumber.Visible = false;
		this.simpleButton46.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton46.Location = new System.Drawing.Point(757, 7);
		this.simpleButton46.Name = "simpleButton46";
		this.simpleButton46.Size = new System.Drawing.Size(75, 23);
		this.simpleButton46.TabIndex = 2;
		this.simpleButton46.Text = "Delete";
		this.gridStudentRecords.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridStudentRecords.Location = new System.Drawing.Point(0, 0);
		this.gridStudentRecords.MainView = this.dgRecords;
		this.gridStudentRecords.MenuManager = this.ribbon;
		this.gridStudentRecords.Name = "gridStudentRecords";
		this.gridStudentRecords.Size = new System.Drawing.Size(850, 444);
		this.gridStudentRecords.TabIndex = 0;
		this.gridStudentRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.dgRecords });
		this.dgRecords.GridControl = this.gridStudentRecords;
		this.dgRecords.Name = "dgRecords";
		this.dgRecords.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.dgRecords.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.dgRecords.OptionsBehavior.Editable = false;
		this.dgRecords.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.dgRecords.OptionsCustomization.AllowGroup = false;
		this.dgRecords.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
		this.dgRecords.OptionsView.ShowAutoFilterRow = true;
		this.dgRecords.OptionsView.ShowGroupPanel = false;
		this.tabEmployeeLists.Controls.Add(this.panelControl21);
		this.tabEmployeeLists.Controls.Add(this.dgRecords_emp);
		this.tabEmployeeLists.Name = "tabEmployeeLists";
		this.tabEmployeeLists.Size = new System.Drawing.Size(851, 484);
		this.tabEmployeeLists.Text = "Employee Lists";
		this.panelControl21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl21.Controls.Add(this.btnChooseEmployee);
		this.panelControl21.Controls.Add(this.lblEmployeeNumber);
		this.panelControl21.Controls.Add(this.lblEmployeeName);
		this.panelControl21.Controls.Add(this.simpleButton49);
		this.panelControl21.Location = new System.Drawing.Point(3, 450);
		this.panelControl21.Name = "panelControl21";
		this.panelControl21.Size = new System.Drawing.Size(837, 35);
		this.panelControl21.TabIndex = 1;
		this.btnChooseEmployee.Location = new System.Drawing.Point(5, 6);
		this.btnChooseEmployee.Name = "btnChooseEmployee";
		this.btnChooseEmployee.Size = new System.Drawing.Size(75, 23);
		this.btnChooseEmployee.TabIndex = 5;
		this.btnChooseEmployee.Text = "Choose";
		this.btnChooseEmployee.Visible = false;
		this.lblEmployeeNumber.Location = new System.Drawing.Point(386, 16);
		this.lblEmployeeNumber.Name = "lblEmployeeNumber";
		this.lblEmployeeNumber.Size = new System.Drawing.Size(0, 13);
		this.lblEmployeeNumber.TabIndex = 4;
		this.lblEmployeeNumber.Visible = false;
		this.lblEmployeeName.Location = new System.Drawing.Point(202, 16);
		this.lblEmployeeName.Name = "lblEmployeeName";
		this.lblEmployeeName.Size = new System.Drawing.Size(0, 13);
		this.lblEmployeeName.TabIndex = 3;
		this.lblEmployeeName.Visible = false;
		this.simpleButton49.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton49.Location = new System.Drawing.Point(755, 6);
		this.simpleButton49.Name = "simpleButton49";
		this.simpleButton49.Size = new System.Drawing.Size(75, 23);
		this.simpleButton49.TabIndex = 2;
		this.simpleButton49.Text = "Delete";
		this.dgRecords_emp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dgRecords_emp.Location = new System.Drawing.Point(0, 0);
		this.dgRecords_emp.MainView = this.gridViewEmployees;
		this.dgRecords_emp.MenuManager = this.ribbon;
		this.dgRecords_emp.Name = "dgRecords_emp";
		this.dgRecords_emp.Size = new System.Drawing.Size(850, 444);
		this.dgRecords_emp.TabIndex = 0;
		this.dgRecords_emp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewEmployees });
		this.gridViewEmployees.GridControl = this.dgRecords_emp;
		this.gridViewEmployees.Name = "gridViewEmployees";
		this.gridViewEmployees.OptionsBehavior.Editable = false;
		this.gridViewEmployees.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewEmployees.OptionsView.ShowAutoFilterRow = true;
		this.gridViewEmployees.OptionsView.ShowGroupPanel = false;
		this.tabReceiveVouchers.Controls.Add(this.panelControl16);
		this.tabReceiveVouchers.Controls.Add(this.gridControl26);
		this.tabReceiveVouchers.Name = "tabReceiveVouchers";
		this.tabReceiveVouchers.Size = new System.Drawing.Size(851, 484);
		this.tabReceiveVouchers.Text = "Receive vouchers";
		this.panelControl16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl16.Controls.Add(this.simpleButton69);
		this.panelControl16.Controls.Add(this.simpleButton71);
		this.panelControl16.Controls.Add(this.simpleButton70);
		this.panelControl16.Location = new System.Drawing.Point(3, 450);
		this.panelControl16.Name = "panelControl16";
		this.panelControl16.Size = new System.Drawing.Size(837, 35);
		this.panelControl16.TabIndex = 8;
		this.simpleButton69.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton69.Location = new System.Drawing.Point(596, 7);
		this.simpleButton69.Name = "simpleButton69";
		this.simpleButton69.Size = new System.Drawing.Size(75, 23);
		this.simpleButton69.TabIndex = 5;
		this.simpleButton69.Text = "Show";
		this.simpleButton71.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton71.Location = new System.Drawing.Point(758, 7);
		this.simpleButton71.Name = "simpleButton71";
		this.simpleButton71.Size = new System.Drawing.Size(75, 23);
		this.simpleButton71.TabIndex = 7;
		this.simpleButton71.Text = "Delete";
		this.simpleButton70.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton70.Location = new System.Drawing.Point(677, 7);
		this.simpleButton70.Name = "simpleButton70";
		this.simpleButton70.Size = new System.Drawing.Size(75, 23);
		this.simpleButton70.TabIndex = 6;
		this.simpleButton70.Text = "New";
		this.gridControl26.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl26.Location = new System.Drawing.Point(0, 0);
		this.gridControl26.MainView = this.gridView26;
		this.gridControl26.Name = "gridControl26";
		this.gridControl26.Size = new System.Drawing.Size(843, 444);
		this.gridControl26.TabIndex = 4;
		this.gridControl26.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView26 });
		this.gridView26.GridControl = this.gridControl26;
		this.gridView26.Name = "gridView26";
		this.tabReceiveVouchersDetails.Controls.Add(this.panelControl17);
		this.tabReceiveVouchersDetails.Controls.Add(this.btnDeleteReceivingVoucher);
		this.tabReceiveVouchersDetails.Controls.Add(this.btnAddReceivingVoucher);
		this.tabReceiveVouchersDetails.Controls.Add(this.btnSearchSupplierVouchers);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit60);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl90);
		this.tabReceiveVouchersDetails.Controls.Add(this.dateEdit6);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl91);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl92);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl93);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit61);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit62);
		this.tabReceiveVouchersDetails.Controls.Add(this.gridControl27);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit63);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit64);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit65);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit66);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit67);
		this.tabReceiveVouchersDetails.Controls.Add(this.textEdit68);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl94);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl95);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl96);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl97);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl98);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl99);
		this.tabReceiveVouchersDetails.Controls.Add(this.memoEdit8);
		this.tabReceiveVouchersDetails.Controls.Add(this.labelControl100);
		this.tabReceiveVouchersDetails.Controls.Add(this.simpleButton73);
		this.tabReceiveVouchersDetails.Name = "tabReceiveVouchersDetails";
		this.tabReceiveVouchersDetails.Size = new System.Drawing.Size(851, 484);
		this.tabReceiveVouchersDetails.Text = "Receive vouchers";
		this.panelControl17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl17.Controls.Add(this.simpleButton77);
		this.panelControl17.Controls.Add(this.simpleButton76);
		this.panelControl17.Controls.Add(this.simpleButton75);
		this.panelControl17.Controls.Add(this.simpleButton74);
		this.panelControl17.Location = new System.Drawing.Point(3, 450);
		this.panelControl17.Name = "panelControl17";
		this.panelControl17.Size = new System.Drawing.Size(837, 35);
		this.panelControl17.TabIndex = 80;
		this.simpleButton77.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.simpleButton77.Location = new System.Drawing.Point(5, 7);
		this.simpleButton77.Name = "simpleButton77";
		this.simpleButton77.Size = new System.Drawing.Size(100, 23);
		this.simpleButton77.TabIndex = 53;
		this.simpleButton77.Text = "Receiving Vouchers";
		this.simpleButton76.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton76.Location = new System.Drawing.Point(596, 7);
		this.simpleButton76.Name = "simpleButton76";
		this.simpleButton76.Size = new System.Drawing.Size(75, 23);
		this.simpleButton76.TabIndex = 39;
		this.simpleButton76.Text = "Close";
		this.simpleButton75.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton75.Location = new System.Drawing.Point(677, 7);
		this.simpleButton75.Name = "simpleButton75";
		this.simpleButton75.Size = new System.Drawing.Size(75, 23);
		this.simpleButton75.TabIndex = 40;
		this.simpleButton75.Text = "Print";
		this.simpleButton74.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton74.Location = new System.Drawing.Point(758, 7);
		this.simpleButton74.Name = "simpleButton74";
		this.simpleButton74.Size = new System.Drawing.Size(75, 23);
		this.simpleButton74.TabIndex = 41;
		this.simpleButton74.Text = "New";
		this.btnDeleteReceivingVoucher.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnDeleteReceivingVoucher.Location = new System.Drawing.Point(767, 79);
		this.btnDeleteReceivingVoucher.Name = "btnDeleteReceivingVoucher";
		this.btnDeleteReceivingVoucher.Size = new System.Drawing.Size(75, 23);
		this.btnDeleteReceivingVoucher.TabIndex = 79;
		this.btnDeleteReceivingVoucher.Text = "Delete";
		this.btnAddReceivingVoucher.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnAddReceivingVoucher.Location = new System.Drawing.Point(767, 50);
		this.btnAddReceivingVoucher.Name = "btnAddReceivingVoucher";
		this.btnAddReceivingVoucher.Size = new System.Drawing.Size(75, 23);
		this.btnAddReceivingVoucher.TabIndex = 78;
		this.btnAddReceivingVoucher.Text = "Add";
		this.btnSearchSupplierVouchers.Location = new System.Drawing.Point(599, 21);
		this.btnSearchSupplierVouchers.Name = "btnSearchSupplierVouchers";
		this.btnSearchSupplierVouchers.Size = new System.Drawing.Size(43, 23);
		this.btnSearchSupplierVouchers.TabIndex = 77;
		this.btnSearchSupplierVouchers.Text = "...";
		this.textEdit60.Location = new System.Drawing.Point(322, 24);
		this.textEdit60.Name = "textEdit60";
		this.textEdit60.Properties.ReadOnly = true;
		this.textEdit60.Size = new System.Drawing.Size(259, 20);
		this.textEdit60.TabIndex = 76;
		this.labelControl90.Location = new System.Drawing.Point(322, 9);
		this.labelControl90.Name = "labelControl90";
		this.labelControl90.Size = new System.Drawing.Size(42, 13);
		this.labelControl90.TabIndex = 75;
		this.labelControl90.Text = "Supplier:";
		this.dateEdit6.EditValue = null;
		this.dateEdit6.Location = new System.Drawing.Point(216, 24);
		this.dateEdit6.Name = "dateEdit6";
		this.dateEdit6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit6.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit6.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dateEdit6.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dateEdit6.Size = new System.Drawing.Size(100, 20);
		this.dateEdit6.TabIndex = 74;
		this.labelControl91.Location = new System.Drawing.Point(216, 9);
		this.labelControl91.Name = "labelControl91";
		this.labelControl91.Size = new System.Drawing.Size(27, 13);
		this.labelControl91.TabIndex = 73;
		this.labelControl91.Text = "Date:";
		this.labelControl92.Location = new System.Drawing.Point(110, 7);
		this.labelControl92.Name = "labelControl92";
		this.labelControl92.Size = new System.Drawing.Size(35, 13);
		this.labelControl92.TabIndex = 72;
		this.labelControl92.Text = "Status:";
		this.labelControl93.Location = new System.Drawing.Point(4, 7);
		this.labelControl93.Name = "labelControl93";
		this.labelControl93.Size = new System.Drawing.Size(29, 13);
		this.labelControl93.TabIndex = 71;
		this.labelControl93.Text = "Code:";
		this.textEdit61.Location = new System.Drawing.Point(110, 24);
		this.textEdit61.Name = "textEdit61";
		this.textEdit61.Properties.ReadOnly = true;
		this.textEdit61.Size = new System.Drawing.Size(100, 20);
		this.textEdit61.TabIndex = 70;
		this.textEdit62.Location = new System.Drawing.Point(4, 24);
		this.textEdit62.Name = "textEdit62";
		this.textEdit62.Properties.ReadOnly = true;
		this.textEdit62.Size = new System.Drawing.Size(100, 20);
		this.textEdit62.TabIndex = 69;
		this.gridControl27.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl27.Location = new System.Drawing.Point(3, 50);
		this.gridControl27.MainView = this.gridView27;
		this.gridControl27.Name = "gridControl27";
		this.gridControl27.Size = new System.Drawing.Size(758, 240);
		this.gridControl27.TabIndex = 68;
		this.gridControl27.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView27 });
		this.gridView27.GridControl = this.gridControl27;
		this.gridView27.Name = "gridView27";
		this.textEdit63.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit63.Location = new System.Drawing.Point(653, 424);
		this.textEdit63.Name = "textEdit63";
		this.textEdit63.Properties.ReadOnly = true;
		this.textEdit63.Size = new System.Drawing.Size(100, 20);
		this.textEdit63.TabIndex = 67;
		this.textEdit64.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit64.Location = new System.Drawing.Point(517, 424);
		this.textEdit64.Name = "textEdit64";
		this.textEdit64.Properties.ReadOnly = true;
		this.textEdit64.Size = new System.Drawing.Size(100, 20);
		this.textEdit64.TabIndex = 66;
		this.textEdit65.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit65.Location = new System.Drawing.Point(653, 378);
		this.textEdit65.Name = "textEdit65";
		this.textEdit65.Size = new System.Drawing.Size(100, 20);
		this.textEdit65.TabIndex = 65;
		this.textEdit66.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit66.Location = new System.Drawing.Point(517, 378);
		this.textEdit66.Name = "textEdit66";
		this.textEdit66.Size = new System.Drawing.Size(100, 20);
		this.textEdit66.TabIndex = 64;
		this.textEdit67.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit67.Location = new System.Drawing.Point(653, 333);
		this.textEdit67.Name = "textEdit67";
		this.textEdit67.Size = new System.Drawing.Size(100, 20);
		this.textEdit67.TabIndex = 63;
		this.textEdit68.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit68.Location = new System.Drawing.Point(517, 333);
		this.textEdit68.Name = "textEdit68";
		this.textEdit68.Size = new System.Drawing.Size(100, 20);
		this.textEdit68.TabIndex = 62;
		this.labelControl94.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl94.Location = new System.Drawing.Point(517, 410);
		this.labelControl94.Name = "labelControl94";
		this.labelControl94.Size = new System.Drawing.Size(42, 13);
		this.labelControl94.TabIndex = 61;
		this.labelControl94.Text = "SubTotal";
		this.labelControl95.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl95.Location = new System.Drawing.Point(653, 364);
		this.labelControl95.Name = "labelControl95";
		this.labelControl95.Size = new System.Drawing.Size(22, 13);
		this.labelControl95.TabIndex = 60;
		this.labelControl95.Text = "Free";
		this.labelControl96.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl96.Location = new System.Drawing.Point(517, 364);
		this.labelControl96.Name = "labelControl96";
		this.labelControl96.Size = new System.Drawing.Size(41, 13);
		this.labelControl96.TabIndex = 59;
		this.labelControl96.Text = "Discount";
		this.labelControl97.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl97.Location = new System.Drawing.Point(653, 318);
		this.labelControl97.Name = "labelControl97";
		this.labelControl97.Size = new System.Drawing.Size(34, 13);
		this.labelControl97.TabIndex = 58;
		this.labelControl97.Text = "Freight";
		this.labelControl98.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl98.Location = new System.Drawing.Point(653, 410);
		this.labelControl98.Name = "labelControl98";
		this.labelControl98.Size = new System.Drawing.Size(24, 13);
		this.labelControl98.TabIndex = 57;
		this.labelControl98.Text = "Total";
		this.labelControl99.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl99.Location = new System.Drawing.Point(517, 318);
		this.labelControl99.Name = "labelControl99";
		this.labelControl99.Size = new System.Drawing.Size(55, 13);
		this.labelControl99.TabIndex = 56;
		this.labelControl99.Text = "Discount %";
		this.memoEdit8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.memoEdit8.Location = new System.Drawing.Point(3, 316);
		this.memoEdit8.Name = "memoEdit8";
		this.memoEdit8.Size = new System.Drawing.Size(482, 128);
		this.memoEdit8.TabIndex = 55;
		this.labelControl100.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl100.Location = new System.Drawing.Point(3, 296);
		this.labelControl100.Name = "labelControl100";
		this.labelControl100.Size = new System.Drawing.Size(89, 13);
		this.labelControl100.TabIndex = 54;
		this.labelControl100.Text = "Instructions/Notes";
		this.simpleButton73.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton73.Location = new System.Drawing.Point(767, 490);
		this.simpleButton73.Name = "simpleButton73";
		this.simpleButton73.Size = new System.Drawing.Size(75, 23);
		this.simpleButton73.TabIndex = 42;
		this.simpleButton73.Text = "Delete";
		this.tabReturnVouchers.Controls.Add(this.panelControl18);
		this.tabReturnVouchers.Controls.Add(this.gridControl28);
		this.tabReturnVouchers.Name = "tabReturnVouchers";
		this.tabReturnVouchers.Size = new System.Drawing.Size(851, 484);
		this.tabReturnVouchers.Text = "Return vouchers";
		this.panelControl18.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl18.Controls.Add(this.simpleButton72);
		this.panelControl18.Controls.Add(this.simpleButton79);
		this.panelControl18.Controls.Add(this.simpleButton78);
		this.panelControl18.Location = new System.Drawing.Point(3, 450);
		this.panelControl18.Name = "panelControl18";
		this.panelControl18.Size = new System.Drawing.Size(837, 35);
		this.panelControl18.TabIndex = 7;
		this.simpleButton72.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton72.Location = new System.Drawing.Point(595, 7);
		this.simpleButton72.Name = "simpleButton72";
		this.simpleButton72.Size = new System.Drawing.Size(75, 23);
		this.simpleButton72.TabIndex = 4;
		this.simpleButton72.Text = "Show";
		this.simpleButton79.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton79.Location = new System.Drawing.Point(757, 7);
		this.simpleButton79.Name = "simpleButton79";
		this.simpleButton79.Size = new System.Drawing.Size(75, 23);
		this.simpleButton79.TabIndex = 6;
		this.simpleButton79.Text = "Delete";
		this.simpleButton78.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton78.Location = new System.Drawing.Point(676, 7);
		this.simpleButton78.Name = "simpleButton78";
		this.simpleButton78.Size = new System.Drawing.Size(75, 23);
		this.simpleButton78.TabIndex = 5;
		this.simpleButton78.Text = "New";
		this.gridControl28.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl28.Location = new System.Drawing.Point(0, 0);
		this.gridControl28.MainView = this.gridView28;
		this.gridControl28.Name = "gridControl28";
		this.gridControl28.Size = new System.Drawing.Size(841, 444);
		this.gridControl28.TabIndex = 1;
		this.gridControl28.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView28 });
		this.gridView28.GridControl = this.gridControl28;
		this.gridView28.Name = "gridView28";
		this.tabReturnVouchersDetails.Controls.Add(this.panelControl26);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit72);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit73);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit74);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit75);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit76);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit77);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl105);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl106);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl107);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl108);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl109);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl110);
		this.tabReturnVouchersDetails.Controls.Add(this.memoEdit9);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl111);
		this.tabReturnVouchersDetails.Controls.Add(this.btnReturningOrders);
		this.tabReturnVouchersDetails.Controls.Add(this.btnDeleteReturningOrder);
		this.tabReturnVouchersDetails.Controls.Add(this.btnAddReturningOrder);
		this.tabReturnVouchersDetails.Controls.Add(this.gridControl29);
		this.tabReturnVouchersDetails.Controls.Add(this.btnSearchReturningOrders);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit69);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl101);
		this.tabReturnVouchersDetails.Controls.Add(this.dateEdit7);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl102);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl103);
		this.tabReturnVouchersDetails.Controls.Add(this.labelControl104);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit70);
		this.tabReturnVouchersDetails.Controls.Add(this.textEdit71);
		this.tabReturnVouchersDetails.Name = "tabReturnVouchersDetails";
		this.tabReturnVouchersDetails.Size = new System.Drawing.Size(851, 484);
		this.tabReturnVouchersDetails.Text = "Return vouchers";
		this.panelControl26.Controls.Add(this.panelControl19);
		this.panelControl26.Controls.Add(this.simpleButton4);
		this.panelControl26.Controls.Add(this.textEdit6);
		this.panelControl26.Controls.Add(this.labelControl11);
		this.panelControl26.Controls.Add(this.dateEdit1);
		this.panelControl26.Controls.Add(this.labelControl12);
		this.panelControl26.Controls.Add(this.labelControl13);
		this.panelControl26.Controls.Add(this.labelControl14);
		this.panelControl26.Controls.Add(this.textEdit7);
		this.panelControl26.Controls.Add(this.textEdit8);
		this.panelControl26.Controls.Add(this.textEdit9);
		this.panelControl26.Controls.Add(this.textEdit10);
		this.panelControl26.Controls.Add(this.textEdit11);
		this.panelControl26.Controls.Add(this.textEdit12);
		this.panelControl26.Controls.Add(this.textEdit13);
		this.panelControl26.Controls.Add(this.textEdit26);
		this.panelControl26.Controls.Add(this.labelControl15);
		this.panelControl26.Controls.Add(this.labelControl16);
		this.panelControl26.Controls.Add(this.labelControl17);
		this.panelControl26.Controls.Add(this.labelControl18);
		this.panelControl26.Controls.Add(this.labelControl19);
		this.panelControl26.Controls.Add(this.labelControl20);
		this.panelControl26.Controls.Add(this.memoEdit4);
		this.panelControl26.Controls.Add(this.labelControl21);
		this.panelControl26.Controls.Add(this.simpleButton6);
		this.panelControl26.Controls.Add(this.simpleButton7);
		this.panelControl26.Controls.Add(this.gridControl7);
		this.panelControl26.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panelControl26.Location = new System.Drawing.Point(0, 0);
		this.panelControl26.Name = "panelControl26";
		this.panelControl26.Size = new System.Drawing.Size(851, 484);
		this.panelControl26.TabIndex = 89;
		this.panelControl19.Controls.Add(this.simpleButton84);
		this.panelControl19.Controls.Add(this.simpleButton83);
		this.panelControl19.Controls.Add(this.simpleButton82);
		this.panelControl19.Controls.Add(this.simpleButton81);
		this.panelControl19.Controls.Add(this.simpleButton5);
		this.panelControl19.Location = new System.Drawing.Point(3, 450);
		this.panelControl19.Name = "panelControl19";
		this.panelControl19.Size = new System.Drawing.Size(835, 35);
		this.panelControl19.TabIndex = 62;
		this.simpleButton84.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton84.Location = new System.Drawing.Point(511, 7);
		this.simpleButton84.Name = "simpleButton84";
		this.simpleButton84.Size = new System.Drawing.Size(75, 23);
		this.simpleButton84.TabIndex = 35;
		this.simpleButton84.Text = "Close";
		this.simpleButton83.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton83.Location = new System.Drawing.Point(592, 7);
		this.simpleButton83.Name = "simpleButton83";
		this.simpleButton83.Size = new System.Drawing.Size(75, 23);
		this.simpleButton83.TabIndex = 36;
		this.simpleButton83.Text = "Print";
		this.simpleButton82.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton82.Location = new System.Drawing.Point(673, 7);
		this.simpleButton82.Name = "simpleButton82";
		this.simpleButton82.Size = new System.Drawing.Size(75, 23);
		this.simpleButton82.TabIndex = 37;
		this.simpleButton82.Text = "New";
		this.simpleButton81.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton81.Location = new System.Drawing.Point(754, 7);
		this.simpleButton81.Name = "simpleButton81";
		this.simpleButton81.Size = new System.Drawing.Size(75, 23);
		this.simpleButton81.TabIndex = 38;
		this.simpleButton81.Text = "Delete";
		this.simpleButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.simpleButton5.Location = new System.Drawing.Point(5, 7);
		this.simpleButton5.Name = "simpleButton5";
		this.simpleButton5.Size = new System.Drawing.Size(100, 23);
		this.simpleButton5.TabIndex = 34;
		this.simpleButton5.Text = "Returning Orders";
		this.simpleButton4.Location = new System.Drawing.Point(600, 19);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(43, 23);
		this.simpleButton4.TabIndex = 61;
		this.simpleButton4.Text = "...";
		this.textEdit6.Location = new System.Drawing.Point(323, 22);
		this.textEdit6.Name = "textEdit6";
		this.textEdit6.Properties.ReadOnly = true;
		this.textEdit6.Size = new System.Drawing.Size(259, 20);
		this.textEdit6.TabIndex = 60;
		this.labelControl11.Location = new System.Drawing.Point(324, 8);
		this.labelControl11.Name = "labelControl11";
		this.labelControl11.Size = new System.Drawing.Size(42, 13);
		this.labelControl11.TabIndex = 59;
		this.labelControl11.Text = "Supplier:";
		this.dateEdit1.EditValue = null;
		this.dateEdit1.Location = new System.Drawing.Point(217, 22);
		this.dateEdit1.Name = "dateEdit1";
		this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit1.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dateEdit1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dateEdit1.Size = new System.Drawing.Size(100, 20);
		this.dateEdit1.TabIndex = 58;
		this.labelControl12.Location = new System.Drawing.Point(218, 8);
		this.labelControl12.Name = "labelControl12";
		this.labelControl12.Size = new System.Drawing.Size(27, 13);
		this.labelControl12.TabIndex = 57;
		this.labelControl12.Text = "Date:";
		this.labelControl13.Location = new System.Drawing.Point(112, 6);
		this.labelControl13.Name = "labelControl13";
		this.labelControl13.Size = new System.Drawing.Size(35, 13);
		this.labelControl13.TabIndex = 56;
		this.labelControl13.Text = "Status:";
		this.labelControl14.Location = new System.Drawing.Point(6, 6);
		this.labelControl14.Name = "labelControl14";
		this.labelControl14.Size = new System.Drawing.Size(29, 13);
		this.labelControl14.TabIndex = 55;
		this.labelControl14.Text = "Code:";
		this.textEdit7.Location = new System.Drawing.Point(111, 22);
		this.textEdit7.Name = "textEdit7";
		this.textEdit7.Properties.ReadOnly = true;
		this.textEdit7.Size = new System.Drawing.Size(100, 20);
		this.textEdit7.TabIndex = 54;
		this.textEdit8.Location = new System.Drawing.Point(5, 22);
		this.textEdit8.Name = "textEdit8";
		this.textEdit8.Properties.ReadOnly = true;
		this.textEdit8.Size = new System.Drawing.Size(100, 20);
		this.textEdit8.TabIndex = 53;
		this.textEdit9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit9.Location = new System.Drawing.Point(655, 421);
		this.textEdit9.Name = "textEdit9";
		this.textEdit9.Properties.ReadOnly = true;
		this.textEdit9.Size = new System.Drawing.Size(100, 20);
		this.textEdit9.TabIndex = 52;
		this.textEdit10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit10.Location = new System.Drawing.Point(519, 421);
		this.textEdit10.Name = "textEdit10";
		this.textEdit10.Properties.ReadOnly = true;
		this.textEdit10.Size = new System.Drawing.Size(100, 20);
		this.textEdit10.TabIndex = 51;
		this.textEdit11.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit11.Location = new System.Drawing.Point(655, 375);
		this.textEdit11.Name = "textEdit11";
		this.textEdit11.Size = new System.Drawing.Size(100, 20);
		this.textEdit11.TabIndex = 50;
		this.textEdit12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit12.Location = new System.Drawing.Point(519, 375);
		this.textEdit12.Name = "textEdit12";
		this.textEdit12.Size = new System.Drawing.Size(100, 20);
		this.textEdit12.TabIndex = 49;
		this.textEdit13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit13.Location = new System.Drawing.Point(655, 330);
		this.textEdit13.Name = "textEdit13";
		this.textEdit13.Size = new System.Drawing.Size(100, 20);
		this.textEdit13.TabIndex = 48;
		this.textEdit26.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit26.Location = new System.Drawing.Point(519, 330);
		this.textEdit26.Name = "textEdit26";
		this.textEdit26.Size = new System.Drawing.Size(100, 20);
		this.textEdit26.TabIndex = 47;
		this.labelControl15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl15.Location = new System.Drawing.Point(519, 407);
		this.labelControl15.Name = "labelControl15";
		this.labelControl15.Size = new System.Drawing.Size(42, 13);
		this.labelControl15.TabIndex = 46;
		this.labelControl15.Text = "SubTotal";
		this.labelControl16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl16.Location = new System.Drawing.Point(655, 361);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(22, 13);
		this.labelControl16.TabIndex = 45;
		this.labelControl16.Text = "Free";
		this.labelControl17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl17.Location = new System.Drawing.Point(519, 361);
		this.labelControl17.Name = "labelControl17";
		this.labelControl17.Size = new System.Drawing.Size(41, 13);
		this.labelControl17.TabIndex = 44;
		this.labelControl17.Text = "Discount";
		this.labelControl18.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl18.Location = new System.Drawing.Point(655, 315);
		this.labelControl18.Name = "labelControl18";
		this.labelControl18.Size = new System.Drawing.Size(34, 13);
		this.labelControl18.TabIndex = 43;
		this.labelControl18.Text = "Freight";
		this.labelControl19.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl19.Location = new System.Drawing.Point(655, 407);
		this.labelControl19.Name = "labelControl19";
		this.labelControl19.Size = new System.Drawing.Size(24, 13);
		this.labelControl19.TabIndex = 42;
		this.labelControl19.Text = "Total";
		this.labelControl20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl20.Location = new System.Drawing.Point(519, 315);
		this.labelControl20.Name = "labelControl20";
		this.labelControl20.Size = new System.Drawing.Size(55, 13);
		this.labelControl20.TabIndex = 41;
		this.labelControl20.Text = "Discount %";
		this.memoEdit4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.memoEdit4.Location = new System.Drawing.Point(5, 313);
		this.memoEdit4.Name = "memoEdit4";
		this.memoEdit4.Size = new System.Drawing.Size(482, 128);
		this.memoEdit4.TabIndex = 40;
		this.labelControl21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl21.Location = new System.Drawing.Point(5, 293);
		this.labelControl21.Name = "labelControl21";
		this.labelControl21.Size = new System.Drawing.Size(89, 13);
		this.labelControl21.TabIndex = 39;
		this.labelControl21.Text = "Instructions/Notes";
		this.simpleButton6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton6.Location = new System.Drawing.Point(771, 81);
		this.simpleButton6.Name = "simpleButton6";
		this.simpleButton6.Size = new System.Drawing.Size(75, 23);
		this.simpleButton6.TabIndex = 33;
		this.simpleButton6.Text = "Delete";
		this.simpleButton7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton7.Location = new System.Drawing.Point(771, 52);
		this.simpleButton7.Name = "simpleButton7";
		this.simpleButton7.Size = new System.Drawing.Size(75, 23);
		this.simpleButton7.TabIndex = 32;
		this.simpleButton7.Text = "Add";
		this.gridControl7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl7.Location = new System.Drawing.Point(4, 52);
		this.gridControl7.MainView = this.gridView7;
		this.gridControl7.Name = "gridControl7";
		this.gridControl7.Size = new System.Drawing.Size(756, 235);
		this.gridControl7.TabIndex = 31;
		this.gridControl7.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView7 });
		this.gridView7.GridControl = this.gridControl7;
		this.gridView7.Name = "gridView7";
		this.textEdit72.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit72.Location = new System.Drawing.Point(654, 463);
		this.textEdit72.Name = "textEdit72";
		this.textEdit72.Properties.ReadOnly = true;
		this.textEdit72.Size = new System.Drawing.Size(100, 20);
		this.textEdit72.TabIndex = 88;
		this.textEdit73.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit73.Location = new System.Drawing.Point(518, 463);
		this.textEdit73.Name = "textEdit73";
		this.textEdit73.Properties.ReadOnly = true;
		this.textEdit73.Size = new System.Drawing.Size(100, 20);
		this.textEdit73.TabIndex = 87;
		this.textEdit74.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit74.Location = new System.Drawing.Point(654, 417);
		this.textEdit74.Name = "textEdit74";
		this.textEdit74.Size = new System.Drawing.Size(100, 20);
		this.textEdit74.TabIndex = 86;
		this.textEdit75.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit75.Location = new System.Drawing.Point(518, 417);
		this.textEdit75.Name = "textEdit75";
		this.textEdit75.Size = new System.Drawing.Size(100, 20);
		this.textEdit75.TabIndex = 85;
		this.textEdit76.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit76.Location = new System.Drawing.Point(654, 372);
		this.textEdit76.Name = "textEdit76";
		this.textEdit76.Size = new System.Drawing.Size(100, 20);
		this.textEdit76.TabIndex = 84;
		this.textEdit77.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.textEdit77.Location = new System.Drawing.Point(518, 372);
		this.textEdit77.Name = "textEdit77";
		this.textEdit77.Size = new System.Drawing.Size(100, 20);
		this.textEdit77.TabIndex = 83;
		this.labelControl105.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl105.Location = new System.Drawing.Point(518, 449);
		this.labelControl105.Name = "labelControl105";
		this.labelControl105.Size = new System.Drawing.Size(42, 13);
		this.labelControl105.TabIndex = 82;
		this.labelControl105.Text = "SubTotal";
		this.labelControl106.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl106.Location = new System.Drawing.Point(654, 403);
		this.labelControl106.Name = "labelControl106";
		this.labelControl106.Size = new System.Drawing.Size(22, 13);
		this.labelControl106.TabIndex = 81;
		this.labelControl106.Text = "Free";
		this.labelControl107.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl107.Location = new System.Drawing.Point(518, 403);
		this.labelControl107.Name = "labelControl107";
		this.labelControl107.Size = new System.Drawing.Size(41, 13);
		this.labelControl107.TabIndex = 80;
		this.labelControl107.Text = "Discount";
		this.labelControl108.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl108.Location = new System.Drawing.Point(654, 357);
		this.labelControl108.Name = "labelControl108";
		this.labelControl108.Size = new System.Drawing.Size(34, 13);
		this.labelControl108.TabIndex = 79;
		this.labelControl108.Text = "Freight";
		this.labelControl109.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl109.Location = new System.Drawing.Point(654, 449);
		this.labelControl109.Name = "labelControl109";
		this.labelControl109.Size = new System.Drawing.Size(24, 13);
		this.labelControl109.TabIndex = 78;
		this.labelControl109.Text = "Total";
		this.labelControl110.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl110.Location = new System.Drawing.Point(518, 357);
		this.labelControl110.Name = "labelControl110";
		this.labelControl110.Size = new System.Drawing.Size(55, 13);
		this.labelControl110.TabIndex = 77;
		this.labelControl110.Text = "Discount %";
		this.memoEdit9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.memoEdit9.Location = new System.Drawing.Point(4, 355);
		this.memoEdit9.Name = "memoEdit9";
		this.memoEdit9.Size = new System.Drawing.Size(482, 128);
		this.memoEdit9.TabIndex = 76;
		this.labelControl111.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl111.Location = new System.Drawing.Point(4, 335);
		this.labelControl111.Name = "labelControl111";
		this.labelControl111.Size = new System.Drawing.Size(89, 13);
		this.labelControl111.TabIndex = 75;
		this.labelControl111.Text = "Instructions/Notes";
		this.btnReturningOrders.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnReturningOrders.Location = new System.Drawing.Point(4, 489);
		this.btnReturningOrders.Name = "btnReturningOrders";
		this.btnReturningOrders.Size = new System.Drawing.Size(100, 23);
		this.btnReturningOrders.TabIndex = 74;
		this.btnReturningOrders.Text = "Returning Orders";
		this.btnDeleteReturningOrder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnDeleteReturningOrder.Location = new System.Drawing.Point(768, 77);
		this.btnDeleteReturningOrder.Name = "btnDeleteReturningOrder";
		this.btnDeleteReturningOrder.Size = new System.Drawing.Size(75, 23);
		this.btnDeleteReturningOrder.TabIndex = 73;
		this.btnDeleteReturningOrder.Text = "Delete";
		this.btnAddReturningOrder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnAddReturningOrder.Location = new System.Drawing.Point(768, 48);
		this.btnAddReturningOrder.Name = "btnAddReturningOrder";
		this.btnAddReturningOrder.Size = new System.Drawing.Size(75, 23);
		this.btnAddReturningOrder.TabIndex = 72;
		this.btnAddReturningOrder.Text = "Add";
		this.gridControl29.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl29.Location = new System.Drawing.Point(4, 48);
		this.gridControl29.MainView = this.gridView29;
		this.gridControl29.Name = "gridControl29";
		this.gridControl29.Size = new System.Drawing.Size(758, 281);
		this.gridControl29.TabIndex = 71;
		this.gridControl29.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView29 });
		this.gridView29.GridControl = this.gridControl29;
		this.gridView29.Name = "gridView29";
		this.btnSearchReturningOrders.Location = new System.Drawing.Point(598, 19);
		this.btnSearchReturningOrders.Name = "btnSearchReturningOrders";
		this.btnSearchReturningOrders.Size = new System.Drawing.Size(43, 23);
		this.btnSearchReturningOrders.TabIndex = 70;
		this.btnSearchReturningOrders.Text = "...";
		this.textEdit69.Location = new System.Drawing.Point(321, 22);
		this.textEdit69.Name = "textEdit69";
		this.textEdit69.Properties.ReadOnly = true;
		this.textEdit69.Size = new System.Drawing.Size(259, 20);
		this.textEdit69.TabIndex = 69;
		this.labelControl101.Location = new System.Drawing.Point(322, 8);
		this.labelControl101.Name = "labelControl101";
		this.labelControl101.Size = new System.Drawing.Size(42, 13);
		this.labelControl101.TabIndex = 68;
		this.labelControl101.Text = "Supplier:";
		this.dateEdit7.EditValue = null;
		this.dateEdit7.Location = new System.Drawing.Point(215, 22);
		this.dateEdit7.Name = "dateEdit7";
		this.dateEdit7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateEdit7.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateEdit7.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dateEdit7.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dateEdit7.Size = new System.Drawing.Size(100, 20);
		this.dateEdit7.TabIndex = 67;
		this.labelControl102.Location = new System.Drawing.Point(216, 8);
		this.labelControl102.Name = "labelControl102";
		this.labelControl102.Size = new System.Drawing.Size(27, 13);
		this.labelControl102.TabIndex = 66;
		this.labelControl102.Text = "Date:";
		this.labelControl103.Location = new System.Drawing.Point(110, 6);
		this.labelControl103.Name = "labelControl103";
		this.labelControl103.Size = new System.Drawing.Size(35, 13);
		this.labelControl103.TabIndex = 65;
		this.labelControl103.Text = "Status:";
		this.labelControl104.Location = new System.Drawing.Point(4, 6);
		this.labelControl104.Name = "labelControl104";
		this.labelControl104.Size = new System.Drawing.Size(29, 13);
		this.labelControl104.TabIndex = 64;
		this.labelControl104.Text = "Code:";
		this.textEdit70.Location = new System.Drawing.Point(109, 22);
		this.textEdit70.Name = "textEdit70";
		this.textEdit70.Properties.ReadOnly = true;
		this.textEdit70.Size = new System.Drawing.Size(100, 20);
		this.textEdit70.TabIndex = 63;
		this.textEdit71.Location = new System.Drawing.Point(3, 22);
		this.textEdit71.Name = "textEdit71";
		this.textEdit71.Properties.ReadOnly = true;
		this.textEdit71.Size = new System.Drawing.Size(100, 20);
		this.textEdit71.TabIndex = 62;
		this.tabInfirmaryDiagnosis.Controls.Add(this.panelControl6);
		this.tabInfirmaryDiagnosis.Controls.Add(this.xtraTabControl7);
		this.tabInfirmaryDiagnosis.Controls.Add(this.layoutControl6);
		this.tabInfirmaryDiagnosis.Controls.Add(this.picPerson);
		this.tabInfirmaryDiagnosis.Controls.Add(this.groupControl13);
		this.tabInfirmaryDiagnosis.Name = "tabInfirmaryDiagnosis";
		this.tabInfirmaryDiagnosis.Size = new System.Drawing.Size(851, 484);
		this.tabInfirmaryDiagnosis.Text = "Infirmary Diagnosis";
		this.panelControl6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl6.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl6.Appearance.Options.UseBackColor = true;
		this.panelControl6.Controls.Add(this.checkEdit5);
		this.panelControl6.Controls.Add(this.simpleButton10);
		this.panelControl6.Controls.Add(this.simpleButton13);
		this.panelControl6.Location = new System.Drawing.Point(230, 447);
		this.panelControl6.Name = "panelControl6";
		this.panelControl6.Size = new System.Drawing.Size(609, 35);
		this.panelControl6.TabIndex = 24;
		this.checkEdit5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.checkEdit5.Location = new System.Drawing.Point(362, 10);
		this.checkEdit5.MenuManager = this.ribbon;
		this.checkEdit5.Name = "checkEdit5";
		this.checkEdit5.Properties.Caption = "Print medical form";
		this.checkEdit5.Size = new System.Drawing.Size(118, 19);
		this.checkEdit5.TabIndex = 4;
		this.simpleButton10.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.simpleButton10.Location = new System.Drawing.Point(6, 6);
		this.simpleButton10.Name = "simpleButton10";
		this.simpleButton10.Size = new System.Drawing.Size(93, 23);
		this.simpleButton10.TabIndex = 3;
		this.simpleButton10.Text = "Print";
		this.simpleButton13.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton13.Location = new System.Drawing.Point(486, 6);
		this.simpleButton13.Name = "simpleButton13";
		this.simpleButton13.Size = new System.Drawing.Size(119, 23);
		this.simpleButton13.TabIndex = 0;
		this.simpleButton13.Text = "Continue";
		this.xtraTabControl7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.xtraTabControl7.Location = new System.Drawing.Point(232, 162);
		this.xtraTabControl7.Name = "xtraTabControl7";
		this.xtraTabControl7.SelectedTabPage = this.xtraTabPage3;
		this.xtraTabControl7.Size = new System.Drawing.Size(614, 279);
		this.xtraTabControl7.TabIndex = 23;
		this.xtraTabControl7.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[1] { this.xtraTabPage3 });
		this.xtraTabPage3.Controls.Add(this.layoutControl7);
		this.xtraTabPage3.Controls.Add(this.labelControl23);
		this.xtraTabPage3.Controls.Add(this.cboSemester);
		this.xtraTabPage3.Controls.Add(this.labelControl27);
		this.xtraTabPage3.Controls.Add(this.dt2);
		this.xtraTabPage3.Name = "xtraTabPage3";
		this.xtraTabPage3.Size = new System.Drawing.Size(608, 253);
		this.xtraTabPage3.Text = "Diagnosis information";
		this.layoutControl7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutControl7.Controls.Add(this.txtRecommendation);
		this.layoutControl7.Controls.Add(this.txtTreatment);
		this.layoutControl7.Controls.Add(this.txtDiagnosis);
		this.layoutControl7.Location = new System.Drawing.Point(164, 1);
		this.layoutControl7.Name = "layoutControl7";
		this.layoutControl7.Root = this.layoutControlGroup11;
		this.layoutControl7.Size = new System.Drawing.Size(444, 253);
		this.layoutControl7.TabIndex = 7;
		this.layoutControl7.Text = "layoutControl1";
		this.txtRecommendation.Location = new System.Drawing.Point(4, 193);
		this.txtRecommendation.MenuManager = this.ribbon;
		this.txtRecommendation.Name = "txtRecommendation";
		this.txtRecommendation.Size = new System.Drawing.Size(436, 56);
		this.txtRecommendation.StyleController = this.layoutControl7;
		this.txtRecommendation.TabIndex = 9;
		this.txtTreatment.Location = new System.Drawing.Point(4, 134);
		this.txtTreatment.MenuManager = this.ribbon;
		this.txtTreatment.Name = "txtTreatment";
		this.txtTreatment.Size = new System.Drawing.Size(436, 39);
		this.txtTreatment.StyleController = this.layoutControl7;
		this.txtTreatment.TabIndex = 8;
		this.txtDiagnosis.Location = new System.Drawing.Point(4, 20);
		this.txtDiagnosis.MenuManager = this.ribbon;
		this.txtDiagnosis.Name = "txtDiagnosis";
		this.txtDiagnosis.Size = new System.Drawing.Size(436, 94);
		this.txtDiagnosis.StyleController = this.layoutControl7;
		this.txtDiagnosis.TabIndex = 4;
		this.layoutControlGroup11.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup11.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup11.GroupBordersVisible = false;
		this.layoutControlGroup11.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem101, this.layoutControlItem102, this.layoutControlItem103 });
		this.layoutControlGroup11.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup11.Name = "layoutControlGroup2";
		this.layoutControlGroup11.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup11.Size = new System.Drawing.Size(444, 253);
		this.layoutControlGroup11.Text = "layoutControlGroup2";
		this.layoutControlGroup11.TextVisible = false;
		this.layoutControlItem101.Control = this.txtDiagnosis;
		this.layoutControlItem101.CustomizationFormText = "Diagnosis:";
		this.layoutControlItem101.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem101.Name = "layoutControlItem3";
		this.layoutControlItem101.Size = new System.Drawing.Size(440, 114);
		this.layoutControlItem101.Text = "Diagnosis:";
		this.layoutControlItem101.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem101.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem102.Control = this.txtTreatment;
		this.layoutControlItem102.CustomizationFormText = "Treatment:";
		this.layoutControlItem102.Location = new System.Drawing.Point(0, 114);
		this.layoutControlItem102.Name = "layoutControlItem102";
		this.layoutControlItem102.Size = new System.Drawing.Size(440, 59);
		this.layoutControlItem102.Text = "Treatment:";
		this.layoutControlItem102.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem102.TextSize = new System.Drawing.Size(87, 13);
		this.layoutControlItem103.Control = this.txtRecommendation;
		this.layoutControlItem103.CustomizationFormText = "Recommendations";
		this.layoutControlItem103.Location = new System.Drawing.Point(0, 173);
		this.layoutControlItem103.Name = "layoutControlItem103";
		this.layoutControlItem103.Size = new System.Drawing.Size(440, 76);
		this.layoutControlItem103.Text = "Recommendations";
		this.layoutControlItem103.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem103.TextSize = new System.Drawing.Size(87, 13);
		this.labelControl23.Location = new System.Drawing.Point(4, 32);
		this.labelControl23.Name = "labelControl23";
		this.labelControl23.Size = new System.Drawing.Size(27, 13);
		this.labelControl23.TabIndex = 3;
		this.labelControl23.Text = "Date:";
		this.cboSemester.Location = new System.Drawing.Point(56, 3);
		this.cboSemester.MenuManager = this.ribbon;
		this.cboSemester.Name = "cboSemester";
		this.cboSemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemester.Size = new System.Drawing.Size(106, 20);
		this.cboSemester.TabIndex = 2;
		this.labelControl27.Location = new System.Drawing.Point(3, 10);
		this.labelControl27.Name = "labelControl27";
		this.labelControl27.Size = new System.Drawing.Size(49, 13);
		this.labelControl27.TabIndex = 1;
		this.labelControl27.Text = "Semester:";
		this.dt2.EditValue = null;
		this.dt2.Location = new System.Drawing.Point(56, 25);
		this.dt2.MenuManager = this.ribbon;
		this.dt2.Name = "dt2";
		this.dt2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dt2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dt2.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dt2.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dt2.Properties.Mask.EditMask = "";
		this.dt2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.dt2.Size = new System.Drawing.Size(106, 20);
		this.dt2.TabIndex = 4;
		this.layoutControl6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.layoutControl6.Controls.Add(this.txtHall);
		this.layoutControl6.Controls.Add(this.txtName);
		this.layoutControl6.Controls.Add(this.txtPersonId);
		this.layoutControl6.Controls.Add(this.txtContact);
		this.layoutControl6.Controls.Add(this.txtStatus);
		this.layoutControl6.Location = new System.Drawing.Point(387, 0);
		this.layoutControl6.Name = "layoutControl6";
		this.layoutControl6.Root = this.layoutControlGroup10;
		this.layoutControl6.Size = new System.Drawing.Size(460, 156);
		this.layoutControl6.TabIndex = 22;
		this.layoutControl6.Text = "layoutControl1";
		this.txtHall.Location = new System.Drawing.Point(293, 5);
		this.txtHall.MenuManager = this.ribbon;
		this.txtHall.Name = "txtHall";
		this.txtHall.Properties.ReadOnly = true;
		this.txtHall.Size = new System.Drawing.Size(162, 20);
		this.txtHall.StyleController = this.layoutControl6;
		this.txtHall.TabIndex = 16;
		this.txtName.Location = new System.Drawing.Point(66, 29);
		this.txtName.MenuManager = this.ribbon;
		this.txtName.Name = "txtName";
		this.txtName.Properties.ReadOnly = true;
		this.txtName.Size = new System.Drawing.Size(389, 20);
		this.txtName.StyleController = this.layoutControl6;
		this.txtName.TabIndex = 6;
		this.txtPersonId.Location = new System.Drawing.Point(66, 5);
		this.txtPersonId.MenuManager = this.ribbon;
		this.txtPersonId.Name = "txtPersonId";
		this.txtPersonId.Properties.ReadOnly = true;
		this.txtPersonId.Size = new System.Drawing.Size(162, 20);
		this.txtPersonId.StyleController = this.layoutControl6;
		this.txtPersonId.TabIndex = 5;
		this.txtContact.Location = new System.Drawing.Point(66, 53);
		this.txtContact.MenuManager = this.ribbon;
		this.txtContact.Name = "txtContact";
		this.txtContact.Properties.ReadOnly = true;
		this.txtContact.Size = new System.Drawing.Size(389, 20);
		this.txtContact.StyleController = this.layoutControl6;
		this.txtContact.TabIndex = 8;
		this.txtStatus.Location = new System.Drawing.Point(66, 77);
		this.txtStatus.MenuManager = this.ribbon;
		this.txtStatus.Name = "txtStatus";
		this.txtStatus.Properties.ReadOnly = true;
		this.txtStatus.Size = new System.Drawing.Size(389, 20);
		this.txtStatus.StyleController = this.layoutControl6;
		this.txtStatus.TabIndex = 9;
		this.layoutControlGroup10.CustomizationFormText = "layout";
		this.layoutControlGroup10.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup10.GroupBordersVisible = false;
		this.layoutControlGroup10.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem89, this.layoutControlItem90, this.layoutControlItem91, this.layoutControlItem92, this.layoutControlItem100 });
		this.layoutControlGroup10.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup10.Name = "layout";
		this.layoutControlGroup10.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layoutControlGroup10.Size = new System.Drawing.Size(460, 156);
		this.layoutControlGroup10.Text = "layout";
		this.layoutControlGroup10.TextVisible = false;
		this.layoutControlItem89.Control = this.txtPersonId;
		this.layoutControlItem89.CustomizationFormText = "Student No.";
		this.layoutControlItem89.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem89.Name = "layoutControlItem4";
		this.layoutControlItem89.Size = new System.Drawing.Size(227, 24);
		this.layoutControlItem89.Text = "Student No.";
		this.layoutControlItem89.TextSize = new System.Drawing.Size(58, 13);
		this.layoutControlItem90.Control = this.txtName;
		this.layoutControlItem90.CustomizationFormText = "Surname";
		this.layoutControlItem90.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem90.Name = "layoutControlItem5";
		this.layoutControlItem90.Size = new System.Drawing.Size(454, 24);
		this.layoutControlItem90.Text = "Surname:";
		this.layoutControlItem90.TextSize = new System.Drawing.Size(58, 13);
		this.layoutControlItem91.Control = this.txtContact;
		this.layoutControlItem91.CustomizationFormText = "Sex";
		this.layoutControlItem91.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem91.Name = "layoutControlItem7";
		this.layoutControlItem91.Size = new System.Drawing.Size(454, 24);
		this.layoutControlItem91.Text = "Sex:";
		this.layoutControlItem91.TextSize = new System.Drawing.Size(58, 13);
		this.layoutControlItem92.Control = this.txtStatus;
		this.layoutControlItem92.CustomizationFormText = "Date of birth";
		this.layoutControlItem92.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem92.Name = "layoutControlItem8";
		this.layoutControlItem92.Size = new System.Drawing.Size(454, 78);
		this.layoutControlItem92.Text = "D/B:";
		this.layoutControlItem92.TextSize = new System.Drawing.Size(58, 13);
		this.layoutControlItem100.Control = this.txtHall;
		this.layoutControlItem100.CustomizationFormText = "Hall:";
		this.layoutControlItem100.Location = new System.Drawing.Point(227, 0);
		this.layoutControlItem100.Name = "layoutControlItem34";
		this.layoutControlItem100.Size = new System.Drawing.Size(227, 24);
		this.layoutControlItem100.Text = "Hall:";
		this.layoutControlItem100.TextSize = new System.Drawing.Size(58, 13);
		this.picPerson.Location = new System.Drawing.Point(232, 4);
		this.picPerson.MenuManager = this.ribbon;
		this.picPerson.Name = "picPerson";
		this.picPerson.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picPerson.Size = new System.Drawing.Size(155, 149);
		this.picPerson.TabIndex = 21;
		this.groupControl13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl13.Controls.Add(this.labelControl28);
		this.groupControl13.Controls.Add(this.listBoxControl1);
		this.groupControl13.Controls.Add(this.txtIDNumber);
		this.groupControl13.Controls.Add(this.label1);
		this.groupControl13.Controls.Add(this.radioGroup7);
		this.groupControl13.Location = new System.Drawing.Point(3, 3);
		this.groupControl13.Name = "groupControl13";
		this.groupControl13.Size = new System.Drawing.Size(223, 479);
		this.groupControl13.TabIndex = 20;
		this.groupControl13.Text = "Person type";
		this.labelControl28.Location = new System.Drawing.Point(5, 106);
		this.labelControl28.Name = "labelControl28";
		this.labelControl28.Size = new System.Drawing.Size(89, 13);
		this.labelControl28.TabIndex = 4;
		this.labelControl28.Text = "Treatment records";
		this.listBoxControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.listBoxControl1.Location = new System.Drawing.Point(5, 125);
		this.listBoxControl1.Name = "listBoxControl1";
		this.listBoxControl1.Size = new System.Drawing.Size(212, 348);
		this.listBoxControl1.TabIndex = 3;
		this.txtIDNumber.Location = new System.Drawing.Point(69, 68);
		this.txtIDNumber.MenuManager = this.ribbon;
		this.txtIDNumber.Name = "txtIDNumber";
		this.txtIDNumber.Size = new System.Drawing.Size(148, 20);
		this.txtIDNumber.TabIndex = 2;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(6, 75);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(55, 13);
		this.label1.TabIndex = 1;
		this.label1.Text = "Person Id:";
		this.radioGroup7.Location = new System.Drawing.Point(5, 25);
		this.radioGroup7.MenuManager = this.ribbon;
		this.radioGroup7.Name = "radioGroup7";
		this.radioGroup7.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroup7.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroup7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroup7.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Student"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Employee")
		});
		this.radioGroup7.Size = new System.Drawing.Size(220, 43);
		this.radioGroup7.TabIndex = 0;
		this.tabBorrowRecords.Controls.Add(this.panelControl8);
		this.tabBorrowRecords.Controls.Add(this.gridControl12);
		this.tabBorrowRecords.Name = "tabBorrowRecords";
		this.tabBorrowRecords.Size = new System.Drawing.Size(851, 484);
		this.tabBorrowRecords.Text = "Borrowing records";
		this.panelControl8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl8.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl8.Appearance.Options.UseBackColor = true;
		this.panelControl8.Controls.Add(this.simpleButton21);
		this.panelControl8.Controls.Add(this.simpleButton19);
		this.panelControl8.Controls.Add(this.simpleButton20);
		this.panelControl8.Location = new System.Drawing.Point(3, 477);
		this.panelControl8.Name = "panelControl8";
		this.panelControl8.Size = new System.Drawing.Size(840, 35);
		this.panelControl8.TabIndex = 25;
		this.simpleButton21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton21.Location = new System.Drawing.Point(679, 5);
		this.simpleButton21.Name = "simpleButton21";
		this.simpleButton21.Size = new System.Drawing.Size(75, 23);
		this.simpleButton21.TabIndex = 2;
		this.simpleButton21.Text = "New";
		this.simpleButton19.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton19.Location = new System.Drawing.Point(598, 5);
		this.simpleButton19.Name = "simpleButton19";
		this.simpleButton19.Size = new System.Drawing.Size(75, 23);
		this.simpleButton19.TabIndex = 1;
		this.simpleButton19.Text = "Show";
		this.simpleButton20.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton20.Location = new System.Drawing.Point(760, 5);
		this.simpleButton20.Name = "simpleButton20";
		this.simpleButton20.Size = new System.Drawing.Size(75, 23);
		this.simpleButton20.TabIndex = 0;
		this.simpleButton20.Text = "Delete";
		this.gridControl12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl12.Location = new System.Drawing.Point(0, 0);
		this.gridControl12.MainView = this.gridView12;
		this.gridControl12.MenuManager = this.ribbon;
		this.gridControl12.Name = "gridControl12";
		this.gridControl12.Size = new System.Drawing.Size(843, 471);
		this.gridControl12.TabIndex = 0;
		this.gridControl12.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView12 });
		this.gridView12.GridControl = this.gridControl12;
		this.gridView12.Name = "gridView12";
		this.xtraTabPage1.Controls.Add(this.gridBorrorRecords);
		this.xtraTabPage1.Controls.Add(this.groupControl14);
		this.xtraTabPage1.Controls.Add(this.groupControl12);
		this.xtraTabPage1.Name = "xtraTabPage1";
		this.xtraTabPage1.Size = new System.Drawing.Size(851, 484);
		this.xtraTabPage1.Text = "Books borrowing";
		this.tabStudentRegistrationStandard.Controls.Add(this.simpleButton27);
		this.tabStudentRegistrationStandard.Controls.Add(this.simpleButton26);
		this.tabStudentRegistrationStandard.Controls.Add(this.panelControl9);
		this.tabStudentRegistrationStandard.Controls.Add(this.groupControl17);
		this.tabStudentRegistrationStandard.Controls.Add(this.groupControl16);
		this.tabStudentRegistrationStandard.Controls.Add(this.groupControl15);
		this.tabStudentRegistrationStandard.Name = "tabStudentRegistrationStandard";
		this.tabStudentRegistrationStandard.Size = new System.Drawing.Size(851, 484);
		this.tabStudentRegistrationStandard.Text = "Standard tbl_Stud registration";
		this.simpleButton27.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton27.Location = new System.Drawing.Point(425, 491);
		this.simpleButton27.Name = "simpleButton27";
		this.simpleButton27.Size = new System.Drawing.Size(75, 23);
		this.simpleButton27.TabIndex = 5;
		this.simpleButton27.Text = "Drop subjects";
		this.simpleButton26.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton26.Location = new System.Drawing.Point(562, 491);
		this.simpleButton26.Name = "simpleButton26";
		this.simpleButton26.Size = new System.Drawing.Size(106, 23);
		this.simpleButton26.TabIndex = 4;
		this.simpleButton26.Text = "Register student";
		this.panelControl9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.panelControl9.Controls.Add(this.layoutControl9);
		this.panelControl9.Location = new System.Drawing.Point(423, 81);
		this.panelControl9.Name = "panelControl9";
		this.panelControl9.Size = new System.Drawing.Size(245, 404);
		this.panelControl9.TabIndex = 3;
		this.layoutControl9.Controls.Add(this.panelControl22);
		this.layoutControl9.Controls.Add(this.btnRegisterStudents);
		this.layoutControl9.Controls.Add(this.btnFindStudent);
		this.layoutControl9.Controls.Add(this.txtStudentNumberRegister);
		this.layoutControl9.Controls.Add(this.cboClassR);
		this.layoutControl9.Controls.Add(this.cboTermOfStudyRegister);
		this.layoutControl9.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl9.Location = new System.Drawing.Point(2, 2);
		this.layoutControl9.Name = "layoutControl9";
		this.layoutControl9.Root = this.layoutControlGroup13;
		this.layoutControl9.Size = new System.Drawing.Size(241, 400);
		this.layoutControl9.TabIndex = 0;
		this.layoutControl9.Text = "layoutControl9";
		this.panelControl22.Controls.Add(this.lblClass);
		this.panelControl22.Controls.Add(this.lblClassForRegistration);
		this.panelControl22.Location = new System.Drawing.Point(4, 102);
		this.panelControl22.Name = "panelControl22";
		this.panelControl22.Size = new System.Drawing.Size(233, 268);
		this.panelControl22.TabIndex = 9;
		this.lblClass.Location = new System.Drawing.Point(5, 5);
		this.lblClass.Name = "lblClass";
		this.lblClass.Size = new System.Drawing.Size(70, 13);
		this.lblClass.TabIndex = 1;
		this.lblClass.Text = "Student Class:";
		this.lblClass.Visible = false;
		this.lblClassForRegistration.Location = new System.Drawing.Point(81, 5);
		this.lblClassForRegistration.Name = "lblClassForRegistration";
		this.lblClassForRegistration.Size = new System.Drawing.Size(0, 13);
		this.lblClassForRegistration.TabIndex = 0;
		this.lblClassForRegistration.Visible = false;
		this.btnRegisterStudents.Location = new System.Drawing.Point(4, 374);
		this.btnRegisterStudents.Name = "btnRegisterStudents";
		this.btnRegisterStudents.Size = new System.Drawing.Size(233, 22);
		this.btnRegisterStudents.StyleController = this.layoutControl9;
		this.btnRegisterStudents.TabIndex = 8;
		this.btnRegisterStudents.Text = "Register tbl_Stud";
		this.btnFindStudent.Location = new System.Drawing.Point(4, 28);
		this.btnFindStudent.Name = "btnFindStudent";
		this.btnFindStudent.Size = new System.Drawing.Size(233, 22);
		this.btnFindStudent.StyleController = this.layoutControl9;
		this.btnFindStudent.TabIndex = 5;
		this.btnFindStudent.Text = "Search student";
		this.txtStudentNumberRegister.Location = new System.Drawing.Point(89, 4);
		this.txtStudentNumberRegister.MenuManager = this.ribbon;
		this.txtStudentNumberRegister.Name = "txtStudentNumberRegister";
		this.txtStudentNumberRegister.Properties.ReadOnly = true;
		this.txtStudentNumberRegister.Size = new System.Drawing.Size(148, 20);
		this.txtStudentNumberRegister.StyleController = this.layoutControl9;
		this.txtStudentNumberRegister.TabIndex = 4;
		this.cboClassR.Location = new System.Drawing.Point(89, 78);
		this.cboClassR.MenuManager = this.ribbon;
		this.cboClassR.Name = "cboClassR";
		this.cboClassR.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClassR.Size = new System.Drawing.Size(148, 20);
		this.cboClassR.StyleController = this.layoutControl9;
		this.cboClassR.TabIndex = 7;
		this.cboTermOfStudyRegister.EditValue = "Year";
		this.cboTermOfStudyRegister.Location = new System.Drawing.Point(89, 54);
		this.cboTermOfStudyRegister.MenuManager = this.ribbon;
		this.cboTermOfStudyRegister.Name = "cboTermOfStudyRegister";
		this.cboTermOfStudyRegister.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTermOfStudyRegister.Properties.Items.AddRange(new object[10] { "Year", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020" });
		this.cboTermOfStudyRegister.Size = new System.Drawing.Size(148, 20);
		this.cboTermOfStudyRegister.StyleController = this.layoutControl9;
		this.cboTermOfStudyRegister.TabIndex = 6;
		this.layoutControlGroup13.CustomizationFormText = "layoutControlGroup13";
		this.layoutControlGroup13.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup13.GroupBordersVisible = false;
		this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem110, this.layoutControlItem111, this.layoutControlItem112, this.layoutControlItem113, this.layoutControlItem94, this.layoutControlItem95 });
		this.layoutControlGroup13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup13.Name = "layoutControlGroup13";
		this.layoutControlGroup13.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup13.Size = new System.Drawing.Size(241, 400);
		this.layoutControlGroup13.Text = "layoutControlGroup13";
		this.layoutControlGroup13.TextVisible = false;
		this.layoutControlItem110.Control = this.txtStudentNumberRegister;
		this.layoutControlItem110.CustomizationFormText = "Student Number:";
		this.layoutControlItem110.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem110.Name = "layoutControlItem110";
		this.layoutControlItem110.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem110.Text = "Student Number:";
		this.layoutControlItem110.TextSize = new System.Drawing.Size(82, 13);
		this.layoutControlItem111.Control = this.btnFindStudent;
		this.layoutControlItem111.CustomizationFormText = "layoutControlItem111";
		this.layoutControlItem111.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem111.Name = "layoutControlItem111";
		this.layoutControlItem111.Size = new System.Drawing.Size(237, 26);
		this.layoutControlItem111.Text = "layoutControlItem111";
		this.layoutControlItem111.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem111.TextToControlDistance = 0;
		this.layoutControlItem111.TextVisible = false;
		this.layoutControlItem112.Control = this.cboTermOfStudyRegister;
		this.layoutControlItem112.CustomizationFormText = "Academic year:";
		this.layoutControlItem112.Location = new System.Drawing.Point(0, 50);
		this.layoutControlItem112.Name = "layoutControlItem112";
		this.layoutControlItem112.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem112.Text = "Academic year:";
		this.layoutControlItem112.TextSize = new System.Drawing.Size(82, 13);
		this.layoutControlItem113.Control = this.cboClassR;
		this.layoutControlItem113.CustomizationFormText = "Class:";
		this.layoutControlItem113.Location = new System.Drawing.Point(0, 74);
		this.layoutControlItem113.Name = "layoutControlItem113";
		this.layoutControlItem113.Size = new System.Drawing.Size(237, 24);
		this.layoutControlItem113.Text = "Class:";
		this.layoutControlItem113.TextSize = new System.Drawing.Size(82, 13);
		this.layoutControlItem94.Control = this.btnRegisterStudents;
		this.layoutControlItem94.CustomizationFormText = "layoutControlItem94";
		this.layoutControlItem94.Location = new System.Drawing.Point(0, 370);
		this.layoutControlItem94.Name = "layoutControlItem94";
		this.layoutControlItem94.Size = new System.Drawing.Size(237, 26);
		this.layoutControlItem94.Text = "layoutControlItem94";
		this.layoutControlItem94.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem94.TextToControlDistance = 0;
		this.layoutControlItem94.TextVisible = false;
		this.layoutControlItem95.Control = this.panelControl22;
		this.layoutControlItem95.CustomizationFormText = "layoutControlItem95";
		this.layoutControlItem95.Location = new System.Drawing.Point(0, 98);
		this.layoutControlItem95.Name = "layoutControlItem95";
		this.layoutControlItem95.Size = new System.Drawing.Size(237, 272);
		this.layoutControlItem95.Text = "layoutControlItem95";
		this.layoutControlItem95.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem95.TextToControlDistance = 0;
		this.layoutControlItem95.TextVisible = false;
		this.groupControl17.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl17.Controls.Add(this.chkLstSubjects);
		this.groupControl17.Controls.Add(this.chkSelectAll);
		this.groupControl17.Location = new System.Drawing.Point(172, 81);
		this.groupControl17.Name = "groupControl17";
		this.groupControl17.Size = new System.Drawing.Size(245, 404);
		this.groupControl17.TabIndex = 2;
		this.groupControl17.Text = "Subject list";
		this.chkLstSubjects.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.chkLstSubjects.Location = new System.Drawing.Point(6, 52);
		this.chkLstSubjects.Name = "chkLstSubjects";
		this.chkLstSubjects.Size = new System.Drawing.Size(234, 350);
		this.chkLstSubjects.TabIndex = 1;
		this.chkSelectAll.Location = new System.Drawing.Point(6, 26);
		this.chkSelectAll.MenuManager = this.ribbon;
		this.chkSelectAll.Name = "chkSelectAll";
		this.chkSelectAll.Properties.Caption = "Select All";
		this.chkSelectAll.Size = new System.Drawing.Size(75, 19);
		this.chkSelectAll.TabIndex = 0;
		this.groupControl16.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl16.Controls.Add(this.radioGroupMode);
		this.groupControl16.Location = new System.Drawing.Point(423, 3);
		this.groupControl16.Name = "groupControl16";
		this.groupControl16.Size = new System.Drawing.Size(245, 72);
		this.groupControl16.TabIndex = 1;
		this.groupControl16.Text = "Registration mode";
		this.radioGroupMode.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroupMode.Location = new System.Drawing.Point(2, 21);
		this.radioGroupMode.MenuManager = this.ribbon;
		this.radioGroupMode.Name = "radioGroupMode";
		this.radioGroupMode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupMode.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupMode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Entire class"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single student")
		});
		this.radioGroupMode.Size = new System.Drawing.Size(241, 49);
		this.radioGroupMode.TabIndex = 0;
		this.groupControl15.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl15.Controls.Add(this.radioGroupLevelToRegister);
		this.groupControl15.Location = new System.Drawing.Point(172, 3);
		this.groupControl15.Name = "groupControl15";
		this.groupControl15.Size = new System.Drawing.Size(245, 72);
		this.groupControl15.TabIndex = 0;
		this.groupControl15.Text = "Select group";
		this.radioGroupLevelToRegister.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroupLevelToRegister.Location = new System.Drawing.Point(2, 21);
		this.radioGroupLevelToRegister.MenuManager = this.ribbon;
		this.radioGroupLevelToRegister.Name = "radioGroupLevelToRegister";
		this.radioGroupLevelToRegister.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupLevelToRegister.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupLevelToRegister.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupLevelToRegister.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "O Level Students"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "A Level Students")
		});
		this.radioGroupLevelToRegister.Size = new System.Drawing.Size(241, 49);
		this.radioGroupLevelToRegister.TabIndex = 0;
		this.tabStudentRegistrationAdvanced.Controls.Add(this.comboBoxEdit10);
		this.tabStudentRegistrationAdvanced.Controls.Add(this.comboBoxEdit5);
		this.tabStudentRegistrationAdvanced.Controls.Add(this.labelControl63);
		this.tabStudentRegistrationAdvanced.Controls.Add(this.labelControl38);
		this.tabStudentRegistrationAdvanced.Controls.Add(this.panelControl10);
		this.tabStudentRegistrationAdvanced.Name = "tabStudentRegistrationAdvanced";
		this.tabStudentRegistrationAdvanced.Size = new System.Drawing.Size(851, 484);
		this.tabStudentRegistrationAdvanced.Text = "Advanced tbl_Stud registration";
		this.comboBoxEdit10.Location = new System.Drawing.Point(215, 8);
		this.comboBoxEdit10.MenuManager = this.ribbon;
		this.comboBoxEdit10.Name = "comboBoxEdit10";
		this.comboBoxEdit10.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit10.Size = new System.Drawing.Size(100, 20);
		this.comboBoxEdit10.TabIndex = 30;
		this.comboBoxEdit5.Location = new System.Drawing.Point(34, 8);
		this.comboBoxEdit5.MenuManager = this.ribbon;
		this.comboBoxEdit5.Name = "comboBoxEdit5";
		this.comboBoxEdit5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit5.Size = new System.Drawing.Size(100, 20);
		this.comboBoxEdit5.TabIndex = 29;
		this.labelControl63.Location = new System.Drawing.Point(164, 15);
		this.labelControl63.Name = "labelControl63";
		this.labelControl63.Size = new System.Drawing.Size(45, 13);
		this.labelControl63.TabIndex = 28;
		this.labelControl63.Text = "Semetser";
		this.labelControl38.Location = new System.Drawing.Point(3, 15);
		this.labelControl38.Name = "labelControl38";
		this.labelControl38.Size = new System.Drawing.Size(25, 13);
		this.labelControl38.TabIndex = 27;
		this.labelControl38.Text = "Class";
		this.panelControl10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl10.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl10.Appearance.Options.UseBackColor = true;
		this.panelControl10.Controls.Add(this.simpleButton33);
		this.panelControl10.Location = new System.Drawing.Point(2, 450);
		this.panelControl10.Name = "panelControl10";
		this.panelControl10.Size = new System.Drawing.Size(840, 35);
		this.panelControl10.TabIndex = 26;
		this.simpleButton33.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.simpleButton33.Location = new System.Drawing.Point(760, 5);
		this.simpleButton33.Name = "simpleButton33";
		this.simpleButton33.Size = new System.Drawing.Size(75, 23);
		this.simpleButton33.TabIndex = 0;
		this.simpleButton33.Text = "Register";
		this.tabSelectSubjects.Controls.Add(this.lbSubjectsSelected);
		this.tabSelectSubjects.Controls.Add(this.btnAppend);
		this.tabSelectSubjects.Controls.Add(this.lblStatus);
		this.tabSelectSubjects.Controls.Add(this.simpleButton35);
		this.tabSelectSubjects.Controls.Add(this.simpleButton34);
		this.tabSelectSubjects.Controls.Add(this.simpleButton32);
		this.tabSelectSubjects.Controls.Add(this.simpleButton31);
		this.tabSelectSubjects.Controls.Add(this.lbSubjects);
		this.tabSelectSubjects.Controls.Add(this.groupControl18);
		this.tabSelectSubjects.Name = "tabSelectSubjects";
		this.tabSelectSubjects.Size = new System.Drawing.Size(851, 484);
		this.tabSelectSubjects.Text = "Select subjects";
		this.lbSubjectsSelected.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.lbSubjectsSelected.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
		this.lbSubjectsSelected.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
		this.lbSubjectsSelected.Location = new System.Drawing.Point(457, 80);
		this.lbSubjectsSelected.Name = "lbSubjectsSelected";
		this.lbSubjectsSelected.Size = new System.Drawing.Size(199, 369);
		this.lbSubjectsSelected.TabIndex = 9;
		this.btnAppend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.btnAppend.Location = new System.Drawing.Point(212, 462);
		this.btnAppend.Name = "btnAppend";
		this.btnAppend.Size = new System.Drawing.Size(75, 23);
		this.btnAppend.TabIndex = 8;
		this.btnAppend.Text = "Append";
		this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.lblStatus.Location = new System.Drawing.Point(293, 472);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(0, 13);
		this.lblStatus.TabIndex = 7;
		this.simpleButton35.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton35.Location = new System.Drawing.Point(579, 491);
		this.simpleButton35.Name = "simpleButton35";
		this.simpleButton35.Size = new System.Drawing.Size(75, 23);
		this.simpleButton35.TabIndex = 6;
		this.simpleButton35.Text = "Add subjects";
		this.simpleButton34.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton34.Location = new System.Drawing.Point(415, 290);
		this.simpleButton34.Name = "simpleButton34";
		this.simpleButton34.Size = new System.Drawing.Size(35, 23);
		this.simpleButton34.TabIndex = 5;
		this.simpleButton34.Text = "<<";
		this.simpleButton32.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton32.Location = new System.Drawing.Point(416, 261);
		this.simpleButton32.Name = "simpleButton32";
		this.simpleButton32.Size = new System.Drawing.Size(35, 23);
		this.simpleButton32.TabIndex = 4;
		this.simpleButton32.Text = "<";
		this.simpleButton31.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton31.Location = new System.Drawing.Point(416, 232);
		this.simpleButton31.Name = "simpleButton31";
		this.simpleButton31.Size = new System.Drawing.Size(35, 23);
		this.simpleButton31.TabIndex = 3;
		this.simpleButton31.Text = ">";
		this.lbSubjects.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.lbSubjects.CheckOnClick = true;
		this.lbSubjects.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
		this.lbSubjects.Location = new System.Drawing.Point(212, 80);
		this.lbSubjects.Name = "lbSubjects";
		this.lbSubjects.Size = new System.Drawing.Size(197, 369);
		this.lbSubjects.TabIndex = 1;
		this.groupControl18.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl18.Controls.Add(this.radioGroupLevel);
		this.groupControl18.Location = new System.Drawing.Point(212, 3);
		this.groupControl18.Name = "groupControl18";
		this.groupControl18.Size = new System.Drawing.Size(444, 71);
		this.groupControl18.TabIndex = 0;
		this.groupControl18.Text = "Select level";
		this.radioGroupLevel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.radioGroupLevel.Location = new System.Drawing.Point(2, 21);
		this.radioGroupLevel.MenuManager = this.ribbon;
		this.radioGroupLevel.Name = "radioGroupLevel";
		this.radioGroupLevel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupLevel.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupLevel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupLevel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "O Level"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "A Level")
		});
		this.radioGroupLevel.Size = new System.Drawing.Size(440, 48);
		this.radioGroupLevel.TabIndex = 0;
		this.tabOLevelGradingScale.Controls.Add(this.tabMainGradings);
		this.tabOLevelGradingScale.Controls.Add(this.tabOLevelScales);
		this.tabOLevelGradingScale.Name = "tabOLevelGradingScale";
		this.tabOLevelGradingScale.Size = new System.Drawing.Size(851, 484);
		this.tabOLevelGradingScale.Text = "O Level grading scale";
		this.tabMainGradings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabMainGradings.Location = new System.Drawing.Point(3, 0);
		this.tabMainGradings.Name = "tabMainGradings";
		this.tabMainGradings.SelectedTabPage = this.tabGradings1;
		this.tabMainGradings.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
		this.tabMainGradings.Size = new System.Drawing.Size(848, 294);
		this.tabMainGradings.TabIndex = 2;
		this.tabMainGradings.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[2] { this.tabGradings1, this.tabGradings2 });
		this.tabGradings1.Controls.Add(this.dgOLevelGrades);
		this.tabGradings1.Name = "tabGradings1";
		this.tabGradings1.Size = new System.Drawing.Size(842, 288);
		this.tabGradings1.Text = "xtraTabPage4";
		this.dgOLevelGrades.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgOLevelGrades.Location = new System.Drawing.Point(0, 0);
		this.dgOLevelGrades.MainView = this.gridViewOLevelGrades;
		this.dgOLevelGrades.MenuManager = this.ribbon;
		this.dgOLevelGrades.Name = "dgOLevelGrades";
		this.dgOLevelGrades.Size = new System.Drawing.Size(842, 288);
		this.dgOLevelGrades.TabIndex = 0;
		this.dgOLevelGrades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewOLevelGrades });
		this.gridViewOLevelGrades.GridControl = this.dgOLevelGrades;
		this.gridViewOLevelGrades.Name = "gridViewOLevelGrades";
		this.gridViewOLevelGrades.OptionsBehavior.Editable = false;
		this.gridViewOLevelGrades.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewOLevelGrades.OptionsCustomization.AllowGroup = false;
		this.gridViewOLevelGrades.OptionsView.ShowGroupPanel = false;
		this.tabGradings2.Controls.Add(this.gridOLevelGrading);
		this.tabGradings2.Name = "tabGradings2";
		this.tabGradings2.Size = new System.Drawing.Size(842, 288);
		this.tabGradings2.Text = "xtraTabPage5";
		this.gridOLevelGrading.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridOLevelGrading.Location = new System.Drawing.Point(0, 0);
		this.gridOLevelGrading.MainView = this.gridViewOLevelGrading;
		this.gridOLevelGrading.MenuManager = this.ribbon;
		this.gridOLevelGrading.Name = "gridOLevelGrading";
		this.gridOLevelGrading.Size = new System.Drawing.Size(842, 288);
		this.gridOLevelGrading.TabIndex = 0;
		this.gridOLevelGrading.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewOLevelGrading });
		this.gridViewOLevelGrading.GridControl = this.gridOLevelGrading;
		this.gridViewOLevelGrading.Name = "gridViewOLevelGrading";
		this.gridViewOLevelGrading.OptionsBehavior.Editable = false;
		this.gridViewOLevelGrading.OptionsCustomization.AllowGroup = false;
		this.gridViewOLevelGrading.OptionsView.ShowGroupPanel = false;
		this.tabOLevelScales.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabOLevelScales.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.tabOLevelScales.Location = new System.Drawing.Point(1, 306);
		this.tabOLevelScales.Name = "tabOLevelScales";
		this.tabOLevelScales.SelectedTabPage = this.tabGradingScale;
		this.tabOLevelScales.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
		this.tabOLevelScales.Size = new System.Drawing.Size(850, 175);
		this.tabOLevelScales.TabIndex = 1;
		this.tabOLevelScales.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[2] { this.tabGradingScale, this.tabDivisionScale });
		this.tabGradingScale.Controls.Add(this.lblOLevelGSId);
		this.tabGradingScale.Controls.Add(this.labelControl123);
		this.tabGradingScale.Controls.Add(this.labelControl122);
		this.tabGradingScale.Controls.Add(this.txtOLevelComment3);
		this.tabGradingScale.Controls.Add(this.txtOLevelComment2);
		this.tabGradingScale.Controls.Add(this.txtOLevelComment);
		this.tabGradingScale.Controls.Add(this.labelControl71);
		this.tabGradingScale.Controls.Add(this.txtGradePoints);
		this.tabGradingScale.Controls.Add(this.labelControl70);
		this.tabGradingScale.Controls.Add(this.btnUpdateGradingScale);
		this.tabGradingScale.Controls.Add(this.labelControl67);
		this.tabGradingScale.Controls.Add(this.labelControl68);
		this.tabGradingScale.Controls.Add(this.labelControl69);
		this.tabGradingScale.Controls.Add(this.txtGradeEnd);
		this.tabGradingScale.Controls.Add(this.txtGradeDebut);
		this.tabGradingScale.Controls.Add(this.txtGradeCategory);
		this.tabGradingScale.Name = "tabGradingScale";
		this.tabGradingScale.Size = new System.Drawing.Size(844, 169);
		this.tabGradingScale.Text = "Grading scale";
		this.lblOLevelGSId.Location = new System.Drawing.Point(67, 134);
		this.lblOLevelGSId.Name = "lblOLevelGSId";
		this.lblOLevelGSId.Size = new System.Drawing.Size(0, 13);
		this.lblOLevelGSId.TabIndex = 25;
		this.lblOLevelGSId.Visible = false;
		this.labelControl123.Location = new System.Drawing.Point(3, 115);
		this.labelControl123.Name = "labelControl123";
		this.labelControl123.Size = new System.Drawing.Size(58, 13);
		this.labelControl123.TabIndex = 24;
		this.labelControl123.Text = "Comment 3:";
		this.labelControl122.Location = new System.Drawing.Point(3, 90);
		this.labelControl122.Name = "labelControl122";
		this.labelControl122.Size = new System.Drawing.Size(58, 13);
		this.labelControl122.TabIndex = 23;
		this.labelControl122.Text = "Comment 2:";
		this.txtOLevelComment3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment3.Location = new System.Drawing.Point(67, 108);
		this.txtOLevelComment3.MenuManager = this.ribbon;
		this.txtOLevelComment3.Name = "txtOLevelComment3";
		this.txtOLevelComment3.Size = new System.Drawing.Size(774, 20);
		this.txtOLevelComment3.TabIndex = 22;
		this.txtOLevelComment2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment2.Location = new System.Drawing.Point(66, 84);
		this.txtOLevelComment2.MenuManager = this.ribbon;
		this.txtOLevelComment2.Name = "txtOLevelComment2";
		this.txtOLevelComment2.Size = new System.Drawing.Size(775, 20);
		this.txtOLevelComment2.TabIndex = 21;
		this.txtOLevelComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOLevelComment.Location = new System.Drawing.Point(67, 60);
		this.txtOLevelComment.MenuManager = this.ribbon;
		this.txtOLevelComment.Name = "txtOLevelComment";
		this.txtOLevelComment.Size = new System.Drawing.Size(774, 20);
		this.txtOLevelComment.TabIndex = 20;
		this.labelControl71.Location = new System.Drawing.Point(3, 67);
		this.labelControl71.Name = "labelControl71";
		this.labelControl71.Size = new System.Drawing.Size(58, 13);
		this.labelControl71.TabIndex = 19;
		this.labelControl71.Text = "Comment 1:";
		this.txtGradePoints.Location = new System.Drawing.Point(66, 34);
		this.txtGradePoints.MenuManager = this.ribbon;
		this.txtGradePoints.Name = "txtGradePoints";
		this.txtGradePoints.Properties.ReadOnly = true;
		this.txtGradePoints.Size = new System.Drawing.Size(147, 20);
		this.txtGradePoints.TabIndex = 18;
		this.labelControl70.Location = new System.Drawing.Point(28, 41);
		this.labelControl70.Name = "labelControl70";
		this.labelControl70.Size = new System.Drawing.Size(33, 13);
		this.labelControl70.TabIndex = 17;
		this.labelControl70.Text = "Points:";
		this.btnUpdateGradingScale.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdateGradingScale.Location = new System.Drawing.Point(693, 142);
		this.btnUpdateGradingScale.Name = "btnUpdateGradingScale";
		this.btnUpdateGradingScale.Size = new System.Drawing.Size(148, 23);
		this.btnUpdateGradingScale.TabIndex = 16;
		this.btnUpdateGradingScale.Text = "Update Grading Scale";
		this.labelControl67.Location = new System.Drawing.Point(301, 41);
		this.labelControl67.Name = "labelControl67";
		this.labelControl67.Size = new System.Drawing.Size(22, 13);
		this.labelControl67.TabIndex = 14;
		this.labelControl67.Text = "End:";
		this.labelControl68.Location = new System.Drawing.Point(290, 15);
		this.labelControl68.Name = "labelControl68";
		this.labelControl68.Size = new System.Drawing.Size(33, 13);
		this.labelControl68.TabIndex = 13;
		this.labelControl68.Text = "Debut:";
		this.labelControl69.Location = new System.Drawing.Point(12, 15);
		this.labelControl69.Name = "labelControl69";
		this.labelControl69.Size = new System.Drawing.Size(49, 13);
		this.labelControl69.TabIndex = 12;
		this.labelControl69.Text = "Category:";
		this.txtGradeEnd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtGradeEnd.Location = new System.Drawing.Point(329, 34);
		this.txtGradeEnd.MenuManager = this.ribbon;
		this.txtGradeEnd.Name = "txtGradeEnd";
		this.txtGradeEnd.Size = new System.Drawing.Size(512, 20);
		this.txtGradeEnd.TabIndex = 11;
		this.txtGradeDebut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtGradeDebut.Location = new System.Drawing.Point(329, 8);
		this.txtGradeDebut.MenuManager = this.ribbon;
		this.txtGradeDebut.Name = "txtGradeDebut";
		this.txtGradeDebut.Size = new System.Drawing.Size(512, 20);
		this.txtGradeDebut.TabIndex = 10;
		this.txtGradeCategory.Location = new System.Drawing.Point(67, 8);
		this.txtGradeCategory.MenuManager = this.ribbon;
		this.txtGradeCategory.Name = "txtGradeCategory";
		this.txtGradeCategory.Properties.ReadOnly = true;
		this.txtGradeCategory.Size = new System.Drawing.Size(146, 20);
		this.txtGradeCategory.TabIndex = 9;
		this.tabDivisionScale.Controls.Add(this.lblGrade);
		this.tabDivisionScale.Controls.Add(this.labelControl128);
		this.tabDivisionScale.Controls.Add(this.labelControl127);
		this.tabDivisionScale.Controls.Add(this.labelControl126);
		this.tabDivisionScale.Controls.Add(this.txtHeadTeacherComment);
		this.tabDivisionScale.Controls.Add(this.txtDOSComment);
		this.tabDivisionScale.Controls.Add(this.txtClassTeacherComment);
		this.tabDivisionScale.Controls.Add(this.btnUpdateGrades);
		this.tabDivisionScale.Controls.Add(this.labelControl66);
		this.tabDivisionScale.Controls.Add(this.labelControl65);
		this.tabDivisionScale.Controls.Add(this.labelControl64);
		this.tabDivisionScale.Controls.Add(this.txtEnd);
		this.tabDivisionScale.Controls.Add(this.txtDebut);
		this.tabDivisionScale.Controls.Add(this.txtCategory);
		this.tabDivisionScale.Name = "tabDivisionScale";
		this.tabDivisionScale.Size = new System.Drawing.Size(844, 169);
		this.tabDivisionScale.Text = "Division scale";
		this.lblGrade.Location = new System.Drawing.Point(4, 127);
		this.lblGrade.Name = "lblGrade";
		this.lblGrade.Size = new System.Drawing.Size(0, 13);
		this.lblGrade.TabIndex = 15;
		this.lblGrade.Visible = false;
		this.labelControl128.Location = new System.Drawing.Point(4, 113);
		this.labelControl128.Name = "labelControl128";
		this.labelControl128.Size = new System.Drawing.Size(112, 13);
		this.labelControl128.TabIndex = 14;
		this.labelControl128.Text = "Headteacher comment:";
		this.labelControl127.Location = new System.Drawing.Point(4, 90);
		this.labelControl127.Name = "labelControl127";
		this.labelControl127.Size = new System.Drawing.Size(73, 13);
		this.labelControl127.TabIndex = 13;
		this.labelControl127.Text = "DOS Comment:";
		this.labelControl126.Location = new System.Drawing.Point(4, 67);
		this.labelControl126.Name = "labelControl126";
		this.labelControl126.Size = new System.Drawing.Size(115, 13);
		this.labelControl126.TabIndex = 12;
		this.labelControl126.Text = "Class teacher comment:";
		this.txtHeadTeacherComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtHeadTeacherComment.Location = new System.Drawing.Point(134, 107);
		this.txtHeadTeacherComment.MenuManager = this.ribbon;
		this.txtHeadTeacherComment.Name = "txtHeadTeacherComment";
		this.txtHeadTeacherComment.Size = new System.Drawing.Size(707, 20);
		this.txtHeadTeacherComment.TabIndex = 11;
		this.txtDOSComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtDOSComment.Location = new System.Drawing.Point(134, 83);
		this.txtDOSComment.MenuManager = this.ribbon;
		this.txtDOSComment.Name = "txtDOSComment";
		this.txtDOSComment.Size = new System.Drawing.Size(707, 20);
		this.txtDOSComment.TabIndex = 10;
		this.txtClassTeacherComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtClassTeacherComment.Location = new System.Drawing.Point(134, 59);
		this.txtClassTeacherComment.MenuManager = this.ribbon;
		this.txtClassTeacherComment.Name = "txtClassTeacherComment";
		this.txtClassTeacherComment.Size = new System.Drawing.Size(707, 20);
		this.txtClassTeacherComment.TabIndex = 9;
		this.btnUpdateGrades.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdateGrades.Location = new System.Drawing.Point(693, 142);
		this.btnUpdateGrades.Name = "btnUpdateGrades";
		this.btnUpdateGrades.Size = new System.Drawing.Size(148, 23);
		this.btnUpdateGrades.TabIndex = 8;
		this.btnUpdateGrades.Text = "Update Division Scale";
		this.labelControl66.Location = new System.Drawing.Point(197, 40);
		this.labelControl66.Name = "labelControl66";
		this.labelControl66.Size = new System.Drawing.Size(22, 13);
		this.labelControl66.TabIndex = 6;
		this.labelControl66.Text = "End:";
		this.labelControl65.Location = new System.Drawing.Point(4, 38);
		this.labelControl65.Name = "labelControl65";
		this.labelControl65.Size = new System.Drawing.Size(33, 13);
		this.labelControl65.TabIndex = 5;
		this.labelControl65.Text = "Debut:";
		this.labelControl64.Location = new System.Drawing.Point(4, 15);
		this.labelControl64.Name = "labelControl64";
		this.labelControl64.Size = new System.Drawing.Size(33, 13);
		this.labelControl64.TabIndex = 4;
		this.labelControl64.Text = "Grade:";
		this.txtEnd.Location = new System.Drawing.Point(225, 33);
		this.txtEnd.MenuManager = this.ribbon;
		this.txtEnd.Name = "txtEnd";
		this.txtEnd.Size = new System.Drawing.Size(57, 20);
		this.txtEnd.TabIndex = 3;
		this.txtDebut.Location = new System.Drawing.Point(134, 33);
		this.txtDebut.MenuManager = this.ribbon;
		this.txtDebut.Name = "txtDebut";
		this.txtDebut.Size = new System.Drawing.Size(57, 20);
		this.txtDebut.TabIndex = 2;
		this.txtCategory.Location = new System.Drawing.Point(134, 8);
		this.txtCategory.MenuManager = this.ribbon;
		this.txtCategory.Name = "txtCategory";
		this.txtCategory.Size = new System.Drawing.Size(148, 20);
		this.txtCategory.TabIndex = 1;
		this.tabALevelGradingScale.Controls.Add(this.tabALevelGrading);
		this.tabALevelGradingScale.Controls.Add(this.tabALevelScales);
		this.tabALevelGradingScale.Name = "tabALevelGradingScale";
		this.tabALevelGradingScale.Size = new System.Drawing.Size(851, 484);
		this.tabALevelGradingScale.Text = "A Level grading scale";
		this.tabALevelGrading.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabALevelGrading.Location = new System.Drawing.Point(3, 0);
		this.tabALevelGrading.Name = "tabALevelGrading";
		this.tabALevelGrading.SelectedTabPage = this.tabALevelGradings1;
		this.tabALevelGrading.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
		this.tabALevelGrading.Size = new System.Drawing.Size(846, 295);
		this.tabALevelGrading.TabIndex = 4;
		this.tabALevelGrading.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[2] { this.tabALevelGradings1, this.tabALevelGrading2 });
		this.tabALevelGradings1.Controls.Add(this.dgALevelGrades);
		this.tabALevelGradings1.Name = "tabALevelGradings1";
		this.tabALevelGradings1.Size = new System.Drawing.Size(840, 289);
		this.tabALevelGradings1.Text = "xtraTabPage4";
		this.dgALevelGrades.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgALevelGrades.Location = new System.Drawing.Point(0, 0);
		this.dgALevelGrades.MainView = this.gridViewALGrades;
		this.dgALevelGrades.MenuManager = this.ribbon;
		this.dgALevelGrades.Name = "dgALevelGrades";
		this.dgALevelGrades.Size = new System.Drawing.Size(840, 289);
		this.dgALevelGrades.TabIndex = 2;
		this.dgALevelGrades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewALGrades });
		this.gridViewALGrades.GridControl = this.dgALevelGrades;
		this.gridViewALGrades.Name = "gridViewALGrades";
		this.gridViewALGrades.OptionsBehavior.Editable = false;
		this.gridViewALGrades.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewALGrades.OptionsCustomization.AllowGroup = false;
		this.gridViewALGrades.OptionsView.ShowGroupPanel = false;
		this.tabALevelGrading2.Controls.Add(this.dgALevelGrades2);
		this.tabALevelGrading2.Name = "tabALevelGrading2";
		this.tabALevelGrading2.Size = new System.Drawing.Size(840, 289);
		this.tabALevelGrading2.Text = "xtraTabPage5";
		this.dgALevelGrades2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgALevelGrades2.Location = new System.Drawing.Point(0, 0);
		this.dgALevelGrades2.MainView = this.gridViewALGrades2;
		this.dgALevelGrades2.MenuManager = this.ribbon;
		this.dgALevelGrades2.Name = "dgALevelGrades2";
		this.dgALevelGrades2.Size = new System.Drawing.Size(840, 289);
		this.dgALevelGrades2.TabIndex = 0;
		this.dgALevelGrades2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewALGrades2 });
		this.gridViewALGrades2.GridControl = this.dgALevelGrades2;
		this.gridViewALGrades2.Name = "gridViewALGrades2";
		this.gridViewALGrades2.OptionsBehavior.Editable = false;
		this.gridViewALGrades2.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewALGrades2.OptionsCustomization.AllowGroup = false;
		this.gridViewALGrades2.OptionsView.ShowGroupPanel = false;
		this.tabALevelScales.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabALevelScales.Location = new System.Drawing.Point(3, 306);
		this.tabALevelScales.Name = "tabALevelScales";
		this.tabALevelScales.SelectedTabPage = this.tabPaperBalancingScale;
		this.tabALevelScales.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
		this.tabALevelScales.Size = new System.Drawing.Size(846, 178);
		this.tabALevelScales.TabIndex = 3;
		this.tabALevelScales.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[2] { this.tabPaperBalancingScale, this.tabGradingScaleA });
		this.tabPaperBalancingScale.Controls.Add(this.lblGradeIdAA);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl121);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl120);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl119);
		this.tabPaperBalancingScale.Controls.Add(this.txtALevelComment3);
		this.tabPaperBalancingScale.Controls.Add(this.txtALevelComment2);
		this.tabPaperBalancingScale.Controls.Add(this.txtALevelComment);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl72);
		this.tabPaperBalancingScale.Controls.Add(this.txtAPoints);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl73);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl74);
		this.tabPaperBalancingScale.Controls.Add(this.labelControl80);
		this.tabPaperBalancingScale.Controls.Add(this.txtAEnd);
		this.tabPaperBalancingScale.Controls.Add(this.txtADebut);
		this.tabPaperBalancingScale.Controls.Add(this.txtACategory);
		this.tabPaperBalancingScale.Controls.Add(this.btnUpdateALevelGradingScale);
		this.tabPaperBalancingScale.Name = "tabPaperBalancingScale";
		this.tabPaperBalancingScale.Size = new System.Drawing.Size(840, 172);
		this.tabPaperBalancingScale.Text = "Paper balancing scale";
		this.lblGradeIdAA.Location = new System.Drawing.Point(71, 134);
		this.lblGradeIdAA.Name = "lblGradeIdAA";
		this.lblGradeIdAA.Size = new System.Drawing.Size(0, 13);
		this.lblGradeIdAA.TabIndex = 35;
		this.lblGradeIdAA.Visible = false;
		this.labelControl121.Location = new System.Drawing.Point(258, 17);
		this.labelControl121.Name = "labelControl121";
		this.labelControl121.Size = new System.Drawing.Size(33, 13);
		this.labelControl121.TabIndex = 34;
		this.labelControl121.Text = "Debut:";
		this.labelControl120.Location = new System.Drawing.Point(6, 116);
		this.labelControl120.Name = "labelControl120";
		this.labelControl120.Size = new System.Drawing.Size(58, 13);
		this.labelControl120.TabIndex = 33;
		this.labelControl120.Text = "Comment 3:";
		this.labelControl119.Location = new System.Drawing.Point(6, 91);
		this.labelControl119.Name = "labelControl119";
		this.labelControl119.Size = new System.Drawing.Size(58, 13);
		this.labelControl119.TabIndex = 32;
		this.labelControl119.Text = "Comment 2:";
		this.txtALevelComment3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment3.Location = new System.Drawing.Point(70, 108);
		this.txtALevelComment3.MenuManager = this.ribbon;
		this.txtALevelComment3.Name = "txtALevelComment3";
		this.txtALevelComment3.Size = new System.Drawing.Size(767, 20);
		this.txtALevelComment3.TabIndex = 31;
		this.txtALevelComment2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment2.Location = new System.Drawing.Point(70, 84);
		this.txtALevelComment2.MenuManager = this.ribbon;
		this.txtALevelComment2.Name = "txtALevelComment2";
		this.txtALevelComment2.Size = new System.Drawing.Size(767, 20);
		this.txtALevelComment2.TabIndex = 30;
		this.txtALevelComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtALevelComment.Location = new System.Drawing.Point(70, 60);
		this.txtALevelComment.MenuManager = this.ribbon;
		this.txtALevelComment.Name = "txtALevelComment";
		this.txtALevelComment.Size = new System.Drawing.Size(767, 20);
		this.txtALevelComment.TabIndex = 29;
		this.labelControl72.Location = new System.Drawing.Point(6, 67);
		this.labelControl72.Name = "labelControl72";
		this.labelControl72.Size = new System.Drawing.Size(58, 13);
		this.labelControl72.TabIndex = 28;
		this.labelControl72.Text = "Comment 1:";
		this.txtAPoints.Location = new System.Drawing.Point(70, 36);
		this.txtAPoints.MenuManager = this.ribbon;
		this.txtAPoints.Name = "txtAPoints";
		this.txtAPoints.Properties.ReadOnly = true;
		this.txtAPoints.Size = new System.Drawing.Size(182, 20);
		this.txtAPoints.TabIndex = 27;
		this.labelControl73.Location = new System.Drawing.Point(6, 43);
		this.labelControl73.Name = "labelControl73";
		this.labelControl73.Size = new System.Drawing.Size(33, 13);
		this.labelControl73.TabIndex = 26;
		this.labelControl73.Text = "Points:";
		this.labelControl74.Location = new System.Drawing.Point(258, 43);
		this.labelControl74.Name = "labelControl74";
		this.labelControl74.Size = new System.Drawing.Size(22, 13);
		this.labelControl74.TabIndex = 25;
		this.labelControl74.Text = "End:";
		this.labelControl80.Location = new System.Drawing.Point(6, 17);
		this.labelControl80.Name = "labelControl80";
		this.labelControl80.Size = new System.Drawing.Size(49, 13);
		this.labelControl80.TabIndex = 24;
		this.labelControl80.Text = "Category:";
		this.txtAEnd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtAEnd.Location = new System.Drawing.Point(297, 36);
		this.txtAEnd.MenuManager = this.ribbon;
		this.txtAEnd.Name = "txtAEnd";
		this.txtAEnd.Size = new System.Drawing.Size(540, 20);
		this.txtAEnd.TabIndex = 23;
		this.txtADebut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtADebut.Location = new System.Drawing.Point(297, 10);
		this.txtADebut.MenuManager = this.ribbon;
		this.txtADebut.Name = "txtADebut";
		this.txtADebut.Size = new System.Drawing.Size(540, 20);
		this.txtADebut.TabIndex = 22;
		this.txtACategory.Location = new System.Drawing.Point(70, 10);
		this.txtACategory.MenuManager = this.ribbon;
		this.txtACategory.Name = "txtACategory";
		this.txtACategory.Properties.ReadOnly = true;
		this.txtACategory.Size = new System.Drawing.Size(182, 20);
		this.txtACategory.TabIndex = 21;
		this.btnUpdateALevelGradingScale.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnUpdateALevelGradingScale.Location = new System.Drawing.Point(689, 145);
		this.btnUpdateALevelGradingScale.Name = "btnUpdateALevelGradingScale";
		this.btnUpdateALevelGradingScale.Size = new System.Drawing.Size(148, 23);
		this.btnUpdateALevelGradingScale.TabIndex = 8;
		this.btnUpdateALevelGradingScale.Text = "Update Grading Scale";
		this.tabGradingScaleA.Controls.Add(this.lblGradeIdAAA);
		this.tabGradingScaleA.Controls.Add(this.txtPointsAA);
		this.tabGradingScaleA.Controls.Add(this.labelControl76);
		this.tabGradingScaleA.Controls.Add(this.btnUpdateA);
		this.tabGradingScaleA.Controls.Add(this.labelControl77);
		this.tabGradingScaleA.Controls.Add(this.labelControl78);
		this.tabGradingScaleA.Controls.Add(this.labelControl79);
		this.tabGradingScaleA.Controls.Add(this.txtEndAA);
		this.tabGradingScaleA.Controls.Add(this.txtDebutAA);
		this.tabGradingScaleA.Controls.Add(this.txtCategoryAA);
		this.tabGradingScaleA.Name = "tabGradingScaleA";
		this.tabGradingScaleA.Size = new System.Drawing.Size(840, 172);
		this.tabGradingScaleA.Text = "Grading scale";
		this.lblGradeIdAAA.Location = new System.Drawing.Point(53, 127);
		this.lblGradeIdAAA.Name = "lblGradeIdAAA";
		this.lblGradeIdAAA.Size = new System.Drawing.Size(0, 13);
		this.lblGradeIdAAA.TabIndex = 19;
		this.lblGradeIdAAA.Visible = false;
		this.txtPointsAA.Location = new System.Drawing.Point(194, 10);
		this.txtPointsAA.MenuManager = this.ribbon;
		this.txtPointsAA.Name = "txtPointsAA";
		this.txtPointsAA.Properties.ReadOnly = true;
		this.txtPointsAA.Size = new System.Drawing.Size(56, 20);
		this.txtPointsAA.TabIndex = 18;
		this.labelControl76.Location = new System.Drawing.Point(145, 16);
		this.labelControl76.Name = "labelControl76";
		this.labelControl76.Size = new System.Drawing.Size(33, 13);
		this.labelControl76.TabIndex = 17;
		this.labelControl76.Text = "Points:";
		this.btnUpdateA.Location = new System.Drawing.Point(167, 85);
		this.btnUpdateA.Name = "btnUpdateA";
		this.btnUpdateA.Size = new System.Drawing.Size(83, 23);
		this.btnUpdateA.TabIndex = 16;
		this.btnUpdateA.Text = "Set Grade";
		this.labelControl77.Location = new System.Drawing.Point(144, 42);
		this.labelControl77.Name = "labelControl77";
		this.labelControl77.Size = new System.Drawing.Size(22, 13);
		this.labelControl77.TabIndex = 14;
		this.labelControl77.Text = "End:";
		this.labelControl78.Location = new System.Drawing.Point(13, 42);
		this.labelControl78.Name = "labelControl78";
		this.labelControl78.Size = new System.Drawing.Size(33, 13);
		this.labelControl78.TabIndex = 13;
		this.labelControl78.Text = "Debut:";
		this.labelControl79.Location = new System.Drawing.Point(13, 16);
		this.labelControl79.Name = "labelControl79";
		this.labelControl79.Size = new System.Drawing.Size(49, 13);
		this.labelControl79.TabIndex = 12;
		this.labelControl79.Text = "Category:";
		this.txtEndAA.Location = new System.Drawing.Point(194, 35);
		this.txtEndAA.MenuManager = this.ribbon;
		this.txtEndAA.Name = "txtEndAA";
		this.txtEndAA.Size = new System.Drawing.Size(56, 20);
		this.txtEndAA.TabIndex = 11;
		this.txtDebutAA.Location = new System.Drawing.Point(68, 35);
		this.txtDebutAA.MenuManager = this.ribbon;
		this.txtDebutAA.Name = "txtDebutAA";
		this.txtDebutAA.Size = new System.Drawing.Size(60, 20);
		this.txtDebutAA.TabIndex = 10;
		this.txtCategoryAA.Location = new System.Drawing.Point(68, 10);
		this.txtCategoryAA.MenuManager = this.ribbon;
		this.txtCategoryAA.Name = "txtCategoryAA";
		this.txtCategoryAA.Properties.ReadOnly = true;
		this.txtCategoryAA.Size = new System.Drawing.Size(60, 20);
		this.txtCategoryAA.TabIndex = 9;
		this.tabPersonalRequirements.Controls.Add(this.groupControl27);
		this.tabPersonalRequirements.Controls.Add(this.simpleButton41);
		this.tabPersonalRequirements.Controls.Add(this.labelControl113);
		this.tabPersonalRequirements.Controls.Add(this.txtAppendAmount);
		this.tabPersonalRequirements.Controls.Add(this.labelControl112);
		this.tabPersonalRequirements.Controls.Add(this.labelControl89);
		this.tabPersonalRequirements.Controls.Add(this.labelControl88);
		this.tabPersonalRequirements.Controls.Add(this.labelControl87);
		this.tabPersonalRequirements.Controls.Add(this.cboAppItem);
		this.tabPersonalRequirements.Controls.Add(this.cboSemesterApp);
		this.tabPersonalRequirements.Controls.Add(this.cboClassAppend);
		this.tabPersonalRequirements.Controls.Add(this.groupControl26);
		this.tabPersonalRequirements.Controls.Add(this.groupControl25);
		this.tabPersonalRequirements.Controls.Add(this.groupControl24);
		this.tabPersonalRequirements.Controls.Add(this.txtStudentNoAppend);
		this.tabPersonalRequirements.Name = "tabPersonalRequirements";
		this.tabPersonalRequirements.Size = new System.Drawing.Size(851, 484);
		this.tabPersonalRequirements.Text = "Append student requirements";
		this.groupControl27.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl27.Controls.Add(this.txtStudentStreamAppend);
		this.groupControl27.Controls.Add(this.txtStudentClassAppend);
		this.groupControl27.Controls.Add(this.txtStudentNameAppend);
		this.groupControl27.Controls.Add(this.labelControl129);
		this.groupControl27.Controls.Add(this.labelControl125);
		this.groupControl27.Controls.Add(this.labelControl124);
		this.groupControl27.Location = new System.Drawing.Point(435, 160);
		this.groupControl27.Name = "groupControl27";
		this.groupControl27.Size = new System.Drawing.Size(254, 137);
		this.groupControl27.TabIndex = 14;
		this.groupControl27.Text = "Student details";
		this.txtStudentStreamAppend.Location = new System.Drawing.Point(54, 89);
		this.txtStudentStreamAppend.MenuManager = this.ribbon;
		this.txtStudentStreamAppend.Name = "txtStudentStreamAppend";
		this.txtStudentStreamAppend.Properties.ReadOnly = true;
		this.txtStudentStreamAppend.Size = new System.Drawing.Size(195, 20);
		this.txtStudentStreamAppend.TabIndex = 5;
		this.txtStudentClassAppend.Location = new System.Drawing.Point(54, 64);
		this.txtStudentClassAppend.MenuManager = this.ribbon;
		this.txtStudentClassAppend.Name = "txtStudentClassAppend";
		this.txtStudentClassAppend.Properties.ReadOnly = true;
		this.txtStudentClassAppend.Size = new System.Drawing.Size(195, 20);
		this.txtStudentClassAppend.TabIndex = 4;
		this.txtStudentNameAppend.Location = new System.Drawing.Point(54, 39);
		this.txtStudentNameAppend.MenuManager = this.ribbon;
		this.txtStudentNameAppend.Name = "txtStudentNameAppend";
		this.txtStudentNameAppend.Properties.ReadOnly = true;
		this.txtStudentNameAppend.Size = new System.Drawing.Size(195, 20);
		this.txtStudentNameAppend.TabIndex = 3;
		this.labelControl129.Location = new System.Drawing.Point(7, 96);
		this.labelControl129.Name = "labelControl129";
		this.labelControl129.Size = new System.Drawing.Size(38, 13);
		this.labelControl129.TabIndex = 2;
		this.labelControl129.Text = "Stream:";
		this.labelControl125.Location = new System.Drawing.Point(7, 71);
		this.labelControl125.Name = "labelControl125";
		this.labelControl125.Size = new System.Drawing.Size(29, 13);
		this.labelControl125.TabIndex = 1;
		this.labelControl125.Text = "Class:";
		this.labelControl124.Location = new System.Drawing.Point(7, 46);
		this.labelControl124.Name = "labelControl124";
		this.labelControl124.Size = new System.Drawing.Size(31, 13);
		this.labelControl124.TabIndex = 0;
		this.labelControl124.Text = "Name:";
		this.simpleButton41.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton41.Location = new System.Drawing.Point(614, 458);
		this.simpleButton41.Name = "simpleButton41";
		this.simpleButton41.Size = new System.Drawing.Size(75, 23);
		this.simpleButton41.TabIndex = 13;
		this.simpleButton41.Text = "Append";
		this.labelControl113.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl113.Location = new System.Drawing.Point(435, 390);
		this.labelControl113.Name = "labelControl113";
		this.labelControl113.Size = new System.Drawing.Size(41, 13);
		this.labelControl113.TabIndex = 12;
		this.labelControl113.Text = "Amount:";
		this.txtAppendAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.txtAppendAmount.EditValue = "0";
		this.txtAppendAmount.Location = new System.Drawing.Point(523, 383);
		this.txtAppendAmount.MenuManager = this.ribbon;
		this.txtAppendAmount.Name = "txtAppendAmount";
		this.txtAppendAmount.Properties.Mask.EditMask = "d";
		this.txtAppendAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAppendAmount.Size = new System.Drawing.Size(166, 20);
		this.txtAppendAmount.TabIndex = 11;
		this.labelControl112.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl112.Location = new System.Drawing.Point(435, 364);
		this.labelControl112.Name = "labelControl112";
		this.labelControl112.Size = new System.Drawing.Size(26, 13);
		this.labelControl112.TabIndex = 10;
		this.labelControl112.Text = "Item:";
		this.labelControl89.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl89.Location = new System.Drawing.Point(435, 337);
		this.labelControl89.Name = "labelControl89";
		this.labelControl89.Size = new System.Drawing.Size(49, 13);
		this.labelControl89.TabIndex = 9;
		this.labelControl89.Text = "Semester:";
		this.labelControl88.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl88.Location = new System.Drawing.Point(435, 310);
		this.labelControl88.Name = "labelControl88";
		this.labelControl88.Size = new System.Drawing.Size(29, 13);
		this.labelControl88.TabIndex = 8;
		this.labelControl88.Text = "Class:";
		this.labelControl87.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.labelControl87.Location = new System.Drawing.Point(435, 133);
		this.labelControl87.Name = "labelControl87";
		this.labelControl87.Size = new System.Drawing.Size(82, 13);
		this.labelControl87.TabIndex = 7;
		this.labelControl87.Text = "Student Number:";
		this.cboAppItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.cboAppItem.Location = new System.Drawing.Point(523, 357);
		this.cboAppItem.MenuManager = this.ribbon;
		this.cboAppItem.Name = "cboAppItem";
		this.cboAppItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboAppItem.Size = new System.Drawing.Size(166, 20);
		this.cboAppItem.TabIndex = 6;
		this.cboSemesterApp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.cboSemesterApp.Location = new System.Drawing.Point(523, 330);
		this.cboSemesterApp.MenuManager = this.ribbon;
		this.cboSemesterApp.Name = "cboSemesterApp";
		this.cboSemesterApp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemesterApp.Size = new System.Drawing.Size(166, 20);
		this.cboSemesterApp.TabIndex = 5;
		this.cboClassAppend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.cboClassAppend.EditValue = "-Select class-";
		this.cboClassAppend.Location = new System.Drawing.Point(523, 303);
		this.cboClassAppend.MenuManager = this.ribbon;
		this.cboClassAppend.Name = "cboClassAppend";
		this.cboClassAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClassAppend.Properties.Items.AddRange(new object[7] { "-Select class-", "S.1", "S.2", "S.3", "S.4", "S.5", "S.6" });
		this.cboClassAppend.Size = new System.Drawing.Size(166, 20);
		this.cboClassAppend.TabIndex = 4;
		this.groupControl26.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl26.Controls.Add(this.chkCustomList);
		this.groupControl26.Location = new System.Drawing.Point(173, 122);
		this.groupControl26.Name = "groupControl26";
		this.groupControl26.Size = new System.Drawing.Size(255, 359);
		this.groupControl26.TabIndex = 2;
		this.groupControl26.Text = "Student custom list";
		this.chkCustomList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.chkCustomList.Location = new System.Drawing.Point(2, 21);
		this.chkCustomList.Name = "chkCustomList";
		this.chkCustomList.Size = new System.Drawing.Size(251, 336);
		this.chkCustomList.TabIndex = 0;
		this.groupControl25.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl25.Controls.Add(this.radioGroupAppendTo);
		this.groupControl25.Location = new System.Drawing.Point(434, 3);
		this.groupControl25.Name = "groupControl25";
		this.groupControl25.Size = new System.Drawing.Size(255, 113);
		this.groupControl25.TabIndex = 1;
		this.groupControl25.Text = "Append to";
		this.radioGroupAppendTo.Location = new System.Drawing.Point(5, 25);
		this.radioGroupAppendTo.MenuManager = this.ribbon;
		this.radioGroupAppendTo.Name = "radioGroupAppendTo";
		this.radioGroupAppendTo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupAppendTo.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupAppendTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupAppendTo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[3]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Entire class"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single student"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Custom list")
		});
		this.radioGroupAppendTo.Size = new System.Drawing.Size(245, 63);
		this.radioGroupAppendTo.TabIndex = 0;
		this.groupControl24.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl24.Controls.Add(this.radioGrCat);
		this.groupControl24.Location = new System.Drawing.Point(173, 3);
		this.groupControl24.Name = "groupControl24";
		this.groupControl24.Size = new System.Drawing.Size(255, 113);
		this.groupControl24.TabIndex = 0;
		this.groupControl24.Text = "Select category";
		this.radioGrCat.Location = new System.Drawing.Point(5, 25);
		this.radioGrCat.MenuManager = this.ribbon;
		this.radioGrCat.Name = "radioGrCat";
		this.radioGrCat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGrCat.Properties.Appearance.Options.UseBackColor = true;
		this.radioGrCat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGrCat.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Fees"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Other requirements")
		});
		this.radioGrCat.Size = new System.Drawing.Size(245, 44);
		this.radioGrCat.TabIndex = 0;
		this.txtStudentNoAppend.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.txtStudentNoAppend.Location = new System.Drawing.Point(523, 126);
		this.txtStudentNoAppend.MenuManager = this.ribbon;
		this.txtStudentNoAppend.Name = "txtStudentNoAppend";
		this.txtStudentNoAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtStudentNoAppend.Properties.NullText = "";
		this.txtStudentNoAppend.Size = new System.Drawing.Size(166, 20);
		this.txtStudentNoAppend.TabIndex = 3;
		this.tabEmployeeDebts.Controls.Add(this.groupControl28);
		this.tabEmployeeDebts.Controls.Add(this.simpleButton42);
		this.tabEmployeeDebts.Controls.Add(this.labelControl114);
		this.tabEmployeeDebts.Controls.Add(this.txtAmountAppend);
		this.tabEmployeeDebts.Controls.Add(this.labelControl115);
		this.tabEmployeeDebts.Controls.Add(this.labelControl116);
		this.tabEmployeeDebts.Controls.Add(this.labelControl117);
		this.tabEmployeeDebts.Controls.Add(this.labelControl118);
		this.tabEmployeeDebts.Controls.Add(this.cboSemesterAppend);
		this.tabEmployeeDebts.Controls.Add(this.cboMonthAppend);
		this.tabEmployeeDebts.Controls.Add(this.cboItemAppend);
		this.tabEmployeeDebts.Controls.Add(this.groupControl29);
		this.tabEmployeeDebts.Controls.Add(this.groupControl30);
		this.tabEmployeeDebts.Controls.Add(this.groupControl31);
		this.tabEmployeeDebts.Controls.Add(this.lookUpEmployee);
		this.tabEmployeeDebts.Name = "tabEmployeeDebts";
		this.tabEmployeeDebts.Size = new System.Drawing.Size(851, 484);
		this.tabEmployeeDebts.Text = "Append employee debts";
		this.groupControl28.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl28.Controls.Add(this.lblEmplResponsibility);
		this.groupControl28.Controls.Add(this.lblEmplContact);
		this.groupControl28.Controls.Add(this.lblEmplSex);
		this.groupControl28.Controls.Add(this.lblEmplName);
		this.groupControl28.Location = new System.Drawing.Point(435, 160);
		this.groupControl28.Name = "groupControl28";
		this.groupControl28.Size = new System.Drawing.Size(254, 144);
		this.groupControl28.TabIndex = 29;
		this.groupControl28.Text = "Employee details";
		this.lblEmplResponsibility.Location = new System.Drawing.Point(14, 95);
		this.lblEmplResponsibility.Name = "lblEmplResponsibility";
		this.lblEmplResponsibility.Size = new System.Drawing.Size(75, 13);
		this.lblEmplResponsibility.TabIndex = 3;
		this.lblEmplResponsibility.Text = "labelControl136";
		this.lblEmplContact.Location = new System.Drawing.Point(14, 75);
		this.lblEmplContact.Name = "lblEmplContact";
		this.lblEmplContact.Size = new System.Drawing.Size(75, 13);
		this.lblEmplContact.TabIndex = 2;
		this.lblEmplContact.Text = "labelControl135";
		this.lblEmplSex.Location = new System.Drawing.Point(14, 56);
		this.lblEmplSex.Name = "lblEmplSex";
		this.lblEmplSex.Size = new System.Drawing.Size(75, 13);
		this.lblEmplSex.TabIndex = 1;
		this.lblEmplSex.Text = "labelControl134";
		this.lblEmplName.Location = new System.Drawing.Point(14, 37);
		this.lblEmplName.Name = "lblEmplName";
		this.lblEmplName.Size = new System.Drawing.Size(75, 13);
		this.lblEmplName.TabIndex = 0;
		this.lblEmplName.Text = "labelControl133";
		this.simpleButton42.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.simpleButton42.Location = new System.Drawing.Point(613, 458);
		this.simpleButton42.Name = "simpleButton42";
		this.simpleButton42.Size = new System.Drawing.Size(75, 23);
		this.simpleButton42.TabIndex = 28;
		this.simpleButton42.Text = "Append";
		this.labelControl114.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl114.Location = new System.Drawing.Point(434, 397);
		this.labelControl114.Name = "labelControl114";
		this.labelControl114.Size = new System.Drawing.Size(41, 13);
		this.labelControl114.TabIndex = 27;
		this.labelControl114.Text = "Amount:";
		this.txtAmountAppend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.txtAmountAppend.EditValue = "0";
		this.txtAmountAppend.Location = new System.Drawing.Point(522, 390);
		this.txtAmountAppend.MenuManager = this.ribbon;
		this.txtAmountAppend.Name = "txtAmountAppend";
		this.txtAmountAppend.Properties.Mask.EditMask = "n";
		this.txtAmountAppend.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAmountAppend.Size = new System.Drawing.Size(166, 20);
		this.txtAmountAppend.TabIndex = 26;
		this.labelControl115.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl115.Location = new System.Drawing.Point(434, 371);
		this.labelControl115.Name = "labelControl115";
		this.labelControl115.Size = new System.Drawing.Size(49, 13);
		this.labelControl115.TabIndex = 25;
		this.labelControl115.Text = "Semester:";
		this.labelControl116.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl116.Location = new System.Drawing.Point(434, 344);
		this.labelControl116.Name = "labelControl116";
		this.labelControl116.Size = new System.Drawing.Size(34, 13);
		this.labelControl116.TabIndex = 24;
		this.labelControl116.Text = "Month:";
		this.labelControl117.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.labelControl117.Location = new System.Drawing.Point(434, 317);
		this.labelControl117.Name = "labelControl117";
		this.labelControl117.Size = new System.Drawing.Size(26, 13);
		this.labelControl117.TabIndex = 23;
		this.labelControl117.Text = "Item:";
		this.labelControl118.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.labelControl118.Location = new System.Drawing.Point(434, 129);
		this.labelControl118.Name = "labelControl118";
		this.labelControl118.Size = new System.Drawing.Size(90, 13);
		this.labelControl118.TabIndex = 22;
		this.labelControl118.Text = "Employee Number:";
		this.cboSemesterAppend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.cboSemesterAppend.Location = new System.Drawing.Point(522, 364);
		this.cboSemesterAppend.MenuManager = this.ribbon;
		this.cboSemesterAppend.Name = "cboSemesterAppend";
		this.cboSemesterAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemesterAppend.Size = new System.Drawing.Size(166, 20);
		this.cboSemesterAppend.TabIndex = 21;
		this.cboMonthAppend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.cboMonthAppend.EditValue = "-Select Month-";
		this.cboMonthAppend.Location = new System.Drawing.Point(522, 337);
		this.cboMonthAppend.MenuManager = this.ribbon;
		this.cboMonthAppend.Name = "cboMonthAppend";
		this.cboMonthAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboMonthAppend.Properties.Items.AddRange(new object[13]
		{
			"-Select Month-", "January", "Febraury", "March", "April", "May", "June", "July", "August", "September",
			"October", "November", "December"
		});
		this.cboMonthAppend.Size = new System.Drawing.Size(166, 20);
		this.cboMonthAppend.TabIndex = 20;
		this.cboItemAppend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.cboItemAppend.Location = new System.Drawing.Point(522, 310);
		this.cboItemAppend.MenuManager = this.ribbon;
		this.cboItemAppend.Name = "cboItemAppend";
		this.cboItemAppend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboItemAppend.Size = new System.Drawing.Size(166, 20);
		this.cboItemAppend.TabIndex = 19;
		this.groupControl29.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl29.Controls.Add(this.chkEmployeeList);
		this.groupControl29.Location = new System.Drawing.Point(173, 122);
		this.groupControl29.Name = "groupControl29";
		this.groupControl29.Size = new System.Drawing.Size(255, 359);
		this.groupControl29.TabIndex = 17;
		this.groupControl29.Text = "Employee custom list";
		this.chkEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
		this.chkEmployeeList.Location = new System.Drawing.Point(2, 21);
		this.chkEmployeeList.Name = "chkEmployeeList";
		this.chkEmployeeList.Size = new System.Drawing.Size(251, 336);
		this.chkEmployeeList.TabIndex = 0;
		this.groupControl30.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl30.Controls.Add(this.rdEmployeeItems);
		this.groupControl30.Location = new System.Drawing.Point(434, 3);
		this.groupControl30.Name = "groupControl30";
		this.groupControl30.Size = new System.Drawing.Size(255, 113);
		this.groupControl30.TabIndex = 16;
		this.groupControl30.Text = "Item";
		this.rdEmployeeItems.Location = new System.Drawing.Point(5, 25);
		this.rdEmployeeItems.MenuManager = this.ribbon;
		this.rdEmployeeItems.Name = "rdEmployeeItems";
		this.rdEmployeeItems.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.rdEmployeeItems.Properties.Appearance.Options.UseBackColor = true;
		this.rdEmployeeItems.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.rdEmployeeItems.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Monthly salary"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Allowance")
		});
		this.rdEmployeeItems.Size = new System.Drawing.Size(245, 44);
		this.rdEmployeeItems.TabIndex = 0;
		this.groupControl31.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.groupControl31.Controls.Add(this.chkCheckAll);
		this.groupControl31.Controls.Add(this.rdAppendTo);
		this.groupControl31.Location = new System.Drawing.Point(173, 3);
		this.groupControl31.Name = "groupControl31";
		this.groupControl31.Size = new System.Drawing.Size(255, 113);
		this.groupControl31.TabIndex = 15;
		this.groupControl31.Text = "Append to";
		this.chkCheckAll.Enabled = false;
		this.chkCheckAll.Location = new System.Drawing.Point(7, 89);
		this.chkCheckAll.MenuManager = this.ribbon;
		this.chkCheckAll.Name = "chkCheckAll";
		this.chkCheckAll.Properties.Caption = "Select all employees";
		this.chkCheckAll.Size = new System.Drawing.Size(161, 19);
		this.chkCheckAll.TabIndex = 1;
		this.rdAppendTo.Location = new System.Drawing.Point(5, 25);
		this.rdAppendTo.MenuManager = this.ribbon;
		this.rdAppendTo.Name = "rdAppendTo";
		this.rdAppendTo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.rdAppendTo.Properties.Appearance.Options.UseBackColor = true;
		this.rdAppendTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.rdAppendTo.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single Employee"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Custom list")
		});
		this.rdAppendTo.Size = new System.Drawing.Size(245, 56);
		this.rdAppendTo.TabIndex = 0;
		this.lookUpEmployee.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lookUpEmployee.Location = new System.Drawing.Point(530, 122);
		this.lookUpEmployee.MenuManager = this.ribbon;
		this.lookUpEmployee.Name = "lookUpEmployee";
		this.lookUpEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpEmployee.Properties.NullText = "";
		this.lookUpEmployee.Size = new System.Drawing.Size(158, 20);
		this.lookUpEmployee.TabIndex = 18;
		this.tabQuickExpenses.Controls.Add(this.panelControl11);
		this.tabQuickExpenses.Controls.Add(this.groupControl32);
		this.tabQuickExpenses.Name = "tabQuickExpenses";
		this.tabQuickExpenses.Size = new System.Drawing.Size(851, 484);
		this.tabQuickExpenses.Text = "Quick Expenses";
		this.panelControl11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.panelControl11.Controls.Add(this.btnMakeExpenses);
		this.panelControl11.Location = new System.Drawing.Point(190, 444);
		this.panelControl11.Name = "panelControl11";
		this.panelControl11.Size = new System.Drawing.Size(454, 37);
		this.panelControl11.TabIndex = 1;
		this.btnMakeExpenses.Location = new System.Drawing.Point(374, 7);
		this.btnMakeExpenses.Name = "btnMakeExpenses";
		this.btnMakeExpenses.Size = new System.Drawing.Size(75, 23);
		this.btnMakeExpenses.TabIndex = 0;
		this.btnMakeExpenses.Text = "Continue";
		this.groupControl32.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl32.Controls.Add(this.layoutControl10);
		this.groupControl32.Location = new System.Drawing.Point(190, 3);
		this.groupControl32.Name = "groupControl32";
		this.groupControl32.Size = new System.Drawing.Size(454, 435);
		this.groupControl32.TabIndex = 0;
		this.groupControl32.Text = "Expense particulars";
		this.layoutControl10.Controls.Add(this.checkEdit8);
		this.layoutControl10.Controls.Add(this.txtEAmount);
		this.layoutControl10.Controls.Add(this.txtEQty);
		this.layoutControl10.Controls.Add(this.txtEPayeQuick);
		this.layoutControl10.Controls.Add(this.txtENarration);
		this.layoutControl10.Controls.Add(this.cboCategoriesQuick);
		this.layoutControl10.Controls.Add(this.cboItemsQuick);
		this.layoutControl10.Controls.Add(this.cboSemesterQuick);
		this.layoutControl10.Controls.Add(this.cboUnitsQuick);
		this.layoutControl10.Controls.Add(this.dateTimePicker1);
		this.layoutControl10.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl10.Location = new System.Drawing.Point(2, 21);
		this.layoutControl10.Name = "layoutControl10";
		this.layoutControl10.Root = this.layoutControlGroup14;
		this.layoutControl10.Size = new System.Drawing.Size(450, 412);
		this.layoutControl10.TabIndex = 1;
		this.layoutControl10.Text = "layoutControl10";
		this.checkEdit8.Location = new System.Drawing.Point(227, 76);
		this.checkEdit8.MenuManager = this.ribbon;
		this.checkEdit8.Name = "checkEdit8";
		this.checkEdit8.Properties.Caption = "Remember my selection";
		this.checkEdit8.Size = new System.Drawing.Size(219, 19);
		this.checkEdit8.StyleController = this.layoutControl10;
		this.checkEdit8.TabIndex = 13;
		this.txtEAmount.Location = new System.Drawing.Point(56, 148);
		this.txtEAmount.MenuManager = this.ribbon;
		this.txtEAmount.Name = "txtEAmount";
		this.txtEAmount.Properties.Mask.EditMask = "n";
		this.txtEAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtEAmount.Size = new System.Drawing.Size(390, 20);
		this.txtEAmount.StyleController = this.layoutControl10;
		this.txtEAmount.TabIndex = 12;
		this.txtEQty.EditValue = "1";
		this.txtEQty.Location = new System.Drawing.Point(56, 100);
		this.txtEQty.MenuManager = this.ribbon;
		this.txtEQty.Name = "txtEQty";
		this.txtEQty.Properties.Mask.EditMask = "d";
		this.txtEQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtEQty.Size = new System.Drawing.Size(390, 20);
		this.txtEQty.StyleController = this.layoutControl10;
		this.txtEQty.TabIndex = 8;
		this.txtEPayeQuick.Location = new System.Drawing.Point(56, 52);
		this.txtEPayeQuick.MenuManager = this.ribbon;
		this.txtEPayeQuick.Name = "txtEPayeQuick";
		this.txtEPayeQuick.Size = new System.Drawing.Size(390, 20);
		this.txtEPayeQuick.StyleController = this.layoutControl10;
		this.txtEPayeQuick.TabIndex = 6;
		this.txtENarration.Location = new System.Drawing.Point(56, 196);
		this.txtENarration.MenuManager = this.ribbon;
		this.txtENarration.Name = "txtENarration";
		this.txtENarration.Size = new System.Drawing.Size(390, 212);
		this.txtENarration.StyleController = this.layoutControl10;
		this.txtENarration.TabIndex = 11;
		this.cboCategoriesQuick.Location = new System.Drawing.Point(56, 4);
		this.cboCategoriesQuick.MenuManager = this.ribbon;
		this.cboCategoriesQuick.Name = "cboCategoriesQuick";
		this.cboCategoriesQuick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCategoriesQuick.Size = new System.Drawing.Size(390, 20);
		this.cboCategoriesQuick.StyleController = this.layoutControl10;
		this.cboCategoriesQuick.TabIndex = 4;
		this.cboItemsQuick.Location = new System.Drawing.Point(56, 28);
		this.cboItemsQuick.MenuManager = this.ribbon;
		this.cboItemsQuick.Name = "cboItemsQuick";
		this.cboItemsQuick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboItemsQuick.Size = new System.Drawing.Size(390, 20);
		this.cboItemsQuick.StyleController = this.layoutControl10;
		this.cboItemsQuick.TabIndex = 5;
		this.cboSemesterQuick.Location = new System.Drawing.Point(56, 76);
		this.cboSemesterQuick.MenuManager = this.ribbon;
		this.cboSemesterQuick.Name = "cboSemesterQuick";
		this.cboSemesterQuick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemesterQuick.Size = new System.Drawing.Size(167, 20);
		this.cboSemesterQuick.StyleController = this.layoutControl10;
		this.cboSemesterQuick.TabIndex = 7;
		this.cboUnitsQuick.EditValue = "-Select units-";
		this.cboUnitsQuick.Location = new System.Drawing.Point(56, 124);
		this.cboUnitsQuick.MenuManager = this.ribbon;
		this.cboUnitsQuick.Name = "cboUnitsQuick";
		this.cboUnitsQuick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboUnitsQuick.Properties.Items.AddRange(new object[19]
		{
			"-Select units-", "Bags", "Boxes", "Cards", "Containers", "g", "Gallons", "Jerrycans", "Kg", "Litres",
			"Meters", "Others", "Pairs", "Pcs", "Sachets", "Sacks", "Sets", "Tins", "Workig hours"
		});
		this.cboUnitsQuick.Size = new System.Drawing.Size(390, 20);
		this.cboUnitsQuick.StyleController = this.layoutControl10;
		this.cboUnitsQuick.TabIndex = 9;
		this.dateTimePicker1.EditValue = null;
		this.dateTimePicker1.Location = new System.Drawing.Point(56, 172);
		this.dateTimePicker1.MenuManager = this.ribbon;
		this.dateTimePicker1.Name = "dateTimePicker1";
		this.dateTimePicker1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dateTimePicker1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dateTimePicker1.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dateTimePicker1.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dateTimePicker1.Properties.Mask.EditMask = "D";
		this.dateTimePicker1.Size = new System.Drawing.Size(390, 20);
		this.dateTimePicker1.StyleController = this.layoutControl10;
		this.dateTimePicker1.TabIndex = 10;
		this.layoutControlGroup14.CustomizationFormText = "layoutControlGroup14";
		this.layoutControlGroup14.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup14.GroupBordersVisible = false;
		this.layoutControlGroup14.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[10] { this.layoutControlItem115, this.layoutControlItem116, this.layoutControlItem117, this.layoutControlItem118, this.layoutControlItem119, this.layoutControlItem120, this.layoutControlItem121, this.layoutControlItem122, this.layoutControlItem123, this.layoutControlItem129 });
		this.layoutControlGroup14.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup14.Name = "layoutControlGroup14";
		this.layoutControlGroup14.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup14.Size = new System.Drawing.Size(450, 412);
		this.layoutControlGroup14.Text = "layoutControlGroup14";
		this.layoutControlGroup14.TextVisible = false;
		this.layoutControlItem115.Control = this.cboCategoriesQuick;
		this.layoutControlItem115.CustomizationFormText = "Category:";
		this.layoutControlItem115.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem115.Name = "layoutControlItem115";
		this.layoutControlItem115.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem115.Text = "Category:";
		this.layoutControlItem115.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem116.Control = this.cboItemsQuick;
		this.layoutControlItem116.CustomizationFormText = "Item:";
		this.layoutControlItem116.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem116.Name = "layoutControlItem116";
		this.layoutControlItem116.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem116.Text = "Item:";
		this.layoutControlItem116.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem117.Control = this.txtEPayeQuick;
		this.layoutControlItem117.CustomizationFormText = "Payee:";
		this.layoutControlItem117.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem117.Name = "layoutControlItem117";
		this.layoutControlItem117.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem117.Text = "Payee:";
		this.layoutControlItem117.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem118.Control = this.cboSemesterQuick;
		this.layoutControlItem118.CustomizationFormText = "Semester:";
		this.layoutControlItem118.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem118.Name = "layoutControlItem118";
		this.layoutControlItem118.Size = new System.Drawing.Size(223, 24);
		this.layoutControlItem118.Text = "Semester:";
		this.layoutControlItem118.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem119.Control = this.txtEQty;
		this.layoutControlItem119.CustomizationFormText = "Quantity:";
		this.layoutControlItem119.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem119.Name = "layoutControlItem119";
		this.layoutControlItem119.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem119.Text = "Quantity:";
		this.layoutControlItem119.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem120.Control = this.cboUnitsQuick;
		this.layoutControlItem120.CustomizationFormText = "Units:";
		this.layoutControlItem120.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem120.Name = "layoutControlItem120";
		this.layoutControlItem120.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem120.Text = "Units:";
		this.layoutControlItem120.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem121.Control = this.dateTimePicker1;
		this.layoutControlItem121.CustomizationFormText = "Date:";
		this.layoutControlItem121.Location = new System.Drawing.Point(0, 168);
		this.layoutControlItem121.Name = "layoutControlItem121";
		this.layoutControlItem121.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem121.Text = "Date:";
		this.layoutControlItem121.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem122.Control = this.txtENarration;
		this.layoutControlItem122.CustomizationFormText = "Narration:";
		this.layoutControlItem122.Location = new System.Drawing.Point(0, 192);
		this.layoutControlItem122.Name = "layoutControlItem122";
		this.layoutControlItem122.Size = new System.Drawing.Size(446, 216);
		this.layoutControlItem122.Text = "Narration:";
		this.layoutControlItem122.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem123.Control = this.txtEAmount;
		this.layoutControlItem123.CustomizationFormText = "Amount:";
		this.layoutControlItem123.Location = new System.Drawing.Point(0, 144);
		this.layoutControlItem123.Name = "layoutControlItem123";
		this.layoutControlItem123.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem123.Text = "Amount:";
		this.layoutControlItem123.TextSize = new System.Drawing.Size(49, 13);
		this.layoutControlItem129.Control = this.checkEdit8;
		this.layoutControlItem129.CustomizationFormText = "layoutControlItem129";
		this.layoutControlItem129.Location = new System.Drawing.Point(223, 72);
		this.layoutControlItem129.Name = "layoutControlItem129";
		this.layoutControlItem129.Size = new System.Drawing.Size(223, 24);
		this.layoutControlItem129.Text = "layoutControlItem129";
		this.layoutControlItem129.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem129.TextToControlDistance = 0;
		this.layoutControlItem129.TextVisible = false;
		this.tabQuickIncome.Controls.Add(this.panelControl12);
		this.tabQuickIncome.Controls.Add(this.groupControl33);
		this.tabQuickIncome.Name = "tabQuickIncome";
		this.tabQuickIncome.Size = new System.Drawing.Size(851, 484);
		this.tabQuickIncome.Text = "Quick Income";
		this.panelControl12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.panelControl12.Controls.Add(this.btnAddIncome);
		this.panelControl12.Location = new System.Drawing.Point(190, 444);
		this.panelControl12.Name = "panelControl12";
		this.panelControl12.Size = new System.Drawing.Size(454, 37);
		this.panelControl12.TabIndex = 2;
		this.btnAddIncome.Location = new System.Drawing.Point(374, 7);
		this.btnAddIncome.Name = "btnAddIncome";
		this.btnAddIncome.Size = new System.Drawing.Size(75, 23);
		this.btnAddIncome.TabIndex = 0;
		this.btnAddIncome.Text = "Continue";
		this.groupControl33.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.groupControl33.Controls.Add(this.layoutControl11);
		this.groupControl33.Location = new System.Drawing.Point(190, 3);
		this.groupControl33.Name = "groupControl33";
		this.groupControl33.Size = new System.Drawing.Size(454, 435);
		this.groupControl33.TabIndex = 1;
		this.groupControl33.Text = "Income particulars";
		this.layoutControl11.Controls.Add(this.checkEdit7);
		this.layoutControl11.Controls.Add(this.txtAmountIncome);
		this.layoutControl11.Controls.Add(this.txtCreditor);
		this.layoutControl11.Controls.Add(this.txtNarrationQuick);
		this.layoutControl11.Controls.Add(this.cboIncomeSource);
		this.layoutControl11.Controls.Add(this.cboSemesterIQuick);
		this.layoutControl11.Controls.Add(this.dtDateQuick);
		this.layoutControl11.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl11.Location = new System.Drawing.Point(2, 21);
		this.layoutControl11.Name = "layoutControl11";
		this.layoutControl11.Root = this.layoutControlGroup15;
		this.layoutControl11.Size = new System.Drawing.Size(450, 412);
		this.layoutControl11.TabIndex = 1;
		this.layoutControl11.Text = "layoutControl11";
		this.checkEdit7.Location = new System.Drawing.Point(227, 52);
		this.checkEdit7.MenuManager = this.ribbon;
		this.checkEdit7.Name = "checkEdit7";
		this.checkEdit7.Properties.Caption = "Remember my selection";
		this.checkEdit7.Size = new System.Drawing.Size(219, 19);
		this.checkEdit7.StyleController = this.layoutControl11;
		this.checkEdit7.TabIndex = 13;
		this.txtAmountIncome.Location = new System.Drawing.Point(81, 100);
		this.txtAmountIncome.MenuManager = this.ribbon;
		this.txtAmountIncome.Name = "txtAmountIncome";
		this.txtAmountIncome.Properties.Mask.EditMask = "n";
		this.txtAmountIncome.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAmountIncome.Size = new System.Drawing.Size(365, 20);
		this.txtAmountIncome.StyleController = this.layoutControl11;
		this.txtAmountIncome.TabIndex = 12;
		this.txtCreditor.Location = new System.Drawing.Point(81, 76);
		this.txtCreditor.MenuManager = this.ribbon;
		this.txtCreditor.Name = "txtCreditor";
		this.txtCreditor.Size = new System.Drawing.Size(365, 20);
		this.txtCreditor.StyleController = this.layoutControl11;
		this.txtCreditor.TabIndex = 8;
		this.txtNarrationQuick.Location = new System.Drawing.Point(81, 124);
		this.txtNarrationQuick.MenuManager = this.ribbon;
		this.txtNarrationQuick.Name = "txtNarrationQuick";
		this.txtNarrationQuick.Size = new System.Drawing.Size(365, 284);
		this.txtNarrationQuick.StyleController = this.layoutControl11;
		this.txtNarrationQuick.TabIndex = 11;
		this.cboIncomeSource.Location = new System.Drawing.Point(81, 4);
		this.cboIncomeSource.MenuManager = this.ribbon;
		this.cboIncomeSource.Name = "cboIncomeSource";
		this.cboIncomeSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboIncomeSource.Size = new System.Drawing.Size(365, 20);
		this.cboIncomeSource.StyleController = this.layoutControl11;
		this.cboIncomeSource.TabIndex = 5;
		this.cboSemesterIQuick.Location = new System.Drawing.Point(81, 52);
		this.cboSemesterIQuick.MenuManager = this.ribbon;
		this.cboSemesterIQuick.Name = "cboSemesterIQuick";
		this.cboSemesterIQuick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemesterIQuick.Size = new System.Drawing.Size(142, 20);
		this.cboSemesterIQuick.StyleController = this.layoutControl11;
		this.cboSemesterIQuick.TabIndex = 7;
		this.dtDateQuick.EditValue = null;
		this.dtDateQuick.Location = new System.Drawing.Point(81, 28);
		this.dtDateQuick.MenuManager = this.ribbon;
		this.dtDateQuick.Name = "dtDateQuick";
		this.dtDateQuick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDateQuick.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtDateQuick.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtDateQuick.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtDateQuick.Properties.Mask.EditMask = "D";
		this.dtDateQuick.Size = new System.Drawing.Size(365, 20);
		this.dtDateQuick.StyleController = this.layoutControl11;
		this.dtDateQuick.TabIndex = 6;
		this.layoutControlGroup15.CustomizationFormText = "layoutControlGroup14";
		this.layoutControlGroup15.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup15.GroupBordersVisible = false;
		this.layoutControlGroup15.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem125, this.layoutControlItem126, this.layoutControlItem127, this.layoutControlItem128, this.layoutControlItem131, this.layoutControlItem132, this.layoutControlItem124 });
		this.layoutControlGroup15.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup15.Name = "layoutControlGroup14";
		this.layoutControlGroup15.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup15.Size = new System.Drawing.Size(450, 412);
		this.layoutControlGroup15.Text = "layoutControlGroup14";
		this.layoutControlGroup15.TextVisible = false;
		this.layoutControlItem125.Control = this.cboIncomeSource;
		this.layoutControlItem125.CustomizationFormText = "Item:";
		this.layoutControlItem125.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem125.Name = "layoutControlItem116";
		this.layoutControlItem125.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem125.Text = "Income source:";
		this.layoutControlItem125.TextSize = new System.Drawing.Size(74, 13);
		this.layoutControlItem126.Control = this.dtDateQuick;
		this.layoutControlItem126.CustomizationFormText = "Payee:";
		this.layoutControlItem126.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem126.Name = "layoutControlItem117";
		this.layoutControlItem126.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem126.Text = "Date:";
		this.layoutControlItem126.TextSize = new System.Drawing.Size(74, 13);
		this.layoutControlItem127.Control = this.cboSemesterIQuick;
		this.layoutControlItem127.CustomizationFormText = "Semester:";
		this.layoutControlItem127.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem127.Name = "layoutControlItem118";
		this.layoutControlItem127.Size = new System.Drawing.Size(223, 24);
		this.layoutControlItem127.Text = "Semester:";
		this.layoutControlItem127.TextSize = new System.Drawing.Size(74, 13);
		this.layoutControlItem128.Control = this.txtCreditor;
		this.layoutControlItem128.CustomizationFormText = "Quantity:";
		this.layoutControlItem128.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem128.Name = "layoutControlItem119";
		this.layoutControlItem128.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem128.Text = "Creditor:";
		this.layoutControlItem128.TextSize = new System.Drawing.Size(74, 13);
		this.layoutControlItem131.Control = this.txtNarrationQuick;
		this.layoutControlItem131.CustomizationFormText = "Narration:";
		this.layoutControlItem131.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem131.Name = "layoutControlItem122";
		this.layoutControlItem131.Size = new System.Drawing.Size(446, 288);
		this.layoutControlItem131.Text = "Narration:";
		this.layoutControlItem131.TextSize = new System.Drawing.Size(74, 13);
		this.layoutControlItem132.Control = this.txtAmountIncome;
		this.layoutControlItem132.CustomizationFormText = "Amouny:";
		this.layoutControlItem132.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem132.Name = "layoutControlItem123";
		this.layoutControlItem132.Size = new System.Drawing.Size(446, 24);
		this.layoutControlItem132.Text = "Amount:";
		this.layoutControlItem132.TextSize = new System.Drawing.Size(74, 13);
		this.layoutControlItem124.Control = this.checkEdit7;
		this.layoutControlItem124.CustomizationFormText = "layoutControlItem124";
		this.layoutControlItem124.Location = new System.Drawing.Point(223, 48);
		this.layoutControlItem124.Name = "layoutControlItem124";
		this.layoutControlItem124.Size = new System.Drawing.Size(223, 24);
		this.layoutControlItem124.Text = "layoutControlItem124";
		this.layoutControlItem124.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem124.TextToControlDistance = 0;
		this.layoutControlItem124.TextVisible = false;
		this.tabProcessOLevel.Controls.Add(this.panelControl30);
		this.tabProcessOLevel.Controls.Add(this.panelControl25);
		this.tabProcessOLevel.Name = "tabProcessOLevel";
		this.tabProcessOLevel.Size = new System.Drawing.Size(851, 484);
		this.tabProcessOLevel.Text = "Process O Level";
		this.panelControl30.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.panelControl30.Controls.Add(this.layoutControl12);
		this.panelControl30.Location = new System.Drawing.Point(198, 3);
		this.panelControl30.Name = "panelControl30";
		this.panelControl30.Size = new System.Drawing.Size(434, 437);
		this.panelControl30.TabIndex = 4;
		this.layoutControl12.Controls.Add(this.chkF9InSCI);
		this.layoutControl12.Controls.Add(this.panelControl23);
		this.layoutControl12.Controls.Add(this.chkOLevel);
		this.layoutControl12.Controls.Add(this.btnAdvanced);
		this.layoutControl12.Controls.Add(this.dtEnds);
		this.layoutControl12.Controls.Add(this.dtBegins);
		this.layoutControl12.Controls.Add(this.panelControl24);
		this.layoutControl12.Controls.Add(this.chkMandatory);
		this.layoutControl12.Controls.Add(this.chkF9InMathematics);
		this.layoutControl12.Controls.Add(this.chkP7nP8InEnglish);
		this.layoutControl12.Controls.Add(this.chkF9English);
		this.layoutControl12.Controls.Add(this.txtReportHeader2);
		this.layoutControl12.Controls.Add(this.cboSemesterProcess);
		this.layoutControl12.Controls.Add(this.cboClassProcess);
		this.layoutControl12.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl12.Location = new System.Drawing.Point(2, 2);
		this.layoutControl12.Name = "layoutControl12";
		this.layoutControl12.Root = this.layoutControlGroup16;
		this.layoutControl12.Size = new System.Drawing.Size(430, 433);
		this.layoutControl12.TabIndex = 3;
		this.layoutControl12.Text = "layoutControl12";
		this.chkF9InSCI.Location = new System.Drawing.Point(4, 185);
		this.chkF9InSCI.MenuManager = this.ribbon;
		this.chkF9InSCI.Name = "chkF9InSCI";
		this.chkF9InSCI.Properties.Caption = "Automatically send to division 2 F9 in any Science subject";
		this.chkF9InSCI.Size = new System.Drawing.Size(422, 19);
		this.chkF9InSCI.StyleController = this.layoutControl12;
		this.chkF9InSCI.TabIndex = 19;
		this.panelControl23.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl23.Location = new System.Drawing.Point(4, 76);
		this.panelControl23.Name = "panelControl23";
		this.panelControl23.Size = new System.Drawing.Size(422, 36);
		this.panelControl23.TabIndex = 16;
		this.chkOLevel.Location = new System.Drawing.Point(216, 407);
		this.chkOLevel.Name = "chkOLevel";
		this.chkOLevel.Properties.Caption = "Output as percentages";
		this.chkOLevel.Size = new System.Drawing.Size(210, 19);
		this.chkOLevel.StyleController = this.layoutControl12;
		this.chkOLevel.TabIndex = 15;
		this.btnAdvanced.Location = new System.Drawing.Point(4, 407);
		this.btnAdvanced.Name = "btnAdvanced";
		this.btnAdvanced.Size = new System.Drawing.Size(208, 22);
		this.btnAdvanced.StyleController = this.layoutControl12;
		this.btnAdvanced.TabIndex = 14;
		this.btnAdvanced.Text = "Score ratio settings";
		this.dtEnds.EditValue = null;
		this.dtEnds.Location = new System.Drawing.Point(108, 383);
		this.dtEnds.Name = "dtEnds";
		this.dtEnds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtEnds.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtEnds.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtEnds.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtEnds.Size = new System.Drawing.Size(318, 20);
		this.dtEnds.StyleController = this.layoutControl12;
		this.dtEnds.TabIndex = 13;
		this.dtBegins.EditValue = null;
		this.dtBegins.Location = new System.Drawing.Point(108, 359);
		this.dtBegins.Name = "dtBegins";
		this.dtBegins.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtBegins.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtBegins.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtBegins.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtBegins.Size = new System.Drawing.Size(318, 20);
		this.dtBegins.StyleController = this.layoutControl12;
		this.dtBegins.TabIndex = 12;
		this.panelControl24.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl24.Location = new System.Drawing.Point(4, 231);
		this.panelControl24.Name = "panelControl24";
		this.panelControl24.Size = new System.Drawing.Size(422, 124);
		this.panelControl24.TabIndex = 11;
		this.chkMandatory.Location = new System.Drawing.Point(4, 208);
		this.chkMandatory.Name = "chkMandatory";
		this.chkMandatory.Properties.Caption = "Assign Grade X for fewer than mandatory number of sujects";
		this.chkMandatory.Size = new System.Drawing.Size(422, 19);
		this.chkMandatory.StyleController = this.layoutControl12;
		this.chkMandatory.TabIndex = 10;
		this.chkF9InMathematics.Location = new System.Drawing.Point(4, 162);
		this.chkF9InMathematics.Name = "chkF9InMathematics";
		this.chkF9InMathematics.Properties.Caption = "Automatically send to division 2 for F9 in Mathematics";
		this.chkF9InMathematics.Size = new System.Drawing.Size(422, 19);
		this.chkF9InMathematics.StyleController = this.layoutControl12;
		this.chkF9InMathematics.TabIndex = 9;
		this.chkP7nP8InEnglish.Location = new System.Drawing.Point(4, 139);
		this.chkP7nP8InEnglish.Name = "chkP7nP8InEnglish";
		this.chkP7nP8InEnglish.Properties.Caption = "Automatically send to division 2 for P7 or P8 in English";
		this.chkP7nP8InEnglish.Size = new System.Drawing.Size(422, 19);
		this.chkP7nP8InEnglish.StyleController = this.layoutControl12;
		this.chkP7nP8InEnglish.TabIndex = 8;
		this.chkF9English.Location = new System.Drawing.Point(4, 116);
		this.chkF9English.Name = "chkF9English";
		this.chkF9English.Properties.Caption = "Automatically send to division 3 for F9 in English";
		this.chkF9English.Size = new System.Drawing.Size(422, 19);
		this.chkF9English.StyleController = this.layoutControl12;
		this.chkF9English.TabIndex = 7;
		this.txtReportHeader2.EditValue = "O LEVEL TERMINAL REPORT CARD";
		this.txtReportHeader2.Location = new System.Drawing.Point(108, 52);
		this.txtReportHeader2.Name = "txtReportHeader2";
		this.txtReportHeader2.Size = new System.Drawing.Size(318, 20);
		this.txtReportHeader2.StyleController = this.layoutControl12;
		this.txtReportHeader2.TabIndex = 6;
		this.cboSemesterProcess.Location = new System.Drawing.Point(108, 28);
		this.cboSemesterProcess.Name = "cboSemesterProcess";
		this.cboSemesterProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSemesterProcess.Size = new System.Drawing.Size(318, 20);
		this.cboSemesterProcess.StyleController = this.layoutControl12;
		this.cboSemesterProcess.TabIndex = 5;
		this.cboClassProcess.EditValue = "-Select class-";
		this.cboClassProcess.Location = new System.Drawing.Point(108, 4);
		this.cboClassProcess.Name = "cboClassProcess";
		this.cboClassProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClassProcess.Properties.Items.AddRange(new object[5] { "-Select class-", "S.1", "S.2", "S.3", "S.4" });
		this.cboClassProcess.Size = new System.Drawing.Size(318, 20);
		this.cboClassProcess.StyleController = this.layoutControl12;
		this.cboClassProcess.TabIndex = 4;
		this.layoutControlGroup16.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup16.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup16.GroupBordersVisible = false;
		this.layoutControlGroup16.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[14]
		{
			this.layoutControlItem96, this.layoutControlItem97, this.layoutControlItem98, this.layoutControlItem99, this.layoutControlItem114, this.layoutControlItem130, this.layoutControlItem133, this.layoutControlItem134, this.layoutControlItem135, this.layoutControlItem136,
			this.layoutControlItem137, this.layoutControlItem138, this.layoutControlItem139, this.layoutControlItem152
		});
		this.layoutControlGroup16.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup16.Name = "layoutControlGroup1";
		this.layoutControlGroup16.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup16.Size = new System.Drawing.Size(430, 433);
		this.layoutControlGroup16.Text = "layoutControlGroup1";
		this.layoutControlGroup16.TextVisible = false;
		this.layoutControlItem96.Control = this.cboClassProcess;
		this.layoutControlItem96.CustomizationFormText = "Class:";
		this.layoutControlItem96.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem96.Name = "layoutControlItem1";
		this.layoutControlItem96.Size = new System.Drawing.Size(426, 24);
		this.layoutControlItem96.Text = "Class:";
		this.layoutControlItem96.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem97.Control = this.cboSemesterProcess;
		this.layoutControlItem97.CustomizationFormText = "Semester:";
		this.layoutControlItem97.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem97.Name = "layoutControlItem2";
		this.layoutControlItem97.Size = new System.Drawing.Size(426, 24);
		this.layoutControlItem97.Text = "Semester:";
		this.layoutControlItem97.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem98.Control = this.txtReportHeader2;
		this.layoutControlItem98.CustomizationFormText = "Report header:";
		this.layoutControlItem98.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem98.Name = "layoutControlItem3";
		this.layoutControlItem98.Size = new System.Drawing.Size(426, 24);
		this.layoutControlItem98.Text = "Report header:";
		this.layoutControlItem98.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem99.Control = this.chkF9English;
		this.layoutControlItem99.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem99.Location = new System.Drawing.Point(0, 112);
		this.layoutControlItem99.Name = "layoutControlItem4";
		this.layoutControlItem99.Size = new System.Drawing.Size(426, 23);
		this.layoutControlItem99.Text = "layoutControlItem4";
		this.layoutControlItem99.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem99.TextToControlDistance = 0;
		this.layoutControlItem99.TextVisible = false;
		this.layoutControlItem114.Control = this.chkP7nP8InEnglish;
		this.layoutControlItem114.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem114.Location = new System.Drawing.Point(0, 135);
		this.layoutControlItem114.Name = "layoutControlItem5";
		this.layoutControlItem114.Size = new System.Drawing.Size(426, 23);
		this.layoutControlItem114.Text = "layoutControlItem5";
		this.layoutControlItem114.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem114.TextToControlDistance = 0;
		this.layoutControlItem114.TextVisible = false;
		this.layoutControlItem130.Control = this.chkF9InMathematics;
		this.layoutControlItem130.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem130.Location = new System.Drawing.Point(0, 158);
		this.layoutControlItem130.Name = "layoutControlItem6";
		this.layoutControlItem130.Size = new System.Drawing.Size(426, 23);
		this.layoutControlItem130.Text = "layoutControlItem6";
		this.layoutControlItem130.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem130.TextToControlDistance = 0;
		this.layoutControlItem130.TextVisible = false;
		this.layoutControlItem133.Control = this.chkMandatory;
		this.layoutControlItem133.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem133.Location = new System.Drawing.Point(0, 204);
		this.layoutControlItem133.Name = "layoutControlItem7";
		this.layoutControlItem133.Size = new System.Drawing.Size(426, 23);
		this.layoutControlItem133.Text = "layoutControlItem7";
		this.layoutControlItem133.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem133.TextToControlDistance = 0;
		this.layoutControlItem133.TextVisible = false;
		this.layoutControlItem134.Control = this.panelControl24;
		this.layoutControlItem134.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem134.Location = new System.Drawing.Point(0, 227);
		this.layoutControlItem134.Name = "layoutControlItem8";
		this.layoutControlItem134.Size = new System.Drawing.Size(426, 128);
		this.layoutControlItem134.Text = "layoutControlItem8";
		this.layoutControlItem134.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem134.TextToControlDistance = 0;
		this.layoutControlItem134.TextVisible = false;
		this.layoutControlItem135.Control = this.dtBegins;
		this.layoutControlItem135.CustomizationFormText = "Next term begins on:";
		this.layoutControlItem135.Location = new System.Drawing.Point(0, 355);
		this.layoutControlItem135.Name = "layoutControlItem9";
		this.layoutControlItem135.Size = new System.Drawing.Size(426, 24);
		this.layoutControlItem135.Text = "Next term begins on:";
		this.layoutControlItem135.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem136.Control = this.dtEnds;
		this.layoutControlItem136.CustomizationFormText = "Next term ends on:";
		this.layoutControlItem136.Location = new System.Drawing.Point(0, 379);
		this.layoutControlItem136.Name = "layoutControlItem10";
		this.layoutControlItem136.Size = new System.Drawing.Size(426, 24);
		this.layoutControlItem136.Text = "Next term ends on:";
		this.layoutControlItem136.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem137.Control = this.btnAdvanced;
		this.layoutControlItem137.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem137.Location = new System.Drawing.Point(0, 403);
		this.layoutControlItem137.Name = "layoutControlItem11";
		this.layoutControlItem137.Size = new System.Drawing.Size(212, 26);
		this.layoutControlItem137.Text = "layoutControlItem11";
		this.layoutControlItem137.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem137.TextToControlDistance = 0;
		this.layoutControlItem137.TextVisible = false;
		this.layoutControlItem138.Control = this.chkOLevel;
		this.layoutControlItem138.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem138.Location = new System.Drawing.Point(212, 403);
		this.layoutControlItem138.Name = "layoutControlItem12";
		this.layoutControlItem138.Size = new System.Drawing.Size(214, 26);
		this.layoutControlItem138.Text = "layoutControlItem12";
		this.layoutControlItem138.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem138.TextToControlDistance = 0;
		this.layoutControlItem138.TextVisible = false;
		this.layoutControlItem139.Control = this.panelControl23;
		this.layoutControlItem139.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem139.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem139.Name = "layoutControlItem13";
		this.layoutControlItem139.Size = new System.Drawing.Size(426, 40);
		this.layoutControlItem139.Text = "layoutControlItem13";
		this.layoutControlItem139.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem139.TextToControlDistance = 0;
		this.layoutControlItem139.TextVisible = false;
		this.layoutControlItem152.Control = this.chkF9InSCI;
		this.layoutControlItem152.CustomizationFormText = "layoutControlItem152";
		this.layoutControlItem152.Location = new System.Drawing.Point(0, 181);
		this.layoutControlItem152.Name = "layoutControlItem152";
		this.layoutControlItem152.Size = new System.Drawing.Size(426, 23);
		this.layoutControlItem152.Text = "layoutControlItem152";
		this.layoutControlItem152.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem152.TextToControlDistance = 0;
		this.layoutControlItem152.TextVisible = false;
		this.panelControl25.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		this.panelControl25.Controls.Add(this.btnProcessOLevelReports);
		this.panelControl25.Location = new System.Drawing.Point(198, 446);
		this.panelControl25.Name = "panelControl25";
		this.panelControl25.Size = new System.Drawing.Size(434, 35);
		this.panelControl25.TabIndex = 2;
		this.btnProcessOLevelReports.Location = new System.Drawing.Point(353, 7);
		this.btnProcessOLevelReports.Name = "btnProcessOLevelReports";
		this.btnProcessOLevelReports.Size = new System.Drawing.Size(75, 23);
		this.btnProcessOLevelReports.TabIndex = 0;
		this.btnProcessOLevelReports.Text = "Continue";
		this.tabProcessALevel.Name = "tabProcessALevel";
		this.tabProcessALevel.Size = new System.Drawing.Size(0, 0);
		this.panelControl29.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
		this.panelControl29.Controls.Add(this.layoutControl13);
		this.panelControl29.Location = new System.Drawing.Point(0, 0);
		this.panelControl29.Name = "panelControl29";
		this.panelControl29.Size = new System.Drawing.Size(200, 100);
		this.panelControl29.TabIndex = 0;
		this.layoutControl13.Controls.Add(this.panelControl28);
		this.layoutControl13.Controls.Add(this.chkALevel);
		this.layoutControl13.Controls.Add(this.button4);
		this.layoutControl13.Controls.Add(this.dtAEnds);
		this.layoutControl13.Controls.Add(this.dtABegins);
		this.layoutControl13.Controls.Add(this.txtReportHeader);
		this.layoutControl13.Controls.Add(this.cboALevelSemester);
		this.layoutControl13.Controls.Add(this.cboALevelClass);
		this.layoutControl13.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl13.Location = new System.Drawing.Point(2, 2);
		this.layoutControl13.Name = "layoutControl13";
		this.layoutControl13.Root = this.layoutControlGroup17;
		this.layoutControl13.Size = new System.Drawing.Size(196, 96);
		this.layoutControl13.TabIndex = 5;
		this.layoutControl13.Text = "layoutControl13";
		this.panelControl28.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl28.Location = new System.Drawing.Point(4, 76);
		this.panelControl28.Name = "panelControl28";
		this.panelControl28.Size = new System.Drawing.Size(240, 20);
		this.panelControl28.TabIndex = 16;
		this.chkALevel.Location = new System.Drawing.Point(110, 148);
		this.chkALevel.Name = "chkALevel";
		this.chkALevel.Properties.Caption = "Output as percentages";
		this.chkALevel.Size = new System.Drawing.Size(134, 19);
		this.chkALevel.StyleController = this.layoutControl13;
		this.chkALevel.TabIndex = 15;
		this.button4.Location = new System.Drawing.Point(4, 148);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(102, 22);
		this.button4.StyleController = this.layoutControl13;
		this.button4.TabIndex = 14;
		this.button4.Text = "Score ratio settings";
		this.dtAEnds.EditValue = null;
		this.dtAEnds.Location = new System.Drawing.Point(108, 124);
		this.dtAEnds.Name = "dtAEnds";
		this.dtAEnds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtAEnds.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtAEnds.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtAEnds.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtAEnds.Size = new System.Drawing.Size(136, 20);
		this.dtAEnds.StyleController = this.layoutControl13;
		this.dtAEnds.TabIndex = 13;
		this.dtABegins.EditValue = null;
		this.dtABegins.Location = new System.Drawing.Point(108, 100);
		this.dtABegins.Name = "dtABegins";
		this.dtABegins.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtABegins.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtABegins.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtABegins.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtABegins.Size = new System.Drawing.Size(136, 20);
		this.dtABegins.StyleController = this.layoutControl13;
		this.dtABegins.TabIndex = 12;
		this.txtReportHeader.EditValue = "A LEVEL TERMINAL REPORT CARD";
		this.txtReportHeader.Location = new System.Drawing.Point(108, 52);
		this.txtReportHeader.Name = "txtReportHeader";
		this.txtReportHeader.Size = new System.Drawing.Size(136, 20);
		this.txtReportHeader.StyleController = this.layoutControl13;
		this.txtReportHeader.TabIndex = 6;
		this.cboALevelSemester.Location = new System.Drawing.Point(108, 28);
		this.cboALevelSemester.Name = "cboALevelSemester";
		this.cboALevelSemester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboALevelSemester.Size = new System.Drawing.Size(136, 20);
		this.cboALevelSemester.StyleController = this.layoutControl13;
		this.cboALevelSemester.TabIndex = 5;
		this.cboALevelClass.EditValue = "-Select class-";
		this.cboALevelClass.Location = new System.Drawing.Point(108, 4);
		this.cboALevelClass.Name = "cboALevelClass";
		this.cboALevelClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboALevelClass.Properties.Items.AddRange(new object[3] { "-Select class-", "S.5", "S.6" });
		this.cboALevelClass.Size = new System.Drawing.Size(136, 20);
		this.cboALevelClass.StyleController = this.layoutControl13;
		this.cboALevelClass.TabIndex = 4;
		this.layoutControlGroup17.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup17.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup17.GroupBordersVisible = false;
		this.layoutControlGroup17.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem140, this.layoutControlItem141, this.layoutControlItem142, this.layoutControlItem143, this.layoutControlItem144, this.layoutControlItem145, this.layoutControlItem146, this.layoutControlItem147 });
		this.layoutControlGroup17.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup17.Name = "layoutControlGroup1";
		this.layoutControlGroup17.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup17.Size = new System.Drawing.Size(248, 174);
		this.layoutControlGroup17.Text = "layoutControlGroup1";
		this.layoutControlGroup17.TextVisible = false;
		this.layoutControlItem140.Control = this.cboALevelClass;
		this.layoutControlItem140.CustomizationFormText = "Class:";
		this.layoutControlItem140.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem140.Name = "layoutControlItem1";
		this.layoutControlItem140.Size = new System.Drawing.Size(244, 24);
		this.layoutControlItem140.Text = "Class:";
		this.layoutControlItem140.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem141.Control = this.cboALevelSemester;
		this.layoutControlItem141.CustomizationFormText = "Semester:";
		this.layoutControlItem141.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem141.Name = "layoutControlItem2";
		this.layoutControlItem141.Size = new System.Drawing.Size(244, 24);
		this.layoutControlItem141.Text = "Semester:";
		this.layoutControlItem141.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem142.Control = this.txtReportHeader;
		this.layoutControlItem142.CustomizationFormText = "Report header:";
		this.layoutControlItem142.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem142.Name = "layoutControlItem3";
		this.layoutControlItem142.Size = new System.Drawing.Size(244, 24);
		this.layoutControlItem142.Text = "Report header:";
		this.layoutControlItem142.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem143.Control = this.dtABegins;
		this.layoutControlItem143.CustomizationFormText = "Next term begins on:";
		this.layoutControlItem143.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem143.Name = "layoutControlItem9";
		this.layoutControlItem143.Size = new System.Drawing.Size(244, 24);
		this.layoutControlItem143.Text = "Next term begins on:";
		this.layoutControlItem143.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem144.Control = this.dtAEnds;
		this.layoutControlItem144.CustomizationFormText = "Next term ends on:";
		this.layoutControlItem144.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem144.Name = "layoutControlItem10";
		this.layoutControlItem144.Size = new System.Drawing.Size(244, 24);
		this.layoutControlItem144.Text = "Next term ends on:";
		this.layoutControlItem144.TextSize = new System.Drawing.Size(101, 13);
		this.layoutControlItem145.Control = this.button4;
		this.layoutControlItem145.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem145.Location = new System.Drawing.Point(0, 144);
		this.layoutControlItem145.Name = "layoutControlItem11";
		this.layoutControlItem145.Size = new System.Drawing.Size(106, 26);
		this.layoutControlItem145.Text = "layoutControlItem11";
		this.layoutControlItem145.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem145.TextToControlDistance = 0;
		this.layoutControlItem145.TextVisible = false;
		this.layoutControlItem146.Control = this.chkALevel;
		this.layoutControlItem146.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem146.Location = new System.Drawing.Point(106, 144);
		this.layoutControlItem146.Name = "layoutControlItem12";
		this.layoutControlItem146.Size = new System.Drawing.Size(138, 26);
		this.layoutControlItem146.Text = "layoutControlItem12";
		this.layoutControlItem146.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem146.TextToControlDistance = 0;
		this.layoutControlItem146.TextVisible = false;
		this.layoutControlItem147.Control = this.panelControl28;
		this.layoutControlItem147.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem147.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem147.Name = "layoutControlItem13";
		this.layoutControlItem147.Size = new System.Drawing.Size(244, 24);
		this.layoutControlItem147.Text = "layoutControlItem13";
		this.layoutControlItem147.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem147.TextToControlDistance = 0;
		this.layoutControlItem147.TextVisible = false;
		this.layoutControl2.Controls.Add(this.pnlMain);
		this.layoutControl2.Controls.Add(this.groupControl21);
		this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl2.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem20 });
		this.layoutControl2.Location = new System.Drawing.Point(0, 146);
		this.layoutControl2.Name = "layoutControl2";
		this.layoutControl2.Root = this.layoutControlGroup1;
		this.layoutControl2.Size = new System.Drawing.Size(851, 510);
		this.layoutControl2.TabIndex = 8;
		this.layoutControl2.Text = "layoutControl2";
		this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pnlMain.Location = new System.Drawing.Point(3, 3);
		this.pnlMain.Name = "pnlMain";
		this.pnlMain.Size = new System.Drawing.Size(845, 504);
		this.pnlMain.TabIndex = 6;
		this.groupControl21.Location = new System.Drawing.Point(743, 12);
		this.groupControl21.Name = "groupControl21";
		this.groupControl21.Size = new System.Drawing.Size(100, 481);
		this.groupControl21.TabIndex = 5;
		this.groupControl21.Text = "groupControl21";
		this.layoutControlItem20.Control = this.groupControl21;
		this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
		this.layoutControlItem20.Location = new System.Drawing.Point(628, 0);
		this.layoutControlItem20.Name = "layoutControlItem20";
		this.layoutControlItem20.Size = new System.Drawing.Size(207, 485);
		this.layoutControlItem20.Text = "layoutControlItem20";
		this.layoutControlItem20.TextSize = new System.Drawing.Size(50, 20);
		this.layoutControlItem20.TextToControlDistance = 5;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(851, 510);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.pnlMain;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(849, 508);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(851, 683);
		base.Controls.Add(this.layoutControl2);
		base.Controls.Add(this.ribbonStatusBar);
		base.Controls.Add(this.ribbon);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "LibraryMain";
		this.Ribbon = this.ribbon;
		base.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
		this.StatusBar = this.ribbonStatusBar;
		this.Text = "Xtreme Library Manager";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(LibraryMain_Load);
		((System.ComponentModel.ISupportInitialize)this.ribbon).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemProgressBar2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemZoomTrackBar2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridBorrorRecords).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl14).EndInit();
		this.groupControl14.ResumeLayout(false);
		this.groupControl14.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtNoOfCopies.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtReturnDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBookReference.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpBooks.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBorrowDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBorrowDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl12).EndInit();
		this.groupControl12.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpStudent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReservationStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReservationCode.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
		this.tabOrderDetails.ResumeLayout(false);
		this.tabOrderDetails.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl2).EndInit();
		this.groupControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl4).EndInit();
		this.xtraTabControl4.ResumeLayout(false);
		this.tabNewOrders.ResumeLayout(false);
		this.tabNewOrders.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplyId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridSales).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSales).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtOrderDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtOrderDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpSupplier.Properties).EndInit();
		this.tabStudentAdmission.ResumeLayout(false);
		this.tabStudentAdmission.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl5).EndInit();
		this.groupControl5.ResumeLayout(false);
		this.groupControl5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumberSearch.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNameSearch.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStudent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl2).EndInit();
		this.xtraTabControl2.ResumeLayout(false);
		this.tabStudyInformation.ResumeLayout(false);
		this.tabStudyInformation.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutFeesStatus).EndInit();
		this.layoutFeesStatus.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRequiredFees.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboBursaryProvider.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem36).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl3).EndInit();
		this.groupControl3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupStudyStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl4).EndInit();
		this.groupControl4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupBursaryStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutPersonData).EndInit();
		this.layoutPersonData.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtGuardianContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboReligion.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboHall.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboNationality.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFormerSchool.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAdmissionDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSex.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGurdianAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGuardian.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLastName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFirstName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layout).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem34).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		this.tabEmployeeAdmission.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutEmployeeData).EndInit();
		this.layoutEmployeeData.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboEmplHouse.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplFormerEmployee.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit22.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplContactNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplFirstName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEmplHireDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtResponsibility.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQualification.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplLastName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboEmplSex.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem24).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem25).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem27).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem28).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem29).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem30).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem31).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem32).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem33).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem35).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem93).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		this.groupControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNumberSearch.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStaffNameSearch.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStaff.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl3).EndInit();
		this.xtraTabControl3.ResumeLayout(false);
		this.tabSalaryInformation.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtUnTaxable.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNSSFAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPAYE.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNetPay.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNSSFRate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPAYECalc.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplSalaryAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEmplNotes.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem37).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem40).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem43).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem38).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem39).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl8).EndInit();
		this.groupControl8.ResumeLayout(false);
		this.groupControl8.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroup6.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl3).EndInit();
		this.panelControl3.ResumeLayout(false);
		this.tabStudentPayments.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridStudentPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutStudentPayment).EndInit();
		this.layoutStudentPayment.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtStudentFees.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentBursaryStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentFirstName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtConfirmStudentNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentLastName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentSex.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentStudyStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentReligion.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentHomeCountry.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem46).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem47).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem48).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem49).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem50).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem51).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem52).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem53).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem54).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem55).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem56).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lblCurrentBank).EndInit();
		this.lblCurrentBank.ResumeLayout(false);
		this.lblCurrentBank.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.chkBankCharges.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintReceipt.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmountPaid.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceiptNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl7).EndInit();
		this.groupControl7.ResumeLayout(false);
		this.groupControl7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.radioGroup4.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl11).EndInit();
		this.groupControl11.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.lbRequirements).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkRememberSem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTermOfStudy.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpEdit.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStudentPicture.Properties).EndInit();
		this.tabReports.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl2).EndInit();
		this.tabEmployeePayments.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridEmpSalary).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewESalary).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl5).EndInit();
		this.layoutControl5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkPayStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayEmplType.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayResponsibility.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayTelephone.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySurname.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayEmployeeNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayOtherNames.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayNSSF.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayNetPay.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayBasicPay.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayPaye.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem74).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem75).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem76).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem77).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem78).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem79).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem80).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem81).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem82).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem83).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem84).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem85).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl10).EndInit();
		this.groupControl10.ResumeLayout(false);
		this.groupControl10.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit4.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayNarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpStaff.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboPaySemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboPayMonth.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayAMount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboPayItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStaffPay.Properties).EndInit();
		this.tabSuppliers.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl15).EndInit();
		this.panelControl15.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridSuppliers).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSuppliers).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl5).EndInit();
		this.xtraTabControl5.ResumeLayout(false);
		this.tabSupplierDetails.ResumeLayout(false);
		this.tabSupplierDetails.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierSurname.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierNotes.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierPhone.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierBoxNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierFax.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierJobTitle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCompany.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierStreet1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierMobile.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierEmail.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierOthername.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierCity.Properties).EndInit();
		this.tabOrderLists.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.groupControl6).EndInit();
		this.groupControl6.ResumeLayout(false);
		this.groupControl6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierNarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboPaySupplierSemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintVoucherS.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOffice.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierMob.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOtherName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierSurname.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpSupplierPayment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLedger).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSL).EndInit();
		this.tabBudgetCreattion.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.groupControl23).EndInit();
		this.groupControl23.ResumeLayout(false);
		this.groupControl23.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtTotal.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtYear.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQuantity.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboUnits.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboItems.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboCategories.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemester3.Properties).EndInit();
		this.tabStudentLists.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl20).EndInit();
		this.panelControl20.ResumeLayout(false);
		this.panelControl20.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgRecords).EndInit();
		this.tabEmployeeLists.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl21).EndInit();
		this.panelControl21.ResumeLayout(false);
		this.panelControl21.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dgRecords_emp).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewEmployees).EndInit();
		this.tabReceiveVouchers.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl16).EndInit();
		this.panelControl16.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView26).EndInit();
		this.tabReceiveVouchersDetails.ResumeLayout(false);
		this.tabReceiveVouchersDetails.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl17).EndInit();
		this.panelControl17.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.textEdit60.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit6.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit6.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit61.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit62.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl27).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView27).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit63.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit64.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit65.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit66.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit67.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit68.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit8.Properties).EndInit();
		this.tabReturnVouchers.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl18).EndInit();
		this.panelControl18.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl28).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView28).EndInit();
		this.tabReturnVouchersDetails.ResumeLayout(false);
		this.tabReturnVouchersDetails.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl26).EndInit();
		this.panelControl26.ResumeLayout(false);
		this.panelControl26.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl19).EndInit();
		this.panelControl19.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.textEdit6.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit7.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit8.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit9.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit10.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit11.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit12.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit13.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit26.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit4.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit72.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit73.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit74.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit75.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit76.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit77.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit9.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl29).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView29).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit69.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit7.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateEdit7.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit70.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit71.Properties).EndInit();
		this.tabInfirmaryDiagnosis.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl6).EndInit();
		this.panelControl6.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit5.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl7).EndInit();
		this.xtraTabControl7.ResumeLayout(false);
		this.xtraTabPage3.ResumeLayout(false);
		this.xtraTabPage3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl7).EndInit();
		this.layoutControl7.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtRecommendation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTreatment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDiagnosis.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem101).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem102).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem103).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dt2.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dt2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl6).EndInit();
		this.layoutControl6.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtHall.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPersonId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem89).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem90).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem91).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem92).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem100).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picPerson.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl13).EndInit();
		this.groupControl13.ResumeLayout(false);
		this.groupControl13.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtIDNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroup7.Properties).EndInit();
		this.tabBorrowRecords.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl8).EndInit();
		this.panelControl8.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView12).EndInit();
		this.xtraTabPage1.ResumeLayout(false);
		this.tabStudentRegistrationStandard.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl9).EndInit();
		this.panelControl9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl9).EndInit();
		this.layoutControl9.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl22).EndInit();
		this.panelControl22.ResumeLayout(false);
		this.panelControl22.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNumberRegister.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassR.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTermOfStudyRegister.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem110).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem111).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem112).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem113).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem94).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem95).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl17).EndInit();
		this.groupControl17.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkLstSubjects).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkSelectAll.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl16).EndInit();
		this.groupControl16.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupMode.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl15).EndInit();
		this.groupControl15.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupLevelToRegister.Properties).EndInit();
		this.tabStudentRegistrationAdvanced.ResumeLayout(false);
		this.tabStudentRegistrationAdvanced.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit10.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit5.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl10).EndInit();
		this.panelControl10.ResumeLayout(false);
		this.tabSelectSubjects.ResumeLayout(false);
		this.tabSelectSubjects.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.lbSubjectsSelected).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lbSubjects).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl18).EndInit();
		this.groupControl18.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupLevel.Properties).EndInit();
		this.tabOLevelGradingScale.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.tabMainGradings).EndInit();
		this.tabMainGradings.ResumeLayout(false);
		this.tabGradings1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).EndInit();
		this.tabGradings2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridOLevelGrading).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrading).EndInit();
		((System.ComponentModel.ISupportInitialize)this.tabOLevelScales).EndInit();
		this.tabOLevelScales.ResumeLayout(false);
		this.tabGradingScale.ResumeLayout(false);
		this.tabGradingScale.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOLevelComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradePoints.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeEnd.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeDebut.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtGradeCategory.Properties).EndInit();
		this.tabDivisionScale.ResumeLayout(false);
		this.tabDivisionScale.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtHeadTeacherComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDOSComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtClassTeacherComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEnd.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebut.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategory.Properties).EndInit();
		this.tabALevelGradingScale.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.tabALevelGrading).EndInit();
		this.tabALevelGrading.ResumeLayout(false);
		this.tabALevelGradings1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades).EndInit();
		this.tabALevelGrading2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgALevelGrades2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewALGrades2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.tabALevelScales).EndInit();
		this.tabALevelScales.ResumeLayout(false);
		this.tabPaperBalancingScale.ResumeLayout(false);
		this.tabPaperBalancingScale.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtALevelComment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAPoints.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAEnd.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtADebut.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtACategory.Properties).EndInit();
		this.tabGradingScaleA.ResumeLayout(false);
		this.tabGradingScaleA.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPointsAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEndAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebutAA.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCategoryAA.Properties).EndInit();
		this.tabPersonalRequirements.ResumeLayout(false);
		this.tabPersonalRequirements.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl27).EndInit();
		this.groupControl27.ResumeLayout(false);
		this.groupControl27.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStudentStreamAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentClassAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNameAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAppendAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboAppItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterApp.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl26).EndInit();
		this.groupControl26.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkCustomList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl25).EndInit();
		this.groupControl25.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGroupAppendTo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl24).EndInit();
		this.groupControl24.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.radioGrCat.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNoAppend.Properties).EndInit();
		this.tabEmployeeDebts.ResumeLayout(false);
		this.tabEmployeeDebts.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl28).EndInit();
		this.groupControl28.ResumeLayout(false);
		this.groupControl28.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAmountAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboMonthAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboItemAppend.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl29).EndInit();
		this.groupControl29.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkEmployeeList).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl30).EndInit();
		this.groupControl30.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.rdEmployeeItems.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl31).EndInit();
		this.groupControl31.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkCheckAll.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.rdAppendTo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpEmployee.Properties).EndInit();
		this.tabQuickExpenses.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl11).EndInit();
		this.panelControl11.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.groupControl32).EndInit();
		this.groupControl32.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl10).EndInit();
		this.layoutControl10.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit8.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEQty.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEPayeQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtENarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboCategoriesQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboItemsQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboUnitsQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateTimePicker1.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dateTimePicker1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem115).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem116).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem117).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem118).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem119).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem120).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem121).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem122).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem123).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem129).EndInit();
		this.tabQuickIncome.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl12).EndInit();
		this.panelControl12.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.groupControl33).EndInit();
		this.groupControl33.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl11).EndInit();
		this.layoutControl11.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit7.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmountIncome.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtCreditor.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarrationQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboIncomeSource.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterIQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDateQuick.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDateQuick.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem125).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem126).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem127).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem128).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem131).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem132).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem124).EndInit();
		this.tabProcessOLevel.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl30).EndInit();
		this.panelControl30.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl12).EndInit();
		this.layoutControl12.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkF9InSCI.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl23).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkOLevel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEnds.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEnds.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl24).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkMandatory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9InMathematics.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkP7nP8InEnglish.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9English.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSemesterProcess.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassProcess.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem96).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem97).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem98).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem99).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem114).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem130).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem133).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem134).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem135).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem136).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem137).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem138).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem139).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem152).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl25).EndInit();
		this.panelControl25.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl29).EndInit();
		this.panelControl29.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl13).EndInit();
		this.layoutControl13.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl28).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkALevel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtAEnds.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtAEnds.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtABegins.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtABegins.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboALevelSemester.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboALevelClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem140).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem141).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem142).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem143).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem144).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem145).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem146).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem147).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).EndInit();
		this.layoutControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pnlMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
