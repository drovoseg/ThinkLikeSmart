using System;
using Tls.ThinkLikeSmart.Common.Storage;
using Tls.ThinkLikeSmart.Common.Views.Authentication;

namespace Tls.ThinkLikeSmart.Common.Strategies.Authentication
{
    public class LoginViaPhoneStrategy : ILoginStrategy
    {
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
            string recentCountryPhoneCode = settings.RecentCountryPhoneCode;

            if (recentCountryPhoneCode != string.Empty)
            {
                loginView.CountryPhoneCode = '+' + recentCountryPhoneCode;
                loginView.CountryName = resourcesProvider.GetLocalizedCountryNameByCode(recentCountryPhoneCode);
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
    }
}
