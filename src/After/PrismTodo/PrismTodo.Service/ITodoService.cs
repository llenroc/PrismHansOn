using System.Collections.Generic;

namespace PrismTodo.Service
{
    public interface ITodoService
    {
        IEnumerable<TodoItemOperation> GetOperations(int operationNumber);
        void Add(TodoItem todoItem);
        void Update(TodoItem todoItem);
        void Delete(int id);
    }
}