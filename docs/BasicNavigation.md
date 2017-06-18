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

### MainPageViewModelへ画面遷移コマンドの追加