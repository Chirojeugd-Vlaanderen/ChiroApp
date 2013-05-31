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
	[Activity (Label = "FaqAdapter")]			
	public class FaqAdapter : BaseAdapter<TableItem>
	{
		List<TableItem> items;
		Activity context;
		public FaqAdapter(Activity context, List<TableItem> items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override long GetItemId(int position)
		{
			return position;
		}
		public override TableItem this[int position]
		{
			get { return items[position]; }
		}
		public override int Count
		{
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];

			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1,null);
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = item.Title;
			//view.FindViewById<TextView> (Android.Resource.Id.Text2).Text = item.Title;
			//view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Title;
			//view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
			//view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);

			return view;
		}
		}
	}


