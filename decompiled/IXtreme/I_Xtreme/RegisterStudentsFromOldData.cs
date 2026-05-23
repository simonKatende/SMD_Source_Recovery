using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class RegisterStudentsFromOldData : XtraForm
{
	private int i;

	private int k = 0;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private string _Class = string.Empty;

	private string _Stream = string.Empty;

	private string _SemesterId = string.Empty;

	private string connectionString = string.Empty;

	private string _PrevTerm = string.Empty;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker bgRegisterStudents;

	private ProgressBarControl progressBarControl1;

	public RegisterStudentsFromOldData(string _Class, string _Stream, string _PrevTerm, string _CurrTerm)
	{
		InitializeComponent();
		this._Class = _Class;
		_SemesterId = _CurrTerm;
		this._Stream = _Stream;
		this._PrevTerm = _PrevTerm;
	}

	private void RegisterStudents_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			timer1.Enabled = false;
			bgRegisterStudents.RunWorkerAsync();
		}
	}

	private void bgRegisterStudents_DoWork(object sender, DoWorkEventArgs e)
	{
		RegisterAllOLevel();
	}

	private void bgRegisterStudents_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Dispose();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void RegisterStudents_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bgRegisterStudents.IsBusy)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to cancel the current process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				bgRegisterStudents.CancelAsync();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
		}
	}

	private string FirstWords(string input, int numberWords)
	{
		try
		{
			int num = numberWords;
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == ' ')
				{
					num--;
				}
				if (num == 0)
				{
					return input.Substring(0, i);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return string.Empty;
	}

	private int UnitsUsed(string _subject, string _class, string _term)
	{
		int result = 1;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNC WHERE ClassId='{_class}' AND SemesterId='{_term}' AND SubjectId='{_subject}'", connectionString);
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			result = Convert.ToInt32(dataTable.Rows[0]["TUnits"].ToString());
		}
		return result;
	}

	private void RegisterAllOLevel()
	{
		try
		{
			connectionString = DataConnection.ConnectToDatabase();
			k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string empty = string.Empty;
			string empty2 = string.Empty;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE Status='Active' AND ClassId='{_Class}' AND StreamId='{_Stream}'", connectionString);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				empty2 = row["StudentNumber"].ToString();
				k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(k);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT StudentNumber, SubjectId, SemesterId FROM tbl_Scores_OL_Report WHERE StudentNumber = '{empty2}' AND SemesterId = '{_PrevTerm}'", connectionString);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				foreach (DataRow row2 in dataTable2.Rows)
				{
					empty = row2["SubjectId"].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNC WHERE SemesterId='{_SemesterId}' AND ClassId='{_Class}' AND SubjectId='{empty}'", connectionString);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					if (dataTable3.Rows.Count == 0)
					{
						using SqlConnection sqlConnection = new SqlConnection(connectionString);
						sqlConnection.Open();
						using SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = "INSERT INTO tbl_TermSettingsNC (ClassId,SemesterId,TUnits,IsAssessed,SubjectId) VALUES (@ClassId,@SemesterId,1,'1',@SubjectId)",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _SemesterId);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", row2["SubjectId"]);
						sqlParameter.Direction = ParameterDirection.Input;
						if (sqlCommand.ExecuteNonQuery() > 0)
						{
							sqlConnection.Close();
						}
					}
					SqlConnection sqlConnection2 = new SqlConnection(connectionString);
					sqlConnection2.Open();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "SELECT * FROM tbl_Scores_OL_Report WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
						CommandType = CommandType.Text
					})
					{
						sqlCommand2.Parameters.AddWithValue("@StudentNumber", empty2);
						sqlCommand2.Parameters.AddWithValue("@SemesterId", _SemesterId);
						sqlCommand2.Parameters.AddWithValue("@SubjectId", empty);
						sqlCommand2.Parameters.AddWithValue("@ClassId", _Class);
						SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							sqlDataReader.Close();
							sqlConnection2.Close();
							return;
						}
						sqlConnection2.Close();
					}
					sqlConnection2.Open();
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_Scores_OL_Report (StudentNumber,SemesterId,SubjectId,ClassId,TUnits,IsAssessed, U1,U2,U3,U4,U5,U6,U7,U8,U9,U10,Score1,Score2,Score3,Score4,Score5,Score6,Score7,Score8,Score9,Score10,Hund1,Hund2,Hund3,Hund4,Hund5,Hund6,Hund7,Hund8,Hund9,Hund10) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId,@TUnits,@IsAssessed, @U1,@U2,@U3,@U4,@U5,@U6,@U7,@U8,@U9,@U10,@Score1,@Score2,@Score3,@Score4,@Score5,@Score6,@Score7,@Score8,@Score9,@Score10,@Hund1,@Hund2,@Hund3,@Hund4,@Hund5,@Hund6,@Hund7,@Hund8,@Hund9,@Hund10)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = empty2;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter2.Value = _SemesterId;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = empty;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter2.Value = _Class;
						sqlParameter2.Direction = ParameterDirection.Input;
						if (UnitsUsed(empty, _Class, _SemesterId) == 1)
						{
							sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
							sqlParameter2.Value = 1;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score5", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score6", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score7", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score8", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score9", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score10", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
						}
						else if (UnitsUsed(empty, _Class, _SemesterId) == 2)
						{
							sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
							sqlParameter2.Value = 2;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score5", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score6", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score7", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score8", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score9", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score10", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
						}
						else if (UnitsUsed(empty, _Class, _SemesterId) == 3)
						{
							sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
							sqlParameter2.Value = 3;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score5", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score6", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score7", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score8", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score9", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score10", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
						}
						else if (UnitsUsed(empty, _Class, _SemesterId) == 4)
						{
							sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
							sqlParameter2.Value = 4;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@U10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score5", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score6", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score7", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score8", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score9", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Score10", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund5", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund6", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund7", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund8", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund9", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Hund10", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "x";
							sqlParameter2.Direction = ParameterDirection.Input;
						}
						sqlParameter2 = sqlCommand3.Parameters.Add("@IsAssessed", SqlDbType.Bit);
						sqlParameter2.Value = 1;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					sqlConnection2.Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void bgRegisterStudents_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum;
		Text = currentTask;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void RegisterStudents_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.timer1 = new System.Windows.Forms.Timer();
		this.bgRegisterStudents = new System.ComponentModel.BackgroundWorker();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.bgRegisterStudents.WorkerReportsProgress = true;
		this.bgRegisterStudents.WorkerSupportsCancellation = true;
		this.bgRegisterStudents.DoWork += new System.ComponentModel.DoWorkEventHandler(bgRegisterStudents_DoWork);
		this.bgRegisterStudents.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgRegisterStudents_ProgressChanged);
		this.bgRegisterStudents.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgRegisterStudents_RunWorkerCompleted);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(418, 44);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(418, 44);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "RegisterStudentsNewCur";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Registering students...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RegisterStudents_FormClosing);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(RegisterStudents_FormClosed);
		base.Load += new System.EventHandler(RegisterStudents_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
