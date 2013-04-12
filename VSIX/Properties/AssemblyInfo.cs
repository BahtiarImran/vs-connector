//
// Copyright © 2012 ThoughtWorks, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at:
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("Mingle Extension for Visual Studio")]
[assembly: AssemblyDescription("Supports context-relevant use of Mingle within Visual Studio.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ThoughtWorks, Inc.")]
[assembly: AssemblyProduct("Mingle Extension for Visual Studio")]
[assembly: AssemblyCopyright("Copyright © 2012,2013 ThoughtWorks, Inc.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("50B1971A-569D-4BD0-96BC-4F855CDBDBEE")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
//
// 0.8.*.* denotes Alpha phase builds
// 0.9.*.* denotes Beta phase builds

[assembly: AssemblyVersion("1.1.6.*")]
[assembly: InternalsVisibleTo("VsConnectorTests")]
[assembly: InternalsVisibleTo("VsConnectorTests.2012")]