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

            //        recentPwd = SharedPreferencesManager.getInstance().getData(
            //                mContext, SharedPreferencesManager.SP_FILE_GWELL,
            //                SharedPreferencesManager.KEY_RECENTPASS);
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

            //        else
            //        {
            //            if (getResources().getConfiguration().locale.getCountry()
            //                    .equals("TW"))
            //            {
            //                default_count.setText("+886");
            //                String name = SearchListActivity.getNameByCode(mContext,
            //                        886);
            //                default_name.setText(name);
            //            }
            //            else if (getResources().getConfiguration().locale
            //                  .getCountry().equals("CN"))
            //            {
            //                default_count.setText("+86");
            //                String name = SearchListActivity
            //                        .getNameByCode(mContext, 86);
            //                default_name.setText(name);
            //            }
            //            else
            //            {
            //                default_count.setText("+1");
            //                String name = SearchListActivity.getNameByCode(mContext, 1);
            //                default_name.setText(name);
            //            }
            //        }

            //        if (SharedPreferencesManager.getInstance().getIsRememberPass(
            //                mContext))
            //        {
            //            remember_pwd_img.setImageResource(R.drawable.ic_remember_pwd);
            //            if (!recentPwd.equals(""))
            //            {
            //                mAccountPwd.setText(recentPwd);
            //            }
            //            else
            //            {
            //                mAccountPwd.setText("");
            //            }
            //        }
            //        else
            //        {
            //            remember_pwd_img.setImageResource(R.drawable.ic_unremember_pwd);
            //            mAccountPwd.setText("");
            //        }
        }

        private void SetupCountryRelatedControls(ushort countryPhoneCode)
        {
            loginView.CountryPhoneCode = "+" + countryPhoneCode;
            loginView.CountryName = resourcesProvider.GetLocalizedCountryNameByCode(countryPhoneCode);
        }
    }
}
