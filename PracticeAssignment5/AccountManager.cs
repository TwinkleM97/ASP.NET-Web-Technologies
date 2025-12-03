using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TransactionRecordApp.Models;
using System.Threading.Tasks;

namespace TransactionRecordApp.Controllers
    {
        public class AccountController : Controller
        {
            private readonly SignInManager<User> _signInManager;
            private readonly UserManager<User> _userManager;

            public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
            {
                _signInManager = signInManager;
                _userManager = userManager;
            }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = new User { UserName = model.Username };
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(model);
            }

            [HttpGet]
            public IActionResult LogIn(string returnUrl = "")
            {
                return View(new LoginViewModel { ReturnUrl = returnUrl });
            }

            [HttpPost]
            public async Task<IActionResult> LogIn(LoginViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                            return Redirect(model.ReturnUrl);

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Invalid username/password.");
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> LogOut()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            [HttpGet]
            public IActionResult AccessDenied()
            {
                return View();
            }
        }
    }
