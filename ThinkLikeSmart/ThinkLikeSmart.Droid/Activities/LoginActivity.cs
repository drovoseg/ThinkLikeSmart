
using Android.App;
using Android.OS;
using Tls.ThinkLikeSmart.Common.Interfaces.Views.Authentication;

namespace Tls.ThinkLikeSmart.Droid.Activities
{
    [Activity]
    public class LoginActivity : Activity, ILoginView
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);
        }
    }
}