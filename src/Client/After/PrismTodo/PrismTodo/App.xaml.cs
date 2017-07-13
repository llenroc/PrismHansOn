using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Prism.Autofac.Forms;
using PrismTodo.DataStore;
using PrismTodo.Repositories;
using PrismTodo.Views;
using Xamarin.Forms;

namespace PrismTodo
{
    public partial class App
    {
        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync(nameof(MainPage));
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            
            var builder = new ContainerBuilder();
            builder.RegisterType<TodoItemsRepository>().As<ITodoItemsRepository>();
            builder.RegisterType<TodoItemsService>().As<ITodoItemsService>();
            
            builder.Update(Container);
        }
    }
}
