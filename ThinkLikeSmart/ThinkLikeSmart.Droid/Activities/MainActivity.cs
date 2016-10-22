
using Android.App;
using Android.OS;

namespace Tls.ThinkLikeSmart.Droid.Activities
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
        }
    }
}