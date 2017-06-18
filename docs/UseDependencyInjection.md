# Dependency Injectionを利用する  

## IDeviceServiceを利用する  

MainPageViewModelにつぎのコードを追加する。  

```cs
private readonly IDeviceService _deviceService;
public MainPageViewModel(IDeviceService deviceService)
{
    _deviceService = deviceService;
    Message = Message + " on " + _deviceService.Platform;
}
```

