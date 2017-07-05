using Autofac;
using Prism.Autofac.Forms;
using PrismHansOn.Models;

namespace PrismHansOn.UWP
{
    public sealed partial class MainPage
	{
		public MainPage()
		{
			this.InitializeComponent();

			LoadApplication(new PrismHansOn.App(new PlatformInitializer()));
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
