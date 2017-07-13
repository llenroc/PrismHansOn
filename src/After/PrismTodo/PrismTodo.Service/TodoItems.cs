using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTodo.Service
{
    public class TodoItems : List<TodoItem>, ITodoItems
    {
        public int LatestOperationNumber { get; set; }
    }
}
