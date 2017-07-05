# ITextToSpeechServiceの実装：iOS  

## ITextToSpeechServiceの実装クラスを作成する  

PrismHansOn.AndroidプロジェクトにTextToSpeechService.csクラスを作成する  

```cs
using Android.Speech.Tts;
using PrismHansOn.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PrismHansOn.Droid
{
    public class TextToSpeechService : Java.Lang.Object, ITextToSpeechService, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speaker;
        string _text;

        public void Speak(string text)
        {
            _text = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(Forms.Context, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                _speaker.Speak(_text, QueueMode.Flush, p);
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                _speaker.Speak(_text, QueueMode.Flush, p);
            }
        }
        #endregion
    }
}
```

## DIコンテナへTextToSpeechServiceを登録する  

PrismHansOn.AndroidプロジェクトのMainActivityを開き、OnCreateメソッドの下に内部クラスPlatformInitializerを作成する。  

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
MainActivityを修正する。  

■変更前  
```cs
protected override void OnCreate(Bundle bundle)
{
    ...
    LoadApplication(new App());
}
```

■変更後
```cs
protected override void OnCreate(Bundle bundle)
{
    ...
    LoadApplication(new App(new PlatformInitializer()));
}
```