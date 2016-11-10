using System;
using System.Collections.Generic;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Strategies.Authentication
{
    public class LoginViaPhoneStrategy : ILoginStrategy
    {
        private static readonly IDictionary<string, ushort> DefaultRegionCountryKeyPairs = new Dictionary<string, ushort>
        {
            { "en" , 1 },
            { "fr" , 33 },
            { "ko" , 850 },
            { "ru" , 7 },
            { "zh" , 86 },
            { "zh-TW" , 886 }
        };

        private readonly ILoginView loginView;
        private readonly ISettings settings;
        private readonly IResourcesProvider resourcesProvider;

        public LoginViaPhoneStrategy(ILoginView loginView, ISettings settings, IResourcesProvider resourcesProvider)
        {
            if (loginView == null)
                throw new ArgumentNullException(nameof(loginView));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (resourcesProvider == null)
                throw new ArgumentNullException(nameof(resourcesProvider));

            this.loginView = loginView;
            this.settings = settings;
            this.resourcesProvider = resourcesProvider;
        }

        public void InitializeView()
        {
            string recentEmail = settings.RecentAccountName;

            loginView.AccountName = !string.IsNullOrWhiteSpace(recentEmail) ? recentEmail : string.Empty;

            ushort recentCountryPhoneCode = settings.RecentCountryPhoneCode;

            if (recentCountryPhoneCode != 0)
            {
                SetupCountryRelatedControls(recentCountryPhoneCode);
            }
            else
            {
                string settingsLanguage = settings.CurrentLanguage;

                if (DefaultRegionCountryKeyPairs.ContainsKey(settingsLanguage))
                {
                    SetupCountryRelatedControls(DefaultRegionCountryKeyPairs[settingsLanguage]);
                }
                else
                {
                    string key = settingsLanguage + "-" + settings.CurrentCountry;

                    if (DefaultRegionCountryKeyPairs.ContainsKey(key))
                    {
                        SetupCountryRelatedControls(DefaultRegionCountryKeyPairs[key]);
                    }
                    else SetupCountryRelatedControls(1);
                }
            }

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

        private void SetupCountryRelatedControls(ushort countryPhoneCode)
        {
            loginView.CountryPhoneCode = "+" + countryPhoneCode;
            loginView.CountryName = resourcesProvider.GetLocalizedCountryNameByCode(countryPhoneCode);
        }
    }
}
