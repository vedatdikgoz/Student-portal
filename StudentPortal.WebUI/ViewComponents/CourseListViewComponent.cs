using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using StudentPortal.Business.Abstract;


namespace StudentPortal.WebUI.ViewComponents
{
    public class CourseListViewComponent:ViewComponent
    {
        private ICourseService _courseService;

        public CourseListViewComponent(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_courseService.GetAll());
        }
    }
}
