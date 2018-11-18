# QRCoder.Unity
[![qrcoder-unity MyGet Build Status](https://www.myget.org/BuildSource/Badge/qrcoder-unity?identifier=ebdfbc4c-0c57-4f3d-9afd-1f9a0abde8ca)](https://www.myget.org/feed/Packages/qrcoder-unity)
## Info 

QRCoder.Unity is an extension for the popular QRCoder.NET library. It allows you to render QRCodes as `Texture2D` objetcs for usage in Unity projects. Please open issues in this repository only if they are Unity specific. For general problems/ideas/enhancement requests concerning the QR code funtionalities, please open an issue in the [main QRCoder repository](https://github.com/codebude/QRCoder).

For usage information see:
[**QRCode Wiki**](https://github.com/codebude/QRCoder/wiki) and especially the page about the Unity renderer: [UnityQRCodeRenderer in detail](https://github.com/codebude/QRCoder/wiki/Advanced-usage---QR-Code-renderers#27-unityqrcode-renderer-in-detail)
 
 
## Installation

Either checkout this Github repository or install QRCoder.Unity via NuGet Package Manager. If you want to use NuGet just search for "QRCoder.Unity" or run the following command in the NuGet Package Manager console:
```bash
PM> Install-Package QRCoder.Unity
```

*Note: The NuGet feed contains only **stable** releases. If you wan't the latest build add one of the following urls to the "Package Sources" of Visual Studio's NuGet Package Manager options.*

*NuGet V3 feed URL (Visual Studio 2015+):* `https://www.myget.org/F/qrcoder-unity/api/v3/index.json`

*NuGet V2 feed URL (Visual Studio 2012+):* `https://www.myget.org/F/qrcoder-unity/api/v2`

 
## Legal information and credits

QRCoder.Unity is project by [Raffael Herrmann](http://raffaelherrmann.de) and was first released 
in 11/2018. It's licensed under the MIT license and based on the work of [QRCoder](https://github.com/codebude/QRCoder).