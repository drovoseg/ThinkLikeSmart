using System;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Strategies.Authentication
{
    public class LoginViaEmailStrategy : ILoginStrategy
    {
        private readonly ILoginView loginView;
        private readonly ISettings settings;

        public LoginViaEmailStrategy(ILoginView loginView, ISettings settings)
        {
            if (loginView == null)
                throw new ArgumentNullException(nameof(loginView));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            this.loginView = loginView;
            this.settings = settings;
        }

        public void InitializeView()
        {
            string recentEmail = settings.RecentAccountName;

            loginView.AccountName = string.IsNullOrWhiteSpace(recentEmail) ? string.Empty : recentEmail;

            if (!settings.NeedToRememberRecentPassword)
            {
                loginView.RememberPasswordToggled = false;
                loginView.Password = string.Empty;
                 
                return;
            }
            
            loginView.RememberPasswordToggled = true;

            string recentPassword = settings.RecentPassword;
            loginView.Password = string.IsNullOrWhiteSpace(recentPassword) ? string.Empty : recentPassword;
        }
    }
}
