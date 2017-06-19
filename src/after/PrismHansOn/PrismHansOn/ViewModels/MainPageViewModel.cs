using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismHansOn.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
		private readonly IDeviceService _deviceService;

	    private readonly INavigationService _navigationService;

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

	    public DelegateCommand NavigateToTextToSpeechPageCommand => new DelegateCommand(() =>
	    {
            var navigationParameter = new NavigationParameters();
            navigationParameter.Add("Message", "Hello, NavigationParameter.");
	        _navigationService.NavigateAsync("TextToSpeechPage", navigationParameter);
	    });


        public MainPageViewModel(IDeviceService deviceService, INavigationService navigationService)
		{
			_deviceService = deviceService;
		    _navigationService = navigationService;
		    Message = Message + " on " + _deviceService.Platform;
		}
	}
}
