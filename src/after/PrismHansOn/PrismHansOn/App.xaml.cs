using Xamarin.Forms;
using Prism.Autofac.Forms;
using PrismHansOn.Views;

namespace PrismHansOn
{
	public partial class App
	{
	    public App()
	    {
	    }

	    public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
	    {
	    }

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SecondPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
        }

		protected override void OnInitialized()
		{
		    NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
        }
	}
}
