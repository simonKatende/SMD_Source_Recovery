using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.MealCards.dsMealCardv2TableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class DTableMealCardAdapter : Component
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
	public DTableMealCardAdapter()
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
		dataTableMapping.DataSetTable = "DTableMealCard";
		dataTableMapping.ColumnMappings.Add("auto", "auto");
		dataTableMapping.ColumnMappings.Add("StudentNumber", "StudentNumber");
		dataTableMapping.ColumnMappings.Add("Oid", "Oid");
		dataTableMapping.ColumnMappings.Add("StudentID", "StudentID");
		dataTableMapping.ColumnMappings.Add("fullName", "fullName");
		dataTableMapping.ColumnMappings.Add("ClassId", "ClassId");
		dataTableMapping.ColumnMappings.Add("StreamId", "StreamId");
		dataTableMapping.ColumnMappings.Add("LIN", "LIN");
		dataTableMapping.ColumnMappings.Add("Picture", "Picture");
		dataTableMapping.ColumnMappings.Add("RequiredFees", "RequiredFees");
		dataTableMapping.ColumnMappings.Add("cashOnAccount", "cashOnAccount");
		dataTableMapping.ColumnMappings.Add("FeesDiscount", "FeesDiscount");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [tbl_Stud] WHERE (([auto] = @Original_auto) AND ([StudentNumber] = @Original_StudentNumber) AND ([Oid] = @Original_Oid) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_LIN = 1 AND [LIN] IS NULL) OR ([LIN] = @Original_LIN)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_LIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [tbl_Stud] ([StudentNumber], [Oid], [StudentID], [fullName], [ClassId], [StreamId], [LIN], [Picture], [RequiredFees], [cashOnAccount], [FeesDiscount]) VALUES (@StudentNumber, @Oid, @StudentID, @fullName, @ClassId, @StreamId, @LIN, @Picture, @RequiredFees, @cashOnAccount, @FeesDiscount);\r\nSELECT auto, StudentNumber, Oid, StudentID, fullName, ClassId, StreamId, LIN, Picture, RequiredFees, cashOnAccount, FeesDiscount FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [tbl_Stud] SET [StudentNumber] = @StudentNumber, [Oid] = @Oid, [StudentID] = @StudentID, [fullName] = @fullName, [ClassId] = @ClassId, [StreamId] = @StreamId, [LIN] = @LIN, [Picture] = @Picture, [RequiredFees] = @RequiredFees, [cashOnAccount] = @cashOnAccount, [FeesDiscount] = @FeesDiscount WHERE (([auto] = @Original_auto) AND ([StudentNumber] = @Original_StudentNumber) AND ([Oid] = @Original_Oid) AND ((@IsNull_StudentID = 1 AND [StudentID] IS NULL) OR ([StudentID] = @Original_StudentID)) AND ((@IsNull_fullName = 1 AND [fullName] IS NULL) OR ([fullName] = @Original_fullName)) AND ((@IsNull_ClassId = 1 AND [ClassId] IS NULL) OR ([ClassId] = @Original_ClassId)) AND ((@IsNull_StreamId = 1 AND [StreamId] IS NULL) OR ([StreamId] = @Original_StreamId)) AND ((@IsNull_LIN = 1 AND [LIN] IS NULL) OR ([LIN] = @Original_LIN)) AND ((@IsNull_RequiredFees = 1 AND [RequiredFees] IS NULL) OR ([RequiredFees] = @Original_RequiredFees)) AND ((@IsNull_cashOnAccount = 1 AND [cashOnAccount] IS NULL) OR ([cashOnAccount] = @Original_cashOnAccount)) AND ((@IsNull_FeesDiscount = 1 AND [FeesDiscount] IS NULL) OR ([FeesDiscount] = @Original_FeesDiscount)));\r\nSELECT auto, StudentNumber, Oid, StudentID, fullName, ClassId, StreamId, LIN, Picture, RequiredFees, cashOnAccount, FeesDiscount FROM tbl_Stud WHERE (Oid = @Oid) AND (StudentNumber = @StudentNumber) AND (auto = @auto)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Picture", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Picture", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_auto", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Oid", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, 0, 0, "Oid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StudentID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StudentID", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StudentID", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fullName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fullName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ClassId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ClassId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ClassId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StreamId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StreamId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StreamId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_LIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_LIN", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "LIN", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_RequiredFees", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_RequiredFees", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "RequiredFees", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_cashOnAccount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_cashOnAccount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "cashOnAccount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FeesDiscount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FeesDiscount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "FeesDiscount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@auto", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "auto", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = "SELECT        auto, StudentNumber, Oid, StudentID, fullName, ClassId, StreamId, LIN, Picture, RequiredFees, cashOnAccount, FeesDiscount\r\nFROM            tbl_Stud";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(dsMealCardv2.DTableMealCardDataTable dataTable)
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
	public virtual dsMealCardv2.DTableMealCardDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		dsMealCardv2.DTableMealCardDataTable dTableMealCardDataTable = new dsMealCardv2.DTableMealCardDataTable();
		Adapter.Fill(dTableMealCardDataTable);
		return dTableMealCardDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dsMealCardv2.DTableMealCardDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dsMealCardv2 dataSet)
	{
		return Adapter.Update(dataSet, "DTableMealCard");
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
	public virtual int Delete(long Original_auto, string Original_StudentNumber, Guid Original_Oid, string Original_StudentID, string Original_fullName, string Original_ClassId, string Original_StreamId, string Original_LIN, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_auto;
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.DeleteCommand.Parameters[1].Value = Original_StudentNumber;
		Adapter.DeleteCommand.Parameters[2].Value = Original_Oid;
		if (Original_StudentID == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_StudentID;
		}
		if (Original_fullName == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_fullName;
		}
		if (Original_ClassId == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_StreamId;
		}
		if (Original_LIN == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_LIN;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
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
	public virtual int Insert(string StudentNumber, Guid Oid, string StudentID, string fullName, string ClassId, string StreamId, string LIN, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.InsertCommand.Parameters[0].Value = StudentNumber;
		Adapter.InsertCommand.Parameters[1].Value = Oid;
		if (StudentID == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = StudentID;
		}
		if (fullName == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = fullName;
		}
		if (ClassId == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = ClassId;
		}
		if (StreamId == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = StreamId;
		}
		if (LIN == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = LIN;
		}
		if (Picture == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = Picture;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.InsertCommand.Parameters[8].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.InsertCommand.Parameters[9].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.InsertCommand.Parameters[10].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
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
	public virtual int Update(string StudentNumber, Guid Oid, string StudentID, string fullName, string ClassId, string StreamId, string LIN, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, long Original_auto, string Original_StudentNumber, Guid Original_Oid, string Original_StudentID, string Original_fullName, string Original_ClassId, string Original_StreamId, string Original_LIN, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount, long auto)
	{
		if (StudentNumber == null)
		{
			throw new ArgumentNullException("StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[0].Value = StudentNumber;
		Adapter.UpdateCommand.Parameters[1].Value = Oid;
		if (StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = StudentID;
		}
		if (fullName == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = fullName;
		}
		if (ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = ClassId;
		}
		if (StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = StreamId;
		}
		if (LIN == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = LIN;
		}
		if (Picture == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = Picture;
		}
		if (RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[8].Value = RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		if (cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[9].Value = cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		if (FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[10].Value = FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		Adapter.UpdateCommand.Parameters[11].Value = Original_auto;
		if (Original_StudentNumber == null)
		{
			throw new ArgumentNullException("Original_StudentNumber");
		}
		Adapter.UpdateCommand.Parameters[12].Value = Original_StudentNumber;
		Adapter.UpdateCommand.Parameters[13].Value = Original_Oid;
		if (Original_StudentID == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = 1;
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = 0;
			Adapter.UpdateCommand.Parameters[15].Value = Original_StudentID;
		}
		if (Original_fullName == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = 1;
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = 0;
			Adapter.UpdateCommand.Parameters[17].Value = Original_fullName;
		}
		if (Original_ClassId == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = 1;
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = 0;
			Adapter.UpdateCommand.Parameters[19].Value = Original_ClassId;
		}
		if (Original_StreamId == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = 1;
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = 0;
			Adapter.UpdateCommand.Parameters[21].Value = Original_StreamId;
		}
		if (Original_LIN == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = 1;
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = 0;
			Adapter.UpdateCommand.Parameters[23].Value = Original_LIN;
		}
		if (Original_RequiredFees.HasValue)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_RequiredFees.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		if (Original_cashOnAccount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_cashOnAccount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		if (Original_FeesDiscount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[28].Value = 0;
			Adapter.UpdateCommand.Parameters[29].Value = Original_FeesDiscount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = 1;
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		Adapter.UpdateCommand.Parameters[30].Value = auto;
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
	public virtual int Update(string StudentID, string fullName, string ClassId, string StreamId, string LIN, byte[] Picture, decimal? RequiredFees, decimal? cashOnAccount, decimal? FeesDiscount, long Original_auto, string Original_StudentNumber, Guid Original_Oid, string Original_StudentID, string Original_fullName, string Original_ClassId, string Original_StreamId, string Original_LIN, decimal? Original_RequiredFees, decimal? Original_cashOnAccount, decimal? Original_FeesDiscount)
	{
		return Update(Original_StudentNumber, Original_Oid, StudentID, fullName, ClassId, StreamId, LIN, Picture, RequiredFees, cashOnAccount, FeesDiscount, Original_auto, Original_StudentNumber, Original_Oid, Original_StudentID, Original_fullName, Original_ClassId, Original_StreamId, Original_LIN, Original_RequiredFees, Original_cashOnAccount, Original_FeesDiscount, Original_auto);
	}
}
