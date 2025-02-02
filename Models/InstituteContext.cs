using Microsoft.EntityFrameworkCore;

namespace Institute_Management.Models
{
    public class InstituteContext : DbContext
    {
        public InstituteContext(DbContextOptions<InstituteContext> options) : base(options) { }

        public DbSet<UserModule.User> Users { get; set; }
        public DbSet<StudentModule.Student> Students { get; set; }
        public DbSet<TeacherModule.Teacher> Teachers { get; set; }
        public DbSet<AdminModule.Admin> Admins { get; set; }
        public DbSet<BatchModule.Batch> Batches { get; set; }
        public DbSet<CourseModule.Course> Courses { get; set; }
        public DbSet<StudentCourseModule.StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite primary key for StudentCourse
            modelBuilder.Entity<StudentCourseModule.StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
