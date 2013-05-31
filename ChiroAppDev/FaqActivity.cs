using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ChiroAppDev {
	[Activity(Label = "FAQ")]
	public class FaqActivity : Activity{//, View.IOnClickListener {

		List<TableItem> tableItems = new List<TableItem>();
		ListView listView;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			string[] faqs = Resources.GetStringArray (Resource.Array.faqs);
			for (int a = 0; a<faqs.Length;a++){
				string str = faqs [a];
				tableItems.Add (new TableItem(){Title =str.Substring(0,str.IndexOf("|")), Text=str.Substring(str.IndexOf("|")+1)});
			}
			overzicht();

		}

		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			var listView = sender as ListView;
			var t = tableItems[e.Position];
			SetContentView (Resource.Layout.faq_detail);
			TextView title = FindViewById<TextView> (Resource.Id.faqTitle);
			TextView text = FindViewById<TextView> (Resource.Id.faqText);
			Button back = FindViewById<Button> (Resource.Id.faqBackButton);
			//Android.Widget.Toast.MakeText(this, t.Title, Android.Widget.ToastLength.Short).Show();
			title.Text = t.Title;
			text.Text = t.Text;
			Console.WriteLine("Clicked on " + t.Title);
			back.Click += delegate {
				overzicht();
		};
		}
		protected void overzicht(){
			SetContentView(Resource.Layout.FAQ);
			listView = FindViewById<ListView>(Resource.Id.faqList);
			listView.Adapter = new FaqAdapter(this, tableItems);
			listView.ItemClick += OnListItemClick;
		
		}
	}
}