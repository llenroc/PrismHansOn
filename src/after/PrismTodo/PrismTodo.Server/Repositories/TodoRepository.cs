using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrismTodo.Service;

namespace PrismTodo.Server.Repositories
{
    public class TodoRepository : ITodoService
    {
        public static TodoRepository Instance { get; } = new TodoRepository();
        
        private List<TodoItemOperation> _operations = new List<TodoItemOperation>();
        
        private TodoRepository()
        {
            // Add Initial Item
            AddTodoItems(UserGroup.Group1);
        }

        public IEnumerable<TodoItemOperation> GetOperations(int operationNumber)
        {
            lock (_operations)
            {
                return _operations.Where(x => operationNumber <= x.Number);
            }
        }

        public void Add(TodoItem todoItem)
        {
            lock (_operations)
            {
                todoItem.Id = _operations.Count == 0 ? 0 : _operations.Max(x => x.TodoItem.Id) + 1;
                _operations.Add(
                    new TodoItemOperation
                    {
                        Number = _operations.Count,
                        OperationType = OperationType.Add,
                        TodoItem = todoItem
                    });
            }
        }

        public void Update(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        private void AddTodoItems(UserGroup userGroup)
        {
            Add(new TodoItem { Title = "First Item", Owner = userGroup, Deadline = DateTime.Today.AddDays(10) });
            Add(new TodoItem { Title = "Second Item", Owner = userGroup, Deadline = DateTime.Today.AddDays(20) });
        }
    }
}
