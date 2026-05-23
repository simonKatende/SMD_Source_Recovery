using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using DevExpress.XtraBars.Ribbon;

namespace AlienAge.Accounts;

public class Budget
{
	private static GalleryItemGroup galleryItemGroup1 = new GalleryItemGroup();

	public static void PopulateBudgetGallery(GalleryDropDown[] galleryDropDown1)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		string[] array = new string[0];
		string[] array2 = new string[0];
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Category FROM tbl_budgetCategories Order By id", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "budgetCategories");
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			empty3 = row["Category"].ToString();
			empty = empty3.Substring(empty3.IndexOf('_') + 1, empty3.Length - (empty3.IndexOf('_') + 1));
			empty2 = empty3.Substring(0, empty3.IndexOf('_'));
			list.Add(empty);
			list2.Add(empty2);
		}
		array = list.ToArray();
		array2 = list2.ToArray();
		galleryItemGroup1.Items.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			GalleryItem galleryItem = new GalleryItem();
			galleryItem.Caption = array[i].ToString();
			galleryItem.Description = array2[i].ToString();
			galleryItemGroup1.Items.AddRange(new GalleryItem[1] { galleryItem });
		}
		for (int j = 0; j < galleryDropDown1.Length; j++)
		{
			galleryDropDown1[j].Gallery.Groups.AddRange(new GalleryItemGroup[1] { galleryItemGroup1 });
		}
	}
}
