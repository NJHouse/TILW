﻿
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

namespace XAndPluginDemo
{
	[Activity(Label = "LocNotiActivity")]
	public class LocNotiActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Get the count value passed to us from MainActivity:
			int count = Intent.Extras.GetInt("count", -1);

			// No count was passed? Then just return.
			if (count <= 0)
				return;

			// Display the count sent from the first activity:
			SetContentView(Resource.Layout.LocNoti);
			TextView textView = FindViewById<TextView>(Resource.Id.textView);
			textView.Text = string.Format(
				"You clicked the button {0} times in the previous activity.", count
			);
		}
	}
}

