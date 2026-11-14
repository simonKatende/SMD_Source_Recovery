using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

// The application-side constructor: kept apart from the rest of the service so the service
// itself depends only on a connection string and can be tested against a throwaway database.
public partial class FeesFollowUpService
{
    public FeesFollowUpService() : this(DataConnection.ConnectToDatabase())
    {
        SendSms = (string phone, string message, out string error)
            => FeeSmsHelper.TrySend(connectionString, phone, message, out error);
        DecryptSchoolName = AlienAge.Security.CryptorEngine.Decrypt;
    }
}
