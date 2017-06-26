using Xamarin.Forms;
using Prism.Autofac.Forms;
using PrismHansOn.Views;

namespace PrismHansOn
{
	public partial class App
	{
		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<TextToSpeechPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
		}

		protected override void OnInitialized()
		{
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
		}
	}
}
