set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.3
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

echo Working dir: %cd%

echo Create template folders

mkdir Build
mkdir Build\lib
mkdir Build\lib\net35
mkdir Build\lib\net40
del README.md

echo Compile single projects

echo Restoring packages - Custom 3.5
Tools\nuget.exe install QRCoder.Unity\packages.config -OutputDirectory packages -Framework net35

"C:\Program Files (x86)\MSBuild\14.0\bin\msbuild" QRCoder.Unity\QRCoder.Unity.csproj /p:Configuration="%config%";VisualStudioVersion=14.0 /tv:14.0 /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false /t:Rebuild
copy "QRCoder.Unity\bin\%config%\net35\*.dll" "Build\lib\net35"
del /F /S /Q "QRCoder\bin"
del /F /S /Q "QRCoder\obj"

echo Restoring packages - Custom 4.5
Tools\nuget.exe install QRCoder.Unity\packages.config -OutputDirectory packages -Framework net45

"C:\Program Files (x86)\MSBuild\14.0\bin\msbuild" QRCoder.Unity\QRCoder.Unity.NET40.csproj /p:Configuration="%config%";VisualStudioVersion=14.0 /tv:14.0 /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false /t:Rebuild
copy "QRCoder.Unity\bin\%config%\net40\*.dll" "Build\lib\net40"
del /F /S /Q "QRCoder\bin"
del /F /S /Q "QRCoder\obj"

echo Assembly information

powershell -Command "[Reflection.Assembly]::ReflectionOnlyLoadFrom(\"%cd%\Build\lib\net35\QRCoder.Unity.dll\").ImageRuntimeVersion"
certUtil -hashfile "Build\lib\net35\QRCoder.dll" md5

powershell -Command "[Reflection.Assembly]::ReflectionOnlyLoadFrom(\"%cd%\Build\lib\net40\QRCoder.Unity.dll\").ImageRuntimeVersion"
certUtil -hashfile "Build\lib\net40\QRCoder.dll" md5

echo Build package
call %NuGet% pack "QRCoder.Unity.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"
