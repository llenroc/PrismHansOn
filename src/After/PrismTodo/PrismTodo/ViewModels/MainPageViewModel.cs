using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using PrismTodo.Service;
using PrismTodo.Usecases;

namespace PrismTodo.ViewModels
{
    public class MainPageViewModel : INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IManageUserGroup _manageUserGroup;
        private readonly IManageTodo _manageTodo;
        
        public ReadOnlyObservableCollection<TodoItem> TodoItems { get; }

        public DelegateCommand LoadTodoItemsCommand => new DelegateCommand(() => _manageTodo.LoadAsync());

        public MainPageViewModel(INavigationService navigationService, IManageUserGroup manageUserGroup, IManageTodo manageTodo)
        {
            _navigationService = navigationService;
            _manageUserGroup = manageUserGroup;
            _manageTodo = manageTodo;
            TodoItems = _manageTodo.TodoItems;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
