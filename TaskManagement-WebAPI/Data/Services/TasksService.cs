using TaskManagement_WebAPI.Data.Models;

namespace TaskManagement_WebAPI.Data.Services
{
    public class TasksService
    {
        private readonly AppDbContext _context;

        public TasksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTasks(TaskDataVM task)
        {
            var taskDetails = new TaskData()
            {
                taskName = task.taskName,
                startDate = task.startDate,
                endDate = task.endDate
            };
            _context.Tasks.Add(taskDetails);
            _context.SaveChanges();
        }

        public List<TaskDatawithIdVM> GetAllTasks()
        {
            List<TaskDatawithIdVM> taskDataVMs = new List<TaskDatawithIdVM>();
            var tasks = _context.Tasks.ToList();
            if(tasks.Count>0)
            {
                foreach(var item in tasks)
                {
                    var _tasksdetails = _context.Tasks.Where(x => x.id == item.id).Select(task => new TaskDatawithIdVM()
                    {
                        id = task.id,
                        taskName=task.taskName,
                        startDate=task.startDate, 
                        endDate=task.endDate
                    }).FirstOrDefault();
                    taskDataVMs.Add(_tasksdetails);
                }
            }
            return taskDataVMs;
        }

        public TaskData UpdateTaskDetails(int id,TaskDataVM task)
        {
            var taskdata = _context.Tasks.FirstOrDefault(x => x.id == id);
            if(taskdata!=null)
            {
                taskdata.startDate = task.startDate;
                taskdata.endDate = task.endDate;
                taskdata.taskName = task.taskName;
                _context.SaveChanges();
            }
            return taskdata;
        }

        public void DeleteTask(int id)
        {
            var taskdata = _context.Tasks.FirstOrDefault(x => x.id == id);
            if (taskdata != null)
            {
                _context.Tasks.Remove(taskdata);
                _context.SaveChanges();
            }
        }
    }
}
