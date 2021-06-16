using System;
using System.Collections.Generic;
using System.Text;
using StudentPortal.Business.Abstract;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.Entites.Concrete;


namespace StudentPortal.Business.Concrete
{
   public class ChosenCourseManager:IChosenCourseService
   {
       private IChosenCourseRepository _chosenCourseRepository;

       public ChosenCourseManager(IChosenCourseRepository chosenCourseRepository)
       {
           _chosenCourseRepository = chosenCourseRepository;
       }

        public void Add(ChosenCourse entity)
        {
            _chosenCourseRepository.Add(entity);
        }

        public List<ChosenCourse> GetChosenCourses(string userId)
       {
           return _chosenCourseRepository.GetChosenCourses(userId);
       }

   }
}
