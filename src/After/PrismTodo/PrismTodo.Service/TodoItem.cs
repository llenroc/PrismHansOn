using System;
using System.Collections.Generic;
using System.Text;

namespace PrismTodo.Service
{
    public class TodoItem
    {
        public int Id { get; set; }
        public UserGroup Owner { get; set; }
        public string Title { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
