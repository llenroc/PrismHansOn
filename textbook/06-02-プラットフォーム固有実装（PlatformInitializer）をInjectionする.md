# 固有サービスをInjectionする  

## ITextToSpeechService.csの追加  

ModelsフォルダにITextToSpeechService.csを追加 

```cs
namespace PrismHansOn.Models
{
    public interface ITextToSpeechService
    {
        void Speech(string text);
    }
}
```

## TextToSpeechPageViewModelを修正する  

TextToSpeechPageViewModelへITextToSpeechServiceをインジェクションする  
■変更前  
```cs
public TextToSpeechPageViewModel(INavigationService navigationService)
{
    _navigationService = navigationService;
}
```

■変更後
```cs
private readonly ITextToSpeechService _textToSpeechService;
public TextToSpeechPageViewModel(INavigationService navigationService, ITextToSpeechService textToSpeechService)
{
    _navigationService = navigationService;
    _textToSpeechService = textToSpeechService;
}
```

ITextToSpeechServiceを実行するコマンドを追加する  

```cs
public DelegateCommand SpeakCommand => new DelegateCommand(() =>
{
    _textToSpeechService.Speak(Message);
});
```

## TextToSpeechPage.xamlからSpeakCommandを呼び出す  

戻るボタンの下に追加
```cs
<Button Text="Speak" Command="{Binding SpeakCommand}"/>
```

## App.csクラスにプラットフォーム別の初期化に対応したコンストラクタを追加する

PrismHansOnプロジェクトのApp.csクラスを開き、次のコンストラクタを追加する。

```cs
public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
{
}
```

## 各プラットフォーム別 ITextToSpeechServiceの実装  

* [iOS](06-02-01-ITextToSpeechServiceの実装-iOS.md)  
* [Android](06-02-02-ITextToSpeechServiceの実装-Android.md)  
* [UWP](06-02-03-ITextToSpeechServiceの実装-UWP.md)  
