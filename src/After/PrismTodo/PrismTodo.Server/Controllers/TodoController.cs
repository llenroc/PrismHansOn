using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrismTodo.Service;

namespace PrismTodo.Server.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller, ITodoService
    {
        [HttpGet]
        public ITodoItems GetTodoItems()
        {
            return new TodoItems();
        }

        [HttpGet("{operationNumber}")]
        public IEnumerable<TodoServiceOperation> GetOperations(int operationNumber)
        {
            return null;
        }

        [HttpPost]
        public void Add([FromBody]TodoItem todoItem)
        {
        }
        
        [HttpPut]
        public void Update([FromBody]TodoItem todoItem)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
