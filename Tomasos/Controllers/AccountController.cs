using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ASPNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using ASPNetCoreIdentity.Models.AccountViewModels;
using Microsoft.Extensions.Logging;
using Tomasos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Internal;
using Tomasos.Models.AccountViewModels;

namespace Tomasos.Controllers
{
    public class AccountController : Controller
    {


        public UserManager<AppUser> UserManager { get; }
        public SignInManager<AppUser> SignInManager { get; }
        public ILogger Logger { get; }

        public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ILogger<AccountController> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
        }




        private void AddErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            EditUserViewModel model = new EditUserViewModel
            {
                Address = user.Address,
                City = user.City,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PostalCode = user.PostalCode
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            AppUser currentUser = await UserManager.FindByNameAsync(User.Identity.Name);
            currentUser.Address = model.Address;
            currentUser.City = model.City;
            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.PostalCode = model.PostalCode;
            currentUser.PhoneNumber = model.PhoneNumber;
            currentUser.PostalCode = model.PostalCode;
            await UserManager.UpdateAsync(currentUser);
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PostalCode = model.PostalCode,
                City = model.City,
                PhoneNumber = model.PhoneNumber
            };
            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user, Roles.Premium.ToString());
                await SignInManager.SignInAsync(user, isPersistent: false);
                Logger.LogInformation("User created a new account with password.");
                return RedirectToLocal(returnUrl);
            }
            AddErrors(result);

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    Logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            Logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> ChangePremium(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);

            bool isPremium = await UserManager.IsInRoleAsync(user, Roles.Premium.ToString());
            if (user != null)
            {
                if (isPremium)
                    await UserManager.RemoveFromRoleAsync(user, Roles.Premium.ToString());
                else
                    await UserManager.AddToRoleAsync(user, Roles.Premium.ToString());
            }

            return Content(!isPremium ? "True" : "False");
        }


    }
}

