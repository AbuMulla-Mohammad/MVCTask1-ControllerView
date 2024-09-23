using Microsoft.EntityFrameworkCore;
using MVCTask1.Models;

namespace MVCTask1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
