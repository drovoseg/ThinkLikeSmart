using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.Droid.Storage
{
    class AndroidSettings : ISettings
    {
        public LoginType RecentLoginType { get; set; }
    }
}