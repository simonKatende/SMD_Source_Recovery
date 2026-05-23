using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibraryManagement;

[Serializable]
internal class EditableFields
{
	private long fieldId { get; set; }

	private string fieldGroup { get; set; }

	public static long FieldID
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "Xtreme_Library_Manager_EditableFields.tmp");
			EditableFields editableFields = new EditableFields();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			editableFields = (EditableFields)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return editableFields.fieldId;
		}
	}

	public static void SetEditableFieldValues(long _fieldId, string _fieldGroup)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "Xtreme_Library_Manager_EditableFields.tmp");
		EditableFields editableFields = new EditableFields();
		editableFields.fieldGroup = _fieldGroup;
		editableFields.fieldId = _fieldId;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, editableFields);
		fileStream.Close();
	}

	public static string FieldGroup()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "Xtreme_Library_Manager_EditableFields.tmp");
		EditableFields editableFields = new EditableFields();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		editableFields = (EditableFields)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return editableFields.fieldGroup;
	}
}
