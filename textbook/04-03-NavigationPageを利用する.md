# NavigationPageを利用する

## App.xaml.csでNavigationPageのDIコンテナへの登録  

変更前  
```cs
protected override void RegisterTypes()
{
    Container.RegisterTypeForNavigation<MainPage>();
    Container.RegisterTypeForNavigation<TextToSpeechPage>();
}
```

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
```  
