using System;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Views;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Presenters.Authentication
{
    public class LoginPresenter : BasePresenter
    {
        private readonly ILoginView loginView;
        private readonly ISettings settings;

        private LoginType currentType;

        public LoginPresenter(ILoginView loginView, ISettings settings)
        {
            if (loginView == null)
                throw new ArgumentNullException(nameof(loginView));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            this.loginView = loginView;
            this.settings = settings;
        }

        public override void ViewCreated()
        {
            currentType = settings.RecentLoginType;

            if (currentType == LoginType.Phone)
            {
                loginView.IsCountryContainerVisible = true;
                loginView.TogglePhoneLoginType();
            }
            else
            {
                loginView.IsCountryContainerVisible = false;
                loginView.ToggleEmailLoginType();
            }
            //regFilter();
            //initRememberPass();
        }

        public void HandleEmailRadioButtonClick()
        {
            loginView.IsCountryContainerVisible = false;
        }

        public void HandlePhoneRadioButtonClick()
        {
            loginView.IsCountryContainerVisible = true;
        }
    }

}
