using ApplicationLayer.Services.TaskServices;
using DomainLayer.Models;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositorio.Commons;
using InfrastructureLayer.Repositorio.TaskRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoApiContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListDB"));
});

builder.Services.AddScoped<ICommonsProcess<Tareas>, TaskRepository>();
builder.Services.AddControllers();
builder.Services.AddScoped<TaskService>();
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TodoApiContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Todo API V1");
        
    } );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
