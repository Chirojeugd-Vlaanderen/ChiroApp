using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;

namespace ChiroAppDev
{
	[Activity ()]			
	public class AfterCallActivity : TabActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			//Vraag om bericht te sturen na het terugkomen van een telefoon
			if (Globals.CALLED == true){
				AlertDialog.Builder sendMessage = new AlertDialog.Builder(this);
				sendMessage.SetTitle("gegevens verzenden?");
				sendMessage.SetMessage("Wil je ook je gegevens per sms versturen?.");
				sendMessage.SetPositiveButton("Ja", delegate {
					sendSms();
				});
				sendMessage.SetNegativeButton("Neen", delegate {});
				sendMessage.Show ();
			}


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
		private void sendSms() {

			// in the meantime send the message
			ISharedPreferences settings = GetSharedPreferences ("be.chiro.bivak.settings",0);
			string message = "Ik ben " + settings.GetString("naam", "<anoniem>") + ", mijn chirogroep is "+ settings.GetString("groep", "<onbekend>") + " en ik bel dadelijk de permanentiegsm";

			if (Constants.DEV == false) {
				var smsUri = Android.Net.Uri.Parse ("smsto:" + Constants.GSMNUMMER);
				var smsIntent = new Intent (Intent.ActionSendto, smsUri);
				smsIntent.PutExtra ("sms_body", message);
				StartActivity (smsIntent);
			} else {
				Android.Widget.Toast.MakeText (this, "DEV: " + message, ToastLength.Long).Show ();
			}
			//let the user know their message is sent.
			Android.Widget.Toast.MakeText (this, "Je gegevens werden verstuurd", ToastLength.Short).Show ();


		}


	}
}

