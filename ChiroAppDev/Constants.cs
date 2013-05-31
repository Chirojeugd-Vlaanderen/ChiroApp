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
	public class Constants
	{
		private Constants(){
		}
		//COMMENT FOLLOWING CODE FOR RELEASE
		public const bool DEV = false;
		public const string TELNUMMER = "1230";
		public const string GSMNUMMER = "+32476588722";


		//USE FOLLOWING CODE FOR RELEASE
		/*
		public const bool DEV = false;
		public const string TELNUMMER = "+3232310795";
		public const string GSMNUMMER = "+32478787988";
		*/



	}
}

