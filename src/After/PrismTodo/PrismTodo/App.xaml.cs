using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Prism.Autofac.Forms;
using PrismTodo.Usecases;
using Xamarin.Forms;
using PrismTodo.Views;

namespace PrismTodo
{
    public partial class App
    {
        protected override void OnInitialized()
        {
            if (Container.Resolve<IManageUserGroup>().SelectedUserGroup())
            {
                NavigationService.NavigateAsync("NavigationPage/MainPage");
            }
            else
            {
                NavigationService.NavigateAsync("NavigationPage/SelectUserGroupPage");
            }
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SelectUserGroupPage>();

            var builder = new ContainerBuilder();
            
            // Usecases
            builder.RegisterType<ManageUserGroup>().As<IManageUserGroup>();
            builder.RegisterType<ManageTodo>().As<IManageTodo>();
            
            builder.Update(Container);
            Container.RegisterTypeForNavigation<SelectUserGroupPage>();
        }
    }
}
