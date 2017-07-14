using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using PrismTodo.DataStore;
using PrismTodo.Repositories;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public class ManageTodo : BindableBase, IManageTodo
    {
        private readonly ITodoRepository _todoRepository;

        public ReadOnlyObservableCollection<TodoItem> TodoItems { get; }

        public Task LoadAsync()
        {
            return _todoRepository.LoadAsync();
        }

        public ManageTodo(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            TodoItems = _todoRepository.TodoItems;
        }


    }
}
