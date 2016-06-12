using System;
using Android.App;
using Android.Runtime;
using Autofac;

namespace AutofacDemo
{
	#if DEBUG
	[Application(Debuggable = true, Icon = "@mipmap/icon")]
	#else
	[Application(Debuggable=false, Icon="@mipmap/icon")]
	#endif
	 
	public class App : Application
	{
		public static IContainer Container { get; set; }

		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho) { }

		public override void OnCreate()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<AddRepository>().As<IAddRepository>();
			builder.RegisterType<MainModel>();

			App.Container = builder.Build();

			base.OnCreate();
		}
	}
}

