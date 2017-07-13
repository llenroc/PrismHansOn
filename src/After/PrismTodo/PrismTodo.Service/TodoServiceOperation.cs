using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTodo.Service
{
    public class TodoServiceOperation
    {
        public int Number { get; set; }
        public OperationType OperationType { get; set; }
        public TodoItem TodoItem { get; set; }
    }
}
