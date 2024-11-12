using Microsoft.EntityFrameworkCore;
using StudentDataCRUD.Models;

namespace StudentDataCRUD.AppDbContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
    }
}
