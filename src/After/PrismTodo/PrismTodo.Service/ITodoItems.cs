using System.Collections.Generic;

namespace PrismTodo.Service
{
    public interface ITodoItems : IEnumerable<TodoItem>
    {
        int LatestOperationNumber { get; set; }
    }
}