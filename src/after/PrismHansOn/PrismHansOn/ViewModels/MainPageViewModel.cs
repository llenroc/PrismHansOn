using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismHansOn.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
	    private readonly INavigationService _navigationService;

	    private readonly IPageDialogService _pageDialogService;

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

        public DelegateCommand DisplayAlertCommand => new DelegateCommand(() =>
        {
            _pageDialogService.DisplayAlertAsync("Title", "Hello, Dialog.", "OK");
        });

	    public DelegateCommand NavigateToTextToSpeechPageCommand => new DelegateCommand(() =>
	    {
            var navigationParameter = new NavigationParameters();
            navigationParameter.Add("Message", "Hello, NavigationParameter.");
	        _navigationService.NavigateAsync("TextToSpeechPage", navigationParameter);
	    });


        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }
	}
}
