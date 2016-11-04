using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.iOS.Storage
{
    class IosSettings : ISettings
    {
        public LoginType RecentLoginType { get; set; }
    }
}
