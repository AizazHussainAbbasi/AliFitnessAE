#pragma checksum "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_SideBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fd74785571f2c536e5b6b18d9405f3a4f51896c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Layout__SideBar), @"mvc.1.0.view", @"/Views/Shared/Layout/_SideBar.cshtml")]
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
#line 1 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_SideBar.cshtml"
using AliFitnessAE.Web.Admin.Views.Shared.Components.SideBarMenu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_SideBar.cshtml"
using AliFitnessAE.Web.Views.Shared.Components.SideBarUserArea;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fd74785571f2c536e5b6b18d9405f3a4f51896c", @"/Views/Shared/Layout/_SideBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f22aab0795945ed318351279fb17916bfb283757", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Layout__SideBar : AliFitnessAE.Web.Views.AliFitnessAERazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<aside class=\"main-sidebar sidebar-dark-primary elevation-4\">\n    ");
#nullable restore
#line 4 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_SideBar.cshtml"
Write(await Html.PartialAsync("_SideBar.Logo.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div class=\"sidebar\">\n");
            WriteLiteral("        ");
#nullable restore
#line 7 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_SideBar.cshtml"
   Write(await Component.InvokeAsync(typeof(SideBarMenuViewComponent)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n</aside>\n");
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
