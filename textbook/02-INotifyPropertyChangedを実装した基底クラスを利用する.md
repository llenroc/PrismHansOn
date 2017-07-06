# INotifyPropertyChangedを実装した基底クラスを利用する

## MainPageViewModel.csの追加  

```cs
using Prism.Mvvm;

namespace PrismHansOn.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _message = "Hello, Prism for Xamarin.Forms!";

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
    }
}
```

## ViewModelをViewのBindingContextに設定する  

変更前
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:PrismHansOn"
             x:Class="PrismHansOn.Views.MainPage">
```

変更後  
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mvvm="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             mvvm:ViewModelLocator.AutowireViewModel="True"
             x:Class="PrismHansOn.Views.MainPage">
```

## ViewModelのプロパティをViewへバインドする

変更前
```xml
<Label Text="Welcome to Xamarin Forms!" 
        VerticalOptions="Center" 
        HorizontalOptions="Center" />
```

変更後  
```xml
<Label Text="{Binding Message}" 
        VerticalOptions="Center" 
        HorizontalOptions="Center" />
```
