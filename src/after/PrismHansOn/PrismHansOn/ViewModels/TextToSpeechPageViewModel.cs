using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismHansOn.Models;

namespace PrismHansOn.ViewModels
{
    public class TextToSpeechPageViewModel : BindableBase, IDestructible, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private readonly ITextToSpeechService _textToSpeechService;

        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand GoBackCommand => new DelegateCommand(() =>
        {
            _navigationService.GoBackAsync();
        });

        public DelegateCommand SpeakCommand => new DelegateCommand(() =>
        {
            _textToSpeechService.Speak(Message);
        });

        public TextToSpeechPageViewModel(INavigationService navigationService, ITextToSpeechService textToSpeechService)
        {
            _navigationService = navigationService;
            _textToSpeechService = textToSpeechService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
	        Message = (string)parameters["Message"];
        }

        public void Destroy()
        {
            Debug.WriteLine("TextToSpeechPageViewModel#Destroy()");
        }
    }
}
