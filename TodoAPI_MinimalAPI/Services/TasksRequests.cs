using System;
namespace TodoAPI_MinimalAPI.Services
{
	public class TasksRequests
	{
		public static void EndpointsManager(WebApplication app)
        {
			app.MapGet("/tasksList", TasksRequests.GetAllTasks)
				.Produces<List<Model.Task>>()
				.Produces(StatusCodes.Status204NoContent);
			app.MapGet("/tasksList/{id}", TasksRequests.GetSpecificTask)
				.Produces<Model.Task>()
				.Produces(StatusCodes.Status404NotFound);
			app.MapPost("/tasksList", TasksRequests.CreateTask)
				.Produces(StatusCodes.Status201Created)
				.Accepts<Model.Task>("application/json");
			app.MapPut("/tasksList", TasksRequests.ModifyTask)
				.Produces(StatusCodes.Status200OK)
				.Produces(StatusCodes.Status400BadRequest)
				.Accepts<Model.Task>("application/json");
			app.MapDelete("/tasksList/{id}", TasksRequests.RemoveTask)
				.Produces(StatusCodes.Status204NoContent)
				.Produces(StatusCodes.Status404NotFound);
		}

		public static IResult GetAllTasks(ITasksService tasksService)
        {
			var result = tasksService.GetAllTasks();

			if (result.Count == 0)
				return Results.NoContent();
			return Results.Ok(result);
        }

		public static IResult GetSpecificTask(ITasksService tasksService, Guid guid)
        {
			var result = tasksService.GetSpecificTask(guid);
			if (result == null) return Results.NotFound();
			return Results.Ok(result);
        }

		public static IResult CreateTask(ITasksService tasksService, Model.Task task)
        {
            
			tasksService.CreateTask(task);
			return Results.Created($"/tasksList/{task.Id}", task);
        }

		public static IResult ModifyTask(ITasksService tasksService, Model.Task task)
		{
			if (tasksService.GetSpecificTask(task.Id) == null)
				return Results.BadRequest();

			tasksService.ModifyTask(task);
			return Results.Ok();
		}

		public static IResult RemoveTask(ITasksService tasksService, Guid guid)
        {
			if(tasksService.GetSpecificTask(guid) == null)
				return Results.NotFound();
			tasksService.RemoveTask(guid);
			return Results.NoContent();
		}


		public TasksRequests()
		{
		}
	}
}

