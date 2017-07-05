# ITextToSpeechServiceの実装：iOS  

## ITextToSpeechServiceの実装クラスを作成する  

PrismHansOn.iOSプロジェクトにTextToSpeechService.csクラスを作成する  

```cs
using AVFoundation;
using PrismHansOn.Models;

namespace PrismHansOn.iOS
{
    public class TextToSpeechService : ITextToSpeechService
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}
```

## DIコンテナへTextToSpeechServiceを登録する  

PrismHansOn.iOSプロジェクトのAppDelegateを開き、FinishedLaunchingメソッドの下に内部クラスPlatformInitializerを作成する。  

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
AppDelegateのFinishedLaunchingを修正する。  

■変更前  
```cs
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    global::Xamarin.Forms.Forms.Init();
    LoadApplication(new App());

    return base.FinishedLaunching(app, options);
}
```

■変更後
```cs
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    global::Xamarin.Forms.Forms.Init();
    LoadApplication(new App(new PlatformInitializer()));

    return base.FinishedLaunching(app, options);
}
```