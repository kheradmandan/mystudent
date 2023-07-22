using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Persistence.DbContexts
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<Teacher> Teachers { get; set; } = default!;



        public DbSet<CI_FieldCourse> CI_FieldCourses { get; set; } = default!;
        public DbSet<CI_FieldStudent> CI_FieldStudents { get; set; } = default!;

        public DbSet<CourseStudent> CourseStudents { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<CI_Role> CI_Roles { get; set; } = default!;

  

        public StudentDbContext() : base() { }
        public StudentDbContext(DbContextOptions opt) : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-POCSAAB\\SQL;Initial Catalog=Student_Core19;Integrated Security=True;Trusted_Connection=True;");
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);

            modelBuilder.Entity<CourseStudent>()
                .HasOne<Course>(sc => sc.courses)
                .WithMany(s => s.CourseStudent)
            .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne<Student>(sc => sc.Students)
                .WithMany(s => s.CourseStudent)
                .HasForeignKey(s => s.StudentId);




        }
 
    }
}
