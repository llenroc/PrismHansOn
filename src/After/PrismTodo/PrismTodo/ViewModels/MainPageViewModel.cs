using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;
using PrismTodo.Usecases;

namespace PrismTodo.ViewModels
{
    public class MainPageViewModel : INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IManageUserGroup _manageUserGroup;

        public MainPageViewModel(INavigationService navigationService, IManageUserGroup manageUserGroup)
        {
            _navigationService = navigationService;
            _manageUserGroup = manageUserGroup;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (_manageUserGroup.SelectedUserGroup())
            {

            }
            else
            {
                _navigationService.NavigateAsync("/NavigationPage/SelectUserGroupPage");
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
