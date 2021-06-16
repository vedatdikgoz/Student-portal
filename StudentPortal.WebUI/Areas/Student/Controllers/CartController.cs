using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using StudentPortal.Business.Abstract;
using StudentPortal.Entites.Concrete;
using StudentPortal.WebUI.Areas.Student.Models;
using StudentPortal.WebUI.Identity;


namespace StudentPortal.WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize(Roles = "Student")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;
        private readonly IChosenCourseService _chosenCourseService;

        public CartController(ICartService cartService, UserManager<User> userManager, IChosenCourseService chosenCourseService)
        {
            _userManager = userManager;
            _cartService = cartService;
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
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    CourseId = i.CourseId,
                    CourseName=i.Course.CourseName
                    

                }).ToList()
            });
        }


        [HttpPost]
        public IActionResult AddToCart(int courseId)
        {
            var userId = _userManager.GetUserId(User);

            _cartService.AddToCart(userId, courseId);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteFromCart(int courseId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, courseId);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));

            var chosenCourseModel = new ChosenCourseModel();
            chosenCourseModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    CourseId = i.CourseId
                    

                }).ToList()
            };
            return View(chosenCourseModel);

        }


        [HttpPost]
        public IActionResult Checkout(ChosenCourseModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);

                model.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemModel()
                    {
                        CartItemId = i.Id,
                        CourseId = i.CourseId


                    }).ToList()
                };
                
                    SaveOrder(model, userId);
                    ClearCart(model.CartModel.CartId);
                    return View();

            }

            return View();
        }

        private void SaveOrder(ChosenCourseModel model, string userId)
        {
            var chosenCourse = new ChosenCourse();

            chosenCourse.FirstName = model.FirstName;
            chosenCourse.LastName = model.LastName;
            chosenCourse.UserId = userId;


            chosenCourse.ChosenCourseItems = new List<ChosenCourseItem>();

            foreach (var item in model.CartModel.CartItems)
            {
                var chosenCourseItem = new ChosenCourseItem()
                {
                    CourseId = item.CourseId,
                    Midterm = item.Midterm,
                    Quiz1 = item.Quiz1,
                    Quiz2 = item.Quiz2,
                    Homework = item.Homework,
                    Final = item.Final
                };

                chosenCourse.ChosenCourseItems.Add(chosenCourseItem);
            }

            _chosenCourseService.Add(chosenCourse);
        }

        private void ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
        }


        public IActionResult GetChosenCourses()
        {
            var userId = _userManager.GetUserId(User);
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
                    ChosenCourseName= i.Course.CourseName,
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
