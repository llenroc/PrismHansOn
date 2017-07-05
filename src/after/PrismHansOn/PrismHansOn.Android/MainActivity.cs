using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using Prism;
using Prism.Autofac.Forms;
using PrismHansOn.Models;

namespace PrismHansOn.Droid
{
	[Activity(Label = "PrismHansOn", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App(new PlatformInitializer()));
		}

	    private class PlatformInitializer : IPlatformInitializer
	    {
	        public void RegisterTypes(IContainer container)
	        {
	            var builder = new ContainerBuilder();
	            builder.RegisterType<TextToSpeechService>().As<ITextToSpeechService>().SingleInstance();
	            builder.Update(container);
	        }
	    }

    }
}

