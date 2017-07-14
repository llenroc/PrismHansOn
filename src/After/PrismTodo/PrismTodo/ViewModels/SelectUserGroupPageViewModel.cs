﻿using Prism.Commands;
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
	        _pageDialogService.DisplayActionSheetAsync(
	            "ユーザーグループを選択してください。",
	            ActionSheetButton.CreateCancelButton("キャンセル", () => { }),
	            ActionSheetButton.CreateButton("グループ1", OnSelectedUserGroup, UserGroup.Group1),
	            ActionSheetButton.CreateButton("グループ2", OnSelectedUserGroup, UserGroup.Group2),
	            ActionSheetButton.CreateButton("グループ3", OnSelectedUserGroup, UserGroup.Group3),
	            ActionSheetButton.CreateButton("グループ4", OnSelectedUserGroup, UserGroup.Group4));
        }

        private void OnSelectedUserGroup(UserGroup userGroup)
        {
             _manageUserGroup.SaveUserGroup(userGroup);
            _navigationService.NavigateAsync("/NavigationPage/MainPage");
        }
	}
}