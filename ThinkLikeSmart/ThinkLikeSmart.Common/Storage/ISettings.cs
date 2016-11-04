using Tls.ThinkLikeSmart.Common.Presenters.Authentication;

namespace Tls.ThinkLikeSmart.Common.Storage
{
    public interface ISettings
    {
        LoginType RecentLoginType { get; set; }
    }
}
