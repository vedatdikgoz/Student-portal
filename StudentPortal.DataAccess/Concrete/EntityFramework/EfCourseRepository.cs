using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Core.DataAccess.EntityFramework;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.DataAccess.Concrete.Context;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Concrete.EntityFramework
{
    public class EfCourseRepository : EfEntityRepositoryBase<Course, DataContext>, ICourseRepository
    {
    }
}
