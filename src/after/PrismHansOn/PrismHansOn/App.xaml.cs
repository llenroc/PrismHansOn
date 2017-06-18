using Prism.Autofac.Forms;

namespace PrismHansOn
{
	public partial class App
	{
		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<Views.MainPage>();
		}

		protected override void OnInitialized()
		{
			NavigationService.NavigateAsync(nameof(MainPage));
		}
	}
}
