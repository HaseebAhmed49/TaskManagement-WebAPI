using TaskManagement_WebAPI.Data.Models;

namespace TaskManagement_WebAPI.Data.Services
{
    public interface ITaskService
    {
        public void AddTasks(TaskDataVM task);

        public List<TaskDatawithIdVM> GetAllTasks();

        public TaskData UpdateTaskDetails(int id, TaskDataVM task);

        public void DeleteTask(int id);


    }
}
