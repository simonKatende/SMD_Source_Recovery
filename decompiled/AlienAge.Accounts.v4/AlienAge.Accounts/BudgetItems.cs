using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.Accounts;

[Serializable]
public class BudgetItems
{
	private string itemId { get; set; }

	private string item { get; set; }

	public static string BudgetItemID
	{
		get
		{
			string empty = string.Empty;
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "Alien_Age_SMD_Budget.tmp");
			if (File.Exists(path))
			{
				BudgetItems budgetItems = new BudgetItems();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				budgetItems = (BudgetItems)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return budgetItems.itemId;
			}
			return "Nothing";
		}
	}

	public static string BudgetItemName
	{
		get
		{
			string empty = string.Empty;
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "Alien_Age_SMD_Budget.tmp");
			if (File.Exists(path))
			{
				BudgetItems budgetItems = new BudgetItems();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				budgetItems = (BudgetItems)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return budgetItems.item;
			}
			return "Nothing";
		}
	}

	public static void SetItemId(string ItemID, string Item)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "Alien_Age_SMD_Budget.tmp");
		BudgetItems budgetItems = new BudgetItems();
		budgetItems.itemId = ItemID;
		budgetItems.item = Item;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, budgetItems);
		fileStream.Close();
	}
}
