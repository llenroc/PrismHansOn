using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrismTodo.Server.Repositories;
using PrismTodo.Service;

namespace PrismTodo.Server.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller, ITodoService
    {
        [HttpGet("{operationNumber}")]
        public IEnumerable<TodoItemOperation> GetOperations(int operationNumber)
        {
            return TodoRepository.Instance.GetOperations(operationNumber);
        }

        [HttpPost]
        public void Add([FromBody]TodoItem todoItem)
        {
            TodoRepository.Instance.Add(todoItem);
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
