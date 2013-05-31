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
	[Activity (Label = "SettingsActivity")]			
	public class SettingsActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			//Show settings-layout
			SetContentView (Resource.Layout.Settings);
			//get groupen from resources/strings.xml
			string[] groepen = Resources.GetStringArray (Resource.Array.groepen_array);
			//find autocompleteview
			AutoCompleteTextView groepList = FindViewById<AutoCompleteTextView> (Resource.Id.autocomplete_groep);
			// link view & groepen
			var adapter = new ArrayAdapter<String> (this, Resource.Layout.list_item, groepen);
			groepList.Adapter = adapter;

			//get ids of fields
			EditText naamField = FindViewById<EditText> (Resource.Id.naamField);
			EditText groepField = FindViewById<AutoCompleteTextView> (Resource.Id.autocomplete_groep);
			//EditText dokterField = FindViewById<EditText> (Resource.Id.dokterField);
			//EditText apotheekField = FindViewById<EditText> (Resource.Id.apotheekField);


			//get settings
			ISharedPreferences settings = GetSharedPreferences ("be.chiro.bivak.settings",0);

			//put settings in fields
			naamField.Text = settings.GetString ("naam", "");
			groepField.Text = settings.GetString ("groep", "");
			//dokterField.Text = settings.GetString ("dokterTel", "");
			//apotheekField.Text = settings.GetString ("apotheekTel", "");


		
			//find savebutton and save settings
			Button save = FindViewById<Button> (Resource.Id.saveButton);
			save.Click += delegate {
				ISharedPreferencesEditor editor = settings.Edit();	
				editor.PutString("naam",naamField.Text);
				editor.PutString("groep",groepField.Text);
				//editor.PutString("dokterTel",dokterField.Text);
				//editor.PutString("apotheekTel",apotheekField.Text);
				editor.PutBoolean("ingevuld",true);
				editor.Commit();
				//show succes message
				Android.Widget.Toast.MakeText (this, "Instellingen opgeslagen", ToastLength.Short).Show ();
			};
		}
	}
}

