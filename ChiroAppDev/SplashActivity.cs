namespace ChiroAppDev
{
	using System.Threading;

	using Android.App;
	using Android.OS;

	[Activity(Theme = "@style/Theme.Splash", NoHistory = true, MainLauncher = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			//Thread.Sleep(10000); // Simulate a long loading process on app startup.
			StartActivity(typeof(Tabactivity));
		}
	}
}

