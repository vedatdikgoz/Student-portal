using Microsoft.EntityFrameworkCore;
using StudentPortal.DataAccess.Concrete.EntityFramework.Mapping;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Concrete.Context
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=VEDAT; Database=PortalDb; Trusted_Connection=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ChosenCourse> ChosenCourses { get; set; }
        public DbSet<ChosenCourseItem> ChosenCourseItems { get; set; }
    }
}
