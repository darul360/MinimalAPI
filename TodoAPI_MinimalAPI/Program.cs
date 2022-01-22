using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TodoAPI_MinimalAPI.Services;
using TodoAPI_MinimalAPI.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITasksService, TasksService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/tasksList", (ITasksService service) => service.GetAllTasks());
app.MapGet("/tasksList/{id}", (ITasksService service, [FromRoute]Guid id) => service.GetSpecificTask(id));
app.MapPost("/tasksList", (ITasksService service, [FromBody] TodoAPI_MinimalAPI.Model.Task task ) => service.CreateTask(task));
app.MapPut("/tasksList", (ITasksService service, [FromBody] TodoAPI_MinimalAPI.Model.Task task) => service.ModifyTask(task));
app.MapDelete("/tasksList/{id}", (ITasksService service, [FromRoute] Guid id) => service.RemoveTask(id));

app.Run();