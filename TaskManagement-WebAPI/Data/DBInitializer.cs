using TaskManagement_WebAPI.Data.Models;

namespace TaskManagement_WebAPI.Data
{
    public class DBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Tasks.Any())
                {
                    context.AddRange(new TaskDataVM()
                    {
                        taskName = "Task 123",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now.AddDays(1)
                    }
                    , new TaskDataVM()
                    {
                        taskName = "Task 456",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now.AddDays(2)
                    }
                    , new TaskDataVM()
                    {
                        taskName = "Task 789",
                        startDate = DateTime.Now,
                        endDate = DateTime.Now.AddDays(3)
                    });
                    context.SaveChanges();
                };
            }
        }
    }
}
