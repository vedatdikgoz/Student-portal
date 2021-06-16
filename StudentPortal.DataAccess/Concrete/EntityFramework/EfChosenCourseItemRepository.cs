using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Core.DataAccess;
using StudentPortal.Core.DataAccess.EntityFramework;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.DataAccess.Concrete.Context;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Concrete.EntityFramework
{
    public class EfChosenCourseItemRepository : EfEntityRepositoryBase<ChosenCourseItem, DataContext>, IChosenCourseItemRepository
    {
        public ChosenCourseItem GetChosenCourseItem(int id)
        {
            using var context = new DataContext();
            return context.ChosenCourseItems.Where(I => I.Id == id).Include(I=>I.Course).Include(I=>I.ChosenCourse).FirstOrDefault();
        }
    }
}
