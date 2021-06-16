using System;
using System.Collections.Generic;
using System.Text;
using StudentPortal.Core.DataAccess;
using StudentPortal.Entites.Concrete;


namespace StudentPortal.DataAccess.Abstract
{
    public interface IChosenCourseRepository : IEntityRepository<ChosenCourse>
    {
        List<ChosenCourse> GetChosenCourses(string userId);
    }
}
