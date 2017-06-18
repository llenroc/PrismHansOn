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
		}

		protected override void OnInitialized()
		{
			NavigationService.NavigateAsync(nameof(MainPage));
		}
	}
}
