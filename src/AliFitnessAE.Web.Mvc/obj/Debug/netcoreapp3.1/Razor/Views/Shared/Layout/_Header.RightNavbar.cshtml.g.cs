#pragma checksum "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_Header.RightNavbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37736751eb1744fe9e3900289aefe78e5188ef56"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Layout__Header_RightNavbar), @"mvc.1.0.view", @"/Views/Shared/Layout/_Header.RightNavbar.cshtml")]
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
#line 1 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_Header.RightNavbar.cshtml"
using AliFitnessAE.Web.Views.Shared.Components.RightNavbarLanguageSwitch;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_Header.RightNavbar.cshtml"
using AliFitnessAE.Web.Views.Shared.Components.RightNavbarUserArea;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37736751eb1744fe9e3900289aefe78e5188ef56", @"/Views/Shared/Layout/_Header.RightNavbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f22aab0795945ed318351279fb17916bfb283757", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Layout__Header_RightNavbar : AliFitnessAE.Web.Views.AliFitnessAERazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<ul class=\"navbar-nav ml-auto\">\n    ");
#nullable restore
#line 4 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_Header.RightNavbar.cshtml"
Write(await Component.InvokeAsync(typeof(RightNavbarLanguageSwitchViewComponent)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral("</ul>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
