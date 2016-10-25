
using Android.App;
using Android.OS;

namespace Tls.ThinkLikeSmart.Droid.Activities
{
    [Activity]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);
        }
    }
}