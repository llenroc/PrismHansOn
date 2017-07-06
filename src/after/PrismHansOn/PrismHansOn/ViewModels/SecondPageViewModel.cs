using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismHansOn.ViewModels
{
    public class SecondPageViewModel : BindableBase, IDestructible, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private readonly IPageDialogService _pageDialogService;

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
            var deleteButton = ActionSheetButton.CreateDestroyButton("削除", () => Message = "Selected:削除");

            var twitterButton = ActionSheetButton.CreateButton("ついったー", SelectedTwitter);
            var lineButton = ActionSheetButton.CreateButton("らいん", SelectedLine);
            var facebookButton = ActionSheetButton.CreateButton("ふぇいすぶっく", SelectedItem, "Facebook");
            _pageDialogService.DisplayActionSheetAsync("共有先を選択してください。", cancelButton, deleteButton, twitterButton, lineButton, facebookButton);
        });

        private void SelectedTwitter()
        {
            Message = $"Selected:Twitter";
        }

        private void SelectedLine()
        {
            Message = $"Selected:LINE";
        }

        private void SelectedItem(string message)
        {
            Message = $"Selected:{message}";
        }

        public SecondPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }

        public void Destroy()
        {
            // ここで必要に応じて解放処理を行う
            Debug.WriteLine("SecondPageViewModel#Destroy()");
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
