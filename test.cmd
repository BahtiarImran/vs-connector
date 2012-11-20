del /S build\tests\testresults.trx
%MSTEST% /testcontainer:build\tests\VsConnectorTests.dll /resultsfile:build\tests\testresults.trx
tools\msxsl build\tests\testresults.trx tools\MSBuild-to-NUnit.xslt -o build/tests/testresults.trx.xml