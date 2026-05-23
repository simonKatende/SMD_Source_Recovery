using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ExtremeMessenger.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("ExtremeMessenger.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap close
	{
		get
		{
			object @object = ResourceManager.GetObject("close", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap connected
	{
		get
		{
			object @object = ResourceManager.GetObject("connected", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Icon EM
	{
		get
		{
			object @object = ResourceManager.GetObject("EM", resourceCulture);
			return (Icon)@object;
		}
	}

	internal static Bitmap greenStateIcon
	{
		get
		{
			object @object = ResourceManager.GetObject("greenStateIcon", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap lostCon
	{
		get
		{
			object @object = ResourceManager.GetObject("lostCon", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap min
	{
		get
		{
			object @object = ResourceManager.GetObject("min", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap notConnectedStateIcon
	{
		get
		{
			object @object = ResourceManager.GetObject("notConnectedStateIcon", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal Resources()
	{
	}
}
