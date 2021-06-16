using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Core.Entities;

namespace StudentPortal.Entites.Concrete
{
    public class ChosenCourseItem:IEntity
    {
        public int Id { get; set; }
        public int ChosenCourseId { get; set; }
        public ChosenCourse ChosenCourse { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Midterm { get; set; }
        public int Final { get; set; }
        public int Quiz1 { get; set; }
        public int Quiz2 { get; set; }
        public int Homework { get; set; }

    }
}
