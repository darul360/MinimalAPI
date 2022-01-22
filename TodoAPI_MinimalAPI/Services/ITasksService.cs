
namespace TodoAPI_MinimalAPI.Services
{
    public interface ITasksService
    {
        void CreateTask(Model.Task task);
        List<Model.Task> GetAllTasks();
        Model.Task GetSpecificTask(Guid guid);
        void ModifyTask(Model.Task task);
        void RemoveTask(Guid guid);
    }
}