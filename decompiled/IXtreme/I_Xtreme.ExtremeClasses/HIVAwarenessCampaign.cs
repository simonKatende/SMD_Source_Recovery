using System.Drawing;

namespace I_Xtreme.ExtremeClasses;

internal class HIVAwarenessCampaign
{
	private static bool ShowHIVAwarenessMessage => false;

	private static Image HIVAwarenessLogo => null;

	private static string HIVAwarenessMessage => string.Empty;

	public static void SetAwarenessMessage(Image SponsorLogo, string AwarenessMessage, bool ShowMessage)
	{
	}
}
