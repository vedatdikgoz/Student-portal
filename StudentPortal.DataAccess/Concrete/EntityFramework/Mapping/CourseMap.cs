using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentPortal.Entites.Concrete;

namespace StudentPortal.DataAccess.Concrete.EntityFramework.Mapping
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(I => I.CourseId);
            builder.Property(I => I.CourseId).UseIdentityColumn();
            
        }
    }
}
