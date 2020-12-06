## Vibrate Plugin for Xamarin and Windows
Simple and elegant way to trigger the vibration on a device in your Xamarin.iOS, Xamarin.Android, Windows, and Xamarin.Forms projects.

### Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Vibrate [![NuGet](https://img.shields.io/nuget/v/Xam.Plugins.Vibrate.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugins.Vibrate/)
* Install into your PCL project and Client projects.

Build status: ![Build status](https://jamesmontemagno.visualstudio.com/_apis/public/build/definitions/6b79a378-ddd6-4e31-98ac-a12fcd68644c/12/badge)

### The Future: [Xamarin.Essentials](https://docs.microsoft.com/xamarin/essentials/index?WT.mc_id=friends-0000-jamont)

I have been working on Plugins for Xamarin for a long time now. Through the years I have always wanted to create a single, optimized, and official package from the Xamarin team at Microsoft that could easily be consumed by any application. The time is now with [Xamarin.Essentials](https://docs.microsoft.com/xamarin/essentials/index?WT.mc_id=friends-0000-jamont), which offers over 50 cross-platform native APIs in a single optimized package. I worked on this new library with an amazing team of developers and I highly highly highly recommend you check it out.

I will continue to work and maintain my Plugins, but I do recommend you checkout Xamarin.Essentials to see if it is a great fit your app as it has been for all of mine!

### Platform Support

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 7+|
|Xamarin.Android|API 10+|
|Windows 10 UWP|10+|


### API Usage

To gain access to the Vibrate class simply use this method:

```csharp
var v = CrossVibrate.Current;
v.Vibration(TimeSpan.FromSeconds(1)); // 1 second vibration
```

#### Methods

```csharp
/// <summary>
/// Vibrate the phone for specified amount of time
/// </summary>
/// <param name="vibrateSpan">Time to vibrate. 500ms is default</param>
void Vibration(TimeSpan? vibrateSpan = null);
```


#### Platform Tweaks

**iOS**
There is no API to vibrate for a specific amount of time, so it will vibrate for the default time the system specifies (around 500 milliseconds)..

**Android**
The `android.permission.VIBRATE` permission will automatically be added for you into your AndroidManifest.xml


#### Contributions
Contributions are welcome! If you find a bug please report it and if you want a feature please report it.

If you want to contribute code please file an issue and create a branch off of the current dev branch and file a pull request.

#### License
Under MIT, see LICENSE file.
