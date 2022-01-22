using System;
using System.Diagnostics;
using TodoAPI_MinimalAPI.Model;
namespace TodoAPI_MinimalAPI.Services
{
    public class TasksService : ITasksService
    {
        private readonly Dictionary<Guid, Model.Task> _tasksList = new Dictionary<Guid, Model.Task>();

        public TasksService()
        {
            /*Sample data generating*/
            var task1 = new Model.Task("Prepare dinner");
            var task2 = new Model.Task("Wash dishes");
            var task3 = new Model.Task("Buy gift for parents");
            var task4 = new Model.Task("Take medicine", true);
            var task5 = new Model.Task("Do homework");
            var task6 = new Model.Task("Call Rachel at 5PM");

            CreateTask(task1);
            CreateTask(task2);
            CreateTask(task3);
            CreateTask(task4);
            CreateTask(task5);
            CreateTask(task6);
        }

            public Model.Task GetSpecificTask(Guid guid) => _tasksList.GetValueOrDefault(guid);
        public List<Model.Task> GetAllTasks() => _tasksList.Values.ToList();
        public void CreateTask(Model.Task task) {_tasksList.Add(task.Id, task); }
        public void ModifyTask(Model.Task task) { if (task != null && _tasksList.GetValueOrDefault(task.Id) != null) _tasksList[task.Id] = task; }
        public void RemoveTask(Guid guid) => _tasksList.Remove(guid);

    }
}


