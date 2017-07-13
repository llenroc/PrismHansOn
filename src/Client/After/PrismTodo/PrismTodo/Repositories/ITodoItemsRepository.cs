using System.Collections.Generic;

namespace PrismTodo.Repositories
{
    public interface ITodoItemsRepository
    {
        IReadOnlyList<TodoItem> GeTodoItems();
    }
}
