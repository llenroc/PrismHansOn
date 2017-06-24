# Prismをアプリケーションに適用する

今回は、DIコンテナにAutofacを利用する想定で進めます。  

## NuGetからパッケージをインストールする  

NuGetで「prism autofac」で検索し、Prism.Forms.Autofacをソリューション内のすべてのプロジェクトにインストールします。  
インストールされるAutofacが最新版ではありませんが、最新版は.NET Standard版のみの為、ここでは少し古い3.5.2を利用する想定で進めます。  

## Appの親クラスをPrismApplicationに変更する  

App.xaml
```cs
<?xml version="1.0" encoding="utf-8" ?>
<autofac:PrismApplication xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:autofac="clr-namespace:Prism.Autofac;assembly=Prism.Autofac.Forms"
             x:Class="PrismHansOn.App">
</autofac:PrismApplication>
```

App.xaml.cs
```cs
using Prism.Autofac.Forms;

namespace PrismHansOn
{
	public partial class App
	{
		protected override void RegisterTypes()
		{
		}

		protected override void OnInitialized()
		{
		}
	}
}
```

## DIコンテナにMainPageを登録する  

App.xaml.cs
```cs
protected override void RegisterTypes()
{
	Container.RegisterTypeForNavigation<MainPage>();
}
```

## Mainページへ画面遷移する  

App.xaml.cs
```cs
protected override void OnInitialized()
{
	NavigationService.NavigateAsync(nameof(MainPage));
}
```

