using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Persistence.TypeConfigurations
{
    public class CourseStudentTypeConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            //builder
            //.HasKey(x => new
            //{
            //    x.CourseId,
            //    x.StudentId
            //});

            //builder
            //   .HasMany<Student>()
            //   .WithOne()
            //   .HasForeignKey(x => x.Id)
            //   ;


            //builder
            //   .HasMany<Course>()
            //   .WithOne()
            //   .HasForeignKey(x => x.Id)
            //   ;


        }
    }
}
