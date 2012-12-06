@ECHO OFF
DEL /S build\tests\testresults.trx
ECHO Beginning test run.
%MSTEST% /testcontainer:build\tests\VsConnectorTests.dll /resultsfile:build\tests\testresults.trx
ECHO Test run completed. 
ECHO Beginning test result transformation to XUnit.
tools\msxsl build\tests\testresults.trx tools\MSBuild-to-NUnit.xslt -o build/tests/testresults.trx.xml
ECHO Test result transformation to XUnit completed.
ECHO Check for failed tests and tell Go
tools\inspecttrx build\tests\testresults.trx

