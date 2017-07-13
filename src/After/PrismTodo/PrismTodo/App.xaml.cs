using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Autofac.Forms;
using Xamarin.Forms;
using PrismTodo.Views;

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
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
