using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Business.Abstract;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }
    }
}
