using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using PrismTodo.Service;
using PrismTodo.Usecases;

namespace PrismTodo.ViewModels
{
	public class SelectUserGroupPageViewModel : BindableBase
	{
	    private readonly INavigationService _navigationService;
	    private readonly IPageDialogService _pageDialogService;
	    private readonly IManageUserGroup _manageUserGroup;
	    
	    public DelegateCommand SelectUserGroupCommand => new DelegateCommand(SelectUserGroup);
	    
        public SelectUserGroupPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IManageUserGroup manageUserGroup)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _manageUserGroup = manageUserGroup;
        }

	    private void SelectUserGroup()
	    {
	        var cancelButton = ActionSheetButton.CreateCancelButton("キャンセル", () => { });

	        var userGroup1Button = ActionSheetButton.CreateButton<UserGroup>("グループ1", SetUserGroup, UserGroup.Group1);
	        var userGroup2Button = ActionSheetButton.CreateButton<UserGroup>("グループ2", SetUserGroup, UserGroup.Group2);
	        var userGroup3Button = ActionSheetButton.CreateButton<UserGroup>("グループ3", SetUserGroup, UserGroup.Group3);
	        var userGroup4Button = ActionSheetButton.CreateButton<UserGroup>("グループ4", SetUserGroup, UserGroup.Group4);
	        _pageDialogService.DisplayActionSheetAsync(
	            "ユーザーグループを選択してください。", 
	            cancelButton, 
	            userGroup1Button, 
	            userGroup2Button, 
	            userGroup3Button, 
	            userGroup4Button);

        }

        private async void SetUserGroup(UserGroup userGroup)
        {
            await _manageUserGroup.SaveUserGroup(userGroup);
#pragma warning disable CS4014 // この呼び出しを待たないため、現在のメソッドの実行は、呼び出しが完了する前に続行します
            _navigationService.NavigateAsync("/NavigationPage/MainPage");
#pragma warning restore CS4014 // この呼び出しを待たないため、現在のメソッドの実行は、呼び出しが完了する前に続行します
        }
	}
}
