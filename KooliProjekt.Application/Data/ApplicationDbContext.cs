using KooliProjekt.Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(student => student.Email)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .HasIndex(teacher => teacher.Email)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(course => course.Code)
                .IsUnique();

            modelBuilder.Entity<Enrollment>()
                .HasKey(enrollment => new { enrollment.StudentId, enrollment.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
