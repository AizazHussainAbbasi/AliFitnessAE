using Abp;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.Threading;
using Abp.Timing;
using Abp.UI;
using Abp.Web.Models;
using Abp.Web.Mvc.Models;
using Abp.Zero.Configuration;
using Acme.SimpleTaskApp.Common;
using AliFitnessAE.Authorization;
using AliFitnessAE.Authorization.Users;
using AliFitnessAE.Common.Constants;
using AliFitnessAE.Controllers;
using AliFitnessAE.Document.Dto;
using AliFitnessAE.Email;
using AliFitnessAE.Identity;
using AliFitnessAE.MultiTenancy;
using AliFitnessAE.NotificationTemplate;
using AliFitnessAE.Sessions;
using AliFitnessAE.Users.Dto;
using AliFitnessAE.Web.Admin.Views.Shared.Components.TenantChange;
using AliFitnessAE.Web.Models.Admin.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AliFitnessAE.Web.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : AliFitnessAEControllerBase
    {
        private readonly UserManager _userManager;
        private readonly TenantManager _tenantManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly LogInManager _logInManager;
        private readonly SignInManager _signInManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly ISessionAppService _sessionAppService;
        private readonly ITenantCache _tenantCache;
        private readonly INotificationPublisher _notificationPublisher;
        private readonly ILookupAppService _lookupAppService;
        private readonly ISettingManager _settingManager;
        private readonly INotificationManager _notificationManager;
        private readonly IEmailService _emailService;
        private readonly ITemplateManager _templateManager;
        public AccountController(
            UserManager userManager,
            IMultiTenancyConfig multiTenancyConfig,
            TenantManager tenantManager,
            IUnitOfWorkManager unitOfWorkManager,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            LogInManager logInManager,
            SignInManager signInManager,
            UserRegistrationManager userRegistrationManager,
            ISessionAppService sessionAppService,
            ITenantCache tenantCache,
            INotificationPublisher notificationPublisher,
            ILookupAppService lookupAppService,
            ISettingManager settingManager,
            INotificationManager notificationManager,
                IEmailService emailService,
            ITemplateManager templateManager
)
        {
            _userManager = userManager;
            _multiTenancyConfig = multiTenancyConfig;
            _tenantManager = tenantManager;
            _unitOfWorkManager = unitOfWorkManager;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _logInManager = logInManager;
            _signInManager = signInManager;
            _userRegistrationManager = userRegistrationManager;
            _sessionAppService = sessionAppService;
            _tenantCache = tenantCache;
            _notificationPublisher = notificationPublisher;
            _lookupAppService = lookupAppService;
            _settingManager = settingManager;
            _notificationManager = notificationManager;
            _emailService = emailService;
            _templateManager = templateManager;
        }

        #region Login / Logout

        public ActionResult Login(string userNameOrEmailAddress = "", string returnUrl = "", string successMessage = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = GetAppHomeUrl();
            }

            return View(new LoginFormViewModel
            {
                ReturnUrl = returnUrl,
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                IsSelfRegistrationAllowed = IsSelfRegistrationEnabled(),
                MultiTenancySide = AbpSession.MultiTenancySide
            });
        }

        //[HttpPost]
        //[UnitOfWork]
        //public virtual async Task<ActionResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        //{
        //    returnUrl = NormalizeReturnUrl(returnUrl);
        //    if (!string.IsNullOrWhiteSpace(returnUrlHash))
        //    {
        //        returnUrl = returnUrl + returnUrlHash;
        //    }

        //    var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, GetTenancyNameOrNull());
        //    if (!loginResult.User.IsEmailConfirmed)
        //    {
        //        return View("RegisterResult", new RegisterResultViewModel
        //        {
        //            NameAndSurname = loginResult.User.FullName,
        //            UserName = loginResult.User.UserName,
        //            EmailAddress = loginResult.User.EmailAddress,
        //            IsEmailConfirmed = loginResult.User.IsEmailConfirmed,
        //            IsActive = loginResult.User.IsActive,
        //            IsEmailConfirmationRequiredForLogin = true
        //        });
        //    }

        //    await _signInManager.SignInAsync(loginResult.Identity, loginModel.RememberMe);
        //    await UnitOfWorkManager.Current.SaveChangesAsync();

        //    return Json(new AjaxResponse { TargetUrl = returnUrl });
        //}
        [HttpPost]
        [UnitOfWork]
        public virtual async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            returnUrl = NormalizeReturnUrl(returnUrl);
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, GetTenancyNameOrNull());

            await _signInManager.SignInAsync(loginResult.Identity, loginModel.RememberMe);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return Json(new AjaxResponse { TargetUrl = returnUrl });
        }
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password, string tenancyName)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    if (!loginResult.User.IsEmailConfirmed)
                        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(AbpLoginResultType.UserEmailIsNotConfirmed, usernameOrEmailAddress, tenancyName);
                    if (!loginResult.User.IsActive)
                        throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(AbpLoginResultType.UserIsNotActive, usernameOrEmailAddress, tenancyName);
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, tenancyName);
            }
        }

        #endregion

        #region Register

        public async Task<ActionResult> Register()
        {
            //var genderMasterId = (await _lookupAppService.GetAllLookUpMaster(null, "Gender")).Items.FirstOrDefault().Id;
            //var genderSelectListItems = (await _lookupAppService.GetLookDetailComboboxItems(genderMasterId)).Items
            //          .Select(p => p.ToSelectListItem())
            //          .ToList();

            // genderSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("SelectGender"), Selected = true });

            var model = new RegisterViewModel
            {
                GenderList = GetGenderSelectListItem()
            };

            return RegisterView(model);
        }
        private List<SelectListItem> GetGenderSelectListItem()
        {
            var genderMasterId = _lookupAppService.GetAllLookUpMaster(null, "Gender").Result.Items.FirstOrDefault().Id;
            var genderSelectListItems = _lookupAppService.GetLookDetailComboboxItems(genderMasterId).Result.Items
                      .Select(p => p.ToSelectListItem())
                      .ToList();

            genderSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("SelectGender"), Selected = true });
            return genderSelectListItems;
        }
        private ActionResult RegisterView(RegisterViewModel model)
        {
            ViewBag.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;

            return View("Register", model);
        }

        private bool IsSelfRegistrationEnabled()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return false; // No registration enabled for host users!
            }

            return true;
        }

        [HttpPost]
        [UnitOfWork]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                ExternalLoginInfo externalLoginInfo = null;
                if (model.IsExternalLogin)
                {
                    externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
                    if (externalLoginInfo == null)
                    {
                        throw new Exception("Can not external login!");
                    }

                    model.UserName = model.EmailAddress;
                    model.Password = Authorization.Users.User.CreateRandomPassword();
                }
                else
                {
                    if (model.UserName.IsNullOrEmpty() || model.Password.IsNullOrEmpty())
                    {
                        throw new UserFriendlyException(L("FormIsNotValidMessage"));
                    }
                }

                var user = await _userRegistrationManager.RegisterAsync(
                    model.Name,
                    string.Empty,// model.Surname,
                    model.EmailAddress,
                    model.UserName,
                    model.Password,
                    false,
                    false,
                    model.MobileNumber,
                    model.ZoomId,
                    model.DOB,
                    model.Gender
                    );

                // Getting tenant-specific settings
                var isEmailConfirmationRequiredForLogin = true; // await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

                if (model.IsExternalLogin)
                {
                    Debug.Assert(externalLoginInfo != null);

                    if (string.Equals(externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email), model.EmailAddress, StringComparison.OrdinalIgnoreCase))
                    {
                        user.IsEmailConfirmed = true;
                    }

                    user.Logins = new List<UserLogin>
                    {
                        new UserLogin
                        {
                            LoginProvider = externalLoginInfo.LoginProvider,
                            ProviderKey = externalLoginInfo.ProviderKey,
                            TenantId = user.TenantId
                        }
                    };
                }

                await _unitOfWorkManager.Current.SaveChangesAsync();

                Debug.Assert(user.TenantId != null);

                var tenant = await _tenantManager.GetByIdAsync(user.TenantId.Value);

                // Directly login if possible
                if (user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin))
                {
                    AbpLoginResult<Tenant, User> loginResult;
                    if (externalLoginInfo != null)
                    {
                        loginResult = await _logInManager.LoginAsync(externalLoginInfo, tenant.TenancyName);
                    }
                    else
                    {
                        loginResult = await GetLoginResultAsync(user.UserName, model.Password, tenant.TenancyName);
                    }

                    if (loginResult.Result == AbpLoginResultType.Success)
                    {
                        await _signInManager.SignInAsync(loginResult.Identity, false);
                        return Redirect(GetAppHomeUrl());
                    }

                    Logger.Warn("New registered user could not be login. This should not be normally. login result: " + loginResult.Result);
                }

                //Welcome Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrlMessage = Url.Action(nameof(ConfirmEmail), "Account", new { token = code, email = user.EmailAddress }, protocol: HttpContext.Request.Scheme);
                try
                {
                    var welcomeModel = new WelcomeNotificationUserDto()
                    {
                        FullName = user.FullName,
                        Email = user.EmailAddress,
                        UserName = user.UserName,
                        Message = callbackUrlMessage
                    };
                    await _notificationManager.SendWelcomeEmail(welcomeModel);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return View("RegisterResult", new RegisterResultViewModel
                {
                    TenancyName = tenant.TenancyName,
                    NameAndSurname = user.Name + " " + user.Surname,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    IsEmailConfirmed = user.IsEmailConfirmed,
                    IsActive = user.IsActive,
                    IsEmailConfirmationRequiredForLogin = isEmailConfirmationRequiredForLogin
                });
            }
            catch (UserFriendlyException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                model.GenderList = GetGenderSelectListItem();
                return View("Register", model);
            }
        }
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return View("ErrorPage", new ErrorInfo() { Message = L("InvalidEmailAddress"), Details = L("EmailIsNotValidPleasContactWithAdminToResolveTheIssue") });

            var result = await _userManager.ConfirmEmailAsync(user, token);
            ConfirmEmailResultViewModel model = new ConfirmEmailResultViewModel()
            {
                Email = email,
                FullName = user?.FullName
            };
            if (result.Succeeded)
                model.IsEmailConfirmed = user.IsEmailConfirmed;
            else
                model.IsEmailConfirmed = false;

            return View("ConfirmEmail", model);
        }
        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View("ForgotPassword", new ForgotPasswordRequest());
        }
        [HttpPost]
        [UnitOfWork]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            //always return ok response to prevent email enumeration
            if (user == null)
            {
                ModelState.TryAddModelError("InValidEmail", L("InvalidEmailAddress"));
                return View(model);
            }
            if (!user.IsEmailConfirmed)
            {
                ModelState.TryAddModelError("InValidEmail", L("UserEmailIsNotConfirmedAndResetPassword"));
                return View(model);
            }
            if (!user.IsActive)
            {
                ModelState.TryAddModelError("InvalidUserNameOrPassword", string.Format(L("UserIsNotActiveAndCanNotResetPassword"), user.FullName));
                return View(model);
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action(nameof(ResetPassword), "Account", new { token = code, email = model.Email }, protocol: HttpContext.Request.Scheme);

            var forgotPassworNotificationdDto = new ForgotPasswordNotificationUserDto()
            {
                FullName = user.FullName,
                Email = user.EmailAddress,
                Message = callbackUrl,
                Subject = "Forgot Password"
            };
            await _notificationManager.SendForgotPasswordEmail(forgotPassworNotificationdDto);

            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordRequest { Token = token, Email = email };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        #endregion

        #region External Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action(
                "ExternalLoginCallback",
                "Account",
                new
                {
                    ReturnUrl = returnUrl
                });

            return Challenge(
                // TODO: ...?
                // new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
                // {
                //     Items = { { "LoginProvider", provider } },
                //     RedirectUri = redirectUrl
                // },
                provider
            );
        }

        [UnitOfWork]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl, string remoteError = null)
        {
            returnUrl = NormalizeReturnUrl(returnUrl);

            if (remoteError != null)
            {
                Logger.Error("Remote Error in ExternalLoginCallback: " + remoteError);
                throw new UserFriendlyException(L("CouldNotCompleteLoginOperation"));
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                Logger.Warn("Could not get information from external login.");
                return RedirectToAction(nameof(Login));
            }

            await _signInManager.SignOutAsync();

            var tenancyName = GetTenancyNameOrNull();

            var loginResult = await _logInManager.LoginAsync(externalLoginInfo, tenancyName);

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    await _signInManager.SignInAsync(loginResult.Identity, false);
                    return Redirect(returnUrl);
                case AbpLoginResultType.UnknownExternalLogin:
                    return await RegisterForExternalLogin(externalLoginInfo);
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(
                        loginResult.Result,
                        externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email) ?? externalLoginInfo.ProviderKey,
                        tenancyName
                    );
            }
        }

        private async Task<ActionResult> RegisterForExternalLogin(ExternalLoginInfo externalLoginInfo)
        {
            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);
            var nameinfo = ExternalLoginInfoHelper.GetNameAndSurnameFromClaims(externalLoginInfo.Principal.Claims.ToList());

            var viewModel = new RegisterViewModel
            {
                EmailAddress = email,
                Name = nameinfo.name,
                //Surname = string.Empty, // Surname = nameinfo.surname,
                IsExternalLogin = true,
                ExternalLoginAuthSchema = externalLoginInfo.LoginProvider
            };

            if (nameinfo.name != null &&
                nameinfo.surname != null &&
                email != null)
            {
                return await Register(viewModel);
            }

            return RegisterView(viewModel);
        }

        [UnitOfWork]
        protected virtual async Task<List<Tenant>> FindPossibleTenantsOfUserAsync(UserLoginInfo login)
        {
            List<User> allUsers;
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                allUsers = await _userManager.FindAllAsync(login);
            }

            return allUsers
                .Where(u => u.TenantId != null)
                .Select(u => AsyncHelper.RunSync(() => _tenantManager.FindByIdAsync(u.TenantId.Value)))
                .ToList();
        }

        #endregion

        #region Helpers

        public ActionResult RedirectToAppHome()
        {
            return RedirectToAction("Index", "Home");
        }

        public string GetAppHomeUrl()
        {
            var action = Url.Action("Index", "Home", new { Area = "Admin" });
            return action;
        }

        #endregion

        #region Change Tenant

        public async Task<ActionResult> TenantChangeModal()
        {
            try
            {
                var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
                return View("~/Areas/Admin/Views/Shared/Components/TenantChange/_ChangeModal.cshtml", new ChangeModalViewModel
                {
                    TenancyName = loginInfo.Tenant?.TenancyName
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Common

        private string GetTenancyNameOrNull()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                return null;
            }

            return _tenantCache.GetOrNull(AbpSession.TenantId.Value)?.TenancyName;
        }

        private string NormalizeReturnUrl(string returnUrl, Func<string> defaultValueBuilder = null)
        {
            if (defaultValueBuilder == null)
            {
                defaultValueBuilder = GetAppHomeUrl;
            }

            if (returnUrl.IsNullOrEmpty())
            {
                return defaultValueBuilder();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return defaultValueBuilder();
        }

        #endregion

        #region Etc

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [AbpMvcAuthorize]
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                    "App.SimpleMessage",
                    new MessageNotificationData(message),
                    severity: NotificationSeverity.Info,
                    userIds: new[] { defaultTenantAdmin, hostAdmin }
                 );

            return Content("Sent notification: " + message);
        }

        #endregion
        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
