#pragma checksum "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d964d4a736ea807f84bff9b4b1159e20a3121f7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_AccountLanguages_Default), @"mvc.1.0.view", @"/Views/Shared/Components/AccountLanguages/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
using AliFitnessAE.Web.Views.Shared.Components.AccountLanguages;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d964d4a736ea807f84bff9b4b1159e20a3121f7b", @"/Views/Shared/Components/AccountLanguages/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f22aab0795945ed318351279fb17916bfb283757", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_AccountLanguages_Default : AliFitnessAE.Web.Views.AliFitnessAERazorPage<LanguageSelectionViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
 if (Model.Languages.Count > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center\">\n");
#nullable restore
#line 6 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
         foreach (var languageInfo in Model.Languages)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 242, "\"", 457, 1);
#nullable restore
#line 8 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
WriteAttributeValue("", 249, Url.Action("ChangeCulture", "AbpLocalization", new {
                    cultureName = languageInfo.Name,
                    returnUrl = Context.Request.Path + Context.Request.QueryString
                }), 249, 208, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <span");
            BeginWriteAttribute("class", " class=\"", 481, "\"", 570, 1);
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
WriteAttributeValue("", 489, languageInfo.Name == Model.CurrentLanguage.Name ? "current-language-icon" : "", 489, 81, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 571, "\"", 604, 1);
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
WriteAttributeValue("", 579, languageInfo.DisplayName, 579, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <i");
            BeginWriteAttribute("class", " class=\"", 629, "\"", 655, 1);
#nullable restore
#line 13 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
WriteAttributeValue("", 637, languageInfo.Icon, 637, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\n                </span>\n            </a>\n");
#nullable restore
#line 16 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n");
#nullable restore
#line 18 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Components\AccountLanguages\Default.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LanguageSelectionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
