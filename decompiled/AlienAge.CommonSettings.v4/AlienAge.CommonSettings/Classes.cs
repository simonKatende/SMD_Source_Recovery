using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AlienAge.CommonSettings;

[Serializable]
public class Classes
{
	public string ClassList { get; set; }

	public static void LoadComboWithClasses(ComboBoxEdit[] cboClass)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ClassId FROM Classes WHERE (ClassId<>'All')  Order By Id", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ClassesList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			for (int i = 0; i < cboClass.Length; i++)
			{
				cboClass[i].Properties.Items.Clear();
				foreach (DataRow row in dataTable.Rows)
				{
					cboClass[i].Properties.Items.Add(row["ClassId"]);
				}
				cboClass[i].SelectedIndex = 0;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void LoadComboWithClasses(ComboBoxEdit cboClass, string ClassGroup)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ClassId FROM Classes WHERE (ClassId<>'All' AND ClassId<>'-N/A-' AND ClassId<>'N/A')  AND ClassGroup='{ClassGroup}' Order By Id", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ClassesList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			cboClass.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				cboClass.Properties.Items.Add(row["ClassId"]);
			}
			cboClass.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void LoadLookUpWithClasses(LookUpEdit lookUpClasses)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ClassId, ClassGroup,SubGroup FROM Classes WHERE (ClassId<>'All' AND ClassId<>'-N/A-' AND ClassId<>'N/A')  Order By Id", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ClassesList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpClasses.Properties.Columns.Clear();
			lookUpClasses.Properties.DataSource = dataTable;
			lookUpClasses.Properties.DisplayMember = "ClassId";
			lookUpClasses.Properties.ValueMember = "ClassId";
			LookUpColumnInfoCollection columns = lookUpClasses.Properties.Columns;
			columns.Add(new LookUpColumnInfo("ClassId", 0, "Class"));
			columns.Add(new LookUpColumnInfo("ClassGroup", 0, "Class Level"));
			columns.Add(new LookUpColumnInfo("SubGroup", 0, "Level Ranking"));
			lookUpClasses.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpClasses.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpClasses.Properties.AutoSearchColumnIndex = 0;
			lookUpClasses.Properties.HotTrackItems = true;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void LoadLookUpWithClasses(LookUpEdit lookUpClasses, string ClassGroup)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ClassId, ClassGroup,SubGroup FROM Classes WHERE (ClassId<>'All' AND ClassId<>'-N/A-' AND ClassId<>'N/A') AND ClassGroup='{ClassGroup}' Order By Id", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ClassesList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpClasses.Properties.Columns.Clear();
			lookUpClasses.Properties.DataSource = dataTable;
			lookUpClasses.Properties.DisplayMember = "ClassId";
			lookUpClasses.Properties.ValueMember = "ClassId";
			LookUpColumnInfoCollection columns = lookUpClasses.Properties.Columns;
			columns.Add(new LookUpColumnInfo("ClassId", 0, "Class"));
			columns.Add(new LookUpColumnInfo("ClassGroup", 0, "Class Level"));
			columns.Add(new LookUpColumnInfo("SubGroup", 0, "Level Ranking"));
			lookUpClasses.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpClasses.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpClasses.Properties.AutoSearchColumnIndex = 0;
			lookUpClasses.Properties.HotTrackItems = true;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static string ListOfClasses()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ClassId  FROM Classes WHERE ClassId<>'All' AND ClassId<>'-N/A-' AND ClassId<>'Year1' AND ClassId<>'Year2' AND ClassId<>'Year3' Order By Id", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ListOfClasses");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				stringBuilder.Append(row["ClassId"].ToString() + " ");
			}
		}
		return stringBuilder.ToString().Trim();
	}

	public static string GetNextClassAfterThis(string CurrentClass)
	{
		string[] array = ListOfClasses().Split(' ');
		List<string> list = new List<string>();
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i].Equals(CurrentClass))
			{
				list.Add(array[i + 1]);
			}
		}
		return list[0].ToString();
	}

	public static void PopulateClassGallery(GalleryDropDown[] galleryDropDown1)
	{
		try
		{
			List<string> list = new List<string>();
			string[] array = new string[0];
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ClassId FROM Classes Order By Id", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ClassesList");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				list.Add(row["ClassId"].ToString());
			}
			array = list.ToArray();
			GalleryItemGroup galleryItemGroup = new GalleryItemGroup();
			for (int i = 0; i < array.Length; i++)
			{
				GalleryItem galleryItem = new GalleryItem();
				galleryItem.Caption = array[i].ToString();
				galleryItemGroup.Items.AddRange(new GalleryItem[1] { galleryItem });
			}
			for (int j = 0; j < galleryDropDown1.Length; j++)
			{
				galleryDropDown1[j].Gallery.Groups.AddRange(new GalleryItemGroup[1] { galleryItemGroup });
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
