using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using PrismTodo.Repositories;

namespace PrismTodo.ViewModels
{
    public class MainPageViewModel : INavigationAware
    {
        private readonly ITodoItemsRepository _todoItemsRepository;

        public MainPageViewModel(ITodoItemsRepository todoItemsRepository)
        {
            _todoItemsRepository = todoItemsRepository;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            _todoItemsRepository.GeTodoItems();
        }
    }
}
