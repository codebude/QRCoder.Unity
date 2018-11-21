# QRCoder.Unity
[![qrcoder-unity MyGet Build Status](https://www.myget.org/BuildSource/Badge/qrcoder-unity?identifier=ebdfbc4c-0c57-4f3d-9afd-1f9a0abde8ca&kill_cache=1)](https://www.myget.org/feed/Packages/qrcoder-unity)
## Info 

QRCoder.Unity is an extension for the popular QRCoder.NET library. It allows you to render QRCodes as `Texture2D` objetcs for usage in Unity projects. Please open issues in this repository only if they are Unity-specific. For general problems/ideas/enhancement requests concerning the QR code funtionalities, please open an issue in the [main QRCoder repository](https://github.com/codebude/QRCoder).

For usage information see the **demo code below**. For more general information check the [**QRCoder Wiki**](https://github.com/codebude/QRCoder/wiki).
 
 
## Installation

Either checkout this Github repository or install QRCoder.Unity via NuGet Package Manager. If you want to use NuGet just search for "QRCoder.Unity" or run the following command in the NuGet Package Manager console:
```bash
PM> Install-Package QRCoder.Unity
```
  
*Note: The NuGet feed contains only **stable** releases. If you wan't the latest build add one of the following urls to the "Package Sources" of Visual Studio's NuGet Package Manager options.*

*NuGet V3 feed URL (Visual Studio 2015+):* `https://www.myget.org/F/qrcoder-unity/api/v3/index.json`

*NuGet V2 feed URL (Visual Studio 2012+):* `https://www.myget.org/F/qrcoder-unity/api/v2`


## Usage & Demos

*Note: For a complete up'n'running solution have a look at the [demo project](https://github.com/codebude/QRCoder.Unity/tree/master/QRCoder.Unity.Demo), provided in this repository.*
![Demo animation](/Assets/QRCoder.Unity_demo.gif "Demo app from this repository")

### Preparation
For use in Unity projects you should install the QRCoder.Unity via NuGet package manager for Unity3D. So, if not done, you should install [NuGet for Unity](https://github.com/GlitchEnzo/NuGetForUnity) first, before doing the next steps. (If you install the package via NuGet from Visual Studio/Monodevelop, Unity won't recognize the DLLs correctly.) After installation of NuGet for Unity, restart the Unity IDE.

### General usage
To use QRCoder.Unity in an Unity project do the following steps:  
- Install the package `QRCoder.Unity` via NuGet for Unity package manager. (If it won't install, check the note for Linux/MacOS users in the next section.)
- Add a new script (or edit an existing script).
- Add the following using statements to the script's header section
```csharp
using QRCoder;
using QRCoder.Unity;
```
- Create the QR code and render it as `Texture2D`.
```csharp
QRCodeGenerator qrGenerator = new QRCodeGenerator();
QRCodeData qrCodeData = qrGenerator.CreateQrCode("Hello world!", QRCodeGenerator.ECCLevel.Q);
UnityQRCode qrCode = new UnityQRCode(qrCodeData);
Texture2D qrCodeAsTexture2D = qrCode.GetGraphic(20);
```
- Attach the QR code texture to a game object. (The following example uses an cube object named "Cube".)
```csharp
GameObject.Find("Cube").GetComponent<Renderer>().material.mainTexture = qrCodeAsTexture2D;
```
  
## Legal information and credits

QRCoder.Unity is project by [Raffael Herrmann](http://raffaelherrmann.de) and was first released 
in 11/2018. It's licensed under the MIT license and based on the work of [QRCoder](https://github.com/codebude/QRCoder).
