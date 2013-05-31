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

namespace ChiroAppDev
{
	[Activity (Label = "EmergencyActivity")]			
	public class EmergencyActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Emergency);
			//find buttons
			Button hulp = FindViewById<Button> (Resource.Id.hulpdiensten);
			Button politie = FindViewById<Button> (Resource.Id.politie);
			Button antigif = FindViewById<Button> (Resource.Id.antigifcentrum);
			Button apotheek = FindViewById<Button> (Resource.Id.apotheek);
			//Button dokter = FindViewById<Button> (Resource.Id.dokter);
		

			ISharedPreferences settings = GetSharedPreferences ("be.chiro.bivak.settings",0);

		

			hulp.Click += delegate {
				bel ("112");
			};
			politie.Click += delegate {
				bel ("101");
			};
			antigif.Click += delegate {
				bel ("070245245");
			};
			apotheek.Click += delegate {
				bel (settings.GetString("apotheekTel","090010500"));
			};
			/*dokter.Click += delegate {
				if (settings.GetString("dokterTel","") == ""){
					AlertDialog.Builder sendMessage = new AlertDialog.Builder(this);
					sendMessage.SetTitle("Geen nummer ingevuld");
					sendMessage.SetMessage("Vul bij de instellingen het nummer van de dokter van wacht in.");
					sendMessage.SetPositiveButton("OK", delegate {});
					//sendMessage.SetNeutralButton("Neen", delegate {belKipdorp();});
					//sendMessage.SetNegativeButton("Annuleren", delegate {annuleer();});
					sendMessage.Show();
				}else{
					bel (settings.GetString("dokterTel",""));
				}
			};


		dokter.Text = "Dokter (" + settings.GetString ("dokterTel", "Geen nummer gevonden") +")";
		*/	
			if (settings.GetString("apotheekTel","") != ""){
				apotheek.Text = "Apotheek van wacht (" + settings.GetString ("apotheekTel", "") + ")";
			}

		}
				private void bel (string telnr){

			var callUri = Android.Net.Uri.Parse ("tel:" + telnr);




			//PRODUCTION: UNCOMMENT NEXT LINE
			if (Constants.DEV != true){
				var callIntent = new Intent (Intent.ActionCall);
				callIntent.SetData (callUri);
				StartActivity (callIntent);
			} else {
				Android.Widget.Toast.MakeText (this, "DEV: bel naar: " + telnr, ToastLength.Short).Show ();
			}
		}
	}
}

