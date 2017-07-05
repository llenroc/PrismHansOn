# ITextToSpeechServiceの実装：iOS  

## ITextToSpeechServiceの実装クラスを作成する  

PrismHansOn.UWPプロジェクトにTextToSpeechService.csクラスを作成する  

```cs
using System;
using Windows.UI.Xaml.Controls;
using PrismHansOn.Models;

public class TextToSpeechService : ITextToSpeechService
{
    public async void Speak(string text)
    {
        var mediaElement = new MediaElement();
        var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
        var stream = await synth.SynthesizeTextToStreamAsync(text);

        mediaElement.SetSource(stream, stream.ContentType);
        mediaElement.Play();
    }
}
```

## DIコンテナへTextToSpeechServiceを登録する  

PrismHansOn.UWPプロジェクトのMainPage.xaml.csを開き、コンストラクタの下に内部クラスPlatformInitializerを作成する。  

```cs
private class PlatformInitializer : IPlatformInitializer
{
    public void RegisterTypes(IContainer container)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<TextToSpeechService>().As<ITextToSpeechService>().SingleInstance();
        builder.Update(container);
    }
}
```

PlatformInitializerをAppクラスにインジェクションする。  
MainPage.xaml.csを修正する。  

■変更前  
```cs
public MainPage()
{
    this.InitializeComponent();

    LoadApplication(new PrismHansOn.App());
}
```

■変更後
```cs
public MainPage()
{
    this.InitializeComponent();

    LoadApplication(new PrismHansOn.App(new PlatformInitializer()));
}
```