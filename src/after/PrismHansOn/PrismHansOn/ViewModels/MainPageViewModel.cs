using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismHansOn.Models;

namespace PrismHansOn.ViewModels
{
	public class MainPageViewModel : BindableBase
	{
		private string _message = "Hello, Prism for Xamarin.Forms!";

        private bool _canUpdateMessage;

        private readonly ITextToSpeechService _textToSpeechService;

	    private readonly INavigationService _navigationService;

        public string Message
		{
			get => _message;
			set => SetProperty(ref _message, value);
		}


		public bool CanUpdateMessage
		{
			get => _canUpdateMessage;
			set => SetProperty(ref _canUpdateMessage, value);
		}

		public DelegateCommand UpdateMessageCommand => new DelegateCommand(() =>
		{
			Message = "Updated message.";
		}).ObservesCanExecute(() => CanUpdateMessage);

	    public DelegateCommand SpeakCommand => new DelegateCommand(() =>
	    {
	        _textToSpeechService.Speak(Message);
	    });

	    public DelegateCommand NavigateToSecondPageCommand => new DelegateCommand(() =>
	    {
	        var navigationParameter = new NavigationParameters();
	        navigationParameter.Add("Message", "Hello, Navigation Parameter.");
	        _navigationService.NavigateAsync("SecondPage", navigationParameter);
	    });

        public MainPageViewModel(INavigationService navigationService, ITextToSpeechService textToSpeechService)
        {
            _navigationService = navigationService;
            _textToSpeechService = textToSpeechService;
        }
	}
}
