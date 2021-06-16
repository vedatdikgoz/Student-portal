using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.WebUI.Areas.Teacher.Models
{
    public class AddMarkModel
    {
        public int Id { get; set; }
        public int ChosenCourseId { get; set; }
        public ChosenCourse ChosenCourse { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string ChosenCourseName { get; set; }
        public int Midterm { get; set; }
        public int Final { get; set; }
        public int Quiz1 { get; set; }
        public int Quiz2 { get; set; }
        public int Homework { get; set; }
    }
}
