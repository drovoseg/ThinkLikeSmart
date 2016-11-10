using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.iOS.Storage
{
    class IosSettings : ISettings
    {
        public LoginType RecentLoginType { get; set; }

        public ushort RecentCountryPhoneCode { get; set; }

        public string RecentAccountName { get; set; }

        public string RecentPassword { get; set; }

        public bool NeedToRememberRecentPassword { get; set; }

        public IosSettings()
        {
            RecentLoginType = LoginType.Phone;
            RecentCountryPhoneCode = 7;
            RecentAccountName = "yevgeny.sotnikov@gmail.com";
            RecentPassword = "drovoseg";
            //NeedToRememberRecentPassword = true;
        }
    }
}
