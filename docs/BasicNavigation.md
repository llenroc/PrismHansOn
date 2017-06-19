# 基本の画面遷移

## 別画面へ遷移する  

### TextToSpeechPageの追加



### TextToSpeechPageをDIコンテナへ登録  

```cs
protected override void RegisterTypes()
{
    Container.RegisterTypeForNavigation<MainPage>();
    Container.RegisterTypeForNavigation<TextToSpeechPage>();
}
```

### MainPageViewModelへINavigationServiceのインジェクション  

MainPageViewModelにつぎのコードを追加する。  

```cs
private readonly INavigationService _navigationService;
```

コンストラクタを修正します。  

変更前
```cs
public MainPageViewModel(IDeviceService deviceService)
{
    _deviceService = deviceService;
    Message = Message + " on " + _deviceService.Platform;
}
```

変更後
```cs
public MainPageViewModel(IDeviceService deviceService, INavigationService navigationService)
{
    _deviceService = deviceService;
    _navigationService = navigationService;
    Message = Message + " on " + _deviceService.Platform;
}
```

INavigationServiceをインジェクションする場合、引数名はnavigationServiceである必要があります。

### MainPageViewModelへ画面遷移コマンドの追加

MainPageViewModelにつぎのコードを追加する。  

```cs
public DelegateCommand NavigateToTextToSpeechPageCommand => new DelegateCommand(() =>
{
    _navigationService.NavigateAsync("TextToSpeechPage");
});
```

### MainPage.xamlへ画面遷移ボタンの追加  

## 前画面へ戻る  

### TextToSpeechPageViewModel.csの追加

### TextToSpeechPageViewModel.csへ戻る処理の実装  

```cs
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismHansOn.ViewModels
{
    public class TextToSpeechPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoBackCommand => new DelegateCommand(() =>
        {
            _navigationService.GoBackAsync();
        });

        public TextToSpeechPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
```

### TextToSpeechPage.xamlの修正  

* ViewModelLocator.AutowireViewModelの有効化  
* 戻るボタンの追加  

変更前  
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PrismHansOn.Views.TextToSpeechPage">
    <ContentPage.Content>
        <StackLayout>
            <Label Text="Welcome to Xamarin Forms!" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

変更後
```cs
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mvvm="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             mvvm:ViewModelLocator.AutowireViewModel="True"
             x:Class="PrismHansOn.Views.TextToSpeechPage">
    <ContentPage.Content>
        <StackLayout>
            <Label Text="Welcome to Xamarin Forms!" />
            <Button Text="Go Back" Command="{Binding GoBackCommand}"/>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

## 画面遷移パラメーター  

### MainPageViewModel.csで遷移パラメーターの指定  

変更前  
```cs
public DelegateCommand NavigateToTextToSpeechPageCommand => new DelegateCommand(() =>
{
    _navigationService.NavigateAsync("TextToSpeechPage");
});
```

変更後  
```cs
public DelegateCommand NavigateToTextToSpeechPageCommand => new DelegateCommand(() =>
{
    var navigationParameter = new NavigationParameters();
    navigationParameter.Add("Message", "Hello, NavigationParameter.");
    _navigationService.NavigateAsync("TextToSpeechPage", navigationParameter);
});
```

### TextToSpeechPageViewModel.csへパラメーター受け取り処理の追加  

「Message」パラメーターを格納し、画面へ表示するためのプロパティの追加  
```cs
private string _message;

public string Message
{
    get => _message;
    set => SetProperty(ref _message, value);
}
```

INavigationAwareの宣言の追加  
変更前  
```cs
public class TextToSpeechPageViewModel : BindableBase
```  

変更後  
```cs
public class TextToSpeechPageViewModel : BindableBase, INavigationAware
```  

INavigationAwareインターフェースメソッドの追加  
```cs
```