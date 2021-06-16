using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Business.Abstract;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.Entites.Concrete;
using StudentPortal.WebUI.Areas.Teacher.Models;
using StudentPortal.WebUI.Identity;

namespace StudentPortal.WebUI.Areas.Teacher.Controllers
{

    [Area("Teacher")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IChosenCourseItemService _chosenCourseItemService;
        private readonly IChosenCourseService _chosenCourseService;
        public AdminController(UserManager<User> userManager, SignInManager<User> signInManager, IChosenCourseItemService chosenCourseItemService, IChosenCourseService chosenCourseService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _chosenCourseItemService = chosenCourseItemService;
            _chosenCourseService = chosenCourseService;

        }

        public void AddModelError(IdentityResult result)
        {

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        public IActionResult Index()
        {

            return View();
        }




        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "Student");

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    AddModelError(result);
                    return View(model);
                }
            }


            return View(model);
        }



        public IActionResult Students()
        {
            
            return View( _userManager.GetUsersInRoleAsync("Student").Result.ToList());

        }



        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { @area = "" });
        }



        [HttpGet]
        public IActionResult AddMarks(int? id)
        {
            var chosenCourse = _chosenCourseItemService.GetChosenCourseItem((int) id);
            var model = new AddMarkModel()
            {
                Id = chosenCourse.Id,
                Midterm = chosenCourse.Midterm,
                Quiz1 = chosenCourse.Quiz1,
                Quiz2 = chosenCourse.Quiz2,
                Homework = chosenCourse.Homework,
                Final = chosenCourse.Final,
                ChosenCourseName = chosenCourse.Course.CourseName,
                FirstName = chosenCourse.ChosenCourse.FirstName,
                LastName = chosenCourse.ChosenCourse.LastName
                
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult AddMarks(AddMarkModel model)
        {
           
            if (ModelState.IsValid)
            {
                var chosenCourse = _chosenCourseItemService.GetChosenCourseItem(model.Id);
                chosenCourse.Midterm = model.Midterm;
                chosenCourse.Quiz1 = model.Quiz1;
                chosenCourse.Quiz2 = model.Quiz2;
                chosenCourse.Homework = model.Homework;
                chosenCourse.Final = model.Final;


                _chosenCourseItemService.Update(chosenCourse);

                return RedirectToAction("Index","Home");
              
            }

            return View(model);

        }


        [HttpGet]
        public IActionResult GetChosenCourses(string userId)
        {
            var chosenCourses = _chosenCourseService.GetChosenCourses(userId);

            var chosenCourseListModel = new List<ChosenCourseListModel>();
            ChosenCourseListModel chosenCourseModel;
            foreach (var chosenCourse in chosenCourses)
            {
                chosenCourseModel = new ChosenCourseListModel();

                chosenCourseModel.ChosenCourseId = chosenCourse.Id;

                chosenCourseModel.ChosenCourseItems = chosenCourse.ChosenCourseItems.Select(i => new ChosenCourseItemModel()
                {
                    ChosenCourseItemId = i.Id,
                    ChosenCourseName = i.Course.CourseName,
                    Midterm = i.Midterm,
                    Quiz1 = i.Quiz1,
                    Quiz2 = i.Quiz2,
                    Homework = i.Homework,
                    Final = i.Final

                }).ToList();

                chosenCourseListModel.Add(chosenCourseModel);
            }


            return View(chosenCourseListModel);
        }
    }
}

