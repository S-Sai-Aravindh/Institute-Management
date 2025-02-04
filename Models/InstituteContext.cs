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

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<UserModule.User>().HasData(
                new UserModule.User { UserId = 1, Name = "Admin User", Email = "admin@example.com", Password = "admin123", Role = "Admin", ContactDetails = "123-456-7890" },
                new UserModule.User { UserId = 2, Name = "Student User", Email = "student@example.com", Password = "student123", Role = "Student", ContactDetails = "234-567-8901" },
                new UserModule.User { UserId = 3, Name = "Teacher User", Email = "teacher@example.com", Password = "teacher123", Role = "Teacher", ContactDetails = "345-678-9012" }
            );

            // Admins
            modelBuilder.Entity<AdminModule.Admin>().HasData(
                new AdminModule.Admin { AdminId = 1, UserId = 1 }
            );

            // Students
            modelBuilder.Entity<StudentModule.Student>().HasData(
                new StudentModule.Student { StudentId = 1, UserId = 2, BatchId = 1 }
            );

            // Teachers
            modelBuilder.Entity<TeacherModule.Teacher>().HasData(
                new TeacherModule.Teacher { TeacherId = 1, UserId = 3, SubjectSpecialization = "Mathematics" }
            );

            // Batches
            modelBuilder.Entity<BatchModule.Batch>().HasData(
                new BatchModule.Batch { BatchId = 1, BatchName = "Batch A", CourseId = 1 }
            );

            // Courses
            modelBuilder.Entity<CourseModule.Course>().HasData(
                new CourseModule.Course { CourseId = 1, CourseName = "Algebra 101", Description = "Introduction to Algebra", TeacherId = 1 }
            );

            // Student Courses
            modelBuilder.Entity<StudentCourseModule.StudentCourse>().HasData(
                new StudentCourseModule.StudentCourse { StudentId = 1, CourseId = 1 }
            );
        }
    }
}