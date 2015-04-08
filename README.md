# LoadAssembly for PCL (Support for Desktop, iOS and Android only)
Shims `LoadAssembly(byte[] rawAssembly)` for for Windows Desktop, Xamarin iOS and Xamarin Android when running under `portable-net45+wp8+wpa81+win8+MonoAndroid10+MonoTouch10+Xamarin.iOS10`. WinRT projects will throw a NotImplementedException if this is called. iOS can only use this on the simulator. The PCL `Assembly` class only supports loading from the GAC by name; this lets you load arbitrary assemblies as you can when running a normal .NET project.

NuGet package is available [here](https://www.nuget.org/packages/rda.LoadAssemblyForPCL). It must be installed in your PCL project and each platform project. 

##### Why would you need something like this? 
There really aren't many use cases. This doesn't do any magic tricks and you are still subject to native platform constraints when it comes to loading assemblies at runtime. Specifically, you can't do it on WinRT, and on iOS you can only do it while running under the Simulator. 

##### That didn't answer the question!
Ok - If you want to code against the popular `portable-net45+wp8+wpa81+win8+MonoAndroid10+MonoTouch10+Xamarin.iOS10` profile, and you want to be able to load assemblies at runtime on platforms that support it, and you're happy to work around it or disable the functionality if you find you're running on a platform that doesn't support it, then this is for you. 

##### Cool, how do I do it? 
First, be a good citizen and check that you're running on a platform that supports runtime assembly load:

```csharp
/* returns true if we can do runtime assembly loads */
var supported = Loader.RuntimeLoadAvailable;
```

Once you're satisfied, load an assembly using:
```csharp
byte[] rawAssemblyData = /* your assembly bytes here */ 
var assembly = Loader.LoadAssembly(rawAssemblyData);
```

and you're good to go. 

##### What about all the other `Load` overloads?
It's on the radar but I'll take a PR -- for any path/file-related overloads, I'd expect [PCLStorage](https://github.com/dsplaisted/PCLStorage) to be useful.
