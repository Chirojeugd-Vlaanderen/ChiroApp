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
	[Activity (Label = "FaqListActivity")]			
	public class FaqListActivity : ListActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			overzicht ();
		}
		protected override void OnListItemClick(ListView l, View v,	int position, long id){
			var t = texts [position];
			Intent = new Intent ();

			TextView title = FindViewById<TextView> (Resource.Id.faqTitle);
			TextView text = FindViewById<TextView> (Resource.Id.faqText);
			Button back = FindViewById<Button> (Resource.Id.faqBackButton);
			title.Text = titles [position];
			text.Text = texts [position];
			back.Click += delegate {
				overzicht();
			};
		}
		private void overzicht(){

			faqArray = Resources.GetStringArray (Resource.Array.faqs);
			titles = faqArray;
			texts = Resources.GetStringArray (Resource.Array.faqs);
			for (int a = 0; a < faqArray.Length; a++) {
				string str = faqArray [a];
				titles [a] = str.Substring (0, str.IndexOf ("|"));
				texts [a] = str.Substring (str.IndexOf("|")+1);
			}
			ListAdapter = new ArrayAdapter<String> (this, Android.Resource.Layout.SimpleListItem1, titles);

		}
		protected string[] faqArray;
		private string[] titles;
		private string[] texts ;
	}
}

