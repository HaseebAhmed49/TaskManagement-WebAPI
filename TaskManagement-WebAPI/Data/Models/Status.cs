using System;
namespace TaskManagement_WebAPI.Data.Models
{
    public class Status
    {
        public enum TaskStatus
        {
            NotStarted,
            Pending,
            Completed,
            OnHold
        }
    }
}

