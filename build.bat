C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild /t:Rebuild /p:configuration=%1 /fileLogger /flp:logfile=buildlog.txt /flp1:logfile=builderrors.txt;errorsonly /flp2:logfile=buildwarnings.txt;warningsonly vsc.sln

