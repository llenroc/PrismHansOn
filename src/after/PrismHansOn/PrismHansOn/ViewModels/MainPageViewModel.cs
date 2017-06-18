using Prism.Mvvm;

namespace PrismHansOn.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
		private string _message = "Hello, Prism for Xamarin.Forms!";

		public string Message
		{
			get => _message;
			set => SetProperty(ref _message, value);
		}
	}
}
