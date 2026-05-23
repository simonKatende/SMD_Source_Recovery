using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace I_Xtreme.dSet_SchoolDetails_SmallTableAdapters;

[DesignerCategory("code")]
[ToolboxItem(true)]
[DataObject(true)]
[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[HelpKeyword("vs.data.TableAdapter")]
public class SchoolDetailsAdapter : Component
{
	private SqlDataAdapter _adapter;

	private SqlConnection _connection;

	private SqlCommand[] _commandCollection;

	private bool _clearBeforeFill;

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private SqlDataAdapter Adapter
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
	public SchoolDetailsAdapter()
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
		dataTableMapping.DataSetTable = "SchoolDetails";
		dataTableMapping.ColumnMappings.Add("DetailId", "DetailId");
		dataTableMapping.ColumnMappings.Add("SchoolName", "SchoolName");
		dataTableMapping.ColumnMappings.Add("schoolMotto", "schoolMotto");
		dataTableMapping.ColumnMappings.Add("boxNumber", "boxNumber");
		dataTableMapping.ColumnMappings.Add("location", "location");
		dataTableMapping.ColumnMappings.Add("mobileContact", "mobileContact");
		dataTableMapping.ColumnMappings.Add("officeContact", "officeContact");
		dataTableMapping.ColumnMappings.Add("emailAddress", "emailAddress");
		dataTableMapping.ColumnMappings.Add("webAddress", "webAddress");
		dataTableMapping.ColumnMappings.Add("netAddress", "netAddress");
		dataTableMapping.ColumnMappings.Add("fullContact", "fullContact");
		dataTableMapping.ColumnMappings.Add("logo", "logo");
		dataTableMapping.ColumnMappings.Add("district", "district");
		dataTableMapping.ColumnMappings.Add("ShortName", "ShortName");
		_adapter.TableMappings.Add(dataTableMapping);
		_adapter.DeleteCommand = new SqlCommand();
		_adapter.DeleteCommand.Connection = Connection;
		_adapter.DeleteCommand.CommandText = "DELETE FROM [SchoolDetails] WHERE (([DetailId] = @Original_DetailId) AND ((@IsNull_SchoolName = 1 AND [SchoolName] IS NULL) OR ([SchoolName] = @Original_SchoolName)) AND ((@IsNull_schoolMotto = 1 AND [schoolMotto] IS NULL) OR ([schoolMotto] = @Original_schoolMotto)) AND ((@IsNull_boxNumber = 1 AND [boxNumber] IS NULL) OR ([boxNumber] = @Original_boxNumber)) AND ((@IsNull_location = 1 AND [location] IS NULL) OR ([location] = @Original_location)) AND ((@IsNull_mobileContact = 1 AND [mobileContact] IS NULL) OR ([mobileContact] = @Original_mobileContact)) AND ((@IsNull_officeContact = 1 AND [officeContact] IS NULL) OR ([officeContact] = @Original_officeContact)) AND ((@IsNull_emailAddress = 1 AND [emailAddress] IS NULL) OR ([emailAddress] = @Original_emailAddress)) AND ((@IsNull_webAddress = 1 AND [webAddress] IS NULL) OR ([webAddress] = @Original_webAddress)) AND ((@IsNull_netAddress = 1 AND [netAddress] IS NULL) OR ([netAddress] = @Original_netAddress)) AND ((@IsNull_fullContact = 1 AND [fullContact] IS NULL) OR ([fullContact] = @Original_fullContact)) AND ((@IsNull_district = 1 AND [district] IS NULL) OR ([district] = @Original_district)) AND ((@IsNull_ShortName = 1 AND [ShortName] IS NULL) OR ([ShortName] = @Original_ShortName)))";
		_adapter.DeleteCommand.CommandType = CommandType.Text;
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_DetailId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DetailId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_SchoolName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SchoolName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_SchoolName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SchoolName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_schoolMotto", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "schoolMotto", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_schoolMotto", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "schoolMotto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_boxNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "boxNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_boxNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "boxNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_location", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "location", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_location", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "location", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_mobileContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mobileContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_mobileContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mobileContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_officeContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "officeContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_officeContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "officeContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_emailAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "emailAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_emailAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "emailAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_webAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "webAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_webAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "webAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_netAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "netAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_netAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "netAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_fullContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_fullContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_district", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "district", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_district", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "district", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@IsNull_ShortName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ShortName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_ShortName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShortName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand = new SqlCommand();
		_adapter.InsertCommand.Connection = Connection;
		_adapter.InsertCommand.CommandText = "INSERT INTO [SchoolDetails] ([SchoolName], [schoolMotto], [boxNumber], [location], [mobileContact], [officeContact], [emailAddress], [webAddress], [netAddress], [fullContact], [logo], [district], [ShortName]) VALUES (@SchoolName, @schoolMotto, @boxNumber, @location, @mobileContact, @officeContact, @emailAddress, @webAddress, @netAddress, @fullContact, @logo, @district, @ShortName);\r\nSELECT DetailId, SchoolName, schoolMotto, boxNumber, location, mobileContact, officeContact, emailAddress, webAddress, netAddress, fullContact, logo, district, ShortName FROM SchoolDetails WHERE (DetailId = SCOPE_IDENTITY())";
		_adapter.InsertCommand.CommandType = CommandType.Text;
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@SchoolName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SchoolName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@schoolMotto", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "schoolMotto", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@boxNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "boxNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "location", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@mobileContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mobileContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@officeContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "officeContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@emailAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "emailAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@webAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "webAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@netAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "netAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@fullContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@logo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "logo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "district", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.InsertCommand.Parameters.Add(new SqlParameter("@ShortName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShortName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand = new SqlCommand();
		_adapter.UpdateCommand.Connection = Connection;
		_adapter.UpdateCommand.CommandText = "UPDATE [SchoolDetails] SET [SchoolName] = @SchoolName, [schoolMotto] = @schoolMotto, [boxNumber] = @boxNumber, [location] = @location, [mobileContact] = @mobileContact, [officeContact] = @officeContact, [emailAddress] = @emailAddress, [webAddress] = @webAddress, [netAddress] = @netAddress, [fullContact] = @fullContact, [logo] = @logo, [district] = @district, [ShortName] = @ShortName WHERE (([DetailId] = @Original_DetailId) AND ((@IsNull_SchoolName = 1 AND [SchoolName] IS NULL) OR ([SchoolName] = @Original_SchoolName)) AND ((@IsNull_schoolMotto = 1 AND [schoolMotto] IS NULL) OR ([schoolMotto] = @Original_schoolMotto)) AND ((@IsNull_boxNumber = 1 AND [boxNumber] IS NULL) OR ([boxNumber] = @Original_boxNumber)) AND ((@IsNull_location = 1 AND [location] IS NULL) OR ([location] = @Original_location)) AND ((@IsNull_mobileContact = 1 AND [mobileContact] IS NULL) OR ([mobileContact] = @Original_mobileContact)) AND ((@IsNull_officeContact = 1 AND [officeContact] IS NULL) OR ([officeContact] = @Original_officeContact)) AND ((@IsNull_emailAddress = 1 AND [emailAddress] IS NULL) OR ([emailAddress] = @Original_emailAddress)) AND ((@IsNull_webAddress = 1 AND [webAddress] IS NULL) OR ([webAddress] = @Original_webAddress)) AND ((@IsNull_netAddress = 1 AND [netAddress] IS NULL) OR ([netAddress] = @Original_netAddress)) AND ((@IsNull_fullContact = 1 AND [fullContact] IS NULL) OR ([fullContact] = @Original_fullContact)) AND ((@IsNull_district = 1 AND [district] IS NULL) OR ([district] = @Original_district)) AND ((@IsNull_ShortName = 1 AND [ShortName] IS NULL) OR ([ShortName] = @Original_ShortName)));\r\nSELECT DetailId, SchoolName, schoolMotto, boxNumber, location, mobileContact, officeContact, emailAddress, webAddress, netAddress, fullContact, logo, district, ShortName FROM SchoolDetails WHERE (DetailId = @DetailId)";
		_adapter.UpdateCommand.CommandType = CommandType.Text;
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SchoolName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SchoolName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@schoolMotto", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "schoolMotto", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@boxNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "boxNumber", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "location", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mobileContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mobileContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@officeContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "officeContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@emailAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "emailAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@webAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "webAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@netAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "netAddress", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@fullContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullContact", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@logo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "logo", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@district", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "district", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ShortName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShortName", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_DetailId", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DetailId", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_SchoolName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SchoolName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_SchoolName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "SchoolName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_schoolMotto", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "schoolMotto", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_schoolMotto", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "schoolMotto", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_boxNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "boxNumber", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_boxNumber", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "boxNumber", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_location", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "location", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_location", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "location", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_mobileContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mobileContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_mobileContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "mobileContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_officeContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "officeContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_officeContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "officeContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_emailAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "emailAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_emailAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "emailAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_webAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "webAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_webAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "webAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_netAddress", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "netAddress", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_netAddress", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "netAddress", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_fullContact", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "fullContact", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_fullContact", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "fullContact", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_district", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "district", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_district", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "district", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IsNull_ShortName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ShortName", DataRowVersion.Original, sourceColumnNullMapping: true, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_ShortName", SqlDbType.VarChar, 0, ParameterDirection.Input, 0, 0, "ShortName", DataRowVersion.Original, sourceColumnNullMapping: false, null, "", "", ""));
		_adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DetailId", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "DetailId", DataRowVersion.Current, sourceColumnNullMapping: false, null, "", "", ""));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitConnection()
	{
		_connection = new SqlConnection();
		_connection.ConnectionString = "Data Source=INTELLIGENT\\SQLEXPRESS;Initial Catalog=IntelligentSRMS;Persist Security Info=True;User ID=sa;Password=spiderwick";
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	private void InitCommandCollection()
	{
		_commandCollection = new SqlCommand[1];
		_commandCollection[0] = new SqlCommand();
		_commandCollection[0].Connection = Connection;
		_commandCollection[0].CommandText = "SELECT DetailId, SchoolName, schoolMotto, boxNumber, location, mobileContact, officeContact, emailAddress, webAddress, netAddress, fullContact, logo, district, ShortName FROM SchoolDetails";
		_commandCollection[0].CommandType = CommandType.Text;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	[DataObjectMethod(DataObjectMethodType.Fill, true)]
	public virtual int Fill(dSet_SchoolDetails_Small.SchoolDetailsDataTable dataTable)
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
	public virtual dSet_SchoolDetails_Small.SchoolDetailsDataTable GetData()
	{
		Adapter.SelectCommand = CommandCollection[0];
		dSet_SchoolDetails_Small.SchoolDetailsDataTable schoolDetailsDataTable = new dSet_SchoolDetails_Small.SchoolDetailsDataTable();
		Adapter.Fill(schoolDetailsDataTable);
		return schoolDetailsDataTable;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dSet_SchoolDetails_Small.SchoolDetailsDataTable dataTable)
	{
		return Adapter.Update(dataTable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")]
	[HelpKeyword("vs.data.TableAdapter")]
	public virtual int Update(dSet_SchoolDetails_Small dataSet)
	{
		return Adapter.Update(dataSet, "SchoolDetails");
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
	public virtual int Delete(int Original_DetailId, string Original_SchoolName, string Original_schoolMotto, string Original_boxNumber, string Original_location, string Original_mobileContact, string Original_officeContact, string Original_emailAddress, string Original_webAddress, string Original_netAddress, string Original_fullContact, string Original_district, string Original_ShortName)
	{
		Adapter.DeleteCommand.Parameters[0].Value = Original_DetailId;
		if (Original_SchoolName == null)
		{
			Adapter.DeleteCommand.Parameters[1].Value = 1;
			Adapter.DeleteCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[1].Value = 0;
			Adapter.DeleteCommand.Parameters[2].Value = Original_SchoolName;
		}
		if (Original_schoolMotto == null)
		{
			Adapter.DeleteCommand.Parameters[3].Value = 1;
			Adapter.DeleteCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[3].Value = 0;
			Adapter.DeleteCommand.Parameters[4].Value = Original_schoolMotto;
		}
		if (Original_boxNumber == null)
		{
			Adapter.DeleteCommand.Parameters[5].Value = 1;
			Adapter.DeleteCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[5].Value = 0;
			Adapter.DeleteCommand.Parameters[6].Value = Original_boxNumber;
		}
		if (Original_location == null)
		{
			Adapter.DeleteCommand.Parameters[7].Value = 1;
			Adapter.DeleteCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[7].Value = 0;
			Adapter.DeleteCommand.Parameters[8].Value = Original_location;
		}
		if (Original_mobileContact == null)
		{
			Adapter.DeleteCommand.Parameters[9].Value = 1;
			Adapter.DeleteCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[9].Value = 0;
			Adapter.DeleteCommand.Parameters[10].Value = Original_mobileContact;
		}
		if (Original_officeContact == null)
		{
			Adapter.DeleteCommand.Parameters[11].Value = 1;
			Adapter.DeleteCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[11].Value = 0;
			Adapter.DeleteCommand.Parameters[12].Value = Original_officeContact;
		}
		if (Original_emailAddress == null)
		{
			Adapter.DeleteCommand.Parameters[13].Value = 1;
			Adapter.DeleteCommand.Parameters[14].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[13].Value = 0;
			Adapter.DeleteCommand.Parameters[14].Value = Original_emailAddress;
		}
		if (Original_webAddress == null)
		{
			Adapter.DeleteCommand.Parameters[15].Value = 1;
			Adapter.DeleteCommand.Parameters[16].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[15].Value = 0;
			Adapter.DeleteCommand.Parameters[16].Value = Original_webAddress;
		}
		if (Original_netAddress == null)
		{
			Adapter.DeleteCommand.Parameters[17].Value = 1;
			Adapter.DeleteCommand.Parameters[18].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[17].Value = 0;
			Adapter.DeleteCommand.Parameters[18].Value = Original_netAddress;
		}
		if (Original_fullContact == null)
		{
			Adapter.DeleteCommand.Parameters[19].Value = 1;
			Adapter.DeleteCommand.Parameters[20].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[19].Value = 0;
			Adapter.DeleteCommand.Parameters[20].Value = Original_fullContact;
		}
		if (Original_district == null)
		{
			Adapter.DeleteCommand.Parameters[21].Value = 1;
			Adapter.DeleteCommand.Parameters[22].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[21].Value = 0;
			Adapter.DeleteCommand.Parameters[22].Value = Original_district;
		}
		if (Original_ShortName == null)
		{
			Adapter.DeleteCommand.Parameters[23].Value = 1;
			Adapter.DeleteCommand.Parameters[24].Value = DBNull.Value;
		}
		else
		{
			Adapter.DeleteCommand.Parameters[23].Value = 0;
			Adapter.DeleteCommand.Parameters[24].Value = Original_ShortName;
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
	public virtual int Insert(string SchoolName, string schoolMotto, string boxNumber, string location, string mobileContact, string officeContact, string emailAddress, string webAddress, string netAddress, string fullContact, byte[] logo, string district, string ShortName)
	{
		if (SchoolName == null)
		{
			Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[0].Value = SchoolName;
		}
		if (schoolMotto == null)
		{
			Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[1].Value = schoolMotto;
		}
		if (boxNumber == null)
		{
			Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[2].Value = boxNumber;
		}
		if (location == null)
		{
			Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[3].Value = location;
		}
		if (mobileContact == null)
		{
			Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[4].Value = mobileContact;
		}
		if (officeContact == null)
		{
			Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[5].Value = officeContact;
		}
		if (emailAddress == null)
		{
			Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[6].Value = emailAddress;
		}
		if (webAddress == null)
		{
			Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[7].Value = webAddress;
		}
		if (netAddress == null)
		{
			Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[8].Value = netAddress;
		}
		if (fullContact == null)
		{
			Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[9].Value = fullContact;
		}
		if (logo == null)
		{
			Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[10].Value = logo;
		}
		if (district == null)
		{
			Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[11].Value = district;
		}
		if (ShortName == null)
		{
			Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.InsertCommand.Parameters[12].Value = ShortName;
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
	public virtual int Update(string SchoolName, string schoolMotto, string boxNumber, string location, string mobileContact, string officeContact, string emailAddress, string webAddress, string netAddress, string fullContact, byte[] logo, string district, string ShortName, int Original_DetailId, string Original_SchoolName, string Original_schoolMotto, string Original_boxNumber, string Original_location, string Original_mobileContact, string Original_officeContact, string Original_emailAddress, string Original_webAddress, string Original_netAddress, string Original_fullContact, string Original_district, string Original_ShortName, int DetailId)
	{
		if (SchoolName == null)
		{
			Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[0].Value = SchoolName;
		}
		if (schoolMotto == null)
		{
			Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[1].Value = schoolMotto;
		}
		if (boxNumber == null)
		{
			Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[2].Value = boxNumber;
		}
		if (location == null)
		{
			Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[3].Value = location;
		}
		if (mobileContact == null)
		{
			Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[4].Value = mobileContact;
		}
		if (officeContact == null)
		{
			Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[5].Value = officeContact;
		}
		if (emailAddress == null)
		{
			Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[6].Value = emailAddress;
		}
		if (webAddress == null)
		{
			Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[7].Value = webAddress;
		}
		if (netAddress == null)
		{
			Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[8].Value = netAddress;
		}
		if (fullContact == null)
		{
			Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[9].Value = fullContact;
		}
		if (logo == null)
		{
			Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[10].Value = logo;
		}
		if (district == null)
		{
			Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[11].Value = district;
		}
		if (ShortName == null)
		{
			Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[12].Value = ShortName;
		}
		Adapter.UpdateCommand.Parameters[13].Value = Original_DetailId;
		if (Original_SchoolName == null)
		{
			Adapter.UpdateCommand.Parameters[14].Value = 1;
			Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[14].Value = 0;
			Adapter.UpdateCommand.Parameters[15].Value = Original_SchoolName;
		}
		if (Original_schoolMotto == null)
		{
			Adapter.UpdateCommand.Parameters[16].Value = 1;
			Adapter.UpdateCommand.Parameters[17].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[16].Value = 0;
			Adapter.UpdateCommand.Parameters[17].Value = Original_schoolMotto;
		}
		if (Original_boxNumber == null)
		{
			Adapter.UpdateCommand.Parameters[18].Value = 1;
			Adapter.UpdateCommand.Parameters[19].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[18].Value = 0;
			Adapter.UpdateCommand.Parameters[19].Value = Original_boxNumber;
		}
		if (Original_location == null)
		{
			Adapter.UpdateCommand.Parameters[20].Value = 1;
			Adapter.UpdateCommand.Parameters[21].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[20].Value = 0;
			Adapter.UpdateCommand.Parameters[21].Value = Original_location;
		}
		if (Original_mobileContact == null)
		{
			Adapter.UpdateCommand.Parameters[22].Value = 1;
			Adapter.UpdateCommand.Parameters[23].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[22].Value = 0;
			Adapter.UpdateCommand.Parameters[23].Value = Original_mobileContact;
		}
		if (Original_officeContact == null)
		{
			Adapter.UpdateCommand.Parameters[24].Value = 1;
			Adapter.UpdateCommand.Parameters[25].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[24].Value = 0;
			Adapter.UpdateCommand.Parameters[25].Value = Original_officeContact;
		}
		if (Original_emailAddress == null)
		{
			Adapter.UpdateCommand.Parameters[26].Value = 1;
			Adapter.UpdateCommand.Parameters[27].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[26].Value = 0;
			Adapter.UpdateCommand.Parameters[27].Value = Original_emailAddress;
		}
		if (Original_webAddress == null)
		{
			Adapter.UpdateCommand.Parameters[28].Value = 1;
			Adapter.UpdateCommand.Parameters[29].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[28].Value = 0;
			Adapter.UpdateCommand.Parameters[29].Value = Original_webAddress;
		}
		if (Original_netAddress == null)
		{
			Adapter.UpdateCommand.Parameters[30].Value = 1;
			Adapter.UpdateCommand.Parameters[31].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[30].Value = 0;
			Adapter.UpdateCommand.Parameters[31].Value = Original_netAddress;
		}
		if (Original_fullContact == null)
		{
			Adapter.UpdateCommand.Parameters[32].Value = 1;
			Adapter.UpdateCommand.Parameters[33].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[32].Value = 0;
			Adapter.UpdateCommand.Parameters[33].Value = Original_fullContact;
		}
		if (Original_district == null)
		{
			Adapter.UpdateCommand.Parameters[34].Value = 1;
			Adapter.UpdateCommand.Parameters[35].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[34].Value = 0;
			Adapter.UpdateCommand.Parameters[35].Value = Original_district;
		}
		if (Original_ShortName == null)
		{
			Adapter.UpdateCommand.Parameters[36].Value = 1;
			Adapter.UpdateCommand.Parameters[37].Value = DBNull.Value;
		}
		else
		{
			Adapter.UpdateCommand.Parameters[36].Value = 0;
			Adapter.UpdateCommand.Parameters[37].Value = Original_ShortName;
		}
		Adapter.UpdateCommand.Parameters[38].Value = DetailId;
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
	public virtual int Update(string SchoolName, string schoolMotto, string boxNumber, string location, string mobileContact, string officeContact, string emailAddress, string webAddress, string netAddress, string fullContact, byte[] logo, string district, string ShortName, int Original_DetailId, string Original_SchoolName, string Original_schoolMotto, string Original_boxNumber, string Original_location, string Original_mobileContact, string Original_officeContact, string Original_emailAddress, string Original_webAddress, string Original_netAddress, string Original_fullContact, string Original_district, string Original_ShortName)
	{
		return Update(SchoolName, schoolMotto, boxNumber, location, mobileContact, officeContact, emailAddress, webAddress, netAddress, fullContact, logo, district, ShortName, Original_DetailId, Original_SchoolName, Original_schoolMotto, Original_boxNumber, Original_location, Original_mobileContact, Original_officeContact, Original_emailAddress, Original_webAddress, Original_netAddress, Original_fullContact, Original_district, Original_ShortName, Original_DetailId);
	}
}
