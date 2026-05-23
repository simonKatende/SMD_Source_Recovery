using System;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

internal class Stream
{
	public static void LoadStreams(string studentClass, ComboBoxEdit _cboStream)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * from Streams WHERE ClassId='{studentClass}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Streams");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				_cboStream.Properties.Items.Clear();
				_cboStream.Properties.Items.Add("-");
				_cboStream.SelectedIndex = 0;
				return;
			}
			_cboStream.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				_cboStream.Properties.Items.Add(row["StreamId"]);
			}
			_cboStream.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public static void LoadParameterStreams(ComboBoxEdit _cboClass, ComboBoxEdit _cboStream)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * from Streams WHERE ClassId='{_cboClass.SelectedItem}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Streams");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				_cboStream.Properties.Items.Clear();
				_cboStream.Properties.Items.Add("-");
				return;
			}
			_cboStream.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				_cboStream.Properties.Items.Add(row["StreamId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}
}
