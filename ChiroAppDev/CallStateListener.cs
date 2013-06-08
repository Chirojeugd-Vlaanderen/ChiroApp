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

	[BroadcastReceiver()]
	[IntentFilter(new[] {"android.intent.action.PHONE_STATE"})]
	public class IncomingCallReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			//make sure there is info
			if (intent.Extras != null) {
				// get the call state
				string state = intent.GetStringExtra (TelephonyManager.ExtraState);
				if (state == TelephonyManager.ExtraStateRinging) {
					Console.WriteLine ("RINGING");
					//Toast.MakeText (context, "RINGING", ToastLength.Long);
				} else if (state == TelephonyManager.ExtraStateOffhook) {
					Console.WriteLine ("OFF HOOK");
					//Toast.MakeText (context, "OFFHOOK", ToastLength.Long);

				} else if (state == TelephonyManager.ExtraStateIdle) {
					Console.WriteLine ("IDLE");
					sendSMS (context);
				}
			}
		}
		public void sendSMS(Context context)
		{
			ISharedPreferences settings = context.GetSharedPreferences ("be.chiro.bivak.settings",0);
			string message = "Ik ben " + settings.GetString("naam", "<anoniem>") + ", mijn chirogroep is "+ settings.GetString("groep", "<onbekend>") + " en ik belde juist de permanentiegsm";
			AlertDialog.Builder sendMessage = new AlertDialog.Builder(context);

			sendMessage.SetTitle("gegevens verzenden?");
			sendMessage.SetMessage("Wil je ook je gegevens per sms versturen?.");
			sendMessage.SetPositiveButton ("Ja", delegate {
				SmsManager.Default.SendTextMessage (Constants.GSMNUMMER, null, message, null, null);
			Android.Widget.Toast.MakeText (context, "Je gegevens werden verstuurd", ToastLength.Short).Show ();
			});
		sendMessage.SetNegativeButton ("Neen", delegate {});
		sendMessage.Show ();
		}
	
			//StartActivity (smsIntent);
	}

}




