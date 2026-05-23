using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace I_Xtreme.dSetStaffTableAdapters;

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
		dataTableMapping.ColumnMappings.Add("StaffName", "StaffName");
		dataTableMapping.ColumnMappings.Add("StaffId", "StaffId");
		dataTableMapping.ColumnMappings.Add("FirstName", "FirstName");
		dataTableMapping.ColumnMappings.Add("LastName", "LastName");
		dataTableMapping.ColumnMappings.Add("ContactNumber", "ContactNumber");
		dataTableMapping.ColumnMappings.Add("Address", "Address");
		dataTableMapping.ColumnMappings.Add("Sex", "Sex");
		dataTableMapping.ColumnMappings.Add("Responsibility", "Responsibility");
		dataTableMapping.ColumnMappings.Add("HouseId", "HouseId");
		dataTableMapping.ColumnMappings.Add("Qualification", "Qualification");
		dataTableMapping.ColumnMappings.Add("DateOfHire", "DateOfHire");
		dataTableMapping.ColumnMappings.Add("SalaryAmount", "SalaryAmount");
		dataTableMapping.ColumnMappings.Add("unTaxableAmount", "unTaxableAmount");
		dataTableMapping.ColumnMappings.Add("payeeRate", "payeeRate");
		dataTableMapping.ColumnMappings.Add("payee", "payee");
		dataTableMapping.ColumnMappings.Add("NetPay", "NetPay");
		dataTableMapping.ColumnMappings.Add("WorkingStatus", "WorkingStatus");
		dataTableMapping.ColumnMappings.Add("Pic", "Pic");
		dataTableMapping.ColumnMappings.Add("FormerEmployee", "FormerEmployee");
		dataTableMapping.ColumnMappings.Add("status", "status");
		dataTableMapping.ColumnMappings.Add("NSSF", "NSSF");
		dataTableMapping.ColumnMappings.Add("NSSFRate", "NSSFRate");
		dataTableMapping.ColumnMappings.Add("Notes", "Notes");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Staff] WHERE (((@IsNull_StaffName = 1 AND [StaffName] IS NULL) OR ([StaffName] = @Original_StaffName)) AND ([StaffId] = @Original_StaffId) AND ((@IsNull_FirstName = 1 AND [FirstName] IS NULL) OR ([FirstName] = @Original_FirstName)) AND ((@IsNull_LastName = 1 AND [LastName] IS NULL) OR ([LastName] = @Original_LastName)) AND ((@IsNull_ContactNumber = 1 AND [ContactNumber] IS NULL) OR ([ContactNumber] = @Original_ContactNumber)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_Responsibility = 1 AND [Responsibility] IS NULL) OR ([Responsibility] = @Original_Responsibility)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_Qualification = 1 AND [Qualification] IS NULL) OR ([Qualification] = @Original_Qualification)) AND ((@IsNull_DateOfHire = 1 AND [DateOfHire] IS NULL) OR ([DateOfHire] = @Original_DateOfHire)) AND ((@IsNull_SalaryAmount = 1 AND [SalaryAmount] IS NULL) OR ([SalaryAmount] = @Original_SalaryAmount)) AND ((@IsNull_unTaxableAmount = 1 AND [unTaxableAmount] IS NULL) OR ([unTaxableAmount] = @Original_unTaxableAmount)) AND ((@IsNull_payeeRate = 1 AND [payeeRate] IS NULL) OR ([payeeRate] = @Original_payeeRate)) AND ((@IsNull_payee = 1 AND [payee] IS NULL) OR ([payee] = @Original_payee)) AND ((@IsNull_NetPay = 1 AND [NetPay] IS NULL) OR ([NetPay] = @Original_NetPay)) AND ((@IsNull_WorkingStatus = 1 AND [WorkingStatus] IS NULL) OR ([WorkingStatus] = @Original_WorkingStatus)) AND ((@IsNull_FormerEmployee = 1 AND [FormerEmployee] IS NULL) OR ([FormerEmployee] = @Original_FormerEmployee)) AND ((@IsNull_status = 1 AND [status] IS NULL) OR ([status] = @Original_status)) AND ((@IsNull_NSSF = 1 AND [NSSF] IS NULL) OR ([NSSF] = @Original_NSSF)) AND ((@IsNull_NSSFRate = 1 AND [NSSFRate] IS NULL) OR ([NSSFRate] = @Original_NSSFRate)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_StaffName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FirstName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_LastName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ContactNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Address", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Responsibility", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_HouseId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Qualification", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qualification", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Qualification", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Qualification", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_DateOfHire", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DateOfHire", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DateOfHire", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfHire", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SalaryAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalaryAmount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "SalaryAmount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_unTaxableAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "unTaxableAmount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_unTaxableAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "unTaxableAmount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_payeeRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "payeeRate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_payeeRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "payeeRate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_payee", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "payee", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_payee", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "payee", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_NetPay", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NetPay", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NetPay", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NetPay", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_WorkingStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WorkingStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_WorkingStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkingStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_FormerEmployee", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FormerEmployee", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_FormerEmployee", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerEmployee", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_NSSF", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NSSF", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NSSF", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NSSF", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_NSSFRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NSSFRate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NSSFRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "NSSFRate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Staff] ([StaffName], [StaffId], [FirstName], [LastName], [ContactNumber], [Address], [Sex], [Responsibility], [HouseId], [Qualification], [DateOfHire], [SalaryAmount], [unTaxableAmount], [payeeRate], [payee], [NetPay], [WorkingStatus], [Pic], [FormerEmployee], [status], [NSSF], [NSSFRate], [Notes]) VALUES (@StaffName, @StaffId, @FirstName, @LastName, @ContactNumber, @Address, @Sex, @Responsibility, @HouseId, @Qualification, @DateOfHire, @SalaryAmount, @unTaxableAmount, @payeeRate, @payee, @NetPay, @WorkingStatus, @Pic, @FormerEmployee, @status, @NSSF, @NSSFRate, @Notes);\r\nSELECT StaffName, StaffId, FirstName, LastName, ContactNumber, Address, Sex, Responsibility, HouseId, Qualification, DateOfHire, SalaryAmount, unTaxableAmount, payeeRate, payee, NetPay, WorkingStatus, Pic, FormerEmployee, status, NSSF, NSSFRate, Notes FROM Staff WHERE (StaffId = @StaffId)";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Qualification", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@DateOfHire", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfHire", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "SalaryAmount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@unTaxableAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "unTaxableAmount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@payeeRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "payeeRate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@payee", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "payee", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@NetPay", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NetPay", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@WorkingStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkingStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Pic", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Pic", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@FormerEmployee", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerEmployee", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@NSSF", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NSSF", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@NSSFRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "NSSFRate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Staff] SET [StaffName] = @StaffName, [StaffId] = @StaffId, [FirstName] = @FirstName, [LastName] = @LastName, [ContactNumber] = @ContactNumber, [Address] = @Address, [Sex] = @Sex, [Responsibility] = @Responsibility, [HouseId] = @HouseId, [Qualification] = @Qualification, [DateOfHire] = @DateOfHire, [SalaryAmount] = @SalaryAmount, [unTaxableAmount] = @unTaxableAmount, [payeeRate] = @payeeRate, [payee] = @payee, [NetPay] = @NetPay, [WorkingStatus] = @WorkingStatus, [Pic] = @Pic, [FormerEmployee] = @FormerEmployee, [status] = @status, [NSSF] = @NSSF, [NSSFRate] = @NSSFRate, [Notes] = @Notes WHERE (((@IsNull_StaffName = 1 AND [StaffName] IS NULL) OR ([StaffName] = @Original_StaffName)) AND ([StaffId] = @Original_StaffId) AND ((@IsNull_FirstName = 1 AND [FirstName] IS NULL) OR ([FirstName] = @Original_FirstName)) AND ((@IsNull_LastName = 1 AND [LastName] IS NULL) OR ([LastName] = @Original_LastName)) AND ((@IsNull_ContactNumber = 1 AND [ContactNumber] IS NULL) OR ([ContactNumber] = @Original_ContactNumber)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_Sex = 1 AND [Sex] IS NULL) OR ([Sex] = @Original_Sex)) AND ((@IsNull_Responsibility = 1 AND [Responsibility] IS NULL) OR ([Responsibility] = @Original_Responsibility)) AND ((@IsNull_HouseId = 1 AND [HouseId] IS NULL) OR ([HouseId] = @Original_HouseId)) AND ((@IsNull_Qualification = 1 AND [Qualification] IS NULL) OR ([Qualification] = @Original_Qualification)) AND ((@IsNull_DateOfHire = 1 AND [DateOfHire] IS NULL) OR ([DateOfHire] = @Original_DateOfHire)) AND ((@IsNull_SalaryAmount = 1 AND [SalaryAmount] IS NULL) OR ([SalaryAmount] = @Original_SalaryAmount)) AND ((@IsNull_unTaxableAmount = 1 AND [unTaxableAmount] IS NULL) OR ([unTaxableAmount] = @Original_unTaxableAmount)) AND ((@IsNull_payeeRate = 1 AND [payeeRate] IS NULL) OR ([payeeRate] = @Original_payeeRate)) AND ((@IsNull_payee = 1 AND [payee] IS NULL) OR ([payee] = @Original_payee)) AND ((@IsNull_NetPay = 1 AND [NetPay] IS NULL) OR ([NetPay] = @Original_NetPay)) AND ((@IsNull_WorkingStatus = 1 AND [WorkingStatus] IS NULL) OR ([WorkingStatus] = @Original_WorkingStatus)) AND ((@IsNull_FormerEmployee = 1 AND [FormerEmployee] IS NULL) OR ([FormerEmployee] = @Original_FormerEmployee)) AND ((@IsNull_status = 1 AND [status] IS NULL) OR ([status] = @Original_status)) AND ((@IsNull_NSSF = 1 AND [NSSF] IS NULL) OR ([NSSF] = @Original_NSSF)) AND ((@IsNull_NSSFRate = 1 AND [NSSFRate] IS NULL) OR ([NSSFRate] = @Original_NSSFRate)));\r\nSELECT StaffName, StaffId, FirstName, LastName, ContactNumber, Address, Sex, Responsibility, HouseId, Qualification, DateOfHire, SalaryAmount, unTaxableAmount, payeeRate, payee, NetPay, WorkingStatus, Pic, FormerEmployee, status, NSSF, NSSFRate, Notes FROM Staff WHERE (StaffId = @StaffId)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Qualification", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Qualification", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DateOfHire", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfHire", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "SalaryAmount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@unTaxableAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "unTaxableAmount", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@payeeRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "payeeRate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@payee", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "payee", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NetPay", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NetPay", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@WorkingStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkingStatus", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Pic", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Pic", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FormerEmployee", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerEmployee", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "status", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NSSF", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NSSF", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NSSFRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "NSSFRate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_StaffName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StaffName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_StaffId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "StaffId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FirstName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FirstName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FirstName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_LastName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_LastName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "LastName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ContactNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ContactNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ContactNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Address", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Sex", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Sex", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Sex", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Responsibility", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Responsibility", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Responsibility", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_HouseId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_HouseId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "HouseId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Qualification", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qualification", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Qualification", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Qualification", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_DateOfHire", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DateOfHire", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DateOfHire", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfHire", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SalaryAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalaryAmount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SalaryAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "SalaryAmount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_unTaxableAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "unTaxableAmount", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_unTaxableAmount", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "unTaxableAmount", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_payeeRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "payeeRate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_payeeRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "payeeRate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_payee", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "payee", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_payee", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "payee", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_NetPay", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NetPay", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_NetPay", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NetPay", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_WorkingStatus", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "WorkingStatus", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_WorkingStatus", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "WorkingStatus", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_FormerEmployee", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FormerEmployee", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_FormerEmployee", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "FormerEmployee", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_status", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "status", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_status", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "status", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_NSSF", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NSSF", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_NSSF", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "NSSF", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_NSSFRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NSSFRate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_NSSFRate", SqlDbType.Float, 0, ParameterDirection.Input, 0, 0, "NSSFRate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitConnection()
	{
		_connection = new SqlConnection();
		_connection.ConnectionString = "Data Source=INTELLIGENT\\SQLEXPRESS;Initial Catalog=IntelligentSRMS;User ID=sa;Password=spiderwick";
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitCommandCollection()
	{
		_commandCollection = new SqlCommand[1];
		_commandCollection[0] = new SqlCommand();
		_commandCollection[0].Connection = Connection;
		_commandCollection[0].CommandText = "SELECT StaffName, StaffId, FirstName, LastName, ContactNumber, Address, Sex, Responsibility, HouseId, Qualification, DateOfHire, SalaryAmount, unTaxableAmount, payeeRate, payee, NetPay, WorkingStatus, Pic, FormerEmployee, status, NSSF, NSSFRate, Notes FROM dbo.Staff";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(dSetStaff.StaffDataTable dataTable)
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
	public virtual dSetStaff.StaffDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		dSetStaff.StaffDataTable staffDataTable = new dSetStaff.StaffDataTable();
		Adapter.Fill(staffDataTable);
		return staffDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dSetStaff.StaffDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dSetStaff dataSet)
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
	public virtual int Delete(string Original_StaffName, string Original_StaffId, string Original_FirstName, string Original_LastName, string Original_ContactNumber, string Original_Address, string Original_Sex, string Original_Responsibility, string Original_HouseId, string Original_Qualification, DateTime? Original_DateOfHire, decimal? Original_SalaryAmount, decimal? Original_unTaxableAmount, double? Original_payeeRate, decimal? Original_payee, decimal? Original_NetPay, string Original_WorkingStatus, string Original_FormerEmployee, string Original_status, decimal? Original_NSSF, double? Original_NSSFRate)
	{
		if (Original_StaffName == null)
		{
			Adapter.DeleteCommand.Parameters[0].Value = 1;
			Adapter.DeleteCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[0].Value = 0;
			Adapter.DeleteCommand.Parameters[1].Value = Original_StaffName;
		}
		if (Original_StaffId == null)
		{
			throw new ArgumentNullException("Original_StaffId");
		}
		Adapter.DeleteCommand.Parameters[2].Value = Original_StaffId;
		if (Original_FirstName == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_FirstName;
		}
		if (Original_LastName == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_LastName;
		}
		if (Original_ContactNumber == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_ContactNumber;
		}
		if (Original_Address == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_Address;
		}
		if (Original_Sex == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_Sex;
		}
		if (Original_Responsibility == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_Responsibility;
		}
		if (Original_HouseId == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_HouseId;
		}
		if (Original_Qualification == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_Qualification;
		}
		if (Original_DateOfHire.HasValue)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_DateOfHire.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		if (Original_SalaryAmount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_SalaryAmount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		if (Original_unTaxableAmount.HasValue)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_unTaxableAmount.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		if (Original_payeeRate.HasValue)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_payeeRate.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		if (Original_payee.HasValue)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_payee.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		if (Original_NetPay.HasValue)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_NetPay.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		if (Original_WorkingStatus == null)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_WorkingStatus;
		}
		if (Original_FormerEmployee == null)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_FormerEmployee;
		}
		if (Original_status == null)
		{
			Adapter.DeleteCommand.Parameters[35].Value = 1;
			Adapter.DeleteCommand.Parameters[36].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[35].Value = 0;
			Adapter.DeleteCommand.Parameters[36].Value = Original_status;
		}
		if (Original_NSSF.HasValue)
		{
			Adapter.DeleteCommand.Parameters[37].Value = 0;
			Adapter.DeleteCommand.Parameters[38].Value = Original_NSSF.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[37].Value = 1;
			Adapter.DeleteCommand.Parameters[38].Value = DBNull.Value;
		}
		if (Original_NSSFRate.HasValue)
		{
			Adapter.DeleteCommand.Parameters[39].Value = 0;
			Adapter.DeleteCommand.Parameters[40].Value = Original_NSSFRate.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[39].Value = 1;
			Adapter.DeleteCommand.Parameters[40].Value = DBNull.Value;
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
	public virtual int Insert(string StaffName, string StaffId, string FirstName, string LastName, string ContactNumber, string Address, string Sex, string Responsibility, string HouseId, string Qualification, DateTime? DateOfHire, decimal? SalaryAmount, decimal? unTaxableAmount, double? payeeRate, decimal? payee, decimal? NetPay, string WorkingStatus, byte[] Pic, string FormerEmployee, string status, decimal? NSSF, double? NSSFRate, string Notes)
	{
		if (StaffName == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = StaffName;
		}
		if (StaffId == null)
		{
			throw new ArgumentNullException("StaffId");
		}
		Adapter.InsertCommand.Parameters[1].Value = StaffId;
		if (FirstName == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = FirstName;
		}
		if (LastName == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = LastName;
		}
		if (ContactNumber == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = ContactNumber;
		}
		if (Address == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = Address;
		}
		if (Sex == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = Sex;
		}
		if (Responsibility == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = Responsibility;
		}
		if (HouseId == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = HouseId;
		}
		if (Qualification == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = Qualification;
		}
		if (DateOfHire.HasValue)
		{
			Adapter.InsertCommand.Parameters[10].Value = DateOfHire.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		if (SalaryAmount.HasValue)
		{
			Adapter.InsertCommand.Parameters[11].Value = SalaryAmount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		if (unTaxableAmount.HasValue)
		{
			Adapter.InsertCommand.Parameters[12].Value = unTaxableAmount.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		if (payeeRate.HasValue)
		{
			Adapter.InsertCommand.Parameters[13].Value = payeeRate.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		if (payee.HasValue)
		{
			Adapter.InsertCommand.Parameters[14].Value = payee.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		if (NetPay.HasValue)
		{
			Adapter.InsertCommand.Parameters[15].Value = NetPay.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		if (WorkingStatus == null)
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = WorkingStatus;
		}
		if (Pic == null)
		{
			Adapter.InsertCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[17].Value = Pic;
		}
		if (FormerEmployee == null)
		{
			Adapter.InsertCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[18].Value = FormerEmployee;
		}
		if (status == null)
		{
			Adapter.InsertCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[19].Value = status;
		}
		if (NSSF.HasValue)
		{
			Adapter.InsertCommand.Parameters[20].Value = NSSF.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
		}
		if (NSSFRate.HasValue)
		{
			Adapter.InsertCommand.Parameters[21].Value = NSSFRate.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[21].Value = DBNull.Value;
		}
		if (Notes == null)
		{
			Adapter.InsertCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[22].Value = Notes;
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
	public virtual int Update(string StaffName, string StaffId, string FirstName, string LastName, string ContactNumber, string Address, string Sex, string Responsibility, string HouseId, string Qualification, DateTime? DateOfHire, decimal? SalaryAmount, decimal? unTaxableAmount, double? payeeRate, decimal? payee, decimal? NetPay, string WorkingStatus, byte[] Pic, string FormerEmployee, string status, decimal? NSSF, double? NSSFRate, string Notes, string Original_StaffName, string Original_StaffId, string Original_FirstName, string Original_LastName, string Original_ContactNumber, string Original_Address, string Original_Sex, string Original_Responsibility, string Original_HouseId, string Original_Qualification, DateTime? Original_DateOfHire, decimal? Original_SalaryAmount, decimal? Original_unTaxableAmount, double? Original_payeeRate, decimal? Original_payee, decimal? Original_NetPay, string Original_WorkingStatus, string Original_FormerEmployee, string Original_status, decimal? Original_NSSF, double? Original_NSSFRate)
	{
		if (StaffName == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = StaffName;
		}
		if (StaffId == null)
		{
			throw new ArgumentNullException("StaffId");
		}
		Adapter.UpdateCommand.Parameters[1].Value = StaffId;
		if (FirstName == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = FirstName;
		}
		if (LastName == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = LastName;
		}
		if (ContactNumber == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = ContactNumber;
		}
		if (Address == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = Address;
		}
		if (Sex == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = Sex;
		}
		if (Responsibility == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = Responsibility;
		}
		if (HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = HouseId;
		}
		if (Qualification == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = Qualification;
		}
		if (DateOfHire.HasValue)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DateOfHire.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		if (SalaryAmount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[11].Value = SalaryAmount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		if (unTaxableAmount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[12].Value = unTaxableAmount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		if (payeeRate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[13].Value = payeeRate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		if (payee.HasValue)
		{
			Adapter.UpdateCommand.Parameters[14].Value = payee.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		if (NetPay.HasValue)
		{
			Adapter.UpdateCommand.Parameters[15].Value = NetPay.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		if (WorkingStatus == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = WorkingStatus;
		}
		if (Pic == null)
		{
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[17].Value = Pic;
		}
		if (FormerEmployee == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = FormerEmployee;
		}
		if (status == null)
		{
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[19].Value = status;
		}
		if (NSSF.HasValue)
		{
			Adapter.UpdateCommand.Parameters[20].Value = NSSF.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
		}
		if (NSSFRate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[21].Value = NSSFRate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		if (Notes == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = Notes;
		}
		if (Original_StaffName == null)
		{
			Adapter.UpdateCommand.Parameters[23].Value = 1;
			Adapter.UpdateCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[23].Value = 0;
			Adapter.UpdateCommand.Parameters[24].Value = Original_StaffName;
		}
		if (Original_StaffId == null)
		{
			throw new ArgumentNullException("Original_StaffId");
		}
		Adapter.UpdateCommand.Parameters[25].Value = Original_StaffId;
		if (Original_FirstName == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_FirstName;
		}
		if (Original_LastName == null)
		{
			Adapter.UpdateCommand.Parameters[28].Value = 1;
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = 0;
			Adapter.UpdateCommand.Parameters[29].Value = Original_LastName;
		}
		if (Original_ContactNumber == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = 1;
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = 0;
			Adapter.UpdateCommand.Parameters[31].Value = Original_ContactNumber;
		}
		if (Original_Address == null)
		{
			Adapter.UpdateCommand.Parameters[32].Value = 1;
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = 0;
			Adapter.UpdateCommand.Parameters[33].Value = Original_Address;
		}
		if (Original_Sex == null)
		{
			Adapter.UpdateCommand.Parameters[34].Value = 1;
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = 0;
			Adapter.UpdateCommand.Parameters[35].Value = Original_Sex;
		}
		if (Original_Responsibility == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = 1;
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = 0;
			Adapter.UpdateCommand.Parameters[37].Value = Original_Responsibility;
		}
		if (Original_HouseId == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = 1;
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = 0;
			Adapter.UpdateCommand.Parameters[39].Value = Original_HouseId;
		}
		if (Original_Qualification == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = 1;
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = 0;
			Adapter.UpdateCommand.Parameters[41].Value = Original_Qualification;
		}
		if (Original_DateOfHire.HasValue)
		{
			Adapter.UpdateCommand.Parameters[42].Value = 0;
			Adapter.UpdateCommand.Parameters[43].Value = Original_DateOfHire.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = 1;
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		if (Original_SalaryAmount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[44].Value = 0;
			Adapter.UpdateCommand.Parameters[45].Value = Original_SalaryAmount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = 1;
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		if (Original_unTaxableAmount.HasValue)
		{
			Adapter.UpdateCommand.Parameters[46].Value = 0;
			Adapter.UpdateCommand.Parameters[47].Value = Original_unTaxableAmount.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = 1;
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		if (Original_payeeRate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[48].Value = 0;
			Adapter.UpdateCommand.Parameters[49].Value = Original_payeeRate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = 1;
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		if (Original_payee.HasValue)
		{
			Adapter.UpdateCommand.Parameters[50].Value = 0;
			Adapter.UpdateCommand.Parameters[51].Value = Original_payee.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = 1;
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		if (Original_NetPay.HasValue)
		{
			Adapter.UpdateCommand.Parameters[52].Value = 0;
			Adapter.UpdateCommand.Parameters[53].Value = Original_NetPay.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[52].Value = 1;
			Adapter.UpdateCommand.Parameters[53].Value = DBNull.Value;
		}
		if (Original_WorkingStatus == null)
		{
			Adapter.UpdateCommand.Parameters[54].Value = 1;
			Adapter.UpdateCommand.Parameters[55].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[54].Value = 0;
			Adapter.UpdateCommand.Parameters[55].Value = Original_WorkingStatus;
		}
		if (Original_FormerEmployee == null)
		{
			Adapter.UpdateCommand.Parameters[56].Value = 1;
			Adapter.UpdateCommand.Parameters[57].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[56].Value = 0;
			Adapter.UpdateCommand.Parameters[57].Value = Original_FormerEmployee;
		}
		if (Original_status == null)
		{
			Adapter.UpdateCommand.Parameters[58].Value = 1;
			Adapter.UpdateCommand.Parameters[59].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[58].Value = 0;
			Adapter.UpdateCommand.Parameters[59].Value = Original_status;
		}
		if (Original_NSSF.HasValue)
		{
			Adapter.UpdateCommand.Parameters[60].Value = 0;
			Adapter.UpdateCommand.Parameters[61].Value = Original_NSSF.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[60].Value = 1;
			Adapter.UpdateCommand.Parameters[61].Value = DBNull.Value;
		}
		if (Original_NSSFRate.HasValue)
		{
			Adapter.UpdateCommand.Parameters[62].Value = 0;
			Adapter.UpdateCommand.Parameters[63].Value = Original_NSSFRate.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[62].Value = 1;
			Adapter.UpdateCommand.Parameters[63].Value = DBNull.Value;
		}
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
	public virtual int Update(string StaffName, string FirstName, string LastName, string ContactNumber, string Address, string Sex, string Responsibility, string HouseId, string Qualification, DateTime? DateOfHire, decimal? SalaryAmount, decimal? unTaxableAmount, double? payeeRate, decimal? payee, decimal? NetPay, string WorkingStatus, byte[] Pic, string FormerEmployee, string status, decimal? NSSF, double? NSSFRate, string Notes, string Original_StaffName, string Original_StaffId, string Original_FirstName, string Original_LastName, string Original_ContactNumber, string Original_Address, string Original_Sex, string Original_Responsibility, string Original_HouseId, string Original_Qualification, DateTime? Original_DateOfHire, decimal? Original_SalaryAmount, decimal? Original_unTaxableAmount, double? Original_payeeRate, decimal? Original_payee, decimal? Original_NetPay, string Original_WorkingStatus, string Original_FormerEmployee, string Original_status, decimal? Original_NSSF, double? Original_NSSFRate)
	{
		return Update(StaffName, Original_StaffId, FirstName, LastName, ContactNumber, Address, Sex, Responsibility, HouseId, Qualification, DateOfHire, SalaryAmount, unTaxableAmount, payeeRate, payee, NetPay, WorkingStatus, Pic, FormerEmployee, status, NSSF, NSSFRate, Notes, Original_StaffName, Original_StaffId, Original_FirstName, Original_LastName, Original_ContactNumber, Original_Address, Original_Sex, Original_Responsibility, Original_HouseId, Original_Qualification, Original_DateOfHire, Original_SalaryAmount, Original_unTaxableAmount, Original_payeeRate, Original_payee, Original_NetPay, Original_WorkingStatus, Original_FormerEmployee, Original_status, Original_NSSF, Original_NSSFRate);
	}
}
