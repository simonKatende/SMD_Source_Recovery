using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.StaffIDS.StaffDataTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class StaffTableAdapter : Component
{
	private SqlDataAdapter _adapter;

	private SqlConnection _connection;

	private SqlTransaction _transaction;

	private SqlCommand[] _commandCollection;

	private bool _clearBeforeFill;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected internal SqlDataAdapter Adapter
	{
		get
		{
			if (_adapter == null)
			{
				InitAdapter();
			}
			return _adapter;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	internal SqlConnection Connection
	{
		get
		{
			if (_connection == null)
			{
				InitConnection();
			}
			return _connection;
		}
		set
		{
			_connection = value;
			if (Adapter.InsertCommand != null)
			{
				Adapter.InsertCommand.Connection = value;
			}
			if (Adapter.DeleteCommand != null)
			{
				Adapter.DeleteCommand.Connection = value;
			}
			if (Adapter.UpdateCommand != null)
			{
				Adapter.UpdateCommand.Connection = value;
			}
			for (int i = 0; i < CommandCollection.Length; i++)
			{
				if (CommandCollection[i] != null)
				{
					CommandCollection[i].Connection = value;
				}
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	internal SqlTransaction Transaction
	{
		get
		{
			return _transaction;
		}
		set
		{
			_transaction = value;
			for (int i = 0; i < CommandCollection.Length; i++)
			{
				CommandCollection[i].Transaction = _transaction;
			}
			if (Adapter != null && Adapter.DeleteCommand != null)
			{
				Adapter.DeleteCommand.Transaction = _transaction;
			}
			if (Adapter != null && Adapter.InsertCommand != null)
			{
				Adapter.InsertCommand.Transaction = _transaction;
			}
			if (Adapter != null && Adapter.UpdateCommand != null)
			{
				Adapter.UpdateCommand.Transaction = _transaction;
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	protected SqlCommand[] CommandCollection
	{
		get
		{
			if (_commandCollection == null)
			{
				InitCommandCollection();
			}
			return _commandCollection;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public bool ClearBeforeFill
	{
		get
		{
			return _clearBeforeFill;
		}
		set
		{
			_clearBeforeFill = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	public StaffTableAdapter()
	{
		ClearBeforeFill = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitAdapter()
	{
		_adapter = new SqlDataAdapter();
		DataTableMapping dataTableMapping = new DataTableMapping();
		dataTableMapping.SourceTable = "Table";
		dataTableMapping.DataSetTable = "Staff";
		dataTableMapping.ColumnMappings.Add("StaffId", "StaffId");
		dataTableMapping.ColumnMappings.Add("StaffName", "StaffName");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("ContactNumber", "ContactNumber");
		dataTableMapping.ColumnMappings.Add("Responsibility", "Responsibility");
		dataTableMapping.ColumnMappings.Add("Pic", "Pic");
		dataTableMapping.ColumnMappings.Add("id", "id");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [Staff] WHERE (([StaffId] = @Original_StaffId) AND ((@IsNull_StaffName = 1 AND [StaffName] IS NULL) OR ([StaffName] = @Original_StaffName)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_ContactNumber = 1 AND [ContactNumber] IS NULL) OR ([ContactNumber] = @Original_ContactNumber)) AND ((@IsNull_Responsibility = 1 AND [Responsibility] IS NULL) OR ([Responsibility] = @Original_Responsibility)) AND ([id] = @Original_id))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StaffName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ContactNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Responsibility", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [Staff] ([StaffId], [StaffName], [Sex], [ContactNumber], [Responsibility], [Pic]) VALUES (@StaffId, @StaffName, @Sex, @ContactNumber, @Responsibility, @Pic);\r\nSELECT StaffId, StaffName, Sex, ContactNumber, Responsibility, Pic, id FROM Staff WHERE (StaffId = @StaffId)";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Pic", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [Staff] SET [StaffId] = @StaffId, [StaffName] = @StaffName, [Sex] = @Sex, [ContactNumber] = @ContactNumber, [Responsibility] = @Responsibility, [Pic] = @Pic WHERE (([StaffId] = @Original_StaffId) AND ((@IsNull_StaffName = 1 AND [StaffName] IS NULL) OR ([StaffName] = @Original_StaffName)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_ContactNumber = 1 AND [ContactNumber] IS NULL) OR ([ContactNumber] = @Original_ContactNumber)) AND ((@IsNull_Responsibility = 1 AND [Responsibility] IS NULL) OR ([Responsibility] = @Original_Responsibility)) AND ([id] = @Original_id));\r\nSELECT StaffId, StaffName, Sex, ContactNumber, Responsibility, Pic, id FROM Staff WHERE (StaffId = @StaffId)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Pic", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StaffName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ContactNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Responsibility", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitConnection()
	{
		_connection = new SqlConnection();
		_connection.ConnectionString = DataConnection.ConnectToDatabase();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitCommandCollection()
	{
		_commandCollection = new SqlCommand[1];
		_commandCollection[0] = new SqlCommand();
		_commandCollection[0].Connection = Connection;
		_commandCollection[0].CommandText = "SELECT        StaffId, StaffName, Sex, ContactNumber, Responsibility, Pic, id\r\nFROM            Staff";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(StaffData.StaffDataTable dataTable)
	{
		Adapter.SelectCommand = CommandCollection[0];
		if (ClearBeforeFill)
		{
			dataTable.Clear();
		}
		return Adapter.Fill(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Select, true)]
	public virtual StaffData.StaffDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		StaffData.StaffDataTable staffDataTable = new StaffData.StaffDataTable();
		Adapter.Fill(staffDataTable);
		return staffDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(StaffData.StaffDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(StaffData dataSet)
	{
		return Adapter.Update(dataSet, "Staff");
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(DataRow dataRow)
	{
		return Adapter.Update(new DataRow[1] { dataRow });
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(DataRow[] dataRows)
	{
		return Adapter.Update(dataRows);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Delete, true)]
	public virtual int Delete(string Original_StaffId, string Original_StaffName, string Original_Sex, string Original_ContactNumber, string Original_Responsibility, int Original_id)
	{
		if (Original_StaffId == null)
		{
			throw new ArgumentNullException("Original_StaffId");
		}
		Adapter.DeleteCommand.Parameters[0].Value = Original_StaffId;
		if (Original_StaffName == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_StaffName;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_Sex;
		}
		if (Original_ContactNumber == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_ContactNumber;
		}
		if (Original_Responsibility == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_Responsibility;
		}
		Adapter.DeleteCommand.Parameters[9].Value = Original_id;
		ConnectionState state = Adapter.DeleteCommand.Connection.State;
		if ((Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			Adapter.DeleteCommand.Connection.Open();
		}
		try
		{
			return Adapter.DeleteCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				Adapter.DeleteCommand.Connection.Close();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Insert, true)]
	public virtual int Insert(string StaffId, string StaffName, string Sex, string ContactNumber, string Responsibility, byte[] Pic)
	{
		if (StaffId == null)
		{
			throw new ArgumentNullException("StaffId");
		}
		Adapter.InsertCommand.Parameters[0].Value = StaffId;
		if (StaffName == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = StaffName;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = Sex;
		}
		if (ContactNumber == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = ContactNumber;
		}
		if (Responsibility == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = Responsibility;
		}
		if (Pic == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = Pic;
		}
		ConnectionState state = Adapter.InsertCommand.Connection.State;
		if ((Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			Adapter.InsertCommand.Connection.Open();
		}
		try
		{
			return Adapter.InsertCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				Adapter.InsertCommand.Connection.Close();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	public virtual int Update(string StaffId, string StaffName, string Sex, string ContactNumber, string Responsibility, byte[] Pic, string Original_StaffId, string Original_StaffName, string Original_Sex, string Original_ContactNumber, string Original_Responsibility, int Original_id)
	{
		if (StaffId == null)
		{
			throw new ArgumentNullException("StaffId");
		}
		Adapter.UpdateCommand.Parameters[0].Value = StaffId;
		if (StaffName == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = StaffName;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = Sex;
		}
		if (ContactNumber == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = ContactNumber;
		}
		if (Responsibility == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = Responsibility;
		}
		if (Pic == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = Pic;
		}
		if (Original_StaffId == null)
		{
			throw new ArgumentNullException("Original_StaffId");
		}
		Adapter.UpdateCommand.Parameters[6].Value = Original_StaffId;
		if (Original_StaffName == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = 1;
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = 0;
			Adapter.UpdateCommand.Parameters[8].Value = Original_StaffName;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = 1;
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = 0;
			Adapter.UpdateCommand.Parameters[10].Value = Original_Sex;
		}
		if (Original_ContactNumber == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = 1;
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = 0;
			Adapter.UpdateCommand.Parameters[12].Value = Original_ContactNumber;
		}
		if (Original_Responsibility == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = 1;
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = 0;
			Adapter.UpdateCommand.Parameters[14].Value = Original_Responsibility;
		}
		Adapter.UpdateCommand.Parameters[15].Value = Original_id;
		ConnectionState state = Adapter.UpdateCommand.Connection.State;
		if ((Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
		{
			Adapter.UpdateCommand.Connection.Open();
		}
		try
		{
			return Adapter.UpdateCommand.ExecuteNonQuery();
		}
		finally
		{
			if (state == ConnectionState.Closed)
			{
				Adapter.UpdateCommand.Connection.Close();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Update, true)]
	public virtual int Update(string StaffName, string Sex, string ContactNumber, string Responsibility, byte[] Pic, string Original_StaffId, string Original_StaffName, string Original_Sex, string Original_ContactNumber, string Original_Responsibility, int Original_id)
	{
		return Update(Original_StaffId, StaffName, Sex, ContactNumber, Responsibility, Pic, Original_StaffId, Original_StaffName, Original_Sex, Original_ContactNumber, Original_Responsibility, Original_id);
	}
}
