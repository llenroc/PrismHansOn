using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace PrismTodo.DataStore
{
    public class TodoItemsService : ITodoItemsService
    {
        public IReadOnlyList<TodoItem> GetAll()
        {
            try
            {
                var client = new MobileServiceClient("http://helloapiservice.azurewebsites.net");
                var task =
                    client.InvokeApiAsync(
                        "Values", System.Net.Http.HttpMethod.Get, null);
                task.Wait();
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
