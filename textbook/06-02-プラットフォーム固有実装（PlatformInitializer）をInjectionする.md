# 共通部分を実装する   

本節では、Xamarin.Formsの共有部分からプラットフォーム固有実装を呼び出す箇所を実装します。  
プラットフォーム固有の実装は後続をご覧ください。  

## ITextToSpeechService.csの追加  

Modelsフォルダに、文字列を読み上げるためのサービスのインターフェース、ITextToSpeechService.csを追加します。  

```cs
namespace PrismHansOn.Models
{
    public interface ITextToSpeechService
    {
        void Speech(string text);
    }
}
```

## MainPageViewModel.csへITextToSpeechService実行する処理を追加する  

ITextToSpeechServiceの実体は、DIコンテナからインジェクションさせます。  
このため、MainPageViewModel.csのコンストラクタでITextToSpeechServiceのインスタンスを受け取り、フィールドへ格納するよう修正します。  

■変更後
```cs
private readonly ITextToSpeechService _textToSpeechService;
public MainPageViewModel(ITextToSpeechService textToSpeechService)
{
    _textToSpeechService = textToSpeechService;
}
```

その上でITextToSpeechServiceを実行するコマンドを追加します。  

```cs
public DelegateCommand SpeakCommand => new DelegateCommand(() =>
{
    _textToSpeechService.Speak(Message);
});
```

## MainPage.xamlからSpeakCommandを呼び出す  

Switchの下に追加
```cs
<Button Text="Speak" Command="{Binding SpeakCommand}"/>
```

## App.csクラスにプラットフォーム別の初期化に対応したコンストラクタを追加する

プラットフォーム固有の実装に対する設定を受け取るため、App.csクラスを修正します。  
PrismHansOnプロジェクトのApp.csクラスを開き、次のコンストラクタを追加してください。  

```cs
public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
{
}
```

## 各プラットフォーム別 ITextToSpeechServiceの実装  

* [iOS](06-02-01-ITextToSpeechServiceの実装-iOS.md)  
* [Android](06-02-02-ITextToSpeechServiceの実装-Android.md)  
* [UWP](06-02-03-ITextToSpeechServiceの実装-UWP.md)  
