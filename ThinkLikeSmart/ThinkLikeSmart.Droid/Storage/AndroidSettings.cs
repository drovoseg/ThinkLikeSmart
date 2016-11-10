using Android.App;
using Java.Util;
using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.Droid.Storage
{
    class AndroidSettings : ISettings
    {
        public string CurrentLanguage
        {
            get { return CurrentLocale.Language; }
        }

        public string CurrentCountry
        {
            get { return CurrentLocale.Country; }
        }

        public LoginType RecentLoginType { get; set; }

        public ushort RecentCountryPhoneCode { get; set; }

        public string RecentAccountName { get; set; }

        public string RecentPassword { get; set; }

        public bool NeedToRememberRecentPassword { get; set; }

        private Locale CurrentLocale
        {
            get { return Application.Context.Resources.Configuration.Locale; }
        }

        public AndroidSettings()
        {
            RecentLoginType = LoginType.Phone;
            RecentCountryPhoneCode = 0;
            RecentAccountName = "yevgeny.sotnikov@gmail.com";
            RecentPassword = "drovoseg";
            //NeedToRememberRecentPassword = true;
        }
    }
}