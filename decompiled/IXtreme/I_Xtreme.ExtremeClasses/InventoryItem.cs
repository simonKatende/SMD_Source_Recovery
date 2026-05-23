using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
internal class InventoryItem
{
	private bool updateRunner { get; set; }

	private float stockCategoryId { get; set; }

	private string itemName { get; set; }

	public static float StockCategoryID
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_InventoryIem.tmp");
			InventoryItem inventoryItem = new InventoryItem();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			inventoryItem = (InventoryItem)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return inventoryItem.stockCategoryId;
		}
	}

	public static string StockItemName
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_InventoryIem.tmp");
			InventoryItem inventoryItem = new InventoryItem();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			inventoryItem = (InventoryItem)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return inventoryItem.itemName;
		}
	}

	public static void SetItemCategoryID(float catId, string ItemName)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_InventoryIem.tmp");
		InventoryItem inventoryItem = new InventoryItem();
		inventoryItem.stockCategoryId = catId;
		inventoryItem.itemName = ItemName;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, inventoryItem);
		fileStream.Close();
	}
}
