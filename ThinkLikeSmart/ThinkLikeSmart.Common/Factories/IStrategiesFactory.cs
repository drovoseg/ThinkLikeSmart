using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Strategies.Authentication;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Factories
{
    public interface IStrategiesFactory
    {
        ILoginStrategy CreateLoginStrategy(LoginType loginType, ILoginView loginView, ISettings settings, IResourcesProvider resourcesProvider);
    }
}
