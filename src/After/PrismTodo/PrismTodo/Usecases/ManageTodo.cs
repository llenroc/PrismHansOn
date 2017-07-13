using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Mvvm;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public class ManageTodo : BindableBase, IManageTodo
    {
        private ReadOnlyObservableCollection<TodoItem> _todoItems;

        public ReadOnlyObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set => SetProperty(ref _todoItems, value);
        }
    }
}
