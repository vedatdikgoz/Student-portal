using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Core.DataAccess.EntityFramework;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.DataAccess.Concrete.Context;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Concrete.EntityFramework
{
    public class EfChosenCourseRepository : EfEntityRepositoryBase<ChosenCourse, DataContext>, IChosenCourseRepository
    {
        public List<ChosenCourse> GetChosenCourses(string userId)
        {
            using var context = new DataContext();
            var chosenCourses = context.ChosenCourses.Include(I => I.ChosenCourseItems)
                .ThenInclude(I => I.Course).AsQueryable();

            if (!string.IsNullOrEmpty(userId))
            {
                chosenCourses = chosenCourses.Where(I => I.UserId == userId);
            }

            return chosenCourses.ToList();
        }
    }
}
