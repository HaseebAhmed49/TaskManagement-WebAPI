using System.ComponentModel.DataAnnotations;

namespace TaskManagement_WebAPI.Data.Models
{
    public class TaskData
    {
        [Key]
        public int id { get; set; }

        public string taskName { get; set; }

        public string? taskDescription { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public TaskStatus? taskStatus { get; set; }
    }

    public enum TaskStatus
    {
        NotStarted,
        Pending,
        Completed,
        OnHold
    }

}
