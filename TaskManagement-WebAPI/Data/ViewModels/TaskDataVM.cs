using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TaskManagement_WebAPI.Data;

namespace TaskManagement_WebAPI.Data.Models
{
    public class TaskDataVM
    {
        public string taskName { get; set; }

        public string? taskDescription { get; set; }

        public TaskStatus? taskStatus { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }

    public class TaskDatawithIdVM
    {
        public int id { get; set; }

        public string taskName { get; set; }

        public string? taskDescription { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public TaskStatus? taskStatus { get; set; }
    }
}
