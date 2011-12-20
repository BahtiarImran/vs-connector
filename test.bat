@echo off
set path=C:\Windows\Microsoft.NET\Framework\v4.0.30319;C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE;
del /S testresults.trx
mstest /testcontainer:build\tests\vsconnectortests.dll /resultsfile:build\tests\testresults.trx
tools\msxsl build\tests\testresults.trx tools\MSBuild-to-NUnit.xslt -o build/tests/testresults.trx.xml

