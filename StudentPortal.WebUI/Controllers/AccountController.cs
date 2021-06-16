using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StudentPortal.Business.Abstract;
using StudentPortal.WebUI.Identity;
using StudentPortal.WebUI.Models;

namespace StudentPortal.WebUI.Controllers
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
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user =await _userManager.FindByNameAsync(loginViewModel.UserName);
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user,
                    loginViewModel.Password, loginViewModel.RememberMe, false);

                bool isAdmin =await _userManager.IsInRoleAsync(user,"Admin");

                if (result.Succeeded)
                {
                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { @area = "Teacher" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { @area = "Student" });
                    }
                    
                }

                ModelState.AddModelError("", "Hatalı Giriş!");
            }

            return View(loginViewModel);
        }



    }
}
