using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.WebUI.Areas.Student.Models
{
    public class ChosenCourseListModel
    {
        public int ChosenCourseId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ChosenCourseItemModel> ChosenCourseItems { get; set; }
    }

    public class ChosenCourseItemModel
    {
        public int ChosenCourseItemId { get; set; }
        public string ChosenCourseName { get; set; }
        public int Midterm { get; set; }
        public int Final { get; set; }
        public int Quiz1 { get; set; }
        public int Quiz2 { get; set; }
        public int Homework { get; set; }

    }
}
