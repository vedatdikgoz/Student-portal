using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.Business.Abstract
{
    public interface ICourseService
    {
        List<Course> GetAll();
    }
}
