using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Entity.Models.Entity;
using StudentCourseManagementSystem.Models.Entity;

namespace StudentCourseManagementSystem.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Certificate>()
     .HasOne(c => c.Student)
     .WithMany()
     .HasForeignKey(c => c.StudentId)
     .OnDelete(DeleteBehavior.Restrict); // No cascade

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade

            modelBuilder.Entity<Certificate>()
                .HasOne(c => c.Instructor)
                .WithMany()
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); // No cascade
        }
        public DbSet<Students> students {  get; set; }

        public DbSet<Instructors> instructors { get; set; }

        public DbSet<Courses> courses { get; set; } 

        public DbSet<Grade> grades { get; set; }


        public DbSet<StudentCourses> studentCourses { get; set; }

        public DbSet<Certificate> Certificates { get; set; }

    }
}
