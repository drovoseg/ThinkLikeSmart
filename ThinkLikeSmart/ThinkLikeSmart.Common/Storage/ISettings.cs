using Tls.ThinkLikeSmart.Common.Presenters.Authentication;

namespace Tls.ThinkLikeSmart.Common.Storage
{
    public interface ISettings
    {
        string CurrentCountry { get; }

        string CurrentLanguage { get; }

        LoginType RecentLoginType { get; set; }

        ushort RecentCountryPhoneCode { get; set; }

        string RecentAccountName { get; set; }

        string RecentPassword { get; set; }

        bool NeedToRememberRecentPassword { get; set; }
    }
}
