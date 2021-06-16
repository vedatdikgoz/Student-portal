using Microsoft.Extensions.DependencyInjection;
using StudentPortal.Business.Abstract;
using StudentPortal.Business.Concrete;
using StudentPortal.Core.DataAccess;
using StudentPortal.Core.DataAccess.EntityFramework;
using StudentPortal.DataAccess.Abstract;
using StudentPortal.DataAccess.Concrete.EntityFramework;



namespace StudentPortal.Business.Containers
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<,>));


            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<ICourseRepository, EfCourseRepository>();

            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartRepository, EfCartRepository>();

            services.AddScoped<IChosenCourseService, ChosenCourseManager>();
            services.AddScoped<IChosenCourseRepository, EfChosenCourseRepository>();

            services.AddScoped<IChosenCourseItemService, ChosenCourseItemManager>();
            services.AddScoped<IChosenCourseItemRepository, EfChosenCourseItemRepository>();

        }
    }
}
