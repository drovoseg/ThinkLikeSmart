using Android.App;
using Android.OS;
using System.Threading.Tasks;
using Android.Content;
using Tls.ThinkLikeSmart.Droid.Activities;

namespace Tls.ThinkLikeSmart.Droid.Activties
{
    [Activity(Theme = "@style/ThinkLikeSmart.SplashScreen", MainLauncher = true, NoHistory = true)]
	public class LogoActivity : Activity
    {
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		}

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() => {
                Task.Delay(2000);  // Simulate a bit of startup work.
            });

            startupWork.ContinueWith(t => {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}


