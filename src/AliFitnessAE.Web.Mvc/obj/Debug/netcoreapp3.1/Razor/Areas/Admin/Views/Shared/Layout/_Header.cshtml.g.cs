#pragma checksum "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Layout\_Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6dad05aa244f528a658580416fb945239e0577d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Layout__Header), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Layout/_Header.cshtml")]
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
#line 1 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Common.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Views.Shared.Components.DocumentUploader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Models.Common.Admin.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Models.Common.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Models.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Admin.Views.Shared.Components.UserTrackingChart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Common.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Areas.Admin.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Models.Admin.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Web.Admin.Views.UserTracking.Components.PhotoTracking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\_ViewImports.cshtml"
using AliFitnessAE.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dad05aa244f528a658580416fb945239e0577d2", @"/Areas/Admin/Views/Shared/Layout/_Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31bec4093dc05441da1a0036bd5e43fc9a6f82cc", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Layout__Header : AliFitnessAE.Web.Views.AliFitnessAERazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<nav class=\"main-header navbar navbar-expand navbar-white navbar-light\">\n    ");
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Layout\_Header.cshtml"
Write(await Html.PartialAsync("_Header.LeftNavbar.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    ");
#nullable restore
#line 3 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Shared\Layout\_Header.cshtml"
Write(await Html.PartialAsync("_Header.RightNavbar.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</nav>\n");
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
