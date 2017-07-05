# NavigationPageを利用する

## TextToSpeechPage.xamlへタイトルの追加  

変更前
```cs
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mvvm="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             mvvm:ViewModelLocator.AutowireViewModel="True"
             x:Class="PrismHansOn.Views.TextToSpeechPage">
```

変更後（Titleの追加）
```cs
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mvvm="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             mvvm:ViewModelLocator.AutowireViewModel="True"
             x:Class="PrismHansOn.Views.TextToSpeechPage"
             Title="Text to Speech Page">
```

## App.xaml.csでNavigationPageのDIコンテナへの登録  

変更前  
```cs
protected override void RegisterTypes()
{
    Container.RegisterTypeForNavigation<MainPage>();
    Container.RegisterTypeForNavigation<TextToSpeechPage>();
}
```

* Xamarin.Forms名前空間のusing宣言の追加  
* NavigationPageをContainerへ登録  

変更後  
```cs
using Xamarin.Forms;
// 省略
// ...
protected override void RegisterTypes()
{
    Container.RegisterTypeForNavigation<MainPage>();
    Container.RegisterTypeForNavigation<TextToSpeechPage>();
    Container.RegisterTypeForNavigation<NavigationPage>();
}
```

## App.xaml.csでNavigationPageを利用した画面遷移へ変更  

変更前  
```cs
NavigationService.NavigateAsync(nameof(MainPage));
```

変更後
```cs
NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainPage)}");
```  
