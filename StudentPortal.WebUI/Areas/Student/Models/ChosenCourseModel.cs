using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.WebUI.Areas.Student.Models
{
    public class ChosenCourseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CartModel CartModel { get; set; }
    }
}
