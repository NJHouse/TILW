using Android.App;
using Android.Widget;
using Android.OS;
using Autofac;
using Android.Content;

namespace XAndPluginDemo
{
	[Activity (Label = "XAndPluginDemo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			/*
			IDiCount diCount;

			using (var scope = App.Container.BeginLifetimeScope ()) 
			{
				diCount  = scope.Resolve<IDiCount> ();
			}
			*/
			var diCount = App.Container.Resolve<MainModel> ();

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			/*
			button.Click += delegate {
				//button.Text = string.Format ("{0} clicks!", count++);
				button.Text = string.Format("{0} clicks!", diCount.AddPerClick());
			};
			*/
			button.Click += (sender, e) =>
			{
				// Pass the current button press count value to the next activity:
				Bundle valuesForActivity = new Bundle();
				valuesForActivity.PutInt("count", count);

				// When the user clicks notification, SecondActivity will start up.
				Intent resultIntent = new Intent(this, typeof(LocNotiActivity));

				// Pass some values to SecondActivity:
				resultIntent.PutExtras(valuesForActivity);

				// Construct a back stack for cross-task navigation:
				TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
				stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(LocNotiActivity)));
				stackBuilder.AddNextIntent(resultIntent);

				// Create the PendingIntent with the back stack:
				PendingIntent resultPendingIntent =
					stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

				// Build the notification:
				//NotificationCompat.

			};
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
		}
	}
}


