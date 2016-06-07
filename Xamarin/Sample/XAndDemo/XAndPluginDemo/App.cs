using System;
using Android.App;
using Autofac;
using Android.Runtime;

namespace XAndPluginDemo
{
	#if DEBUG
	[Application(
		Debuggable=true
		, Icon="@mipmap/icon")
	]
	#else
	[Application(
	Debuggable=false
	, Icon="@mipmap/icon")
	]
	#endif
	public class App : Application
	{
		public static IContainer Container { get; set; }

		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho) {}

		public override void OnCreate ()
		{
			var builder = new ContainerBuilder ();
			builder.RegisterType<DiCount>().As<IDiCount>();
			builder.RegisterType<MainModel> ();

			App.Container = builder.Build ();

			base.OnCreate ();
		}
	}
}

