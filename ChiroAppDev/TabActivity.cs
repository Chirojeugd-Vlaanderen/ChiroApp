using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;



namespace ChiroAppDev
{
	[Activity (Label = "Op Bivak!", Theme = "@style/Theme.Light")]
	public class Tabactivity : TabActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);


			TabHost.TabSpec spec;     // Resusable TabSpec for each tab
			Intent intent;            // Reusable Intent for each tab

			// Create an Intent to launch an Activity for the tab (to be reused)
			intent = new Intent (this, typeof (Activity1));
			intent.AddFlags (ActivityFlags.NewTask);

			// Initialize a TabSpec for each tab and add it to the TabHost
			spec = TabHost.NewTabSpec ("Op Bivak");
			spec.SetIndicator ("", Resources.GetDrawable (Resource.Drawable.tab_main));
			//spec.SetIndicator ("Main", null);
			spec.SetContent (intent);
			TabHost.AddTab (spec);

			// Do the same for the other tabs
			intent = new Intent (this, typeof (EmergencyActivity));
			intent.AddFlags (ActivityFlags.NewTask);

			spec = TabHost.NewTabSpec ("Emergency");
			spec.SetIndicator ("", Resources.GetDrawable (Resource.Drawable.tab_sos_red));
			//spec.SetIndicator ("Settings", null);
			spec.SetContent (intent);
			TabHost.AddTab (spec);

			intent = new Intent (this, typeof (FaqActivity));
			intent.AddFlags (ActivityFlags.NewTask);

			spec = TabHost.NewTabSpec ("FAQ");
			spec.SetIndicator ("", Resources.GetDrawable (Resource.Drawable.tab_faq));
			//spec.SetIndicator ("Settings", null);
			spec.SetContent (intent);
			TabHost.AddTab (spec);

			intent = new Intent (this, typeof (SettingsActivity));
			intent.AddFlags (ActivityFlags.NewTask);
			spec = TabHost.NewTabSpec ("Settings");
			spec.SetIndicator ("", Resources.GetDrawable (Resource.Drawable.tab_settings));
			//spec.SetIndicator ("Settings", null);
			spec.SetContent (intent);
			TabHost.AddTab (spec);



			TabHost.CurrentTab = 0;
		}
	}

}


