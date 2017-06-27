using System;
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

	    public DelegateCommand NavigateToTextToSpeechPageCommand => new DelegateCommand(() =>
	    {
            var navigationParameter = new NavigationParameters();
            navigationParameter.Add("Message", "Hello, NavigationParameter.");
	        _navigationService.NavigateAsync("TextToSpeechPage", navigationParameter);
	    });

	    public DelegateCommand DisplayAlertCommand => new DelegateCommand(() =>
	    {
	        _pageDialogService.DisplayAlertAsync("Title", "Hello, Dialog.", "OK");
	    });

	    public DelegateCommand DisplayConfirmCommand => new DelegateCommand(async () =>
	    {
	        var result = await _pageDialogService.DisplayAlertAsync("Title", "何れかを選んでください。", "はい", "いいえ");
	        Message = $"Selected:{result}";
	    });


	    public DelegateCommand DisplayActionSheetCommand => new DelegateCommand(() =>
	    {
            var cancelButton = ActionSheetButton.CreateCancelButton("キャンセル", () => Message = "Selected:Cancel");
	        var deleteButton = ActionSheetButton.CreateCancelButton("削除", () => Message = "Selected:Cancel");

	        var action = (Action<string>)(selectedItem => { Message = $"Selected:{selectedItem}"; });
            var twitterButton = ActionSheetButton.CreateCancelButton("ついったー", action, "Twitter");
	        var lineButton = ActionSheetButton.CreateCancelButton("らいん", action, "LINE");
	        var facebookButton = ActionSheetButton.CreateCancelButton("ふぇいすぶっく", action, "Facebook");
            _pageDialogService.DisplayActionSheetAsync("共有先を選択してください。", cancelButton, deleteButton, twitterButton, lineButton, facebookButton);
	    });

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }
	}
}
