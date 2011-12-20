@echo off
set path=C:\Windows\Microsoft.NET\Framework\v4.0.30319;C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE
msbuild /t:Rebuild /p:configuration=%1 /fileLogger /flp:logfile=buildlog.txt /flp1:logfile=builderrors.txt;errorsonly /flp2:logfile=buildwarnings.txt;warningsonly vsc.sln

