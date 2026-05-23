using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using AlienAge.Connectivity;

namespace I_Xtreme.PaymentVoucher.PaymentVoucherTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class PaymentVoucherTableAdapter : Component
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
	public PaymentVoucherTableAdapter()
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
		dataTableMapping.DataSetTable = "PaymentVoucher";
		dataTableMapping.ColumnMappings.Add("Expenseid", "Expenseid");
		dataTableMapping.ColumnMappings.Add("ExpenseName", "ExpenseName");
		dataTableMapping.ColumnMappings.Add("expenseSource", "expenseSource");
		dataTableMapping.ColumnMappings.Add("qty", "qty");
		dataTableMapping.ColumnMappings.Add("units", "units");
		dataTableMapping.ColumnMappings.Add("PaymentMode", "PaymentMode");
		dataTableMapping.ColumnMappings.Add("ChequeNo", "ChequeNo");
		dataTableMapping.ColumnMappings.Add("VoucherNo", "VoucherNo");
		dataTableMapping.ColumnMappings.Add("ExpenseValue", "ExpenseValue");
		dataTableMapping.ColumnMappings.Add("DateOfExpense", "DateOfExpense");
		dataTableMapping.ColumnMappings.Add("SemesterId", "SemesterId");
		dataTableMapping.ColumnMappings.Add("Narration", "Narration");
		dataTableMapping.ColumnMappings.Add("Debitor", "Debitor");
		dataTableMapping.ColumnMappings.Add("CaptureDate", "CaptureDate");
		dataTableMapping.ColumnMappings.Add("NarrationBig", "NarrationBig");
		dataTableMapping.ColumnMappings.Add("Contact", "Contact");
		dataTableMapping.ColumnMappings.Add("Address", "Address");
		dataTableMapping.ColumnMappings.Add("Payee", "Payee");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [Expenses] WHERE (([Expenseid] = @Original_Expenseid) AND ((@IsNull_ExpenseName = 1 AND [ExpenseName] IS NULL) OR ([ExpenseName] = @Original_ExpenseName)) AND ((@IsNull_expenseSource = 1 AND [expenseSource] IS NULL) OR ([expenseSource] = @Original_expenseSource)) AND ((@IsNull_qty = 1 AND [qty] IS NULL) OR ([qty] = @Original_qty)) AND ((@IsNull_units = 1 AND [units] IS NULL) OR ([units] = @Original_units)) AND ((@IsNull_PaymentMode = 1 AND [PaymentMode] IS NULL) OR ([PaymentMode] = @Original_PaymentMode)) AND ((@IsNull_ChequeNo = 1 AND [ChequeNo] IS NULL) OR ([ChequeNo] = @Original_ChequeNo)) AND ((@IsNull_VoucherNo = 1 AND [VoucherNo] IS NULL) OR ([VoucherNo] = @Original_VoucherNo)) AND ((@IsNull_ExpenseValue = 1 AND [ExpenseValue] IS NULL) OR ([ExpenseValue] = @Original_ExpenseValue)) AND ((@IsNull_DateOfExpense = 1 AND [DateOfExpense] IS NULL) OR ([DateOfExpense] = @Original_DateOfExpense)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_Narration = 1 AND [Narration] IS NULL) OR ([Narration] = @Original_Narration)) AND ((@IsNull_Debitor = 1 AND [Debitor] IS NULL) OR ([Debitor] = @Original_Debitor)) AND ((@IsNull_CaptureDate = 1 AND [CaptureDate] IS NULL) OR ([CaptureDate] = @Original_CaptureDate)) AND ((@IsNull_NarrationBig = 1 AND [NarrationBig] IS NULL) OR ([NarrationBig] = @Original_NarrationBig)) AND ((@IsNull_Contact = 1 AND [Contact] IS NULL) OR ([Contact] = @Original_Contact)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_Payee = 1 AND [Payee] IS NULL) OR ([Payee] = @Original_Payee)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Expenseid", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "Expenseid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ExpenseName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ExpenseName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ExpenseName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ExpenseName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_expenseSource", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "expenseSource", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_expenseSource", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "expenseSource", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "qty", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "qty", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_units", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "units", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_units", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "units", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_PaymentMode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_PaymentMode", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ChequeNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ChequeNo", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ChequeNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ChequeNo", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_VoucherNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_VoucherNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ExpenseValue", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ExpenseValue", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ExpenseValue", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "ExpenseValue", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_DateOfExpense", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DateOfExpense", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DateOfExpense", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfExpense", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Narration", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Narration", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Narration", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Narration", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Debitor", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Debitor", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Debitor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Debitor", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_CaptureDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_NarrationBig", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NarrationBig", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_NarrationBig", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "NarrationBig", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Contact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Contact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Contact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Contact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_Payee", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Payee", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Payee", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Payee", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [Expenses] ([ExpenseName], [expenseSource], [qty], [units], [PaymentMode], [ChequeNo], [VoucherNo], [ExpenseValue], [DateOfExpense], [SemesterId], [Narration], [Debitor], [CaptureDate], [NarrationBig], [Contact], [Address], [Payee]) VALUES (@ExpenseName, @expenseSource, @qty, @units, @PaymentMode, @ChequeNo, @VoucherNo, @ExpenseValue, @DateOfExpense, @SemesterId, @Narration, @Debitor, @CaptureDate, @NarrationBig, @Contact, @Address, @Payee);\r\nSELECT Expenseid, ExpenseName, expenseSource, qty, units, PaymentMode, ChequeNo, VoucherNo, ExpenseValue, DateOfExpense, SemesterId, Narration, Debitor, CaptureDate, NarrationBig, Contact, Address, Payee FROM Expenses WHERE (Expenseid = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ExpenseName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ExpenseName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@expenseSource", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "expenseSource", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "qty", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@units", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "units", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ChequeNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ChequeNo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@VoucherNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ExpenseValue", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "ExpenseValue", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@DateOfExpense", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfExpense", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Narration", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Narration", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Debitor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Debitor", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@NarrationBig", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "NarrationBig", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Contact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@Payee", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Payee", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [Expenses] SET [ExpenseName] = @ExpenseName, [expenseSource] = @expenseSource, [qty] = @qty, [units] = @units, [PaymentMode] = @PaymentMode, [ChequeNo] = @ChequeNo, [VoucherNo] = @VoucherNo, [ExpenseValue] = @ExpenseValue, [DateOfExpense] = @DateOfExpense, [SemesterId] = @SemesterId, [Narration] = @Narration, [Debitor] = @Debitor, [CaptureDate] = @CaptureDate, [NarrationBig] = @NarrationBig, [Contact] = @Contact, [Address] = @Address, [Payee] = @Payee WHERE (([Expenseid] = @Original_Expenseid) AND ((@IsNull_ExpenseName = 1 AND [ExpenseName] IS NULL) OR ([ExpenseName] = @Original_ExpenseName)) AND ((@IsNull_expenseSource = 1 AND [expenseSource] IS NULL) OR ([expenseSource] = @Original_expenseSource)) AND ((@IsNull_qty = 1 AND [qty] IS NULL) OR ([qty] = @Original_qty)) AND ((@IsNull_units = 1 AND [units] IS NULL) OR ([units] = @Original_units)) AND ((@IsNull_PaymentMode = 1 AND [PaymentMode] IS NULL) OR ([PaymentMode] = @Original_PaymentMode)) AND ((@IsNull_ChequeNo = 1 AND [ChequeNo] IS NULL) OR ([ChequeNo] = @Original_ChequeNo)) AND ((@IsNull_VoucherNo = 1 AND [VoucherNo] IS NULL) OR ([VoucherNo] = @Original_VoucherNo)) AND ((@IsNull_ExpenseValue = 1 AND [ExpenseValue] IS NULL) OR ([ExpenseValue] = @Original_ExpenseValue)) AND ((@IsNull_DateOfExpense = 1 AND [DateOfExpense] IS NULL) OR ([DateOfExpense] = @Original_DateOfExpense)) AND ((@IsNull_SemesterId = 1 AND [SemesterId] IS NULL) OR ([SemesterId] = @Original_SemesterId)) AND ((@IsNull_Narration = 1 AND [Narration] IS NULL) OR ([Narration] = @Original_Narration)) AND ((@IsNull_Debitor = 1 AND [Debitor] IS NULL) OR ([Debitor] = @Original_Debitor)) AND ((@IsNull_CaptureDate = 1 AND [CaptureDate] IS NULL) OR ([CaptureDate] = @Original_CaptureDate)) AND ((@IsNull_NarrationBig = 1 AND [NarrationBig] IS NULL) OR ([NarrationBig] = @Original_NarrationBig)) AND ((@IsNull_Contact = 1 AND [Contact] IS NULL) OR ([Contact] = @Original_Contact)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_Payee = 1 AND [Payee] IS NULL) OR ([Payee] = @Original_Payee)));\r\nSELECT Expenseid, ExpenseName, expenseSource, qty, units, PaymentMode, ChequeNo, VoucherNo, ExpenseValue, DateOfExpense, SemesterId, Narration, Debitor, CaptureDate, NarrationBig, Contact, Address, Payee FROM Expenses WHERE (Expenseid = @Expenseid)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ExpenseName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ExpenseName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@expenseSource", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "expenseSource", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "qty", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@units", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "units", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ChequeNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ChequeNo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@VoucherNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ExpenseValue", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "ExpenseValue", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DateOfExpense", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfExpense", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Narration", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Narration", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Debitor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Debitor", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NarrationBig", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "NarrationBig", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Contact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Payee", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Payee", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Expenseid", SqlDbType.BigInt, 0, ParameterDirection.Input, 0, 0, "Expenseid", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ExpenseName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ExpenseName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ExpenseName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ExpenseName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_expenseSource", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "expenseSource", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_expenseSource", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "expenseSource", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "qty", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "qty", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_units", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "units", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_units", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "units", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_PaymentMode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_PaymentMode", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ChequeNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ChequeNo", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ChequeNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ChequeNo", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_VoucherNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_VoucherNo", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ExpenseValue", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ExpenseValue", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ExpenseValue", SqlDbType.Money, 0, ParameterDirection.Input, 0, 0, "ExpenseValue", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_DateOfExpense", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DateOfExpense", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DateOfExpense", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "DateOfExpense", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SemesterId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SemesterId", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SemesterId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Narration", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Narration", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Narration", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Narration", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Debitor", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Debitor", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Debitor", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "Debitor", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_CaptureDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_CaptureDate", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "CaptureDate", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_NarrationBig", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "NarrationBig", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_NarrationBig", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "NarrationBig", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Contact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Contact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Contact", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Contact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_Payee", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Payee", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Payee", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Payee", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Expenseid", SqlDbType.BigInt, 8, ParameterDirection.Input, 0, 0, "Expenseid", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
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
		_commandCollection[0].CommandText = $"SELECT Expenseid, ExpenseName, expenseSource, qty, units, PaymentMode, ChequeNo, VoucherNo, ExpenseValue, DateOfExpense, SemesterId, Narration, Debitor, CaptureDate, NarrationBig, Contact, Address, Payee\r\n            FROM  Expenses WHERE  VoucherNo = '{VoucherParameters.VoucherNoSelected}'";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(PaymentVoucher.PaymentVoucherDataTable dataTable)
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
	public virtual PaymentVoucher.PaymentVoucherDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		PaymentVoucher.PaymentVoucherDataTable paymentVoucherDataTable = new PaymentVoucher.PaymentVoucherDataTable();
		Adapter.Fill(paymentVoucherDataTable);
		return paymentVoucherDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(PaymentVoucher.PaymentVoucherDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(PaymentVoucher dataSet)
	{
		return Adapter.Update(dataSet, "PaymentVoucher");
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
	public virtual int Delete(long Original_Expenseid, string Original_ExpenseName, string Original_expenseSource, int? Original_qty, string Original_units, string Original_PaymentMode, string Original_ChequeNo, string Original_VoucherNo, decimal? Original_ExpenseValue, DateTime? Original_DateOfExpense, string Original_SemesterId, string Original_Narration, string Original_Debitor, string Original_CaptureDate, string Original_NarrationBig, string Original_Contact, string Original_Address, string Original_Payee)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_Expenseid;
		if (Original_ExpenseName == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_ExpenseName;
		}
		if (Original_expenseSource == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_expenseSource;
		}
		if (Original_qty.HasValue)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_qty.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		if (Original_units == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_units;
		}
		if (Original_PaymentMode == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_PaymentMode;
		}
		if (Original_ChequeNo == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_ChequeNo;
		}
		if (Original_VoucherNo == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_VoucherNo;
		}
		if (Original_ExpenseValue.HasValue)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_ExpenseValue.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		if (Original_DateOfExpense.HasValue)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_DateOfExpense.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		if (Original_SemesterId == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_SemesterId;
		}
		if (Original_Narration == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_Narration;
		}
		if (Original_Debitor == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_Debitor;
		}
		if (Original_CaptureDate == null)
		{
			Adapter.DeleteCommand.Parameters[25].Value = 1;
			Adapter.DeleteCommand.Parameters[26].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[25].Value = 0;
			Adapter.DeleteCommand.Parameters[26].Value = Original_CaptureDate;
		}
		if (Original_NarrationBig == null)
		{
			Adapter.DeleteCommand.Parameters[27].Value = 1;
			Adapter.DeleteCommand.Parameters[28].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[27].Value = 0;
			Adapter.DeleteCommand.Parameters[28].Value = Original_NarrationBig;
		}
		if (Original_Contact == null)
		{
			Adapter.DeleteCommand.Parameters[29].Value = 1;
			Adapter.DeleteCommand.Parameters[30].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[29].Value = 0;
			Adapter.DeleteCommand.Parameters[30].Value = Original_Contact;
		}
		if (Original_Address == null)
		{
			Adapter.DeleteCommand.Parameters[31].Value = 1;
			Adapter.DeleteCommand.Parameters[32].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[31].Value = 0;
			Adapter.DeleteCommand.Parameters[32].Value = Original_Address;
		}
		if (Original_Payee == null)
		{
			Adapter.DeleteCommand.Parameters[33].Value = 1;
			Adapter.DeleteCommand.Parameters[34].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[33].Value = 0;
			Adapter.DeleteCommand.Parameters[34].Value = Original_Payee;
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
	public virtual int Insert(string ExpenseName, string expenseSource, int? qty, string units, string PaymentMode, string ChequeNo, string VoucherNo, decimal? ExpenseValue, DateTime? DateOfExpense, string SemesterId, string Narration, string Debitor, string CaptureDate, string NarrationBig, string Contact, string Address, string Payee)
	{
		if (ExpenseName == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = ExpenseName;
		}
		if (expenseSource == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = expenseSource;
		}
		if (qty.HasValue)
		{
			Adapter.InsertCommand.Parameters[2].Value = qty.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		if (units == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = units;
		}
		if (PaymentMode == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = PaymentMode;
		}
		if (ChequeNo == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = ChequeNo;
		}
		if (VoucherNo == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = VoucherNo;
		}
		if (ExpenseValue.HasValue)
		{
			Adapter.InsertCommand.Parameters[7].Value = ExpenseValue.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		if (DateOfExpense.HasValue)
		{
			Adapter.InsertCommand.Parameters[8].Value = DateOfExpense.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		if (SemesterId == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = SemesterId;
		}
		if (Narration == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = Narration;
		}
		if (Debitor == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = Debitor;
		}
		if (CaptureDate == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = CaptureDate;
		}
		if (NarrationBig == null)
		{
			Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[13].Value = NarrationBig;
		}
		if (Contact == null)
		{
			Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[14].Value = Contact;
		}
		if (Address == null)
		{
			Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[15].Value = Address;
		}
		if (Payee == null)
		{
			Adapter.InsertCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[16].Value = Payee;
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
	public virtual int Update(string ExpenseName, string expenseSource, int? qty, string units, string PaymentMode, string ChequeNo, string VoucherNo, decimal? ExpenseValue, DateTime? DateOfExpense, string SemesterId, string Narration, string Debitor, string CaptureDate, string NarrationBig, string Contact, string Address, string Payee, long Original_Expenseid, string Original_ExpenseName, string Original_expenseSource, int? Original_qty, string Original_units, string Original_PaymentMode, string Original_ChequeNo, string Original_VoucherNo, decimal? Original_ExpenseValue, DateTime? Original_DateOfExpense, string Original_SemesterId, string Original_Narration, string Original_Debitor, string Original_CaptureDate, string Original_NarrationBig, string Original_Contact, string Original_Address, string Original_Payee, long Expenseid)
	{
		if (ExpenseName == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = ExpenseName;
		}
		if (expenseSource == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = expenseSource;
		}
		if (qty.HasValue)
		{
			Adapter.UpdateCommand.Parameters[2].Value = qty.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		if (units == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = units;
		}
		if (PaymentMode == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = PaymentMode;
		}
		if (ChequeNo == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = ChequeNo;
		}
		if (VoucherNo == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = VoucherNo;
		}
		if (ExpenseValue.HasValue)
		{
			Adapter.UpdateCommand.Parameters[7].Value = ExpenseValue.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		if (DateOfExpense.HasValue)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DateOfExpense.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		if (SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = SemesterId;
		}
		if (Narration == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = Narration;
		}
		if (Debitor == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = Debitor;
		}
		if (CaptureDate == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = CaptureDate;
		}
		if (NarrationBig == null)
		{
			Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[13].Value = NarrationBig;
		}
		if (Contact == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = Contact;
		}
		if (Address == null)
		{
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[15].Value = Address;
		}
		if (Payee == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = Payee;
		}
		Adapter.UpdateCommand.Parameters[17].Value = Original_Expenseid;
		if (Original_ExpenseName == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = 1;
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = 0;
			Adapter.UpdateCommand.Parameters[19].Value = Original_ExpenseName;
		}
		if (Original_expenseSource == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = 1;
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = 0;
			Adapter.UpdateCommand.Parameters[21].Value = Original_expenseSource;
		}
		if (Original_qty.HasValue)
		{
			Adapter.UpdateCommand.Parameters[22].Value = 0;
			Adapter.UpdateCommand.Parameters[23].Value = Original_qty.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = 1;
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		if (Original_units == null)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_units;
		}
		if (Original_PaymentMode == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_PaymentMode;
		}
		if (Original_ChequeNo == null)
		{
			Adapter.UpdateCommand.Parameters[28].Value = 1;
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = 0;
			Adapter.UpdateCommand.Parameters[29].Value = Original_ChequeNo;
		}
		if (Original_VoucherNo == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = 1;
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = 0;
			Adapter.UpdateCommand.Parameters[31].Value = Original_VoucherNo;
		}
		if (Original_ExpenseValue.HasValue)
		{
			Adapter.UpdateCommand.Parameters[32].Value = 0;
			Adapter.UpdateCommand.Parameters[33].Value = Original_ExpenseValue.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = 1;
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		if (Original_DateOfExpense.HasValue)
		{
			Adapter.UpdateCommand.Parameters[34].Value = 0;
			Adapter.UpdateCommand.Parameters[35].Value = Original_DateOfExpense.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = 1;
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		if (Original_SemesterId == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = 1;
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = 0;
			Adapter.UpdateCommand.Parameters[37].Value = Original_SemesterId;
		}
		if (Original_Narration == null)
		{
			Adapter.UpdateCommand.Parameters[38].Value = 1;
			Adapter.UpdateCommand.Parameters[39].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[38].Value = 0;
			Adapter.UpdateCommand.Parameters[39].Value = Original_Narration;
		}
		if (Original_Debitor == null)
		{
			Adapter.UpdateCommand.Parameters[40].Value = 1;
			Adapter.UpdateCommand.Parameters[41].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[40].Value = 0;
			Adapter.UpdateCommand.Parameters[41].Value = Original_Debitor;
		}
		if (Original_CaptureDate == null)
		{
			Adapter.UpdateCommand.Parameters[42].Value = 1;
			Adapter.UpdateCommand.Parameters[43].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[42].Value = 0;
			Adapter.UpdateCommand.Parameters[43].Value = Original_CaptureDate;
		}
		if (Original_NarrationBig == null)
		{
			Adapter.UpdateCommand.Parameters[44].Value = 1;
			Adapter.UpdateCommand.Parameters[45].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[44].Value = 0;
			Adapter.UpdateCommand.Parameters[45].Value = Original_NarrationBig;
		}
		if (Original_Contact == null)
		{
			Adapter.UpdateCommand.Parameters[46].Value = 1;
			Adapter.UpdateCommand.Parameters[47].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[46].Value = 0;
			Adapter.UpdateCommand.Parameters[47].Value = Original_Contact;
		}
		if (Original_Address == null)
		{
			Adapter.UpdateCommand.Parameters[48].Value = 1;
			Adapter.UpdateCommand.Parameters[49].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[48].Value = 0;
			Adapter.UpdateCommand.Parameters[49].Value = Original_Address;
		}
		if (Original_Payee == null)
		{
			Adapter.UpdateCommand.Parameters[50].Value = 1;
			Adapter.UpdateCommand.Parameters[51].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[50].Value = 0;
			Adapter.UpdateCommand.Parameters[51].Value = Original_Payee;
		}
		Adapter.UpdateCommand.Parameters[52].Value = Expenseid;
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
	public virtual int Update(string ExpenseName, string expenseSource, int? qty, string units, string PaymentMode, string ChequeNo, string VoucherNo, decimal? ExpenseValue, DateTime? DateOfExpense, string SemesterId, string Narration, string Debitor, string CaptureDate, string NarrationBig, string Contact, string Address, string Payee, long Original_Expenseid, string Original_ExpenseName, string Original_expenseSource, int? Original_qty, string Original_units, string Original_PaymentMode, string Original_ChequeNo, string Original_VoucherNo, decimal? Original_ExpenseValue, DateTime? Original_DateOfExpense, string Original_SemesterId, string Original_Narration, string Original_Debitor, string Original_CaptureDate, string Original_NarrationBig, string Original_Contact, string Original_Address, string Original_Payee)
	{
		return Update(ExpenseName, expenseSource, qty, units, PaymentMode, ChequeNo, VoucherNo, ExpenseValue, DateOfExpense, SemesterId, Narration, Debitor, CaptureDate, NarrationBig, Contact, Address, Payee, Original_Expenseid, Original_ExpenseName, Original_expenseSource, Original_qty, Original_units, Original_PaymentMode, Original_ChequeNo, Original_VoucherNo, Original_ExpenseValue, Original_DateOfExpense, Original_SemesterId, Original_Narration, Original_Debitor, Original_CaptureDate, Original_NarrationBig, Original_Contact, Original_Address, Original_Payee, Original_Expenseid);
	}
}
