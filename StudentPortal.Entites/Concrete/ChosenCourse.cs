using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Core.Entities;

namespace StudentPortal.Entites.Concrete
{
    public class ChosenCourse:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ChosenCourseItem> ChosenCourseItems { get; set; }
    }
}
