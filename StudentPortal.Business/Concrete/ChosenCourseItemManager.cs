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
    public class ChosenCourseItemManager:IChosenCourseItemService
    {
        private readonly IChosenCourseItemRepository _chosenCourseItemRepository;

        public ChosenCourseItemManager(IChosenCourseItemRepository chosenCourseItemRepository)
        {
            _chosenCourseItemRepository = chosenCourseItemRepository;
        }
        public void Add(ChosenCourseItem entity)
        {
            _chosenCourseItemRepository.Add(entity);
        }

        public void Update(ChosenCourseItem entity)
        {
            _chosenCourseItemRepository.Update(entity);
        }

        public ChosenCourseItem GetChosenCourseItem(int id)
        {
            return _chosenCourseItemRepository.GetChosenCourseItem(id);
        }
    }
}
