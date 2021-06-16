using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Core.Entities;

namespace StudentPortal.Entites.Concrete
{
    public class Course:IEntity
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
