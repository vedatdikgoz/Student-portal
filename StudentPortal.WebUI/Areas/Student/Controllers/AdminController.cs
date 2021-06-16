using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using StudentPortal.Business.Abstract;
using StudentPortal.Business.Concrete;
using StudentPortal.Entites.Concrete;
using StudentPortal.WebUI.Areas.Student.Models;
using StudentPortal.WebUI.Identity;

namespace StudentPortal.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICartService _cartService;
        private readonly IChosenCourseService _chosenCourseService;

        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, ICartService cartService, IChosenCourseService chosenCourseService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
            _chosenCourseService = chosenCourseService;

        }
      

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { @area = "" });
        }


    }
}
