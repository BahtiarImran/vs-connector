// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.

#region Copyright © 2011, 2012 ThoughtWorks, Inc.

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

#endregion


using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "UrlType",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "authUrl",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetBaseMingleUrl(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "ThoughtWorks.VisualStudio")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "ThoughtWorks.VisualStudio.Model")]
[assembly: SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId =
            "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.Object,System.String)"
        , Scope = "member"
        , Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#.ctor()")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.Server.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "IEnumerable", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "PropertyElement", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "RequestType", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "requestType", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(System.Net.WebRequest)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "WebRequest", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(System.Net.WebRequest)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "rq", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(System.Net.WebRequest)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "requestType", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "RequestType", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "RequestType", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "requestType", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetBaseMingleUrl(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "GetBaseMingleUrl", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetBaseMingleUrl(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetBaseMingleUrl(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudioGetUrl", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetBaseMingleUrl(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudioGetUrl", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "urlType", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.UrlHelper.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId =
            "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.Object,System.String)"
        , Scope = "member"
        , Target = "ThoughtWorksCoreLib.TraceLog.#Exception(System.Object,System.Exception)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId =
            "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String,System.String,System.String)"
        ,
        Scope = "member",
        Target = "ThoughtWorksCoreLib.TraceLog.#Exception(System.String,System.String,System.Exception)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "System.Diagnostics.TraceListener.WriteLine(System.String)", Scope = "member",
        Target = "ThoughtWorksCoreLib.TraceLog.#WriteLine(System.Object,System.String)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "System.Diagnostics.TraceListener.WriteLine(System.String)", Scope = "member",
        Target = "ThoughtWorksCoreLib.TraceLog.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member",
        Target = "ThoughtWorksCoreLib.TraceLog.#Exception(System.String,System.String,System.Exception)")]
[assembly:
    SuppressMessage("Microsoft.Performance",
        "CA1810:InitializeReferenceTypeStaticFieldsInline", Scope = "member",
        Target = "ThoughtWorksCoreLib.TraceLog.#.cctor()")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Transition.#RequireComment")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudio", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ModelResponse", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudio", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ModelResponse", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "requestType", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudio", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "RequestType", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ModelResponse", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(ThoughtWorks.VisualStudio.Model.RequestType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudio", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(System.Net.WebRequest)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(System.Net.WebRequest)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ModelResponse", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#Response(System.Net.WebRequest)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudio", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ModelRequest", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.Model.MingleServer.#Request(ThoughtWorks.VisualStudio.Model.RequestType,System.String,ThoughtWorks.VisualStudio.Model.Filters)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "urlType", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "VisualStudio", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "UrlType", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ThoughtWorks", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "ModelGetUrl", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Globalization",
        "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.String)"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleServer.#GetUrl(ThoughtWorks.VisualStudio.Model.UrlType)")]
[assembly:
    SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters",
        MessageId = "name", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.MingleViewModel.#OnPropertyChanged(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.MingleViewModel.#OnPropertyChanged(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.MingleViewModel.#.ctor(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#CreatedByName")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#CreatedOn")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#ModifiedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#ModifiedByName")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#ModifiedOn")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#ProjectIdentifier")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#ProjectName")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#ProjectUri")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#Rank")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#Save()")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#Transitions")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#Type")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#Version")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.CardSet.#Get()")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Model.Card.#CreatedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.GuidsList.#GuidCardViewPersistanceString")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.GuidsList.#GuidGoCommandBmp")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.GuidsList.#GuidMenuAndCommandsPkg")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.GuidsList.#GuidMingleCardCommandBmp")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.GuidsList.#GuidCardSetViewPersistanceString")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "SVsResourceManager",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#GetResourceString(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId =
            "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.Object,System.String)"
        , Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#.ctor()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId =
            "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.Object,System.String)"
        , Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#Initialize()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId =
            "ThoughtWorksCoreLib.TraceLog.WriteLine(new StackFrame().GetMethod().Name,System.Object,System.String)"
        , Scope = "member", Target = "ThoughtWorks.VisualStudio.Model.Card.#Parse(System.Xml.XmlElement)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Tw", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Vsc", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#.ctor()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#DefineCommandHandler(System.EventHandler,System.ComponentModel.Design.CommandID)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Tw", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#GetResourceString(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#Initialize()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowCardWindow(ThoughtWorksMingleLib.MingleCard)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowListOfCards(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowListOfPipelineProperties(System.Object,System.EventArgs)"
        )]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Leavring",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowSettingsWindow(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardBrowserView.CardBrowserViewWindowPane.#OnToolWindowCreated()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardSetView.CardSetViewWindowPane.#OnToolWindowCreated()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardView.CardViewWindowPane.#OnToolWindowCreated()")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ExplorerViewWindowPane.#Bind()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ExplorerViewWindowPane.#OnToolWindowCreated()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        ,
        Target =
            "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#SetPropertyValue(System.Reflection.PropertyInfo,System.Object,System.Object,System.Globalization.CultureInfo)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        ,
        Target =
            "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#GetPropertyValue(System.Reflection.PropertyInfo,System.Object,System.Globalization.CultureInfo)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member"
        ,
        Target =
            "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#CreateDelegate(System.Type,System.Object,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member"
        ,
        Target =
            "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#AddEventHandler(System.Reflection.EventInfo,System.Object,System.Delegate)"
        )]
[assembly: SuppressMessage("Microsoft.Performance", "CA1824:MarkAssembliesWithNeutralResourcesLanguage")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
        Target = "XamlGeneratedNamespace")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#GoLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#MingleLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#SetGoSettings(System.String,System.String,System.Security.SecureString)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#SetMingleSettings(System.String,System.String,System.Security.SecureString,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#.ctor(System.String,System.String,System.Security.SecureString)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ProjectId",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+TeamMembersDictionary.#Get()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+TeamMembersDictionary.#Get()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.ToString",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+FavoritesDictionary.#Get()")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CurrentProjectId",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+FavoritesDictionary.#Get()")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CurrentProjectId",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#GetCardsFromFavorite(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#CurrentProjectId")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#FavoriteDictionaryList")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#ProjectDictionaryList")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#TeamMembersDictionaryList")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+TeamMembersDictionary")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Secure")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+ProjectsDictionary")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+FavoritesDictionary")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+CardsCollection")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#GetCardsFromFavorite(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#CreatedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#ModifiedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#CreatedByUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#ModifiedByUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#ProjectUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#CardTypeUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#Url")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.CardSetView.CardSetViewControl.#Bind(ThoughtWorksMingleLib.MingleCardCollection)"
        )]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardView.CardViewControl.#Bind()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.CardView.CardViewControl.#OnPropertyComboBoxSelectionChanged(System.Object,System.Windows.Controls.SelectionChangedEventArgs)"
        )]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardSetViewControl.#Bind(ThoughtWorksMingleLib.MingleCardCollection)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CardSetView",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardSetViewControl.#Bind(ThoughtWorksMingleLib.MingleCardCollection)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardViewControl.#Bind()")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "BindPropertyElements", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardViewControl.#Bind()")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
        MessageId = "BindTopLevelElements", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardViewControl.#Bind()")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
        MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.CardViewControl.#OnPropertyComboBoxSelectionChanged(System.Object,System.Windows.Controls.SelectionChangedEventArgs)"
        )]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel.#CurrentProjectId")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel.#FavoriteList")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel.#GetCardsFromFavorite(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel.#ProjectList")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel.#TeamMembersList")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#CardTypeUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#CreatedByUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#ModifiedByUrl")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#ModifiedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#CreatedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#ProjectUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#Url")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ViewModel+CardsCollection")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ViewModel+FavoritesDictionary")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CurrentProjectId",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+FavoritesDictionary.#Get()")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ViewModel+ProjectsDictionary")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ViewModel+Secure")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type",
        Target = "ThoughtWorks.VisualStudio.ViewModel+TeamMembersDictionary")]
[assembly:
    SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ExplorerViewWindowPane.#Bind()")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.SettingsModel.#GoLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.SettingsModel.#MingleLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.SettingsModel.#SetGoSettings(System.String,System.String,System.Security.SecureString)"
        )]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.SettingsModel.#SetMingleSettings(System.String,System.String,System.Security.SecureString,System.String)"
        )]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Transition.#Url")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Transition.#CardTypeUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardTypePropertyDefinition.#Url")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.CardProperty.#CardUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#Url")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#ProjectUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#ModifiedByUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#CreatedByUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#CardTypeUrl")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mql",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.IProject.#ExecMql(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "mql",
        Scope = "member", Target = "ThoughtWorks.VisualStudio.IProject.#ExecMql(System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#CreatedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.Card.#ModifiedByLogin")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.MingleSettings.#Login")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.MingleSettings.#Set(System.String,System.String,System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TeamMember.#Login")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member",
        Target = "ThoughtWorks.VisualStudio.ViewModel.#.ctor(System.String,System.String,System.String)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ExplorerViewControl"
        , Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ViewModel",
        Scope = "member",
        Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly:
    SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "System.Int32.Parse(System.String)", Scope = "member",
        Target =
            "ThoughtWorks.VisualStudio.ViewModel.#GetCardList(System.Collections.Generic.IEnumerable`1<System.String>)")
]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Controls.TextBox.set_Text(System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel.#MakeTextBox(ThoughtWorks.VisualStudio.CardProperty,ThoughtWorks.VisualStudio.Card)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardListWindow.#SearchForCards()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardListWindow.#OnWindowIsInitialized(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardSetViewControl.#OnSelectionChanged(System.Object,System.Windows.Controls.SelectionChangedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnPropertyComboBoxSelectionChanged(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnButtonChooseCardClick(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnPropertyTextBoxLostFocus(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnTransitionButtonClick(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnButtonSaveCommentClicked(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#UserControlInitialized(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#OnProjectSelectionChanged(System.Object,System.Windows.Controls.SelectionChangedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#OnButtonClick(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.MurmurViewControl.#RefreshMurmurs()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.MurmurViewControl.#OnClickButtonMurmur(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#OnFavoritesTreeCardDoubleClick(System.Object,System.Windows.Input.MouseButtonEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#OnFavoritesTreeItemMouseDoubleClick(System.Object,System.Windows.Input.MouseButtonEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#ShowCardViewToolWindow(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#ShowCardViewToolWindow(ThoughtWorks.VisualStudio.Card)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#ShowMurmurWindow()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#ShowMurmurWindow()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#BindManagedProperties()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Controls.TextBox.set_Text(System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnButtonChooseCardClick(System.Object,System.Windows.RoutedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#BindProjectList()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewControl.#OnButtonClick(System.Object,System.Windows.RoutedEventArgs)")]
