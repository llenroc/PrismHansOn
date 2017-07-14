﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.Usecases
{
    public interface IManageTodo
    {
        ReadOnlyObservableCollection<TodoItem> TodoItems { get; }

        Task LoadAsync();
    }
}