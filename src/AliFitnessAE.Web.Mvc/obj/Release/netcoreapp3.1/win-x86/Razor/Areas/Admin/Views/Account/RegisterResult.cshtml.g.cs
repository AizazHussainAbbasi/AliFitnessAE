#pragma checksum "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61a92a329e8e3747fe8abbcf0b91836f1da85d0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account_RegisterResult), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/RegisterResult.cshtml")]
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
#line 1 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61a92a329e8e3747fe8abbcf0b91836f1da85d0a", @"/Areas/Admin/Views/Account/RegisterResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4828771e146879edc5054bc895c4c62b097a0a79", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f22aab0795945ed318351279fb17916bfb283757", @"/Areas/Admin/Views/Account/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Account_RegisterResult : AliFitnessAE.Web.Views.AliFitnessAERazorPage<AliFitnessAE.Web.Models.Admin.Account.RegisterResultViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
  
    ViewBag.Title = L("SuccessfullyRegistered");

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card\">\n    <div class=\"card-body\">\n        <h4>");
#nullable restore
#line 7 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
       Write(L("SuccessfullyRegistered"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n        <ul>\n            <li><span class=\"text-muted\">");
#nullable restore
#line 9 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                    Write(L("NameSurname"));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span> ");
#nullable restore
#line 9 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                                              Write(Model.NameAndSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            <li><span class=\"text-muted\">");
#nullable restore
#line 10 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                    Write(L("TenancyName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span> ");
#nullable restore
#line 10 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                                              Write(Model.TenancyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            <li><span class=\"text-muted\">");
#nullable restore
#line 11 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                    Write(L("UserName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span> ");
#nullable restore
#line 11 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                                           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n            <li><span class=\"text-muted\">");
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                    Write(L("EmailAddress"));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</span> ");
#nullable restore
#line 12 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
                                                               Write(Model.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n        </ul>\n        <div>\n");
#nullable restore
#line 15 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
             if (!Model.IsActive)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-warning\" role=\"alert\">\n                    ");
#nullable restore
#line 18 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
               Write(L("WaitingForActivationMessage"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n");
#nullable restore
#line 20 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 22 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
             if (Model.IsEmailConfirmationRequiredForLogin && !Model.IsEmailConfirmed)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-warning\" role=\"alert\">\n                    ");
#nullable restore
#line 25 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
               Write(L("WaitingForEmailActivation"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n");
#nullable restore
#line 27 "C:\Projects\AliFitness\MultiPageApp\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Areas\Admin\Views\Account\RegisterResult.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n    </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AliFitnessAE.Web.Models.Admin.Account.RegisterResultViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
