using System;
using System.Collections.Generic;
using System.Text;
using StudentPortal.Entites.Concrete;


namespace StudentPortal.Business.Abstract
{
    public interface IChosenCourseService
    {
        List<ChosenCourse> GetChosenCourses(string userId);
        void Add(ChosenCourse entity);
    }
}
