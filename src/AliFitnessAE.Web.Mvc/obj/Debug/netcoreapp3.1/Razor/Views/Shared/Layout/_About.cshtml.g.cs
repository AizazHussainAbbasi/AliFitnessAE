#pragma checksum "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc620437db955c5a141c277de5979e941f66d097"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Layout__About), @"mvc.1.0.view", @"/Views/Shared/Layout/_About.cshtml")]
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
#line 1 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_About.cshtml"
using AliFitnessAE.Web.Views.Shared.Components.TopicBlock;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc620437db955c5a141c277de5979e941f66d097", @"/Views/Shared/Layout/_About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f22aab0795945ed318351279fb17916bfb283757", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Layout__About : AliFitnessAE.Web.Views.AliFitnessAERazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_About.cshtml"
  
    ViewData["Title"] = "_About";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- About -->\r\n<section id=\"about\" class=\"container waypoint\">\r\n    <div class=\"inner\">\r\n        <h1 class=\"m-0 text-dark\">");
#nullable restore
#line 9 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_About.cshtml"
                             Write(L("HomePage"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        ");
#nullable restore
#line 10 "C:\Projects\AliFitness\MultiPageApp\GitHub\AliFitnessAE\5.8.1\aspnet-core\src\AliFitnessAE.Web.Mvc\Views\Shared\Layout\_About.cshtml"
   Write(await Component.InvokeAsync(typeof(TopicBlockViewComponent), "HomepageText"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

        <!-- Header -->
        <h1 class=""header light gray3 fancy""><span class=""colored"">Know </span>about us</h1>

        <!-- Description -->
        <p class=""h-desc gray4"">lorem Ipsum is<span class=""colored bold""> lorem Ipsum</span> of passages of Lorem Ipsum available, but the majority have suffered alteration.<br /><br /></p>
        <hr>

        <!-- Boxes -->
        <div class=""boxes"">


            <div class=""col-xs-3 col-sm-6 col-md-3 about-box animated"" data-animation=""fadeIn"" data-animation-delay=""100"">
                <p class=""lead"">Pressure check up</p>
                <hr><br>
                <a class=""about-icon"">
                    <i class=""fa fa-stethoscope""></i>
                </a>
                <br><br>
                <p class=""light about-text"">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority.</p>
            </div>


            <div class=""col-xs-3 col-sm-6 col-md-3 about-box animated"" data-animation=""fadeIn"" data-a");
            WriteLiteral(@"nimation-delay=""300"">
                <p class=""lead"">Max. gym equipments</p>
                <hr><br>
                <a class=""about-icon"">
                    <i class=""fa fa-wheelchair""></i>
                </a>
                <br><br>
                <p class=""light about-text"">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority.</p>
            </div>


            <div class=""col-xs-12 col-md-6 col-sm-12 about-box animated"" data-animation=""fadeIn"" data-animation-delay=""700"">
                <p class=""lead lead-text"">Best in the city</p><hr>
                <p class=""left pro-bars"" style=""color: rgb(83, 205, 181);"">Treadmill </p>
                <div class=""pro-bar-container color-green-sea"">
                    <div class=""pro-bar bar-100 color-turquoise"" data-pro-bar-percent=""100"">
                        <div class=""pro-bar-candy candy-ltr""></div>
                    </div>
                </div>
                <p class=""left pro-bars"" style=""color: ");
            WriteLiteral(@"#3498DB;"">Spinning </p>
                <div class=""pro-bar-container color-belize-hole"">
                    <div class=""pro-bar bar-80 color-peter-river"" data-pro-bar-percent=""80"" data-pro-bar-delay=""200"">
                        <div class=""pro-bar-candy candy-ltr""></div>
                    </div>
                </div>
                <p class=""left pro-bars"" style=""color: #B483C8;"">Cardio </p>
                <div class=""pro-bar-container color-wisteria"">
                    <div class=""pro-bar bar-70 color-amethyst"" data-pro-bar-percent=""70"" data-pro-bar-delay=""300"">
                        <div class=""pro-bar-candy candy-ltr""></div>
                    </div>
                </div>
            </div>
        </div><!-- End Boxes -->
    </div><!-- End About Inner -->
</section><!-- End About Section -->");
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
