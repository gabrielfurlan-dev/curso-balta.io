using Microsoft.EntityFrameworkCore;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Repositories.Contracts;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // builder.Services.AddDbContext<DataContext>(opt => opt.USeSqlServer(Configuration.GetConnectionString("connectionString")));
        builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
        // builder.Services.AddTransient<ITodoRepository, TodoRepository>();
        builder.Services.AddTransient<ToDoHandler, ToDoHandler>();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}