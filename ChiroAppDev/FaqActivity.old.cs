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
using Android.Graphics;

namespace ChiroAppDev
{
	[Activity (Label = "FaqActivity", Theme = "@style/Theme.Light")]			
	public class FaqActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			Color grey = new Color (125, 125, 125);
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.FAQ);
			//ListView list= FindViewById<ListView> (Resource.Id.faqView);
			//list.ItemClick += OnListItemClick;//


			/*string[] items = Resources.GetStringArray (Resource.Array.faqs);
			for (int a = 0; a < items.Length; a++) {
				addfaqs (items[a]);
			}
		var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;
			//LayoutRules lrules = new LinearLayout.LayoutParams
			foreach (KeyValuePair<string, string> pair in faqs)
			{
				var title = new TextView (this);
				var text = new TextView (this);
				//var line = new View (this);
				//line.SetMinimumHeight ();
				//line.SetBackgroundColor (grey);
				title.Text = pair.Key;
				text.Text = pair.Value;
				layout.AddView (title);
				//layout.AddView (line);
				layout.AddView (text);
				//layout.AddView (line);
			}
			SetContentView (layout);
			SetContentView (Resource.Layout.FAQ);
			ListView faqView = FindViewById<ListView> (Resource.Id.faqView);
			//get groupen from resources/strings.xml
			string[] faqArray = Resources.GetStringArray (Resource.Array.faqs);
			for (int a = 0; a < faqArray.Length; a++) {
				string str = faqArray [a];
				faqArray [a] = str.Substring (0, str.IndexOf ("|"));
			}
			//find autocompleteview
			//AutoCompleteTextView groepList = FindViewById<AutoCompleteTextView> (Resource.Id.autocomplete_groep);
			// link view & groepen
			var adapter = new ArrayAdapter<String> (this, Resource.Layout.faq_item, faqArray);
			faqView.Adapter = adapter;
			//ListView.IOnItemClickListener
			

			*/
		}
	

		/*private void addfaqs(string str){
				string title = str.Substring (0, str.IndexOf ("|"));
				string text = str.Substring (str.IndexOf("|")+1);
				faqs.Add (title, text);
		}
		private Dictionary<string, string> faqs = new Dictionary<string,string>();
		/*protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			//base.OnListItemClick (l, v, position, id);
			Toast.MakeText (this, faqs [position],
			                ToastLength.Short).Show ();
		}*/

	}
}

