using System;
using Tls.ThinkLikeSmart.Common.Presenters.Authentication;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Strategies.Authentication;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Factories
{
    public class StrategiesFactory : IStrategiesFactory
    {
        public ILoginStrategy CreateLoginStrategy(LoginType loginType, ILoginView loginView, ISettings settings, IResourcesProvider resourcesProvider)
        {
            if (loginView == null)
                throw new ArgumentNullException(nameof(loginView));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (resourcesProvider == null)
                throw new ArgumentNullException(nameof(resourcesProvider));

            switch (loginType)
            {
                case LoginType.Email: return new LoginViaEmailStrategy(loginView, settings);
                case LoginType.Phone: return new LoginViaPhoneStrategy(loginView, settings, resourcesProvider);

                default: throw new ArgumentException(nameof(loginType));
            }
        }
    }
}
