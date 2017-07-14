using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PrismTodo.Service;

namespace PrismTodo.DataStore
{
    public class TodoServiceClient : ITodoServiceClient
    {
        private readonly MobileServiceClient _client =
            new MobileServiceClient("http://prismtodo.azurewebsites.net");

        public Task<IEnumerable<TodoItemOperation>> GetOperationsAsync(int operationNumber)
        {
            return _client.InvokeApiAsync<IEnumerable<TodoItemOperation>>(
                "Todo/0", System.Net.Http.HttpMethod.Get, null);
        }

        public Task AddAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
