To install the Visual Studio Connector execute its VSIX container file, ThoughtWorks.VisualStudio.vsix. Visual Studio must be restarted 
before the extension will appear.

Use the Mingle/Go Visual Studio connector by exposing its Explorer window:

View -> Other windows -> ThoughtWorks Explorer

Debugging TwVsc requires the project properties to start an external program. On the Debug tab of Properties for TwVsc:

Select "Start external program" and point to the Visual Studio IDE, e.g. "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe".
Under Start Options -> Command Line Arguments put this: "/rootsuffix Exp"

Build dependencies:

Visual Studion 2010 with .NET Framework 4.0
Visual Studio 2010 SP1
Visual Studio 2010 SP1 SDK

To build the help file documentation for the MingleLib, GoLib and CoreLib APIs you need Sandcastle and the Sandcastle Help File Builder. 
They can be found here:

http://sandcastle.codeplex.com/
http://shfb.codeplex.com/

Install these programs and open the tw.shfbproj file to build. Output goes into a compiler-generated Help directory. 
The build produces both an HTML web site and a binary .chm file compatible with the Microsoft Help reader.

Readme.

