using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.WebUI.Areas.Student.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<CartItemModel> CartItems { get; set; }
    }

    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Midterm { get; set; }
        public int Final { get; set; }
        public int Quiz1 { get; set; }
        public int Quiz2 { get; set; }
        public int Homework { get; set; }

    }
}
