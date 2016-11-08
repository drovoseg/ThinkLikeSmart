using System;
using Tls.ThinkLikeSmart.Common.Factories;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Strategies.Authentication;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Presenters.Authentication
{
    public class LoginPresenter : BasePresenter
    {
        private readonly ILoginView loginView;
        private readonly ISettings settings;


        private ILoginStrategy currentloginStrategy = null;
        private readonly ILoginStrategy loginViaPhoneStrategy;
        private readonly ILoginStrategy loginViaEmailStrategy;

        public LoginPresenter(ILoginView loginView, IStrategiesFactory factory, ISettings settings)
        {
            if (loginView == null)
                throw new ArgumentNullException(nameof(loginView));

            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            this.loginView = loginView;
            this.settings = settings;

            loginViaPhoneStrategy = factory.CreateLoginStrategy(LoginType.Phone, loginView, settings);
            loginViaEmailStrategy = factory.CreateLoginStrategy(LoginType.Email, loginView, settings);
        }

        public override void ViewCreated()
        {

            if (settings.RecentLoginType == LoginType.Phone)
            {
                loginView.CountryContainerVisible = true;
                loginView.TogglePhoneLoginType();

                currentloginStrategy = loginViaPhoneStrategy;
            }
            else
            {
                loginView.CountryContainerVisible = false;
                loginView.ToggleEmailLoginType();

                currentloginStrategy = loginViaEmailStrategy;
            }
            //regFilter();

            currentloginStrategy.InitializeView();
        }

        public void HandleEmailRadioButtonClick()
        {
            loginView.CountryContainerVisible = false;
        }

        public void HandlePhoneRadioButtonClick()
        {
            loginView.CountryContainerVisible = true;
        }
    }

}
