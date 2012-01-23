// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Error List, point to "Suppress Message(s)", and click 
// "In Project Suppression File".
// You do not need to add suppressions to this file manually.

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
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Tw", Scope = "type", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Vsc", Scope = "type", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#.ctor()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#DefineCommandHandler(System.EventHandler,System.ComponentModel.Design.CommandID)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Tw", Scope = "type", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#GetResourceString(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#Initialize()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowCardWindow(ThoughtWorksMingleLib.MingleCard)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowListOfCards(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowListOfPipelineProperties(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "Leavring", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowSettingsWindow(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardBrowserView.CardBrowserViewWindowPane.#OnToolWindowCreated()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardSetView.CardSetViewWindowPane.#OnToolWindowCreated()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardView.CardViewWindowPane.#OnToolWindowCreated()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ExplorerViewWindowPane.#Bind()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ExplorerViewWindowPane.#OnToolWindowCreated()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#SetPropertyValue(System.Reflection.PropertyInfo,System.Object,System.Object,System.Globalization.CultureInfo)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#GetPropertyValue(System.Reflection.PropertyInfo,System.Object,System.Globalization.CultureInfo)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1", Scope = "member", Target = "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#CreateDelegate(System.Type,System.Object,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "XamlGeneratedNamespace.GeneratedInternalTypeHelper.#AddEventHandler(System.Reflection.EventInfo,System.Object,System.Delegate)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1824:MarkAssembliesWithNeutralResourcesLanguage")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "XamlGeneratedNamespace")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#GoLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#MingleLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#SetGoSettings(System.String,System.String,System.Security.SecureString)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsView.SettingsModel.#SetMingleSettings(System.String,System.String,System.Security.SecureString,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#.ctor(System.String,System.String,System.Security.SecureString)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ProjectId", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+TeamMembersDictionary.#Get()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+TeamMembersDictionary.#Get()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.ToString", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+FavoritesDictionary.#Get()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CurrentProjectId", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+FavoritesDictionary.#Get()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CurrentProjectId", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#GetCardsFromFavorite(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#CurrentProjectId")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#FavoriteDictionaryList")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#ProjectDictionaryList")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#TeamMembersDictionaryList")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+TeamMembersDictionary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Secure")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+ProjectsDictionary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+FavoritesDictionary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+CardsCollection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel.#GetCardsFromFavorite(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#CreatedByLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#ModifiedByLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#CreatedByUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#ModifiedByUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#ProjectUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#CardTypeUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerView.ViewModel+Card.#Url")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardSetView.CardSetViewControl.#Bind(ThoughtWorksMingleLib.MingleCardCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardView.CardViewControl.#Bind()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardView.CardViewControl.#OnPropertyComboBoxSelectionChanged(System.Object,System.Windows.Controls.SelectionChangedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardSetViewControl.#Bind(ThoughtWorksMingleLib.MingleCardCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CardSetView", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardSetViewControl.#Bind(ThoughtWorksMingleLib.MingleCardCollection)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#Bind()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "BindPropertyElements", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#Bind()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "BindTopLevelElements", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#Bind()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "ThoughtWorksCoreLib.TraceLog.WriteLine(System.String,System.String)", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardViewControl.#OnPropertyComboBoxSelectionChanged(System.Object,System.Windows.Controls.SelectionChangedEventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel.#CurrentProjectId")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel.#FavoriteList")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel.#GetCardsFromFavorite(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel.#ProjectList")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel.#TeamMembersList")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#CardTypeUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#CreatedByUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#ModifiedByUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#ModifiedByLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#CreatedByLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ViewModel+Card")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#ProjectUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+Card.#Url")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ViewModel+CardsCollection")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ViewModel+FavoritesDictionary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "CurrentProjectId", Scope = "member", Target = "ThoughtWorks.VisualStudio.ViewModel+FavoritesDictionary.#Get()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ViewModel+ProjectsDictionary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ViewModel+Secure")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Scope = "type", Target = "ThoughtWorks.VisualStudio.ViewModel+TeamMembersDictionary")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "ThoughtWorks.VisualStudio.ExplorerViewWindowPane.#Bind()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsModel.#GoLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsModel.#MingleLogin")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsModel.#SetGoSettings(System.String,System.String,System.Security.SecureString)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "login", Scope = "member", Target = "ThoughtWorks.VisualStudio.SettingsModel.#SetMingleSettings(System.String,System.String,System.Security.SecureString,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Transition.#Url")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Transition.#CardTypeUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardTypePropertyDefinition.#Url")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.CardProperty.#CardUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Card.#Url")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Card.#ProjectUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Card.#ModifiedByUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Card.#CreatedByUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Scope = "member", Target = "ThoughtWorks.VisualStudio.Card.#CardTypeUrl")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope = "member", Target = "ThoughtWorks.VisualStudio.TwVscCommandsPackage.#ShowMingleExplorer(System.Object,System.EventArgs)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Mql", Scope = "member", Target = "ThoughtWorks.VisualStudio.IProject.#ExecMql(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "mql", Scope = "member", Target = "ThoughtWorks.VisualStudio.IProject.#ExecMql(System.String)")]
