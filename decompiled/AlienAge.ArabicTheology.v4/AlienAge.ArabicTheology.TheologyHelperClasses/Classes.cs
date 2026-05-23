using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public class Classes
{
	public enum ClassLevels
	{
		Shuuba,
		Idaad,
		Thanawi
	}

	private static ReportViewMode.ReportViewLanguage viewL = default(ReportViewMode.ReportViewLanguage);

	public static string[] ShuubaClassesEn
	{
		get
		{
			List<string> list = new List<string>();
			for (int i = 0; i < 4; i++)
			{
				list.Add(ClassList[i].Key);
			}
			return list.ToArray();
		}
	}

	public static string[] IdaadClassesEn
	{
		get
		{
			List<string> list = new List<string>();
			for (int i = 4; i < 7; i++)
			{
				list.Add(ClassList[i].Key);
			}
			return list.ToArray();
		}
	}

	public static string[] ThanawiClassesEn
	{
		get
		{
			List<string> list = new List<string>();
			for (int i = 7; i < 10; i++)
			{
				list.Add(ClassList[i].Key);
			}
			return list.ToArray();
		}
	}

	public static List<string> CurriculumLevels
	{
		get
		{
			List<string> list = new List<string>();
			if (viewL.IsShuubaDone)
			{
				list.Add("Shuuba");
			}
			if (viewL.IsIdaadDone)
			{
				list.Add("Idaad");
			}
			if (viewL.IsThanawiDone)
			{
				list.Add("Thanawi");
			}
			return list;
		}
	}

	private static List<KeyValuePair<string, string>> ClassList
	{
		get
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("Shu`ba Alifu", "شعبة ا"));
			list.Add(new KeyValuePair<string, string>("Shu`ba Baa - u", "شعبة ب"));
			list.Add(new KeyValuePair<string, string>("Shu`ba Jiimu", "شعبة ج"));
			list.Add(new KeyValuePair<string, string>("Shu`ba Daal", "شعبة د"));
			list.Add(new KeyValuePair<string, string>("Awwalu Idaad", "الأول الإعدادي"));
			list.Add(new KeyValuePair<string, string>("Thaani Idaad", "الثاني الإعدادي"));
			list.Add(new KeyValuePair<string, string>("Thaalitha Idaad", "الثالث الإعدادي"));
			list.Add(new KeyValuePair<string, string>("Awwalu Thanawi", "الأول الثانوي"));
			list.Add(new KeyValuePair<string, string>("Thaani Thanawi", "الثاني الثانوي"));
			list.Add(new KeyValuePair<string, string>("Thaalitha Thanawi", "الثالث الثانوي"));
			return list;
		}
	}

	public Classes()
	{
		viewL.InitializeViewLanguage();
	}

	public static string GetArabicClass(int index)
	{
		string empty = string.Empty;
		return ClassList[index].Value.ToString();
	}

	public void PopulateAllClassesToComboEn(ComboBoxEdit[] comb)
	{
		for (int i = 0; i < comb.Length; i++)
		{
			if (viewL.IsShuubaDone)
			{
				for (int j = 0; j < ShuubaClassesEn.Length; j++)
				{
					comb[i].Properties.Items.Add(ShuubaClassesEn[j]);
				}
			}
			if (viewL.IsIdaadDone)
			{
				for (int k = 0; k < IdaadClassesEn.Length; k++)
				{
					comb[i].Properties.Items.Add(IdaadClassesEn[k]);
				}
			}
			if (viewL.IsThanawiDone)
			{
				for (int l = 0; l < ThanawiClassesEn.Length; l++)
				{
					comb[i].Properties.Items.Add(ThanawiClassesEn[l]);
				}
			}
		}
	}

	public static void LoadClassesToCombo(ComboBoxEdit comb, string ClassLevel)
	{
		if (ClassLevel == ClassLevels.Idaad.ToString())
		{
			comb.Properties.Items.Clear();
			for (int i = 0; i < IdaadClassesEn.Length; i++)
			{
				comb.Properties.Items.Add(IdaadClassesEn[i].ToString());
			}
		}
		else if (ClassLevel == ClassLevels.Shuuba.ToString())
		{
			comb.Properties.Items.Clear();
			for (int j = 0; j < ShuubaClassesEn.Length; j++)
			{
				comb.Properties.Items.Add(ShuubaClassesEn[j].ToString());
			}
		}
		else if (ClassLevel == ClassLevels.Thanawi.ToString())
		{
			comb.Properties.Items.Clear();
			for (int k = 0; k < ThanawiClassesEn.Length; k++)
			{
				comb.Properties.Items.Add(ThanawiClassesEn[k].ToString());
			}
		}
	}
}
