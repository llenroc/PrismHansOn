# ViewのイベントをViewModelへ通知する

DelegateCommandを利用しメッセージを更新する  

## ViewModelにメッセージを更新するコマンドを追加する

Messageプロパティの直下にUpdateMessageCommandプロパティを追加する。  

```cs
public DelegateCommand UpdateMessageCommand => new DelegateCommand(() =>
{
	Message = "Updated message.";
});
```

## MainPageにボタンを追加しUpdateMessageCommandを実行する

変更前
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mvvm="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             mvvm:ViewModelLocator.AutowireViewModel="True"
             x:Class="PrismHansOn.Views.MainPage">

	<Label Text="{Binding Message}" 
           VerticalOptions="Center" 
           HorizontalOptions="Center" />

</ContentPage>
```

変更後
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mvvm="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             mvvm:ViewModelLocator.AutowireViewModel="True"
             x:Class="PrismHansOn.Views.MainPage">

    <StackLayout VerticalOptions="Center" HorizontalOptions="Center">
        <Label Text="{Binding Message}" 
               VerticalOptions="Center" 
               HorizontalOptions="Center" />
        <Button Text="Update Message" Command="{Binding UpdateMessageCommand}"/>
    </StackLayout>

</ContentPage>
```