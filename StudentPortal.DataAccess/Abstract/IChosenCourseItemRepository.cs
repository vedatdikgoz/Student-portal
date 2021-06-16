using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentPortal.Core.DataAccess;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Abstract
{
    public interface IChosenCourseItemRepository : IEntityRepository<ChosenCourseItem>
    {
        ChosenCourseItem GetChosenCourseItem(int id);
    }
}
