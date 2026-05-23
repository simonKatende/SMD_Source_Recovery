using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace I_Xtreme.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.13.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

	public static Settings Default => defaultInstance;

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=DESKTOP-8785BH1;Initial Catalog=iXtremeDB;Persist Security Info=True;User ID=sa;Password=spider4544;TrustServerCertificate=True")]
	public string iXtremeDBConnectionString => (string)this["iXtremeDBConnectionString"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=.;Initial Catalog=iXtremeDBK;Persist Security Info=True;User ID=sa;Password=spider4544;TrustServerCertificate=True")]
	public string iXtremeDBKConnectionString => (string)this["iXtremeDBKConnectionString"];

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.ConnectionString)]
	[DefaultSettingValue("Data Source=.;Initial Catalog=iXtremeDB24;Persist Security Info=True;User ID=sa;Password=spider4544;TrustServerCertificate=True")]
	public string iXtremeDB24ConnectionString => (string)this["iXtremeDB24ConnectionString"];
}
