using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PrismTodo.DataStore;
using PrismTodo.Service;

namespace PrismTodo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ITodoServiceClient _todoServiceClient;
        
        private readonly ObservableCollection<TodoItem> _todoItems = new ObservableCollection<TodoItem>();

        public ReadOnlyObservableCollection<TodoItem> TodoItems => new ReadOnlyObservableCollection<TodoItem>(_todoItems);
        public TodoRepository(ITodoServiceClient todoServiceClient)
        {
            _todoServiceClient = todoServiceClient;
        }

        public async Task LoadAsync()
        {
            var operations = await _todoServiceClient.GetOperationsAsync(0);
            foreach (var operation in operations)
            {
                _todoItems.Add(operation.TodoItem);
            }
        }
    }
}
