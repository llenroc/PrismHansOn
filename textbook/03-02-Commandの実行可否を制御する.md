# コマンドの実行状態を切り替える  

## ViewModelを修正する  

Updateの可否を表すフィールドとプロパティを追加する。  

```cs
private bool _canUpdateMessage;

public bool CanUpdateMessage
{
    get => _canUpdateMessage;
    set => SetProperty(ref _canUpdateMessage, value);
}
```

UpdateMessageCommandでCanUpdateMessageを監視する。  

変更前  
```cs
public DelegateCommand UpdateMessageCommand => new DelegateCommand(() =>
{
    Message = "Updated message.";
});
```

変更後  
```cs
public DelegateCommand UpdateMessageCommand => new DelegateCommand(() =>
{
    Message = "Updated message.";
}).ObservesCanExecute(() => CanUpdateMessage);
```

## Viewを修正する  

Buttonの後ろに、ViewModelのCanUpdateCommandをバインドしたSwitchを追加する。  

```xml
<Switch IsToggled="{Binding CanUpdateMessage}"/>
```

