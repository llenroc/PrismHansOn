using System.Collections.Generic;

namespace PrismTodo.DataStore
{
    public interface ITodoItemsService
    {
        IReadOnlyList<TodoItem> GetAll();
    }
}