using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismTodo.DataStore;

namespace PrismTodo.Repositories
{
    public class TodoItemsRepository : ITodoItemsRepository
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodoItemsRepository(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        public IReadOnlyList<TodoItem> GeTodoItems()
        {
            return _todoItemsService.GetAll();
        }
    }
}
