using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.StudentIDs;

[Serializable]
internal class TemplateCard
{
	private static Image tempImage { get; set; }

	public static Image TemplateCardImage
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "IXtreme_TemplateCard.tmp");
			TemplateCard templateCard = new TemplateCard();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			templateCard = (TemplateCard)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return tempImage;
		}
	}

	public static void SetTemplateCard(Image TempImages)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "IXtreme_TemplateCard.tmp");
		TemplateCard graph = new TemplateCard();
		tempImage = TempImages;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
