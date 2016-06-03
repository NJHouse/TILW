using Android.App;
using Android.Widget;
using Android.OS;
using Autofac;

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

			IDiCount diCount;

			using (var scope = App.Container.BeginLifetimeScope ()) 
			{
				diCount  = scope.Resolve<IDiCount> ();
			}

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				//button.Text = string.Format ("{0} clicks!", count++);
				button.Text = string.Format("{0} clicks!", diCount.AddPerClick());
			};
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
		}
	}
}


