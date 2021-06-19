using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using AliFitnessAE.Authorization;

namespace AliFitnessAE.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class AliFitnessAENavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Home"),
                        url: "/Admin/Home",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "/Admin/Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "/Admin/Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                )
                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.UserTracking,
                //        L("UserTracking"),
                //        url: "/Admin/UserTracking",
                //        icon: "fas fa-theater-masks",
                //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_UserTracking)
                //            )
                //)
                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.About,
                //        L("About"),
                //        url: "About",
                //        icon: "fas fa-info-circle"
                //    )
                //)
                .AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        PageNames.UserTracking,
                        L("UserTracking"),
                        icon: "fas fa-weight",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_UserTracking)
                    ).AddItem(
                            new MenuItemDefinition(
                                    PageNames.UserTracking,
                                    L("Measurement"),
                                    url: "/Admin/UserTracking",
                                    icon: "fas fa-tape"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                    PageNames.PhotoTracking,
                                    L("Photo"),
                                    url: "/Admin/UserTracking/PhotoTracking",
                                    icon: "fas fa-images"
                            )
                      )
                 ).AddItem(
                    new MenuItemDefinition(
                        PageNames.UserType,
                        L("UserType"),
                        url: "/Admin/UserType",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_UserType)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "/Admin/Roles",
                        icon: "fas fa-user-tag",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Topic,
                        L("Topic"),
                        url: "/Admin/Topic",
                        icon: "fas fa-align-left",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Topic)
                            )
                );
                //.AddItem( // Menu items below is just for demonstration!
                //    new MenuItemDefinition(
                //        "MultiLevelMenu",
                //        L("MultiLevelMenu"),
                //        icon: "fas fa-circle"
                //    ).AddItem(
                //        new MenuItemDefinition(
                //            "AspNetBoilerplate",
                //            new FixedLocalizableString("ASP.NET Boilerplate"),
                //            icon: "far fa-circle"
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetBoilerplateHome",
                //                new FixedLocalizableString("Home"),
                //                url: "https://aspnetboilerplate.com?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetBoilerplateTemplates",
                //                new FixedLocalizableString("Templates"),
                //                url: "https://aspnetboilerplate.com/Templates?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetBoilerplateSamples",
                //                new FixedLocalizableString("Samples"),
                //                url: "https://aspnetboilerplate.com/Samples?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetBoilerplateDocuments",
                //                new FixedLocalizableString("Documents"),
                //                url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        )
                //    ).AddItem(
                //        new MenuItemDefinition(
                //            "AspNetZero",
                //            new FixedLocalizableString("ASP.NET Zero"),
                //            icon: "far fa-circle"
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetZeroHome",
                //                new FixedLocalizableString("Home"),
                //                url: "https://aspnetzero.com?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetZeroFeatures",
                //                new FixedLocalizableString("Features"),
                //                url: "https://aspnetzero.com/Features?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetZeroPricing",
                //                new FixedLocalizableString("Pricing"),
                //                url: "https://aspnetzero.com/Pricing?ref=abptmpl#pricing",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetZeroFaq",
                //                new FixedLocalizableString("Faq"),
                //                url: "https://aspnetzero.com/Faq?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        ).AddItem(
                //            new MenuItemDefinition(
                //                "AspNetZeroDocuments",
                //                new FixedLocalizableString("Documents"),
                //                url: "https://aspnetzero.com/Documents?ref=abptmpl",
                //                icon: "far fa-dot-circle"
                //            )
                //        )
                //    )
                //);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AliFitnessAEConsts.LocalizationSourceName);
        }
    }
}
