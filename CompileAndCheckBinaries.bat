echo Working dir: %cd%

set config=%1
if "%config%" == "" (
   set config=Release
)

"C:\Program Files (x86)\MSBuild\14.0\bin\msbuild" QRCoder.Unity\QRCoder.Unity.csproj /p:Configuration="%config%";VisualStudioVersion=14.0 /tv:14.0 /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false /t:Rebuild
copy "QRCoder.Unity\bin\%config%\net35\*.dll" "Build\lib\net35"
del /F /S /Q "QRCoder\bin"
del /F /S /Q "QRCoder\obj"

"C:\Program Files (x86)\MSBuild\14.0\bin\msbuild" QRCoder.Unity\QRCoder.Unity.NET40.csproj /p:Configuration="%config%";VisualStudioVersion=14.0 /tv:14.0 /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false /t:Rebuild
copy "QRCoder.Unity\bin\%config%\net40\*.dll" "Build\lib\net40"
del /F /S /Q "QRCoder\bin"
del /F /S /Q "QRCoder\obj"

certUtil -hashfile "QRCoder.Unity\bin\Release\net35\QRCoder.Unity.dll" md5
certUtil -hashfile "QRCoder.Unity\bin\Release\net40\QRCoder.Unity.dll" md5

powershell -Command "[Reflection.Assembly]::ReflectionOnlyLoadFrom(\"%cd%\QRCoder.Unity\bin\Release\net35\QRCoder.Unity.dll\").ImageRuntimeVersion"
powershell -Command "[Reflection.Assembly]::ReflectionOnlyLoadFrom(\"%cd%\QRCoder.Unity\bin\Release\net40\QRCoder.Unity.dll\").ImageRuntimeVersion"

pause
