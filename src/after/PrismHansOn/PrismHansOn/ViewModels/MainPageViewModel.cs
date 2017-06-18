using Prism.Commands;
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

		private bool _canUpdateMessage;

		public bool CanUpdateMessage
		{
			get => _canUpdateMessage;
			set => SetProperty(ref _canUpdateMessage, value);
		}

		public DelegateCommand UpdateMessageCommand => new DelegateCommand(() =>
		{
			Message = "Updated message.";
		}).ObservesCanExecute(() => CanUpdateMessage);
	}
}
