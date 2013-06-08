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

			if (settings.GetBoolean("ingevuld", false) == false){
				AlertDialog.Builder sendMessage = new AlertDialog.Builder(this);
				sendMessage.SetTitle("Vul je gegevens in");
				sendMessage.SetMessage("Om je optimaal te kunnen helpen als er iets mis gaat hebben we je gegevens nodig. Bekijk even de instellingen om ze in te vullen");
				sendMessage.SetPositiveButton("OK", delegate {});
				sendMessage.Show();
			}else if(settings.GetString("naam","") == "" || settings.GetString("groep","") == ""){
				Android.Widget.Toast.MakeText (this, "Je hebt je naam en/of je chirogroep nog niet ingevuld", ToastLength.Long).Show ();
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

				//Show alert to ask if the sms has to be sent (before the call!)
				AlertDialog.Builder sendMessage = new AlertDialog.Builder(this);
				sendMessage.SetTitle("gegevens verzenden?");
				sendMessage.SetMessage("Wil je ook je gegevens per sms versturen?.");
				sendMessage.SetPositiveButton("Ja", delegate {verstuur();});
				sendMessage.SetNeutralButton("Neen", delegate {belKipdorp();});
				sendMessage.SetNegativeButton("Annuleren", delegate {annuleer();});
				//sendMessage.Show();
				belKipdorp();

			};

		
		}
		private void verstuur (){
			//initiate call
			belKipdorp ();
			// in the meantime send the message
			ISharedPreferences settings = GetSharedPreferences ("be.chiro.bivak.settings",0);
			string message = "Ik ben " + settings.GetString("naam", "<anoniem>") + ", mijn chirogroep is "+ settings.GetString("groep", "<onbekend>") + " en ik bel dadelijk de permanentiegsm";

			//FOR DEV
			//EditText gsmField = FindViewById<EditText> (Resource.Id.gsmField);
			//SmsManager.Default.SendTextMessage(gsmField.Text,null,message, null, null);
			//PRODUCTION: UNCOMMENT NEXT LINE:
			if (Constants.DEV == false) {
				SmsManager.Default.SendTextMessage (Constants.GSMNUMMER, null, message, null, null);
			} else {
				Android.Widget.Toast.MakeText (this, "DEV: " + message, ToastLength.Long).Show ();
			}
			//let the user know their message is sent.
			Android.Widget.Toast.MakeText (this, "Je gegevens werden verstuurd", ToastLength.Short).Show ();


		}
		private void annuleer(){
			//Do Nothing
		}
		private void belKipdorp(){
			//call Kipdorp

			//FOR DEV
			//EditText telField = FindViewById<EditText> (Resource.Id.tel);
			//var callUri = Android.Net.Uri.Parse ("tel:" + telField.Text);

			//PRODUCTION: UNCOMMENT NEXT LINE

			var callUri = Android.Net.Uri.Parse ("tel:" + Constants.TELNUMMER);
			if (Constants.DEV == false){
				var callIntent = new Intent (Intent.ActionCall);
				callIntent.SetData (callUri);
				StartActivity (callIntent);
			} else {
				Android.Widget.Toast.MakeText (this, "DEV: bel naar " + Constants.TELNUMMER, ToastLength.Short).Show ();
			}
		}
	
	}
}


