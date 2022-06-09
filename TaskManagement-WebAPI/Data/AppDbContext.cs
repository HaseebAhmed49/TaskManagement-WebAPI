using Microsoft.EntityFrameworkCore;
using TaskManagement_WebAPI.Data.Models;

namespace TaskManagement_WebAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskData>()
                .HasKey(task => task.id);
        }

        public DbSet<TaskData> Tasks { get; set; }
    }
}
