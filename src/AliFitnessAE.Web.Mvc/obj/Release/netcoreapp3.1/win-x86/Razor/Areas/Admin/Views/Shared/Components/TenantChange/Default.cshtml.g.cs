#pragma checksum "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c02a905923631d96ca426988f1975beffe3f344"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_TenantChange_Default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/TenantChange/Default.cshtml")]
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
#line 1 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Common.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Models.Common.Admin.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Common.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Models.Admin.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
using AliFitnessAE.Web.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c02a905923631d96ca426988f1975beffe3f344", @"/Areas/Admin/Views/Shared/Components/TenantChange/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4828771e146879edc5054bc895c4c62b097a0a79", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Components_TenantChange_Default : AliFitnessAE.Web.Views.AliFitnessAERazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
  
    WebResourceManager.AddScript(ApplicationPath + "view-resources/Admin/Views/Shared/Components/TenantChange/Default.js");

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center tenant-change-component\">\n    <span>\n        ");
#nullable restore
#line 8 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
   Write(L("CurrentTenant"));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\n\n");
#nullable restore
#line 10 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
         if (Model.Tenant != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span");
            BeginWriteAttribute("title", " title=\"", 363, "\"", 389, 1);
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
WriteAttributeValue("", 371, Model.Tenant.Name, 371, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><strong>");
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
                                                Write(Model.Tenant.TenancyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span>\n");
#nullable restore
#line 13 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span>");
#nullable restore
#line 16 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
             Write(L("NotSelected"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 17 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        (<a href=\"javascript:;\" data-toggle=\"modal\" data-target=\"#TenantChangeModal\">");
#nullable restore
#line 19 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Components\TenantChange\Default.cshtml"
                                                                                Write(L("Change"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>)
    </span>
</div>
<div class=""modal fade"" id=""TenantChangeModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""UserCreateModalLabel"" data-backdrop=""static"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
        </div>
    </div>
</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IWebResourceManager WebResourceManager { get; private set; }
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
