using System.Collections.Generic;
using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.DataStore
{
    public interface ITodoServiceClient
    {
        Task<IEnumerable<TodoItemOperation>> GetOperationsAsync(int operationNumber);
        Task AddAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(int id);

    }
}