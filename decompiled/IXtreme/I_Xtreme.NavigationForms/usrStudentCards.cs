using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting.Control;
using I_Xtreme.Properties;
using I_Xtreme.StudentIDs;

namespace I_Xtreme.NavigationForms;

public class usrStudentCards : XtraUserControl
{
	private PrintControl printControl11;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private PopupMenu popupMenu1;

	private BarManager barManager1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private ComboBoxEdit cboFontSize;

	private FontEdit cboFont;

	private ColorPickEdit colF3;

	private ColorPickEdit colF2;

	private ColorPickEdit colF1;

	private LabelControl labelControl1;

	private LabelControl labelControl9;

	private ColorPickEdit colHB;

	private ColorPickEdit colHF;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem12;

	private LayoutControlItem layoutControlItem13;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem10;

	private PictureEdit picSignatory;

	private LayoutControlItem layoutControlItem14;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	public usrStudentCards()
	{
		InitializeComponent();
		colHB.Color = Color.FromArgb(IDCustomization.HBColor);
		colHF.Color = Color.FromArgb(IDCustomization.HFColor);
		cboFont.SelectedItem = IDCustomization.HFont;
		cboFontSize.SelectedItem = IDCustomization.FontSize.ToString();
		colF1.Color = Color.FromArgb(IDCustomization.FCol1);
		colF2.Color = Color.FromArgb(IDCustomization.FCol2);
		colF3.Color = Color.FromArgb(IDCustomization.FCol3);
		picSignatory.Image = IDCustomization.Signatory;
		PreviewImage();
	}

	private void PreviewImage()
	{
		printControl11 = new PrintControl
		{
			Dock = DockStyle.Fill
		};
		panelControl1.Controls.Add(printControl11);
		ID_Fullpage iD_Fullpage = new ID_Fullpage();
		printControl11.PrintingSystem = iD_Fullpage.PrintingSystem;
		iD_Fullpage.PrintingSystem.ClearContent();
		iD_Fullpage.CreateDocument();
	}

	private void PreviewImageOnSave()
	{
		IDCustomization.SetIDColors(colHB.Color.ToArgb(), colHF.Color.ToArgb(), colF1.Color.ToArgb(), colF2.Color.ToArgb(), colF3.Color.ToArgb());
		IDCustomization.SetIDFonts(cboFont.SelectedItem.ToString(), Convert.ToDecimal(cboFontSize.SelectedItem));
		printControl11 = new PrintControl
		{
			Dock = DockStyle.Fill
		};
		panelControl1.Controls.Clear();
		panelControl1.Controls.Add(printControl11);
		ID_Fullpage iD_Fullpage = new ID_Fullpage();
		printControl11.PrintingSystem = iD_Fullpage.PrintingSystem;
		iD_Fullpage.PrintingSystem.ClearContent();
		iD_Fullpage.CreateDocument();
	}

	private static void DeleteFromTable(string cmdText)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = cmdText,
				CommandType = CommandType.Text
			};
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		PreviewImageOnSave();
	}

	private void colHB_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void colHF_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void cboFont_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void cboFontSize_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void colF1_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void colF2_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void colF3_Closed(object sender, ClosedEventArgs e)
	{
		PreviewImageOnSave();
	}

	private void chkShowWM_CheckedChanged(object sender, EventArgs e)
	{
		PreviewImageOnSave();
	}

	private void picSignatory_DoubleClick(object sender, EventArgs e)
	{
		try
		{
			string text = null;
			using OpenFileDialog openFileDialog = new OpenFileDialog
			{
				RestoreDirectory = true,
				Title = "Open Signature File",
				Filter = "png files (*.png)|*.png|gif files (*.gif)|*.gif|jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			text = openFileDialog.FileName;
			picSignatory.Image = Image.FromFile(text);
			Image original = Image.FromFile(text);
			if (picSignatory.Image == null)
			{
				original = Resources.Default;
			}
			Bitmap bitmap = new Bitmap(original);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				bitmap.Save(memoryStream, ImageFormat.Png);
				memoryStream.Position = 0L;
				byte[] array = new byte[memoryStream.Length + 1];
				memoryStream.Read(array, 0, array.Length);
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT * FROM tbl_Signatory",
					CommandType = CommandType.Text
				};
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_Signatory (sign) VALUES (@sign)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@sign", SqlDbType.Image);
					sqlParameter.Value = array;
					sqlParameter.Direction = ParameterDirection.Input;
					if (sqlCommand2.ExecuteNonQuery() > 0)
					{
						PreviewImageOnSave();
						sqlConnection.Close();
					}
				}
				else
				{
					sqlDataReader.Close();
					using SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "UPDATE tbl_Signatory SET sign=@sign",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@sign", SqlDbType.Image);
					sqlParameter2.Value = array;
					sqlParameter2.Direction = ParameterDirection.Input;
					if (sqlCommand3.ExecuteNonQuery() > 0)
					{
						PreviewImageOnSave();
						sqlConnection.Close();
					}
				}
			}
			PreviewImageOnSave();
		}
		catch (ArgumentException ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
		catch (Exception ex2)
		{
			XtraMessageBox.Show(ex2.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		this.components = new System.ComponentModel.Container();
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.picSignatory = new DevExpress.XtraEditors.PictureEdit();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.colHB = new DevExpress.XtraEditors.ColorPickEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.colHF = new DevExpress.XtraEditors.ColorPickEdit();
		this.cboFont = new DevExpress.XtraEditors.FontEdit();
		this.cboFontSize = new DevExpress.XtraEditors.ComboBoxEdit();
		this.colF1 = new DevExpress.XtraEditors.ColorPickEdit();
		this.colF2 = new DevExpress.XtraEditors.ColorPickEdit();
		this.colF3 = new DevExpress.XtraEditors.ColorPickEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picSignatory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.colHB.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.colHF.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboFont.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboFontSize.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.colF1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.colF2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.colF3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.picSignatory);
		this.layoutControl1.Controls.Add(this.labelControl9);
		this.layoutControl1.Controls.Add(this.colHB);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.colHF);
		this.layoutControl1.Controls.Add(this.cboFont);
		this.layoutControl1.Controls.Add(this.cboFontSize);
		this.layoutControl1.Controls.Add(this.colF1);
		this.layoutControl1.Controls.Add(this.colF2);
		this.layoutControl1.Controls.Add(this.colF3);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(300, 306, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(1066, 511);
		this.layoutControl1.TabIndex = 3;
		this.layoutControl1.Text = "layoutControl1";
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Location = new System.Drawing.Point(5, 226);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(299, 224);
		this.panelControl1.TabIndex = 32;
		this.picSignatory.EditValue = I_Xtreme.Properties.Resources.bg;
		this.picSignatory.Location = new System.Drawing.Point(5, 470);
		this.picSignatory.MenuManager = this.barManager1;
		this.picSignatory.Name = "picSignatory";
		this.picSignatory.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picSignatory.Size = new System.Drawing.Size(299, 36);
		this.picSignatory.StyleController = this.layoutControl1;
		toolTipTitleItem.Text = "Signatory";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Double Click in the image box to load the signature image forthe Identity Cards";
		toolTipTitleItem2.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem2.Appearance.Options.UseImage = true;
		toolTipTitleItem2.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem2.LeftIndent = 6;
		toolTipTitleItem2.Text = "Press F1 for help";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		superToolTip.Items.Add(item);
		superToolTip.Items.Add(toolTipTitleItem2);
		this.picSignatory.SuperTip = superToolTip;
		this.picSignatory.TabIndex = 0;
		this.picSignatory.DoubleClick += new System.EventHandler(picSignatory_DoubleClick);
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[3] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3 });
		this.barManager1.MaxItemId = 3;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Size = new System.Drawing.Size(1066, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 511);
		this.barDockControlBottom.Size = new System.Drawing.Size(1066, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 511);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(1066, 0);
		this.barDockControlRight.Size = new System.Drawing.Size(0, 511);
		this.barButtonItem1.Caption = "Print All";
		this.barButtonItem1.Id = 0;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem2.Caption = "Print Selected";
		this.barButtonItem2.Id = 1;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem3.Caption = "Delete";
		this.barButtonItem3.Id = 2;
		this.barButtonItem3.Name = "barButtonItem3";
		this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl9.Visible = true;
		this.labelControl9.Location = new System.Drawing.Point(5, 137);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(299, 13);
		this.labelControl9.StyleController = this.layoutControl1;
		this.labelControl9.TabIndex = 24;
		this.labelControl9.Text = "Flag Colors";
		this.colHB.EditValue = System.Drawing.Color.Empty;
		this.colHB.Location = new System.Drawing.Point(173, 41);
		this.colHB.MenuManager = this.barManager1;
		this.colHB.Name = "colHB";
		this.colHB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.colHB.Size = new System.Drawing.Size(131, 20);
		this.colHB.StyleController = this.layoutControl1;
		this.colHB.TabIndex = 7;
		this.colHB.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(colHB_Closed);
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(5, 24);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(299, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 16;
		this.labelControl1.Text = "Header";
		this.colHF.EditValue = System.Drawing.Color.Empty;
		this.colHF.Location = new System.Drawing.Point(173, 65);
		this.colHF.MenuManager = this.barManager1;
		this.colHF.Name = "colHF";
		this.colHF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.colHF.Size = new System.Drawing.Size(131, 20);
		this.colHF.StyleController = this.layoutControl1;
		this.colHF.TabIndex = 8;
		this.colHF.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(colHF_Closed);
		this.cboFont.Location = new System.Drawing.Point(173, 89);
		this.cboFont.MenuManager = this.barManager1;
		this.cboFont.Name = "cboFont";
		this.cboFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboFont.Size = new System.Drawing.Size(131, 20);
		this.cboFont.StyleController = this.layoutControl1;
		this.cboFont.TabIndex = 14;
		this.cboFont.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboFont_Closed);
		this.cboFontSize.Location = new System.Drawing.Point(173, 113);
		this.cboFontSize.MenuManager = this.barManager1;
		this.cboFontSize.Name = "cboFontSize";
		this.cboFontSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboFontSize.Properties.Items.AddRange(new object[23]
		{
			"8", "9", "10", "11", "12", "13", "14", "15", "16", "17",
			"18", "19", "20", "21", "22", "23", "24", "25", "26", "27",
			"28", "29", "30"
		});
		this.cboFontSize.Size = new System.Drawing.Size(131, 20);
		this.cboFontSize.StyleController = this.layoutControl1;
		this.cboFontSize.TabIndex = 15;
		this.cboFontSize.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboFontSize_Closed);
		this.colF1.EditValue = System.Drawing.Color.Empty;
		this.colF1.Location = new System.Drawing.Point(173, 154);
		this.colF1.MenuManager = this.barManager1;
		this.colF1.Name = "colF1";
		this.colF1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.colF1.Size = new System.Drawing.Size(131, 20);
		this.colF1.StyleController = this.layoutControl1;
		this.colF1.TabIndex = 10;
		this.colF1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(colF1_Closed);
		this.colF2.EditValue = System.Drawing.Color.Empty;
		this.colF2.Location = new System.Drawing.Point(173, 178);
		this.colF2.MenuManager = this.barManager1;
		this.colF2.Name = "colF2";
		this.colF2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.colF2.Size = new System.Drawing.Size(131, 20);
		this.colF2.StyleController = this.layoutControl1;
		this.colF2.TabIndex = 11;
		this.colF2.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(colF2_Closed);
		this.colF3.EditValue = System.Drawing.Color.Empty;
		this.colF3.Location = new System.Drawing.Point(173, 202);
		this.colF3.MenuManager = this.barManager1;
		this.colF3.Name = "colF3";
		this.colF3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.colF3.Size = new System.Drawing.Size(131, 20);
		this.colF3.StyleController = this.layoutControl1;
		this.colF3.TabIndex = 12;
		this.colF3.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(colF3_Closed);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlGroup2, this.emptySpaceItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(1066, 511);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlGroup2.CustomizationFormText = "ID Customization";
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[11]
		{
			this.layoutControlItem2, this.layoutControlItem6, this.layoutControlItem8, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem12, this.layoutControlItem13, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem14,
			this.layoutControlItem4
		});
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup2.Size = new System.Drawing.Size(309, 511);
		this.layoutControlGroup2.Text = "ID Customization";
		this.layoutControlItem2.Control = this.colHB;
		this.layoutControlItem2.CustomizationFormText = "Back Color";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 17);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem2.Text = "Back Color";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem6.Control = this.cboFont;
		this.layoutControlItem6.CustomizationFormText = "Font";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 65);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem6.Text = "Font";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem8.Control = this.colF1;
		this.layoutControlItem8.CustomizationFormText = "Color 1";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 130);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem8.Text = "Color 1";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem5.Control = this.colHF;
		this.layoutControlItem5.CustomizationFormText = "Fore Color";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 41);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem5.Text = "Fore Color";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem7.Control = this.cboFontSize;
		this.layoutControlItem7.CustomizationFormText = "Font Size";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 89);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem7.Text = "Font Size";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem12.Control = this.labelControl9;
		this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 113);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(303, 17);
		this.layoutControlItem12.Text = "layoutControlItem12";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextToControlDistance = 0;
		this.layoutControlItem12.TextVisible = false;
		this.layoutControlItem13.Control = this.labelControl1;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(303, 17);
		this.layoutControlItem13.Text = "layoutControlItem13";
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextToControlDistance = 0;
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem9.Control = this.colF2;
		this.layoutControlItem9.CustomizationFormText = "Color 2";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 154);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem9.Text = "Color 2";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem10.Control = this.colF3;
		this.layoutControlItem10.CustomizationFormText = "Color 3";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 178);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(303, 24);
		this.layoutControlItem10.Text = "Color 3";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem14.Control = this.picSignatory;
		this.layoutControlItem14.CustomizationFormText = "Signatory";
		this.layoutControlItem14.Location = new System.Drawing.Point(0, 430);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(303, 56);
		this.layoutControlItem14.Text = "Signatory (Double Click in the Box)";
		this.layoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem14.TextSize = new System.Drawing.Size(165, 13);
		this.layoutControlItem4.Control = this.panelControl1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 202);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(303, 228);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(309, 0);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(757, 511);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)
		});
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrStudentCards";
		base.Size = new System.Drawing.Size(1066, 511);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picSignatory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.colHB.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.colHF.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboFont.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboFontSize.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.colF1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.colF2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.colF3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		base.ResumeLayout(false);
	}
}
