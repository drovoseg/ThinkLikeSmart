using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.Droid.Storage
{
    class AndroidSettings : ISettings
    {
        public LoginType RecentLoginType { get; set; }

        public string RecentCountryPhoneCode { get; set; }

        public string RecentAccountName { get; set; }

        public string RecentPassword { get; set; }

        public bool NeedToRememberRecentPassword { get; set; }

        public AndroidSettings()
        {
            RecentLoginType = LoginType.Phone;
            RecentCountryPhoneCode = "380";
            RecentAccountName = "yevgeny.sotnikov@gmail.com";
            RecentPassword = "drovoseg";
            //NeedToRememberRecentPassword = true;
        }
    }
}