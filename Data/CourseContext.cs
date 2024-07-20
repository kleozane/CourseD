using Microsoft.EntityFrameworkCore;

namespace Course.Data
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) 
        { }

        public DbSet<Student> Students { get; set; }
    }
}
