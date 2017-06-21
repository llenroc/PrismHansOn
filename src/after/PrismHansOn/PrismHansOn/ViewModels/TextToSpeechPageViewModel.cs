using System.Runtime.InteropServices.WindowsRuntime;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismHansOn.ViewModels
{
    public class TextToSpeechPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

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

        public TextToSpeechPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
    }
}
