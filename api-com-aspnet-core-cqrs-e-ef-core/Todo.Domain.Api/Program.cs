using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Commands.Handlers;
using ToDo.Domain.Infra.Contexts;
using ToDo.Domain.Infra.Repositories.ToDo;
using ToDo.Domain.Repositories.Contracts;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // builder.Services.AddDbContext<DataContext>(opt => opt.USeSqlServer(Configuration.GetConnectionString("connectionString")));
        builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
        
        builder.Services.AddTransient<IToDoRepository, ToDoRepository>();
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
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(x => x.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin());

        app.UseAuthorization();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.MapControllers();

        app.Run();
    }
}