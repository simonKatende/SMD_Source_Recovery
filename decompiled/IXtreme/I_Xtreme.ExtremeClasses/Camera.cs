using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
internal class Camera
{
	private static int brightness { get; set; }

	private static int contrast { get; set; }

	public static int BrightnessValue
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "IXtreme_Camera.tmp");
			if (File.Exists(path))
			{
				Camera camera = new Camera();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				camera = (Camera)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return brightness;
			}
			return 10;
		}
	}

	public static int ContrastValue
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "IXtreme_Camera.tmp");
			if (File.Exists(path))
			{
				Camera camera = new Camera();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				camera = (Camera)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return contrast;
			}
			return 10;
		}
	}

	public static void AdjustCameraValues(int _brightness, int _contrast)
	{
		string path = Path.Combine(Path.GetTempPath(), "IXtreme_Camera.tmp");
		Camera graph = new Camera();
		brightness = _brightness;
		contrast = _contrast;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
