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
TasksRequests.EndpointsManager(app);

app.Run();