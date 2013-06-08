using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//call and sms
using Android.Telephony;
//bgcolor
using Android.Graphics;




namespace ChiroAppDev
{
	[Activity (Label = "Op Bivak!", Theme = "@style/Theme.Light")]
	public class Activity1 : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "Tabbed" layout resource
			SetContentView (Resource.Layout.Tabbed);
			// Get settings
			ISharedPreferences settings = GetSharedPreferences ("be.chiro.bivak.settings",0);
			//Toen waarschuwingen als je niet terugkomt van een call
			if (Globals.CALLED==false)
			{
				// de settings zijn nog nooit opgeslagen
				if (settings.GetBoolean("ingevuld", false) == false){
					AlertDialog.Builder sendMessage = new AlertDialog.Builder(this);
					sendMessage.SetTitle("Vul je gegevens in");
					sendMessage.SetMessage("Om je optimaal te kunnen helpen als er iets mis gaat hebben we je gegevens nodig. Bekijk even de instellingen om ze in te vullen");
					sendMessage.SetPositiveButton("OK", delegate {});
					sendMessage.Show();
				}
				//De settings zijn nog niet volledig
				else if(settings.GetString("naam","") == "" || settings.GetString("groep","") == ""){
					Android.Widget.Toast.MakeText (this, "Je hebt je naam en/of je chirogroep nog niet ingevuld", ToastLength.Long).Show ();
				}
				//reset global var CALLED
				Globals.CALLED = false;
			}

			// For Warnings we use chirorood
			Color chirorood = new Color (225, 20, 60, 225); //R, G, B, alpha
			// Find ID of infotext
			TextView infoText = FindViewById<TextView> (Resource.Id.infoText);


			//Show a different text between 09h and 18h
			var hour = DateTime.Now.Hour;
			var day = DateTime.Now.DayOfWeek;

			if (9 <= hour && hour < 18){
				infoText.SetText(Resource.String.voor18u);
			}else{
				infoText.SetText(Resource.String.na18u);
				infoText.SetBackgroundColor (chirorood);
			}
			// Als het zaterdag of zondag is doen we sowieso alsof het na 18u is.
			if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday){
				infoText.SetText (Resource.String.na18u);
				infoText.SetBackgroundColor (chirorood);
			}

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				//sendMessage.Show();
				belKipdorp();

			};

		
		
		}
		private void belKipdorp(){

			var callUri = Android.Net.Uri.Parse ("tel:" + Constants.TELNUMMER);
			if (Constants.DEV == false){
				var callIntent = new Intent (Intent.ActionSendto, callUri);
				StartActivity (callIntent);
			} else {
				Android.Widget.Toast.MakeText (this, "DEV: bel naar " + Constants.TELNUMMER, ToastLength.Short).Show ();
			}
		}
	
	}
}


