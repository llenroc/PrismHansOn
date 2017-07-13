using System.Collections.Generic;

namespace PrismTodo.Service
{
    public interface ITodoService
    {
        ITodoItems GetTodoItems();
        IEnumerable<TodoServiceOperation> GetOperations(int operationNumber);
        void Add(TodoItem todoItem);
        void Update(TodoItem todoItem);
        void Delete(int id);
    }
}